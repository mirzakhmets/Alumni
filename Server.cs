
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Alumni
{
  public class Server
  {
    public int Port;
    public IPAddress ipAddress;
    public TcpListener Listener;
    public Stack<Client> Queue = new Stack<Client>();
    public Thread ListenerThread;
    public Thread QueueThread;
    public int MaxQueue = -1;
    public List<Source> Sources = new List<Source>();

    public Server(int Port, string ipAddress, int MaxQueue)
    {
      this.Port = Port;
      this.ipAddress = IPAddress.Parse(ipAddress);
      this.ListenerThread = new Thread(new ThreadStart(this.Run));
      this.QueueThread = new Thread(new ThreadStart(this.RunQueue));
    }

    public void Start()
    {
      this.ListenerThread.Start();
      this.QueueThread.Start();
    }

    public void Stop()
    {
      this.Listener.Stop();
      this.ListenerThread.Abort();
      this.QueueThread.Abort();
      while (this.Queue.Count > 0)
        this.Queue.Pop().Stop();
    }

    public void Run()
    {
      this.Listener = new TcpListener(this.ipAddress, this.Port);
      this.Listener.Start();
      while (true)
      {
        Thread.Yield();
        TcpClient client = this.Listener.AcceptTcpClient();
        if (client != null)
        {
          if (this.Queue.Count < this.MaxQueue || this.MaxQueue == -1)
            this.Queue.Push(new Client(this, client));
          else
            client.Close();
        }
      }
    }

    public void RunQueue()
    {
      while (true)
      {
        Client client = (Client) null;
        Thread.Yield();
        if (this.Queue.Count > 0)
          client = this.Queue.Pop();
        if (client != null)
        	client.Start();
      }
    }

    public void AddSource(string filename)
    {
      CSVFile csvFile = new CSVFile(new ParsingStream((Stream) System.IO.File.Open(filename, FileMode.Open)), filename);
      int index1 = csvFile.namesIndex["Location"];
      int index2 = csvFile.namesIndex["CGI"];
      int index3 = csvFile.namesIndex["Authorization"];
      int index4 = 0;
      while (index4 < csvFile.lines.Count)
      {
        Authorization Authorization = (Authorization) null;
        if (index3 < csvFile.lines[index4].values.Count)
          Authorization = new Authorization(csvFile.lines[index4].values[index3]);
        string Path = (string) null;
        string CGI = (string) null;
        if (index1 < csvFile.lines[index4].values.Count)
          Path = csvFile.lines[index4].values[index1];
        if (index2 < csvFile.lines[index4].values.Count)
          CGI = csvFile.lines[index4].values[index2];
        this.Sources.Add(new Source(Path, CGI, Authorization));
        checked { ++index4; }
      }
    }
  }
}
