using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace iBMSC
{
    public partial class MainWindow
    {
        private void NewRecent(string xFileName)
        {
            bool xAlreadyExists = false;
            int xI1;

            for (xI1 = 0; xI1 <= 4; xI1++)
            {
                if ((this.Recent[xI1] ?? "") == (xFileName ?? ""))
                {
                    xAlreadyExists = true;
                    break;
                }
            }

            if (xAlreadyExists)
            {
                for (int xI2 = xI1; xI2 >= 1; xI2 -= 1)
                    this.Recent[xI2] = this.Recent[xI2 - 1];
                this.Recent[0] = xFileName;
            }

            else
            {
                this.Recent[4] = this.Recent[3];
                this.Recent[3] = this.Recent[2];
                this.Recent[2] = this.Recent[1];
                this.Recent[1] = this.Recent[0];
                this.Recent[0] = xFileName;
            }

            this.SetRecent(4, this.Recent[4]);
            this.SetRecent(3, this.Recent[3]);
            this.SetRecent(2, this.Recent[2]);
            this.SetRecent(1, this.Recent[1]);
            this.SetRecent(0, this.Recent[0]);
        }

        private void SetRecent(int Index, string Text)
        {
            Text = Text.Trim();

            ToolStripMenuItem xTBOpenR;
            ToolStripMenuItem xmnOpenR;
            switch (Index)
            {
                case 0:
                    {
                        xTBOpenR = this.TBOpenR0;
                        xmnOpenR = this.mnOpenR0;
                        break;
                    }
                case 1:
                    {
                        xTBOpenR = this.TBOpenR1;
                        xmnOpenR = this.mnOpenR1;
                        break;
                    }
                case 2:
                    {
                        xTBOpenR = this.TBOpenR2;
                        xmnOpenR = this.mnOpenR2;
                        break;
                    }
                case 3:
                    {
                        xTBOpenR = this.TBOpenR3;
                        xmnOpenR = this.mnOpenR3;
                        break;
                    }
                case 4:
                    {
                        xTBOpenR = this.TBOpenR4;
                        xmnOpenR = this.mnOpenR4;
                        break;
                    }

                default:
                    {
                        return;
                    }
            }

            xTBOpenR.Text = Conversions.ToString(Interaction.IIf(string.IsNullOrEmpty(Text), "<" + iBMSCStrings.None + ">", this.GetFileName(Text)));
            xTBOpenR.ToolTipText = Text;
            xTBOpenR.Enabled = !string.IsNullOrEmpty(Text);
            xmnOpenR.Text = Conversions.ToString(Interaction.IIf(string.IsNullOrEmpty(Text), "<" + iBMSCStrings.None + ">", this.GetFileName(Text)));
            xmnOpenR.ToolTipText = Text;
            xmnOpenR.Enabled = !string.IsNullOrEmpty(Text);
        }

        private void OpenRecent(string xFileName)
        {
            // KMouseDown = -1
            this.SelectedNotes = new iBMSC.Editor.Note[0];
            this.KMouseOver = -1;
            if (!File.Exists(xFileName))
            {
                Interaction.MsgBox(iBMSCStrings.Messages.CannotFind.Replace("{}", xFileName), MsgBoxStyle.Critical);
                return;
            }
            if (this.ClosingPopSave())
                return;

            switch (Strings.UCase(Path.GetExtension(xFileName)) ?? "")
            {
                case ".BMS":
                case ".BME":
                case ".BML":
                case ".PMS":
                case ".TXT":
                    {
                        this.InitPath = this.ExcludeFileName(xFileName);
                        this.SetFileName(xFileName);
                        this.ClearUndo();
                        this.OpenBMS(File.ReadAllText(xFileName, this.TextEncoding));
                        this.SetFileName(this.FileName);
                        this.SetIsSaved(true);
                        break;
                    }
                case ".IBMSC":
                    {
                        this.InitPath = this.ExcludeFileName(xFileName);
                        this.SetFileName("Imported_" + this.GetFileName(xFileName));
                        this.OpeniBMSC(xFileName);
                        this.SetIsSaved(false);
                        break;
                    }
            }
        }

        private void TBOpenR0_Click(object sender, EventArgs e)
        {
            this.OpenRecent(this.Recent[0]);
        }
        private void TBOpenR1_Click(object sender, EventArgs e)
        {
            this.OpenRecent(this.Recent[1]);
        }
        private void TBOpenR2_Click(object sender, EventArgs e)
        {
            this.OpenRecent(this.Recent[2]);
        }
        private void TBOpenR3_Click(object sender, EventArgs e)
        {
            this.OpenRecent(this.Recent[3]);
        }
        private void TBOpenR4_Click(object sender, EventArgs e)
        {
            this.OpenRecent(this.Recent[4]);
        }

    }
}