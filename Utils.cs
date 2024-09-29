
using System;
using System.IO;

namespace Alumni
{
  public class Utils
  {
    public static string GetURLPath(string url)
    {
    
      string str1 = url;
      if (url.IndexOf("http://", StringComparison.CurrentCulture) == 0)
      {
        str1 = url.Substring(7);
        if (str1.IndexOf('/') >= 0)
          str1 = str1.Substring(checked (str1.IndexOf('/') + 1));
      }
      if (url.IndexOf("https://", StringComparison.CurrentCulture) == 0)
      {
        str1 = url.Substring(8);
        if (str1.IndexOf('/') >= 0)
          str1 = str1.Substring(checked (str1.IndexOf('/') + 1));
      }
      string str2 = "";
      int index = 0;
      string lower = str1.ToLower();
      while (index < str1.Length)
      {
        if (str1[index] == '%')
        {
          checked { ++index; }
          int num1 = 0;
          int num2 = 0;
          int num3;
          while ((num3 = "0123456789abcdef".IndexOf(lower[index])) >= 0 && index < str1.Length && num2 < 2)
          {
            num1 = checked (num1 * 16 + num3);
            checked { ++index; }
            checked { ++num2; }
          }
          str2 += ((char) num1);
        }
        else if (str1[index] == '+')
        {
          str2 += ' ';
          checked { ++index; }
        }
        else
        {
          str2 += str1[index];
          checked { ++index; }
        }
      }
      return str2.Replace('\\', '/');
    }

    public static string GetFullPath(string path)
    {
      string path1 = Utils.GetURLPath(path);
      if (path1.IndexOf(':') == -1 || path1.Length > 0 && path1[0] != '/' && path1.IndexOf(':') == -1)
        path1 = ".\\" + path1;
      return Path.GetFullPath(path1);
    }
  }
}
