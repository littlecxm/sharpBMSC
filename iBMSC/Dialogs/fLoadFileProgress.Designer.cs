using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace iBMSC
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class fLoadFileProgress : Form
    {

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
            Cancel_Button = new Button();
            Cancel_Button.Click += new EventHandler(Cancel_Button_Click);
            prog = new ProgressBar();
            Label1 = new Label();
            SuspendLayout();
            // 
            // Cancel_Button
            // 
            Cancel_Button.Anchor = AnchorStyles.Bottom;
            Cancel_Button.DialogResult = DialogResult.Cancel;
            Cancel_Button.Location = new Point(245, 81);
            Cancel_Button.Name = "Cancel_Button";
            Cancel_Button.Size = new Size(120, 27);
            Cancel_Button.TabIndex = 1;
            Cancel_Button.Text = "Cancel";
            // 
            // prog
            // 
            prog.Location = new Point(15, 60);
            prog.Name = "prog";
            prog.Size = new Size(584, 15);
            prog.TabIndex = 2;
            // 
            // Label1
            // 
            Label1.Location = new Point(12, 9);
            Label1.Name = "Label1";
            Label1.Size = new Size(587, 48);
            Label1.TabIndex = 3;
            Label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // fLoadFileProgress
            // 
            AcceptButton = Cancel_Button;
            AutoScaleMode = AutoScaleMode.None;
            CancelButton = Cancel_Button;
            ClientSize = new Size(611, 120);
            ControlBox = false;
            Controls.Add(Label1);
            Controls.Add(prog);
            Controls.Add(Cancel_Button);
            Font = new Font("Segoe UI", 9.0f, FontStyle.Regular, GraphicsUnit.Point, 134);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "fLoadFileProgress";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Loading Files";
            TopMost = true;
            Shown += new EventHandler(fLoadFileProgress_Shown);
            Load += new EventHandler(fLoadFileProgress_Load);
            ResumeLayout(false);

        }
        internal Button Cancel_Button;
        internal ProgressBar prog;
        internal Label Label1;

    }
}