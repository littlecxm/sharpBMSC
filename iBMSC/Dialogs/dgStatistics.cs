using System;
using System.Drawing;
using System.Windows.Forms;
using iBMSC.My;
using Microsoft.VisualBasic.CompilerServices;

namespace iBMSC;

[DesignerGenerated]
public partial class dgStatistics : Form
{
    private void OK_Button_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
        Close();
    }

    private void Cancel_Button_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void dgStatistics_Load(object sender, EventArgs e)
    {
        Font = MyProject.Forms.MainWindow.Font;
        Text = Strings1.fStatistics.Title;
        Label6.Text = Strings1.fStatistics.lBPM;
        Label7.Text = Strings1.fStatistics.lSTOP;
        Label8.Text = Strings1.fStatistics.lA;
        Label9.Text = Strings1.fStatistics.lD;
        Label10.Text = Strings1.fStatistics.lBGM;
        Label1.Text = Strings1.fStatistics.lTotal;
        Label11.Text = Strings1.fStatistics.lShort;
        Label12.Text = Strings1.fStatistics.lLong;
        Label13.Text = Strings1.fStatistics.lLnObj;
        Label14.Text = Strings1.fStatistics.lHidden;
        Label15.Text = Strings1.fStatistics.lErrors;
        Label2.Text = Strings1.fStatistics.lTotal;
        OK_Button.Text = Strings1.OK;
    }

    public dgStatistics(int[,] data)
    {
        Load += dgStatistics_Load;
        InitializeComponent();
        var num = 0;

        do
        {
            var num2 = 0;
            do
            {
                var label = new Label
                {
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                var margin = new Padding(0);
                label.Margin = margin;
                label.Font = new Font(Font, FontStyle.Bold);
                if (data[num, num2] != 0)
                {
                    label.Text = Conversions.ToString(data[num, num2]);
                }

                if (num % 2 == 0)
                {
                    label.BackColor = Color.FromArgb(268435456);
                }

                TableLayoutPanel1.Controls.Add(label, num2 + 1, num + 1);
                num2++;
            } while (num2 <= 5);

            num++;
        } while (num <= 5);
    }
}
