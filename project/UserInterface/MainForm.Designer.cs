﻿namespace UserInterface {
	partial class MainForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.settingsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.renderMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.rayTraceMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.pathTraceMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.pathTrace2Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.configTextBox = new System.Windows.Forms.RichTextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.settingsMenu,
            this.renderMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(584, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuOpen,
            this.fileMenuSave,
            this.fileMenuExit,
            this.toolStripSeparator});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "File";
            // 
            // fileMenuOpen
            // 
            this.fileMenuOpen.Name = "fileMenuOpen";
            this.fileMenuOpen.Size = new System.Drawing.Size(103, 22);
            this.fileMenuOpen.Text = "Open";
            this.fileMenuOpen.Click += new System.EventHandler(this.FileMenuOpen_Click);
            // 
            // fileMenuSave
            // 
            this.fileMenuSave.Name = "fileMenuSave";
            this.fileMenuSave.Size = new System.Drawing.Size(103, 22);
            this.fileMenuSave.Text = "Save";
            this.fileMenuSave.Click += new System.EventHandler(this.FileMenuSave_Click);
            // 
            // fileMenuExit
            // 
            this.fileMenuExit.Name = "fileMenuExit";
            this.fileMenuExit.Size = new System.Drawing.Size(103, 22);
            this.fileMenuExit.Text = "Exit";
            this.fileMenuExit.Click += new System.EventHandler(this.FileMenuExit_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(100, 6);
            // 
            // settingsMenu
            // 
            this.settingsMenu.Name = "settingsMenu";
            this.settingsMenu.Size = new System.Drawing.Size(61, 20);
            this.settingsMenu.Text = "Settings";
            this.settingsMenu.Click += new System.EventHandler(this.settingsMenu_Click);
            // 
            // renderMenu
            // 
            this.renderMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rayTraceMenu,
            this.pathTraceMenu,
            this.pathTrace2Menu});
            this.renderMenu.Name = "renderMenu";
            this.renderMenu.Size = new System.Drawing.Size(56, 20);
            this.renderMenu.Text = "Render";
            // 
            // rayTraceMenu
            // 
            this.rayTraceMenu.Name = "rayTraceMenu";
            this.rayTraceMenu.Size = new System.Drawing.Size(153, 22);
            this.rayTraceMenu.Text = "Ray Trace";
            this.rayTraceMenu.Click += new System.EventHandler(this.rayTraceMenu_Click);
            // 
            // pathTraceMenu
            // 
            this.pathTraceMenu.Name = "pathTraceMenu";
            this.pathTraceMenu.Size = new System.Drawing.Size(153, 22);
            this.pathTraceMenu.Text = "OpenCL Tracer";
            this.pathTraceMenu.Click += new System.EventHandler(this.pathTraceMenu_Click);
            // 
            // pathTrace2Menu
            // 
            this.pathTrace2Menu.Name = "pathTrace2Menu";
            this.pathTrace2Menu.Size = new System.Drawing.Size(153, 22);
            this.pathTrace2Menu.Text = "Path Trace 2";
            this.pathTrace2Menu.Click += new System.EventHandler(this.pathTrace2Menu_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(0, 24);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.configTextBox);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.pictureBox);
            this.splitContainer.Size = new System.Drawing.Size(584, 313);
            this.splitContainer.SplitterDistance = 209;
            this.splitContainer.TabIndex = 1;
            // 
            // configTextBox
            // 
            this.configTextBox.AcceptsTab = true;
            this.configTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.configTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.configTextBox.Location = new System.Drawing.Point(0, 0);
            this.configTextBox.Name = "configTextBox";
            this.configTextBox.Size = new System.Drawing.Size(209, 313);
            this.configTextBox.TabIndex = 0;
            this.configTextBox.Text = "";
            this.configTextBox.WordWrap = false;
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(371, 313);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 340);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(584, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel.Text = "toolStripStatusLabel1";
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "RayTracer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileMenu;
		private System.Windows.Forms.ToolStripMenuItem fileMenuOpen;
		private System.Windows.Forms.SplitContainer splitContainer;
		private System.Windows.Forms.RichTextBox configTextBox;
        private System.Windows.Forms.ToolStripMenuItem fileMenuExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
		private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolStripMenuItem fileMenuSave;
        private System.Windows.Forms.ToolStripMenuItem renderMenu;
        private System.Windows.Forms.ToolStripMenuItem rayTraceMenu;
        private System.Windows.Forms.ToolStripMenuItem pathTraceMenu;
        private System.Windows.Forms.ToolStripMenuItem pathTrace2Menu;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem settingsMenu;
	}
}

