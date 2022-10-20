using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace iBMSC.Editor
{
    public static class Functions
    {
        private static System.Globalization.NumberFormatInfo _WriteDecimalWithDot_nfi =
            new System.Globalization.NumberFormatInfo();

        public static string WriteDecimalWithDot(double v)
        {
            _WriteDecimalWithDot_nfi.NumberDecimalSeparator = ".";
            return v.ToString(_WriteDecimalWithDot_nfi);
        }

        public static string Add3Zeros(int xNum)
        {
            string xStr1 = "000" + xNum;
            return Strings.Mid(xStr1, Strings.Len(xStr1) - 2);
        }

        public static string Add2Zeros(int xNum)
        {
            string xStr1 = "00" + xNum;
            return Strings.Mid(xStr1, Strings.Len(xStr1) - 1);
        }

        public static char C10to36S(int xStart)
        {
            if (xStart < 10) return Conversions.ToChar(xStart.ToString());
            else return Strings.Chr(xStart + 55);
        }

        public static int C36to10S(char xChar)
        {
            int xAsc = Strings.Asc(Strings.UCase(xChar));
            if (xAsc >= 48 & xAsc <= 57)
            {
                return xAsc - 48;
            }
            else if (xAsc >= 65 & xAsc <= 90)
            {
                return xAsc - 55;
            }

            return 0;
        }

        public static string C10to36(long xStart)
        {
            if (xStart < 1L) xStart = 1L;
            if (xStart > 1295L) xStart = 1295L;
            return Conversions.ToString(C10to36S((int)(xStart / 36L))) + C10to36S((int)(xStart % 36L));
        }

        public static int C36to10(string xStart)
        {
            xStart = Strings.Mid("00" + xStart, Strings.Len(xStart) + 1);
            return C36to10S(xStart[0]) * 36 + C36to10S(xStart[1]);
        }

        public static string EncodingToString(System.Text.Encoding TextEncoding)
        {
            if (ReferenceEquals(TextEncoding, System.Text.Encoding.Default)) return "System Ansi";
            if (ReferenceEquals(TextEncoding, System.Text.Encoding.Unicode)) return "Little Endian UTF16";
            if (ReferenceEquals(TextEncoding, System.Text.Encoding.ASCII)) return "ASCII";
            if (ReferenceEquals(TextEncoding, System.Text.Encoding.BigEndianUnicode)) return "Big Endian UTF16";
            if (ReferenceEquals(TextEncoding, System.Text.Encoding.UTF32)) return "Little Endian UTF32";
            if (ReferenceEquals(TextEncoding, System.Text.Encoding.UTF7)) return "UTF7";
            if (ReferenceEquals(TextEncoding, System.Text.Encoding.UTF8)) return "UTF8";
            if (ReferenceEquals(TextEncoding, System.Text.Encoding.GetEncoding(932))) return "SJIS";
            if (ReferenceEquals(TextEncoding, System.Text.Encoding.GetEncoding(51949))) return "EUC-KR";
            return "ANSI (" + TextEncoding.EncodingName + ")" +
                   ReferenceEquals(TextEncoding, System.Text.Encoding.Default);
        }

        /// <summary>
        /// Adjust the brightness of a color.
        /// </summary>
        /// <param name="cStart">Original Color.</param>
        /// <param name="iPercent">(-100 to 100) Brightness.</param>
        /// <param name="iTransparency">(0 - 1) Transparency.</param>
        public static Color AdjustBrightness(Color cStart, float iPercent, float iTransparency)
        {
            if (cStart.A == 0)
            {
                return Color.FromArgb(0);
            }
            else
            {
                return Color.FromArgb((int)Math.Round(cStart.A * iTransparency),
                    (int)Math.Round(cStart.R * (100f - Math.Abs(iPercent)) * 0.01d +
                                    Math.Abs(Conversions.ToInteger(iPercent >= 0f) * iPercent) * 2.55d),
                    (int)Math.Round(cStart.G * (100f - Math.Abs(iPercent)) * 0.01d +
                                    Math.Abs(Conversions.ToInteger(iPercent >= 0f) * iPercent) * 2.55d),
                    (int)Math.Round(cStart.B * (100f - Math.Abs(iPercent)) * 0.01d +
                                    Math.Abs(Conversions.ToInteger(iPercent >= 0f) * iPercent) * 2.55d));
            }
        }

        public static bool IdentifiertoLongNote(string I)
        {
            int xI = (int)Math.Round(Conversion.Val(I));
            return xI >= 50 & xI < 90;
        }

        public static bool IdentifiertoHidden(string I)
        {
            int xI = (int)Math.Round(Conversion.Val(I));
            return xI >= 30 & xI < 50 | xI >= 70 & xI < 90;
        }

        public static string RandomFileName(string extWithDot)
        {
            string RandomFileNameRet = default;
            do
            {
                VBMath.Randomize();
                RandomFileNameRet = DateTime.Now.Ticks + Strings.Mid(VBMath.Rnd().ToString(), 3) + extWithDot;
            } while (File.Exists(RandomFileNameRet) | Directory.Exists(RandomFileNameRet));

            return RandomFileNameRet;
        }

        /// <param name="xH">Hue (0-359)</param>
        /// <param name="xS">Saturation (0-1000)</param>
        /// <param name="xL">Lightness (0-1000)</param>
        /// <param name="xA">Alpha (0-255)</param>
        public static Color HSL2RGB(int xH, int xS, int xL, int xA = 255)
        {
            if (xH > 360 | xS > 1000 | xL > 1000 | xA > 255) return Color.Black;

            // Dim xxH As Double = xH
            double xxS = xS / 1000d;
            double xxB = (xL - 500) / 500d;
            double xR;
            double xG;
            double xB;
            if (xH < 60)
            {
                xB = -1;
                xR = 1d;
                xG = (xH - 30) / 30d;
            }
            else if (xH < 120)
            {
                xB = -1;
                xG = 1d;
                xR = (90 - xH) / 30d;
            }
            else if (xH < 180)
            {
                xR = -1;
                xG = 1d;
                xB = (xH - 150) / 30d;
            }
            else if (xH < 240)
            {
                xR = -1;
                xB = 1d;
                xG = (210 - xH) / 30d;
            }
            else if (xH < 300)
            {
                xG = -1;
                xB = 1d;
                xR = (xH - 270) / 30d;
            }
            else
            {
                xG = -1;
                xR = 1d;
                xB = (330 - xH) / 30d;
            }

            xR = (xR * xxS * (1d - Math.Abs(xxB)) + xxB + 1d) * 255d / 2d;
            xG = (xG * xxS * (1d - Math.Abs(xxB)) + xxB + 1d) * 255d / 2d;
            xB = (xB * xxS * (1d - Math.Abs(xxB)) + xxB + 1d) * 255d / 2d;
            return Color.FromArgb(xA, (int)Math.Round(xR), (int)Math.Round(xG), (int)Math.Round(xB));
        }

        public static string FontToString(Font xFont)
        {
            return xFont.FontFamily.Name + "," + xFont.Size + "," + (int)xFont.Style;
        }

        public static bool isFontInstalled(string f)
        {
            var xFontCollection = new System.Drawing.Text.InstalledFontCollection();
            foreach (FontFamily ff in xFontCollection.Families)
            {
                if (f.Equals(ff.Name, StringComparison.CurrentCultureIgnoreCase)) return true;
            }

            return false;
        }

        public static Font StringToFont(string xStr, Font xDefault)
        {
            var xLine = Strings.Split(xStr, ",");
            if (Information.UBound(xLine) == 2)
            {
                FontStyle xFontStyle = (FontStyle)Math.Round(Conversion.Val(xLine[2]));
                return new Font(xLine[0], (float)Conversion.Val(xLine[1]), xFontStyle, GraphicsUnit.Pixel);
            }
            else
            {
                return xDefault;
            }
        }

        public static string ArrayToString(int[] xInt)
        {
            string xStr = "";
            for (int xI1 = 0, loopTo = Information.UBound(xInt); xI1 <= loopTo; xI1++)
                xStr = Conversions.ToString(xStr + Operators.ConcatenateObject(xInt[xI1].ToString(),
                    Interaction.IIf(xI1 == Information.UBound(xInt), "", ",")));
            return xStr;
        }

        public static string ArrayToString(bool[] xBool)
        {
            string xStr = "";
            for (int xI1 = 0, loopTo = Information.UBound(xBool); xI1 <= loopTo; xI1++)
                xStr = Conversions.ToString(xStr + Operators.ConcatenateObject(
                    Conversions.ToInteger(xBool[xI1]).ToString(),
                    Interaction.IIf(xI1 == Information.UBound(xBool), "", ",")));
            return xStr;
        }

        public static string ArrayToString(Color[] xColor)
        {
            string xStr = "";
            for (int xI1 = 0, loopTo = Information.UBound(xColor); xI1 <= loopTo; xI1++)
                xStr = Conversions.ToString(xStr + Operators.ConcatenateObject(xColor[xI1].ToArgb().ToString(),
                    Interaction.IIf(xI1 == Information.UBound(xColor), "", ",")));
            return xStr;
        }

        public static int[] StringToArrayInt(string xStr)
        {
            var xL = Strings.Split(xStr, ",");
            var xInt = new int[Information.UBound(xL) + 1];
            for (int xI1 = 0, loopTo = Information.UBound(xInt); xI1 <= loopTo; xI1++)
                xInt[xI1] = (int)Math.Round(Conversion.Val(xL[xI1]));
            return xInt;
        }

        public static bool[] StringToArrayBool(string xStr)
        {
            var xL = Strings.Split(xStr, ",");
            var xBool = new bool[Information.UBound(xL) + 1];
            for (int xI1 = 0, loopTo = Information.UBound(xBool); xI1 <= loopTo; xI1++)
                xBool[xI1] = Conversions.ToBoolean(Conversion.Val(xL[xI1]));
            return xBool;
        }

        public static long GetDenominator(double a, long maxDenom = 0x7FFFFFFFL)
        {
            long m00 = 1L;
            long m01 = 0L;
            long m10 = 0L;
            long m11 = 1L;
            double x = a;
            long ai = (long)Math.Round(Conversion.Int(x));
            while (m10 * ai + m11 <= maxDenom)
            {
                long t;
                t = m00 * ai + m01;
                m01 = m00;
                m00 = t;
                t = m10 * ai + m11;
                m11 = m10;
                m10 = t;
                if (x == ai) break;
                x = 1d / (x - ai);
                if (x > 0x7FFFFFFFFFFFFFFF) break;
                ai = (long)Math.Round(Conversion.Int(x));
            }

            return m10;
        }

        private static Regex _IsBase36_re = new Regex("^[A-Za-z0-9]+$");

        public static bool IsBase36(string str)
        {
            return _IsBase36_re.IsMatch(str);
        }
    }
}