/*
 * Created by SharpDevelop.
 * User: Mirzakhmet
 * Date: 6/29/2022
 * Time: 2:47 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Alumni
{
	/// <summary>
	/// User.
	/// </summary>
	public class User
	{
		public string Username, Password;
		
		public User(string Username, string Password)
		{
			this.Username = Username;
			
			this.Password = Password;
		}
	}
}
