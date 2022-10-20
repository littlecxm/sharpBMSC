using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using iBMSC.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace iBMSC;

[DesignerGenerated]
public partial  class ColorPicker : Form
{
    public Color OrigColor;

    public Color NewColor;

    private int DrawingIndex;

    private bool PassiveValueChange;

    private Point mMain;

    private int mAlpha;

    private int m1;

    public ColorPicker()
    {
        base.Load += ColorPicker_Load;
        OrigColor = Color.Black;
        NewColor = Color.Black;
        DrawingIndex = 1;
        PassiveValueChange = false;
        ref Point reference = ref mMain;
        reference = new Point(0, 255);
        mAlpha = 255;
        m1 = 255;
        InitializeComponent();
    }

    public void SetOrigColor(Color xColor)
    {
        OrigColor = xColor;
        SetNewColor(xColor);
    }

    private void OK_Button_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
        Close();
    }

    private void Cancel_Button_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void SetNewColor(Color xColor, bool xSetText = true)
    {
        NewColor = xColor;
        RefreshPrev(pPrev.DisplayRectangle);
        if (xSetText)
        {
            tStr.Text = Microsoft.VisualBasic.Strings.Mid("0000000" + Conversion.Hex(xColor.ToArgb()), Microsoft.VisualBasic.Strings.Len(Conversion.Hex(xColor.ToArgb())));
        }
    }

    private void SetCursor()
    {
        switch (DrawingIndex)
        {
        case 0:
        {
            ref Point reference6 = ref mMain;
            reference6 = new Point(Convert.ToInt32(decimal.Multiply(decimal.Divide(inS.Value, new decimal(1000L)), new decimal(255L))), Convert.ToInt32(decimal.Multiply(decimal.Divide(decimal.Subtract(new decimal(1000L), inL.Value), new decimal(1000L)), new decimal(255L))));
            m1 = Convert.ToInt32(decimal.Divide(decimal.Multiply(decimal.Subtract(new decimal(360L), inH.Value), new decimal(255L)), new decimal(360L)));
            break;
        }
        case 1:
        {
            ref Point reference5 = ref mMain;
            reference5 = new Point(Convert.ToInt32(decimal.Divide(decimal.Multiply(inH.Value, new decimal(255L)), new decimal(360L))), Convert.ToInt32(decimal.Multiply(decimal.Divide(decimal.Subtract(new decimal(1000L), inL.Value), new decimal(1000L)), new decimal(255L))));
            m1 = Convert.ToInt32(decimal.Divide(decimal.Multiply(decimal.Subtract(new decimal(1000L), inS.Value), new decimal(255L)), new decimal(1000L)));
            break;
        }
        case 2:
        {
            ref Point reference4 = ref mMain;
            reference4 = new Point(Convert.ToInt32(decimal.Divide(decimal.Multiply(inH.Value, new decimal(255L)), new decimal(360L))), Convert.ToInt32(decimal.Divide(decimal.Multiply(decimal.Subtract(new decimal(1000L), inS.Value), new decimal(255L)), new decimal(1000L))));
            m1 = Convert.ToInt32(decimal.Divide(decimal.Multiply(decimal.Subtract(new decimal(1000L), inL.Value), new decimal(255L)), new decimal(1000L)));
            break;
        }
        case 3:
        {
            ref Point reference3 = ref mMain;
            reference3 = new Point(Convert.ToInt32(inB.Value), Convert.ToInt32(decimal.Subtract(new decimal(255L), inG.Value)));
            m1 = Convert.ToInt32(decimal.Subtract(new decimal(255L), inR.Value));
            break;
        }
        case 4:
        {
            ref Point reference2 = ref mMain;
            reference2 = new Point(Convert.ToInt32(inB.Value), Convert.ToInt32(decimal.Subtract(new decimal(255L), inR.Value)));
            m1 = Convert.ToInt32(decimal.Subtract(new decimal(255L), inG.Value));
            break;
        }
        case 5:
        {
            ref Point reference = ref mMain;
            reference = new Point(Convert.ToInt32(inG.Value), Convert.ToInt32(decimal.Subtract(new decimal(255L), inR.Value)));
            m1 = Convert.ToInt32(decimal.Subtract(new decimal(255L), inB.Value));
            break;
        }
        }
        mAlpha = Convert.ToInt32(inA.Value);
    }

    private Color HSL2RGB(int xH, int xS, int xL, int xA = 255)
    {
        if (xH > 360 || xS > 1000 || xL > 1000 || xA > 255)
        {
            return Color.Black;
        }
        double num = (double)xS / 1000.0;
        checked
        {
            double num2 = (double)(xL - 500) / 500.0;
            double num4;
            double num5;
            double num3;
            if (xH < 60)
            {
                num3 = -1.0;
                num4 = 1.0;
                num5 = (double)(xH - 30) / 30.0;
            }
            else if (xH < 120)
            {
                num3 = -1.0;
                num5 = 1.0;
                num4 = (double)(90 - xH) / 30.0;
            }
            else if (xH < 180)
            {
                num4 = -1.0;
                num5 = 1.0;
                num3 = (double)(xH - 150) / 30.0;
            }
            else if (xH < 240)
            {
                num4 = -1.0;
                num3 = 1.0;
                num5 = (double)(210 - xH) / 30.0;
            }
            else if (xH < 300)
            {
                num5 = -1.0;
                num3 = 1.0;
                num4 = (double)(xH - 270) / 30.0;
            }
            else
            {
                num5 = -1.0;
                num4 = 1.0;
                num3 = (double)(330 - xH) / 30.0;
            }
            num4 = (num4 * num * (1.0 - Math.Abs(num2)) + num2 + 1.0) * 255.0 / 2.0;
            num5 = (num5 * num * (1.0 - Math.Abs(num2)) + num2 + 1.0) * 255.0 / 2.0;
            num3 = (num3 * num * (1.0 - Math.Abs(num2)) + num2 + 1.0) * 255.0 / 2.0;
            return Color.FromArgb(xA, (int)Math.Round(num4), (int)Math.Round(num5), (int)Math.Round(num3));
        }
    }

    private void PCMain_MouseDown(object sender, MouseEventArgs e)
    {
        PCMain_MouseMove(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void PCMain_MouseMove(object sender, MouseEventArgs e)
    {
        checked
        {
            if (e.Button == MouseButtons.Left)
            {
                mMain = e.Location;
                if (mMain.X < 0)
                {
                    mMain.X = 0;
                }
                if (mMain.X > 255)
                {
                    mMain.X = 255;
                }
                if (mMain.Y < 0)
                {
                    mMain.Y = 0;
                }
                if (mMain.Y > 255)
                {
                    mMain.Y = 255;
                }
                switch (DrawingIndex)
                {
                case 0:
                    inL.Value = new decimal(1000.0 - (double)mMain.Y / 255.0 * 1000.0);
                    inS.Value = new decimal((double)mMain.X / 255.0 * 1000.0);
                    break;
                case 1:
                    inL.Value = new decimal(1000.0 - (double)mMain.Y / 255.0 * 1000.0);
                    inH.Value = new decimal((double)mMain.X / 255.0 * 360.0);
                    break;
                case 2:
                    inS.Value = new decimal(1000.0 - (double)mMain.Y / 255.0 * 1000.0);
                    inH.Value = new decimal((double)mMain.X / 255.0 * 360.0);
                    break;
                case 3:
                    inG.Value = new decimal(255 - mMain.Y);
                    inB.Value = new decimal(mMain.X);
                    break;
                case 4:
                    inR.Value = new decimal(255 - mMain.Y);
                    inB.Value = new decimal(mMain.X);
                    break;
                case 5:
                    inR.Value = new decimal(255 - mMain.Y);
                    inG.Value = new decimal(mMain.X);
                    break;
                }
            }
        }
    }

    private void PCMain_Paint(object sender, PaintEventArgs e)
    {
        RefreshMain(e.ClipRectangle);
    }

    private void RefreshMain(Rectangle xRegion)
    {
        BufferedGraphics bufferedGraphics = BufferedGraphicsManager.Current.Allocate(PCMain.CreateGraphics(), xRegion);
        int value = tbPrecision.Value;
        checked
        {
            switch (DrawingIndex)
            {
            case 0:
            {
                int xH = Convert.ToInt32(inH.Value);
                int num4 = value;
                for (int i = 0; ((num4 >> 31) ^ i) <= ((num4 >> 31) ^ 0xFF); i += num4)
                {
                    Graphics graphics4 = bufferedGraphics.Graphics;
                    Point point3 = new Point(0, 0);
                    Point point6 = point3;
                    Point point = new Point(0, 128);
                    graphics4.FillRectangle(new LinearGradientBrush(point6, point, Color.White, HSL2RGB(xH, (int)Math.Round((double)i / 255.0 * 1000.0), 500)), i, 0, value, 128);
                    Graphics graphics5 = bufferedGraphics.Graphics;
                    point = new Point(0, 128);
                    Point point7 = point;
                    point3 = new Point(0, 256);
                    graphics5.FillRectangle(new LinearGradientBrush(point7, point3, HSL2RGB(xH, (int)Math.Round((double)i / 255.0 * 1000.0), 500), Color.Black), i, 128, value, 128);
                }
                break;
            }
            case 1:
            {
                int xS = Convert.ToInt32(inS.Value);
                int num6 = value;
                for (int i = 0; ((num6 >> 31) ^ i) <= ((num6 >> 31) ^ 0xFF); i += num6)
                {
                    Graphics graphics7 = bufferedGraphics.Graphics;
                    Point point = new Point(0, 0);
                    Point point9 = point;
                    Point point3 = new Point(0, 128);
                    graphics7.FillRectangle(new LinearGradientBrush(point9, point3, Color.White, HSL2RGB((int)Math.Round((double)i / 255.0 * 360.0), xS, 500)), i, 0, value, 128);
                    Graphics graphics8 = bufferedGraphics.Graphics;
                    point = new Point(0, 128);
                    Point point10 = point;
                    point3 = new Point(0, 256);
                    graphics8.FillRectangle(new LinearGradientBrush(point10, point3, HSL2RGB((int)Math.Round((double)i / 255.0 * 360.0), xS, 500), Color.Black), i, 128, value, 128);
                }
                break;
            }
            case 2:
            {
                int xL = Convert.ToInt32(inL.Value);
                int num2 = value;
                for (int i = 0; ((num2 >> 31) ^ i) <= ((num2 >> 31) ^ 0xFF); i += num2)
                {
                    Graphics graphics2 = bufferedGraphics.Graphics;
                    Point point = new Point(0, 0);
                    Point point4 = point;
                    Point point3 = new Point(0, 256);
                    graphics2.FillRectangle(new LinearGradientBrush(point4, point3, HSL2RGB((int)Math.Round((double)i / 255.0 * 360.0), 1000, xL), HSL2RGB((int)Math.Round((double)i / 255.0 * 360.0), 0, xL)), i, 0, value, 256);
                }
                break;
            }
            case 3:
            {
                int red = Convert.ToInt32(inR.Value);
                int num5 = value;
                for (int i = 0; ((num5 >> 31) ^ i) <= ((num5 >> 31) ^ 0xFF); i += num5)
                {
                    Graphics graphics6 = bufferedGraphics.Graphics;
                    Point point = new Point(0, 0);
                    Point point8 = point;
                    Point point3 = new Point(0, 256);
                    graphics6.FillRectangle(new LinearGradientBrush(point8, point3, Color.FromArgb(red, 255, i), Color.FromArgb(red, 0, i)), i, 0, value, 256);
                }
                break;
            }
            case 4:
            {
                int green = Convert.ToInt32(inG.Value);
                int num3 = value;
                for (int i = 0; ((num3 >> 31) ^ i) <= ((num3 >> 31) ^ 0xFF); i += num3)
                {
                    Graphics graphics3 = bufferedGraphics.Graphics;
                    Point point = new Point(0, 0);
                    Point point5 = point;
                    Point point3 = new Point(0, 256);
                    graphics3.FillRectangle(new LinearGradientBrush(point5, point3, Color.FromArgb(255, green, i), Color.FromArgb(0, green, i)), i, 0, value, 256);
                }
                break;
            }
            case 5:
            {
                int blue = Convert.ToInt32(inB.Value);
                int num = value;
                for (int i = 0; ((num >> 31) ^ i) <= ((num >> 31) ^ 0xFF); i += num)
                {
                    Graphics graphics = bufferedGraphics.Graphics;
                    Point point = new Point(0, 0);
                    Point point2 = point;
                    Point point3 = new Point(0, 256);
                    graphics.FillRectangle(new LinearGradientBrush(point2, point3, Color.FromArgb(255, i, blue), Color.FromArgb(0, i, blue)), i, 0, value, 256);
                }
                break;
            }
            }
            bufferedGraphics.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            NewLateBinding.LateCall(bufferedGraphics.Graphics, null, "DrawEllipse", new object[5]
            {
                RuntimeHelpers.GetObjectValue(Interaction.IIf(decimal.Compare(inL.Value, new decimal(500L)) > 0, Pens.Black, Pens.White)),
                mMain.X - 4,
                mMain.Y - 4,
                8,
                8
            }, null, null, null, IgnoreReturn: true);
            bufferedGraphics.Render(PCMain.CreateGraphics());
            bufferedGraphics.Dispose();
        }
    }

    private void rbH_CheckedChanged(object sender, EventArgs e)
    {
        if (Conversions.ToBoolean(NewLateBinding.LateGet(sender, null, "Checked", new object[0], null, null, null)))
        {
            DrawingIndex = 0;
            SetCursor();
            RefreshMain(PCMain.DisplayRectangle);
            Refresh1(PC1.DisplayRectangle);
            RefreshA(PCA.DisplayRectangle);
        }
    }

    private void rbS_CheckedChanged(object sender, EventArgs e)
    {
        if (Conversions.ToBoolean(NewLateBinding.LateGet(sender, null, "Checked", new object[0], null, null, null)))
        {
            DrawingIndex = 1;
            SetCursor();
            RefreshMain(PCMain.DisplayRectangle);
            Refresh1(PC1.DisplayRectangle);
            RefreshA(PCA.DisplayRectangle);
        }
    }

    private void rbL_CheckedChanged(object sender, EventArgs e)
    {
        if (Conversions.ToBoolean(NewLateBinding.LateGet(sender, null, "Checked", new object[0], null, null, null)))
        {
            DrawingIndex = 2;
            SetCursor();
            RefreshMain(PCMain.DisplayRectangle);
            Refresh1(PC1.DisplayRectangle);
            RefreshA(PCA.DisplayRectangle);
        }
    }

    private void rbR_CheckedChanged(object sender, EventArgs e)
    {
        if (Conversions.ToBoolean(NewLateBinding.LateGet(sender, null, "Checked", new object[0], null, null, null)))
        {
            DrawingIndex = 3;
            SetCursor();
            RefreshMain(PCMain.DisplayRectangle);
            Refresh1(PC1.DisplayRectangle);
            RefreshA(PCA.DisplayRectangle);
        }
    }

    private void rbG_CheckedChanged(object sender, EventArgs e)
    {
        if (Conversions.ToBoolean(NewLateBinding.LateGet(sender, null, "Checked", new object[0], null, null, null)))
        {
            DrawingIndex = 4;
            SetCursor();
            RefreshMain(PCMain.DisplayRectangle);
            Refresh1(PC1.DisplayRectangle);
            RefreshA(PCA.DisplayRectangle);
        }
    }

    private void rbB_CheckedChanged(object sender, EventArgs e)
    {
        if (Conversions.ToBoolean(NewLateBinding.LateGet(sender, null, "Checked", new object[0], null, null, null)))
        {
            DrawingIndex = 5;
            SetCursor();
            RefreshMain(PCMain.DisplayRectangle);
            Refresh1(PC1.DisplayRectangle);
            RefreshA(PCA.DisplayRectangle);
        }
    }

    private void inH_ValueChanged(object sender, EventArgs e)
    {
        if (decimal.Compare(inH.Value, new decimal(360L)) == 0)
        {
            inH.Value = 0m;
        }
        if (!PassiveValueChange)
        {
            PassiveValueChange = true;
            SetNewColor(HSL2RGB(Convert.ToInt32(inH.Value), Convert.ToInt32(inS.Value), Convert.ToInt32(inL.Value), Convert.ToInt32(inA.Value)));
            inR.Value = new decimal(NewColor.R);
            inG.Value = new decimal(NewColor.G);
            inB.Value = new decimal(NewColor.B);
            RefreshMain(PCMain.DisplayRectangle);
            Refresh1(PC1.DisplayRectangle);
            RefreshA(PCA.DisplayRectangle);
            PassiveValueChange = false;
        }
    }

    private void inS_ValueChanged(object sender, EventArgs e)
    {
        if (!PassiveValueChange)
        {
            PassiveValueChange = true;
            SetNewColor(HSL2RGB(Convert.ToInt32(inH.Value), Convert.ToInt32(inS.Value), Convert.ToInt32(inL.Value), Convert.ToInt32(inA.Value)));
            inR.Value = new decimal(NewColor.R);
            inG.Value = new decimal(NewColor.G);
            inB.Value = new decimal(NewColor.B);
            RefreshMain(PCMain.DisplayRectangle);
            Refresh1(PC1.DisplayRectangle);
            RefreshA(PCA.DisplayRectangle);
            PassiveValueChange = false;
        }
    }

    private void inL_ValueChanged(object sender, EventArgs e)
    {
        if (!PassiveValueChange)
        {
            PassiveValueChange = true;
            SetNewColor(HSL2RGB(Convert.ToInt32(inH.Value), Convert.ToInt32(inS.Value), Convert.ToInt32(inL.Value), Convert.ToInt32(inA.Value)));
            inR.Value = new decimal(NewColor.R);
            inG.Value = new decimal(NewColor.G);
            inB.Value = new decimal(NewColor.B);
            RefreshMain(PCMain.DisplayRectangle);
            Refresh1(PC1.DisplayRectangle);
            RefreshA(PCA.DisplayRectangle);
            PassiveValueChange = false;
        }
    }

    private void inR_ValueChanged(object sender, EventArgs e)
    {
        if (!PassiveValueChange)
        {
            PassiveValueChange = true;
            SetNewColor(Color.FromArgb(Convert.ToInt32(inA.Value), Convert.ToInt32(inR.Value), Convert.ToInt32(inG.Value), Convert.ToInt32(inB.Value)));
            inH.Value = new decimal(NewColor.GetHue());
            inS.Value = new decimal(NewColor.GetSaturation() * 1000f);
            inL.Value = new decimal(NewColor.GetBrightness() * 1000f);
            RefreshMain(PCMain.DisplayRectangle);
            Refresh1(PC1.DisplayRectangle);
            RefreshA(PCA.DisplayRectangle);
            PassiveValueChange = false;
        }
    }

    private void inG_ValueChanged(object sender, EventArgs e)
    {
        if (!PassiveValueChange)
        {
            PassiveValueChange = true;
            SetNewColor(Color.FromArgb(Convert.ToInt32(inA.Value), Convert.ToInt32(inR.Value), Convert.ToInt32(inG.Value), Convert.ToInt32(inB.Value)));
            inH.Value = new decimal(NewColor.GetHue());
            inS.Value = new decimal(NewColor.GetSaturation() * 1000f);
            inL.Value = new decimal(NewColor.GetBrightness() * 1000f);
            RefreshMain(PCMain.DisplayRectangle);
            Refresh1(PC1.DisplayRectangle);
            RefreshA(PCA.DisplayRectangle);
            PassiveValueChange = false;
        }
    }

    private void inB_ValueChanged(object sender, EventArgs e)
    {
        if (!PassiveValueChange)
        {
            PassiveValueChange = true;
            SetNewColor(Color.FromArgb(Convert.ToInt32(inA.Value), Convert.ToInt32(inR.Value), Convert.ToInt32(inG.Value), Convert.ToInt32(inB.Value)));
            inH.Value = new decimal(NewColor.GetHue());
            inS.Value = new decimal(NewColor.GetSaturation() * 1000f);
            inL.Value = new decimal(NewColor.GetBrightness() * 1000f);
            RefreshMain(PCMain.DisplayRectangle);
            Refresh1(PC1.DisplayRectangle);
            RefreshA(PCA.DisplayRectangle);
            PassiveValueChange = false;
        }
    }

    private void inA_ValueChanged(object sender, EventArgs e)
    {
        if (!PassiveValueChange)
        {
            PassiveValueChange = true;
            SetNewColor(Color.FromArgb(Convert.ToInt32(inA.Value), Convert.ToInt32(inR.Value), Convert.ToInt32(inG.Value), Convert.ToInt32(inB.Value)));
            RefreshA(PCA.DisplayRectangle);
            PassiveValueChange = false;
        }
    }

    private void PC1_MouseDown(object sender, MouseEventArgs e)
    {
        PC1_MouseMove(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void PC1_MouseMove(object sender, MouseEventArgs e)
    {
        checked
        {
            if (e.Button == MouseButtons.Left)
            {
                m1 = e.Y;
                if (m1 < 0)
                {
                    m1 = 0;
                }
                if (m1 > 255)
                {
                    m1 = 255;
                }
                switch (DrawingIndex)
                {
                case 0:
                    inH.Value = new decimal(360.0 - (double)m1 / 255.0 * 360.0);
                    break;
                case 1:
                    inS.Value = new decimal(1000.0 - (double)m1 / 255.0 * 1000.0);
                    break;
                case 2:
                    inL.Value = new decimal(1000.0 - (double)m1 / 255.0 * 1000.0);
                    break;
                case 3:
                    inR.Value = new decimal(255 - m1);
                    break;
                case 4:
                    inG.Value = new decimal(255 - m1);
                    break;
                case 5:
                    inB.Value = new decimal(255 - m1);
                    break;
                }
            }
        }
    }

    private void PC1_Paint(object sender, PaintEventArgs e)
    {
        Refresh1(e.ClipRectangle);
    }

    private void Refresh1(Rectangle xRegion)
    {
        BufferedGraphics bufferedGraphics = BufferedGraphicsManager.Current.Allocate(PC1.CreateGraphics(), xRegion);
        int num = PC1.DisplayRectangle.Width;
        int value = tbPrecision.Value;
        checked
        {
            Point point;
            Point point3;
            switch (DrawingIndex)
            {
            case 0:
            {
                int xS2 = Convert.ToInt32(inS.Value);
                int xL2 = Convert.ToInt32(inL.Value);
                int num2 = value;
                for (int i = 0; ((num2 >> 31) ^ i) <= ((num2 >> 31) ^ 0xFF); i += num2)
                {
                    bufferedGraphics.Graphics.FillRectangle(new SolidBrush(HSL2RGB((int)Math.Round((double)(255 - i) / 255.0 * 360.0), xS2, xL2)), 0, i, num, value);
                }
                break;
            }
            case 1:
            {
                int xH2 = Convert.ToInt32(inH.Value);
                int xL = Convert.ToInt32(inL.Value);
                Graphics graphics6 = bufferedGraphics.Graphics;
                point3 = new Point(0, 0);
                Point point8 = point3;
                point = new Point(0, 256);
                graphics6.FillRectangle(new LinearGradientBrush(point8, point, HSL2RGB(xH2, 1000, xL), HSL2RGB(xH2, 0, xL)), 0, 0, num, 256);
                break;
            }
            case 2:
            {
                int xH = Convert.ToInt32(inH.Value);
                int xS = Convert.ToInt32(inS.Value);
                Graphics graphics4 = bufferedGraphics.Graphics;
                point = new Point(0, 0);
                Point point6 = point;
                point3 = new Point(0, 128);
                graphics4.FillRectangle(new LinearGradientBrush(point6, point3, HSL2RGB(xH, xS, 1000), HSL2RGB(xH, xS, 500)), 0, 0, num, 128);
                Graphics graphics5 = bufferedGraphics.Graphics;
                point = new Point(0, 128);
                Point point7 = point;
                point3 = new Point(0, 256);
                graphics5.FillRectangle(new LinearGradientBrush(point7, point3, HSL2RGB(xH, xS, 500), HSL2RGB(xH, xS, 0)), 0, 128, num, 128);
                break;
            }
            case 3:
            {
                int green2 = Convert.ToInt32(inG.Value);
                int blue2 = Convert.ToInt32(inB.Value);
                Graphics graphics3 = bufferedGraphics.Graphics;
                point = new Point(0, 0);
                Point point5 = point;
                point3 = new Point(0, 256);
                graphics3.FillRectangle(new LinearGradientBrush(point5, point3, Color.FromArgb(255, green2, blue2), Color.FromArgb(0, green2, blue2)), 0, 0, num, 256);
                break;
            }
            case 4:
            {
                int red2 = Convert.ToInt32(inR.Value);
                int blue = Convert.ToInt32(inB.Value);
                Graphics graphics2 = bufferedGraphics.Graphics;
                point = new Point(0, 0);
                Point point4 = point;
                point3 = new Point(0, 256);
                graphics2.FillRectangle(new LinearGradientBrush(point4, point3, Color.FromArgb(red2, 255, blue), Color.FromArgb(red2, 0, blue)), 0, 0, num, 256);
                break;
            }
            case 5:
            {
                int red = Convert.ToInt32(inR.Value);
                int green = Convert.ToInt32(inG.Value);
                Graphics graphics = bufferedGraphics.Graphics;
                point = new Point(0, 0);
                Point point2 = point;
                point3 = new Point(0, 256);
                graphics.FillRectangle(new LinearGradientBrush(point2, point3, Color.FromArgb(red, green, 255), Color.FromArgb(red, green, 0)), 0, 0, num, 256);
                break;
            }
            }
            Point[] array = new Point[3];
            ref Point reference = ref array[0];
            point = new Point(4, m1);
            reference = point;
            ref Point reference2 = ref array[1];
            point3 = new Point(-1, m1 - 2);
            reference2 = point3;
            ref Point reference3 = ref array[2];
            Point point9 = new Point(-1, m1 + 2);
            reference3 = point9;
            Point[] points = array;
            array = new Point[3];
            ref Point reference4 = ref array[0];
            point9 = new Point(num - 5, m1);
            reference4 = point9;
            ref Point reference5 = ref array[1];
            point = new Point(num, m1 - 2);
            reference5 = point;
            ref Point reference6 = ref array[2];
            point3 = new Point(num, m1 + 2);
            reference6 = point3;
            Point[] points2 = array;
            bufferedGraphics.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            bufferedGraphics.Graphics.FillPolygon((Brush)Interaction.IIf(decimal.Compare(inL.Value, new decimal(500L)) > 0, Brushes.Black, Brushes.White), points);
            bufferedGraphics.Graphics.FillPolygon((Brush)Interaction.IIf(decimal.Compare(inL.Value, new decimal(500L)) > 0, Brushes.Black, Brushes.White), points2);
            bufferedGraphics.Render(PC1.CreateGraphics());
            bufferedGraphics.Dispose();
        }
    }

    private void PCA_MouseDown(object sender, MouseEventArgs e)
    {
        PCA_MouseMove(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void PCA_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            mAlpha = e.X;
            if (mAlpha < 0)
            {
                mAlpha = 0;
            }
            if (mAlpha > 255)
            {
                mAlpha = 255;
            }
            inA.Value = new decimal(mAlpha);
        }
    }

    private void PCA_Paint(object sender, PaintEventArgs e)
    {
        RefreshA(e.ClipRectangle);
    }

    private void RefreshA(Rectangle xRegion)
    {
        BufferedGraphics bufferedGraphics = BufferedGraphicsManager.Current.Allocate(PCA.CreateGraphics(), xRegion);
        int num = PCA.DisplayRectangle.Height;
        int value = tbPrecision.Value;
        Color baseColor = Color.FromArgb(Convert.ToInt32(inR.Value), Convert.ToInt32(inG.Value), Convert.ToInt32(inB.Value));
        bufferedGraphics.Graphics.DrawImageUnscaledAndClipped(Resources.TransparentBG, xRegion);
        int num2 = value;
        checked
        {
            int i;
            for (i = 0; ((num2 >> 31) ^ i) <= ((num2 >> 31) ^ 0xFF); i += num2)
            {
                bufferedGraphics.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(i, baseColor)), i, 0, value, num);
            }
            Point[] array = new Point[3];
            ref Point reference = ref array[0];
            Point point = new Point(mAlpha, 4);
            reference = point;
            ref Point reference2 = ref array[1];
            Point point2 = new Point(mAlpha - 2, -1);
            reference2 = point2;
            ref Point reference3 = ref array[2];
            Point point3 = new Point(mAlpha + 2, -1);
            reference3 = point3;
            Point[] points = array;
            array = new Point[3];
            ref Point reference4 = ref array[0];
            point3 = new Point(mAlpha, num - 5);
            reference4 = point3;
            ref Point reference5 = ref array[1];
            point2 = new Point(mAlpha - 2, num);
            reference5 = point2;
            ref Point reference6 = ref array[2];
            point = new Point(mAlpha + 2, num);
            reference6 = point;
            Point[] points2 = array;
            i = Convert.ToInt32(decimal.Add(inL.Value, decimal.Divide(decimal.Multiply(decimal.Subtract(new decimal(255L), inA.Value), new decimal(1000L)), new decimal(255L))));
            bufferedGraphics.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            bufferedGraphics.Graphics.FillPolygon((Brush)Interaction.IIf(i > 500, Brushes.Black, Brushes.White), points);
            bufferedGraphics.Graphics.FillPolygon((Brush)Interaction.IIf(i > 500, Brushes.Black, Brushes.White), points2);
            bufferedGraphics.Render(PCA.CreateGraphics());
            bufferedGraphics.Dispose();
        }
    }

    private void tbPrecision_ValueChanged(object sender, EventArgs e)
    {
        RefreshMain(PCMain.DisplayRectangle);
        Refresh1(PC1.DisplayRectangle);
        RefreshA(PCA.DisplayRectangle);
    }

    private void pPrev_Paint(object sender, PaintEventArgs e)
    {
        RefreshPrev(e.ClipRectangle);
    }

    private void RefreshPrev(Rectangle xRegion)
    {
        BufferedGraphics bufferedGraphics = BufferedGraphicsManager.Current.Allocate(pPrev.CreateGraphics(), xRegion);
        Font font = pPrev.Font;
        bufferedGraphics.Graphics.DrawImageUnscaledAndClipped(Resources.TransparentBG, xRegion);
        checked
        {
            if (xRegion.X < 62)
            {
                bufferedGraphics.Graphics.FillRectangle(new SolidBrush(OrigColor), 0, 0, 61, 28);
                bufferedGraphics.Graphics.DrawLine(new Pen(Color.FromKnownColor(KnownColor.WindowFrame)), 61, 0, 61, 28);
                bufferedGraphics.Graphics.DrawString("Orig", font, (Brush)Interaction.IIf((double)OrigColor.GetBrightness() + (double)(255 - unchecked((int)OrigColor.A)) / 255.0 > 0.5, Brushes.Black, Brushes.White), 31f - bufferedGraphics.Graphics.MeasureString("Orig", font).Width / 2f, 14f - bufferedGraphics.Graphics.MeasureString("Orig", font).Height / 2f);
            }
            bufferedGraphics.Graphics.FillRectangle(new SolidBrush(NewColor), 62, 0, 61, 28);
            bufferedGraphics.Graphics.DrawString("New", font, (Brush)Interaction.IIf((double)NewColor.GetBrightness() + (double)(255 - unchecked((int)NewColor.A)) / 255.0 > 0.5, Brushes.Black, Brushes.White), 93f - bufferedGraphics.Graphics.MeasureString("New", font).Width / 2f, 14f - bufferedGraphics.Graphics.MeasureString("New", font).Height / 2f);
            bufferedGraphics.Render(pPrev.CreateGraphics());
            bufferedGraphics.Dispose();
        }
    }

    private void tStr_GotFocus(object sender, EventArgs e)
    {
        tStr.SelectAll();
    }

    private void tStr_LostFocus(object sender, EventArgs e)
    {
        try
        {
            int argb = Convert.ToInt32(tStr.Text, 16);
            SetNewColor(Color.FromArgb(argb));
            PassiveValueChange = true;
            inR.Value = new decimal(NewColor.R);
            inG.Value = new decimal(NewColor.G);
            inB.Value = new decimal(NewColor.B);
            inH.Value = new decimal(NewColor.GetHue());
            inS.Value = new decimal(NewColor.GetSaturation() * 1000f);
            inL.Value = new decimal(NewColor.GetBrightness() * 1000f);
            inA.Value = new decimal(NewColor.A);
            SetCursor();
            RefreshMain(PCMain.DisplayRectangle);
            Refresh1(PC1.DisplayRectangle);
            RefreshA(PCA.DisplayRectangle);
            PassiveValueChange = false;
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical, "Error");
            ProjectData.ClearProjectError();
        }
        finally
        {
            tStr.Text = Microsoft.VisualBasic.Strings.Mid("0000000" + Conversion.Hex(NewColor.ToArgb()), Microsoft.VisualBasic.Strings.Len(Conversion.Hex(NewColor.ToArgb())));
        }
    }

    private void tStr_TextChanged(object sender, EventArgs e)
    {
        if (PassiveValueChange)
        {
            return;
        }
        try
        {
            int argb = Convert.ToInt32(tStr.Text, 16);
            SetNewColor(Color.FromArgb(argb), xSetText: false);
            PassiveValueChange = true;
            inR.Value = new decimal(NewColor.R);
            inG.Value = new decimal(NewColor.G);
            inB.Value = new decimal(NewColor.B);
            inH.Value = new decimal(NewColor.GetHue());
            inS.Value = new decimal(NewColor.GetSaturation() * 1000f);
            inL.Value = new decimal(NewColor.GetBrightness() * 1000f);
            inA.Value = new decimal(NewColor.A);
            SetCursor();
            RefreshMain(PCMain.DisplayRectangle);
            Refresh1(PC1.DisplayRectangle);
            RefreshA(PCA.DisplayRectangle);
            PassiveValueChange = false;
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            ProjectData.ClearProjectError();
        }
    }

    private void ColorPicker_Load(object sender, EventArgs e)
    {
        Font = MyProject.Forms.MainWindow.Font;
    }
}
