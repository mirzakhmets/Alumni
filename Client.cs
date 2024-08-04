
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Alumni
{
  public class Client
  {
    public Server server;
    public TcpClient client;
    public Thread thread;

    public Client(Server server, TcpClient client)
    {
      this.server = server;
      this.client = client;
      this.thread = new Thread(new ParameterizedThreadStart(this.Run));
    }

    public void Start() {
    	this.thread.Start();
    }

    public void Stop()
    {
      this.thread.Abort();
      this.client.Close();
    }

    private void WriteNetworkStream(NetworkStream ns, string s)
    {
      ns.Write(Encoding.Default.GetBytes(s), 0, Encoding.Default.GetBytes(s).Length);
    }

    public void Run(object o)
    {
      Thread.Yield();
      NetworkStream stream = this.client.GetStream();
      byte[] numArray = new byte[1024];
      string str1 = "";
      while (stream.DataAvailable && stream.Read(numArray, 0, numArray.Length) > 0)
        str1 += Encoding.Default.GetString(numArray, 0, numArray.Length);
      string str2 = "";
      string str3 = "";
      if (str1.IndexOf('\n') >= 0)
      {
        str2 = str1.Substring(0, str1.IndexOf('\n')).Trim();
        str3 = str1.Substring(checked (str1.IndexOf('\n') + 1));
      }
      string[] strArray = str2.Split(' ');
      if (strArray.Length >= 2)
      {
        Request request = new Request(strArray[1], strArray[0]);
        if (strArray[1].Equals("/"))
          request.Path = "index.html";
        foreach (Source source in this.server.Sources)
        {
          string key = (string) null;
          string str4 = (string) null;
          if (str3.IndexOf("Authorization: Basic ") >= 0)
          {
            string str5 = str3.Substring(checked (str3.IndexOf("Authorization: Basic ") + "Authorization: Basic ".Length));
            string str6 = Encoding.Default.GetString(Convert.FromBase64String(str5.Substring(0, str5.IndexOf('\n'))));
            if (str6.IndexOf(':') >= 0)
            {
              key = str6.Substring(0, str6.IndexOf(':'));
              str4 = str6.Substring(checked (str6.IndexOf(':') + 1));
            }
          }
          if (source.Authorization != null)
          {
            bool flag = false;
            if (key != null && str4 != null && source.Authorization.Users.ContainsKey(key) && source.Authorization.Users[key].Password.Equals(str4))
              flag = true;
            if (!flag)
            {
              this.WriteNetworkStream(stream, "HTTP/1.1 401 Unauthorized\r\n");
              this.WriteNetworkStream(stream, "WWW-Authenticate: Basic realm=\"Alumni Web Server\"\r\n");
              stream.Close();
              this.client.Close();
              return;
            }
          }
          if (File.Exists(source.Path + "/" + request.Path) || Directory.Exists(source.Path + "/" + request.Path))
          {
            string fullPath = Utils.GetFullPath(source.Path + "/" + request.Path);
            if (fullPath.IndexOf(source.Path) != -1)
            {
              if (Directory.Exists(source.Path + "/" + request.Path))
              {
                this.WriteNetworkStream(stream, "HTTP/1.0 200 OK\r\n");
                this.WriteNetworkStream(stream, "Content-Type: text/html\r\n\r\n");
                this.WriteNetworkStream(stream, "<!DOCTYPE HTML>\r\n");
                this.WriteNetworkStream(stream, "<html>\r\n");
                this.WriteNetworkStream(stream, "<head>\r\n");
                this.WriteNetworkStream(stream, "<title>Directory listing</title>\r\n");
                this.WriteNetworkStream(stream, "</head>\r\n");
                this.WriteNetworkStream(stream, "<body>\r\n");
                foreach (string directory in Directory.GetDirectories(source.Path + "/" + request.Path))
                {
                  string str7 = directory;
                  if (directory.IndexOf(source.Path) == 0)
                    str7 = directory.Substring(source.Path.Length);
                  this.WriteNetworkStream(stream, "<a href=\"" + str7 + "\">" + str7 + "</a><br>\r\n");
                }
                foreach (string file in Directory.GetFiles(source.Path + "/" + request.Path))
                {
                  string str8 = file;
                  if (file.IndexOf(source.Path) == 0)
                    str8 = file.Substring(source.Path.Length);
                  this.WriteNetworkStream(stream, "<a href=\"" + str8 + "\">" + str8 + "</a><br>\r\n");
                }
                this.WriteNetworkStream(stream, "</body>\r\n");
                this.WriteNetworkStream(stream, "</html>\r\n");
                stream.Close();
                this.client.Close();
                return;
              }
              string str9 = (string) null;
              if (fullPath.LastIndexOf('.') >= 0)
              {
                string str10 = fullPath.Substring(fullPath.LastIndexOf('.'));
                if (MIMEType.MIMETypes.ContainsKey(str10.ToLower()))
                  str9 = MIMEType.MIMETypes[str10.ToLower()].Type;
              }
              if (str9 == null)
                str9 = "application/octet-stream";
              this.WriteNetworkStream(stream, "HTTP/1.0 200 OK\r\n");
              this.WriteNetworkStream(stream, "Content-Type: " + str9 + "\r\n");
              this.WriteNetworkStream(stream, "Connection: close\r\n");
              string s = File.ReadAllText(fullPath);
              this.WriteNetworkStream(stream, "Content-Length: " + (object) s.Length + "\r\n\r\n");
              this.WriteNetworkStream(stream, s);
              stream.Close();
              this.client.Close();
              return;
            }
          }
          else if (source.CGI.IndexOf(request.Path) >= 0 && source.CGI.Length > 0)
          {
            ProcessStartInfo processStartInfo = new ProcessStartInfo(source.Path);
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.UseShellExecute = false;
            Process process = new Process();
            process.StartInfo = processStartInfo;
            process.Start();
            process.StandardInput.Write(str1);
            process.WaitForExit();
            if (process.ExitCode == 0)
            {
              string end = process.StandardOutput.ReadToEnd();
              this.WriteNetworkStream(stream, "HTTP/1.0 200 OK\r\nConnection: close\r\n" + end);
            }
            else
              this.NotFound(stream);
            stream.Close();
            this.client.Close();
            return;
          }
        }
      }
      this.NotFound(stream);
      stream.Close();
      this.client.Close();
    }

    public void NotFound(NetworkStream ns)
    {
      this.WriteNetworkStream(ns, "HTTP/1.0 400 Not found\r\nContent-Type: text/html\r\n\r\n400: File not found<hr>Alumni Web Server");
    }
  }
}
