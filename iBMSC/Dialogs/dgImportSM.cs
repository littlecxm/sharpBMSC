using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using iBMSC.My;
using Microsoft.VisualBasic.CompilerServices;

namespace iBMSC;

[DesignerGenerated]
public partial  class dgImportSM : Form
{
    public int iResult;

    public dgImportSM(string[] sDiff)
    {
        Load += dgImportSM_Load;
        iResult = -1;
        InitializeComponent();
        LDiff.Items.AddRange(sDiff);
        LDiff.SelectedIndex = 0;
    }

    private void OK_Button_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
        iResult = LDiff.SelectedIndex;
        Close();
    }

    private void Cancel_Button_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void dgImportSM_Load(object sender, EventArgs e)
    {
        Font = MyProject.Forms.MainWindow.Font;
        Text = Strings1.fImportSM.Title;
        Label7.Text = Strings1.fImportSM.Difficulty;
        Label5.Text = Strings1.fImportSM.Note;
        OK_Button.Text = Strings1.OK;
        Cancel_Button.Text = Strings1.Cancel;
    }
}
