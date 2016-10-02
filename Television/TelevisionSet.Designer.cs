namespace Television
{
    partial class TelevisionSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelevisionSet));
            this.PowerBtn = new System.Windows.Forms.Button();
            this.NextChannelBtn = new System.Windows.Forms.Button();
            this.PreviousChannelBtn = new System.Windows.Forms.Button();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.buttons = new System.Windows.Forms.GroupBox();
            this.NumberLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.VolumeLabel = new System.Windows.Forms.Label();
            this.PlayTimer = new System.Windows.Forms.Timer(this.components);
            this.DisappearTimer = new System.Windows.Forms.Timer(this.components);
            this.VolumeTimer = new System.Windows.Forms.Timer(this.components);
            this.VideoPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.ResetTimer = new System.Windows.Forms.Timer(this.components);
            this.SignalLabel = new System.Windows.Forms.Label();
            this.ProcessLabel = new System.Windows.Forms.Label();
            this.buttons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VideoPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // PowerBtn
            // 
            this.PowerBtn.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.PowerBtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PowerBtn.Location = new System.Drawing.Point(26, 14);
            this.PowerBtn.Name = "PowerBtn";
            this.PowerBtn.Size = new System.Drawing.Size(64, 34);
            this.PowerBtn.TabIndex = 0;
            this.PowerBtn.Text = "On/Off";
            this.PowerBtn.UseVisualStyleBackColor = false;
            this.PowerBtn.Click += new System.EventHandler(this.PowerBtn_Click);
            // 
            // NextChannelBtn
            // 
            this.NextChannelBtn.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.NextChannelBtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NextChannelBtn.Location = new System.Drawing.Point(111, 14);
            this.NextChannelBtn.Name = "NextChannelBtn";
            this.NextChannelBtn.Size = new System.Drawing.Size(64, 34);
            this.NextChannelBtn.TabIndex = 1;
            this.NextChannelBtn.Text = "Next(+)";
            this.NextChannelBtn.UseVisualStyleBackColor = false;
            this.NextChannelBtn.Click += new System.EventHandler(this.NextChannelBtn_Click);
            // 
            // PreviousChannelBtn
            // 
            this.PreviousChannelBtn.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.PreviousChannelBtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PreviousChannelBtn.Location = new System.Drawing.Point(191, 14);
            this.PreviousChannelBtn.Name = "PreviousChannelBtn";
            this.PreviousChannelBtn.Size = new System.Drawing.Size(64, 34);
            this.PreviousChannelBtn.TabIndex = 2;
            this.PreviousChannelBtn.Text = "Prev(-)";
            this.PreviousChannelBtn.UseVisualStyleBackColor = false;
            this.PreviousChannelBtn.Click += new System.EventHandler(this.PreviousChannelBtn_Click);
            // 
            // ResetBtn
            // 
            this.ResetBtn.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ResetBtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResetBtn.Location = new System.Drawing.Point(275, 14);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(64, 34);
            this.ResetBtn.TabIndex = 3;
            this.ResetBtn.Text = "Reset";
            this.ResetBtn.UseVisualStyleBackColor = false;
            this.ResetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // buttons
            // 
            this.buttons.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttons.Controls.Add(this.PowerBtn);
            this.buttons.Controls.Add(this.ResetBtn);
            this.buttons.Controls.Add(this.NextChannelBtn);
            this.buttons.Controls.Add(this.PreviousChannelBtn);
            this.buttons.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttons.Location = new System.Drawing.Point(304, 437);
            this.buttons.Name = "buttons";
            this.buttons.Size = new System.Drawing.Size(364, 58);
            this.buttons.TabIndex = 4;
            this.buttons.TabStop = false;
            // 
            // NumberLabel
            // 
            this.NumberLabel.BackColor = System.Drawing.Color.Blue;
            this.NumberLabel.Font = new System.Drawing.Font("RuneScape UF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumberLabel.ForeColor = System.Drawing.Color.Yellow;
            this.NumberLabel.Location = new System.Drawing.Point(50, 33);
            this.NumberLabel.Name = "NumberLabel";
            this.NumberLabel.Size = new System.Drawing.Size(176, 23);
            this.NumberLabel.TabIndex = 8;
            this.NumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NumberLabel.Visible = false;
            // 
            // NameLabel
            // 
            this.NameLabel.BackColor = System.Drawing.Color.Blue;
            this.NameLabel.Font = new System.Drawing.Font("RuneScape UF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.ForeColor = System.Drawing.Color.Yellow;
            this.NameLabel.Location = new System.Drawing.Point(755, 33);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(147, 23);
            this.NameLabel.TabIndex = 9;
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NameLabel.Visible = false;
            // 
            // VolumeLabel
            // 
            this.VolumeLabel.BackColor = System.Drawing.Color.Blue;
            this.VolumeLabel.Font = new System.Drawing.Font("RuneScape UF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VolumeLabel.ForeColor = System.Drawing.Color.Yellow;
            this.VolumeLabel.Location = new System.Drawing.Point(50, 381);
            this.VolumeLabel.Name = "VolumeLabel";
            this.VolumeLabel.Size = new System.Drawing.Size(319, 21);
            this.VolumeLabel.TabIndex = 11;
            this.VolumeLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.VolumeLabel.Visible = false;
            // 
            // PlayTimer
            // 
            this.PlayTimer.Interval = 1000;
            this.PlayTimer.Tick += new System.EventHandler(this.PlayTimer_Tick);
            // 
            // DisappearTimer
            // 
            this.DisappearTimer.Interval = 4000;
            this.DisappearTimer.Tick += new System.EventHandler(this.DisappearTimer_Tick);
            // 
            // VolumeTimer
            // 
            this.VolumeTimer.Interval = 4000;
            this.VolumeTimer.Tick += new System.EventHandler(this.VolumeTimer_Tick);
            // 
            // VideoPlayer
            // 
            this.VideoPlayer.Enabled = true;
            this.VideoPlayer.Location = new System.Drawing.Point(11, 11);
            this.VideoPlayer.Name = "VideoPlayer";
            this.VideoPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("VideoPlayer.OcxState")));
            this.VideoPlayer.Size = new System.Drawing.Size(949, 420);
            this.VideoPlayer.TabIndex = 7;
            // 
            // ResetTimer
            // 
            this.ResetTimer.Interval = 1000;
            this.ResetTimer.Tick += new System.EventHandler(this.ResetTimer_Tick);
            // 
            // SignalLabel
            // 
            this.SignalLabel.BackColor = System.Drawing.Color.Blue;
            this.SignalLabel.Font = new System.Drawing.Font("RuneScape UF", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignalLabel.ForeColor = System.Drawing.Color.Yellow;
            this.SignalLabel.Location = new System.Drawing.Point(370, 167);
            this.SignalLabel.Name = "SignalLabel";
            this.SignalLabel.Size = new System.Drawing.Size(255, 94);
            this.SignalLabel.TabIndex = 12;
            this.SignalLabel.Text = "Signal not found\r\nPlease stand by";
            this.SignalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SignalLabel.Visible = false;
            // 
            // ProcessLabel
            // 
            this.ProcessLabel.BackColor = System.Drawing.Color.Blue;
            this.ProcessLabel.Font = new System.Drawing.Font("RuneScape UF", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProcessLabel.ForeColor = System.Drawing.Color.Yellow;
            this.ProcessLabel.Location = new System.Drawing.Point(433, 381);
            this.ProcessLabel.Name = "ProcessLabel";
            this.ProcessLabel.Size = new System.Drawing.Size(100, 23);
            this.ProcessLabel.TabIndex = 13;
            this.ProcessLabel.Text = "Reseting";
            this.ProcessLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ProcessLabel.Visible = false;
            // 
            // TelevisionSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(971, 507);
            this.Controls.Add(this.ProcessLabel);
            this.Controls.Add(this.SignalLabel);
            this.Controls.Add(this.VolumeLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.NumberLabel);
            this.Controls.Add(this.VideoPlayer);
            this.Controls.Add(this.buttons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelevisionSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Television";
            this.buttons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VideoPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PowerBtn;
        private System.Windows.Forms.Button NextChannelBtn;
        private System.Windows.Forms.Button PreviousChannelBtn;
        private System.Windows.Forms.Button ResetBtn;
        private System.Windows.Forms.GroupBox buttons;
        public AxWMPLib.AxWindowsMediaPlayer VideoPlayer;
        public System.Windows.Forms.Label NumberLabel;
        public System.Windows.Forms.Label NameLabel;
        public System.Windows.Forms.Label VolumeLabel;
        public System.Windows.Forms.Timer PlayTimer;
        public System.Windows.Forms.Timer DisappearTimer;
        public System.Windows.Forms.Timer VolumeTimer;
        public System.Windows.Forms.Label SignalLabel;
        public System.Windows.Forms.Label ProcessLabel;
        public System.Windows.Forms.Timer ResetTimer;
    }
}

