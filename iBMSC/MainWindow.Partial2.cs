using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSCore;
using CSCore.Codecs;
using iBMSC.Editor;
using iBMSC.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace iBMSC
{
    public partial class MainWindow
    {
        private void BVCReverse_Click(object sender, EventArgs e)
        {
            vSelStart += vSelLength;
            vSelHalf -= vSelLength;
            vSelLength *= -1.0;
            ValidateSelection();
            RefreshPanelAll();
            POStatusRefresh();
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private void AutoSaveTimer_Tick(object sender, EventArgs e)
        {
            int try0000_dispatch = -1;
            int num = default(int);
            DateTime now = default(DateTime);
            int num2 = default(int);
            int num3 = default(int);
            string text = default(string);
            while (true)
            {
                try
                {
                    /*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/
                    ;
                    switch (try0000_dispatch)
                    {
                        default:
                            num = 1;
                            now = DateAndTime.Now;
                            goto IL_0009;
                        case 367:
                            {
                                num2 = num;
                                switch (num3)
                                {
                                    case 1:
                                        break;
                                    default:
                                        goto end_IL_0000;
                                }
                                int num4 = num2 + 1;
                                num2 = 0;
                                switch (num4)
                                {
                                    case 1:
                                        break;
                                    case 2:
                                        goto IL_0009;
                                    case 3:
                                        goto IL_000c;
                                    case 4:
                                    case 5:
                                        goto IL_00e0;
                                    case 6:
                                        goto IL_00ea;
                                    case 7:
                                        goto IL_00f1;
                                    case 8:
                                        goto IL_0108;
                                    case 9:
                                    case 10:
                                        goto IL_0116;
                                    case 11:
                                        goto end_IL_0000_2;
                                    default:
                                        goto end_IL_0000;
                                    case 12:
                                        goto end_IL_0000_3;
                                }
                                goto default;
                            }
IL_0116:
                            ProjectData.ClearProjectError();
                            num3 = 0;
                            break;
IL_0009:
                            num = 2;
                            goto IL_000c;
IL_000c:
                            num = 3;
                            text = MyProject.Application.Info.DirectoryPath + "\\AutoSave_" + Conversions.ToString(now.Year) + "_" + Conversions.ToString(now.Month) + "_" + Conversions.ToString(now.Day) + "_" + Conversions.ToString(now.Hour) + "_" + Conversions.ToString(now.Minute) + "_" + Conversions.ToString(now.Second) + "_" + Conversions.ToString(now.Millisecond) + ".IBMSC";
                            goto IL_00e0;
IL_00e0:
                            num = 5;
                            SaveiBMSC(text);
                            goto IL_00ea;
IL_00ea:
                            ProjectData.ClearProjectError();
                            num3 = 1;
                            goto IL_00f1;
IL_00f1:
                            num = 7;
                            if (Operators.CompareString(PreviousAutoSavedFileName, "", TextCompare: false) != 0)
                            {
                                goto IL_0108;
                            }
                            goto IL_0116;
IL_0108:
                            num = 8;
                            File.Delete(PreviousAutoSavedFileName);
                            goto IL_0116;
end_IL_0000_2:
                            break;
                    }
                    num = 11;
                    PreviousAutoSavedFileName = text;
                    break;
end_IL_0000:;
                }
                catch (Exception obj) when (num3 != 0 && num2 == 0)
                {
                    ProjectData.SetProjectError(obj);
                    try0000_dispatch = 367;
                    continue;
                }
                throw ProjectData.CreateProjectError(-2146828237);
                continue;
end_IL_0000_3:
                break;
            }
            if (num2 != 0)
            {
                ProjectData.ClearProjectError();
            }
        }

        private void CWAVMultiSelect_CheckedChanged(object sender, EventArgs e)
        {
            WAVMultiSelect = CWAVMultiSelect.Checked;
            LWAV.SelectionMode = (SelectionMode)Conversions.ToInteger(Interaction.IIf(WAVMultiSelect, SelectionMode.MultiExtended, SelectionMode.One));
        }

        private void CWAVChangeLabel_CheckedChanged(object sender, EventArgs e)
        {
            WAVChangeLabel = CWAVChangeLabel.Checked;
        }

        private void BWAVUp_Click(object sender, EventArgs e)
        {
            if (LWAV.SelectedIndex == -1)
            {
                return;
            }
            UndoRedo.LinkedURCmd BaseUndo = null;
            UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
            UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
            int[] array = new int[LWAV.SelectedIndices.Count - 1 + 1];
            LWAV.SelectedIndices.CopyTo(array, 0);
            int num = 0;
            while (Array.IndexOf(array, num) != -1)
            {
                num++;
                if (num > 1294)
                {
                    break;
                }
            }
            string text = "";
            int num2 = -1;
            for (int i = num; i <= 1294; i++)
            {
                num2 = Array.IndexOf(array, i);
                if (num2 == -1)
                {
                    continue;
                }
                text = hWAV[i + 1];
                hWAV[i + 1] = hWAV[i];
                hWAV[i] = text;
                LWAV.Items[i] = Functions.C10to36(i + 1) + ": " + hWAV[i + 1];
                LWAV.Items[i - 1] = Functions.C10to36(i) + ": " + hWAV[i];
                if (WAVChangeLabel)
                {
                    string right = Functions.C10to36(i);
                    string right2 = Functions.C10to36(i + 1);
                    int num3 = Information.UBound(Notes);
                    for (int j = 1; j <= num3; j++)
                    {
                        if (!IsColumnNumeric(Notes[j].ColumnIndex))
                        {
                            if (Operators.CompareString(Functions.C10to36(Notes[j].Value / 10000), right, TextCompare: false) == 0)
                            {
                                RedoRelabelNote(Notes[j], i * 10000 + 10000, ref BaseUndo, ref BaseRedo);
                                Notes[j].Value = i * 10000 + 10000;
                            }
                            else if (Operators.CompareString(Functions.C10to36(Notes[j].Value / 10000), right2, TextCompare: false) == 0)
                            {
                                RedoRelabelNote(Notes[j], i * 10000, ref BaseUndo, ref BaseRedo);
                                Notes[j].Value = i * 10000;
                            }
                        }
                    }
                }

                int num4 = num2;
                array[num4] += -1;
            }
            LWAV.SelectedIndices.Clear();
            int num5 = Information.UBound(array);
            for (int k = 0; k <= num5; k++)
            {
                LWAV.SelectedIndices.Add(array[k]);
            }
            AddUndo(BaseUndo, linkedURCmd.Next);
            RefreshPanelAll();
            POStatusRefresh();
        }

        private void BWAVDown_Click(object sender, EventArgs e)
        {
            if (LWAV.SelectedIndex == -1)
            {
                return;
            }
            UndoRedo.LinkedURCmd BaseUndo = null;
            UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
            UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
            int[] array = new int[LWAV.SelectedIndices.Count - 1 + 1];
            LWAV.SelectedIndices.CopyTo(array, 0);
            int num = 1294;
            while (Array.IndexOf(array, num) != -1)
            {
                num += -1;
                if (num < 0)
                {
                    break;
                }
            }
            string text = "";
            int num2 = -1;
            for (int i = num; i >= 0; i += -1)
            {
                num2 = Array.IndexOf(array, i);
                if (num2 == -1)
                {
                    continue;
                }
                text = hWAV[i + 1];
                hWAV[i + 1] = hWAV[i + 2];
                hWAV[i + 2] = text;
                LWAV.Items[i] = Functions.C10to36(i + 1) + ": " + hWAV[i + 1];
                LWAV.Items[i + 1] = Functions.C10to36(i + 2) + ": " + hWAV[i + 2];
                if (WAVChangeLabel)
                {
                    string right = Functions.C10to36(i + 2);
                    string right2 = Functions.C10to36(i + 1);
                    int num3 = Information.UBound(Notes);
                    for (int j = 1; j <= num3; j++)
                    {
                        if (!IsColumnNumeric(Notes[j].ColumnIndex))
                        {
                            if (Operators.CompareString(Functions.C10to36(Notes[j].Value / 10000), right, TextCompare: false) == 0)
                            {
                                RedoRelabelNote(Notes[j], i * 10000 + 10000, ref BaseUndo, ref BaseRedo);
                                Notes[j].Value = i * 10000 + 10000;
                            }
                            else if (Operators.CompareString(Functions.C10to36(Notes[j].Value / 10000), right2, TextCompare: false) == 0)
                            {
                                RedoRelabelNote(Notes[j], i * 10000 + 20000, ref BaseUndo, ref BaseRedo);
                                Notes[j].Value = i * 10000 + 20000;
                            }
                        }
                    }
                }

                int num4 = num2;
                array[num4]++;
            }
            LWAV.SelectedIndices.Clear();
            int num5 = Information.UBound(array);
            for (int k = 0; k <= num5; k++)
            {
                LWAV.SelectedIndices.Add(array[k]);
            }
            AddUndo(BaseUndo, linkedURCmd.Next);
            RefreshPanelAll();
            POStatusRefresh();
        }

        private void BWAVBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "wav";
            openFileDialog.Filter = Strings1.FileType._wave + "|*.wav;*.ogg;*.mp3|" + Strings1.FileType.WAV + "|*.wav|" + Strings1.FileType.OGG + "|*.ogg|" + Strings1.FileType.MP3 + "|*.mp3|" + Strings1.FileType._all + "|*.*";
            openFileDialog.InitialDirectory = Conversions.ToString(Interaction.IIf(Operators.CompareString(ExcludeFileName(FileName), "", TextCompare: false) == 0, InitPath, ExcludeFileName(FileName)));
            openFileDialog.Multiselect = WAVMultiSelect;
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                InitPath = ExcludeFileName(openFileDialog.FileName);
                AddToPOWAV(openFileDialog.FileNames);
            }
        }

        private void BWAVRemove_Click(object sender, EventArgs e)
        {
            int[] array = new int[LWAV.SelectedIndices.Count - 1 + 1];
            LWAV.SelectedIndices.CopyTo(array, 0);
            int num = Information.UBound(array);
            for (int i = 0; i <= num; i++)
            {
                hWAV[array[i] + 1] = "";
                LWAV.Items[array[i]] = Functions.C10to36(array[i] + 1) + ": ";
            }
            LWAV.SelectedIndices.Clear();
            int num2 = Information.UBound(array);
            for (int j = 0; j <= num2; j++)
            {
                LWAV.SelectedIndices.Add(array[j]);
            }
            if (IsSaved)
            {
                SetIsSaved(isSaved: false);
            }
            RefreshPanelAll();
            POStatusRefresh();
        }

        private void mnMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 274, 61458, 0);
                if (e.Clicks == 2)
                {
                    if (WindowState == FormWindowState.Maximized)
                    {
                        WindowState = FormWindowState.Normal;
                    }
                    else
                    {
                        WindowState = FormWindowState.Maximized;
                    }
                }
            }
            else if (e.Button != MouseButtons.Right)
            {
            }
        }

        private void mnSelectAll_Click(object sender, EventArgs e)
        {
            if ((PMainIn.Focused || PMainInL.Focused) | PMainInR.Focused)
            {
                int num = Information.UBound(Notes);
                for (int i = 1; i <= num; i += 1)
                {
                    Notes[i].Selected = nEnabled(Notes[i].ColumnIndex);
                }
                if (TBTimeSelect.Checked)
                {
                    CalculateGreatestVPosition();
                    vSelStart = 0.0;
                    vSelLength = MeasureBottom[MeasureAtDisplacement(GreatestVPosition)] + MeasureLength[MeasureAtDisplacement(GreatestVPosition)];
                }
                RefreshPanelAll();
                POStatusRefresh();
            }
        }

        private void mnDelete_Click(object sender, EventArgs e)
        {
            if ((PMainIn.Focused || PMainInL.Focused ? true : false) | PMainInR.Focused)
            {
                UndoRedo.LinkedURCmd BaseUndo = null;
                UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
                UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
                RedoRemoveNoteSelected(xSel: true, ref BaseUndo, ref BaseRedo);
                RemoveNotes();
                AddUndo(BaseUndo, linkedURCmd.Next);
                CalculateGreatestVPosition();
                CalculateTotalPlayableNotes();
                RefreshPanelAll();
                POStatusRefresh();
            }
        }

        private void mnUpdate_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.cs.mcgill.ca/~ryang6/iBMSC/");
        }

        private void mnUpdateC_Click(object sender, EventArgs e)
        {
            Process.Start("http://bbs.rohome.net/thread-1074065-1-1.html");
        }

        private void mnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EnableDWM()
        {
            mnMain.BackColor = Color.Black;
            IEnumerator enumerator = default(IEnumerator);
            try
            {
                enumerator = mnMain.Items.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)enumerator.Current;
                    toolStripMenuItem.ForeColor = Color.White;
                    toolStripMenuItem.DropDownClosed += mn_DropDownClosed;
                    toolStripMenuItem.DropDownOpened += mn_DropDownOpened;
                    toolStripMenuItem.MouseEnter += mn_MouseEnter;
                    toolStripMenuItem.MouseLeave += mn_MouseLeave;
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
        }

        private void DisableDWM()
        {
            mnMain.BackColor = SystemColors.Control;
            IEnumerator enumerator = default(IEnumerator);
            try
            {
                enumerator = mnMain.Items.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)enumerator.Current;
                    toolStripMenuItem.ForeColor = SystemColors.ControlText;
                    toolStripMenuItem.DropDownClosed -= mn_DropDownClosed;
                    toolStripMenuItem.DropDownOpened -= mn_DropDownOpened;
                    toolStripMenuItem.MouseEnter -= mn_MouseEnter;
                    toolStripMenuItem.MouseLeave -= mn_MouseLeave;
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
        }

        private void ttlIcon_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void ttlIcon_MouseEnter(object sender, EventArgs e)
        {
        }

        private void ttlIcon_MouseLeave(object sender, EventArgs e)
        {
        }

        private void mnSMenu_Click(object sender, EventArgs e)
        {
            mnMain.Visible = mnSMenu.Checked;
        }

        private void mnSTB_Click(object sender, EventArgs e)
        {
            TBMain.Visible = mnSTB.Checked;
        }

        private void mnSOP_Click(object sender, EventArgs e)
        {
            POptions.Visible = mnSOP.Checked;
        }

        private void mnSStatus_Click(object sender, EventArgs e)
        {
            pStatus.Visible = mnSStatus.Checked;
        }

        private void mnSLSplitter_Click(object sender, EventArgs e)
        {
            SpL.Visible = mnSLSplitter.Checked;
        }

        private void mnSRSplitter_Click(object sender, EventArgs e)
        {
            SpR.Visible = mnSRSplitter.Checked;
        }

        private void CGShow_CheckedChanged(object sender, EventArgs e)
        {
            gShowGrid = CGShow.Checked;
            RefreshPanelAll();
        }

        private void CGShowS_CheckedChanged(object sender, EventArgs e)
        {
            gShowSubGrid = CGShowS.Checked;
            RefreshPanelAll();
        }

        private void CGShowBG_CheckedChanged(object sender, EventArgs e)
        {
            gShowBG = CGShowBG.Checked;
            RefreshPanelAll();
        }

        private void CGShowM_CheckedChanged(object sender, EventArgs e)
        {
            gShowMeasureNumber = CGShowM.Checked;
            RefreshPanelAll();
        }

        private void CGShowV_CheckedChanged(object sender, EventArgs e)
        {
            gShowVerticalLine = CGShowV.Checked;
            RefreshPanelAll();
        }

        private void CGShowMB_CheckedChanged(object sender, EventArgs e)
        {
            gShowMeasureBar = CGShowMB.Checked;
            RefreshPanelAll();
        }

        private void CGShowC_CheckedChanged(object sender, EventArgs e)
        {
            gShowC = CGShowC.Checked;
            RefreshPanelAll();
        }

        private void CGBLP_CheckedChanged(object sender, EventArgs e)
        {
            gDisplayBGAColumn = CGBLP.Checked;
            column[23].isVisible = gDisplayBGAColumn;
            column[24].isVisible = gDisplayBGAColumn;
            column[25].isVisible = gDisplayBGAColumn;
            column[26].isVisible = gDisplayBGAColumn;
            if (!IsInitializing)
            {
                int num = Information.UBound(Notes);
                for (int i = 1; i <= num; i += 1)
                {
                    Notes[i].Selected &= nEnabled(Notes[i].ColumnIndex);
                }
                UpdateColumnsX();
                RefreshPanelAll();
            }
        }

        private void CGSCROLL_CheckedChanged(object sender, EventArgs e)
        {
            gSCROLL = CGSCROLL.Checked;
            column[1].isVisible = gSCROLL;
            if (!IsInitializing)
            {
                int num = Information.UBound(Notes);
                for (int i = 1; i <= num; i += 1)
                {
                    Notes[i].Selected &= nEnabled(Notes[i].ColumnIndex);
                }
                UpdateColumnsX();
                RefreshPanelAll();
            }
        }

        private void CGSTOP_CheckedChanged(object sender, EventArgs e)
        {
            gSTOP = CGSTOP.Checked;
            column[3].isVisible = gSTOP;
            if (!IsInitializing)
            {
                int num = Information.UBound(Notes);
                for (int i = 1; i <= num; i += 1)
                {
                    Notes[i].Selected &= nEnabled(Notes[i].ColumnIndex);
                }
                UpdateColumnsX();
                RefreshPanelAll();
            }
        }

        private void CGBPM_CheckedChanged(object sender, EventArgs e)
        {
            gBPM = CGBPM.Checked;
            column[2].isVisible = gBPM;
            if (!IsInitializing)
            {
                int num = Information.UBound(Notes);
                for (int i = 1; i <= num; i += 1)
                {
                    Notes[i].Selected &= nEnabled(Notes[i].ColumnIndex);
                }
                UpdateColumnsX();
                RefreshPanelAll();
            }
        }

        private void CGDisableVertical_CheckedChanged(object sender, EventArgs e)
        {
            DisableVerticalMove = CGDisableVertical.Checked;
        }

        private void CBeatPreserve_Click(object sender, EventArgs e)
        {
            RadioButton[] array = new RadioButton[4] { CBeatPreserve, CBeatMeasure, CBeatCut, CBeatScale };
            BeatChangeMode = Array.IndexOf(array, (RadioButton)sender);
        }

        private void tBeatValue_LostFocus(object sender, EventArgs e)
        {
            if (double.TryParse(tBeatValue.Text, out var result))
            {
                if (result <= 0.0 || result >= 1000.0)
                {
                    tBeatValue.BackColor = Color.FromArgb(-16192);
                }
                else
                {
                    Color backColor = default(Color);
                    tBeatValue.BackColor = backColor;
                }
                tBeatValue.Text = Conversions.ToString(result);
            }
        }

        private void ApplyBeat(double xRatio, string xDisplay)
        {
            SortByVPositionInsertion();
            UndoRedo.LinkedURCmd BaseUndo = null;
            UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
            UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
            RedoChangeMeasureLengthSelected(192.0 * xRatio, ref BaseUndo, ref BaseRedo);
            int[] array = new int[LBeat.SelectedIndices.Count - 1 + 1];
            LBeat.SelectedIndices.CopyTo(array, 0);
            foreach (int num in array)
            {
                double num2 = xRatio * 192.0 - MeasureLength[num];
                double num3 = xRatio * 192.0 / MeasureLength[num];
                double num4 = 0.0;
                int num5 = num - 1;
                for (int j = 0; j <= num5; j++)
                {
                    num4 += MeasureLength[j];
                }
                double num6 = num4 + MeasureLength[num];
                double num7 = num6 + num2;
                switch (BeatChangeMode)
                {
                    case 1:
                        {
                            int num25;
                            if (NTInput)
                            {
                                int num24 = Information.UBound(Notes);
                                for (num25 = 1; num25 <= num24 && !(Notes[num25].VPosition >= num6); num25++)
                                {
                                    if (Notes[num25].VPosition + Notes[num25].Length >= num6)
                                    {
                                        RedoLongNoteModify(Notes[num25], Notes[num25].VPosition, Notes[num25].Length + num2, ref BaseUndo, ref BaseRedo);
                                        Note[] notes = Notes;
                                        notes[num25].Length += num2;
                                    }
                                }
                            }
                            else
                            {
                                int num26 = Information.UBound(Notes);
                                for (num25 = 1; num25 <= num26 && !(Notes[num25].VPosition >= num6); num25++)
                                {
                                }
                            }
                            int num27 = num25;
                            int num28 = Information.UBound(Notes);
                            for (int num29 = num27; num29 <= num28; num29++)
                            {
                                RedoLongNoteModify(Notes[num29], Notes[num29].VPosition + num2, Notes[num29].Length, ref BaseUndo, ref BaseRedo);
                                Note[] notes = Notes;
                                notes[num29].VPosition += num2;
                            }
                            break;
                        }
                    case 2:
                        if (num2 < 0.0)
                        {
                            if (NTInput)
                            {
                                int num30 = 1;
                                for (int num31 = Information.UBound(Notes); num30 <= num31; num30++)
                                {
                                    if (Notes[num30].VPosition < num7)
                                    {
                                        if ((Notes[num30].VPosition + Notes[num30].Length >= num7) & (Notes[num30].VPosition + Notes[num30].Length < num6))
                                        {
                                            double num32 = num7 - Notes[num30].VPosition - 1.0;
                                            RedoLongNoteModify(Notes[num30], Notes[num30].VPosition, num32, ref BaseUndo, ref BaseRedo);
                                            Notes[num30].Length = num32;
                                        }
                                    }
                                    else if (Notes[num30].VPosition < num6)
                                    {
                                        if (Notes[num30].VPosition + Notes[num30].Length < num6)
                                        {
                                            RedoRemoveNote(Notes[num30], ref BaseUndo, ref BaseRedo);
                                            RemoveNote(num30);
                                            num30--;
                                            num31--;
                                        }
                                        else
                                        {
                                            double num33 = Notes[num30].Length - num6 + Notes[num30].VPosition;
                                            RedoLongNoteModify(Notes[num30], num6, num33, ref BaseUndo, ref BaseRedo);
                                            Notes[num30].Length = num33;
                                            Notes[num30].VPosition = num6;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                int num34 = Information.UBound(Notes);
                                int num35;
                                for (num35 = 1; num35 <= num34 && !(Notes[num35].VPosition >= num7); num35++)
                                {
                                }
                                int num36 = num35;
                                int num37 = Information.UBound(Notes);
                                int num38;
                                for (num38 = num36; num38 <= num37 && !(Notes[num38].VPosition >= num6); num38++)
                                {
                                }
                                int num39 = num35;
                                int num40 = num38 - 1;
                                for (int num41 = num39; num41 <= num40; num41++)
                                {
                                    RedoRemoveNote(Notes[num41], ref BaseUndo, ref BaseRedo);
                                }
                                int num42 = num38;
                                int num43 = Information.UBound(Notes);
                                for (int num44 = num42; num44 <= num43; num44++)
                                {
                                    ref Note reference = ref Notes[num44 - num38 + num35];
                                    reference = Notes[num44];
                                }
                                Notes = (Note[])Utils.CopyArray(Notes, new Note[Information.UBound(Notes) - num38 + num35 + 1]);
                            }
                        }
                        goto case 1;
                    case 3:
                        if (NTInput)
                        {
                            int num8 = Information.UBound(Notes);
                            for (int k = 1; k <= num8; k++)
                            {
                                if (Notes[k].VPosition < num4)
                                {
                                    if (Notes[k].VPosition + Notes[k].Length > num6)
                                    {
                                        RedoLongNoteModify(Notes[k], Notes[k].VPosition, Notes[k].Length + num2, ref BaseUndo, ref BaseRedo);
                                        Note[] notes = Notes;
                                        notes[k].Length += num2;
                                    }
                                    else if (Notes[k].VPosition + Notes[k].Length > num4)
                                    {
                                        double num10 = (Notes[k].Length + Notes[k].VPosition - num4) * num3 + num4 - Notes[k].VPosition;
                                        RedoLongNoteModify(Notes[k], Notes[k].VPosition, num10, ref BaseUndo, ref BaseRedo);
                                        Notes[k].Length = num10;
                                    }
                                }
                                else if (Notes[k].VPosition < num6)
                                {
                                    if (Notes[k].VPosition + Notes[k].Length > num6)
                                    {
                                        double num11 = (num6 - Notes[k].VPosition) * num3 + Notes[k].VPosition + Notes[k].Length - num6;
                                        double num12 = (Notes[k].VPosition - num4) * num3 + num4;
                                        RedoLongNoteModify(Notes[k], num12, num11, ref BaseUndo, ref BaseRedo);
                                        Notes[k].Length = num11;
                                        Notes[k].VPosition = num12;
                                    }
                                    else
                                    {
                                        double num13 = Notes[k].Length * num3;
                                        double num14 = (Notes[k].VPosition - num4) * num3 + num4;
                                        RedoLongNoteModify(Notes[k], num14, num13, ref BaseUndo, ref BaseRedo);
                                        Notes[k].Length = num13;
                                        Notes[k].VPosition = num14;
                                    }
                                }
                                else
                                {
                                    RedoLongNoteModify(Notes[k], Notes[k].VPosition + num2, Notes[k].Length, ref BaseUndo, ref BaseRedo);
                                    Note[] notes = Notes;
                                    notes[k].VPosition += num2;
                                }
                            }
                        }
                        else
                        {
                            int num15 = Information.UBound(Notes);
                            int l;
                            for (l = 1; l <= num15 && !(Notes[l].VPosition >= num4); l++)
                            {
                            }
                            int num16 = l;
                            int num17 = Information.UBound(Notes);
                            int m;
                            for (m = num16; m <= num17 && !(Notes[m].VPosition >= num6); m++)
                            {
                            }
                            int num18 = l;
                            int num19 = m - 1;
                            for (int n = num18; n <= num19; n++)
                            {
                                double num20 = (Notes[n].VPosition - num4) * num3 + num4;
                                RedoLongNoteModify(Notes[l], num20, Notes[l].Length, ref BaseUndo, ref BaseRedo);
                                Notes[n].VPosition = num20;
                            }
                            int num21 = m;
                            int num22 = Information.UBound(Notes);
                            for (int num23 = num21; num23 <= num22; num23++)
                            {
                                RedoLongNoteModify(Notes[num23], Notes[num23].VPosition + num2, Notes[num23].Length, ref BaseUndo, ref BaseRedo);
                                Note[] notes = Notes;
                                notes[num23].VPosition += num2;
                            }
                        }
                        break;
                }
                MeasureLength[num] = xRatio * 192.0;
                LBeat.Items[num] = Functions.Add3Zeros(num) + ": " + xDisplay;
            }
            UpdateMeasureBottom();
            LBeat.SelectedIndices.Clear();
            int num45 = Information.UBound(array);
            for (int num46 = 0; num46 <= num45; num46++)
            {
                LBeat.SelectedIndices.Add(array[num46]);
            }
            AddUndo(BaseUndo, linkedURCmd.Next);
            SortByVPositionInsertion();
            UpdatePairing();
            CalculateTotalPlayableNotes();
            CalculateGreatestVPosition();
            RefreshPanelAll();
            POStatusRefresh();
        }

        private void BBeatApply_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(nBeatD.Value);
            int num2 = Convert.ToInt32(nBeatN.Value);
            double num3 = num2 / (double)num;
            ApplyBeat(num3, Conversions.ToString(num3) + " ( " + Conversions.ToString(num2) + " / " + Conversions.ToString(num) + " ) ");
        }

        private void BBeatApplyV_Click(object sender, EventArgs e)
        {
            if (double.TryParse(tBeatValue.Text, out var result))
            {
                if (result <= 0.0 || result >= 1000.0)
                {
                    SystemSounds.Hand.Play();
                    return;
                }
                long denominator = Functions.GetDenominator(result, 2147483647L);
                ApplyBeat(result, Conversions.ToString(Operators.ConcatenateObject(result, Interaction.IIf(denominator > 10000, "", " ( " + Conversions.ToString((long)Math.Round(result * denominator)) + " / " + Conversions.ToString(denominator) + " ) "))));
            }
        }

        private void BHStageFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = Strings1.FileType._image + "|*.bmp;*.png;*.jpg;*.gif|" + Strings1.FileType._all + "|*.*";
            openFileDialog.InitialDirectory = Conversions.ToString(Interaction.IIf(Operators.CompareString(ExcludeFileName(FileName), "", TextCompare: false) == 0, InitPath, ExcludeFileName(FileName)));
            openFileDialog.DefaultExt = "png";
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                InitPath = ExcludeFileName(openFileDialog.FileName);
                if (ReferenceEquals(RuntimeHelpers.GetObjectValue(sender), BHStageFile))
                {
                    THStageFile.Text = GetFileName(openFileDialog.FileName);
                }
                else if (ReferenceEquals(RuntimeHelpers.GetObjectValue(sender), BHBanner))
                {
                    THBanner.Text = GetFileName(openFileDialog.FileName);
                }
                else if (ReferenceEquals(RuntimeHelpers.GetObjectValue(sender), BHBackBMP))
                {
                    THBackBMP.Text = GetFileName(openFileDialog.FileName);
                }
            }
        }

        private void Switches_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox checkBox = (CheckBox)sender;
                Panel panel = null;
                if (!ReferenceEquals(RuntimeHelpers.GetObjectValue(sender), null))
                {
                    if (ReferenceEquals(RuntimeHelpers.GetObjectValue(sender), POHeaderSwitch))
                    {
                        panel = POHeaderInner;
                    }
                    else if (ReferenceEquals(RuntimeHelpers.GetObjectValue(sender), POGridSwitch))
                    {
                        panel = POGridInner;
                    }
                    else if (ReferenceEquals(RuntimeHelpers.GetObjectValue(sender), POWaveFormSwitch))
                    {
                        panel = POWaveFormInner;
                    }
                    else if (ReferenceEquals(RuntimeHelpers.GetObjectValue(sender), POWAVSwitch))
                    {
                        panel = POWAVInner;
                    }
                    else if (ReferenceEquals(RuntimeHelpers.GetObjectValue(sender), POBeatSwitch))
                    {
                        panel = POBeatInner;
                    }
                    else if (ReferenceEquals(RuntimeHelpers.GetObjectValue(sender), POExpansionSwitch))
                    {
                        panel = POExpansionInner;
                    }
                    if (checkBox.Checked)
                    {
                        panel.Visible = true;
                    }
                    else
                    {
                        panel.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ProjectData.ClearProjectError();
            }
        }

        private void Expanders_CheckChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox checkBox = (CheckBox)sender;
                Panel panel = null;
                if (!ReferenceEquals(RuntimeHelpers.GetObjectValue(sender), null))
                {
                    if (ReferenceEquals(RuntimeHelpers.GetObjectValue(sender), POHeaderExpander))
                    {
                        panel = POHeaderPart2;
                    }
                    else if (ReferenceEquals(RuntimeHelpers.GetObjectValue(sender), POGridExpander))
                    {
                        panel = POGridPart2;
                    }
                    else if (ReferenceEquals(RuntimeHelpers.GetObjectValue(sender), POWaveFormExpander))
                    {
                        panel = POWaveFormPart2;
                    }
                    else if (ReferenceEquals(RuntimeHelpers.GetObjectValue(sender), POWAVExpander))
                    {
                        panel = POWAVPart2;
                    }
                    else if (ReferenceEquals(RuntimeHelpers.GetObjectValue(sender), POBeatExpander))
                    {
                        panel = POBeatPart2;
                    }
                    if (checkBox.Checked)
                    {
                        panel.Visible = true;
                    }
                    else
                    {
                        panel.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ProjectData.ClearProjectError();
            }
        }

        private void VerticalResizer_MouseDown(object sender, MouseEventArgs e)
        {
            tempResize = e.Y;
        }

        private void HorizontalResizer_MouseDown(object sender, MouseEventArgs e)
        {
            tempResize = e.X;
        }

        private void POResizer_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || e.Y == tempResize)
            {
                return;
            }
            try
            {
                Button button = (Button)sender;
                Panel panel = (Panel)button.Parent;
                int num = panel.Height + e.Y - tempResize;
                if (num < 10)
                {
                    num = 10;
                }
                panel.Height = num;
                panel.Refresh();
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ProjectData.ClearProjectError();
            }
        }

        private void POptionsResizer_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || e.X == tempResize)
            {
                return;
            }
            try
            {
                int num = POptionsScroll.Width - e.X + tempResize;
                if (num < 25)
                {
                    num = 25;
                }
                POptionsScroll.Width = num;
                Refresh();
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ProjectData.ClearProjectError();
            }
        }

        private void SpR_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || e.X == tempResize)
            {
                return;
            }
            try
            {
                int num = PMainR.Width - e.X + tempResize;
                if (num < 0)
                {
                    num = 0;
                }
                PMainR.Width = num;
                ToolStripContainer1.Refresh();
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ProjectData.ClearProjectError();
            }
        }

        private void SpL_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || e.X == tempResize)
            {
                return;
            }
            try
            {
                int num = PMainL.Width + e.X - tempResize;
                if (num < 0)
                {
                    num = 0;
                }
                PMainL.Width = num;
                ToolStripContainer1.Refresh();
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ProjectData.ClearProjectError();
            }
        }

        private void mnGotoMeasure_Click(object sender, EventArgs e)
        {
            string s = Interaction.InputBox(Strings1.Messages.PromptEnterMeasure, "Enter Measure");
            if (int.TryParse(s, out var result) && !(result < 0 || result > 999))
            {
                PanelVScroll[PanelFocus] = (int)Math.Round(0.0 - MeasureBottom[result]);
            }
        }

        public void MyO2ConstBPM(int vBPM)
        {
            SortByVPositionInsertion();
            UndoRedo.LinkedURCmd BaseUndo = null;
            UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
            UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
            RedoRemoveNoteAll(xSel: false, ref BaseUndo, ref BaseRedo);
            double num = 0.0;
            double num2 = 0.0;
            int num3 = (int)Notes[0].Value;
            int i;
            if (!NTInput)
            {
                int num4 = Information.UBound(Notes);
                for (i = 1; i <= num4; i++)
                {
                    if (Notes[i].ColumnIndex == 2)
                    {
                        num += (Notes[i].VPosition - num2) / num3;
                        num2 = Notes[i].VPosition;
                        num3 = (int)Notes[i].Value;
                    }
                    else
                    {
                        Notes[i].VPosition = vBPM * (num + (Notes[i].VPosition - num2) / num3);
                    }
                }
            }
            else
            {
                int num5 = Information.UBound(Notes);
                for (i = 1; i <= num5; i++)
                {
                    if (Notes[i].ColumnIndex == 2)
                    {
                        num += (Notes[i].VPosition - num2) / num3;
                        num2 = Notes[i].VPosition;
                        num3 = (int)Notes[i].Value;
                        continue;
                    }
                    if (Notes[i].Length == 0.0)
                    {
                        Notes[i].VPosition = vBPM * (num + (Notes[i].VPosition - num2) / num3);
                        continue;
                    }
                    double num6 = num + (Notes[i].VPosition - num2) / num3;
                    double num7 = num;
                    double num8 = num2;
                    int num9 = num3;
                    int num10 = i + 1;
                    int num11 = Information.UBound(Notes);
                    for (int j = num10; j <= num11 && !(Notes[j].VPosition >= Notes[i].VPosition + Notes[i].Length); j++)
                    {
                        if (Notes[j].ColumnIndex == 2)
                        {
                            num7 += (Notes[j].VPosition - num8) / num9;
                            num8 = Notes[j].VPosition;
                            num9 = (int)Notes[j].Value;
                        }
                    }
                    double num12 = num7 + (Notes[i].VPosition + Notes[i].Length - num8) / num9;
                    Notes[i].VPosition = vBPM * num6;
                    Notes[i].Length = vBPM * num12 - Notes[i].VPosition;
                }
            }
            i = 1;
            while (i <= Information.UBound(Notes))
            {
                if (Notes[i].ColumnIndex == 2)
                {
                    int num13 = i + 1;
                    int num14 = Information.UBound(Notes);
                    for (int k = num13; k <= num14; k++)
                    {
                        ref Note reference = ref Notes[k - 1];
                        reference = Notes[k];
                    }
                    Notes = (Note[])Utils.CopyArray(Notes, new Note[Information.UBound(Notes) - 1 + 1]);
                }
                else
                {
                    i++;
                }
            }
            RedoAddNoteAll(xSel: false, ref BaseUndo, ref BaseRedo);
            RedoRelabelNote(Notes[0], vBPM, ref BaseUndo, ref BaseRedo);
            AddUndo(BaseUndo, linkedURCmd.Next);
            SortByVPositionInsertion();
            UpdatePairing();
            Notes[0].Value = vBPM;
            THBPM.Value = new decimal(vBPM / 10000.0);
            CalculateTotalPlayableNotes();
            CalculateGreatestVPosition();
            RefreshPanelAll();
            POStatusRefresh();
        }

        public string[] MyO2GridCheck()
        {
            CalculateGreatestVPosition();
            SortByVPositionInsertion();
            string[] array = Array.Empty<string>();
            string[] array2 = Array.Empty<string>();
            string[] array3 = new string[71]
            {
            "01", "03", "04", "06", "07", "08", "09", "16", "11", "12",
            "13", "14", "15", "18", "19", "26", "21", "22", "23", "24",
            "25", "28", "29", "36", "31", "32", "33", "34", "35", "38",
            "39", "46", "41", "42", "43", "44", "45", "48", "49", "56",
            "51", "52", "53", "54", "55", "58", "59", "66", "61", "62",
            "63", "64", "65", "68", "69", "76", "71", "72", "73", "74",
            "75", "78", "79", "86", "81", "82", "83", "84", "85", "88",
            "89"
            };
            int num = 1;
            int num2 = 1;
            if (!NTInput)
            {
                int num3 = MeasureAtDisplacement(GreatestVPosition);
                for (int i = 0; i <= num3; i++)
                {
                    int num4 = num;
                    int num5 = Information.UBound(Notes);
                    int j;
                    for (j = num4; j <= num5 && MeasureAtDisplacement(Notes[j].VPosition) <= i; j++)
                    {
                    }
                    num2 = j;
                    foreach (string text in array3)
                    {
                        double[] array5 = Array.Empty<double>();
                        int num7 = num2 - 1;
                        for (int l = num; l <= num7; l++)
                        {
                            if ((Operators.CompareString(GetBMSChannelBy(Notes[l]), text, TextCompare: false) == 0) & (Math.Abs(Notes[l].VPosition - MeasureAtDisplacement(Notes[l].VPosition) * 192) > 0.0))
                            {
                                array5 = (double[])Utils.CopyArray(array5, new double[Information.UBound(array5) + 1 + 1]);
                                array5[Information.UBound(array5)] = Notes[l].VPosition - i * 192;
                                if (array5[Information.UBound(array5)] < 0.0)
                                {
                                    array5[Information.UBound(array5)] = 0.0;
                                }
                            }
                        }
                        double num8 = 192.0;
                        int num9 = Information.UBound(array5);
                        for (int m = 0; m <= num9; m++)
                        {
                            num8 = GCD(num8, array5[m]);
                        }
                        if (num8 < 3.0)
                        {
                            int num10 = 0;
                            int num11 = 0;
                            int num12 = Information.UBound(array5);
                            for (int n = 0; n <= num12; n++)
                            {
                                num10 = (int)Math.Round(num10 + Math.Abs(array5[n] - (int)Math.Round(array5[n] / 4.0) * 4));
                                num11 = (int)Math.Round(num11 + Math.Abs(array5[n] - (int)Math.Round(array5[n] / 3.0) * 3));
                            }
                            bool flag = num10 > num11;
                            array = (string[])Utils.CopyArray(array, new string[Information.UBound(array) + 1 + 1]);
                            unchecked
                            {
                                array[Information.UBound(array)] = Conversions.ToString(i) + "_" + Conversions.ToString(BMSChannelToColumn(text)) + "_" + nTitle(BMSChannelToColumn(text)) + "_" + Conversions.ToString((int)Math.Round(192.0 / num8)) + "_" + Conversions.ToString(0 - (BMS.IsChannelLongNote(text) ? 1 : 0)) + "_" + Conversions.ToString(0 - (BMS.IsChannelHidden(text) ? 1 : 0)) + "_" + Conversions.ToString(0 - (flag ? 1 : 0)) + "_" + Conversions.ToString(num11) + "_" + Conversions.ToString(num10);
                            }
                        }
                    }
                    num = num2;
                }
            }
            else
            {
                int num13 = MeasureAtDisplacement(GreatestVPosition);
                for (int num14 = 0; num14 <= num13; num14++)
                {
                    foreach (string text2 in array3)
                    {
                        double[] array7 = Array.Empty<double>();
                        int num16 = Information.UBound(Notes);
                        for (int num17 = 1; num17 <= num16 && MeasureAtDisplacement(Notes[num17].VPosition) <= num14; num17++)
                        {
                            if (Operators.CompareString(GetBMSChannelBy(Notes[num17]), text2, TextCompare: false) != 0 || BMS.IsChannelLongNote(text2) ^ (Notes[num17].Length != 0.0))
                            {
                                continue;
                            }
                            if (MeasureAtDisplacement(Notes[num17].VPosition) == num14 && Math.Abs(Notes[num17].VPosition - MeasureAtDisplacement(Notes[num17].VPosition) * 192) > 0.0)
                            {
                                array7 = (double[])Utils.CopyArray(array7, new double[Information.UBound(array7) + 1 + 1]);
                                array7[Information.UBound(array7)] = Notes[num17].VPosition - num14 * 192;
                                if (array7[Information.UBound(array7)] < 0.0)
                                {
                                    array7[Information.UBound(array7)] = 0.0;
                                }
                            }
                            if (Notes[num17].Length != 0.0 && MeasureAtDisplacement(Notes[num17].VPosition + Notes[num17].Length) == num14 && Notes[num17].VPosition + Notes[num17].Length - num14 * 192 != 0.0)
                            {
                                array7 = (double[])Utils.CopyArray(array7, new double[Information.UBound(array7) + 1 + 1]);
                                array7[Information.UBound(array7)] = Notes[num17].VPosition + Notes[num17].Length - num14 * 192;
                                if (array7[Information.UBound(array7)] < 0.0)
                                {
                                    array7[Information.UBound(array7)] = 0.0;
                                }
                            }
                        }
                        double num18 = 192.0;
                        int num19 = Information.UBound(array7);
                        for (int num20 = 0; num20 <= num19; num20++)
                        {
                            num18 = GCD(num18, array7[num20]);
                        }
                        if (num18 < 3.0)
                        {
                            int num21 = 0;
                            int num22 = 0;
                            int num23 = Information.UBound(array7);
                            for (int num24 = 0; num24 <= num23; num24++)
                            {
                                num21 = (int)Math.Round(num21 + Math.Abs(array7[num24] - (int)Math.Round(array7[num24] / 4.0) * 4));
                                num22 = (int)Math.Round(num22 + Math.Abs(array7[num24] - (int)Math.Round(array7[num24] / 3.0) * 3));
                            }
                            bool flag2 = num21 > num22;
                            array = (string[])Utils.CopyArray(array, new string[Information.UBound(array) + 1 + 1]);
                            unchecked
                            {
                                array[Information.UBound(array)] = Conversions.ToString(num14) + "_" + Conversions.ToString(BMSChannelToColumn(text2)) + "_" + nTitle(BMSChannelToColumn(text2)) + "_" + Conversions.ToString((int)Math.Round(192.0 / num18)) + "_" + Conversions.ToString(0 - (BMS.IsChannelLongNote(text2) ? 1 : 0)) + "_" + Conversions.ToString(0 - (BMS.IsChannelHidden(text2) ? 1 : 0)) + "_" + Conversions.ToString(0 - (flag2 ? 1 : 0)) + "_" + Conversions.ToString(num22) + "_" + Conversions.ToString(num21);
                            }
                        }
                    }
                }
            }
            return array;
        }

        public void MyO2GridAdjust(dgMyO2.Adj[] xaj)
        {
            UndoRedo.LinkedURCmd BaseUndo = null;
            UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
            UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
            RedoRemoveNoteAll(xSel: false, ref BaseUndo, ref BaseRedo);
            if (!NTInput)
            {
                for (int i = 0; i < xaj.Length; i++)
                {
                    dgMyO2.Adj adj = xaj[i];
                    int num = Information.UBound(Notes);
                    for (int j = 1; j <= num; j++)
                    {
                        if ((MeasureAtDisplacement(Notes[j].VPosition) == adj.Measure) & (Notes[j].ColumnIndex == adj.ColumnIndex) & (Notes[j].LongNote == adj.LongNote) & (Notes[j].Hidden == adj.Hidden))
                        {
                            Notes[j].VPosition = Conversions.ToDouble(Operators.MultiplyObject(Conversions.ToLong(Operators.DivideObject(Notes[j].VPosition, Interaction.IIf(adj.AdjTo64, 3, 4))), Interaction.IIf(adj.AdjTo64, 3, 4)));
                        }
                    }
                }
            }
            else
            {
                for (int k = 0; k < xaj.Length; k++)
                {
                    dgMyO2.Adj adj2 = xaj[k];
                    int num2 = Information.UBound(Notes);
                    for (int l = 1; l <= num2; l++)
                    {
                        if (!((Notes[l].Length != 0.0) ^ adj2.LongNote))
                        {
                            double vPosition = Notes[l].VPosition;
                            double num3 = Notes[l].VPosition + Notes[l].Length;
                            if ((MeasureAtDisplacement(Notes[l].VPosition) == adj2.Measure) & (Notes[l].ColumnIndex == adj2.ColumnIndex) & (Notes[l].Hidden == adj2.Hidden))
                            {
                                vPosition = Conversions.ToDouble(Operators.MultiplyObject(Conversions.ToLong(Operators.DivideObject(Notes[l].VPosition, Interaction.IIf(adj2.AdjTo64, 3, 4))), Interaction.IIf(adj2.AdjTo64, 3, 4)));
                            }
                            if ((Notes[l].Length > 0.0 && MeasureAtDisplacement(Notes[l].VPosition + Notes[l].Length) == adj2.Measure ? true : false) & (Notes[l].ColumnIndex == adj2.ColumnIndex) & (Notes[l].Hidden == adj2.Hidden))
                            {
                                num3 = Conversions.ToDouble(Operators.MultiplyObject(Conversions.ToLong(Operators.DivideObject(Notes[l].VPosition + Notes[l].Length, Interaction.IIf(adj2.AdjTo64, 3, 4))), Interaction.IIf(adj2.AdjTo64, 3, 4)));
                            }
                            Notes[l].VPosition = vPosition;
                            if (Notes[l].Length > 0.0)
                            {
                                Notes[l].Length = num3 - Notes[l].VPosition;
                            }
                        }
                    }
                }
            }
            RedoAddNoteAll(xSel: false, ref BaseUndo, ref BaseRedo);
            AddUndo(BaseUndo, linkedURCmd.Next);
            SortByVPositionInsertion();
            UpdatePairing();
            CalculateTotalPlayableNotes();
            CalculateGreatestVPosition();
            RefreshPanelAll();
            POStatusRefresh();
            Interaction.Beep();
        }

        private void RefreshPanelAll()
        {
            if (!IsInitializing)
            {
                RefreshPanel(0, PMainInL.DisplayRectangle);
                RefreshPanel(1, PMainIn.DisplayRectangle);
                RefreshPanel(2, PMainInR.DisplayRectangle);
            }
        }

        private object GetBuffer(int xIndex, Rectangle DisplayRect)
        {
            if (bufferlist.ContainsKey(xIndex) && rectList[xIndex] == DisplayRect)
            {
                return bufferlist[xIndex];
            }
            if (bufferlist.ContainsKey(xIndex))
            {
                bufferlist[xIndex].Dispose();
                bufferlist.Remove(xIndex);
                rectList.Remove(xIndex);
            }
            BufferedGraphics bufferedGraphics = BufferedGraphicsManager.Current.Allocate(spMain[xIndex].CreateGraphics(), DisplayRect);
            bufferlist.Add(xIndex, bufferedGraphics);
            rectList.Add(xIndex, DisplayRect);
            return bufferedGraphics;
        }

        private void RefreshPanel(int xIndex, Rectangle DisplayRect)
        {
            if (WindowState != FormWindowState.Minimized && !((DisplayRect.Width <= 0) | (DisplayRect.Height <= 0)))
            {
                BufferedGraphics bufferedGraphics = (BufferedGraphics)GetBuffer(xIndex, DisplayRect);
                bufferedGraphics.Graphics.FillRectangle(vo.Bg, DisplayRect);
                int num = spMain[xIndex].Height;
                int xTWidth = spMain[xIndex].Width;
                int xHS = PanelHScroll[xIndex];
                int xVS = PanelVScroll[xIndex];
                int num2 = -PanelVScroll[xIndex];
                int xVSu = Conversions.ToInteger(Interaction.IIf(num2 + num / gxHeight > GetMaxVPosition(), GetMaxVPosition(), num2 + num / gxHeight));
                int xI = default(int);
                DrawBackgroundColor(bufferedGraphics, num, xTWidth, xHS, xI);
                xI = DrawPanelLines(bufferedGraphics, num, xTWidth, xHS, xVS, xVSu);
                xI = DrawColumnCaptions(bufferedGraphics, xTWidth, xHS, xI);
                DrawWaveform(bufferedGraphics, num, num2, xI);
                DrawNotes(bufferedGraphics, num, xHS, xVS);
                DrawSelectionBox(xIndex, bufferedGraphics);
                if (TBSelect.Checked && KMouseOver != -1)
                {
                    DrawMouseOver(bufferedGraphics, num, xHS, xVS);
                }
                if (ShouldDrawTempNote && (SelectedColumn > -1) & (TempVPosition > -1.0))
                {
                    DrawTempNote(bufferedGraphics, num, xHS, xVS);
                }
                if (TBTimeSelect.Checked)
                {
                    DrawTimeSelection(bufferedGraphics, num, xTWidth, xHS, xVS);
                }
                if (MiddleButtonClicked)
                {
                    bufferedGraphics = DrawClickAndScroll(xIndex, bufferedGraphics);
                }
                DrawDragAndDrop(xIndex, bufferedGraphics);
                bufferedGraphics.Render(spMain[xIndex].CreateGraphics());
            }
        }

        private void DrawTempNote(BufferedGraphics e1, int xTHeight, int xHS, int xVS)
        {
            var num = (LWAV.SelectedIndex + 1) * 10000;
            var opacity = 1f;
            if (PanelKeyStates.ModifierHiddenActive())
            {
                opacity = vo.kOpacity;
            }
            var s = Functions.C10to36(num / 10000);
            if (IsColumnNumeric(SelectedColumn))
            {
                s = GetColumn(SelectedColumn).Title;
            }
            var point = new Point(HorizontalPositiontoDisplay(nLeft(SelectedColumn), xHS), NoteRowToPanelHeight(TempVPosition, xVS, xTHeight) - vo.kHeight - 10);
            var point2 = new Point(HorizontalPositiontoDisplay(nLeft(SelectedColumn) + GetColumnWidth(SelectedColumn), xHS), NoteRowToPanelHeight(TempVPosition, xVS, xTHeight) + 10);
            Pen pen;
            Color color;
            Color color2;
            SolidBrush brush;
            if (NTInput | !PanelKeyStates.ModifierLongNoteActive())
            {
                pen = new Pen(GetColumn(SelectedColumn).getBright(opacity));
                color = GetColumn(SelectedColumn).getBright(opacity);
                color2 = GetColumn(SelectedColumn).getDark(opacity);
                brush = new SolidBrush(GetColumn(SelectedColumn).cText);
            }
            else
            {
                pen = new Pen(GetColumn(SelectedColumn).getLongBright(opacity));
                color = GetColumn(SelectedColumn).getLongBright(opacity);
                color2 = GetColumn(SelectedColumn).getLongDark(opacity);
                brush = new SolidBrush(GetColumn(SelectedColumn).cLText);
            }
            if (PanelKeyStates.ModifierLandmineActive())
            {
                color = Color.Red;
                color2 = Color.Red;
            }
            var brush2 = new LinearGradientBrush(point, point2, color, color2);
            e1.Graphics.FillRectangle(brush2, HorizontalPositiontoDisplay(nLeft(SelectedColumn), xHS) + 2, NoteRowToPanelHeight(TempVPosition, xVS, xTHeight) - vo.kHeight + 1, GetColumnWidth(SelectedColumn) * gxWidth - 3f, vo.kHeight - 1);
            e1.Graphics.DrawRectangle(pen, HorizontalPositiontoDisplay(nLeft(SelectedColumn), xHS) + 1, NoteRowToPanelHeight(TempVPosition, xVS, xTHeight) - vo.kHeight, GetColumnWidth(SelectedColumn) * gxWidth - 2f, vo.kHeight);
            e1.Graphics.DrawString(s, vo.kFont, brush, HorizontalPositiontoDisplay(nLeft(SelectedColumn), xHS) + vo.kLabelHShiftL - 2, NoteRowToPanelHeight(TempVPosition, xVS, xTHeight) - vo.kHeight + vo.kLabelVShift);
        }

        private void DrawDragAndDrop(int xIndex, BufferedGraphics e1)
        {
            if (Information.UBound(DDFileName) > -1)
            {
                SolidBrush brush = new SolidBrush(Color.FromArgb(-1056964609));
                float num = (float)(spMain[xIndex].DisplayRectangle.Width / 2.0);
                float num2 = (float)(spMain[xIndex].DisplayRectangle.Height / 2.0);
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                e1.Graphics.DrawString(Microsoft.VisualBasic.Strings.Join(DDFileName, "\r\n"), Font, brush, spMain[xIndex].DisplayRectangle, stringFormat);
            }
        }

        private void DrawSelectionBox(int xIndex, BufferedGraphics e1)
        {
            if (TBSelect.Checked && xIndex == PanelFocus)
            {
                PointF pointF = pMouseMove;
                Point point = new Point(-1, -1);
                bool num = pointF == point;
                PointF lastMouseDownLocation = LastMouseDownLocation;
                Point point2 = new Point(-1, -1);
                if (!(num | (lastMouseDownLocation == point2)))
                {
                    e1.Graphics.DrawRectangle(vo.SelBox, Conversions.ToSingle(Interaction.IIf(pMouseMove.X > LastMouseDownLocation.X, LastMouseDownLocation.X, pMouseMove.X)), Conversions.ToSingle(Interaction.IIf(pMouseMove.Y > LastMouseDownLocation.Y, LastMouseDownLocation.Y, pMouseMove.Y)), Math.Abs(pMouseMove.X - LastMouseDownLocation.X), Math.Abs(pMouseMove.Y - LastMouseDownLocation.Y));
                }
            }
        }

        public object GetColumnHighlightColor(Color col, double factor = 2.0)
        {
            var clamp = delegate (object x) { return Interaction.IIf(Operators.ConditionalCompareObjectGreater(x, 255, TextCompare: false), 255, RuntimeHelpers.GetObjectValue(x)); };
            return Color.FromArgb(
                Conversions.ToInteger(clamp(col.A * factor)),
                Conversions.ToInteger(clamp(col.R * factor)),
                Conversions.ToInteger(clamp(col.G * factor)),
                Conversions.ToInteger(clamp(col.B * factor))
              );
        }

        private void DrawBackgroundColor(BufferedGraphics e1, int xTHeight, int xTWidth, int xHS, int xI1)
        {
            if (!gShowBG)
            {
                return;
            }
            var num = gColumns;
            var color2 = default(Color);
            for (xI1 = 0; xI1 <= num; xI1++)
            {
                if (!(nLeft(xI1 + 1) * gxWidth - xHS * gxWidth + 1f < 0f))
                {
                    if (nLeft(xI1) * gxWidth - xHS * gxWidth + 1f > xTWidth)
                    {
                        break;
                    }
                    if ((GetColumn(xI1).cBG.GetBrightness() != 0f) & (GetColumnWidth(xI1) > 0))
                    {
                        var color = GetColumn(xI1).cBG;
                        if (xI1 == GetColumnAtX(MouseMoveStatus.X, xHS))
                        {
                            var num2 = 1.2;
                            var columnHighlightColor = GetColumnHighlightColor(color);
                            color = columnHighlightColor != null ? (Color)columnHighlightColor : color2;
                        }
                        var brush = new SolidBrush(color);
                        e1.Graphics.FillRectangle(brush, nLeft(xI1) * gxWidth - xHS * gxWidth + 1f, 0f, GetColumnWidth(xI1) * gxWidth, xTHeight);
                    }
                }
            }
        }

        private int DrawColumnCaptions(BufferedGraphics e1, int xTWidth, int xHS, int xI1)
        {
            if (gShowC)
            {
                var num = gColumns;
                for (xI1 = 0; xI1 <= num; xI1++)
                {
                    if (!(nLeft(xI1 + 1) * gxWidth - xHS * gxWidth + 1f < 0f))
                    {
                        if (nLeft(xI1) * gxWidth - xHS * gxWidth + 1f > xTWidth)
                        {
                            break;
                        }
                        if (GetColumnWidth(xI1) > 0)
                        {
                            e1.Graphics.DrawString(nTitle(xI1), vo.ColumnTitleFont, vo.ColumnTitle, nLeft(xI1) * gxWidth - xHS * gxWidth, 0f);
                        }
                    }
                }
            }
            return xI1;
        }

        private int DrawPanelLines(BufferedGraphics e1, int xTHeight, int xTWidth, int xHS, int xVS, int xVSu)
        {
            if (gShowVerticalLine)
            {
                var num = gColumns;
                for (var i = 0; i <= num; i++)
                {
                    var num2 = nLeft(i) * gxWidth - xHS * gxWidth;
                    if (!(num2 + 1f < 0f))
                    {
                        if (num2 + 1f > xTWidth)
                        {
                            break;
                        }
                        if (GetColumnWidth(i) > 0)
                        {
                            e1.Graphics.DrawLine(vo.pVLine, num2, 0f, num2, xTHeight);
                        }
                    }
                }
            }
            var CounterResult = default(object);
            var LoopForResult = default(object);
            if (ObjectFlowControl.ForLoopControl.ForLoopInitObj(CounterResult, MeasureAtDisplacement(-xVS), MeasureAtDisplacement(xVSu), 1, ref LoopForResult, ref CounterResult))
            {
                do
                {
                    if (gShowGrid)
                    {
                        DrawGridLines(e1, xTHeight, xTWidth, xVS, Conversions.ToInteger(CounterResult), gDivide, vo.pGrid);
                    }
                    if (gShowSubGrid)
                    {
                        DrawGridLines(e1, xTHeight, xTWidth, xVS, Conversions.ToInteger(CounterResult), gSub, vo.pSub);
                    }
                    var xVPosition = MeasureBottom[Conversions.ToInteger(CounterResult)];
                    var num3 = NoteRowToPanelHeight(xVPosition, xVS, xTHeight);
                    if (gShowMeasureBar)
                    {
                        e1.Graphics.DrawLine(vo.pMLine, 0, num3, xTWidth, num3);
                    }
                    if (gShowMeasureNumber)
                    {
                        e1.Graphics.DrawString("[" + Functions.Add3Zeros(Conversions.ToInteger(CounterResult)).ToString() + "]", vo.kMFont, new SolidBrush(GetColumn(0).cText), -xHS * gxWidth, num3 - vo.kMFont.Height);
                    }
                }
                while (ObjectFlowControl.ForLoopControl.ForNextCheckObj(CounterResult, LoopForResult, ref CounterResult));
            }
            var objectValue = RuntimeHelpers.GetObjectValue(GetMouseVPosition(gSnap));
            var num4 = NoteRowToPanelHeight(Conversions.ToDouble(objectValue), xVS, xTHeight);
            var pen = new Pen(Color.White);
            e1.Graphics.DrawLine(pen, 0, num4, xTWidth, num4);
            return Conversions.ToInteger(CounterResult);
        }

        private void DrawGridLines(BufferedGraphics e1, int xTHeight, int xTWidth, int xVS, int measureIndex, int divisions, Pen pen)
        {
            int num = 0;
            double num2 = MeasureUpper(measureIndex);
            double num3 = MeasureBottom[measureIndex];
            double num4 = 192.0 / divisions;
            while (num3 < num2)
            {
                int num5 = NoteRowToPanelHeight(num3, xVS, xTHeight);
                e1.Graphics.DrawLine(pen, 0, num5, xTWidth, num5);
                num += 1;
                num3 = MeasureBottom[measureIndex] + num * num4;
            }
        }

        private bool IsNoteVisible(Note note, int xTHeight, int xVS)
        {
            float num = Math.Abs(xVS) + xTHeight / gxHeight;
            float num2 = Math.Abs(xVS) - vo.kHeight / gxHeight;
            bool flag = note.VPosition >= num2;
            bool flag2 = note.VPosition <= num2;
            bool flag3 = note.VPosition + note.Length >= num2;
            bool flag4 = flag2 && flag3;
            bool flag5 = (note.VPosition <= num2) & (Notes[note.LNPair].VPosition >= num2);
            bool flag6 = note.VPosition > num;
            if (!(!flag6 && flag) && !flag4 && !flag4)
            {
                return false;
            }
            return true;
        }

        private bool IsNoteVisible(int noteindex, int xTHeight, int xVS)
        {
            return IsNoteVisible(Notes[noteindex], xTHeight, xVS);
        }

        private void DrawNotes(BufferedGraphics e1, int xTHeight, int xHS, int xVS)
        {
            float num = Math.Abs(xVS) + xTHeight / gxHeight;
            float num2 = Math.Abs(xVS) - vo.kHeight / gxHeight;
            int num3 = Information.UBound(Notes);
            for (int i = 0; i <= num3 && !(Notes[i].VPosition > num); i += 1)
            {
                if (IsNoteVisible(i, xTHeight, xVS))
                {
                    if (NTInput)
                    {
                        DrawNoteNT(Notes[i], e1, xHS, xVS, xTHeight);
                    }
                    else
                    {
                        DrawNote(Notes[i], e1, xHS, xVS, xTHeight);
                    }
                }
            }
        }

        private Rectangle GetNoteRectangle(Note note, int xTHeight, int xHS, int xVS)
        {
            var num = HorizontalPositiontoDisplay(nLeft(note.ColumnIndex), xHS);
            var num2 = Conversions.ToInteger(Interaction.IIf(!NTInput | (bAdjustLength & !bAdjustUpper), NoteRowToPanelHeight(note.VPosition, xVS, xTHeight) - vo.kHeight - 1, NoteRowToPanelHeight(note.VPosition + note.Length, xVS, xTHeight) - vo.kHeight - 1));
            var num3 = (int)Math.Round(GetColumnWidth(note.ColumnIndex) * gxWidth + 1f);
            var num4 = Conversions.ToInteger(Interaction.IIf(!NTInput | bAdjustLength, vo.kHeight + 3, note.Length * gxHeight + vo.kHeight + 3.0));
            return new Rectangle(num, num2, num3, num4);
        }

        private Rectangle GetNoteRectangle(int noteIndex, int xTHeight, int xHS, int xVS)
        {
            return GetNoteRectangle(Notes[noteIndex], xTHeight, xHS, xVS);
        }

        private void DrawMouseOver(BufferedGraphics e1, int xTHeight, int xHS, int xVS)
        {
            if (NTInput)
            {
                if (!bAdjustLength)
                {
                    DrawNoteNT(Notes[KMouseOver], e1, xHS, xVS, xTHeight);
                }
            }
            else
            {
                DrawNote(Notes[KMouseOver], e1, xHS, xVS, xTHeight);
            }
            Rectangle noteRectangle = GetNoteRectangle(KMouseOver, xTHeight, xHS, xVS);
            object objectValue = RuntimeHelpers.GetObjectValue(Interaction.IIf(bAdjustLength, vo.kMouseOverE, vo.kMouseOver));
            Graphics graphics = e1.Graphics;
            object[] array = new object[5]
                {
                RuntimeHelpers.GetObjectValue(objectValue),
                noteRectangle.X,
                noteRectangle.Y,
                noteRectangle.Width - 1,
                noteRectangle.Height - 1
                };
            bool[] array2 = new bool[5] { true, true, true, false, false };
            NewLateBinding.LateCall(graphics, null, "DrawRectangle", array, null, null, array2, IgnoreReturn: true);
            if (array2[0])
            {
                objectValue = RuntimeHelpers.GetObjectValue(array[0]);
            }
            if (array2[1])
            {
                noteRectangle.X = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(int));
            }
            if (array2[2])
            {
                noteRectangle.Y = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[2]), typeof(int));
            }
            if (!PanelKeyStates.ModifierMultiselectActive())
            {
                return;
            }
            Note[] notes = Notes;
            foreach (Note note in notes)
            {
                if (IsNoteVisible(note, xTHeight, xVS) && IsLabelMatch(note, KMouseOver))
                {
                    Rectangle noteRectangle2 = GetNoteRectangle(note, xTHeight, xHS, xVS);
                    Graphics graphics2 = e1.Graphics;
                    object[] array3 = new object[5]
                    {
                        RuntimeHelpers.GetObjectValue(objectValue),
                        noteRectangle2.X,
                        noteRectangle2.Y,
                        noteRectangle2.Width - 1,
                        noteRectangle2.Height - 1
                    };
                    array2 = new bool[5] { true, true, true, false, false };
                    NewLateBinding.LateCall(graphics2, null, "DrawRectangle", array3, null, null, array2, IgnoreReturn: true);
                    if (array2[0])
                    {
                        objectValue = RuntimeHelpers.GetObjectValue(array3[0]);
                    }
                    if (array2[1])
                    {
                        noteRectangle2.X = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[1]), typeof(int));
                    }
                    if (array2[2])
                    {
                        noteRectangle2.Y = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[2]), typeof(int));
                    }
                }
            }
        }

        private void DrawTimeSelection(BufferedGraphics e1, int xTHeight, int xTWidth, int xHS, int xVS)
        {
            long value = Notes[0].Value;
            long value2 = Notes[0].Value;
            long value3 = Notes[0].Value;
            int num = Information.UBound(Notes);
            for (int i = 1; i <= num; i++)
            {
                if (Notes[i].ColumnIndex == 2)
                {
                    if (Notes[i].VPosition <= vSelStart)
                    {
                        value = Notes[i].Value;
                    }
                    if (Notes[i].VPosition <= vSelStart + vSelHalf)
                    {
                        value2 = Notes[i].Value;
                    }
                    if (Notes[i].VPosition <= vSelStart + vSelLength)
                    {
                        value3 = Notes[i].Value;
                    }
                }
                if (Notes[i].VPosition > vSelStart + vSelLength)
                {
                    break;
                }
            }
            e1.Graphics.FillRectangle(vo.PESel, 0, NoteRowToPanelHeight(Conversions.ToDouble(Operators.AddObject(vSelStart, Interaction.IIf(vSelLength > 0.0, vSelLength, 0))), xVS, xTHeight) + Math.Abs(unchecked(0 - (vSelLength != 0.0 ? 1 : 0))), xTWidth, (int)Math.Round(Math.Abs(vSelLength) * gxHeight));
            e1.Graphics.DrawLine(vo.PECursor, 0, NoteRowToPanelHeight(vSelStart + vSelLength, xVS, xTHeight), xTWidth, NoteRowToPanelHeight(vSelStart + vSelLength, xVS, xTHeight));
            e1.Graphics.DrawLine(vo.PEHalf, 0, NoteRowToPanelHeight(vSelStart + vSelHalf, xVS, xTHeight), xTWidth, NoteRowToPanelHeight(vSelStart + vSelHalf, xVS, xTHeight));
            e1.Graphics.DrawString(Conversions.ToString(value / 10000.0), vo.PEBPMFont, vo.PEBPM, (-xHS + nLeft(2)) * gxWidth, NoteRowToPanelHeight(vSelStart, xVS, xTHeight) - vo.PEBPMFont.Height + 3);
            e1.Graphics.DrawString(Conversions.ToString(value2 / 10000.0), vo.PEBPMFont, vo.PEBPM, (-xHS + nLeft(2)) * gxWidth, NoteRowToPanelHeight(vSelStart + vSelHalf, xVS, xTHeight) - vo.PEBPMFont.Height + 3);
            e1.Graphics.DrawString(Conversions.ToString(value3 / 10000.0), vo.PEBPMFont, vo.PEBPM, (-xHS + nLeft(2)) * gxWidth, NoteRowToPanelHeight(vSelStart + vSelLength, xVS, xTHeight) - vo.PEBPMFont.Height + 3);
            if (vSelMouseOverLine == 1)
            {
                e1.Graphics.DrawRectangle(vo.PEMouseOver, 0, NoteRowToPanelHeight(vSelStart, xVS, xTHeight) - 1, xTWidth - 1, 2);
            }
            else if (vSelMouseOverLine == 2)
            {
                e1.Graphics.DrawRectangle(vo.PEMouseOver, 0, NoteRowToPanelHeight(vSelStart + vSelHalf, xVS, xTHeight) - 1, xTWidth - 1, 2);
            }
            else if (vSelMouseOverLine == 3)
            {
                e1.Graphics.DrawRectangle(vo.PEMouseOver, 0, NoteRowToPanelHeight(vSelStart + vSelLength, xVS, xTHeight) - 1, xTWidth - 1, 2);
            }
        }

        private BufferedGraphics DrawClickAndScroll(int xIndex, BufferedGraphics e1)
        {
            Panel obj = spMain[xIndex];
            Point p = new Point(0, 0);
            Point point = obj.PointToScreen(p);
            float num = MiddleButtonLocation.X - point.X;
            float num2 = MiddleButtonLocation.Y - point.Y;
            float num3 = Cursor.Position.X - point.X;
            float num4 = Cursor.Position.Y - point.Y;
            double num5 = Math.Atan2(num4 - num2, num3 - num);
            e1.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            if (!(num == num3 && num2 == num4))
            {
                PointF[] array = new PointF[3];
                ref PointF reference = ref array[0];
                PointF pointF = new PointF(num3, num4);
                reference = pointF;
                ref PointF reference2 = ref array[1];
                PointF pointF2 = new PointF((float)(Math.Cos(num5 + Math.PI / 2.0) * 10.0 + num), (float)(Math.Sin(num5 + Math.PI / 2.0) * 10.0 + num2));
                reference2 = pointF2;
                ref PointF reference3 = ref array[2];
                PointF pointF3 = new PointF((float)(Math.Cos(num5 - Math.PI / 2.0) * 10.0 + num), (float)(Math.Sin(num5 - Math.PI / 2.0) * 10.0 + num2));
                reference3 = pointF3;
                Graphics graphics = e1.Graphics;
                p = new Point((int)Math.Round(num), (int)Math.Round(num2));
                Point point2 = p;
                Point point3 = new Point((int)Math.Round(num3), (int)Math.Round(num4));
                graphics.FillPolygon(new LinearGradientBrush(point2, point3, Color.FromArgb(0), Color.FromArgb(-1)), array);
            }
            e1.Graphics.FillEllipse(Brushes.LightGray, num - 10f, num2 - 10f, 20f, 20f);
            e1.Graphics.DrawEllipse(Pens.Black, num - 8f, num2 - 8f, 16f, 16f);
            e1.Graphics.SmoothingMode = SmoothingMode.Default;
            return e1;
        }

        private void DrawWaveform(BufferedGraphics e1, int xTHeight, int xVSR, int xI1)
        {
            if (!((wWavL != null) & (wWavR != null) & (wPrecision > 0)))
            {
                return;
            }
            if (wLock)
            {
                int num = Information.UBound(Notes);
                for (int i = 1; i <= num; i++)
                {
                    if (Notes[i].ColumnIndex >= 27)
                    {
                        wPosition = Notes[i].VPosition;
                        break;
                    }
                }
            }
            PointF[] array = new PointF[xTHeight * wPrecision + 1];
            PointF[] array2 = new PointF[xTHeight * wPrecision + 1];
            double[] array3 = new double[1] { wPosition };
            decimal[] array4 = new decimal[1]
            {
                new decimal(Notes[0].Value / 10000.0)
            };
            decimal[] array5 = new decimal[1] { 0m };
            int num2 = Information.UBound(Notes);
            for (xI1 = 1; xI1 <= num2; xI1++)
            {
                if (Notes[xI1].ColumnIndex == 2)
                {
                    if (Notes[xI1].VPosition >= wPosition)
                    {
                        array3 = (double[])Utils.CopyArray(array3, new double[Information.UBound(array3) + 1 + 1]);
                        array4 = (decimal[])Utils.CopyArray(array4, new decimal[Information.UBound(array4) + 1 + 1]);
                        array5 = (decimal[])Utils.CopyArray(array5, new decimal[Information.UBound(array5) + 1 + 1]);
                        array3[Information.UBound(array3)] = Notes[xI1].VPosition;
                        ref decimal reference = ref array4[Information.UBound(array4)];
                        reference = new decimal(Notes[xI1].Value / 10000.0);
                        ref decimal reference2 = ref array5[Information.UBound(array5)];
                        reference2 = new decimal((Notes[xI1].VPosition - array3[Information.UBound(array3) - 1]) * 1.25 * wSampleRate / Convert.ToDouble(array4[Information.UBound(array4) - 1]) + Convert.ToDouble(array5[Information.UBound(array5) - 1]));
                    }
                    else
                    {
                        ref decimal reference3 = ref array4[0];
                        reference3 = new decimal(Notes[xI1].Value / 10000.0);
                    }
                }
            }
            int num3 = 0;
            for (xI1 = xTHeight * wPrecision; xI1 >= 0; xI1 += -1)
            {
                double num4 = (-xI1 / (double)wPrecision + xTHeight + xVSR * gxHeight - 1.0) / gxHeight;
                int num5 = Information.UBound(array3);
                for (num3 = 1; num3 <= num5 && !(array3[num3] >= num4); num3++)
                {
                }
                num3--;
                double num6 = Convert.ToDouble(array5[num3]) + (num4 - array3[num3]) * 1.25 * wSampleRate / Convert.ToDouble(array4[num3]);
                if (num6 <= Information.UBound(wWavL) && num6 >= 0.0)
                {
                    ref PointF reference4 = ref array[xI1];
                    reference4 = new PointF(wWavL[(int)Math.Round(Conversion.Int(num6))] * wWidth + wLeft, (float)(xI1 / (double)wPrecision));
                    ref PointF reference5 = ref array2[xI1];
                    reference5 = new PointF(wWavR[(int)Math.Round(Conversion.Int(num6))] * wWidth + wLeft, (float)(xI1 / (double)wPrecision));
                }
                else
                {
                    ref PointF reference6 = ref array[xI1];
                    reference6 = new PointF(wLeft, (float)(xI1 / (double)wPrecision));
                    ref PointF reference7 = ref array2[xI1];
                    reference7 = new PointF(wLeft, (float)(xI1 / (double)wPrecision));
                }
            }
            e1.Graphics.DrawLines(vo.pBGMWav, array);
            e1.Graphics.DrawLines(vo.pBGMWav, array2);
        }

        private void DrawNote(Note sNote, BufferedGraphics e, long xHS, long xVS, int xHeight)
        {
            if (!nEnabled(sNote.ColumnIndex))
            {
                return;
            }
            var num = 1f;
            if (sNote.Hidden)
            {
                num = vo.kOpacity;
            }
            var text = Functions.C10to36(sNote.Value / 10000);
            if (ShowFileName && Operators.CompareString(hWAV[Functions.C36to10(text)], "", TextCompare: false) != 0)
            {
                text = Path.GetFileNameWithoutExtension(hWAV[Functions.C36to10(text)]);
            }
            var point = new Point(HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS), NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) - vo.kHeight - 10);
            var point2 = new Point(HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex) + GetColumnWidth(sNote.ColumnIndex), xHS), NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) + 10);
            Color color;
            Color color2;
            SolidBrush brush;
            Pen pen;
            if (!sNote.LongNote)
            {
                pen = new Pen(GetColumn(sNote.ColumnIndex).getBright(num));
                color = GetColumn(sNote.ColumnIndex).getBright(num);
                color2 = GetColumn(sNote.ColumnIndex).getDark(num);
                if (sNote.Landmine)
                {
                    color = Color.Red;
                    color2 = Color.Red;
                }
                brush = new SolidBrush(GetColumn(sNote.ColumnIndex).cText);
            }
            else
            {
                color = GetColumn(sNote.ColumnIndex).getLongBright(num);
                color2 = GetColumn(sNote.ColumnIndex).getLongDark(num);
                brush = new SolidBrush(GetColumn(sNote.ColumnIndex).cLText);
            }
            pen = new Pen(color);
            var brush2 = new LinearGradientBrush(point, point2, color, color2);
            e.Graphics.FillRectangle(brush2, HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS) + 2, NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) - vo.kHeight + 1, GetColumnWidth(sNote.ColumnIndex) * gxWidth - 3f, vo.kHeight - 1);
            e.Graphics.DrawRectangle(pen, HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS) + 1, NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) - vo.kHeight, GetColumnWidth(sNote.ColumnIndex) * gxWidth - 2f, vo.kHeight);
            e.Graphics.DrawString(Conversions.ToString(Interaction.IIf(IsColumnNumeric(sNote.ColumnIndex), sNote.Value / 10000.0, text)), vo.kFont, brush, HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS) + vo.kLabelHShift, NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) - vo.kHeight + vo.kLabelVShift);
            if (sNote.ColumnIndex < 27 && sNote.LNPair != 0)
            {
                DrawPairedLNBody(sNote, e, xHS, xVS, xHeight, num);
            }
            if (ErrorCheck && sNote.HasError)
            {
                e.Graphics.DrawImage(Resources.ImageError, HorizontalPositiontoDisplay((int)Math.Round(nLeft(sNote.ColumnIndex) + GetColumnWidth(sNote.ColumnIndex) / 2.0), xHS) - 12, (int)Math.Round(NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) - vo.kHeight / 2.0 - 12.0), 24, 24);
            }
            if (sNote.Selected)
            {
                e.Graphics.DrawRectangle(vo.kSelected, HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS), NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) - vo.kHeight - 1, GetColumnWidth(sNote.ColumnIndex) * gxWidth, vo.kHeight + 2);
            }
        }

        private void DrawPairedLNBody(Note sNote, BufferedGraphics e, long xHS, long xVS, int xHeight, float xAlpha)
        {
            Pen pen = new Pen(GetColumn(sNote.ColumnIndex).getLongBright(xAlpha));
            Point point = new Point(HorizontalPositiontoDisplay((int)Math.Round(nLeft(sNote.ColumnIndex) - 0.5 * GetColumnWidth(sNote.ColumnIndex)), xHS), NoteRowToPanelHeight(Notes[sNote.LNPair].VPosition, xVS, xHeight));
            Point point2 = new Point(HorizontalPositiontoDisplay((int)Math.Round(nLeft(sNote.ColumnIndex) + 1.5 * GetColumnWidth(sNote.ColumnIndex)), xHS), NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) + vo.kHeight);
            LinearGradientBrush brush = new LinearGradientBrush(point, point2, GetColumn(sNote.ColumnIndex).getLongBright(xAlpha), GetColumn(sNote.ColumnIndex).getLongDark(xAlpha));
            e.Graphics.FillRectangle(brush, HorizontalPositiontoDisplay(nLeft(Notes[sNote.LNPair].ColumnIndex), xHS) + 3, NoteRowToPanelHeight(Notes[sNote.LNPair].VPosition, xVS, xHeight) + 1, GetColumnWidth(Notes[sNote.LNPair].ColumnIndex) * gxWidth - 5f, NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) - NoteRowToPanelHeight(Notes[sNote.LNPair].VPosition, xVS, xHeight) - vo.kHeight - 1);
            e.Graphics.DrawRectangle(pen, HorizontalPositiontoDisplay(nLeft(Notes[sNote.LNPair].ColumnIndex), xHS) + 2, NoteRowToPanelHeight(Notes[sNote.LNPair].VPosition, xVS, xHeight), GetColumnWidth(Notes[sNote.LNPair].ColumnIndex) * gxWidth - 4f, NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) - NoteRowToPanelHeight(Notes[sNote.LNPair].VPosition, xVS, xHeight) - vo.kHeight);
        }

        private void DrawNoteNT(Note sNote, BufferedGraphics e, long xHS, long xVS, int xHeight)
        {
            if (!nEnabled(sNote.ColumnIndex))
            {
                return;
            }
            float num = 1f;
            if (sNote.Hidden)
            {
                num = vo.kOpacity;
            }
            string text = Functions.C10to36(sNote.Value / 10000);
            if (ShowFileName && Operators.CompareString(hWAV[Functions.C36to10(text)], "", TextCompare: false) != 0)
            {
                text = Path.GetFileNameWithoutExtension(hWAV[Functions.C36to10(text)]);
            }
            Point point;
            Point point2;
            Color color;
            Color color2;
            SolidBrush brush;
            if (sNote.Length == 0.0)
            {
                point = new Point(HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS), NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) - vo.kHeight - 10);
                point2 = new Point(HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex) + GetColumnWidth(sNote.ColumnIndex), xHS), NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) + 10);
                color = GetColumn(sNote.ColumnIndex).getBright(num);
                color2 = GetColumn(sNote.ColumnIndex).getDark(num);
                if (sNote.Landmine)
                {
                    color = Color.Red;
                    color2 = Color.Red;
                }
                brush = new SolidBrush(GetColumn(sNote.ColumnIndex).cText);
            }
            else
            {
                point = new Point(HorizontalPositiontoDisplay((int)Math.Round(nLeft(sNote.ColumnIndex) - 0.5 * GetColumnWidth(sNote.ColumnIndex)), xHS), NoteRowToPanelHeight(sNote.VPosition + sNote.Length, xVS, xHeight) - vo.kHeight);
                point2 = new Point(HorizontalPositiontoDisplay((int)Math.Round(nLeft(sNote.ColumnIndex) + 1.5 * GetColumnWidth(sNote.ColumnIndex)), xHS), NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight));
                color = GetColumn(sNote.ColumnIndex).getLongBright(num);
                color2 = GetColumn(sNote.ColumnIndex).getLongDark(num);
                brush = new SolidBrush(GetColumn(sNote.ColumnIndex).cLText);
            }
            Pen pen = new Pen(color);
            LinearGradientBrush brush2 = new LinearGradientBrush(point, point2, color, color2);
            e.Graphics.FillRectangle(brush2, HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS) + 1, NoteRowToPanelHeight(sNote.VPosition + sNote.Length, xVS, xHeight) - vo.kHeight + 1, GetColumnWidth(sNote.ColumnIndex) * gxWidth - 1f, (int)Math.Round(sNote.Length * gxHeight) + vo.kHeight - 1);
            e.Graphics.DrawRectangle(pen, HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS) + 1, NoteRowToPanelHeight(sNote.VPosition + sNote.Length, xVS, xHeight) - vo.kHeight, GetColumnWidth(sNote.ColumnIndex) * gxWidth - 3f, (int)Math.Round(sNote.Length * gxHeight) + vo.kHeight);
            e.Graphics.DrawString(Conversions.ToString(Interaction.IIf(IsColumnNumeric(sNote.ColumnIndex), sNote.Value / 10000.0, text)), vo.kFont, brush, HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS) + vo.kLabelHShiftL - 2, NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) - vo.kHeight + vo.kLabelVShift);
            if (sNote.ColumnIndex < 27 && (sNote.Length == 0.0) & (sNote.LNPair != 0))
            {
                DrawPairedLNBody(sNote, e, xHS, xVS, xHeight, num);
            }
            if (sNote.Selected)
            {
                e.Graphics.DrawRectangle(vo.kSelected, HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS), NoteRowToPanelHeight(sNote.VPosition + sNote.Length, xVS, xHeight) - vo.kHeight - 1, GetColumnWidth(sNote.ColumnIndex) * gxWidth, (int)Math.Round(sNote.Length * gxHeight) + vo.kHeight + 2);
            }
            if (ErrorCheck && sNote.HasError)
            {
                e.Graphics.DrawImage(Resources.ImageError, HorizontalPositiontoDisplay((int)Math.Round(nLeft(sNote.ColumnIndex) + GetColumnWidth(sNote.ColumnIndex) / 2.0), xHS) - 12, (int)Math.Round(NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) - vo.kHeight / 2.0 - 12.0), 24, 24);
            }
        }

        private void PMainInPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if ((e.KeyCode == Keys.ShiftKey) | (e.KeyCode == Keys.ControlKey))
            {
                RefreshPanelAll();
                POStatusRefresh();
            }
            else
            {
                if (e.KeyCode == Keys.Menu)
                {
                    return;
                }
                int num = Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "Tag", Array.Empty<object>(), null, null, null));
                int num2 = -1;
                UndoRedo.LinkedURCmd BaseUndo = null;
                UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
                UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
                SelectedNotes = Array.Empty<Note>();
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        {
                            double num3 = 192.0 / gDivide;
                            if (MyProject.Computer.Keyboard.CtrlKeyDown)
                            {
                                num3 = 1.0;
                            }
                            double num4 = GetMaxVPosition() - 1.0;
                            int num5 = Information.UBound(Notes);
                            for (int i = 1; i <= num5; i++)
                            {
                                if (Notes[i].Selected)
                                {
                                    num4 = Conversions.ToDouble(Interaction.IIf(Operators.ConditionalCompareObjectGreater(Operators.AddObject(Operators.AddObject(Notes[i].VPosition, Interaction.IIf(NTInput, Notes[i].Length, 0)), num3), num4, TextCompare: false), Operators.AddObject(Operators.AddObject(Notes[i].VPosition, Interaction.IIf(NTInput, Notes[i].Length, 0)), num3), num4));
                                }
                            }
                            num4 -= 191999.0;
                            int num6 = Information.UBound(Notes);
                            for (int i = 1; i <= num6; i++)
                            {
                                if (Notes[i].Selected)
                                {
                                    double num7 = Notes[i].VPosition + num3 - num4;
                                    RedoMoveNote(Notes[i], Notes[i].ColumnIndex, num7, ref BaseUndo, ref BaseRedo);
                                    Notes[i].VPosition = num7;
                                }
                            }
                            if (num3 - num4 != 0.0)
                            {
                                AddUndo(BaseUndo, linkedURCmd.Next);
                            }
                            SortByVPositionInsertion();
                            UpdatePairing();
                            CalculateTotalPlayableNotes();
                            CalculateGreatestVPosition();
                            RefreshPanelAll();
                            break;
                        }
                    case Keys.Down:
                        {
                            double num10 = -192.0 / gDivide;
                            if (MyProject.Computer.Keyboard.CtrlKeyDown)
                            {
                                num10 = -1.0;
                            }
                            double num11 = 0.0;
                            int num12 = Information.UBound(Notes);
                            for (int i = 1; i <= num12; i++)
                            {
                                if (Notes[i].Selected)
                                {
                                    num11 = Conversions.ToDouble(Interaction.IIf(Notes[i].VPosition + num10 < num11, Notes[i].VPosition + num10, num11));
                                }
                            }
                            int num13 = Information.UBound(Notes);
                            for (int i = 1; i <= num13; i++)
                            {
                                if (Notes[i].Selected)
                                {
                                    double num14 = Notes[i].VPosition + num10 - num11;
                                    RedoMoveNote(Notes[i], Notes[i].ColumnIndex, num14, ref BaseUndo, ref BaseRedo);
                                    Notes[i].VPosition = num14;
                                }
                            }
                            if (num10 - num11 != 0.0)
                            {
                                AddUndo(BaseUndo, linkedURCmd.Next);
                            }
                            SortByVPositionInsertion();
                            UpdatePairing();
                            CalculateTotalPlayableNotes();
                            CalculateGreatestVPosition();
                            RefreshPanelAll();
                            break;
                        }
                    case Keys.Left:
                        {
                            int num15 = 0;
                            int num16 = Information.UBound(Notes);
                            for (int i = 1; i <= num16; i++)
                            {
                                if (Notes[i].Selected)
                                {
                                    num15 = Conversions.ToInteger(Interaction.IIf(ColumnArrayIndexToEnabledColumnIndex(Notes[i].ColumnIndex) - 1 < num15, ColumnArrayIndexToEnabledColumnIndex(Notes[i].ColumnIndex) - 1, num15));
                                }
                            }
                            int num17 = Information.UBound(Notes);
                            for (int i = 1; i <= num17; i++)
                            {
                                if (Notes[i].Selected)
                                {
                                    int num18 = EnabledColumnIndexToColumnArrayIndex(ColumnArrayIndexToEnabledColumnIndex(Notes[i].ColumnIndex) - 1 - num15);
                                    RedoMoveNote(Notes[i], num18, Notes[i].VPosition, ref BaseUndo, ref BaseRedo);
                                    Notes[i].ColumnIndex = num18;
                                }
                            }
                            if (-1 - num15 != 0)
                            {
                                AddUndo(BaseUndo, linkedURCmd.Next);
                            }
                            UpdatePairing();
                            CalculateTotalPlayableNotes();
                            RefreshPanelAll();
                            break;
                        }
                    case Keys.Right:
                        {
                            int num8 = Information.UBound(Notes);
                            for (int i = 1; i <= num8; i++)
                            {
                                if (Notes[i].Selected)
                                {
                                    int num9 = EnabledColumnIndexToColumnArrayIndex(ColumnArrayIndexToEnabledColumnIndex(Notes[i].ColumnIndex) + 1);
                                    RedoMoveNote(Notes[i], num9, Notes[i].VPosition, ref BaseUndo, ref BaseRedo);
                                    Notes[i].ColumnIndex = num9;
                                }
                            }
                            AddUndo(BaseUndo, linkedURCmd.Next);
                            UpdatePairing();
                            CalculateTotalPlayableNotes();
                            RefreshPanelAll();
                            break;
                        }
                    case Keys.Delete:
                        mnDelete_Click(mnDelete, EventArgs.Empty);
                        break;
                    case Keys.Home:
                        if (PanelFocus == 0)
                        {
                            LeftPanelScroll.Value = 0;
                        }
                        if (PanelFocus == 1)
                        {
                            MainPanelScroll.Value = 0;
                        }
                        if (PanelFocus == 2)
                        {
                            RightPanelScroll.Value = 0;
                        }
                        break;
                    case Keys.End:
                        if (PanelFocus == 0)
                        {
                            LeftPanelScroll.Value = LeftPanelScroll.Minimum;
                        }
                        if (PanelFocus == 1)
                        {
                            MainPanelScroll.Value = MainPanelScroll.Minimum;
                        }
                        if (PanelFocus == 2)
                        {
                            RightPanelScroll.Value = RightPanelScroll.Minimum;
                        }
                        break;
                    case Keys.Prior:
                        if (PanelFocus == 0)
                        {
                            LeftPanelScroll.Value = Conversions.ToInteger(Interaction.IIf(LeftPanelScroll.Value - gPgUpDn > LeftPanelScroll.Minimum, LeftPanelScroll.Value - gPgUpDn, LeftPanelScroll.Minimum));
                        }
                        if (PanelFocus == 1)
                        {
                            MainPanelScroll.Value = Conversions.ToInteger(Interaction.IIf(MainPanelScroll.Value - gPgUpDn > MainPanelScroll.Minimum, MainPanelScroll.Value - gPgUpDn, MainPanelScroll.Minimum));
                        }
                        if (PanelFocus == 2)
                        {
                            RightPanelScroll.Value = Conversions.ToInteger(Interaction.IIf(RightPanelScroll.Value - gPgUpDn > RightPanelScroll.Minimum, RightPanelScroll.Value - gPgUpDn, RightPanelScroll.Minimum));
                        }
                        break;
                    case Keys.Next:
                        if (PanelFocus == 0)
                        {
                            LeftPanelScroll.Value = Conversions.ToInteger(Interaction.IIf(LeftPanelScroll.Value + gPgUpDn < 0, LeftPanelScroll.Value + gPgUpDn, 0));
                        }
                        if (PanelFocus == 1)
                        {
                            MainPanelScroll.Value = Conversions.ToInteger(Interaction.IIf(MainPanelScroll.Value + gPgUpDn < 0, MainPanelScroll.Value + gPgUpDn, 0));
                        }
                        if (PanelFocus == 2)
                        {
                            RightPanelScroll.Value = Conversions.ToInteger(Interaction.IIf(RightPanelScroll.Value + gPgUpDn < 0, RightPanelScroll.Value + gPgUpDn, 0));
                        }
                        break;
                    case Keys.Oemcomma:
                        if (decimal.Compare(new decimal(gDivide * 2), CGDivide.Maximum) <= 0)
                        {
                            CGDivide.Value = new decimal(gDivide * 2);
                        }
                        break;
                    case Keys.OemPeriod:
                        unchecked
                        {
                            if (decimal.Compare(new decimal(gDivide / 2), CGDivide.Minimum) >= 0)
                            {
                                CGDivide.Value = new decimal(gDivide / 2);
                            }
                            break;
                        }
                    case Keys.OemQuestion:
                        CGDivide.Value = new decimal(gSlash);
                        break;
                    case Keys.Oemplus:
                        {
                            NumericUpDown cGHeight2 = CGHeight;
                            NumericUpDown numericUpDown = cGHeight2;
                            numericUpDown.Value = Conversions.ToDecimal(Operators.AddObject(numericUpDown.Value, Interaction.IIf(decimal.Compare(cGHeight2.Value, decimal.Subtract(cGHeight2.Maximum, cGHeight2.Increment)) > 0, decimal.Subtract(cGHeight2.Maximum, cGHeight2.Value), cGHeight2.Increment)));
                            cGHeight2 = null;
                            break;
                        }
                    case Keys.OemMinus:
                        {
                            NumericUpDown cGHeight = CGHeight;
                            NumericUpDown numericUpDown = cGHeight;
                            numericUpDown.Value = Conversions.ToDecimal(Operators.SubtractObject(numericUpDown.Value, Interaction.IIf(decimal.Compare(cGHeight.Value, decimal.Add(cGHeight.Minimum, cGHeight.Increment)) < 0, decimal.Subtract(cGHeight.Value, cGHeight.Minimum), cGHeight.Increment)));
                            cGHeight = null;
                            break;
                        }
                    case Keys.Add:
                        IncreaseCurrentWav();
                        break;
                    case Keys.Subtract:
                        DecreaseCurrentWav();
                        break;
                    case Keys.G:
                        if (!MyProject.Computer.Keyboard.CtrlKeyDown)
                        {
                            CGSnap.Checked = !gSnap;
                        }
                        break;
                    case Keys.L:
                        if (!MyProject.Computer.Keyboard.CtrlKeyDown)
                        {
                            POBLong_Click(null, null);
                        }
                        break;
                    case Keys.S:
                        if (!MyProject.Computer.Keyboard.CtrlKeyDown)
                        {
                            POBNormal_Click(null, null);
                        }
                        break;
                    case Keys.D:
                        CGDisableVertical.Checked = !CGDisableVertical.Checked;
                        break;
                    case Keys.D0:
                    case Keys.NumPad0:
                        MoveToBGM(BaseUndo, BaseRedo);
                        break;
                    case Keys.D1:
                    case Keys.NumPad1:
                    case Keys.OemSemicolon:
                        MoveToColumn(5, BaseUndo, BaseRedo);
                        break;
                    case Keys.D2:
                    case Keys.NumPad2:
                        MoveToColumn(6, BaseUndo, BaseRedo);
                        break;
                    case Keys.D3:
                    case Keys.NumPad3:
                    case Keys.Oemtilde:
                        MoveToColumn(7, BaseUndo, BaseRedo);
                        break;
                    case Keys.D4:
                    case Keys.NumPad4:
                    case Keys.OemOpenBrackets:
                        MoveToColumn(8, BaseUndo, BaseRedo);
                        break;
                    case Keys.D5:
                    case Keys.NumPad5:
                    case Keys.OemPipe:
                        MoveToColumn(9, BaseUndo, BaseRedo);
                        break;
                    case Keys.D6:
                    case Keys.NumPad6:
                    case Keys.OemCloseBrackets:
                        MoveToColumn(10, BaseUndo, BaseRedo);
                        break;
                    case Keys.D7:
                    case Keys.NumPad7:
                    case Keys.OemQuotes:
                        MoveToColumn(11, BaseUndo, BaseRedo);
                        break;
                    case Keys.D8:
                    case Keys.NumPad8:
                    case Keys.Oem8:
                        MoveToColumn(12, BaseUndo, BaseRedo);
                        break;
                }
                if (MyProject.Computer.Keyboard.CtrlKeyDown & !MyProject.Computer.Keyboard.AltKeyDown & !MyProject.Computer.Keyboard.ShiftKeyDown)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Z:
                            TBUndo_Click(TBUndo, EventArgs.Empty);
                            break;
                        case Keys.Y:
                            TBRedo_Click(TBRedo, EventArgs.Empty);
                            break;
                        case Keys.X:
                            TBCut_Click(TBCut, EventArgs.Empty);
                            break;
                        case Keys.C:
                            TBCopy_Click(TBCopy, EventArgs.Empty);
                            break;
                        case Keys.V:
                            TBPaste_Click(TBPaste, EventArgs.Empty);
                            break;
                        case Keys.A:
                            mnSelectAll_Click(mnSelectAll, EventArgs.Empty);
                            break;
                        case Keys.F:
                            TBFind_Click(TBFind, EventArgs.Empty);
                            break;
                        case Keys.T:
                            TBStatistics_Click(TBStatistics, EventArgs.Empty);
                            break;
                    }
                }
                if (PanelKeyStates.ModifierMultiselectActive() && (e.KeyCode == Keys.A) & (KMouseOver != -1))
                {
                    SelectAllWithHoveredNoteLabel();
                }
                PMainInMouseMove((Panel)sender);
                POStatusRefresh();
            }
        }

        private void SelectAllWithHoveredNoteLabel()
        {
            int num = Information.UBound(Notes);
            for (int i = 0; i <= num; i += 1)
            {
                Notes[i].Selected = Conversions.ToBoolean(Interaction.IIf(IsLabelMatch(Notes[i], KMouseOver), true, Notes[i].Selected));
            }
        }

        private bool IsLabelMatch(Note note, int index)
        {
            if (TBShowFileName.Checked)
            {
                double a = Notes[index].Value / 10000.0;
                string right = hWAV[(int)Math.Round(a)];
                if (Operators.CompareString(hWAV[(int)Math.Round(note.Value / 10000.0)], right, TextCompare: false) == 0)
                {
                    return true;
                }
            }
            else if (note.Value == Notes[index].Value)
            {
                return true;
            }
            return false;
        }

        private void DecreaseCurrentWav()
        {
            if (LWAV.SelectedIndex == -1)
            {
                LWAV.SelectedIndex = 0;
                return;
            }
            int num = LWAV.SelectedIndex - 1;
            if (num < 0)
            {
                num = 0;
            }
            LWAV.SelectedIndices.Clear();
            LWAV.SelectedIndex = num;
        }

        private void IncreaseCurrentWav()
        {
            if (LWAV.SelectedIndex == -1)
            {
                LWAV.SelectedIndex = 0;
                return;
            }
            int num = LWAV.SelectedIndex + 1;
            if (num > LWAV.Items.Count - 1)
            {
                num = LWAV.Items.Count - 1;
            }
            LWAV.SelectedIndices.Clear();
            LWAV.SelectedIndex = num;
            ValidateWavListView();
        }

        private void MoveToBGM(UndoRedo.LinkedURCmd xUndo, UndoRedo.LinkedURCmd xRedo)
        {
            UndoRedo.LinkedURCmd linkedURCmd = xRedo;
            int num = Information.UBound(Notes);
            for (int i = 1; i <= num; i++)
            {
                if (!Notes[i].Selected)
                {
                    continue;
                }
                Note[] notes = Notes;
                int num3 = 27;
                if (NTInput)
                {
                    int num4 = Information.UBound(Notes);
                    for (int j = 1; j <= num4; j++)
                    {
                        bool flag = Notes[j].VPosition <= Notes[i].VPosition + Notes[i].Length;
                        bool flag2 = Notes[j].VPosition + Notes[j].Length >= Notes[i].VPosition;
                        if ((Notes[j].ColumnIndex == num3 && flag ? true : false) && flag2)
                        {
                            num3++;
                            j = 1;
                        }
                    }
                }
                else
                {
                    int num5 = Information.UBound(Notes);
                    for (int k = 1; k <= num5; k++)
                    {
                        if (Notes[k].ColumnIndex == num3 && Notes[k].VPosition == Notes[i].VPosition)
                        {
                            num3++;
                            k = 1;
                        }
                    }
                }
                RedoMoveNote(Notes[i], num3, notes[i].VPosition, ref xUndo, ref xRedo);
                notes[i].ColumnIndex = num3;
            }
            AddUndo(xUndo, linkedURCmd.Next);
            UpdatePairing();
            CalculateTotalPlayableNotes();
            RefreshPanelAll();
        }

        private void MoveToColumn(int xTargetColumn, UndoRedo.LinkedURCmd xUndo, UndoRedo.LinkedURCmd xRedo)
        {
            UndoRedo.LinkedURCmd linkedURCmd = xRedo;
            if (xTargetColumn == -1 || !nEnabled(xTargetColumn))
            {
                return;
            }
            bool shiftKeyDown = MyProject.Computer.Keyboard.ShiftKeyDown;
            int num = Information.UBound(Notes);
            for (int i = 1; i <= num; i++)
            {
                if (!Notes[i].Selected)
                {
                    continue;
                }
                RedoMoveNote(Notes[i], xTargetColumn, Notes[i].VPosition, ref xUndo, ref xRedo);
                Notes[i].ColumnIndex = xTargetColumn;
                if (!shiftKeyDown)
                {
                    continue;
                }
                Notes[i].Selected = false;
                PanelPreviewNoteIndex(i);
                int num2 = Information.UBound(Notes);
                for (int j = 1; j <= num2; j++)
                {
                    if (j != i && Notes[j].Selected)
                    {
                        RedoMoveNote(Notes[j], Notes[j].ColumnIndex, Notes[j].VPosition, ref xUndo, ref xRedo);
                    }
                }
                break;
            }
            AddUndo(xUndo, linkedURCmd.Next);
            UpdatePairing();
            CalculateTotalPlayableNotes();
            RefreshPanelAll();
        }

        private void PMainInResize(object sender, EventArgs e)
        {
            if (!Created)
            {
                return;
            }
            int num = Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "Tag", Array.Empty<object>(), null, null, null));
            PanelWidth[0] = PMainL.Width;
            PanelWidth[1] = PMain.Width;
            PanelWidth[2] = PMainR.Width;
            switch (num)
            {
                case 0:
                    LeftPanelScroll.LargeChange = Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(sender, null, "Height", Array.Empty<object>(), null, null, null), 0.9));
                    LeftPanelScroll.Maximum = LeftPanelScroll.LargeChange - 1;
                    HSL.LargeChange = Conversions.ToInteger(Operators.DivideObject(NewLateBinding.LateGet(sender, null, "Width", Array.Empty<object>(), null, null, null), gxWidth));
                    if (HSL.Value > HSL.Maximum - HSL.LargeChange + 1)
                    {
                        HSL.Value = HSL.Maximum - HSL.LargeChange + 1;
                    }
                    break;
                case 1:
                    MainPanelScroll.LargeChange = Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(sender, null, "Height", Array.Empty<object>(), null, null, null), 0.9));
                    MainPanelScroll.Maximum = MainPanelScroll.LargeChange - 1;
                    HS.LargeChange = Conversions.ToInteger(Operators.DivideObject(NewLateBinding.LateGet(sender, null, "Width", Array.Empty<object>(), null, null, null), gxWidth));
                    if (HS.Value > HS.Maximum - HS.LargeChange + 1)
                    {
                        HS.Value = HS.Maximum - HS.LargeChange + 1;
                    }
                    break;
                case 2:
                    RightPanelScroll.LargeChange = Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(sender, null, "Height", Array.Empty<object>(), null, null, null), 0.9));
                    RightPanelScroll.Maximum = RightPanelScroll.LargeChange - 1;
                    HSR.LargeChange = Conversions.ToInteger(Operators.DivideObject(NewLateBinding.LateGet(sender, null, "Width", Array.Empty<object>(), null, null, null), gxWidth));
                    if (HSR.Value > HSR.Maximum - HSR.LargeChange + 1)
                    {
                        HSR.Value = HSR.Maximum - HSR.LargeChange + 1;
                    }
                    break;
            }
            object obj = NewLateBinding.LateGet(sender, null, "DisplayRectangle", Array.Empty<object>(), null, null, null);
            Rectangle rectangle = default(Rectangle);
            RefreshPanel(num, obj != null ? (Rectangle)obj : rectangle);
        }

        private void PMainInLostFocus(object sender, EventArgs e)
        {
            RefreshPanelAll();
        }

        private void PMainInMouseDown(object sender, MouseEventArgs e)
        {
            tempFirstMouseDown = Conversions.ToBoolean(Operators.AndObject(FirstClickDisabled, Operators.NotObject(NewLateBinding.LateGet(sender, null, "Focused", Array.Empty<object>(), null, null, null))));
            PanelFocus = Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "Tag", Array.Empty<object>(), null, null, null));
            NewLateBinding.LateCall(sender, null, "Focus", Array.Empty<object>(), null, null, null, IgnoreReturn: true);
            Point point = new Point(-1, -1);
            LastMouseDownLocation = point;
            VSValue = PanelVScroll[PanelFocus];
            if (NTInput)
            {
                bAdjustUpper = false;
                bAdjustLength = false;
            }
            ctrlPressed = false;
            DuplicatedSelectedNotes = false;
            if (MiddleButtonClicked)
            {
                MiddleButtonClicked = false;
                return;
            }
            long num = PanelHScroll[PanelFocus];
            long num2 = PanelVScroll[PanelFocus];
            int xHeight = spMain[PanelFocus].Height;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    {
                        if (tempFirstMouseDown & !TBTimeSelect.Checked)
                        {
                            RefreshPanelAll();
                            break;
                        }
                        KMouseOver = -1;
                        int NoteIndex = GetClickedNote(e, num, num2, xHeight);
                        PanelPreviewNoteIndex(NoteIndex);
                        int num3 = Information.UBound(Notes);
                        for (int i = 0; i <= num3; i++)
                        {
                            Notes[i].TempMouseDown = false;
                        }
                        HandleCurrentModeOnClick(e, num, num2, xHeight, ref NoteIndex);
                        RefreshPanelAll();
                        POStatusRefresh();
                        break;
                    }
                case MouseButtons.Middle:
                    if (MiddleButtonMoveMethod == 1)
                    {
                        tempX = e.X;
                        tempY = e.Y;
                        tempV = (int)num2;
                        tempH = (int)num;
                    }
                    else
                    {
                        MiddleButtonLocation = Cursor.Position;
                        MiddleButtonClicked = true;
                        TimerMiddle.Enabled = true;
                    }
                    break;
                case MouseButtons.Right:
                    DeselectOrRemove(e, num, num2, xHeight);
                    break;
            }
        }

        private void DeselectOrRemove(MouseEventArgs e, long xHS, long xVS, int xHeight)
        {
            KMouseOver = -1;
            SelectedNotes = Array.Empty<Note>();
            if (tempFirstMouseDown)
            {
                return;
            }
            for (int i = Information.UBound(Notes); i >= 1; i += -1)
            {
                if (MouseInNote(e, xHS, xVS, xHeight, Notes[i]))
                {
                    if (MyProject.Computer.Keyboard.ShiftKeyDown)
                    {
                        LWAV.SelectedIndices.Clear();
                        LWAV.SelectedIndex = Functions.C36to10(Functions.C10to36(Notes[i].Value / 10000)) - 1;
                        ValidateWavListView();
                        break;
                    }
                    UndoRedo.LinkedURCmd BaseUndo = null;
                    UndoRedo.LinkedURCmd BaseRedo = null;
                    RedoRemoveNote(Notes[i], ref BaseUndo, ref BaseRedo);
                    RemoveNote(i);
                    AddUndo(BaseUndo, BaseRedo);
                    RefreshPanelAll();
                    break;
                }
            }
            CalculateTotalPlayableNotes();
        }

        private int GetClickedNote(MouseEventArgs e, long xHS, long xVS, int xHeight)
        {
            int result = -1;
            for (int i = Information.UBound(Notes); i >= 0; i += -1)
            {
                if (MouseInNote(e, xHS, xVS, xHeight, Notes[i]))
                {
                    result = i;
                    deltaVPosition = Conversions.ToDouble(Interaction.IIf(NTInput, Operators.SubtractObject(GetMouseVPosition(snap: false), Notes[i].VPosition), 0));
                    if (NTInput & MyProject.Computer.Keyboard.ShiftKeyDown)
                    {
                        bAdjustUpper = e.Y <= NoteRowToPanelHeight(Notes[i].VPosition + Notes[i].Length, xVS, xHeight);
                        bAdjustLength = (e.Y >= NoteRowToPanelHeight(Notes[i].VPosition, xVS, xHeight) - vo.kHeight) | bAdjustUpper;
                    }
                    break;
                }
            }
            return result;
        }

        private void PanelPreviewNoteIndex(int NoteIndex)
        {
            if (ClickStopPreview)
            {
                PreviewNote("", bStop: true);
            }
            if (!((NoteIndex > 0) & PreviewOnClick) || IsColumnNumeric(Notes[NoteIndex].ColumnIndex))
            {
                return;
            }
            int num = (int)(Notes[NoteIndex].Value / 10000);
            if (num <= 0)
            {
                num = 1;
            }
            if (num >= 1296)
            {
                num = 1295;
            }
            if (Operators.CompareString(hWAV[num], "", TextCompare: false) != 0)
            {
                string xFileLocation = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Interaction.IIf(Operators.CompareString(ExcludeFileName(FileName), "", TextCompare: false) == 0, InitPath, ExcludeFileName(FileName)), "\\"), hWAV[num]));
                if (!ClickStopPreview)
                {
                    PreviewNote("", bStop: true);
                }
                PreviewNote(xFileLocation, bStop: false);
            }
        }

        private void HandleCurrentModeOnClick(MouseEventArgs e, long xHS, long xVS, int xHeight, ref int NoteIndex)
        {
            if (TBSelect.Checked)
            {
                OnSelectModeLeftClick(e, NoteIndex, xHeight, (int)xVS);
            }
            else if (NTInput & TBWrite.Checked)
            {
                TempVPosition = -1.0;
                SelectedColumn = -1;
                ShouldDrawTempNote = false;
                object objectValue = RuntimeHelpers.GetObjectValue(GetMouseVPosition(gSnap));
                if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectLess(objectValue, 0, TextCompare: false), Operators.CompareObjectGreaterEqual(objectValue, GetMaxVPosition(), TextCompare: false))))
                {
                    return;
                }
                object objectValue2 = RuntimeHelpers.GetObjectValue(GetColumnAtEvent(e, (int)xHS));
                for (int i = Information.UBound(Notes); i >= 1; i += -1)
                {
                    if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(Notes[i].VPosition, objectValue, TextCompare: false), Operators.CompareObjectEqual(Notes[i].ColumnIndex, objectValue2, TextCompare: false))))
                    {
                        NoteIndex = i;
                        break;
                    }
                }
                bool flag = PanelKeyStates.ModifierHiddenActive();
                if (NoteIndex > 0)
                {
                    SelectedNotes = new Note[1];
                    ref Note reference = ref SelectedNotes[0];
                    reference = Notes[NoteIndex];
                    Notes[NoteIndex].TempIndex = 0;
                    Notes[NoteIndex].TempMouseDown = true;
                    Notes[NoteIndex].Length = Conversions.ToDouble(Operators.SubtractObject(objectValue, Notes[NoteIndex].VPosition));
                    bAdjustUpper = true;
                    UndoRedo.LinkedURCmd BaseUndo = null;
                    UndoRedo.LinkedURCmd BaseRedo = null;
                    RedoLongNoteModify(SelectedNotes[0], Notes[NoteIndex].VPosition, Notes[NoteIndex].Length, ref BaseUndo, ref BaseRedo);
                    AddUndo(BaseUndo, BaseRedo);
                }
                else if (IsColumnNumeric(Conversions.ToInteger(objectValue2)))
                {
                    string prompt = Strings1.Messages.PromptEnterNumeric;
                    if (Operators.ConditionalCompareObjectEqual(objectValue2, 2, TextCompare: false))
                    {
                        prompt = Strings1.Messages.PromptEnterBPM;
                    }
                    if (Operators.ConditionalCompareObjectEqual(objectValue2, 3, TextCompare: false))
                    {
                        prompt = Strings1.Messages.PromptEnterSTOP;
                    }
                    if (Operators.ConditionalCompareObjectEqual(objectValue2, 1, TextCompare: false))
                    {
                        prompt = Strings1.Messages.PromptEnterSCROLL;
                    }
                    string text = Interaction.InputBox(prompt, Text);
                    double num = Conversion.Val(text) * 10000.0;
                    if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(Operators.CompareObjectEqual(objectValue2, 1, TextCompare: false), Operators.CompareString(text, "0", TextCompare: false) == 0), num != 0.0)))
                    {
                        if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(objectValue2, 1, TextCompare: false), num <= 0.0)))
                        {
                            num = 1.0;
                        }
                        UndoRedo.LinkedURCmd BaseUndo2 = null;
                        UndoRedo.LinkedURCmd BaseRedo2 = new UndoRedo.Void();
                        UndoRedo.LinkedURCmd linkedURCmd = BaseRedo2;
                        int num2 = Information.UBound(Notes);
                        for (int j = 1; j <= num2; j++)
                        {
                            if (Operators.ConditionalCompareObjectEqual(Notes[j].VPosition, objectValue, TextCompare: false) && Operators.ConditionalCompareObjectEqual(Notes[j].ColumnIndex, objectValue2, TextCompare: false))
                            {
                                RedoRemoveNote(Notes[j], ref BaseUndo2, ref BaseRedo2);
                            }
                        }
                        Note note = new Note(Conversions.ToInteger(objectValue2), Conversions.ToDouble(objectValue), (long)Math.Round(num), 0.0, flag);
                        RedoAddNote(note, ref BaseUndo2, ref BaseRedo2);
                        AddNote(note);
                        AddUndo(BaseUndo2, linkedURCmd.Next);
                    }
                    ShouldDrawTempNote = true;
                }
                else
                {
                    int num3 = (LWAV.SelectedIndex + 1) * 10000;
                    bool landmine = PanelKeyStates.ModifierLandmineActive();
                    Notes = (Note[])Utils.CopyArray(Notes, new Note[Information.UBound(Notes) + 1 + 1]);
                    Note[] notes = Notes;
                    int num4 = Information.UBound(Notes);
                    notes[num4].VPosition = Conversions.ToDouble(objectValue);
                    notes[num4].ColumnIndex = Conversions.ToInteger(objectValue2);
                    notes[num4].Value = num3;
                    notes[num4].Hidden = flag;
                    notes[num4].Landmine = landmine;
                    notes[num4].TempMouseDown = true;
                    SelectedNotes = new Note[1];
                    ref Note reference2 = ref SelectedNotes[0];
                    reference2 = Notes[Information.UBound(Notes)];
                    SelectedNotes[0].LNPair = -1;
                    if (TBWavIncrease.Checked)
                    {
                        IncreaseCurrentWav();
                    }
                    uAdded = false;
                    UndoRedo.LinkedURCmd BaseUndo3 = null;
                    UndoRedo.LinkedURCmd BaseRedo3 = null;
                    RedoAddNote(Notes[Information.UBound(Notes)], ref BaseUndo3, ref BaseRedo3, TBWavIncrease.Checked);
                    AddUndo(BaseUndo3, BaseRedo3);
                }
                SortByVPositionInsertion();
                UpdatePairing();
                CalculateTotalPlayableNotes();
            }
            else
            {
                if (!TBTimeSelect.Checked)
                {
                    return;
                }
                double num5 = NoteIndex < 0 ? (xHeight - xVS * gxHeight - e.Y - 1f) / gxHeight : Notes[NoteIndex].VPosition;
                vSelAdjust = PanelKeyStates.ModifierLongNoteActive();
                vSelMouseOverLine = 0;
                if (Math.Abs(e.Y - NoteRowToPanelHeight(vSelStart + vSelLength, xVS, xHeight)) <= vo.PEDeltaMouseOver)
                {
                    vSelMouseOverLine = 3;
                }
                else if (Math.Abs(e.Y - NoteRowToPanelHeight(vSelStart + vSelHalf, xVS, xHeight)) <= vo.PEDeltaMouseOver)
                {
                    vSelMouseOverLine = 2;
                }
                else if (Math.Abs(e.Y - NoteRowToPanelHeight(vSelStart, xVS, xHeight)) <= vo.PEDeltaMouseOver)
                {
                    vSelMouseOverLine = 1;
                }
                if (!vSelAdjust)
                {
                    if (vSelMouseOverLine == 1)
                    {
                        if (gSnap & (NoteIndex <= 0))
                        {
                            num5 = SnapToGrid(num5);
                        }
                        vSelLength += vSelStart - num5;
                        vSelHalf += vSelStart - num5;
                        vSelStart = num5;
                    }
                    else if (vSelMouseOverLine == 2)
                    {
                        vSelHalf = num5;
                        if (gSnap & (NoteIndex <= 0))
                        {
                            vSelHalf = SnapToGrid(vSelHalf);
                        }
                        vSelHalf -= vSelStart;
                    }
                    else if (vSelMouseOverLine == 3)
                    {
                        vSelLength = num5;
                        if (gSnap & (NoteIndex <= 0))
                        {
                            vSelLength = SnapToGrid(vSelLength);
                        }
                        vSelLength -= vSelStart;
                    }
                    else
                    {
                        vSelLength = 0.0;
                        vSelStart = num5;
                        if (gSnap & (NoteIndex <= 0))
                        {
                            vSelStart = SnapToGrid(vSelStart);
                        }
                    }
                    ValidateSelection();
                }
                else if (vSelMouseOverLine == 2)
                {
                    SortByVPositionInsertion();
                    vSelPStart = vSelStart;
                    vSelPLength = vSelLength;
                    vSelPHalf = vSelHalf;
                    vSelK = Notes;
                    vSelK = (Note[])Utils.CopyArray(vSelK, new Note[Information.UBound(vSelK) + 1]);
                    if (gSnap & (NoteIndex <= 0) & !MyProject.Computer.Keyboard.CtrlKeyDown)
                    {
                        num5 = SnapToGrid(num5);
                    }
                    AddUndo(new UndoRedo.Void(), new UndoRedo.Void());
                    BPMChangeHalf(num5 - vSelHalf - vSelStart, bAddUndo: true, bOverWriteUndo: true);
                    SortByVPositionInsertion();
                    UpdatePairing();
                    CalculateGreatestVPosition();
                }
                else if ((vSelMouseOverLine == 3) | (vSelMouseOverLine == 1))
                {
                    SortByVPositionInsertion();
                    vSelPStart = vSelStart;
                    vSelPLength = vSelLength;
                    vSelPHalf = vSelHalf;
                    vSelK = Notes;
                    vSelK = (Note[])Utils.CopyArray(vSelK, new Note[Information.UBound(vSelK) + 1]);
                    if (gSnap & (NoteIndex <= 0) & !MyProject.Computer.Keyboard.CtrlKeyDown)
                    {
                        num5 = SnapToGrid(num5);
                    }
                    AddUndo(new UndoRedo.Void(), new UndoRedo.Void());
                    BPMChangeTop(Conversions.ToDouble(Operators.DivideObject(Interaction.IIf(vSelMouseOverLine == 3, num5 - vSelStart, vSelStart + vSelLength - num5), vSelLength)), bAddUndo: true, bOverWriteUndo: true);
                    SortByVPositionInsertion();
                    UpdatePairing();
                    CalculateGreatestVPosition();
                }
                else
                {
                    vSelLength = num5;
                    if (gSnap & (NoteIndex <= 0) & !MyProject.Computer.Keyboard.CtrlKeyDown)
                    {
                        vSelLength = SnapToGrid(vSelLength);
                    }
                    vSelLength -= vSelStart;
                }
                if (vSelLength != 0.0)
                {
                    double num6 = Conversions.ToDouble(Interaction.IIf(vSelLength > 0.0, vSelStart, vSelStart + vSelLength));
                    double num7 = Conversions.ToDouble(Interaction.IIf(vSelLength < 0.0, vSelStart, vSelStart + vSelLength));
                    if (NTInput)
                    {
                        int num8 = Information.UBound(Notes);
                        for (int k = 1; k <= num8; k++)
                        {
                            Notes[k].Selected = !(Notes[k].VPosition >= num7) & !(Notes[k].VPosition + Notes[k].Length < num6) & nEnabled(Notes[k].ColumnIndex);
                        }
                    }
                    else
                    {
                        int num9 = Information.UBound(Notes);
                        for (int l = 1; l <= num9; l++)
                        {
                            Notes[l].Selected = (Notes[l].VPosition >= num6) & (Notes[l].VPosition < num7) & nEnabled(Notes[l].ColumnIndex);
                        }
                    }
                }
                else
                {
                    int num10 = Information.UBound(Notes);
                    for (int m = 1; m <= num10; m++)
                    {
                        Notes[m].Selected = false;
                    }
                }
            }
        }

        private void OnSelectModeLeftClick(MouseEventArgs e, int NoteIndex, int xTHeight, int xVS)
        {
            if ((NoteIndex >= 0) & (e.Clicks == 2))
            {
                DoubleClickNoteIndex(NoteIndex);
                return;
            }
            if (NoteIndex > 0)
            {
                SelectedNotes = Array.Empty<Note>();
                Notes[NoteIndex].TempMouseDown = true;
                if (MyProject.Computer.Keyboard.CtrlKeyDown & !PanelKeyStates.ModifierMultiselectActive())
                {
                    ctrlPressed = true;
                    return;
                }
                if (PanelKeyStates.ModifierMultiselectActive())
                {
                    int num = Information.UBound(Notes);
                    for (int i = 0; i <= num; i++)
                    {
                        if (IsNoteVisible(i, xTHeight, xVS) && IsLabelMatch(Notes[i], NoteIndex))
                        {
                            Notes[i].Selected = !Notes[i].Selected;
                        }
                    }
                    return;
                }
                if (!Notes[NoteIndex].Selected)
                {
                    int num2 = Information.UBound(Notes);
                    for (int j = 0; j <= num2; j++)
                    {
                        if (Notes[j].Selected)
                        {
                            Notes[j].Selected = false;
                        }
                    }
                    Notes[NoteIndex].Selected = true;
                }
                int num3 = 0;
                int num4 = Information.UBound(Notes);
                for (int k = 0; k <= num4; k++)
                {
                    if (Notes[k].Selected)
                    {
                        num3++;
                    }
                }
                bAdjustSingle = num3 == 1;
                SelectedNotes = new Note[num3 + 1];
                ref Note reference = ref SelectedNotes[0];
                reference = Notes[NoteIndex];
                Notes[NoteIndex].TempIndex = 0;
                int num5 = 1;
                int num6 = NoteIndex - 1;
                for (int l = 1; l <= num6; l++)
                {
                    if (Notes[l].Selected)
                    {
                        Notes[l].TempIndex = num5;
                        ref Note reference2 = ref SelectedNotes[num5];
                        reference2 = Notes[l];
                        num5++;
                    }
                }
                int num7 = NoteIndex + 1;
                int num8 = Information.UBound(Notes);
                for (int m = num7; m <= num8; m++)
                {
                    if (Notes[m].Selected)
                    {
                        Notes[m].TempIndex = num5;
                        ref Note reference3 = ref SelectedNotes[num5];
                        reference3 = Notes[m];
                        num5++;
                    }
                }
                uAdded = false;
                return;
            }

            SelectedNotes = Array.Empty<Note>();
            LastMouseDownLocation = e.Location;
            if (!MyProject.Computer.Keyboard.CtrlKeyDown)
            {
                int num9 = Information.UBound(Notes);
                for (int n = 0; n <= num9; n++)
                {
                    Notes[n].Selected = false;
                    Notes[n].TempSelected = false;
                }
            }
            else
            {
                int num10 = Information.UBound(Notes);
                for (int num11 = 0; num11 <= num10; num11++)
                {
                    Notes[num11].TempSelected = Notes[num11].Selected;
                }
            }
        }

        private void DoubleClickNoteIndex(int NoteIndex)
        {
            Note xN = Notes[NoteIndex];
            int columnIndex = xN.ColumnIndex;
            if (IsColumnNumeric(columnIndex))
            {
                string prompt = Strings1.Messages.PromptEnterNumeric;
                if (columnIndex == 2)
                {
                    prompt = Strings1.Messages.PromptEnterBPM;
                }
                if (columnIndex == 3)
                {
                    prompt = Strings1.Messages.PromptEnterSTOP;
                }
                if (columnIndex == 1)
                {
                    prompt = Strings1.Messages.PromptEnterSCROLL;
                }
                string text = Interaction.InputBox(prompt, Text);
                double num = Conversion.Val(text) * 10000.0;
                if ((columnIndex == 1) & (Operators.CompareString(text, "0", TextCompare: false) == 0) || num != 0.0)
                {
                    UndoRedo.LinkedURCmd BaseUndo = null;
                    UndoRedo.LinkedURCmd BaseRedo = null;
                    RedoRelabelNote(xN, (long)Math.Round(num), ref BaseUndo, ref BaseRedo);
                    if (NoteIndex == 0)
                    {
                        THBPM.Value = new decimal(num / 10000.0);
                    }
                    else
                    {
                        Notes[NoteIndex].Value = (long)Math.Round(num);
                    }
                    AddUndo(BaseUndo, BaseRedo);
                }
                return;
            }
            string text2 = Microsoft.VisualBasic.Strings.UCase(Microsoft.VisualBasic.Strings.Trim(Interaction.InputBox(Strings1.Messages.PromptEnter, Text)));
            if (Microsoft.VisualBasic.Strings.Len(text2) != 0)
            {
                if (Functions.IsBase36(text2) & !((Operators.CompareString(text2, "00", TextCompare: false) == 0) | (Operators.CompareString(text2, "0", TextCompare: false) == 0)))
                {
                    UndoRedo.LinkedURCmd BaseUndo2 = null;
                    UndoRedo.LinkedURCmd BaseRedo2 = null;
                    RedoRelabelNote(xN, Functions.C36to10(text2) * 10000, ref BaseUndo2, ref BaseRedo2);
                    Notes[NoteIndex].Value = Functions.C36to10(text2) * 10000;
                    AddUndo(BaseUndo2, BaseRedo2);
                }
                else
                {
                    Interaction.MsgBox(Strings1.Messages.InvalidLabel, MsgBoxStyle.Critical, Strings1.Messages.Err);
                }
            }
        }

        private bool MouseInNote(MouseEventArgs e, long xHS, long xVS, int xHeight, Note note)
        {
            return (e.X >= HorizontalPositiontoDisplay(nLeft(note.ColumnIndex), xHS) + 1) & (e.X <= HorizontalPositiontoDisplay(nLeft(note.ColumnIndex) + GetColumnWidth(note.ColumnIndex), xHS) - 1) & (e.Y >= NoteRowToPanelHeight(Conversions.ToDouble(Operators.AddObject(note.VPosition, Interaction.IIf(NTInput, note.Length, 0))), xVS, xHeight) - vo.kHeight) & (e.Y <= NoteRowToPanelHeight(note.VPosition, xVS, xHeight));
        }

        private void PMainInMouseEnter(object sender, EventArgs e)
        {
            spMouseOver = Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "Tag", Array.Empty<object>(), null, null, null));
            Panel panel = (Panel)sender;
            if (AutoFocusMouseEnter && Focused)
            {
                panel.Focus();
                PanelFocus = spMouseOver;
            }
            if (FirstMouseEnter)
            {
                FirstMouseEnter = false;
                panel.Focus();
                PanelFocus = spMouseOver;
            }
        }

        private void PMainInMouseLeave(object sender, EventArgs e)
        {
            KMouseOver = -1;
            SelectedNotes = Array.Empty<Note>();
            TempVPosition = -1.0;
            SelectedColumn = -1;
            RefreshPanelAll();
        }

        private void PMainInMouseMove(Panel sender)
        {
            Point point = sender.PointToClient(Cursor.Position);
            PMainInMouseMove(sender, new MouseEventArgs(MouseButtons.None, 0, point.X, point.Y, 0));
        }

        private void PMainInMouseMove(object sender, MouseEventArgs e)
        {
            MouseMoveStatus = e.Location;
            int num = Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "Tag", Array.Empty<object>(), null, null, null));
            long num2 = PanelHScroll[num];
            long num3 = PanelVScroll[num];
            int num4 = spMain[num].Height;
            int num5 = spMain[num].Width;
            switch (e.Button)
            {
                case MouseButtons.None:
                    {
                        if (MiddleButtonClicked)
                        {
                            break;
                        }
                        if (isFullScreen)
                        {
                            if (e.Y < 5)
                            {
                                ToolStripContainer1.TopToolStripPanelVisible = true;
                            }
                            else
                            {
                                ToolStripContainer1.TopToolStripPanelVisible = false;
                            }
                        }
                        bool flag = false;
                        int num6 = -1;
                        for (int i = Information.UBound(Notes); i >= 0; i += -1)
                        {
                            unchecked
                            {
                                if (MouseInNote(e, num2, num3, num4, Notes[i]))
                                {
                                    num6 = i;
                                    flag = num6 == KMouseOver;
                                    if (NTInput)
                                    {
                                        int num7 = NoteRowToPanelHeight(Notes[i].VPosition + Notes[i].Length, num3, num4);
                                        bool flag2 = (e.Y <= num7) & PanelKeyStates.ModifierLongNoteActive();
                                        bool flag3 = (e.Y >= num7 - vo.kHeight || flag2) & PanelKeyStates.ModifierLongNoteActive();
                                        flag = flag & (flag2 == bAdjustUpper) & (flag3 == bAdjustLength);
                                        bAdjustUpper = flag2;
                                        bAdjustLength = flag3;
                                    }
                                    break;
                                }
                            }
                        }
                        bool @checked = TBTimeSelect.Checked;
                        if (TBSelect.Checked || @checked)
                        {
                            if (flag)
                            {
                                break;
                            }
                            if (KMouseOver >= 0)
                            {
                                KMouseOver = -1;
                            }
                            if (@checked)
                            {
                                int num8 = vSelMouseOverLine;
                                vSelMouseOverLine = 0;
                                if (Math.Abs(e.Y - NoteRowToPanelHeight(vSelStart + vSelLength, num3, num4)) <= vo.PEDeltaMouseOver)
                                {
                                    vSelMouseOverLine = 3;
                                }
                                else if (Math.Abs(e.Y - NoteRowToPanelHeight(vSelStart + vSelHalf, num3, num4)) <= vo.PEDeltaMouseOver)
                                {
                                    vSelMouseOverLine = 2;
                                }
                                else if (Math.Abs(e.Y - NoteRowToPanelHeight(vSelStart, num3, num4)) <= vo.PEDeltaMouseOver)
                                {
                                    vSelMouseOverLine = 1;
                                }
                            }
                            if (num6 > -1)
                            {
                                DrawNoteHoverHighlight(num, num2, num3, num4, num6);
                            }
                            KMouseOver = num6;
                        }
                        else if (TBWrite.Checked)
                        {
                            TempVPosition = (num4 - num3 * gxHeight - e.Y - 1f) / gxHeight;
                            if (gSnap)
                            {
                                TempVPosition = SnapToGrid(TempVPosition);
                            }
                            SelectedColumn = Conversions.ToInteger(GetColumnAtEvent(e, (int)num2));
                            TempLength = 0.0;
                            if (num6 > -1)
                            {
                                TempLength = Notes[num6].Length;
                            }
                            RefreshPanelAll();
                        }
                        break;
                    }
                case MouseButtons.Left:
                    if (tempFirstMouseDown & !TBTimeSelect.Checked)
                    {
                        break;
                    }
                    tempX = 0;
                    tempY = 0;
                    if ((e.X < 0) | (e.X > num5) | (e.Y < 0) | (e.Y > num4))
                    {
                        if (e.X < 0)
                        {
                            tempX = e.X;
                        }
                        if (e.X > num5)
                        {
                            tempX = e.X - num5;
                        }
                        if (e.Y < 0)
                        {
                            tempY = e.Y;
                        }
                        if (e.Y > num4)
                        {
                            tempY = e.Y - num4;
                        }
                        Timer1.Enabled = true;
                    }
                    else
                    {
                        Timer1.Enabled = false;
                    }
                    if (TBSelect.Checked)
                    {
                        pMouseMove = e.Location;
                        PointF lastMouseDownLocation = LastMouseDownLocation;
                        Point point = new Point(-1, -1);
                        if (!(lastMouseDownLocation == point))
                        {
                            UpdateSelectionBox(num2, num3, num4);
                        }
                        else if (SelectedNotes.Length != 0)
                        {
                            UpdateSelectedNotes(num4, num3, num2, e);
                        }
                        else if (ctrlPressed)
                        {
                            OnDuplicateSelectedNotes(num4, num3, num2, e);
                        }
                    }
                    else if (TBWrite.Checked)
                    {
                        if (NTInput)
                        {
                            OnWriteModeMouseMove(num4, num3, e);
                            break;
                        }
                        TempVPosition = (num4 - num3 * gxHeight - e.Y - 1f) / gxHeight;
                        if (gSnap)
                        {
                            TempVPosition = SnapToGrid(TempVPosition);
                        }
                        SelectedColumn = Conversions.ToInteger(GetColumnAtEvent(e, (int)num2));
                    }
                    else if (TBTimeSelect.Checked)
                    {
                        OnTimeSelectClick(num4, num2, num3, e);
                    }
                    break;
                case MouseButtons.Middle:
                    OnPanelMousePan(e);
                    break;
            }
            object objectValue = RuntimeHelpers.GetObjectValue(GetColumnAtEvent(e, (int)num2));
            object objectValue2 = RuntimeHelpers.GetObjectValue(GetMouseVPosition(gSnap));
            if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectNotEqual(objectValue2, lastVPos, TextCompare: false), Operators.CompareObjectNotEqual(objectValue, lastColumn, TextCompare: false))))
            {
                lastVPos = RuntimeHelpers.GetObjectValue(objectValue2);
                lastColumn = RuntimeHelpers.GetObjectValue(objectValue);
                POStatusRefresh();
                RefreshPanelAll();
            }
        }

        private void UpdateSelectedNotes(double xHeight, double xvs, double xhs, MouseEventArgs e)
        {
            int num = Information.UBound(Notes);
            int num2 = default(int);
            for (int i = 1; i <= num; i++)
            {
                if (Notes[i].TempMouseDown)
                {
                    num2 = i;
                    break;
                }
            }
            double num3 = Conversions.ToDouble(GetMouseVPosition(gSnap));
            if (bAdjustLength & bAdjustSingle)
            {
                if (bAdjustUpper && num3 < Notes[num2].VPosition)
                {
                    bAdjustUpper = false;
                    Note[] notes = Notes;
                    Note[] array = notes;
                    int num4 = num2;
                    array[num4].VPosition = notes[num4].VPosition + Notes[num2].Length;
                    notes = Notes;
                    Note[] array2 = notes;
                    num4 = num2;
                    array2[num4].Length = notes[num4].Length * -1.0;
                }
                else if (!bAdjustUpper && num3 > Notes[num2].VPosition + Notes[num2].Length)
                {
                    bAdjustUpper = true;
                    Note[] notes = Notes;
                    Note[] array3 = notes;
                    int num4 = num2;
                    array3[num4].VPosition = notes[num4].VPosition + Notes[num2].Length;
                    notes = Notes;
                    Note[] array4 = notes;
                    num4 = num2;
                    array4[num4].Length = notes[num4].Length * -1.0;
                }
            }
            if (!bAdjustLength)
            {
                OnSelectModeMoveNotes(e, (long)Math.Round(xhs), num2);
            }
            else if (bAdjustUpper)
            {
                double dVPosition = num3 - Notes[num2].VPosition - Notes[num2].Length;
                OnAdjustUpperEnd(dVPosition);
            }
            else
            {
                double dVPosition2 = num3 - Notes[num2].VPosition;
                OnAdjustLowerEnd(dVPosition2);
            }
            SortByVPositionInsertion();
            UpdatePairing();
            CalculateTotalPlayableNotes();
        }

        private void OnPanelMousePan(MouseEventArgs e)
        {
            if (MiddleButtonMoveMethod != 1)
            {
                return;
            }
            int num = (int)Math.Round(tempV + (tempY - e.Y) / gxHeight);
            int num2 = (int)Math.Round(tempH + (tempX - e.X) / gxWidth);
            if (num > 0)
            {
                num = 0;
            }
            if (num2 < 0)
            {
                num2 = 0;
            }
            switch (PanelFocus)
            {
                case 0:
                    if (num < LeftPanelScroll.Minimum)
                    {
                        num = LeftPanelScroll.Minimum;
                    }
                    LeftPanelScroll.Value = num;
                    if (num2 > HSL.Maximum - HSL.LargeChange + 1)
                    {
                        num2 = HSL.Maximum - HSL.LargeChange + 1;
                    }
                    HSL.Value = num2;
                    break;
                case 1:
                    if (num < MainPanelScroll.Minimum)
                    {
                        num = MainPanelScroll.Minimum;
                    }
                    MainPanelScroll.Value = num;
                    if (num2 > HS.Maximum - HS.LargeChange + 1)
                    {
                        num2 = HS.Maximum - HS.LargeChange + 1;
                    }
                    HS.Value = num2;
                    break;
                case 2:
                    if (num < RightPanelScroll.Minimum)
                    {
                        num = RightPanelScroll.Minimum;
                    }
                    RightPanelScroll.Value = num;
                    if (num2 > HSR.Maximum - HSR.LargeChange + 1)
                    {
                        num2 = HSR.Maximum - HSR.LargeChange + 1;
                    }
                    HSR.Value = num2;
                    break;
            }
        }

        private void OnTimeSelectClick(double xHeight, double xHS, double xvs, MouseEventArgs e)
        {
            int num = -1;
            if (Notes != null)
            {
                for (int i = Information.UBound(Notes); i >= 0; i += -1)
                {
                    if (MouseInNote(e, (long)Math.Round(xHS), (long)Math.Round(xvs), (int)Math.Round(xHeight), Notes[i]))
                    {
                        num = i;
                        break;
                    }
                }
            }
            if (!vSelAdjust)
            {
                unchecked
                {
                    if (vSelMouseOverLine == 1)
                    {
                        double num2 = (xHeight - xvs * gxHeight - e.Y - 1.0) / gxHeight;
                        if (num >= 0)
                        {
                            num2 = Notes[num].VPosition;
                        }
                        if ((gSnap && num <= 0) & !MyProject.Computer.Keyboard.CtrlKeyDown)
                        {
                            num2 = SnapToGrid(num2);
                        }
                        vSelLength += vSelStart - num2;
                        vSelHalf += vSelStart - num2;
                        vSelStart = num2;
                    }
                    else if (vSelMouseOverLine == 2)
                    {
                        vSelHalf = (xHeight - xvs * gxHeight - e.Y - 1.0) / gxHeight;
                        if (num >= 0)
                        {
                            vSelHalf = Notes[num].VPosition;
                        }
                        if ((gSnap && num <= 0) & !MyProject.Computer.Keyboard.CtrlKeyDown)
                        {
                            vSelHalf = SnapToGrid(vSelHalf);
                        }
                        vSelHalf -= vSelStart;
                    }
                    else if (vSelMouseOverLine == 3)
                    {
                        vSelLength = (xHeight - xvs * gxHeight - e.Y - 1.0) / gxHeight;
                        if (num >= 0)
                        {
                            vSelLength = Notes[num].VPosition;
                        }
                        if ((gSnap && num <= 0) & !MyProject.Computer.Keyboard.CtrlKeyDown)
                        {
                            vSelLength = SnapToGrid(vSelLength);
                        }
                        vSelLength -= vSelStart;
                    }
                    else
                    {
                        if (num >= 0)
                        {
                            vSelLength = Notes[num].VPosition;
                        }
                        else
                        {
                            vSelLength = (xHeight - xvs * gxHeight - e.Y - 1.0) / gxHeight;
                            if (gSnap & !MyProject.Computer.Keyboard.CtrlKeyDown)
                            {
                                vSelLength = SnapToGrid(vSelLength);
                            }
                        }
                        vSelLength -= vSelStart;
                        vSelHalf = vSelLength / 2.0;
                    }
                    ValidateSelection();
                }
            }
            else
            {
                double num3 = (xHeight - xvs * gxHeight - e.Y - 1.0) / gxHeight;
                if (vSelMouseOverLine == 2)
                {
                    vSelStart = vSelPStart;
                    vSelLength = vSelPLength;
                    vSelHalf = vSelPHalf;
                    Notes = vSelK;
                    Notes = (Note[])Utils.CopyArray(Notes, new Note[Information.UBound(Notes) + 1]);
                    if (gSnap & !MyProject.Computer.Keyboard.CtrlKeyDown)
                    {
                        num3 = SnapToGrid(num3);
                    }
                    BPMChangeHalf(num3 - vSelHalf - vSelStart, bAddUndo: true, bOverWriteUndo: true);
                    SortByVPositionInsertion();
                    UpdatePairing();
                    CalculateGreatestVPosition();
                }
                else if ((vSelMouseOverLine == 3) | (vSelMouseOverLine == 1))
                {
                    vSelStart = vSelPStart;
                    vSelLength = vSelPLength;
                    vSelHalf = vSelPHalf;
                    Notes = vSelK;
                    Notes = (Note[])Utils.CopyArray(Notes, new Note[Information.UBound(Notes) + 1]);
                    if (gSnap & !MyProject.Computer.Keyboard.CtrlKeyDown)
                    {
                        num3 = SnapToGrid(num3);
                    }
                    BPMChangeTop(Conversions.ToDouble(Operators.DivideObject(Interaction.IIf(vSelMouseOverLine == 3, num3 - vSelStart, vSelStart + vSelLength - num3), vSelLength)), bAddUndo: true, bOverWriteUndo: true);
                    SortByVPositionInsertion();
                    UpdatePairing();
                    CalculateGreatestVPosition();
                }
                else
                {
                    vSelLength = num3;
                    if (gSnap & !MyProject.Computer.Keyboard.CtrlKeyDown)
                    {
                        vSelLength = SnapToGrid(vSelLength);
                    }
                    if (num >= 0)
                    {
                        vSelLength = Notes[num].VPosition;
                    }
                    vSelLength -= vSelStart;
                    ValidateSelection();
                }
            }
            if (vSelLength != 0.0)
            {
                double num4 = Conversions.ToDouble(Interaction.IIf(vSelLength > 0.0, vSelStart, vSelStart + vSelLength));
                double num5 = Conversions.ToDouble(Interaction.IIf(vSelLength < 0.0, vSelStart, vSelStart + vSelLength));
                if (NTInput)
                {
                    int num6 = Information.UBound(Notes);
                    for (int j = 1; j <= num6; j++)
                    {
                        Notes[j].Selected = (Notes[j].VPosition < num5) & (Notes[j].VPosition + Notes[j].Length >= num4) & nEnabled(Notes[j].ColumnIndex);
                    }
                }
                else
                {
                    int num7 = Information.UBound(Notes);
                    for (int k = 1; k <= num7; k++)
                    {
                        Notes[k].Selected = (Notes[k].VPosition >= num4) & (Notes[k].VPosition < num5) & nEnabled(Notes[k].ColumnIndex);
                    }
                }
            }
            else
            {
                int num8 = Information.UBound(Notes);
                for (int l = 1; l <= num8; l++)
                {
                    Notes[l].Selected = false;
                }
            }
        }

        private void OnAdjustUpperEnd(double dVPosition)
        {
            double num = 0.0;
            double num2 = 191999.0;
            int num3 = Information.UBound(Notes);
            for (int i = 1; i <= num3; i++)
            {
                if (Notes[i].Selected)
                {
                    if (Notes[i].Length + dVPosition < num)
                    {
                        num = Notes[i].Length + dVPosition;
                    }
                    if (Notes[i].Length + Notes[i].VPosition + dVPosition > num2)
                    {
                        num2 = Notes[i].Length + Notes[i].VPosition + dVPosition;
                    }
                }
            }
            num2 -= 191999.0;
            UndoRedo.LinkedURCmd BaseUndo = null;
            UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
            UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
            int num4 = Information.UBound(Notes);
            for (int j = 1; j <= num4; j++)
            {
                if (Notes[j].Selected)
                {
                    double num5 = Notes[j].Length + dVPosition - num - num2;
                    RedoLongNoteModify(SelectedNotes[Notes[j].TempIndex], Notes[j].VPosition, num5, ref BaseUndo, ref BaseRedo);
                    Notes[j].Length = num5;
                }
            }
            if (dVPosition - num - num2 != 0.0)
            {
                AddUndo(BaseUndo, linkedURCmd.Next, uAdded);
                if (!uAdded)
                {
                    uAdded = true;
                }
            }
        }

        private void OnAdjustLowerEnd(double dVPosition)
        {
            double num = 0.0;
            double num2 = 0.0;
            int num3 = Information.UBound(Notes);
            for (int i = 1; i <= num3; i++)
            {
                if (Notes[i].Selected && Notes[i].Length - dVPosition < num)
                {
                    num = Notes[i].Length - dVPosition;
                }
                if (Notes[i].Selected && Notes[i].VPosition + dVPosition < num2)
                {
                    num2 = Notes[i].VPosition + dVPosition;
                }
            }
            UndoRedo.LinkedURCmd BaseUndo = null;
            UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
            UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
            int num4 = Information.UBound(Notes);
            for (int i = 0; i <= num4; i++)
            {
                if (Notes[i].Selected)
                {
                    double num5 = Notes[i].VPosition + dVPosition + num - num2;
                    double num6 = Notes[i].Length - dVPosition - num + num2;
                    RedoLongNoteModify(SelectedNotes[Notes[i].TempIndex], num5, num6, ref BaseUndo, ref BaseRedo);
                    Notes[i].VPosition = num5;
                    Notes[i].Length = num6;
                }
            }
            if (dVPosition + num - num2 != 0.0)
            {
                AddUndo(BaseUndo, linkedURCmd.Next, uAdded);
                if (!uAdded)
                {
                    uAdded = true;
                }
            }
        }

        private void OnDuplicateSelectedNotes(double xHeight, double xVS, double xHS, MouseEventArgs e)
        {
            int num = Information.UBound(Notes);
            int i;
            double num2;
            int num5;
            int num6;
            double num7;
            double num8;
            for (i = 1; i <= num && !Notes[i].TempMouseDown; i++)
            {
            }
            object left = RuntimeHelpers.GetObjectValue(GetMouseVPosition(gSnap));
            if (DisableVerticalMove)
            {
                left = Notes[i].VPosition;
            }
            num2 = Conversions.ToDouble(Operators.SubtractObject(left, Notes[i].VPosition));
            int num3 = ColumnArrayIndexToEnabledColumnIndex(Conversions.ToInteger(GetColumnAtEvent(e, (int)Math.Round(xHS))));
            int num4 = ColumnArrayIndexToEnabledColumnIndex(Notes[i].ColumnIndex);
            num5 = num3 - num4;
            num6 = 0;
            num7 = 0.0;
            num8 = 191999.0;
            int num9 = Information.UBound(Notes);
            for (int j = 1; j <= num9; j++)
            {
                if (Notes[j].Selected)
                {
                    if (ColumnArrayIndexToEnabledColumnIndex(Notes[j].ColumnIndex) + num5 < num6)
                    {
                        num6 = ColumnArrayIndexToEnabledColumnIndex(Notes[j].ColumnIndex) + num5;
                    }
                    if (Notes[j].VPosition + num2 < num7)
                    {
                        num7 = Notes[j].VPosition + num2;
                    }
                    if (Operators.ConditionalCompareObjectGreater(Operators.AddObject(Operators.AddObject(Notes[j].VPosition, Interaction.IIf(NTInput, Notes[j].Length, 0)), num2), num8, TextCompare: false))
                    {
                        num8 = Conversions.ToDouble(Operators.AddObject(Operators.AddObject(Notes[j].VPosition, Interaction.IIf(NTInput, Notes[j].Length, 0)), num2));
                    }
                }
            }
            num8 -= 191999.0;

            if (!DuplicatedSelectedNotes & (num5 - num6 == 0) && num2 - num7 - num8 == 0.0)
            {
                return;
            }
            UndoRedo.LinkedURCmd BaseUndo = null;
            UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
            UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
            if (!DuplicatedSelectedNotes)
            {
                DuplicateSelectedNotes(i, num2, num5, num6, num7, num8);
                DuplicatedSelectedNotes = true;
            }
            else
            {
                int num10 = Information.UBound(Notes);
                for (int k = 1; k <= num10; k++)
                {
                    if (Notes[k].Selected)
                    {
                        Notes[k].ColumnIndex = EnabledColumnIndexToColumnArrayIndex(ColumnArrayIndexToEnabledColumnIndex(Notes[k].ColumnIndex) + num5 - num6);
                        Notes[k].VPosition = Notes[k].VPosition + num2 - num7 - num8;
                        RedoAddNote(Notes[k], ref BaseUndo, ref BaseRedo);
                    }
                }
                AddUndo(BaseUndo, linkedURCmd.Next, OverWrite: true);
            }
            SortByVPositionInsertion();
            UpdatePairing();
            CalculateTotalPlayableNotes();
        }

        private void OnWriteModeMouseMove(int xHeight, long xVS, MouseEventArgs e)
        {
            if (SelectedNotes.Length == 0)
            {
                return;
            }
            int num = Information.UBound(Notes);
            int num2 = default(int);
            for (int i = 1; i <= num; i += 1)
            {
                if (Notes[i].TempMouseDown)
                {
                    num2 = i;
                    break;
                }
            }
            object objectValue = RuntimeHelpers.GetObjectValue(GetMouseVPosition(gSnap));
            Note[] notes = Notes;
            int num3 = num2;
            if (bAdjustUpper && Operators.ConditionalCompareObjectLess(objectValue, notes[num3].VPosition, TextCompare: false))
            {
                bAdjustUpper = false;
                notes[num3].VPosition += notes[num3].Length;
                notes[num3].Length *= -1.0;
            }
            else if (!bAdjustUpper && Operators.ConditionalCompareObjectGreater(objectValue, notes[num3].VPosition + notes[num3].Length, TextCompare: false))
            {
                bAdjustUpper = true;
                notes[num3].VPosition += notes[num3].Length;
                notes[num3].Length *= -1.0;
            }
            if (bAdjustUpper)
            {
                notes[num3].Length = Conversions.ToDouble(Operators.SubtractObject(objectValue, notes[num3].VPosition));
            }
            else
            {
                notes[num3].Length = Conversions.ToDouble(Operators.SubtractObject(notes[num3].VPosition + notes[num3].Length, objectValue));
                notes[num3].VPosition = Conversions.ToDouble(objectValue);
            }
            if (notes[num3].VPosition < 0.0)
            {
                notes[num3].Length += notes[num3].VPosition;
                notes[num3].VPosition = 0.0;
            }
            if (notes[num3].VPosition + notes[num3].Length >= GetMaxVPosition())
            {
                notes[num3].Length = GetMaxVPosition() - 1.0 - notes[num3].VPosition;
            }
            if (SelectedNotes[0].LNPair == -1)
            {
                UndoRedo.LinkedURCmd BaseUndo = null;
                UndoRedo.LinkedURCmd BaseRedo = null;
                RedoAddNote(Notes[num2], ref BaseUndo, ref BaseRedo);
                AddUndo(BaseUndo, BaseRedo, OverWrite: true);
            }
            else
            {
                UndoRedo.LinkedURCmd BaseUndo2 = null;
                UndoRedo.LinkedURCmd BaseRedo2 = null;
                RedoLongNoteModify(SelectedNotes[0], notes[num3].VPosition, notes[num3].Length, ref BaseUndo2, ref BaseRedo2);
                AddUndo(BaseUndo2, BaseRedo2, OverWrite: true);
            }
            SelectedColumn = notes[num3].ColumnIndex;
            TempVPosition = Conversions.ToDouble(objectValue);
            TempLength = notes[num3].Length;
            SortByVPositionInsertion();
            UpdatePairing();
            CalculateTotalPlayableNotes();
        }

        private void OnSelectModeMoveNotes(MouseEventArgs e, long xHS, int xITemp)
        {
            object left = RuntimeHelpers.GetObjectValue(GetMouseVPosition(gSnap));
            if (DisableVerticalMove)
            {
                left = SelectedNotes[0].VPosition;
            }
            object right = Operators.SubtractObject(left, Notes[xITemp].VPosition);
            int i = 0;
            int num = (int)Math.Round(e.X / gxWidth + xHS);
            int num2 = default(int);
            if (num >= 0)
            {
                for (; !((num < nLeft(i + 1)) | (i >= gColumns)); i++)
                {
                }
                num2 = ColumnArrayIndexToEnabledColumnIndex(i);
            }
            int num3 = num2 - ColumnArrayIndexToEnabledColumnIndex(Notes[xITemp].ColumnIndex);
            num = 0;
            double num4 = 0.0;
            double num5 = 191999.0;
            int num6 = Information.UBound(Notes);
            for (i = 1; i <= num6; i++)
            {
                if (Notes[i].Selected)
                {
                    num = Conversions.ToInteger(Interaction.IIf(ColumnArrayIndexToEnabledColumnIndex(Notes[i].ColumnIndex) + num3 < num, ColumnArrayIndexToEnabledColumnIndex(Notes[i].ColumnIndex) + num3, num));
                    num4 = Conversions.ToDouble(Interaction.IIf(Operators.ConditionalCompareObjectLess(Operators.AddObject(Notes[i].VPosition, right), num4, TextCompare: false), Operators.AddObject(Notes[i].VPosition, right), num4));
                    num5 = Conversions.ToDouble(Interaction.IIf(Operators.ConditionalCompareObjectGreater(Operators.AddObject(Operators.AddObject(Notes[i].VPosition, Interaction.IIf(NTInput, Notes[i].Length, 0)), right), num5, TextCompare: false), Operators.AddObject(Operators.AddObject(Notes[i].VPosition, Interaction.IIf(NTInput, Notes[i].Length, 0)), right), num5));
                }
            }
            num5 -= 191999.0;
            UndoRedo.LinkedURCmd BaseUndo = null;
            UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
            UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
            int num7 = Information.UBound(Notes);
            for (i = 1; i <= num7; i++)
            {
                if (Notes[i].Selected)
                {
                    int num8 = EnabledColumnIndexToColumnArrayIndex(ColumnArrayIndexToEnabledColumnIndex(Notes[i].ColumnIndex) + num3 - num);
                    double num9 = Conversions.ToDouble(Operators.SubtractObject(Operators.SubtractObject(Operators.AddObject(Notes[i].VPosition, right), num4), num5));
                    RedoMoveNote(SelectedNotes[Notes[i].TempIndex], num8, num9, ref BaseUndo, ref BaseRedo);
                    Notes[i].ColumnIndex = num8;
                    Notes[i].VPosition = num9;
                }
            }
            AddUndo(BaseUndo, linkedURCmd.Next, uAdded);
            if (!uAdded)
            {
                uAdded = true;
            }
        }

        private void UpdateSelectionBox(long xHS, long xVS, int xHeight)
        {
            Rectangle rect = new Rectangle(Conversions.ToInteger(Interaction.IIf(pMouseMove.X > LastMouseDownLocation.X, LastMouseDownLocation.X, pMouseMove.X)), Conversions.ToInteger(Interaction.IIf(pMouseMove.Y > LastMouseDownLocation.Y, LastMouseDownLocation.Y, pMouseMove.Y)), (int)Math.Round(Math.Abs(pMouseMove.X - LastMouseDownLocation.X)), (int)Math.Round(Math.Abs(pMouseMove.Y - LastMouseDownLocation.Y)));
            int num = Information.UBound(Notes);
            for (int i = 1; i <= num; i++)
            {
                if (new Rectangle(HorizontalPositiontoDisplay(nLeft(Notes[i].ColumnIndex), xHS) + 1, NoteRowToPanelHeight(Conversions.ToDouble(Operators.AddObject(Notes[i].VPosition, Interaction.IIf(NTInput, Notes[i].Length, 0))), xVS, xHeight) - vo.kHeight, (int)Math.Round(GetColumnWidth(Notes[i].ColumnIndex) * gxWidth - 2f), Conversions.ToInteger(Operators.AddObject(vo.kHeight, Interaction.IIf(NTInput, Notes[i].Length * gxHeight, 0)))).IntersectsWith(rect))
                {
                    Notes[i].Selected = !Notes[i].TempSelected & nEnabled(Notes[i].ColumnIndex);
                }
                else
                {
                    Notes[i].Selected = Notes[i].TempSelected & nEnabled(Notes[i].ColumnIndex);
                }
            }
        }

        private void DuplicateSelectedNotes(int tempNoteIndex, double dVPosition, int dColumn, int mLeft, double mVPosition, double muVPosition)
        {
            UndoRedo.LinkedURCmd BaseUndo = null;
            UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
            UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
            Notes[tempNoteIndex].Selected = true;
            int num = 0;
            int num2 = Information.UBound(Notes);
            for (int i = 1; i <= num2; i++)
            {
                if (Notes[i].Selected)
                {
                    num++;
                }
            }
            Note[] array = new Note[num - 1 + 1];
            int num3 = 0;
            int num4 = Information.UBound(Notes);
            for (int j = 1; j <= num4; j++)
            {
                if (Notes[j].Selected)
                {
                    ref Note reference = ref array[num3];
                    reference = Notes[j];
                    array[num3].ColumnIndex = EnabledColumnIndexToColumnArrayIndex(ColumnArrayIndexToEnabledColumnIndex(Notes[j].ColumnIndex) + dColumn - mLeft);
                    array[num3].VPosition = Notes[j].VPosition + dVPosition - mVPosition - muVPosition;
                    RedoAddNote(array[num3], ref BaseUndo, ref BaseRedo);
                    Notes[j].Selected = false;
                    num3++;
                }
            }
            Notes[tempNoteIndex].TempMouseDown = false;
            int num5 = Information.UBound(Notes);
            Notes = (Note[])Utils.CopyArray(Notes, new Note[num5 + num + 1]);
            num3 = 0;
            int num6 = num5 + 1;
            int num7 = Information.UBound(Notes);
            for (int k = num6; k <= num7; k++)
            {
                ref Note reference2 = ref Notes[k];
                reference2 = array[num3];
                num3++;
            }
            AddUndo(BaseUndo, linkedURCmd.Next);
        }

        private void DrawNoteHoverHighlight(int iI, long xHS, long xVS, int xHeight, int foundNoteIndex)
        {
            int num = HorizontalPositiontoDisplay(nLeft(Notes[foundNoteIndex].ColumnIndex), xHS);
            int num2 = Conversions.ToInteger(Interaction.IIf(!NTInput | (bAdjustLength & !bAdjustUpper), NoteRowToPanelHeight(Notes[foundNoteIndex].VPosition, xVS, xHeight) - vo.kHeight - 1, NoteRowToPanelHeight(Notes[foundNoteIndex].VPosition + Notes[foundNoteIndex].Length, xVS, xHeight) - vo.kHeight - 1));
            int num3 = (int)Math.Round(GetColumnWidth(Notes[foundNoteIndex].ColumnIndex) * gxWidth + 1f);
            int num4 = Conversions.ToInteger(Interaction.IIf(!NTInput | bAdjustLength, vo.kHeight + 3, Notes[foundNoteIndex].Length * gxHeight + vo.kHeight + 3.0));
            BufferedGraphicsContext current = BufferedGraphicsManager.Current;
            Graphics targetGraphics = spMain[iI].CreateGraphics();
            Rectangle targetRectangle = new Rectangle(num, num2, num3, num4);
            BufferedGraphics bufferedGraphics = current.Allocate(targetGraphics, targetRectangle);
            Graphics graphics = bufferedGraphics.Graphics;
            SolidBrush bg = vo.Bg;
            targetRectangle = new Rectangle(num, num2, num3, num4);
            graphics.FillRectangle(bg, targetRectangle);
            if (NTInput)
            {
                DrawNoteNT(Notes[foundNoteIndex], bufferedGraphics, xHS, xVS, xHeight);
            }
            else
            {
                DrawNote(Notes[foundNoteIndex], bufferedGraphics, xHS, xVS, xHeight);
            }
            Graphics graphics2 = bufferedGraphics.Graphics;
            object[] array = new object[5]
            {
                RuntimeHelpers.GetObjectValue(Interaction.IIf(bAdjustLength, vo.kMouseOverE, vo.kMouseOver)),
                num,
                num2,
                num3 - 1,
                num4 - 1
            };
            bool[] array2 = new bool[5] { false, true, true, false, false };
            NewLateBinding.LateCall(graphics2, null, "DrawRectangle", array, null, null, array2, IgnoreReturn: true);
            if (array2[1])
            {
                num = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(int));
            }
            if (array2[2])
            {
                num2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[2]), typeof(int));
            }
            bufferedGraphics.Render(spMain[iI].CreateGraphics());
            bufferedGraphics.Dispose();
        }

        private int GetColumnAtX(int x, int xHS)
        {
            int i = 0;

            int num = (int)Math.Round(x / gxWidth + xHS);
            int cReal = 0;
            if (num >= 0)
            {
                for (; !((num < nLeft(i + 1)) | (i >= gColumns)); i++)
                {
                }

                cReal = i;
            }

            return EnabledColumnIndexToColumnArrayIndex(ColumnArrayIndexToEnabledColumnIndex(cReal));
        }

        private object GetColumnAtEvent(MouseEventArgs e, int xHS)
        {
            return GetColumnAtX(e.X, xHS);
        }

        private void PMain_Scroll(object sender, MouseEventArgs e)
        {
            if (MyProject.Computer.Keyboard.CtrlKeyDown)
            {
                double val = Math.Round(CGHeight2.Value + e.Delta / 120.0);
                CGHeight2.Value = (int)Math.Round(Math.Min(CGHeight2.Maximum, Math.Max(CGHeight2.Minimum, val)));
                CGHeight.Value = new decimal(CGHeight2.Value / 4.0);
            }
        }

        private void PMainInMouseUp(object sender, MouseEventArgs e)
        {
            tempX = 0;
            tempY = 0;
            tempV = 0;
            tempH = 0;
            VSValue = -1;
            HSValue = -1;
            Timer1.Enabled = false;
            SelectedNotes = Array.Empty<Note>();
            int num = Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "Tag", Array.Empty<object>(), null, null, null));
            if (MiddleButtonClicked && e.Button == MouseButtons.Middle && Math.Pow(MiddleButtonLocation.X - Cursor.Position.X, 2.0) + Math.Pow(MiddleButtonLocation.Y - Cursor.Position.Y, 2.0) >= vo.MiddleDeltaRelease)
            {
                MiddleButtonClicked = false;
            }
            if (TBSelect.Checked)
            {
                Point point = new Point(-1, -1);
                LastMouseDownLocation = point;
                point = new Point(-1, -1);
                pMouseMove = point;
                if (ctrlPressed & !DuplicatedSelectedNotes & !PanelKeyStates.ModifierMultiselectActive())
                {
                    int num2 = Information.UBound(Notes);
                    for (int i = 1; i <= num2; i++)
                    {
                        if (Notes[i].TempMouseDown)
                        {
                            Notes[i].Selected = !Notes[i].Selected;
                            break;
                        }
                    }
                }
                ctrlPressed = false;
                DuplicatedSelectedNotes = false;
            }
            else if (TBWrite.Checked)
            {
                if (!NTInput & !tempFirstMouseDown)
                {
                    double num3 = Conversions.ToDouble(Operators.DivideObject(Operators.SubtractObject(Operators.SubtractObject(Operators.SubtractObject(NewLateBinding.LateGet(sender, null, "Height", Array.Empty<object>(), null, null, null), PanelVScroll[num] * gxHeight), e.Y), 1), gxHeight));
                    if (gSnap)
                    {
                        num3 = SnapToGrid(num3);
                    }
                    object objectValue = RuntimeHelpers.GetObjectValue(GetColumnAtEvent(e, PanelHScroll[num]));
                    if (e.Button == MouseButtons.Left)
                    {
                        bool nHidden = PanelKeyStates.ModifierHiddenActive();
                        bool flag = PanelKeyStates.ModifierLongNoteActive();
                        bool nLandmine = PanelKeyStates.ModifierLandmineActive();
                        UndoRedo.LinkedURCmd BaseUndo = null;
                        UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
                        UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
                        if (IsColumnNumeric(Conversions.ToInteger(objectValue)))
                        {
                            string prompt = Strings1.Messages.PromptEnterNumeric;
                            if (Operators.ConditionalCompareObjectEqual(objectValue, 2, TextCompare: false))
                            {
                                prompt = Strings1.Messages.PromptEnterBPM;
                            }
                            if (Operators.ConditionalCompareObjectEqual(objectValue, 3, TextCompare: false))
                            {
                                prompt = Strings1.Messages.PromptEnterSTOP;
                            }
                            if (Operators.ConditionalCompareObjectEqual(objectValue, 1, TextCompare: false))
                            {
                                prompt = Strings1.Messages.PromptEnterSCROLL;
                            }
                            string text = Interaction.InputBox(prompt, Text);
                            long num4 = (long)Math.Round(Conversion.Val(text) * 10000.0);
                            if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(Operators.CompareObjectEqual(objectValue, 1, TextCompare: false), Operators.CompareString(text, "0", TextCompare: false) == 0), num4 != 0)))
                            {
                                int num5 = Information.UBound(Notes);
                                for (int j = 1; j <= num5; j++)
                                {
                                    if (Notes[j].VPosition == num3 && Operators.ConditionalCompareObjectEqual(Notes[j].ColumnIndex, objectValue, TextCompare: false))
                                    {
                                        RedoRemoveNote(Notes[j], ref BaseUndo, ref BaseRedo);
                                    }
                                }
                                Note note = new Note(Conversions.ToInteger(objectValue), num3, num4, unchecked(0 - (flag ? 1 : 0)), nHidden);
                                RedoAddNote(note, ref BaseUndo, ref BaseRedo);
                                AddNote(note);
                                AddUndo(BaseUndo, linkedURCmd.Next);
                            }
                        }
                        else
                        {
                            int num6 = (LWAV.SelectedIndex + 1) * 10000;
                            int num7 = Information.UBound(Notes);
                            for (int k = 1; k <= num7; k++)
                            {
                                if (Notes[k].VPosition == num3 && Operators.ConditionalCompareObjectEqual(Notes[k].ColumnIndex, objectValue, TextCompare: false))
                                {
                                    RedoRemoveNote(Notes[k], ref BaseUndo, ref BaseRedo);
                                }
                            }
                            Note note2 = new Note(Conversions.ToInteger(objectValue), num3, num6, unchecked(0 - (flag ? 1 : 0)), nHidden, nSelected: true, nLandmine);
                            RedoAddNote(note2, ref BaseUndo, ref BaseRedo);
                            AddNote(note2);
                            AddUndo(BaseUndo, BaseRedo);
                        }
                    }
                }
                if (!ShouldDrawTempNote)
                {
                    ShouldDrawTempNote = true;
                }
                TempVPosition = -1.0;
                SelectedColumn = -1;
            }
            CalculateGreatestVPosition();
            RefreshPanelAll();
        }

        private void PMainInMouseWheel(object sender, MouseEventArgs e)
        {
            if (MiddleButtonClicked)
            {
                MiddleButtonClicked = false;
            }
            switch (spMouseOver)
            {
                case 0:
                    {
                        int num = PanelVScroll[spMouseOver] - Math.Sign(e.Delta) * gWheel;
                        if (num > 0)
                        {
                            num = 0;
                        }
                        if (num < LeftPanelScroll.Minimum)
                        {
                            num = LeftPanelScroll.Minimum;
                        }
                        LeftPanelScroll.Value = num;
                        break;
                    }
                case 1:
                    {
                        int num = PanelVScroll[spMouseOver] - Math.Sign(e.Delta) * gWheel;
                        if (num > 0)
                        {
                            num = 0;
                        }
                        if (num < MainPanelScroll.Minimum)
                        {
                            num = MainPanelScroll.Minimum;
                        }
                        MainPanelScroll.Value = num;
                        break;
                    }
                case 2:
                    {
                        int num = PanelVScroll[spMouseOver] - Math.Sign(e.Delta) * gWheel;
                        if (num > 0)
                        {
                            num = 0;
                        }
                        if (num < RightPanelScroll.Minimum)
                        {
                            num = RightPanelScroll.Minimum;
                        }
                        RightPanelScroll.Value = num;
                        break;
                    }
            }
        }

        private void PMainInPaint(object sender, PaintEventArgs e)
        {
            RefreshPanel(Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "Tag", Array.Empty<object>(), null, null, null)), e.ClipRectangle);
        }

        private void BVCCalculate_Click(object sender, EventArgs e)
        {
            if (TBTimeSelect.Checked)
            {
                SortByVPositionInsertion();
                BPMChangeByValue((int)Math.Round(Conversion.Val(TVCBPM.Text) * 10000.0));
                SortByVPositionInsertion();
                UpdatePairing();
                RefreshPanelAll();
                POStatusRefresh();
                Interaction.Beep();
                TVCBPM.Focus();
            }
        }

        private void BVCApply_Click(object sender, EventArgs e)
        {
            if (TBTimeSelect.Checked)
            {
                SortByVPositionInsertion();
                BPMChangeTop(Conversion.Val(TVCM.Text) / Conversion.Val(TVCD.Text));
                SortByVPositionInsertion();
                UpdatePairing();
                RefreshPanelAll();
                POStatusRefresh();
                CalculateGreatestVPosition();
                Interaction.Beep();
                TVCM.Focus();
            }
        }

        private void BPMChangeTop(double xRatio, bool bAddUndo = true, bool bOverWriteUndo = false)
        {
            UndoRedo.LinkedURCmd BaseUndo = null;
            UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
            UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
            if (vSelLength != 0.0 && !(xRatio == 1.0 || xRatio <= 0.0))
            {
                double num = Conversions.ToDouble(Interaction.IIf(vSelLength > 0.0, vSelStart, vSelStart + vSelLength));
                double num2 = Conversions.ToDouble(Interaction.IIf(vSelLength < 0.0, vSelStart, vSelStart + vSelLength));
                if (num < 0.0)
                {
                    num = 0.0;
                }
                if (num2 >= GetMaxVPosition())
                {
                    num2 = GetMaxVPosition() - 1.0;
                }
                int num3 = (int)Notes[0].Value;
                int num4 = num3;
                int num5 = num3;
                RedoRemoveNoteAll(xSel: false, ref BaseUndo, ref BaseRedo);
                if (!NTInput)
                {
                    int num6 = Information.UBound(Notes);
                    int i;
                    for (i = 1; i <= num6 && !(Notes[i].VPosition > num); i++)
                    {
                        if (Notes[i].ColumnIndex == 2)
                        {
                            num3 = (int)Notes[i].Value;
                        }
                    }
                    num4 = num3;
                    int num7 = i;
                    int num8 = num7;
                    int num9 = Information.UBound(Notes);
                    for (i = num8; i <= num9 && !(Notes[i].VPosition > num2); i++)
                    {
                        if (Notes[i].ColumnIndex == 2)
                        {
                            num3 = (int)Notes[i].Value;
                            Notes[i].Value = (long)Math.Round(Notes[i].Value * xRatio);
                        }
                        Notes[i].VPosition = (Notes[i].VPosition - num) * xRatio + num;
                    }
                    num5 = num3;
                    num7 = i;
                    int num10 = num7;
                    int num11 = Information.UBound(Notes);
                    for (i = num10; i <= num11; i++)
                    {
                        Note[] notes = Notes;
                        notes[i].VPosition += (xRatio - 1.0) * (num2 - num);
                    }
                    Note note = new Note(2, num, (long)Math.Round(num4 * xRatio));
                    AddNote(note, xSelected: false, OverWrite: true, SortAndUpdatePairing: false);
                    note = new Note(2, num2 + (xRatio - 1.0) * (num2 - num), num5);
                    AddNote(note, xSelected: false, OverWrite: true, SortAndUpdatePairing: false);
                }
                else
                {
                    bool flag = true;
                    bool flag2 = true;
                    int num13 = Information.UBound(Notes);
                    for (int i = 1; i <= num13; i++)
                    {
                        if (Notes[i].VPosition <= num)
                        {
                            if (Notes[i].ColumnIndex == 2)
                            {
                                num4 = (int)Notes[i].Value;
                                num5 = (int)Notes[i].Value;
                                if (Notes[i].VPosition == num)
                                {
                                    flag = false;
                                    Notes[i].Value = Conversions.ToLong(Interaction.IIf(Notes[i].Value * xRatio <= 655359999.0, Notes[i].Value * xRatio, 655359999));
                                }
                            }
                            if (Notes[i].VPosition + Notes[i].Length > num)
                            {
                                Note[] notes = Notes;
                                notes[i].Length = Conversions.ToDouble(Operators.AddObject(notes[i].Length, Operators.MultiplyObject(Operators.SubtractObject(Interaction.IIf(num2 < Notes[i].VPosition + Notes[i].Length, num2, Notes[i].VPosition + Notes[i].Length), num), xRatio - 1.0)));
                            }
                        }
                        else if (Notes[i].VPosition <= num2)
                        {
                            if (Notes[i].ColumnIndex == 2)
                            {
                                num5 = (int)Notes[i].Value;
                                if (Notes[i].VPosition == num2)
                                {
                                    flag2 = false;
                                }
                                else
                                {
                                    Notes[i].Value = Conversions.ToLong(Interaction.IIf(Notes[i].Value * xRatio <= 655359999.0, Notes[i].Value * xRatio, 655359999));
                                }
                            }
                            Note[] notes = Notes;
                            notes[i].Length = Conversions.ToDouble(Operators.AddObject(notes[i].Length, Operators.MultiplyObject(Operators.SubtractObject(Interaction.IIf(num2 < Notes[i].Length + Notes[i].VPosition, num2, Notes[i].Length + Notes[i].VPosition), Notes[i].VPosition), xRatio - 1.0)));
                            Notes[i].VPosition = (Notes[i].VPosition - num) * xRatio + num;
                        }
                        else
                        {
                            Note[] notes = Notes;
                            notes[i].VPosition += (num2 - num) * (xRatio - 1.0);
                        }
                    }
                    if (flag)
                    {
                        Note note = new Note(2, num, (long)Math.Round(num4 * xRatio));
                        AddNote(note, xSelected: false, OverWrite: true, SortAndUpdatePairing: false);
                    }
                    if (flag2)
                    {
                        Note note = new Note(2, (num2 - num) * xRatio + num, num5);
                        AddNote(note, xSelected: false, OverWrite: true, SortAndUpdatePairing: false);
                    }
                }
                int num14 = Information.UBound(Notes);
                for (int j = 1; j <= num14; j++)
                {
                    if (Notes[j].ColumnIndex == 2 && Notes[j].Value < 1)
                    {
                        Notes[j].Value = 1L;
                    }
                }
                RedoAddNoteAll(xSel: false, ref BaseUndo, ref BaseRedo);
                double pStart = vSelStart;
                double pLen = vSelLength;
                double pHalf = vSelHalf;
                if (vSelLength < 0.0)
                {
                    vSelStart += (xRatio - 1.0) * (num2 - num);
                }
                vSelLength *= xRatio;
                vSelHalf *= xRatio;
                ValidateSelection();
                RedoChangeTimeSelection(pStart, pLen, pHalf, vSelStart, vSelLength, vSelHalf, xSel: true, ref BaseUndo, ref BaseRedo);
                num = Conversions.ToDouble(Interaction.IIf(vSelLength > 0.0, vSelStart, vSelStart + vSelLength));
                num2 = Conversions.ToDouble(Interaction.IIf(vSelLength < 0.0, vSelStart, vSelStart + vSelLength));
                if (!NTInput)
                {
                    int num15 = Information.UBound(Notes);
                    for (int j = 1; j <= num15; j++)
                    {
                        Notes[j].Selected = (Notes[j].VPosition >= num) & (Notes[j].VPosition < num2) & nEnabled(Notes[j].ColumnIndex);
                    }
                }
                else
                {
                    int num16 = Information.UBound(Notes);
                    for (int j = 1; j <= num16; j++)
                    {
                        Notes[j].Selected = (Notes[j].VPosition < num2) & (Notes[j].VPosition + Notes[j].Length >= num) & nEnabled(Notes[j].ColumnIndex);
                    }
                }
            }
            if (bAddUndo)
            {
                AddUndo(BaseUndo, linkedURCmd.Next, bOverWriteUndo);
            }
        }

        private void BPMChangeHalf(double dVPosition, bool bAddUndo = true, bool bOverWriteUndo = false)
        {
            UndoRedo.LinkedURCmd BaseUndo = null;
            UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
            UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
            if (vSelLength != 0.0 && dVPosition != 0.0)
            {
                double num = Conversions.ToDouble(Interaction.IIf(vSelLength > 0.0, vSelStart, vSelStart + vSelLength));
                double num2 = vSelStart + vSelHalf;
                double num3 = Conversions.ToDouble(Interaction.IIf(vSelLength < 0.0, vSelStart, vSelStart + vSelLength));
                if (!(dVPosition + num2 <= num || dVPosition + num2 >= num3))
                {
                    if (num < 0.0)
                    {
                        num = 0.0;
                    }
                    if (num3 >= GetMaxVPosition())
                    {
                        num3 = GetMaxVPosition() - 1.0;
                    }
                    if (num2 > num3)
                    {
                        num2 = num3;
                    }
                    if (num2 < num)
                    {
                        num2 = num;
                    }
                    int num4 = (int)Notes[0].Value;
                    int num5 = num4;
                    int num6 = num4;
                    int num7 = num4;
                    double num8 = (num2 - num + dVPosition) / (num2 - num);
                    double num9 = (num3 - num2 - dVPosition) / (num3 - num2);
                    RedoRemoveNoteAll(xSel: false, ref BaseUndo, ref BaseRedo);
                    if (!NTInput)
                    {
                        int num10 = Information.UBound(Notes);
                        int i;
                        for (i = 1; i <= num10 && !(Notes[i].VPosition > num); i++)
                        {
                            if (Notes[i].ColumnIndex == 2)
                            {
                                num4 = (int)Notes[i].Value;
                            }
                        }
                        num5 = num4;
                        int num11 = i;
                        int num12 = num11;
                        int num13 = Information.UBound(Notes);
                        for (i = num12; i <= num13 && !(Notes[i].VPosition > num2); i++)
                        {
                            if (Notes[i].ColumnIndex == 2)
                            {
                                num4 = (int)Notes[i].Value;
                                Notes[i].Value = (long)Math.Round(Notes[i].Value * num8);
                            }
                            Notes[i].VPosition = (Notes[i].VPosition - num) * num8 + num;
                        }
                        num6 = num4;
                        num11 = i;
                        int num14 = num11;
                        int num15 = Information.UBound(Notes);
                        for (i = num14; i <= num15 && !(Notes[i].VPosition > num3); i++)
                        {
                            if (Notes[i].ColumnIndex == 2)
                            {
                                num4 = (int)Notes[i].Value;
                                Notes[i].Value = Conversions.ToLong(Interaction.IIf(Notes[i].Value * num9 <= 655359999.0, Notes[i].Value * num9, 655359999));
                            }
                            Notes[i].VPosition = (Notes[i].VPosition - num2) * num9 + num2 + dVPosition;
                        }
                        num7 = num4;
                        num11 = i;
                        Note note = new Note(2, num, (long)Math.Round(num5 * num8));
                        AddNote(note, xSelected: false, OverWrite: true, SortAndUpdatePairing: false);
                        note = new Note(2, num2 + dVPosition, (long)Math.Round(num6 * num9));
                        AddNote(note, xSelected: false, OverWrite: true, SortAndUpdatePairing: false);
                        note = new Note(2, num3, num7);
                        AddNote(note, xSelected: false, OverWrite: true, SortAndUpdatePairing: false);
                    }
                    else
                    {
                        bool flag = true;
                        bool flag2 = true;
                        bool flag3 = true;
                        int num16 = Information.UBound(Notes);
                        for (int i = 1; i <= num16; i++)
                        {
                            if (Notes[i].VPosition <= num)
                            {
                                if (Notes[i].ColumnIndex == 2)
                                {
                                    num5 = (int)Notes[i].Value;
                                    num6 = (int)Notes[i].Value;
                                    num7 = (int)Notes[i].Value;
                                    if (Notes[i].VPosition == num)
                                    {
                                        flag = false;
                                        Notes[i].Value = (long)Math.Round(Notes[i].Value * num8);
                                    }
                                }
                                double num17 = Notes[i].VPosition + Notes[i].Length;
                                if (!(num17 > num3))
                                {
                                    if (num17 > num2)
                                    {
                                        Notes[i].Length = (num17 - num2) * num9 + num2 + dVPosition - Notes[i].VPosition;
                                    }
                                    else if (num17 > num)
                                    {
                                        Notes[i].Length = (num17 - num) * num8 + num - Notes[i].VPosition;
                                    }
                                }
                            }
                            else if (Notes[i].VPosition <= num2)
                            {
                                if (Notes[i].ColumnIndex == 2)
                                {
                                    num6 = (int)Notes[i].Value;
                                    num7 = (int)Notes[i].Value;
                                    if (Notes[i].VPosition == num2)
                                    {
                                        flag2 = false;
                                        Notes[i].Value = (long)Math.Round(Notes[i].Value * num9);
                                    }
                                    else
                                    {
                                        Notes[i].Value = (long)Math.Round(Notes[i].Value * num8);
                                    }
                                }
                                double num18 = Notes[i].VPosition + Notes[i].Length;
                                if (num18 > num3)
                                {
                                    Notes[i].Length = num18 - num - (Notes[i].VPosition - num) * num8;
                                }
                                else if (num18 > num2)
                                {
                                    Notes[i].Length = (num2 - Notes[i].VPosition) * num8 + (num18 - num2) * num9;
                                }
                                else
                                {
                                    Note[] notes = Notes;
                                    notes[i].Length *= num8;
                                }
                                Notes[i].VPosition = (Notes[i].VPosition - num) * num8 + num;
                            }
                            else
                            {
                                if (!(Notes[i].VPosition <= num3))
                                {
                                    continue;
                                }
                                if (Notes[i].ColumnIndex == 2)
                                {
                                    num7 = (int)Notes[i].Value;
                                    if (Notes[i].VPosition == num3)
                                    {
                                        flag3 = false;
                                    }
                                    else
                                    {
                                        Notes[i].Value = Conversions.ToLong(Interaction.IIf(Notes[i].Value * num9 <= 655359999.0, Notes[i].Value * num9, 655359999));
                                    }
                                }
                                double num20 = Notes[i].VPosition + Notes[i].Length;
                                if (num20 > num3)
                                {
                                    Notes[i].Length = (num3 - Notes[i].VPosition) * num9 + num20 - num3;
                                }
                                else
                                {
                                    Note[] notes = Notes;
                                    notes[i].Length *= num9;
                                }
                                Notes[i].VPosition = (Notes[i].VPosition - num2) * num9 + num2 + dVPosition;
                            }
                        }
                        if (flag)
                        {
                            Note note = new Note(2, num, (long)Math.Round(num5 * num8));
                            AddNote(note, xSelected: false, OverWrite: true, SortAndUpdatePairing: false);
                        }
                        if (flag2)
                        {
                            Note note = new Note(2, num2 + dVPosition, (long)Math.Round(num6 * num9));
                            AddNote(note, xSelected: false, OverWrite: true, SortAndUpdatePairing: false);
                        }
                        if (flag3)
                        {
                            Note note = new Note(2, num3, num7);
                            AddNote(note, xSelected: false, OverWrite: true, SortAndUpdatePairing: false);
                        }
                    }
                    double pHalf = vSelHalf;
                    vSelHalf += dVPosition;
                    ValidateSelection();
                    RedoChangeTimeSelection(vSelStart, vSelLength, pHalf, vSelStart, vSelStart, vSelHalf, xSel: true, ref BaseUndo, ref BaseRedo);
                    RedoAddNoteAll(xSel: false, ref BaseUndo, ref BaseRedo);
                    num = Conversions.ToDouble(Interaction.IIf(vSelLength > 0.0, vSelStart, vSelStart + vSelLength));
                    num3 = Conversions.ToDouble(Interaction.IIf(vSelLength < 0.0, vSelStart, vSelStart + vSelLength));
                    if (!NTInput)
                    {
                        int num21 = Information.UBound(Notes);
                        for (int j = 1; j <= num21; j++)
                        {
                            Notes[j].Selected = (Notes[j].VPosition >= num) & (Notes[j].VPosition < num3) & nEnabled(Notes[j].ColumnIndex);
                        }
                    }
                    else
                    {
                        int num22 = Information.UBound(Notes);
                        for (int j = 1; j <= num22; j++)
                        {
                            Notes[j].Selected = (Notes[j].VPosition < num3) & (Notes[j].VPosition + Notes[j].Length >= num) & nEnabled(Notes[j].ColumnIndex);
                        }
                    }
                }
            }
            if (bAddUndo)
            {
                AddUndo(BaseUndo, linkedURCmd.Next, bOverWriteUndo);
            }
        }

        private void BPMChangeByValue(int xValue)
        {
            UndoRedo.LinkedURCmd BaseUndo = null;
            UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
            UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
            if (vSelLength == 0.0)
            {
                return;
            }
            double num = Conversions.ToDouble(Interaction.IIf(vSelLength > 0.0, vSelStart, vSelStart + vSelLength));
            double num2 = vSelStart + vSelHalf;
            double num3 = Conversions.ToDouble(Interaction.IIf(vSelLength < 0.0, vSelStart, vSelStart + vSelLength));
            if (num2 == num3)
            {
                num2 = num;
            }
            if (num < 0.0)
            {
                num = 0.0;
            }
            if (num3 >= GetMaxVPosition())
            {
                num3 = GetMaxVPosition() - 1.0;
            }
            if (num2 > num3)
            {
                num2 = num3;
            }
            if (num2 < num)
            {
                num2 = num;
            }
            long value = Notes[0].Value;
            double num4 = 0.0;
            int num5 = Information.UBound(Notes);
            int i;
            for (i = 1; i <= num5 && !(Notes[i].VPosition > num); i++)
            {
                if (Notes[i].ColumnIndex == 2)
                {
                    value = Notes[i].Value;
                }
            }
            int num6 = i;
            double[] array = new double[1] { num };
            long[] array2 = new long[1] { value };
            int num7 = 0;
            int num8 = num6;
            int num9 = Information.UBound(Notes);
            for (i = num8; i <= num9 && !(Notes[i].VPosition > num3); i++)
            {
                if (Notes[i].ColumnIndex == 2)
                {
                    num7 = Information.UBound(array) + 1;
                    array = (double[])Utils.CopyArray(array, new double[num7 + 1]);
                    array2 = (long[])Utils.CopyArray(array2, new long[num7 + 1]);
                    array[num7] = Notes[i].VPosition;
                    array2[num7] = Notes[i].Value;
                }
            }
            array = (double[])Utils.CopyArray(array, new double[num7 + 1 + 1]);
            array[num7 + 1] = num3;
            int num10 = num7;
            for (i = 0; i <= num10; i++)
            {
                num4 += (array[i + 1] - array[i]) / array2[i];
            }
            num4 = (num3 - num) / num4;
            if ((num3 - num) / num4 <= (num2 - num) / xValue)
            {
                double num11 = (num2 - num) * num4 / (num3 - num) / 10000.0;
                Interaction.MsgBox("Please enter a value that is greater than " + Conversions.ToString(num11) + ".", MsgBoxStyle.Critical, Strings1.Messages.Err);
                return;
            }
            double num12 = num4 * (num2 - num) - xValue * (num3 - num);
            if (num12 == 0.0)
            {
                return;
            }
            double num13 = (num2 - num3) * xValue / num12 * num4;
            RedoRemoveNoteAll(xSel: false, ref BaseUndo, ref BaseRedo);
            if (!NTInput)
            {
                int num14 = Information.UBound(Notes);
                for (i = 1; i <= num14 && !(Notes[i].VPosition > num); i++)
                {
                }
                num6 = i;
                if (num6 <= Information.UBound(Notes))
                {
                    int num16 = Information.UBound(Notes);
                    for (i = num6; i <= num16 && !(Notes[i].VPosition >= num3); i++)
                    {
                        double num17 = 0.0;
                        double vPosition = Notes[i].VPosition;
                        int j;
                        for (j = 0; j <= num7 && !(vPosition < array[j + 1]); j++)
                        {
                            num17 += (array[j + 1] - array[j]) / array2[j];
                        }
                        num17 += (vPosition - array[j]) / array2[j];
                        if (num17 - (num2 - num) / xValue > 0.0)
                        {
                            Notes[i].VPosition = (num17 - (num2 - num) / xValue) * num13 + num2;
                        }
                        else
                        {
                            Notes[i].VPosition = num17 * xValue + num;
                        }
                    }
                }
            }
            else
            {
                int num19 = Information.UBound(Notes);
                double num20 = default(double);
                for (i = 1; i <= num19; i++)
                {
                    if (Notes[i].Length != 0.0)
                    {
                        num20 = Notes[i].VPosition + Notes[i].Length;
                    }
                    if ((Notes[i].VPosition > num) & (Notes[i].VPosition < num3))
                    {
                        double num21 = 0.0;
                        double vPosition2 = Notes[i].VPosition;
                        int j;
                        for (j = 0; j <= num7 && !(vPosition2 < array[j + 1]); j++)
                        {
                            num21 += (array[j + 1] - array[j]) / array2[j];
                        }
                        num21 += (vPosition2 - array[j]) / array2[j];
                        if (num21 - (num2 - num) / xValue > 0.0)
                        {
                            Notes[i].VPosition = (num21 - (num2 - num) / xValue) * num13 + num2;
                        }
                        else
                        {
                            Notes[i].VPosition = num21 * xValue + num;
                        }
                    }
                    if (Notes[i].Length == 0.0)
                    {
                        continue;
                    }
                    if (num20 > num && num20 < num3)
                    {
                        double num21 = 0.0;
                        int j;
                        for (j = 0; j <= num7 && !(num20 < array[j + 1]); j++)
                        {
                            num21 += (array[j + 1] - array[j]) / array2[j];
                        }
                        num21 += (num20 - array[j]) / array2[j];
                        if (num21 - (num2 - num) / xValue > 0.0)
                        {
                            Notes[i].Length = (num21 - (num2 - num) / xValue) * num13 + num2 - Notes[i].VPosition;
                        }
                        else
                        {
                            Notes[i].Length = num21 * xValue + num - Notes[i].VPosition;
                        }
                    }
                    else
                    {
                        Notes[i].Length = num20 - Notes[i].VPosition;
                    }
                }
            }
            i = 1;
            while (i <= Information.UBound(Notes) && !(Notes[i].VPosition > num3))
            {
                if ((Notes[i].VPosition >= num) & (Notes[i].ColumnIndex == 2))
                {
                    int num24 = i + 1;
                    int num25 = Information.UBound(Notes);
                    for (int j = num24; j <= num25; j++)
                    {
                        ref Note reference = ref Notes[j - 1];
                        reference = Notes[j];
                    }
                    Notes = (Note[])Utils.CopyArray(Notes, new Note[Information.UBound(Notes) - 1 + 1]);
                }
                else
                {
                    i++;
                }
            }
            Notes = (Note[])Utils.CopyArray(Notes, new Note[Information.UBound(Notes) + 2 + 1]);
            Note[] notes = Notes;
            int num26 = Information.UBound(Notes) - 1;
            notes[num26].ColumnIndex = 2;
            notes[num26].VPosition = num2;
            notes[num26].Value = (long)Math.Round(num13);
            Note[] notes2 = Notes;
            int num27 = Information.UBound(Notes);
            notes2[num27].ColumnIndex = 2;
            notes2[num27].VPosition = num3;
            notes2[num27].Value = array2[num7];
            if (num != num2)
            {
                Notes = (Note[])Utils.CopyArray(Notes, new Note[Information.UBound(Notes) + 1 + 1]);
                Note[] notes3 = Notes;
                int num28 = Information.UBound(Notes);
                notes3[num28].ColumnIndex = 2;
                notes3[num28].VPosition = num;
                notes3[num28].Value = xValue;
            }
            RedoAddNoteAll(xSel: false, ref BaseUndo, ref BaseRedo);
            num = Conversions.ToDouble(Interaction.IIf(vSelLength > 0.0, vSelStart, vSelStart + vSelLength));
            num3 = Conversions.ToDouble(Interaction.IIf(vSelLength < 0.0, vSelStart, vSelStart + vSelLength));
            if (!NTInput)
            {
                int num29 = Information.UBound(Notes);
                for (int j = 1; j <= num29; j++)
                {
                    Notes[j].Selected = (Notes[j].VPosition >= num) & (Notes[j].VPosition < num3) & nEnabled(Notes[j].ColumnIndex);
                }
            }
            else
            {
                int num30 = Information.UBound(Notes);
                for (int j = 1; j <= num30; j++)
                {
                    Notes[j].Selected = (Notes[j].VPosition < num3) & (Notes[j].VPosition + Notes[j].Length >= num) & nEnabled(Notes[j].ColumnIndex);
                }
            }
            AddUndo(BaseUndo, linkedURCmd.Next);
        }

        private void ConvertAreaToStop()
        {
            UndoRedo.LinkedURCmd BaseUndo = null;
            UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
            UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
            if (vSelLength == 0.0)
            {
                return;
            }
            double num = Conversions.ToDouble(Interaction.IIf(vSelLength > 0.0, vSelStart, vSelStart + vSelLength));
            double num2 = Conversions.ToDouble(Interaction.IIf(vSelLength < 0.0, vSelStart, vSelStart + vSelLength));
            IEnumerable<Note> source = from note in Notes
                                       where (note.VPosition > num) & (note.VPosition <= num2)
                                       select note;
            if (source.Count() > 0)
            {
                MessageBox.Show("The selected area can't have notes anywhere but at the start.");
                return;
            }
            RedoRemoveNoteAll(xSel: false, ref BaseUndo, ref BaseRedo);
            int num3 = Information.UBound(Notes);
            for (int i = 1; i <= num3; i++)
            {
                if (Notes[i].VPosition > num2)
                {
                    Note[] notes = Notes;
                    notes[i].VPosition -= vSelLength;
                }
            }
            Notes = (Note[])Utils.CopyArray(Notes, new Note[Information.UBound(Notes) + 1 + 1]);
            Note[] notes2 = Notes;
            int num5 = Information.UBound(Notes);
            notes2[num5].ColumnIndex = 3;
            notes2[num5].VPosition = num;
            notes2[num5].Value = (long)Math.Round(vSelLength * 10000.0);
            RedoAddNoteAll(xSel: false, ref BaseUndo, ref BaseRedo);
            AddUndo(BaseUndo, linkedURCmd.Next);
        }

        private void BConvertStop_Click(object sender, EventArgs e)
        {
            SortByVPositionInsertion();
            ConvertAreaToStop();
            SortByVPositionInsertion();
            UpdatePairing();
            RefreshPanelAll();
            POStatusRefresh();
            Interaction.Beep();
            TVCBPM.Focus();
        }

        private void BWLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Wave files (*.wav, *.ogg)|*.wav;*.ogg";
            openFileDialog.DefaultExt = "wav";
            openFileDialog.InitialDirectory = Conversions.ToString(Interaction.IIf(Operators.CompareString(ExcludeFileName(FileName), "", TextCompare: false) == 0, InitPath, ExcludeFileName(FileName)));
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            InitPath = ExcludeFileName(openFileDialog.FileName);
            IWaveSource codec = CodecFactory.Instance.GetCodec(openFileDialog.FileName);
            codec.ToStereo();
            float[] array = new float[(int)codec.Length + 1];
            codec.ToSampleSource().Read(array, 0, (int)codec.Length);
            double num = (codec.Length - 1) / (double)codec.WaveFormat.Channels;
            wWavL = new float[(int)Math.Round(num + 1.0) + 1];
            wWavR = new float[(int)Math.Round(num + 1.0) + 1];
            int num2 = (int)Math.Round(num);
            for (int i = 0; i <= num2; i++)
            {
                if (2 * i < codec.Length)
                {
                    wWavL[i] = array[2 * i];
                }
                if (2 * i + 1 < codec.Length)
                {
                    wWavR[i] = array[2 * i + 1];
                }
            }
            wSampleRate = codec.WaveFormat.SampleRate;
            RefreshPanelAll();
            TWFileName.Text = openFileDialog.FileName;
            TWFileName.Select(Microsoft.VisualBasic.Strings.Len(openFileDialog.FileName), 0);
        }

        private void BWClear_Click(object sender, EventArgs e)
        {
            wWavL = null;
            wWavR = null;
            TWFileName.Text = "(" + Strings1.None + ")";
            RefreshPanelAll();
        }

        private void BWLock_CheckedChanged(object sender, EventArgs e)
        {
            wLock = BWLock.Checked;
            TWPosition.Enabled = !wLock;
            TWPosition2.Enabled = !wLock;
            RefreshPanelAll();
        }
    }
}
