using System;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace iBMSC.Editor;

[StandardModule]
public sealed class Functions
{
    [SpecialName]
    private static Regex _0024STATIC_0024IsBase36_0024012E_0024re;

    [SpecialName]
    private static NumberFormatInfo _0024STATIC_0024WriteDecimalWithDot_002401ED_0024nfi;

    [SpecialName]
    private static StaticLocalInitFlag _0024STATIC_0024WriteDecimalWithDot_002401ED_0024nfi_0024Init = new StaticLocalInitFlag();

    [SpecialName]
    private static StaticLocalInitFlag _0024STATIC_0024IsBase36_0024012E_0024re_0024Init = new StaticLocalInitFlag();

    public static string WriteDecimalWithDot(double v)
    {
        var lockTaken = false;
        try
        {
            Monitor.Enter(_0024STATIC_0024WriteDecimalWithDot_002401ED_0024nfi_0024Init, ref lockTaken);
            if (_0024STATIC_0024WriteDecimalWithDot_002401ED_0024nfi_0024Init.State == 0)
            {
                _0024STATIC_0024WriteDecimalWithDot_002401ED_0024nfi_0024Init.State = 2;
                _0024STATIC_0024WriteDecimalWithDot_002401ED_0024nfi = new NumberFormatInfo();
            }
            else if (_0024STATIC_0024WriteDecimalWithDot_002401ED_0024nfi_0024Init.State == 2)
            {
                throw new IncompleteInitialization();
            }
        }
        finally
        {
            _0024STATIC_0024WriteDecimalWithDot_002401ED_0024nfi_0024Init.State = 1;
            if (lockTaken)
            {
                Monitor.Exit(_0024STATIC_0024WriteDecimalWithDot_002401ED_0024nfi_0024Init);
            }
        }
        _0024STATIC_0024WriteDecimalWithDot_002401ED_0024nfi.NumberDecimalSeparator = ".";
        return v.ToString(_0024STATIC_0024WriteDecimalWithDot_002401ED_0024nfi);
    }

    public static string Add3Zeros(int xNum)
    {
        var text = "000" + Conversions.ToString(xNum);
        return Microsoft.VisualBasic.Strings.Mid(text, Microsoft.VisualBasic.Strings.Len(text) - 2);
    }

    public static string Add2Zeros(int xNum)
    {
        var text = "00" + Conversions.ToString(xNum);
        return Microsoft.VisualBasic.Strings.Mid(text, Microsoft.VisualBasic.Strings.Len(text) - 1);
    }

    public static char C10to36S(int xStart)
    {
        if (xStart < 10)
        {
            return Conversions.ToChar(Conversions.ToString(xStart));
        }
        return Microsoft.VisualBasic.Strings.Chr(xStart + 55);
    }

    public static int C36to10S(char xChar)
    {
        var num = Microsoft.VisualBasic.Strings.Asc(Microsoft.VisualBasic.Strings.UCase(xChar));
        if (num is >= 48 and <= 57)
        {
            return num - 48;
        }
        if (num is >= 65 and <= 90)
        {
            return num - 55;
        }
        return 0;
    }

    public static string C10to36(long xStart)
    {
        if (xStart < 1)
        {
            xStart = 1L;
        }
        if (xStart > 1295)
        {
            xStart = 1295L;
        }

        return Conversions.ToString(C10to36S((int)(xStart / 36))) + Conversions.ToString(C10to36S((int)(xStart % 36)));
    }

    public static int C36to10(string xStart)
    {
        xStart = Microsoft.VisualBasic.Strings.Mid("00" + xStart, Microsoft.VisualBasic.Strings.Len(xStart) + 1);
        return C36to10S(xStart[0]) * 36 + C36to10S(xStart[1]);
    }

    public static string EncodingToString(Encoding TextEncoding)
    {
        if (TextEncoding == Encoding.Default)
        {
            return "System Ansi";
        }
        if (TextEncoding == Encoding.Unicode)
        {
            return "Little Endian UTF16";
        }
        if (TextEncoding == Encoding.ASCII)
        {
            return "ASCII";
        }
        if (TextEncoding == Encoding.BigEndianUnicode)
        {
            return "Big Endian UTF16";
        }
        if (TextEncoding == Encoding.UTF32)
        {
            return "Little Endian UTF32";
        }
        if (TextEncoding == Encoding.UTF7)
        {
            return "UTF7";
        }
        if (TextEncoding == Encoding.UTF8)
        {
            return "UTF8";
        }
        if (TextEncoding == Encoding.GetEncoding(932))
        {
            return "SJIS";
        }
        if (TextEncoding == Encoding.GetEncoding(51949))
        {
            return "EUC-KR";
        }
        return "ANSI (" + TextEncoding.EncodingName + ")" + Conversions.ToString(TextEncoding == Encoding.Default);
    }

    public static Color AdjustBrightness(Color cStart, float iPercent, float iTransparency)
    {
        if (cStart.A == 0)
        {
            return Color.FromArgb(0);
        }

        return Color.FromArgb((int)Math.Round(cStart.A * iTransparency), (int)Math.Round(unchecked(cStart.R * (100f - Math.Abs(iPercent)) * 0.01 + Math.Abs((0 - (iPercent >= 0f ? 1 : 0)) * iPercent) * 2.55)), (int)Math.Round(unchecked(cStart.G * (100f - Math.Abs(iPercent)) * 0.01 + Math.Abs((0 - (iPercent >= 0f ? 1 : 0)) * iPercent) * 2.55)), (int)Math.Round(unchecked(cStart.B * (100f - Math.Abs(iPercent)) * 0.01 + Math.Abs((0 - (iPercent >= 0f ? 1 : 0)) * iPercent) * 2.55)));
    }

    public static bool IdentifiertoLongNote(string I)
    {
        var num = (int)Math.Round(Conversion.Val(I));
        return num is >= 50 and < 90;
    }

    public static bool IdentifiertoHidden(string I)
    {
        var num = (int)Math.Round(Conversion.Val(I));
        return num is >= 30 and < 50 || num is >= 70 and < 90;
    }

    public static string RandomFileName(string extWithDot)
    {
        string text;
        do
        {
            VBMath.Randomize();
            text = Conversions.ToString(DateAndTime.Now.Ticks) + Microsoft.VisualBasic.Strings.Mid(Conversions.ToString(VBMath.Rnd()), 3) + extWithDot;
        }
        while (File.Exists(text) | Directory.Exists(text));
        return text;
    }

    public static Color HSL2RGB(int xH, int xS, int xL, int xA = 255)
    {
        if (xH > 360 || xS > 1000 || xL > 1000 || xA > 255)
        {
            return Color.Black;
        }
        var num = xS / 1000.0;

        var num2 = (xL - 500) / 500.0;
        double num4;
        double num5;
        double num3;
        if (xH < 60)
        {
            num3 = -1.0;
            num4 = 1.0;
            num5 = (xH - 30) / 30.0;
        }
        else if (xH < 120)
        {
            num3 = -1.0;
            num5 = 1.0;
            num4 = (90 - xH) / 30.0;
        }
        else if (xH < 180)
        {
            num4 = -1.0;
            num5 = 1.0;
            num3 = (xH - 150) / 30.0;
        }
        else if (xH < 240)
        {
            num4 = -1.0;
            num3 = 1.0;
            num5 = (210 - xH) / 30.0;
        }
        else if (xH < 300)
        {
            num5 = -1.0;
            num3 = 1.0;
            num4 = (xH - 270) / 30.0;
        }
        else
        {
            num5 = -1.0;
            num4 = 1.0;
            num3 = (330 - xH) / 30.0;
        }
        num4 = (num4 * num * (1.0 - Math.Abs(num2)) + num2 + 1.0) * 255.0 / 2.0;
        num5 = (num5 * num * (1.0 - Math.Abs(num2)) + num2 + 1.0) * 255.0 / 2.0;
        num3 = (num3 * num * (1.0 - Math.Abs(num2)) + num2 + 1.0) * 255.0 / 2.0;
        return Color.FromArgb(xA, (int)Math.Round(num4), (int)Math.Round(num5), (int)Math.Round(num3));
    }

    public static string FontToString(Font xFont)
    {
        return xFont.FontFamily.Name + "," + Conversions.ToString(xFont.Size) + "," + Conversions.ToString((int)xFont.Style);
    }

    public static bool isFontInstalled(string f)
    {
        var installedFontCollection = new InstalledFontCollection();
        var families = installedFontCollection.Families;
        foreach (var fontFamily in families)
        {
            if (f.Equals(fontFamily.Name, StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }

    public static Font StringToFont(string xStr, Font xDefault)
    {
        var array = Microsoft.VisualBasic.Strings.Split(xStr, ",");
        if (Information.UBound(array) == 2)
        {
            var style = (FontStyle)(int)Math.Round(Conversion.Val(array[2]));
            return new Font(array[0], (float)Conversion.Val(array[1]), style, GraphicsUnit.Pixel);
        }
        return xDefault;
    }

    public static string ArrayToString(int[] xInt)
    {
        var text = "";
        var num = Information.UBound(xInt);
        for (var i = 0; i <= num; i += 1)
        {
            text = Conversions.ToString(Operators.ConcatenateObject(text, Operators.ConcatenateObject(xInt[i].ToString(), Interaction.IIf(i == Information.UBound(xInt), "", ","))));
        }
        return text;
    }

    public static string ArrayToString(bool[] xBool)
    {
        var text = "";
        var num = Information.UBound(xBool);
        for (var i = 0; i <= num; i += 1)
        {
            text = Conversions.ToString(Operators.ConcatenateObject(text, Operators.ConcatenateObject((0 - (xBool[i] ? 1 : 0)).ToString(), Interaction.IIf(i == Information.UBound(xBool), "", ","))));
        }
        return text;
    }

    public static string ArrayToString(Color[] xColor)
    {
        var text = "";
        var num = Information.UBound(xColor);
        for (var i = 0; i <= num; i += 1)
        {
            text = Conversions.ToString(Operators.ConcatenateObject(text, Operators.ConcatenateObject(xColor[i].ToArgb().ToString(), Interaction.IIf(i == Information.UBound(xColor), "", ","))));
        }
        return text;
    }

    public static int[] StringToArrayInt(string xStr)
    {
        var array = Microsoft.VisualBasic.Strings.Split(xStr, ",");

        var array2 = new int[Information.UBound(array) + 1];
        var num = Information.UBound(array2);
        for (var i = 0; i <= num; i++)
        {
            array2[i] = (int)Math.Round(Conversion.Val(array[i]));
        }

        return array2;
    }

    public static bool[] StringToArrayBool(string xStr)
    {
        var array = Microsoft.VisualBasic.Strings.Split(xStr, ",");

        var array2 = new bool[Information.UBound(array) + 1];
        var num = Information.UBound(array2);
        for (var i = 0; i <= num; i++)
        {
            array2[i] = Conversion.Val(array[i]) != 0.0;
        }

        return array2;
    }

    public static long GetDenominator(double a, long maxDenom = 2147483647L)
    {
        var num = 1L;
        var num2 = 0L;
        var num3 = 0L;
        var num4 = 1L;
        var num5 = a;

        var num6 = (long)Math.Round(Conversion.Int(num5));
        while (num3 * num6 + num4 <= maxDenom)
        {
            var num7 = num * num6 + num2;
            num2 = num;
            num = num7;
            num7 = num3 * num6 + num4;
            num4 = num3;
            num3 = num7;
            if (num5 == num6)
            {
                break;
            }

            num5 = 1.0 / (num5 - num6);
            if (num5 > 9.223372036854776E+18)
            {
                break;
            }

            num6 = (long)Math.Round(Conversion.Int(num5));
        }

        return num3;
    }

    public static bool IsBase36(string str)
    {
        var lockTaken = false;
        try
        {
            Monitor.Enter(_0024STATIC_0024IsBase36_0024012E_0024re_0024Init, ref lockTaken);
            if (_0024STATIC_0024IsBase36_0024012E_0024re_0024Init.State == 0)
            {
                _0024STATIC_0024IsBase36_0024012E_0024re_0024Init.State = 2;
                _0024STATIC_0024IsBase36_0024012E_0024re = new Regex("^[A-Za-z0-9]+$");
            }
            else if (_0024STATIC_0024IsBase36_0024012E_0024re_0024Init.State == 2)
            {
                throw new IncompleteInitialization();
            }
        }
        finally
        {
            _0024STATIC_0024IsBase36_0024012E_0024re_0024Init.State = 1;
            if (lockTaken)
            {
                Monitor.Exit(_0024STATIC_0024IsBase36_0024012E_0024re_0024Init);
            }
        }
        return _0024STATIC_0024IsBase36_0024012E_0024re.IsMatch(str);
    }
}
