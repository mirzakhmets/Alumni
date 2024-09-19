
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Alumni
{
  public class MainForm : Form
  {
    public Server server;
    private IContainer components = (IContainer) null;
    private TabControl tabControlMain;
    private TabPage tabPageSettings;
    private TabPage tabPageAbout;
    private MenuStrip menuStripMain;
    private StatusStrip statusStripMain;
    private ToolStripStatusLabel toolStripStatusLabelMain;
    private ToolStripMenuItem configurationToolStripMenuItem;
    private ToolStripMenuItem loadToolStripMenuItem;
    private ToolStripMenuItem saveToolStripMenuItem;
    private Label labelIPAddress;
    private Label labelPort;
    private Label labelMaxClients;
    private TextBox textBoxIPAddress;
    private TextBox textBoxPort;
    private TextBox textBoxMaxClients;
    private Label labelAbout;
    private ToolStripMenuItem serverToolStripMenuItem;
    private ToolStripMenuItem runToolStripMenuItem;
    private ToolStripMenuItem stopToolStripMenuItem;
    private Label labelDirectories;
    private ListBox listBoxDirectories;
    private OpenFileDialog openFileDialog;
    private SaveFileDialog saveFileDialog;
    private Button buttonRemoveDirectory;
    private Button buttonAddDirectory;
    private OpenFileDialog openConfigurationFileDialog;
    private SaveFileDialog saveConfigurationFileDialog;

    public void CheckRuns() {
		try {
			RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\OVG-Developers", true);
			
			int runs = -1;
			
			if (key != null && key.GetValue("Runs") != null) {
				runs = (int) key.GetValue("Runs");
			} else {
				key = Registry.CurrentUser.CreateSubKey("Software\\OVG-Developers");
			}
			
			runs = runs + 1;
			
			key.SetValue("Runs", runs);
			
			if (runs > 10) {
				System.Windows.Forms.MessageBox.Show("Number of runs expired.\n"
							+ "Please register the application (visit https://ovg-developers.mystrikingly.com/ for purchase).");
				
				Environment.Exit(0);
			}
		} catch (Exception e) {
			Console.WriteLine(e.Message);
		}
	}
	
	public bool IsRegistered() {
		try {
			RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\OVG-Developers");
			
			if (key != null && key.GetValue("Registered") != null) {
				return true;
			}
		} catch (Exception e) {
			Console.WriteLine(e.Message);
		}
		
		return false;
	}
	
    public MainForm() {
    	this.InitializeComponent();    	
    }

    private void ButtonRunClick(object sender, EventArgs e)
    {
      if (this.server != null)
        this.server.Stop();
      this.server = new Server(int.Parse(this.textBoxPort.Text), this.textBoxIPAddress.Text, int.Parse(this.textBoxMaxClients.Text));
      foreach (object obj in this.listBoxDirectories.Items)
        this.server.AddSource(obj.ToString());
      this.server.Start();
    }

    private void ButtonStopClick(object sender, EventArgs e)
    {
      if (this.server == null)
        return;
      this.server.Stop();
      this.server = (Server) null;
    }

    private void RunToolStripMenuItemClick(object sender, EventArgs e)
    {
      this.ButtonRunClick(sender, e);
    }

    private void StopToolStripMenuItemClick(object sender, EventArgs e)
    {
      this.ButtonStopClick(sender, e);
    }

    private void ButtonAddDirectoryClick(object sender, EventArgs e)
    {
      if (this.openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      this.listBoxDirectories.Items.Add((object) this.openFileDialog.FileName);
    }

    private void ButtonRemoveDirectoryClick(object sender, EventArgs e)
    {
      if (this.listBoxDirectories.SelectedIndex < 0)
        return;
      this.listBoxDirectories.Items.Remove(this.listBoxDirectories.SelectedItem);
    }

    private void LoadToolStripMenuItemClick(object sender, EventArgs e)
    {
      if (sender != null && this.openConfigurationFileDialog.ShowDialog() != DialogResult.OK)
        return;
      StreamReader streamReader = sender != null ? File.OpenText(this.openConfigurationFileDialog.FileName) : File.OpenText("default.cfg");
      this.listBoxDirectories.Items.Clear();
      string str1;
      while ((str1 = streamReader.ReadLine()) != null)
      {
        string str2 = str1.Substring(0, str1.IndexOf('='));
        string str3 = str1.Substring(checked (str1.IndexOf('=') + 1));
        switch (str2)
        {
          case "Server.IP":
            this.textBoxIPAddress.Text = str3;
            break;
          case "Server.Port":
            this.textBoxPort.Text = str3;
            break;
          case "Server.MaxClients":
            this.textBoxMaxClients.Text = str3;
            break;
          default:
            if (str2.IndexOf("Sources[", StringComparison.CurrentCulture) == 0)
            {
              this.listBoxDirectories.Items.Add((object) str3);
              break;
            }
            break;
        }
      }
      streamReader.Close();
    }

    private void SaveToolStripMenuItemClick(object sender, EventArgs e)
    {
      if (this.saveConfigurationFileDialog.ShowDialog() != DialogResult.OK)
        return;
      StreamWriter text = File.CreateText(this.saveConfigurationFileDialog.FileName);
      text.WriteLine("Server.IP=" + this.textBoxIPAddress.Text);
      text.WriteLine("Server.Port=" + this.textBoxPort.Text);
      text.WriteLine("Server.MaxClients=" + this.textBoxMaxClients.Text);
      if (this.listBoxDirectories.Items.Count > 0)
      {
        text.WriteLine("Sources.Count=" + (object) this.listBoxDirectories.Items.Count);
        int index = 0;
        while (index < this.listBoxDirectories.Items.Count)
        {
          text.WriteLine("Sources[" + (object) index + "]=" + this.listBoxDirectories.Items[index].ToString());
          checked { ++index; }
        }
      }
      text.Close();
    }

    private void MainFormShown(object sender, EventArgs e)
    {	
      	if (!IsRegistered()) {
    		CheckRuns();
    	}
    }

    private void MainFormLoad(object sender, EventArgs e)
    {
      MIMEType.InitializeMIMETypes();
      if (!File.Exists("default.cfg"))
        return;
      this.LoadToolStripMenuItemClick((object) null, e);
      this.ButtonRunClick(sender, e);
    }

    private void MainFormFormClosed(object sender, FormClosedEventArgs e)
    {
      this.ButtonStopClick(sender, (EventArgs) e);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

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
    	this.tabControlMain.Location = new System.Drawing.Point(16, 33);
    	this.tabControlMain.Margin = new System.Windows.Forms.Padding(4);
    	this.tabControlMain.Name = "tabControlMain";
    	this.tabControlMain.SelectedIndex = 0;
    	this.tabControlMain.Size = new System.Drawing.Size(535, 327);
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
    	this.tabPageSettings.Location = new System.Drawing.Point(4, 25);
    	this.tabPageSettings.Margin = new System.Windows.Forms.Padding(4);
    	this.tabPageSettings.Name = "tabPageSettings";
    	this.tabPageSettings.Padding = new System.Windows.Forms.Padding(4);
    	this.tabPageSettings.Size = new System.Drawing.Size(527, 298);
    	this.tabPageSettings.TabIndex = 0;
    	this.tabPageSettings.Text = "Settings";
    	this.tabPageSettings.UseVisualStyleBackColor = true;
    	// 
    	// buttonRemoveDirectory
    	// 
    	this.buttonRemoveDirectory.Location = new System.Drawing.Point(456, 247);
    	this.buttonRemoveDirectory.Margin = new System.Windows.Forms.Padding(4);
    	this.buttonRemoveDirectory.Name = "buttonRemoveDirectory";
    	this.buttonRemoveDirectory.Size = new System.Drawing.Size(33, 27);
    	this.buttonRemoveDirectory.TabIndex = 9;
    	this.buttonRemoveDirectory.Text = "-";
    	this.buttonRemoveDirectory.UseVisualStyleBackColor = true;
    	this.buttonRemoveDirectory.Click += new System.EventHandler(this.ButtonRemoveDirectoryClick);
    	// 
    	// buttonAddDirectory
    	// 
    	this.buttonAddDirectory.Location = new System.Drawing.Point(456, 190);
    	this.buttonAddDirectory.Margin = new System.Windows.Forms.Padding(4);
    	this.buttonAddDirectory.Name = "buttonAddDirectory";
    	this.buttonAddDirectory.Size = new System.Drawing.Size(33, 30);
    	this.buttonAddDirectory.TabIndex = 8;
    	this.buttonAddDirectory.Text = "+";
    	this.buttonAddDirectory.UseVisualStyleBackColor = true;
    	this.buttonAddDirectory.Click += new System.EventHandler(this.ButtonAddDirectoryClick);
    	// 
    	// listBoxDirectories
    	// 
    	this.listBoxDirectories.FormattingEnabled = true;
    	this.listBoxDirectories.HorizontalScrollbar = true;
    	this.listBoxDirectories.ItemHeight = 16;
    	this.listBoxDirectories.Location = new System.Drawing.Point(56, 158);
    	this.listBoxDirectories.Margin = new System.Windows.Forms.Padding(4);
    	this.listBoxDirectories.Name = "listBoxDirectories";
    	this.listBoxDirectories.Size = new System.Drawing.Size(383, 116);
    	this.listBoxDirectories.TabIndex = 7;
    	// 
    	// labelDirectories
    	// 
    	this.labelDirectories.Location = new System.Drawing.Point(56, 137);
    	this.labelDirectories.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
    	this.labelDirectories.Name = "labelDirectories";
    	this.labelDirectories.Size = new System.Drawing.Size(155, 22);
    	this.labelDirectories.TabIndex = 6;
    	this.labelDirectories.Text = "Directories:";
    	// 
    	// textBoxMaxClients
    	// 
    	this.textBoxMaxClients.Location = new System.Drawing.Point(272, 110);
    	this.textBoxMaxClients.Margin = new System.Windows.Forms.Padding(4);
    	this.textBoxMaxClients.Name = "textBoxMaxClients";
    	this.textBoxMaxClients.Size = new System.Drawing.Size(167, 22);
    	this.textBoxMaxClients.TabIndex = 5;
    	this.textBoxMaxClients.Text = "50";
    	this.textBoxMaxClients.Visible = false;
    	// 
    	// textBoxPort
    	// 
    	this.textBoxPort.Location = new System.Drawing.Point(272, 78);
    	this.textBoxPort.Margin = new System.Windows.Forms.Padding(4);
    	this.textBoxPort.Name = "textBoxPort";
    	this.textBoxPort.Size = new System.Drawing.Size(167, 22);
    	this.textBoxPort.TabIndex = 4;
    	this.textBoxPort.Text = "80";
    	// 
    	// textBoxIPAddress
    	// 
    	this.textBoxIPAddress.Location = new System.Drawing.Point(272, 32);
    	this.textBoxIPAddress.Margin = new System.Windows.Forms.Padding(4);
    	this.textBoxIPAddress.Name = "textBoxIPAddress";
    	this.textBoxIPAddress.Size = new System.Drawing.Size(167, 22);
    	this.textBoxIPAddress.TabIndex = 3;
    	this.textBoxIPAddress.Text = "127.0.0.1";
    	// 
    	// labelMaxClients
    	// 
    	this.labelMaxClients.Location = new System.Drawing.Point(56, 113);
    	this.labelMaxClients.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
    	this.labelMaxClients.Name = "labelMaxClients";
    	this.labelMaxClients.Size = new System.Drawing.Size(155, 23);
    	this.labelMaxClients.TabIndex = 2;
    	this.labelMaxClients.Text = "Maximum clients (per):";
    	this.labelMaxClients.Visible = false;
    	// 
    	// labelPort
    	// 
    	this.labelPort.Location = new System.Drawing.Point(56, 75);
    	this.labelPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
    	this.labelPort.Name = "labelPort";
    	this.labelPort.Size = new System.Drawing.Size(155, 27);
    	this.labelPort.TabIndex = 1;
    	this.labelPort.Text = "Port:";
    	// 
    	// labelIPAddress
    	// 
    	this.labelIPAddress.Location = new System.Drawing.Point(56, 32);
    	this.labelIPAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
    	this.labelIPAddress.Name = "labelIPAddress";
    	this.labelIPAddress.Size = new System.Drawing.Size(155, 21);
    	this.labelIPAddress.TabIndex = 0;
    	this.labelIPAddress.Text = "IP Address:";
    	// 
    	// tabPageAbout
    	// 
    	this.tabPageAbout.Controls.Add(this.labelAbout);
    	this.tabPageAbout.Location = new System.Drawing.Point(4, 25);
    	this.tabPageAbout.Margin = new System.Windows.Forms.Padding(4);
    	this.tabPageAbout.Name = "tabPageAbout";
    	this.tabPageAbout.Padding = new System.Windows.Forms.Padding(4);
    	this.tabPageAbout.Size = new System.Drawing.Size(527, 298);
    	this.tabPageAbout.TabIndex = 2;
    	this.tabPageAbout.Text = "About";
    	this.tabPageAbout.UseVisualStyleBackColor = true;
    	// 
    	// labelAbout
    	// 
    	this.labelAbout.Location = new System.Drawing.Point(28, 31);
    	this.labelAbout.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
    	this.labelAbout.Name = "labelAbout";
    	this.labelAbout.Size = new System.Drawing.Size(177, 22);
    	this.labelAbout.TabIndex = 0;
    	this.labelAbout.Text = "2022 - OVG-Developers";
    	// 
    	// menuStripMain
    	// 
    	this.menuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
    	this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.configurationToolStripMenuItem,
			this.serverToolStripMenuItem});
    	this.menuStripMain.Location = new System.Drawing.Point(0, 0);
    	this.menuStripMain.Name = "menuStripMain";
    	this.menuStripMain.Size = new System.Drawing.Size(567, 28);
    	this.menuStripMain.TabIndex = 1;
    	this.menuStripMain.Text = "menuStrip1";
    	// 
    	// configurationToolStripMenuItem
    	// 
    	this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.loadToolStripMenuItem,
			this.saveToolStripMenuItem});
    	this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
    	this.configurationToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
    	this.configurationToolStripMenuItem.Text = "Configuration";
    	// 
    	// loadToolStripMenuItem
    	// 
    	this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
    	this.loadToolStripMenuItem.Size = new System.Drawing.Size(126, 26);
    	this.loadToolStripMenuItem.Text = "Load...";
    	this.loadToolStripMenuItem.Click += new System.EventHandler(this.LoadToolStripMenuItemClick);
    	// 
    	// saveToolStripMenuItem
    	// 
    	this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
    	this.saveToolStripMenuItem.Size = new System.Drawing.Size(126, 26);
    	this.saveToolStripMenuItem.Text = "Save...";
    	this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
    	// 
    	// serverToolStripMenuItem
    	// 
    	this.serverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.runToolStripMenuItem,
			this.stopToolStripMenuItem});
    	this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
    	this.serverToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
    	this.serverToolStripMenuItem.Text = "Server";
    	// 
    	// runToolStripMenuItem
    	// 
    	this.runToolStripMenuItem.Name = "runToolStripMenuItem";
    	this.runToolStripMenuItem.Size = new System.Drawing.Size(115, 26);
    	this.runToolStripMenuItem.Text = "Run";
    	this.runToolStripMenuItem.Click += new System.EventHandler(this.RunToolStripMenuItemClick);
    	// 
    	// stopToolStripMenuItem
    	// 
    	this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
    	this.stopToolStripMenuItem.Size = new System.Drawing.Size(115, 26);
    	this.stopToolStripMenuItem.Text = "Stop";
    	this.stopToolStripMenuItem.Click += new System.EventHandler(this.StopToolStripMenuItemClick);
    	// 
    	// statusStripMain
    	// 
    	this.statusStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
    	this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolStripStatusLabelMain});
    	this.statusStripMain.Location = new System.Drawing.Point(0, 371);
    	this.statusStripMain.Name = "statusStripMain";
    	this.statusStripMain.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
    	this.statusStripMain.Size = new System.Drawing.Size(567, 22);
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
    	this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
    	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    	this.ClientSize = new System.Drawing.Size(567, 393);
    	this.Controls.Add(this.statusStripMain);
    	this.Controls.Add(this.tabControlMain);
    	this.Controls.Add(this.menuStripMain);
    	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
    	this.MainMenuStrip = this.menuStripMain;
    	this.Margin = new System.Windows.Forms.Padding(4);
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
