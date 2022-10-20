using System;
using System.Runtime.InteropServices;

namespace iBMSC;

internal class APIHelp
{
    public enum Bool
    {
        False,
        True
    }

    public struct Point
    {
        public int x;

        public int y;

        public Point(int x, int y)
        {
            this = default(Point);
            this.x = x;
            this.y = y;
        }
    }

    public struct Size
    {
        public int cx;

        public int cy;

        public Size(int cx, int cy)
        {
            this = default(Size);
            this.cx = cx;
            this.cy = cy;
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    private struct ARGB
    {
        public byte Blue;

        public byte Green;

        public byte Red;

        public byte Alpha;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BLENDFUNCTION
    {
        public byte BlendOp;

        public byte BlendFlags;

        public byte SourceConstantAlpha;

        public byte AlphaFormat;
    }

    public const int WS_EX_LAYERED = 524288;

    public const int HTCAPTION = 2;

    public const int WM_NCHITTEST = 132;

    public const int ULW_ALPHA = 2;

    public const byte AC_SRC_OVER = 0;

    public const byte AC_SRC_ALPHA = 1;

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern Bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pprSrc, int crKey, ref BLENDFUNCTION pblend, int dwFlags);

    [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr GetDC(IntPtr hWnd);

    [DllImport("user32.dll", ExactSpelling = true)]
    public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

    [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern Bool DeleteDC(IntPtr hdc);

    [DllImport("gdi32.dll", ExactSpelling = true)]
    public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

    [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern Bool DeleteObject(IntPtr hObject);
}
