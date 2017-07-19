namespace AutoNetWatcher
{
    partial class MainFrame
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrame));
            this.tray_ = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip_ = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.about_ = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.start_ = new System.Windows.Forms.ToolStripMenuItem();
            this.stop_ = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exit_ = new System.Windows.Forms.ToolStripMenuItem();
            this.tooltip_ = new System.Windows.Forms.Label();
            this.num_ = new System.Windows.Forms.Label();
            this.enableNetcard_ = new System.Windows.Forms.ToolStripMenuItem();
            this.netcards_ = new System.Windows.Forms.ComboBox();
            this.disableNetcard_ = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_.SuspendLayout();
            this.SuspendLayout();
            // 
            // tray_
            // 
            this.tray_.ContextMenuStrip = this.contextMenuStrip_;
            this.tray_.Icon = ((System.Drawing.Icon)(resources.GetObject("tray_.Icon")));
            this.tray_.Text = "网络观察者";
            this.tray_.Visible = true;
            this.tray_.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tray__MouseDoubleClick);
            this.tray_.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tray__MouseClick);
            // 
            // contextMenuStrip_
            // 
            this.contextMenuStrip_.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.about_,
            this.toolStripSeparator1,
            this.start_,
            this.stop_,
            this.toolStripSeparator2,
            this.enableNetcard_,
            this.disableNetcard_,
            this.exit_});
            this.contextMenuStrip_.Name = "contextMenuStrip_";
            this.contextMenuStrip_.Size = new System.Drawing.Size(153, 170);
            // 
            // about_
            // 
            this.about_.Name = "about_";
            this.about_.Size = new System.Drawing.Size(152, 22);
            this.about_.Text = "关于";
            this.about_.Click += new System.EventHandler(this.about__Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // start_
            // 
            this.start_.Name = "start_";
            this.start_.Size = new System.Drawing.Size(152, 22);
            this.start_.Text = "开启";
            this.start_.Click += new System.EventHandler(this.start__Click);
            // 
            // stop_
            // 
            this.stop_.Name = "stop_";
            this.stop_.Size = new System.Drawing.Size(152, 22);
            this.stop_.Text = "停止";
            this.stop_.Click += new System.EventHandler(this.stop__Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // exit_
            // 
            this.exit_.Name = "exit_";
            this.exit_.Size = new System.Drawing.Size(152, 22);
            this.exit_.Text = "退出";
            this.exit_.Click += new System.EventHandler(this.exit__Click);
            // 
            // tooltip_
            // 
            this.tooltip_.AutoSize = true;
            this.tooltip_.Location = new System.Drawing.Point(36, 15);
            this.tooltip_.Name = "tooltip_";
            this.tooltip_.Size = new System.Drawing.Size(0, 12);
            this.tooltip_.TabIndex = 1;
            // 
            // num_
            // 
            this.num_.AutoSize = true;
            this.num_.Location = new System.Drawing.Point(12, 14);
            this.num_.Name = "num_";
            this.num_.Size = new System.Drawing.Size(0, 12);
            this.num_.TabIndex = 2;
            // 
            // enableNetcard_
            // 
            this.enableNetcard_.Name = "enableNetcard_";
            this.enableNetcard_.Size = new System.Drawing.Size(152, 22);
            this.enableNetcard_.Text = "启用网卡";
            this.enableNetcard_.Click += new System.EventHandler(this.enableNetcard__Click);
            // 
            // netcards_
            // 
            this.netcards_.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.netcards_.FormattingEnabled = true;
            this.netcards_.Location = new System.Drawing.Point(13, 30);
            this.netcards_.Name = "netcards_";
            this.netcards_.Size = new System.Drawing.Size(317, 20);
            this.netcards_.TabIndex = 3;
            // 
            // disableNetcard_
            // 
            this.disableNetcard_.Name = "disableNetcard_";
            this.disableNetcard_.Size = new System.Drawing.Size(152, 22);
            this.disableNetcard_.Text = "禁用网卡";
            this.disableNetcard_.Click += new System.EventHandler(this.disableNetcard__Click);
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 63);
            this.Controls.Add(this.netcards_);
            this.Controls.Add(this.num_);
            this.Controls.Add(this.tooltip_);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainFrame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NetWatcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrame_FormClosing);
            this.Load += new System.EventHandler(this.MainFrame_Load);
            this.Shown += new System.EventHandler(this.MainFrame_Shown);
            this.SizeChanged += new System.EventHandler(this.MainFrame_SizeChanged);
            this.contextMenuStrip_.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon tray_;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_;
        private System.Windows.Forms.ToolStripMenuItem about_;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem start_;
        private System.Windows.Forms.ToolStripMenuItem stop_;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exit_;
        private System.Windows.Forms.Label tooltip_;
        private System.Windows.Forms.Label num_;
        private System.Windows.Forms.ToolStripMenuItem enableNetcard_;
        private System.Windows.Forms.ComboBox netcards_;
        private System.Windows.Forms.ToolStripMenuItem disableNetcard_;
    }
}

