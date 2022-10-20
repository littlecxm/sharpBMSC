using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace iBMSC
{
    public partial class AboutBox1 : Form
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
            this.ClickToCopy = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ClickToCopy
            // 
            this.ClickToCopy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClickToCopy.Location = new System.Drawing.Point(540, 355);
            this.ClickToCopy.Name = "ClickToCopy";
            this.ClickToCopy.Size = new System.Drawing.Size(131, 23);
            this.ClickToCopy.TabIndex = 1;
            this.ClickToCopy.Tag = "620, 288";
            this.ClickToCopy.Text = "Click to copy";
            this.ClickToCopy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ClickToCopy.Visible = false;
            this.ClickToCopy.Click += new System.EventHandler(this.ClickToCopy_Click);
            // 
            // Label1
            // 
            this.Label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Label1.Location = new System.Drawing.Point(620, 288);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(96, 21);
            this.Label1.TabIndex = 2;
            this.Label1.Tag = "620, 288";
            this.Label1.Text = "Click to copy";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Label1.Visible = false;
            // 
            // AboutBox1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.ClickToCopy);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox1";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.ResumeLayout(false);

    }

internal Label ClickToCopy;
internal Label Label1;
    }
}
