using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace iBMSC;

[DesignerGenerated]
public sealed partial  class SplashScreen1 : Form
{
    public SplashScreen1()
    {
        Paint += SplashScreen1_Paint;
        InitializeComponent();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        var rectangle = new Rectangle(0, 0, Width, Height);
    }

    private void SplashScreen1_Paint(object sender, PaintEventArgs e)
    {
    }
}
