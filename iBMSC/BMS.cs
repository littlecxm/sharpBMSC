using System;
using Microsoft.VisualBasic;

namespace iBMSC
{

    static class BMS
    {
        public static bool IsChannelLongNote(string I)
        {
            int xI = (int)Math.Round(Conversion.Val(I));
            return xI >= 50 & xI < 90;
        }

        public static bool IsChannelHidden(string I)
        {
            int xI = (int)Math.Round(Conversion.Val(I));
            return xI >= 30 & xI < 50 | xI >= 70 & xI < 90;
        }

        public static bool IsChannelLandmine(string I)
        {
            int LandmineStart = iBMSC.Editor.Functions.C36to10("D0");
            int LandmineEnd = iBMSC.Editor.Functions.C36to10("EZ");

            int xI = iBMSC.Editor.Functions.C36to10(I);

            return xI > LandmineStart & xI < LandmineEnd;
        }
    }
}