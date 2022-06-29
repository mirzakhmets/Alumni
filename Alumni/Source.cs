/*
 * Created by SharpDevelop.
 * User: Mirzakhmet
 * Date: 6/29/2022
 * Time: 2:37 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Alumni
{
	/// <summary>
	/// Source.
	/// </summary>
	public class Source
	{
		public string Path;
		public string CGI;
		public Authorization Authorization;
		
		/*
		public Source(string Path) {
			
		}*/
		
		public Source(string Path, string CGI, Authorization Authorization)
		{
			this.Path = Path;
			
			this.CGI = CGI;
			
			this.Authorization = Authorization;
		}
	}
}
