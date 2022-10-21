using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using iBMSC.Editor;
using iBMSC.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace iBMSC;

[DesignerGenerated]
public partial class OpVisual : Form
{
    public struct ColumnOptionSet
    {
        public NumericUpDown Width;

        public TextBox Title;

        public Button SNote;

        public Button SText;

        public Button LNote;

        public Button LText;

        public Button BG;
    }

    private int niB;

    private int[] lLeft;

    private visualSettings vo;

    private Column[] col;

    private ColumnOptionSet[] co;

    public OpVisual(visualSettings xvo, Column[] xcol, Font monoFont)
    {
        base.Load += OpVisual_Load;
        niB = 27;
        lLeft = new int[28]
        {
            78, 110, 142, 174, 208, 240, 272, 304, 336, 368,
            400, 432, 464, 498, 530, 562, 594, 626, 658, 690,
            722, 754, 788, 820, 852, 884, 918, 950
        };
        InitializeComponent();
        vo = xvo;
        cButtonChange(cColumnTitle, vo.ColumnTitle.Color);
        cButtonChange(cBG, vo.Bg.Color);
        cButtonChange(cGrid, vo.pGrid.Color);
        cButtonChange(cSub, vo.pSub.Color);
        cButtonChange(cVerticalLine, vo.pVLine.Color);
        cButtonChange(cMeasureBarLine, vo.pMLine.Color);
        cButtonChange(cWaveForm, vo.pBGMWav.Color);
        cButtonChange(cMouseOver, vo.kMouseOver.Color);
        cButtonChange(cSelectedBorder, vo.kSelected.Color);
        cButtonChange(cAdjustLengthBorder, vo.kMouseOverE.Color);
        cButtonChange(cSelectionBox, vo.SelBox.Color);
        cButtonChange(cTSCursor, vo.PECursor.Color);
        cButtonChange(cTSSplitter, vo.PEHalf.Color);
        cButtonChange(cTSMouseOver, vo.PEMouseOver.Color);
        cButtonChange(cTSSelectionFill, vo.PESel.Color);
        cButtonChange(cTSBPM, vo.PEBPM.Color);
        fButtonChange(fColumnTitle, vo.ColumnTitleFont);
        fButtonChange(fNoteLabel, vo.kFont);
        fButtonChange(fMeasureLabel, vo.kMFont);
        fButtonChange(fTSBPM, vo.PEBPMFont);
        var self = iNoteHeight;
        Extensions.SetValClamped(self, new decimal(vo.kHeight));
        iNoteHeight = self;
        self = iLabelVerticalShift;
        Extensions.SetValClamped(self, new decimal(vo.kLabelVShift));
        iLabelVerticalShift = self;
        self = iLabelHorizShift;
        Extensions.SetValClamped(self, new decimal(vo.kLabelHShift));
        iLabelHorizShift = self;
        self = iLongLabelHorizShift;
        Extensions.SetValClamped(self, new decimal(vo.kLabelHShiftL));
        iLongLabelHorizShift = self;
        self = iHiddenNoteOpacity;
        Extensions.SetValClamped(self, new decimal(vo.kOpacity));
        iHiddenNoteOpacity = self;
        self = iTSSensitivity;
        Extensions.SetValClamped(self, new decimal(vo.PEDeltaMouseOver));
        iTSSensitivity = self;
        self = iMiddleSensitivity;
        Extensions.SetValClamped(self, new decimal(vo.MiddleDeltaRelease));
        iMiddleSensitivity = self;
        col = (Column[])xcol.Clone();
        checked
        {
            co = new ColumnOptionSet[Information.UBound(col) + 1];
            var num = Information.UBound(col);
            var color = default(Color);
            for (var i = 0; i <= num; i++)
            {
                var numericUpDown = new NumericUpDown();
                var numericUpDown2 = numericUpDown;
                numericUpDown2.BorderStyle = BorderStyle.FixedSingle;
                var numericUpDown3 = numericUpDown2;
                var location = new Point(lLeft[i], 12);
                numericUpDown3.Location = location;
                numericUpDown2.Maximum = 999m;
                var numericUpDown4 = numericUpDown2;
                var size = new Size(33, 23);
                numericUpDown4.Size = size;
                numericUpDown2.Value = new decimal(col[i].Width);
                numericUpDown2 = null;
                var textBox = new TextBox();
                var textBox2 = textBox;
                textBox2.BorderStyle = BorderStyle.FixedSingle;
                var textBox3 = textBox2;
                location = new Point(lLeft[i], 34);
                textBox3.Location = location;
                var textBox4 = textBox2;
                size = new Size(33, 23);
                textBox4.Size = size;
                textBox2.Text = col[i].Title;
                textBox2 = null;
                var button = new Button();
                var button2 = button;
                button2.FlatStyle = FlatStyle.Popup;
                button2.Font = monoFont;
                var button3 = button2;
                location = new Point(lLeft[i], 63);
                button3.Location = location;
                var button4 = button2;
                size = new Size(33, 66);
                button4.Size = size;
                button2.BackColor = Color.FromArgb(col[i].cNote);
                button2.ForeColor = col[i].cText;
                button2.Text = To4Hex(col[i].cNote);
                button2.Name = "cNote";
                button2 = null;
                var button5 = new Button();
                var button6 = button5;
                button6.FlatStyle = FlatStyle.Popup;
                button6.Font = monoFont;
                var button7 = button6;
                location = new Point(lLeft[i], 128);
                button7.Location = location;
                var button8 = button6;
                size = new Size(33, 66);
                button8.Size = size;
                button6.BackColor = Color.FromArgb(col[i].cNote);
                button6.ForeColor = col[i].cText;
                button6.Text = To4Hex(col[i].cText.ToArgb());
                button6.Name = "cText";
                button6 = null;
                button.Tag = button5;
                button5.Tag = button;
                var button9 = new Button();
                var button10 = button9;
                button10.FlatStyle = FlatStyle.Popup;
                button10.Font = monoFont;
                var button11 = button10;
                location = new Point(lLeft[i], 193);
                button11.Location = location;
                var button12 = button10;
                size = new Size(33, 66);
                button12.Size = size;
                button10.BackColor = Color.FromArgb(col[i].cLNote);
                button10.ForeColor = col[i].cLText;
                button10.Text = To4Hex(col[i].cLNote);
                button10.Name = "cNote";
                button10 = null;
                var button13 = new Button();
                var button14 = button13;
                button14.FlatStyle = FlatStyle.Popup;
                button14.Font = monoFont;
                var button15 = button14;
                location = new Point(lLeft[i], 258);
                button15.Location = location;
                var button16 = button14;
                size = new Size(33, 66);
                button16.Size = size;
                button14.BackColor = Color.FromArgb(col[i].cLNote);
                button14.ForeColor = col[i].cLText;
                button14.Text = To4Hex(col[i].cLText.ToArgb());
                button14.Name = "cText";
                button14 = null;
                button9.Tag = button13;
                button13.Tag = button9;
                var button17 = new Button();
                var button18 = button17;
                button18.FlatStyle = FlatStyle.Popup;
                button18.Font = monoFont;
                var button19 = button18;
                location = new Point(lLeft[i], 323);
                button19.Location = location;
                var button20 = button18;
                size = new Size(33, 66);
                button20.Size = size;
                button18.BackColor = col[i].cBG;
                var button21 = button18;
                var obj = Interaction.IIf((int)Math.Round(col[i].cBG.GetBrightness() * 255f) + 255 - unchecked(col[i].cBG.A) >= 128, Color.Black, Color.White);
                button21.ForeColor = ((obj != null) ? ((Color)obj) : color);
                button18.Text = To4Hex(col[i].cBG.ToArgb());
                button18.Name = "cBG";
                button18.Tag = null;
                button18 = null;
                Panel1.Controls.Add(numericUpDown);
                Panel1.Controls.Add(textBox);
                Panel1.Controls.Add(button);
                Panel1.Controls.Add(button5);
                Panel1.Controls.Add(button9);
                Panel1.Controls.Add(button13);
                Panel1.Controls.Add(button17);
                co[i].Width = numericUpDown;
                co[i].Title = textBox;
                co[i].SNote = button;
                co[i].SText = button5;
                co[i].LNote = button9;
                co[i].LText = button13;
                co[i].BG = button17;
                button.Click += ButtonClick;
                button5.Click += ButtonClick;
                button9.Click += ButtonClick;
                button13.Click += ButtonClick;
                button17.Click += ButtonClick;
            }
        }
    }

    private void cButtonChange(Button xbutton, Color c)
    {
        xbutton.Text = Conversion.Hex(c.ToArgb());
        xbutton.BackColor = c;
        checked
        {
            var obj = Interaction.IIf((int)Math.Round(c.GetBrightness() * 255f) + 255 - unchecked(c.A) >= 128, Color.Black, Color.White);
            var color = default(Color);
            xbutton.ForeColor = ((obj != null) ? ((Color)obj) : color);
        }
    }

    private void fButtonChange(Button xbutton, Font f)
    {
        xbutton.Text = f.FontFamily.Name;
        xbutton.Font = f;
    }

    private void OK_Button_Click(object sender, EventArgs e)
    {
        vo.ColumnTitle.Color = cColumnTitle.BackColor;
        vo.Bg.Color = cBG.BackColor;
        vo.pGrid.Color = cGrid.BackColor;
        vo.pSub.Color = cSub.BackColor;
        vo.pVLine.Color = cVerticalLine.BackColor;
        vo.pMLine.Color = cMeasureBarLine.BackColor;
        vo.pBGMWav.Color = cWaveForm.BackColor;
        vo.kMouseOver.Color = cMouseOver.BackColor;
        vo.kSelected.Color = cSelectedBorder.BackColor;
        vo.kMouseOverE.Color = cAdjustLengthBorder.BackColor;
        vo.SelBox.Color = cSelectionBox.BackColor;
        vo.PECursor.Color = cTSCursor.BackColor;
        vo.PEHalf.Color = cTSSplitter.BackColor;
        vo.PEMouseOver.Color = cTSMouseOver.BackColor;
        vo.PESel.Color = cTSSelectionFill.BackColor;
        vo.PEBPM.Color = cTSBPM.BackColor;
        vo.ColumnTitleFont = fColumnTitle.Font;
        vo.kFont = fNoteLabel.Font;
        vo.kMFont = fMeasureLabel.Font;
        vo.PEBPMFont = fTSBPM.Font;
        vo.kHeight = Convert.ToInt32(iNoteHeight.Value);
        vo.kLabelVShift = Convert.ToInt32(iLabelVerticalShift.Value);
        vo.kLabelHShift = Convert.ToInt32(iLabelHorizShift.Value);
        vo.kLabelHShiftL = Convert.ToInt32(iLongLabelHorizShift.Value);
        vo.kOpacity = Convert.ToSingle(iHiddenNoteOpacity.Value);
        vo.PEDeltaMouseOver = Convert.ToInt32(iTSSensitivity.Value);
        vo.MiddleDeltaRelease = Convert.ToInt32(iMiddleSensitivity.Value);
        MyProject.Forms.MainWindow.setVO(vo);
        var num = Information.UBound(co);
        for (var i = 0; i <= num; i = checked(i + 1))
        {
            col[i].Title = co[i].Title.Text;
            col[i].Width = Convert.ToInt32(co[i].Width.Value);
            col[i].setNoteColor(co[i].SNote.BackColor.ToArgb());
            col[i].cText = co[i].SText.ForeColor;
            col[i].setLNoteColor(co[i].LNote.BackColor.ToArgb());
            col[i].cLText = co[i].LText.ForeColor;
            col[i].cBG = co[i].BG.BackColor;
        }
        MyProject.Forms.MainWindow.column = col;
        DialogResult = DialogResult.OK;
        Close();
    }

    private void Cancel_Button_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void OpVisual_Load(object sender, EventArgs e)
    {
        Font = MyProject.Forms.MainWindow.Font;
        Text = Strings.fopVisual.Title;
        Label37.Text = Strings.fopVisual.ColumnCaption;
        Label9.Text = Strings.fopVisual.ColumnCaptionFont;
        Label30.Text = Strings.fopVisual.Background;
        Label26.Text = Strings.fopVisual.Grid;
        Label27.Text = Strings.fopVisual.SubGrid;
        Label29.Text = Strings.fopVisual.VerticalLine;
        Label40.Text = Strings.fopVisual.MeasureBarLine;
        Label22.Text = Strings.fopVisual.BGMWaveform;
        Label21.Text = Strings.fopVisual.NoteHeight;
        Label24.Text = Strings.fopVisual.NoteLabel;
        Label28.Text = Strings.fopVisual.MeasureLabel;
        Label25.Text = Strings.fopVisual.LabelVerticalShift;
        Label38.Text = Strings.fopVisual.LabelHorizontalShift;
        Label39.Text = Strings.fopVisual.LongNoteLabelHorizontalShift;
        Label33.Text = Strings.fopVisual.HiddenNoteOpacity;
        Label34.Text = Strings.fopVisual.NoteBorderOnMouseOver;
        Label35.Text = Strings.fopVisual.NoteBorderOnSelection;
        Label23.Text = Strings.fopVisual.NoteBorderOnAdjustingLength;
        Label31.Text = Strings.fopVisual.SelectionBoxBorder;
        Label98.Text = Strings.fopVisual.TSCursor;
        Label97.Text = Strings.fopVisual.TSSplitter;
        Label96.Text = Strings.fopVisual.TSCursorSensitivity;
        Label91.Text = Strings.fopVisual.TSMouseOverBorder;
        Label86.Text = Strings.fopVisual.TSFill;
        Label88.Text = Strings.fopVisual.TSBPM;
        Label82.Text = Strings.fopVisual.TSBPMFont;
        Label14.Text = Strings.fopVisual.MiddleSensitivity;
        Label1.Text = Strings.fopVisual.Width;
        Label2.Text = Strings.fopVisual.Caption;
        Label4.Text = Strings.fopVisual.Note;
        Label6.Text = Strings.fopVisual.Label;
        Label5.Text = Strings.fopVisual.LongNote;
        Label7.Text = Strings.fopVisual.LongNoteLabel;
        Label8.Text = Strings.fopVisual.Bg;
    }

    private void BCClick(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var colorPicker = new ColorPicker();
        colorPicker.SetOrigColor(button.BackColor);
        if (colorPicker.ShowDialog(this) != DialogResult.Cancel)
        {
            cButtonChange(button, colorPicker.NewColor);
        }
    }

    private void BFClick(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var fontDialog = new FontDialog();
        fontDialog.Font = button.Font;
        if (fontDialog.ShowDialog(this) != DialogResult.Cancel)
        {
            fButtonChange(button, fontDialog.Font);
        }
    }

    private void ButtonClick(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var colorPicker = new ColorPicker();
        if (Operators.CompareString(button.Name, "cText", TextCompare: false) == 0)
        {
            colorPicker.SetOrigColor(button.ForeColor);
        }
        else
        {
            colorPicker.SetOrigColor(button.BackColor);
        }
        checked
        {
            if (colorPicker.ShowDialog(this) != DialogResult.Cancel)
            {
                button.Text = To4Hex(colorPicker.NewColor.ToArgb());
                switch (button.Name)
                {
                    case "cNote":
                        button.BackColor = colorPicker.NewColor;
                        ((Button)button.Tag).BackColor = colorPicker.NewColor;
                        break;
                    case "cText":
                        button.ForeColor = colorPicker.NewColor;
                        ((Button)button.Tag).ForeColor = colorPicker.NewColor;
                        break;
                    case "cBG":
                        {
                            button.BackColor = colorPicker.NewColor;
                            var obj = Interaction.IIf((int)Math.Round(colorPicker.NewColor.GetBrightness() * 255f) + 255 - unchecked(colorPicker.NewColor.A) >= 128, Color.Black, Color.White);
                            var color = default(Color);
                            button.ForeColor = ((obj != null) ? ((Color)obj) : color);
                            break;
                        }
                }
            }
        }
    }

    private int[] ColorArrayToIntArray(Color[] xC)
    {
        checked
        {
            var array = new int[Information.UBound(xC) + 1];
            var num = Information.UBound(array);
            for (var i = 0; i <= num; i++)
            {
                array[i] = xC[i].ToArgb();
            }
            return array;
        }
    }

    private string To4Hex(int xInt)
    {
        var color = Color.FromArgb(xInt);
        return Conversion.Hex(color.A) + "\r\n" + Conversion.Hex(color.R) + "\r\n" + Conversion.Hex(color.G) + "\r\n" + Conversion.Hex(color.B);
    }
}
