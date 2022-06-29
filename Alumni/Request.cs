/*
 * Created by SharpDevelop.
 * User: Mirzakhmet
 * Date: 6/29/2022
 * Time: 3:12 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
//using System.Collections;
using System.Collections.Generic;

namespace Alumni
{
	/// <summary>
	/// HTTP Request.
	/// </summary>
	public class Request
	{
		public string Path;
		public Dictionary<string, string> Parameters = new Dictionary<string, string>();
		public string Action;
		
		public Request(string Url, string Action)
		{
			if (Url.IndexOf('?') >= 0) {
				this.Path = Url.Substring(0, Url.IndexOf('?'));
				
				string[] r = Url.Substring(Url.IndexOf('?') + 1).Split(new char[] { '&' });
				
				for (int i = 0; i < r.Length; ++i) {
					int k = -1;
					
					if ((k = r[i].IndexOf('=')) >= 0) {
						this.Parameters.Add(Utils.GetURLPath(r[i].Substring(0, k)), Utils.GetURLPath(r[i].Substring(k + 1)));
					}
				}
			} else {
				this.Path = Url;
			}
			
			//this.Path = Utils.GetFullPath(this.Path);
			
			if (this.Path.IndexOf('/') == 0) {
				this.Path = this.Path.Substring(1);
			}
			
			this.Action = Action;
		}
	}
}
