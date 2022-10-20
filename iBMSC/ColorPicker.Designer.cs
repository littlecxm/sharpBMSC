using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace iBMSC
{
    public partial class ColorPicker : Form
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
            this.OK_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.PCMain = new System.Windows.Forms.Panel();
            this.tbPrecision = new System.Windows.Forms.TrackBar();
            this.PCA = new System.Windows.Forms.Panel();
            this.PC1 = new System.Windows.Forms.Panel();
            this.rbH = new System.Windows.Forms.RadioButton();
            this.rbS = new System.Windows.Forms.RadioButton();
            this.rbL = new System.Windows.Forms.RadioButton();
            this.rbR = new System.Windows.Forms.RadioButton();
            this.rbG = new System.Windows.Forms.RadioButton();
            this.rbB = new System.Windows.Forms.RadioButton();
            this.inH = new System.Windows.Forms.NumericUpDown();
            this.inS = new System.Windows.Forms.NumericUpDown();
            this.inL = new System.Windows.Forms.NumericUpDown();
            this.inR = new System.Windows.Forms.NumericUpDown();
            this.inG = new System.Windows.Forms.NumericUpDown();
            this.inB = new System.Windows.Forms.NumericUpDown();
            this.Label1 = new System.Windows.Forms.Label();
            this.tStr = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.inA = new System.Windows.Forms.NumericUpDown();
            this.rbA = new System.Windows.Forms.RadioButton();
            this.pPrev = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.tbPrecision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inA)).BeginInit();
            this.SuspendLayout();
            // 
            // OK_Button
            // 
            this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OK_Button.Location = new System.Drawing.Point(315, 275);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(126, 27);
            this.OK_Button.TabIndex = 21;
            this.OK_Button.Text = "OK";
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Location = new System.Drawing.Point(315, 306);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(126, 27);
            this.Cancel_Button.TabIndex = 22;
            this.Cancel_Button.Text = "Cancel";
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // PCMain
            // 
            this.PCMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PCMain.Location = new System.Drawing.Point(14, 14);
            this.PCMain.Name = "PCMain";
            this.PCMain.Size = new System.Drawing.Size(258, 258);
            this.PCMain.TabIndex = 1;
            this.PCMain.Paint += new System.Windows.Forms.PaintEventHandler(this.PCMain_Paint);
            this.PCMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PCMain_MouseDown);
            this.PCMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PCMain_MouseMove);
            // 
            // tbPrecision
            // 
            this.tbPrecision.LargeChange = 2;
            this.tbPrecision.Location = new System.Drawing.Point(73, 303);
            this.tbPrecision.Minimum = 1;
            this.tbPrecision.Name = "tbPrecision";
            this.tbPrecision.Size = new System.Drawing.Size(199, 45);
            this.tbPrecision.TabIndex = 2;
            this.tbPrecision.Value = 2;
            this.tbPrecision.ValueChanged += new System.EventHandler(this.tbPrecision_ValueChanged);
            // 
            // PCA
            // 
            this.PCA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PCA.Location = new System.Drawing.Point(14, 278);
            this.PCA.Name = "PCA";
            this.PCA.Size = new System.Drawing.Size(258, 19);
            this.PCA.TabIndex = 3;
            this.PCA.Paint += new System.Windows.Forms.PaintEventHandler(this.PCA_Paint);
            this.PCA.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PCA_MouseDown);
            this.PCA.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PCA_MouseMove);
            // 
            // PC1
            // 
            this.PC1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PC1.Location = new System.Drawing.Point(278, 14);
            this.PC1.Name = "PC1";
            this.PC1.Size = new System.Drawing.Size(19, 258);
            this.PC1.TabIndex = 4;
            this.PC1.Paint += new System.Windows.Forms.PaintEventHandler(this.PC1_Paint);
            this.PC1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PC1_MouseDown);
            this.PC1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PC1_MouseMove);
            // 
            // rbH
            // 
            this.rbH.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbH.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbH.Location = new System.Drawing.Point(315, 55);
            this.rbH.Name = "rbH";
            this.rbH.Size = new System.Drawing.Size(77, 23);
            this.rbH.TabIndex = 7;
            this.rbH.Text = "H (0-359)";
            this.rbH.UseVisualStyleBackColor = true;
            this.rbH.CheckedChanged += new System.EventHandler(this.rbH_CheckedChanged);
            // 
            // rbS
            // 
            this.rbS.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbS.Checked = true;
            this.rbS.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbS.Location = new System.Drawing.Point(315, 80);
            this.rbS.Name = "rbS";
            this.rbS.Size = new System.Drawing.Size(77, 23);
            this.rbS.TabIndex = 8;
            this.rbS.TabStop = true;
            this.rbS.Text = "S (0-1000)";
            this.rbS.UseVisualStyleBackColor = true;
            this.rbS.CheckedChanged += new System.EventHandler(this.rbS_CheckedChanged);
            // 
            // rbL
            // 
            this.rbL.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbL.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbL.Location = new System.Drawing.Point(315, 105);
            this.rbL.Name = "rbL";
            this.rbL.Size = new System.Drawing.Size(77, 23);
            this.rbL.TabIndex = 9;
            this.rbL.Text = "L (0-1000)";
            this.rbL.UseVisualStyleBackColor = true;
            this.rbL.CheckedChanged += new System.EventHandler(this.rbL_CheckedChanged);
            // 
            // rbR
            // 
            this.rbR.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbR.Location = new System.Drawing.Point(315, 134);
            this.rbR.Name = "rbR";
            this.rbR.Size = new System.Drawing.Size(77, 23);
            this.rbR.TabIndex = 10;
            this.rbR.Text = "R (0-255)";
            this.rbR.UseVisualStyleBackColor = true;
            this.rbR.CheckedChanged += new System.EventHandler(this.rbR_CheckedChanged);
            // 
            // rbG
            // 
            this.rbG.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbG.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbG.Location = new System.Drawing.Point(315, 159);
            this.rbG.Name = "rbG";
            this.rbG.Size = new System.Drawing.Size(77, 23);
            this.rbG.TabIndex = 11;
            this.rbG.Text = "G (0-255)";
            this.rbG.UseVisualStyleBackColor = true;
            this.rbG.CheckedChanged += new System.EventHandler(this.rbG_CheckedChanged);
            // 
            // rbB
            // 
            this.rbB.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbB.Location = new System.Drawing.Point(315, 184);
            this.rbB.Name = "rbB";
            this.rbB.Size = new System.Drawing.Size(77, 23);
            this.rbB.TabIndex = 12;
            this.rbB.Text = "B (0-255)";
            this.rbB.UseVisualStyleBackColor = true;
            this.rbB.CheckedChanged += new System.EventHandler(this.rbB_CheckedChanged);
            // 
            // inH
            // 
            this.inH.Location = new System.Drawing.Point(396, 55);
            this.inH.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.inH.Name = "inH";
            this.inH.Size = new System.Drawing.Size(45, 23);
            this.inH.TabIndex = 14;
            this.inH.ValueChanged += new System.EventHandler(this.inH_ValueChanged);
            // 
            // inS
            // 
            this.inS.Location = new System.Drawing.Point(396, 80);
            this.inS.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.inS.Name = "inS";
            this.inS.Size = new System.Drawing.Size(45, 23);
            this.inS.TabIndex = 15;
            this.inS.ValueChanged += new System.EventHandler(this.inS_ValueChanged);
            // 
            // inL
            // 
            this.inL.Location = new System.Drawing.Point(396, 105);
            this.inL.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.inL.Name = "inL";
            this.inL.Size = new System.Drawing.Size(45, 23);
            this.inL.TabIndex = 16;
            this.inL.ValueChanged += new System.EventHandler(this.inL_ValueChanged);
            // 
            // inR
            // 
            this.inR.Location = new System.Drawing.Point(396, 134);
            this.inR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.inR.Name = "inR";
            this.inR.Size = new System.Drawing.Size(45, 23);
            this.inR.TabIndex = 17;
            this.inR.ValueChanged += new System.EventHandler(this.inR_ValueChanged);
            // 
            // inG
            // 
            this.inG.Location = new System.Drawing.Point(396, 159);
            this.inG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.inG.Name = "inG";
            this.inG.Size = new System.Drawing.Size(45, 23);
            this.inG.TabIndex = 18;
            this.inG.ValueChanged += new System.EventHandler(this.inG_ValueChanged);
            // 
            // inB
            // 
            this.inB.Location = new System.Drawing.Point(396, 184);
            this.inB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.inB.Name = "inB";
            this.inB.Size = new System.Drawing.Size(45, 23);
            this.inB.TabIndex = 19;
            this.inB.ValueChanged += new System.EventHandler(this.inB_ValueChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(16, 305);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(58, 15);
            this.Label1.TabIndex = 99;
            this.Label1.Text = "Precision:";
            // 
            // tStr
            // 
            this.tStr.Location = new System.Drawing.Point(340, 245);
            this.tStr.Name = "tStr";
            this.tStr.Size = new System.Drawing.Size(89, 23);
            this.tStr.TabIndex = 0;
            this.tStr.Text = "FF000000";
            this.tStr.TextChanged += new System.EventHandler(this.tStr_TextChanged);
            this.tStr.GotFocus += new System.EventHandler(this.tStr_GotFocus);
            this.tStr.LostFocus += new System.EventHandler(this.tStr_LostFocus);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(320, 248);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(14, 15);
            this.Label2.TabIndex = 21;
            this.Label2.Text = "#";
            // 
            // inA
            // 
            this.inA.Location = new System.Drawing.Point(396, 213);
            this.inA.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.inA.Name = "inA";
            this.inA.Size = new System.Drawing.Size(45, 23);
            this.inA.TabIndex = 20;
            this.inA.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.inA.ValueChanged += new System.EventHandler(this.inA_ValueChanged);
            // 
            // rbA
            // 
            this.rbA.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbA.Enabled = false;
            this.rbA.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbA.Location = new System.Drawing.Point(315, 213);
            this.rbA.Name = "rbA";
            this.rbA.Size = new System.Drawing.Size(77, 23);
            this.rbA.TabIndex = 13;
            this.rbA.Text = "A (0-255)";
            this.rbA.UseVisualStyleBackColor = true;
            // 
            // pPrev
            // 
            this.pPrev.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pPrev.Location = new System.Drawing.Point(315, 14);
            this.pPrev.Name = "pPrev";
            this.pPrev.Size = new System.Drawing.Size(125, 30);
            this.pPrev.TabIndex = 25;
            this.pPrev.Paint += new System.Windows.Forms.PaintEventHandler(this.pPrev_Paint);
            // 
            // ColorPicker
            // 
            this.AcceptButton = this.OK_Button;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(453, 345);
            this.Controls.Add(this.inA);
            this.Controls.Add(this.rbA);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.tStr);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.OK_Button);
            this.Controls.Add(this.inB);
            this.Controls.Add(this.inG);
            this.Controls.Add(this.inR);
            this.Controls.Add(this.inL);
            this.Controls.Add(this.inS);
            this.Controls.Add(this.inH);
            this.Controls.Add(this.rbB);
            this.Controls.Add(this.rbG);
            this.Controls.Add(this.rbR);
            this.Controls.Add(this.rbL);
            this.Controls.Add(this.rbS);
            this.Controls.Add(this.rbH);
            this.Controls.Add(this.PC1);
            this.Controls.Add(this.PCA);
            this.Controls.Add(this.tbPrecision);
            this.Controls.Add(this.PCMain);
            this.Controls.Add(this.pPrev);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColorPicker";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ColorPicker";
            ((System.ComponentModel.ISupportInitialize)(this.tbPrecision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

internal Button OK_Button;
internal Button Cancel_Button;
internal Panel PCMain;
internal TrackBar tbPrecision;
internal Panel PCA;
internal Panel PC1;
internal RadioButton rbH;
internal RadioButton rbS;
internal RadioButton rbL;
internal RadioButton rbR;
internal RadioButton rbG;
internal RadioButton rbB;
internal NumericUpDown inH;
internal NumericUpDown inS;
internal NumericUpDown inL;
internal NumericUpDown inR;
internal NumericUpDown inG;
internal NumericUpDown inB;
internal Label Label1;
internal TextBox tStr;
internal Label Label2;
internal NumericUpDown inA;
internal RadioButton rbA;
internal Panel pPrev;
    }
}
