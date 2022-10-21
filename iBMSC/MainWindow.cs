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
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using CSCore;
using CSCore.Codecs;
using iBMSC.Editor;
using iBMSC.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace iBMSC;

[DesignerGenerated]
public partial class MainWindow : Form
{
    public struct PlayerArguments
    {
        public string Path;

        public string aBegin;

        public string aHere;

        public string aStop;

        public PlayerArguments(string xPath, string xBegin, string xHere, string xStop)
        {
            this = default(PlayerArguments);
            Path = xPath;
            aBegin = xBegin;
            aHere = xHere;
            aStop = xStop;
        }
    }

    [CompilerGenerated]
    internal class _Closure_0024__1
    {
        public double _0024VB_0024Local_duration;

        public double _0024VB_0024Local_notevpos;

        public _Closure_0024__1(_Closure_0024__1 other)
        {
            if (other != null)
            {
                _0024VB_0024Local_duration = other._0024VB_0024Local_duration;
                _0024VB_0024Local_notevpos = other._0024VB_0024Local_notevpos;
            }
        }
    }

    private readonly string[] BMSChannelList;
    

    private double[] MeasureLength;

    private double[] MeasureBottom;

    private Note[] Notes;

    private int[] mColumn;

    private double GreatestVPosition;

    private int VSValue;

    private int HSValue;

    private int MiddleButtonMoveMethod;

    private Encoding TextEncoding;

    private string DispLang;

    private string[] Recent;

    private bool NTInput;

    private bool ShowFileName;

    private bool BeepWhileSaved;

    private bool BPMx1296;

    private bool STOPx1296;

    private bool IsInitializing;

    private bool FirstMouseEnter;

    private bool WAVMultiSelect;

    private bool WAVChangeLabel;

    private int BeatChangeMode;

    private double BMSGridLimit;

    private int LnObj;

    private string FileName;

    private string InitPath;

    private bool IsSaved;

    private string[] DDFileName;

    private string[] SupportedFileExtension;

    private string[] SupportedAudioExtension;

    private UndoRedo.LinkedURCmd[] sUndo;

    private UndoRedo.LinkedURCmd[] sRedo;

    private int sI;

    private bool DisableVerticalMove;

    private int KMouseOver;

    private PointF LastMouseDownLocation;

    private PointF pMouseMove;

    private double deltaVPosition;

    private bool bAdjustLength;

    private bool bAdjustUpper;

    private bool bAdjustSingle;

    private int tempY;

    private int tempV;

    private int tempX;

    private int tempH;

    private Point MiddleButtonLocation;

    private bool MiddleButtonClicked;

    private Point MouseMoveStatus;

    private bool uAdded;

    private Note[] SelectedNotes;

    private bool ctrlPressed;

    private bool DuplicatedSelectedNotes;

    private bool ShouldDrawTempNote;

    private int SelectedColumn;

    private double TempVPosition;

    private double TempLength;

    private double vSelStart;

    private double vSelLength;

    private double vSelHalf;

    private int vSelMouseOverLine;

    private bool vSelAdjust;

    private Note[] vSelK;

    private double vSelPStart;

    private double vSelPLength;

    private double vSelPHalf;

    private bool isFullScreen;

    private FormWindowState previousWindowState;

    private Rectangle previousWindowPosition;

    private double menuVPosition;

    private int tempResize;

    private string PreviousAutoSavedFileName;

    private int AutoSaveInterval;

    private bool ErrorCheck;

    private string[] hWAV;

    private long[] hBPM;

    private long[] hSTOP;

    private long[] hSCROLL;

    private bool gSnap;

    private bool gShowGrid;

    private bool gShowSubGrid;

    private bool gShowBG;

    private bool gShowMeasureNumber;

    private bool gShowVerticalLine;

    private bool gShowMeasureBar;

    private bool gShowC;

    private int gDivide;

    private int gSub;

    private int gSlash;

    private float gxHeight;

    private float gxWidth;

    private int gWheel;

    private int gPgUpDn;

    private bool gDisplayBGAColumn;

    private bool gSCROLL;

    private bool gSTOP;

    private bool gBPM;

    private int iPlayer;

    private int gColumns;

    private visualSettings vo;

    public PlayerArguments[] pArgs;

    public int CurrentPlayer;

    private bool PreviewOnClick;

    private bool PreviewErrorCheck;

    private bool ClickStopPreview;

    private string[] pTempFileNames;

    private float[] PanelWidth;

    private int[] PanelHScroll;

    private int[] PanelVScroll;

    private bool[] spLock;

    private int[] spDiff;

    private int PanelFocus;

    private int spMouseOver;

    private bool AutoFocusMouseEnter;

    private bool FirstClickDisabled;

    private bool tempFirstMouseDown;

    private Panel[] spMain;

    private int fdriMesL;

    private int fdriMesU;

    private int fdriLblL;

    private int fdriLblU;

    private int fdriValL;

    private int fdriValU;

    private int[] fdriCol;

    private Dictionary<int, BufferedGraphics> bufferlist;

    private Dictionary<int, Rectangle> rectList;

    private object lastVPos;

    private object lastColumn;

    private float[] wWavL;

    private float[] wWavR;

    private bool wLock;

    private int wSampleRate;

    private double wPosition;

    private int wLeft;

    private int wWidth;

    private int wPrecision;

    private void OpenBMS(string xStrAll)
    {
        KMouseOver = -1;
        xStrAll = Microsoft.VisualBasic.Strings.Replace(Microsoft.VisualBasic.Strings.Replace(Microsoft.VisualBasic.Strings.Replace(xStrAll, "\n", "\r"), "\r\r", "\r"), "\r", "\r\n");
        var array = Microsoft.VisualBasic.Strings.Split(xStrAll, "\r\n", -1, CompareMethod.Text);
        var text = "";
        Notes = new Note[1];
        mColumn = new int[1000];
        hWAV = new string[1296];
        hBPM = new long[1296];
        hSTOP = new long[1296];
        hSCROLL = new long[1296];
        InitializeNewBMS();
        InitializeOpenBMS();
        var notes = Notes;
        var num = 0;
        notes[num].ColumnIndex = 2;
        notes[num].VPosition = -1.0;
        notes[num].Value = 1200000L;
        var num2 = 0;

        foreach (var text2 in array)
        {
            var text3 = text2.Trim();
            if (num2 <= 0)
            {
                if (text3.StartsWith("#") & (Operators.CompareString(Microsoft.VisualBasic.Strings.Mid(text3, 5, 3), "02:", TextCompare: false) == 0))
                {
                    var num3 = (int)Math.Round(Conversion.Val(Microsoft.VisualBasic.Strings.Mid(text3, 2, 3)));
                    var num4 = Conversion.Val(Microsoft.VisualBasic.Strings.Mid(text3, 8));
                    var denominator = Functions.GetDenominator(num4, 2147483647L);
                    MeasureLength[num3] = num4 * 192.0;
                    LBeat.Items[num3] = Operators.ConcatenateObject(string.Concat(Functions.Add3Zeros(num3) + ": ", Conversions.ToString(num4)), Interaction.IIf(denominator > 10000, "", " ( " + Conversions.ToString((long)Math.Round(num4 * denominator)) + " / " + Conversions.ToString(denominator) + " ) "));
                    continue;
                }
                if (text3.StartsWith("#WAV", StringComparison.CurrentCultureIgnoreCase))
                {
                    hWAV[Functions.C36to10(Microsoft.VisualBasic.Strings.Mid(text3, Microsoft.VisualBasic.Strings.Len("#WAV") + 1, 2))] = Microsoft.VisualBasic.Strings.Mid(text3, Microsoft.VisualBasic.Strings.Len("#WAV") + 4);
                    continue;
                }
                if (text3.StartsWith("#BPM", StringComparison.CurrentCultureIgnoreCase) & (Operators.CompareString(Microsoft.VisualBasic.Strings.Mid(text3, Microsoft.VisualBasic.Strings.Len("#BPM") + 1, 1).Trim(), "", TextCompare: false) != 0))
                {
                    hBPM[Functions.C36to10(Microsoft.VisualBasic.Strings.Mid(text3, Microsoft.VisualBasic.Strings.Len("#BPM") + 1, 2))] = (long)Math.Round(Conversion.Val(Microsoft.VisualBasic.Strings.Mid(text3, Microsoft.VisualBasic.Strings.Len("#BPM") + 4)) * 10000.0);
                    continue;
                }
                if (text3.StartsWith("#STOP", StringComparison.CurrentCultureIgnoreCase))
                {
                    hSTOP[Functions.C36to10(Microsoft.VisualBasic.Strings.Mid(text3, Microsoft.VisualBasic.Strings.Len("#STOP") + 1, 2))] = (long)Math.Round(Conversion.Val(Microsoft.VisualBasic.Strings.Mid(text3, Microsoft.VisualBasic.Strings.Len("#STOP") + 4)) * 10000.0);
                    continue;
                }
                if (text3.StartsWith("#SCROLL", StringComparison.CurrentCultureIgnoreCase))
                {
                    hSCROLL[Functions.C36to10(Microsoft.VisualBasic.Strings.Mid(text3, Microsoft.VisualBasic.Strings.Len("#SCROLL") + 1, 2))] = (long)Math.Round(Conversion.Val(Microsoft.VisualBasic.Strings.Mid(text3, Microsoft.VisualBasic.Strings.Len("#SCROLL") + 4)) * 10000.0);
                    continue;
                }
                if (text3.StartsWith("#TITLE", StringComparison.CurrentCultureIgnoreCase))
                {
                    THTitle.Text = Microsoft.VisualBasic.Strings.Mid(text3, Microsoft.VisualBasic.Strings.Len("#TITLE") + 1).Trim();
                    continue;
                }
                if (text3.StartsWith("#ARTIST", StringComparison.CurrentCultureIgnoreCase))
                {
                    THArtist.Text = Microsoft.VisualBasic.Strings.Mid(text3, Microsoft.VisualBasic.Strings.Len("#ARTIST") + 1).Trim();
                    continue;
                }
                if (text3.StartsWith("#GENRE", StringComparison.CurrentCultureIgnoreCase))
                {
                    THGenre.Text = Microsoft.VisualBasic.Strings.Mid(text3, Microsoft.VisualBasic.Strings.Len("#GENRE") + 1).Trim();
                    continue;
                }
                if (text3.StartsWith("#BPM", StringComparison.CurrentCultureIgnoreCase))
                {
                    Notes[0].Value = (long)Math.Round(Conversion.Val(Microsoft.VisualBasic.Strings.Mid(text3, Microsoft.VisualBasic.Strings.Len("#BPM") + 1).Trim()) * 10000.0);
                    THBPM.Value = new decimal(Notes[0].Value / 10000.0);
                    continue;
                }
                if (text3.StartsWith("#PLAYER", StringComparison.CurrentCultureIgnoreCase))
                {
                    var num5 = (int)Math.Round(Conversion.Val(Microsoft.VisualBasic.Strings.Mid(text3, Microsoft.VisualBasic.Strings.Len("#PLAYER") + 1).Trim()));
                    if (num5 >= 1 && num5 <= 4)
                    {
                        CHPlayer.SelectedIndex = num5 - 1;
                    }
                    continue;
                }
                if (text3.StartsWith("#RANK", StringComparison.CurrentCultureIgnoreCase))
                {
                    var num6 = (int)Math.Round(Conversion.Val(Microsoft.VisualBasic.Strings.Mid(text3, Microsoft.VisualBasic.Strings.Len("#RANK") + 1).Trim()));
                    if (num6 >= 0 && num6 <= 4)
                    {
                        CHRank.SelectedIndex = num6;
                    }
                    continue;
                }
                if (text3.StartsWith("#PLAYLEVEL", StringComparison.CurrentCultureIgnoreCase))
                {
                    THPlayLevel.Text = Microsoft.VisualBasic.Strings.Mid(text3, Microsoft.VisualBasic.Strings.Len("#PLAYLEVEL") + 1).Trim();
                    continue;
                }
                if (text3.StartsWith("#SUBTITLE", StringComparison.CurrentCultureIgnoreCase))
                {
                    THSubTitle.Text = Microsoft.VisualBasic.Strings.Mid(text3, Microsoft.VisualBasic.Strings.Len("#SUBTITLE") + 1).Trim();
                    continue;
                }
                if (text3.StartsWith("#SUBARTIST", StringComparison.CurrentCultureIgnoreCase))
                {
                    THSubArtist.Text = Microsoft.VisualBasic.Strings.Mid(text3, Microsoft.VisualBasic.Strings.Len("#SUBARTIST") + 1).Trim();
                    continue;
                }
                if (text3.StartsWith("#STAGEFILE", StringComparison.CurrentCultureIgnoreCase))
                {
                    THStageFile.Text = Microsoft.VisualBasic.Strings.Mid(text3, Microsoft.VisualBasic.Strings.Len("#STAGEFILE") + 1).Trim();
                    continue;
                }
                if (text3.StartsWith("#BANNER", StringComparison.CurrentCultureIgnoreCase))
                {
                    THBanner.Text = Microsoft.VisualBasic.Strings.Mid(text3, Microsoft.VisualBasic.Strings.Len("#BANNER") + 1).Trim();
                    continue;
                }
                if (text3.StartsWith("#BACKBMP", StringComparison.CurrentCultureIgnoreCase))
                {
                    THBackBMP.Text = Microsoft.VisualBasic.Strings.Mid(text3, Microsoft.VisualBasic.Strings.Len("#BACKBMP") + 1).Trim();
                    continue;
                }
                if (text3.StartsWith("#DIFFICULTY", StringComparison.CurrentCultureIgnoreCase))
                {
                    try
                    {
                        CHDifficulty.SelectedIndex = int.Parse(Microsoft.VisualBasic.Strings.Mid(text3, Microsoft.VisualBasic.Strings.Len("#DIFFICULTY") + 1).Trim());
                    }
                    catch (Exception ex)
                    {
                        ProjectData.SetProjectError(ex);
                        var ex2 = ex;
                        ProjectData.ClearProjectError();
                    }
                    continue;
                }
                if (text3.StartsWith("#DEFEXRANK", StringComparison.CurrentCultureIgnoreCase))
                {
                    THExRank.Text = Microsoft.VisualBasic.Strings.Mid(text3, Microsoft.VisualBasic.Strings.Len("#DEFEXRANK") + 1).Trim();
                    continue;
                }
                if (text3.StartsWith("#TOTAL", StringComparison.CurrentCultureIgnoreCase))
                {
                    var text4 = Microsoft.VisualBasic.Strings.Mid(text3, Microsoft.VisualBasic.Strings.Len("#TOTAL") + 1).Trim();
                    THTotal.Text = text4;
                    continue;
                }
                if (text3.StartsWith("#COMMENT", StringComparison.CurrentCultureIgnoreCase))
                {
                    var text5 = Microsoft.VisualBasic.Strings.Mid(text3, Microsoft.VisualBasic.Strings.Len("#COMMENT") + 1).Trim();
                    if (text5.StartsWith("\""))
                    {
                        text5 = Microsoft.VisualBasic.Strings.Mid(text5, 2);
                    }
                    if (text5.EndsWith("\""))
                    {
                        text5 = Microsoft.VisualBasic.Strings.Mid(text5, 1, Microsoft.VisualBasic.Strings.Len(text5) - 1);
                    }
                    THComment.Text = text5;
                    continue;
                }
                if (text3.StartsWith("#LNTYPE", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (Conversion.Val(Microsoft.VisualBasic.Strings.Mid(text3, Microsoft.VisualBasic.Strings.Len("#LNTYPE") + 1).Trim()) == 1.0)
                    {
                        CHLnObj.SelectedIndex = 0;
                    }
                    continue;
                }
                if (text3.StartsWith("#LNOBJ", StringComparison.CurrentCultureIgnoreCase))
                {
                    var selectedIndex = Functions.C36to10(Microsoft.VisualBasic.Strings.Mid(text3, Microsoft.VisualBasic.Strings.Len("#LNOBJ") + 1).Trim());
                    CHLnObj.SelectedIndex = selectedIndex;
                    continue;
                }
                if (text3.StartsWith("#") & (Operators.CompareString(Microsoft.VisualBasic.Strings.Mid(text3, 7, 1), ":", TextCompare: false) == 0))
                {
                    var i2 = Microsoft.VisualBasic.Strings.Mid(text3, 5, 2);
                    if (BMSChannelToColumn(i2) != 0)
                    {
                        continue;
                    }
                    goto IL_0952;
                }
            }
            if (text3.StartsWith("#IF", StringComparison.CurrentCultureIgnoreCase))
            {
                num2++;
            }
            else if (text3.StartsWith("#ENDIF", StringComparison.CurrentCultureIgnoreCase))
            {
                num2--;
            }
            else if (text3.StartsWith("#SWITCH", StringComparison.CurrentCultureIgnoreCase))
            {
                num2++;
            }
            else if (text3.StartsWith("#SETSWITCH", StringComparison.CurrentCultureIgnoreCase))
            {
                num2++;
            }
            else if (text3.StartsWith("#ENDSW", StringComparison.CurrentCultureIgnoreCase))
            {
                num2--;
            }
            else if (!text3.StartsWith("#"))
            {
                continue;
            }
            goto IL_0952;
IL_0952:
            text = text + text2 + "\r\n";
        }
        UpdateMeasureBottom();
        num2 = 0;
        int k;
        foreach (var text2 in array)
        {
            var text6 = text2.Trim();
            if (num2 > 0 || !(text6.StartsWith("#") & (Operators.CompareString(Microsoft.VisualBasic.Strings.Mid(text6, 7, 1), ":", TextCompare: false) == 0)))
            {
                continue;
            }
            var num7 = (int)Math.Round(Conversion.Val(Microsoft.VisualBasic.Strings.Mid(text6, 2, 3)));
            var text7 = Microsoft.VisualBasic.Strings.Mid(text6, 5, 2);
            if (BMSChannelToColumn(text7) == 0)
            {
                continue;
            }
            if (Operators.CompareString(text7, "01", TextCompare: false) == 0)
            {
                var array4 = mColumn;
                array4[num7]++;
            }
            var num9 = Microsoft.VisualBasic.Strings.Len(text6) - 1;
            for (k = 8; k <= num9; k += 2)
            {
                if (Operators.CompareString(Microsoft.VisualBasic.Strings.Mid(text6, k, 2), "00", TextCompare: false) != 0)
                {
                    Notes = (Note[])Utils.CopyArray(Notes, new Note[Notes.Length + 1]);
                    var notes2 = Notes;
                    var num10 = Information.UBound(Notes);
                    notes2[num10].ColumnIndex = Conversions.ToInteger(Operators.AddObject(BMSChannelToColumn(text7), Operators.MultiplyObject(Interaction.IIf(Operators.CompareString(text7, "01", TextCompare: false) == 0, 1, 0), mColumn[num7] - 1)));
                    notes2[num10].LongNote = BMS.IsChannelLongNote(text7);
                    notes2[num10].Hidden = BMS.IsChannelHidden(text7);
                    notes2[num10].Landmine = BMS.IsChannelLandmine(text7);
                    notes2[num10].Selected = false;
                    notes2[num10].VPosition = MeasureBottom[num7] + MeasureLength[num7] * (k / 2.0 - 4.0) / ((Microsoft.VisualBasic.Strings.Len(text6) - 7) / 2.0);
                    notes2[num10].Value = Functions.C36to10(Microsoft.VisualBasic.Strings.Mid(text6, k, 2)) * 10000;
                    if (Operators.CompareString(text7, "03", TextCompare: false) == 0)
                    {
                        notes2[num10].Value = Convert.ToInt32(Microsoft.VisualBasic.Strings.Mid(text6, k, 2), 16) * 10000;
                    }
                    if (Operators.CompareString(text7, "08", TextCompare: false) == 0)
                    {
                        notes2[num10].Value = hBPM[Functions.C36to10(Microsoft.VisualBasic.Strings.Mid(text6, k, 2))];
                    }
                    if (Operators.CompareString(text7, "09", TextCompare: false) == 0)
                    {
                        notes2[num10].Value = hSTOP[Functions.C36to10(Microsoft.VisualBasic.Strings.Mid(text6, k, 2))];
                    }
                    if (Operators.CompareString(text7, "SC", TextCompare: false) == 0)
                    {
                        notes2[num10].Value = hSCROLL[Functions.C36to10(Microsoft.VisualBasic.Strings.Mid(text6, k, 2))];
                    }
                }
            }
        }
        if (NTInput)
        {
            ConvertBMSE2NT();
        }
        LWAV.Visible = false;
        LWAV.Items.Clear();
        k = 1;
        do
        {
            LWAV.Items.Add(Functions.C10to36(k) + ": " + hWAV[k]);
            k++;
        }
        while (k <= 1295);
        LWAV.SelectedIndex = 0;
        LWAV.Visible = true;
        TExpansion.Text = text;
        SortByVPositionQuick(0, Information.UBound(Notes));
        UpdatePairing();
        CalculateTotalPlayableNotes();
        CalculateGreatestVPosition();
        RefreshPanelAll();
        POStatusRefresh();
    }

    private string SaveBMS()
    {
        CalculateGreatestVPosition();
        SortByVPositionInsertion();
        UpdatePairing();
        bool hasOverlapping = false;

        string[] array = new string[MeasureAtDisplacement(GreatestVPosition) + 1 + 1];
        hBPM = new long[1];
        hSTOP = new long[1];
        hSCROLL = new long[1];
        bool nTInput = NTInput;
        Note[] notes = Notes;
        if (nTInput)
        {
            NTInput = false;
            ConvertNT2BMSE();
        }
        Note[] xprevNotes = Array.Empty<Note>();
        int num = MeasureAtDisplacement(GreatestVPosition) + 1;
        for (int i = 0; i <= num; i++)
        {
            array[i] = "\r\n";
            string text = Functions.WriteDecimalWithDot(MeasureLength[i] / 192.0);
            if (MeasureLength[i] != 192.0)
            {
                array[i] = array[i] + "#" + Functions.Add3Zeros(i) + "02:" + text + "\r\n";
            }
            int LowerLimit = 0;
            int UpperLimit = 0;
            GetMeasureLimits(i, ref LowerLimit, ref UpperLimit);
            if (UpperLimit - LowerLimit != 0)
            {
                int num3 = Information.UBound(xprevNotes);
                Note[] array3 = new Note[UpperLimit - LowerLimit + num3 + 1];
                for (int j = 0; j <= num3; j++)
                {
                    ref Note reference = ref array3[j];
                    reference = xprevNotes[j];
                }

                int num6 = UpperLimit - 1;
                for (int k = LowerLimit; k <= num6; k++)
                {
                    ref Note reference2 = ref array3[k - LowerLimit + xprevNotes.Length];
                    reference2 = Notes[k];
                }
                int num7 = 0;
                for (int l = 0; l < array3.Length; l++)
                {
                    Note note = array3[l];
                    num7 = Math.Max(note.ColumnIndex, num7);
                }
                xprevNotes = Array.Empty<Note>();
                string[] array5 = array;
                string[] array6 = array5;
                int num2 = i;
                array6[num2] = array5[num2] + GenerateBackgroundTracks(i, ref hasOverlapping, array3, num7, ref xprevNotes);
                array5 = array;
                string[] array7 = array5;
                num2 = i;
                array7[num2] = array5[num2] + GenerateKeyTracks(i, ref hasOverlapping, array3, ref xprevNotes);
            }
        }
        if (hasOverlapping)
        {
            Interaction.MsgBox(Strings1.Messages.SaveWarning + "\r\n" + Strings1.Messages.NoteOverlapError + "\r\n" + Strings1.Messages.SavedFileWillContainErrors, MsgBoxStyle.Exclamation);
        }
        if (Operators.ConditionalCompareObjectGreater(Information.UBound(hBPM), Interaction.IIf(BPMx1296, 1295, 255), TextCompare: false))
        {
            Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(string.Concat(string.Concat(string.Concat(Strings1.Messages.SaveWarning + "\r\n", Strings1.Messages.BPMOverflowError), Conversions.ToString(Information.UBound(hBPM))), " > "), Interaction.IIf(BPMx1296, 1295, 255)), "\r\n"), Strings1.Messages.SavedFileWillContainErrors), MsgBoxStyle.Exclamation);
        }
        if (Operators.ConditionalCompareObjectGreater(Information.UBound(hSTOP), Interaction.IIf(STOPx1296, 1295, 255), TextCompare: false))
        {
            Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(string.Concat(string.Concat(string.Concat(Strings1.Messages.SaveWarning + "\r\n", Strings1.Messages.STOPOverflowError), Conversions.ToString(Information.UBound(hSTOP))), " > "), Interaction.IIf(STOPx1296, 1295, 255)), "\r\n"), Strings1.Messages.SavedFileWillContainErrors), MsgBoxStyle.Exclamation);
        }
        if (Information.UBound(hSCROLL) > 1295)
        {
            Interaction.MsgBox(Strings1.Messages.SaveWarning + "\r\n" + Strings1.Messages.SCROLLOverflowError + Conversions.ToString(Information.UBound(hSCROLL)) + " > " + Conversions.ToString(1295) + "\r\n" + Strings1.Messages.SavedFileWillContainErrors, MsgBoxStyle.Exclamation);
        }
        string text2 = "\r\n*---------------------- EXPANSION FIELD\r\n" + TExpansion.Text + "\r\n\r\n";
        if (Operators.CompareString(TExpansion.Text, "", TextCompare: false) == 0)
        {
            text2 = "";
        }
        string text3 = "*---------------------- MAIN DATA FIELD\r\n\r\n" + Microsoft.VisualBasic.Strings.Join(array, "") + "\r\n";
        if (nTInput)
        {
            Notes = notes;
            NTInput = true;
        }
        string text4 = GenerateHeaderMeta();
        text4 += GenerateHeaderIndexedData();
        return text4 + "\r\n" + text2 + "\r\n" + text3;
    }

    private string GenerateHeaderMeta()
    {
        string text = "\r\n*---------------------- HEADER FIELD\r\n\r\n";
        text = text + "#PLAYER " + Conversions.ToString(CHPlayer.SelectedIndex + 1) + "\r\n";
        text = text + "#GENRE " + THGenre.Text + "\r\n";
        text = text + "#TITLE " + THTitle.Text + "\r\n";
        text = text + "#ARTIST " + THArtist.Text + "\r\n";
        text = text + "#BPM " + Functions.WriteDecimalWithDot(Notes[0].Value / 10000.0) + "\r\n";
        text = text + "#PLAYLEVEL " + THPlayLevel.Text + "\r\n";
        text = text + "#RANK " + Conversions.ToString(CHRank.SelectedIndex) + "\r\n";
        text += "\r\n";
        if (Operators.CompareString(THSubTitle.Text, "", TextCompare: false) != 0)
        {
            text = text + "#SUBTITLE " + THSubTitle.Text + "\r\n";
        }
        if (Operators.CompareString(THSubArtist.Text, "", TextCompare: false) != 0)
        {
            text = text + "#SUBARTIST " + THSubArtist.Text + "\r\n";
        }
        if (Operators.CompareString(THStageFile.Text, "", TextCompare: false) != 0)
        {
            text = text + "#STAGEFILE " + THStageFile.Text + "\r\n";
        }
        if (Operators.CompareString(THBanner.Text, "", TextCompare: false) != 0)
        {
            text = text + "#BANNER " + THBanner.Text + "\r\n";
        }
        if (Operators.CompareString(THBackBMP.Text, "", TextCompare: false) != 0)
        {
            text = text + "#BACKBMP " + THBackBMP.Text + "\r\n";
        }
        text += "\r\n";
        if (CHDifficulty.SelectedIndex != 0)
        {
            text = text + "#DIFFICULTY " + Conversions.ToString(CHDifficulty.SelectedIndex) + "\r\n";
        }
        if (Operators.CompareString(THExRank.Text, "", TextCompare: false) != 0)
        {
            text = text + "#DEFEXRANK " + THExRank.Text + "\r\n";
        }
        if (Operators.CompareString(THTotal.Text, "", TextCompare: false) != 0)
        {
            text = text + "#TOTAL " + THTotal.Text + "\r\n";
        }
        if (Operators.CompareString(THComment.Text, "", TextCompare: false) != 0)
        {
            text = text + "#COMMENT \"" + THComment.Text + "\"\r\n";
        }
        text = CHLnObj.SelectedIndex <= 0 ? text + "#LNTYPE 1\r\n" : text + "#LNOBJ " + Functions.C10to36(CHLnObj.SelectedIndex) + "\r\n";
        return text + "\r\n";
    }

    private string GenerateHeaderIndexedData()
    {
        string text = "";
        int num = Information.UBound(hWAV);

        for (int i = 1; i <= num; i++)
        {
            if (Operators.CompareString(hWAV[i], "", TextCompare: false) != 0)
            {
                text = text + "#WAV" + Functions.C10to36(i) + " " + hWAV[i] + "\r\n";
            }
        }
        int num2 = Information.UBound(hBPM);
        for (int j = 1; j <= num2; j++)
        {
            text = Conversions.ToString(Operators.ConcatenateObject(text, Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("#BPM", Interaction.IIf(BPMx1296, Functions.C10to36(j), Microsoft.VisualBasic.Strings.Mid("0" + Conversion.Hex(j), Microsoft.VisualBasic.Strings.Len(Conversion.Hex(j))))), " "), Functions.WriteDecimalWithDot(hBPM[j] / 10000.0)), "\r\n")));
        }
        int num3 = Information.UBound(hSTOP);
        for (int k = 1; k <= num3; k++)
        {
            text = Conversions.ToString(Operators.ConcatenateObject(text, Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("#STOP", Interaction.IIf(STOPx1296, Functions.C10to36(k), Microsoft.VisualBasic.Strings.Mid("0" + Conversion.Hex(k), Microsoft.VisualBasic.Strings.Len(Conversion.Hex(k))))), " "), Functions.WriteDecimalWithDot(hSTOP[k] / 10000.0)), "\r\n")));
        }
        int num4 = Information.UBound(hSCROLL);
        for (int l = 1; l <= num4; l++)
        {
            text = text + "#SCROLL" + Functions.C10to36(l) + " " + Functions.WriteDecimalWithDot(hSCROLL[l] / 10000.0) + "\r\n";
        }
        return text;
    }

    private void GetMeasureLimits(int MeasureIndex, ref int LowerLimit, ref int UpperLimit)
    {
        int num = Information.UBound(Notes);
        LowerLimit = 0;

        for (int i = 1; i <= num; i++)
        {
            if (MeasureAtDisplacement(Notes[i].VPosition) >= MeasureIndex)
            {
                LowerLimit = i;
                break;
            }
        }
        UpperLimit = 0;
        int num3 = LowerLimit;
        for (int j = num3; j <= num; j++)
        {
            if (MeasureAtDisplacement(Notes[j].VPosition) > MeasureIndex)
            {
                UpperLimit = j;
                break;
            }
        }
        if (UpperLimit < LowerLimit)
        {
            UpperLimit = num + 1;
        }
    }

    private string GenerateKeyTracks(int MeasureIndex, ref bool hasOverlapping, Note[] NotesInMeasure, ref Note[] xprevNotes)
    {
        string text = "";

        object CounterResult3 = default(object);
        object LoopForResult3 = default(object);
        object CounterResult2 = default(object);
        object LoopForResult2 = default(object);
        object CounterResult = default(object);
        object LoopForResult = default(object);
        foreach (string text2 in BMSChannelList)
        {
            object[] array = Array.Empty<object>();
            object[] array2 = Array.Empty<object>();
            if (Operators.CompareString(text2, "01", TextCompare: false) == 0)
            {
                continue;
            }
            int num = Information.UBound(NotesInMeasure);
            for (int j = 0; j <= num; j++)
            {
                Note note = NotesInMeasure[j];
                if (Operators.CompareString(GetBMSChannelBy(note), text2, TextCompare: false) != 0)
                {
                    continue;
                }
                array = (object[])Utils.CopyArray(array, new object[Information.UBound(array) + 1 + 1]);
                array2 = (object[])Utils.CopyArray(array2, new object[Information.UBound(array2) + 1 + 1]);
                array[Information.UBound(array)] = note.VPosition - MeasureBottom[MeasureAtDisplacement(note.VPosition)];
                if (Operators.ConditionalCompareObjectLess(array[Information.UBound(array)], 0, TextCompare: false))
                {
                    array[Information.UBound(array)] = 0;
                }
                switch (text2)
                {
                    case "03":
                        array2[Information.UBound(array2)] = Microsoft.VisualBasic.Strings.Mid("0" + Conversion.Hex(note.Value / 10000), Microsoft.VisualBasic.Strings.Len(Conversion.Hex(note.Value / 10000)));
                        break;
                    case "08":
                        if (ObjectFlowControl.ForLoopControl.ForLoopInitObj(CounterResult3, 1, Information.UBound(hBPM), 1, ref LoopForResult3, ref CounterResult3))
                        {
                            while (note.Value != hBPM[Conversions.ToInteger(CounterResult3)] && ObjectFlowControl.ForLoopControl.ForNextCheckObj(CounterResult3, LoopForResult3, ref CounterResult3))
                            {
                            }
                        }
                        if (Operators.ConditionalCompareObjectGreater(CounterResult3, Information.UBound(hBPM), TextCompare: false))
                        {
                            hBPM = (long[])Utils.CopyArray(hBPM, new long[Information.UBound(hBPM) + 1 + 1]);
                            hBPM[Information.UBound(hBPM)] = note.Value;
                        }
                        array2[Information.UBound(array2)] = RuntimeHelpers.GetObjectValue(Interaction.IIf(BPMx1296, Functions.C10to36(Conversions.ToLong(CounterResult3)), Microsoft.VisualBasic.Strings.Mid("0" + Conversion.Hex(RuntimeHelpers.GetObjectValue(CounterResult3)), Microsoft.VisualBasic.Strings.Len(Conversion.Hex(RuntimeHelpers.GetObjectValue(CounterResult3))))));
                        break;
                    case "09":
                        if (ObjectFlowControl.ForLoopControl.ForLoopInitObj(CounterResult2, 1, Information.UBound(hSTOP), 1, ref LoopForResult2, ref CounterResult2))
                        {
                            while (note.Value != hSTOP[Conversions.ToInteger(CounterResult2)] && ObjectFlowControl.ForLoopControl.ForNextCheckObj(CounterResult2, LoopForResult2, ref CounterResult2))
                            {
                            }
                        }
                        if (Operators.ConditionalCompareObjectGreater(CounterResult2, Information.UBound(hSTOP), TextCompare: false))
                        {
                            hSTOP = (long[])Utils.CopyArray(hSTOP, new long[Information.UBound(hSTOP) + 1 + 1]);
                            hSTOP[Information.UBound(hSTOP)] = note.Value;
                        }
                        array2[Information.UBound(array2)] = RuntimeHelpers.GetObjectValue(Interaction.IIf(STOPx1296, Functions.C10to36(Conversions.ToLong(CounterResult2)), Microsoft.VisualBasic.Strings.Mid("0" + Conversion.Hex(RuntimeHelpers.GetObjectValue(CounterResult2)), Microsoft.VisualBasic.Strings.Len(Conversion.Hex(RuntimeHelpers.GetObjectValue(CounterResult2))))));
                        break;
                    case "SC":
                        if (ObjectFlowControl.ForLoopControl.ForLoopInitObj(CounterResult, 1, Information.UBound(hSCROLL), 1, ref LoopForResult, ref CounterResult))
                        {
                            while (note.Value != hSCROLL[Conversions.ToInteger(CounterResult)] && ObjectFlowControl.ForLoopControl.ForNextCheckObj(CounterResult, LoopForResult, ref CounterResult))
                            {
                            }
                        }
                        if (Operators.ConditionalCompareObjectGreater(CounterResult, Information.UBound(hSCROLL), TextCompare: false))
                        {
                            hSCROLL = (long[])Utils.CopyArray(hSCROLL, new long[Information.UBound(hSCROLL) + 1 + 1]);
                            hSCROLL[Information.UBound(hSCROLL)] = note.Value;
                        }
                        array2[Information.UBound(array2)] = Functions.C10to36(Conversions.ToLong(CounterResult));
                        break;
                    default:
                        array2[Information.UBound(array2)] = Functions.C10to36(note.Value / 10000);
                        break;
                }
            }
            if (array.Length == 0)
            {
                continue;
            }
            double num2 = MeasureLength[MeasureIndex];
            int num3 = Information.UBound(array);
            for (int k = 0; k <= num3; k++)
            {
                if (Operators.ConditionalCompareObjectGreater(array[k], 0, TextCompare: false))
                {
                    num2 = GCD(num2, Conversions.ToDouble(array[k]));
                }
            }
            string[] array3 = new string[(int)Math.Round(MeasureLength[MeasureIndex] / num2) - 1 + 1];
            int num4 = Information.UBound(array3);
            for (int l = 0; l <= num4; l++)
            {
                array3[l] = "00";
            }
            int num5 = Information.UBound(array);
            for (int m = 0; m <= num5; m++)
            {
                if (Conversions.ToInteger(Operators.DivideObject(array[m], num2)) > Information.UBound(array3))
                {
                    xprevNotes = (Note[])Utils.CopyArray(xprevNotes, new Note[Information.UBound(xprevNotes) + 1 + 1]);
                    Note[] array4 = xprevNotes;
                    int num6 = Information.UBound(xprevNotes);
                    array4[num6].ColumnIndex = BMSChannelToColumn(BMSChannelList[Conversions.ToInteger(text2)]);
                    array4[num6].LongNote = BMS.IsChannelLongNote(BMSChannelList[Conversions.ToInteger(text2)]);
                    array4[num6].Hidden = BMS.IsChannelHidden(BMSChannelList[Conversions.ToInteger(text2)]);
                    array4[num6].VPosition = MeasureBottom[MeasureIndex];
                    array4[num6].Value = Functions.C36to10(Conversions.ToString(array2[m]));
                    if (Operators.CompareString(BMSChannelList[Conversions.ToInteger(text2)], "08", TextCompare: false) == 0)
                    {
                        xprevNotes[Information.UBound(xprevNotes)].Value = Conversions.ToLong(Interaction.IIf(BPMx1296, hBPM[Functions.C36to10(Conversions.ToString(array2[m]))], hBPM[Convert.ToInt32(Conversions.ToString(array2[m]), 16)]));
                    }
                    if (Operators.CompareString(BMSChannelList[Conversions.ToInteger(text2)], "09", TextCompare: false) == 0)
                    {
                        xprevNotes[Information.UBound(xprevNotes)].Value = Conversions.ToLong(Interaction.IIf(STOPx1296, hSTOP[Functions.C36to10(Conversions.ToString(array2[m]))], hSTOP[Convert.ToInt32(Conversions.ToString(array2[m]), 16)]));
                    }
                    if (Operators.CompareString(BMSChannelList[Conversions.ToInteger(text2)], "SC", TextCompare: false) == 0)
                    {
                        xprevNotes[Information.UBound(xprevNotes)].Value = hSCROLL[Functions.C36to10(Conversions.ToString(array2[m]))];
                    }
                }
                else
                {
                    if (Operators.CompareString(array3[Conversions.ToInteger(Operators.DivideObject(array[m], num2))], "00", TextCompare: false) != 0)
                    {
                        hasOverlapping = true;
                    }
                    array3[Conversions.ToInteger(Operators.DivideObject(array[m], num2))] = Conversions.ToString(array2[m]);
                }
            }
            text = text + "#" + Functions.Add3Zeros(MeasureIndex) + text2 + ":" + Microsoft.VisualBasic.Strings.Join(array3, "") + "\r\n";
        }
        return text;
    }

    private string GenerateBackgroundTracks(int MeasureIndex, ref bool hasOverlapping, Note[] NotesInMeasure, int GreatestColumn, ref Note[] xprevNotes)
    {
        string text = "";

        for (int i = 27; i <= GreatestColumn; i++)
        {
            double[] array = Array.Empty<double>();
            string[] array2 = Array.Empty<string>();
            int num = Information.UBound(NotesInMeasure);
            for (int j = 0; j <= num; j++)
            {
                if (NotesInMeasure[j].ColumnIndex == i)
                {
                    array = (double[])Utils.CopyArray(array, new double[Information.UBound(array) + 1 + 1]);
                    array2 = (string[])Utils.CopyArray(array2, new string[Information.UBound(array2) + 1 + 1]);
                    array[Information.UBound(array)] = NotesInMeasure[j].VPosition - MeasureBottom[MeasureAtDisplacement(NotesInMeasure[j].VPosition)];
                    if (array[Information.UBound(array)] < 0.0)
                    {
                        array[Information.UBound(array)] = 0.0;
                    }
                    array2[Information.UBound(array2)] = Functions.C10to36(NotesInMeasure[j].Value / 10000);
                }
            }
            double num2 = MeasureLength[MeasureIndex];
            int num3 = Information.UBound(array);
            for (int k = 0; k <= num3; k++)
            {
                if (array[k] > 0.0)
                {
                    num2 = GCD(num2, array[k]);
                }
            }
            string[] array3 = new string[(int)Math.Round(MeasureLength[MeasureIndex] / num2) - 1 + 1];
            int num4 = Information.UBound(array3);
            for (int l = 0; l <= num4; l++)
            {
                array3[l] = "00";
            }
            int num5 = Information.UBound(array);
            for (int m = 0; m <= num5; m++)
            {
                if ((int)Math.Round(array[m] / num2) > Information.UBound(array3))
                {
                    xprevNotes = (Note[])Utils.CopyArray(xprevNotes, new Note[Information.UBound(xprevNotes) + 1 + 1]);
                    Note[] array4 = xprevNotes;
                    int num6 = Information.UBound(xprevNotes);
                    array4[num6].ColumnIndex = i;
                    array4[num6].VPosition = MeasureBottom[MeasureIndex];
                    array4[num6].Value = Functions.C36to10(array2[m]);
                }
                else
                {
                    if (Operators.CompareString(array3[(int)Math.Round(array[m] / num2)], "00", TextCompare: false) != 0)
                    {
                        hasOverlapping = true;
                    }
                    array3[(int)Math.Round(array[m] / num2)] = array2[m];
                }
            }
            text = text + "#" + Functions.Add3Zeros(MeasureIndex) + "01:" + Microsoft.VisualBasic.Strings.Join(array3, "") + "\r\n";
        }
        return text;
    }

    private bool OpenSM(string xStrAll)
    {
        KMouseOver = -1;
        string[] array = Microsoft.VisualBasic.Strings.Split(xStrAll, "\r\n");
        int num = Information.UBound(array);

        for (int i = 0; i <= num; i++)
        {
            if (array[i].Contains("//"))
            {
                array[i] = Microsoft.VisualBasic.Strings.Mid(array[i], 1, Microsoft.VisualBasic.Strings.InStr(array[i], "//") - 1);
            }
        }
        xStrAll = Microsoft.VisualBasic.Strings.Join(array, "");
        array = Microsoft.VisualBasic.Strings.Split(xStrAll, ";");
        int num2 = 0;
        int num3 = 0;
        string[] array2 = Microsoft.VisualBasic.Strings.Split(xStrAll, "#NOTES:");
        string[] array3 = Array.Empty<string>();
        if (array2.Length > 2)
        {
            array3 = (string[])Utils.CopyArray(array3, new string[Information.UBound(array2) - 1 + 1]);
            int num4 = Information.UBound(array2);
            for (int j = 1; j <= num4; j++)
            {
                array2[j] = Microsoft.VisualBasic.Strings.Mid(array2[j], Microsoft.VisualBasic.Strings.InStr(array2[j], ":") + 1);
                array2[j] = Microsoft.VisualBasic.Strings.Mid(array2[j], Microsoft.VisualBasic.Strings.InStr(array2[j], ":") + 1).Trim();
                array3[j - 1] = Microsoft.VisualBasic.Strings.Mid(array2[j], 1, Microsoft.VisualBasic.Strings.InStr(array2[j], ":") - 1);
                array2[j] = Microsoft.VisualBasic.Strings.Mid(array2[j], Microsoft.VisualBasic.Strings.InStr(array2[j], ":") + 1).Trim();
                int num5 = j - 1;
                array3[num5] = array3[num5] + " : " + Microsoft.VisualBasic.Strings.Mid(array2[j], 1, Microsoft.VisualBasic.Strings.InStr(array2[j], ":") - 1);
            }
            dgImportSM dgImportSM2 = new dgImportSM(array3);
            if (dgImportSM2.ShowDialog() == DialogResult.Cancel)
            {
                return true;
            }
            num2 = dgImportSM2.iResult;
        }
        Notes = new Note[1];
        mColumn = new int[1000];
        hWAV = new string[1296];
        hBPM = new long[1296];
        hSTOP = new long[1296];
        hSCROLL = new long[1296];
        InitializeNewBMS();
        Note[] notes = Notes;
        int num6 = 0;
        notes[num6].ColumnIndex = 2;
        notes[num6].VPosition = -1.0;
        notes[num6].Value = 1200000L;
        string[] array5 = array;
        foreach (string text in array5)
        {
            if (Microsoft.VisualBasic.Strings.UCase(text).StartsWith("#TITLE:"))
            {
                THTitle.Text = Microsoft.VisualBasic.Strings.Mid(text, Microsoft.VisualBasic.Strings.Len("#TITLE:") + 1);
            }
            else if (Microsoft.VisualBasic.Strings.UCase(text).StartsWith("#SUBTITLE:"))
            {
                if (!Microsoft.VisualBasic.Strings.UCase(text).EndsWith("#SUBTITLE:"))
                {
                    TextBox tHTitle = THTitle;
                    tHTitle.Text = tHTitle.Text + " " + Microsoft.VisualBasic.Strings.Mid(text, Microsoft.VisualBasic.Strings.Len("#SUBTITLE:") + 1);
                }
            }
            else if (Microsoft.VisualBasic.Strings.UCase(text).StartsWith("#ARTIST:"))
            {
                THArtist.Text = Microsoft.VisualBasic.Strings.Mid(text, Microsoft.VisualBasic.Strings.Len("#ARTIST:") + 1);
            }
            else if (Microsoft.VisualBasic.Strings.UCase(text).StartsWith("#GENRE:"))
            {
                THGenre.Text = Microsoft.VisualBasic.Strings.Mid(text, Microsoft.VisualBasic.Strings.Len("#GENRE:") + 1);
            }
            else if (Microsoft.VisualBasic.Strings.UCase(text).StartsWith("#BPMS:"))
            {
                string expression = Microsoft.VisualBasic.Strings.Mid(text, Microsoft.VisualBasic.Strings.Len("#BPMS:") + 1);
                string[] array6 = Microsoft.VisualBasic.Strings.Split(expression, ",");
                int num7 = Information.UBound(array6);
                for (int l = 0; l <= num7; l++)
                {
                    double num8 = Conversions.ToDouble(Microsoft.VisualBasic.Strings.Mid(array6[l], 1, Microsoft.VisualBasic.Strings.InStr(array6[l], "=") - 1));
                    double num9 = Conversions.ToDouble(Microsoft.VisualBasic.Strings.Mid(array6[l], Microsoft.VisualBasic.Strings.InStr(array6[l], "=") + 1));
                    if (num8 != 0.0)
                    {
                        Notes = (Note[])Utils.CopyArray(Notes, new Note[Notes.Length + 1]);
                        Note[] notes2 = Notes;
                        int num10 = Information.UBound(Notes);
                        notes2[num10].ColumnIndex = 2;
                        notes2[num10].VPosition = num8 * 48.0;
                        notes2[num10].Value = (long)Math.Round(num9 * 10000.0);
                    }
                    else
                    {
                        Notes[0].Value = (long)Math.Round(num9 * 10000.0);
                    }
                }
            }
            else
            {
                if (!Microsoft.VisualBasic.Strings.UCase(text).StartsWith("#NOTES:"))
                {
                    continue;
                }
                if (num3 != num2)
                {
                    num3++;
                    continue;
                }
                num3++;
                string expression2 = Microsoft.VisualBasic.Strings.Mid(text, Microsoft.VisualBasic.Strings.Len("#NOTES:") + 1);
                string[] array7 = Microsoft.VisualBasic.Strings.Split(expression2, ":");
                int num11 = Information.UBound(array7);
                for (int m = 0; m <= num11; m++)
                {
                    array7[m] = array7[m].Trim();
                }
                if (array7.Length != 6)
                {
                    continue;
                }
                THPlayLevel.Text = array7[3];
                string[] array8 = Microsoft.VisualBasic.Strings.Split(array7[5], ",");
                int num12 = Information.UBound(array8);
                for (int n = 0; n <= num12; n++)
                {
                    array8[n] = array8[n].Trim();
                }
                int num13 = Information.UBound(array8);
                for (int num14 = 0; num14 <= num13; num14++)
                {
                    int num15 = Microsoft.VisualBasic.Strings.Len(array8[num14]) - 1;
                    for (int num16 = 0; num16 <= num15; num16 += 4)
                    {
                        if (Operators.CompareString(Conversions.ToString(array8[num14][num16]), "0", TextCompare: false) != 0)
                        {
                            Notes = (Note[])Utils.CopyArray(Notes, new Note[Notes.Length + 1]);
                            Note[] notes3 = Notes;
                            int num17 = Information.UBound(Notes);
                            notes3[num17].ColumnIndex = 5;
                            notes3[num17].LongNote = (Operators.CompareString(Conversions.ToString(array8[num14][num16]), "2", TextCompare: false) == 0) | (Operators.CompareString(Conversions.ToString(array8[num14][num16]), "3", TextCompare: false) == 0);
                            notes3[num17].VPosition = 192 / (Microsoft.VisualBasic.Strings.Len(array8[num14]) / 4) * num16 / 4 + num14 * 192;
                            notes3[num17].Value = 10000L;
                        }
                        if (Operators.CompareString(Conversions.ToString(array8[num14][num16 + 1]), "0", TextCompare: false) != 0)
                        {
                            Notes = (Note[])Utils.CopyArray(Notes, new Note[Notes.Length + 1]);
                            Note[] notes4 = Notes;
                            int num18 = Information.UBound(Notes);
                            notes4[num18].ColumnIndex = 6;
                            notes4[num18].LongNote = (Operators.CompareString(Conversions.ToString(array8[num14][num16 + 1]), "2", TextCompare: false) == 0) | (Operators.CompareString(Conversions.ToString(array8[num14][num16 + 1]), "3", TextCompare: false) == 0);
                            notes4[num18].VPosition = 192 / (Microsoft.VisualBasic.Strings.Len(array8[num14]) / 4) * num16 / 4 + num14 * 192;
                            notes4[num18].Value = 10000L;
                        }
                        if (Operators.CompareString(Conversions.ToString(array8[num14][num16 + 2]), "0", TextCompare: false) != 0)
                        {
                            Notes = (Note[])Utils.CopyArray(Notes, new Note[Notes.Length + 1]);
                            Note[] notes5 = Notes;
                            int num19 = Information.UBound(Notes);
                            notes5[num19].ColumnIndex = 7;
                            notes5[num19].LongNote = (Operators.CompareString(Conversions.ToString(array8[num14][num16 + 2]), "2", TextCompare: false) == 0) | (Operators.CompareString(Conversions.ToString(array8[num14][num16 + 2]), "3", TextCompare: false) == 0);
                            notes5[num19].VPosition = 192 / (Microsoft.VisualBasic.Strings.Len(array8[num14]) / 4) * num16 / 4 + num14 * 192;
                            notes5[num19].Value = 10000L;
                        }
                        if (Operators.CompareString(Conversions.ToString(array8[num14][num16 + 3]), "0", TextCompare: false) != 0)
                        {
                            Notes = (Note[])Utils.CopyArray(Notes, new Note[Notes.Length + 1]);
                            Note[] notes6 = Notes;
                            int num20 = Information.UBound(Notes);
                            notes6[num20].ColumnIndex = 8;
                            notes6[num20].LongNote = (Operators.CompareString(Conversions.ToString(array8[num14][num16 + 3]), "2", TextCompare: false) == 0) | (Operators.CompareString(Conversions.ToString(array8[num14][num16 + 3]), "3", TextCompare: false) == 0);
                            notes6[num20].VPosition = 192 / (Microsoft.VisualBasic.Strings.Len(array8[num14]) / 4) * num16 / 4 + num14 * 192;
                            notes6[num20].Value = 10000L;
                        }
                    }
                }
            }
        }
        if (NTInput)
        {
            ConvertBMSE2NT();
        }
        LWAV.Visible = false;
        LWAV.Items.Clear();
        int num21 = 1;
        do
        {
            LWAV.Items.Add(Functions.C10to36(num21) + ": " + hWAV[num21]);
            num21++;
        }
        while (num21 <= 1295);
        LWAV.SelectedIndex = 0;
        LWAV.Visible = true;
        THBPM.Value = new decimal(Notes[0].Value / 10000.0);
        SortByVPositionQuick(0, Information.UBound(Notes));
        UpdatePairing();
        CalculateTotalPlayableNotes();
        CalculateGreatestVPosition();
        RefreshPanelAll();
        POStatusRefresh();
        return false;
    }

    private void OpeniBMSC(string Path)
    {
        KMouseOver = -1;
        BinaryReader br = new BinaryReader(new FileStream(Path, FileMode.Open, FileAccess.Read), Encoding.Unicode);

        if (br.ReadInt32() == 1397572201 && br.ReadByte() == 67)
        {
            int num = br.ReadByte();
            int num2 = br.ReadByte();
            int num3 = br.ReadByte();
            ClearUndo();
            Notes = new Note[1];
            mColumn = new int[1000];
            hWAV = new string[1296];
            InitializeNewBMS();
            InitializeOpenBMS();
            Note[] notes = Notes;
            int num4 = 0;
            notes[num4].ColumnIndex = 2;
            notes[num4].VPosition = -1.0;
            notes[num4].Value = 1200000L;
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                switch (br.ReadInt32())
                {
                    case 1717924432:
                        {
                            int num17 = br.ReadInt32();
                            NTInput = (num17 & 1) != 0;
                            TBNTInput.Checked = NTInput;
                            mnNTInput.Checked = NTInput;
                            POBLong.Enabled = !NTInput;
                            POBLongShort.Enabled = !NTInput;
                            ErrorCheck = (num17 & 2) != 0;
                            TBErrorCheck.Checked = ErrorCheck;
                            TBErrorCheck_Click(TBErrorCheck, EventArgs.Empty);
                            PreviewOnClick = (num17 & 4) != 0;
                            TBPreviewOnClick.Checked = PreviewOnClick;
                            TBPreviewOnClick_Click(TBPreviewOnClick, EventArgs.Empty);
                            ShowFileName = (num17 & 8) != 0;
                            TBShowFileName.Checked = ShowFileName;
                            TBShowFileName_Click(TBShowFileName, EventArgs.Empty);
                            mnSMenu.Checked = (num17 & 0x100) != 0;
                            mnSTB.Checked = (num17 & 0x200) != 0;
                            mnSOP.Checked = (num17 & 0x400) != 0;
                            mnSStatus.Checked = (num17 & 0x800) != 0;
                            mnSLSplitter.Checked = (num17 & 0x1000) != 0;
                            mnSRSplitter.Checked = (num17 & 0x2000) != 0;
                            CGShow.Checked = (num17 & 0x4000) != 0;
                            CGShowS.Checked = (num17 & 0x8000) != 0;
                            CGShowBG.Checked = (num17 & 0x10000) != 0;
                            CGShowM.Checked = (num17 & 0x20000) != 0;
                            CGShowMB.Checked = (num17 & 0x40000) != 0;
                            CGShowV.Checked = (num17 & 0x80000) != 0;
                            CGShowC.Checked = (num17 & 0x100000) != 0;
                            CGBLP.Checked = (num17 & 0x200000) != 0;
                            CGSTOP.Checked = (num17 & 0x400000) != 0;
                            CGSCROLL.Checked = (num17 & 0x20000000) != 0;
                            CGBPM.Checked = (num17 & 0x800000) != 0;
                            CGSnap.Checked = (num17 & 0x1000000) != 0;
                            CGDisableVertical.Checked = (num17 & 0x2000000) != 0;
                            cVSLockL.Checked = (num17 & 0x4000000) != 0;
                            cVSLock.Checked = (num17 & 0x8000000) != 0;
                            cVSLockR.Checked = (num17 & 0x10000000) != 0;
                            CGDivide.Value = new decimal(br.ReadInt32());
                            CGSub.Value = new decimal(br.ReadInt32());
                            gSlash = br.ReadInt32();
                            CGHeight.Value = new decimal(br.ReadSingle());
                            CGWidth.Value = new decimal(br.ReadSingle());
                            CGB.Value = new decimal(br.ReadInt32());
                            break;
                        }
                    case 1684104520:
                        {
                            THTitle.Text = br.ReadString();
                            THArtist.Text = br.ReadString();
                            THGenre.Text = br.ReadString();
                            Notes[0].Value = br.ReadInt64();
                            int num23 = br.ReadByte();
                            THPlayLevel.Text = br.ReadString();
                            CHPlayer.SelectedIndex = num23 & 0xF;
                            CHRank.SelectedIndex = num23 >> 4;
                            THSubTitle.Text = br.ReadString();
                            THSubArtist.Text = br.ReadString();
                            THStageFile.Text = br.ReadString();
                            THBanner.Text = br.ReadString();
                            THBackBMP.Text = br.ReadString();
                            CHDifficulty.SelectedIndex = br.ReadByte();
                            THExRank.Text = br.ReadString();
                            THTotal.Text = br.ReadString();
                            THComment.Text = br.ReadString();
                            CHLnObj.SelectedIndex = br.ReadInt16();
                            break;
                        }
                    case 5652823:
                        {
                            int num11 = br.ReadByte();
                            WAVMultiSelect = (num11 & 1) != 0;
                            CWAVMultiSelect.Checked = WAVMultiSelect;
                            CWAVMultiSelect_CheckedChanged(CWAVMultiSelect, EventArgs.Empty);
                            WAVChangeLabel = (num11 & 2) != 0;
                            CWAVChangeLabel.Checked = WAVChangeLabel;
                            CWAVChangeLabel_CheckedChanged(CWAVChangeLabel, EventArgs.Empty);
                            int num12 = br.ReadInt32();
                            for (int k = 1; k <= num12; k++)
                            {
                                int num14 = br.ReadInt16();
                                hWAV[num14] = br.ReadString();
                            }
                            break;
                        }
                    case 1952539970:
                        {
                            nBeatN.Value = new decimal(br.ReadInt16());
                            nBeatD.Value = new decimal(br.ReadInt16());
                            int num18 = br.ReadByte();
                            RadioButton[] array = new RadioButton[4] { CBeatPreserve, CBeatMeasure, CBeatCut, CBeatScale };
                            array[num18].Checked = true;
                            CBeatPreserve_Click(array[num18], EventArgs.Empty);
                            int num19 = br.ReadInt32();
                            for (int m = 1; m <= num19; m++)
                            {
                                int num21 = br.ReadInt16();
                                MeasureLength[num21] = br.ReadDouble();
                                double num22 = MeasureLength[num21] / 192.0;
                                long denominator = Functions.GetDenominator(num22, 2147483647L);
                                LBeat.Items[num21] = Operators.ConcatenateObject(string.Concat(Functions.Add3Zeros(num21) + ": ", Conversions.ToString(num22)), Interaction.IIf(denominator > 10000, "", " ( " + Conversions.ToString((long)Math.Round(num22 * denominator)) + " / " + Conversions.ToString(denominator) + " ) "));
                            }
                            break;
                        }
                    case 1852864581:
                        TExpansion.Text = br.ReadString();
                        break;
                    case 1702129486:
                        {
                            int num15 = br.ReadInt32();
                            Notes = (Note[])Utils.CopyArray(Notes, new Note[num15 + 1]);
                            int num16 = Information.UBound(Notes);
                            for (int l = 1; l <= num16; l++)
                            {
                                Notes[l].FromBinReader(ref br);
                            }
                            break;
                        }
                    case 1868852821:
                        {
                            int num5 = br.ReadInt32();
                            sI = br.ReadInt32();
                            int num6 = 0;
                            do
                            {
                                int num7 = br.ReadInt32();
                                UndoRedo.Void @void = new UndoRedo.Void();
                                UndoRedo.LinkedURCmd linkedURCmd = @void;
                                for (int i = 1; i <= num7; i++)
                                {
                                    int count = br.ReadInt32();
                                    byte[] b = br.ReadBytes(count);
                                    linkedURCmd.Next = UndoRedo.fromBytes(b);
                                    linkedURCmd = linkedURCmd.Next;
                                }
                                sUndo[num6] = @void.Next;
                                int num9 = br.ReadInt32();
                                UndoRedo.Void void2 = new UndoRedo.Void();
                                UndoRedo.LinkedURCmd linkedURCmd2 = void2;
                                for (int j = 1; j <= num9; j++)
                                {
                                    int count2 = br.ReadInt32();
                                    byte[] b2 = br.ReadBytes(count2);
                                    linkedURCmd2.Next = UndoRedo.fromBytes(b2);
                                    linkedURCmd2 = linkedURCmd2.Next;
                                }
                                sRedo[num6] = void2.Next;
                                num6++;
                            }
                            while (num6 <= 99);
                            break;
                        }
                }
            }
        }
        br.Close();
        TBUndo.Enabled = sUndo[sI].ofType() != byte.MaxValue;
        TBRedo.Enabled = sRedo[sIA()].ofType() != byte.MaxValue;
        mnUndo.Enabled = sUndo[sI].ofType() != byte.MaxValue;
        mnRedo.Enabled = sRedo[sIA()].ofType() != byte.MaxValue;
        LWAV.Visible = false;
        LWAV.Items.Clear();
        int num24 = 1;
        do
        {
            LWAV.Items.Add(Functions.C10to36(num24) + ": " + hWAV[num24]);
            num24++;
        }
        while (num24 <= 1295);
        LWAV.SelectedIndex = 0;
        LWAV.Visible = true;
        THBPM.Value = new decimal(Notes[0].Value / 10000.0);
        SortByVPositionQuick(0, Information.UBound(Notes));
        UpdatePairing();
        UpdateMeasureBottom();
        CalculateTotalPlayableNotes();
        CalculateGreatestVPosition();
        RefreshPanelAll();
        POStatusRefresh();
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    private void SaveiBMSC(string Path)
    {
        CalculateGreatestVPosition();
        SortByVPositionInsertion();
        UpdatePairing();

        try
        {
            BinaryWriter bw = new BinaryWriter(new FileStream(Path, FileMode.Create), Encoding.Unicode);
            bw.Write(1397572201);
            bw.Write((byte)67);
            bw.Write((byte)MyProject.Application.Info.Version.Major);
            bw.Write((byte)MyProject.Application.Info.Version.Minor);
            bw.Write((byte)MyProject.Application.Info.Version.Build);
            bw.Write(1717924432);
            int num = 0;
            if (NTInput)
            {
                num |= 1;
            }
            if (ErrorCheck)
            {
                num |= 2;
            }
            if (PreviewOnClick)
            {
                num |= 4;
            }
            if (ShowFileName)
            {
                num |= 8;
            }
            if (mnSMenu.Checked)
            {
                num |= 0x100;
            }
            if (mnSTB.Checked)
            {
                num |= 0x200;
            }
            if (mnSOP.Checked)
            {
                num |= 0x400;
            }
            if (mnSStatus.Checked)
            {
                num |= 0x800;
            }
            if (mnSLSplitter.Checked)
            {
                num |= 0x1000;
            }
            if (mnSRSplitter.Checked)
            {
                num |= 0x2000;
            }
            if (gShowGrid)
            {
                num |= 0x4000;
            }
            if (gShowSubGrid)
            {
                num |= 0x8000;
            }
            if (gShowBG)
            {
                num |= 0x10000;
            }
            if (gShowMeasureNumber)
            {
                num |= 0x20000;
            }
            if (gShowMeasureBar)
            {
                num |= 0x40000;
            }
            if (gShowVerticalLine)
            {
                num |= 0x80000;
            }
            if (gShowC)
            {
                num |= 0x100000;
            }
            if (gDisplayBGAColumn)
            {
                num |= 0x200000;
            }
            if (gSTOP)
            {
                num |= 0x400000;
            }
            if (gBPM)
            {
                num |= 0x800000;
            }
            if (gSCROLL)
            {
                num |= 0x20000000;
            }
            if (gSnap)
            {
                num |= 0x1000000;
            }
            if (DisableVerticalMove)
            {
                num |= 0x2000000;
            }
            if (spLock[0])
            {
                num |= 0x4000000;
            }
            if (spLock[1])
            {
                num |= 0x8000000;
            }
            if (spLock[2])
            {
                num |= 0x10000000;
            }
            bw.Write(num);
            bw.Write(BitConverter.GetBytes(gDivide));
            bw.Write(BitConverter.GetBytes(gSub));
            bw.Write(BitConverter.GetBytes(gSlash));
            bw.Write(BitConverter.GetBytes(gxHeight));
            bw.Write(BitConverter.GetBytes(gxWidth));
            bw.Write(BitConverter.GetBytes(gColumns));
            bw.Write(1684104520);
            bw.Write(THTitle.Text);
            bw.Write(THArtist.Text);
            bw.Write(THGenre.Text);
            bw.Write(Notes[0].Value);
            int selectedIndex = CHPlayer.SelectedIndex;
            int num2 = CHRank.SelectedIndex << 4;
            bw.Write((byte)(selectedIndex | num2));
            bw.Write(THPlayLevel.Text);
            bw.Write(THSubTitle.Text);
            bw.Write(THSubArtist.Text);
            bw.Write(THStageFile.Text);
            bw.Write(THBanner.Text);
            bw.Write(THBackBMP.Text);
            bw.Write((byte)CHDifficulty.SelectedIndex);
            bw.Write(THExRank.Text);
            bw.Write(THTotal.Text);
            bw.Write(THComment.Text);
            bw.Write((short)CHLnObj.SelectedIndex);
            bw.Write(5652823);
            int num3 = 0;
            if (WAVMultiSelect)
            {
                num3 |= 1;
            }
            if (WAVChangeLabel)
            {
                num3 |= 2;
            }
            bw.Write((byte)num3);
            int num4 = 0;
            int num5 = Information.UBound(hWAV);
            for (int i = 1; i <= num5; i++)
            {
                if (Operators.CompareString(hWAV[i], "", TextCompare: false) != 0)
                {
                    num4++;
                }
            }
            bw.Write(num4);
            int num6 = Information.UBound(hWAV);
            for (int j = 1; j <= num6; j++)
            {
                if (Operators.CompareString(hWAV[j], "", TextCompare: false) != 0)
                {
                    bw.Write((short)j);
                    bw.Write(hWAV[j]);
                }
            }
            bw.Write(1952539970);
            bw.Write(Convert.ToInt16(nBeatN.Value));
            bw.Write(Convert.ToInt16(nBeatD.Value));
            bw.Write((byte)BeatChangeMode);
            int num7 = 0;
            int num8 = Information.UBound(MeasureLength);
            for (int k = 0; k <= num8; k++)
            {
                if (MeasureLength[k] != 192.0)
                {
                    num7++;
                }
            }
            bw.Write(num7);
            int num9 = Information.UBound(MeasureLength);
            for (int l = 0; l <= num9; l++)
            {
                if (MeasureLength[l] != 192.0)
                {
                    bw.Write((short)l);
                    bw.Write(MeasureLength[l]);
                }
            }
            bw.Write(1852864581);
            bw.Write(TExpansion.Text);
            bw.Write(1702129486);
            bw.Write(Information.UBound(Notes));
            int num10 = Information.UBound(Notes);
            for (int m = 1; m <= num10; m++)
            {
                Notes[m].WriteBinWriter(ref bw);
            }
            bw.Write(1868852821);
            bw.Write(100);
            bw.Write(sI);
            int num11 = 0;
            do
            {
                int num12 = 0;
                UndoRedo.LinkedURCmd linkedURCmd;
                for (linkedURCmd = sUndo[num11]; linkedURCmd != null; linkedURCmd = linkedURCmd.Next)
                {
                    num12++;
                }
                bw.Write(num12);
                linkedURCmd = sUndo[num11];
                int num13 = num12;
                for (int n = 1; n <= num13; n++)
                {
                    byte[] array = linkedURCmd.toBytes();
                    bw.Write(array.Length);
                    bw.Write(array);
                    linkedURCmd = linkedURCmd.Next;
                }
                int num14 = 0;
                UndoRedo.LinkedURCmd linkedURCmd2;
                for (linkedURCmd2 = sRedo[num11]; linkedURCmd2 != null; linkedURCmd2 = linkedURCmd2.Next)
                {
                    num14++;
                }
                bw.Write(num14);
                linkedURCmd2 = sRedo[num11];
                int num15 = num14;
                for (int num16 = 1; num16 <= num15; num16++)
                {
                    byte[] array2 = linkedURCmd2.toBytes();
                    bw.Write(array2.Length);
                    bw.Write(array2);
                    linkedURCmd2 = linkedURCmd2.Next;
                }
                num11++;
            }
            while (num11 <= 99);
            bw.Close();
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Interaction.MsgBox(ex.Message);
            ProjectData.ClearProjectError();
        }
    }


    private void NewRecent(string xFileName)
    {
        bool flag = false;
        int num = 0;
        do
        {
            if (Operators.CompareString(Recent[num], xFileName, TextCompare: false) == 0)
            {
                flag = true;
                break;
            }
            num++;
        }
        while (num <= 4);
        if (flag)
        {
            for (int i = num; i >= 1; i += -1)
            {
                Recent[i] = Recent[i - 1];
            }
            Recent[0] = xFileName;
        }
        else
        {
            Recent[4] = Recent[3];
            Recent[3] = Recent[2];
            Recent[2] = Recent[1];
            Recent[1] = Recent[0];
            Recent[0] = xFileName;
        }
        SetRecent(4, Recent[4]);
        SetRecent(3, Recent[3]);
        SetRecent(2, Recent[2]);
        SetRecent(1, Recent[1]);
        SetRecent(0, Recent[0]);

    }

    private void SetRecent(int Index, string Text)
    {
        //Discarded unreachable code: IL_0073
        Text = Text.Trim();
        ToolStripMenuItem toolStripMenuItem;
        ToolStripMenuItem toolStripMenuItem2;
        switch (Index)
        {
            default:
                return;
            case 0:
                toolStripMenuItem = TBOpenR0;
                toolStripMenuItem2 = mnOpenR0;
                break;
            case 1:
                toolStripMenuItem = TBOpenR1;
                toolStripMenuItem2 = mnOpenR1;
                break;
            case 2:
                toolStripMenuItem = TBOpenR2;
                toolStripMenuItem2 = mnOpenR2;
                break;
            case 3:
                toolStripMenuItem = TBOpenR3;
                toolStripMenuItem2 = mnOpenR3;
                break;
            case 4:
                toolStripMenuItem = TBOpenR4;
                toolStripMenuItem2 = mnOpenR4;
                break;
        }
        toolStripMenuItem.Text = Conversions.ToString(Interaction.IIf(Operators.CompareString(Text, "", TextCompare: false) == 0, "<" + Strings1.None + ">", GetFileName(Text)));
        toolStripMenuItem.ToolTipText = Text;
        toolStripMenuItem.Enabled = Operators.CompareString(Text, "", TextCompare: false) != 0;
        toolStripMenuItem2.Text = Conversions.ToString(Interaction.IIf(Operators.CompareString(Text, "", TextCompare: false) == 0, "<" + Strings1.None + ">", GetFileName(Text)));
        toolStripMenuItem2.ToolTipText = Text;
        toolStripMenuItem2.Enabled = Operators.CompareString(Text, "", TextCompare: false) != 0;
    }

    private void OpenRecent(string xFileName)
    {
        SelectedNotes = Array.Empty<Note>();
        KMouseOver = -1;
        if (!MyProject.Computer.FileSystem.FileExists(xFileName))
        {
            Interaction.MsgBox(Strings1.Messages.CannotFind.Replace("{}", xFileName), MsgBoxStyle.Critical);
        }
        else if (!ClosingPopSave())
        {
            switch (Microsoft.VisualBasic.Strings.UCase(Path.GetExtension(xFileName)))
            {
                case ".BMS":
                case ".BME":
                case ".BML":
                case ".PMS":
                case ".TXT":
                    InitPath = ExcludeFileName(xFileName);
                    SetFileName(xFileName);
                    ClearUndo();
                    OpenBMS(MyProject.Computer.FileSystem.ReadAllText(xFileName, TextEncoding));
                    SetFileName(FileName);
                    SetIsSaved(isSaved: true);
                    break;
                case ".IBMSC":
                    InitPath = ExcludeFileName(xFileName);
                    SetFileName("Imported_" + GetFileName(xFileName));
                    OpeniBMSC(xFileName);
                    SetIsSaved(isSaved: false);
                    break;
            }
        }
    }

    private void TBOpenR0_Click(object sender, EventArgs e)
    {
        OpenRecent(Recent[0]);
    }

    private void TBOpenR1_Click(object sender, EventArgs e)
    {
        OpenRecent(Recent[1]);
    }

    private void TBOpenR2_Click(object sender, EventArgs e)
    {
        OpenRecent(Recent[2]);
    }

    private void TBOpenR3_Click(object sender, EventArgs e)
    {
        OpenRecent(Recent[3]);
    }

    private void TBOpenR4_Click(object sender, EventArgs e)
    {
        OpenRecent(Recent[4]);
    }

    private void PerformCommand(UndoRedo.LinkedURCmd sCmd)
    {
        int num = Information.UBound(Notes);
        for (int i = 1; i <= num; i++)
        {
            Notes[i].Selected = false;
        }
        LBeat.SelectedIndices.Clear();
        while (sCmd != null)
        {
            switch (sCmd.ofType())
            {
                case 1:
                    {
                        UndoRedo.AddNote addNote = (UndoRedo.AddNote)sCmd;
                        Notes = (Note[])Utils.CopyArray(Notes, new Note[Information.UBound(Notes) + 1 + 1]);
                        ref Note reference = ref Notes[Information.UBound(Notes)];
                        reference = addNote.note;
                        if (TBWavIncrease.Checked)
                        {
                            IncreaseCurrentWav();
                        }
                        break;
                    }
                case 2:
                    {
                        UndoRedo.RemoveNote removeNote = (UndoRedo.RemoveNote)sCmd;
                        int num7 = FindNoteIndex(removeNote.note);
                        if (num7 < Notes.Length)
                        {
                            int num8 = num7 + 1;
                            int num9 = Information.UBound(Notes);
                            for (int k = num8; k <= num9; k++)
                            {
                                ref Note reference2 = ref Notes[k - 1];
                                reference2 = Notes[k];
                            }
                            Notes = (Note[])Utils.CopyArray(Notes, new Note[Information.UBound(Notes) - 1 + 1]);
                        }
                        if (TBWavIncrease.Checked)
                        {
                            DecreaseCurrentWav();
                        }
                        break;
                    }
                case 3:
                    {
                        UndoRedo.ChangeNote changeNote = (UndoRedo.ChangeNote)sCmd;
                        int num15 = FindNoteIndex(changeNote.note);
                        if (num15 < Notes.Length)
                        {
                            ref Note reference3 = ref Notes[num15];
                            reference3 = changeNote.note;
                        }
                        break;
                    }
                case 4:
                    {
                        UndoRedo.MoveNote moveNote = (UndoRedo.MoveNote)sCmd;
                        int num13 = FindNoteIndex(moveNote.note);
                        if (num13 < Notes.Length)
                        {
                            Note[] notes2 = Notes;
                            notes2[num13].ColumnIndex = moveNote.NColumnIndex;
                            notes2[num13].VPosition = moveNote.NVPosition;
                            notes2[num13].Selected = moveNote.note.Selected & nEnabled(notes2[num13].ColumnIndex);
                        }
                        break;
                    }
                case 5:
                    {
                        UndoRedo.LongNoteModify longNoteModify = (UndoRedo.LongNoteModify)sCmd;
                        int num10 = FindNoteIndex(longNoteModify.note);
                        if (num10 < Notes.Length)
                        {
                            Note[] notes = Notes;
                            if (NTInput)
                            {
                                notes[num10].VPosition = longNoteModify.NVPosition;
                                notes[num10].Length = longNoteModify.NLongNote;
                            }
                            else
                            {
                                notes[num10].LongNote = longNoteModify.NLongNote != 0.0;
                            }
                            notes[num10].Selected = longNoteModify.note.Selected & nEnabled(notes[num10].ColumnIndex);
                        }
                        break;
                    }
                case 6:
                    {
                        UndoRedo.HiddenNoteModify hiddenNoteModify = (UndoRedo.HiddenNoteModify)sCmd;
                        int num3 = FindNoteIndex(hiddenNoteModify.note);
                        if (num3 < Notes.Length)
                        {
                            Notes[num3].Hidden = hiddenNoteModify.NHidden;
                            Notes[num3].Selected = hiddenNoteModify.note.Selected & nEnabled(Notes[num3].ColumnIndex);
                        }
                        break;
                    }
                case 7:
                    {
                        UndoRedo.RelabelNote relabelNote = (UndoRedo.RelabelNote)sCmd;
                        int num2 = FindNoteIndex(relabelNote.note);
                        if (num2 < Notes.Length)
                        {
                            Notes[num2].Value = relabelNote.NValue;
                            Notes[num2].Selected = relabelNote.note.Selected & nEnabled(Notes[num2].ColumnIndex);
                        }
                        break;
                    }
                case 15:
                    Notes = (Note[])Utils.CopyArray(Notes, new Note[1]);
                    break;
                case 16:
                    {
                        UndoRedo.ChangeMeasureLength changeMeasureLength = (UndoRedo.ChangeMeasureLength)sCmd;
                        long denominator = Functions.GetDenominator(changeMeasureLength.Value / 192.0, 2147483647L);
                        int[] indices = changeMeasureLength.Indices;
                        foreach (int num12 in indices)
                        {
                            MeasureLength[num12] = changeMeasureLength.Value;
                            LBeat.Items[num12] = Operators.ConcatenateObject(string.Concat(Functions.Add3Zeros(num12) + ": ", Conversions.ToString(changeMeasureLength.Value / 192.0)), Interaction.IIf(denominator > 10000, "", " ( " + Conversions.ToString((long)Math.Round(changeMeasureLength.Value / 192.0 * denominator)) + " / " + Conversions.ToString(denominator) + " ) "));
                            LBeat.SelectedIndices.Add(num12);
                        }
                        UpdateMeasureBottom();
                        break;
                    }
                case 17:
                    {
                        UndoRedo.ChangeTimeSelection changeTimeSelection = (UndoRedo.ChangeTimeSelection)sCmd;
                        vSelStart = changeTimeSelection.SelStart;
                        vSelLength = changeTimeSelection.SelLength;
                        vSelHalf = changeTimeSelection.SelHalf;
                        if (changeTimeSelection.Selected)
                        {
                            double num4 = Conversions.ToDouble(Operators.AddObject(vSelStart, Interaction.IIf(vSelLength < 0.0, vSelLength, 0)));
                            double num5 = Conversions.ToDouble(Operators.AddObject(vSelStart, Interaction.IIf(vSelLength > 0.0, vSelLength, 0)));
                            int num6 = Information.UBound(Notes);
                            for (int j = 1; j <= num6; j++)
                            {
                                Notes[j].Selected = Notes[j].VPosition >= num4 && Notes[j].VPosition < num5 && nEnabled(Notes[j].ColumnIndex) ? true : false;
                            }
                        }
                        break;
                    }
                case 18:
                    {
                        UndoRedo.NT nT = (UndoRedo.NT)sCmd;
                        NTInput = nT.BecomeNT;
                        TBNTInput.Checked = NTInput;
                        mnNTInput.Checked = NTInput;
                        POBLong.Enabled = !NTInput;
                        POBLongShort.Enabled = !NTInput;
                        bAdjustLength = false;
                        bAdjustUpper = false;
                        if (nT.AutoConvert)
                        {
                            if (NTInput)
                            {
                                ConvertBMSE2NT();
                            }
                            else
                            {
                                ConvertNT2BMSE();
                            }
                        }
                        break;
                    }
                case 20:
                    {
                        UndoRedo.WavAutoincFlag wavAutoincFlag = (UndoRedo.WavAutoincFlag)sCmd;
                        TBWavIncrease.Checked = wavAutoincFlag.Checked;
                        break;
                    }
            }
            sCmd = sCmd.Next;
        }
        THBPM.Value = new decimal(Notes[0].Value / 10000.0);
        if (IsSaved)
        {
            SetIsSaved(isSaved: false);
        }
        SortByVPositionInsertion();
        UpdatePairing();
        CalculateTotalPlayableNotes();
        CalculateGreatestVPosition();
        RefreshPanelAll();
        POStatusRefresh();
    }

    private void AddUndo(UndoRedo.LinkedURCmd sCUndo, UndoRedo.LinkedURCmd sCRedo, bool OverWrite = false)
    {
        if (!(sCUndo == null && sCRedo == null))
        {
            if (IsSaved)
            {
                SetIsSaved(isSaved: false);
            }
            if (!OverWrite)
            {
                sI = sIA();
            }
            sUndo[sI] = sCUndo;
            sRedo[sI] = sCRedo;
            sUndo[sIA()] = new UndoRedo.NoOperation();
            sRedo[sIA()] = new UndoRedo.NoOperation();
            TBUndo.Enabled = true;
            TBRedo.Enabled = false;
            mnUndo.Enabled = true;
            mnRedo.Enabled = false;
        }
    }

    private void ClearUndo()
    {
        sUndo = new UndoRedo.LinkedURCmd[100];
        sRedo = new UndoRedo.LinkedURCmd[100];
        sUndo[0] = new UndoRedo.NoOperation();
        sUndo[1] = new UndoRedo.NoOperation();
        sRedo[0] = new UndoRedo.NoOperation();
        sRedo[1] = new UndoRedo.NoOperation();
        sI = 0;
        TBUndo.Enabled = false;
        TBRedo.Enabled = false;
        mnUndo.Enabled = false;
        mnRedo.Enabled = false;
    }

    private void RedoAddNote(Note note, ref UndoRedo.LinkedURCmd BaseUndo, ref UndoRedo.LinkedURCmd BaseRedo, bool autoinc = false)
    {
        UndoRedo.RemoveNote removeNote = new UndoRedo.RemoveNote(note);
        UndoRedo.AddNote addNote = new UndoRedo.AddNote(note);
        removeNote.Next = BaseUndo;
        BaseUndo = removeNote;
        if (BaseRedo != null)
        {
            BaseRedo.Next = addNote;
        }
        BaseRedo = addNote;
    }

    private void RedoAddNote(int[] xIndices, bool xSel, ref UndoRedo.LinkedURCmd BaseUndo, ref UndoRedo.LinkedURCmd BaseRedo)
    {
        int num = Information.UBound(xIndices);
        for (int i = 0; i <= num; i += 1)
        {
            UndoRedo.RemoveNote removeNote = new UndoRedo.RemoveNote(Notes[i]);
            UndoRedo.AddNote addNote = new UndoRedo.AddNote(Notes[i]);
            removeNote.Next = BaseUndo;
            BaseUndo = removeNote;
            if (BaseRedo != null)
            {
                BaseRedo.Next = addNote;
            }
            BaseRedo = addNote;
        }
    }

    private void RedoAddNoteSelected(bool xSel, ref UndoRedo.LinkedURCmd BaseUndo, ref UndoRedo.LinkedURCmd BaseRedo)
    {
        int num = Information.UBound(Notes);
        for (int i = 1; i <= num; i += 1)
        {
            if (Notes[i].Selected)
            {
                UndoRedo.RemoveNote removeNote = new UndoRedo.RemoveNote(Notes[i]);
                UndoRedo.AddNote addNote = new UndoRedo.AddNote(Notes[i]);
                removeNote.Next = BaseUndo;
                BaseUndo = removeNote;
                if (BaseRedo != null)
                {
                    BaseRedo.Next = addNote;
                }
                BaseRedo = addNote;
            }
        }
    }

    private void RedoAddNoteAll(bool xSel, ref UndoRedo.LinkedURCmd BaseUndo, ref UndoRedo.LinkedURCmd BaseRedo)
    {
        int num = Information.UBound(Notes);
        for (int i = 1; i <= num; i += 1)
        {
            UndoRedo.AddNote addNote = new UndoRedo.AddNote(Notes[i]);
            if (BaseRedo != null)
            {
                BaseRedo.Next = addNote;
            }
            BaseRedo = addNote;
        }
        UndoRedo.RemoveAllNotes removeAllNotes = new UndoRedo.RemoveAllNotes();
        removeAllNotes.Next = BaseUndo;
        BaseUndo = removeAllNotes;
    }

    private void RedoRemoveNote(Note xN, ref UndoRedo.LinkedURCmd BaseUndo, ref UndoRedo.LinkedURCmd BaseRedo)
    {
        UndoRedo.AddNote addNote = new UndoRedo.AddNote(xN);
        UndoRedo.RemoveNote removeNote = new UndoRedo.RemoveNote(xN);
        addNote.Next = BaseUndo;
        BaseUndo = addNote;
        if (BaseRedo != null)
        {
            BaseRedo.Next = removeNote;
        }
        BaseRedo = removeNote;
    }

    private void RedoRemoveNote(int[] xIndices, ref UndoRedo.LinkedURCmd BaseUndo, ref UndoRedo.LinkedURCmd BaseRedo)
    {
        int num = Information.UBound(xIndices);
        for (int i = 0; i <= num; i += 1)
        {
            UndoRedo.AddNote addNote = new UndoRedo.AddNote(Notes[xIndices[i]]);
            UndoRedo.RemoveNote removeNote = new UndoRedo.RemoveNote(Notes[xIndices[i]]);
            addNote.Next = BaseUndo;
            BaseUndo = addNote;
            if (BaseRedo != null)
            {
                BaseRedo.Next = removeNote;
            }
            BaseRedo = removeNote;
        }
    }

    private void RedoRemoveNoteSelected(bool xSel, ref UndoRedo.LinkedURCmd BaseUndo, ref UndoRedo.LinkedURCmd BaseRedo)
    {
        int num = Information.UBound(Notes);
        for (int i = 1; i <= num; i += 1)
        {
            if (Notes[i].Selected)
            {
                UndoRedo.AddNote addNote = new UndoRedo.AddNote(Notes[i]);
                UndoRedo.RemoveNote removeNote = new UndoRedo.RemoveNote(Notes[i]);
                addNote.Next = BaseUndo;
                BaseUndo = addNote;
                if (BaseRedo != null)
                {
                    BaseRedo.Next = removeNote;
                }
                BaseRedo = removeNote;
            }
        }
    }

    private void RedoRemoveNoteAll(bool xSel, ref UndoRedo.LinkedURCmd BaseUndo, ref UndoRedo.LinkedURCmd BaseRedo)
    {
        int num = Information.UBound(Notes);
        for (int i = 1; i <= num; i += 1)
        {
            Note[] notes = Notes;
            int num2 = i;
            UndoRedo.AddNote addNote = new UndoRedo.AddNote(Notes[i]);
            addNote.Next = BaseUndo;
            BaseUndo = addNote;
        }
        UndoRedo.RemoveAllNotes removeAllNotes = new UndoRedo.RemoveAllNotes();
        if (BaseRedo != null)
        {
            BaseRedo.Next = removeAllNotes;
        }
        BaseRedo = removeAllNotes;
    }

    private void RedoChangeNote(Note note1, Note note2, ref UndoRedo.LinkedURCmd BaseUndo, ref UndoRedo.LinkedURCmd BaseRedo)
    {
        UndoRedo.ChangeNote changeNote = new UndoRedo.ChangeNote(note2, note1);
        UndoRedo.ChangeNote changeNote2 = new UndoRedo.ChangeNote(note1, note2);
        changeNote.Next = BaseUndo;
        BaseUndo = changeNote;
        if (BaseRedo != null)
        {
            BaseRedo.Next = changeNote2;
        }
        BaseRedo = changeNote2;
    }

    private void RedoMoveNote(Note note, int nCol, double nVPos, ref UndoRedo.LinkedURCmd BaseUndo, ref UndoRedo.LinkedURCmd BaseRedo)
    {
        Note note2 = note;
        note2.ColumnIndex = nCol;
        note2.VPosition = nVPos;
        UndoRedo.MoveNote moveNote = new UndoRedo.MoveNote(note2, note.ColumnIndex, note.VPosition);
        UndoRedo.MoveNote moveNote2 = new UndoRedo.MoveNote(note, nCol, nVPos);
        moveNote.Next = BaseUndo;
        BaseUndo = moveNote;
        if (BaseRedo != null)
        {
            BaseRedo.Next = moveNote2;
        }
        BaseRedo = moveNote2;
    }

    private void RedoLongNoteModify(Note note, double nVPos, double nLong, ref UndoRedo.LinkedURCmd BaseUndo, ref UndoRedo.LinkedURCmd BaseRedo)
    {
        Note note2 = note;
        note2.VPosition = nVPos;
        note2.Length = nLong;
        UndoRedo.LongNoteModify longNoteModify = new UndoRedo.LongNoteModify(note2, note.VPosition, note.Length);
        UndoRedo.LongNoteModify longNoteModify2 = new UndoRedo.LongNoteModify(note, nVPos, note2.Length);
        longNoteModify.Next = BaseUndo;
        BaseUndo = longNoteModify;
        if (BaseRedo != null)
        {
            BaseRedo.Next = longNoteModify2;
        }
        BaseRedo = longNoteModify2;
    }

    private void RedoHiddenNoteModify(Note xN, bool nHide, bool xSel, ref UndoRedo.LinkedURCmd BaseUndo, ref UndoRedo.LinkedURCmd BaseRedo)
    {
        Note note = xN;
        note.Hidden = nHide;
        UndoRedo.HiddenNoteModify hiddenNoteModify = new UndoRedo.HiddenNoteModify(note, xN.Hidden);
        UndoRedo.HiddenNoteModify hiddenNoteModify2 = new UndoRedo.HiddenNoteModify(xN, nHide);
        hiddenNoteModify.Next = BaseUndo;
        BaseUndo = hiddenNoteModify;
        if (BaseRedo != null)
        {
            BaseRedo.Next = hiddenNoteModify2;
        }
        BaseRedo = hiddenNoteModify2;
    }

    private void RedoRelabelNote(Note xN, long nVal, ref UndoRedo.LinkedURCmd BaseUndo, ref UndoRedo.LinkedURCmd BaseRedo)
    {
        Note note = xN;
        note.Value = nVal;
        UndoRedo.RelabelNote relabelNote = new UndoRedo.RelabelNote(note, xN.Value);
        UndoRedo.RelabelNote relabelNote2 = new UndoRedo.RelabelNote(xN, nVal);
        relabelNote.Next = BaseUndo;
        BaseUndo = relabelNote;
        if (BaseRedo != null)
        {
            BaseRedo.Next = relabelNote2;
        }
        BaseRedo = relabelNote2;
    }

    private void RedoChangeMeasureLengthSelected(double nVal, ref UndoRedo.LinkedURCmd BaseUndo, ref UndoRedo.LinkedURCmd BaseRedo)
    {
        int[] array = new int[LBeat.SelectedIndices.Count - 1 + 1];
        LBeat.SelectedIndices.CopyTo(array, 0);
        if (array.Length == 0)
        {
            return;
        }

        double[] array2 = Array.Empty<double>();
        UndoRedo.ChangeMeasureLength[] array3 = Array.Empty<UndoRedo.ChangeMeasureLength>();
        foreach (int num in array)
        {
            int num2 = Array.IndexOf(array2, MeasureLength[num]);
            if (num2 == -1)
            {
                array2 = (double[])Utils.CopyArray(array2, new double[Information.UBound(array2) + 1 + 1]);
                array3 = (UndoRedo.ChangeMeasureLength[])Utils.CopyArray(array3, new UndoRedo.ChangeMeasureLength[Information.UBound(array3) + 1 + 1]);
                array2[Information.UBound(array2)] = MeasureLength[num];
                array3[Information.UBound(array3)] = new UndoRedo.ChangeMeasureLength(MeasureLength[num], new int[1] { num });
            }
            else
            {
                UndoRedo.ChangeMeasureLength changeMeasureLength = array3[num2];
                changeMeasureLength.Indices = (int[])Utils.CopyArray(changeMeasureLength.Indices, new int[Information.UBound(changeMeasureLength.Indices) + 1 + 1]);
                changeMeasureLength.Indices[Information.UBound(changeMeasureLength.Indices)] = num;
                changeMeasureLength = null;
            }
        }
        int num3 = Information.UBound(array3) - 1;
        for (int j = 0; j <= num3; j++)
        {
            array3[j].Next = array3[j + 1];
        }
        array3[Information.UBound(array3)].Next = BaseUndo;
        BaseUndo = array3[0];
        UndoRedo.ChangeMeasureLength changeMeasureLength2 = new UndoRedo.ChangeMeasureLength(nVal, (int[])array.Clone());
        if (BaseRedo != null)
        {
            BaseRedo.Next = changeMeasureLength2;
        }
        BaseRedo = changeMeasureLength2;
    }

    private void RedoChangeTimeSelection(double pStart, double pLen, double pHalf, double nStart, double nLen, double nHalf, bool xSel, ref UndoRedo.LinkedURCmd BaseUndo, ref UndoRedo.LinkedURCmd BaseRedo)
    {
        UndoRedo.ChangeTimeSelection changeTimeSelection = new UndoRedo.ChangeTimeSelection(pStart, pLen, pHalf, xSel);
        UndoRedo.ChangeTimeSelection changeTimeSelection2 = new UndoRedo.ChangeTimeSelection(nStart, nLen, nHalf, xSel);
        changeTimeSelection.Next = BaseUndo;
        BaseUndo = changeTimeSelection;
        if (BaseRedo != null)
        {
            BaseRedo.Next = changeTimeSelection2;
        }
        BaseRedo = changeTimeSelection2;
    }

    private void RedoNT(bool becomeNT, bool autoConvert, ref UndoRedo.LinkedURCmd BaseUndo, ref UndoRedo.LinkedURCmd BaseRedo)
    {
        UndoRedo.NT nT = new UndoRedo.NT(!becomeNT, autoConvert);
        UndoRedo.NT nT2 = new UndoRedo.NT(becomeNT, autoConvert);
        nT.Next = BaseUndo;
        BaseUndo = nT;
        if (BaseRedo != null)
        {
            BaseRedo.Next = nT2;
        }
        BaseRedo = nT2;
    }

    private void RedoWavIncrease(bool wavinc, ref UndoRedo.LinkedURCmd BaseUndo, ref UndoRedo.LinkedURCmd BaseRedo)
    {
        UndoRedo.WavAutoincFlag wavAutoincFlag = new UndoRedo.WavAutoincFlag(!wavinc);
        UndoRedo.WavAutoincFlag wavAutoincFlag2 = new UndoRedo.WavAutoincFlag(wavinc);
        wavAutoincFlag.Next = BaseUndo;
        BaseUndo = wavAutoincFlag;
        if (BaseUndo != null)
        {
            BaseRedo.Next = wavAutoincFlag2;
        }
        BaseRedo = wavAutoincFlag2;
    }

    [DllImport("user32.dll", CharSet = CharSet.Ansi, EntryPoint = "SendMessageA", ExactSpelling = true, SetLastError = true)]
    public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

    [DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
    public static extern int ReleaseCapture();

    public double MeasureUpper(int idx)
    {
        return MeasureBottom[idx] + MeasureLength[idx];
    }

    public void setVO(visualSettings xvo)
    {
        vo = xvo;
    }

    public MainWindow()
    {
        FormClosed += Form1_FormClosed;
        FormClosing += Form1_FormClosing;
        DragEnter += Form1_DragEnter;
        DragLeave += Form1_DragLeave;
        DragDrop += Form1_DragDrop;
        KeyDown += Form1_KeyDown;
        KeyUp += Form1_KeyUp;
        Disposed += [SpecialName][DebuggerStepThrough] (object a0, EventArgs a1) =>
        {
            Unload();
        };
        Load += Form1_Load;
        BMSChannelList = new string[]
        {
            "01", "03", "04", "06", "07", "08", "09", "11", "12", "13",
            "14", "15", "16", "18", "19", "21", "22", "23", "24", "25",
            "26", "28", "29", "31", "32", "33", "34", "35", "36", "38",
            "39", "41", "42", "43", "44", "45", "46", "48", "49", "51",
            "52", "53", "54", "55", "56", "58", "59", "61", "62", "63",
            "64", "65", "66", "68", "69", "D1", "D2", "D3", "D4", "D5",
            "D6", "D8", "D9", "E1", "E2", "E3", "E4", "E5", "E6", "E8",
            "E9", "SC"
        };

        MeasureLength = new double[1000];
        MeasureBottom = new double[1000];
        var array2 = new Note[1];
        ref var reference29 = ref array2[0];
        var note = new Note(2, -1.0, 1200000L);
        reference29 = note;
        Notes = array2;
        mColumn = new int[1000];
        VSValue = 0;
        HSValue = 0;
        MiddleButtonMoveMethod = 0;
        TextEncoding = Encoding.UTF8;
        DispLang = "";
        Recent = new string[5] { "", "", "", "", "" };
        NTInput = true;
        ShowFileName = false;
        BeepWhileSaved = true;
        BPMx1296 = false;
        STOPx1296 = false;
        IsInitializing = true;
        FirstMouseEnter = true;
        WAVMultiSelect = true;
        WAVChangeLabel = true;
        BeatChangeMode = 0;
        BMSGridLimit = 1.0;
        LnObj = 0;
        FileName = "Untitled.bms";
        InitPath = "";
        IsSaved = true;
        DDFileName = Array.Empty<string>();
        SupportedFileExtension = new string[7] { ".bms", ".bme", ".bml", ".pms", ".txt", ".sm", ".ibmsc" };
        SupportedAudioExtension = new string[3] { ".wav", ".mp3", ".ogg" };
        sUndo = new UndoRedo.LinkedURCmd[100];
        sRedo = new UndoRedo.LinkedURCmd[100];
        sI = 0;
        DisableVerticalMove = false;
        KMouseOver = -1;
        var point = new Point(-1, -1);
        LastMouseDownLocation = point;
        point = new Point(-1, -1);
        pMouseMove = point;
        deltaVPosition = 0.0;
        MiddleButtonLocation = new Point(0, 0);
        MiddleButtonClicked = false;
        MouseMoveStatus = new Point(0, 0);
        SelectedNotes = Array.Empty<Note>();
        ctrlPressed = false;
        DuplicatedSelectedNotes = false;
        ShouldDrawTempNote = false;
        SelectedColumn = -1;
        TempVPosition = -1.0;
        TempLength = 0.0;
        vSelStart = 192.0;
        vSelLength = 0.0;
        vSelHalf = 0.0;
        vSelMouseOverLine = 0;
        vSelAdjust = false;
        vSelK = Array.Empty<Note>();
        vSelPStart = 192.0;
        vSelPLength = 0.0;
        vSelPHalf = 0.0;
        isFullScreen = false;
        previousWindowState = FormWindowState.Normal;
        previousWindowPosition = new Rectangle(0, 0, 0, 0);
        menuVPosition = 0.0;
        tempResize = 0;
        PreviousAutoSavedFileName = "";
        AutoSaveInterval = 120000;
        ErrorCheck = true;
        hWAV = new string[1296];
        hBPM = new long[1296];
        hSTOP = new long[1296];
        hSCROLL = new long[1296];
        gSnap = true;
        gShowGrid = true;
        gShowSubGrid = true;
        gShowBG = true;
        gShowMeasureNumber = true;
        gShowVerticalLine = true;
        gShowMeasureBar = true;
        gShowC = true;
        gDivide = 16;
        gSub = 4;
        gSlash = 192;
        gxHeight = 1f;
        gxWidth = 1f;
        gWheel = 96;
        gPgUpDn = 384;
        gDisplayBGAColumn = true;
        gSCROLL = true;
        gSTOP = true;
        gBPM = true;
        iPlayer = 0;
        gColumns = 46;
        vo = new visualSettings();
        var array3 = new PlayerArguments[2];
        ref var reference31 = ref array3[0];
        var playerArguments = new PlayerArguments("<apppath>\\uBMplay.exe", "-P -N0 \"<filename>\"", "-P -N<measure> \"<filename>\"", "-S");
        reference31 = playerArguments;
        ref var reference32 = ref array3[1];
        var playerArguments2 = new PlayerArguments("<apppath>\\o2play.exe", "-P -N0 \"<filename>\"", "-P -N<measure> \"<filename>\"", "-S");
        reference32 = playerArguments2;
        pArgs = array3;
        CurrentPlayer = 0;
        PreviewOnClick = true;
        PreviewErrorCheck = false;
        ClickStopPreview = true;
        pTempFileNames = Array.Empty<string>();
        PanelWidth = new float[3] { 0f, 100f, 0f };
        PanelHScroll = new int[3] { 0, 0, 0 };
        PanelVScroll = new int[3] { 0, 0, 0 };
        spLock = new bool[3] { false, false, false };
        spDiff = new int[3] { 0, 0, 0 };
        PanelFocus = 1;
        spMouseOver = 1;
        AutoFocusMouseEnter = false;
        FirstClickDisabled = true;
        tempFirstMouseDown = false;
        spMain = Array.Empty<Panel>();
        bufferlist = new Dictionary<int, BufferedGraphics>();
        rectList = new Dictionary<int, Rectangle>();
        lastVPos = -1;
        lastColumn = -1;
        wLock = true;
        wPosition = 0.0;
        wLeft = 50;
        wWidth = 100;
        wPrecision = 1;


        InitializeComponent();
        Audio.Initialize();
    }
}
