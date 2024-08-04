
using System.Collections.Generic;
using System.IO;

namespace Alumni
{
  public class Authorization
  {
    public Dictionary<string, User> Users = new Dictionary<string, User>();

    public Authorization(string filename)
    {
      CSVFile csvFile = new CSVFile(new ParsingStream((Stream) File.Open(filename, FileMode.Open)), filename);
      int index1 = csvFile.namesIndex["User"];
      int index2 = csvFile.namesIndex["Password"];
      int index3 = 0;
      while (index3 < csvFile.lines.Count)
      {
        User user = new User(csvFile.lines[index3].values[index1], csvFile.lines[index3].values[index2]);
        this.Users.Add(user.Username, user);
        checked { ++index3; }
      }
    }
  }
}
