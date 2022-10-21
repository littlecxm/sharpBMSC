using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using iBMSC.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;

namespace iBMSC;

[DesignerGenerated]
public partial  class OpGeneral : Form
{
    public int zWheel;

    public int zPgUpDn;

    public Encoding zEncoding;

    public int zMiddle;

    public int zAutoSave;

    public int zGridPartition;

    [DllImport("shell32.dll")]
    public static extern void SHChangeNotify(int wEventId, int uFlags, int dwItem1, int dwItem2);

    private void OK_Button_Click(object sender, EventArgs e)
    {
        zWheel = CWheel.SelectedIndex switch
        {
            0 => 192,
            1 => 96,
            2 => 64,
            3 => 48,
            _ => zWheel
        };
        zPgUpDn = CPgUpDn.SelectedIndex switch
        {
            0 => 1536,
            1 => 1152,
            2 => 768,
            3 => 576,
            4 => 384,
            5 => 192,
            6 => 96,
            _ => zPgUpDn
        };
        zEncoding = CTextEncoding.SelectedIndex switch
        {
            0 => Encoding.Default,
            1 => Encoding.Unicode,
            2 => Encoding.ASCII,
            3 => Encoding.BigEndianUnicode,
            4 => Encoding.UTF32,
            5 => Encoding.UTF7,
            6 => Encoding.UTF8,
            7 => Encoding.GetEncoding(932),
            8 => Encoding.GetEncoding(51949),
            _ => zEncoding
        };
        zMiddle = Conversions.ToInteger(Interaction.IIf(rMiddleDrag.Checked, 1, 0));
        zAutoSave = Conversions.ToInteger(Operators.MultiplyObject(Operators.MultiplyObject(Interaction.IIf(cAutoSave.Checked, 1, 0), NAutoSave.Value), 60000));
        zGridPartition = Convert.ToInt32(nGridPartition.Value);
        DialogResult = DialogResult.OK;
        Close();
    }

    private void Cancel_Button_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    public OpGeneral(int xMsWheel, int xPgUpDn, int xMiddleButton, int xTextEncoding, int xGridPartition, int xAutoSave, bool xBeep, bool xBPMx, bool xSTOPx, bool xMFEnter, bool xMFClick, bool xMStopPreview)
    {
        var try0006_dispatch = -1;
        var num2 = default(int);
        var num = default(int);
        var num3 = default(int);
        var num5 = default(int);
        var num6 = default(int);
        while (true)
        {
            try
            {
                /*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/
                ;
                switch (try0006_dispatch)
                {
                    default:
                        Load += OpGeneral_Load;
                        goto IL_0019;
                    case 950:
                        {
                            num2 = num;
                            switch (num3)
                            {
                                case 1:
                                    break;
                                default:
                                    goto end_IL_0006;
                            }
                            var num4 = num2 + 1;
                            num2 = 0;
                            switch (num4)
                            {
                                case 1:
                                    break;
                                case 2:
                                    goto IL_0022;
                                case 3:
                                    goto IL_0029;
                                case 5:
                                case 6:
                                    goto IL_002e;
                                case 7:
                                    goto IL_0039;
                                case 9:
                                    goto IL_004a;
                                case 10:
                                    goto IL_0053;
                                case 12:
                                    goto IL_0065;
                                case 13:
                                    goto IL_006e;
                                case 15:
                                    goto IL_0080;
                                case 16:
                                    goto IL_0089;
                                case 4:
                                case 8:
                                case 11:
                                case 14:
                                case 17:
                                case 18:
                                    goto IL_0099;
                                case 20:
                                case 21:
                                    goto IL_009f;
                                case 22:
                                    goto IL_00ab;
                                case 24:
                                    goto IL_00c0;
                                case 25:
                                    goto IL_00cc;
                                case 27:
                                    goto IL_00e1;
                                case 28:
                                    goto IL_00ed;
                                case 30:
                                    goto IL_00ff;
                                case 31:
                                    goto IL_010b;
                                case 33:
                                    goto IL_011d;
                                case 34:
                                    goto IL_0129;
                                case 36:
                                    goto IL_013b;
                                case 37:
                                    goto IL_0147;
                                case 39:
                                    goto IL_0159;
                                case 40:
                                    goto IL_0162;
                                case 19:
                                case 23:
                                case 26:
                                case 29:
                                case 32:
                                case 35:
                                case 38:
                                case 41:
                                case 42:
                                    goto IL_0172;
                                case 43:
                                    goto IL_0183;
                                case 44:
                                    goto IL_0199;
                                case 45:
                                    goto IL_01a1;
                                case 47:
                                    goto IL_01b3;
                                case 48:
                                    goto IL_01b7;
                                case 46:
                                case 49:
                                case 50:
                                    goto IL_01c7;
                                case 51:
                                    goto IL_020c;
                                case 53:
                                    goto IL_021e;
                                case 54:
                                    goto IL_0222;
                                case 52:
                                case 55:
                                case 56:
                                    goto IL_0243;
                                case 57:
                                    goto IL_0254;
                                case 58:
                                    goto IL_0265;
                                case 59:
                                    goto IL_0276;
                                case 60:
                                    goto IL_0287;
                                case 61:
                                    goto end_IL_0006_2;
                                default:
                                    goto end_IL_0006;
                                case 62:
                                    goto end_IL_0006_3;
                            }
                            goto IL_0019;
                        }
IL_0287:
                        num = 60;
                        cMClickFocus.Checked = xMFClick;
                        break;
IL_0019:
                        num = 1;
                        InitializeComponent();
                        goto IL_0022;
IL_0022:
                        ProjectData.ClearProjectError();
                        num3 = 1;
                        goto IL_0029;
IL_0029:
                        num = 3;
                        num5 = xMsWheel;
                        goto IL_002e;
IL_002e:
                        num = 6;
                        if (num5 == 192)
                        {
                            goto IL_0039;
                        }
                        goto IL_004a;
IL_0039:
                        num = 7;
                        CWheel.SelectedIndex = 0;
                        goto IL_0099;
IL_004a:
                        num = 9;
                        if (num5 == 96)
                        {
                            goto IL_0053;
                        }
                        goto IL_0065;
IL_0053:
                        num = 10;
                        CWheel.SelectedIndex = 1;
                        goto IL_0099;
IL_0065:
                        num = 12;
                        if (num5 == 64)
                        {
                            goto IL_006e;
                        }
                        goto IL_0080;
IL_006e:
                        num = 13;
                        CWheel.SelectedIndex = 2;
                        goto IL_0099;
IL_0080:
                        num = 15;
                        if (num5 == 48)
                        {
                            goto IL_0089;
                        }
                        goto IL_0099;
IL_0089:
                        num = 16;
                        CWheel.SelectedIndex = 3;
                        goto IL_0099;
IL_0099:
                        num = 18;
                        num6 = xPgUpDn;
                        goto IL_009f;
IL_009f:
                        num = 21;
                        if (num6 == 1536)
                        {
                            goto IL_00ab;
                        }
                        goto IL_00c0;
IL_00ab:
                        num = 22;
                        CPgUpDn.SelectedIndex = 0;
                        goto IL_0172;
IL_00c0:
                        num = 24;
                        if (num6 == 1152)
                        {
                            goto IL_00cc;
                        }
                        goto IL_00e1;
IL_00cc:
                        num = 25;
                        CPgUpDn.SelectedIndex = 1;
                        goto IL_0172;
IL_00e1:
                        num = 27;
                        if (num6 == 768)
                        {
                            goto IL_00ed;
                        }
                        goto IL_00ff;
IL_00ed:
                        num = 28;
                        CPgUpDn.SelectedIndex = 2;
                        goto IL_0172;
IL_00ff:
                        num = 30;
                        if (num6 == 576)
                        {
                            goto IL_010b;
                        }
                        goto IL_011d;
IL_010b:
                        num = 31;
                        CPgUpDn.SelectedIndex = 3;
                        goto IL_0172;
IL_011d:
                        num = 33;
                        if (num6 == 384)
                        {
                            goto IL_0129;
                        }
                        goto IL_013b;
IL_0129:
                        num = 34;
                        CPgUpDn.SelectedIndex = 4;
                        goto IL_0172;
IL_013b:
                        num = 36;
                        if (num6 == 192)
                        {
                            goto IL_0147;
                        }
                        goto IL_0159;
IL_0147:
                        num = 37;
                        CPgUpDn.SelectedIndex = 5;
                        goto IL_0172;
IL_0159:
                        num = 39;
                        if (num6 == 96)
                        {
                            goto IL_0162;
                        }
                        goto IL_0172;
IL_0162:
                        num = 40;
                        CPgUpDn.SelectedIndex = 6;
                        goto IL_0172;
IL_0172:
                        num = 42;
                        CTextEncoding.SelectedIndex = xTextEncoding;
                        goto IL_0183;
IL_0183:
                        num = 43;
                        nGridPartition.Value = new decimal(xGridPartition);
                        goto IL_0199;
IL_0199:
                        num = 44;
                        if (xMiddleButton == 0)
                        {
                            goto IL_01a1;
                        }
                        goto IL_01b3;
IL_01a1:
                        num = 45;
                        rMiddleAuto.Checked = true;
                        goto IL_01c7;
IL_01b3:
                        num = 47;
                        goto IL_01b7;
IL_01b7:
                        num = 48;
                        rMiddleDrag.Checked = true;
                        goto IL_01c7;
IL_01c7:
                        num = 50;
                        if ((xAutoSave / 60000.0 > Convert.ToDouble(NAutoSave.Maximum)) | (xAutoSave / 60000.0 < Convert.ToDouble(NAutoSave.Minimum)))
                        {
                            goto IL_020c;
                        }
                        goto IL_021e;
IL_020c:
                        num = 51;
                        cAutoSave.Checked = false;
                        goto IL_0243;
IL_021e:
                        num = 53;
                        goto IL_0222;
IL_0222:
                        num = 54;
                        NAutoSave.Value = new decimal(xAutoSave / 60000.0);
                        goto IL_0243;
IL_0243:
                        num = 56;
                        cBeep.Checked = xBeep;
                        goto IL_0254;
IL_0254:
                        num = 57;
                        cBpm1296.Checked = xBPMx;
                        goto IL_0265;
IL_0265:
                        num = 58;
                        cStop1296.Checked = xSTOPx;
                        goto IL_0276;
IL_0276:
                        num = 59;
                        cMEnterFocus.Checked = xMFEnter;
                        goto IL_0287;
end_IL_0006_2:
                        break;
                }
                num = 61;
                cMStopPreview.Checked = xMStopPreview;
                break;
end_IL_0006:;
            }
            catch (Exception obj) when (num3 != 0 && num2 == 0)
            {
                ProjectData.SetProjectError(obj);
                try0006_dispatch = 950;
                continue;
            }
            throw ProjectData.CreateProjectError(-2146828237);
            continue;
end_IL_0006_3:
            break;
        }
        if (num2 != 0)
        {
            ProjectData.ClearProjectError();
        }
    }

    private void OpGeneral_Load(object sender, EventArgs e)
    {
        Font = MyProject.Forms.MainWindow.Font;
        Text = Strings.fopGeneral.Title;
        Label1.Text = Strings.fopGeneral.MouseWheel;
        Label2.Text = Strings.fopGeneral.TextEncoding;
        Label5.Text = Strings.fopGeneral.PageUpDown;
        Label3.Text = Strings.fopGeneral.MiddleButton;
        Label4.Text = Strings.fopGeneral.AssociateFileType;
        rMiddleAuto.Text = Strings.fopGeneral.MiddleButtonAuto;
        rMiddleDrag.Text = Strings.fopGeneral.MiddleButtonDrag;
        Label6.Text = Strings.fopGeneral.MaxGridPartition;
        cBeep.Text = Strings.fopGeneral.BeepWhileSaved;
        cBpm1296.Text = Strings.fopGeneral.ExtendBPM;
        cStop1296.Text = Strings.fopGeneral.ExtendSTOP;
        cMEnterFocus.Text = Strings.fopGeneral.AutoFocusOnMouseEnter;
        cMClickFocus.Text = Strings.fopGeneral.DisableFirstClick;
        cAutoSave.Text = Strings.fopGeneral.AutoSave;
        Label7.Text = Strings.fopGeneral.minutes;
        cMStopPreview.Text = Strings.fopGeneral.StopPreviewOnClick;
        var @default = Encoding.Default;
        CTextEncoding.Items[0] = "System ANSI (" + @default.EncodingName + ")";
        OK_Button.Text = Strings.OK;
        Cancel_Button.Text = Strings.Cancel;
    }

    private void TBAssociate_Click(object sender, EventArgs e)
    {
        Associate(".bms", "iBMSC.BMS", Strings.FileAssociation.BMS, isIBMSC: false);
    }

    private void TBAssociateIBMSC_Click(object sender, EventArgs e)
    {
        Associate(".ibmsc", "iBMSC.iBMSC", Strings.FileAssociation.IBMSC, isIBMSC: true);
    }

    private void TBAssociateBME_Click(object sender, EventArgs e)
    {
        Associate(".bme", "iBMSC.BME", Strings.FileAssociation.BME, isIBMSC: false);
    }

    private void TBAssociateBML_Click(object sender, EventArgs e)
    {
        Associate(".bml", "iBMSC.BML", Strings.FileAssociation.BML, isIBMSC: false);
    }

    private void TBAssociatePMS_Click(object sender, EventArgs e)
    {
        Associate(".pms", "iBMSC.PMS", Strings.FileAssociation.PMS, isIBMSC: false);
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    private void Associate(string xExt, string xClass, string xDescription, bool isIBMSC)
    {
        if (Interaction.MsgBox(Microsoft.VisualBasic.Strings.Replace(Strings.Messages.FileAssociationPrompt, "{}", "*" + xExt), MsgBoxStyle.YesNo | MsgBoxStyle.Question) != MsgBoxResult.Yes)
        {
            return;
        }
        try
        {
            var classesRoot = Registry.ClassesRoot;
            if (Array.IndexOf(classesRoot.GetSubKeyNames(), xExt) != -1)
            {
                classesRoot.DeleteSubKeyTree(xExt);
            }
            classesRoot.CreateSubKey(xExt);
            var registryKey = classesRoot.OpenSubKey(xExt, writable: true);
            registryKey.SetValue("", xClass, RegistryValueKind.String);
            if (Array.IndexOf(classesRoot.GetSubKeyNames(), xClass) != -1)
            {
                classesRoot.DeleteSubKeyTree(xClass);
            }
            classesRoot.CreateSubKey(xClass);
            registryKey = classesRoot.OpenSubKey(xClass, writable: true);
            registryKey.SetValue("", xDescription, RegistryValueKind.String);
            registryKey.CreateSubKey("DefaultIcon");
            registryKey = classesRoot.OpenSubKey(xClass + "\\DefaultIcon", writable: true);
            registryKey.SetValue("", MyProject.Application.Info.DirectoryPath + "\\TypeBMS.ico", RegistryValueKind.String);
            registryKey = classesRoot.OpenSubKey(xClass, writable: true);
            registryKey.CreateSubKey("shell");
            registryKey = classesRoot.OpenSubKey(xClass + "\\shell", writable: true);
            registryKey.SetValue("", "open");
            registryKey = classesRoot.OpenSubKey(xClass + "\\shell", writable: true);
            registryKey.CreateSubKey("open\\command");
            registryKey = classesRoot.OpenSubKey(xClass + "\\shell\\open", writable: true);
            registryKey.SetValue("", Strings.FileAssociation.Open);
            registryKey = classesRoot.OpenSubKey(xClass + "\\shell\\open\\command", writable: true);
            registryKey.SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"");
            if (!isIBMSC)
            {
                registryKey = classesRoot.OpenSubKey(xClass + "\\shell", writable: true);
                registryKey.CreateSubKey("preview\\command");
                registryKey = classesRoot.OpenSubKey(xClass + "\\shell\\preview", writable: true);
                registryKey.SetValue("", Strings.FileAssociation.Preview);
                registryKey = classesRoot.OpenSubKey(xClass + "\\shell\\preview\\command", writable: true);
                registryKey.SetValue("", "\"" + MyProject.Application.Info.DirectoryPath + "\\uBMplay.exe\" \"%1\"");
                registryKey = classesRoot.OpenSubKey(xClass + "\\shell", writable: true);
                registryKey.CreateSubKey("viewcode\\command");
                registryKey = classesRoot.OpenSubKey(xClass + "\\shell\\viewcode", writable: true);
                registryKey.SetValue("", Strings.FileAssociation.ViewCode);
                registryKey = classesRoot.OpenSubKey(xClass + "\\shell\\viewcode\\command", writable: true);
                registryKey.SetValue("", Environment.SystemDirectory + "\\notepad.exe %1");
            }
            classesRoot = null;
            var currentUser = Registry.CurrentUser;
            currentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\" + xExt);
            registryKey = currentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\" + xExt, writable: true);
            registryKey.CreateSubKey("UserChoice");
            registryKey = currentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\" + xExt + "\\UserChoice", writable: true);
            registryKey.SetValue("Progid", xClass);
            currentUser = null;
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Interaction.MsgBox(Strings.Messages.FileAssociationError + "\r\n\r\n" + ex.Message, MsgBoxStyle.Exclamation, Strings.Messages.Err);
            ProjectData.ClearProjectError();
        }
        SHChangeNotify(134217728, 0, 0, 0);
        Interaction.Beep();
    }

    private void cAutoSave_CheckedChanged(object sender, EventArgs e)
    {
        NAutoSave.Enabled = cAutoSave.Checked;
    }
}
