/*
 * Created by SharpDevelop.
 * User: Mirzakhmet
 * Date: 6/18/2022
 * Time: 8:04 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Alumni
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TabControl tabControlMain;
		private System.Windows.Forms.TabPage tabPageSettings;
		private System.Windows.Forms.TabPage tabPageAbout;
		private System.Windows.Forms.MenuStrip menuStripMain;
		private System.Windows.Forms.StatusStrip statusStripMain;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelMain;
		private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.Label labelIPAddress;
		private System.Windows.Forms.Label labelPort;
		private System.Windows.Forms.Label labelMaxClients;
		private System.Windows.Forms.TextBox textBoxIPAddress;
		private System.Windows.Forms.TextBox textBoxPort;
		private System.Windows.Forms.TextBox textBoxMaxClients;
		private System.Windows.Forms.Label labelAbout;
		private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
		private System.Windows.Forms.Label labelDirectories;
		private System.Windows.Forms.ListBox listBoxDirectories;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.Button buttonRemoveDirectory;
		private System.Windows.Forms.Button buttonAddDirectory;
		private System.Windows.Forms.OpenFileDialog openConfigurationFileDialog;
		private System.Windows.Forms.SaveFileDialog saveConfigurationFileDialog;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.tabControlMain = new System.Windows.Forms.TabControl();
			this.tabPageSettings = new System.Windows.Forms.TabPage();
			this.buttonRemoveDirectory = new System.Windows.Forms.Button();
			this.buttonAddDirectory = new System.Windows.Forms.Button();
			this.listBoxDirectories = new System.Windows.Forms.ListBox();
			this.labelDirectories = new System.Windows.Forms.Label();
			this.textBoxMaxClients = new System.Windows.Forms.TextBox();
			this.textBoxPort = new System.Windows.Forms.TextBox();
			this.textBoxIPAddress = new System.Windows.Forms.TextBox();
			this.labelMaxClients = new System.Windows.Forms.Label();
			this.labelPort = new System.Windows.Forms.Label();
			this.labelIPAddress = new System.Windows.Forms.Label();
			this.tabPageAbout = new System.Windows.Forms.TabPage();
			this.labelAbout = new System.Windows.Forms.Label();
			this.menuStripMain = new System.Windows.Forms.MenuStrip();
			this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStripMain = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabelMain = new System.Windows.Forms.ToolStripStatusLabel();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.openConfigurationFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveConfigurationFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.tabControlMain.SuspendLayout();
			this.tabPageSettings.SuspendLayout();
			this.tabPageAbout.SuspendLayout();
			this.menuStripMain.SuspendLayout();
			this.statusStripMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControlMain
			// 
			this.tabControlMain.Controls.Add(this.tabPageSettings);
			this.tabControlMain.Controls.Add(this.tabPageAbout);
			this.tabControlMain.Location = new System.Drawing.Point(12, 27);
			this.tabControlMain.Name = "tabControlMain";
			this.tabControlMain.SelectedIndex = 0;
			this.tabControlMain.Size = new System.Drawing.Size(401, 266);
			this.tabControlMain.TabIndex = 0;
			// 
			// tabPageSettings
			// 
			this.tabPageSettings.Controls.Add(this.buttonRemoveDirectory);
			this.tabPageSettings.Controls.Add(this.buttonAddDirectory);
			this.tabPageSettings.Controls.Add(this.listBoxDirectories);
			this.tabPageSettings.Controls.Add(this.labelDirectories);
			this.tabPageSettings.Controls.Add(this.textBoxMaxClients);
			this.tabPageSettings.Controls.Add(this.textBoxPort);
			this.tabPageSettings.Controls.Add(this.textBoxIPAddress);
			this.tabPageSettings.Controls.Add(this.labelMaxClients);
			this.tabPageSettings.Controls.Add(this.labelPort);
			this.tabPageSettings.Controls.Add(this.labelIPAddress);
			this.tabPageSettings.Location = new System.Drawing.Point(4, 22);
			this.tabPageSettings.Name = "tabPageSettings";
			this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageSettings.Size = new System.Drawing.Size(393, 240);
			this.tabPageSettings.TabIndex = 0;
			this.tabPageSettings.Text = "Settings";
			this.tabPageSettings.UseVisualStyleBackColor = true;
			// 
			// buttonRemoveDirectory
			// 
			this.buttonRemoveDirectory.Location = new System.Drawing.Point(342, 201);
			this.buttonRemoveDirectory.Name = "buttonRemoveDirectory";
			this.buttonRemoveDirectory.Size = new System.Drawing.Size(25, 22);
			this.buttonRemoveDirectory.TabIndex = 9;
			this.buttonRemoveDirectory.Text = "-";
			this.buttonRemoveDirectory.UseVisualStyleBackColor = true;
			this.buttonRemoveDirectory.Click += new System.EventHandler(this.ButtonRemoveDirectoryClick);
			// 
			// buttonAddDirectory
			// 
			this.buttonAddDirectory.Location = new System.Drawing.Point(342, 154);
			this.buttonAddDirectory.Name = "buttonAddDirectory";
			this.buttonAddDirectory.Size = new System.Drawing.Size(25, 24);
			this.buttonAddDirectory.TabIndex = 8;
			this.buttonAddDirectory.Text = "+";
			this.buttonAddDirectory.UseVisualStyleBackColor = true;
			this.buttonAddDirectory.Click += new System.EventHandler(this.ButtonAddDirectoryClick);
			// 
			// listBoxDirectories
			// 
			this.listBoxDirectories.FormattingEnabled = true;
			this.listBoxDirectories.HorizontalScrollbar = true;
			this.listBoxDirectories.Location = new System.Drawing.Point(42, 128);
			this.listBoxDirectories.Name = "listBoxDirectories";
			this.listBoxDirectories.Size = new System.Drawing.Size(288, 95);
			this.listBoxDirectories.TabIndex = 7;
			// 
			// labelDirectories
			// 
			this.labelDirectories.Location = new System.Drawing.Point(42, 111);
			this.labelDirectories.Name = "labelDirectories";
			this.labelDirectories.Size = new System.Drawing.Size(116, 18);
			this.labelDirectories.TabIndex = 6;
			this.labelDirectories.Text = "Directories:";
			// 
			// textBoxMaxClients
			// 
			this.textBoxMaxClients.Location = new System.Drawing.Point(204, 89);
			this.textBoxMaxClients.Name = "textBoxMaxClients";
			this.textBoxMaxClients.Size = new System.Drawing.Size(126, 20);
			this.textBoxMaxClients.TabIndex = 5;
			this.textBoxMaxClients.Text = "50";
			this.textBoxMaxClients.Visible = false;
			// 
			// textBoxPort
			// 
			this.textBoxPort.Location = new System.Drawing.Point(204, 63);
			this.textBoxPort.Name = "textBoxPort";
			this.textBoxPort.Size = new System.Drawing.Size(126, 20);
			this.textBoxPort.TabIndex = 4;
			this.textBoxPort.Text = "80";
			// 
			// textBoxIPAddress
			// 
			this.textBoxIPAddress.Location = new System.Drawing.Point(204, 26);
			this.textBoxIPAddress.Name = "textBoxIPAddress";
			this.textBoxIPAddress.Size = new System.Drawing.Size(126, 20);
			this.textBoxIPAddress.TabIndex = 3;
			this.textBoxIPAddress.Text = "127.0.0.1";
			// 
			// labelMaxClients
			// 
			this.labelMaxClients.Location = new System.Drawing.Point(42, 92);
			this.labelMaxClients.Name = "labelMaxClients";
			this.labelMaxClients.Size = new System.Drawing.Size(116, 19);
			this.labelMaxClients.TabIndex = 2;
			this.labelMaxClients.Text = "Maximum clients (per):";
			this.labelMaxClients.Visible = false;
			// 
			// labelPort
			// 
			this.labelPort.Location = new System.Drawing.Point(42, 61);
			this.labelPort.Name = "labelPort";
			this.labelPort.Size = new System.Drawing.Size(116, 22);
			this.labelPort.TabIndex = 1;
			this.labelPort.Text = "Port:";
			// 
			// labelIPAddress
			// 
			this.labelIPAddress.Location = new System.Drawing.Point(42, 26);
			this.labelIPAddress.Name = "labelIPAddress";
			this.labelIPAddress.Size = new System.Drawing.Size(116, 17);
			this.labelIPAddress.TabIndex = 0;
			this.labelIPAddress.Text = "IP Address:";
			// 
			// tabPageAbout
			// 
			this.tabPageAbout.Controls.Add(this.labelAbout);
			this.tabPageAbout.Location = new System.Drawing.Point(4, 22);
			this.tabPageAbout.Name = "tabPageAbout";
			this.tabPageAbout.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageAbout.Size = new System.Drawing.Size(393, 240);
			this.tabPageAbout.TabIndex = 2;
			this.tabPageAbout.Text = "About";
			this.tabPageAbout.UseVisualStyleBackColor = true;
			// 
			// labelAbout
			// 
			this.labelAbout.Location = new System.Drawing.Point(21, 25);
			this.labelAbout.Name = "labelAbout";
			this.labelAbout.Size = new System.Drawing.Size(133, 29);
			this.labelAbout.TabIndex = 0;
			this.labelAbout.Text = "2022 - M.S.-Developers";
			// 
			// menuStripMain
			// 
			this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.configurationToolStripMenuItem,
			this.serverToolStripMenuItem});
			this.menuStripMain.Location = new System.Drawing.Point(0, 0);
			this.menuStripMain.Name = "menuStripMain";
			this.menuStripMain.Size = new System.Drawing.Size(425, 24);
			this.menuStripMain.TabIndex = 1;
			this.menuStripMain.Text = "menuStrip1";
			// 
			// configurationToolStripMenuItem
			// 
			this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.loadToolStripMenuItem,
			this.saveToolStripMenuItem});
			this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
			this.configurationToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
			this.configurationToolStripMenuItem.Text = "Configuration";
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
			this.loadToolStripMenuItem.Text = "Load...";
			this.loadToolStripMenuItem.Click += new System.EventHandler(this.LoadToolStripMenuItemClick);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
			this.saveToolStripMenuItem.Text = "Save...";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
			// 
			// serverToolStripMenuItem
			// 
			this.serverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.runToolStripMenuItem,
			this.stopToolStripMenuItem});
			this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
			this.serverToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
			this.serverToolStripMenuItem.Text = "Server";
			// 
			// runToolStripMenuItem
			// 
			this.runToolStripMenuItem.Name = "runToolStripMenuItem";
			this.runToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
			this.runToolStripMenuItem.Text = "Run";
			this.runToolStripMenuItem.Click += new System.EventHandler(this.RunToolStripMenuItemClick);
			// 
			// stopToolStripMenuItem
			// 
			this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
			this.stopToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
			this.stopToolStripMenuItem.Text = "Stop";
			this.stopToolStripMenuItem.Click += new System.EventHandler(this.StopToolStripMenuItemClick);
			// 
			// statusStripMain
			// 
			this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolStripStatusLabelMain});
			this.statusStripMain.Location = new System.Drawing.Point(0, 296);
			this.statusStripMain.Name = "statusStripMain";
			this.statusStripMain.Size = new System.Drawing.Size(425, 22);
			this.statusStripMain.TabIndex = 2;
			this.statusStripMain.Text = "statusStrip1";
			// 
			// toolStripStatusLabelMain
			// 
			this.toolStripStatusLabelMain.Name = "toolStripStatusLabelMain";
			this.toolStripStatusLabelMain.Size = new System.Drawing.Size(0, 17);
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "CSV files(*.csv)|*.csv|All files(*.*)|*.*";
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.Filter = "CSV files(*.csv)|*.csv|All files(*.*)|*.*";
			// 
			// openConfigurationFileDialog
			// 
			this.openConfigurationFileDialog.Filter = "CFG files(*.cfg)|*.cfg|All files(*.*)|*.*";
			// 
			// saveConfigurationFileDialog
			// 
			this.saveConfigurationFileDialog.Filter = "CFG files(*.cfg)|*.cfg|All files(*.*)|*.*";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(425, 318);
			this.Controls.Add(this.statusStripMain);
			this.Controls.Add(this.tabControlMain);
			this.Controls.Add(this.menuStripMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStripMain;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.Text = "Alumni Web Server";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosed);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.Shown += new System.EventHandler(this.MainFormShown);
			this.tabControlMain.ResumeLayout(false);
			this.tabPageSettings.ResumeLayout(false);
			this.tabPageSettings.PerformLayout();
			this.tabPageAbout.ResumeLayout(false);
			this.menuStripMain.ResumeLayout(false);
			this.menuStripMain.PerformLayout();
			this.statusStripMain.ResumeLayout(false);
			this.statusStripMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
