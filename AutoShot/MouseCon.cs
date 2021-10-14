using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Text;
using System.Threading;

namespace AutoShot
{
    static class MouseCon
    {
        [DllImport("user32")]
        private static extern int SetCursorPos(int x, int y);

        public static void MoveTo(Point p)
        {
            SetCursorPos(p.X, p.Y);
        }

        [DllImport("user32")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public enum MouseEventFlag
        {
            Move = 0x1,
            LeftDown = 0x2,
            LeftUp = 0x4,
            RightDown = 0x8,
            RightUp = 0x10,
            MiddleDown = 0x20,
            MiddleUp = 0x40,
            Wheel = 0x80,
            Absolute = 0x8000
        }

        public static void MouseEvent(MouseEventFlag flg, int dx, int dy, int cButtons, int extraInfo)
        {
            mouse_event((int)flg, dx, dy, cButtons, extraInfo);
        }

        public static void Move(int x, int y)
        {
            mouse_event((int)MouseEventFlag.Move, x, y, 0, 0);
        }

        public static void Click()
        {
            MouseEvent(MouseEventFlag.LeftDown | MouseEventFlag.LeftUp, 0, 0, 0, 0);
        }

        public static void DoubleClick()
        {
            Click();
            Click();
        }

        public static void DoubleClick(int gapTime)
        {
            Click();
            Thread.Sleep(gapTime);
            Click();
        }

        public static void ClickAt(int x, int y)
        {
            MouseEvent(MouseEventFlag.LeftUp | MouseEventFlag.LeftDown | MouseEventFlag.Absolute, x, y, 0, 0);
        }
    }
}
