using System;
using iBMSC.Editor;
using Microsoft.VisualBasic;

namespace iBMSC;

internal static class BMS
{
    public static bool IsChannelLongNote(string I)
    {
        int xI = (int)Math.Round(Conversion.Val(I));
        return xI is >= 50 and < 90;
    }

    public static bool IsChannelHidden(string I)
    {
        var xI = (int)Math.Round(Conversion.Val(I));
        return xI is >= 30 and < 50 or >= 70 and < 90;
    }

    public static bool IsChannelLandmine(string I)
    {
        int LandmineStart = Functions.C36to10("D0");
        int LandmineEnd = Functions.C36to10("EZ");

        int xI = Functions.C36to10(I);

        return xI > LandmineStart & xI < LandmineEnd;
    }
}
