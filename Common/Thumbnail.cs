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

        #region//getThumbnail:��ָ���ĳߴ���������ͼ(����ԭͼ�ĳߴ����).
        /// <summary>
        /// ��ͼƬ�ļ����ļ���������ͼ,������Ϊ�ļ�..
        /// </summary>
        /// <param name="MyImage">ԭͼƬ·�����ļ���.</param>
        /// <param name="MyStream">����ͼƬ��·�����ļ���.</param>
        /// <param name="tWidth">�޶��Ŀ��.</param>
        /// <param name="tHeight">�޶��ĸ߶�.</param>
        public static void getThumbnail(string strFromFile, string strFileName, int tWidth, int tHeight)
        {
            Image MyImage = Image.FromFile(strFromFile);
            DrawingThumbnail(MyImage, strFileName, tWidth, tHeight);
        }

        /// <summary>
        /// ������������ͼ,������Ϊ�ļ�..
        /// </summary>
        /// <param name="MyImage">ԭ������.</param>
        /// <param name="MyStream">����ͼƬ��·�����ļ���.</param>
        /// <param name="tWidth">�޶��Ŀ��.</param>
        /// <param name="tHeight">�޶��ĸ߶�.</param>
        public static void getThumbnail(System.IO.Stream stFrom, string strFileName, int tWidth, int tHeight)
        {
            Image MyImage = Image.FromStream(stFrom);
            DrawingThumbnail(MyImage, strFileName, tWidth, tHeight);
        }

        /// <summary>
        /// ��ͼƬ��������ͼ,������Ϊ�ļ�..
        /// </summary>
        /// <param name="MyImage">ԭͼƬ����.</param>
        /// <param name="MyStream">����ͼƬ��·�����ļ���.</param>
        /// <param name="tWidth">�޶��Ŀ��.</param>
        /// <param name="tHeight">�޶��ĸ߶�.</param>
        public static void getThumbnail(Image MyImage, string strFileName, int tWidth, int tHeight)
        {
            DrawingThumbnail(MyImage, strFileName, tWidth, tHeight);
        }

        /// <summary>
        /// ���ϴ����ļ���������ͼ,������Ϊ�ļ�.
        /// </summary>
        /// <param name="MyImage">�ϴ��ؼ�.</param>
        /// <param name="MyStream">����ͼƬ��·�����ļ���.</param>
        /// <param name="tWidth">�޶��Ŀ��.</param>
        /// <param name="tHeight">�޶��ĸ߶�.</param>
        public static void getThumbnail(System.Web.UI.HtmlControls.HtmlInputFile MyPostFile, string strFileName, int tWidth, int tHeight)
        {
            System.IO.Stream oStream = MyPostFile.PostedFile.InputStream;
            Image MyImage = Image.FromStream(oStream);
            DrawingThumbnail(MyImage, strFileName, tWidth, tHeight);
            oStream.Close();
        }

        /// <summary>
        /// ��һ��ͼƬ�ļ���������ͼ,���������.
        /// </summary>
        /// <param name="MyImage">ԭͼƬ·�����ļ���.</param>
        /// <param name="MyStream">�������յ���.</param>
        /// <param name="tWidth">�޶��Ŀ��.</param>
        /// <param name="tHeight">�޶��ĸ߶�.</param>
        public static void getThumbnail(string strFromFile, ref System.IO.Stream MyStream, int tWidth, int tHeight)
        {
            Image MyImage = Image.FromFile(strFromFile);
            DrawingThumbnail(MyImage, ref MyStream, tWidth, tHeight);
        }

        /// <summary>
        /// ������������ͼ,���������.
        /// </summary>
        /// <param name="MyImage">ԭ������.</param>
        /// <param name="MyStream">�������յ���.</param>
        /// <param name="tWidth">�޶��Ŀ��.</param>
        /// <param name="tHeight">�޶��ĸ߶�.</param>
        public static void getThumbnail(System.IO.Stream stFrom, ref System.IO.Stream MyStream, int tWidth, int tHeight)
        {
            Image MyImage = Image.FromStream(stFrom);
            DrawingThumbnail(MyImage, ref MyStream, tWidth, tHeight);
        }

        /// <summary>
        /// ��ͼƬ��������ͼ,���������.
        /// </summary>
        /// <param name="MyImage">ԭͼƬ����.</param>
        /// <param name="MyStream">�������յ���.</param>
        /// <param name="tWidth">�޶��Ŀ��.</param>
        /// <param name="tHeight">�޶��ĸ߶�.</param>
        public static void getThumbnail(Image MyImage, ref System.IO.Stream MyStream, int tWidth, int tHeight)
        {
            DrawingThumbnail(MyImage, ref MyStream, tWidth, tHeight);
        }

        /// <summary>
        /// ���ϴ���ͼƬ��������ͼ,���������.
        /// </summary>
        /// <param name="MyImage">�ϴ��ؼ�.</param>
        /// <param name="MyStream">�������յ���.</param>
        /// <param name="tWidth">�޶��Ŀ��.</param>
        /// <param name="tHeight">�޶��ĸ߶�.</param>
        public static void getThumbnail(System.Web.UI.HtmlControls.HtmlInputFile MyPostFile, ref System.IO.Stream MyStream, int tWidth, int tHeight)
        {
            System.IO.Stream oStream = MyPostFile.PostedFile.InputStream;
            Image MyImage = Image.FromStream(oStream);
            DrawingThumbnail(MyImage, ref MyStream, tWidth, tHeight);
            oStream.Close();
        }

        /// <summary>
        /// ��һ��ͼƬ�ļ���������ͼ,���������.
        /// </summary>
        /// <param name="MyImage">ԭͼƬ·�����ļ���.</param>
        /// <param name="MyStream">�������յ���.</param>
        /// <param name="tWidth">�޶��Ŀ��.</param>
        /// <param name="tHeight">�޶��ĸ߶�.</param>
        public static void getThumbnail(string strFromFile, int tWidth, int tHeight)
        {
            Image MyImage = Image.FromFile(strFromFile);
            DrawingThumbnail(MyImage, tWidth, tHeight);
        }

        /// <summary>
        /// ������������ͼ,���������.
        /// </summary>
        /// <param name="MyImage">ԭ������.</param>
        /// <param name="MyStream">�������յ���.</param>
        /// <param name="tWidth">�޶��Ŀ��.</param>
        /// <param name="tHeight">�޶��ĸ߶�.</param>
        public static void getThumbnail(System.IO.Stream stFrom, int tWidth, int tHeight)
        {
            Image MyImage = Image.FromStream(stFrom);
            DrawingThumbnail(MyImage, tWidth, tHeight);
        }

        /// <summary>
        /// ��ͼƬ��������ͼ,���������.
        /// </summary>
        /// <param name="MyImage">ԭͼƬ����.</param>
        /// <param name="MyStream">�������յ���.</param>
        /// <param name="tWidth">�޶��Ŀ��.</param>
        /// <param name="tHeight">�޶��ĸ߶�.</param>
        public static void getThumbnail(Image MyImage, int tWidth, int tHeight)
        {
            DrawingThumbnail(MyImage, tWidth, tHeight);
        }

        /// <summary>
        /// ���ϴ���ͼƬ��������ͼ,���������.
        /// </summary>
        /// <param name="MyImage">�ϴ��ؼ�.</param>
        /// <param name="MyStream">�������յ���.</param>
        /// <param name="tWidth">�޶��Ŀ��.</param>
        /// <param name="tHeight">�޶��ĸ߶�.</param>
        public static void getThumbnail(System.Web.UI.HtmlControls.HtmlInputFile MyPostFile, int tWidth, int tHeight)
        {
            System.IO.Stream oStream = MyPostFile.PostedFile.InputStream;
            Image MyImage = Image.FromStream(oStream);
            DrawingThumbnail(MyImage, tWidth, tHeight);
            oStream.Close();
        }
        #endregion

        #region//DrawingThumbnail:˽�з���,ʵ�ʴ���ͼƬ�ķ���.
        /// <summary>
        /// �������ͼƬ����ָ���ĳߴ���������ͼ,�������һ����.
        /// </summary>
        /// <param name="MyImage">ԭͼƬ.</param>
        /// <param name="MyStream">�������յ���.</param>
        /// <param name="tWidth">�޶��Ŀ��.</param>
        /// <param name="tHeight">�޶��ĸ߶�.</param>
        private static void DrawingThumbnail(System.Drawing.Image MyImage, ref System.IO.Stream MyStream, int tWidth, int tHeight)
        {
            int oWidth = MyImage.Width; //ԭͼ��� 
            int oHeight = MyImage.Height; //ԭͼ�߶� 

            //���������������ͼ�Ŀ�Ⱥ͸߶� 
            if (oWidth >= oHeight)
            {
                tHeight = (int)Math.Floor(Convert.ToDouble(oHeight) * (Convert.ToDouble(tWidth) / Convert.ToDouble(oWidth)));
            }
            else
            {
                tWidth = (int)Math.Floor(Convert.ToDouble(oWidth) * (Convert.ToDouble(tHeight) / Convert.ToDouble(oHeight)));
            }

            //��������ԭͼ 
            Bitmap tImage = new Bitmap(tWidth, tHeight);
            Graphics g = Graphics.FromImage(tImage);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic; //���ø�������ֵ�� 
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;//���ø�����,���ٶȳ���ƽ���̶� 
            g.Clear(Color.Transparent); //��ջ�������͸������ɫ��� 
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
        /// �������ͼƬ����ָ���ĳߴ���������ͼ,�������һ����.
        /// </summary>
        /// <param name="MyImage">ԭͼƬ.</param>
        /// <param name="MyStream">�������յ���.</param>
        /// <param name="tWidth">�޶��Ŀ��.</param>
        /// <param name="tHeight">�޶��ĸ߶�.</param>
        private static void DrawingThumbnail(System.Drawing.Image MyImage, int tWidth, int tHeight)
        {
            int oWidth = MyImage.Width; //ԭͼ��� 
            int oHeight = MyImage.Height; //ԭͼ�߶� 

            //���������������ͼ�Ŀ�Ⱥ͸߶� 
            if (oWidth >= oHeight)
            {
                tHeight = (int)Math.Floor(Convert.ToDouble(oHeight) * (Convert.ToDouble(tWidth) / Convert.ToDouble(oWidth)));
            }
            else
            {
                tWidth = (int)Math.Floor(Convert.ToDouble(oWidth) * (Convert.ToDouble(tHeight) / Convert.ToDouble(oHeight)));
            }

            //��������ԭͼ 
            Bitmap tImage = new Bitmap(tWidth, tHeight);
            Graphics g = Graphics.FromImage(tImage);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic; //���ø�������ֵ�� 
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;//���ø�����,���ٶȳ���ƽ���̶� 
            g.Clear(Color.Transparent); //��ջ�������͸������ɫ��� 
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
        /// �������ͼƬ����ָ���ĳߴ���������ͼ,������Ϊһ���ļ�.
        /// </summary>
        /// <param name="MyImage">ԭͼƬ.</param>
        /// <param name="MyStream">����ͼƬ��·�����ļ���.</param>
        /// <param name="tWidth">�޶��Ŀ��.</param>
        /// <param name="tHeight">�޶��ĸ߶�.</param>
        private static void DrawingThumbnail(System.Drawing.Image MyImage, string strFileName, int tWidth, int tHeight)
        {
            int oWidth = MyImage.Width; //ԭͼ��� 
            int oHeight = MyImage.Height; //ԭͼ�߶� 

            //���������������ͼ�Ŀ�Ⱥ͸߶� 
            if (oWidth >= oHeight)
            {
                tHeight = (int)Math.Floor(Convert.ToDouble(oHeight) * (Convert.ToDouble(tWidth) / Convert.ToDouble(oWidth)));
            }
            else
            {
                tWidth = (int)Math.Floor(Convert.ToDouble(oWidth) * (Convert.ToDouble(tHeight) / Convert.ToDouble(oHeight)));
            }

            //��������ԭͼ 
            Bitmap tImage = new Bitmap(tWidth, tHeight);
            Graphics g = Graphics.FromImage(tImage);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic; //���ø�������ֵ�� 
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;//���ø�����,���ٶȳ���ƽ���̶� 
            g.Clear(Color.Transparent); //��ջ�������͸������ɫ��� 
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
