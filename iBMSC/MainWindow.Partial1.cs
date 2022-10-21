using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iBMSC.Editor;
using iBMSC.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace iBMSC
{
    public partial class MainWindow
    {
        private int HorizontalPositiontoDisplay(int xHPosition, long xHSVal)
        {
            return (int)Math.Round(xHPosition * gxWidth - xHSVal * gxWidth);
        }

        private int NoteRowToPanelHeight(double xVPosition, long xVSVal, int xTHeight)
        {
            return xTHeight - (int)Math.Round((xVPosition + xVSVal) * gxHeight) - 1;
        }

        public int MeasureAtDisplacement(double xVPos)
        {
            int num = 1;
            while (!(xVPos < MeasureBottom[num]))
            {
                num++;
                if (num > 999)
                {
                    break;
                }
            }
            return num - 1;
        }

        private double GetMaxVPosition()
        {
            return MeasureUpper(999);
        }

        private double SnapToGrid(double xVPos)
        {
            double num = MeasureBottom[MeasureAtDisplacement(xVPos)];
            double num2 = 192.0 / gDivide;
            return Math.Floor((xVPos - num) / num2) * num2 + num;
        }

        private void CalculateGreatestVPosition()
        {
            GreatestVPosition = 0.0;
            if (NTInput)
            {
                for (int i = Information.UBound(Notes); i >= 0; i += -1)
                {
                    if (Notes[i].VPosition + Notes[i].Length > GreatestVPosition)
                    {
                        GreatestVPosition = Notes[i].VPosition + Notes[i].Length;
                    }
                }
            }
            else
            {
                for (int i = Information.UBound(Notes); i >= 0; i += -1)
                {
                    if (Notes[i].VPosition > GreatestVPosition)
                    {
                        GreatestVPosition = Notes[i].VPosition;
                    }
                }
            }
            int minimum = -Conversions.ToInteger(Interaction.IIf(GreatestVPosition + 2000.0 > GetMaxVPosition(), GetMaxVPosition(), GreatestVPosition + 2000.0));
            MainPanelScroll.Minimum = minimum;
            LeftPanelScroll.Minimum = minimum;
            RightPanelScroll.Minimum = minimum;
        }

        private void SortByVPositionInsertion()
        {
            if (Information.UBound(Notes) <= 0)
            {
                return;
            }
            int num = Information.UBound(Notes);
            for (int i = 2; i <= num; i++)
            {
                Note note = Notes[i];
                for (int j = i - 1; j >= 1; j += -1)
                {
                    if (Notes[j].VPosition > note.VPosition)
                    {
                        ref Note reference = ref Notes[j + 1];
                        reference = Notes[j];
                        if (j == 1)
                        {
                            Notes[j] = note;
                            break;
                        }
                        continue;
                    }
                    Notes[j + 1] = note;
                    break;
                }
            }
        }

        private void SortByVPositionQuick(int xMin, int xMax)
        {
            if (xMin >= xMax)
            {
                return;
            }
            int num = (int)Math.Round((xMax - xMin) / 2.0) + xMin;
            Note note = Notes[num];
            ref Note reference = ref Notes[num];
            reference = Notes[xMin];
            int num2 = xMin;
            int num3 = xMax;
            while (true)
            {
                if (Notes[num3].VPosition >= note.VPosition)
                {
                    num3--;
                    if (num3 > num2)
                    {
                        continue;
                    }
                }
                if (num3 <= num2)
                {
                    Notes[num2] = note;
                    break;
                }
                ref Note reference2 = ref Notes[num2];
                reference2 = Notes[num3];
                num2++;
                while (Notes[num2].VPosition < note.VPosition)
                {
                    num2++;
                    if (num2 >= num3)
                    {
                        break;
                    }
                }
                if (num2 >= num3)
                {
                    num2 = num3;
                    Notes[num3] = note;
                    break;
                }
                ref Note reference3 = ref Notes[num3];
                reference3 = Notes[num2];
            }
            SortByVPositionQuick(xMin, num2 - 1);
            SortByVPositionQuick(num2 + 1, xMax);

        }

        private void SortByVPositionQuick3(int xMin, int xMax)
        {
            int num = xMin;
            int num2 = xMax;
            int num3 = xMax - xMin + 1;
            int num4 = (int)Math.Round(Conversion.Int(num3 * VBMath.Rnd())) + xMin;
            int num5 = (int)Math.Round(Conversion.Int(num3 * VBMath.Rnd())) + xMin;
            int num6 = (int)Math.Round(Conversion.Int(num3 * VBMath.Rnd())) + xMin;
            num3 = (Notes[num4].VPosition <= Notes[num5].VPosition) & (Notes[num5].VPosition <= Notes[num6].VPosition) ? num5 : !((Notes[num5].VPosition <= Notes[num4].VPosition) & (Notes[num4].VPosition <= Notes[num6].VPosition)) ? num6 : num4;
            Note note = Notes[num3];
            while (true)
            {
                if (Notes[num].VPosition < note.VPosition && num < xMax)
                {
                    num++;
                    continue;
                }
                while (note.VPosition < Notes[num2].VPosition && num2 > xMin)
                {
                    num2--;
                }
                if (num <= num2)
                {
                    Note note2 = Notes[num];
                    ref Note reference = ref Notes[num];
                    reference = Notes[num2];
                    Notes[num2] = note2;
                    num++;
                    num2--;
                }
                if (num > num2)
                {
                    break;
                }
            }
            if (num2 - xMin < xMax - num)
            {
                if (xMin < num2)
                {
                    SortByVPositionQuick3(xMin, num2);
                }
                if (num < xMax)
                {
                    SortByVPositionQuick3(num, xMax);
                }
            }
            else
            {
                if (num < xMax)
                {
                    SortByVPositionQuick3(num, xMax);
                }
                if (xMin < num2)
                {
                    SortByVPositionQuick3(xMin, num2);
                }
            }
        }

        private void UpdateMeasureBottom()
        {
            MeasureBottom[0] = 0.0;
            int num = 0;
            do
            {
                MeasureBottom[num + 1] = MeasureBottom[num] + MeasureLength[num];
                num++;
            }
            while (num <= 998);
        }

        private bool PathIsValid(string sPath)
        {
            return File.Exists(sPath) | Directory.Exists(sPath);
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public string PrevCodeToReal(string InitStr)
        {
            string replacement = Conversions.ToString(Operators.ConcatenateObject(Interaction.IIf(!PathIsValid(FileName), RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(InitPath, "", TextCompare: false) == 0, MyProject.Application.Info.DirectoryPath, InitPath)), ExcludeFileName(FileName)), "\\___TempBMS.bms"));
            int num = MeasureAtDisplacement(Math.Abs(PanelVScroll[PanelFocus]));
            string expression = Microsoft.VisualBasic.Strings.Replace(InitStr, "<apppath>", MyProject.Application.Info.DirectoryPath);
            string expression2 = Microsoft.VisualBasic.Strings.Replace(expression, "<measure>", Conversions.ToString(num));
            return Microsoft.VisualBasic.Strings.Replace(expression2, "<filename>", replacement);
        }

        private void SetFileName(string xFileName)
        {
            FileName = xFileName.Trim();
            InitPath = ExcludeFileName(FileName);
            SetIsSaved(IsSaved);
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private void SetIsSaved(bool isSaved)
        {
            string right = Conversions.ToString(Operators.ConcatenateObject(string.Concat(Conversions.ToString(MyProject.Application.Info.Version.Major) + ".", Conversions.ToString(MyProject.Application.Info.Version.Minor)), Interaction.IIf(MyProject.Application.Info.Version.Build == 0, "", "." + Conversions.ToString(MyProject.Application.Info.Version.Build))));
            Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Interaction.IIf(isSaved, "", "*"), GetFileName(FileName)), " - "), MyProject.Application.Info.Title), " "), right));
            IsSaved = isSaved;
        }

        private void PreviewNote(string xFileLocation, bool bStop)
        {
            if (bStop)
            {
                Audio.StopPlaying();
            }
            Audio.Play(xFileLocation);
        }

        private void AddNote(Note note, bool xSelected = false, bool OverWrite = true, bool SortAndUpdatePairing = true)
        {
            if ((note.VPosition < 0.0) | (note.VPosition >= GetMaxVPosition()))
            {
                return;
            }
            int num = 1;
            if (OverWrite)
            {
                while (num <= Information.UBound(Notes))
                {
                    if ((Notes[num].VPosition == note.VPosition) & (Notes[num].ColumnIndex == note.ColumnIndex))
                    {
                        RemoveNote(num);
                    }
                    else
                    {
                        num++;
                    }
                }
            }
            Notes = (Note[])Utils.CopyArray(Notes, new Note[Information.UBound(Notes) + 1 + 1]);
            note.Selected &= nEnabled(note.ColumnIndex);
            Notes[Information.UBound(Notes)] = note;
            if (SortAndUpdatePairing)
            {
                SortByVPositionInsertion();
                UpdatePairing();
            }
            CalculateTotalPlayableNotes();
        }

        private void RemoveNote(int I, bool SortAndUpdatePairing = true)
        {
            KMouseOver = -1;
            if (TBWavIncrease.Checked && Notes[I].Value == LWAV.SelectedIndex * 10000)
            {
                DecreaseCurrentWav();
            }
            int num = I + 1;
            int num2 = Information.UBound(Notes);
            for (int i = num; i <= num2; i++)
            {
                ref Note reference = ref Notes[i - 1];
                reference = Notes[i];
            }
            Notes = (Note[])Utils.CopyArray(Notes, new Note[Information.UBound(Notes) - 1 + 1]);
            if (SortAndUpdatePairing)
            {
                SortByVPositionInsertion();
                UpdatePairing();
            }
        }

        private void AddNotesFromClipboard(bool xSelected = true, bool SortAndUpdatePairing = true)
        {
            string[] array = Microsoft.VisualBasic.Strings.Split(Clipboard.GetText(), "\r\n");
            int num = Information.UBound(Notes);
            for (int i = 0; i <= num; i++)
            {
                Notes[i].Selected = false;
            }
            long num2 = PanelVScroll[PanelFocus];
            Note[] notes = Notes;
            if (Operators.CompareString(array[0], "iBMSC Clipboard Data", TextCompare: false) == 0)
            {
                if (NTInput)
                {
                    Notes = (Note[])Utils.CopyArray(Notes, new Note[1]);
                }
                int num3 = Information.UBound(array);
                for (int i = 1; i <= num3; i++)
                {
                    if (Operators.CompareString(array[i].Trim(), "", TextCompare: false) != 0)
                    {
                        string[] array2 = Microsoft.VisualBasic.Strings.Split(array[i]);
                        double num4 = Conversion.Val(array2[1]) + MeasureBottom[MeasureAtDisplacement(-num2) + 1];
                        if ((Information.UBound(array2) == 5 && num4 >= 0.0) & (num4 < GetMaxVPosition()))
                        {
                            Notes = (Note[])Utils.CopyArray(Notes, new Note[Information.UBound(Notes) + 1 + 1]);
                            Note[] notes2 = Notes;
                            int num5 = Information.UBound(Notes);
                            notes2[num5].ColumnIndex = (int)Math.Round(Conversion.Val(array2[0]));
                            notes2[num5].VPosition = num4;
                            notes2[num5].Value = (long)Math.Round(Conversion.Val(array2[2]));
                            notes2[num5].LongNote = Conversion.Val(array2[3]) != 0.0;
                            notes2[num5].Hidden = Conversion.Val(array2[4]) != 0.0;
                            notes2[num5].Landmine = Conversion.Val(array2[5]) != 0.0;
                            notes2[num5].Selected = xSelected;
                        }
                    }
                }
                if (NTInput)
                {
                    ConvertBMSE2NT();
                    int num6 = Information.UBound(Notes);
                    for (int i = 1; i <= num6; i++)
                    {
                        ref Note reference = ref Notes[i - 1];
                        reference = Notes[i];
                    }
                    Notes = (Note[])Utils.CopyArray(Notes, new Note[Information.UBound(Notes) - 1 + 1]);
                    Note[] notes3 = Notes;
                    Notes = notes;
                    int num7 = Notes.Length;
                    Notes = (Note[])Utils.CopyArray(Notes, new Note[Information.UBound(Notes) + notes3.Length + 1]);
                    int num8 = Information.UBound(Notes);
                    for (int i = num7; i <= num8; i++)
                    {
                        ref Note reference2 = ref Notes[i];
                        reference2 = notes3[i - num7];
                    }
                }
            }
            else if (Operators.CompareString(array[0], "iBMSC Clipboard Data xNT", TextCompare: false) == 0)
            {
                if (!NTInput)
                {
                    Notes = (Note[])Utils.CopyArray(Notes, new Note[1]);
                }
                int num9 = Information.UBound(array);
                for (int i = 1; i <= num9; i++)
                {
                    if (Operators.CompareString(array[i].Trim(), "", TextCompare: false) != 0)
                    {
                        string[] array3 = Microsoft.VisualBasic.Strings.Split(array[i]);
                        double num4 = Conversion.Val(array3[1]) + MeasureBottom[MeasureAtDisplacement(-num2) + 1];
                        if ((Information.UBound(array3) == 5 && num4 >= 0.0) & (num4 < GetMaxVPosition()))
                        {
                            Notes = (Note[])Utils.CopyArray(Notes, new Note[Information.UBound(Notes) + 1 + 1]);
                            Note[] notes4 = Notes;
                            int num10 = Information.UBound(Notes);
                            notes4[num10].ColumnIndex = (int)Math.Round(Conversion.Val(array3[0]));
                            notes4[num10].VPosition = num4;
                            notes4[num10].Value = (long)Math.Round(Conversion.Val(array3[2]));
                            notes4[num10].Length = Conversion.Val(array3[3]);
                            notes4[num10].Hidden = Conversion.Val(array3[4]) != 0.0;
                            notes4[num10].Landmine = Conversion.Val(array3[5]) != 0.0;
                            notes4[num10].Selected = xSelected;
                        }
                    }
                }
                if (!NTInput)
                {
                    ConvertNT2BMSE();
                    int num11 = Information.UBound(Notes);
                    for (int i = 1; i <= num11; i++)
                    {
                        ref Note reference3 = ref Notes[i - 1];
                        reference3 = Notes[i];
                    }
                    Notes = (Note[])Utils.CopyArray(Notes, new Note[Information.UBound(Notes) - 1 + 1]);
                    Note[] notes5 = Notes;
                    Notes = notes;
                    int num12 = Notes.Length;
                    Notes = (Note[])Utils.CopyArray(Notes, new Note[Information.UBound(Notes) + notes5.Length + 1]);
                    int num13 = Information.UBound(Notes);
                    for (int i = num12; i <= num13; i++)
                    {
                        ref Note reference4 = ref Notes[i];
                        reference4 = notes5[i - num12];
                    }
                }
            }
            else if (Operators.CompareString(array[0], "BMSE ClipBoard Object Data Format", TextCompare: false) == 0)
            {
                if (NTInput)
                {
                    Notes = (Note[])Utils.CopyArray(Notes, new Note[1]);
                }
                int num14 = Information.UBound(array);
                for (int i = 1; i <= num14; i++)
                {
                    string inputStr = Microsoft.VisualBasic.Strings.Mid(array[i], 5, 7);
                    double num15 = Conversion.Val(inputStr) + MeasureBottom[MeasureAtDisplacement(-num2) + 1];
                    string i2 = Microsoft.VisualBasic.Strings.Mid(array[i], 1, 3);
                    object objectValue = RuntimeHelpers.GetObjectValue(BMSEChannelToColumnIndex(i2));
                    double a = Conversion.Val(Microsoft.VisualBasic.Strings.Mid(array[i], 12)) * 10000.0;
                    string left = Microsoft.VisualBasic.Strings.Mid(array[i], 4, 1);
                    object left2 = Operators.AndObject(Microsoft.VisualBasic.Strings.Len(array[i]) > 11, Operators.CompareObjectGreater(objectValue, 0, TextCompare: false));
                    bool flag = (num15 >= 0.0) & (num15 < GetMaxVPosition());
                    if (Conversions.ToBoolean(Operators.AndObject(left2, flag)))
                    {
                        Notes = (Note[])Utils.CopyArray(Notes, new Note[Information.UBound(Notes) + 1 + 1]);
                        Note[] notes6 = Notes;
                        int num16 = Information.UBound(Notes);
                        notes6[num16].ColumnIndex = Conversions.ToInteger(objectValue);
                        notes6[num16].VPosition = num15;
                        notes6[num16].Value = (long)Math.Round(a);
                        notes6[num16].LongNote = Operators.CompareString(left, "2", TextCompare: false) == 0;
                        notes6[num16].Hidden = Operators.CompareString(left, "1", TextCompare: false) == 0;
                        notes6[num16].Selected = xSelected & nEnabled(notes6[num16].ColumnIndex);
                    }
                }
                if (NTInput)
                {
                    ConvertBMSE2NT();
                    int num17 = Information.UBound(Notes);
                    for (int i = 1; i <= num17; i++)
                    {
                        ref Note reference5 = ref Notes[i - 1];
                        reference5 = Notes[i];
                    }
                    Notes = (Note[])Utils.CopyArray(Notes, new Note[Information.UBound(Notes) - 1 + 1]);
                    Note[] notes7 = Notes;
                    Notes = notes;
                    int num18 = Notes.Length;
                    Notes = (Note[])Utils.CopyArray(Notes, new Note[Information.UBound(Notes) + notes7.Length + 1]);
                    int num19 = Information.UBound(Notes);
                    for (int i = num18; i <= num19; i++)
                    {
                        ref Note reference6 = ref Notes[i];
                        reference6 = notes7[i - num18];
                    }
                }
            }
            if (SortAndUpdatePairing)
            {
                SortByVPositionInsertion();
                UpdatePairing();
            }
            CalculateTotalPlayableNotes();
        }

        private void CopyNotes(bool Unselect = true)
        {
            string text = Conversions.ToString(Operators.ConcatenateObject("iBMSC Clipboard Data", Interaction.IIf(NTInput, " xNT", "")));
            double num = 999.0;
            int num2 = Information.UBound(Notes);
            for (int i = 1; i <= num2; i++)
            {
                if (Notes[i].Selected & (MeasureAtDisplacement(Notes[i].VPosition) < num))
                {
                    num = MeasureAtDisplacement(Notes[i].VPosition);
                }
            }
            num = MeasureBottom[(int)Math.Round(num)];
            if (!NTInput)
            {
                int num3 = Information.UBound(Notes);
                for (int i = 1; i <= num3; i++)
                {
                    if (Notes[i].Selected)
                    {
                        text = unchecked(text + "\r\n" + Notes[i].ColumnIndex + " " + (Notes[i].VPosition - num) + " " + Notes[i].Value + " " + (0 - (Notes[i].LongNote ? 1 : 0)) + " " + (0 - (Notes[i].Hidden ? 1 : 0)) + " " + (0 - (Notes[i].Landmine ? 1 : 0)));
                        Notes[i].Selected = !Unselect;
                    }
                }
            }
            else
            {
                int num4 = Information.UBound(Notes);
                for (int i = 1; i <= num4; i++)
                {
                    if (Notes[i].Selected)
                    {
                        text = unchecked(text + "\r\n" + Notes[i].ColumnIndex + " " + (Notes[i].VPosition - num) + " " + Notes[i].Value + " " + Notes[i].Length + " " + (0 - (Notes[i].Hidden ? 1 : 0)) + " " + (0 - (Notes[i].Landmine ? 1 : 0)));
                        Notes[i].Selected = !Unselect;
                    }
                }
            }
            Clipboard.SetText(text);
        }

        private void RemoveNotes(bool SortAndUpdatePairing = true)
        {
            if (Information.UBound(Notes) == 0)
            {
                return;
            }
            KMouseOver = -1;
            int num = 1;
            do
            {
                if (Notes[num].Selected)
                {
                    int num2 = num + 1;
                    int num3 = Information.UBound(Notes);
                    for (int i = num2; i <= num3; i++)
                    {
                        ref Note reference = ref Notes[i - 1];
                        reference = Notes[i];
                    }
                    Notes = (Note[])Utils.CopyArray(Notes, new Note[Information.UBound(Notes) - 1 + 1]);
                    num = 0;
                }
                num++;
            }
            while (num < Information.UBound(Notes) + 1);
            if (SortAndUpdatePairing)
            {
                SortByVPositionInsertion();
                UpdatePairing();
            }
            CalculateTotalPlayableNotes();
        }

        private int EnabledColumnIndexToColumnArrayIndex(int cEnabled)
        {
            for (int i = 0; i < gColumns; i++)
            {
                if (!nEnabled(i))
                {
                    cEnabled++;
                }
                if (i >= cEnabled)
                {
                    break;
                }
            }
            return cEnabled;
        }

        private int ColumnArrayIndexToEnabledColumnIndex(int cReal)
        {
            int num = cReal - 1;
            for (int i = 0; i <= num; i++)
            {
                if (!nEnabled(i))
                {
                    cReal--;
                }
            }
            return cReal;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (pTempFileNames != null)
            {
                string[] array = pTempFileNames;
                foreach (string path in array)
                {
                    File.Delete(path);
                }
            }
            if (Operators.CompareString(PreviousAutoSavedFileName, "", TextCompare: false) != 0)
            {
                File.Delete(PreviousAutoSavedFileName);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsSaved)
            {
                string prompt = Strings.Messages.SaveOnExit;
                if (e.CloseReason == CloseReason.WindowsShutDown)
                {
                    prompt = Strings.Messages.SaveOnExit1;
                }
                if (e.CloseReason == CloseReason.TaskManagerClosing)
                {
                    prompt = Strings.Messages.SaveOnExit2;
                }
                MsgBoxResult msgBoxResult = Interaction.MsgBox(prompt, MsgBoxStyle.YesNoCancel | MsgBoxStyle.Question, Text);
                if (msgBoxResult == MsgBoxResult.Yes)
                {
                    if (Operators.CompareString(ExcludeFileName(FileName), "", TextCompare: false) == 0)
                    {
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = Strings.FileType._bms + "|*.bms;*.bme;*.bml;*.pms;*.txt|" + Strings.FileType.BMS + "|*.bms|" + Strings.FileType.BME + "|*.bme|" + Strings.FileType.BML + "|*.bml|" + Strings.FileType.PMS + "|*.pms|" + Strings.FileType.TXT + "|*.txt|" + Strings.FileType._all + "|*.*";
                        saveFileDialog.DefaultExt = "bms";
                        saveFileDialog.InitialDirectory = InitPath;
                        if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                        {
                            e.Cancel = true;
                            return;
                        }
                        SetFileName(saveFileDialog.FileName);
                    }
                    string text = SaveBMS();
                    MyProject.Computer.FileSystem.WriteAllText(FileName, text, append: false, TextEncoding);
                    NewRecent(FileName);
                    if (BeepWhileSaved)
                    {
                        Interaction.Beep();
                    }
                }
                if (msgBoxResult == MsgBoxResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
            if (!e.Cancel)
            {
                SaveSettings(MyProject.Application.Info.DirectoryPath + "\\iBMSC.Settings.xml", ThemeOnly: false);
            }
        }

        private string[] FilterFileBySupported(string[] xFile, string[] xFilter)
        {
            string[] array = Array.Empty<string>();
            int num = Information.UBound(xFile);
            for (int i = 0; i <= num; i++)
            {
                if (MyProject.Computer.FileSystem.FileExists(xFile[i]) & (Array.IndexOf(xFilter, Path.GetExtension(xFile[i])) != -1))
                {
                    array = (string[])Utils.CopyArray(array, new string[Information.UBound(array) + 1 + 1]);
                    array[Information.UBound(array)] = xFile[i];
                }
                if (!MyProject.Computer.FileSystem.DirectoryExists(xFile[i]))
                {
                    continue;
                }
                FileInfo[] files = MyProject.Computer.FileSystem.GetDirectoryInfo(xFile[i]).GetFiles();
                foreach (FileInfo fileInfo in files)
                {
                    if (Array.IndexOf(xFilter, fileInfo.Extension) != -1)
                    {
                        array = (string[])Utils.CopyArray(array, new string[Information.UBound(array) + 1 + 1]);
                        array[Information.UBound(array)] = fileInfo.FullName;
                    }
                }
            }
            return array;
        }

        private void InitializeNewBMS()
        {
            THTitle.Text = "";
            THArtist.Text = "";
            THGenre.Text = "";
            THBPM.Value = 120m;
            if (CHPlayer.SelectedIndex == -1)
            {
                CHPlayer.SelectedIndex = 0;
            }
            CHRank.SelectedIndex = 3;
            THPlayLevel.Text = "";
            THSubTitle.Text = "";
            THSubArtist.Text = "";
            THStageFile.Text = "";
            THBanner.Text = "";
            THBackBMP.Text = "";
            CHDifficulty.SelectedIndex = 0;
            THExRank.Text = "";
            THTotal.Text = "";
            THComment.Text = "";
            CHLnObj.SelectedIndex = 0;
            TExpansion.Text = "";
            LBeat.Items.Clear();
            int num = 0;
            do
            {
                MeasureLength[num] = 192.0;
                MeasureBottom[num] = num * 192.0;
                LBeat.Items.Add(Functions.Add3Zeros(num) + ": 1 ( 4 / 4 )");
                num += 1;
            }
            while (num <= 999);
        }

        private void InitializeOpenBMS()
        {
            CHPlayer.SelectedIndex = 0;
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                DDFileName = FilterFileBySupported((string[])e.Data.GetData(DataFormats.FileDrop), SupportedFileExtension);
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
            RefreshPanelAll();
        }

        private void Form1_DragLeave(object sender, EventArgs e)
        {
            DDFileName = Array.Empty<string>();
            RefreshPanelAll();
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            DDFileName = Array.Empty<string>();
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] xFile = (string[])e.Data.GetData(DataFormats.FileDrop);
                string[] array = FilterFileBySupported(xFile, SupportedFileExtension);
                if (array.Length > 0)
                {
                    fLoadFileProgress fLoadFileProgress2 = new fLoadFileProgress(array, IsSaved);
                    fLoadFileProgress2.ShowDialog(this);
                }
                RefreshPanelAll();
            }
        }

        private void setFullScreen(bool value)
        {
            if (value)
            {
                if (WindowState != FormWindowState.Minimized)
                {
                    SuspendLayout();
                    previousWindowPosition.Location = Location;
                    previousWindowPosition.Size = Size;
                    previousWindowState = WindowState;
                    WindowState = FormWindowState.Normal;
                    FormBorderStyle = FormBorderStyle.None;
                    WindowState = FormWindowState.Maximized;
                    ToolStripContainer1.TopToolStripPanelVisible = false;
                    ResumeLayout();
                    isFullScreen = true;
                }
            }
            else
            {
                SuspendLayout();
                FormBorderStyle = FormBorderStyle.Sizable;
                ToolStripContainer1.TopToolStripPanelVisible = true;
                WindowState = FormWindowState.Normal;
                WindowState = previousWindowState;
                if (WindowState == FormWindowState.Normal)
                {
                    Location = previousWindowPosition.Location;
                    Size = previousWindowPosition.Size;
                }
                ResumeLayout();
                isFullScreen = false;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Keys keyCode = e.KeyCode;
            if (keyCode == Keys.F11)
            {
                setFullScreen(!isFullScreen);
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            RefreshPanelAll();
            POStatusRefresh();
        }

        internal void ReadFile(string xPath)
        {
            switch (Microsoft.VisualBasic.Strings.LCase(Path.GetExtension(xPath)))
            {
                case ".bms":
                case ".bme":
                case ".bml":
                case ".pms":
                case ".txt":
                    OpenBMS(MyProject.Computer.FileSystem.ReadAllText(xPath, TextEncoding));
                    ClearUndo();
                    NewRecent(xPath);
                    SetFileName(xPath);
                    SetIsSaved(isSaved: true);
                    break;
                case ".sm":
                    if (!OpenSM(MyProject.Computer.FileSystem.ReadAllText(xPath, TextEncoding)))
                    {
                        InitPath = ExcludeFileName(xPath);
                        ClearUndo();
                        SetFileName("Untitled.bms");
                        SetIsSaved(isSaved: false);
                    }
                    break;
                case ".ibmsc":
                    OpeniBMSC(xPath);
                    InitPath = ExcludeFileName(xPath);
                    NewRecent(xPath);
                    SetFileName("Imported_" + GetFileName(xPath));
                    SetIsSaved(isSaved: false);
                    break;
            }
        }

        public double GCD(double NumA, double NumB)
        {
            double num = NumA;
            double num2 = NumB;
            if (NumA < NumB)
            {
                num = NumB;
                num2 = NumA;
            }
            while (num2 >= BMSGridLimit)
            {
                double num3 = num - Math.Floor(num / num2) * num2;
                num = num2;
                num2 = num3;
            }
            return num;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr LoadCursorFromFile(string fileName);

        public static Cursor ActuallyLoadCursor(string path)
        {
            return new Cursor(LoadCursorFromFile(path));
        }

        private void Unload()
        {
            Audio.Finalize();
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private void Form1_Load(object sender, EventArgs e)
        {
            TopMost = true;
            SuspendLayout();
            Visible = false;
            SetFileName(FileName);
            InitializeNewBMS();
            var lErl = default(int);
            try
            {
                var text = Functions.RandomFileName(".cur");
                MyProject.Computer.FileSystem.WriteAllBytes(text, Resources.CursorResizeDown, append: false);
                var cursor = ActuallyLoadCursor(text);
                MyProject.Computer.FileSystem.WriteAllBytes(text, Resources.CursorResizeLeft, append: false);
                var cursor2 = ActuallyLoadCursor(text);
                MyProject.Computer.FileSystem.WriteAllBytes(text, Resources.CursorResizeRight, append: false);
                var cursor3 = ActuallyLoadCursor(text);
                File.Delete(text);
                POWAVResizer.Cursor = cursor;
                POBeatResizer.Cursor = cursor;
                POExpansionResizer.Cursor = cursor;
                POptionsResizer.Cursor = cursor2;
                SpL.Cursor = cursor3;
                SpR.Cursor = cursor2;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex, lErl);
                var ex2 = ex;
                ProjectData.ClearProjectError();
            }
            spMain = new Panel[3] { PMainInL, PMainIn, PMainInR };
            sUndo[0] = new UndoRedo.NoOperation();
            sUndo[1] = new UndoRedo.NoOperation();
            sRedo[0] = new UndoRedo.NoOperation();
            sRedo[1] = new UndoRedo.NoOperation();
            sI = 0;
            LWAV.Items.Clear();
            var num = 1;
            do
            {
                LWAV.Items.Add(Functions.C10to36(num) + ":");
                num++;
            }
            while (num <= 1295);
            LWAV.SelectedIndex = 0;
            CHPlayer.SelectedIndex = 0;
            CalculateGreatestVPosition();
            TBLangRefresh_Click(TBLangRefresh, null);
            TBThemeRefresh_Click(TBThemeRefresh, null);
            POHeaderPart2.Visible = false;
            POGridPart2.Visible = false;
            POWaveFormPart2.Visible = false;
            if (MyProject.Computer.FileSystem.FileExists(MyProject.Application.Info.DirectoryPath + "\\iBMSC.Settings.xml"))
            {
                LoadSettings(MyProject.Application.Info.DirectoryPath + "\\iBMSC.Settings.xml");
            }
            SetIsSaved(isSaved: true);
            var commandLineArgs = Environment.GetCommandLineArgs();
            if (commandLineArgs.Length == 2)
            {
                ReadFile(commandLineArgs[1]);
                if (Operators.CompareString(Microsoft.VisualBasic.Strings.LCase(Path.GetExtension(commandLineArgs[1])), ".ibmsc", TextCompare: false) == 0 && GetFileName(commandLineArgs[1]).StartsWith("AutoSave_", ignoreCase: true, null))
                {
                    goto IL_03ba;
                }
            }
            IsInitializing = false;
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length <= 1)
            {
                var files = MyProject.Computer.FileSystem.GetDirectoryInfo(MyProject.Application.Info.DirectoryPath).GetFiles("AutoSave_*.IBMSC");
                if (files != null && files.Length != 0)
                {
                    if (Interaction.MsgBox(Microsoft.VisualBasic.Strings.Replace(Strings.Messages.RestoreAutosavedFile, "{}", Conversions.ToString(files.Length)), MsgBoxStyle.YesNo | MsgBoxStyle.MsgBoxSetForeground) == MsgBoxResult.Yes)
                    {
                        foreach (var fileInfo in files)
                        {
                            Process.Start(Application.ExecutablePath, "\"" + fileInfo.FullName + "\"");
                        }
                    }

                    foreach (var fileInfo2 in files)
                    {
                        pTempFileNames = (string[])Utils.CopyArray(pTempFileNames, new string[Information.UBound(pTempFileNames) + 1 + 1]);
                        pTempFileNames[Information.UBound(pTempFileNames)] = fileInfo2.FullName;
                    }
                }
            }
            goto IL_03ba;
IL_03ba:
            lErl = 1000;
            IsInitializing = false;
            POStatusRefresh();
            ResumeLayout();
            tempResize = (int)WindowState;
            TopMost = false;
            WindowState = (FormWindowState)tempResize;
            Visible = true;
        }

        private void UpdatePairing()
        {
            if (NTInput)
            {
                int num = Information.UBound(Notes);
                for (int i = 0; i <= num; i++)
                {
                    Notes[i].HasError = false;
                    Notes[i].LNPair = 0;
                    if (Notes[i].Length < 0.0)
                    {
                        Notes[i].Length = 0.0;
                    }
                }
                int num2 = Information.UBound(Notes);
                for (int i = 1; i <= num2; i++)
                {
                    int j;
                    if (Notes[i].Length != 0.0)
                    {
                        int num3 = i + 1;
                        int num4 = Information.UBound(Notes);
                        for (j = num3; j <= num4 && !(Notes[j].VPosition > Notes[i].VPosition + Notes[i].Length); j++)
                        {
                            if (Notes[j].ColumnIndex == Notes[i].ColumnIndex)
                            {
                                Notes[j].HasError = true;
                            }
                        }
                        continue;
                    }
                    int num5 = i + 1;
                    int num6 = Information.UBound(Notes);
                    for (j = num5; j <= num6 && !(Notes[j].VPosition > Notes[i].VPosition); j++)
                    {
                        if (Notes[j].ColumnIndex == Notes[i].ColumnIndex)
                        {
                            Notes[j].HasError = true;
                        }
                    }
                    if (Notes[i].Value / 10000 != LnObj || IsColumnNumeric(Notes[i].ColumnIndex))
                    {
                        continue;
                    }
                    for (j = i - 1; j >= 1; j += -1)
                    {
                        if (Notes[j].ColumnIndex == Notes[i].ColumnIndex && !Notes[j].Hidden)
                        {
                            if (Notes[j].Length != 0.0 || Notes[j].Value / 10000 == LnObj)
                            {
                                Notes[i].HasError = true;
                                break;
                            }
                            Notes[i].LNPair = j;
                            Notes[j].LNPair = i;
                            break;
                        }
                    }
                    if (j == 0)
                    {
                        Notes[i].HasError = true;
                    }
                }
            }
            else
            {
                int num7 = Information.UBound(Notes);
                for (int i = 0; i <= num7; i++)
                {
                    Notes[i].HasError = false;
                    Notes[i].LNPair = 0;
                }
                int num8 = Information.UBound(Notes);
                for (int i = 1; i <= num8; i++)
                {
                    if (Notes[i].LongNote)
                    {
                        int j = i - 1;
                        while (true)
                        {
                            if (j >= 1)
                            {
                                if (Notes[j].ColumnIndex != Notes[i].ColumnIndex)
                                {
                                    j += -1;
                                    continue;
                                }
                                if (Notes[j].VPosition == Notes[i].VPosition)
                                {
                                    Notes[i].HasError = true;
                                    break;
                                }
                                if (Notes[j].LongNote & (Notes[j].LNPair == i))
                                {
                                    Notes[i].LNPair = j;
                                    break;
                                }
                            }
                            int num9 = i + 1;
                            int num10 = Information.UBound(Notes);
                            for (j = num9; j <= num10; j++)
                            {
                                if (Notes[j].ColumnIndex == Notes[i].ColumnIndex)
                                {
                                    Notes[i].LNPair = j;
                                    Notes[j].LNPair = i;
                                    if (!Notes[j].LongNote && Notes[j].Value / 10000 != LnObj)
                                    {
                                        Notes[j].HasError = true;
                                    }
                                    break;
                                }
                            }
                            if (j == Information.UBound(Notes) + 1)
                            {
                                Notes[i].HasError = true;
                            }
                            break;
                        }
                        continue;
                    }
                    if ((Notes[i].Value / 10000 == LnObj) & !IsColumnNumeric(Notes[i].ColumnIndex))
                    {
                        int j;
                        for (j = i - 1; j >= 1; j += -1)
                        {
                            if (Notes[i].ColumnIndex == Notes[j].ColumnIndex)
                            {
                                if ((Notes[j].LNPair != 0) & (Notes[j].LNPair != i))
                                {
                                    Notes[j].HasError = true;
                                }
                                Notes[i].LNPair = j;
                                Notes[j].LNPair = i;
                                if (Notes[i].VPosition == Notes[j].VPosition)
                                {
                                    Notes[i].HasError = true;
                                }
                                if (Notes[j].Value / 10000 == LnObj)
                                {
                                    Notes[j].HasError = true;
                                }
                                break;
                            }
                        }
                        if (j == 0)
                        {
                            Notes[i].HasError = true;
                        }
                        continue;
                    }
                    for (int j = i - 1; j >= 1 && !(Notes[j].VPosition < Notes[i].VPosition); j += -1)
                    {
                        if (Notes[j].ColumnIndex == Notes[i].ColumnIndex)
                        {
                            Notes[i].HasError = true;
                            break;
                        }
                    }
                }
            }
            double num11 = 0.0;
            double num12 = Notes[0].Value / 10000.0;
            double num13 = 0.0;
            int num14 = Information.UBound(Notes);
            for (int i = 1; i <= num14; i++)
            {
                if (Notes[i].ColumnIndex == 2)
                {
                    num11 += (Notes[i].VPosition - num13) / num12 * 1250.0;
                    num12 = Notes[i].Value / 10000.0;
                    num13 = Notes[i].VPosition;
                }
            }
        }

        public void ExceptionSave(string Path)
        {
            SaveiBMSC(Path);
        }

        private bool ClosingPopSave()
        {
            if (!IsSaved)
            {
                MsgBoxResult msgBoxResult = Interaction.MsgBox(Strings.Messages.SaveOnExit, MsgBoxStyle.YesNoCancel | MsgBoxStyle.Question, Text);
                if (msgBoxResult == MsgBoxResult.Yes)
                {
                    if (Operators.CompareString(ExcludeFileName(FileName), "", TextCompare: false) == 0)
                    {
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = Strings.FileType._bms + "|*.bms;*.bme;*.bml;*.pms;*.txt|" + Strings.FileType.BMS + "|*.bms|" + Strings.FileType.BME + "|*.bme|" + Strings.FileType.BML + "|*.bml|" + Strings.FileType.PMS + "|*.pms|" + Strings.FileType.TXT + "|*.txt|" + Strings.FileType._all + "|*.*";
                        saveFileDialog.DefaultExt = "bms";
                        saveFileDialog.InitialDirectory = InitPath;
                        if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                        {
                            return true;
                        }
                        SetFileName(saveFileDialog.FileName);
                    }
                    string text = SaveBMS();
                    MyProject.Computer.FileSystem.WriteAllText(FileName, text, append: false, TextEncoding);
                    NewRecent(FileName);
                    if (BeepWhileSaved)
                    {
                        Interaction.Beep();
                    }
                }
                if (msgBoxResult == MsgBoxResult.Cancel)
                {
                    return true;
                }
            }
            return false;
        }

        private void TBNew_Click(object sender, EventArgs e)
        {
            SelectedNotes = Array.Empty<Note>();
            KMouseOver = -1;
            if (!ClosingPopSave())
            {
                ClearUndo();
                InitializeNewBMS();
                Notes = new Note[1];
                mColumn = new int[1000];
                hWAV = new string[1296];
                hBPM = new long[1296];
                hSTOP = new long[1296];
                hSCROLL = new long[1296];
                THGenre.Text = "";
                THTitle.Text = "";
                THArtist.Text = "";
                THPlayLevel.Text = "";
                Note[] notes = Notes;
                int num = 0;
                notes[num].ColumnIndex = 2;
                notes[num].VPosition = -1.0;
                notes[num].Value = 1200000L;
                THBPM.Value = 120m;
                LWAV.Items.Clear();
                int num2 = 1;
                do
                {
                    LWAV.Items.Add(Functions.C10to36(num2) + ": " + hWAV[num2]);
                    num2 += 1;
                }
                while (num2 <= 1295);
                LWAV.SelectedIndex = 0;
                SetFileName("Untitled.bms");
                SetIsSaved(isSaved: true);
                CalculateTotalPlayableNotes();
                CalculateGreatestVPosition();
                RefreshPanelAll();
                POStatusRefresh();
            }
        }

        private void TBNewC_Click(object sender, EventArgs e)
        {
            SelectedNotes = Array.Empty<Note>();
            KMouseOver = -1;
            if (!ClosingPopSave())
            {
                ClearUndo();
                Notes = new Note[1];
                mColumn = new int[1000];
                hWAV = new string[1296];
                hBPM = new long[1296];
                hSTOP = new long[1296];
                hSCROLL = new long[1296];
                THGenre.Text = "";
                THTitle.Text = "";
                THArtist.Text = "";
                THPlayLevel.Text = "";
                Note[] notes = Notes;
                int num = 0;
                notes[num].ColumnIndex = 2;
                notes[num].VPosition = -1.0;
                notes[num].Value = 1200000L;
                THBPM.Value = 120m;
                SetFileName("Untitled.bms");
                SetIsSaved(isSaved: true);
                if (Interaction.MsgBox("Please copy your code to clipboard and click OK.", MsgBoxStyle.OkCancel, "Create from code") != MsgBoxResult.Cancel)
                {
                    OpenBMS(Clipboard.GetText());
                }
            }
        }

        private void TBOpen_ButtonClick(object sender, EventArgs e)
        {
            SelectedNotes = Array.Empty<Note>();
            KMouseOver = -1;
            if (!ClosingPopSave())
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = Strings.FileType._bms + "|*.bms;*.bme;*.bml;*.pms;*.txt";
                openFileDialog.DefaultExt = "bms";
                openFileDialog.InitialDirectory = Conversions.ToString(Interaction.IIf(Operators.CompareString(ExcludeFileName(FileName), "", TextCompare: false) == 0, InitPath, ExcludeFileName(FileName)));
                if (openFileDialog.ShowDialog() != DialogResult.Cancel)
                {
                    InitPath = ExcludeFileName(openFileDialog.FileName);
                    OpenBMS(MyProject.Computer.FileSystem.ReadAllText(openFileDialog.FileName, TextEncoding));
                    ClearUndo();
                    SetFileName(openFileDialog.FileName);
                    NewRecent(FileName);
                    SetIsSaved(isSaved: true);
                }
            }
        }

        private void TBImportIBMSC_Click(object sender, EventArgs e)
        {
            SelectedNotes = Array.Empty<Note>();
            KMouseOver = -1;
            if (!ClosingPopSave())
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = Strings.FileType.IBMSC + "|*.ibmsc";
                openFileDialog.DefaultExt = "ibmsc";
                openFileDialog.InitialDirectory = Conversions.ToString(Interaction.IIf(Operators.CompareString(ExcludeFileName(FileName), "", TextCompare: false) == 0, InitPath, ExcludeFileName(FileName)));
                if (openFileDialog.ShowDialog() != DialogResult.Cancel)
                {
                    InitPath = ExcludeFileName(openFileDialog.FileName);
                    SetFileName("Imported_" + GetFileName(openFileDialog.FileName));
                    OpeniBMSC(openFileDialog.FileName);
                    NewRecent(openFileDialog.FileName);
                    SetIsSaved(isSaved: false);
                }
            }
        }

        private void TBImportSM_Click(object sender, EventArgs e)
        {
            SelectedNotes = Array.Empty<Note>();
            KMouseOver = -1;
            if (!ClosingPopSave())
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = Strings.FileType.SM + "|*.sm";
                openFileDialog.DefaultExt = "sm";
                openFileDialog.InitialDirectory = Conversions.ToString(Interaction.IIf(Operators.CompareString(ExcludeFileName(FileName), "", TextCompare: false) == 0, InitPath, ExcludeFileName(FileName)));
                if (openFileDialog.ShowDialog() != DialogResult.Cancel && !OpenSM(MyProject.Computer.FileSystem.ReadAllText(openFileDialog.FileName, TextEncoding)))
                {
                    InitPath = ExcludeFileName(openFileDialog.FileName);
                    SetFileName("Untitled.bms");
                    ClearUndo();
                    SetIsSaved(isSaved: false);
                }
            }
        }

        private void TBSave_ButtonClick(object sender, EventArgs e)
        {
            SelectedNotes = Array.Empty<Note>();
            KMouseOver = -1;
            if (Operators.CompareString(ExcludeFileName(FileName), "", TextCompare: false) == 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = Strings.FileType._bms + "|*.bms;*.bme;*.bml;*.pms;*.txt|" + Strings.FileType.BMS + "|*.bms|" + Strings.FileType.BME + "|*.bme|" + Strings.FileType.BML + "|*.bml|" + Strings.FileType.PMS + "|*.pms|" + Strings.FileType.TXT + "|*.txt|" + Strings.FileType._all + "|*.*";
                saveFileDialog.DefaultExt = "bms";
                saveFileDialog.InitialDirectory = InitPath;
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                InitPath = ExcludeFileName(saveFileDialog.FileName);
                SetFileName(saveFileDialog.FileName);
            }
            string text = SaveBMS();
            MyProject.Computer.FileSystem.WriteAllText(FileName, text, append: false, TextEncoding);
            NewRecent(FileName);
            SetFileName(FileName);
            SetIsSaved(isSaved: true);
            if (BeepWhileSaved)
            {
                Interaction.Beep();
            }
        }

        private void TBSaveAs_Click(object sender, EventArgs e)
        {
            SelectedNotes = Array.Empty<Note>();
            KMouseOver = -1;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = Strings.FileType._bms + "|*.bms;*.bme;*.bml;*.pms;*.txt|" + Strings.FileType.BMS + "|*.bms|" + Strings.FileType.BME + "|*.bme|" + Strings.FileType.BML + "|*.bml|" + Strings.FileType.PMS + "|*.pms|" + Strings.FileType.TXT + "|*.txt|" + Strings.FileType._all + "|*.*";
            saveFileDialog.DefaultExt = "bms";
            saveFileDialog.InitialDirectory = Conversions.ToString(Interaction.IIf(Operators.CompareString(ExcludeFileName(FileName), "", TextCompare: false) == 0, InitPath, ExcludeFileName(FileName)));
            if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                InitPath = ExcludeFileName(saveFileDialog.FileName);
                SetFileName(saveFileDialog.FileName);
                string text = SaveBMS();
                MyProject.Computer.FileSystem.WriteAllText(FileName, text, append: false, TextEncoding);
                NewRecent(FileName);
                SetFileName(FileName);
                SetIsSaved(isSaved: true);
                if (BeepWhileSaved)
                {
                    Interaction.Beep();
                }
            }
        }

        private void TBExport_Click(object sender, EventArgs e)
        {
            SelectedNotes = Array.Empty<Note>();
            KMouseOver = -1;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = Strings.FileType.IBMSC + "|*.ibmsc";
            saveFileDialog.DefaultExt = "ibmsc";
            saveFileDialog.InitialDirectory = Conversions.ToString(Interaction.IIf(Operators.CompareString(ExcludeFileName(FileName), "", TextCompare: false) == 0, InitPath, ExcludeFileName(FileName)));
            if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                SaveiBMSC(saveFileDialog.FileName);
                NewRecent(FileName);
                if (BeepWhileSaved)
                {
                    Interaction.Beep();
                }
            }
        }

        private void VSGotFocus(object sender, EventArgs e)
        {
            PanelFocus = Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "Tag", Array.Empty<object>(), null, null, null));
            spMain[PanelFocus].Focus();
        }

        private void VSValueChanged(object sender, EventArgs e)
        {
            int num = Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "Tag", Array.Empty<object>(), null, null, null));
            if (MyProject.Computer.Keyboard.CtrlKeyDown)
            {
                NewLateBinding.LateSet(sender, null, "Value", new object[1] { VSValue }, null, null);
                return;
            }
            bool num2 = num == PanelFocus;
            PointF lastMouseDownLocation = LastMouseDownLocation;
            Point point = new Point(-1, -1);
            if (num2 & !(lastMouseDownLocation == point) & (VSValue != -1))
            {
                LastMouseDownLocation.Y = Conversions.ToSingle(Operators.AddObject(LastMouseDownLocation.Y, Operators.MultiplyObject(Operators.SubtractObject(VSValue, NewLateBinding.LateGet(sender, null, "Value", Array.Empty<object>(), null, null, null)), gxHeight)));
            }
            PanelVScroll[num] = Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "Value", Array.Empty<object>(), null, null, null));
            if (spLock[(num + 1) % 3])
            {
                int num3 = PanelVScroll[num] + spDiff[num];
                if (num3 > 0)
                {
                    num3 = 0;
                }
                if (num3 < MainPanelScroll.Minimum)
                {
                    num3 = MainPanelScroll.Minimum;
                }
                switch (num)
                {
                    case 0:
                        MainPanelScroll.Value = num3;
                        break;
                    case 1:
                        RightPanelScroll.Value = num3;
                        break;
                    case 2:
                        LeftPanelScroll.Value = num3;
                        break;
                }
            }
            if (spLock[(num + 2) % 3])
            {
                int num4 = PanelVScroll[num] - spDiff[(num + 2) % 3];
                if (num4 > 0)
                {
                    num4 = 0;
                }
                if (num4 < MainPanelScroll.Minimum)
                {
                    num4 = MainPanelScroll.Minimum;
                }
                switch (num)
                {
                    case 0:
                        RightPanelScroll.Value = num4;
                        break;
                    case 1:
                        LeftPanelScroll.Value = num4;
                        break;
                    case 2:
                        MainPanelScroll.Value = num4;
                        break;
                }
            }
            spDiff[num] = PanelVScroll[(num + 1) % 3] - PanelVScroll[num];
            spDiff[(num + 2) % 3] = PanelVScroll[num] - PanelVScroll[(num + 2) % 3];
            VSValue = Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "Value", Array.Empty<object>(), null, null, null));
            RefreshPanel(num, spMain[num].DisplayRectangle);

        }

        private void cVSLock_CheckedChanged(object sender, EventArgs e)
        {
            int num = Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "Tag", Array.Empty<object>(), null, null, null));
            spLock[num] = Conversions.ToBoolean(NewLateBinding.LateGet(sender, null, "Checked", Array.Empty<object>(), null, null, null));
            if (spLock[num])
            {
                spDiff[num] = PanelVScroll[(num + 1) % 3] - PanelVScroll[num];
                spDiff[(num + 2) % 3] = PanelVScroll[num] - PanelVScroll[(num + 2) % 3];
            }

        }

        private void HSGotFocus(object sender, EventArgs e)
        {
            PanelFocus = Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "Tag", Array.Empty<object>(), null, null, null));
            spMain[PanelFocus].Focus();
        }

        private void HSValueChanged(object sender, EventArgs e)
        {
            int num = Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "Tag", Array.Empty<object>(), null, null, null));
            PointF lastMouseDownLocation = LastMouseDownLocation;
            Point point = new Point(-1, -1);
            if (!(lastMouseDownLocation == point) & (HSValue != -1))
            {
                LastMouseDownLocation.X = Conversions.ToSingle(Operators.AddObject(LastMouseDownLocation.X, Operators.MultiplyObject(Operators.SubtractObject(HSValue, NewLateBinding.LateGet(sender, null, "Value", Array.Empty<object>(), null, null, null)), gxWidth)));
            }
            PanelHScroll[num] = Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "Value", Array.Empty<object>(), null, null, null));
            HSValue = Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "Value", Array.Empty<object>(), null, null, null));
            RefreshPanel(num, spMain[num].DisplayRectangle);
        }

        private void TBSelect_Click(object sender, EventArgs e)
        {
            TBSelect.Checked = true;
            TBWrite.Checked = false;
            TBTimeSelect.Checked = false;
            mnSelect.Checked = true;
            mnWrite.Checked = false;
            mnTimeSelect.Checked = false;
            FStatus2.Visible = false;
            FStatus.Visible = true;
            ShouldDrawTempNote = false;
            SelectedColumn = -1;
            TempVPosition = -1.0;
            TempLength = 0.0;
            vSelStart = MeasureBottom[MeasureAtDisplacement(-PanelVScroll[PanelFocus]) + 1];
            vSelLength = 0.0;
            RefreshPanelAll();
            POStatusRefresh();
        }

        private void TBWrite_Click(object sender, EventArgs e)
        {
            TBSelect.Checked = false;
            TBWrite.Checked = true;
            TBTimeSelect.Checked = false;
            mnSelect.Checked = false;
            mnWrite.Checked = true;
            mnTimeSelect.Checked = false;
            FStatus2.Visible = false;
            FStatus.Visible = true;
            ShouldDrawTempNote = true;
            SelectedColumn = -1;
            TempVPosition = -1.0;
            TempLength = 0.0;
            vSelStart = MeasureBottom[MeasureAtDisplacement(-PanelVScroll[PanelFocus]) + 1];
            vSelLength = 0.0;
            RefreshPanelAll();
            POStatusRefresh();
        }

        private void TBPostEffects_Click(object sender, EventArgs e)
        {
            TBSelect.Checked = false;
            TBWrite.Checked = false;
            TBTimeSelect.Checked = true;
            mnSelect.Checked = false;
            mnWrite.Checked = false;
            mnTimeSelect.Checked = true;
            FStatus.Visible = false;
            FStatus2.Visible = true;
            vSelMouseOverLine = 0;
            ShouldDrawTempNote = false;
            SelectedColumn = -1;
            TempVPosition = -1.0;
            TempLength = 0.0;
            ValidateSelection();
            int num = Information.UBound(Notes);
            for (int i = 0; i <= num; i += 1)
            {
                Notes[i].Selected = false;
            }
            RefreshPanelAll();
            POStatusRefresh();
        }

        private void CGHeight_ValueChanged(object sender, EventArgs e)
        {
            gxHeight = Convert.ToSingle(CGHeight.Value);
            CGHeight2.Value = Conversions.ToInteger(Interaction.IIf(decimal.Compare(decimal.Multiply(CGHeight.Value, new decimal(4L)), new decimal(CGHeight2.Maximum)) < 0, decimal.Multiply(CGHeight.Value, new decimal(4L)), CGHeight2.Maximum));
            RefreshPanelAll();
        }

        private void CGHeight2_Scroll(object sender, EventArgs e)
        {
            CGHeight.Value = new decimal(CGHeight2.Value / 4.0);
        }

        private void CGWidth_ValueChanged(object sender, EventArgs e)
        {
            gxWidth = Convert.ToSingle(CGWidth.Value);
            CGWidth2.Value = Conversions.ToInteger(Interaction.IIf(decimal.Compare(decimal.Multiply(CGWidth.Value, new decimal(4L)), new decimal(CGWidth2.Maximum)) < 0, decimal.Multiply(CGWidth.Value, new decimal(4L)), CGWidth2.Maximum));
            HS.LargeChange = (int)Math.Round(PMainIn.Width / gxWidth);
            if (HS.Value > HS.Maximum - HS.LargeChange + 1)
            {
                HS.Value = HS.Maximum - HS.LargeChange + 1;
            }
            HSL.LargeChange = (int)Math.Round(PMainInL.Width / gxWidth);
            if (HSL.Value > HSL.Maximum - HSL.LargeChange + 1)
            {
                HSL.Value = HSL.Maximum - HSL.LargeChange + 1;
            }
            HSR.LargeChange = (int)Math.Round(PMainInR.Width / gxWidth);
            if (HSR.Value > HSR.Maximum - HSR.LargeChange + 1)
            {
                HSR.Value = HSR.Maximum - HSR.LargeChange + 1;
            }
            RefreshPanelAll();
        }

        private void CGWidth2_Scroll(object sender, EventArgs e)
        {
            CGWidth.Value = new decimal(CGWidth2.Value / 4.0);
        }

        private void CGDivide_ValueChanged(object sender, EventArgs e)
        {
            gDivide = Convert.ToInt32(CGDivide.Value);
            RefreshPanelAll();
        }

        private void CGSub_ValueChanged(object sender, EventArgs e)
        {
            gSub = Convert.ToInt32(CGSub.Value);
            RefreshPanelAll();
        }

        private void BGSlash_Click(object sender, EventArgs e)
        {
            int num = (int)Math.Round(Conversion.Val(Interaction.InputBox(Strings.Messages.PromptSlashValue, "", Conversions.ToString(gSlash))));
            if (num != 0)
            {
                if (decimal.Compare(new decimal(num), CGDivide.Maximum) > 0)
                {
                    num = Convert.ToInt32(CGDivide.Maximum);
                }
                if (decimal.Compare(new decimal(num), CGDivide.Minimum) < 0)
                {
                    num = Convert.ToInt32(CGDivide.Minimum);
                }
                gSlash = num;
            }
        }

        private void CGSnap_CheckedChanged(object sender, EventArgs e)
        {
            gSnap = CGSnap.Checked;
            RefreshPanelAll();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            switch (PanelFocus)
            {
                case 0:
                    {
                        VScrollBar leftPanelScroll = LeftPanelScroll;
                        int num = (int)Math.Round(leftPanelScroll.Value + tempY / 5.0 / gxHeight);
                        if (num > 0)
                        {
                            num = 0;
                        }
                        if (num < leftPanelScroll.Minimum)
                        {
                            num = leftPanelScroll.Minimum;
                        }
                        leftPanelScroll.Value = num;
                        leftPanelScroll = null;
                        HScrollBar hSL = HSL;
                        num = (int)Math.Round(hSL.Value + tempX / 10.0 / gxWidth);
                        if (num > hSL.Maximum - hSL.LargeChange + 1)
                        {
                            num = hSL.Maximum - hSL.LargeChange + 1;
                        }
                        if (num < hSL.Minimum)
                        {
                            num = hSL.Minimum;
                        }
                        hSL.Value = num;
                        hSL = null;
                        break;
                    }
                case 1:
                    {
                        VScrollBar mainPanelScroll = MainPanelScroll;
                        int num = (int)Math.Round(mainPanelScroll.Value + tempY / 5.0 / gxHeight);
                        if (num > 0)
                        {
                            num = 0;
                        }
                        if (num < mainPanelScroll.Minimum)
                        {
                            num = mainPanelScroll.Minimum;
                        }
                        mainPanelScroll.Value = num;
                        mainPanelScroll = null;
                        HScrollBar hS = HS;
                        num = (int)Math.Round(hS.Value + tempX / 10.0 / gxWidth);
                        if (num > hS.Maximum - hS.LargeChange + 1)
                        {
                            num = hS.Maximum - hS.LargeChange + 1;
                        }
                        if (num < hS.Minimum)
                        {
                            num = hS.Minimum;
                        }
                        hS.Value = num;
                        hS = null;
                        break;
                    }
                case 2:
                    {
                        VScrollBar rightPanelScroll = RightPanelScroll;
                        int num = (int)Math.Round(rightPanelScroll.Value + tempY / 5.0 / gxHeight);
                        if (num > 0)
                        {
                            num = 0;
                        }
                        if (num < rightPanelScroll.Minimum)
                        {
                            num = rightPanelScroll.Minimum;
                        }
                        rightPanelScroll.Value = num;
                        rightPanelScroll = null;
                        HScrollBar hSR = HSR;
                        num = (int)Math.Round(hSR.Value + tempX / 10.0 / gxWidth);
                        if (num > hSR.Maximum - hSR.LargeChange + 1)
                        {
                            num = hSR.Maximum - hSR.LargeChange + 1;
                        }
                        if (num < hSR.Minimum)
                        {
                            num = hSR.Minimum;
                        }
                        hSR.Value = num;
                        hSR = null;
                        break;
                    }
            }
            MouseEventArgs e2 = new MouseEventArgs(MouseButtons.Left, 0, MouseMoveStatus.X, MouseMoveStatus.Y, 0);
            PMainInMouseMove(spMain[PanelFocus], e2);
        }

        private void TimerMiddle_Tick(object sender, EventArgs e)
        {
            if (!MiddleButtonClicked)
            {
                TimerMiddle.Enabled = false;
                return;
            }
            switch (PanelFocus)
            {
                case 0:
                    {
                        VScrollBar leftPanelScroll = LeftPanelScroll;
                        int num = (int)Math.Round(leftPanelScroll.Value + (Cursor.Position.Y - MiddleButtonLocation.Y) / 5.0 / gxHeight);
                        if (num > 0)
                        {
                            num = 0;
                        }
                        if (num < leftPanelScroll.Minimum)
                        {
                            num = leftPanelScroll.Minimum;
                        }
                        leftPanelScroll.Value = num;
                        leftPanelScroll = null;
                        HScrollBar hSL = HSL;
                        num = (int)Math.Round(hSL.Value + (Cursor.Position.X - MiddleButtonLocation.X) / 5.0 / gxWidth);
                        if (num > hSL.Maximum - hSL.LargeChange + 1)
                        {
                            num = hSL.Maximum - hSL.LargeChange + 1;
                        }
                        if (num < hSL.Minimum)
                        {
                            num = hSL.Minimum;
                        }
                        hSL.Value = num;
                        hSL = null;
                        break;
                    }
                case 1:
                    {
                        VScrollBar mainPanelScroll = MainPanelScroll;
                        int num = (int)Math.Round(mainPanelScroll.Value + (Cursor.Position.Y - MiddleButtonLocation.Y) / 5.0 / gxHeight);
                        if (num > 0)
                        {
                            num = 0;
                        }
                        if (num < mainPanelScroll.Minimum)
                        {
                            num = mainPanelScroll.Minimum;
                        }
                        mainPanelScroll.Value = num;
                        mainPanelScroll = null;
                        HScrollBar hS = HS;
                        num = (int)Math.Round(hS.Value + (Cursor.Position.X - MiddleButtonLocation.X) / 5.0 / gxWidth);
                        if (num > hS.Maximum - hS.LargeChange + 1)
                        {
                            num = hS.Maximum - hS.LargeChange + 1;
                        }
                        if (num < hS.Minimum)
                        {
                            num = hS.Minimum;
                        }
                        hS.Value = num;
                        hS = null;
                        break;
                    }
                case 2:
                    {
                        VScrollBar rightPanelScroll = RightPanelScroll;
                        int num = (int)Math.Round(rightPanelScroll.Value + (Cursor.Position.Y - MiddleButtonLocation.Y) / 5.0 / gxHeight);
                        if (num > 0)
                        {
                            num = 0;
                        }
                        if (num < rightPanelScroll.Minimum)
                        {
                            num = rightPanelScroll.Minimum;
                        }
                        rightPanelScroll.Value = num;
                        rightPanelScroll = null;
                        HScrollBar hSR = HSR;
                        num = (int)Math.Round(hSR.Value + (Cursor.Position.X - MiddleButtonLocation.X) / 5.0 / gxWidth);
                        if (num > hSR.Maximum - hSR.LargeChange + 1)
                        {
                            num = hSR.Maximum - hSR.LargeChange + 1;
                        }
                        if (num < hSR.Minimum)
                        {
                            num = hSR.Minimum;
                        }
                        hSR.Value = num;
                        hSR = null;
                        break;
                    }
            }
            MouseEventArgs e2 = new MouseEventArgs(MouseButtons.Left, 0, MouseMoveStatus.X, MouseMoveStatus.Y, 0);
            PMainInMouseMove(spMain[PanelFocus], e2);
        }

        private void ValidateWavListView()
        {
            try
            {
                Rectangle itemRectangle = LWAV.GetItemRectangle(LWAV.SelectedIndex);
                if (itemRectangle.Top + itemRectangle.Height > LWAV.DisplayRectangle.Height)
                {
                    SendMessage(LWAV.Handle, 277, 1, 0);
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ProjectData.ClearProjectError();
            }
        }

        private void LWAV_Click(object sender, EventArgs e)
        {
            if (TBWrite.Checked)
            {
                FSW.Text = Functions.C10to36(LWAV.SelectedIndex + 1);
            }
            PreviewNote("", bStop: true);
            if (PreviewOnClick && Operators.CompareString(hWAV[LWAV.SelectedIndex + 1], "", TextCompare: false) != 0)
            {
                string xFileLocation = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Interaction.IIf(Operators.CompareString(ExcludeFileName(FileName), "", TextCompare: false) == 0, InitPath, ExcludeFileName(FileName)), "\\"), hWAV[LWAV.SelectedIndex + 1]));
                PreviewNote(xFileLocation, bStop: false);
            }
        }

        private void LWAV_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "wav";
            openFileDialog.Filter = Strings.FileType._wave + "|*.wav;*.ogg;*.mp3|" + Strings.FileType.WAV + "|*.wav|" + Strings.FileType.OGG + "|*.ogg|" + Strings.FileType.MP3 + "|*.mp3|" + Strings.FileType._all + "|*.*";
            openFileDialog.InitialDirectory = Conversions.ToString(Interaction.IIf(Operators.CompareString(ExcludeFileName(FileName), "", TextCompare: false) == 0, InitPath, ExcludeFileName(FileName)));
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                InitPath = ExcludeFileName(openFileDialog.FileName);
                hWAV[LWAV.SelectedIndex + 1] = GetFileName(openFileDialog.FileName);
                LWAV.Items[LWAV.SelectedIndex] = Functions.C10to36(LWAV.SelectedIndex + 1) + ": " + GetFileName(openFileDialog.FileName);
                if (IsSaved)
                {
                    SetIsSaved(isSaved: false);
                }
            }
        }

        private void LWAV_KeyDown(object sender, KeyEventArgs e)
        {
            Keys keyCode = e.KeyCode;
            if (keyCode == Keys.Delete)
            {
                hWAV[LWAV.SelectedIndex + 1] = "";
                LWAV.Items[LWAV.SelectedIndex] = Functions.C10to36(LWAV.SelectedIndex + 1) + ": ";
                if (IsSaved)
                {
                    SetIsSaved(isSaved: false);
                }
            }
        }

        private void TBErrorCheck_Click(object sender, EventArgs e)
        {
            ErrorCheck = Conversions.ToBoolean(NewLateBinding.LateGet(sender, null, "Checked", Array.Empty<object>(), null, null, null));
            TBErrorCheck.Checked = ErrorCheck;
            mnErrorCheck.Checked = ErrorCheck;
            TBErrorCheck.Image = (Image)Interaction.IIf(TBErrorCheck.Checked, Resources.x16CheckError, Resources.x16CheckErrorN);
            mnErrorCheck.Image = (Image)Interaction.IIf(TBErrorCheck.Checked, Resources.x16CheckError, Resources.x16CheckErrorN);
            RefreshPanelAll();
        }

        private void TBPreviewOnClick_Click(object sender, EventArgs e)
        {
            PreviewNote("", bStop: true);
            PreviewOnClick = Conversions.ToBoolean(NewLateBinding.LateGet(sender, null, "Checked", Array.Empty<object>(), null, null, null));
            TBPreviewOnClick.Checked = PreviewOnClick;
            mnPreviewOnClick.Checked = PreviewOnClick;
            TBPreviewOnClick.Image = (Image)Interaction.IIf(PreviewOnClick, Resources.x16PreviewOnClick, Resources.x16PreviewOnClickN);
            mnPreviewOnClick.Image = (Image)Interaction.IIf(PreviewOnClick, Resources.x16PreviewOnClick, Resources.x16PreviewOnClickN);
        }

        private void TBShowFileName_Click(object sender, EventArgs e)
        {
            ShowFileName = Conversions.ToBoolean(NewLateBinding.LateGet(sender, null, "Checked", Array.Empty<object>(), null, null, null));
            TBShowFileName.Checked = ShowFileName;
            mnShowFileName.Checked = ShowFileName;
            TBShowFileName.Image = (Image)Interaction.IIf(ShowFileName, Resources.x16ShowFileName, Resources.x16ShowFileNameN);
            mnShowFileName.Image = (Image)Interaction.IIf(ShowFileName, Resources.x16ShowFileName, Resources.x16ShowFileNameN);
            RefreshPanelAll();
        }

        private void TBCut_Click(object sender, EventArgs e)
        {
            UndoRedo.LinkedURCmd BaseUndo = null;
            UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
            UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
            RedoRemoveNoteSelected(xSel: true, ref BaseUndo, ref BaseRedo);
            CopyNotes(Unselect: false);
            RemoveNotes(SortAndUpdatePairing: false);
            AddUndo(BaseUndo, linkedURCmd.Next);
            SortByVPositionInsertion();
            UpdatePairing();
            CalculateTotalPlayableNotes();
            RefreshPanelAll();
            POStatusRefresh();
            CalculateGreatestVPosition();
        }

        private void TBCopy_Click(object sender, EventArgs e)
        {
            CopyNotes();
            RefreshPanelAll();
            POStatusRefresh();
        }

        private void TBPaste_Click(object sender, EventArgs e)
        {
            AddNotesFromClipboard();
            UndoRedo.LinkedURCmd BaseUndo = null;
            UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
            UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
            RedoAddNoteSelected(xSel: true, ref BaseUndo, ref BaseRedo);
            AddUndo(BaseUndo, linkedURCmd.Next);
            SortByVPositionInsertion();
            UpdatePairing();
            CalculateTotalPlayableNotes();
            RefreshPanelAll();
            POStatusRefresh();
            CalculateGreatestVPosition();
        }

        private string GetFileName(string s)
        {
            int num = Microsoft.VisualBasic.Strings.InStrRev(s, "/");
            int num2 = Microsoft.VisualBasic.Strings.InStrRev(s, "\\");
            return Microsoft.VisualBasic.Strings.Mid(s, Conversions.ToInteger(Operators.AddObject(Interaction.IIf(num > num2, num, num2), 1)));
        }

        private string ExcludeFileName(string s)
        {
            int num = Microsoft.VisualBasic.Strings.InStrRev(s, "/");
            int num2 = Microsoft.VisualBasic.Strings.InStrRev(s, "\\");
            if ((num2 | num) == 0)
            {
                return "";
            }
            return Microsoft.VisualBasic.Strings.Mid(s, 1, Conversions.ToInteger(Operators.SubtractObject(Interaction.IIf(num > num2, num, num2), 1)));
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private void PlayerMissingPrompt()
        {
            PlayerArguments playerArguments = pArgs[CurrentPlayer];
            Interaction.MsgBox(Strings.Messages.CannotFind.Replace("{}", PrevCodeToReal(playerArguments.Path)) + "\r\n" + Strings.Messages.PleaseRespecifyPath, MsgBoxStyle.Critical, Strings.Messages.PlayerNotFound);
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Conversions.ToString(Interaction.IIf(Operators.CompareString(ExcludeFileName(PrevCodeToReal(playerArguments.Path)), "", TextCompare: false) == 0, MyProject.Application.Info.DirectoryPath, ExcludeFileName(PrevCodeToReal(playerArguments.Path))));
            openFileDialog.FileName = PrevCodeToReal(playerArguments.Path);
            openFileDialog.Filter = Strings.FileType.EXE + "|*.exe";
            openFileDialog.DefaultExt = "exe";
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                pArgs[CurrentPlayer].Path = Microsoft.VisualBasic.Strings.Replace(openFileDialog.FileName, MyProject.Application.Info.DirectoryPath, "<apppath>");
                playerArguments = pArgs[CurrentPlayer];
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private void TBPlay_Click(object sender, EventArgs e)
        {
            PlayerArguments playerArguments = pArgs[CurrentPlayer];
            if (!File.Exists(PrevCodeToReal(playerArguments.Path)))
            {
                PlayerMissingPrompt();
                playerArguments = pArgs[CurrentPlayer];
            }
            if (File.Exists(PrevCodeToReal(playerArguments.Path)))
            {
                string text = SaveBMS();
                string text2 = Conversions.ToString(Operators.ConcatenateObject(Interaction.IIf(!PathIsValid(FileName), RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(InitPath, "", TextCompare: false) == 0, MyProject.Application.Info.DirectoryPath, InitPath)), ExcludeFileName(FileName)), "\\___TempBMS.bms"));
                MyProject.Computer.FileSystem.WriteAllText(text2, text, append: false, TextEncoding);
                AddTempFileList(text2);
                Process.Start(PrevCodeToReal(playerArguments.Path), PrevCodeToReal(playerArguments.aHere));
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private void TBPlayB_Click(object sender, EventArgs e)
        {
            PlayerArguments playerArguments = pArgs[CurrentPlayer];
            if (!File.Exists(PrevCodeToReal(playerArguments.Path)))
            {
                PlayerMissingPrompt();
                playerArguments = pArgs[CurrentPlayer];
            }
            if (File.Exists(PrevCodeToReal(playerArguments.Path)))
            {
                string text = SaveBMS();
                string text2 = Conversions.ToString(Operators.ConcatenateObject(Interaction.IIf(!PathIsValid(FileName), RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(InitPath, "", TextCompare: false) == 0, MyProject.Application.Info.DirectoryPath, InitPath)), ExcludeFileName(FileName)), "\\___TempBMS.bms"));
                MyProject.Computer.FileSystem.WriteAllText(text2, text, append: false, TextEncoding);
                AddTempFileList(text2);
                Process.Start(PrevCodeToReal(playerArguments.Path), PrevCodeToReal(playerArguments.aBegin));
            }
        }

        private void TBStop_Click(object sender, EventArgs e)
        {
            PlayerArguments playerArguments = pArgs[CurrentPlayer];
            if (!File.Exists(PrevCodeToReal(playerArguments.Path)))
            {
                PlayerMissingPrompt();
                playerArguments = pArgs[CurrentPlayer];
            }
            if (File.Exists(PrevCodeToReal(playerArguments.Path)))
            {
                Process.Start(PrevCodeToReal(playerArguments.Path), PrevCodeToReal(playerArguments.aStop));
            }
        }

        private void AddTempFileList(string s)
        {
            bool flag = true;
            if (pTempFileNames != null)
            {
                string[] array = pTempFileNames;
                foreach (string left in array)
                {
                    if (Operators.CompareString(left, s, TextCompare: false) == 0)
                    {
                        flag = false;
                        break;
                    }
                }
            }
            if (flag)
            {
                pTempFileNames = (string[])Utils.CopyArray(pTempFileNames, new string[Information.UBound(pTempFileNames) + 1 + 1]);
                pTempFileNames[Information.UBound(pTempFileNames)] = s;
            }
        }

        private void TBStatistics_Click(object sender, EventArgs e)
        {
            SortByVPositionInsertion();
            UpdatePairing();
            int[,] array = new int[7, 6];
            int num = Information.UBound(Notes);
            for (int i = 1; i <= num; i++)
            {
                Note[] notes = Notes;
                int num3 = -1;
                int columnIndex = notes[i].ColumnIndex;
                num3 = columnIndex != 1 ? columnIndex == 2 ? 1 : columnIndex == 3 ? 2 : columnIndex != 5 && columnIndex != 6 && columnIndex != 7 && columnIndex != 8 && columnIndex != 9 && columnIndex != 10 && columnIndex != 11 && columnIndex != 12 ? columnIndex == 14 || columnIndex == 15 || columnIndex == 16 || columnIndex == 17 || columnIndex == 18 || columnIndex == 19 || columnIndex == 20 || columnIndex == 21 ? 4 : columnIndex < 27 ? 6 : 5 : 3 : 0;
                while (true)
                {
                    if (!NTInput)
                    {
                        int[,] array2;
                        int num6;
                        int num4;
                        if (!notes[i].LongNote)
                        {
                            array2 = array;
                            int[,] array3 = array2;
                            num4 = num3;
                            int num5 = num4;
                            num6 = 0;
                            array3[num5, num6] = array2[num4, num6] + 1;
                        }
                        if (notes[i].LongNote)
                        {
                            array2 = array;
                            int[,] array4 = array2;
                            num6 = num3;
                            int num7 = num6;
                            num4 = 1;
                            array4[num7, num4] = array2[num6, num4] + 1;
                        }
                        if (notes[i].Value / 10000 == LnObj)
                        {
                            array2 = array;
                            int[,] array5 = array2;
                            num6 = num3;
                            int num8 = num6;
                            num4 = 2;
                            array5[num8, num4] = array2[num6, num4] + 1;
                        }
                        if (notes[i].Hidden)
                        {
                            array2 = array;
                            int[,] array6 = array2;
                            num6 = num3;
                            int num9 = num6;
                            num4 = 3;
                            array6[num9, num4] = array2[num6, num4] + 1;
                        }
                        if (notes[i].HasError)
                        {
                            array2 = array;
                            int[,] array7 = array2;
                            num6 = num3;
                            int num10 = num6;
                            num4 = 4;
                            array7[num10, num4] = array2[num6, num4] + 1;
                        }
                        array2 = array;
                        int[,] array8 = array2;
                        num6 = num3;
                        int num11 = num6;
                        num4 = 5;
                        array8[num11, num4] = array2[num6, num4] + 1;
                    }
                    else
                    {
                        int num12 = 1;
                        int[,] array2;
                        int num6;
                        int num4;
                        if (notes[i].Length == 0.0)
                        {
                            array2 = array;
                            int[,] array9 = array2;
                            num6 = num3;
                            int num13 = num6;
                            num4 = 0;
                            array9[num13, num4] = array2[num6, num4] + 1;
                        }
                        if (notes[i].Length != 0.0)
                        {
                            array2 = array;
                            int[,] array10 = array2;
                            num6 = num3;
                            int num14 = num6;
                            num4 = 1;
                            array10[num14, num4] = array2[num6, num4] + 2;
                            num12 = 2;
                        }
                        if (notes[i].Value / 10000 == LnObj)
                        {
                            array2 = array;
                            int[,] array11 = array2;
                            num6 = num3;
                            int num15 = num6;
                            num4 = 2;
                            array11[num15, num4] = array2[num6, num4] + num12;
                        }
                        if (notes[i].Hidden)
                        {
                            array2 = array;
                            int[,] array12 = array2;
                            num6 = num3;
                            int num16 = num6;
                            num4 = 3;
                            array12[num16, num4] = array2[num6, num4] + num12;
                        }
                        if (notes[i].HasError)
                        {
                            array2 = array;
                            int[,] array13 = array2;
                            num6 = num3;
                            int num17 = num6;
                            num4 = 4;
                            array13[num17, num4] = array2[num6, num4] + num12;
                        }
                        array2 = array;
                        int[,] array14 = array2;
                        num6 = num3;
                        int num18 = num6;
                        num4 = 5;
                        array14[num18, num4] = array2[num6, num4] + num12;
                    }
                    if (num3 == 6)
                    {
                        break;
                    }
                    num3 = 6;
                }
            }
            dgStatistics dgStatistics2 = new dgStatistics(array);
            dgStatistics2.ShowDialog();
        }

        private void CalculateTotalPlayableNotes()
        {
            int num = 0;
            if (!NTInput)
            {
                int num2 = Information.UBound(Notes);
                for (int i = 1; i <= num2; i++)
                {
                    if ((Notes[i].ColumnIndex >= 5) & (Notes[i].ColumnIndex <= 12))
                    {
                        num++;
                    }
                }
            }
            else
            {
                int num3 = Information.UBound(Notes);
                for (int i = 1; i <= num3; i++)
                {
                    if ((Notes[i].ColumnIndex >= 5) & (Notes[i].ColumnIndex <= 12))
                    {
                        num++;
                        if (Notes[i].Length != 0.0)
                        {
                            num++;
                        }
                    }
                }
            }
            TBStatistics.Text = Conversions.ToString(num);
        }

        public object GetMouseVPosition(bool snap = true)
        {
            int num = spMain[PanelFocus].Height;
            int num2 = PanelVScroll[PanelFocus];
            float num3 = (num - num2 * gxHeight - MouseMoveStatus.Y - 1f) / gxHeight;
            if (snap)
            {
                return SnapToGrid(num3);
            }
            return num3;
        }

        private void POStatusRefresh()
        {
            if (TBSelect.Checked)
            {
                var kMouseOver = KMouseOver;
                if (kMouseOver < 0)
                {
                    TempVPosition = Conversions.ToDouble(GetMouseVPosition(gSnap));
                    SelectedColumn = GetColumnAtX(MouseMoveStatus.X, PanelHScroll[PanelFocus]);
                    var num = MeasureAtDisplacement(TempVPosition);
                    var num2 = MeasureLength[num];
                    var num3 = TempVPosition - MeasureBottom[num];
                    var num4 = GCD(Conversions.ToDouble(Interaction.IIf(num3 == 0.0, num2, num3)), num2);
                    FSP1.Text = num3 * gDivide / 192.0 + " / " + num2 * gDivide / 192.0 + "  ";
                    FSP2.Text = num3 + " / " + Conversions.ToString(num2) + "  ";
                    FSP3.Text = (int)Math.Round(num3 / num4) + " / " + (int)Math.Round(num2 / num4) + "  ";
                    FSP4.Text = TempVPosition + "  ";
                    TimeStatusLabel.Text = GetTimeFromVPosition(TempVPosition).ToString("F4");
                    FSC.Text = nTitle(SelectedColumn);
                    FSW.Text = "";
                    FSM.Text = Functions.Add3Zeros(num);
                    FST.Text = "";
                    FSH.Text = "";
                    FSE.Text = "";
                }
                else
                {
                    var num5 = MeasureAtDisplacement(Notes[kMouseOver].VPosition);
                    var num6 = MeasureLength[num5];
                    var num7 = Notes[kMouseOver].VPosition - MeasureBottom[num5];
                    var num8 = GCD(Conversions.ToDouble(Interaction.IIf(num7 == 0.0, num6, num7)), num6);
                    FSP1.Text = num7 * gDivide / 192.0 + " / " + num6 * gDivide / 192.0 + "  ";
                    FSP2.Text = num7 + " / " + Conversions.ToString(num6) + "  ";
                    FSP3.Text = (int)Math.Round(num7 / num8) + " / " + (int)Math.Round(num6 / num8) + "  ";
                    FSP4.Text = Notes[kMouseOver].VPosition + "  ";
                    TimeStatusLabel.Text = GetTimeFromVPosition(TempVPosition).ToString("F4");
                    FSC.Text = nTitle(Notes[kMouseOver].ColumnIndex);
                    FSW.Text = Conversions.ToString(Interaction.IIf(IsColumnNumeric(Notes[kMouseOver].ColumnIndex), Notes[kMouseOver].Value / 10000.0, Functions.C10to36(Notes[kMouseOver].Value / 10000)));
                    FSM.Text = Functions.Add3Zeros(num5);
                    FST.Text = Conversions.ToString(Interaction.IIf(NTInput, Strings.StatusBar.Length + " = " + Conversions.ToString(Notes[kMouseOver].Length), RuntimeHelpers.GetObjectValue(Interaction.IIf(Notes[kMouseOver].LongNote, Strings.StatusBar.LongNote, ""))));
                    FSH.Text = Conversions.ToString(Interaction.IIf(Notes[kMouseOver].Hidden, Strings.StatusBar.Hidden, ""));
                    FSE.Text = Conversions.ToString(Interaction.IIf(Notes[kMouseOver].HasError, Strings.StatusBar.Err, ""));
                }
            }
            else if (TBWrite.Checked)
            {
                if (SelectedColumn < 0)
                {
                    return;
                }
                var num9 = MeasureAtDisplacement(TempVPosition);
                var num10 = MeasureLength[num9];
                var num11 = TempVPosition - MeasureBottom[num9];
                var num12 = GCD(Conversions.ToDouble(Interaction.IIf(num11 == 0.0, num10, num11)), num10);
                FSP1.Text = num11 * gDivide / 192.0 + " / " + num10 * gDivide / 192.0 + "  ";
                FSP2.Text = num11 + " / " + Conversions.ToString(num10) + "  ";
                FSP3.Text = (int)Math.Round(num11 / num12) + " / " + (int)Math.Round(num10 / num12) + "  ";
                FSP4.Text = TempVPosition + "  ";
                TimeStatusLabel.Text = GetTimeFromVPosition(TempVPosition).ToString("F4");
                FSC.Text = nTitle(SelectedColumn);
                FSW.Text = Functions.C10to36(LWAV.SelectedIndex + 1);
                FSM.Text = Functions.Add3Zeros(num9);
                FST.Text = Conversions.ToString(Interaction.IIf(NTInput, TempLength, RuntimeHelpers.GetObjectValue(Interaction.IIf(MyProject.Computer.Keyboard.ShiftKeyDown, Strings.StatusBar.LongNote, ""))));
                FSH.Text = Conversions.ToString(Interaction.IIf(MyProject.Computer.Keyboard.CtrlKeyDown, Strings.StatusBar.Hidden, ""));
            }
            else if (TBTimeSelect.Checked)
            {
                FSSS.Text = Conversions.ToString(vSelStart);
                FSSL.Text = Conversions.ToString(vSelLength);
                FSSH.Text = Conversions.ToString(vSelHalf);
            }
            FStatus.Invalidate();
        }

        private double GetTimeFromVPosition(double vpos)
        {
            var dictionary = Notes.Where(note => (note.ColumnIndex == 2) | (note.ColumnIndex == 3))
                .GroupBy(note => note.ColumnIndex,
                    (Column, NoteGroups) => new
                    {
                        Column,
                        NoteGroups
                    })
                .ToDictionary(x => x.Column, x => x.NoteGroups);
            //Dictionary<int, IEnumerable<Note>> dictionary = Notes
            //    .Where([SpecialName](Note note) => (note.ColumnIndex == 2) | (note.ColumnIndex == 3))
            //    .GroupBy([SpecialName](Note note) => note.ColumnIndex,
            //        [SpecialName](int Column, IEnumerable<Note> _0024VB_0024Group) =>
            //            new VB_0024AnonymousType_0<int, IEnumerable<Note>>(Column, _0024VB_0024Group)).ToDictionary(
            //        [SpecialName](VB_0024AnonymousType_0<int, IEnumerable<Note>> x) => x.Column,
            //        [SpecialName](VB_0024AnonymousType_0<int, IEnumerable<Note>> x) => x.NoteGroups);
            IEnumerable<Note> bpm_notes = dictionary[2];
            IEnumerable<Note> stop_notes = null;
            if (dictionary.ContainsKey(3))
            {
                stop_notes = dictionary[3];
            }
            int num = bpm_notes.Count() - 1;
            //_Closure_0024__1 closure_0024__ = default(_Closure_0024__1);
            double bpm_contrib = default(double);
            double stop_contrib = default(double);
            for (int i = 0; i <= num; i++)
            {
                //closure_0024__ = new _Closure_0024__1(closure_0024__);
                double duration = 0.0d;
                //closure_0024__._0024VB_0024Local_duration = 0.0;
                Note current_note = bpm_notes.ElementAt(i);
                //closure_0024__._0024VB_0024Local_notevpos = Math.Max(0.0, current_note.VPosition);
                double notevpos = Math.Max(0d, current_note.VPosition);
                if (i + 1 != bpm_notes.Count())
                {
                    var next_note = bpm_notes.ElementAt(i + 1);
                    duration = next_note.VPosition - notevpos;
                    //closure_0024__._0024VB_0024Local_duration = bpm_notes.ElementAt(i + 1).VPosition - closure_0024__._0024VB_0024Local_notevpos;
                }
                else
                {
                    duration = vpos - notevpos;
                    //closure_0024__._0024VB_0024Local_duration = vpos - closure_0024__._0024VB_0024Local_notevpos;
                }
                double current_bps = 60.0 / (current_note.Value / 10000.0);
                //bpm_contrib += current_bps * closure_0024__._0024VB_0024Local_duration / 48.0;
                bpm_contrib += current_bps * duration / 48d;
                if (stop_notes != null)
                {
                    var stops = from stp in stop_notes
                                where stp.VPosition >= notevpos & stp.VPosition < notevpos + duration
                                select stp;
                    //IEnumerable<Note> stops = enumerable.Where(closure_0024__._Lambda_0024__8);
                    double stop_beats = stops.Sum([SpecialName] (Note x) => x.Value / 10000.0) / 48.0;
                    stop_contrib += current_bps * stop_beats;
                }
            }
            return stop_contrib + bpm_contrib;
        }

        private void POBStorm_Click(object sender, EventArgs e)
        {
        }

        private void POBMirror_Click(object sender, EventArgs e)
        {
            //Discarded unreachable code: IL_008f
            UndoRedo.LinkedURCmd BaseUndo = null;
            UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
            UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
            int num = 0;
            int num2 = Information.UBound(Notes);
            for (int i = 1; i <= num2; i += 1)
            {
                if (Notes[i].Selected)
                {
                    switch (Notes[i].ColumnIndex)
                    {
                        case 5:
                            num = 11;
                            break;
                        case 6:
                            num = 10;
                            break;
                        case 7:
                            num = 9;
                            break;
                        case 8:
                            num = 8;
                            break;
                        case 9:
                            num = 7;
                            break;
                        case 10:
                            num = 6;
                            break;
                        case 11:
                            num = 5;
                            break;
                        default:
                            continue;
                    }
                    RedoMoveNote(Notes[i], num, Notes[i].VPosition, ref BaseUndo, ref BaseRedo);
                    Notes[i].ColumnIndex = num;
                }
            }
            AddUndo(BaseUndo, linkedURCmd.Next);
            UpdatePairing();
            RefreshPanelAll();
        }

        private void ValidateSelection()
        {
            if (vSelStart < 0.0)
            {
                vSelLength += vSelStart;
                vSelHalf += vSelStart;
                vSelStart = 0.0;
            }
            if (vSelStart > GetMaxVPosition() - 1.0)
            {
                vSelLength += vSelStart - GetMaxVPosition() + 1.0;
                vSelHalf += vSelStart - GetMaxVPosition() + 1.0;
                vSelStart = GetMaxVPosition() - 1.0;
            }
            if (vSelStart + vSelLength < 0.0)
            {
                vSelLength = 0.0 - vSelStart;
            }
            if (vSelStart + vSelLength > GetMaxVPosition() - 1.0)
            {
                vSelLength = GetMaxVPosition() - 1.0 - vSelStart;
            }
            if (Math.Sign(vSelHalf) != Math.Sign(vSelLength))
            {
                vSelHalf = 0.0;
            }
            if (Math.Abs(vSelHalf) > Math.Abs(vSelLength))
            {
                vSelHalf = vSelLength;
            }
        }

        private void TVCM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                TVCM.Text = Conversions.ToString(Conversion.Val(TVCM.Text));
                if (Conversion.Val(TVCM.Text) <= 0.0)
                {
                    Interaction.MsgBox(Strings.Messages.NegativeFactorError, MsgBoxStyle.Critical, Strings.Messages.Err);
                    TVCM.Text = Conversions.ToString(1);
                    TVCM.Focus();
                    TVCM.SelectAll();
                }
                else
                {
                    BVCApply_Click(BVCApply, new EventArgs());
                }
            }
        }

        private void TVCM_LostFocus(object sender, EventArgs e)
        {
            TVCM.Text = Conversions.ToString(Conversion.Val(TVCM.Text));
            if (Conversion.Val(TVCM.Text) <= 0.0)
            {
                Interaction.MsgBox(Strings.Messages.NegativeFactorError, MsgBoxStyle.Critical, Strings.Messages.Err);
                TVCM.Text = Conversions.ToString(1);
                TVCM.Focus();
                TVCM.SelectAll();
            }
        }

        private void TVCD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                TVCD.Text = Conversions.ToString(Conversion.Val(TVCD.Text));
                if (Conversion.Val(TVCD.Text) <= 0.0)
                {
                    Interaction.MsgBox(Strings.Messages.NegativeDivisorError, MsgBoxStyle.Critical, Strings.Messages.Err);
                    TVCD.Text = Conversions.ToString(1);
                    TVCD.Focus();
                    TVCD.SelectAll();
                }
                else
                {
                    BVCApply_Click(BVCApply, new EventArgs());
                }
            }
        }

        private void TVCD_LostFocus(object sender, EventArgs e)
        {
            TVCD.Text = Conversions.ToString(Conversion.Val(TVCD.Text));
            if (Conversion.Val(TVCD.Text) <= 0.0)
            {
                Interaction.MsgBox(Strings.Messages.NegativeDivisorError, MsgBoxStyle.Critical, Strings.Messages.Err);
                TVCD.Text = Conversions.ToString(1);
                TVCD.Focus();
                TVCD.SelectAll();
            }
        }

        private void TVCBPM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                TVCBPM.Text = Conversions.ToString(Conversion.Val(TVCBPM.Text));
                if (Conversion.Val(TVCBPM.Text) <= 0.0)
                {
                    Interaction.MsgBox(Strings.Messages.NegativeDivisorError, MsgBoxStyle.Critical, Strings.Messages.Err);
                    TVCBPM.Text = Conversions.ToString(Notes[0].Value / 10000.0);
                    TVCBPM.Focus();
                    TVCBPM.SelectAll();
                }
                else
                {
                    BVCCalculate_Click(BVCCalculate, new EventArgs());
                }
            }
        }

        private void TVCBPM_LostFocus(object sender, EventArgs e)
        {
            TVCBPM.Text = Conversions.ToString(Conversion.Val(TVCBPM.Text));
            if (Conversion.Val(TVCBPM.Text) <= 0.0)
            {
                Interaction.MsgBox(Strings.Messages.NegativeDivisorError, MsgBoxStyle.Critical, Strings.Messages.Err);
                TVCBPM.Text = Conversions.ToString(Notes[0].Value / 10000.0);
                TVCBPM.Focus();
                TVCBPM.SelectAll();
            }
        }

        private int FindNoteIndex(Note note)
        {
            int i;
            if (NTInput)
            {
                int num = Information.UBound(Notes);
                for (i = 1; i <= num; i++)
                {
                    if (Notes[i].equalsNT(note))
                    {
                        return i;
                    }
                }
            }
            else
            {
                int num2 = Information.UBound(Notes);
                for (i = 1; i <= num2; i++)
                {
                    if (Notes[i].equalsBMSE(note))
                    {
                        return i;
                    }
                }
            }
            return i;
        }

        private int sIA()
        {
            return Conversions.ToInteger(Interaction.IIf(sI > 98, 0, sI + 1));
        }

        private int sIM()
        {
            return Conversions.ToInteger(Interaction.IIf(sI < 1, 99, sI - 1));
        }

        private void TBUndo_Click(object sender, EventArgs e)
        {
            KMouseOver = -1;
            SelectedNotes = Array.Empty<Note>();
            if (sUndo[sI].ofType() != byte.MaxValue)
            {
                PerformCommand(sUndo[sI]);
                sI = sIM();
                TBUndo.Enabled = sUndo[sI].ofType() != byte.MaxValue;
                TBRedo.Enabled = sRedo[sIA()].ofType() != byte.MaxValue;
                mnUndo.Enabled = sUndo[sI].ofType() != byte.MaxValue;
                mnRedo.Enabled = sRedo[sIA()].ofType() != byte.MaxValue;
            }
        }

        private void TBRedo_Click(object sender, EventArgs e)
        {
            KMouseOver = -1;
            SelectedNotes = Array.Empty<Note>();
            if (sRedo[sIA()].ofType() != byte.MaxValue)
            {
                PerformCommand(sRedo[sIA()]);
                sI = sIA();
                TBUndo.Enabled = sUndo[sI].ofType() != byte.MaxValue;
                TBRedo.Enabled = sRedo[sIA()].ofType() != byte.MaxValue;
                mnUndo.Enabled = sUndo[sI].ofType() != byte.MaxValue;
                mnRedo.Enabled = sRedo[sIA()].ofType() != byte.MaxValue;
            }
        }

        private void TBAbout_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.bBitmap = Resources.About0;
            Size clientSize = new Size(1000, 500);
            aboutBox.ClientSize = clientSize;
            aboutBox.ClickToCopy.Visible = true;
            aboutBox.ShowDialog(this);
        }

        private void TBOptions_Click(object sender, EventArgs e)
        {
            OpVisual opVisual = new OpVisual(vo, column, LWAV.Font);
            opVisual.ShowDialog(this);
            UpdateColumnsX();
            RefreshPanelAll();
        }

        private void AddToPOWAV(string[] xPath)
        {
            int[] array = new int[LWAV.SelectedIndices.Count - 1 + 1];
            LWAV.SelectedIndices.CopyTo(array, 0);
            if (array.Length == 0)
            {
                return;
            }
            if (array.Length < xPath.Length)
            {
                int i = array.Length;
                int j = array[Information.UBound(array)] + 1;
                for (array = (int[])Utils.CopyArray(array, new int[Information.UBound(xPath) + 1]); i < array.Length && j <= 1294; i++)
                {
                    for (; j <= 1294 && Operators.CompareString(hWAV[j + 1], "", TextCompare: false) != 0; j++)
                    {
                    }
                    if (j > 1294)
                    {
                        break;
                    }
                    array[i] = j;
                    j++;
                }
                if (j > 1294)
                {
                    xPath = (string[])Utils.CopyArray(xPath, new string[i - 1 + 1]);
                    array = (int[])Utils.CopyArray(array, new int[i - 1 + 1]);
                }
            }
            int num = Information.UBound(xPath);
            for (int k = 0; k <= num; k++)
            {
                hWAV[array[k] + 1] = GetFileName(xPath[k]);
                LWAV.Items[array[k]] = Functions.C10to36(array[k] + 1) + ": " + GetFileName(xPath[k]);
            }
            LWAV.SelectedIndices.Clear();
            int num2 = Conversions.ToInteger(Interaction.IIf(Information.UBound(array) < Information.UBound(xPath), Information.UBound(array), Information.UBound(xPath)));
            for (int l = 0; l <= num2; l++)
            {
                LWAV.SelectedIndices.Add(array[l]);
            }
            if (IsSaved)
            {
                SetIsSaved(isSaved: false);
            }
            RefreshPanelAll();
        }

        private void POWAV_DragDrop(object sender, DragEventArgs e)
        {
            DDFileName = Array.Empty<string>();
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] xFile = (string[])e.Data.GetData(DataFormats.FileDrop);
                string[] array = FilterFileBySupported(xFile, SupportedAudioExtension);
                Array.Sort(array);
                if (array.Length == 0)
                {
                    RefreshPanelAll();
                }
                else
                {
                    AddToPOWAV(array);
                }
            }
        }

        private void POWAV_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                DDFileName = FilterFileBySupported((string[])e.Data.GetData(DataFormats.FileDrop), SupportedAudioExtension);
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
            RefreshPanelAll();
        }

        private void POWAV_DragLeave(object sender, EventArgs e)
        {
            DDFileName = Array.Empty<string>();
            RefreshPanelAll();
        }

        private void POWAV_Resize(object sender, EventArgs e)
        {
            LWAV.Height = Conversions.ToInteger(Operators.SubtractObject(NewLateBinding.LateGet(sender, null, "Height", Array.Empty<object>(), null, null, null), 25));
        }

        private void POBeat_Resize(object sender, EventArgs e)
        {
            LBeat.Height = POBeat.Height - 25;
        }

        private void POExpansion_Resize(object sender, EventArgs e)
        {
            TExpansion.Height = POExpansion.Height - 2;
        }

        private void mn_DropDownClosed(object sender, EventArgs e)
        {
            NewLateBinding.LateSet(sender, null, "ForeColor", new object[1] { Color.White }, null, null);
        }

        private void mn_DropDownOpened(object sender, EventArgs e)
        {
            NewLateBinding.LateSet(sender, null, "ForeColor", new object[1] { Color.Black }, null, null);
        }

        private void mn_MouseEnter(object sender, EventArgs e)
        {
            if (!Conversions.ToBoolean(NewLateBinding.LateGet(sender, null, "Pressed", Array.Empty<object>(), null, null, null)))
            {
                NewLateBinding.LateSet(sender, null, "ForeColor", new object[1] { Color.Black }, null, null);
            }
        }

        private void mn_MouseLeave(object sender, EventArgs e)
        {
            if (!Conversions.ToBoolean(NewLateBinding.LateGet(sender, null, "Pressed", Array.Empty<object>(), null, null, null)))
            {
                NewLateBinding.LateSet(sender, null, "ForeColor", new object[1] { Color.White }, null, null);
            }
        }

        private void TBPOptions_Click(object sender, EventArgs e)
        {
            OpPlayer opPlayer = new OpPlayer(CurrentPlayer);
            opPlayer.ShowDialog(this);
        }

        private void THGenre_TextChanged(object sender, EventArgs e)
        {
            if (IsSaved)
            {
                SetIsSaved(isSaved: false);
            }
        }

        private void CHLnObj_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsSaved)
            {
                SetIsSaved(isSaved: false);
            }
            LnObj = CHLnObj.SelectedIndex;
            UpdatePairing();
            RefreshPanelAll();
        }

        private void ConvertBMSE2NT()
        {
            SelectedNotes = Array.Empty<Note>();
            SortByVPositionInsertion();
            int num = Information.UBound(Notes);
            for (int i = 0; i <= num; i++)
            {
                Notes[i].Length = 0.0;
            }
            int num2 = 1;
            int num3 = 0;
            int num4 = Information.UBound(Notes);
            while (num2 <= num4)
            {
                if (!Notes[num2].LongNote)
                {
                    num2++;
                    continue;
                }
                int num5 = num2 + 1;
                int num6 = num4;
                for (num3 = num5; num3 <= num6; num3++)
                {
                    if (Notes[num3].ColumnIndex != Notes[num2].ColumnIndex)
                    {
                        continue;
                    }
                    if (Notes[num3].LongNote)
                    {
                        Notes[num2].Length = Notes[num3].VPosition - Notes[num2].VPosition;
                        int num8 = num4 - 1;
                        for (int j = num3; j <= num8; j++)
                        {
                            ref Note reference = ref Notes[j];
                            reference = Notes[j + 1];
                        }
                        num4--;
                        break;
                    }
                    if (Notes[num3].Value / 10000 == LnObj)
                    {
                        break;
                    }
                }
                num2++;
            }
            Notes = (Note[])Utils.CopyArray(Notes, new Note[num4 + 1]);
            int num9 = num4;
            for (num2 = 0; num2 <= num9; num2++)
            {
                Notes[num2].LongNote = false;
            }
            SortByVPositionInsertion();
            UpdatePairing();
            CalculateTotalPlayableNotes();
        }

        private void ConvertNT2BMSE()
        {
            SelectedNotes = Array.Empty<Note>();
            Note[] array = new Note[1] { Notes[0] };
            int num = Information.UBound(Notes);
            for (int i = 1; i <= num; i++)
            {
                array = (Note[])Utils.CopyArray(array, new Note[Information.UBound(array) + 1 + 1]);
                Note[] array2 = array;
                int num2 = Information.UBound(array);
                array2[num2].ColumnIndex = Notes[i].ColumnIndex;
                array2[num2].LongNote = Notes[i].Length > 0.0;
                array2[num2].Landmine = Notes[i].Landmine;
                array2[num2].Value = Notes[i].Value;
                array2[num2].VPosition = Notes[i].VPosition;
                array2[num2].Selected = Notes[i].Selected;
                array2[num2].Hidden = Notes[i].Hidden;
                if (Notes[i].Length > 0.0)
                {
                    array = (Note[])Utils.CopyArray(array, new Note[Information.UBound(array) + 1 + 1]);
                    Note[] array3 = array;
                    int num3 = Information.UBound(array);
                    array3[num3].ColumnIndex = Notes[i].ColumnIndex;
                    array3[num3].LongNote = true;
                    array3[num3].Landmine = false;
                    array3[num3].Value = Notes[i].Value;
                    array3[num3].VPosition = Notes[i].VPosition + Notes[i].Length;
                    array3[num3].Selected = Notes[i].Selected;
                    array3[num3].Hidden = Notes[i].Hidden;
                }
            }
            Notes = array;
            SortByVPositionInsertion();
            UpdatePairing();
            CalculateTotalPlayableNotes();
        }

        private void TBWavIncrease_Click(object sender, EventArgs e)
        {
            UndoRedo.LinkedURCmd BaseUndo = null;
            UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
            UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
            TBWavIncrease.Checked = Conversions.ToBoolean(Operators.NotObject(NewLateBinding.LateGet(sender, null, "Checked", Array.Empty<object>(), null, null, null)));
            RedoWavIncrease(TBWavIncrease.Checked, ref BaseUndo, ref BaseRedo);
            AddUndo(BaseUndo, linkedURCmd.Next);
        }

        private void TBNTInput_Click(object sender, EventArgs e)
        {
            UndoRedo.LinkedURCmd BaseUndo = null;
            UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
            UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
            RedoRemoveNoteAll(xSel: false, ref BaseUndo, ref BaseRedo);
            NTInput = Conversions.ToBoolean(NewLateBinding.LateGet(sender, null, "Checked", Array.Empty<object>(), null, null, null));
            TBNTInput.Checked = NTInput;
            mnNTInput.Checked = NTInput;
            POBLong.Enabled = !NTInput;
            POBLongShort.Enabled = !NTInput;
            bAdjustLength = false;
            bAdjustUpper = false;
            RedoNT(NTInput, autoConvert: false, ref BaseUndo, ref BaseRedo);
            if (NTInput)
            {
                ConvertBMSE2NT();
            }
            else
            {
                ConvertNT2BMSE();
            }
            RedoAddNoteAll(xSel: false, ref BaseUndo, ref BaseRedo);
            AddUndo(BaseUndo, linkedURCmd.Next);
            RefreshPanelAll();
        }

        private void THBPM_ValueChanged(object sender, EventArgs e)
        {
            if (Notes != null)
            {
                Notes[0].Value = Convert.ToInt64(decimal.Multiply(THBPM.Value, 10000m));
                RefreshPanelAll();
            }
            if (IsSaved)
            {
                SetIsSaved(isSaved: false);
            }
        }

        private void TWPosition_ValueChanged(object sender, EventArgs e)
        {
            wPosition = Convert.ToDouble(TWPosition.Value);
            TWPosition2.Value = Conversions.ToInteger(Interaction.IIf(wPosition > TWPosition2.Maximum, TWPosition2.Maximum, wPosition));
            RefreshPanelAll();
        }

        private void TWLeft_ValueChanged(object sender, EventArgs e)
        {
            wLeft = Convert.ToInt32(TWLeft.Value);
            TWLeft2.Value = Conversions.ToInteger(Interaction.IIf(wLeft > TWLeft2.Maximum, TWLeft2.Maximum, wLeft));
            RefreshPanelAll();
        }

        private void TWWidth_ValueChanged(object sender, EventArgs e)
        {
            wWidth = Convert.ToInt32(TWWidth.Value);
            TWWidth2.Value = Conversions.ToInteger(Interaction.IIf(wWidth > TWWidth2.Maximum, TWWidth2.Maximum, wWidth));
            RefreshPanelAll();
        }

        private void TWPrecision_ValueChanged(object sender, EventArgs e)
        {
            wPrecision = Convert.ToInt32(TWPrecision.Value);
            TWPrecision2.Value = Conversions.ToInteger(Interaction.IIf(wPrecision > TWPrecision2.Maximum, TWPrecision2.Maximum, wPrecision));
            RefreshPanelAll();
        }

        private void TWTransparency_ValueChanged(object sender, EventArgs e)
        {
            TWTransparency2.Value = Convert.ToInt32(TWTransparency.Value);
            vo.pBGMWav.Color = Color.FromArgb(Convert.ToInt32(TWTransparency.Value), vo.pBGMWav.Color);
            RefreshPanelAll();
        }

        private void TWSaturation_ValueChanged(object sender, EventArgs e)
        {
            Color color = vo.pBGMWav.Color;
            TWSaturation2.Value = Convert.ToInt32(TWSaturation.Value);
            vo.pBGMWav.Color = Functions.HSL2RGB((int)Math.Round(color.GetHue()), Convert.ToInt32(TWSaturation.Value), (int)Math.Round(color.GetBrightness() * 1000f), color.A);
            RefreshPanelAll();
        }

        private void TWPosition2_Scroll(object sender, EventArgs e)
        {
            TWPosition.Value = new decimal(TWPosition2.Value);
        }

        private void TWLeft2_Scroll(object sender, EventArgs e)
        {
            TWLeft.Value = new decimal(TWLeft2.Value);
        }

        private void TWWidth2_Scroll(object sender, EventArgs e)
        {
            TWWidth.Value = new decimal(TWWidth2.Value);
        }

        private void TWPrecision2_Scroll(object sender, EventArgs e)
        {
            TWPrecision.Value = new decimal(TWPrecision2.Value);
        }

        private void TWTransparency2_Scroll(object sender, EventArgs e)
        {
            TWTransparency.Value = new decimal(TWTransparency2.Value);
        }

        private void TWSaturation2_Scroll(object sender, EventArgs e)
        {
            TWSaturation.Value = new decimal(TWSaturation2.Value);
        }

        private void TBLangDef_Click(object sender, EventArgs e)
        {
            DispLang = "";
            Interaction.MsgBox(Strings.Messages.PreferencePostpone, MsgBoxStyle.Information);
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private void TBLangRefresh_Click(object sender, EventArgs e)
        {
            for (int i = cmnLanguage.Items.Count - 1; i >= 3; i += -1)
            {
                try
                {
                    cmnLanguage.Items.RemoveAt(i);
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    Exception ex2 = ex;
                    ProjectData.ClearProjectError();
                }
            }
            if (!Directory.Exists(MyProject.Application.Info.DirectoryPath + "\\Data"))
            {
                MyProject.Computer.FileSystem.CreateDirectory(MyProject.Application.Info.DirectoryPath + "\\Data");
            }
            FileInfo[] files = MyProject.Computer.FileSystem.GetDirectoryInfo(MyProject.Application.Info.DirectoryPath + "\\Data").GetFiles("*.Lang.xml");
            foreach (FileInfo xStr in files)
            {
                LoadLocaleXML(xStr);
            }
        }

        private void UpdateColumnsX()
        {
            column[0].Left = 0;
            int num = Information.UBound(column);
            for (int i = 1; i <= num; i++)
            {
                column[i].Left = Conversions.ToInteger(Operators.AddObject(column[i - 1].Left, Interaction.IIf(column[i - 1].isVisible, column[i - 1].Width, 0)));
            }
            HSL.Maximum = nLeft(gColumns) + column[27].Width;
            HS.Maximum = nLeft(gColumns) + column[27].Width;
            HSR.Maximum = nLeft(gColumns) + column[27].Width;
        }

        private void CHPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CHPlayer.SelectedIndex == -1)
            {
                CHPlayer.SelectedIndex = 0;
            }
            iPlayer = CHPlayer.SelectedIndex;
            bool isVisible = iPlayer != 0;
            column[14].isVisible = isVisible;
            column[15].isVisible = isVisible;
            column[16].isVisible = isVisible;
            column[17].isVisible = isVisible;
            column[18].isVisible = isVisible;
            column[19].isVisible = isVisible;
            column[20].isVisible = isVisible;
            column[21].isVisible = isVisible;
            column[22].isVisible = isVisible;
            int num = Information.UBound(Notes);
            for (int i = 1; i <= num; i += 1)
            {
                Notes[i].Selected &= nEnabled(Notes[i].ColumnIndex);
            }
            UpdateColumnsX();
            if (!IsInitializing)
            {
                RefreshPanelAll();
            }
        }

        private void CGB_ValueChanged(object sender, EventArgs e)
        {
            gColumns = Convert.ToInt32(decimal.Subtract(decimal.Add(27m, CGB.Value), 1m));
            UpdateColumnsX();
            RefreshPanelAll();
        }

        private void TBGOptions_Click(object sender, EventArgs e)
        {
            OpGeneral opGeneral = new OpGeneral(xTextEncoding: Microsoft.VisualBasic.Strings.UCase(Functions.EncodingToString(TextEncoding)) switch
            {
                "SYSTEM ANSI" => 0,
                "LITTLE ENDIAN UTF16" => 1,
                "ASCII" => 2,
                "BIG ENDIAN UTF16" => 3,
                "LITTLE ENDIAN UTF32" => 4,
                "UTF7" => 5,
                "UTF8" => 6,
                "SJIS" => 7,
                "EUC-KR" => 8,
                _ => 0,
            }, xMsWheel: gWheel, xPgUpDn: gPgUpDn, xMiddleButton: MiddleButtonMoveMethod, xGridPartition: (int)Math.Round(192.0 / BMSGridLimit), xAutoSave: AutoSaveInterval, xBeep: BeepWhileSaved, xBPMx: BPMx1296, xSTOPx: STOPx1296, xMFEnter: AutoFocusMouseEnter, xMFClick: FirstClickDisabled, xMStopPreview: ClickStopPreview);
            if (opGeneral.ShowDialog() == DialogResult.OK)
            {
                OpGeneral opGeneral2 = opGeneral;
                gWheel = opGeneral2.zWheel;
                gPgUpDn = opGeneral2.zPgUpDn;
                TextEncoding = opGeneral2.zEncoding;
                MiddleButtonMoveMethod = opGeneral2.zMiddle;
                AutoSaveInterval = opGeneral2.zAutoSave;
                BMSGridLimit = 192.0 / opGeneral2.zGridPartition;
                BeepWhileSaved = opGeneral2.cBeep.Checked;
                BPMx1296 = opGeneral2.cBpm1296.Checked;
                STOPx1296 = opGeneral2.cStop1296.Checked;
                AutoFocusMouseEnter = opGeneral2.cMEnterFocus.Checked;
                FirstClickDisabled = opGeneral2.cMClickFocus.Checked;
                ClickStopPreview = opGeneral2.cMStopPreview.Checked;
                opGeneral2 = null;
                if (AutoSaveInterval != 0)
                {
                    AutoSaveTimer.Interval = AutoSaveInterval;
                }
                AutoSaveTimer.Enabled = AutoSaveInterval != 0;
            }
        }

        private void POBLong_Click(object sender, EventArgs e)
        {
            if (NTInput)
            {
                return;
            }
            UndoRedo.LinkedURCmd BaseUndo = null;
            UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
            UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
            int num = Information.UBound(Notes);
            for (int i = 1; i <= num; i += 1)
            {
                if (Notes[i].Selected)
                {
                    RedoLongNoteModify(Notes[i], Notes[i].VPosition, -1.0, ref BaseUndo, ref BaseRedo);
                    Notes[i].LongNote = true;
                }
            }
            AddUndo(BaseUndo, linkedURCmd.Next);
            SortByVPositionInsertion();
            UpdatePairing();
            RefreshPanelAll();
        }

        private void POBNormal_Click(object sender, EventArgs e)
        {
            UndoRedo.LinkedURCmd BaseUndo = null;
            UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
            UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
            if (!NTInput)
            {
                int num = Information.UBound(Notes);
                for (int i = 1; i <= num; i++)
                {
                    if (Notes[i].Selected)
                    {
                        RedoLongNoteModify(Notes[i], Notes[i].VPosition, 0.0, ref BaseUndo, ref BaseRedo);
                        Notes[i].LongNote = false;
                    }
                }
            }
            else
            {
                int num2 = Information.UBound(Notes);
                for (int j = 1; j <= num2; j++)
                {
                    if (Notes[j].Selected)
                    {
                        RedoLongNoteModify(Notes[j], Notes[j].VPosition, 0.0, ref BaseUndo, ref BaseRedo);
                        Notes[j].Length = 0.0;
                    }
                }
            }
            AddUndo(BaseUndo, linkedURCmd.Next);
            SortByVPositionInsertion();
            UpdatePairing();
            RefreshPanelAll();
        }

        private void POBNormalLong_Click(object sender, EventArgs e)
        {
            if (NTInput)
            {
                return;
            }
            UndoRedo.LinkedURCmd BaseUndo = null;
            UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
            UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
            int num = Information.UBound(Notes);
            for (int i = 1; i <= num; i += 1)
            {
                if (Notes[i].Selected)
                {
                    RedoLongNoteModify(Notes[i], Notes[i].VPosition, 0 - (!Notes[i].LongNote ? 1 : 0), ref BaseUndo, ref BaseRedo);
                    Notes[i].LongNote = !Notes[i].LongNote;
                }
            }
            AddUndo(BaseUndo, linkedURCmd.Next);
            SortByVPositionInsertion();
            UpdatePairing();
            RefreshPanelAll();
        }

        private void POBHidden_Click(object sender, EventArgs e)
        {
            UndoRedo.LinkedURCmd BaseUndo = null;
            UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
            UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
            int num = Information.UBound(Notes);
            for (int i = 1; i <= num; i += 1)
            {
                if (Notes[i].Selected)
                {
                    RedoHiddenNoteModify(Notes[i], nHide: true, xSel: true, ref BaseUndo, ref BaseRedo);
                    Notes[i].Hidden = true;
                }
            }
            AddUndo(BaseUndo, linkedURCmd.Next);
            SortByVPositionInsertion();
            UpdatePairing();
            RefreshPanelAll();
        }

        private void POBVisible_Click(object sender, EventArgs e)
        {
            UndoRedo.LinkedURCmd BaseUndo = null;
            UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
            UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
            int num = Information.UBound(Notes);
            for (int i = 1; i <= num; i += 1)
            {
                if (Notes[i].Selected)
                {
                    RedoHiddenNoteModify(Notes[i], nHide: false, xSel: true, ref BaseUndo, ref BaseRedo);
                    Notes[i].Hidden = false;
                }
            }
            AddUndo(BaseUndo, linkedURCmd.Next);
            SortByVPositionInsertion();
            UpdatePairing();
            RefreshPanelAll();
        }

        private void POBHiddenVisible_Click(object sender, EventArgs e)
        {
            UndoRedo.LinkedURCmd BaseUndo = null;
            UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
            UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
            int num = Information.UBound(Notes);
            for (int i = 1; i <= num; i += 1)
            {
                if (Notes[i].Selected)
                {
                    RedoHiddenNoteModify(Notes[i], !Notes[i].Hidden, xSel: true, ref BaseUndo, ref BaseRedo);
                    Notes[i].Hidden = !Notes[i].Hidden;
                }
            }
            AddUndo(BaseUndo, linkedURCmd.Next);
            SortByVPositionInsertion();
            UpdatePairing();
            RefreshPanelAll();
        }

        private void POBModify_Click(object sender, EventArgs e)
        {
            bool flag = false;
            bool flag2 = false;
            int num = Information.UBound(Notes);
            for (int i = 1; i <= num; i++)
            {
                if (Notes[i].Selected && IsColumnNumeric(Notes[i].ColumnIndex))
                {
                    flag = true;
                    break;
                }
            }
            int num2 = Information.UBound(Notes);
            for (int i = 1; i <= num2; i++)
            {
                if (Notes[i].Selected && !IsColumnNumeric(Notes[i].ColumnIndex))
                {
                    flag2 = true;
                    break;
                }
            }
            if (!(flag || flag2))
            {
                return;
            }
            if (flag)
            {
                double num3 = Conversion.Val(Interaction.InputBox(Strings.Messages.PromptEnterNumeric, Text)) * 10000.0;
                if (num3 != 0.0)
                {
                    if (num3 <= 0.0)
                    {
                        num3 = 1.0;
                    }
                    UndoRedo.LinkedURCmd BaseUndo = null;
                    UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
                    UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
                    int num4 = Information.UBound(Notes);
                    for (int i = 1; i <= num4; i++)
                    {
                        if (IsColumnNumeric(Notes[i].ColumnIndex) && Notes[i].Selected)
                        {
                            RedoRelabelNote(Notes[i], (long)Math.Round(num3), ref BaseUndo, ref BaseRedo);
                            Notes[i].Value = (long)Math.Round(num3);
                        }
                    }
                    AddUndo(BaseUndo, linkedURCmd.Next);
                }
            }
            if (flag2)
            {
                string text = Microsoft.VisualBasic.Strings.UCase(Microsoft.VisualBasic.Strings.Trim(Interaction.InputBox(Strings.Messages.PromptEnter, Text)));
                if (Microsoft.VisualBasic.Strings.Len(text) != 0)
                {
                    if (!((Operators.CompareString(text, "00", TextCompare: false) == 0) | (Operators.CompareString(text, "0", TextCompare: false) == 0)) && !((Microsoft.VisualBasic.Strings.Len(text) != 1) & (Microsoft.VisualBasic.Strings.Len(text) != 2)))
                    {
                        int num5 = Microsoft.VisualBasic.Strings.Asc(Microsoft.VisualBasic.Strings.Mid(text, 1, 1));
                        if ((num5 >= 48 && num5 <= 57) || (num5 >= 65 && num5 <= 90))
                        {
                            if (Microsoft.VisualBasic.Strings.Len(text) == 2)
                            {
                                int num6 = Microsoft.VisualBasic.Strings.Asc(Microsoft.VisualBasic.Strings.Mid(text, 2, 1));
                                if (!((num6 >= 48 && num6 <= 57) || (num6 >= 65 && num6 <= 90)))
                                {
                                    goto IL_0347;
                                }
                            }
                            int num7 = Functions.C36to10(text) * 10000;
                            UndoRedo.LinkedURCmd BaseUndo2 = null;
                            UndoRedo.LinkedURCmd BaseRedo2 = new UndoRedo.Void();
                            UndoRedo.LinkedURCmd linkedURCmd2 = BaseRedo2;
                            int num8 = Information.UBound(Notes);
                            for (int i = 1; i <= num8; i++)
                            {
                                if (!IsColumnNumeric(Notes[i].ColumnIndex) && Notes[i].Selected)
                                {
                                    RedoRelabelNote(Notes[i], num7, ref BaseUndo2, ref BaseRedo2);
                                    Notes[i].Value = num7;
                                }
                            }
                            AddUndo(BaseUndo2, linkedURCmd2.Next);
                            goto IL_0359;
                        }
                    }
                    goto IL_0347;
                }
            }
            goto IL_0359;
IL_0359:
            RefreshPanelAll();
            return;
IL_0347:
            Interaction.MsgBox(Strings.Messages.InvalidLabel, MsgBoxStyle.Critical, Strings.Messages.Err);
            goto IL_0359;
        }

        private void TBMyO2_Click(object sender, EventArgs e)
        {
            dgMyO2 dgMyO3 = new dgMyO2();
            dgMyO3.Show();
        }

        private void TBFind_Click(object sender, EventArgs e)
        {
            diagFind diagFind2 = new diagFind(gColumns, Strings.Messages.Err, Strings.Messages.InvalidLabel);
            diagFind2.Show();
        }

        private bool fdrCheck(Note xNote)
        {
            return Conversions.ToBoolean(!Conversions.ToBoolean((xNote.VPosition >= MeasureBottom[fdriMesL]) & (xNote.VPosition < MeasureBottom[fdriMesU] + MeasureLength[fdriMesU])) || !Conversions.ToBoolean(Interaction.IIf(IsColumnNumeric(xNote.ColumnIndex), (xNote.Value >= fdriValL) & (xNote.Value <= fdriValU), (xNote.Value >= fdriLblL) & (xNote.Value <= fdriLblU))) || !Conversions.ToBoolean(Array.IndexOf(fdriCol, xNote.ColumnIndex) != -1) ? false : (object)true);
        }

        private bool fdrRangeS(bool xbLim1, bool xbLim2, bool xVal)
        {
            return (!xbLim1 && xbLim2 && xVal) || (xbLim1 && !xbLim2 && !xVal) || (xbLim1 && xbLim2);
        }

        public void fdrSelect(int iRange, int xMesL, int xMesU, string xLblL, string xLblU, int xValL, int xValU, int[] iCol)
        {
            fdriMesL = xMesL;
            fdriMesU = xMesU;
            fdriLblL = Functions.C36to10(xLblL) * 10000;
            fdriLblU = Functions.C36to10(xLblU) * 10000;
            fdriValL = xValL;
            fdriValU = xValU;
            fdriCol = iCol;
            bool flag = iRange % 2 == 0;
            bool flag2 = iRange % 3 == 0;
            bool xbLim = iRange % 5 == 0;
            bool xbLim2 = iRange % 7 == 0;
            bool xbLim3 = iRange % 11 == 0;
            bool xbLim4 = iRange % 13 == 0;
            bool[] array = new bool[Information.UBound(Notes) + 1];
            int num = Information.UBound(Notes);
            for (int i = 1; i <= num; i++)
            {
                array[i] = Notes[i].Selected;
            }
            int num2 = Information.UBound(Notes);
            for (int j = 1; j <= num2; j++)
            {
                bool flag3 = flag & array[j];
                bool flag4 = flag2 & !array[j];
                bool flag5 = nEnabled(Notes[j].ColumnIndex);
                bool flag6 = fdrRangeS(xbLim, xbLim2, Conversions.ToBoolean(Interaction.IIf(NTInput, Notes[j].Length, Notes[j].LongNote)));
                bool flag7 = fdrRangeS(xbLim4, xbLim3, Notes[j].Hidden);
                bool flag8 = fdrCheck(Notes[j]);
                if (((flag & array[j]) | (flag2 & !array[j]) && nEnabled(Notes[j].ColumnIndex) && fdrRangeS(xbLim, xbLim2, Conversions.ToBoolean(Interaction.IIf(NTInput, Notes[j].Length, Notes[j].LongNote))) ? true : false) & fdrRangeS(xbLim4, xbLim3, Notes[j].Hidden))
                {
                    Notes[j].Selected = fdrCheck(Notes[j]);
                }
            }
            RefreshPanelAll();
            Interaction.Beep();
        }

        public void fdrUnselect(int iRange, int xMesL, int xMesU, string xLblL, string xLblU, int xValL, int xValU, int[] iCol)
        {
            fdriMesL = xMesL;
            fdriMesU = xMesU;
            fdriLblL = Functions.C36to10(xLblL) * 10000;
            fdriLblU = Functions.C36to10(xLblU) * 10000;
            fdriValL = xValL;
            fdriValU = xValU;
            fdriCol = iCol;
            bool flag = iRange % 2 == 0;
            bool flag2 = iRange % 3 == 0;
            bool xbLim = iRange % 5 == 0;
            bool xbLim2 = iRange % 7 == 0;
            bool xbLim3 = iRange % 11 == 0;
            bool xbLim4 = iRange % 13 == 0;
            bool[] array = new bool[Information.UBound(Notes) + 1];
            int num = Information.UBound(Notes);
            for (int i = 1; i <= num; i++)
            {
                array[i] = Notes[i].Selected;
            }
            int num2 = Information.UBound(Notes);
            for (int j = 1; j <= num2; j++)
            {
                if (((flag & array[j]) | (flag2 & !array[j]) && nEnabled(Notes[j].ColumnIndex) && fdrRangeS(xbLim, xbLim2, Conversions.ToBoolean(Interaction.IIf(NTInput, Notes[j].Length, Notes[j].LongNote))) ? true : false) & fdrRangeS(xbLim4, xbLim3, Notes[j].Hidden))
                {
                    Notes[j].Selected = !fdrCheck(Notes[j]);
                }
            }
            RefreshPanelAll();
            Interaction.Beep();
        }

        public void fdrDelete(int iRange, int xMesL, int xMesU, string xLblL, string xLblU, int xValL, int xValU, int[] iCol)
        {
            fdriMesL = xMesL;
            fdriMesU = xMesU;
            fdriLblL = Functions.C36to10(xLblL) * 10000;
            fdriLblU = Functions.C36to10(xLblU) * 10000;
            fdriValL = xValL;
            fdriValU = xValU;
            fdriCol = iCol;
            bool flag = iRange % 2 == 0;
            bool flag2 = iRange % 3 == 0;
            bool xbLim = iRange % 5 == 0;
            bool xbLim2 = iRange % 7 == 0;
            bool xbLim3 = iRange % 11 == 0;
            bool xbLim4 = iRange % 13 == 0;
            UndoRedo.LinkedURCmd BaseUndo = null;
            UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
            UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
            int num = 1;
            while (num <= Information.UBound(Notes))
            {
                if (((flag & Notes[num].Selected) | (flag2 & !Notes[num].Selected) && fdrCheck(Notes[num]) && nEnabled(Notes[num].ColumnIndex) && fdrRangeS(xbLim, xbLim2, Conversions.ToBoolean(Interaction.IIf(NTInput, Notes[num].Length, Notes[num].LongNote))) ? true : false) & fdrRangeS(xbLim4, xbLim3, Notes[num].Hidden))
                {
                    RedoRemoveNote(Notes[num], ref BaseUndo, ref BaseRedo);
                    RemoveNote(num, SortAndUpdatePairing: false);
                }
                else
                {
                    num += 1;
                }
            }
            AddUndo(BaseUndo, linkedURCmd.Next);
            SortByVPositionInsertion();
            UpdatePairing();
            RefreshPanelAll();
            CalculateTotalPlayableNotes();
            Interaction.Beep();
        }

        public void fdrReplaceL(int iRange, int xMesL, int xMesU, string xLblL, string xLblU, int xValL, int xValU, int[] iCol, string xReplaceLbl)
        {
            fdriMesL = xMesL;
            fdriMesU = xMesU;
            fdriLblL = Functions.C36to10(xLblL) * 10000;
            fdriLblU = Functions.C36to10(xLblU) * 10000;
            fdriValL = xValL;
            fdriValU = xValU;
            fdriCol = iCol;
            bool flag = iRange % 2 == 0;
            bool flag2 = iRange % 3 == 0;
            bool xbLim = iRange % 5 == 0;
            bool xbLim2 = iRange % 7 == 0;
            bool xbLim3 = iRange % 11 == 0;
            bool xbLim4 = iRange % 13 == 0;
            int num = Functions.C36to10(xReplaceLbl) * 10000;
            UndoRedo.LinkedURCmd BaseUndo = null;
            UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
            UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
            int num2 = Information.UBound(Notes);
            for (int i = 1; i <= num2; i++)
            {
                if ((((flag & Notes[i].Selected) | (flag2 & !Notes[i].Selected) && fdrCheck(Notes[i]) && nEnabled(Notes[i].ColumnIndex) ? true : false) & !IsColumnNumeric(Notes[i].ColumnIndex) && fdrRangeS(xbLim, xbLim2, Conversions.ToBoolean(Interaction.IIf(NTInput, Notes[i].Length, Notes[i].LongNote))) ? true : false) & fdrRangeS(xbLim4, xbLim3, Notes[i].Hidden))
                {
                    RedoRelabelNote(Notes[i], num, ref BaseUndo, ref BaseRedo);
                    Notes[i].Value = num;
                }
            }
            AddUndo(BaseUndo, linkedURCmd.Next);
            RefreshPanelAll();
            Interaction.Beep();
        }

        public void fdrReplaceV(int iRange, int xMesL, int xMesU, string xLblL, string xLblU, int xValL, int xValU, int[] iCol, int xReplaceVal)
        {
            fdriMesL = xMesL;
            fdriMesU = xMesU;
            fdriLblL = Functions.C36to10(xLblL) * 10000;
            fdriLblU = Functions.C36to10(xLblU) * 10000;
            fdriValL = xValL;
            fdriValU = xValU;
            fdriCol = iCol;
            bool flag = iRange % 2 == 0;
            bool flag2 = iRange % 3 == 0;
            bool xbLim = iRange % 5 == 0;
            bool xbLim2 = iRange % 7 == 0;
            bool xbLim3 = iRange % 11 == 0;
            bool xbLim4 = iRange % 13 == 0;
            UndoRedo.LinkedURCmd BaseUndo = null;
            UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
            UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
            int num = Information.UBound(Notes);
            for (int i = 1; i <= num; i += 1)
            {
                if ((((flag & Notes[i].Selected) | (flag2 & !Notes[i].Selected) && fdrCheck(Notes[i]) && nEnabled(Notes[i].ColumnIndex) ? true : false) & IsColumnNumeric(Notes[i].ColumnIndex) && fdrRangeS(xbLim, xbLim2, Conversions.ToBoolean(Interaction.IIf(NTInput, Notes[i].Length, Notes[i].LongNote))) ? true : false) & fdrRangeS(xbLim4, xbLim3, Notes[i].Hidden))
                {
                    RedoRelabelNote(Notes[i], xReplaceVal, ref BaseUndo, ref BaseRedo);
                    Notes[i].Value = xReplaceVal;
                }
            }
            AddUndo(BaseUndo, linkedURCmd.Next);
            RefreshPanelAll();
            Interaction.Beep();
        }

        private void MInsert_Click(object sender, EventArgs e)
        {
            UndoRedo.LinkedURCmd BaseUndo = null;
            UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
            UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
            int num = MeasureAtDisplacement(menuVPosition);
            double num2 = MeasureLength[num];
            double num3 = MeasureBottom[num];
            if (NTInput)
            {
                int num4 = 1;
                while (num4 <= Information.UBound(Notes))
                {
                    if (MeasureAtDisplacement(Notes[num4].VPosition) >= 999)
                    {
                        RedoRemoveNote(Notes[num4], ref BaseUndo, ref BaseRedo);
                        RemoveNote(num4, SortAndUpdatePairing: false);
                    }
                    else
                    {
                        num4++;
                    }
                }
                int num5 = Information.UBound(Notes);
                for (num4 = 1; num4 <= num5; num4++)
                {
                    if ((Notes[num4].VPosition >= num3) & (Notes[num4].VPosition + Notes[num4].Length <= MeasureBottom[999]))
                    {
                        RedoMoveNote(Notes[num4], Notes[num4].ColumnIndex, Notes[num4].VPosition + num2, ref BaseUndo, ref BaseRedo);
                        Note[] notes = Notes;
                        notes[num4].VPosition += num2;
                    }
                    else if (Notes[num4].VPosition >= num3)
                    {
                        double num7 = MeasureBottom[999] - 1.0 - Notes[num4].VPosition - Notes[num4].Length;
                        RedoLongNoteModify(Notes[num4], Notes[num4].VPosition + num2, Notes[num4].Length + num7, ref BaseUndo, ref BaseRedo);
                        Note[] notes = Notes;
                        Note[] array2 = notes;
                        int num6 = num4;
                        array2[num6].VPosition = notes[num6].VPosition + num2;
                        notes = Notes;
                        Note[] array3 = notes;
                        num6 = num4;
                        array3[num6].Length = notes[num6].Length + num7;
                    }
                    else if (Notes[num4].VPosition + Notes[num4].Length >= num3)
                    {
                        double num7 = Conversions.ToDouble(Interaction.IIf(Notes[num4].VPosition + Notes[num4].Length > MeasureBottom[999] - 1.0, GetMaxVPosition() - 1.0 - Notes[num4].VPosition - Notes[num4].Length, num2));
                        RedoLongNoteModify(Notes[num4], Notes[num4].VPosition, Notes[num4].Length + num7, ref BaseUndo, ref BaseRedo);
                        Note[] notes = Notes;
                        notes[num4].Length += num7;
                    }
                }
            }
            else
            {
                int num8 = 1;
                while (num8 <= Information.UBound(Notes))
                {
                    if (MeasureAtDisplacement(Notes[num8].VPosition) >= 999)
                    {
                        RedoRemoveNote(Notes[num8], ref BaseUndo, ref BaseRedo);
                        RemoveNote(num8, SortAndUpdatePairing: false);
                    }
                    else
                    {
                        num8++;
                    }
                }
                int num9 = Information.UBound(Notes);
                for (num8 = 1; num8 <= num9; num8++)
                {
                    if (Notes[num8].VPosition >= num3)
                    {
                        RedoMoveNote(Notes[num8], Notes[num8].ColumnIndex, Notes[num8].VPosition + num2, ref BaseUndo, ref BaseRedo);
                        Note[] notes = Notes;
                        notes[num8].VPosition += num2;
                    }
                }
            }
            int num10 = num + 1;
            for (int i = 999; i >= num10; i += -1)
            {
                MeasureLength[i] = MeasureLength[i - 1];
            }
            UpdateMeasureBottom();
            AddUndo(BaseUndo, linkedURCmd.Next);
            UpdatePairing();
            CalculateGreatestVPosition();
            CalculateTotalPlayableNotes();
            RefreshPanelAll();
        }

        private void MRemove_Click(object sender, EventArgs e)
        {
            UndoRedo.LinkedURCmd BaseUndo = null;
            UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
            UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
            int num = MeasureAtDisplacement(menuVPosition);
            double num2 = MeasureLength[num];
            double num3 = MeasureBottom[num];
            if (NTInput)
            {
                int num4 = 1;
                while (num4 <= Information.UBound(Notes))
                {
                    if ((MeasureAtDisplacement(Notes[num4].VPosition) == num) & (MeasureAtDisplacement(Notes[num4].VPosition + Notes[num4].Length) == num))
                    {
                        RedoRemoveNote(Notes[num4], ref BaseUndo, ref BaseRedo);
                        RemoveNote(num4, SortAndUpdatePairing: false);
                    }
                    else
                    {
                        num4++;
                    }
                }
                num3 = MeasureBottom[num];
                int num5 = Information.UBound(Notes);
                for (num4 = 1; num4 <= num5; num4++)
                {
                    if (Notes[num4].VPosition >= num3 + num2)
                    {
                        RedoMoveNote(Notes[num4], Notes[num4].ColumnIndex, Notes[num4].VPosition - num2, ref BaseUndo, ref BaseRedo);
                        Note[] notes = Notes;
                        notes[num4].VPosition -= num2;
                    }
                    else if (Notes[num4].VPosition >= num3)
                    {
                        double num7 = num2 + num3 - Notes[num4].VPosition;
                        RedoLongNoteModify(Notes[num4], Notes[num4].VPosition + num7 - num2, Notes[num4].Length - num7, ref BaseUndo, ref BaseRedo);
                        Note[] notes = Notes;
                        Note[] array2 = notes;
                        int num6 = num4;
                        array2[num6].VPosition = notes[num6].VPosition + (num7 - num2);
                        notes = Notes;
                        Note[] array3 = notes;
                        num6 = num4;
                        array3[num6].Length = notes[num6].Length - num7;
                    }
                    else if (Notes[num4].VPosition + Notes[num4].Length >= num3)
                    {
                        double num7 = Conversions.ToDouble(Interaction.IIf(Notes[num4].VPosition + Notes[num4].Length >= num3 + num2, num2, Notes[num4].VPosition + Notes[num4].Length - num3 + 1.0));
                        RedoLongNoteModify(Notes[num4], Notes[num4].VPosition, Notes[num4].Length - num7, ref BaseUndo, ref BaseRedo);
                        Note[] notes = Notes;
                        notes[num4].Length -= num7;
                    }
                }
            }
            else
            {
                int num8 = 1;
                while (num8 <= Information.UBound(Notes))
                {
                    if (MeasureAtDisplacement(Notes[num8].VPosition) == num)
                    {
                        RedoRemoveNote(Notes[num8], ref BaseUndo, ref BaseRedo);
                        RemoveNote(num8, SortAndUpdatePairing: false);
                    }
                    else
                    {
                        num8++;
                    }
                }
                num3 = MeasureBottom[num];
                int num9 = Information.UBound(Notes);
                for (num8 = 1; num8 <= num9; num8++)
                {
                    if (Notes[num8].VPosition >= num3)
                    {
                        RedoMoveNote(Notes[num8], Notes[num8].ColumnIndex, Notes[num8].VPosition - num2, ref BaseUndo, ref BaseRedo);
                        Note[] notes = Notes;
                        notes[num8].VPosition -= num2;
                    }
                }
            }
            int num10 = num + 1;
            for (int i = 999; i >= num10; i += -1)
            {
                MeasureLength[i - 1] = MeasureLength[i];
            }
            UpdateMeasureBottom();
            AddUndo(BaseUndo, linkedURCmd.Next);
            SortByVPositionInsertion();
            UpdatePairing();
            CalculateGreatestVPosition();
            CalculateTotalPlayableNotes();
            RefreshPanelAll();
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private void TBThemeDef_Click(object sender, EventArgs e)
        {
            string text = MyProject.Application.Info.DirectoryPath + "\\____TempFile.Theme.xml";
            MyProject.Computer.FileSystem.WriteAllText(text, Resources.O2Mania_Theme, append: false, Encoding.Unicode);
            LoadSettings(text);
            File.Delete(text);
            RefreshPanelAll();
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private void TBThemeSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = Strings.FileType.THEME_XML + "|*.Theme.xml";
            saveFileDialog.DefaultExt = "Theme.xml";
            saveFileDialog.InitialDirectory = MyProject.Application.Info.DirectoryPath + "\\Data";
            if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                SaveSettings(saveFileDialog.FileName, ThemeOnly: true);
                if (BeepWhileSaved)
                {
                    Interaction.Beep();
                }
                TBThemeRefresh_Click(TBThemeRefresh, new EventArgs());
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private void TBThemeRefresh_Click(object sender, EventArgs e)
        {
            for (int i = cmnTheme.Items.Count - 1; i >= 5; i += -1)
            {
                try
                {
                    cmnTheme.Items.RemoveAt(i);
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    Exception ex2 = ex;
                    ProjectData.ClearProjectError();
                }
            }
            if (!Directory.Exists(MyProject.Application.Info.DirectoryPath + "\\Data"))
            {
                MyProject.Computer.FileSystem.CreateDirectory(MyProject.Application.Info.DirectoryPath + "\\Data");
            }
            FileInfo[] files = MyProject.Computer.FileSystem.GetDirectoryInfo(MyProject.Application.Info.DirectoryPath + "\\Data").GetFiles("*.Theme.xml");
            foreach (FileInfo fileInfo in files)
            {
                cmnTheme.Items.Add(fileInfo.Name, null, LoadTheme);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private void TBThemeLoadComptability_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = Strings.FileType.TH + "|*.th";
            openFileDialog.DefaultExt = "th";
            openFileDialog.InitialDirectory = MyProject.Application.Info.DirectoryPath;
            if (MyProject.Computer.FileSystem.DirectoryExists(MyProject.Application.Info.DirectoryPath + "\\Theme"))
            {
                openFileDialog.InitialDirectory = MyProject.Application.Info.DirectoryPath + "\\Theme";
            }
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                LoadThemeComptability(openFileDialog.FileName);
                RefreshPanelAll();
            }
        }

        private double InputBoxDouble(string Prompt, double LBound, double UBound, string Title = "", string DefaultResponse = "")
        {
            string text = Interaction.InputBox(Prompt, Title, DefaultResponse);
            if (Operators.CompareString(text, "", TextCompare: false) == 0)
            {
                return double.PositiveInfinity;
            }
            double num = Conversion.Val(text);
            if (num > UBound)
            {
                num = UBound;
            }
            if (num < LBound)
            {
                num = LBound;
            }
            return num;
        }

        private void FSSS_Click(object sender, EventArgs e)
        {
            double num = Conversions.ToDouble(Interaction.IIf(vSelLength > 0.0, GetMaxVPosition() - vSelLength, GetMaxVPosition()));
            double num2 = Conversions.ToDouble(Interaction.IIf(vSelLength < 0.0, 0.0 - vSelLength, 0));
            double num3 = InputBoxDouble("Please enter a number between " + Conversions.ToString(num2) + " and " + Conversions.ToString(num) + ".", num2, num, "", Conversions.ToString(vSelStart));
            if (num3 != double.PositiveInfinity)
            {
                vSelStart = num3;
                ValidateSelection();
                RefreshPanelAll();
                POStatusRefresh();
            }
        }

        private void FSSL_Click(object sender, EventArgs e)
        {
            double num = GetMaxVPosition() - vSelStart;
            double num2 = 0.0 - vSelStart;
            double num3 = InputBoxDouble("Please enter a number between " + Conversions.ToString(num2) + " and " + Conversions.ToString(num) + ".", num2, num, "", Conversions.ToString(vSelLength));
            if (num3 != double.PositiveInfinity)
            {
                vSelLength = num3;
                ValidateSelection();
                RefreshPanelAll();
                POStatusRefresh();
            }
        }

        private void FSSH_Click(object sender, EventArgs e)
        {
            double num = Conversions.ToDouble(Interaction.IIf(vSelLength > 0.0, vSelLength, 0));
            double num2 = Conversions.ToDouble(Interaction.IIf(vSelLength > 0.0, 0, 0.0 - vSelLength));
            double num3 = InputBoxDouble("Please enter a number between " + Conversions.ToString(num2) + " and " + Conversions.ToString(num) + ".", num2, num, "", Conversions.ToString(vSelHalf));
            if (num3 != double.PositiveInfinity)
            {
                vSelHalf = num3;
                ValidateSelection();
                RefreshPanelAll();
                POStatusRefresh();
            }
        }
    }
}
