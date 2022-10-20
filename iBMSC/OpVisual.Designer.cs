using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace iBMSC
{
    public partial class OpVisual : Form
    {
    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
        try
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
        }
        finally
        {
            base.Dispose(disposing);
        }
    }
    private IContainer components;
    [System.Diagnostics.DebuggerStepThrough]
    private void InitializeComponent()
    {
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.OK_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label33 = new System.Windows.Forms.Label();
            this.iHiddenNoteOpacity = new System.Windows.Forms.NumericUpDown();
            this.Label23 = new System.Windows.Forms.Label();
            this.cAdjustLengthBorder = new System.Windows.Forms.Button();
            this.cSelectedBorder = new System.Windows.Forms.Button();
            this.cMouseOver = new System.Windows.Forms.Button();
            this.iLongLabelHorizShift = new System.Windows.Forms.NumericUpDown();
            this.iLabelHorizShift = new System.Windows.Forms.NumericUpDown();
            this.iLabelVerticalShift = new System.Windows.Forms.NumericUpDown();
            this.fMeasureLabel = new System.Windows.Forms.Button();
            this.fNoteLabel = new System.Windows.Forms.Button();
            this.iNoteHeight = new System.Windows.Forms.NumericUpDown();
            this.fTSBPM = new System.Windows.Forms.Button();
            this.cTSBPM = new System.Windows.Forms.Button();
            this.cTSSelectionFill = new System.Windows.Forms.Button();
            this.cTSCursor = new System.Windows.Forms.Button();
            this.cSelectionBox = new System.Windows.Forms.Button();
            this.cWaveForm = new System.Windows.Forms.Button();
            this.cMeasureBarLine = new System.Windows.Forms.Button();
            this.cVerticalLine = new System.Windows.Forms.Button();
            this.cSub = new System.Windows.Forms.Button();
            this.cGrid = new System.Windows.Forms.Button();
            this.cBG = new System.Windows.Forms.Button();
            this.fColumnTitle = new System.Windows.Forms.Button();
            this.cColumnTitle = new System.Windows.Forms.Button();
            this.Label40 = new System.Windows.Forms.Label();
            this.Label39 = new System.Windows.Forms.Label();
            this.Label38 = new System.Windows.Forms.Label();
            this.Label37 = new System.Windows.Forms.Label();
            this.Label88 = new System.Windows.Forms.Label();
            this.Label35 = new System.Windows.Forms.Label();
            this.Label34 = new System.Windows.Forms.Label();
            this.Label86 = new System.Windows.Forms.Label();
            this.Label98 = new System.Windows.Forms.Label();
            this.Label31 = new System.Windows.Forms.Label();
            this.Label30 = new System.Windows.Forms.Label();
            this.Label29 = new System.Windows.Forms.Label();
            this.Label28 = new System.Windows.Forms.Label();
            this.Label27 = new System.Windows.Forms.Label();
            this.Label26 = new System.Windows.Forms.Label();
            this.Label25 = new System.Windows.Forms.Label();
            this.Label24 = new System.Windows.Forms.Label();
            this.Label22 = new System.Windows.Forms.Label();
            this.Label21 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.cTSSplitter = new System.Windows.Forms.Button();
            this.Label97 = new System.Windows.Forms.Label();
            this.Label96 = new System.Windows.Forms.Label();
            this.iTSSensitivity = new System.Windows.Forms.NumericUpDown();
            this.cTSMouseOver = new System.Windows.Forms.Button();
            this.Label91 = new System.Windows.Forms.Label();
            this.Label82 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.iMiddleSensitivity = new System.Windows.Forms.NumericUpDown();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.TableLayoutPanel1.SuspendLayout();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iHiddenNoteOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iLongLabelHorizShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iLabelHorizShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iLabelVerticalShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNoteHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTSSensitivity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMiddleSensitivity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
            this.TableLayoutPanel1.Location = new System.Drawing.Point(868, 672);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(146, 29);
            this.TableLayoutPanel1.TabIndex = 0;
            // 
            // OK_Button
            // 
            this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OK_Button.Location = new System.Drawing.Point(3, 3);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(67, 23);
            this.OK_Button.TabIndex = 0;
            this.OK_Button.Text = "OK";
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Location = new System.Drawing.Point(76, 3);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(67, 23);
            this.Cancel_Button.TabIndex = 1;
            this.Cancel_Button.Text = "Cancel";
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.Label8);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Controls.Add(this.Label7);
            this.Panel1.Controls.Add(this.Label5);
            this.Panel1.Controls.Add(this.Label6);
            this.Panel1.Controls.Add(this.Label2);
            this.Panel1.Controls.Add(this.Label4);
            this.Panel1.Location = new System.Drawing.Point(10, 263);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1004, 402);
            this.Panel1.TabIndex = 87;
            // 
            // Label8
            // 
            this.Label8.Location = new System.Drawing.Point(12, 324);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(60, 65);
            this.Label8.TabIndex = 39;
            this.Label8.Text = "Bg";
            this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(12, 15);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(60, 15);
            this.Label1.TabIndex = 33;
            this.Label1.Text = "Width";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label7
            // 
            this.Label7.Location = new System.Drawing.Point(12, 258);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(60, 66);
            this.Label7.TabIndex = 38;
            this.Label7.Text = "Long\r\nNote\r\nLabel";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label5
            // 
            this.Label5.Location = new System.Drawing.Point(12, 193);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(60, 66);
            this.Label5.TabIndex = 36;
            this.Label5.Text = "Long\r\nNote";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label6
            // 
            this.Label6.Location = new System.Drawing.Point(12, 128);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(60, 66);
            this.Label6.TabIndex = 37;
            this.Label6.Text = "Label";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(12, 37);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(60, 15);
            this.Label2.TabIndex = 34;
            this.Label2.Text = "Caption";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(12, 63);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(60, 66);
            this.Label4.TabIndex = 35;
            this.Label4.Text = "Note";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label33
            // 
            this.Label33.Location = new System.Drawing.Point(315, 152);
            this.Label33.Name = "Label33";
            this.Label33.Size = new System.Drawing.Size(220, 15);
            this.Label33.TabIndex = 137;
            this.Label33.Text = "Hidden Note Opacity";
            this.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // iHiddenNoteOpacity
            // 
            this.iHiddenNoteOpacity.DecimalPlaces = 2;
            this.iHiddenNoteOpacity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.iHiddenNoteOpacity.Location = new System.Drawing.Point(537, 148);
            this.iHiddenNoteOpacity.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.iHiddenNoteOpacity.Name = "iHiddenNoteOpacity";
            this.iHiddenNoteOpacity.Size = new System.Drawing.Size(80, 23);
            this.iHiddenNoteOpacity.TabIndex = 136;
            this.iHiddenNoteOpacity.Tag = "4";
            // 
            // Label23
            // 
            this.Label23.Location = new System.Drawing.Point(315, 225);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(220, 15);
            this.Label23.TabIndex = 135;
            this.Label23.Text = "Note Border on Adjusting Length";
            this.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cAdjustLengthBorder
            // 
            this.cAdjustLengthBorder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cAdjustLengthBorder.Location = new System.Drawing.Point(537, 221);
            this.cAdjustLengthBorder.Name = "cAdjustLengthBorder";
            this.cAdjustLengthBorder.Size = new System.Drawing.Size(80, 23);
            this.cAdjustLengthBorder.TabIndex = 134;
            this.cAdjustLengthBorder.Tag = "13";
            this.cAdjustLengthBorder.Text = "FF000000";
            this.cAdjustLengthBorder.UseVisualStyleBackColor = true;
            this.cAdjustLengthBorder.Click += new System.EventHandler(this.BCClick);
            // 
            // cSelectedBorder
            // 
            this.cSelectedBorder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cSelectedBorder.Location = new System.Drawing.Point(537, 199);
            this.cSelectedBorder.Name = "cSelectedBorder";
            this.cSelectedBorder.Size = new System.Drawing.Size(80, 23);
            this.cSelectedBorder.TabIndex = 133;
            this.cSelectedBorder.Tag = "12";
            this.cSelectedBorder.Text = "FF000000";
            this.cSelectedBorder.UseVisualStyleBackColor = true;
            this.cSelectedBorder.Click += new System.EventHandler(this.BCClick);
            // 
            // cMouseOver
            // 
            this.cMouseOver.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cMouseOver.Location = new System.Drawing.Point(537, 177);
            this.cMouseOver.Name = "cMouseOver";
            this.cMouseOver.Size = new System.Drawing.Size(80, 23);
            this.cMouseOver.TabIndex = 132;
            this.cMouseOver.Tag = "11";
            this.cMouseOver.Text = "FF000000";
            this.cMouseOver.UseVisualStyleBackColor = true;
            this.cMouseOver.Click += new System.EventHandler(this.BCClick);
            // 
            // iLongLabelHorizShift
            // 
            this.iLongLabelHorizShift.Location = new System.Drawing.Point(537, 126);
            this.iLongLabelHorizShift.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.iLongLabelHorizShift.Name = "iLongLabelHorizShift";
            this.iLongLabelHorizShift.Size = new System.Drawing.Size(80, 23);
            this.iLongLabelHorizShift.TabIndex = 131;
            this.iLongLabelHorizShift.Tag = "3";
            // 
            // iLabelHorizShift
            // 
            this.iLabelHorizShift.Location = new System.Drawing.Point(537, 104);
            this.iLabelHorizShift.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.iLabelHorizShift.Name = "iLabelHorizShift";
            this.iLabelHorizShift.Size = new System.Drawing.Size(80, 23);
            this.iLabelHorizShift.TabIndex = 130;
            this.iLabelHorizShift.Tag = "2";
            // 
            // iLabelVerticalShift
            // 
            this.iLabelVerticalShift.Location = new System.Drawing.Point(537, 82);
            this.iLabelVerticalShift.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.iLabelVerticalShift.Name = "iLabelVerticalShift";
            this.iLabelVerticalShift.Size = new System.Drawing.Size(80, 23);
            this.iLabelVerticalShift.TabIndex = 129;
            this.iLabelVerticalShift.Tag = "1";
            // 
            // fMeasureLabel
            // 
            this.fMeasureLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.fMeasureLabel.Location = new System.Drawing.Point(537, 60);
            this.fMeasureLabel.Name = "fMeasureLabel";
            this.fMeasureLabel.Size = new System.Drawing.Size(80, 23);
            this.fMeasureLabel.TabIndex = 128;
            this.fMeasureLabel.Tag = "3";
            this.fMeasureLabel.Text = "Verdana";
            this.fMeasureLabel.UseVisualStyleBackColor = true;
            this.fMeasureLabel.Click += new System.EventHandler(this.BFClick);
            // 
            // fNoteLabel
            // 
            this.fNoteLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.fNoteLabel.Location = new System.Drawing.Point(537, 38);
            this.fNoteLabel.Name = "fNoteLabel";
            this.fNoteLabel.Size = new System.Drawing.Size(80, 23);
            this.fNoteLabel.TabIndex = 127;
            this.fNoteLabel.Tag = "2";
            this.fNoteLabel.Text = "Verdana";
            this.fNoteLabel.UseVisualStyleBackColor = true;
            this.fNoteLabel.Click += new System.EventHandler(this.BFClick);
            // 
            // iNoteHeight
            // 
            this.iNoteHeight.Location = new System.Drawing.Point(537, 16);
            this.iNoteHeight.Name = "iNoteHeight";
            this.iNoteHeight.Size = new System.Drawing.Size(80, 23);
            this.iNoteHeight.TabIndex = 126;
            this.iNoteHeight.Tag = "0";
            // 
            // fTSBPM
            // 
            this.fTSBPM.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.fTSBPM.Location = new System.Drawing.Point(870, 170);
            this.fTSBPM.Name = "fTSBPM";
            this.fTSBPM.Size = new System.Drawing.Size(80, 23);
            this.fTSBPM.TabIndex = 125;
            this.fTSBPM.Tag = "1";
            this.fTSBPM.Text = "Verdana";
            this.fTSBPM.UseVisualStyleBackColor = true;
            this.fTSBPM.Click += new System.EventHandler(this.BFClick);
            // 
            // cTSBPM
            // 
            this.cTSBPM.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cTSBPM.Location = new System.Drawing.Point(870, 148);
            this.cTSBPM.Name = "cTSBPM";
            this.cTSBPM.Size = new System.Drawing.Size(80, 23);
            this.cTSBPM.TabIndex = 124;
            this.cTSBPM.Tag = "10";
            this.cTSBPM.Text = "FF000000";
            this.cTSBPM.UseVisualStyleBackColor = true;
            this.cTSBPM.Click += new System.EventHandler(this.BCClick);
            // 
            // cTSSelectionFill
            // 
            this.cTSSelectionFill.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cTSSelectionFill.Location = new System.Drawing.Point(870, 126);
            this.cTSSelectionFill.Name = "cTSSelectionFill";
            this.cTSSelectionFill.Size = new System.Drawing.Size(80, 23);
            this.cTSSelectionFill.TabIndex = 123;
            this.cTSSelectionFill.Tag = "9";
            this.cTSSelectionFill.Text = "FF000000";
            this.cTSSelectionFill.UseVisualStyleBackColor = true;
            this.cTSSelectionFill.Click += new System.EventHandler(this.BCClick);
            // 
            // cTSCursor
            // 
            this.cTSCursor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cTSCursor.Location = new System.Drawing.Point(870, 38);
            this.cTSCursor.Name = "cTSCursor";
            this.cTSCursor.Size = new System.Drawing.Size(80, 23);
            this.cTSCursor.TabIndex = 122;
            this.cTSCursor.Tag = "8";
            this.cTSCursor.Text = "FF000000";
            this.cTSCursor.UseVisualStyleBackColor = true;
            this.cTSCursor.Click += new System.EventHandler(this.BCClick);
            // 
            // cSelectionBox
            // 
            this.cSelectionBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cSelectionBox.Location = new System.Drawing.Point(870, 16);
            this.cSelectionBox.Name = "cSelectionBox";
            this.cSelectionBox.Size = new System.Drawing.Size(80, 23);
            this.cSelectionBox.TabIndex = 121;
            this.cSelectionBox.Tag = "7";
            this.cSelectionBox.Text = "FF000000";
            this.cSelectionBox.UseVisualStyleBackColor = true;
            this.cSelectionBox.Click += new System.EventHandler(this.BCClick);
            // 
            // cWaveForm
            // 
            this.cWaveForm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cWaveForm.Location = new System.Drawing.Point(204, 177);
            this.cWaveForm.Name = "cWaveForm";
            this.cWaveForm.Size = new System.Drawing.Size(80, 23);
            this.cWaveForm.TabIndex = 120;
            this.cWaveForm.Tag = "6";
            this.cWaveForm.Text = "FF000000";
            this.cWaveForm.UseVisualStyleBackColor = true;
            this.cWaveForm.Click += new System.EventHandler(this.BCClick);
            // 
            // cMeasureBarLine
            // 
            this.cMeasureBarLine.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cMeasureBarLine.Location = new System.Drawing.Point(204, 155);
            this.cMeasureBarLine.Name = "cMeasureBarLine";
            this.cMeasureBarLine.Size = new System.Drawing.Size(80, 23);
            this.cMeasureBarLine.TabIndex = 119;
            this.cMeasureBarLine.Tag = "5";
            this.cMeasureBarLine.Text = "FF000000";
            this.cMeasureBarLine.UseVisualStyleBackColor = true;
            this.cMeasureBarLine.Click += new System.EventHandler(this.BCClick);
            // 
            // cVerticalLine
            // 
            this.cVerticalLine.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cVerticalLine.Location = new System.Drawing.Point(204, 133);
            this.cVerticalLine.Name = "cVerticalLine";
            this.cVerticalLine.Size = new System.Drawing.Size(80, 23);
            this.cVerticalLine.TabIndex = 118;
            this.cVerticalLine.Tag = "4";
            this.cVerticalLine.Text = "FF000000";
            this.cVerticalLine.UseVisualStyleBackColor = true;
            this.cVerticalLine.Click += new System.EventHandler(this.BCClick);
            // 
            // cSub
            // 
            this.cSub.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cSub.Location = new System.Drawing.Point(204, 111);
            this.cSub.Name = "cSub";
            this.cSub.Size = new System.Drawing.Size(80, 23);
            this.cSub.TabIndex = 117;
            this.cSub.Tag = "3";
            this.cSub.Text = "FF000000";
            this.cSub.UseVisualStyleBackColor = true;
            this.cSub.Click += new System.EventHandler(this.BCClick);
            // 
            // cGrid
            // 
            this.cGrid.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cGrid.Location = new System.Drawing.Point(204, 89);
            this.cGrid.Name = "cGrid";
            this.cGrid.Size = new System.Drawing.Size(80, 23);
            this.cGrid.TabIndex = 116;
            this.cGrid.Tag = "2";
            this.cGrid.Text = "FF000000";
            this.cGrid.UseVisualStyleBackColor = true;
            this.cGrid.Click += new System.EventHandler(this.BCClick);
            // 
            // cBG
            // 
            this.cBG.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cBG.Location = new System.Drawing.Point(204, 60);
            this.cBG.Name = "cBG";
            this.cBG.Size = new System.Drawing.Size(80, 23);
            this.cBG.TabIndex = 115;
            this.cBG.Tag = "1";
            this.cBG.Text = "FF000000";
            this.cBG.UseVisualStyleBackColor = true;
            this.cBG.Click += new System.EventHandler(this.BCClick);
            // 
            // fColumnTitle
            // 
            this.fColumnTitle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.fColumnTitle.Location = new System.Drawing.Point(204, 38);
            this.fColumnTitle.Name = "fColumnTitle";
            this.fColumnTitle.Size = new System.Drawing.Size(80, 23);
            this.fColumnTitle.TabIndex = 114;
            this.fColumnTitle.Tag = "0";
            this.fColumnTitle.Text = "Tahoma";
            this.fColumnTitle.UseVisualStyleBackColor = true;
            this.fColumnTitle.Click += new System.EventHandler(this.BFClick);
            // 
            // cColumnTitle
            // 
            this.cColumnTitle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cColumnTitle.Location = new System.Drawing.Point(204, 16);
            this.cColumnTitle.Name = "cColumnTitle";
            this.cColumnTitle.Size = new System.Drawing.Size(80, 23);
            this.cColumnTitle.TabIndex = 113;
            this.cColumnTitle.Tag = "0";
            this.cColumnTitle.Text = "FF000000";
            this.cColumnTitle.UseVisualStyleBackColor = true;
            this.cColumnTitle.Click += new System.EventHandler(this.BCClick);
            // 
            // Label40
            // 
            this.Label40.Location = new System.Drawing.Point(42, 159);
            this.Label40.Name = "Label40";
            this.Label40.Size = new System.Drawing.Size(160, 15);
            this.Label40.TabIndex = 111;
            this.Label40.Text = "Measure BarLine";
            this.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label39
            // 
            this.Label39.Location = new System.Drawing.Point(315, 130);
            this.Label39.Name = "Label39";
            this.Label39.Size = new System.Drawing.Size(220, 15);
            this.Label39.TabIndex = 110;
            this.Label39.Text = "LongNote Label Horizontal Shift";
            this.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label38
            // 
            this.Label38.Location = new System.Drawing.Point(315, 108);
            this.Label38.Name = "Label38";
            this.Label38.Size = new System.Drawing.Size(220, 15);
            this.Label38.TabIndex = 109;
            this.Label38.Text = "Note Label Horizontal Shift";
            this.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label37
            // 
            this.Label37.Location = new System.Drawing.Point(42, 20);
            this.Label37.Name = "Label37";
            this.Label37.Size = new System.Drawing.Size(160, 15);
            this.Label37.TabIndex = 103;
            this.Label37.Text = "Column Caption";
            this.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label88
            // 
            this.Label88.Location = new System.Drawing.Point(648, 152);
            this.Label88.Name = "Label88";
            this.Label88.Size = new System.Drawing.Size(220, 15);
            this.Label88.TabIndex = 102;
            this.Label88.Text = "Time Selection BPM";
            this.Label88.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label35
            // 
            this.Label35.Location = new System.Drawing.Point(315, 203);
            this.Label35.Name = "Label35";
            this.Label35.Size = new System.Drawing.Size(220, 15);
            this.Label35.TabIndex = 101;
            this.Label35.Text = "Note Border on Selection";
            this.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label34
            // 
            this.Label34.Location = new System.Drawing.Point(315, 181);
            this.Label34.Name = "Label34";
            this.Label34.Size = new System.Drawing.Size(220, 15);
            this.Label34.TabIndex = 100;
            this.Label34.Text = "Note Border on MouseOver";
            this.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label86
            // 
            this.Label86.Location = new System.Drawing.Point(648, 130);
            this.Label86.Name = "Label86";
            this.Label86.Size = new System.Drawing.Size(220, 15);
            this.Label86.TabIndex = 99;
            this.Label86.Text = "Time Selection Fill";
            this.Label86.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label98
            // 
            this.Label98.Location = new System.Drawing.Point(648, 42);
            this.Label98.Name = "Label98";
            this.Label98.Size = new System.Drawing.Size(220, 15);
            this.Label98.TabIndex = 98;
            this.Label98.Text = "Time Selection Cursor";
            this.Label98.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label31
            // 
            this.Label31.Location = new System.Drawing.Point(648, 20);
            this.Label31.Name = "Label31";
            this.Label31.Size = new System.Drawing.Size(220, 15);
            this.Label31.TabIndex = 97;
            this.Label31.Text = "Selection Box Border";
            this.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label30
            // 
            this.Label30.Location = new System.Drawing.Point(42, 64);
            this.Label30.Name = "Label30";
            this.Label30.Size = new System.Drawing.Size(160, 15);
            this.Label30.TabIndex = 96;
            this.Label30.Text = "Background";
            this.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label29
            // 
            this.Label29.Location = new System.Drawing.Point(42, 137);
            this.Label29.Name = "Label29";
            this.Label29.Size = new System.Drawing.Size(160, 15);
            this.Label29.TabIndex = 95;
            this.Label29.Text = "Vertical Line";
            this.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label28
            // 
            this.Label28.Location = new System.Drawing.Point(315, 64);
            this.Label28.Name = "Label28";
            this.Label28.Size = new System.Drawing.Size(220, 15);
            this.Label28.TabIndex = 94;
            this.Label28.Text = "Measure Label";
            this.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label27
            // 
            this.Label27.Location = new System.Drawing.Point(42, 115);
            this.Label27.Name = "Label27";
            this.Label27.Size = new System.Drawing.Size(160, 15);
            this.Label27.TabIndex = 93;
            this.Label27.Text = "Sub";
            this.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label26
            // 
            this.Label26.Location = new System.Drawing.Point(42, 93);
            this.Label26.Name = "Label26";
            this.Label26.Size = new System.Drawing.Size(160, 15);
            this.Label26.TabIndex = 92;
            this.Label26.Text = "Grid";
            this.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label25
            // 
            this.Label25.Location = new System.Drawing.Point(315, 86);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(220, 15);
            this.Label25.TabIndex = 91;
            this.Label25.Text = "Note Label Vertical Shift";
            this.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label24
            // 
            this.Label24.Location = new System.Drawing.Point(315, 42);
            this.Label24.Name = "Label24";
            this.Label24.Size = new System.Drawing.Size(220, 15);
            this.Label24.TabIndex = 90;
            this.Label24.Text = "Note Label";
            this.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label22
            // 
            this.Label22.Location = new System.Drawing.Point(42, 181);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(160, 15);
            this.Label22.TabIndex = 88;
            this.Label22.Text = "BGM Waveform";
            this.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label21
            // 
            this.Label21.Location = new System.Drawing.Point(315, 20);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(220, 15);
            this.Label21.TabIndex = 87;
            this.Label21.Text = "Note Height";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label9
            // 
            this.Label9.Location = new System.Drawing.Point(42, 42);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(160, 15);
            this.Label9.TabIndex = 139;
            this.Label9.Text = "Column Caption Font";
            this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cTSSplitter
            // 
            this.cTSSplitter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cTSSplitter.Location = new System.Drawing.Point(870, 60);
            this.cTSSplitter.Name = "cTSSplitter";
            this.cTSSplitter.Size = new System.Drawing.Size(80, 23);
            this.cTSSplitter.TabIndex = 141;
            this.cTSSplitter.Tag = "9";
            this.cTSSplitter.Text = "FF000000";
            this.cTSSplitter.UseVisualStyleBackColor = true;
            this.cTSSplitter.Click += new System.EventHandler(this.BCClick);
            // 
            // Label97
            // 
            this.Label97.Location = new System.Drawing.Point(648, 64);
            this.Label97.Name = "Label97";
            this.Label97.Size = new System.Drawing.Size(220, 15);
            this.Label97.TabIndex = 140;
            this.Label97.Text = "Time Selection Splitter";
            this.Label97.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label96
            // 
            this.Label96.Location = new System.Drawing.Point(648, 86);
            this.Label96.Name = "Label96";
            this.Label96.Size = new System.Drawing.Size(220, 15);
            this.Label96.TabIndex = 142;
            this.Label96.Text = "Time Selection Cursor Sensitivity";
            this.Label96.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // iTSSensitivity
            // 
            this.iTSSensitivity.Location = new System.Drawing.Point(870, 82);
            this.iTSSensitivity.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.iTSSensitivity.Name = "iTSSensitivity";
            this.iTSSensitivity.Size = new System.Drawing.Size(80, 23);
            this.iTSSensitivity.TabIndex = 143;
            this.iTSSensitivity.Tag = "0";
            this.iTSSensitivity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cTSMouseOver
            // 
            this.cTSMouseOver.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cTSMouseOver.Location = new System.Drawing.Point(870, 104);
            this.cTSMouseOver.Name = "cTSMouseOver";
            this.cTSMouseOver.Size = new System.Drawing.Size(80, 23);
            this.cTSMouseOver.TabIndex = 145;
            this.cTSMouseOver.Tag = "9";
            this.cTSMouseOver.Text = "FF000000";
            this.cTSMouseOver.UseVisualStyleBackColor = true;
            this.cTSMouseOver.Click += new System.EventHandler(this.BCClick);
            // 
            // Label91
            // 
            this.Label91.Location = new System.Drawing.Point(648, 108);
            this.Label91.Name = "Label91";
            this.Label91.Size = new System.Drawing.Size(220, 15);
            this.Label91.TabIndex = 144;
            this.Label91.Text = "Time Selection MouseOver Border";
            this.Label91.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label82
            // 
            this.Label82.Location = new System.Drawing.Point(648, 174);
            this.Label82.Name = "Label82";
            this.Label82.Size = new System.Drawing.Size(220, 15);
            this.Label82.TabIndex = 146;
            this.Label82.Text = "Time Selection BPM Font";
            this.Label82.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label14
            // 
            this.Label14.Location = new System.Drawing.Point(648, 203);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(220, 15);
            this.Label14.TabIndex = 147;
            this.Label14.Text = "Middle Button Release Sensitivity";
            this.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // iMiddleSensitivity
            // 
            this.iMiddleSensitivity.Location = new System.Drawing.Point(870, 199);
            this.iMiddleSensitivity.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.iMiddleSensitivity.Name = "iMiddleSensitivity";
            this.iMiddleSensitivity.Size = new System.Drawing.Size(80, 23);
            this.iMiddleSensitivity.TabIndex = 148;
            this.iMiddleSensitivity.Tag = "0";
            this.iMiddleSensitivity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PictureBox1.Location = new System.Drawing.Point(10, 259);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(1000, 1);
            this.PictureBox1.TabIndex = 138;
            this.PictureBox1.TabStop = false;
            // 
            // OpVisual
            // 
            this.AcceptButton = this.OK_Button;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(1026, 713);
            this.Controls.Add(this.Label14);
            this.Controls.Add(this.iMiddleSensitivity);
            this.Controls.Add(this.Label82);
            this.Controls.Add(this.cTSMouseOver);
            this.Controls.Add(this.Label91);
            this.Controls.Add(this.Label96);
            this.Controls.Add(this.iTSSensitivity);
            this.Controls.Add(this.cTSSplitter);
            this.Controls.Add(this.Label97);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.Label33);
            this.Controls.Add(this.iHiddenNoteOpacity);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Controls.Add(this.Label23);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.cAdjustLengthBorder);
            this.Controls.Add(this.Label37);
            this.Controls.Add(this.cSelectedBorder);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.cMouseOver);
            this.Controls.Add(this.Label22);
            this.Controls.Add(this.iLongLabelHorizShift);
            this.Controls.Add(this.Label24);
            this.Controls.Add(this.iLabelHorizShift);
            this.Controls.Add(this.Label25);
            this.Controls.Add(this.iLabelVerticalShift);
            this.Controls.Add(this.Label26);
            this.Controls.Add(this.fMeasureLabel);
            this.Controls.Add(this.Label27);
            this.Controls.Add(this.fNoteLabel);
            this.Controls.Add(this.Label28);
            this.Controls.Add(this.iNoteHeight);
            this.Controls.Add(this.Label29);
            this.Controls.Add(this.fTSBPM);
            this.Controls.Add(this.Label30);
            this.Controls.Add(this.cTSBPM);
            this.Controls.Add(this.Label31);
            this.Controls.Add(this.cTSSelectionFill);
            this.Controls.Add(this.Label98);
            this.Controls.Add(this.cTSCursor);
            this.Controls.Add(this.Label86);
            this.Controls.Add(this.cSelectionBox);
            this.Controls.Add(this.Label34);
            this.Controls.Add(this.cWaveForm);
            this.Controls.Add(this.Label35);
            this.Controls.Add(this.cMeasureBarLine);
            this.Controls.Add(this.Label88);
            this.Controls.Add(this.cVerticalLine);
            this.Controls.Add(this.Label38);
            this.Controls.Add(this.cSub);
            this.Controls.Add(this.Label39);
            this.Controls.Add(this.cGrid);
            this.Controls.Add(this.Label40);
            this.Controls.Add(this.cBG);
            this.Controls.Add(this.cColumnTitle);
            this.Controls.Add(this.fColumnTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpVisual";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Visual Options";
            this.TableLayoutPanel1.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iHiddenNoteOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iLongLabelHorizShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iLabelHorizShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iLabelVerticalShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNoteHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTSSensitivity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMiddleSensitivity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);

    }

internal TableLayoutPanel TableLayoutPanel1;
internal Button OK_Button;
internal Button Cancel_Button;
internal Panel Panel1;
internal Label Label39;
internal Label Label38;
internal Label Label37;
internal Label Label88;
internal Label Label35;
internal Label Label34;
internal Label Label86;
internal Label Label98;
internal Label Label31;
internal Label Label30;
internal Label Label29;
internal Label Label28;
internal Label Label27;
internal Label Label26;
internal Label Label25;
internal Label Label24;
internal Label Label22;
internal Label Label21;
internal Label Label40;
internal Button cColumnTitle;
internal Button fColumnTitle;
internal Button cBG;
internal Button fTSBPM;
internal Button cTSBPM;
internal Button cTSSelectionFill;
internal Button cTSCursor;
internal Button cSelectionBox;
internal Button cWaveForm;
internal Button cMeasureBarLine;
internal Button cVerticalLine;
internal Button cSub;
internal Button cGrid;
internal Button fNoteLabel;
internal NumericUpDown iNoteHeight;
internal Button fMeasureLabel;
internal NumericUpDown iLongLabelHorizShift;
internal NumericUpDown iLabelHorizShift;
internal NumericUpDown iLabelVerticalShift;
internal Button cSelectedBorder;
internal Button cMouseOver;
internal Label Label23;
internal Button cAdjustLengthBorder;
internal Label Label1;
internal Label Label8;
internal Label Label7;
internal Label Label2;
internal Label Label6;
internal Label Label4;
internal Label Label5;
internal Label Label33;
internal NumericUpDown iHiddenNoteOpacity;
internal PictureBox PictureBox1;
internal Label Label9;
internal Button cTSSplitter;
internal Label Label97;
internal Label Label96;
internal NumericUpDown iTSSensitivity;
internal Button cTSMouseOver;
internal Label Label91;
internal Label Label82;
internal Label Label14;
internal NumericUpDown iMiddleSensitivity;
    }
}
