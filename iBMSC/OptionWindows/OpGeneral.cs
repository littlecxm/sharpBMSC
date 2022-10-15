using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace iBMSC
{

    public partial class OpGeneral
    {
        public int zWheel;
        public int zPgUpDn;
        public System.Text.Encoding zEncoding;
        public int zMiddle;
        // Public zSort As Integer
        public int zAutoSave;
        public int zGridPartition;

        // Dim lpfa() As String

        [DllImport("shell32.dll")]
        public static extern void SHChangeNotify(int wEventId, int uFlags, int dwItem1, int dwItem2);

        private void OK_Button_Click(object sender, EventArgs e)
        {

            switch (this.CWheel.SelectedIndex)
            {
                case 0:
                    {
                        zWheel = 192;
                        break;
                    }
                case 1:
                    {
                        zWheel = 96;
                        break;
                    }
                case 2:
                    {
                        zWheel = 64;
                        break;
                    }
                case 3:
                    {
                        zWheel = 48;
                        break;
                    }
            }
            switch (this.CPgUpDn.SelectedIndex)
            {
                case 0:
                    {
                        zPgUpDn = 1536;
                        break;
                    }
                case 1:
                    {
                        zPgUpDn = 1152;
                        break;
                    }
                case 2:
                    {
                        zPgUpDn = 768;
                        break;
                    }
                case 3:
                    {
                        zPgUpDn = 576;
                        break;
                    }
                case 4:
                    {
                        zPgUpDn = 384;
                        break;
                    }
                case 5:
                    {
                        zPgUpDn = 192;
                        break;
                    }
                case 6:
                    {
                        zPgUpDn = 96;
                        break;
                    }
            }
            switch (this.CTextEncoding.SelectedIndex)
            {
                case 0:
                    {
                        zEncoding = System.Text.Encoding.Default;
                        break;
                    }
                case 1:
                    {
                        zEncoding = System.Text.Encoding.Unicode;
                        break;
                    }
                case 2:
                    {
                        zEncoding = System.Text.Encoding.ASCII;
                        break;
                    }
                case 3:
                    {
                        zEncoding = System.Text.Encoding.BigEndianUnicode;
                        break;
                    }
                case 4:
                    {
                        zEncoding = System.Text.Encoding.UTF32;
                        break;
                    }
                case 5:
                    {
                        zEncoding = System.Text.Encoding.UTF7;
                        break;
                    }
                case 6:
                    {
                        zEncoding = System.Text.Encoding.UTF8;
                        break;
                    }
                case 7:
                    {
                        zEncoding = System.Text.Encoding.GetEncoding(932);
                        break;
                    }
                case 8:
                    {
                        zEncoding = System.Text.Encoding.GetEncoding(51949);
                        break;
                    }
            }
            // zSort = CSortingMethod.SelectedIndex
            zMiddle = Conversions.ToInteger(Interaction.IIf(this.rMiddleDrag.Checked, (object)1, (object)0));
            zAutoSave = Conversions.ToInteger(Operators.MultiplyObject(Operators.MultiplyObject(Interaction.IIf(this.cAutoSave.Checked, (object)1, (object)0), this.NAutoSave.Value), 60000));
            zGridPartition = (int)Math.Round(this.nGridPartition.Value);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public OpGeneral(int xMsWheel, int xPgUpDn, int xMiddleButton, int xTextEncoding, int xGridPartition, int xAutoSave, bool xBeep, bool xBPMx, bool xSTOPx, bool xMFEnter, bool xMFClick, bool xMStopPreview)

        {
            this.InitializeComponent();
            switch (xMsWheel)
            {
                case 192:
                    {
                        this.CWheel.SelectedIndex = 0;
                        break;
                    }
                case 96:
                    {
                        this.CWheel.SelectedIndex = 1;
                        break;
                    }
                case 64:
                    {
                        this.CWheel.SelectedIndex = 2;
                        break;
                    }
                case 48:
                    {
                        this.CWheel.SelectedIndex = 3;
                        break;
                    }
            }

            switch (xPgUpDn)
            {
                case 1536:
                    {
                        this.CPgUpDn.SelectedIndex = 0;
                        break;
                    }
                case 1152:
                    {
                        this.CPgUpDn.SelectedIndex = 1;
                        break;
                    }
                case 768:
                    {
                        this.CPgUpDn.SelectedIndex = 2;
                        break;
                    }
                case 576:
                    {
                        this.CPgUpDn.SelectedIndex = 3;
                        break;
                    }
                case 384:
                    {
                        this.CPgUpDn.SelectedIndex = 4;
                        break;
                    }
                case 192:
                    {
                        this.CPgUpDn.SelectedIndex = 5;
                        break;
                    }
                case 96:
                    {
                        this.CPgUpDn.SelectedIndex = 6;
                        break;
                    }
            }

            this.CTextEncoding.SelectedIndex = xTextEncoding;
            // CSortingMethod.SelectedIndex = xSort
            this.nGridPartition.Value = (decimal)xGridPartition;

            if (xMiddleButton == 0)
                this.rMiddleAuto.Checked = true;
            else
                this.rMiddleDrag.Checked = true;

            if (xAutoSave / 60000d > (double)this.NAutoSave.Maximum | xAutoSave / 60000d < (double)this.NAutoSave.Minimum)
            {
                this.cAutoSave.Checked = false;
            }
            else
            {
                this.NAutoSave.Value = (decimal)(xAutoSave / 60000d);
            }

            this.cBeep.Checked = xBeep;
            this.cBpm1296.Checked = xBPMx;
            this.cStop1296.Checked = xSTOPx;
            this.cMEnterFocus.Checked = xMFEnter;
            this.cMClickFocus.Checked = xMFClick;
            this.cMStopPreview.Checked = xMStopPreview;
        }

        private void OpGeneral_Load(object sender, EventArgs e)
        {
            var mainWindow = new MainWindow();
            this.Font = mainWindow.Font;

            // lpfa = Form1.lpfa
            // Dim xL() As String = Form1.lpgo
            this.Text = iBMSC.Strings.fopGeneral.Title;
            this.Label1.Text = iBMSC.Strings.fopGeneral.MouseWheel;
            this.Label2.Text = iBMSC.Strings.fopGeneral.TextEncoding;
            // Label3.Text = Locale.fopGeneral.SortingMethod
            this.Label5.Text = iBMSC.Strings.fopGeneral.PageUpDown;
            this.Label3.Text = iBMSC.Strings.fopGeneral.MiddleButton;
            this.Label4.Text = iBMSC.Strings.fopGeneral.AssociateFileType;
            // CSortingMethod.Items.Item(0) = Locale.fopGeneral.sortBubble
            // CSortingMethod.Items.Item(1) = Locale.fopGeneral.sortInsertion
            // CSortingMethod.Items.Item(2) = Locale.fopGeneral.sortQuick
            // CSortingMethod.Items.Item(3) = Locale.fopGeneral.sortQuickD3
            // CSortingMethod.Items.Item(4) = Locale.fopGeneral.sortHeap
            this.rMiddleAuto.Text = iBMSC.Strings.fopGeneral.MiddleButtonAuto;
            this.rMiddleDrag.Text = iBMSC.Strings.fopGeneral.MiddleButtonDrag;
            this.Label6.Text = iBMSC.Strings.fopGeneral.MaxGridPartition;

            this.cBeep.Text = iBMSC.Strings.fopGeneral.BeepWhileSaved;
            this.cBpm1296.Text = iBMSC.Strings.fopGeneral.ExtendBPM;
            this.cStop1296.Text = iBMSC.Strings.fopGeneral.ExtendSTOP;
            this.cMEnterFocus.Text = iBMSC.Strings.fopGeneral.AutoFocusOnMouseEnter;
            this.cMClickFocus.Text = iBMSC.Strings.fopGeneral.DisableFirstClick;
            this.cAutoSave.Text = iBMSC.Strings.fopGeneral.AutoSave;
            this.Label7.Text = iBMSC.Strings.fopGeneral.minutes;
            this.cMStopPreview.Text = iBMSC.Strings.fopGeneral.StopPreviewOnClick;

            var enc = System.Text.Encoding.Default;
            this.CTextEncoding.Items[0] = "System ANSI (" + enc.EncodingName + ")";

            this.OK_Button.Text = iBMSC.Strings.OK;
            this.Cancel_Button.Text = iBMSC.Strings.Cancel;
        }

        private void TBAssociate_Click(object sender, EventArgs e)
        {
            this.Associate(".bms", "iBMSC.BMS", iBMSC.Strings.FileAssociation.BMS, false);
        }

        private void TBAssociateIBMSC_Click(object sender, EventArgs e)
        {
            this.Associate(".ibmsc", "iBMSC.iBMSC", iBMSC.Strings.FileAssociation.IBMSC, true);
        }

        private void TBAssociateBME_Click(object sender, EventArgs e)
        {
            this.Associate(".bme", "iBMSC.BME", iBMSC.Strings.FileAssociation.BME, false);
        }

        private void TBAssociateBML_Click(object sender, EventArgs e)
        {
            this.Associate(".bml", "iBMSC.BML", iBMSC.Strings.FileAssociation.BML, false);
        }

        private void TBAssociatePMS_Click(object sender, EventArgs e)
        {
            this.Associate(".pms", "iBMSC.PMS", iBMSC.Strings.FileAssociation.PMS, false);
        }

        private void Associate(string xExt, string xClass, string xDescription, bool isIBMSC)
        {
            if (Interaction.MsgBox(iBMSC.Strings.Messages.FileAssociationPrompt.Replace("{}", "*" + xExt), MsgBoxStyle.YesNo | MsgBoxStyle.Question) != MsgBoxResult.Yes)
                return;

            Microsoft.Win32.RegistryKey xReg;

            try
            {
                {
                    var withBlock = Microsoft.Win32.Registry.ClassesRoot;
                    if (Array.IndexOf(withBlock.GetSubKeyNames(), xExt) != -1)
                        withBlock.DeleteSubKeyTree(xExt);
                    withBlock.CreateSubKey(xExt);
                    xReg = withBlock.OpenSubKey(xExt, true);
                    xReg.SetValue("", xClass, Microsoft.Win32.RegistryValueKind.String);

                    if (Array.IndexOf(withBlock.GetSubKeyNames(), xClass) != -1)
                        withBlock.DeleteSubKeyTree(xClass);
                    withBlock.CreateSubKey(xClass);
                    xReg = withBlock.OpenSubKey(xClass, true);
                    xReg.SetValue("", xDescription, Microsoft.Win32.RegistryValueKind.String);

                    // Default Icon
                    xReg.CreateSubKey("DefaultIcon");
                    xReg = withBlock.OpenSubKey(xClass + @"\DefaultIcon", true);
                    xReg.SetValue("", Application.ExecutablePath + @"\TypeBMS.ico", Microsoft.Win32.RegistryValueKind.String);

                    xReg = withBlock.OpenSubKey(xClass, true);
                    xReg.CreateSubKey("shell");
                    xReg = withBlock.OpenSubKey(xClass + @"\shell", true);
                    xReg.SetValue("", "open");

                    xReg = withBlock.OpenSubKey(xClass + @"\shell", true);
                    xReg.CreateSubKey(@"open\command");
                    xReg = withBlock.OpenSubKey(xClass + @"\shell\open", true);
                    xReg.SetValue("", iBMSC.Strings.FileAssociation.Open);
                    xReg = withBlock.OpenSubKey(xClass + @"\shell\open\command", true);
                    xReg.SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"");

                    if (!isIBMSC)
                    {
                        xReg = withBlock.OpenSubKey(xClass + @"\shell", true);
                        xReg.CreateSubKey(@"preview\command");
                        xReg = withBlock.OpenSubKey(xClass + @"\shell\preview", true);
                        xReg.SetValue("", iBMSC.Strings.FileAssociation.Preview);
                        xReg = withBlock.OpenSubKey(xClass + @"\shell\preview\command", true);
                        xReg.SetValue("", "\"" + Application.ExecutablePath + @"\uBMplay.exe" + "\" \"%1\"");

                        xReg = withBlock.OpenSubKey(xClass + @"\shell", true);
                        xReg.CreateSubKey(@"viewcode\command");
                        xReg = withBlock.OpenSubKey(xClass + @"\shell\viewcode", true);
                        xReg.SetValue("", iBMSC.Strings.FileAssociation.ViewCode);
                        xReg = withBlock.OpenSubKey(xClass + @"\shell\viewcode\command", true);
                        xReg.SetValue("", Environment.SystemDirectory + @"\notepad.exe %1");
                    }
                }

                {
                    var withBlock1 = Microsoft.Win32.Registry.CurrentUser;
                    withBlock1.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\" + xExt);

                    xReg = withBlock1.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\" + xExt, true);
                    // xReg.DeleteSubKey("UserChoice")
                    xReg.CreateSubKey("UserChoice");
                    xReg = withBlock1.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\" + xExt + @"\UserChoice", true);
                    xReg.SetValue("Progid", xClass);
                }
            }

            catch (Exception ex)
            {
                Interaction.MsgBox(iBMSC.Strings.Messages.FileAssociationError + Constants.vbCrLf + Constants.vbCrLf + ex.Message, MsgBoxStyle.Exclamation, iBMSC.Strings.Messages.Err);
            }

            SHChangeNotify(0x8000000, 0, 0, 0);
            Interaction.Beep();
        }

        // Private Sub TBAssociateE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBAssociatePMS.Click
        // If MsgBox(Replace(Locale.Messages.FileAssociationPrompt, "{}", "*.bme, *.bml"), MsgBoxStyle.YesNo + MsgBoxStyle.Question) <> MsgBoxResult.Yes Then Exit Sub
        // 
        // Dim xReg As Microsoft.Win32.RegistryKey
        // On Error GoTo Jump1
        // 
        // Dim xExt As String = ".bme"
        // Dim xCtg As String = "iBMSC.BME"
        // 
        // Jump2:
        // 
        // With Microsoft.Win32.Registry.ClassesRoot
        // If Array.IndexOf(.GetSubKeyNames(), xExt) <> -1 Then .DeleteSubKeyTree(xExt)
        // .CreateSubKey(xExt)
        // xReg = .OpenSubKey(xExt, True)
        // xReg.SetValue("", xCtg, Microsoft.Win32.RegistryValueKind.String)
        // 
        // If Array.IndexOf(.GetSubKeyNames(), xCtg) <> -1 Then .DeleteSubKeyTree(xCtg)
        // .CreateSubKey(xCtg)
        // xReg = .OpenSubKey(xCtg, True)
        // xReg.SetValue("", lpfa(0), Microsoft.Win32.RegistryValueKind.String)
        // 
        // xReg.CreateSubKey("DefaultIcon")
        // xReg = .OpenSubKey(xCtg & "\DefaultIcon", True)
        // 'xReg.SetValue("", My.Application.Info.DirectoryPath & "\TypeBMS.ico", Microsoft.Win32.RegistryValueKind.String)
        // 
        // xReg = .OpenSubKey(xCtg, True)
        // xReg.CreateSubKey("shell")
        // xReg = .OpenSubKey(xCtg & "\shell", True)
        // xReg.SetValue("", "open")
        // 
        // xReg.CreateSubKey("open\command")
        // xReg.CreateSubKey("preview\command")
        // xReg.CreateSubKey("viewcode\command")
        // 
        // xReg = .OpenSubKey(xCtg & "\shell\open", True)
        // xReg.SetValue("", lpfa(1))
        // xReg = .OpenSubKey(xCtg & "\shell\preview", True)
        // xReg.SetValue("", lpfa(2))
        // xReg = .OpenSubKey(xCtg & "\shell\viewcode", True)
        // xReg.SetValue("", lpfa(3))
        // 
        // xReg = .OpenSubKey(xCtg & "\shell\open\command", True)
        // xReg.SetValue("", """" & Application.ExecutablePath & """ ""%1""")
        // xReg = .OpenSubKey(xCtg & "\shell\preview\command", True)
        // xReg.SetValue("", """" & My.Application.Info.DirectoryPath & "\uBMplay.exe" & """ ""%1""")
        // xReg = .OpenSubKey(xCtg & "\shell\viewcode\command", True)
        // xReg.SetValue("", Environment.SystemDirectory & "\notepad.exe %1")
        // End With
        // 
        // With Microsoft.Win32.Registry.CurrentUser
        // .CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\" & xExt)
        // 
        // xReg = .OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\" & xExt, True)
        // xReg.CreateSubKey("UserChoice")
        // xReg = .OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\" & xExt & "\UserChoice", True)
        // xReg.SetValue("Progid", xCtg)
        // End With
        // 
        // If xExt <> ".bml" Or xCtg <> "iBMSC.BML" Then
        // xExt = ".bml"
        // xCtg = "iBMSC.BML"
        // GoTo Jump2
        // End If
        // 
        // Jump1:
        // Beep()
        // End Sub

        // Private Sub TBAssociateIBMSC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBAssociateIBMSC.Click
        // If MsgBox(Replace(Locale.Messages.FileAssociationPrompt, "{}", "*.ibmsc"), MsgBoxStyle.YesNo + MsgBoxStyle.Question) <> MsgBoxResult.Yes Then Exit Sub
        // 
        // Dim xReg As Microsoft.Win32.RegistryKey
        // On Error GoTo Jump1
        // 
        // Dim xExt As String = ".ibmsc"
        // Dim xCtg As String = "iBMSC.iBMSC"
        // 
        // With Microsoft.Win32.Registry.ClassesRoot
        // If Array.IndexOf(.GetSubKeyNames(), xExt) <> -1 Then .DeleteSubKeyTree(xExt)
        // .CreateSubKey(xExt)
        // xReg = .OpenSubKey(xExt, True)
        // xReg.SetValue("", xCtg, Microsoft.Win32.RegistryValueKind.String)
        // 
        // If Array.IndexOf(.GetSubKeyNames(), xCtg) <> -1 Then .DeleteSubKeyTree(xCtg)
        // .CreateSubKey(xCtg)
        // xReg = .OpenSubKey(xCtg, True)
        // xReg.SetValue("", lpfa(0), Microsoft.Win32.RegistryValueKind.String)
        // 
        // xReg.CreateSubKey("DefaultIcon")
        // xReg = .OpenSubKey(xCtg & "\DefaultIcon", True)
        // 'xReg.SetValue("", My.Application.Info.DirectoryPath & "\TypeBMS.ico", Microsoft.Win32.RegistryValueKind.String)
        // 
        // xReg = .OpenSubKey(xCtg, True)
        // xReg.CreateSubKey("shell")
        // xReg = .OpenSubKey(xCtg & "\shell", True)
        // xReg.SetValue("", "open")
        // 
        // xReg.CreateSubKey("open\command")
        // 'xReg.CreateSubKey("preview\command")
        // xReg.CreateSubKey("viewcode\command")
        // 
        // xReg = .OpenSubKey(xCtg & "\shell\open", True)
        // xReg.SetValue("", lpfa(1))
        // 'xReg = .OpenSubKey(xCtg & "\shell\preview", True)
        // 'xReg.SetValue("", lpfa(2))
        // xReg = .OpenSubKey(xCtg & "\shell\viewcode", True)
        // xReg.SetValue("", lpfa(3))
        // 
        // xReg = .OpenSubKey(xCtg & "\shell\open\command", True)
        // xReg.SetValue("", """" & Application.ExecutablePath & """ ""%1""")
        // 'xReg = .OpenSubKey(xCtg & "\shell\preview\command", True)
        // 'xReg.SetValue("", """" & My.Application.Info.DirectoryPath & "\uBMplay.exe" & """ ""%1""")
        // xReg = .OpenSubKey(xCtg & "\shell\viewcode\command", True)
        // xReg.SetValue("", Environment.SystemDirectory & "\notepad.exe %1")
        // End With
        // 
        // With Microsoft.Win32.Registry.CurrentUser
        // .CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\" & xExt)
        // 
        // xReg = .OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\" & xExt, True)
        // xReg.CreateSubKey("UserChoice")
        // xReg = .OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\" & xExt & "\UserChoice", True)
        // xReg.SetValue("Progid", xCtg)
        // End With
        // 
        // Jump1:
        // Beep()
        // End Sub

        private void cAutoSave_CheckedChanged(object sender, EventArgs e)
        {
            this.NAutoSave.Enabled = this.cAutoSave.Checked;
        }
    }
}