using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace iBMSC;

internal static  class Extensions
{
    public static void SetValClamped(this  NumericUpDown self, decimal k)
    {
        self.Value = Math.Min(Math.Max(k, self.Minimum), self.Maximum);
    }
}
