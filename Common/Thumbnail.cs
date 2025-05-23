using System;
using System.Drawing;
using System.IO;

namespace Pbzx.Common
{
    public class Thumbnail
    {
        public static void GetThumb(string filename1, string filename2, double width, double height)
        {
            System.Drawing.Image oldImg = System.Drawing.Image.FromFile(filename1);
            Double oldW = oldImg.Width;
            Double oldH = oldImg.Height;
            if (oldW / width >= oldH / height)
            {
                if (oldW > width)
                {

                    oldH = oldH * width / oldW; oldW = width;///             
                }
                else
                {
                    if (oldH > height)
                    {

                        oldW = oldW * height / oldH; oldH = height;
                    }
                }
                System.Drawing.Size size = new Size((int)oldW, (int)oldH);
                System.Drawing.Image bitmap = new System.Drawing.Bitmap(size.Width, size.Height);
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.Clear(Color.White);
                g.DrawImage(oldImg, new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), new System.Drawing.Rectangle(0, 0, oldImg.Width, oldImg.Height), System.Drawing.GraphicsUnit.Pixel);
                bitmap.Save(filename2 + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                g.Dispose();
                oldImg.Dispose();
                bitmap.Dispose();
            }
        }

        #region//getThumbnail:按指定的尺寸生成缩略图(保持原图的尺寸比例).
        /// <summary>
        /// 从图片文件的文件生成缩略图,并保存为文件..
        /// </summary>
        /// <param name="MyImage">原图片路径和文件名.</param>
        /// <param name="MyStream">保存图片的路径和文件名.</param>
        /// <param name="tWidth">限定的宽度.</param>
        /// <param name="tHeight">限定的高度.</param>
        public static void getThumbnail(string strFromFile, string strFileName, int tWidth, int tHeight)
        {
            Image MyImage = Image.FromFile(strFromFile);
            DrawingThumbnail(MyImage, strFileName, tWidth, tHeight);
        }

        /// <summary>
        /// 从流生成缩略图,并保存为文件..
        /// </summary>
        /// <param name="MyImage">原数据流.</param>
        /// <param name="MyStream">保存图片的路径和文件名.</param>
        /// <param name="tWidth">限定的宽度.</param>
        /// <param name="tHeight">限定的高度.</param>
        public static void getThumbnail(System.IO.Stream stFrom, string strFileName, int tWidth, int tHeight)
        {
            Image MyImage = Image.FromStream(stFrom);
            DrawingThumbnail(MyImage, strFileName, tWidth, tHeight);
        }

        /// <summary>
        /// 从图片生成缩略图,并保存为文件..
        /// </summary>
        /// <param name="MyImage">原图片对象.</param>
        /// <param name="MyStream">保存图片的路径和文件名.</param>
        /// <param name="tWidth">限定的宽度.</param>
        /// <param name="tHeight">限定的高度.</param>
        public static void getThumbnail(Image MyImage, string strFileName, int tWidth, int tHeight)
        {
            DrawingThumbnail(MyImage, strFileName, tWidth, tHeight);
        }

        /// <summary>
        /// 从上传的文件生成缩略图,并保存为文件.
        /// </summary>
        /// <param name="MyImage">上传控件.</param>
        /// <param name="MyStream">保存图片的路径和文件名.</param>
        /// <param name="tWidth">限定的宽度.</param>
        /// <param name="tHeight">限定的高度.</param>
        public static void getThumbnail(System.Web.UI.HtmlControls.HtmlInputFile MyPostFile, string strFileName, int tWidth, int tHeight)
        {
            System.IO.Stream oStream = MyPostFile.PostedFile.InputStream;
            Image MyImage = Image.FromStream(oStream);
            DrawingThumbnail(MyImage, strFileName, tWidth, tHeight);
            oStream.Close();
        }

        /// <summary>
        /// 从一个图片文件生成缩略图,并输出到流.
        /// </summary>
        /// <param name="MyImage">原图片路径和文件名.</param>
        /// <param name="MyStream">用来接收的流.</param>
        /// <param name="tWidth">限定的宽度.</param>
        /// <param name="tHeight">限定的高度.</param>
        public static void getThumbnail(string strFromFile, ref System.IO.Stream MyStream, int tWidth, int tHeight)
        {
            Image MyImage = Image.FromFile(strFromFile);
            DrawingThumbnail(MyImage, ref MyStream, tWidth, tHeight);
        }

        /// <summary>
        /// 从流生成缩略图,并输出到流.
        /// </summary>
        /// <param name="MyImage">原数据流.</param>
        /// <param name="MyStream">用来接收的流.</param>
        /// <param name="tWidth">限定的宽度.</param>
        /// <param name="tHeight">限定的高度.</param>
        public static void getThumbnail(System.IO.Stream stFrom, ref System.IO.Stream MyStream, int tWidth, int tHeight)
        {
            Image MyImage = Image.FromStream(stFrom);
            DrawingThumbnail(MyImage, ref MyStream, tWidth, tHeight);
        }

        /// <summary>
        /// 从图片生成缩略图,并输出到流.
        /// </summary>
        /// <param name="MyImage">原图片对象.</param>
        /// <param name="MyStream">用来接收的流.</param>
        /// <param name="tWidth">限定的宽度.</param>
        /// <param name="tHeight">限定的高度.</param>
        public static void getThumbnail(Image MyImage, ref System.IO.Stream MyStream, int tWidth, int tHeight)
        {
            DrawingThumbnail(MyImage, ref MyStream, tWidth, tHeight);
        }

        /// <summary>
        /// 从上传的图片生成缩略图,并输出到流.
        /// </summary>
        /// <param name="MyImage">上传控件.</param>
        /// <param name="MyStream">用来接收的流.</param>
        /// <param name="tWidth">限定的宽度.</param>
        /// <param name="tHeight">限定的高度.</param>
        public static void getThumbnail(System.Web.UI.HtmlControls.HtmlInputFile MyPostFile, ref System.IO.Stream MyStream, int tWidth, int tHeight)
        {
            System.IO.Stream oStream = MyPostFile.PostedFile.InputStream;
            Image MyImage = Image.FromStream(oStream);
            DrawingThumbnail(MyImage, ref MyStream, tWidth, tHeight);
            oStream.Close();
        }

        /// <summary>
        /// 从一个图片文件生成缩略图,并输出到流.
        /// </summary>
        /// <param name="MyImage">原图片路径和文件名.</param>
        /// <param name="MyStream">用来接收的流.</param>
        /// <param name="tWidth">限定的宽度.</param>
        /// <param name="tHeight">限定的高度.</param>
        public static void getThumbnail(string strFromFile, int tWidth, int tHeight)
        {
            Image MyImage = Image.FromFile(strFromFile);
            DrawingThumbnail(MyImage, tWidth, tHeight);
        }

        /// <summary>
        /// 从流生成缩略图,并输出到流.
        /// </summary>
        /// <param name="MyImage">原数据流.</param>
        /// <param name="MyStream">用来接收的流.</param>
        /// <param name="tWidth">限定的宽度.</param>
        /// <param name="tHeight">限定的高度.</param>
        public static void getThumbnail(System.IO.Stream stFrom, int tWidth, int tHeight)
        {
            Image MyImage = Image.FromStream(stFrom);
            DrawingThumbnail(MyImage, tWidth, tHeight);
        }

        /// <summary>
        /// 从图片生成缩略图,并输出到流.
        /// </summary>
        /// <param name="MyImage">原图片对象.</param>
        /// <param name="MyStream">用来接收的流.</param>
        /// <param name="tWidth">限定的宽度.</param>
        /// <param name="tHeight">限定的高度.</param>
        public static void getThumbnail(Image MyImage, int tWidth, int tHeight)
        {
            DrawingThumbnail(MyImage, tWidth, tHeight);
        }

        /// <summary>
        /// 从上传的图片生成缩略图,并输出到流.
        /// </summary>
        /// <param name="MyImage">上传控件.</param>
        /// <param name="MyStream">用来接收的流.</param>
        /// <param name="tWidth">限定的宽度.</param>
        /// <param name="tHeight">限定的高度.</param>
        public static void getThumbnail(System.Web.UI.HtmlControls.HtmlInputFile MyPostFile, int tWidth, int tHeight)
        {
            System.IO.Stream oStream = MyPostFile.PostedFile.InputStream;
            Image MyImage = Image.FromStream(oStream);
            DrawingThumbnail(MyImage, tWidth, tHeight);
            oStream.Close();
        }
        #endregion

        #region//DrawingThumbnail:私有方法,实际处理图片的方法.
        /// <summary>
        /// 将传入的图片按照指定的尺寸生成缩略图,并输出到一个流.
        /// </summary>
        /// <param name="MyImage">原图片.</param>
        /// <param name="MyStream">用来接收的流.</param>
        /// <param name="tWidth">限定的宽度.</param>
        /// <param name="tHeight">限定的高度.</param>
        private static void DrawingThumbnail(System.Drawing.Image MyImage, ref System.IO.Stream MyStream, int tWidth, int tHeight)
        {
            int oWidth = MyImage.Width; //原图宽度 
            int oHeight = MyImage.Height; //原图高度 

            //按比例计算出缩略图的宽度和高度 
            if (oWidth >= oHeight)
            {
                tHeight = (int)Math.Floor(Convert.ToDouble(oHeight) * (Convert.ToDouble(tWidth) / Convert.ToDouble(oWidth)));
            }
            else
            {
                tWidth = (int)Math.Floor(Convert.ToDouble(oWidth) * (Convert.ToDouble(tHeight) / Convert.ToDouble(oHeight)));
            }

            //生成缩略原图 
            Bitmap tImage = new Bitmap(tWidth, tHeight);
            Graphics g = Graphics.FromImage(tImage);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic; //设置高质量插值法 
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;//设置高质量,低速度呈现平滑程度 
            g.Clear(Color.Transparent); //清空画布并以透明背景色填充 
            g.DrawImage(MyImage, new Rectangle(0, 0, tWidth, tHeight), new Rectangle(0, 0, oWidth, oHeight), GraphicsUnit.Pixel);

            try
            {
                tImage.Save(MyStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch
            {
            }
            finally
            {
                MyImage.Dispose();
                tImage.Dispose();
            }
        }

        /// <summary>
        /// 将传入的图片按照指定的尺寸生成缩略图,并输出到一个流.
        /// </summary>
        /// <param name="MyImage">原图片.</param>
        /// <param name="MyStream">用来接收的流.</param>
        /// <param name="tWidth">限定的宽度.</param>
        /// <param name="tHeight">限定的高度.</param>
        private static void DrawingThumbnail(System.Drawing.Image MyImage, int tWidth, int tHeight)
        {
            int oWidth = MyImage.Width; //原图宽度 
            int oHeight = MyImage.Height; //原图高度 

            //按比例计算出缩略图的宽度和高度 
            if (oWidth >= oHeight)
            {
                tHeight = (int)Math.Floor(Convert.ToDouble(oHeight) * (Convert.ToDouble(tWidth) / Convert.ToDouble(oWidth)));
            }
            else
            {
                tWidth = (int)Math.Floor(Convert.ToDouble(oWidth) * (Convert.ToDouble(tHeight) / Convert.ToDouble(oHeight)));
            }

            //生成缩略原图 
            Bitmap tImage = new Bitmap(tWidth, tHeight);
            Graphics g = Graphics.FromImage(tImage);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic; //设置高质量插值法 
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;//设置高质量,低速度呈现平滑程度 
            g.Clear(Color.Transparent); //清空画布并以透明背景色填充 
            g.DrawImage(MyImage, new Rectangle(0, 0, tWidth, tHeight), new Rectangle(0, 0, oWidth, oHeight), GraphicsUnit.Pixel);

            try
            {
                tImage.Save(System.Web.HttpContext.Current.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch
            {
            }
            finally
            {
                MyImage.Dispose();
                tImage.Dispose();
            }
        }

        /// <summary>
        /// 将传入的图片按照指定的尺寸生成缩略图,并保存为一个文件.
        /// </summary>
        /// <param name="MyImage">原图片.</param>
        /// <param name="MyStream">保存图片的路径和文件名.</param>
        /// <param name="tWidth">限定的宽度.</param>
        /// <param name="tHeight">限定的高度.</param>
        private static void DrawingThumbnail(System.Drawing.Image MyImage, string strFileName, int tWidth, int tHeight)
        {
            int oWidth = MyImage.Width; //原图宽度 
            int oHeight = MyImage.Height; //原图高度 

            //按比例计算出缩略图的宽度和高度 
            if (oWidth >= oHeight)
            {
                tHeight = (int)Math.Floor(Convert.ToDouble(oHeight) * (Convert.ToDouble(tWidth) / Convert.ToDouble(oWidth)));
            }
            else
            {
                tWidth = (int)Math.Floor(Convert.ToDouble(oWidth) * (Convert.ToDouble(tHeight) / Convert.ToDouble(oHeight)));
            }

            //生成缩略原图 
            Bitmap tImage = new Bitmap(tWidth, tHeight);
            Graphics g = Graphics.FromImage(tImage);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic; //设置高质量插值法 
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;//设置高质量,低速度呈现平滑程度 
            g.Clear(Color.Transparent); //清空画布并以透明背景色填充 
            g.DrawImage(MyImage, new Rectangle(0, 0, tWidth, tHeight), new Rectangle(0, 0, oWidth, oHeight), GraphicsUnit.Pixel);
            try
            {
                tImage.Save(strFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch
            {
            }
            finally
            {
                MyImage.Dispose();
                tImage.Dispose();
            }
        }
        #endregion
    }
}
