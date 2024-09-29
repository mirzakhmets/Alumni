
using System.Collections.Generic;

namespace Alumni
{
  public class CSVLine
  {
    public List<string> values = new List<string>();

    public CSVLine(ParsingStream stream)
    {
      while (!stream.atEnd())
      {
        this.values.Add(this.parseValue(stream));
        if (stream.current == 10)
        {
          stream.Read();
          break;
        }
      }
    }

    public string parseValue(ParsingStream stream)
    {
      string str = "";
      stream.parseBlanks();
      int num = -1;
      if (stream.current == 34 || stream.current == 39)
      {
        num = stream.current;
        stream.Read();
      }
      if (num == -1)
      {
        while (!stream.atEnd() && ",;".IndexOf(checked ((char) stream.current)) == -1 && stream.current != 10)
        {
          if (stream.current == 92 && num != -1)
          {
            stream.Read();
            if (!stream.atEnd())
	            str += ((char) stream.current);
          }
          else
            str += ((char) stream.current);
          stream.Read();
        }
      }
      else
      {
        while (!stream.atEnd() && stream.current != 10 && stream.current != num && ",;".IndexOf(checked ((char) stream.current)) == -1)
        {
          if (stream.current == 92)
          {
            stream.Read();
            
            if (!stream.atEnd())
	            str += ((char) stream.current);
          }
          else
            str += ((char) stream.current);
          stream.Read();
        }
        if (stream.current == num)
          stream.Read();
      }
      stream.parseBlanks();
      if (",; \t".IndexOf(checked ((char) stream.current)) >= 0)
        stream.Read();
      stream.parseBlanks();
      return str.Trim();
    }
  }
}
