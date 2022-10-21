using System;
using iBMSC.Editor;
using Microsoft.VisualBasic;

namespace iBMSC;

public partial class MainWindow
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

    public Column[] column =
    {
        new Column(0, 50, "Measure", false, true,  true, 0, 0,0xFF00FFFF, 0,0xFF00FFFF, 0),
        new Column(50, 60, "SCROLL", true, true,  true, 99, 0, 0xFFFF0000, 0, 0xFFFF0000, 0),
        new Column(110, 60, "BPM", true, true,  true, 3, 0, 0xFFFF0000, 0, 0xFFFF0000, 0),
        new Column(170, 50, "STOP", true, true,  true, 9, 0, 0xFFFF0000, 0, 0xFFFF0000, 0),
        new Column(220, 5, "", false, false,  true, 0, 0, 0, 0, 0, 0),
        new Column(225, 42, "A1", true, false,  true, 16, 0xFFB0B0B0, 0xFF000000, 0xFFC0C0C0, 0xFF000000, 0x14FFFFFF),
        new Column(267, 30, "A2", true, false,  true, 11, 0xFF62B0FF, 0xFF000000, 0xFF6AB0F7, 0xFF000000, 0x140033FF),
        new Column(297, 42, "A3", true, false,  true, 12, 0xFFB0B0B0, 0xFF000000, 0xFFC0C0C0, 0xFF000000, 0x14FFFFFF),
        new Column(339, 45, "A4", true, false,  true, 13, 0xFFFFC862, 0xFF000000, 0xFFF7C66A, 0xFF000000, 0x16F38B0C),
        new Column(384, 42, "A5", true, false,  true, 14, 0xFFB0B0B0, 0xFF000000, 0xFFC0C0C0, 0xFF000000, 0x14FFFFFF),
        new Column(426, 30, "A6", true, false,  true, 15, 0xFF62B0FF, 0xFF000000, 0xFF6AB0F7, 0xFF000000, 0x140033FF),
        new Column(456, 42, "A7", true, false,  true, 18, 0xFFB0B0B0, 0xFF000000, 0xFFC0C0C0, 0xFF000000, 0x14FFFFFF),
        new Column(498, 40, "A8", true, false,  true, 19, 0xFF808080, 0xFF000000, 0xFF909090, 0xFF000000, 0),
        new Column(498, 5, "", false, false,  true, 0, 0, 0, 0, 0, 0),
        new Column(503, 42, "D1", true, false, false, 21, 0xFFB0B0B0, 0xFF000000, 0xFFC0C0C0, 0xFF000000, 0x14FFFFFF),
        new Column(503, 30, "D2", true, false, false, 22, 0xFF62B0FF, 0xFF000000, 0xFF6AB0F7, 0xFF000000, 0x140033FF),
        new Column(503, 42, "D3", true, false, false, 23, 0xFFB0B0B0, 0xFF000000, 0xFFC0C0C0, 0xFF000000, 0x14FFFFFF),
        new Column(503, 45, "D4", true, false, false, 24, 0xFFFFC862, 0xFF000000, 0xFFF7C66A, 0xFF000000, 0x16F38B0C),
        new Column(503, 42, "D5", true, false, false, 25, 0xFFB0B0B0, 0xFF000000, 0xFFC0C0C0, 0xFF000000, 0x14FFFFFF),
        new Column(503, 30, "D6", true, false, false, 28, 0xFF62B0FF, 0xFF000000, 0xFF6AB0F7, 0xFF000000, 0x140033FF),
        new Column(503, 42, "D7", true, false, false, 29, 0xFFB0B0B0, 0xFF000000, 0xFFC0C0C0, 0xFF000000, 0x14FFFFFF),
        new Column(503, 40, "D8", true, false, false, 26, 0xFF808080, 0xFF000000, 0xFF909090, 0xFF000000, 0),
        new Column(503, 5, "", false, false,  false, 0, 0, 0, 0, 0, 0),
        new Column(503, 40, "BGA", true, false,  false, 4, 0xFF8CD78A, 0xFF000000, 0xFF90D38E, 0xFF000000, 0),
        new Column(503, 40, "LAYER", true, false,  false, 7, 0xFF8CD78A, 0xFF000000, 0xFF90D38E, 0xFF000000, 0),
        new Column(503, 40, "POOR", true, false,  false, 6, 0xFF8CD78A, 0xFF000000, 0xFF90D38E, 0xFF000000, 0),
        new Column(503, 5, "", false, false,  false, 0, 0, 0, 0, 0, 0),
        new Column(503, 40, "B", true, false,  true, 1, 0xFFE18080, 0xFF000000, 0xFFDC8585, 0xFF000000, 0)
    };

    public const int idflBPM = 5;

    private string GetBMSChannelBy(Note note)
    {
        var iCol = note.ColumnIndex;
        var xVal = note.Value;
        var xLong = note.LongNote;
        var xHidden = note.Hidden;
        var bmsBaseChannel = GetColumn(iCol).Identifier;
        var xLandmine = note.Landmine;

        if (iCol == niBPM && (xVal / 10000.0 != xVal / 10000 || xVal >= 2560000 || xVal < 0))
        {
            bmsBaseChannel += idflBPM;
        }

        if (iCol == niSCROLL)
        {
            return "SC";
        }

        // p1 side
        if (iCol >= niA1 && iCol <= niA8)
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
        if (iCol >= niD1 && iCol <= niD8)
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

        return Functions.Add2Zeros(bmsBaseChannel);
    }

    private int nLeft(int iCol)
    {
        if (iCol < niB)
        {
            return column[iCol].Left;
        }
        return column[niB].Left + (iCol - niB) * column[niB].Width;
    }

    private int GetColumnWidth(int iCol)
    {
        if (!GetColumn(iCol).isVisible)
        {
            return 0;
        }
        if (iCol < niB)
        {
            return column[iCol].Width;
        }
        return column[niB].Width;
    }

    private string nTitle(int iCol)
    {
        if (iCol < niB)
        {
            return column[iCol].Title;
        }
        return column[niB].Title + (iCol - niB + 1);
    }

    private bool nEnabled(int iCol)
    {
        if (iCol < niB)
        {
            return column[iCol].isEnabledAfterAll;
        }
        return column[niB].isEnabledAfterAll;
    }

    private bool IsColumnNumeric(int iCol)
    {
        if (iCol < niB)
        {
            return column[iCol].isNumeric;
        }
        return column[niB].isNumeric;
    }

    private Column GetColumn(int iCol)
    {
        if (iCol < niB)
        {
            return column[iCol];
        }
        return column[niB];
    }

    private object BMSEChannelToColumnIndex(string I)
    {
        double Ivalue = Conversion.Val(I);
        if (Ivalue > 100)
        {
            return niB + Ivalue - 101;
        }
        if (Ivalue < 100 && Ivalue > 0)
        {
            return BMSChannelToColumn(Microsoft.VisualBasic.Strings.Mid(I, 2, 2));
        }
        return niB; // ??? how did a negative number get here?
    }

    private int BMSChannelToColumn(string I)
    {
        if (I == "01") return 27;
        if (I is "03" or "08") return 2;
        if (I == "09") return 3;
        if (I == "SC") return 1;
        if (I == "04") return 23;
        if (I == "07") return 24;
        if (I == "06") return 25;

        if (I is "16" or "36" or "56" or "76" or "D6") return 5;
        if (I is "11" or "31" or "51" or "71" or "D1") return 6;
        if (I is "12" or "32" or "52" or "72" or "D2") return 7;
        if (I is "13" or "33" or "53" or "73" or "D3") return 8;
        if (I is "14" or "34" or "54" or "74" or "D4") return 9;
        if (I is "15" or "35" or "55" or "75" or "D5") return 10;
        if (I is "18" or "38" or "58" or "78" or "D8") return 11;
        if (I is "19" or "39" or "59" or "79" or "D9") return 12;

        if (I is "21" or "41" or "61" or "81" or "E1") return 14;
        if (I is "22" or "42" or "62" or "82" or "E2") return 15;
        if (I is "23" or "43" or "63" or "83" or "E3") return 16;
        if (I is "24" or "44" or "64" or "84" or "E4") return 17;
        if (I is "25" or "45" or "65" or "85" or "E5") return 18;
        if (I is "28" or "48" or "68" or "88" or "E8") return 19;
        if (I is "29" or "49" or "69" or "89" or "E9") return 20;
        if (I is "26" or "46" or "66" or "86" or "E6") return 21;

        return 0;
    }
}