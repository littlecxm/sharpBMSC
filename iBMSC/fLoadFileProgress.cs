using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using iBMSC.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace iBMSC;

[DesignerGenerated]
public partial  class fLoadFileProgress : Form
{
    private string[] xPath;

    private bool CancelPressed;

    private bool IsSaved;

    public fLoadFileProgress(string[] xxPath, bool xIsSaved, bool TopMost = true)
    {
        base.Shown += fLoadFileProgress_Shown;
        base.Load += fLoadFileProgress_Load;
        xPath = new string[0];
        CancelPressed = false;
        IsSaved = false;
        InitializeComponent();
        prog.Maximum = checked(Information.UBound(xxPath) + 1);
        xPath = xxPath;
        IsSaved = xIsSaved;
        this.TopMost = TopMost;
    }

    private void Cancel_Button_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        CancelPressed = true;
        Close();
    }

    private void fLoadFileProgress_Shown(object sender, EventArgs e)
    {
        int try0000_dispatch = -1;
        int num2 = default(int);
        int num = default(int);
        while (true)
        {
            try
            {
                /*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
                checked
                {
                    switch (try0000_dispatch)
                    {
                    default:
                    {
                        ProjectData.ClearProjectError();
                        num2 = 0;
                        int num3 = Information.UBound(xPath);
                        for (int i = 0; i <= num3; i++)
                        {
                            Label1.Text = "Currently loading ( " + Conversions.ToString(i + 1) + " / " + Conversions.ToString(Information.UBound(xPath) + 1) + " ): " + xPath[i];
                            int maximum = prog.Maximum;
                            int value = prog.Value;
                            prog.Value = i;
                            Application.DoEvents();
                            if (CancelPressed)
                            {
                                break;
                            }
                            if (i == 0 && IsSaved)
                            {
                                MyProject.Forms.MainWindow.ReadFile(xPath[i]);
                            }
                            else
                            {
                                Process.Start(Application.ExecutablePath, "\"" + xPath[i] + "\"");
                            }
                        }
                        Close();
                        goto end_IL_0000;
                    }
                    case 269:
                        num = -1;
                        switch (num2)
                        {
                        }
                        break;
                    }
                    goto IL_0143;
                }
                end_IL_0000:;
            }
            catch (Exception obj) when (num2 != 0 && num == 0)
            {
                ProjectData.SetProjectError(obj);
                try0000_dispatch = 269;
                continue;
            }
            break;
            IL_0143:
            throw ProjectData.CreateProjectError(-2146828237);
        }
        if (num != 0)
        {
            ProjectData.ClearProjectError();
        }
    }

    private void fLoadFileProgress_Load(object sender, EventArgs e)
    {
        Font = MyProject.Forms.MainWindow.Font;
        Cancel_Button.Text = Strings.Cancel;
    }
}
