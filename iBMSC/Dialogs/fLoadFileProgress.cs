using System;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace iBMSC
{

    public partial class fLoadFileProgress
    {
        private string[] xPath = new string[0];
        private bool CancelPressed = false;
        private bool IsSaved = false;

        public fLoadFileProgress(string[] xxPath, bool xIsSaved, bool TopMost = true)
        {
            this.InitializeComponent();
            this.prog.Maximum = Information.UBound(xxPath) + 1;
            xPath = xxPath;
            IsSaved = xIsSaved;
            this.TopMost = TopMost;
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            CancelPressed = true;
            this.Close();
        }

        private void fLoadFileProgress_Shown(object sender, EventArgs e)
        {
            try
            {
                for (int xI1 = 0, loopTo = Information.UBound(xPath); xI1 <= loopTo; xI1++)
                {
                    this.Label1.Text = "Currently loading ( " + (xI1 + 1) + " / " + (Information.UBound(xPath) + 1) + " ): " + xPath[xI1];
                    int aa = this.prog.Maximum;
                    int bb = this.prog.Value;
                    this.prog.Value = xI1;
                    Application.DoEvents();
                    if (CancelPressed)
                        break;

                    if (xI1 == 0 && IsSaved)
                    {
                        var window = new MainWindow();
                        window.ReadFile(xPath[xI1]);
                    }

                    else
                        Process.Start(Application.ExecutablePath, "\"" + xPath[xI1] + "\""); // Shell("""" & Application.ExecutablePath & """ """ & xPaths(xI1) & """") ' 
                }
            }
            catch (Exception ex)
            {

            }

            this.Close();
        }

        private void fLoadFileProgress_Load(object sender, EventArgs e)
        {
            var window = new MainWindow();
            this.Font = window.Font;
            this.Cancel_Button.Text = iBMSC.Strings.Cancel;
        }
    }
}