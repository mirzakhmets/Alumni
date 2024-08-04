
using System.Collections.Generic;

namespace Alumni
{
  public class Request
  {
    public string Path;
    public Dictionary<string, string> Parameters = new Dictionary<string, string>();
    public string Action;

    public Request(string Url, string Action)
    {
      if (Url.IndexOf('?') >= 0)
      {
        this.Path = Url.Substring(0, Url.IndexOf('?'));
        string[] strArray = Url.Substring(checked (Url.IndexOf('?') + 1)).Split('&');
        int index = 0;
        while (index < strArray.Length)
        {
          int length;
          if ((length = strArray[index].IndexOf('=')) >= 0)
            this.Parameters.Add(Utils.GetURLPath(strArray[index].Substring(0, length)), Utils.GetURLPath(strArray[index].Substring(checked (length + 1))));
          checked { ++index; }
        }
      }
      else
        this.Path = Url;
      if (this.Path.IndexOf('/') == 0)
        this.Path = this.Path.Substring(1);
      this.Action = Action;
    }
  }
}
