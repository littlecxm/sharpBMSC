using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace iBMSC
{
    public partial class diagFind : Form
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
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.mr1 = new System.Windows.Forms.NumericUpDown();
            this.mr2 = new System.Windows.Forms.NumericUpDown();
            this.lr1 = new System.Windows.Forms.TextBox();
            this.lr2 = new System.Windows.Forms.TextBox();
            this.vr2 = new System.Windows.Forms.NumericUpDown();
            this.vr1 = new System.Windows.Forms.NumericUpDown();
            this.cb1 = new System.Windows.Forms.CheckBox();
            this.cb2 = new System.Windows.Forms.CheckBox();
            this.cba1 = new System.Windows.Forms.CheckBox();
            this.cba2 = new System.Windows.Forms.CheckBox();
            this.cba3 = new System.Windows.Forms.CheckBox();
            this.cba4 = new System.Windows.Forms.CheckBox();
            this.cba5 = new System.Windows.Forms.CheckBox();
            this.cba6 = new System.Windows.Forms.CheckBox();
            this.cba7 = new System.Windows.Forms.CheckBox();
            this.cba8 = new System.Windows.Forms.CheckBox();
            this.cbd1 = new System.Windows.Forms.CheckBox();
            this.cbd2 = new System.Windows.Forms.CheckBox();
            this.cbd3 = new System.Windows.Forms.CheckBox();
            this.cbd4 = new System.Windows.Forms.CheckBox();
            this.cbd5 = new System.Windows.Forms.CheckBox();
            this.cbd6 = new System.Windows.Forms.CheckBox();
            this.cbd7 = new System.Windows.Forms.CheckBox();
            this.cbd8 = new System.Windows.Forms.CheckBox();
            this.cb3 = new System.Windows.Forms.CheckBox();
            this.cb4 = new System.Windows.Forms.CheckBox();
            this.cb5 = new System.Windows.Forms.CheckBox();
            this.cbb1 = new System.Windows.Forms.CheckBox();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.BSAll = new System.Windows.Forms.Button();
            this.BSInv = new System.Windows.Forms.Button();
            this.BSNone = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.TBSelect = new System.Windows.Forms.Button();
            this.TBClose = new System.Windows.Forms.Button();
            this.TBDelete = new System.Windows.Forms.Button();
            this.TBrl = new System.Windows.Forms.Button();
            this.TBrv = new System.Windows.Forms.Button();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Ttv = new System.Windows.Forms.NumericUpDown();
            this.Ttl = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.PictureBox3 = new System.Windows.Forms.PictureBox();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbx1 = new System.Windows.Forms.CheckBox();
            this.cbx2 = new System.Windows.Forms.CheckBox();
            this.cbx3 = new System.Windows.Forms.CheckBox();
            this.TBUnselect = new System.Windows.Forms.Button();
            this.cbx4 = new System.Windows.Forms.CheckBox();
            this.cbx5 = new System.Windows.Forms.CheckBox();
            this.cbx6 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.mr1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mr2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vr2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vr1)).BeginInit();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ttv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(26, 20);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(120, 17);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Note Range";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(26, 73);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(120, 17);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Measure Range";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mr1
            // 
            this.mr1.Location = new System.Drawing.Point(152, 72);
            this.mr1.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.mr1.Name = "mr1";
            this.mr1.Size = new System.Drawing.Size(70, 23);
            this.mr1.TabIndex = 5;
            // 
            // mr2
            // 
            this.mr2.Location = new System.Drawing.Point(258, 72);
            this.mr2.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.mr2.Name = "mr2";
            this.mr2.Size = new System.Drawing.Size(70, 23);
            this.mr2.TabIndex = 6;
            this.mr2.Value = new decimal(new int[] {
            999,
            0,
            0,
            0});
            // 
            // lr1
            // 
            this.lr1.Location = new System.Drawing.Point(152, 101);
            this.lr1.MaxLength = 2;
            this.lr1.Name = "lr1";
            this.lr1.Size = new System.Drawing.Size(70, 23);
            this.lr1.TabIndex = 7;
            this.lr1.Text = "01";
            // 
            // lr2
            // 
            this.lr2.Location = new System.Drawing.Point(258, 101);
            this.lr2.MaxLength = 2;
            this.lr2.Name = "lr2";
            this.lr2.Size = new System.Drawing.Size(70, 23);
            this.lr2.TabIndex = 8;
            this.lr2.Text = "ZZ";
            // 
            // vr2
            // 
            this.vr2.DecimalPlaces = 4;
            this.vr2.Location = new System.Drawing.Point(258, 130);
            this.vr2.Maximum = new decimal(new int[] {
            655359999,
            0,
            0,
            262144});
            this.vr2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.vr2.Name = "vr2";
            this.vr2.Size = new System.Drawing.Size(100, 23);
            this.vr2.TabIndex = 10;
            this.vr2.Value = new decimal(new int[] {
            655359999,
            0,
            0,
            262144});
            // 
            // vr1
            // 
            this.vr1.DecimalPlaces = 4;
            this.vr1.Location = new System.Drawing.Point(152, 130);
            this.vr1.Maximum = new decimal(new int[] {
            655359999,
            0,
            0,
            262144});
            this.vr1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.vr1.Name = "vr1";
            this.vr1.Size = new System.Drawing.Size(70, 23);
            this.vr1.TabIndex = 9;
            this.vr1.Value = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            // 
            // cb1
            // 
            this.cb1.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb1.Checked = true;
            this.cb1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cb1.Location = new System.Drawing.Point(3, 2);
            this.cb1.Name = "cb1";
            this.cb1.Size = new System.Drawing.Size(50, 25);
            this.cb1.TabIndex = 0;
            this.cb1.Tag = "1";
            this.cb1.Text = "BPM";
            this.cb1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cb1.UseVisualStyleBackColor = false;
            // 
            // cb2
            // 
            this.cb2.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb2.Checked = true;
            this.cb2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cb2.Location = new System.Drawing.Point(53, 2);
            this.cb2.Name = "cb2";
            this.cb2.Size = new System.Drawing.Size(50, 25);
            this.cb2.TabIndex = 1;
            this.cb2.Tag = "2";
            this.cb2.Text = "STOP";
            this.cb2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cb2.UseVisualStyleBackColor = true;
            // 
            // cba1
            // 
            this.cba1.Appearance = System.Windows.Forms.Appearance.Button;
            this.cba1.Checked = true;
            this.cba1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cba1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cba1.Location = new System.Drawing.Point(3, 27);
            this.cba1.Name = "cba1";
            this.cba1.Size = new System.Drawing.Size(35, 25);
            this.cba1.TabIndex = 2;
            this.cba1.Tag = "4";
            this.cba1.Text = "A1";
            this.cba1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cba1.UseVisualStyleBackColor = true;
            // 
            // cba2
            // 
            this.cba2.Appearance = System.Windows.Forms.Appearance.Button;
            this.cba2.Checked = true;
            this.cba2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cba2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cba2.Location = new System.Drawing.Point(38, 27);
            this.cba2.Name = "cba2";
            this.cba2.Size = new System.Drawing.Size(35, 25);
            this.cba2.TabIndex = 3;
            this.cba2.Tag = "5";
            this.cba2.Text = "A2";
            this.cba2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cba2.UseVisualStyleBackColor = true;
            // 
            // cba3
            // 
            this.cba3.Appearance = System.Windows.Forms.Appearance.Button;
            this.cba3.Checked = true;
            this.cba3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cba3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cba3.Location = new System.Drawing.Point(73, 27);
            this.cba3.Name = "cba3";
            this.cba3.Size = new System.Drawing.Size(35, 25);
            this.cba3.TabIndex = 4;
            this.cba3.Tag = "6";
            this.cba3.Text = "A3";
            this.cba3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cba3.UseVisualStyleBackColor = true;
            // 
            // cba4
            // 
            this.cba4.Appearance = System.Windows.Forms.Appearance.Button;
            this.cba4.Checked = true;
            this.cba4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cba4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cba4.Location = new System.Drawing.Point(108, 27);
            this.cba4.Name = "cba4";
            this.cba4.Size = new System.Drawing.Size(35, 25);
            this.cba4.TabIndex = 5;
            this.cba4.Tag = "7";
            this.cba4.Text = "A4";
            this.cba4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cba4.UseVisualStyleBackColor = true;
            // 
            // cba5
            // 
            this.cba5.Appearance = System.Windows.Forms.Appearance.Button;
            this.cba5.Checked = true;
            this.cba5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cba5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cba5.Location = new System.Drawing.Point(143, 27);
            this.cba5.Name = "cba5";
            this.cba5.Size = new System.Drawing.Size(35, 25);
            this.cba5.TabIndex = 6;
            this.cba5.Tag = "8";
            this.cba5.Text = "A5";
            this.cba5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cba5.UseVisualStyleBackColor = true;
            // 
            // cba6
            // 
            this.cba6.Appearance = System.Windows.Forms.Appearance.Button;
            this.cba6.Checked = true;
            this.cba6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cba6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cba6.Location = new System.Drawing.Point(178, 27);
            this.cba6.Name = "cba6";
            this.cba6.Size = new System.Drawing.Size(35, 25);
            this.cba6.TabIndex = 7;
            this.cba6.Tag = "9";
            this.cba6.Text = "A6";
            this.cba6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cba6.UseVisualStyleBackColor = true;
            // 
            // cba7
            // 
            this.cba7.Appearance = System.Windows.Forms.Appearance.Button;
            this.cba7.Checked = true;
            this.cba7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cba7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cba7.Location = new System.Drawing.Point(213, 27);
            this.cba7.Name = "cba7";
            this.cba7.Size = new System.Drawing.Size(35, 25);
            this.cba7.TabIndex = 8;
            this.cba7.Tag = "10";
            this.cba7.Text = "A7";
            this.cba7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cba7.UseVisualStyleBackColor = true;
            // 
            // cba8
            // 
            this.cba8.Appearance = System.Windows.Forms.Appearance.Button;
            this.cba8.Checked = true;
            this.cba8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cba8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cba8.Location = new System.Drawing.Point(248, 27);
            this.cba8.Name = "cba8";
            this.cba8.Size = new System.Drawing.Size(35, 25);
            this.cba8.TabIndex = 9;
            this.cba8.Tag = "11";
            this.cba8.Text = "A8";
            this.cba8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cba8.UseVisualStyleBackColor = true;
            // 
            // cbd1
            // 
            this.cbd1.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbd1.Checked = true;
            this.cbd1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbd1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbd1.Location = new System.Drawing.Point(3, 52);
            this.cbd1.Name = "cbd1";
            this.cbd1.Size = new System.Drawing.Size(35, 25);
            this.cbd1.TabIndex = 10;
            this.cbd1.Tag = "13";
            this.cbd1.Text = "D1";
            this.cbd1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbd1.UseVisualStyleBackColor = true;
            // 
            // cbd2
            // 
            this.cbd2.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbd2.Checked = true;
            this.cbd2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbd2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbd2.Location = new System.Drawing.Point(38, 52);
            this.cbd2.Name = "cbd2";
            this.cbd2.Size = new System.Drawing.Size(35, 25);
            this.cbd2.TabIndex = 11;
            this.cbd2.Tag = "14";
            this.cbd2.Text = "D2";
            this.cbd2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbd2.UseVisualStyleBackColor = true;
            // 
            // cbd3
            // 
            this.cbd3.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbd3.Checked = true;
            this.cbd3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbd3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbd3.Location = new System.Drawing.Point(73, 52);
            this.cbd3.Name = "cbd3";
            this.cbd3.Size = new System.Drawing.Size(35, 25);
            this.cbd3.TabIndex = 12;
            this.cbd3.Tag = "15";
            this.cbd3.Text = "D3";
            this.cbd3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbd3.UseVisualStyleBackColor = true;
            // 
            // cbd4
            // 
            this.cbd4.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbd4.Checked = true;
            this.cbd4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbd4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbd4.Location = new System.Drawing.Point(108, 52);
            this.cbd4.Name = "cbd4";
            this.cbd4.Size = new System.Drawing.Size(35, 25);
            this.cbd4.TabIndex = 13;
            this.cbd4.Tag = "16";
            this.cbd4.Text = "D4";
            this.cbd4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbd4.UseVisualStyleBackColor = true;
            // 
            // cbd5
            // 
            this.cbd5.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbd5.Checked = true;
            this.cbd5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbd5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbd5.Location = new System.Drawing.Point(143, 52);
            this.cbd5.Name = "cbd5";
            this.cbd5.Size = new System.Drawing.Size(35, 25);
            this.cbd5.TabIndex = 14;
            this.cbd5.Tag = "17";
            this.cbd5.Text = "D5";
            this.cbd5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbd5.UseVisualStyleBackColor = true;
            // 
            // cbd6
            // 
            this.cbd6.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbd6.Checked = true;
            this.cbd6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbd6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbd6.Location = new System.Drawing.Point(178, 52);
            this.cbd6.Name = "cbd6";
            this.cbd6.Size = new System.Drawing.Size(35, 25);
            this.cbd6.TabIndex = 15;
            this.cbd6.Tag = "18";
            this.cbd6.Text = "D6";
            this.cbd6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbd6.UseVisualStyleBackColor = true;
            // 
            // cbd7
            // 
            this.cbd7.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbd7.Checked = true;
            this.cbd7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbd7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbd7.Location = new System.Drawing.Point(213, 52);
            this.cbd7.Name = "cbd7";
            this.cbd7.Size = new System.Drawing.Size(35, 25);
            this.cbd7.TabIndex = 16;
            this.cbd7.Tag = "19";
            this.cbd7.Text = "D7";
            this.cbd7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbd7.UseVisualStyleBackColor = true;
            // 
            // cbd8
            // 
            this.cbd8.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbd8.Checked = true;
            this.cbd8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbd8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbd8.Location = new System.Drawing.Point(248, 52);
            this.cbd8.Name = "cbd8";
            this.cbd8.Size = new System.Drawing.Size(35, 25);
            this.cbd8.TabIndex = 17;
            this.cbd8.Tag = "20";
            this.cbd8.Text = "D8";
            this.cbd8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbd8.UseVisualStyleBackColor = true;
            // 
            // cb3
            // 
            this.cb3.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb3.Checked = true;
            this.cb3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cb3.Location = new System.Drawing.Point(3, 77);
            this.cb3.Name = "cb3";
            this.cb3.Size = new System.Drawing.Size(55, 25);
            this.cb3.TabIndex = 18;
            this.cb3.Tag = "22";
            this.cb3.Text = "BGA";
            this.cb3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cb3.UseVisualStyleBackColor = true;
            // 
            // cb4
            // 
            this.cb4.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb4.Checked = true;
            this.cb4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cb4.Location = new System.Drawing.Point(58, 77);
            this.cb4.Name = "cb4";
            this.cb4.Size = new System.Drawing.Size(55, 25);
            this.cb4.TabIndex = 19;
            this.cb4.Tag = "23";
            this.cb4.Text = "LAYER";
            this.cb4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cb4.UseVisualStyleBackColor = true;
            // 
            // cb5
            // 
            this.cb5.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb5.Checked = true;
            this.cb5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cb5.Location = new System.Drawing.Point(113, 77);
            this.cb5.Name = "cb5";
            this.cb5.Size = new System.Drawing.Size(55, 25);
            this.cb5.TabIndex = 20;
            this.cb5.Tag = "24";
            this.cb5.Text = "POOR";
            this.cb5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cb5.UseVisualStyleBackColor = true;
            // 
            // cbb1
            // 
            this.cbb1.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbb1.Checked = true;
            this.cbb1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbb1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbb1.Location = new System.Drawing.Point(3, 102);
            this.cbb1.Name = "cbb1";
            this.cbb1.Size = new System.Drawing.Size(35, 25);
            this.cbb1.TabIndex = 21;
            this.cbb1.Tag = "26";
            this.cbb1.Text = "B1";
            this.cbb1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbb1.UseVisualStyleBackColor = true;
            // 
            // Panel1
            // 
            this.Panel1.AutoScroll = true;
            this.Panel1.Controls.Add(this.cb1);
            this.Panel1.Controls.Add(this.cbd8);
            this.Panel1.Controls.Add(this.cb2);
            this.Panel1.Controls.Add(this.cb3);
            this.Panel1.Controls.Add(this.cba1);
            this.Panel1.Controls.Add(this.cbd7);
            this.Panel1.Controls.Add(this.cb4);
            this.Panel1.Controls.Add(this.cba2);
            this.Panel1.Controls.Add(this.cbd6);
            this.Panel1.Controls.Add(this.cb5);
            this.Panel1.Controls.Add(this.cba3);
            this.Panel1.Controls.Add(this.cbd5);
            this.Panel1.Controls.Add(this.cbb1);
            this.Panel1.Controls.Add(this.cba4);
            this.Panel1.Controls.Add(this.cbd4);
            this.Panel1.Controls.Add(this.cbd3);
            this.Panel1.Controls.Add(this.cba5);
            this.Panel1.Controls.Add(this.cbd2);
            this.Panel1.Controls.Add(this.cbd1);
            this.Panel1.Controls.Add(this.cba6);
            this.Panel1.Controls.Add(this.cba8);
            this.Panel1.Controls.Add(this.cba7);
            this.Panel1.Location = new System.Drawing.Point(26, 186);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(302, 131);
            this.Panel1.TabIndex = 22;
            // 
            // BSAll
            // 
            this.BSAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BSAll.Location = new System.Drawing.Point(334, 189);
            this.BSAll.Name = "BSAll";
            this.BSAll.Size = new System.Drawing.Size(120, 23);
            this.BSAll.TabIndex = 23;
            this.BSAll.Text = "Select All";
            this.BSAll.UseVisualStyleBackColor = true;
            this.BSAll.Click += new System.EventHandler(this.BSAll_Click);
            // 
            // BSInv
            // 
            this.BSInv.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BSInv.Location = new System.Drawing.Point(334, 218);
            this.BSInv.Name = "BSInv";
            this.BSInv.Size = new System.Drawing.Size(120, 23);
            this.BSInv.TabIndex = 24;
            this.BSInv.Text = "Select Inverse";
            this.BSInv.UseVisualStyleBackColor = true;
            this.BSInv.Click += new System.EventHandler(this.BSInv_Click);
            // 
            // BSNone
            // 
            this.BSNone.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BSNone.Location = new System.Drawing.Point(334, 247);
            this.BSNone.Name = "BSNone";
            this.BSNone.Size = new System.Drawing.Size(120, 23);
            this.BSNone.TabIndex = 25;
            this.BSNone.Text = "Unselect All";
            this.BSNone.UseVisualStyleBackColor = true;
            this.BSNone.Click += new System.EventHandler(this.BSNone_Click);
            // 
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(26, 103);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(120, 17);
            this.Label3.TabIndex = 26;
            this.Label3.Text = "Label Range";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(26, 131);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(120, 17);
            this.Label4.TabIndex = 27;
            this.Label4.Text = "Value Range";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TBSelect
            // 
            this.TBSelect.Location = new System.Drawing.Point(298, 354);
            this.TBSelect.Name = "TBSelect";
            this.TBSelect.Size = new System.Drawing.Size(85, 23);
            this.TBSelect.TabIndex = 28;
            this.TBSelect.Text = "Select";
            this.TBSelect.UseVisualStyleBackColor = true;
            this.TBSelect.Click += new System.EventHandler(this.TBSelect_Click);
            // 
            // TBClose
            // 
            this.TBClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.TBClose.Location = new System.Drawing.Point(389, 383);
            this.TBClose.Name = "TBClose";
            this.TBClose.Size = new System.Drawing.Size(65, 23);
            this.TBClose.TabIndex = 29;
            this.TBClose.Text = "Close";
            this.TBClose.UseVisualStyleBackColor = true;
            this.TBClose.Click += new System.EventHandler(this.CloseDialog);
            // 
            // TBDelete
            // 
            this.TBDelete.Location = new System.Drawing.Point(389, 354);
            this.TBDelete.Name = "TBDelete";
            this.TBDelete.Size = new System.Drawing.Size(65, 23);
            this.TBDelete.TabIndex = 30;
            this.TBDelete.Text = "Delete";
            this.TBDelete.UseVisualStyleBackColor = true;
            this.TBDelete.Click += new System.EventHandler(this.TBDelete_Click);
            // 
            // TBrl
            // 
            this.TBrl.Location = new System.Drawing.Point(26, 354);
            this.TBrl.Name = "TBrl";
            this.TBrl.Size = new System.Drawing.Size(178, 23);
            this.TBrl.TabIndex = 33;
            this.TBrl.Text = "Replace with Label:";
            this.TBrl.UseVisualStyleBackColor = true;
            this.TBrl.Click += new System.EventHandler(this.TBrl_Click);
            // 
            // TBrv
            // 
            this.TBrv.Location = new System.Drawing.Point(26, 383);
            this.TBrv.Name = "TBrv";
            this.TBrv.Size = new System.Drawing.Size(178, 23);
            this.TBrv.TabIndex = 35;
            this.TBrv.Text = "Replace with Value:";
            this.TBrv.UseVisualStyleBackColor = true;
            this.TBrv.Click += new System.EventHandler(this.TBrv_Click);
            // 
            // Label5
            // 
            this.Label5.Location = new System.Drawing.Point(221, 103);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(39, 16);
            this.Label5.TabIndex = 50;
            this.Label5.Text = "to";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label6
            // 
            this.Label6.Location = new System.Drawing.Point(221, 74);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(39, 16);
            this.Label6.TabIndex = 51;
            this.Label6.Text = "to";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label7
            // 
            this.Label7.Location = new System.Drawing.Point(221, 132);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(39, 16);
            this.Label7.TabIndex = 52;
            this.Label7.Text = "to";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Ttv
            // 
            this.Ttv.DecimalPlaces = 4;
            this.Ttv.Location = new System.Drawing.Point(210, 383);
            this.Ttv.Maximum = new decimal(new int[] {
            655359999,
            0,
            0,
            262144});
            this.Ttv.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.Ttv.Name = "Ttv";
            this.Ttv.Size = new System.Drawing.Size(70, 23);
            this.Ttv.TabIndex = 34;
            this.Ttv.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // Ttl
            // 
            this.Ttl.Location = new System.Drawing.Point(210, 354);
            this.Ttl.MaxLength = 2;
            this.Ttl.Name = "Ttl";
            this.Ttl.Size = new System.Drawing.Size(70, 23);
            this.Ttl.TabIndex = 32;
            this.Ttl.Text = "01";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(12, 165);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(50, 15);
            this.Label8.TabIndex = 56;
            this.Label8.Text = "Column";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(12, 327);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(60, 15);
            this.Label9.TabIndex = 57;
            this.Label9.Text = "Operation";
            // 
            // PictureBox3
            // 
            this.PictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PictureBox3.Location = new System.Drawing.Point(289, 354);
            this.PictureBox3.Name = "PictureBox3";
            this.PictureBox3.Size = new System.Drawing.Size(1, 52);
            this.PictureBox3.TabIndex = 55;
            this.PictureBox3.TabStop = false;
            // 
            // PictureBox2
            // 
            this.PictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PictureBox2.Location = new System.Drawing.Point(12, 335);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(450, 1);
            this.PictureBox2.TabIndex = 49;
            this.PictureBox2.TabStop = false;
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PictureBox1.Location = new System.Drawing.Point(12, 173);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(450, 1);
            this.PictureBox1.TabIndex = 48;
            this.PictureBox1.TabStop = false;
            // 
            // cbx1
            // 
            this.cbx1.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbx1.Checked = true;
            this.cbx1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbx1.Location = new System.Drawing.Point(152, 16);
            this.cbx1.Name = "cbx1";
            this.cbx1.Size = new System.Drawing.Size(100, 25);
            this.cbx1.TabIndex = 58;
            this.cbx1.Tag = "1";
            this.cbx1.Text = "Selected";
            this.cbx1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbx1.UseVisualStyleBackColor = false;
            // 
            // cbx2
            // 
            this.cbx2.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbx2.Checked = true;
            this.cbx2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbx2.Location = new System.Drawing.Point(152, 41);
            this.cbx2.Name = "cbx2";
            this.cbx2.Size = new System.Drawing.Size(100, 25);
            this.cbx2.TabIndex = 59;
            this.cbx2.Tag = "1";
            this.cbx2.Text = "Unselected";
            this.cbx2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbx2.UseVisualStyleBackColor = false;
            // 
            // cbx3
            // 
            this.cbx3.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbx3.Checked = true;
            this.cbx3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbx3.Location = new System.Drawing.Point(258, 16);
            this.cbx3.Name = "cbx3";
            this.cbx3.Size = new System.Drawing.Size(70, 25);
            this.cbx3.TabIndex = 60;
            this.cbx3.Tag = "1";
            this.cbx3.Text = "Short";
            this.cbx3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbx3.UseVisualStyleBackColor = false;
            // 
            // TBUnselect
            // 
            this.TBUnselect.Location = new System.Drawing.Point(298, 383);
            this.TBUnselect.Name = "TBUnselect";
            this.TBUnselect.Size = new System.Drawing.Size(85, 23);
            this.TBUnselect.TabIndex = 31;
            this.TBUnselect.Text = "Unselect";
            this.TBUnselect.UseVisualStyleBackColor = true;
            this.TBUnselect.Click += new System.EventHandler(this.TBUnselect_Click);
            // 
            // cbx4
            // 
            this.cbx4.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbx4.Checked = true;
            this.cbx4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbx4.Location = new System.Drawing.Point(258, 41);
            this.cbx4.Name = "cbx4";
            this.cbx4.Size = new System.Drawing.Size(70, 25);
            this.cbx4.TabIndex = 61;
            this.cbx4.Tag = "1";
            this.cbx4.Text = "Long";
            this.cbx4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbx4.UseVisualStyleBackColor = false;
            // 
            // cbx5
            // 
            this.cbx5.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbx5.Checked = true;
            this.cbx5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbx5.Location = new System.Drawing.Point(334, 16);
            this.cbx5.Name = "cbx5";
            this.cbx5.Size = new System.Drawing.Size(80, 25);
            this.cbx5.TabIndex = 62;
            this.cbx5.Tag = "1";
            this.cbx5.Text = "Hidden";
            this.cbx5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbx5.UseVisualStyleBackColor = false;
            // 
            // cbx6
            // 
            this.cbx6.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbx6.Checked = true;
            this.cbx6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbx6.Location = new System.Drawing.Point(334, 41);
            this.cbx6.Name = "cbx6";
            this.cbx6.Size = new System.Drawing.Size(80, 25);
            this.cbx6.TabIndex = 63;
            this.cbx6.Tag = "1";
            this.cbx6.Text = "Visible";
            this.cbx6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbx6.UseVisualStyleBackColor = false;
            // 
            // diagFind
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.TBClose;
            this.ClientSize = new System.Drawing.Size(474, 422);
            this.Controls.Add(this.cbx6);
            this.Controls.Add(this.cbx5);
            this.Controls.Add(this.cbx4);
            this.Controls.Add(this.TBUnselect);
            this.Controls.Add(this.cbx3);
            this.Controls.Add(this.cbx2);
            this.Controls.Add(this.cbx1);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.PictureBox3);
            this.Controls.Add(this.Ttv);
            this.Controls.Add(this.Ttl);
            this.Controls.Add(this.PictureBox2);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.TBrv);
            this.Controls.Add(this.TBrl);
            this.Controls.Add(this.TBDelete);
            this.Controls.Add(this.TBClose);
            this.Controls.Add(this.TBSelect);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.BSNone);
            this.Controls.Add(this.BSInv);
            this.Controls.Add(this.BSAll);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.vr2);
            this.Controls.Add(this.vr1);
            this.Controls.Add(this.lr2);
            this.Controls.Add(this.lr1);
            this.Controls.Add(this.mr2);
            this.Controls.Add(this.mr1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label5);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "diagFind";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Find / Delete / Replace";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.mr1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mr2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vr2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vr1)).EndInit();
            this.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Ttv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

internal Label Label1;
internal Label Label2;
internal NumericUpDown mr1;
internal NumericUpDown mr2;
internal TextBox lr1;
internal TextBox lr2;
internal NumericUpDown vr2;
internal NumericUpDown vr1;
internal CheckBox cb1;
internal CheckBox cb2;
internal CheckBox cba1;
internal CheckBox cba2;
internal CheckBox cba3;
internal CheckBox cba4;
internal CheckBox cba5;
internal CheckBox cba6;
internal CheckBox cba7;
internal CheckBox cba8;
internal CheckBox cbd1;
internal CheckBox cbd2;
internal CheckBox cbd3;
internal CheckBox cbd4;
internal CheckBox cbd5;
internal CheckBox cbd6;
internal CheckBox cbd7;
internal CheckBox cbd8;
internal CheckBox cb3;
internal CheckBox cb4;
internal CheckBox cb5;
internal CheckBox cbb1;
internal Panel Panel1;
internal Button BSAll;
internal Button BSInv;
internal Button BSNone;
internal Label Label3;
internal Label Label4;
internal Button TBSelect;
internal Button TBClose;
internal Button TBDelete;
internal Button TBrl;
internal Button TBrv;
internal PictureBox PictureBox1;
internal PictureBox PictureBox2;
internal Label Label5;
internal Label Label6;
internal Label Label7;
internal NumericUpDown Ttv;
internal TextBox Ttl;
internal PictureBox PictureBox3;
internal Label Label8;
internal Label Label9;
internal CheckBox cbx1;
internal CheckBox cbx2;
internal CheckBox cbx3;
internal Button TBUnselect;
internal CheckBox cbx4;
internal CheckBox cbx5;
internal CheckBox cbx6;
    }
}
