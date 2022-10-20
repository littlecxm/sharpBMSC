using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace iBMSC
{
    public partial class dgStatistics : Form
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
            this.lIcon = new System.Windows.Forms.Label();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.TableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OK_Button
            // 
            this.OK_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OK_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.OK_Button.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.OK_Button.Location = new System.Drawing.Point(381, 188);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(78, 27);
            this.OK_Button.TabIndex = 0;
            this.OK_Button.Text = "OK";
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // lIcon
            // 
            this.lIcon.Image = global::iBMSC.Resources.Statistics3;
            this.lIcon.Location = new System.Drawing.Point(12, 9);
            this.lIcon.Name = "lIcon";
            this.lIcon.Size = new System.Drawing.Size(42, 42);
            this.lIcon.TabIndex = 1;
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.ColumnCount = 7;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel1.Controls.Add(this.Label2, 5, 0);
            this.TableLayoutPanel1.Controls.Add(this.Label15, 4, 0);
            this.TableLayoutPanel1.Controls.Add(this.Label1, 0, 6);
            this.TableLayoutPanel1.Controls.Add(this.Label6, 0, 1);
            this.TableLayoutPanel1.Controls.Add(this.Label7, 0, 2);
            this.TableLayoutPanel1.Controls.Add(this.Label8, 0, 3);
            this.TableLayoutPanel1.Controls.Add(this.Label9, 0, 4);
            this.TableLayoutPanel1.Controls.Add(this.Label10, 0, 5);
            this.TableLayoutPanel1.Controls.Add(this.Label11, 1, 0);
            this.TableLayoutPanel1.Controls.Add(this.Label12, 2, 0);
            this.TableLayoutPanel1.Controls.Add(this.Label13, 3, 0);
            this.TableLayoutPanel1.Controls.Add(this.Label14, 4, 0);
            this.TableLayoutPanel1.Location = new System.Drawing.Point(64, 12);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 7;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(387, 164);
            this.TableLayoutPanel1.TabIndex = 12;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label2.Location = new System.Drawing.Point(330, 0);
            this.Label2.Margin = new System.Windows.Forms.Padding(0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(57, 25);
            this.Label2.TabIndex = 16;
            this.Label2.Text = "Total";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label15.Location = new System.Drawing.Point(274, 0);
            this.Label15.Margin = new System.Windows.Forms.Padding(0);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(56, 25);
            this.Label15.TabIndex = 15;
            this.Label15.Text = "Errors";
            this.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label1.Location = new System.Drawing.Point(0, 140);
            this.Label1.Margin = new System.Windows.Forms.Padding(0);
            this.Label1.Name = "Label1";
            this.Label1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.Label1.Size = new System.Drawing.Size(50, 24);
            this.Label1.TabIndex = 14;
            this.Label1.Text = "Total";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label6.Location = new System.Drawing.Point(0, 25);
            this.Label6.Margin = new System.Windows.Forms.Padding(0);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.Label6.Size = new System.Drawing.Size(50, 23);
            this.Label6.TabIndex = 13;
            this.Label6.Text = "BPM";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label7.Location = new System.Drawing.Point(0, 48);
            this.Label7.Margin = new System.Windows.Forms.Padding(0);
            this.Label7.Name = "Label7";
            this.Label7.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.Label7.Size = new System.Drawing.Size(50, 23);
            this.Label7.TabIndex = 13;
            this.Label7.Text = "STOP";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label8.Location = new System.Drawing.Point(0, 71);
            this.Label8.Margin = new System.Windows.Forms.Padding(0);
            this.Label8.Name = "Label8";
            this.Label8.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.Label8.Size = new System.Drawing.Size(50, 23);
            this.Label8.TabIndex = 13;
            this.Label8.Text = "A1-A8";
            this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label9.Location = new System.Drawing.Point(0, 94);
            this.Label9.Margin = new System.Windows.Forms.Padding(0);
            this.Label9.Name = "Label9";
            this.Label9.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.Label9.Size = new System.Drawing.Size(50, 23);
            this.Label9.TabIndex = 13;
            this.Label9.Text = "D1-D8";
            this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label10.Location = new System.Drawing.Point(0, 117);
            this.Label10.Margin = new System.Windows.Forms.Padding(0);
            this.Label10.Name = "Label10";
            this.Label10.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.Label10.Size = new System.Drawing.Size(50, 23);
            this.Label10.TabIndex = 13;
            this.Label10.Text = "BGM";
            this.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label11.Location = new System.Drawing.Point(50, 0);
            this.Label11.Margin = new System.Windows.Forms.Padding(0);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(56, 25);
            this.Label11.TabIndex = 13;
            this.Label11.Text = "Short";
            this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label12.Location = new System.Drawing.Point(106, 0);
            this.Label12.Margin = new System.Windows.Forms.Padding(0);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(56, 25);
            this.Label12.TabIndex = 13;
            this.Label12.Text = "Long";
            this.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label13.Location = new System.Drawing.Point(162, 0);
            this.Label13.Margin = new System.Windows.Forms.Padding(0);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(56, 25);
            this.Label13.TabIndex = 13;
            this.Label13.Text = "LnObj";
            this.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label14.Location = new System.Drawing.Point(218, 0);
            this.Label14.Margin = new System.Windows.Forms.Padding(0);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(56, 25);
            this.Label14.TabIndex = 13;
            this.Label14.Text = "Hidden";
            this.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgStatistics
            // 
            this.AcceptButton = this.OK_Button;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.OK_Button;
            this.ClientSize = new System.Drawing.Size(482, 230);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Controls.Add(this.lIcon);
            this.Controls.Add(this.OK_Button);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dgStatistics";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Statistics";
            this.TableLayoutPanel1.ResumeLayout(false);
            this.TableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

    }

internal Button OK_Button;
internal Label lIcon;
internal TableLayoutPanel TableLayoutPanel1;
internal Label Label6;
internal Label Label15;
internal Label Label1;
internal Label Label7;
internal Label Label8;
internal Label Label9;
internal Label Label10;
internal Label Label11;
internal Label Label12;
internal Label Label13;
internal Label Label14;
internal Label Label2;
    }
}
