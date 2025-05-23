﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Drawing;

public partial class n9_port_checkcode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string[] str = new string[3];
            string serverCode = "";
            //生成随机生成器 
            Random random = new Random();
            for (int i = 0; i < 3; i++)
            {
                str[i] = random.Next(10).ToString().Substring(0, 1);
            }
            CreateCheckCodeImage(str);
            foreach (string s in str)
            {
                serverCode += s;
            }
            Session["CHECKCODEIMG"] = serverCode;
           
        }
        catch
        { 
        
        }
    }

    private void CreateCheckCodeImage(string[] checkCode)
    {
        if (checkCode == null || checkCode.Length <= 0)
        {
            return;
        }
            

        System.Drawing.Bitmap image = new System.Drawing.Bitmap((int)Math.Ceiling((checkCode.Length * 32.5)), 30);

        System.Drawing.Graphics g = Graphics.FromImage(image);

        try
        {
            Random random = new Random();
            //清空图片背景色 
            g.Clear(ColorTranslator.FromHtml("#F7F7F7"));

            //画图片的背景噪音线 
            for (int i = 0; i < 8; i++)
            {
                int x1 = random.Next(image.Width);
                int x2 = random.Next(image.Width);
                int y1 = random.Next(image.Height);
                int y2 = random.Next(image.Height);

                g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            }

            //定义颜色
            Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };
            //定义字体
            string[] f = { "Arial", "Arial", "Arial", "Arial", "Arial" };

            for (int k = 0; k <= checkCode.Length - 1; k++)
            {
                int cindex = random.Next(7);
                int findex = random.Next(5);

                Font drawFont = new Font(f[findex], 12, (System.Drawing.FontStyle.Bold));

                SolidBrush drawBrush = new SolidBrush(c[cindex]);

                float x = 5.0F;
                float y = 0.0F;
                float width = 20.0F;
                float height = 25.0F;
                int sjx = random.Next(10);
                //int sjy = random.Next(image.Height - (int)height);
                int sjy = 4;

                RectangleF drawRect = new RectangleF(x + sjx + (k * 25), y + sjy, width, height);

                StringFormat drawFormat = new StringFormat();
                drawFormat.Alignment = StringAlignment.Center;

                g.DrawString(checkCode[k], drawFont, drawBrush, drawRect, drawFormat);
            }

            //画图片的前景噪音点 
            for (int i = 0; i < 10; i++)
            {
                int x = random.Next(image.Width);
                int y = random.Next(image.Height);

                image.SetPixel(x, y, Color.FromArgb(random.Next()));
            }

            //画图片的边框线 
            //g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            Response.ClearContent();
            //Response.ContentType = "image/Gif";
            Response.ContentType = "image/jpg";
            Response.BinaryWrite(ms.ToArray());
        }
        catch(Exception ex)
        {
            Response.Write(ex.ToString());
        }
        finally
        {
            g.Dispose();
            image.Dispose();
        }
    }

}
