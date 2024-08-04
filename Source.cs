
namespace Alumni
{
  public class Source
  {
    public string Path;
    public string CGI;
    public Authorization Authorization;

    public Source(string Path, string CGI, Authorization Authorization)
    {
      this.Path = Path;
      this.CGI = CGI;
      this.Authorization = Authorization;
    }
  }
}
