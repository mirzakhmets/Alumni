/*
 * Created by SharpDevelop.
 * User: Mirzakhmet
 * Date: 6/27/2022
 * Time: 2:47 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net;
using System.Net.Sockets;
//using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Alumni
{
	/// <summary>
	/// HTTP server.
	/// </summary>
	public class Server
	{
		public int Port;
		public IPAddress ipAddress;
		public TcpListener Listener;
		public Stack<Client> Queue = new Stack<Client>();
		//public List<Thread> Threads = new List<Thread>();
		public Thread ListenerThread;
		public Thread QueueThread;
		public int MaxQueue = -1;
		public List<Source> Sources = new List<Source>();
		
		public Server(int Port, string ipAddress, int MaxQueue)
		{
			this.Port = Port;
			
			this.ipAddress = IPAddress.Parse(ipAddress);
			
			this.ListenerThread = new Thread(this.Run);
			
			this.QueueThread = new Thread(this.RunQueue);
			
			//this.MaxQueue = MaxQueue;
		}
		
		public void Start() {
			//this.Listener = new TcpListener(this.ipAddress, this.Port);
			
			//this.Listener.Start();
			
			this.ListenerThread.Start();
			
			this.QueueThread.Start();
		}
		
		public void Stop() {
			this.Listener.Stop();
			
			this.ListenerThread.Abort();
			
			this.QueueThread.Abort();
			
			while (this.Queue.Count > 0) {
				Client client = this.Queue.Pop();
				
				client.Stop();
			}
		}
		
		public void Run() {
			this.Listener = new TcpListener(this.ipAddress, this.Port);
			
			this.Listener.Start();
			
			while (true) {
				Thread.Yield();
				
				//Thread.Sleep(1000);
				
				//if (this.Listener.Pending()) {
				//	continue;
				//}
				
				TcpClient client = this.Listener.AcceptTcpClient();
				
				if (client != null) {
					//lock (this.Queue)
					{
						if (this.Queue.Count < this.MaxQueue || this.MaxQueue == -1) {
							this.Queue.Push(new Client(this, client));
						} else {
							client.Close();
						}
					}
				}
			}
		}
		
		public void RunQueue() {
			while (true) {
				Client client = null;
				
				Thread.Yield();
				
				//Thread.Sleep(1000);
				
				//lock (this.Queue)
				{
					if (this.Queue.Count > 0) {
						client = this.Queue.Pop();
					}
				}
				
				if (client != null) {
					client.Start();
				}
			}
		}
		
		public void AddSource(string filename) {
			CSVFile file = new CSVFile(new ParsingStream(System.IO.File.Open(filename, System.IO.FileMode.Open)), filename);
			
			int locationIndex = file.namesIndex["Location"];
			
			int cgiIndex = file.namesIndex["CGI"];
			
			int authIndex = file.namesIndex["Authorization"];
			
			for (int i = 0; i < file.lines.Count; ++i) {
				Authorization auth = null;
				
				if (authIndex < file.lines[i].values.Count) {
					auth = new Authorization(file.lines[i].values[authIndex]);
				}
				
				string location = null;
				
				string cgi = null;
				
				if (locationIndex < file.lines[i].values.Count) {
					location = file.lines[i].values[locationIndex];
				}
				
				if (cgiIndex < file.lines[i].values.Count) {
					cgi = file.lines[i].values[cgiIndex];
				}
				
				Source source = new Source(location, cgi, auth);
				
				Sources.Add(source);
			}
		}
	}
}
