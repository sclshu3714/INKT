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
		public MainForm()
        {
            InitializeComponent();
			this.Load += MainForm_Load;
		}
		private void MainForm_Load(object sender, EventArgs e)
		{

			InkControl ink = new InkControl();
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
			this.FormBorderStyle = FormBorderStyle.None;
			this.WindowState = FormWindowState.Maximized;
			ink.GetInkCanvas.EditingMode = System.Windows.Controls.InkCanvasEditingMode.None;

			Rectory = new SetControlRectangle(this);
            Rectory.SetRectangel += Rectory_SetRectangel;
		}

        private void Rectory_SetRectangel(object sender, Rectangle e)
        {
            
        }
    }
}
