﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WFInk
{
    public static class ToBitmapTool
    {
        /// <summary>
        /// 截图转换成bitmap
        /// </summary>
        /// <param name="element"></param>
        /// <param name="width">默认控件宽度</param>
        /// <param name="height">默认控件高度</param>
        /// <param name="x">默认0</param>
        /// <param name="y">默认0</param>
        /// <returns></returns>
        public static Bitmap ToBitmap(this FrameworkElement element, int width = 0, int height = 0, int x = 0, int y = 0)
        {
            if (width == 0) width = (int)element.ActualWidth;
            if (height == 0) height = (int)element.ActualHeight;

            var rtb = new RenderTargetBitmap(width, height, x, y, System.Windows.Media.PixelFormats.Default);
            rtb.Render(element);
            var bit = BitmapSourceToBitmap(rtb);

            //测试代码
            DirectoryInfo d = new DirectoryInfo(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Cache"));
            if (!d.Exists) d.Create();
            bit.Save(System.IO.Path.Combine(d.FullName, "控件截图.png"));

            return bit;
        }

        /// <summary>
        /// BitmapSource转Bitmap
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Bitmap BitmapSourceToBitmap(this BitmapSource source)
        {
            return BitmapSourceToBitmap(source, source.PixelWidth, source.PixelHeight);
        }

        /// <summary>
        /// Convert BitmapSource to Bitmap
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Bitmap BitmapSourceToBitmap(this BitmapSource source, int width, int height)
        {
            Bitmap bmp = null;
            try
            {
                PixelFormat format = PixelFormat.Format24bppRgb;
                /*set the translate type according to the in param(source)*/
                switch (source.Format.ToString())
                {
                    case "Rgb24":
                    case "Bgr24": format = PixelFormat.Format24bppRgb; break;
                    case "Bgra32": format = PixelFormat.Format32bppPArgb; break;
                    case "Bgr32": format = PixelFormat.Format32bppRgb; break;
                    case "Pbgra32": format = PixelFormat.Format32bppArgb; break;
                }
                bmp = new Bitmap(width, height, format);
                BitmapData data = bmp.LockBits(new System.Drawing.Rectangle(System.Drawing.Point.Empty, bmp.Size),
                    ImageLockMode.WriteOnly,
                    format);
                source.CopyPixels(Int32Rect.Empty, data.Scan0, data.Height * data.Stride, data.Stride);
                bmp.UnlockBits(data);
            }
            catch
            {
                if (bmp != null)
                {
                    bmp.Dispose();
                    bmp = null;
                }
            }

            return bmp;
        }
    }
}
