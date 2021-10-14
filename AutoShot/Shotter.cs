using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace AutoShot
{
    class Shotter
    {
        public Point ShotBasePoint { get; set; }
        public Point ShotBandagePoint { get; set; }
        public Point[] ClickPositions { get; private set; }
        public Point[] CheckPositions { get; private set; }
        public bool[,] Results { get; private set; }
        public Bitmap[] Screenshots { get; private set; }
        public string ReportPartialFileGeneratePath { get; set; }

        public bool SaveScreenshot { get; set; }
        public bool SaveScreenshotRealtime { get; set; }
        public string SaveScreenshotPath { get; set; }
        public bool CheckOutput { get; set; }

        private Rectangle scrRect;

        public Shotter(Point[] clickPos, Point[] checkPos)
        {
            ClickPositions = clickPos;
            CheckPositions = checkPos;

            Results = new bool[2 << ClickPositions.Length - 1, CheckPositions.Length];
            Screenshots = new Bitmap[2 << ClickPositions.Length - 1];
            SaveScreenshot = false;
            CheckOutput = true;
        }

        private void ScreenShotInit()
        {
            scrRect = new Rectangle(0, 0, ShotBandagePoint.X - ShotBasePoint.X, ShotBandagePoint.Y - ShotBasePoint.Y);
        }

        private Bitmap DoScreenShot()
        {
            var buffer = new Bitmap(scrRect.Width, scrRect.Height);
            var graph = Graphics.FromImage(buffer);
            graph.CopyFromScreen(ShotBasePoint, new Point(0, 0), scrRect.Size);
            graph.DrawImage(buffer, 0, 0, scrRect, GraphicsUnit.Pixel);
            return buffer;
        }

        private void CheckResult(int grayCode, Bitmap screenshot)
        {
            if (CheckOutput)
            {
                for (int i = 0; i < CheckPositions.Length; ++i)
                {
                    Color c = screenshot.GetPixel(CheckPositions[i].X, CheckPositions[i].Y);
                    Console.WriteLine($"Color on {CheckPositions[i].X},{CheckPositions[i].Y}: #{c.R:X2}{c.G:X2}{c.B:X2}");
                    Results[grayCode, i] = c.R >= 0xcf && c.G <= 0x3f && c.B <= 0x3f;
                }
            }
        }

        private void ClickAndLog(int grayCode, int clickPositionIndex)
        {
            var pt = ClickPositions[clickPositionIndex];
            MouseCon.MoveTo(pt);
            MouseCon.Click();
            Thread.Sleep(500);
            var buffer = DoScreenShot();
            if (SaveScreenshot)
            {
                Screenshots[grayCode] = buffer;
            }

            CheckResult(grayCode, buffer);
        }

        public void Shot()
        {
            ScreenShotInit();

            var buff = DoScreenShot();
            if (SaveScreenshot) Screenshots[0] = buff;
            CheckResult(0, buff);
            _graycode = 0;
            InternalShot(ClickPositions.Length - 1);
        }

        private int _graycode; // 为了 _Shot 的状态记忆——有空就改掉，这样实现很丑

        private void InternalShot(int clickPosition)
        {
            if (clickPosition == -1) return;

            InternalShot(clickPosition - 1);
            _graycode ^= 0x1 << clickPosition;
            ClickAndLog(_graycode, clickPosition);
            InternalShot(clickPosition - 1);
        }
    }
}
