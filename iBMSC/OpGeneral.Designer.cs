using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace iBMSC
{
    public partial class OpGeneral : Form
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
            this.CWheel = new System.Windows.Forms.ComboBox();
            this.CTextEncoding = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.TBAssociate = new System.Windows.Forms.Button();
            this.cBeep = new System.Windows.Forms.CheckBox();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.cBpm1296 = new System.Windows.Forms.CheckBox();
            this.cStop1296 = new System.Windows.Forms.CheckBox();
            this.cMEnterFocus = new System.Windows.Forms.CheckBox();
            this.cMClickFocus = new System.Windows.Forms.CheckBox();
            this.TBAssociatePMS = new System.Windows.Forms.Button();
            this.TBAssociateIBMSC = new System.Windows.Forms.Button();
            this.Label5 = new System.Windows.Forms.Label();
            this.CPgUpDn = new System.Windows.Forms.ComboBox();
            this.NAutoSave = new System.Windows.Forms.NumericUpDown();
            this.Label7 = new System.Windows.Forms.Label();
            this.cAutoSave = new System.Windows.Forms.CheckBox();
            this.cMStopPreview = new System.Windows.Forms.CheckBox();
            this.nGridPartition = new System.Windows.Forms.NumericUpDown();
            this.Label6 = new System.Windows.Forms.Label();
            this.TBAssociateBME = new System.Windows.Forms.Button();
            this.TBAssociateBML = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.FlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.rMiddleAuto = new System.Windows.Forms.RadioButton();
            this.rMiddleDrag = new System.Windows.Forms.RadioButton();
            this.TableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NAutoSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGridPartition)).BeginInit();
            this.FlowLayoutPanel1.SuspendLayout();
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
            this.TableLayoutPanel1.Location = new System.Drawing.Point(229, 463);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(170, 33);
            this.TableLayoutPanel1.TabIndex = 0;
            // 
            // OK_Button
            // 
            this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OK_Button.Location = new System.Drawing.Point(3, 3);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(78, 27);
            this.OK_Button.TabIndex = 0;
            this.OK_Button.Text = "OK";
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Location = new System.Drawing.Point(88, 3);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(78, 27);
            this.Cancel_Button.TabIndex = 1;
            this.Cancel_Button.Text = "Cancel";
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // CWheel
            // 
            this.CWheel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CWheel.FormattingEnabled = true;
            this.CWheel.Items.AddRange(new object[] {
            "1",
            "1 / 2",
            "1 / 3",
            "1 / 4"});
            this.CWheel.Location = new System.Drawing.Point(154, 269);
            this.CWheel.Name = "CWheel";
            this.CWheel.Size = new System.Drawing.Size(237, 23);
            this.CWheel.TabIndex = 11;
            // 
            // CTextEncoding
            // 
            this.CTextEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CTextEncoding.FormattingEnabled = true;
            this.CTextEncoding.Items.AddRange(new object[] {
            "ANSI (Locale dependant)",
            "Little Endian UTF16",
            "ASCII",
            "Big Endian UTF16",
            "Little Endian UTF32",
            "UTF7",
            "UTF8",
            "Shift-JIS",
            "EUC-KR"});
            this.CTextEncoding.Location = new System.Drawing.Point(137, 18);
            this.CTextEncoding.Name = "CTextEncoding";
            this.CTextEncoding.Size = new System.Drawing.Size(254, 23);
            this.CTextEncoding.TabIndex = 2;
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(12, 271);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(136, 17);
            this.Label1.TabIndex = 40;
            this.Label1.Text = "Mouse Wheel";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(-5, 20);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(136, 17);
            this.Label2.TabIndex = 41;
            this.Label2.Text = "Text Encoding";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(-5, 50);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(136, 17);
            this.Label4.TabIndex = 43;
            this.Label4.Text = "Associate Filetype";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TBAssociate
            // 
            this.TBAssociate.Location = new System.Drawing.Point(137, 47);
            this.TBAssociate.Name = "TBAssociate";
            this.TBAssociate.Size = new System.Drawing.Size(122, 23);
            this.TBAssociate.TabIndex = 3;
            this.TBAssociate.Text = "*.bms";
            this.TBAssociate.UseVisualStyleBackColor = true;
            this.TBAssociate.Click += new System.EventHandler(this.TBAssociate_Click);
            // 
            // cBeep
            // 
            this.cBeep.AutoSize = true;
            this.cBeep.Checked = true;
            this.cBeep.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBeep.Location = new System.Drawing.Point(32, 169);
            this.cBeep.Name = "cBeep";
            this.cBeep.Size = new System.Drawing.Size(116, 19);
            this.cBeep.TabIndex = 8;
            this.cBeep.Text = "Beep while saved";
            this.cBeep.UseVisualStyleBackColor = true;
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PictureBox1.Location = new System.Drawing.Point(20, 253);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(375, 1);
            this.PictureBox1.TabIndex = 47;
            this.PictureBox1.TabStop = false;
            // 
            // cBpm1296
            // 
            this.cBpm1296.AutoSize = true;
            this.cBpm1296.Location = new System.Drawing.Point(32, 194);
            this.cBpm1296.Name = "cBpm1296";
            this.cBpm1296.Size = new System.Drawing.Size(254, 19);
            this.cBpm1296.TabIndex = 9;
            this.cBpm1296.Text = "Extend number of multi-byte BPMs to 1296";
            this.cBpm1296.UseVisualStyleBackColor = true;
            // 
            // cStop1296
            // 
            this.cStop1296.AutoSize = true;
            this.cStop1296.Location = new System.Drawing.Point(32, 219);
            this.cStop1296.Name = "cStop1296";
            this.cStop1296.Size = new System.Drawing.Size(197, 19);
            this.cStop1296.TabIndex = 10;
            this.cStop1296.Text = "Extend number of STOPs to 1296";
            this.cStop1296.UseVisualStyleBackColor = true;
            // 
            // cMEnterFocus
            // 
            this.cMEnterFocus.AutoSize = true;
            this.cMEnterFocus.Location = new System.Drawing.Point(34, 379);
            this.cMEnterFocus.Name = "cMEnterFocus";
            this.cMEnterFocus.Size = new System.Drawing.Size(322, 19);
            this.cMEnterFocus.TabIndex = 14;
            this.cMEnterFocus.Text = "Automatically set focus to editing panel on mouse enter";
            this.cMEnterFocus.UseVisualStyleBackColor = true;
            // 
            // cMClickFocus
            // 
            this.cMClickFocus.AutoSize = true;
            this.cMClickFocus.Location = new System.Drawing.Point(34, 404);
            this.cMClickFocus.Name = "cMClickFocus";
            this.cMClickFocus.Size = new System.Drawing.Size(293, 19);
            this.cMClickFocus.TabIndex = 15;
            this.cMClickFocus.Text = "Disable first click if the editing panel is not focused";
            this.cMClickFocus.UseVisualStyleBackColor = true;
            // 
            // TBAssociatePMS
            // 
            this.TBAssociatePMS.Location = new System.Drawing.Point(310, 78);
            this.TBAssociatePMS.Name = "TBAssociatePMS";
            this.TBAssociatePMS.Size = new System.Drawing.Size(81, 23);
            this.TBAssociatePMS.TabIndex = 4;
            this.TBAssociatePMS.Text = "*.pms";
            this.TBAssociatePMS.UseVisualStyleBackColor = true;
            this.TBAssociatePMS.Click += new System.EventHandler(this.TBAssociatePMS_Click);
            // 
            // TBAssociateIBMSC
            // 
            this.TBAssociateIBMSC.Location = new System.Drawing.Point(265, 47);
            this.TBAssociateIBMSC.Name = "TBAssociateIBMSC";
            this.TBAssociateIBMSC.Size = new System.Drawing.Size(127, 23);
            this.TBAssociateIBMSC.TabIndex = 5;
            this.TBAssociateIBMSC.Text = "*.ibmsc";
            this.TBAssociateIBMSC.UseVisualStyleBackColor = true;
            this.TBAssociateIBMSC.Click += new System.EventHandler(this.TBAssociateIBMSC_Click);
            // 
            // Label5
            // 
            this.Label5.Location = new System.Drawing.Point(12, 300);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(136, 17);
            this.Label5.TabIndex = 56;
            this.Label5.Text = "PageUp / PageDown";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CPgUpDn
            // 
            this.CPgUpDn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CPgUpDn.FormattingEnabled = true;
            this.CPgUpDn.Items.AddRange(new object[] {
            "8",
            "6",
            "4",
            "3",
            "2",
            "1",
            "1 / 2"});
            this.CPgUpDn.Location = new System.Drawing.Point(154, 298);
            this.CPgUpDn.Name = "CPgUpDn";
            this.CPgUpDn.Size = new System.Drawing.Size(237, 23);
            this.CPgUpDn.TabIndex = 12;
            // 
            // NAutoSave
            // 
            this.NAutoSave.DecimalPlaces = 1;
            this.NAutoSave.Location = new System.Drawing.Point(171, 142);
            this.NAutoSave.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.NAutoSave.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NAutoSave.Name = "NAutoSave";
            this.NAutoSave.Size = new System.Drawing.Size(62, 23);
            this.NAutoSave.TabIndex = 7;
            this.NAutoSave.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // Label7
            // 
            this.Label7.Location = new System.Drawing.Point(239, 144);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(73, 17);
            this.Label7.TabIndex = 59;
            this.Label7.Text = "minutes";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cAutoSave
            // 
            this.cAutoSave.AutoSize = true;
            this.cAutoSave.Checked = true;
            this.cAutoSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cAutoSave.Location = new System.Drawing.Point(32, 144);
            this.cAutoSave.Name = "cAutoSave";
            this.cAutoSave.Size = new System.Drawing.Size(76, 19);
            this.cAutoSave.TabIndex = 6;
            this.cAutoSave.Text = "AutoSave";
            this.cAutoSave.UseVisualStyleBackColor = true;
            this.cAutoSave.CheckedChanged += new System.EventHandler(this.cAutoSave_CheckedChanged);
            // 
            // cMStopPreview
            // 
            this.cMStopPreview.AutoSize = true;
            this.cMStopPreview.Checked = true;
            this.cMStopPreview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cMStopPreview.Location = new System.Drawing.Point(34, 429);
            this.cMStopPreview.Name = "cMStopPreview";
            this.cMStopPreview.Size = new System.Drawing.Size(253, 19);
            this.cMStopPreview.TabIndex = 60;
            this.cMStopPreview.Text = "Stop preview if clicked on the editing panel";
            this.cMStopPreview.UseVisualStyleBackColor = true;
            // 
            // nGridPartition
            // 
            this.nGridPartition.Location = new System.Drawing.Point(219, 107);
            this.nGridPartition.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nGridPartition.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nGridPartition.Name = "nGridPartition";
            this.nGridPartition.Size = new System.Drawing.Size(79, 23);
            this.nGridPartition.TabIndex = 61;
            this.nGridPartition.Value = new decimal(new int[] {
            192,
            0,
            0,
            0});
            // 
            // Label6
            // 
            this.Label6.Location = new System.Drawing.Point(44, 108);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(169, 17);
            this.Label6.TabIndex = 62;
            this.Label6.Text = "Max Grid Partition in BMS";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TBAssociateBME
            // 
            this.TBAssociateBME.Location = new System.Drawing.Point(137, 78);
            this.TBAssociateBME.Name = "TBAssociateBME";
            this.TBAssociateBME.Size = new System.Drawing.Size(76, 23);
            this.TBAssociateBME.TabIndex = 63;
            this.TBAssociateBME.Text = "*.bme";
            this.TBAssociateBME.UseVisualStyleBackColor = true;
            this.TBAssociateBME.Click += new System.EventHandler(this.TBAssociateBME_Click);
            // 
            // TBAssociateBML
            // 
            this.TBAssociateBML.Location = new System.Drawing.Point(219, 78);
            this.TBAssociateBML.Name = "TBAssociateBML";
            this.TBAssociateBML.Size = new System.Drawing.Size(85, 23);
            this.TBAssociateBML.TabIndex = 64;
            this.TBAssociateBML.Text = "*.bml";
            this.TBAssociateBML.UseVisualStyleBackColor = true;
            this.TBAssociateBML.Click += new System.EventHandler(this.TBAssociateBML_Click);
            // 
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(12, 328);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(136, 17);
            this.Label3.TabIndex = 65;
            this.Label3.Text = "Mouse Middle Button";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FlowLayoutPanel1
            // 
            this.FlowLayoutPanel1.AutoSize = true;
            this.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FlowLayoutPanel1.Controls.Add(this.rMiddleAuto);
            this.FlowLayoutPanel1.Controls.Add(this.rMiddleDrag);
            this.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FlowLayoutPanel1.Location = new System.Drawing.Point(154, 327);
            this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            this.FlowLayoutPanel1.Size = new System.Drawing.Size(141, 38);
            this.FlowLayoutPanel1.TabIndex = 66;
            // 
            // rMiddleAuto
            // 
            this.rMiddleAuto.AutoSize = true;
            this.rMiddleAuto.Checked = true;
            this.rMiddleAuto.Location = new System.Drawing.Point(3, 0);
            this.rMiddleAuto.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.rMiddleAuto.Name = "rMiddleAuto";
            this.rMiddleAuto.Size = new System.Drawing.Size(135, 19);
            this.rMiddleAuto.TabIndex = 0;
            this.rMiddleAuto.TabStop = true;
            this.rMiddleAuto.Text = "Click and Auto Scroll";
            this.rMiddleAuto.UseVisualStyleBackColor = true;
            // 
            // rMiddleDrag
            // 
            this.rMiddleDrag.AutoSize = true;
            this.rMiddleDrag.Location = new System.Drawing.Point(3, 19);
            this.rMiddleDrag.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.rMiddleDrag.Name = "rMiddleDrag";
            this.rMiddleDrag.Size = new System.Drawing.Size(102, 19);
            this.rMiddleDrag.TabIndex = 1;
            this.rMiddleDrag.TabStop = true;
            this.rMiddleDrag.Text = "Click and Drag";
            this.rMiddleDrag.UseVisualStyleBackColor = true;
            // 
            // OpGeneral
            // 
            this.AcceptButton = this.OK_Button;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(413, 510);
            this.Controls.Add(this.FlowLayoutPanel1);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.TBAssociateBML);
            this.Controls.Add(this.TBAssociateBME);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.nGridPartition);
            this.Controls.Add(this.cMStopPreview);
            this.Controls.Add(this.cAutoSave);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.NAutoSave);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.CPgUpDn);
            this.Controls.Add(this.TBAssociateIBMSC);
            this.Controls.Add(this.TBAssociatePMS);
            this.Controls.Add(this.cMClickFocus);
            this.Controls.Add(this.cMEnterFocus);
            this.Controls.Add(this.cStop1296);
            this.Controls.Add(this.cBpm1296);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.cBeep);
            this.Controls.Add(this.TBAssociate);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.CTextEncoding);
            this.Controls.Add(this.CWheel);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpGeneral";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "General Settings";
            this.TableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NAutoSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGridPartition)).EndInit();
            this.FlowLayoutPanel1.ResumeLayout(false);
            this.FlowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

internal TableLayoutPanel TableLayoutPanel1;
internal Button OK_Button;
internal Button Cancel_Button;
internal ComboBox CWheel;
internal ComboBox CTextEncoding;
internal Label Label1;
internal Label Label2;
internal Label Label4;
internal Button TBAssociate;
internal CheckBox cBeep;
internal PictureBox PictureBox1;
internal CheckBox cBpm1296;
internal CheckBox cStop1296;
internal CheckBox cMEnterFocus;
internal CheckBox cMClickFocus;
internal Button TBAssociatePMS;
internal Button TBAssociateIBMSC;
internal Label Label5;
internal ComboBox CPgUpDn;
internal NumericUpDown NAutoSave;
internal Label Label7;
internal CheckBox cAutoSave;
internal CheckBox cMStopPreview;
internal NumericUpDown nGridPartition;
internal Label Label6;
internal Button TBAssociateBME;
internal Button TBAssociateBML;
internal Label Label3;
internal FlowLayoutPanel FlowLayoutPanel1;
internal RadioButton rMiddleAuto;
internal RadioButton rMiddleDrag;
    }
}
