/*
 * Created by SharpDevelop.
 * User: Mirzakhmet
 * Date: 6/28/2022
 * Time: 11:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;

namespace Alumni
{
	/// <summary>
	/// Common procedures and functions.
	/// </summary>
	public class Utils
	{
		public static string GetURLPath(string url) {
			string r = url;
			
			if (url.IndexOf("http://", StringComparison.CurrentCulture) == 0) {
				r = url.Substring(7);
				
				if (r.IndexOf('/') >= 0) {
					r = r.Substring(r.IndexOf('/') + 1);
				}
			}
			
			if (url.IndexOf("https://", StringComparison.CurrentCulture) == 0) {
				r = url.Substring(8);
				
				if (r.IndexOf('/') >= 0) {
					r = r.Substring(r.IndexOf('/') + 1);
				}
			}
			
			string result = "";
			
			int i = 0;
			
			string rLower = r.ToLower();
			
			while (i < r.Length) {
				if (r[i] == '%') {
					++i;
					
					int k = -1;
					int l = 0;
					int n = 0;
					
					while ((k = "0123456789abcdef".IndexOf(rLower[i])) >= 0 && i < r.Length && n < 2) {
						l = l * 16 + k;
						
						++i;
						
						++n;
					}
					
					result += (char) l;
				} else if (r[i] == '+') {
					result += ' ';
					
					++i;
				} else {
					result += r[i];
					
					++i;
				}
			}
			
			return result.Replace('\\', '/');
		}
		
		public static string GetFullPath(string path) {
			string result = GetURLPath(path);
			
			if (result.IndexOf(':') == -1 || (result.Length > 0 && result[0] != '/' && result.IndexOf(':') == -1)) {
				result = ".\\" + result;
			}
			
			return Path.GetFullPath(result);
		}
		
		public Utils()
		{
		}
	}
}
