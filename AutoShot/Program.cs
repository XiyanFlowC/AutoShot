using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoShot
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Directory.Exists("vimg")) Directory.CreateDirectory("vimg");
            string[] inputNames = File.ReadAllLines("innam.txt"); // { "A", "B", "C", "D", "E", "F", "G", "H" };
            string[] outputNames = File.ReadAllLines("outnam.txt");// { "X", "Y", "Z", "M", "N" };

            Console.WriteLine("需要点击的输入开关有几个？");
            int innum = inputNames.Length;//int.Parse(Console.ReadLine());
            Point[] inps = new Point[innum];
            for(int i = inps.Length - 1; i >= 0; --i)
            {
                Console.WriteLine($"准备好录入 {inputNames[i]} 时按回车");
                Console.ReadLine();
                inps[i] = Control.MousePosition;
                Console.WriteLine($"点 {inputNames[i]} 已录入。");
            }

            Console.WriteLine("需要确认的输出灯有几个？");
            int outnum = outputNames.Length;//int.Parse(Console.ReadLine());
            Point[] outps = new Point[outnum];
            for(int i = 0; i < outnum; ++i)
            {
                Console.WriteLine($"准备好录入 {outputNames[i]} 时按回车");
                Console.ReadLine();
                outps[i] = Control.MousePosition;
                Console.WriteLine($"点 {outputNames[i]} 已录入。");
            }

            Console.WriteLine("截图左上角点，鼠标到位后回车。");
            Console.ReadLine();
            Point basepoint = Control.MousePosition;

            Console.WriteLine("截图右下角点，鼠标到位后回车。");
            Console.ReadLine();
            Point termpoint = Control.MousePosition;
            
            for(int i = 0; i < outps.Length; ++i)
            {
                outps[i].X -= basepoint.X;
                outps[i].Y -= basepoint.Y;
            }

            Shotter shot = new Shotter(inps, outps)
            {
                ShotBasePoint = basepoint,
                ShotBandagePoint = termpoint,
                SaveScreenshot = true
            };

            shot.Shot();

            StreamWriter pen = new StreamWriter(File.OpenWrite("truthtbl.tex"));
            pen.WriteLine(@"\begin{table}[h]");
            pen.WriteLine(@"\begin{center}");
            pen.WriteLine(@"\caption{Truth table}");
            pen.WriteLine(@"\begin{tabular}{PUTS YOUR FORMAT HERE!}");
            for(int i = 0; i < inps.Length; ++i)
            {
                pen.Write($@"\textbf{{{inputNames[i]}}} && ");
            }
            for(int i = 0; i < outps.Length - 1; ++i)
            {
                pen.Write($@"\textbf{{{outputNames[i]}}} && ");
            }
            pen.WriteLine($@"\texbf{{{outputNames[outps.Length - 1]}}} \\");
            for (int I = 0; I < (2 << inps.Length - 1); ++I)
            {
                for(int J = inps.Length - 1; J >= 0; --J)
                {
                    pen.Write($@"{(I >> J) & 1} && ");
                }
                for(int J = 0; J < (outps.Length - 1); ++J)
                {
                    pen.Write($@"{(shot.Results[I, J] ? "1" : "0")} && ");
                }
                pen.WriteLine($@"{(shot.Results[I, outps.Length - 1] ? "1" : "0")} \\");
            }
            pen.WriteLine(@"\end{tabular}");
            pen.WriteLine(@"\end{center}");
            pen.WriteLine(@"\end{table}");
            pen.Close();

            pen = new StreamWriter(File.OpenWrite("variimgs.tex"));
            for(int i = 0; i < (2 << inps.Length - 1); ++i)
            {
                //pen.WriteLine($@"\subsubsection{{Result of {i}}}");
                pen.WriteLine($@"\includegraphics{{vimg/{i}.png}}");
                shot.Screenshots[i].Save($"vimg/{i}.png", System.Drawing.Imaging.ImageFormat.Png);
            }
            pen.Close();
        }
    }
}
