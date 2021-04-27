using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFInk
{
    /// <summary>
    /// 在一个控件上绘制虚线矩形，并返回矩形区域
    /// </summary>
    public class SetControlRectangle
    {
        /// <summary>
        /// 绘制的控件
        /// </summary>
        private Control m_Control;
        /// <summary>
        /// 鼠标状态
        /// </summary>
        private bool m_MouseIsDown = false;
        /// <summary>
        /// 绘制区域
        /// </summary>
        public Rectangle m_MouseRect = Rectangle.Empty;
        public delegate void SelectRectangel(object sender, Rectangle e);
        public event SelectRectangel SetRectangel;
        /// <summary>
        /// 需要绘制的图形
        /// </summary>
        /// <param name="p_Control"></param>
        public SetControlRectangle(Control p_Control) {
            m_Control = p_Control;
            m_Control.MouseDown += M_Control_MouseDown;
            m_Control.MouseUp += M_Control_MouseUp;
            m_Control.MouseMove += M_Control_MouseMove;
        }

        private void M_Control_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_MouseIsDown) ResizeToRectangle(new Point(e.X,e.Y));
        }

        private void M_Control_MouseUp(object sender, MouseEventArgs e)
        {
            m_Control.Capture = false;
            Cursor.Clip = Rectangle.Empty;
            m_MouseIsDown = false;
            DrawRectangle();
            if (m_MouseRect.X == 0 || m_MouseRect.Y == 0 || m_MouseRect.Width == 0 || m_MouseRect.Height == 0)
            {
                //不执行委托
            }
            else {
                if (SetRectangel != null) SetRectangel(m_Control, m_MouseRect);
            }
            m_MouseRect = Rectangle.Empty;
        }

        private void M_Control_MouseDown(object sender, MouseEventArgs e)
        {
            m_MouseIsDown = true;
            DrawStart(new Point(e.X,e.Y));
        }

        /// <summary>
        /// 刷新绘制
        /// </summary>
        /// <param name="p_Point"></param>
        private void ResizeToRectangle(Point p_Point) {
            DrawRectangle();
            m_MouseRect.Width = p_Point.X - m_MouseRect.Left;
            m_MouseRect.Height = p_Point.Y - m_MouseRect.Top;
            DrawRectangle();
        }
        /// <summary>
        /// 绘制区域
        /// </summary>
        private void DrawRectangle()
        {
            Rectangle _Rect = m_Control.RectangleToScreen(m_MouseRect);
            ControlPaint.DrawReversibleFrame(_Rect, Color.White, FrameStyle.Dashed);
        }

        /// <summary>
        /// 开始绘制，并且设置鼠标区域
        /// </summary>
        /// <param name="p_Point"></param>
        private void DrawStart(Point p_Point) {
            m_Control.Capture = true;
            Cursor.Clip = m_Control.RectangleToScreen(new Rectangle(0,0,m_Control.Width,m_Control.Height));
            m_MouseRect = new Rectangle(p_Point.X,p_Point.Y,0,0);
        }
    }
}
