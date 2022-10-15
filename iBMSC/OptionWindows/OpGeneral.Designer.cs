using System.Diagnostics;
namespace iBMSC
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class OpGeneral : System.Windows.Forms.Form
    {
        public OpGeneral()
        {
            InitializeComponent();
        }

        // Form 重写 Dispose，以清理组件列表。
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is not null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Windows 窗体设计器所必需的
        private System.ComponentModel.IContainer components;

        // 注意: 以下过程是 Windows 窗体设计器所必需的
        // 可以使用 Windows 窗体设计器修改它。
        // 不要使用代码编辑器修改它。
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            OK_Button = new System.Windows.Forms.Button();
            Cancel_Button = new System.Windows.Forms.Button();
            CWheel = new System.Windows.Forms.ComboBox();
            CTextEncoding = new System.Windows.Forms.ComboBox();
            Label1 = new System.Windows.Forms.Label();
            Label2 = new System.Windows.Forms.Label();
            Label4 = new System.Windows.Forms.Label();
            TBAssociate = new System.Windows.Forms.Button();
            cBeep = new System.Windows.Forms.CheckBox();
            PictureBox1 = new System.Windows.Forms.PictureBox();
            cBpm1296 = new System.Windows.Forms.CheckBox();
            cStop1296 = new System.Windows.Forms.CheckBox();
            cMEnterFocus = new System.Windows.Forms.CheckBox();
            cMClickFocus = new System.Windows.Forms.CheckBox();
            TBAssociatePMS = new System.Windows.Forms.Button();
            TBAssociateIBMSC = new System.Windows.Forms.Button();
            Label5 = new System.Windows.Forms.Label();
            CPgUpDn = new System.Windows.Forms.ComboBox();
            NAutoSave = new System.Windows.Forms.NumericUpDown();
            Label7 = new System.Windows.Forms.Label();
            cAutoSave = new System.Windows.Forms.CheckBox();
            cMStopPreview = new System.Windows.Forms.CheckBox();
            nGridPartition = new System.Windows.Forms.NumericUpDown();
            Label6 = new System.Windows.Forms.Label();
            TBAssociateBME = new System.Windows.Forms.Button();
            TBAssociateBML = new System.Windows.Forms.Button();
            Label3 = new System.Windows.Forms.Label();
            FlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            rMiddleAuto = new System.Windows.Forms.RadioButton();
            rMiddleDrag = new System.Windows.Forms.RadioButton();
            TableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NAutoSave).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nGridPartition).BeginInit();
            FlowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            TableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            TableLayoutPanel1.ColumnCount = 2;
            TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0f));
            TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0f));
            TableLayoutPanel1.Controls.Add(OK_Button, 0, 0);
            TableLayoutPanel1.Controls.Add(Cancel_Button, 1, 0);
            TableLayoutPanel1.Location = new System.Drawing.Point(229, 463);
            TableLayoutPanel1.Name = "TableLayoutPanel1";
            TableLayoutPanel1.RowCount = 1;
            TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0f));
            TableLayoutPanel1.Size = new System.Drawing.Size(170, 33);
            TableLayoutPanel1.TabIndex = 0;
            // 
            // OK_Button
            // 
            OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            OK_Button.Location = new System.Drawing.Point(3, 3);
            OK_Button.Name = "OK_Button";
            OK_Button.Size = new System.Drawing.Size(78, 27);
            OK_Button.TabIndex = 0;
            OK_Button.Text = "OK";
            // 
            // Cancel_Button
            // 
            Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Cancel_Button.Location = new System.Drawing.Point(88, 3);
            Cancel_Button.Name = "Cancel_Button";
            Cancel_Button.Size = new System.Drawing.Size(78, 27);
            Cancel_Button.TabIndex = 1;
            Cancel_Button.Text = "Cancel";
            // 
            // CWheel
            // 
            CWheel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CWheel.FormattingEnabled = true;
            CWheel.Items.AddRange(new object[] { "1", "1 / 2", "1 / 3", "1 / 4" });
            CWheel.Location = new System.Drawing.Point(154, 269);
            CWheel.Name = "CWheel";
            CWheel.Size = new System.Drawing.Size(237, 23);
            CWheel.TabIndex = 11;
            // 
            // CTextEncoding
            // 
            CTextEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CTextEncoding.FormattingEnabled = true;
            CTextEncoding.Items.AddRange(new object[] { "ANSI (Locale dependant)", "Little Endian UTF16", "ASCII", "Big Endian UTF16", "Little Endian UTF32", "UTF7", "UTF8", "Shift-JIS", "EUC-KR" });
            CTextEncoding.Location = new System.Drawing.Point(137, 18);
            CTextEncoding.Name = "CTextEncoding";
            CTextEncoding.Size = new System.Drawing.Size(254, 23);
            CTextEncoding.TabIndex = 2;
            // 
            // Label1
            // 
            Label1.Location = new System.Drawing.Point(12, 271);
            Label1.Name = "Label1";
            Label1.Size = new System.Drawing.Size(136, 17);
            Label1.TabIndex = 40;
            Label1.Text = "Mouse Wheel";
            Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label2
            // 
            Label2.Location = new System.Drawing.Point(-5, 20);
            Label2.Name = "Label2";
            Label2.Size = new System.Drawing.Size(136, 17);
            Label2.TabIndex = 41;
            Label2.Text = "Text Encoding";
            Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label4
            // 
            Label4.Location = new System.Drawing.Point(-5, 50);
            Label4.Name = "Label4";
            Label4.Size = new System.Drawing.Size(136, 17);
            Label4.TabIndex = 43;
            Label4.Text = "Associate Filetype";
            Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TBAssociate
            // 
            TBAssociate.Location = new System.Drawing.Point(137, 47);
            TBAssociate.Name = "TBAssociate";
            TBAssociate.Size = new System.Drawing.Size(122, 23);
            TBAssociate.TabIndex = 3;
            TBAssociate.Text = "*.bms";
            TBAssociate.UseVisualStyleBackColor = true;
            // 
            // cBeep
            // 
            cBeep.AutoSize = true;
            cBeep.Checked = true;
            cBeep.CheckState = System.Windows.Forms.CheckState.Checked;
            cBeep.Location = new System.Drawing.Point(32, 169);
            cBeep.Name = "cBeep";
            cBeep.Size = new System.Drawing.Size(116, 19);
            cBeep.TabIndex = 8;
            cBeep.Text = "Beep while saved";
            cBeep.UseVisualStyleBackColor = true;
            // 
            // PictureBox1
            // 
            PictureBox1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            PictureBox1.Location = new System.Drawing.Point(20, 253);
            PictureBox1.Name = "PictureBox1";
            PictureBox1.Size = new System.Drawing.Size(375, 1);
            PictureBox1.TabIndex = 47;
            PictureBox1.TabStop = false;
            // 
            // cBpm1296
            // 
            cBpm1296.AutoSize = true;
            cBpm1296.Location = new System.Drawing.Point(32, 194);
            cBpm1296.Name = "cBpm1296";
            cBpm1296.Size = new System.Drawing.Size(253, 19);
            cBpm1296.TabIndex = 9;
            cBpm1296.Text = "Extend number of multi-byte BPMs to 1296";
            cBpm1296.UseVisualStyleBackColor = true;
            // 
            // cStop1296
            // 
            cStop1296.AutoSize = true;
            cStop1296.Location = new System.Drawing.Point(32, 219);
            cStop1296.Name = "cStop1296";
            cStop1296.Size = new System.Drawing.Size(198, 19);
            cStop1296.TabIndex = 10;
            cStop1296.Text = "Extend number of STOPs to 1296";
            cStop1296.UseVisualStyleBackColor = true;
            // 
            // cMEnterFocus
            // 
            cMEnterFocus.AutoSize = true;
            cMEnterFocus.Location = new System.Drawing.Point(34, 379);
            cMEnterFocus.Name = "cMEnterFocus";
            cMEnterFocus.Size = new System.Drawing.Size(322, 19);
            cMEnterFocus.TabIndex = 14;
            cMEnterFocus.Text = "Automatically set focus to editing panel on mouse enter";
            cMEnterFocus.UseVisualStyleBackColor = true;
            // 
            // cMClickFocus
            // 
            cMClickFocus.AutoSize = true;
            cMClickFocus.Location = new System.Drawing.Point(34, 404);
            cMClickFocus.Name = "cMClickFocus";
            cMClickFocus.Size = new System.Drawing.Size(293, 19);
            cMClickFocus.TabIndex = 15;
            cMClickFocus.Text = "Disable first click if the editing panel is not focused";
            cMClickFocus.UseVisualStyleBackColor = true;
            // 
            // TBAssociatePMS
            // 
            TBAssociatePMS.Location = new System.Drawing.Point(310, 78);
            TBAssociatePMS.Name = "TBAssociatePMS";
            TBAssociatePMS.Size = new System.Drawing.Size(81, 23);
            TBAssociatePMS.TabIndex = 4;
            TBAssociatePMS.Text = "*.pms";
            TBAssociatePMS.UseVisualStyleBackColor = true;
            // 
            // TBAssociateIBMSC
            // 
            TBAssociateIBMSC.Location = new System.Drawing.Point(265, 47);
            TBAssociateIBMSC.Name = "TBAssociateIBMSC";
            TBAssociateIBMSC.Size = new System.Drawing.Size(127, 23);
            TBAssociateIBMSC.TabIndex = 5;
            TBAssociateIBMSC.Text = "*.ibmsc";
            TBAssociateIBMSC.UseVisualStyleBackColor = true;
            // 
            // Label5
            // 
            Label5.Location = new System.Drawing.Point(12, 300);
            Label5.Name = "Label5";
            Label5.Size = new System.Drawing.Size(136, 17);
            Label5.TabIndex = 56;
            Label5.Text = "PageUp / PageDown";
            Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CPgUpDn
            // 
            CPgUpDn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CPgUpDn.FormattingEnabled = true;
            CPgUpDn.Items.AddRange(new object[] { "8", "6", "4", "3", "2", "1", "1 / 2" });
            CPgUpDn.Location = new System.Drawing.Point(154, 298);
            CPgUpDn.Name = "CPgUpDn";
            CPgUpDn.Size = new System.Drawing.Size(237, 23);
            CPgUpDn.TabIndex = 12;
            // 
            // NAutoSave
            // 
            NAutoSave.DecimalPlaces = 1;
            NAutoSave.Location = new System.Drawing.Point(171, 142);
            NAutoSave.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            NAutoSave.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NAutoSave.Name = "NAutoSave";
            NAutoSave.Size = new System.Drawing.Size(62, 23);
            NAutoSave.TabIndex = 7;
            NAutoSave.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // Label7
            // 
            Label7.Location = new System.Drawing.Point(239, 144);
            Label7.Name = "Label7";
            Label7.Size = new System.Drawing.Size(73, 17);
            Label7.TabIndex = 59;
            Label7.Text = "minutes";
            Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cAutoSave
            // 
            cAutoSave.AutoSize = true;
            cAutoSave.Checked = true;
            cAutoSave.CheckState = System.Windows.Forms.CheckState.Checked;
            cAutoSave.Location = new System.Drawing.Point(32, 144);
            cAutoSave.Name = "cAutoSave";
            cAutoSave.Size = new System.Drawing.Size(76, 19);
            cAutoSave.TabIndex = 6;
            cAutoSave.Text = "AutoSave";
            cAutoSave.UseVisualStyleBackColor = true;
            // 
            // cMStopPreview
            // 
            cMStopPreview.AutoSize = true;
            cMStopPreview.Checked = true;
            cMStopPreview.CheckState = System.Windows.Forms.CheckState.Checked;
            cMStopPreview.Location = new System.Drawing.Point(34, 429);
            cMStopPreview.Name = "cMStopPreview";
            cMStopPreview.Size = new System.Drawing.Size(253, 19);
            cMStopPreview.TabIndex = 60;
            cMStopPreview.Text = "Stop preview if clicked on the editing panel";
            cMStopPreview.UseVisualStyleBackColor = true;
            // 
            // nGridPartition
            // 
            nGridPartition.Location = new System.Drawing.Point(219, 107);
            nGridPartition.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nGridPartition.Minimum = new decimal(new int[] { 8, 0, 0, 0 });
            nGridPartition.Name = "nGridPartition";
            nGridPartition.Size = new System.Drawing.Size(79, 23);
            nGridPartition.TabIndex = 61;
            nGridPartition.Value = new decimal(new int[] { 192, 0, 0, 0 });
            // 
            // Label6
            // 
            Label6.Location = new System.Drawing.Point(44, 108);
            Label6.Name = "Label6";
            Label6.Size = new System.Drawing.Size(169, 17);
            Label6.TabIndex = 62;
            Label6.Text = "Max Grid Partition in BMS";
            Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TBAssociateBME
            // 
            TBAssociateBME.Location = new System.Drawing.Point(137, 78);
            TBAssociateBME.Name = "TBAssociateBME";
            TBAssociateBME.Size = new System.Drawing.Size(76, 23);
            TBAssociateBME.TabIndex = 63;
            TBAssociateBME.Text = "*.bme";
            TBAssociateBME.UseVisualStyleBackColor = true;
            // 
            // TBAssociateBML
            // 
            TBAssociateBML.Location = new System.Drawing.Point(219, 78);
            TBAssociateBML.Name = "TBAssociateBML";
            TBAssociateBML.Size = new System.Drawing.Size(85, 23);
            TBAssociateBML.TabIndex = 64;
            TBAssociateBML.Text = "*.bml";
            TBAssociateBML.UseVisualStyleBackColor = true;
            // 
            // Label3
            // 
            Label3.Location = new System.Drawing.Point(12, 328);
            Label3.Name = "Label3";
            Label3.Size = new System.Drawing.Size(136, 17);
            Label3.TabIndex = 65;
            Label3.Text = "Mouse Middle Button";
            Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FlowLayoutPanel1
            // 
            FlowLayoutPanel1.AutoSize = true;
            FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            FlowLayoutPanel1.Controls.Add(rMiddleAuto);
            FlowLayoutPanel1.Controls.Add(rMiddleDrag);
            FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            FlowLayoutPanel1.Location = new System.Drawing.Point(154, 327);
            FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            FlowLayoutPanel1.Size = new System.Drawing.Size(141, 38);
            FlowLayoutPanel1.TabIndex = 66;
            // 
            // rMiddleAuto
            // 
            rMiddleAuto.AutoSize = true;
            rMiddleAuto.Checked = true;
            rMiddleAuto.Location = new System.Drawing.Point(3, 0);
            rMiddleAuto.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            rMiddleAuto.Name = "rMiddleAuto";
            rMiddleAuto.Size = new System.Drawing.Size(135, 19);
            rMiddleAuto.TabIndex = 0;
            rMiddleAuto.TabStop = true;
            rMiddleAuto.Text = "Click and Auto Scroll";
            rMiddleAuto.UseVisualStyleBackColor = true;
            // 
            // rMiddleDrag
            // 
            rMiddleDrag.AutoSize = true;
            rMiddleDrag.Location = new System.Drawing.Point(3, 19);
            rMiddleDrag.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            rMiddleDrag.Name = "rMiddleDrag";
            rMiddleDrag.Size = new System.Drawing.Size(102, 19);
            rMiddleDrag.TabIndex = 1;
            rMiddleDrag.TabStop = true;
            rMiddleDrag.Text = "Click and Drag";
            rMiddleDrag.UseVisualStyleBackColor = true;
            // 
            // OpGeneral
            // 
            AcceptButton = OK_Button;
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            CancelButton = Cancel_Button;
            ClientSize = new System.Drawing.Size(413, 510);
            Controls.Add(FlowLayoutPanel1);
            Controls.Add(Label3);
            Controls.Add(TBAssociateBML);
            Controls.Add(TBAssociateBME);
            Controls.Add(Label6);
            Controls.Add(nGridPartition);
            Controls.Add(cMStopPreview);
            Controls.Add(cAutoSave);
            Controls.Add(Label7);
            Controls.Add(NAutoSave);
            Controls.Add(Label5);
            Controls.Add(CPgUpDn);
            Controls.Add(TBAssociateIBMSC);
            Controls.Add(TBAssociatePMS);
            Controls.Add(cMClickFocus);
            Controls.Add(cMEnterFocus);
            Controls.Add(cStop1296);
            Controls.Add(cBpm1296);
            Controls.Add(PictureBox1);
            Controls.Add(cBeep);
            Controls.Add(TBAssociate);
            Controls.Add(Label4);
            Controls.Add(Label2);
            Controls.Add(Label1);
            Controls.Add(CTextEncoding);
            Controls.Add(CWheel);
            Controls.Add(TableLayoutPanel1);
            Font = new System.Drawing.Font("Segoe UI", 9.0f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "OpGeneral";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "General Settings";
            TableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)NAutoSave).EndInit();
            ((System.ComponentModel.ISupportInitialize)nGridPartition).EndInit();
            FlowLayoutPanel1.ResumeLayout(false);
            FlowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.Button OK_Button;
        internal System.Windows.Forms.Button Cancel_Button;
        internal System.Windows.Forms.ComboBox CWheel;
        internal System.Windows.Forms.ComboBox CTextEncoding;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Button TBAssociate;
        internal System.Windows.Forms.CheckBox cBeep;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.CheckBox cBpm1296;
        internal System.Windows.Forms.CheckBox cStop1296;
        internal System.Windows.Forms.CheckBox cMEnterFocus;
        internal System.Windows.Forms.CheckBox cMClickFocus;
        internal System.Windows.Forms.Button TBAssociatePMS;
        internal System.Windows.Forms.Button TBAssociateIBMSC;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.ComboBox CPgUpDn;
        internal System.Windows.Forms.NumericUpDown NAutoSave;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.CheckBox cAutoSave;
        internal System.Windows.Forms.CheckBox cMStopPreview;
        internal System.Windows.Forms.NumericUpDown nGridPartition;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Button TBAssociateBME;
        internal System.Windows.Forms.Button TBAssociateBML;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel1;
        internal System.Windows.Forms.RadioButton rMiddleAuto;
        internal System.Windows.Forms.RadioButton rMiddleDrag;

    }
}