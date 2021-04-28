﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFInk
{
    public partial class Form1 : Form
    {
        #region 窗体鼠标穿透
        private const uint WS_EX_LAYERED = 0x80000;
        private const int WS_EX_TRANSPARENT = 0x20;
        private const int GWL_STYLE = (-16);
        private const int GWL_EXSTYLE = (-20);
        private const int LWA_ALPHA = 0;

        [DllImport("user32", EntryPoint = "SetWindowLong")]
        private static extern uint SetWindowLong(
        IntPtr hwnd,
        int nIndex,
        uint dwNewLong
        );

        [DllImport("user32", EntryPoint = "GetWindowLong")]
        private static extern uint GetWindowLong(
        IntPtr hwnd,
        int nIndex
        );

        [DllImport("user32", EntryPoint = "SetLayeredWindowAttributes")]
        private static extern int SetLayeredWindowAttributes(
        IntPtr hwnd,
        int crKey,
        int bAlpha,
        int dwFlags
        );


        /// <summary>
        /// 声明委托类
        /// </summary>
        /// <param name="MsgStr"></param>
        public delegate void FormCt();
        /// <summary>
        /// 定义委托
        /// </summary>
        public static FormCt Ct;
        /// <summary> 
        /// 设置窗体具有鼠标穿透效果 
        /// </summary> 
        private void SetPenetrate()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(Ct);
            }
            else
            {
                this.TopMost = true;
                GetWindowLong(this.Handle, GWL_EXSTYLE);
                SetWindowLong(this.Handle, GWL_EXSTYLE, WS_EX_TRANSPARENT | WS_EX_LAYERED);
                SetLayeredWindowAttributes(this.Handle, 0, 100, LWA_ALPHA);
            }
        }
        #endregion
        public Form1()
        {
            InitializeComponent();
            SetPenetrate();
        }
    }
}
