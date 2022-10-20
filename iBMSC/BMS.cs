using System;
using iBMSC.Editor;
using Microsoft.VisualBasic;

namespace iBMSC;

internal static class BMS
{
    public static bool IsChannelLongNote(string I)
    {
        int num = checked((int)Math.Round(Conversion.Val(I)));
        return num >= 50 && num < 90;
    }

    public static bool IsChannelHidden(string I)
    {
        int num = checked((int)Math.Round(Conversion.Val(I)));
        return (num >= 30 && num < 50) || (num >= 70 && num < 90);
    }

    public static bool IsChannelLandmine(string I)
    {
        int num = Functions.C36to10("D0");
        int num2 = Functions.C36to10("EZ");
        int num3 = Functions.C36to10(I);
        return num3 > num && num3 < num2;
    }
}
