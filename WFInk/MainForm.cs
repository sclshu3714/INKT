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
		public MainForm()
        {
            InitializeComponent();
			this.Load += MainForm_Load;
		}
		private void MainForm_Load(object sender, EventArgs e)
		{
			InkControl ink = new InkControl();
			ink.Width = this.panelView.Width;
			ink.Height = this.panelView.Height;
			ElementHost _elemHost = new ElementHost();
			_elemHost.Dock = DockStyle.Fill;
			_elemHost.Child = ink; // 绑定
			this.panelView.Controls.Add(_elemHost);
			_elemHost.Show();
		}
	}
}
