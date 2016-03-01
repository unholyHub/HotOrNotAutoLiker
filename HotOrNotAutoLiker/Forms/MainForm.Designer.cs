namespace HotOrNotAutoLiker
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.niTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miStartLiking = new System.Windows.Forms.ToolStripMenuItem();
            this.miStopLiking = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // niTray
            // 
            this.niTray.ContextMenuStrip = this.contextMenuStrip;
            this.niTray.Icon = ((System.Drawing.Icon)(resources.GetObject("niTray.Icon")));
            this.niTray.Text = "HotOrNot Auto Liker";
            this.niTray.Visible = true;
            this.niTray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayNotifyIconMouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miStartLiking,
            this.miStopLiking,
            this.toolStripSeparator2,
            this.miAbout,
            this.toolStripSeparator3,
            this.miExit});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(134, 104);
            // 
            // miStartLiking
            // 
            this.miStartLiking.Image = global::HotOrNotAutoLiker.Properties.Resources.start_liking;
            this.miStartLiking.Name = "miStartLiking";
            this.miStartLiking.Size = new System.Drawing.Size(133, 22);
            this.miStartLiking.Text = "Start Liking";
            this.miStartLiking.Click += new System.EventHandler(this.StartBlockingMenuItemClick);
            // 
            // miStopLiking
            // 
            this.miStopLiking.Image = global::HotOrNotAutoLiker.Properties.Resources.stop_liking;
            this.miStopLiking.Name = "miStopLiking";
            this.miStopLiking.Size = new System.Drawing.Size(133, 22);
            this.miStopLiking.Text = "Stop Liking";
            this.miStopLiking.Click += new System.EventHandler(this.StopBlockingMenuItemClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(130, 6);
            // 
            // miAbout
            // 
            this.miAbout.Image = global::HotOrNotAutoLiker.Properties.Resources.about;
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(133, 22);
            this.miAbout.Text = "About";
            this.miAbout.Click += new System.EventHandler(this.AboutBoxMenuItemClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(130, 6);
            // 
            // miExit
            // 
            this.miExit.Image = global::HotOrNotAutoLiker.Properties.Resources.exit;
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(133, 22);
            this.miExit.Text = "Exit";
            this.miExit.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 212);
            this.ControlBox = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon niTray;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripMenuItem miStartLiking;
        private System.Windows.Forms.ToolStripMenuItem miStopLiking;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}
