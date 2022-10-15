using System;
using Microsoft.VisualBasic;

namespace iBMSC
{

    public partial class MainWindow : Form
    {

        public const int niMeasure = 0;
        public const int niSCROLL = 1;
        public const int niBPM = 2;
        public const int niSTOP = 3;
        public const int niS1 = 4;

        public const int niA1 = 5;
        public const int niA2 = 6;
        public const int niA3 = 7;
        public const int niA4 = 8;
        public const int niA5 = 9;
        public const int niA6 = 10;
        public const int niA7 = 11;
        public const int niA8 = 12;
        public const int niS2 = 13;

        public const int niD1 = 14;
        public const int niD2 = 15;
        public const int niD3 = 16;
        public const int niD4 = 17;
        public const int niD5 = 18;
        public const int niD6 = 19;
        public const int niD7 = 20;
        public const int niD8 = 21;
        public const int niS3 = 22;

        public const int niBGA = 23;
        public const int niLAYER = 24;
        public const int niPOOR = 25;
        public const int niS4 = 26;
        public const int niB = 27;

        public iBMSC.Editor.Column[] column = new iBMSC.Editor.Column[] { new iBMSC.Editor.Column(0, 50, "Measure", false, true, false, true, 0, 0, int.MinValue + 0x7F00FFFF, 0, int.MinValue + 0x7F00FFFF, 0), new iBMSC.Editor.Column(50, 60, "SCROLL", true, true, false, true, 99, 0, int.MinValue + 0x7FFF0000, 0, int.MinValue + 0x7FFF0000, 0), new iBMSC.Editor.Column(110, 60, "BPM", true, true, false, true, 3, 0, int.MinValue + 0x7FFF0000, 0, int.MinValue + 0x7FFF0000, 0), new iBMSC.Editor.Column(170, 50, "STOP", true, true, false, true, 9, 0, int.MinValue + 0x7FFF0000, 0, int.MinValue + 0x7FFF0000, 0), new iBMSC.Editor.Column(220, 5, "", false, false, false, true, 0, 0, 0, 0, 0, 0), new iBMSC.Editor.Column(225, 42, "A1", true, false, true, true, 16, int.MinValue + 0x7FB0B0B0, int.MinValue + 0x7F000000, int.MinValue + 0x7FC0C0C0, int.MinValue + 0x7F000000, 0x14FFFFFF), new iBMSC.Editor.Column(267, 30, "A2", true, false, true, true, 11, int.MinValue + 0x7F62B0FF, int.MinValue + 0x7F000000, int.MinValue + 0x7F6AB0F7, int.MinValue + 0x7F000000, 0x140033FF), new iBMSC.Editor.Column(297, 42, "A3", true, false, true, true, 12, int.MinValue + 0x7FB0B0B0, int.MinValue + 0x7F000000, int.MinValue + 0x7FC0C0C0, int.MinValue + 0x7F000000, 0x14FFFFFF), new iBMSC.Editor.Column(339, 45, "A4", true, false, true, true, 13, int.MinValue + 0x7FFFC862, int.MinValue + 0x7F000000, int.MinValue + 0x7FF7C66A, int.MinValue + 0x7F000000, 0x16F38B0C), new iBMSC.Editor.Column(384, 42, "A5", true, false, true, true, 14, int.MinValue + 0x7FB0B0B0, int.MinValue + 0x7F000000, int.MinValue + 0x7FC0C0C0, int.MinValue + 0x7F000000, 0x14FFFFFF), new iBMSC.Editor.Column(426, 30, "A6", true, false, true, true, 15, int.MinValue + 0x7F62B0FF, int.MinValue + 0x7F000000, int.MinValue + 0x7F6AB0F7, int.MinValue + 0x7F000000, 0x140033FF), new iBMSC.Editor.Column(456, 42, "A7", true, false, true, true, 18, int.MinValue + 0x7FB0B0B0, int.MinValue + 0x7F000000, int.MinValue + 0x7FC0C0C0, int.MinValue + 0x7F000000, 0x14FFFFFF), new iBMSC.Editor.Column(498, 40, "A8", true, false, true, true, 19, int.MinValue + 0x7F808080, int.MinValue + 0x7F000000, int.MinValue + 0x7F909090, int.MinValue + 0x7F000000, 0), new iBMSC.Editor.Column(498, 5, "", false, false, false, true, 0, 0, 0, 0, 0, 0), new iBMSC.Editor.Column(503, 42, "D1", true, false, true, false, 21, int.MinValue + 0x7FB0B0B0, int.MinValue + 0x7F000000, int.MinValue + 0x7FC0C0C0, int.MinValue + 0x7F000000, 0x14FFFFFF), new iBMSC.Editor.Column(503, 30, "D2", true, false, true, false, 22, int.MinValue + 0x7F62B0FF, int.MinValue + 0x7F000000, int.MinValue + 0x7F6AB0F7, int.MinValue + 0x7F000000, 0x140033FF), new iBMSC.Editor.Column(503, 42, "D3", true, false, true, false, 23, int.MinValue + 0x7FB0B0B0, int.MinValue + 0x7F000000, int.MinValue + 0x7FC0C0C0, int.MinValue + 0x7F000000, 0x14FFFFFF), new iBMSC.Editor.Column(503, 45, "D4", true, false, true, false, 24, int.MinValue + 0x7FFFC862, int.MinValue + 0x7F000000, int.MinValue + 0x7FF7C66A, int.MinValue + 0x7F000000, 0x16F38B0C), new iBMSC.Editor.Column(503, 42, "D5", true, false, true, false, 25, int.MinValue + 0x7FB0B0B0, int.MinValue + 0x7F000000, int.MinValue + 0x7FC0C0C0, int.MinValue + 0x7F000000, 0x14FFFFFF), new iBMSC.Editor.Column(503, 30, "D6", true, false, true, false, 28, int.MinValue + 0x7F62B0FF, int.MinValue + 0x7F000000, int.MinValue + 0x7F6AB0F7, int.MinValue + 0x7F000000, 0x140033FF), new iBMSC.Editor.Column(503, 42, "D7", true, false, true, false, 29, int.MinValue + 0x7FB0B0B0, int.MinValue + 0x7F000000, int.MinValue + 0x7FC0C0C0, int.MinValue + 0x7F000000, 0x14FFFFFF), new iBMSC.Editor.Column(503, 40, "D8", true, false, true, false, 26, int.MinValue + 0x7F808080, int.MinValue + 0x7F000000, int.MinValue + 0x7F909090, int.MinValue + 0x7F000000, 0), new iBMSC.Editor.Column(503, 5, "", false, false, false, false, 0, 0, 0, 0, 0, 0), new iBMSC.Editor.Column(503, 40, "BGA", true, false, false, false, 4, int.MinValue + 0x7F8CD78A, int.MinValue + 0x7F000000, int.MinValue + 0x7F90D38E, int.MinValue + 0x7F000000, 0), new iBMSC.Editor.Column(503, 40, "LAYER", true, false, false, false, 7, int.MinValue + 0x7F8CD78A, int.MinValue + 0x7F000000, int.MinValue + 0x7F90D38E, int.MinValue + 0x7F000000, 0), new iBMSC.Editor.Column(503, 40, "POOR", true, false, false, false, 6, int.MinValue + 0x7F8CD78A, int.MinValue + 0x7F000000, int.MinValue + 0x7F90D38E, int.MinValue + 0x7F000000, 0), new iBMSC.Editor.Column(503, 5, "", false, false, false, false, 0, 0, 0, 0, 0, 0), new iBMSC.Editor.Column(503, 40, "B", true, false, true, true, 1, int.MinValue + 0x7FE18080, int.MinValue + 0x7F000000, int.MinValue + 0x7FDC8585, int.MinValue + 0x7F000000, 0) };


        public const int idflBPM = 5;

        private string GetBMSChannelBy(iBMSC.Editor.Note note)
        {
            int iCol = note.ColumnIndex;
            long xVal = note.Value;
            bool xLong = note.LongNote;
            bool xHidden = note.Hidden;
            int bmsBaseChannel = GetColumn(iCol).Identifier;
            bool xLandmine = note.Landmine;

            if (iCol == niBPM && xVal / 10000d != xVal / 10000L | xVal >= 2560000L | xVal < 0L)
                bmsBaseChannel += idflBPM;

            if (iCol == niSCROLL)
                return "SC";

            // p1 side
            if (iCol >= niA1 & iCol <= niA8)
            {
                if (xLong)
                {
                    return Conversion.Hex(bmsBaseChannel + Convert.ToInt32("50", 16) - 10);
                }
                if (xHidden)
                {
                    return Conversion.Hex(bmsBaseChannel + Convert.ToInt32("30", 16) - 10);
                }
                if (xLandmine)
                {
                    return Conversion.Hex(bmsBaseChannel + Convert.ToInt32("D0", 16) - 10);
                }
            }

            // p2 side
            if (iCol >= niD1 & iCol <= niD8)
            {
                if (xLong)
                {
                    return Conversion.Hex(bmsBaseChannel + Convert.ToInt32("60", 16) - 20);
                }
                if (xHidden)
                {
                    return Conversion.Hex(bmsBaseChannel + Convert.ToInt32("40", 16) - 20);
                }
                if (xLandmine)
                {
                    return Conversion.Hex(bmsBaseChannel + Convert.ToInt32("E0", 16) - 20);
                }
            }

            return iBMSC.Editor.Functions.Add2Zeros(bmsBaseChannel);
        }

        private int nLeft(int iCol)
        {
            if (iCol < niB)
                return column[iCol].Left;
            else
                return column[niB].Left + (iCol - niB) * column[niB].Width;
        }
        private int GetColumnWidth(int iCol)
        {
            if (!GetColumn(iCol).isVisible)
                return 0;
            if (iCol < niB)
                return column[iCol].Width;
            else
                return column[niB].Width;
        }
        private string nTitle(int iCol)
        {
            if (iCol < niB)
                return column[iCol].Title;
            else
                return column[niB].Title + (iCol - niB + 1).ToString();
        }
        private bool nEnabled(int iCol)
        {
            // If iCol < niB Then Return col(iCol).Enabled And col(iCol).Visible Else Return col(niB).Enabled And col(niB).Visible
            if (iCol < niB)
                return column[iCol].isEnabledAfterAll;
            else
                return column[niB].isEnabledAfterAll;
        }
        private bool IsColumnNumeric(int iCol)
        {
            if (iCol < niB)
                return column[iCol].isNumeric;
            else
                return column[niB].isNumeric;
        }
        private bool IsColumnSound(int iCol)
        {
            if (iCol < niB)
                return column[iCol].isSound;
            else
                return column[niB].isSound;
        }



        private iBMSC.Editor.Column GetColumn(int iCol)
        {
            if (iCol < niB)
                return column[iCol];
            else
                return column[niB];
        }

        private object BMSEChannelToColumnIndex(string I)
        {
            double Ivalue = Conversion.Val(I);
            if (Ivalue > 100d)
            {
                return niB + Ivalue - 101d;
            }
            else if (Ivalue < 100d & Ivalue > 0d)
            {
                return BMSChannelToColumn(Strings.Mid(I, 2, 2));
            }
            return niB; // ??? how did a negative number get here?
        }

        private int BMSChannelToColumn(string I)
        {
            switch (I ?? "")
            {
                case "01":
                    {
                        return niB;
                    }
                case "03":
                case "08":
                    {
                        return niBPM;
                    }
                case "09":
                    {
                        return niSTOP;
                    }
                case "SC":
                    {
                        return niSCROLL;
                    }
                case "04":
                    {
                        return niBGA;
                    }
                case "07":
                    {
                        return niLAYER;
                    }
                case "06":
                    {
                        return niPOOR;
                    }

                case "16":
                case "36":
                case "56":
                case "76":
                case "D6":
                    {
                        return niA1;
                    }
                case "11":
                case "31":
                case "51":
                case "71":
                case "D1":
                    {
                        return niA2;
                    }
                case "12":
                case "32":
                case "52":
                case "72":
                case "D2":
                    {
                        return niA3;
                    }
                case "13":
                case "33":
                case "53":
                case "73":
                case "D3":
                    {
                        return niA4;
                    }
                case "14":
                case "34":
                case "54":
                case "74":
                case "D4":
                    {
                        return niA5;
                    }
                case "15":
                case "35":
                case "55":
                case "75":
                case "D5":
                    {
                        return niA6;
                    }
                case "18":
                case "38":
                case "58":
                case "78":
                case "D8":
                    {
                        return niA7;
                    }
                case "19":
                case "39":
                case "59":
                case "79":
                case "D9":
                    {
                        return niA8;
                    }

                case "21":
                case "41":
                case "61":
                case "81":
                case "E1":
                    {
                        return niD1;
                    }
                case "22":
                case "42":
                case "62":
                case "82":
                case "E2":
                    {
                        return niD2;
                    }
                case "23":
                case "43":
                case "63":
                case "83":
                case "E3":
                    {
                        return niD3;
                    }
                case "24":
                case "44":
                case "64":
                case "84":
                case "E4":
                    {
                        return niD4;
                    }
                case "25":
                case "45":
                case "65":
                case "85":
                case "E5":
                    {
                        return niD5;
                    }
                case "28":
                case "48":
                case "68":
                case "88":
                case "E8":
                    {
                        return niD6;
                    }
                case "29":
                case "49":
                case "69":
                case "89":
                case "E9":
                    {
                        return niD7;
                    }
                case "26":
                case "46":
                case "66":
                case "86":
                case "E6":
                    {
                        return niD8;
                    }

                default:
                    {

                        return 0;
                    }
            }
        }

    }
}