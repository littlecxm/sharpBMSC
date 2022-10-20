using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace iBMSC
{
    public partial class dgMyO2 : Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dgMyO2));
            this.Label1 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.vBPM = new System.Windows.Forms.NumericUpDown();
            this.bApply1 = new System.Windows.Forms.Button();
            this.bApply2 = new System.Windows.Forms.Button();
            this.bApply3 = new System.Windows.Forms.Button();
            this.lResult = new System.Windows.Forms.DataGridView();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Measure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LongNote = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Hidden = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AdjTo64 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.D64 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D48 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.vBPM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lResult)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(35, 24);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(71, 15);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "BPM恒速器";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(24, 56);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(84, 15);
            this.Label4.TabIndex = 3;
            this.Label4.Text = "64线检查工具";
            // 
            // vBPM
            // 
            this.vBPM.DecimalPlaces = 4;
            this.vBPM.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.vBPM.Location = new System.Drawing.Point(109, 22);
            this.vBPM.Maximum = new decimal(new int[] {
            655359999,
            0,
            0,
            262144});
            this.vBPM.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.vBPM.Name = "vBPM";
            this.vBPM.Size = new System.Drawing.Size(168, 23);
            this.vBPM.TabIndex = 11;
            this.vBPM.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // bApply1
            // 
            this.bApply1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bApply1.Location = new System.Drawing.Point(283, 21);
            this.bApply1.Name = "bApply1";
            this.bApply1.Size = new System.Drawing.Size(249, 25);
            this.bApply1.TabIndex = 15;
            this.bApply1.Text = "恒速化";
            this.bApply1.UseVisualStyleBackColor = true;
            this.bApply1.Click += new System.EventHandler(this.bApply1_Click);
            // 
            // bApply2
            // 
            this.bApply2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bApply2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bApply2.Location = new System.Drawing.Point(109, 51);
            this.bApply2.Name = "bApply2";
            this.bApply2.Size = new System.Drawing.Size(196, 25);
            this.bApply2.TabIndex = 16;
            this.bApply2.Text = "检查";
            this.bApply2.UseVisualStyleBackColor = true;
            this.bApply2.Click += new System.EventHandler(this.bApply2_Click);
            // 
            // bApply3
            // 
            this.bApply3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bApply3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bApply3.Location = new System.Drawing.Point(311, 51);
            this.bApply3.Name = "bApply3";
            this.bApply3.Size = new System.Drawing.Size(221, 25);
            this.bApply3.TabIndex = 17;
            this.bApply3.Text = "自动对齐";
            this.bApply3.UseVisualStyleBackColor = true;
            this.bApply3.Click += new System.EventHandler(this.bApply3_Click);
            // 
            // lResult
            // 
            this.lResult.AllowUserToAddRows = false;
            this.lResult.AllowUserToDeleteRows = false;
            this.lResult.AllowUserToResizeColumns = false;
            this.lResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.lResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Index,
            this.Measure,
            this.ColumnName,
            this.Grid,
            this.LongNote,
            this.Hidden,
            this.AdjTo64,
            this.D64,
            this.D48});
            this.lResult.Location = new System.Drawing.Point(27, 82);
            this.lResult.Name = "lResult";
            this.lResult.RowHeadersWidth = 21;
            this.lResult.Size = new System.Drawing.Size(505, 448);
            this.lResult.TabIndex = 20;
            this.lResult.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.lResult_CellEndEdit);
            // 
            // Index
            // 
            this.Index.HeaderText = "序号";
            this.Index.Name = "Index";
            this.Index.ReadOnly = true;
            this.Index.Width = 45;
            // 
            // Measure
            // 
            this.Measure.HeaderText = "小节";
            this.Measure.Name = "Measure";
            this.Measure.ReadOnly = true;
            this.Measure.Width = 50;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "列";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnName.Width = 40;
            // 
            // Grid
            // 
            this.Grid.HeaderText = "格线";
            this.Grid.Name = "Grid";
            this.Grid.ReadOnly = true;
            this.Grid.Width = 37;
            // 
            // LongNote
            // 
            this.LongNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LongNote.HeaderText = "面条";
            this.LongNote.Name = "LongNote";
            this.LongNote.ReadOnly = true;
            this.LongNote.Width = 37;
            // 
            // Hidden
            // 
            this.Hidden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Hidden.HeaderText = "隐藏";
            this.Hidden.Name = "Hidden";
            this.Hidden.ReadOnly = true;
            this.Hidden.Width = 37;
            // 
            // AdjTo64
            // 
            this.AdjTo64.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AdjTo64.HeaderText = "对齐至64线";
            this.AdjTo64.Name = "AdjTo64";
            this.AdjTo64.Width = 73;
            // 
            // D64
            // 
            this.D64.HeaderText = "64线总偏差";
            this.D64.Name = "D64";
            this.D64.ReadOnly = true;
            this.D64.Width = 74;
            // 
            // D48
            // 
            this.D48.HeaderText = "48线总偏差";
            this.D48.Name = "D48";
            this.D48.ReadOnly = true;
            this.D48.Width = 74;
            // 
            // dgMyO2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(559, 552);
            this.Controls.Add(this.lResult);
            this.Controls.Add(this.bApply3);
            this.Controls.Add(this.bApply2);
            this.Controls.Add(this.bApply1);
            this.Controls.Add(this.vBPM);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "dgMyO2";
            this.Text = "MyO2 工具箱";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.vBPM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

internal Label Label1;
internal Label Label4;
internal NumericUpDown vBPM;
internal Button bApply1;
internal Button bApply2;
internal Button bApply3;
internal DataGridView lResult;
internal DataGridViewTextBoxColumn Index;
internal DataGridViewTextBoxColumn Measure;
internal DataGridViewTextBoxColumn ColumnName;
internal DataGridViewTextBoxColumn Grid;
internal DataGridViewCheckBoxColumn LongNote;
internal DataGridViewCheckBoxColumn Hidden;
internal DataGridViewCheckBoxColumn AdjTo64;
internal DataGridViewTextBoxColumn D64;
internal DataGridViewTextBoxColumn D48;
    }
}
