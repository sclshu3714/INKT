using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyInk
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        ///win32 api
        private const int WS_EX_TRANSPARENT = 0x20;
        private const int GWL_EXSTYLE = (-20);
        private const uint WS_EX_LAYERED = 0x80000;
        private const int GWL_STYLE = (-16);
        private const int LWA_ALPHA = 0;

        [DllImport("user32", EntryPoint = "SetWindowLong")]
        private static extern uint SetWindowLong(IntPtr hwnd, int nIndex, long dwNewLong);

        [DllImport("user32", EntryPoint = "GetWindowLong")]
        private static extern uint GetWindowLong(IntPtr hwnd, int nIndex);

        [DllImport("user32", EntryPoint = "SetLayeredWindowAttributes")]

        private static extern int SetLayeredWindowAttributes(IntPtr hwnd,int crKey,int bAlpha,int dwFlags);

        ///
        /// 设置窗体具有鼠标穿透效果
        ///
        public void SetPenetrate()
        {
            IntPtr hwnd = new WindowInteropHelper(this).Handle;
            GetWindowLong(hwnd, GWL_EXSTYLE);
            SetWindowLong(hwnd, GWL_EXSTYLE, WS_EX_TRANSPARENT | WS_EX_LAYERED);
            SetLayeredWindowAttributes(hwnd, 0, 100, LWA_ALPHA);
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DrawingAttributes drawingAttributes = this.inkCanvas.DefaultDrawingAttributes;
            drawingAttributes.Color = Color.FromRgb(128,128,255);
            drawingAttributes.StylusTip = StylusTip.Rectangle;
            drawingAttributes.Width = 2;
            drawingAttributes.Height = 5;
            drawingAttributes.IsHighlighter = true;
            drawingAttributes.IgnorePressure = true;
            drawingAttributes.FitToCurve = true;
            inkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            //this.SourceInitialized += delegate
            //{
            //    IntPtr hwnd = new WindowInteropHelper(this).Handle; 
            //    uint extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
            //    SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle | WS_EX_TRANSPARENT);
            //};
            //SourceInitialized += delegate
            //{
            //    IntPtr hwnd = new WindowInteropHelper(this).Handle;
            //    //long OldLong = GetWindowLong(hwnd,(-20));
            //    SetWindowLong(hwnd, (-20), 0x20);
            //};
        }

        //protected override void OnSourceInitialized(EventArgs e) {
        //    IntPtr hwnd = new WindowInteropHelper(this).Handle;
        //    //long OldLong = GetWindowLong(hwnd,(-20));
        //    SetWindowLong(hwnd, (-20), 0x20);
        //}
        void btn_Click(object sender, RoutedEventArgs e)
        {
            ImageSource imageSource = new BitmapImage(new Uri(@"C:\Users\33169\Pictures\SharedScreenshot.jpg", UriKind.Absolute));
            //draw bitmap onto the Canvas
            DrawingVisual dv = new DrawingVisual();
            DrawingContext dc = dv.RenderOpen();
            dc.DrawImage(imageSource, new Rect(350d, 20d, inkCanvas.Width,
            inkCanvas.Height));
            dc.Close();
        }
    }
}
