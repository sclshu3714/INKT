using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
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
        }
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
