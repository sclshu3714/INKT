
namespace WFInk
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.axInkPicture1 = new AxMSINKAUTLib.AxInkPicture();
            this.axInkEdit1 = new AxINKEDLib.AxInkEdit();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.axInkPicture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axInkEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // axInkPicture1
            // 
            this.axInkPicture1.Location = new System.Drawing.Point(12, 12);
            this.axInkPicture1.Name = "axInkPicture1";
            this.axInkPicture1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axInkPicture1.OcxState")));
            this.axInkPicture1.Size = new System.Drawing.Size(383, 262);
            this.axInkPicture1.TabIndex = 0;
            // 
            // axInkEdit1
            // 
            this.axInkEdit1.Enabled = true;
            this.axInkEdit1.Location = new System.Drawing.Point(413, 12);
            this.axInkEdit1.Name = "axInkEdit1";
            this.axInkEdit1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axInkEdit1.OcxState")));
            this.axInkEdit1.Size = new System.Drawing.Size(380, 472);
            this.axInkEdit1.TabIndex = 1;
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.SystemColors.Control;
            this.canvas.Image = ((System.Drawing.Image)(resources.GetObject("canvas.Image")));
            this.canvas.Location = new System.Drawing.Point(13, 290);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(382, 200);
            this.canvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.canvas.TabIndex = 2;
            this.canvas.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(13, 534);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(780, 69);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(13, 497);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(780, 31);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 611);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.axInkEdit1);
            this.Controls.Add(this.axInkPicture1);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.axInkPicture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axInkEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxMSINKAUTLib.AxInkPicture axInkPicture1;
        private AxINKEDLib.AxInkEdit axInkEdit1;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

