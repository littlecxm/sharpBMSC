using System;
using iBMSC.Editor;
using Microsoft.VisualBasic;

namespace iBMSC;

internal static class BMS
{
    public static bool IsChannelLongNote(string I)
    {
        var num = (int)Math.Round(Conversion.Val(I));
        return num is >= 50 and < 90;
    }

    public static bool IsChannelHidden(string I)
    {
        var num = (int)Math.Round(Conversion.Val(I));
        return num is >= 30 and < 50 || num is >= 70 and < 90;
    }

    public static bool IsChannelLandmine(string I)
    {
        var num = Functions.C36to10("D0");
        var num2 = Functions.C36to10("EZ");
        var num3 = Functions.C36to10(I);
        return num3 > num && num3 < num2;
    }
}
