using Microsoft.Ink;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace WFInk
{
	public partial class MainForm : Form
    {
		private SetControlRectangle Rectory;
        private InkControl ink = null;

        public MainForm()
        {
            InitializeComponent();
			this.Load += MainForm_Load;
		}
		private void MainForm_Load(object sender, EventArgs e)
		{

			ink = new InkControl();
			ink.Width = this.Width;
			ink.Height = this.Height;
			//ElementHost elementHost = new ElementHost();
			//elementHost.Dock = DockStyle.Fill;
			elementHost.Child = ink; // 绑定
            elementHost.BackColor = Color.Transparent;
            elementHost.BackColorTransparent = true;
            //this.Controls.Add(elementHost);
            elementHost.Show();
            //this.BackColor = Color.Red;
            //this.TransparencyKey = Color.Red;
            //this.Opacity = 0.01;
            //this.BackColor = Color.Red;
            //this.TransparencyKey = Color.Red;

            //2.获取含任务栏的屏幕大小：

            //var h = Screen.PrimaryScreen.Bounds.Height;
            //var w = Screen.PrimaryScreen.Bounds.Width;
            //3.获取不含任务栏的屏幕大小：

            var h = SystemInformation.WorkingArea.Height;
			var w = SystemInformation.WorkingArea.Width;
			this.MaximumSize = new Size(w, h);
			this.WindowState = FormWindowState.Maximized;
			this.FormBorderStyle = FormBorderStyle.None;
			ink.GetInkCanvas.EditingMode = System.Windows.Controls.InkCanvasEditingMode.Ink;

			Rectory = new SetControlRectangle(this);
            Rectory.SetRectangel += Rectory_SetRectangel;
		}

        private void Rectory_SetRectangel(object sender, Rectangle e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ToBitmapTool.ToBitmap(this.ink);
        }
    }
}
