
using System.IO;

namespace Alumni
{
  public class ParsingStream
  {
    public Stream stream;
    public int current = -1;

    public ParsingStream(Stream stream)
    {
      this.stream = stream;
      this.Read();
    }

    public void Read() {
    	this.current = (int) this.stream.ReadByte();
    }

    public bool atEnd() {
    	return this.current == -1;
    }

    public void parseBlanks()
    {
      while (" \r\t\v".IndexOf(checked ((char) this.current)) >= 0)
        this.Read();
    }
  }
}
