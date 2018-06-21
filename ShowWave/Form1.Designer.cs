namespace ShowWave
{
    partial class Form1
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
            this.btOpen = new System.Windows.Forms.Button();
            this.pbScreen = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.pbLocate = new System.Windows.Forms.PictureBox();
            this.btReload = new System.Windows.Forms.Button();
            this.cbWave = new System.Windows.Forms.CheckBox();
            this.btPlay = new System.Windows.Forms.Button();
            this.rtbInfo = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLocate)).BeginInit();
            this.SuspendLayout();
            // 
            // btOpen
            // 
            this.btOpen.Location = new System.Drawing.Point(12, 12);
            this.btOpen.Name = "btOpen";
            this.btOpen.Size = new System.Drawing.Size(75, 23);
            this.btOpen.TabIndex = 0;
            this.btOpen.Text = "打开";
            this.btOpen.UseVisualStyleBackColor = true;
            this.btOpen.Click += new System.EventHandler(this.btOpen_Click);
            // 
            // pbScreen
            // 
            this.pbScreen.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pbScreen.Location = new System.Drawing.Point(12, 126);
            this.pbScreen.Name = "pbScreen";
            this.pbScreen.Size = new System.Drawing.Size(745, 306);
            this.pbScreen.TabIndex = 1;
            this.pbScreen.TabStop = false;
            this.pbScreen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbScreen_MouseDown);
            this.pbScreen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbScreen_MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(137, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "增高";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(137, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "缩小";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(244, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "拉伸";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(244, 41);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "压缩";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // pbLocate
            // 
            this.pbLocate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pbLocate.Location = new System.Drawing.Point(12, 104);
            this.pbLocate.Name = "pbLocate";
            this.pbLocate.Size = new System.Drawing.Size(745, 16);
            this.pbLocate.TabIndex = 9;
            this.pbLocate.TabStop = false;
            this.pbLocate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbLocate_MouseDown);
            this.pbLocate.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbLocate_MouseMove);
            this.pbLocate.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbLocate_MouseUp);
            // 
            // btReload
            // 
            this.btReload.Location = new System.Drawing.Point(354, 41);
            this.btReload.Name = "btReload";
            this.btReload.Size = new System.Drawing.Size(75, 23);
            this.btReload.TabIndex = 12;
            this.btReload.Text = "复位";
            this.btReload.UseVisualStyleBackColor = true;
            this.btReload.Click += new System.EventHandler(this.btReload_Click);
            // 
            // cbWave
            // 
            this.cbWave.AutoSize = true;
            this.cbWave.Location = new System.Drawing.Point(12, 82);
            this.cbWave.Name = "cbWave";
            this.cbWave.Size = new System.Drawing.Size(72, 16);
            this.cbWave.TabIndex = 13;
            this.cbWave.Text = "显示模式";
            this.cbWave.UseVisualStyleBackColor = true;
            this.cbWave.CheckedChanged += new System.EventHandler(this.cbWave_CheckedChanged);
            // 
            // btPlay
            // 
            this.btPlay.Location = new System.Drawing.Point(354, 12);
            this.btPlay.Name = "btPlay";
            this.btPlay.Size = new System.Drawing.Size(75, 23);
            this.btPlay.TabIndex = 14;
            this.btPlay.Text = "Play";
            this.btPlay.UseVisualStyleBackColor = true;
            this.btPlay.Click += new System.EventHandler(this.btPlay_Click);
            // 
            // rtbInfo
            // 
            this.rtbInfo.Location = new System.Drawing.Point(465, 14);
            this.rtbInfo.Name = "rtbInfo";
            this.rtbInfo.Size = new System.Drawing.Size(292, 84);
            this.rtbInfo.TabIndex = 15;
            this.rtbInfo.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 444);
            this.Controls.Add(this.rtbInfo);
            this.Controls.Add(this.btPlay);
            this.Controls.Add(this.cbWave);
            this.Controls.Add(this.btReload);
            this.Controls.Add(this.pbLocate);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pbScreen);
            this.Controls.Add(this.btOpen);
            this.MinimumSize = new System.Drawing.Size(785, 482);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLocate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOpen;
        private System.Windows.Forms.PictureBox pbScreen;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox pbLocate;
        private System.Windows.Forms.Button btReload;
        private System.Windows.Forms.CheckBox cbWave;
        private System.Windows.Forms.Button btPlay;
        private System.Windows.Forms.RichTextBox rtbInfo;
    }
}

