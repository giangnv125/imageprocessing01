using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.IO;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.ML;
using Emgu.CV.ML.Structure;
using Emgu.CV.OCR;
using OxyPlot;
using OxyPlot.Series;
using Tesseract;

namespace ImageProcessing01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap bitmap;
        Image<Bgr, byte> imgIn;
        System.Diagnostics.Stopwatch st = new System.Diagnostics.Stopwatch();
        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bitmap = new Bitmap(open.FileName);
                imgIn = new Image<Bgr, byte>(bitmap);
                ptbLoad.Image = bitmap;

            }
        }

        private Bitmap RotateBitmap(Bitmap b, float angle)
        {
            Bitmap bm = new Bitmap(b.Width, b.Height);
            Graphics g = Graphics.FromImage(bm);
            g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
            g.RotateTransform(angle);
            g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
            g.DrawImage(b, new Point(0, 0));
            g.Dispose();
            return bm;
        }



        private void nudDegree_ValueChanged(object sender, EventArgs e)
        {
            st.Reset();
            st.Start();

            float Degree = (float)nudDegree.Value;
            ptbLoad.Image = RotateBitmap(bitmap, Degree);

            st.Stop();
            TimeSpan timespan = st.Elapsed;
            lblRotation.Text = Convert.ToString(timespan.TotalMilliseconds + "\t ms");
        }

        private void convertGray(Bitmap bmpSource, Bitmap bmpNew)
        {
            BitmapData data24 = bmpSource.LockBits(new Rectangle(0, 0, bmpSource.Width, bmpSource.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData data8 = bmpNew.LockBits(new Rectangle(0, 0, bmpNew.Width, bmpNew.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            int i, j;
            unsafe
            {
                int pos24, pos8;
                //int offset24 = data24.Stride - bitmap.Width * 3;
                //int offset8=data8.Stride-bitmap.Width;
                byte* p24 = (byte*)(data24.Scan0.ToPointer());
                byte* p8 = (byte*)(data8.Scan0.ToPointer());
                for (i = 0; i < data8.Height; i++)
                {
                    for (j = 0; j < data8.Width; j++)
                    {
                        pos8 = j + i * data8.Stride;
                        pos24 = 3 * j + i * data24.Stride;
                        p8[pos8] = (byte)((int)(p24[pos24] + p24[pos24 + 1] + p24[pos24 + 2]) / 3);
                    }
                    //p24 += offset24;
                    //p8 += offset8;

                }
            }

            bmpSource.UnlockBits(data24);
            bmpNew.UnlockBits(data8);
        }

        unsafe
        private void ptbLoad_MouseDown(object sender, MouseEventArgs e)
        {
            st.Reset();
            st.Start();

            int[,] gray = new int[bitmap.Width, bitmap.Height];
            //Chuyển ảnh xám trực tiếp trên bitmap
            BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadWrite, bitmap.PixelFormat);
            int offset = data.Stride - bitmap.Width * 3;
            byte* p = (byte*)data.Scan0;

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    int t = (int)(p[0] + p[1] + p[2]) / 3; //Y = 0.2126 * R + 0.7152 * G + 0.0722 * B
                    p[0] = p[1] = p[2] = (byte)t;

                    gray[i, j] = t;
                    p += 3;      //áp dụng cho ảnh jpg, jpeg 24bit, ảnh png p+=4 do có thành phần thể hiện độ trong suốt
                }
                p += offset;
            }

            bitmap.UnlockBits(data);
            ptbLoad.Image = bitmap;

            //Bitmap bmpNew = new Bitmap(bitmap.Width, bitmap.Height, PixelFormat.Format8bppIndexed);

            //PixelFormat format = bitmap.PixelFormat;
            //if (format == PixelFormat.Format24bppRgb)
            //{
            //    convertGray(bitmap, bmpNew);
            //    ptbLoad.Image = bmpNew;
            //}

            int x = e.X;
            int y = e.Y;

            Graphics gfx = ptbLoad.CreateGraphics();
            gfx.DrawLine(
                new Pen(Color.Red, 3f),
               new Point(x, 0),
               new Point(x, y - 5));
            gfx.DrawLine(
                new Pen(Color.Red, 3f),
               new Point(x, bitmap.Height),
               new Point(x, y + 5));
            gfx.DrawLine(
                new Pen(Color.Red, 3f),
               new Point(0, y),
               new Point(x - 5, y));
            gfx.DrawLine(
               new Pen(Color.Red, 3f),
              new Point(bitmap.Width, y),
              new Point(x + 5, y));

            PlotModel pm1 = new PlotModel();
            OxyPlot.Axes.LinearAxis XAxis1 = new OxyPlot.Axes.LinearAxis
            { Position = OxyPlot.Axes.AxisPosition.Bottom, Minimum = 0, Maximum = bitmap.Width };

            OxyPlot.Axes.LinearAxis YAxis1 = new OxyPlot.Axes.LinearAxis
            { Position = OxyPlot.Axes.AxisPosition.Left, Minimum = 0, Maximum = 255 };
            pm1.Axes.Add(XAxis1);
            pm1.Axes.Add(YAxis1);

            var s1 = new LineSeries { Title = "rectX", StrokeThickness = 1 };

            plotView2.Model = pm1;
            for (int i = 0; i < bitmap.Width; i++)
            {
                s1.Points.Add(new DataPoint(i, gray[i, y]));
            }

            plotView2.Model.Series.Add(s1);

            PlotModel pm2 = new PlotModel();
            OxyPlot.Axes.LinearAxis XAxis2 = new OxyPlot.Axes.LinearAxis
            { Position = OxyPlot.Axes.AxisPosition.Left, Minimum = 0, Maximum = 255 };

            OxyPlot.Axes.LinearAxis YAxis2 = new OxyPlot.Axes.LinearAxis
            { Position = OxyPlot.Axes.AxisPosition.Bottom, Minimum = 0, Maximum = bitmap.Height };

            pm2.Axes.Add(XAxis2);
            pm2.Axes.Add(YAxis2);

            var s2 = new LineSeries { Title = "rectY", StrokeThickness = 1 };

            plotView1.Model = pm2;
            for (int i = 0; i < bitmap.Height; i++)
            {
                s2.Points.Add(new DataPoint(gray[x, i], i));
            }

            plotView1.Model.Series.Add(s2);

            //for (int i=0; i<bitmap.Width; i++)
            //{

            //}

            //drawGraph(chartRectX, x, gray[x, y], bitmap.Width);
            //drawGraph(chartRectY, y, gray[x, y], bitmap.Height);

            st.Stop();
            TimeSpan timespan = st.Elapsed;
            lblPointChecker.Text = Convert.ToString(timespan.TotalMilliseconds + "\t ms");
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            int i = 0;
            st.Reset();
            st.Start();
            string[] images = Directory.GetFiles(@"C:\Users\ADMIN\Downloads", "*.jpg");

            foreach (string image in images)
            {
                Bitmap bm = new Bitmap(image);
                Bitmap bmTemp = bm;
                ptbLoad.Image = bmTemp;
                bm.Dispose();
                bm = null;
                i++;

            }
            st.Stop();
            TimeSpan timespan = st.Elapsed;
            lblPointChecker.Text = Convert.ToString(timespan.TotalMilliseconds + "\t ms");
            //lblRotation.Text = Convert.ToString(i);
        }
        private void btnOCR_Click(object sender, EventArgs e)
        {
            var ocr = new TesseractEngine("./tessdata", "eng", EngineMode.TesseractAndCube);

            Image<Gray, byte> imgOut = imgIn.Convert<Gray, byte>().Not().ThresholdBinary(new Gray(50), new Gray(255));
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat matImg = new Mat();

            CvInvoke.FindContours(imgOut, contours, matImg, Emgu.CV.CvEnum.RetrType.External,
                Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);
            //contours = FilterContours(contours, 500);
            if (contours.Size > 0)
            {
                for (int i = 0; i < contours.Size; i++)
                {
                    Rectangle rect = CvInvoke.BoundingRectangle(contours[i]);
                    imgIn.ROI = rect;

                    listBox.Items.Add(rect.Location.X);
                    listBox.Items.Add(rect.Location.Y);

                    Bitmap img = imgIn.Copy().Bitmap;
                    imgIn.Dispose();

                    var temp = ocr.Process(img);
                    img.Dispose();
                    txtOCR.Text = temp.GetText();
                    listBox.Items.Add(temp.GetText());
                }
            }
        }

        private void basicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.oCRToolStripMenuItem.Click += new System.EventHandler(this.oCRToolStripMenuItem_Click);
            panel2.Controls.Add(this.lblRotation);
            panel2.Controls.Add(this.lblPointChecker);
            MainMenuStrip = this.menuStrip1;
            panel2.Controls.Add(nudDegree);
            this.nudDegree.ValueChanged += new System.EventHandler(this.nudDegree_ValueChanged);
            this.Controls.Add(this.panel1);
            panel2.Controls.Add(this.btnPlay);
            btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            panel2.Controls.Add(this.plotView2);
            plotView2.SuspendLayout();
            panel2.Controls.Add(this.plotView1);
            plotView1.SuspendLayout();
            panel2.Controls.Add(this.btnLoad);
            btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            panel2.Controls.Add(plotView1);
            //((System.ComponentModel.ISupportInitialize)(this.plotView1)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.plotView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLoad)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDegree)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
            if (panel2.Controls.Contains(btnOCR))
            {
                this.btnOCR.Click -= new System.EventHandler(this.btnOCR_Click);
                panel2.Controls.Remove(txtOCR);
                txtOCR.Dispose();

                panel2.Controls.Remove(btnOCR);
                btnOCR.Dispose();
            }
        }

        private void oCRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.basicToolStripMenuItem.Click += new System.EventHandler(this.basicToolStripMenuItem_Click);
            panel2.Controls.Add(this.btnOCR);
            MainMenuStrip = this.menuStrip1;
            this.panel2.Controls.Add(this.txtOCR);
            panel2.Controls.Add(this.listBox);
            btnOCR.Click += new System.EventHandler(this.btnOCR_Click);
            if (panel2.Controls.Contains(btnPlay))
            {
                this.btnPlay.Click -= new System.EventHandler(this.btnPlay_Click);
                panel2.Controls.Remove(btnPlay);
                btnPlay.Dispose();

                this.nudDegree.ValueChanged -= new System.EventHandler(this.nudDegree_ValueChanged);
                panel2.Controls.Remove(nudDegree);
                nudDegree.Dispose();

                panel2.Controls.Remove(lblPointChecker);
                lblPointChecker.Dispose();

                panel2.Controls.Remove(lblRotation);
                lblRotation.Dispose();

                panel2.Controls.Remove(plotView1);
               plotView1.Dispose();

                panel2.Controls.Remove(plotView2);
                plotView2.Dispose();
            }           
        }
    }
}
