/*
 * Created by SharpDevelop.
 * User: Mirzakhmet
 * Date: 6/29/2022
 * Time: 2:38 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace Alumni
{
	/// <summary>
	/// Authorization.
	/// </summary>
	public class Authorization
	{
		public Dictionary<string, User> Users = new Dictionary<string, User>();
		//public CSVFile File;
		
		public Authorization(string filename)
		{
			ParsingStream ps = new ParsingStream(File.Open(filename, FileMode.Open));
			
			CSVFile file = new CSVFile(ps, filename);
			
			int userIndex = file.namesIndex["User"];
			
			int passIndex = file.namesIndex["Password"];
						
			for (int i = 0; i < file.lines.Count; ++i) {
				User user = new User(file.lines[i].values[userIndex], file.lines[i].values[passIndex]);
				
				Users.Add(user.Username, user);
			}
		}
	}
}
