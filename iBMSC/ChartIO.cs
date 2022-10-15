using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace iBMSC
{

    public partial class MainWindow : Form
    {
        private void OpenBMS(string xStrAll)
        {
            this.KMouseOver = -1;

            // Line feed validation: will remove some empty lines
            xStrAll = Strings.Replace(Strings.Replace(Strings.Replace(xStrAll, Constants.vbLf, Constants.vbCr), Constants.vbCr + Constants.vbCr, Constants.vbCr), Constants.vbCr, Constants.vbCrLf);

            var xStrLine = Strings.Split(xStrAll, Constants.vbCrLf, Compare: CompareMethod.Text);
            int xI1;
            string sLine;
            string xExpansion = "";
            this.Notes = new iBMSC.Editor.Note[1];
            this.mColumn = new int[1000];
            this.hWAV = new string[1296];
            this.hBPM = new long[1296];    // x10000
            this.hSTOP = new long[1296];
            this.hSCROLL = new long[1296];
            this.InitializeNewBMS();
            this.InitializeOpenBMS();

            {
                ref var withBlock = ref this.Notes[0];
                withBlock.ColumnIndex = MainWindow.niBPM;
                withBlock.VPosition = (double)-1;
                // .LongNote = False
                // .Selected = False
                withBlock.Value = 1200000L;
            }

            // random, setRandom      0
            // endRandom              0
            // if             +1
            // else           0
            // endif          -1
            // switch, setSwitch      +1
            // case, skip, def        0
            // endSw                  -1
            int xStack = 0;

            foreach (var currentSLine in xStrLine)
            {
                sLine = currentSLine;
                string sLineTrim = sLine.Trim();
                if (xStack > 0)
                    goto Expansion;

                if (sLineTrim.StartsWith("#") & Strings.Mid(sLineTrim, 5, 3) == "02:")
                {
                    int xIndex = (int)Math.Round(Conversion.Val(Strings.Mid(sLineTrim, 2, 3)));
                    double xRatio = Conversion.Val(Strings.Mid(sLineTrim, 8));
                    long xxD = iBMSC.Editor.Functions.GetDenominator(xRatio);
                    this.MeasureLength[xIndex] = xRatio * 192.0d;
                    this.LBeat.Items[xIndex] = Operators.ConcatenateObject(iBMSC.Editor.Functions.Add3Zeros(xIndex) + ": " + xRatio, Interaction.IIf(xxD > 10000L, "", " ( " + (long)Math.Round(xRatio * xxD) + " / " + xxD + " ) "));
                }

                else if (sLineTrim.StartsWith("#WAV", StringComparison.CurrentCultureIgnoreCase))
                {
                    this.hWAV[iBMSC.Editor.Functions.C36to10(Strings.Mid(sLineTrim, Strings.Len("#WAV") + 1, 2))] = Strings.Mid(sLineTrim, Strings.Len("#WAV") + 4);
                }

                else if (sLineTrim.StartsWith("#BMP", StringComparison.CurrentCultureIgnoreCase))
                {
                    this.hBMP[iBMSC.Editor.Functions.C36to10(Strings.Mid(sLineTrim, Strings.Len("#BMP") + 1, 2))] = Strings.Mid(sLineTrim, Strings.Len("#BMP") + 4);
                }

                else if (sLineTrim.StartsWith("#BPM", StringComparison.CurrentCultureIgnoreCase) & !string.IsNullOrEmpty(Strings.Mid(sLineTrim, Strings.Len("#BPM") + 1, 1).Trim()))  // If BPM##
                {
                    // zdr: No limits on BPM editing.. they don't make much sense.
                    this.hBPM[iBMSC.Editor.Functions.C36to10(Strings.Mid(sLineTrim, Strings.Len("#BPM") + 1, 2))] = (long)Math.Round(Conversion.Val(Strings.Mid(sLineTrim, Strings.Len("#BPM") + 4)) * 10000d);
                }

                // No limits on STOPs either.
                else if (sLineTrim.StartsWith("#STOP", StringComparison.CurrentCultureIgnoreCase))
                {
                    this.hSTOP[iBMSC.Editor.Functions.C36to10(Strings.Mid(sLineTrim, Strings.Len("#STOP") + 1, 2))] = (long)Math.Round(Conversion.Val(Strings.Mid(sLineTrim, Strings.Len("#STOP") + 4)) * 10000d);
                }

                else if (sLineTrim.StartsWith("#SCROLL", StringComparison.CurrentCultureIgnoreCase))
                {
                    this.hSCROLL[iBMSC.Editor.Functions.C36to10(Strings.Mid(sLineTrim, Strings.Len("#SCROLL") + 1, 2))] = (long)Math.Round(Conversion.Val(Strings.Mid(sLineTrim, Strings.Len("#SCROLL") + 4)) * 10000d);
                }


                else if (sLineTrim.StartsWith("#TITLE", StringComparison.CurrentCultureIgnoreCase))
                {
                    this.THTitle.Text = Strings.Mid(sLineTrim, Strings.Len("#TITLE") + 1).Trim();
                }

                else if (sLineTrim.StartsWith("#ARTIST", StringComparison.CurrentCultureIgnoreCase))
                {
                    this.THArtist.Text = Strings.Mid(sLineTrim, Strings.Len("#ARTIST") + 1).Trim();
                }

                else if (sLineTrim.StartsWith("#GENRE", StringComparison.CurrentCultureIgnoreCase))
                {
                    this.THGenre.Text = Strings.Mid(sLineTrim, Strings.Len("#GENRE") + 1).Trim();
                }

                else if (sLineTrim.StartsWith("#BPM", StringComparison.CurrentCultureIgnoreCase))  // If BPM ####
                {
                    this.Notes[0].Value = (long)Math.Round(Conversion.Val(Strings.Mid(sLineTrim, Strings.Len("#BPM") + 1).Trim()) * 10000d);
                    this.THBPM.Value = (decimal)((double)this.Notes[0].Value / 10000d);
                }

                else if (sLineTrim.StartsWith("#PLAYER", StringComparison.CurrentCultureIgnoreCase))
                {
                    int xInt = (int)Math.Round(Conversion.Val(Strings.Mid(sLineTrim, Strings.Len("#PLAYER") + 1).Trim()));
                    if (xInt >= 1 & xInt <= 4)
                        this.CHPlayer.SelectedIndex = xInt - 1;
                }

                else if (sLineTrim.StartsWith("#RANK", StringComparison.CurrentCultureIgnoreCase))
                {
                    int xInt = (int)Math.Round(Conversion.Val(Strings.Mid(sLineTrim, Strings.Len("#RANK") + 1).Trim()));
                    if (xInt >= 0 & xInt <= 4)
                        this.CHRank.SelectedIndex = xInt;
                }

                else if (sLineTrim.StartsWith("#PLAYLEVEL", StringComparison.CurrentCultureIgnoreCase))
                {
                    this.THPlayLevel.Text = Strings.Mid(sLineTrim, Strings.Len("#PLAYLEVEL") + 1).Trim();
                }


                else if (sLineTrim.StartsWith("#SUBTITLE", StringComparison.CurrentCultureIgnoreCase))
                {
                    this.THSubTitle.Text = Strings.Mid(sLineTrim, Strings.Len("#SUBTITLE") + 1).Trim();
                }

                else if (sLineTrim.StartsWith("#SUBARTIST", StringComparison.CurrentCultureIgnoreCase))
                {
                    this.THSubArtist.Text = Strings.Mid(sLineTrim, Strings.Len("#SUBARTIST") + 1).Trim();
                }

                else if (sLineTrim.StartsWith("#STAGEFILE", StringComparison.CurrentCultureIgnoreCase))
                {
                    this.THStageFile.Text = Strings.Mid(sLineTrim, Strings.Len("#STAGEFILE") + 1).Trim();
                }

                else if (sLineTrim.StartsWith("#BANNER", StringComparison.CurrentCultureIgnoreCase))
                {
                    this.THBanner.Text = Strings.Mid(sLineTrim, Strings.Len("#BANNER") + 1).Trim();
                }

                else if (sLineTrim.StartsWith("#BACKBMP", StringComparison.CurrentCultureIgnoreCase))
                {
                    this.THBackBMP.Text = Strings.Mid(sLineTrim, Strings.Len("#BACKBMP") + 1).Trim();
                }

                else if (sLineTrim.StartsWith("#DIFFICULTY", StringComparison.CurrentCultureIgnoreCase))
                {
                    try
                    {
                        this.CHDifficulty.SelectedIndex = int.Parse(Strings.Mid(sLineTrim, Strings.Len("#DIFFICULTY") + 1).Trim());
                    }
                    catch (Exception ex)
                    {
                    }
                }

                else if (sLineTrim.StartsWith("#DEFEXRANK", StringComparison.CurrentCultureIgnoreCase))
                {
                    this.THExRank.Text = Strings.Mid(sLineTrim, Strings.Len("#DEFEXRANK") + 1).Trim();
                }

                else if (sLineTrim.StartsWith("#TOTAL", StringComparison.CurrentCultureIgnoreCase))
                {
                    string xStr = Strings.Mid(sLineTrim, Strings.Len("#TOTAL") + 1).Trim();
                    // If xStr.EndsWith("%") Then xStr = Mid(xStr, 1, Len(xStr) - 1)
                    this.THTotal.Text = xStr;
                }

                else if (sLineTrim.StartsWith("#COMMENT", StringComparison.CurrentCultureIgnoreCase))
                {
                    string xStr = Strings.Mid(sLineTrim, Strings.Len("#COMMENT") + 1).Trim();
                    if (xStr.StartsWith("\""))
                        xStr = Strings.Mid(xStr, 2);
                    if (xStr.EndsWith("\""))
                        xStr = Strings.Mid(xStr, 1, Strings.Len(xStr) - 1);
                    this.THComment.Text = xStr;
                }

                else if (sLineTrim.StartsWith("#LNTYPE", StringComparison.CurrentCultureIgnoreCase))
                {
                    // THLnType.Text = Mid(sLineTrim, Len("#LNTYPE") + 1).Trim
                    if (Conversion.Val(Strings.Mid(sLineTrim, Strings.Len("#LNTYPE") + 1).Trim()) == 1d)
                        this.CHLnObj.SelectedIndex = 0;
                }

                else if (sLineTrim.StartsWith("#LNOBJ", StringComparison.CurrentCultureIgnoreCase))
                {
                    int xValue = iBMSC.Editor.Functions.C36to10(Strings.Mid(sLineTrim, Strings.Len("#LNOBJ") + 1).Trim());
                    this.CHLnObj.SelectedIndex = xValue;
                }

                // TODO: LNOBJ value validation

                // ElseIf sLineTrim.StartsWith("#LNTYPE", StringComparison.CurrentCultureIgnoreCase) Then
                // CAdLNTYPE.Checked = True
                // If Mid(sLineTrim, 9) = "" Or Mid(sLineTrim, 9) = "1" Or Mid(sLineTrim, 9) = "01" Then CAdLNTYPEb.Text = "1"
                // CAdLNTYPEb.Text = Mid(sLineTrim, 9)

                else if (sLineTrim.StartsWith("#") & Strings.Mid(sLineTrim, 7, 1) == ":")   // If the line contains Ks
                {
                    string xIdentifier = Strings.Mid(sLineTrim, 5, 2);
                    if (this.BMSChannelToColumn(xIdentifier) == 0)
                        goto AddExpansion;
                }

                else
                {
                Expansion:
                    ;
                    if (sLineTrim.StartsWith("#IF", StringComparison.CurrentCultureIgnoreCase))
                    {
                        xStack += 1;
                        goto AddExpansion;
                    }
                    else if (sLineTrim.StartsWith("#ENDIF", StringComparison.CurrentCultureIgnoreCase))
                    {
                        xStack -= 1;
                        goto AddExpansion;
                    }
                    else if (sLineTrim.StartsWith("#SWITCH", StringComparison.CurrentCultureIgnoreCase))
                    {
                        xStack += 1;
                        goto AddExpansion;
                    }
                    else if (sLineTrim.StartsWith("#SETSWITCH", StringComparison.CurrentCultureIgnoreCase))
                    {
                        xStack += 1;
                        goto AddExpansion;
                    }
                    else if (sLineTrim.StartsWith("#ENDSW", StringComparison.CurrentCultureIgnoreCase))
                    {
                        xStack -= 1;
                        goto AddExpansion;
                    }

                    else if (sLineTrim.StartsWith("#"))
                    {
                    AddExpansion:
                        ;
                        xExpansion += sLine + Constants.vbCrLf;
                    }

                }
            }

            this.UpdateMeasureBottom();

            xStack = 0;
            foreach (var currentSLine1 in xStrLine)
            {
                sLine = currentSLine1;
                string sLineTrim = sLine.Trim();
                if (xStack > 0)
                    continue;

                if (!(sLineTrim.StartsWith("#") & Strings.Mid(sLineTrim, 7, 1) == ":"))
                    continue; // If the line contains Ks

                // >> Measure =           Mid(sLine, 2, 3)
                // >> Column Identifier = Mid(sLine, 5, 2)
                // >> K =                 Mid(sLine, xI1, 2)
                int xMeasure = (int)Math.Round(Conversion.Val(Strings.Mid(sLineTrim, 2, 3)));
                string Channel = Strings.Mid(sLineTrim, 5, 2);
                if (this.BMSChannelToColumn(Channel) == 0)
                    continue;

                if (Channel == "01")
                    this.mColumn[xMeasure] += 1; // If the identifier is 01 then add a B column in that measure
                var loopTo = Strings.Len(sLineTrim) - 1;
                for (xI1 = 8; xI1 <= loopTo; xI1 += 2)   // For all Ks within that line ( - 1 can be ommitted )
                {
                    if (Strings.Mid(sLineTrim, xI1, 2) == "00")
                        continue; // If the K is not 00

                    Array.Resize(ref this.Notes, this.Notes.Length + 1);

                    {
                        ref var withBlock1 = ref this.Notes[Information.UBound(this.Notes)];
                        withBlock1.ColumnIndex = Conversions.ToInteger(Operators.AddObject(this.BMSChannelToColumn(Channel), Operators.MultiplyObject(Interaction.IIf(Channel == "01", 1, 0), this.mColumn[xMeasure] - 1)));
                        withBlock1.LongNote = iBMSC.BMS.IsChannelLongNote(Channel);
                        withBlock1.Hidden = iBMSC.BMS.IsChannelHidden(Channel);
                        withBlock1.Landmine = iBMSC.BMS.IsChannelLandmine(Channel);
                        withBlock1.Selected = false;
                        withBlock1.VPosition = this.MeasureBottom[xMeasure] + this.MeasureLength[xMeasure] * (xI1 / 2d - 4d) / ((Strings.Len(sLineTrim) - 7) / 2d);
                        withBlock1.Value = (long)(iBMSC.Editor.Functions.C36to10(Strings.Mid(sLineTrim, xI1, 2)) * 10000);

                        if (Channel == "03")
                            withBlock1.Value = (long)(Convert.ToInt32(Strings.Mid(sLineTrim, xI1, 2), 16) * 10000);
                        if (Channel == "08")
                            withBlock1.Value = this.hBPM[iBMSC.Editor.Functions.C36to10(Strings.Mid(sLineTrim, xI1, 2))];
                        if (Channel == "09")
                            withBlock1.Value = this.hSTOP[iBMSC.Editor.Functions.C36to10(Strings.Mid(sLineTrim, xI1, 2))];
                        if (Channel == "SC")
                            withBlock1.Value = this.hSCROLL[iBMSC.Editor.Functions.C36to10(Strings.Mid(sLineTrim, xI1, 2))];
                    }

                }
            }

            if (this.NTInput)
                this.ConvertBMSE2NT();

            this.LWAV.Visible = false;
            this.LWAV.Items.Clear();
            this.LBMP.Visible = false;
            this.LBMP.Items.Clear();
            for (xI1 = 1; xI1 <= 1295; xI1++)
            {
                this.LWAV.Items.Add(iBMSC.Editor.Functions.C10to36((long)xI1) + ": " + this.hWAV[xI1]);
                this.LBMP.Items.Add(iBMSC.Editor.Functions.C10to36((long)xI1) + ": " + this.hBMP[xI1]);
            }
            this.LWAV.SelectedIndex = 0;
            this.LWAV.Visible = true;
            this.LBMP.SelectedIndex = 0;
            this.LBMP.Visible = true;

            this.TExpansion.Text = xExpansion;

            this.SortByVPositionQuick(0, Information.UBound(this.Notes));
            this.UpdatePairing();
            this.CalculateTotalPlayableNotes();
            this.CalculateGreatestVPosition();
            this.RefreshPanelAll();
            this.POStatusRefresh();
        }

        private readonly string[] BMSChannelList = new string[] { "01", "03", "04", "06", "07", "08", "09", "11", "12", "13", "14", "15", "16", "18", "19", "21", "22", "23", "24", "25", "26", "28", "29", "31", "32", "33", "34", "35", "36", "38", "39", "41", "42", "43", "44", "45", "46", "48", "49", "51", "52", "53", "54", "55", "56", "58", "59", "61", "62", "63", "64", "65", "66", "68", "69", "D1", "D2", "D3", "D4", "D5", "D6", "D8", "D9", "E1", "E2", "E3", "E4", "E5", "E6", "E8", "E9", "SC" };
        // 71 through 89 are reserved
        // "71", "72", "73", "74", "75", "76", "78", "79",
        // "81", "82", "83", "84", "85", "86", "88", "89",


        private string SaveBMS()
        {
            this.CalculateGreatestVPosition();
            this.SortByVPositionInsertion();
            this.UpdatePairing();
            int MeasureIndex;
            bool hasOverlapping = false;
            // Dim xStrAll As String = ""   'for all 
            var xStrMeasure = new string[this.MeasureAtDisplacement(this.GreatestVPosition) + 1 + 1];

            // We regenerate these when traversing the bms event list.
            this.hBPM = new long[1];
            this.hSTOP = new long[1];
            this.hSCROLL = new long[1];

            bool xNTInput = this.NTInput;
            var xKBackUp = this.Notes;
            if (xNTInput)
            {
                this.NTInput = false;
                this.ConvertNT2BMSE();
            }     // Temp K

            var xprevNotes = new iBMSC.Editor.Note[0];  // Notes too close to the next measure

            var loopTo = this.MeasureAtDisplacement(this.GreatestVPosition) + 1;
            for (MeasureIndex = 0; MeasureIndex <= loopTo; MeasureIndex++)  // For xI1 in each measure
            {
                xStrMeasure[MeasureIndex] = Constants.vbCrLf;

                string consistentDecimalStr = iBMSC.Editor.Functions.WriteDecimalWithDot(this.MeasureLength[MeasureIndex] / 192.0d);

                // Handle fractional measure
                if (this.MeasureLength[MeasureIndex] != 192.0d)
                    xStrMeasure[MeasureIndex] += "#" + iBMSC.Editor.Functions.Add3Zeros(MeasureIndex) + "02:" + consistentDecimalStr + Constants.vbCrLf;

                // Get note count in current measure
                int LowerLimit = default;
                int UpperLimit = default;
                GetMeasureLimits(MeasureIndex, ref LowerLimit, ref UpperLimit);

                if (UpperLimit - LowerLimit == 0)
                    continue; // If there is no K in the current measure then end this loop

                // Get notes from this measure
                int xUPrevText = Information.UBound(xprevNotes);
                var NotesInMeasure = new iBMSC.Editor.Note[UpperLimit - LowerLimit + xUPrevText + 1];

                // Copy notes from previous array
                for (int i = 0, loopTo1 = xUPrevText; i <= loopTo1; i++)
                    NotesInMeasure[i] = xprevNotes[i];

                // Copy notes in current measure
                for (int i = LowerLimit, loopTo2 = UpperLimit - 1; i <= loopTo2; i++)
                    NotesInMeasure[i - LowerLimit + xprevNotes.Length] = this.Notes[i];

                // Find greatest column.
                // Since background tracks have the highest column values
                // this - niB will yield the number of B columns.
                int GreatestColumn = 0;
                foreach (var tempNote in NotesInMeasure)
                    GreatestColumn = Math.Max(tempNote.ColumnIndex, GreatestColumn);

                xprevNotes = new iBMSC.Editor.Note[0];
                xStrMeasure[MeasureIndex] += GenerateBackgroundTracks(MeasureIndex, ref hasOverlapping, NotesInMeasure, GreatestColumn, ref xprevNotes);
                xStrMeasure[MeasureIndex] += GenerateKeyTracks(MeasureIndex, ref hasOverlapping, NotesInMeasure, ref xprevNotes);
            }

            // Warn about 255 limit if neccesary.
            if (hasOverlapping)
                Interaction.MsgBox(iBMSC.Strings.Messages.SaveWarning + Constants.vbCrLf + iBMSC.Strings.Messages.NoteOverlapError + Constants.vbCrLf + iBMSC.Strings.Messages.SavedFileWillContainErrors, MsgBoxStyle.Exclamation);
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(Information.UBound(this.hBPM), Interaction.IIf(this.BPMx1296, (object)1295, (object)255), false)))
                Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(iBMSC.Strings.Messages.SaveWarning + Constants.vbCrLf + iBMSC.Strings.Messages.BPMOverflowError + Information.UBound(this.hBPM) + " > ", Interaction.IIf(this.BPMx1296, (object)1295, (object)255)), Constants.vbCrLf), iBMSC.Strings.Messages.SavedFileWillContainErrors), MsgBoxStyle.Exclamation);
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(Information.UBound(this.hSTOP), Interaction.IIf(this.STOPx1296, (object)1295, (object)255), false)))
                Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(iBMSC.Strings.Messages.SaveWarning + Constants.vbCrLf + iBMSC.Strings.Messages.STOPOverflowError + Information.UBound(this.hSTOP) + " > ", Interaction.IIf(this.STOPx1296, (object)1295, (object)255)), Constants.vbCrLf), iBMSC.Strings.Messages.SavedFileWillContainErrors), MsgBoxStyle.Exclamation);
            if (Information.UBound(this.hSCROLL) > 1295)
                Interaction.MsgBox(iBMSC.Strings.Messages.SaveWarning + Constants.vbCrLf + iBMSC.Strings.Messages.SCROLLOverflowError + Information.UBound(this.hSCROLL) + " > " + 1295 + Constants.vbCrLf + iBMSC.Strings.Messages.SavedFileWillContainErrors, MsgBoxStyle.Exclamation);

            // Add expansion text
            string xStrExp = Constants.vbCrLf + "*---------------------- EXPANSION FIELD" + Constants.vbCrLf + this.TExpansion.Text + Constants.vbCrLf + Constants.vbCrLf;
            if (string.IsNullOrEmpty(this.TExpansion.Text))
                xStrExp = "";

            // Output main data field.
            string xStrMain = "*---------------------- MAIN DATA FIELD" + Constants.vbCrLf + Constants.vbCrLf + Strings.Join(xStrMeasure, "") + Constants.vbCrLf;

            if (xNTInput)
            {
                this.Notes = xKBackUp;
                this.NTInput = true;
            }

            // Generate headers now, since we have the unique BPM/STOP/etc declarations.
            string xStrHeader = GenerateHeaderMeta();
            xStrHeader += GenerateHeaderIndexedData();

            string xStrAll = xStrHeader + Constants.vbCrLf + xStrExp + Constants.vbCrLf + xStrMain;
            return xStrAll;
        }

        private string GenerateHeaderMeta()
        {
            string xStrHeader = Constants.vbCrLf + "*---------------------- HEADER FIELD" + Constants.vbCrLf + Constants.vbCrLf;
            xStrHeader += "#PLAYER " + (this.CHPlayer.SelectedIndex + 1) + Constants.vbCrLf;
            xStrHeader += "#GENRE " + this.THGenre.Text + Constants.vbCrLf;
            xStrHeader += "#TITLE " + this.THTitle.Text + Constants.vbCrLf;
            xStrHeader += "#ARTIST " + this.THArtist.Text + Constants.vbCrLf;
            xStrHeader += "#BPM " + iBMSC.Editor.Functions.WriteDecimalWithDot((double)this.Notes[0].Value / 10000d) + Constants.vbCrLf;
            xStrHeader += "#PLAYLEVEL " + this.THPlayLevel.Text + Constants.vbCrLf;
            xStrHeader += "#RANK " + this.CHRank.SelectedIndex + Constants.vbCrLf;
            xStrHeader += Constants.vbCrLf;
            if (!string.IsNullOrEmpty(this.THSubTitle.Text))
                xStrHeader += "#SUBTITLE " + this.THSubTitle.Text + Constants.vbCrLf;
            if (!string.IsNullOrEmpty(this.THSubArtist.Text))
                xStrHeader += "#SUBARTIST " + this.THSubArtist.Text + Constants.vbCrLf;
            if (!string.IsNullOrEmpty(this.THStageFile.Text))
                xStrHeader += "#STAGEFILE " + this.THStageFile.Text + Constants.vbCrLf;
            if (!string.IsNullOrEmpty(this.THBanner.Text))
                xStrHeader += "#BANNER " + this.THBanner.Text + Constants.vbCrLf;
            if (!string.IsNullOrEmpty(this.THBackBMP.Text))
                xStrHeader += "#BACKBMP " + this.THBackBMP.Text + Constants.vbCrLf;
            xStrHeader += Constants.vbCrLf;
            if (Conversions.ToBoolean(this.CHDifficulty.SelectedIndex))
                xStrHeader += "#DIFFICULTY " + this.CHDifficulty.SelectedIndex + Constants.vbCrLf;
            if (!string.IsNullOrEmpty(this.THExRank.Text))
                xStrHeader += "#DEFEXRANK " + this.THExRank.Text + Constants.vbCrLf;
            if (!string.IsNullOrEmpty(this.THTotal.Text))
                xStrHeader += "#TOTAL " + this.THTotal.Text + Constants.vbCrLf;
            if (!string.IsNullOrEmpty(this.THComment.Text))
                xStrHeader += "#COMMENT \"" + this.THComment.Text + "\"" + Constants.vbCrLf;
            // If THLnType.Text <> "" Then xStrHeader &= "#LNTYPE " & THLnType.Text & vbCrLf
            if (this.CHLnObj.SelectedIndex > 0)
                xStrHeader += "#LNOBJ " + iBMSC.Editor.Functions.C10to36((long)this.CHLnObj.SelectedIndex) + Constants.vbCrLf;
            else
                xStrHeader += "#LNTYPE 1" + Constants.vbCrLf;
            xStrHeader += Constants.vbCrLf;
            return xStrHeader;
        }

        private string GenerateHeaderIndexedData()
        {
            string xStrHeader = "";

            for (int i = 1, loopTo = Information.UBound(this.hWAV); i <= loopTo; i++)
            {
                if (!string.IsNullOrEmpty(this.hWAV[i]))
                    xStrHeader += "#WAV" + iBMSC.Editor.Functions.C10to36((long)i) + " " + this.hWAV[i] + Constants.vbCrLf;
            }
            for (int i = 1, loopTo1 = Information.UBound(this.hBMP); i <= loopTo1; i++)
            {
                if (!string.IsNullOrEmpty(this.hBMP[i]))
                    xStrHeader += "#BMP" + iBMSC.Editor.Functions.C10to36((long)i) + " " + this.hBMP[i] + Constants.vbCrLf;
            }
            for (int i = 1, loopTo2 = Information.UBound(this.hBPM); i <= loopTo2; i++)
                xStrHeader = Conversions.ToString(xStrHeader + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("#BPM", Interaction.IIf(this.BPMx1296, iBMSC.Editor.Functions.C10to36((long)i), Strings.Mid("0" + Conversion.Hex(i), Strings.Len(Conversion.Hex(i))))), " "), iBMSC.Editor.Functions.WriteDecimalWithDot((double)this.hBPM[i] / 10000d)), Constants.vbCrLf));
            for (int i = 1, loopTo3 = Information.UBound(this.hSTOP); i <= loopTo3; i++)
                xStrHeader = Conversions.ToString(xStrHeader + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("#STOP", Interaction.IIf(this.STOPx1296, iBMSC.Editor.Functions.C10to36((long)i), Strings.Mid("0" + Conversion.Hex(i), Strings.Len(Conversion.Hex(i))))), " "), iBMSC.Editor.Functions.WriteDecimalWithDot((double)this.hSTOP[i] / 10000d)), Constants.vbCrLf));
            for (int i = 1, loopTo4 = Information.UBound(this.hSCROLL); i <= loopTo4; i++)
                xStrHeader += "#SCROLL" + iBMSC.Editor.Functions.C10to36((long)i) + " " + iBMSC.Editor.Functions.WriteDecimalWithDot((double)this.hSCROLL[i] / 10000d) + Constants.vbCrLf;

            return xStrHeader;
        }

        private void GetMeasureLimits(int MeasureIndex, ref int LowerLimit, ref int UpperLimit)
        {
            int NoteCount = Information.UBound(this.Notes);
            LowerLimit = 0;

            for (int i = 1, loopTo = NoteCount; i <= loopTo; i++)  // Collect Ks in the same measure
            {
                if (this.MeasureAtDisplacement(this.Notes[i].VPosition) >= MeasureIndex)
                {
                    LowerLimit = i;
                    break;
                } // Lower limit found
            }

            UpperLimit = 0;

            for (int i = LowerLimit, loopTo1 = NoteCount; i <= loopTo1; i++)
            {
                if (this.MeasureAtDisplacement(this.Notes[i].VPosition) > MeasureIndex)
                {
                    UpperLimit = i;
                    break; // Upper limit found
                }
            }

            if (UpperLimit < LowerLimit)
                UpperLimit = NoteCount + 1;
        }

        private string GenerateKeyTracks(int MeasureIndex, ref bool hasOverlapping, iBMSC.Editor.Note[] NotesInMeasure, ref iBMSC.Editor.Note[] xprevNotes)
        {
            string Ret = "";

            foreach (var CurrentBMSChannel in BMSChannelList) // Start rendering other notes
            {
                var relativeMeasurePos = new object[0]; // Ks in the same column
                var NoteStrings = new object[0];      // Ks in the same column

                // Background tracks take care of this.
                if (CurrentBMSChannel == "01")
                    continue;


                for (int NoteIndex = 0, loopTo = Information.UBound(NotesInMeasure); NoteIndex <= loopTo; NoteIndex++) // Find Ks in the same column (xI4 is TK index)
                {

                    var currentNote = NotesInMeasure[NoteIndex];
                    if ((this.GetBMSChannelBy(currentNote) ?? "") == (CurrentBMSChannel ?? ""))
                    {

                        Array.Resize(ref relativeMeasurePos, Information.UBound(relativeMeasurePos) + 1 + 1);
                        Array.Resize(ref NoteStrings, Information.UBound(NoteStrings) + 1 + 1);
                        relativeMeasurePos[Information.UBound(relativeMeasurePos)] = (object)(currentNote.VPosition - this.MeasureBottom[this.MeasureAtDisplacement(currentNote.VPosition)]);
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectLess(relativeMeasurePos[Information.UBound(relativeMeasurePos)], 0, false)))
                            relativeMeasurePos[Information.UBound(relativeMeasurePos)] = 0;

                        if (CurrentBMSChannel == "03") // If integer bpm
                        {
                            NoteStrings[Information.UBound(NoteStrings)] = Strings.Mid("0" + Conversion.Hex(currentNote.Value / 10000L), Strings.Len(Conversion.Hex(currentNote.Value / 10000L)));
                        }
                        else if (CurrentBMSChannel == "08") // If bpm requires declaration
                        {
                            object BpmIndex;
                            var loopTo1 = Information.UBound(this.hBPM);
                            for (BpmIndex = 1; BpmIndex <= loopTo1; BpmIndex++) // find BPM value in existing array
                            {
                                if (currentNote.Value == this.hBPM[Conversions.ToInteger(BpmIndex)])
                                    break;
                            }
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(BpmIndex, Information.UBound(this.hBPM), false))) // Didn't find it, add it
                            {
                                Array.Resize(ref this.hBPM, Information.UBound(this.hBPM) + 1 + 1);
                                this.hBPM[Information.UBound(this.hBPM)] = currentNote.Value;
                            }
                            NoteStrings[Information.UBound(NoteStrings)] = Interaction.IIf(this.BPMx1296, iBMSC.Editor.Functions.C10to36(Conversions.ToLong(BpmIndex)), Strings.Mid("0" + Conversion.Hex(BpmIndex), Strings.Len(Conversion.Hex(BpmIndex))));
                        }
                        else if (CurrentBMSChannel == "09") // If STOP
                        {
                            object StopIndex;
                            var loopTo2 = Information.UBound(this.hSTOP);
                            for (StopIndex = 1; StopIndex <= loopTo2; StopIndex++) // find STOP value in existing array
                            {
                                if (currentNote.Value == this.hSTOP[Conversions.ToInteger(StopIndex)])
                                    break;
                            }

                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(StopIndex, Information.UBound(this.hSTOP), false))) // Didn't find it, add it
                            {
                                Array.Resize(ref this.hSTOP, Information.UBound(this.hSTOP) + 1 + 1);
                                this.hSTOP[Information.UBound(this.hSTOP)] = currentNote.Value;
                            }
                            NoteStrings[Information.UBound(NoteStrings)] = Interaction.IIf(this.STOPx1296, iBMSC.Editor.Functions.C10to36(Conversions.ToLong(StopIndex)), Strings.Mid("0" + Conversion.Hex(StopIndex), Strings.Len(Conversion.Hex(StopIndex))));
                        }
                        else if (CurrentBMSChannel == "SC") // If SCROLL
                        {
                            object ScrollIndex;
                            var loopTo3 = Information.UBound(this.hSCROLL);
                            for (ScrollIndex = 1; ScrollIndex <= loopTo3; ScrollIndex++) // find SCROLL value in existing array
                            {
                                if (currentNote.Value == this.hSCROLL[Conversions.ToInteger(ScrollIndex)])
                                    break;
                            }

                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(ScrollIndex, Information.UBound(this.hSCROLL), false))) // Didn't find it, add it
                            {
                                Array.Resize(ref this.hSCROLL, Information.UBound(this.hSCROLL) + 1 + 1);
                                this.hSCROLL[Information.UBound(this.hSCROLL)] = currentNote.Value;
                            }
                            NoteStrings[Information.UBound(NoteStrings)] = iBMSC.Editor.Functions.C10to36(Conversions.ToLong(ScrollIndex));
                        }
                        else
                        {
                            NoteStrings[Information.UBound(NoteStrings)] = iBMSC.Editor.Functions.C10to36(currentNote.Value / 10000L);
                        }
                    }
                }

                if (relativeMeasurePos.Length == 0)
                    continue;

                double xGCD = this.MeasureLength[MeasureIndex];
                for (int i = 0, loopTo4 = Information.UBound(relativeMeasurePos); i <= loopTo4; i++)        // find greatest common divisor
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(relativeMeasurePos[i], 0, false)))
                        xGCD = this.GCD(xGCD, Conversions.ToDouble(relativeMeasurePos[i]));
                }

                string[] xStrKey;
                xStrKey = new string[((int)Math.Round(this.MeasureLength[MeasureIndex] / xGCD))];
                for (int i = 0, loopTo5 = Information.UBound(xStrKey); i <= loopTo5; i++)           // assign 00 to all keys
                    xStrKey[i] = "00";

                for (int i = 0, loopTo6 = Information.UBound(relativeMeasurePos); i <= loopTo6; i++)        // assign K texts
                {
                    if (Conversions.ToInteger(Operators.DivideObject(relativeMeasurePos[i], xGCD)) > Information.UBound(xStrKey))
                    {
                        Array.Resize(ref xprevNotes, Information.UBound(xprevNotes) + 1 + 1);
                        {
                            ref var withBlock = ref xprevNotes[Information.UBound(xprevNotes)];
                            withBlock.ColumnIndex = this.BMSChannelToColumn(BMSChannelList[Conversions.ToInteger(CurrentBMSChannel)]);
                            withBlock.LongNote = iBMSC.BMS.IsChannelLongNote(BMSChannelList[Conversions.ToInteger(CurrentBMSChannel)]);
                            withBlock.Hidden = iBMSC.BMS.IsChannelHidden(BMSChannelList[Conversions.ToInteger(CurrentBMSChannel)]);
                            withBlock.VPosition = this.MeasureBottom[MeasureIndex];
                            withBlock.Value = (long)iBMSC.Editor.Functions.C36to10(Conversions.ToString(NoteStrings[i]));
                        }
                        if (BMSChannelList[Conversions.ToInteger(CurrentBMSChannel)] == "08")
                            xprevNotes[Information.UBound(xprevNotes)].Value = Conversions.ToLong(Interaction.IIf(this.BPMx1296, (object)this.hBPM[iBMSC.Editor.Functions.C36to10(Conversions.ToString(NoteStrings[i]))], (object)this.hBPM[Convert.ToInt32(Conversions.ToString(NoteStrings[i]), 16)]));
                        if (BMSChannelList[Conversions.ToInteger(CurrentBMSChannel)] == "09")
                            xprevNotes[Information.UBound(xprevNotes)].Value = Conversions.ToLong(Interaction.IIf(this.STOPx1296, (object)this.hSTOP[iBMSC.Editor.Functions.C36to10(Conversions.ToString(NoteStrings[i]))], (object)this.hSTOP[Convert.ToInt32(Conversions.ToString(NoteStrings[i]), 16)]));
                        if (BMSChannelList[Conversions.ToInteger(CurrentBMSChannel)] == "SC")
                            xprevNotes[Information.UBound(xprevNotes)].Value = this.hSCROLL[iBMSC.Editor.Functions.C36to10(Conversions.ToString(NoteStrings[i]))];
                        continue;
                    }
                    if (xStrKey[Conversions.ToInteger(Operators.DivideObject(relativeMeasurePos[i], xGCD))] != "00")
                    {
                        hasOverlapping = true;
                    }

                    xStrKey[Conversions.ToInteger(Operators.DivideObject(relativeMeasurePos[i], xGCD))] = Conversions.ToString(NoteStrings[i]);
                }

                Ret += "#" + iBMSC.Editor.Functions.Add3Zeros(MeasureIndex) + CurrentBMSChannel + ":" + Strings.Join(xStrKey, "") + Constants.vbCrLf;
            }

            return Ret;
        }

        private string GenerateBackgroundTracks(int MeasureIndex, ref bool hasOverlapping, iBMSC.Editor.Note[] NotesInMeasure, int GreatestColumn, ref iBMSC.Editor.Note[] xprevNotes)
        {
            double[] relativeNotePositions; // Ks in the same column
            string[] noteStrings;    // Ks in the same column
            string Ret = "";

            for (int ColIndex = MainWindow.niB, loopTo = GreatestColumn; ColIndex <= loopTo; ColIndex++) // Start rendering B notes (xI3 is columnindex)
            {
                relativeNotePositions = new double[0]; // Ks in the same column
                noteStrings = new string[0];      // Ks in the same column

                for (int I = 0, loopTo1 = Information.UBound(NotesInMeasure); I <= loopTo1; I++) // Find Ks in the same column (xI4 is TK index)
                {
                    if (NotesInMeasure[I].ColumnIndex == ColIndex)
                    {

                        Array.Resize(ref relativeNotePositions, Information.UBound(relativeNotePositions) + 1 + 1);
                        Array.Resize(ref noteStrings, Information.UBound(noteStrings) + 1 + 1);

                        relativeNotePositions[Information.UBound(relativeNotePositions)] = NotesInMeasure[I].VPosition - this.MeasureBottom[this.MeasureAtDisplacement(NotesInMeasure[I].VPosition)];
                        if (relativeNotePositions[Information.UBound(relativeNotePositions)] < 0d)
                            relativeNotePositions[Information.UBound(relativeNotePositions)] = 0d;

                        noteStrings[Information.UBound(noteStrings)] = iBMSC.Editor.Functions.C10to36(NotesInMeasure[I].Value / 10000L);
                    }
                }

                double xGCD = this.MeasureLength[MeasureIndex];
                for (int i = 0, loopTo2 = Information.UBound(relativeNotePositions); i <= loopTo2; i++)        // find greatest common divisor
                {
                    if (relativeNotePositions[i] > 0d)
                        xGCD = this.GCD(xGCD, relativeNotePositions[i]);
                }

                var xStrKey = new string[((int)Math.Round(this.MeasureLength[MeasureIndex] / xGCD))];
                for (int i = 0, loopTo3 = Information.UBound(xStrKey); i <= loopTo3; i++)           // assign 00 to all keys
                    xStrKey[i] = "00";

                for (int i = 0, loopTo4 = Information.UBound(relativeNotePositions); i <= loopTo4; i++)        // assign K texts
                {
                    if ((int)Math.Round(relativeNotePositions[i] / xGCD) > Information.UBound(xStrKey))
                    {

                        Array.Resize(ref xprevNotes, Information.UBound(xprevNotes) + 1 + 1);

                        {
                            ref var withBlock = ref xprevNotes[Information.UBound(xprevNotes)];
                            withBlock.ColumnIndex = ColIndex;
                            withBlock.VPosition = this.MeasureBottom[MeasureIndex];
                            withBlock.Value = (long)iBMSC.Editor.Functions.C36to10(noteStrings[i]);
                        }

                        continue;
                    }
                    if (xStrKey[(int)Math.Round(relativeNotePositions[i] / xGCD)] != "00")
                        hasOverlapping = true;
                    xStrKey[(int)Math.Round(relativeNotePositions[i] / xGCD)] = noteStrings[i];
                }

                Ret += "#" + iBMSC.Editor.Functions.Add3Zeros(MeasureIndex) + "01:" + Strings.Join(xStrKey, "") + Constants.vbCrLf;
            }

            return Ret;
        }

        private bool OpenSM(string xStrAll)
        {
            this.KMouseOver = -1;

            var xStrLine = Strings.Split(xStrAll, Constants.vbCrLf);
            // Remove comments starting with "//"
            for (int xI1 = 0, loopTo = Information.UBound(xStrLine); xI1 <= loopTo; xI1++)
            {
                if (xStrLine[xI1].Contains("//"))
                    xStrLine[xI1] = Strings.Mid(xStrLine[xI1], 1, Strings.InStr(xStrLine[xI1], "//") - 1);
            }

            xStrAll = Strings.Join(xStrLine, "");
            xStrLine = Strings.Split(xStrAll, ";");

            int iDiff = 0;
            int iCurrentDiff = 0;
            var xTempSplit = Strings.Split(xStrAll, "#NOTES:");
            var xTempStr = Array.Empty<string>();
            if (xTempSplit.Length > 2)
            {
                Array.Resize(ref xTempStr, Information.UBound(xTempSplit));
                for (int xI1 = 1, loopTo1 = Information.UBound(xTempSplit); xI1 <= loopTo1; xI1++)
                {
                    xTempSplit[xI1] = Strings.Mid(xTempSplit[xI1], Strings.InStr(xTempSplit[xI1], ":") + 1);
                    xTempSplit[xI1] = Strings.Mid(xTempSplit[xI1], Strings.InStr(xTempSplit[xI1], ":") + 1).Trim();
                    xTempStr[xI1 - 1] = Strings.Mid(xTempSplit[xI1], 1, Strings.InStr(xTempSplit[xI1], ":") - 1);
                    xTempSplit[xI1] = Strings.Mid(xTempSplit[xI1], Strings.InStr(xTempSplit[xI1], ":") + 1).Trim();
                    xTempStr[xI1 - 1] += " : " + Strings.Mid(xTempSplit[xI1], 1, Strings.InStr(xTempSplit[xI1], ":") - 1);
                }

                var xDiag = new iBMSC.dgImportSM(xTempStr);
                if (xDiag.ShowDialog() == DialogResult.Cancel)
                    return true;
                iDiff = xDiag.iResult;
            }
            this.Notes = new iBMSC.Editor.Note[1];
            this.mColumn = new int[1000];
            this.hWAV = new string[1296];
            this.hBMP = new string[1296];
            this.hBPM = new long[1296];    // x10000
            this.hSTOP = new long[1296];
            this.hSCROLL = new long[1296];
            this.InitializeNewBMS();

            {
                ref var withBlock = ref this.Notes[0];
                withBlock.ColumnIndex = MainWindow.niBPM;
                withBlock.VPosition = (double)-1;
                // .LongNote = False
                // .Selected = False
                withBlock.Value = 1200000L;
            }

            foreach (var sL in xStrLine)
            {
                if (Strings.UCase(sL).StartsWith("#TITLE:"))
                {
                    this.THTitle.Text = Strings.Mid(sL, Strings.Len("#TITLE:") + 1);
                }

                else if (Strings.UCase(sL).StartsWith("#SUBTITLE:"))
                {
                    if (!Strings.UCase(sL).EndsWith("#SUBTITLE:"))
                        this.THTitle.Text += " " + Strings.Mid(sL, Strings.Len("#SUBTITLE:") + 1);
                }

                else if (Strings.UCase(sL).StartsWith("#ARTIST:"))
                {
                    this.THArtist.Text = Strings.Mid(sL, Strings.Len("#ARTIST:") + 1);
                }

                else if (Strings.UCase(sL).StartsWith("#GENRE:"))
                {
                    this.THGenre.Text = Strings.Mid(sL, Strings.Len("#GENRE:") + 1);
                }

                else if (Strings.UCase(sL).StartsWith("#BPMS:"))
                {
                    string xLine = Strings.Mid(sL, Strings.Len("#BPMS:") + 1);
                    var xItem = Strings.Split(xLine, ",");

                    double xVal1;
                    double xVal2;

                    for (int xI1 = 0, loopTo2 = Information.UBound(xItem); xI1 <= loopTo2; xI1++)
                    {
                        xVal1 = Conversions.ToDouble(Strings.Mid(xItem[xI1], 1, Strings.InStr(xItem[xI1], "=") - 1));
                        xVal2 = Conversions.ToDouble(Strings.Mid(xItem[xI1], Strings.InStr(xItem[xI1], "=") + 1));

                        if (xVal1 != 0d)
                        {
                            Array.Resize(ref this.Notes, this.Notes.Length + 1);
                            {
                                ref var withBlock1 = ref this.Notes[Information.UBound(this.Notes)];
                                withBlock1.ColumnIndex = MainWindow.niBPM;
                                // .LongNote = False
                                // .Hidden = False
                                // .Selected = False
                                withBlock1.VPosition = xVal1 * 48d;
                                withBlock1.Value = (long)Math.Round(xVal2 * 10000d);
                            }
                        }
                        else
                        {
                            this.Notes[0].Value = (long)Math.Round(xVal2 * 10000d);
                        }
                    }
                }

                else if (Strings.UCase(sL).StartsWith("#NOTES:"))
                {
                    if (iCurrentDiff != iDiff)
                    {
                        iCurrentDiff += 1;
                        goto Jump1;
                    }

                    iCurrentDiff += 1;
                    string xLine = Strings.Mid(sL, Strings.Len("#NOTES:") + 1);
                    var xItem = Strings.Split(xLine, ":");
                    for (int xI1 = 0, loopTo3 = Information.UBound(xItem); xI1 <= loopTo3; xI1++)
                        xItem[xI1] = xItem[xI1].Trim();

                    if (xItem.Length != 6)
                        goto Jump1;

                    this.THPlayLevel.Text = xItem[3];

                    var xM = Strings.Split(xItem[5], ",");
                    for (int xI1 = 0, loopTo4 = Information.UBound(xM); xI1 <= loopTo4; xI1++)
                        xM[xI1] = xM[xI1].Trim();

                    for (int xI1 = 0, loopTo5 = Information.UBound(xM); xI1 <= loopTo5; xI1++)
                    {
                        for (int xI2 = 0, loopTo6 = Strings.Len(xM[xI1]) - 1; xI2 <= loopTo6; xI2 += 4)
                        {
                            if (Conversions.ToString(xM[xI1][xI2]) != "0")
                            {
                                Array.Resize(ref this.Notes, this.Notes.Length + 1);
                                {
                                    ref var withBlock2 = ref this.Notes[Information.UBound(this.Notes)];
                                    withBlock2.ColumnIndex = MainWindow.niA1;
                                    withBlock2.LongNote = Conversions.ToString(xM[xI1][xI2]) == "2" | Conversions.ToString(xM[xI1][xI2]) == "3";
                                    // .Hidden = False
                                    // .Selected = False
                                    withBlock2.VPosition = (double)(192 / (Strings.Len(xM[xI1]) / 4) * xI2 / 4 + xI1 * 192);
                                    withBlock2.Value = 10000L;
                                }
                            }
                            if (Conversions.ToString(xM[xI1][xI2 + 1]) != "0")
                            {
                                Array.Resize(ref this.Notes, this.Notes.Length + 1);
                                {
                                    ref var withBlock3 = ref this.Notes[Information.UBound(this.Notes)];
                                    withBlock3.ColumnIndex = MainWindow.niA2;
                                    withBlock3.LongNote = Conversions.ToString(xM[xI1][xI2 + 1]) == "2" | Conversions.ToString(xM[xI1][xI2 + 1]) == "3";
                                    // .Hidden = False
                                    // .Selected = False
                                    withBlock3.VPosition = (double)(192 / (Strings.Len(xM[xI1]) / 4) * xI2 / 4 + xI1 * 192);
                                    withBlock3.Value = 10000L;
                                }
                            }
                            if (Conversions.ToString(xM[xI1][xI2 + 2]) != "0")
                            {
                                Array.Resize(ref this.Notes, this.Notes.Length + 1);
                                {
                                    ref var withBlock4 = ref this.Notes[Information.UBound(this.Notes)];
                                    withBlock4.ColumnIndex = MainWindow.niA3;
                                    withBlock4.LongNote = Conversions.ToString(xM[xI1][xI2 + 2]) == "2" | Conversions.ToString(xM[xI1][xI2 + 2]) == "3";
                                    // .Hidden = False
                                    // .Selected = False
                                    withBlock4.VPosition = (double)(192 / (Strings.Len(xM[xI1]) / 4) * xI2 / 4 + xI1 * 192);
                                    withBlock4.Value = 10000L;
                                }
                            }
                            if (Conversions.ToString(xM[xI1][xI2 + 3]) != "0")
                            {
                                Array.Resize(ref this.Notes, this.Notes.Length + 1);
                                {
                                    ref var withBlock5 = ref this.Notes[Information.UBound(this.Notes)];
                                    withBlock5.ColumnIndex = MainWindow.niA4;
                                    withBlock5.LongNote = Conversions.ToString(xM[xI1][xI2 + 3]) == "2" | Conversions.ToString(xM[xI1][xI2 + 3]) == "3";
                                    // .Hidden = False
                                    // .Selected = False
                                    withBlock5.VPosition = (double)(192 / (Strings.Len(xM[xI1]) / 4) * xI2 / 4 + xI1 * 192);
                                    withBlock5.Value = 10000L;
                                }
                            }
                        }
                    }

                Jump1:
                    ;

                }
            }

            if (this.NTInput)
                this.ConvertBMSE2NT();

            this.LWAV.Visible = false;
            this.LWAV.Items.Clear();
            this.LBMP.Visible = false;
            this.LBMP.Items.Clear();
            for (int xI1 = 1; xI1 <= 1295; xI1++)
            {
                this.LWAV.Items.Add(iBMSC.Editor.Functions.C10to36((long)xI1) + ": " + this.hWAV[xI1]);
                this.LBMP.Items.Add(iBMSC.Editor.Functions.C10to36((long)xI1) + ": " + this.hBMP[xI1]);
            }
            this.LWAV.SelectedIndex = 0;
            this.LWAV.Visible = true;
            this.LBMP.SelectedIndex = 0;
            this.LBMP.Visible = true;

            this.THBPM.Value = (decimal)((double)this.Notes[0].Value / 10000d);
            this.SortByVPositionQuick(0, Information.UBound(this.Notes));
            this.UpdatePairing();
            this.CalculateTotalPlayableNotes();
            this.CalculateGreatestVPosition();
            this.RefreshPanelAll();
            this.POStatusRefresh();
            return false;
        }

        /// <summary>Do not clear Undo.</summary>
        private void OpeniBMSC(string Path)
        {
            this.KMouseOver = -1;

            var br = new BinaryReader(new FileStream(Path, FileMode.Open, FileAccess.Read), System.Text.Encoding.Unicode);

            if (br.ReadInt32() != 0x534D4269)
                goto EndOfSub;
            if (br.ReadByte() != 0x43)
                goto EndOfSub;
            int xMajor = br.ReadByte();
            int xMinor = br.ReadByte();
            int xBuild = br.ReadByte();

            this.ClearUndo();
            this.Notes = new iBMSC.Editor.Note[1];
            this.mColumn = new int[1000];
            this.hWAV = new string[1296];
            this.hBMP = new string[1296];
            this.InitializeNewBMS();
            this.InitializeOpenBMS();

            {
                ref var withBlock = ref this.Notes[0];
                withBlock.ColumnIndex = MainWindow.niBPM;
                withBlock.VPosition = (double)-1;
                // .LongNote = False
                // .Selected = False
                withBlock.Value = 1200000L;
            }

            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                int BlockID = br.ReadInt32();

                switch (BlockID)
                {

                    case 0x66657250:     // Preferences
                        {
                            int xPref = br.ReadInt32();

                            this.NTInput = Conversions.ToBoolean(xPref & 0x1);
                            this.TBNTInput.Checked = this.NTInput;
                            this.mnNTInput.Checked = this.NTInput;
                            this.POBLong.Enabled = !this.NTInput;
                            this.POBLongShort.Enabled = !this.NTInput;

                            this.ErrorCheck = Conversions.ToBoolean(xPref & 0x2);
                            this.TBErrorCheck.Checked = this.ErrorCheck;
                            this.TBErrorCheck_Click(this.TBErrorCheck, new EventArgs());

                            this.PreviewOnClick = Conversions.ToBoolean(xPref & 0x4);
                            this.TBPreviewOnClick.Checked = this.PreviewOnClick;
                            this.TBPreviewOnClick_Click(this.TBPreviewOnClick, new EventArgs());

                            this.ShowFileName = Conversions.ToBoolean(xPref & 0x8);
                            this.TBShowFileName.Checked = this.ShowFileName;
                            this.TBShowFileName_Click(this.TBShowFileName, new EventArgs());

                            this.mnSMenu.Checked = Conversions.ToBoolean(xPref & 0x100);
                            this.mnSTB.Checked = Conversions.ToBoolean(xPref & 0x200);
                            this.mnSOP.Checked = Conversions.ToBoolean(xPref & 0x400);
                            this.mnSStatus.Checked = Conversions.ToBoolean(xPref & 0x800);
                            this.mnSLSplitter.Checked = Conversions.ToBoolean(xPref & 0x1000);
                            this.mnSRSplitter.Checked = Conversions.ToBoolean(xPref & 0x2000);

                            this.CGShow.Checked = Conversions.ToBoolean(xPref & 0x4000);
                            this.CGShowS.Checked = Conversions.ToBoolean(xPref & 0x8000);
                            this.CGShowBG.Checked = Conversions.ToBoolean(xPref & 0x10000);
                            this.CGShowM.Checked = Conversions.ToBoolean(xPref & 0x20000);
                            this.CGShowMB.Checked = Conversions.ToBoolean(xPref & 0x40000);
                            this.CGShowV.Checked = Conversions.ToBoolean(xPref & 0x80000);
                            this.CGShowC.Checked = Conversions.ToBoolean(xPref & 0x100000);
                            this.CGBLP.Checked = Conversions.ToBoolean(xPref & 0x200000);
                            this.CGSTOP.Checked = Conversions.ToBoolean(xPref & 0x400000);
                            this.CGSCROLL.Checked = Conversions.ToBoolean(xPref & 0x20000000);
                            this.CGBPM.Checked = Conversions.ToBoolean(xPref & 0x800000);

                            this.CGSnap.Checked = Conversions.ToBoolean(xPref & 0x1000000);
                            this.CGDisableVertical.Checked = Conversions.ToBoolean(xPref & 0x2000000);
                            this.cVSLockL.Checked = Conversions.ToBoolean(xPref & 0x4000000);
                            this.cVSLock.Checked = Conversions.ToBoolean(xPref & 0x8000000);
                            this.cVSLockR.Checked = Conversions.ToBoolean(xPref & 0x10000000);

                            this.CGDivide.Value = (decimal)br.ReadInt32();
                            this.CGSub.Value = (decimal)br.ReadInt32();
                            this.gSlash = br.ReadInt32();
                            this.CGHeight.Value = (decimal)br.ReadSingle();
                            this.CGWidth.Value = (decimal)br.ReadSingle();
                            this.CGB.Value = (decimal)br.ReadInt32();
                            break;
                        }

                    case 0x64616548:     // Header
                        {
                            this.THTitle.Text = br.ReadString();
                            this.THArtist.Text = br.ReadString();
                            this.THGenre.Text = br.ReadString();
                            this.Notes[0].Value = br.ReadInt64();
                            int xPlayerRank = br.ReadByte();
                            this.THPlayLevel.Text = br.ReadString();

                            this.CHPlayer.SelectedIndex = xPlayerRank & 0xF;
                            this.CHRank.SelectedIndex = xPlayerRank >> 4;

                            this.THSubTitle.Text = br.ReadString();
                            this.THSubArtist.Text = br.ReadString();
                            // THMaker.Text = br.ReadString
                            this.THStageFile.Text = br.ReadString();
                            this.THBanner.Text = br.ReadString();
                            this.THBackBMP.Text = br.ReadString();
                            // THMidiFile.Text = br.ReadString
                            this.CHDifficulty.SelectedIndex = (int)br.ReadByte();
                            this.THExRank.Text = br.ReadString();
                            this.THTotal.Text = br.ReadString();
                            // THVolWAV.Text = br.ReadString
                            this.THComment.Text = br.ReadString();
                            // THLnType.Text = br.ReadString
                            this.CHLnObj.SelectedIndex = (int)br.ReadInt16();
                            break;
                        }

                    case 0x564157:       // WAV List
                        {
                            int xWAVOptions = br.ReadByte();
                            this.WAVMultiSelect = Conversions.ToBoolean(xWAVOptions & 0x1);
                            this.CWAVMultiSelect.Checked = this.WAVMultiSelect;
                            this.CWAVMultiSelect_CheckedChanged(this.CWAVMultiSelect, new EventArgs());
                            this.WAVChangeLabel = Conversions.ToBoolean(xWAVOptions & 0x2);
                            this.CWAVChangeLabel.Checked = this.WAVChangeLabel;
                            this.CWAVChangeLabel_CheckedChanged(this.CWAVChangeLabel, new EventArgs());

                            int xWAVCount = br.ReadInt32();
                            for (int xxi = 1, loopTo = xWAVCount; xxi <= loopTo; xxi++)
                            {
                                int xI = br.ReadInt16();
                                this.hWAV[xI] = br.ReadString();
                            }

                            break;
                        }

                    case 0x504D42:       // BMP List
                        {

                            int xBMPCount = br.ReadInt32();
                            for (int xxi = 1, loopTo1 = xBMPCount; xxi <= loopTo1; xxi++)
                            {
                                int xI = br.ReadInt16();
                                this.hBMP[xI] = br.ReadString();
                            }

                            break;
                        }

                    case 0x74616542:     // Beat
                        {
                            this.nBeatN.Value = (decimal)br.ReadInt16();
                            this.nBeatD.Value = (decimal)br.ReadInt16();
                            // nBeatD.SelectedIndex = br.ReadByte

                            int xBeatChangeMode = br.ReadByte();
                            var xBeatChangeList = new[] { this.CBeatPreserve, this.CBeatMeasure, this.CBeatCut, this.CBeatScale };
                            xBeatChangeList[xBeatChangeMode].Checked = true;
                            this.CBeatPreserve_Click(xBeatChangeList[xBeatChangeMode], new EventArgs());

                            int xBeatCount = br.ReadInt32();
                            for (int xxi = 1, loopTo2 = xBeatCount; xxi <= loopTo2; xxi++)
                            {
                                int xIndex = br.ReadInt16();
                                this.MeasureLength[xIndex] = br.ReadDouble();
                                double xRatio = this.MeasureLength[xIndex] / 192.0d;
                                long xxD = iBMSC.Editor.Functions.GetDenominator(xRatio);
                                this.LBeat.Items[xIndex] = Operators.ConcatenateObject(iBMSC.Editor.Functions.Add3Zeros(xIndex) + ": " + xRatio, Interaction.IIf(xxD > 10000L, "", " ( " + (long)Math.Round(xRatio * xxD) + " / " + xxD + " ) "));
                            }

                            break;
                        }

                    case 0x6E707845:     // Expansion Code
                        {
                            this.TExpansion.Text = br.ReadString();
                            break;
                        }

                    case 0x65746F4E:     // Note
                        {
                            int xNoteUbound = br.ReadInt32();
                            Array.Resize(ref this.Notes, xNoteUbound + 1);
                            for (int i = 1, loopTo3 = Information.UBound(this.Notes); i <= loopTo3; i++)
                                this.Notes[i].FromBinReader(ref br);
                            break;
                        }

                    case 0x6F646E55:     // Undo / Redo Commands
                        {
                            int URCount = br.ReadInt32();   // Should be 100
                            this.sI = br.ReadInt32();

                            for (int xI = 0; xI <= 99; xI++)
                            {
                                int xUndoCount = br.ReadInt32();
                                var xBaseUndo = new iBMSC.UndoRedo.Void();
                                iBMSC.UndoRedo.LinkedURCmd xIteratorUndo = xBaseUndo;

                                for (int xxj = 1, loopTo4 = xUndoCount; xxj <= loopTo4; xxj++)
                                {
                                    int xByteLen = br.ReadInt32();
                                    var xByte = br.ReadBytes(xByteLen);
                                    xIteratorUndo.Next = iBMSC.UndoRedo.fromBytes(xByte);
                                    xIteratorUndo = xIteratorUndo.Next;
                                }

                                this.sUndo[xI] = xBaseUndo.Next;

                                int xRedoCount = br.ReadInt32();
                                var xBaseRedo = new iBMSC.UndoRedo.Void();
                                iBMSC.UndoRedo.LinkedURCmd xIteratorRedo = xBaseRedo;
                                for (int xxj = 1, loopTo5 = xRedoCount; xxj <= loopTo5; xxj++)
                                {
                                    int xByteLen = br.ReadInt32();
                                    var xByte = br.ReadBytes(xByteLen);
                                    xIteratorRedo.Next = iBMSC.UndoRedo.fromBytes(xByte);
                                    xIteratorRedo = xIteratorRedo.Next;
                                }
                                this.sRedo[xI] = xBaseRedo.Next;
                            }

                            break;
                        }

                }
            }

        EndOfSub:
            ;

            br.Close();

            this.TBUndo.Enabled = this.sUndo[this.sI].ofType() != iBMSC.UndoRedo.opNoOperation;
            this.TBRedo.Enabled = this.sRedo[this.sIA()].ofType() != iBMSC.UndoRedo.opNoOperation;
            this.mnUndo.Enabled = this.sUndo[this.sI].ofType() != iBMSC.UndoRedo.opNoOperation;
            this.mnRedo.Enabled = this.sRedo[this.sIA()].ofType() != iBMSC.UndoRedo.opNoOperation;

            this.LBMP.Visible = false;
            this.LBMP.Items.Clear();
            this.LWAV.Visible = false;
            this.LWAV.Items.Clear();
            for (int xI1 = 1; xI1 <= 1295; xI1++)
            {
                this.LWAV.Items.Add(iBMSC.Editor.Functions.C10to36((long)xI1) + ": " + this.hWAV[xI1]);
                this.LBMP.Items.Add(iBMSC.Editor.Functions.C10to36((long)xI1) + ": " + this.hBMP[xI1]);
            }
            this.LWAV.SelectedIndex = 0;
            this.LWAV.Visible = true;
            this.LBMP.SelectedIndex = 0;
            this.LBMP.Visible = true;

            this.THBPM.Value = (decimal)((double)this.Notes[0].Value / 10000d);
            this.SortByVPositionQuick(0, Information.UBound(this.Notes));
            this.UpdatePairing();
            this.UpdateMeasureBottom();
            this.CalculateTotalPlayableNotes();
            this.CalculateGreatestVPosition();
            this.RefreshPanelAll();
            this.POStatusRefresh();
        }

        private void SaveiBMSC(string Path)
        {
            this.CalculateGreatestVPosition();
            this.SortByVPositionInsertion();
            this.UpdatePairing();

            try
            {

                var bw = new BinaryWriter(new FileStream(Path, FileMode.Create), System.Text.Encoding.Unicode);

                // bw.Write("iBMSC".ToCharArray)
                bw.Write(0x534D4269);
                bw.Write((byte)0x43);
                bw.Write((byte)iBMSC.My.MyProject.Application.Info.Version.Major);
                bw.Write((byte)iBMSC.My.MyProject.Application.Info.Version.Minor);
                bw.Write((byte)iBMSC.My.MyProject.Application.Info.Version.Build);

                // Preferences
                // bw.Write("Pref".ToCharArray)
                bw.Write(0x66657250);
                int xPref = 0;
                if (this.NTInput)
                    xPref = xPref | 0x1;
                if (this.ErrorCheck)
                    xPref = xPref | 0x2;
                if (this.PreviewOnClick)
                    xPref = xPref | 0x4;
                if (this.ShowFileName)
                    xPref = xPref | 0x8;
                if (this.mnSMenu.Checked)
                    xPref = xPref | 0x100;
                if (this.mnSTB.Checked)
                    xPref = xPref | 0x200;
                if (this.mnSOP.Checked)
                    xPref = xPref | 0x400;
                if (this.mnSStatus.Checked)
                    xPref = xPref | 0x800;
                if (this.mnSLSplitter.Checked)
                    xPref = xPref | 0x1000;
                if (this.mnSRSplitter.Checked)
                    xPref = xPref | 0x2000;
                if (this.gShowGrid)
                    xPref = xPref | 0x4000;
                if (this.gShowSubGrid)
                    xPref = xPref | 0x8000;
                if (this.gShowBG)
                    xPref = xPref | 0x10000;
                if (this.gShowMeasureNumber)
                    xPref = xPref | 0x20000;
                if (this.gShowMeasureBar)
                    xPref = xPref | 0x40000;
                if (this.gShowVerticalLine)
                    xPref = xPref | 0x80000;
                if (this.gShowC)
                    xPref = xPref | 0x100000;
                if (this.gDisplayBGAColumn)
                    xPref = xPref | 0x200000;
                if (this.gSTOP)
                    xPref = xPref | 0x400000;
                if (this.gBPM)
                    xPref = xPref | 0x800000;
                if (this.gSCROLL)
                    xPref = xPref | 0x20000000;
                if (this.gSnap)
                    xPref = xPref | 0x1000000;
                if (this.DisableVerticalMove)
                    xPref = xPref | 0x2000000;
                if (this.spLock[0])
                    xPref = xPref | 0x4000000;
                if (this.spLock[1])
                    xPref = xPref | 0x8000000;
                if (this.spLock[2])
                    xPref = xPref | 0x10000000;
                bw.Write(xPref);
                bw.Write(BitConverter.GetBytes(this.gDivide));
                bw.Write(BitConverter.GetBytes(this.gSub));
                bw.Write(BitConverter.GetBytes(this.gSlash));
                bw.Write(BitConverter.GetBytes(this.gxHeight));
                bw.Write(BitConverter.GetBytes(this.gxWidth));
                bw.Write(BitConverter.GetBytes(this.gColumns));

                // Header
                // bw.Write("Head".ToCharArray)
                bw.Write(0x64616548);
                bw.Write(this.THTitle.Text);
                bw.Write(this.THArtist.Text);
                bw.Write(this.THGenre.Text);
                bw.Write(this.Notes[0].Value);
                int xPlayer = this.CHPlayer.SelectedIndex;
                int xRank = this.CHRank.SelectedIndex << 4;
                bw.Write((byte)(xPlayer | xRank));
                bw.Write(this.THPlayLevel.Text);

                bw.Write(this.THSubTitle.Text);
                bw.Write(this.THSubArtist.Text);
                // bw.Write(THMaker.Text)
                bw.Write(this.THStageFile.Text);
                bw.Write(this.THBanner.Text);
                bw.Write(this.THBackBMP.Text);
                // bw.Write(THMidiFile.Text)
                bw.Write((byte)this.CHDifficulty.SelectedIndex);
                bw.Write(this.THExRank.Text);
                bw.Write(this.THTotal.Text);
                // bw.Write(THVolWAV.Text)
                bw.Write(this.THComment.Text);
                // bw.Write(THLnType.Text)
                bw.Write((short)this.CHLnObj.SelectedIndex);

                // Wav List
                // bw.Write(("WAV" & vbNullChar).ToCharArray)
                bw.Write(0x564157);

                int xWAVOptions = 0;
                if (this.WAVMultiSelect)
                    xWAVOptions = xWAVOptions | 0x1;
                if (this.WAVChangeLabel)
                    xWAVOptions = xWAVOptions | 0x2;
                bw.Write((byte)xWAVOptions);

                int xWAVCount = 0;
                for (int i = 1, loopTo = Information.UBound(this.hWAV); i <= loopTo; i++)
                {
                    if (!string.IsNullOrEmpty(this.hWAV[i]))
                        xWAVCount += 1;
                }
                bw.Write(xWAVCount);

                for (int i = 1, loopTo1 = Information.UBound(this.hWAV); i <= loopTo1; i++)
                {
                    if (string.IsNullOrEmpty(this.hWAV[i]))
                        continue;
                    bw.Write((short)i);
                    bw.Write(this.hWAV[i]);
                }

                // Bmp List
                // bw.Write(("BMP" & vbNullChar).ToCharArray)
                bw.Write(0x504D42);

                int xBMPCount = 0;
                for (int i = 1, loopTo2 = Information.UBound(this.hBMP); i <= loopTo2; i++)
                {
                    if (!string.IsNullOrEmpty(this.hBMP[i]))
                        xBMPCount += 1;
                }
                bw.Write(xBMPCount);

                for (int i = 1, loopTo3 = Information.UBound(this.hBMP); i <= loopTo3; i++)
                {
                    if (string.IsNullOrEmpty(this.hBMP[i]))
                        continue;
                    bw.Write((short)i);
                    bw.Write(this.hBMP[i]);
                }

                // Beat
                // bw.Write("Beat".ToCharArray)
                bw.Write(0x74616542);
                // Dim xNumerator As Short = nBeatN.Value
                // Dim xDenominator As Short = nBeatD.Value
                // Dim xBeatChangeMode As Byte = BeatChangeMode
                bw.Write((short)Math.Round(this.nBeatN.Value));
                bw.Write((short)Math.Round(this.nBeatD.Value));
                bw.Write((byte)this.BeatChangeMode);

                int xBeatCount = 0;
                for (int i = 0, loopTo4 = Information.UBound(this.MeasureLength); i <= loopTo4; i++)
                {
                    if (this.MeasureLength[i] != 192.0d)
                        xBeatCount += 1;
                }
                bw.Write(xBeatCount);

                for (int i = 0, loopTo5 = Information.UBound(this.MeasureLength); i <= loopTo5; i++)
                {
                    if (this.MeasureLength[i] == 192.0d)
                        continue;
                    bw.Write((short)i);
                    bw.Write(this.MeasureLength[i]);
                }

                // Expansion Code
                // bw.Write("Expn".ToCharArray)
                bw.Write(0x6E707845);
                bw.Write(this.TExpansion.Text);

                // Note
                // bw.Write("Note".ToCharArray)
                bw.Write(0x65746F4E);
                bw.Write(Information.UBound(this.Notes));
                for (int i = 1, loopTo6 = Information.UBound(this.Notes); i <= loopTo6; i++)
                    this.Notes[i].WriteBinWriter(ref bw);

                // Undo / Redo Commands
                // bw.Write("Undo".ToCharArray)
                bw.Write(0x6F646E55);
                bw.Write(100);
                bw.Write(this.sI);

                for (int i = 0; i <= 99; i++)
                {
                    // UndoCommandsCount
                    int countUndo = 0;
                    var pUndo = this.sUndo[i];
                    while (pUndo is not null)
                    {
                        countUndo += 1;
                        pUndo = pUndo.Next;
                    }
                    bw.Write(countUndo);

                    // UndoCommands
                    pUndo = this.sUndo[i];
                    for (int xxi = 1, loopTo7 = countUndo; xxi <= loopTo7; xxi++)
                    {
                        var bUndo = pUndo.toBytes();
                        bw.Write(bUndo.Length);  // Length
                        bw.Write(bUndo);         // Command
                        pUndo = pUndo.Next;
                    }

                    // RedoCommandsCount
                    int countRedo = 0;
                    var pRedo = this.sRedo[i];
                    while (pRedo is not null)
                    {
                        countRedo += 1;
                        pRedo = pRedo.Next;
                    }
                    bw.Write(countRedo);

                    // RedoCommands
                    pRedo = this.sRedo[i];
                    for (int xxi = 1, loopTo8 = countRedo; xxi <= loopTo8; xxi++)
                    {
                        var bRedo = pRedo.toBytes();
                        bw.Write(bRedo.Length);
                        bw.Write(bRedo);
                        pRedo = pRedo.Next;
                    }
                }

                bw.Close();
            }

            catch (Exception ex)
            {

                Interaction.MsgBox(ex.Message);

            }

        }

    }
}