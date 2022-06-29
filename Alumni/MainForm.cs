/*
 * Created by SharpDevelop.
 * User: Mirzakhmet
 * Date: 6/18/2022
 * Time: 8:04 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Alumni
{
	/// <summary>
	/// Main form.
	/// </summary>
	public partial class MainForm : Form
	{
		public Server server;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void ButtonRunClick(object sender, EventArgs e)
		{
			if (this.server != null) {
				this.server.Stop();
			}
			
			this.server = new Server(Int32.Parse(this.textBoxPort.Text), this.textBoxIPAddress.Text, Int32.Parse(this.textBoxMaxClients.Text));
			
			foreach (object o in this.listBoxDirectories.Items) {
				this.server.AddSource(o.ToString());
			}
			
			this.server.Start();
		}
		
		void ButtonStopClick(object sender, EventArgs e)
		{
			if (this.server != null) {
				this.server.Stop();
				
				this.server = null;
			}
		}
		
		void RunToolStripMenuItemClick(object sender, EventArgs e)
		{
			ButtonRunClick(sender, e);
			
			//System.Windows.Forms.MessageBox.Show(Utils.GetFullPath("http://localhost/a+b/%20%20cdef/gh"));
		}
		
		void StopToolStripMenuItemClick(object sender, EventArgs e)
		{
			ButtonStopClick(sender, e);
		}
		
		void ButtonAddDirectoryClick(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK) {
				this.listBoxDirectories.Items.Add(openFileDialog.FileName);
			}
		}
		
		void ButtonRemoveDirectoryClick(object sender, EventArgs e)
		{
			if (listBoxDirectories.SelectedIndex >= 0) {
				listBoxDirectories.Items.Remove(listBoxDirectories.SelectedItem);
			}
		}
		
		void LoadToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (sender == null || this.openConfigurationFileDialog.ShowDialog() == DialogResult.OK) {
				StreamReader sr = null;
				
				if (sender == null) {
					sr = File.OpenText("default.cfg");
				} else {
					sr = File.OpenText(this.openConfigurationFileDialog.FileName);
				}
				this.listBoxDirectories.Items.Clear();
				
				string line = null;
				
				while ((line = sr.ReadLine()) != null) {
					string param = line.Substring(0, line.IndexOf('='));
					
					string value = line.Substring(line.IndexOf('=') + 1);
					
					if (param.Equals("Server.IP")) {
						this.textBoxIPAddress.Text = value;
					} else if (param.Equals("Server.Port")) {
						this.textBoxPort.Text = value;
					} else if (param.Equals("Server.MaxClients")) {
						this.textBoxMaxClients.Text = value;
					} else if (param.IndexOf("Sources[", StringComparison.CurrentCulture) == 0) {
						this.listBoxDirectories.Items.Add(value);
					}
				}
				
				sr.Close();
			}
		}
		
		void SaveToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (this.saveConfigurationFileDialog.ShowDialog() == DialogResult.OK) {
				StreamWriter sw = File.CreateText(this.saveConfigurationFileDialog.FileName);
				
				sw.WriteLine("Server.IP=" + textBoxIPAddress.Text);
				
				sw.WriteLine("Server.Port=" + textBoxPort.Text);
				
				sw.WriteLine("Server.MaxClients=" + textBoxMaxClients.Text);
				
				if (this.listBoxDirectories.Items.Count > 0) {
					sw.WriteLine("Sources.Count=" + this.listBoxDirectories.Items.Count);
					
					for (int i = 0; i < this.listBoxDirectories.Items.Count; ++i) {
						sw.WriteLine("Sources[" + i + "]=" + this.listBoxDirectories.Items[i].ToString());
					}
				}
				
				sw.Close();
			}
		}
		
		void MainFormShown(object sender, EventArgs e)
		{
			
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			MIMEType.InitializeMIMETypes();
			
			if (File.Exists("default.cfg")) {
				LoadToolStripMenuItemClick(null, e);
				
				ButtonRunClick(sender, e);
			}
		}
		
		void MainFormFormClosed(object sender, FormClosedEventArgs e)
		{
			this.ButtonStopClick(sender, e);
		}
	}
}
