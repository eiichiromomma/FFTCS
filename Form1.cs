using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace FFTCS
{
    public partial class Form1 : Form
    {
        VideoCapture cap;
        List<System.Drawing.Point> pts;
        Graphics CAMgraphics;
        Graphics FFTgraphics;
        Graphics IFFTgraphics;
        Graphics FILTERgraphics;
        Stack<List<System.Drawing.Point>> Strokes;
        Mat filter;
        Pen wpen;
        Pen drawPen;
        public Form1()
        {
            InitializeComponent();
        }

        private Mat mulChecker(Mat m)
        {
            for (int y = 0; y < m.Rows; y++)
            {
                for (int x = 0; x < m.Cols; x++)
                {
                    m.Set(y, x, m.Get<double>(y, x) * Math.Pow(-1, x + y));
                }
            }
            return m;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Mat frame = new Mat();
            Mat tmpImg = new Mat();
            Mat gframe = new Mat();
            Mat padded = new Mat();
            Mat padded32 = new Mat();
            cap.Read(frame);

            //表示
            var dy = (float)(CAMpictureBox.Height) / frame.Height;
            tmpImg = frame.Resize(new OpenCvSharp.Size(frame.Width * dy, CAMpictureBox.Height));
            Bitmap tmpBitmap = BitmapConverter.ToBitmap(tmpImg);
            CAMgraphics.DrawImage(tmpBitmap, 0, 0, tmpImg.Width, tmpImg.Height);

            Cv2.CvtColor(frame, gframe, ColorConversionCodes.BGR2GRAY);
            var m = Cv2.GetOptimalDFTSize(gframe.Rows);
            var n = Cv2.GetOptimalDFTSize(gframe.Cols);
            Cv2.CopyMakeBorder(gframe, padded, 0, m - gframe.Rows, 0, n - gframe.Cols, BorderTypes.Constant, Scalar.All(0));
            padded.ConvertTo(padded32, MatType.CV_32F, 1 / 255.0, 0);
            //Mulを使うとメモリをガンガン使って不安になるので自前で-1^(x+y)をやる
            padded32 = mulChecker(padded32);

            // フーリエ
            Mat tmpZero = new Mat(padded32.Size(), MatType.CV_32F);
            Mat dft = new Mat();
            Mat[] complex = { padded32, tmpZero };
            Mat mergedComplex = new Mat();
            Cv2.Merge(complex, mergedComplex);
            Cv2.Dft(mergedComplex, dft, DftFlags.None, 0);
            // 0:実部，1:虚部なのでSplitする
            Mat[] dftplanes = Cv2.Split(dft);
            Mat magnitude = new Mat();
            Cv2.Magnitude(dftplanes[0], dftplanes[1], magnitude);
            // 1加算してからLogで見易く
            magnitude += Scalar.All(1);
            Cv2.Log(magnitude, magnitude);
            Cv2.Normalize(magnitude, magnitude, 0, 1, NormTypes.MinMax);
            // 表示用uint8
            Mat magnitude8 = new Mat();
            Cv2.ConvertScaleAbs(magnitude, magnitude8, 255, 0);
            tmpImg = magnitude8.Resize(new OpenCvSharp.Size(frame.Width * dy, CAMpictureBox.Height));
            tmpBitmap = BitmapConverter.ToBitmap(tmpImg);
            FFTgraphics.DrawImage(tmpBitmap, 0, 0, tmpBitmap.Width, tmpBitmap.Height);

            // 3チャネルなのでSplitして1枚だけ使う
            Mat[] filterplanes = Cv2.Split(filter);
            Mat dfilter = new Mat(filterplanes[1].Size(), MatType.CV_32F);
            filterplanes[1].ConvertTo(dfilter, MatType.CV_32F, 1 / 255.0, 0);
            dfilter = dfilter.Resize(frame.Size());
            dftplanes[0] = dftplanes[0].Mul(dfilter);
            dftplanes[1] = dftplanes[1].Mul(dfilter);

            // 逆フーリエ
            Cv2.Merge(dftplanes, dft);
            Mat invdft = new Mat();
            Cv2.Dft(dft, invdft, DftFlags.Inverse | DftFlags.RealOutput);
            invdft = mulChecker(invdft);
            Cv2.Normalize(invdft, invdft, 0, 1, NormTypes.MinMax);
            Mat invdft8 = new Mat();
            Cv2.ConvertScaleAbs(invdft, invdft8, 255, 0);
            tmpImg = invdft8.Resize(new OpenCvSharp.Size(frame.Width * dy, CAMpictureBox.Height));
            tmpBitmap = BitmapConverter.ToBitmap(tmpImg);
            IFFTgraphics.DrawImage(tmpBitmap, 0, 0, tmpBitmap.Width, tmpBitmap.Height);
            
            //不要だがメモリをモリモリ使うのでゴミ捨て
            invdft8.Dispose();
            invdft.Dispose();
            magnitude8.Dispose();
            magnitude.Dispose();
            mergedComplex.Dispose();
            dft.Dispose();
            tmpZero.Dispose();
            gframe.Dispose();
            padded.Dispose();
            padded32.Dispose();
            frame.Dispose();
            tmpImg.Dispose();
            tmpBitmap.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cap = new VideoCapture(0);
            pts = new List<System.Drawing.Point>();
            wpen = new Pen(Color.White);
            drawPen = new Pen(Color.White, 5.0f);
            Strokes = new Stack<List<System.Drawing.Point>>();
            //pictureBoxごとにGraphicsを取得してDrawImageしないとメモリを食い潰す
            CAMgraphics = CAMpictureBox.CreateGraphics();
            FFTgraphics = FFTpictureBox.CreateGraphics();
            IFFTgraphics = IFFTpictureBox.CreateGraphics();

            Mat frame = new Mat();
            cap.Read(frame);
            // カメラによって画像サイズやアスペクトが不明なので，1枚取得してそれに合わせる
            var dy = (float)(CAMpictureBox.Height) / frame.Height;
            FILTERpictureBox.Size = new System.Drawing.Size((int)(frame.Width * dy), CAMpictureBox.Height);
            FILTERgraphics = FILTERpictureBox.CreateGraphics();
            filter = Mat.Zeros(new OpenCvSharp.Size(frame.Width * dy, CAMpictureBox.Height), MatType.CV_8UC3);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            cap.Release();
        }

        private void FILTERpictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            // →参照 https://www.umayadia.com/cssample/sample0201/Sample275WinFormMouseToDraw.htm
            Strokes.Push(new List<System.Drawing.Point>());
        }

        private void FILTERpictureBox_Paint(object sender, PaintEventArgs e)
        {
            // →参照 https://www.umayadia.com/cssample/sample0201/Sample275WinFormMouseToDraw.htm
            foreach (var stroke in Strokes)
            {
                var path = new System.Drawing.Drawing2D.GraphicsPath(stroke.ToArray(), Enumerable.Repeat<byte>(1, stroke.Count).ToArray());
                e.Graphics.DrawPath(drawPen, path);
            }
        }

        private void FILTERpictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            // →参照 https://www.umayadia.com/cssample/sample0201/Sample275WinFormMouseToDraw.htm
            if (Control.MouseButtons != MouseButtons.None)
            {
                Strokes.Peek().Add(e.Location);
                FILTERpictureBox.Invalidate();
            }
        }

        private void FILTERpictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            //マウスのドラッグが終わった時点でビットマップに画面と同じものを書き込んでMatに変換
            Bitmap filterBmp = new Bitmap(FILTERpictureBox.Width, FILTERpictureBox.Height);
            Graphics g = Graphics.FromImage(filterBmp);
            foreach (var stroke in Strokes)
            {
                var path = new System.Drawing.Drawing2D.GraphicsPath(stroke.ToArray(), Enumerable.Repeat<byte>(1, stroke.Count).ToArray());
                g.DrawPath(drawPen, path);
            }
            filter = BitmapConverter.ToMat(filterBmp);
        }

        private void Clearbutton_Click(object sender, EventArgs e)
        {
            pts.Clear();
            Strokes.Clear();
            FILTERgraphics.Clear(Color.Black);
            filter.SetTo(0);
        }
    }
}
