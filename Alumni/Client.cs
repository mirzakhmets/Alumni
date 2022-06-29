/*
 * Created by SharpDevelop.
 * User: Mirzakhmet
 * Date: 6/27/2022
 * Time: 2:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace Alumni
{
	/// <summary>
	/// HTTP client.
	/// </summary>
	public class Client
	{
		public Server server;
		public TcpClient client;
		public Thread thread;
		
		public Client(Server server, TcpClient client)
		{
			this.server = server;
			
			this.client = client;
			
			this.thread = new Thread(this.Run);
		}
		
		public void Start() {
			this.thread.Start();
		}
		
		public void Stop() {
			this.thread.Abort();
			
			this.client.Close();
		}
		
		private void WriteNetworkStream(NetworkStream ns, string s) {
			ns.Write(System.Text.Encoding.Default.GetBytes(s), 0, System.Text.Encoding.Default.GetBytes(s).Length);
		}
		
		public void Run(object o) {
			Thread.Yield();
			
			//Thread.Sleep(1000);

			NetworkStream ns = client.GetStream();
			
			byte[] buffer = new byte[1024];
			
			string readBuffer = "";
			
			while (ns.DataAvailable) {
				int l = ns.Read(buffer, 0, buffer.Length);
				
				if (l > 0) {
					readBuffer += System.Text.Encoding.Default.GetString(buffer, 0, buffer.Length);
				} else {
					break;
				}
			}
			
			string c = "", d = "";
			
			if (readBuffer.IndexOf('\n') >= 0) {
				c = readBuffer.Substring(0, readBuffer.IndexOf('\n')).Trim();
				
				d = readBuffer.Substring(readBuffer.IndexOf('\n') + 1);
			}
			
			string[] cc = c.Split(new char[] { ' ' } );
			
			if (cc.Length >= 2) {
				Request request = new Request(cc[1], cc[0]);
				
				if (cc[1].Equals("/")) {
					request.Path = "index.html";
				} /*else {
					request.Path = cc[1];
				}*/
								
				foreach (Source source in this.server.Sources) {
					if (File.Exists(source.Path + "/" + request.Path)) {
						string fullPath = Utils.GetFullPath(source.Path + "/" + request.Path);
						string username = null, password = null;
						
						if (fullPath.IndexOf(source.Path) == -1) {
							continue;
						}
						
						if (d.IndexOf("Authorization: Basic ") >= 0) {
							string e = d.Substring(d.IndexOf("Authorization: Basic ") + "Authorization: Basic ".Length);
							
							e = e.Substring(0, e.IndexOf('\n'));
							
							e = System.Text.Encoding.Default.GetString(Convert.FromBase64String(e));
							
							if (e.IndexOf(':') >= 0) {
								username = e.Substring(0, e.IndexOf(':'));
								
								password = e.Substring(e.IndexOf(':') + 1);
							}
						}
						
						if (source.Authorization != null) {
							bool authorized = false;
							
							if (username != null && password != null) {
								if (source.Authorization.Users.ContainsKey(username)) {
									if (source.Authorization.Users[username].Password.Equals(password)) {
										authorized = true;
									}
								}
							}
							
							if (!authorized) {
								this.WriteNetworkStream(ns, "HTTP/1.1 401 Unauthorized\r\n");
								
								this.WriteNetworkStream(ns, "WWW-Authenticate: Basic realm=\"Alumni Web Server\"\r\n");
								
								ns.Close();
								
								this.client.Close();
								
								return;
							}
						}
						
						string type = null;
						
						if (fullPath.LastIndexOf('.') >= 0) {
							string extension = fullPath.Substring(fullPath.LastIndexOf('.'));
							
							if (MIMEType.MIMETypes.ContainsKey(extension.ToLower())) {
								type = MIMEType.MIMETypes[extension.ToLower()].Type;
							}
						}
						
						if (type == null) {
							type = "application/octet-stream";
						}
						
						this.WriteNetworkStream(ns, "HTTP/1.0 200 OK\r\n");
						
						this.WriteNetworkStream(ns, "Content-Type: " + type + "\r\n");
						
						string s = File.ReadAllText(fullPath);
						
						this.WriteNetworkStream(ns, "Content-Length: " + s.Length + "\r\n\r\n");
						
						this.WriteNetworkStream(ns, s);
						
						ns.Close();
						
						this.client.Close();
						
						return;
					} else if (source.CGI.IndexOf(request.Path) >= 0 && source.CGI.Length > 0) {
						// CGI
						
						//this.WriteNetworkStream(ns, "HTTP/1.0 200 OK\r\n");
						
						ProcessStartInfo psi = new ProcessStartInfo(source.Path);
						
						psi.WindowStyle = ProcessWindowStyle.Hidden;
						
						psi.RedirectStandardOutput = true;
						
						psi.RedirectStandardInput = true;
						
						psi.UseShellExecute = false;
						
						Process prc = new Process();
						
						prc.StartInfo = psi;
						
						prc.Start();
						
						prc.StandardInput.Write(readBuffer);
						
						prc.WaitForExit();
						
						if (prc.ExitCode == 0) {
							string s = prc.StandardOutput.ReadToEnd();
							
							this.WriteNetworkStream(ns, "HTTP/1.0 200 OK\r\n" + s);
						} else {
							NotFound(ns);
						}
						
						ns.Close();
						
						this.client.Close();
						
						return;
					}
				}
			}
			
			NotFound(ns);
			
			ns.Close();
			
			this.client.Close();
		}
		
		public void NotFound(NetworkStream ns) {
			this.WriteNetworkStream(ns, "HTTP/1.0 400 Not found\r\nContent-Type: text/html\r\n\r\n400: File not found<hr>Alumni Web Server");
		}
	}
}
