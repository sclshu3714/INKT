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


namespace WFInk
{
	internal struct PointInfo
	{
		public Point pt; //点的位置
		public System.Windows.Vector dir; //与上一个点之间的方向
		public float len; //上一个点到这个点的距离
		public System.Windows.Vector perpendicular; //与上一个点之间的方向的垂直
		public System.Drawing.Point ToDrawingPoint()
		{
			return new System.Drawing.Point(Convert.ToInt32(pt.X), Convert.ToInt32(pt.Y));
		}
	}
	public partial class MainForm : Form
    {
        private Point ptStart; //起始点
        private Point ptEnd; //终点
		private List<PointInfo> ptinfos = new List<PointInfo>(); //点的信息
		public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
			this.canvas.MouseDown += canvas_MouseDown;
			this.canvas.MouseUp += canvas_MouseUp;
			this.canvas.MouseMove += Canvas_MouseMove;
		}
        private void canvas_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			ptEnd = e.Location;
			

			IsPressed = false;
		}

		private float lw = 5.0F;
		private bool IsPressed = false;

		private void Canvas_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Point pt = e.Location;
			
		}
		private void canvas_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			
			IsPressed = true;
		}

		private void MainForm_Load(object sender, EventArgs e)
		{

			InitRecognizer();
		}
		private Recognizers myRecognizers; // REM 所有识别器
		private Microsoft.Ink.Ink ink = new Microsoft.Ink.Ink(); // REM 墨迹
		private Strokes strokes; // REM 所有的笔画
		private RecognizerContext recognizectx; // REM 识别器上下文
												// Private myInkCollector As InkCollector
												// REM 初始化墨迹识别器
		public void InitRecognizer()
		{
			myRecognizers = new Recognizers();
			strokes = ink.CreateStrokes();
			recognizectx = myRecognizers.GetDefaultRecognizer().CreateRecognizerContext();
			recognizectx.Strokes = strokes;
		}

		private string[] Regconize() // REM 识别 ptinfos 中的点
		{
			List<Point> listpts = new List<Point>();
            foreach (var i in ptinfos)
                listpts.Add(i.ToDrawingPoint());
            // REM 每一笔转换成stroke
            Stroke stroke = ink.CreateStroke(listpts.ToArray());
			// REM 添加到识别器的上下文
			recognizectx.Strokes.Add(stroke);
			RecognitionStatus recognizestatus = new RecognitionStatus();
			RecognitionResult recognizeresult = recognizectx.Recognize(out recognizestatus);
			// REM 识别器的所有选择
			RecognitionAlternates recognizealternates = recognizeresult.GetAlternatesFromSelection();
			// REM 列出识别器所识别出的内容
			List<string> result = new List<string>();
			for (var i = 0; i <= recognizealternates.Count - 1; i++)
			{
				string text = recognizealternates[i].ToString();
				// Console.WriteLine(text)
				result.Add(text);
			}
			return result.ToArray();
		}

		private void buttonClear_Click(object sender, EventArgs e)
		{
			
		}
		private void buttonUndo_Click(object sender, EventArgs e)
		{
			
		}

		public void CreateNewBitmap()
		{
			
		}
		private byte[] BitmapSourceToByteArray(System.Windows.Media.Imaging.BitmapSource bmpSrc)
		{
			var encoder = new System.Windows.Media.Imaging.JpegBitmapEncoder();
			encoder.QualityLevel = 100;
			encoder.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(bmpSrc));

			using (var stream = new MemoryStream())
			{
				encoder.Save(stream);
				return stream.ToArray();
			}
		}
	}
}
