namespace FFTCS
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CAMpictureBox = new System.Windows.Forms.PictureBox();
            this.IFFTpictureBox = new System.Windows.Forms.PictureBox();
            this.FFTpictureBox = new System.Windows.Forms.PictureBox();
            this.FILTERpictureBox = new System.Windows.Forms.PictureBox();
            this.Clearbutton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CAMpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IFFTpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FFTpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FILTERpictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.CAMpictureBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.IFFTpictureBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.FFTpictureBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.FILTERpictureBox, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(626, 453);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // CAMpictureBox
            // 
            this.CAMpictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CAMpictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CAMpictureBox.Location = new System.Drawing.Point(3, 3);
            this.CAMpictureBox.Name = "CAMpictureBox";
            this.CAMpictureBox.Size = new System.Drawing.Size(307, 220);
            this.CAMpictureBox.TabIndex = 0;
            this.CAMpictureBox.TabStop = false;
            // 
            // IFFTpictureBox
            // 
            this.IFFTpictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IFFTpictureBox.Location = new System.Drawing.Point(316, 3);
            this.IFFTpictureBox.Name = "IFFTpictureBox";
            this.IFFTpictureBox.Size = new System.Drawing.Size(307, 220);
            this.IFFTpictureBox.TabIndex = 1;
            this.IFFTpictureBox.TabStop = false;
            // 
            // FFTpictureBox
            // 
            this.FFTpictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FFTpictureBox.Location = new System.Drawing.Point(3, 229);
            this.FFTpictureBox.Name = "FFTpictureBox";
            this.FFTpictureBox.Size = new System.Drawing.Size(307, 221);
            this.FFTpictureBox.TabIndex = 2;
            this.FFTpictureBox.TabStop = false;
            // 
            // FILTERpictureBox
            // 
            this.FILTERpictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.FILTERpictureBox.BackColor = System.Drawing.Color.Black;
            this.FILTERpictureBox.Location = new System.Drawing.Point(316, 229);
            this.FILTERpictureBox.Name = "FILTERpictureBox";
            this.FILTERpictureBox.Size = new System.Drawing.Size(307, 221);
            this.FILTERpictureBox.TabIndex = 3;
            this.FILTERpictureBox.TabStop = false;
            this.FILTERpictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.FILTERpictureBox_Paint);
            this.FILTERpictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FILTERpictureBox_MouseDown);
            this.FILTERpictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FILTERpictureBox_MouseMove);
            this.FILTERpictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FILTERpictureBox_MouseUp);
            // 
            // Clearbutton
            // 
            this.Clearbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Clearbutton.Location = new System.Drawing.Point(12, 471);
            this.Clearbutton.Name = "Clearbutton";
            this.Clearbutton.Size = new System.Drawing.Size(114, 46);
            this.Clearbutton.TabIndex = 1;
            this.Clearbutton.Text = "Clear";
            this.Clearbutton.UseVisualStyleBackColor = true;
            this.Clearbutton.Click += new System.EventHandler(this.Clearbutton_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 529);
            this.Controls.Add(this.Clearbutton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CAMpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IFFTpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FFTpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FILTERpictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox CAMpictureBox;
        private System.Windows.Forms.PictureBox IFFTpictureBox;
        private System.Windows.Forms.PictureBox FFTpictureBox;
        private System.Windows.Forms.PictureBox FILTERpictureBox;
        private System.Windows.Forms.Button Clearbutton;
        private System.Windows.Forms.Timer timer1;
    }
}

