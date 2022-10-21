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

    public const int niMeasure = 0;

    public const int niSCROLL = 1;

    public const int niBPM = 2;

    public const int niSTOP = 3;

    public const int niS1 = 4;

    public const int niA1 = 5;

    public const int niA2 = 6;

    public const int niA3 = 7;

    public const int niA4 = 8;

    public const int niA5 = 9;

    public const int niA6 = 10;

    public const int niA7 = 11;

    public const int niA8 = 12;

    public const int niS2 = 13;

    public const int niD1 = 14;

    public const int niD2 = 15;

    public const int niD3 = 16;

    public const int niD4 = 17;

    public const int niD5 = 18;

    public const int niD6 = 19;

    public const int niD7 = 20;

    public const int niD8 = 21;

    public const int niS3 = 22;

    public const int niBGA = 23;

    public const int niLAYER = 24;

    public const int niPOOR = 25;

    public const int niS4 = 26;

    public const int niB = 27;

    public Column[] column;

    public const int idflBPM = 5;

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
            Interaction.MsgBox(Strings.Messages.SaveWarning + "\r\n" + Strings.Messages.NoteOverlapError + "\r\n" + Strings.Messages.SavedFileWillContainErrors, MsgBoxStyle.Exclamation);
        }
        if (Operators.ConditionalCompareObjectGreater(Information.UBound(hBPM), Interaction.IIf(BPMx1296, 1295, 255), TextCompare: false))
        {
            Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(string.Concat(string.Concat(string.Concat(Strings.Messages.SaveWarning + "\r\n", Strings.Messages.BPMOverflowError), Conversions.ToString(Information.UBound(hBPM))), " > "), Interaction.IIf(BPMx1296, 1295, 255)), "\r\n"), Strings.Messages.SavedFileWillContainErrors), MsgBoxStyle.Exclamation);
        }
        if (Operators.ConditionalCompareObjectGreater(Information.UBound(hSTOP), Interaction.IIf(STOPx1296, 1295, 255), TextCompare: false))
        {
            Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(string.Concat(string.Concat(string.Concat(Strings.Messages.SaveWarning + "\r\n", Strings.Messages.STOPOverflowError), Conversions.ToString(Information.UBound(hSTOP))), " > "), Interaction.IIf(STOPx1296, 1295, 255)), "\r\n"), Strings.Messages.SavedFileWillContainErrors), MsgBoxStyle.Exclamation);
        }
        if (Information.UBound(hSCROLL) > 1295)
        {
            Interaction.MsgBox(Strings.Messages.SaveWarning + "\r\n" + Strings.Messages.SCROLLOverflowError + Conversions.ToString(Information.UBound(hSCROLL)) + " > " + Conversions.ToString(1295) + "\r\n" + Strings.Messages.SavedFileWillContainErrors, MsgBoxStyle.Exclamation);
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
                            TBErrorCheck_Click(TBErrorCheck, new EventArgs());
                            PreviewOnClick = (num17 & 4) != 0;
                            TBPreviewOnClick.Checked = PreviewOnClick;
                            TBPreviewOnClick_Click(TBPreviewOnClick, new EventArgs());
                            ShowFileName = (num17 & 8) != 0;
                            TBShowFileName.Checked = ShowFileName;
                            TBShowFileName_Click(TBShowFileName, new EventArgs());
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
                            CWAVMultiSelect_CheckedChanged(CWAVMultiSelect, new EventArgs());
                            WAVChangeLabel = (num11 & 2) != 0;
                            CWAVChangeLabel.Checked = WAVChangeLabel;
                            CWAVChangeLabel_CheckedChanged(CWAVChangeLabel, new EventArgs());
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
                            CBeatPreserve_Click(array[num18], new EventArgs());
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

    private string GetBMSChannelBy(Note note)
    {
        var columnIndex = note.ColumnIndex;
        var value = note.Value;
        var longNote = note.LongNote;
        var hidden = note.Hidden;
        var num = GetColumn(columnIndex).Identifier;
        var landmine = note.Landmine;
        if (columnIndex == 2 && (value / 10000.0 != value / 10000 || value >= 2560000 || value < 0))
        {
            num += 5;
        }
        if (columnIndex == 1)
        {
            return "SC";
        }
        if (columnIndex >= 5 && columnIndex <= 12)
        {
            if (longNote)
            {
                return Conversion.Hex(num + Convert.ToInt32("50", 16) - 10);
            }

            if (hidden)
            {
                return Conversion.Hex(num + Convert.ToInt32("30", 16) - 10);
            }

            if (landmine)
            {
                return Conversion.Hex(num + Convert.ToInt32("D0", 16) - 10);
            }
        }
        if (columnIndex >= 14 && columnIndex <= 21)
        {
            if (longNote)
            {
                return Conversion.Hex(num + Convert.ToInt32("60", 16) - 20);
            }

            if (hidden)
            {
                return Conversion.Hex(num + Convert.ToInt32("40", 16) - 20);
            }

            if (landmine)
            {
                return Conversion.Hex(num + Convert.ToInt32("E0", 16) - 20);
            }
        }
        return Functions.Add2Zeros(num);
    }

    private int nLeft(int iCol)
    {
        if (iCol < 27)
        {
            return column[iCol].Left;
        }
        return column[27].Left + (iCol - 27) * column[27].Width;
    }

    private int GetColumnWidth(int iCol)
    {
        if (!GetColumn(iCol).isVisible)
        {
            return 0;
        }
        if (iCol < 27)
        {
            return column[iCol].Width;
        }
        return column[27].Width;
    }

    private string nTitle(int iCol)
    {
        if (iCol < 27)
        {
            return column[iCol].Title;
        }
        return column[27].Title + (iCol - 27 + 1);
    }

    private bool nEnabled(int iCol)
    {
        if (iCol < 27)
        {
            return column[iCol].isEnabledAfterAll;
        }
        return column[27].isEnabledAfterAll;
    }

    private bool IsColumnNumeric(int iCol)
    {
        if (iCol < 27)
        {
            return column[iCol].isNumeric;
        }
        return column[27].isNumeric;
    }

    private Column GetColumn(int iCol)
    {
        if (iCol < 27)
        {
            return column[iCol];
        }
        return column[27];
    }

    private object BMSEChannelToColumnIndex(string I)
    {
        double num = Conversion.Val(I);
        if (num > 100.0)
        {
            return 27.0 + num - 101.0;
        }
        if (num < 100.0 && num > 0.0)
        {
            return BMSChannelToColumn(Microsoft.VisualBasic.Strings.Mid(I, 2, 2));
        }
        return 27;
    }

    private int BMSChannelToColumn(string I)
    {
        switch (I)
        {
            case "01":
                return 27;
            case "03":
            case "08":
                return 2;
            case "09":
                return 3;
            case "SC":
                return 1;
            case "04":
                return 23;
            case "07":
                return 24;
            case "06":
                return 25;
            case "16":
            case "36":
            case "56":
            case "76":
            case "D6":
                return 5;
            case "11":
            case "31":
            case "51":
            case "71":
            case "D1":
                return 6;
            case "12":
            case "32":
            case "52":
            case "72":
            case "D2":
                return 7;
            case "13":
            case "33":
            case "53":
            case "73":
            case "D3":
                return 8;
            case "14":
            case "34":
            case "54":
            case "74":
            case "D4":
                return 9;
            case "15":
            case "35":
            case "55":
            case "75":
            case "D5":
                return 10;
            case "18":
            case "38":
            case "58":
            case "78":
            case "D8":
                return 11;
            case "19":
            case "39":
            case "59":
            case "79":
            case "D9":
                return 12;
            case "21":
            case "41":
            case "61":
            case "81":
            case "E1":
                return 14;
            case "22":
            case "42":
            case "62":
            case "82":
            case "E2":
                return 15;
            case "23":
            case "43":
            case "63":
            case "83":
            case "E3":
                return 16;
            case "24":
            case "44":
            case "64":
            case "84":
            case "E4":
                return 17;
            case "25":
            case "45":
            case "65":
            case "85":
            case "E5":
                return 18;
            case "28":
            case "48":
            case "68":
            case "88":
            case "E8":
                return 19;
            case "29":
            case "49":
            case "69":
            case "89":
            case "E9":
                return 20;
            case "26":
            case "46":
            case "66":
            case "86":
            case "E6":
                return 21;
            default:
                return 0;
        }
    }

    private void XMLWriteColumn(XmlTextWriter w, int I)
    {
        w.WriteStartElement("Column");
        w.WriteAttributeString("Index", Conversions.ToString(I));
        Column[] array = column;
        w.WriteAttributeString("Width", Conversions.ToString(array[I].Width));
        w.WriteAttributeString("Title", array[I].Title);
        w.WriteAttributeString("NoteColor", Conversions.ToString(array[I].cNote));
        w.WriteAttributeString("TextColor", Conversions.ToString(array[I].cText.ToArgb()));
        w.WriteAttributeString("LongNoteColor", Conversions.ToString(array[I].cLNote));
        w.WriteAttributeString("LongTextColor", Conversions.ToString(array[I].cLText.ToArgb()));
        w.WriteAttributeString("BG", Conversions.ToString(array[I].cBG.ToArgb()));
        w.WriteEndElement();
    }

    private void XMLWriteFont(XmlTextWriter w, string local, Font f)
    {
        w.WriteStartElement(local);
        w.WriteAttributeString("Name", f.FontFamily.Name);
        w.WriteAttributeString("Size", Conversions.ToString(f.SizeInPoints));
        w.WriteAttributeString("Style", Conversions.ToString((int)f.Style));
        w.WriteEndElement();
    }

    private void XMLWritePlayerArguments(XmlTextWriter w, int I)
    {
        w.WriteStartElement("Player");
        w.WriteAttributeString("Index", Conversions.ToString(I));
        w.WriteAttributeString("Path", pArgs[I].Path);
        w.WriteAttributeString("FromBeginning", pArgs[I].aBegin);
        w.WriteAttributeString("FromHere", pArgs[I].aHere);
        w.WriteAttributeString("Stop", pArgs[I].aStop);
        w.WriteEndElement();
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    private void SaveSettings(string Path, bool ThemeOnly)
    {
        XmlTextWriter xmlTextWriter = new XmlTextWriter(Path, Encoding.Unicode);
        XmlTextWriter xmlTextWriter2 = xmlTextWriter;
        xmlTextWriter2.WriteStartDocument();
        xmlTextWriter2.Formatting = Formatting.Indented;
        xmlTextWriter2.Indentation = 4;
        xmlTextWriter2.WriteStartElement("iBMSC");
        xmlTextWriter2.WriteAttributeString("Major", Conversions.ToString(MyProject.Application.Info.Version.Major));
        xmlTextWriter2.WriteAttributeString("Minor", Conversions.ToString(MyProject.Application.Info.Version.Minor));
        xmlTextWriter2.WriteAttributeString("Build", Conversions.ToString(MyProject.Application.Info.Version.Build));

        if (!ThemeOnly)
        {
            xmlTextWriter2.WriteStartElement("Form");
            xmlTextWriter2.WriteAttributeString("WindowState", Conversions.ToString(Interaction.IIf(isFullScreen, previousWindowState, WindowState)));
            xmlTextWriter2.WriteAttributeString("Width", Conversions.ToString(Interaction.IIf(isFullScreen, previousWindowPosition.Width, Width)));
            xmlTextWriter2.WriteAttributeString("Height", Conversions.ToString(Interaction.IIf(isFullScreen, previousWindowPosition.Height, Height)));
            xmlTextWriter2.WriteAttributeString("Top", Conversions.ToString(Interaction.IIf(isFullScreen, previousWindowPosition.Top, Top)));
            xmlTextWriter2.WriteAttributeString("Left", Conversions.ToString(Interaction.IIf(isFullScreen, previousWindowPosition.Left, Left)));
            xmlTextWriter2.WriteEndElement();
            xmlTextWriter2.WriteStartElement("Recent");
            xmlTextWriter2.WriteAttributeString("Recent0", Recent[0]);
            xmlTextWriter2.WriteAttributeString("Recent1", Recent[1]);
            xmlTextWriter2.WriteAttributeString("Recent2", Recent[2]);
            xmlTextWriter2.WriteAttributeString("Recent3", Recent[3]);
            xmlTextWriter2.WriteAttributeString("Recent4", Recent[4]);
            xmlTextWriter2.WriteEndElement();
            xmlTextWriter2.WriteStartElement("Edit");
            xmlTextWriter2.WriteAttributeString("NTInput", Conversions.ToString(NTInput));
            xmlTextWriter2.WriteAttributeString("Language", DispLang);
            xmlTextWriter2.WriteAttributeString("ErrorCheck", Conversions.ToString(ErrorCheck));
            xmlTextWriter2.WriteAttributeString("AutoFocusMouseEnter", Conversions.ToString(AutoFocusMouseEnter));
            xmlTextWriter2.WriteAttributeString("FirstClickDisabled", Conversions.ToString(FirstClickDisabled));
            xmlTextWriter2.WriteAttributeString("ShowFileName", Conversions.ToString(ShowFileName));
            xmlTextWriter2.WriteAttributeString("MiddleButtonMoveMethod", Conversions.ToString(MiddleButtonMoveMethod));
            xmlTextWriter2.WriteAttributeString("AutoSaveInterval", Conversions.ToString(AutoSaveInterval));
            xmlTextWriter2.WriteAttributeString("PreviewOnClick", Conversions.ToString(PreviewOnClick));
            xmlTextWriter2.WriteAttributeString("ClickStopPreview", Conversions.ToString(ClickStopPreview));
            xmlTextWriter2.WriteEndElement();
            xmlTextWriter2.WriteStartElement("Save");
            xmlTextWriter2.WriteAttributeString("TextEncoding", Functions.EncodingToString(TextEncoding));
            xmlTextWriter2.WriteAttributeString("BMSGridLimit", Conversions.ToString(BMSGridLimit));
            xmlTextWriter2.WriteAttributeString("BeepWhileSaved", Conversions.ToString(BeepWhileSaved));
            xmlTextWriter2.WriteAttributeString("BPMx1296", Conversions.ToString(BPMx1296));
            xmlTextWriter2.WriteAttributeString("STOPx1296", Conversions.ToString(STOPx1296));
            xmlTextWriter2.WriteEndElement();
            xmlTextWriter2.WriteStartElement("WAV");
            xmlTextWriter2.WriteAttributeString("WAVMultiSelect", Conversions.ToString(WAVMultiSelect));
            xmlTextWriter2.WriteAttributeString("WAVChangeLabel", Conversions.ToString(WAVChangeLabel));
            xmlTextWriter2.WriteAttributeString("BeatChangeMode", Conversions.ToString(BeatChangeMode));
            xmlTextWriter2.WriteEndElement();
            xmlTextWriter2.WriteStartElement("ShowHide");
            xmlTextWriter2.WriteAttributeString("showMenu", Conversions.ToString(mnSMenu.Checked));
            xmlTextWriter2.WriteAttributeString("showTB", Conversions.ToString(mnSTB.Checked));
            xmlTextWriter2.WriteAttributeString("showOpPanel", Conversions.ToString(mnSOP.Checked));
            xmlTextWriter2.WriteAttributeString("showStatus", Conversions.ToString(mnSStatus.Checked));
            xmlTextWriter2.WriteAttributeString("showLSplit", Conversions.ToString(mnSLSplitter.Checked));
            xmlTextWriter2.WriteAttributeString("showRSplit", Conversions.ToString(mnSRSplitter.Checked));
            xmlTextWriter2.WriteEndElement();
            xmlTextWriter2.WriteStartElement("Grid");
            xmlTextWriter2.WriteAttributeString("gSnap", Conversions.ToString(gSnap));
            xmlTextWriter2.WriteAttributeString("gWheel", Conversions.ToString(gWheel));
            xmlTextWriter2.WriteAttributeString("gPgUpDn", Conversions.ToString(gPgUpDn));
            xmlTextWriter2.WriteAttributeString("gShow", Conversions.ToString(gShowGrid));
            xmlTextWriter2.WriteAttributeString("gShowS", Conversions.ToString(gShowSubGrid));
            xmlTextWriter2.WriteAttributeString("gShowBG", Conversions.ToString(gShowBG));
            xmlTextWriter2.WriteAttributeString("gShowM", Conversions.ToString(gShowMeasureNumber));
            xmlTextWriter2.WriteAttributeString("gShowV", Conversions.ToString(gShowVerticalLine));
            xmlTextWriter2.WriteAttributeString("gShowMB", Conversions.ToString(gShowMeasureBar));
            xmlTextWriter2.WriteAttributeString("gShowC", Conversions.ToString(gShowC));
            xmlTextWriter2.WriteAttributeString("gBPM", Conversions.ToString(gBPM));
            xmlTextWriter2.WriteAttributeString("gSTOP", Conversions.ToString(gSTOP));
            xmlTextWriter2.WriteAttributeString("gSCROLL", Conversions.ToString(gSCROLL));
            xmlTextWriter2.WriteAttributeString("gBLP", Conversions.ToString(gDisplayBGAColumn));
            xmlTextWriter2.WriteAttributeString("gP2", Conversions.ToString(CHPlayer.SelectedIndex));
            xmlTextWriter2.WriteAttributeString("gCol", Conversions.ToString(CGB.Value));
            xmlTextWriter2.WriteAttributeString("gDivide", Conversions.ToString(gDivide));
            xmlTextWriter2.WriteAttributeString("gSub", Conversions.ToString(gSub));
            xmlTextWriter2.WriteAttributeString("gSlash", Conversions.ToString(gSlash));
            xmlTextWriter2.WriteAttributeString("gxHeight", Conversions.ToString(gxHeight));
            xmlTextWriter2.WriteAttributeString("gxWidth", Conversions.ToString(gxWidth));
            xmlTextWriter2.WriteEndElement();
            xmlTextWriter2.WriteStartElement("WaveForm");
            xmlTextWriter2.WriteAttributeString("wLock", Conversions.ToString(wLock));
            xmlTextWriter2.WriteAttributeString("wPosition", Conversions.ToString(wPosition));
            xmlTextWriter2.WriteAttributeString("wLeft", Conversions.ToString(wLeft));
            xmlTextWriter2.WriteAttributeString("wWidth", Conversions.ToString(wWidth));
            xmlTextWriter2.WriteAttributeString("wPrecision", Conversions.ToString(wPrecision));
            xmlTextWriter2.WriteEndElement();
            xmlTextWriter2.WriteStartElement("Player");
            xmlTextWriter2.WriteAttributeString("Count", Conversions.ToString(pArgs.Length));
            xmlTextWriter2.WriteAttributeString("CurrentPlayer", Conversions.ToString(CurrentPlayer));
            int num = Information.UBound(pArgs);
            for (int i = 0; i <= num; i++)
            {
                XMLWritePlayerArguments(xmlTextWriter, i);
            }
            xmlTextWriter2.WriteEndElement();
        }
        xmlTextWriter2.WriteStartElement("Columns");
        int num2 = Information.UBound(column);
        for (int j = 0; j <= num2; j++)
        {
            XMLWriteColumn(xmlTextWriter, j);
        }
        xmlTextWriter2.WriteEndElement();
        xmlTextWriter2.WriteStartElement("VisualSettings");
        XMLUtil.XMLWriteValue(xmlTextWriter, "ColumnTitle", Conversions.ToString(vo.ColumnTitle.Color.ToArgb()));
        XMLWriteFont(xmlTextWriter, "ColumnTitleFont", vo.ColumnTitleFont);
        XMLUtil.XMLWriteValue(xmlTextWriter, "Bg", Conversions.ToString(vo.Bg.Color.ToArgb()));
        XMLUtil.XMLWriteValue(xmlTextWriter, "Grid", Conversions.ToString(vo.pGrid.Color.ToArgb()));
        XMLUtil.XMLWriteValue(xmlTextWriter, "Sub", Conversions.ToString(vo.pSub.Color.ToArgb()));
        XMLUtil.XMLWriteValue(xmlTextWriter, "VLine", Conversions.ToString(vo.pVLine.Color.ToArgb()));
        XMLUtil.XMLWriteValue(xmlTextWriter, "MLine", Conversions.ToString(vo.pMLine.Color.ToArgb()));
        XMLUtil.XMLWriteValue(xmlTextWriter, "BGMWav", Conversions.ToString(vo.pBGMWav.Color.ToArgb()));
        XMLUtil.XMLWriteValue(xmlTextWriter, "SelBox", Conversions.ToString(vo.SelBox.Color.ToArgb()));
        XMLUtil.XMLWriteValue(xmlTextWriter, "TSCursor", Conversions.ToString(vo.PECursor.Color.ToArgb()));
        XMLUtil.XMLWriteValue(xmlTextWriter, "TSHalf", Conversions.ToString(vo.PEHalf.Color.ToArgb()));
        XMLUtil.XMLWriteValue(xmlTextWriter, "TSDeltaMouseOver", Conversions.ToString(vo.PEDeltaMouseOver));
        XMLUtil.XMLWriteValue(xmlTextWriter, "TSMouseOver", Conversions.ToString(vo.PEMouseOver.Color.ToArgb()));
        XMLUtil.XMLWriteValue(xmlTextWriter, "TSSel", Conversions.ToString(vo.PESel.Color.ToArgb()));
        XMLUtil.XMLWriteValue(xmlTextWriter, "TSBPM", Conversions.ToString(vo.PEBPM.Color.ToArgb()));
        XMLWriteFont(xmlTextWriter, "TSBPMFont", vo.PEBPMFont);
        XMLUtil.XMLWriteValue(xmlTextWriter, "MiddleDeltaRelease", Conversions.ToString(vo.MiddleDeltaRelease));
        XMLUtil.XMLWriteValue(xmlTextWriter, "kHeight", Conversions.ToString(vo.kHeight));
        XMLWriteFont(xmlTextWriter, "kFont", vo.kFont);
        XMLWriteFont(xmlTextWriter, "kMFont", vo.kMFont);
        XMLUtil.XMLWriteValue(xmlTextWriter, "kLabelVShift", Conversions.ToString(vo.kLabelVShift));
        XMLUtil.XMLWriteValue(xmlTextWriter, "kLabelHShift", Conversions.ToString(vo.kLabelHShift));
        XMLUtil.XMLWriteValue(xmlTextWriter, "kLabelHShiftL", Conversions.ToString(vo.kLabelHShiftL));
        XMLUtil.XMLWriteValue(xmlTextWriter, "kMouseOver", Conversions.ToString(vo.kMouseOver.Color.ToArgb()));
        XMLUtil.XMLWriteValue(xmlTextWriter, "kMouseOverE", Conversions.ToString(vo.kMouseOverE.Color.ToArgb()));
        XMLUtil.XMLWriteValue(xmlTextWriter, "kSelected", Conversions.ToString(vo.kSelected.Color.ToArgb()));
        XMLUtil.XMLWriteValue(xmlTextWriter, "kOpacity", Conversions.ToString(vo.kOpacity));
        xmlTextWriter2.WriteEndElement();
        xmlTextWriter2.WriteEndElement();
        xmlTextWriter2.WriteEndDocument();
        xmlTextWriter2.Close();
        xmlTextWriter2 = null;
    }

    private void XMLLoadElementValue(XmlElement n, ref int v)
    {
        if (n != null)
        {
            XMLUtil.XMLLoadAttribute(n.GetAttribute("Value"), ref v);
        }
    }

    private void XMLLoadElementValue(XmlElement n, ref float v)
    {
        if (n != null)
        {
            XMLUtil.XMLLoadAttribute(n.GetAttribute("Value"), ref v);
        }
    }

    private void XMLLoadElementValue(XmlElement n, ref Color v)
    {
        if (n != null)
        {
            XMLUtil.XMLLoadAttribute(n.GetAttribute("Value"), ref v);
        }
    }

    private void XMLLoadElementValue(XmlElement n, ref Font v)
    {
        if (n != null)
        {
            string v2 = Font.FontFamily.Name;
            int v3 = (int)Math.Round(Font.Size);
            int v4 = (int)Font.Style;
            XMLUtil.XMLLoadAttribute(n.GetAttribute("Name"), ref v2);
            XMLUtil.XMLLoadAttribute(n.GetAttribute("Size"), ref v3);
            XMLUtil.XMLLoadAttribute(n.GetAttribute("Style"), ref v4);
            v = new Font(v2, v3, (FontStyle)v4);
        }
    }

    private void XMLLoadPlayer(XmlElement n)
    {
        int v = -1;
        XMLUtil.XMLLoadAttribute(n.GetAttribute("Index"), ref v);
        if (!((v < 0) | (v > Information.UBound(pArgs))))
        {
            XMLUtil.XMLLoadAttribute(n.GetAttribute("Path"), ref pArgs[v].Path);
            XMLUtil.XMLLoadAttribute(n.GetAttribute("FromBeginning"), ref pArgs[v].aBegin);
            XMLUtil.XMLLoadAttribute(n.GetAttribute("FromHere"), ref pArgs[v].aHere);
            XMLUtil.XMLLoadAttribute(n.GetAttribute("Stop"), ref pArgs[v].aStop);
        }
    }

    private void XMLLoadColumn(XmlElement n)
    {
        int v = -1;
        XMLUtil.XMLLoadAttribute(n.GetAttribute("Index"), ref v);
        if (!((v < 0) | (v > Information.UBound(column))))
        {
            Column[] array = column;
            string attribute = n.GetAttribute("Width");
            int v2 = array[v].Width;
            XMLUtil.XMLLoadAttribute(attribute, ref v2);
            array[v].Width = v2;
            XMLUtil.XMLLoadAttribute(n.GetAttribute("Title"), ref array[v].Title);
            string attribute2 = n.GetAttribute("Display");
            bool v3 = default(bool);
            XMLUtil.XMLLoadAttribute(attribute2, ref v3);
            array[v].isVisible = Conversions.ToBoolean(Interaction.IIf(string.IsNullOrEmpty(attribute2), array[v].isVisible, v3));
            XMLUtil.XMLLoadAttribute(n.GetAttribute("NoteColor"), ref array[v].cNote);
            array[v].setNoteColor(array[v].cNote);
            XMLUtil.XMLLoadAttribute(n.GetAttribute("TextColor"), ref array[v].cText);
            XMLUtil.XMLLoadAttribute(n.GetAttribute("LongNoteColor"), ref array[v].cLNote);
            array[v].setLNoteColor(array[v].cLNote);
            XMLUtil.XMLLoadAttribute(n.GetAttribute("LongTextColor"), ref array[v].cLText);
            XMLUtil.XMLLoadAttribute(n.GetAttribute("BG"), ref array[v].cBG);
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    private void LoadSettings(string Path)
    {
        if (!MyProject.Computer.FileSystem.FileExists(Path))
        {
            return;
        }
        XmlDocument xmlDocument = new XmlDocument();
        FileStream fileStream = new FileStream(Path, FileMode.Open, FileAccess.Read);
        xmlDocument.Load(fileStream);
        XmlElement xmlElement = xmlDocument["iBMSC"];

        if (xmlElement != null)
        {
            int major = MyProject.Application.Info.Version.Major;
            int minor = MyProject.Application.Info.Version.Minor;
            int build = MyProject.Application.Info.Version.Build;
            try
            {
                int num = (int)Math.Round(Conversion.Val(xmlElement.Attributes["Major"].Value));
                int num2 = (int)Math.Round(Conversion.Val(xmlElement.Attributes["Minor"].Value));
                int num3 = (int)Math.Round(Conversion.Val(xmlElement.Attributes["Build"].Value));
                major = num;
                minor = num2;
                build = num3;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ProjectData.ClearProjectError();
            }
            XmlElement xmlElement2 = xmlElement["Form"];
            if (xmlElement2 != null)
            {
                XmlElement xmlElement3 = xmlElement2;
                double num4 = Conversion.Val(xmlElement3.GetAttribute("WindowState"));
                if (num4 == 0.0)
                {
                    WindowState = FormWindowState.Normal;
                    string attribute = xmlElement3.GetAttribute("Width");
                    int v = Width;
                    XMLUtil.XMLLoadAttribute(attribute, ref v);
                    Width = v;
                    string attribute2 = xmlElement3.GetAttribute("Height");
                    v = Height;
                    XMLUtil.XMLLoadAttribute(attribute2, ref v);
                    Height = v;
                    string attribute3 = xmlElement3.GetAttribute("Top");
                    v = Top;
                    XMLUtil.XMLLoadAttribute(attribute3, ref v);
                    Top = v;
                    string attribute4 = xmlElement3.GetAttribute("Left");
                    v = Left;
                    XMLUtil.XMLLoadAttribute(attribute4, ref v);
                    Left = v;
                }
                else if (num4 == 2.0)
                {
                    WindowState = FormWindowState.Maximized;
                }
                xmlElement3 = null;
            }
            XmlElement xmlElement4 = xmlElement["Recent"];
            if (xmlElement4 != null)
            {
                XmlElement xmlElement5 = xmlElement4;
                XMLUtil.XMLLoadAttribute(xmlElement5.GetAttribute("Recent0"), ref Recent[0]);
                SetRecent(0, Recent[0]);
                XMLUtil.XMLLoadAttribute(xmlElement5.GetAttribute("Recent1"), ref Recent[1]);
                SetRecent(1, Recent[1]);
                XMLUtil.XMLLoadAttribute(xmlElement5.GetAttribute("Recent2"), ref Recent[2]);
                SetRecent(2, Recent[2]);
                XMLUtil.XMLLoadAttribute(xmlElement5.GetAttribute("Recent3"), ref Recent[3]);
                SetRecent(3, Recent[3]);
                XMLUtil.XMLLoadAttribute(xmlElement5.GetAttribute("Recent4"), ref Recent[4]);
                SetRecent(4, Recent[4]);
                xmlElement5 = null;
            }
            XmlElement xmlElement6 = xmlElement["Edit"];
            if (xmlElement6 != null)
            {
                XmlElement xmlElement7 = xmlElement6;
                XMLUtil.XMLLoadAttribute(xmlElement7.GetAttribute("NTInput"), ref NTInput);
                TBNTInput.Checked = NTInput;
                mnNTInput.Checked = NTInput;
                POBLong.Enabled = !NTInput;
                POBLongShort.Enabled = !NTInput;
                LoadLocale(MyProject.Application.Info.DirectoryPath + "\\" + xmlElement7.GetAttribute("Language"));
                XMLUtil.XMLLoadAttribute(xmlElement7.GetAttribute("ErrorCheck"), ref ErrorCheck);
                TBErrorCheck.Checked = ErrorCheck;
                TBErrorCheck_Click(TBErrorCheck, new EventArgs());
                XMLUtil.XMLLoadAttribute(xmlElement7.GetAttribute("ShowFileName"), ref ShowFileName);
                TBShowFileName.Checked = ShowFileName;
                TBShowFileName_Click(TBShowFileName, new EventArgs());
                XMLUtil.XMLLoadAttribute(xmlElement7.GetAttribute("MiddleButtonMoveMethod"), ref MiddleButtonMoveMethod);
                XMLUtil.XMLLoadAttribute(xmlElement7.GetAttribute("AutoFocusMouseEnter"), ref AutoFocusMouseEnter);
                XMLUtil.XMLLoadAttribute(xmlElement7.GetAttribute("FirstClickDisabled"), ref FirstClickDisabled);
                XMLUtil.XMLLoadAttribute(xmlElement7.GetAttribute("AutoSaveInterval"), ref AutoSaveInterval);
                if (AutoSaveInterval != 0)
                {
                    AutoSaveTimer.Interval = AutoSaveInterval;
                }
                else
                {
                    AutoSaveTimer.Enabled = false;
                }
                XMLUtil.XMLLoadAttribute(xmlElement7.GetAttribute("PreviewOnClick"), ref PreviewOnClick);
                TBPreviewOnClick.Checked = PreviewOnClick;
                TBPreviewOnClick_Click(TBPreviewOnClick, new EventArgs());
                XMLUtil.XMLLoadAttribute(xmlElement7.GetAttribute("ClickStopPreview"), ref ClickStopPreview);
                xmlElement7 = null;
            }
            XmlElement xmlElement8 = xmlElement["Save"];
            if (xmlElement8 != null)
            {
                XmlElement xmlElement9 = xmlElement8;
                switch (Microsoft.VisualBasic.Strings.UCase(xmlElement9.GetAttribute("TextEncoding")))
                {
                    case "SYSTEM ANSI":
                        TextEncoding = Encoding.Default;
                        break;
                    case "LITTLE ENDIAN UTF16":
                        TextEncoding = Encoding.Unicode;
                        break;
                    case "ASCII":
                        TextEncoding = Encoding.ASCII;
                        break;
                    case "BIG ENDIAN UTF16":
                        TextEncoding = Encoding.BigEndianUnicode;
                        break;
                    case "LITTLE ENDIAN UTF32":
                        TextEncoding = Encoding.UTF32;
                        break;
                    case "UTF7":
                        TextEncoding = Encoding.UTF7;
                        break;
                    case "UTF8":
                        TextEncoding = Encoding.UTF8;
                        break;
                    case "SJIS":
                        TextEncoding = Encoding.GetEncoding(932);
                        break;
                    case "EUC-KR":
                        TextEncoding = Encoding.GetEncoding(51949);
                        break;
                }
                XMLUtil.XMLLoadAttribute(xmlElement9.GetAttribute("BMSGridLimit"), ref BMSGridLimit);
                XMLUtil.XMLLoadAttribute(xmlElement9.GetAttribute("BeepWhileSaved"), ref BeepWhileSaved);
                XMLUtil.XMLLoadAttribute(xmlElement9.GetAttribute("BPMx1296"), ref BPMx1296);
                XMLUtil.XMLLoadAttribute(xmlElement9.GetAttribute("STOPx1296"), ref STOPx1296);
                xmlElement9 = null;
            }
            XmlElement xmlElement10 = xmlElement["WAV"];
            if (xmlElement10 != null)
            {
                XmlElement xmlElement11 = xmlElement10;
                XMLUtil.XMLLoadAttribute(xmlElement11.GetAttribute("WAVMultiSelect"), ref WAVMultiSelect);
                CWAVMultiSelect.Checked = WAVMultiSelect;
                CWAVMultiSelect_CheckedChanged(CWAVMultiSelect, new EventArgs());
                XMLUtil.XMLLoadAttribute(xmlElement11.GetAttribute("WAVChangeLabel"), ref WAVChangeLabel);
                CWAVChangeLabel.Checked = WAVChangeLabel;
                CWAVChangeLabel_CheckedChanged(CWAVChangeLabel, new EventArgs());
                int num5 = Conversions.ToInteger(xmlElement11.GetAttribute("BeatChangeMode"));
                RadioButton[] array = new RadioButton[4] { CBeatPreserve, CBeatMeasure, CBeatCut, CBeatScale };
                if ((num5 >= 0) & (num5 < array.Length))
                {
                    array[num5].Checked = true;
                    CBeatPreserve_Click(array[num5], new EventArgs());
                }
                xmlElement11 = null;
            }
            XmlElement xmlElement12 = xmlElement["ShowHide"];
            if (xmlElement12 != null)
            {
                XmlElement xmlElement13 = xmlElement12;
                string attribute5 = xmlElement13.GetAttribute("showMenu");
                ToolStripMenuItem toolStripMenuItem = mnSMenu;
                bool v2 = toolStripMenuItem.Checked;
                XMLUtil.XMLLoadAttribute(attribute5, ref v2);
                toolStripMenuItem.Checked = v2;
                string attribute6 = xmlElement13.GetAttribute("showTB");
                toolStripMenuItem = mnSTB;
                v2 = toolStripMenuItem.Checked;
                XMLUtil.XMLLoadAttribute(attribute6, ref v2);
                toolStripMenuItem.Checked = v2;
                string attribute7 = xmlElement13.GetAttribute("showOpPanel");
                toolStripMenuItem = mnSOP;
                v2 = toolStripMenuItem.Checked;
                XMLUtil.XMLLoadAttribute(attribute7, ref v2);
                toolStripMenuItem.Checked = v2;
                string attribute8 = xmlElement13.GetAttribute("showStatus");
                toolStripMenuItem = mnSStatus;
                v2 = toolStripMenuItem.Checked;
                XMLUtil.XMLLoadAttribute(attribute8, ref v2);
                toolStripMenuItem.Checked = v2;
                string attribute9 = xmlElement13.GetAttribute("showLSplit");
                toolStripMenuItem = mnSLSplitter;
                v2 = toolStripMenuItem.Checked;
                XMLUtil.XMLLoadAttribute(attribute9, ref v2);
                toolStripMenuItem.Checked = v2;
                string attribute10 = xmlElement13.GetAttribute("showRSplit");
                toolStripMenuItem = mnSRSplitter;
                v2 = toolStripMenuItem.Checked;
                XMLUtil.XMLLoadAttribute(attribute10, ref v2);
                toolStripMenuItem.Checked = v2;
                xmlElement13 = null;
            }
            XmlElement xmlElement14 = xmlElement["Grid"];
            if (xmlElement14 != null)
            {
                XmlElement xmlElement15 = xmlElement14;
                string attribute11 = xmlElement15.GetAttribute("gSnap");
                CheckBox cGSnap = CGSnap;
                bool v2 = cGSnap.Checked;
                XMLUtil.XMLLoadAttribute(attribute11, ref v2);
                cGSnap.Checked = v2;
                XMLUtil.XMLLoadAttribute(xmlElement15.GetAttribute("gWheel"), ref gWheel);
                XMLUtil.XMLLoadAttribute(xmlElement15.GetAttribute("gPgUpDn"), ref gPgUpDn);
                string attribute12 = xmlElement15.GetAttribute("gShow");
                ToolStripMenuItem toolStripMenuItem = CGShow;
                v2 = toolStripMenuItem.Checked;
                XMLUtil.XMLLoadAttribute(attribute12, ref v2);
                toolStripMenuItem.Checked = v2;
                string attribute13 = xmlElement15.GetAttribute("gShowS");
                toolStripMenuItem = CGShowS;
                v2 = toolStripMenuItem.Checked;
                XMLUtil.XMLLoadAttribute(attribute13, ref v2);
                toolStripMenuItem.Checked = v2;
                string attribute14 = xmlElement15.GetAttribute("gShowBG");
                toolStripMenuItem = CGShowBG;
                v2 = toolStripMenuItem.Checked;
                XMLUtil.XMLLoadAttribute(attribute14, ref v2);
                toolStripMenuItem.Checked = v2;
                string attribute15 = xmlElement15.GetAttribute("gShowM");
                toolStripMenuItem = CGShowM;
                v2 = toolStripMenuItem.Checked;
                XMLUtil.XMLLoadAttribute(attribute15, ref v2);
                toolStripMenuItem.Checked = v2;
                string attribute16 = xmlElement15.GetAttribute("gShowV");
                toolStripMenuItem = CGShowV;
                v2 = toolStripMenuItem.Checked;
                XMLUtil.XMLLoadAttribute(attribute16, ref v2);
                toolStripMenuItem.Checked = v2;
                string attribute17 = xmlElement15.GetAttribute("gShowMB");
                toolStripMenuItem = CGShowMB;
                v2 = toolStripMenuItem.Checked;
                XMLUtil.XMLLoadAttribute(attribute17, ref v2);
                toolStripMenuItem.Checked = v2;
                string attribute18 = xmlElement15.GetAttribute("gShowC");
                toolStripMenuItem = CGShowC;
                v2 = toolStripMenuItem.Checked;
                XMLUtil.XMLLoadAttribute(attribute18, ref v2);
                toolStripMenuItem.Checked = v2;
                string attribute19 = xmlElement15.GetAttribute("gBPM");
                toolStripMenuItem = CGBPM;
                v2 = toolStripMenuItem.Checked;
                XMLUtil.XMLLoadAttribute(attribute19, ref v2);
                toolStripMenuItem.Checked = v2;
                string attribute20 = xmlElement15.GetAttribute("gSTOP");
                toolStripMenuItem = CGSTOP;
                v2 = toolStripMenuItem.Checked;
                XMLUtil.XMLLoadAttribute(attribute20, ref v2);
                toolStripMenuItem.Checked = v2;
                string attribute21 = xmlElement15.GetAttribute("gSCROLL");
                toolStripMenuItem = CGSCROLL;
                v2 = toolStripMenuItem.Checked;
                XMLUtil.XMLLoadAttribute(attribute21, ref v2);
                toolStripMenuItem.Checked = v2;
                string attribute22 = xmlElement15.GetAttribute("gBLP");
                toolStripMenuItem = CGBLP;
                v2 = toolStripMenuItem.Checked;
                XMLUtil.XMLLoadAttribute(attribute22, ref v2);
                toolStripMenuItem.Checked = v2;
                string attribute23 = xmlElement15.GetAttribute("gP2");
                ComboBox cHPlayer = CHPlayer;
                int v = cHPlayer.SelectedIndex;
                XMLUtil.XMLLoadAttribute(attribute23, ref v);
                cHPlayer.SelectedIndex = v;
                string attribute24 = xmlElement15.GetAttribute("gCol");
                NumericUpDown cGB = CGB;
                decimal v3 = cGB.Value;
                XMLUtil.XMLLoadAttribute(attribute24, ref v3);
                cGB.Value = v3;
                string attribute25 = xmlElement15.GetAttribute("gxHeight");
                cGB = CGHeight;
                v3 = cGB.Value;
                XMLUtil.XMLLoadAttribute(attribute25, ref v3);
                cGB.Value = v3;
                string attribute26 = xmlElement15.GetAttribute("gxWidth");
                cGB = CGWidth;
                v3 = cGB.Value;
                XMLUtil.XMLLoadAttribute(attribute26, ref v3);
                cGB.Value = v3;
                XMLUtil.XMLLoadAttribute(xmlElement15.GetAttribute("gSlash"), ref gSlash);
                int value = Conversions.ToInteger(xmlElement15.GetAttribute("gDivide"));
                if ((decimal.Compare(new decimal(value), CGDivide.Minimum) >= 0) & (decimal.Compare(new decimal(value), CGDivide.Maximum) <= 0))
                {
                    CGDivide.Value = new decimal(value);
                }
                int value2 = Conversions.ToInteger(xmlElement15.GetAttribute("gSub"));
                if ((decimal.Compare(new decimal(value2), CGSub.Minimum) >= 0) & (decimal.Compare(new decimal(value2), CGSub.Maximum) <= 0))
                {
                    CGSub.Value = new decimal(value2);
                }
                xmlElement15 = null;
            }
            XmlElement xmlElement16 = xmlElement["WaveForm"];
            if (xmlElement16 != null)
            {
                XmlElement xmlElement17 = xmlElement16;
                string attribute27 = xmlElement17.GetAttribute("wLock");
                CheckBox cGSnap = BWLock;
                bool v2 = cGSnap.Checked;
                XMLUtil.XMLLoadAttribute(attribute27, ref v2);
                cGSnap.Checked = v2;
                string attribute28 = xmlElement17.GetAttribute("wPosition");
                NumericUpDown cGB = TWPosition;
                decimal v3 = cGB.Value;
                XMLUtil.XMLLoadAttribute(attribute28, ref v3);
                cGB.Value = v3;
                string attribute29 = xmlElement17.GetAttribute("wLeft");
                cGB = TWLeft;
                v3 = cGB.Value;
                XMLUtil.XMLLoadAttribute(attribute29, ref v3);
                cGB.Value = v3;
                string attribute30 = xmlElement17.GetAttribute("wWidth");
                cGB = TWWidth;
                v3 = cGB.Value;
                XMLUtil.XMLLoadAttribute(attribute30, ref v3);
                cGB.Value = v3;
                string attribute31 = xmlElement17.GetAttribute("wPrecision");
                cGB = TWPrecision;
                v3 = cGB.Value;
                XMLUtil.XMLLoadAttribute(attribute31, ref v3);
                cGB.Value = v3;
                xmlElement17 = null;
            }
            XmlElement xmlElement18 = xmlElement["Player"];
            if (xmlElement18 != null)
            {
                XmlElement xmlElement19 = xmlElement18;
                XMLUtil.XMLLoadAttribute(xmlElement19.GetAttribute("CurrentPlayer"), ref CurrentPlayer);
                int num6 = Conversions.ToInteger(xmlElement19.GetAttribute("Count"));
                if (num6 > 0)
                {
                    pArgs = (PlayerArguments[])Utils.CopyArray(pArgs, new PlayerArguments[num6 - 1 + 1]);
                }
                xmlElement19 = null;
                IEnumerator enumerator = default(IEnumerator);
                try
                {
                    enumerator = xmlElement18.ChildNodes.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        XmlElement n = (XmlElement)enumerator.Current;
                        XMLLoadPlayer(n);
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
            XmlElement xmlElement20 = xmlElement["Columns"];
            if (xmlElement20 != null)
            {
                IEnumerator enumerator2 = default(IEnumerator);
                try
                {
                    enumerator2 = xmlElement20.ChildNodes.GetEnumerator();
                    while (enumerator2.MoveNext())
                    {
                        XmlElement n2 = (XmlElement)enumerator2.Current;
                        XMLLoadColumn(n2);
                    }
                }
                finally
                {
                    if (enumerator2 is IDisposable)
                    {
                        (enumerator2 as IDisposable).Dispose();
                    }
                }
            }
            XmlElement xmlElement21 = xmlElement["VisualSettings"];
            if (xmlElement21 != null)
            {
                XmlElement xmlElement22 = xmlElement21;
                XmlElement n3 = xmlElement22["ColumnTitle"];
                SolidBrush columnTitle = vo.ColumnTitle;
                Color v4 = columnTitle.Color;
                XMLLoadElementValue(n3, ref v4);
                columnTitle.Color = v4;
                XMLLoadElementValue(xmlElement22["ColumnTitleFont"], ref vo.ColumnTitleFont);
                XmlElement n4 = xmlElement22["Bg"];
                columnTitle = vo.Bg;
                v4 = columnTitle.Color;
                XMLLoadElementValue(n4, ref v4);
                columnTitle.Color = v4;
                XmlElement n5 = xmlElement22["Grid"];
                Pen pGrid = vo.pGrid;
                v4 = pGrid.Color;
                XMLLoadElementValue(n5, ref v4);
                pGrid.Color = v4;
                XmlElement n6 = xmlElement22["Sub"];
                pGrid = vo.pSub;
                v4 = pGrid.Color;
                XMLLoadElementValue(n6, ref v4);
                pGrid.Color = v4;
                XmlElement n7 = xmlElement22["VLine"];
                pGrid = vo.pVLine;
                v4 = pGrid.Color;
                XMLLoadElementValue(n7, ref v4);
                pGrid.Color = v4;
                XmlElement n8 = xmlElement22["MLine"];
                pGrid = vo.pMLine;
                v4 = pGrid.Color;
                XMLLoadElementValue(n8, ref v4);
                pGrid.Color = v4;
                XmlElement n9 = xmlElement22["BGMWav"];
                pGrid = vo.pBGMWav;
                v4 = pGrid.Color;
                XMLLoadElementValue(n9, ref v4);
                pGrid.Color = v4;
                TWTransparency.Value = new decimal(vo.pBGMWav.Color.A);
                TWTransparency2.Value = vo.pBGMWav.Color.A;
                TWSaturation.Value = new decimal(vo.pBGMWav.Color.GetSaturation() * 1000f);
                TWSaturation2.Value = (int)Math.Round(vo.pBGMWav.Color.GetSaturation() * 1000f);
                XmlElement n10 = xmlElement22["SelBox"];
                pGrid = vo.SelBox;
                v4 = pGrid.Color;
                XMLLoadElementValue(n10, ref v4);
                pGrid.Color = v4;
                XmlElement n11 = xmlElement22["TSCursor"];
                pGrid = vo.PECursor;
                v4 = pGrid.Color;
                XMLLoadElementValue(n11, ref v4);
                pGrid.Color = v4;
                XmlElement n12 = xmlElement22["TSHalf"];
                pGrid = vo.PEHalf;
                v4 = pGrid.Color;
                XMLLoadElementValue(n12, ref v4);
                pGrid.Color = v4;
                XMLLoadElementValue(xmlElement22["TSDeltaMouseOver"], ref vo.PEDeltaMouseOver);
                XmlElement n13 = xmlElement22["TSMouseOver"];
                pGrid = vo.PEMouseOver;
                v4 = pGrid.Color;
                XMLLoadElementValue(n13, ref v4);
                pGrid.Color = v4;
                XmlElement n14 = xmlElement22["TSSel"];
                columnTitle = vo.PESel;
                v4 = columnTitle.Color;
                XMLLoadElementValue(n14, ref v4);
                columnTitle.Color = v4;
                XmlElement n15 = xmlElement22["TSBPM"];
                columnTitle = vo.PEBPM;
                v4 = columnTitle.Color;
                XMLLoadElementValue(n15, ref v4);
                columnTitle.Color = v4;
                XMLLoadElementValue(xmlElement22["TSBPMFont"], ref vo.PEBPMFont);
                XMLLoadElementValue(xmlElement22["MiddleDeltaRelease"], ref vo.MiddleDeltaRelease);
                XMLLoadElementValue(xmlElement22["kHeight"], ref vo.kHeight);
                XMLLoadElementValue(xmlElement22["kFont"], ref vo.kFont);
                XMLLoadElementValue(xmlElement22["kMFont"], ref vo.kMFont);
                XMLLoadElementValue(xmlElement22["kLabelVShift"], ref vo.kLabelVShift);
                XMLLoadElementValue(xmlElement22["kLabelHShift"], ref vo.kLabelHShift);
                XMLLoadElementValue(xmlElement22["kLabelHShiftL"], ref vo.kLabelHShiftL);
                XmlElement n16 = xmlElement22["kMouseOver"];
                pGrid = vo.kMouseOver;
                v4 = pGrid.Color;
                XMLLoadElementValue(n16, ref v4);
                pGrid.Color = v4;
                XmlElement n17 = xmlElement22["kMouseOverE"];
                pGrid = vo.kMouseOverE;
                v4 = pGrid.Color;
                XMLLoadElementValue(n17, ref v4);
                pGrid.Color = v4;
                XmlElement n18 = xmlElement22["kSelected"];
                pGrid = vo.kSelected;
                v4 = pGrid.Color;
                XMLLoadElementValue(n18, ref v4);
                pGrid.Color = v4;
                XMLLoadElementValue(xmlElement22["kOpacity"], ref vo.kOpacity);
                xmlElement22 = null;
            }
        }
        UpdateColumnsX();
        fileStream.Close();
    }

    private void XMLLoadLocaleMenu(XmlElement n, ref string target)
    {
        if (n != null)
        {
            if (n.HasAttribute("amp"))
            {
                target = n.InnerText.Insert(int.Parse(n.GetAttribute("amp")), "&");
            }
            else
            {
                target = n.InnerText;
            }
        }
    }

    private void XMLLoadLocale(XmlElement n, ref string target)
    {
        if (n != null)
        {
            target = n.InnerText;
        }
    }

    private void XMLLoadLocaleToolTipUniversal(XmlElement n, Control target)
    {
        if (n != null)
        {
            ToolTipUniversal.SetToolTip(target, n.InnerText);
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    private void LoadLocale(string Path)
    {
        if (!MyProject.Computer.FileSystem.FileExists(Path))
        {
            return;
        }
        XmlDocument xmlDocument = null;
        FileStream fileStream = null;
        bool visible = POHeaderPart2.Visible;
        bool visible2 = POGridPart2.Visible;
        bool visible3 = POWaveFormPart2.Visible;
        POHeaderPart2.Visible = true;
        POGridPart2.Visible = true;
        POWaveFormPart2.Visible = true;

        try
        {
            xmlDocument = new XmlDocument();
            fileStream = new FileStream(Path, FileMode.Open, FileAccess.Read);
            xmlDocument.Load(fileStream);
            XmlElement xmlElement = xmlDocument["iBMSC.Locale"];
            if (xmlElement == null)
            {
                throw new NullReferenceException();
            }
            XMLLoadLocale(xmlElement["OK"], ref Strings.OK);
            XMLLoadLocale(xmlElement["Cancel"], ref Strings.Cancel);
            XMLLoadLocale(xmlElement["None"], ref Strings.None);
            XmlElement xmlElement2 = xmlElement["Font"];
            if (xmlElement2 != null)
            {
                int num = 9;
                if (xmlElement2.HasAttribute("Size"))
                {
                    num = (int)Math.Round(Conversion.Val(xmlElement2.GetAttribute("Size")));
                }
                Font font = new Font(Font.FontFamily, num, FontStyle.Regular);
                XmlNode xmlNode = xmlElement2.LastChild;
                while (xmlNode != null)
                {
                    if (Operators.CompareString(xmlNode.LocalName, "Family", TextCompare: false) == 0)
                    {
                        if (Functions.isFontInstalled(xmlNode.InnerText))
                        {
                            font = new Font(xmlNode.InnerText, num);
                        }
                        xmlNode = xmlNode.PreviousSibling;
                    }
                }
                object[] array = new object[10] { this, mnSys, Menu1, mnMain, cmnLanguage, cmnTheme, cmnConversion, TBMain, FStatus, FStatus2 };
                for (int i = 0; i < array.Length; i++)
                {
                    object objectValue = RuntimeHelpers.GetObjectValue(array[i]);
                    try
                    {
                        NewLateBinding.LateSet(objectValue, null, "Font", new object[1] { font }, null, null);
                    }
                    catch (Exception ex)
                    {
                        ProjectData.SetProjectError(ex);
                        Exception ex2 = ex;
                        ProjectData.ClearProjectError();
                    }
                }
                Font font2 = new Font(font, FontStyle.Bold);
                object[] array3 = new object[16]
                {
                        TBStatistics, FSSS, FSSL, FSSH, TVCM, TVCD, TVCBPM, FSP1, FSP3, FSP2,
                        PMain, PMainIn, PMainR, PMainInR, PMainL, PMainInL
                };
                for (int j = 0; j < array3.Length; j++)
                {
                    object objectValue2 = RuntimeHelpers.GetObjectValue(array3[j]);
                    try
                    {
                        NewLateBinding.LateSet(objectValue2, null, "Font", new object[1] { font2 }, null, null);
                    }
                    catch (Exception ex3)
                    {
                        ProjectData.SetProjectError(ex3);
                        Exception ex4 = ex3;
                        ProjectData.ClearProjectError();
                    }
                }
            }
            XmlElement xmlElement3 = xmlElement["MonoFont"];
            if (xmlElement3 != null)
            {
                int num2 = 9;
                if (xmlElement3.HasAttribute("Size"))
                {
                    num2 = (int)Math.Round(Conversion.Val(xmlElement3.GetAttribute("Size")));
                }
                Font font3 = new Font(POWAVInner.Font.FontFamily, num2);
                XmlNode xmlNode2 = xmlElement3.LastChild;
                while (xmlNode2 != null)
                {
                    if (Operators.CompareString(xmlNode2.LocalName, "Family", TextCompare: false) == 0)
                    {
                        if (Functions.isFontInstalled(xmlNode2.InnerText))
                        {
                            font3 = new Font(xmlNode2.InnerText, num2);
                        }
                        xmlNode2 = xmlNode2.PreviousSibling;
                    }
                }
                object[] array5 = new object[3] { LWAV, LBeat, TExpansion };
                for (int k = 0; k < array5.Length; k++)
                {
                    object objectValue3 = RuntimeHelpers.GetObjectValue(array5[k]);
                    try
                    {
                        NewLateBinding.LateSet(objectValue3, null, "font", new object[1] { font3 }, null, null);
                    }
                    catch (Exception ex5)
                    {
                        ProjectData.SetProjectError(ex5);
                        Exception ex6 = ex5;
                        ProjectData.ClearProjectError();
                    }
                }
            }
            XmlElement xmlElement4 = xmlElement["Menu"];
            if (xmlElement4 != null)
            {
                XmlElement xmlElement5 = xmlElement4["File"];
                ToolStripMenuItem toolStripMenuItem;
                string target;
                if (xmlElement5 != null)
                {
                    XmlElement n = xmlElement5["Title"];
                    toolStripMenuItem = mnFile;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n2 = xmlElement5["New"];
                    toolStripMenuItem = mnNew;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n2, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n3 = xmlElement5["Open"];
                    toolStripMenuItem = mnOpen;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n3, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n4 = xmlElement5["ImportSM"];
                    toolStripMenuItem = mnImportSM;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n4, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n5 = xmlElement5["ImportIBMSC"];
                    toolStripMenuItem = mnImportIBMSC;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n5, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n6 = xmlElement5["Save"];
                    toolStripMenuItem = mnSave;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n6, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n7 = xmlElement5["SaveAs"];
                    toolStripMenuItem = mnSaveAs;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n7, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n8 = xmlElement5["ExportIBMSC"];
                    toolStripMenuItem = mnExport;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n8, ref target);
                    toolStripMenuItem.Text = target;
                    if (Operators.CompareString(Recent[0], "", TextCompare: false) == 0)
                    {
                        XmlElement n9 = xmlElement5["Recent0"];
                        toolStripMenuItem = mnOpenR0;
                        target = toolStripMenuItem.Text;
                        XMLLoadLocaleMenu(n9, ref target);
                        toolStripMenuItem.Text = target;
                    }
                    if (Operators.CompareString(Recent[1], "", TextCompare: false) == 0)
                    {
                        XmlElement n10 = xmlElement5["Recent1"];
                        toolStripMenuItem = mnOpenR1;
                        target = toolStripMenuItem.Text;
                        XMLLoadLocaleMenu(n10, ref target);
                        toolStripMenuItem.Text = target;
                    }
                    if (Operators.CompareString(Recent[2], "", TextCompare: false) == 0)
                    {
                        XmlElement n11 = xmlElement5["Recent2"];
                        toolStripMenuItem = mnOpenR2;
                        target = toolStripMenuItem.Text;
                        XMLLoadLocaleMenu(n11, ref target);
                        toolStripMenuItem.Text = target;
                    }
                    if (Operators.CompareString(Recent[3], "", TextCompare: false) == 0)
                    {
                        XmlElement n12 = xmlElement5["Recent3"];
                        toolStripMenuItem = mnOpenR3;
                        target = toolStripMenuItem.Text;
                        XMLLoadLocaleMenu(n12, ref target);
                        toolStripMenuItem.Text = target;
                    }
                    if (Operators.CompareString(Recent[4], "", TextCompare: false) == 0)
                    {
                        XmlElement n13 = xmlElement5["Recent4"];
                        toolStripMenuItem = mnOpenR4;
                        target = toolStripMenuItem.Text;
                        XMLLoadLocaleMenu(n13, ref target);
                        toolStripMenuItem.Text = target;
                    }
                    XmlElement n14 = xmlElement5["Quit"];
                    toolStripMenuItem = mnQuit;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n14, ref target);
                    toolStripMenuItem.Text = target;
                }
                XmlElement xmlElement6 = xmlElement4["Edit"];
                if (xmlElement6 != null)
                {
                    XmlElement n15 = xmlElement6["Title"];
                    toolStripMenuItem = mnEdit;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n15, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n16 = xmlElement6["Undo"];
                    toolStripMenuItem = mnUndo;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n16, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n17 = xmlElement6["Redo"];
                    toolStripMenuItem = mnRedo;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n17, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n18 = xmlElement6["Cut"];
                    toolStripMenuItem = mnCut;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n18, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n19 = xmlElement6["Copy"];
                    toolStripMenuItem = mnCopy;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n19, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n20 = xmlElement6["Paste"];
                    toolStripMenuItem = mnPaste;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n20, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n21 = xmlElement6["Delete"];
                    toolStripMenuItem = mnDelete;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n21, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n22 = xmlElement6["SelectAll"];
                    toolStripMenuItem = mnSelectAll;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n22, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n23 = xmlElement6["Find"];
                    toolStripMenuItem = mnFind;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n23, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n24 = xmlElement6["Stat"];
                    toolStripMenuItem = mnStatistics;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n24, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n25 = xmlElement6["TimeSelectionTool"];
                    toolStripMenuItem = mnTimeSelect;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n25, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n26 = xmlElement6["SelectTool"];
                    toolStripMenuItem = mnSelect;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n26, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n27 = xmlElement6["WriteTool"];
                    toolStripMenuItem = mnWrite;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n27, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n28 = xmlElement6["MyO2"];
                    toolStripMenuItem = mnMyO2;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n28, ref target);
                    toolStripMenuItem.Text = target;
                }
                XmlElement xmlElement7 = xmlElement4["View"];
                if (xmlElement7 != null)
                {
                    XmlElement n29 = xmlElement7["Title"];
                    toolStripMenuItem = mnSys;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n29, ref target);
                    toolStripMenuItem.Text = target;
                }
                XmlElement xmlElement8 = xmlElement4["Options"];
                if (xmlElement8 != null)
                {
                    XmlElement n30 = xmlElement8["Title"];
                    toolStripMenuItem = mnOptions;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n30, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n31 = xmlElement8["NT"];
                    toolStripMenuItem = mnNTInput;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n31, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n32 = xmlElement8["ErrorCheck"];
                    toolStripMenuItem = mnErrorCheck;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n32, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n33 = xmlElement8["PreviewOnClick"];
                    toolStripMenuItem = mnPreviewOnClick;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n33, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n34 = xmlElement8["ShowFileName"];
                    toolStripMenuItem = mnShowFileName;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n34, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n35 = xmlElement8["GeneralOptions"];
                    toolStripMenuItem = mnGOptions;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n35, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n36 = xmlElement8["VisualOptions"];
                    toolStripMenuItem = mnVOptions;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n36, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n37 = xmlElement8["PlayerOptions"];
                    toolStripMenuItem = mnPOptions;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n37, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n38 = xmlElement8["Language"];
                    toolStripMenuItem = mnLanguage;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n38, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n39 = xmlElement8["Theme"];
                    toolStripMenuItem = mnTheme;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n39, ref target);
                    toolStripMenuItem.Text = target;
                }
                XmlElement n40 = xmlElement4["Conversion"];
                toolStripMenuItem = mnConversion;
                target = toolStripMenuItem.Text;
                XMLLoadLocaleMenu(n40, ref target);
                toolStripMenuItem.Text = target;
                XmlElement xmlElement9 = xmlElement4["Preview"];
                if (xmlElement9 != null)
                {
                    XmlElement n41 = xmlElement9["Title"];
                    toolStripMenuItem = mnPreview;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n41, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n42 = xmlElement9["PlayBegin"];
                    toolStripMenuItem = mnPlayB;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n42, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n43 = xmlElement9["PlayHere"];
                    toolStripMenuItem = mnPlay;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n43, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n44 = xmlElement9["PlayStop"];
                    toolStripMenuItem = mnStop;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n44, ref target);
                    toolStripMenuItem.Text = target;
                }
                XmlElement xmlElement10 = xmlElement4["About"];
            }
            XmlElement xmlElement11 = xmlElement["ToolBar"];
            if (xmlElement11 != null)
            {
                XmlElement n45 = xmlElement11["New"];
                ToolStripButton tBNew = TBNew;
                string target = tBNew.Text;
                XMLLoadLocale(n45, ref target);
                tBNew.Text = target;
                XmlElement n46 = xmlElement11["Open"];
                ToolStripSplitButton tBOpen = TBOpen;
                target = tBOpen.Text;
                XMLLoadLocale(n46, ref target);
                tBOpen.Text = target;
                XmlElement n47 = xmlElement11["Save"];
                tBOpen = TBSave;
                target = tBOpen.Text;
                XMLLoadLocale(n47, ref target);
                tBOpen.Text = target;
                XmlElement n48 = xmlElement11["Cut"];
                tBNew = TBCut;
                target = tBNew.Text;
                XMLLoadLocale(n48, ref target);
                tBNew.Text = target;
                XmlElement n49 = xmlElement11["Copy"];
                tBNew = TBCopy;
                target = tBNew.Text;
                XMLLoadLocale(n49, ref target);
                tBNew.Text = target;
                XmlElement n50 = xmlElement11["Paste"];
                tBNew = TBPaste;
                target = tBNew.Text;
                XMLLoadLocale(n50, ref target);
                tBNew.Text = target;
                XmlElement n51 = xmlElement11["Find"];
                tBNew = TBFind;
                target = tBNew.Text;
                XMLLoadLocale(n51, ref target);
                tBNew.Text = target;
                XmlElement n52 = xmlElement11["Stat"];
                tBNew = TBStatistics;
                target = tBNew.ToolTipText;
                XMLLoadLocale(n52, ref target);
                tBNew.ToolTipText = target;
                XmlElement n53 = xmlElement11["Conversion"];
                ToolStripDropDownButton pOConvert = POConvert;
                target = pOConvert.Text;
                XMLLoadLocale(n53, ref target);
                pOConvert.Text = target;
                XmlElement n54 = xmlElement11["MyO2"];
                tBNew = TBMyO2;
                target = tBNew.Text;
                XMLLoadLocale(n54, ref target);
                tBNew.Text = target;
                XmlElement n55 = xmlElement11["ErrorCheck"];
                tBNew = TBErrorCheck;
                target = tBNew.Text;
                XMLLoadLocale(n55, ref target);
                tBNew.Text = target;
                XmlElement n56 = xmlElement11["PreviewOnClick"];
                tBNew = TBPreviewOnClick;
                target = tBNew.Text;
                XMLLoadLocale(n56, ref target);
                tBNew.Text = target;
                XmlElement n57 = xmlElement11["ShowFileName"];
                tBNew = TBShowFileName;
                target = tBNew.Text;
                XMLLoadLocale(n57, ref target);
                tBNew.Text = target;
                XmlElement n58 = xmlElement11["Undo"];
                tBNew = TBUndo;
                target = tBNew.Text;
                XMLLoadLocale(n58, ref target);
                tBNew.Text = target;
                XmlElement n59 = xmlElement11["Redo"];
                tBNew = TBRedo;
                target = tBNew.Text;
                XMLLoadLocale(n59, ref target);
                tBNew.Text = target;
                XmlElement n60 = xmlElement11["NT"];
                tBNew = TBNTInput;
                target = tBNew.Text;
                XMLLoadLocale(n60, ref target);
                tBNew.Text = target;
                XmlElement n61 = xmlElement11["TimeSelectionTool"];
                tBNew = TBTimeSelect;
                target = tBNew.Text;
                XMLLoadLocale(n61, ref target);
                tBNew.Text = target;
                XmlElement n62 = xmlElement11["SelectTool"];
                tBNew = TBSelect;
                target = tBNew.Text;
                XMLLoadLocale(n62, ref target);
                tBNew.Text = target;
                XmlElement n63 = xmlElement11["WriteTool"];
                tBNew = TBWrite;
                target = tBNew.Text;
                XMLLoadLocale(n63, ref target);
                tBNew.Text = target;
                XmlElement n64 = xmlElement11["PlayBegin"];
                tBNew = TBPlayB;
                target = tBNew.Text;
                XMLLoadLocale(n64, ref target);
                tBNew.Text = target;
                XmlElement n65 = xmlElement11["PlayHere"];
                tBNew = TBPlay;
                target = tBNew.Text;
                XMLLoadLocale(n65, ref target);
                tBNew.Text = target;
                XmlElement n66 = xmlElement11["PlayStop"];
                tBNew = TBStop;
                target = tBNew.Text;
                XMLLoadLocale(n66, ref target);
                tBNew.Text = target;
                XmlElement n67 = xmlElement11["PlayerOptions"];
                tBNew = TBPOptions;
                target = tBNew.Text;
                XMLLoadLocale(n67, ref target);
                tBNew.Text = target;
                XmlElement n68 = xmlElement11["VisualOptions"];
                tBNew = TBVOptions;
                target = tBNew.Text;
                XMLLoadLocale(n68, ref target);
                tBNew.Text = target;
                XmlElement n69 = xmlElement11["GeneralOptions"];
                tBNew = TBGOptions;
                target = tBNew.Text;
                XMLLoadLocale(n69, ref target);
                tBNew.Text = target;
                XmlElement n70 = xmlElement11["Language"];
                pOConvert = TBLanguage;
                target = pOConvert.Text;
                XMLLoadLocale(n70, ref target);
                pOConvert.Text = target;
                XmlElement n71 = xmlElement11["Theme"];
                pOConvert = TBTheme;
                target = pOConvert.Text;
                XMLLoadLocale(n71, ref target);
                pOConvert.Text = target;
            }
            XmlElement xmlElement12 = xmlElement["StatusBar"];
            if (xmlElement12 != null)
            {
                XmlElement n72 = xmlElement12["ColumnCaption"];
                ToolStripStatusLabel fSC = FSC;
                string target = fSC.ToolTipText;
                XMLLoadLocale(n72, ref target);
                fSC.ToolTipText = target;
                XmlElement n73 = xmlElement12["NoteIndex"];
                fSC = FSW;
                target = fSC.ToolTipText;
                XMLLoadLocale(n73, ref target);
                fSC.ToolTipText = target;
                XmlElement n74 = xmlElement12["MeasureIndex"];
                fSC = FSM;
                target = fSC.ToolTipText;
                XMLLoadLocale(n74, ref target);
                fSC.ToolTipText = target;
                XmlElement n75 = xmlElement12["GridResolution"];
                fSC = FSP1;
                target = fSC.ToolTipText;
                XMLLoadLocale(n75, ref target);
                fSC.ToolTipText = target;
                XmlElement n76 = xmlElement12["ReducedResolution"];
                fSC = FSP3;
                target = fSC.ToolTipText;
                XMLLoadLocale(n76, ref target);
                fSC.ToolTipText = target;
                XmlElement n77 = xmlElement12["MeasureResolution"];
                fSC = FSP2;
                target = fSC.ToolTipText;
                XMLLoadLocale(n77, ref target);
                fSC.ToolTipText = target;
                XmlElement n78 = xmlElement12["AbsolutePosition"];
                fSC = FSP4;
                target = fSC.ToolTipText;
                XMLLoadLocale(n78, ref target);
                fSC.ToolTipText = target;
                XMLLoadLocale(xmlElement12["Length"], ref Strings.StatusBar.Length);
                XMLLoadLocale(xmlElement12["LongNote"], ref Strings.StatusBar.LongNote);
                XMLLoadLocale(xmlElement12["Hidden"], ref Strings.StatusBar.Hidden);
                XMLLoadLocale(xmlElement12["Error"], ref Strings.StatusBar.Err);
                XmlElement n79 = xmlElement12["SelStart"];
                ToolStripButton tBNew = FSSS;
                target = tBNew.ToolTipText;
                XMLLoadLocale(n79, ref target);
                tBNew.ToolTipText = target;
                XmlElement n80 = xmlElement12["SelLength"];
                tBNew = FSSL;
                target = tBNew.ToolTipText;
                XMLLoadLocale(n80, ref target);
                tBNew.ToolTipText = target;
                XmlElement n81 = xmlElement12["SelSplit"];
                tBNew = FSSH;
                target = tBNew.ToolTipText;
                XMLLoadLocale(n81, ref target);
                tBNew.ToolTipText = target;
                XmlElement n82 = xmlElement12["Reverse"];
                tBNew = BVCReverse;
                target = tBNew.Text;
                XMLLoadLocale(n82, ref target);
                tBNew.Text = target;
                XmlElement n83 = xmlElement12["ByMultiple"];
                tBNew = BVCApply;
                target = tBNew.Text;
                XMLLoadLocale(n83, ref target);
                tBNew.Text = target;
                XmlElement n84 = xmlElement12["ByValue"];
                tBNew = BVCCalculate;
                target = tBNew.Text;
                XMLLoadLocale(n84, ref target);
                tBNew.Text = target;
            }
            XmlElement xmlElement13 = xmlElement["SubMenu"];
            if (xmlElement13 != null)
            {
                XmlElement xmlElement14 = xmlElement13["ShowHide"];
                if (xmlElement14 != null)
                {
                    XmlElement n85 = xmlElement14["Menu"];
                    ToolStripMenuItem toolStripMenuItem = mnSMenu;
                    string target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n85, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n86 = xmlElement14["ToolBar"];
                    toolStripMenuItem = mnSTB;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n86, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n87 = xmlElement14["OptionsPanel"];
                    toolStripMenuItem = mnSOP;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n87, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n88 = xmlElement14["StatusBar"];
                    toolStripMenuItem = mnSStatus;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n88, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n89 = xmlElement14["LSplit"];
                    toolStripMenuItem = mnSLSplitter;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n89, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n90 = xmlElement14["RSplit"];
                    toolStripMenuItem = mnSRSplitter;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n90, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n91 = xmlElement14["Grid"];
                    toolStripMenuItem = CGShow;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n91, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n92 = xmlElement14["Sub"];
                    toolStripMenuItem = CGShowS;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n92, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n93 = xmlElement14["BG"];
                    toolStripMenuItem = CGShowBG;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n93, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n94 = xmlElement14["MeasureIndex"];
                    toolStripMenuItem = CGShowM;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n94, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n95 = xmlElement14["MeasureLine"];
                    toolStripMenuItem = CGShowMB;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n95, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n96 = xmlElement14["Vertical"];
                    toolStripMenuItem = CGShowV;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n96, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n97 = xmlElement14["ColumnCaption"];
                    toolStripMenuItem = CGShowC;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n97, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n98 = xmlElement14["BPM"];
                    toolStripMenuItem = CGBPM;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n98, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n99 = xmlElement14["STOP"];
                    toolStripMenuItem = CGSTOP;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n99, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n100 = xmlElement14["SCROLL"];
                    toolStripMenuItem = CGSCROLL;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n100, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n101 = xmlElement14["BLP"];
                    toolStripMenuItem = CGBLP;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n101, ref target);
                    toolStripMenuItem.Text = target;
                }
                XmlElement xmlElement15 = xmlElement13["InsertMeasure"];
                if (xmlElement15 != null)
                {
                    XmlElement n102 = xmlElement15["Insert"];
                    ToolStripMenuItem toolStripMenuItem = MInsert;
                    string target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n102, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n103 = xmlElement15["Remove"];
                    toolStripMenuItem = MRemove;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n103, ref target);
                    toolStripMenuItem.Text = target;
                }
                XmlElement xmlElement16 = xmlElement13["Language"];
                if (xmlElement16 != null)
                {
                    XmlElement n104 = xmlElement16["Default"];
                    ToolStripMenuItem toolStripMenuItem = TBLangDef;
                    string target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n104, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n105 = xmlElement16["Refresh"];
                    toolStripMenuItem = TBLangRefresh;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n105, ref target);
                    toolStripMenuItem.Text = target;
                }
                XmlElement xmlElement17 = xmlElement13["Theme"];
                if (xmlElement17 != null)
                {
                    XmlElement n106 = xmlElement17["Default"];
                    ToolStripMenuItem toolStripMenuItem = TBThemeDef;
                    string target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n106, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n107 = xmlElement17["Save"];
                    toolStripMenuItem = TBThemeSave;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n107, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n108 = xmlElement17["Refresh"];
                    toolStripMenuItem = TBThemeRefresh;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n108, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n109 = xmlElement17["LoadComptability"];
                    toolStripMenuItem = TBThemeLoadComptability;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n109, ref target);
                    toolStripMenuItem.Text = target;
                }
                XmlElement xmlElement18 = xmlElement13["Convert"];
                if (xmlElement18 != null)
                {
                    XmlElement n110 = xmlElement18["Long"];
                    ToolStripMenuItem toolStripMenuItem = POBLong;
                    string target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n110, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n111 = xmlElement18["Short"];
                    toolStripMenuItem = POBShort;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n111, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n112 = xmlElement18["LongShort"];
                    toolStripMenuItem = POBLongShort;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n112, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n113 = xmlElement18["Hidden"];
                    toolStripMenuItem = POBHidden;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n113, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n114 = xmlElement18["Visible"];
                    toolStripMenuItem = POBVisible;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n114, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n115 = xmlElement18["HiddenVisible"];
                    toolStripMenuItem = POBHiddenVisible;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n115, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n116 = xmlElement18["Relabel"];
                    toolStripMenuItem = POBModify;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n116, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n117 = xmlElement18["Mirror"];
                    toolStripMenuItem = POBMirror;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n117, ref target);
                    toolStripMenuItem.Text = target;
                }
                XmlElement xmlElement19 = xmlElement13["WAV"];
                if (xmlElement19 != null)
                {
                    XmlElement n118 = xmlElement19["MultiSelection"];
                    CheckBox cWAVMultiSelect = CWAVMultiSelect;
                    string target = cWAVMultiSelect.Text;
                    XMLLoadLocaleMenu(n118, ref target);
                    cWAVMultiSelect.Text = target;
                    XmlElement n119 = xmlElement19["Synchronize"];
                    cWAVMultiSelect = CWAVChangeLabel;
                    target = cWAVMultiSelect.Text;
                    XMLLoadLocaleMenu(n119, ref target);
                    cWAVMultiSelect.Text = target;
                }
                XmlElement xmlElement20 = xmlElement13["Beat"];
                if (xmlElement20 != null)
                {
                    XmlElement n120 = xmlElement20["Absolute"];
                    RadioButton cBeatPreserve = CBeatPreserve;
                    string target = cBeatPreserve.Text;
                    XMLLoadLocaleMenu(n120, ref target);
                    cBeatPreserve.Text = target;
                    XmlElement n121 = xmlElement20["Measure"];
                    cBeatPreserve = CBeatMeasure;
                    target = cBeatPreserve.Text;
                    XMLLoadLocaleMenu(n121, ref target);
                    cBeatPreserve.Text = target;
                    XmlElement n122 = xmlElement20["Cut"];
                    cBeatPreserve = CBeatCut;
                    target = cBeatPreserve.Text;
                    XMLLoadLocaleMenu(n122, ref target);
                    cBeatPreserve.Text = target;
                    XmlElement n123 = xmlElement20["Scale"];
                    cBeatPreserve = CBeatScale;
                    target = cBeatPreserve.Text;
                    XMLLoadLocaleMenu(n123, ref target);
                    cBeatPreserve.Text = target;
                }
            }
            XmlElement xmlElement21 = xmlElement["OptionsPanel"];
            if (xmlElement21 != null)
            {
                XmlElement xmlElement22 = xmlElement21["Header"];
                CheckBox cWAVMultiSelect;
                string target;
                if (xmlElement22 != null)
                {
                    XmlElement n124 = xmlElement22["Header"];
                    cWAVMultiSelect = POHeaderSwitch;
                    target = cWAVMultiSelect.Text;
                    XMLLoadLocale(n124, ref target);
                    cWAVMultiSelect.Text = target;
                    XmlElement n125 = xmlElement22["Title"];
                    Label label = Label3;
                    target = label.Text;
                    XMLLoadLocale(n125, ref target);
                    label.Text = target;
                    XmlElement n126 = xmlElement22["Artist"];
                    label = Label4;
                    target = label.Text;
                    XMLLoadLocale(n126, ref target);
                    label.Text = target;
                    XmlElement n127 = xmlElement22["Genre"];
                    label = Label2;
                    target = label.Text;
                    XMLLoadLocale(n127, ref target);
                    label.Text = target;
                    XmlElement n128 = xmlElement22["BPM"];
                    label = Label9;
                    target = label.Text;
                    XMLLoadLocale(n128, ref target);
                    label.Text = target;
                    XmlElement n129 = xmlElement22["Player"];
                    label = Label8;
                    target = label.Text;
                    XMLLoadLocale(n129, ref target);
                    label.Text = target;
                    XmlElement n130 = xmlElement22["Rank"];
                    label = Label10;
                    target = label.Text;
                    XMLLoadLocale(n130, ref target);
                    label.Text = target;
                    XmlElement n131 = xmlElement22["PlayLevel"];
                    label = Label6;
                    target = label.Text;
                    XMLLoadLocale(n131, ref target);
                    label.Text = target;
                    XmlElement n132 = xmlElement22["SubTitle"];
                    label = Label15;
                    target = label.Text;
                    XMLLoadLocale(n132, ref target);
                    label.Text = target;
                    XmlElement n133 = xmlElement22["SubArtist"];
                    label = Label17;
                    target = label.Text;
                    XMLLoadLocale(n133, ref target);
                    label.Text = target;
                    XmlElement n134 = xmlElement22["StageFile"];
                    label = Label16;
                    target = label.Text;
                    XMLLoadLocale(n134, ref target);
                    label.Text = target;
                    XmlElement n135 = xmlElement22["Banner"];
                    label = Label12;
                    target = label.Text;
                    XMLLoadLocale(n135, ref target);
                    label.Text = target;
                    XmlElement n136 = xmlElement22["BackBMP"];
                    label = Label11;
                    target = label.Text;
                    XMLLoadLocale(n136, ref target);
                    label.Text = target;
                    XmlElement n137 = xmlElement22["Difficulty"];
                    label = Label21;
                    target = label.Text;
                    XMLLoadLocale(n137, ref target);
                    label.Text = target;
                    XmlElement n138 = xmlElement22["ExRank"];
                    label = Label23;
                    target = label.Text;
                    XMLLoadLocale(n138, ref target);
                    label.Text = target;
                    XmlElement n139 = xmlElement22["Total"];
                    label = Label20;
                    target = label.Text;
                    XMLLoadLocale(n139, ref target);
                    label.Text = target;
                    XmlElement n140 = xmlElement22["Comment"];
                    label = Label19;
                    target = label.Text;
                    XMLLoadLocale(n140, ref target);
                    label.Text = target;
                    XmlElement n141 = xmlElement22["LnObj"];
                    label = Label24;
                    target = label.Text;
                    XMLLoadLocale(n141, ref target);
                    label.Text = target;
                    CHPlayer.SelectedIndexChanged -= CHPlayer_SelectedIndexChanged;
                    XmlElement n142 = xmlElement22["Player1"];
                    ComboBox.ObjectCollection items = CHPlayer.Items;
                    ComboBox.ObjectCollection objectCollection = items;
                    int index = 0;
                    target = Conversions.ToString(objectCollection[index]);
                    XMLLoadLocale(n142, ref target);
                    items[index] = target;
                    XmlElement n143 = xmlElement22["Player2"];
                    items = CHPlayer.Items;
                    ComboBox.ObjectCollection objectCollection2 = items;
                    index = 1;
                    target = Conversions.ToString(objectCollection2[index]);
                    XMLLoadLocale(n143, ref target);
                    items[index] = target;
                    XmlElement n144 = xmlElement22["Player3"];
                    items = CHPlayer.Items;
                    ComboBox.ObjectCollection objectCollection3 = items;
                    index = 2;
                    target = Conversions.ToString(objectCollection3[index]);
                    XMLLoadLocale(n144, ref target);
                    items[index] = target;
                    CHPlayer.SelectedIndexChanged += CHPlayer_SelectedIndexChanged;
                    CHRank.SelectedIndexChanged -= THGenre_TextChanged;
                    XmlElement n145 = xmlElement22["Rank0"];
                    items = CHRank.Items;
                    ComboBox.ObjectCollection objectCollection4 = items;
                    index = 0;
                    target = Conversions.ToString(objectCollection4[index]);
                    XMLLoadLocale(n145, ref target);
                    items[index] = target;
                    XmlElement n146 = xmlElement22["Rank1"];
                    items = CHRank.Items;
                    ComboBox.ObjectCollection objectCollection5 = items;
                    index = 1;
                    target = Conversions.ToString(objectCollection5[index]);
                    XMLLoadLocale(n146, ref target);
                    items[index] = target;
                    XmlElement n147 = xmlElement22["Rank2"];
                    items = CHRank.Items;
                    ComboBox.ObjectCollection objectCollection6 = items;
                    index = 2;
                    target = Conversions.ToString(objectCollection6[index]);
                    XMLLoadLocale(n147, ref target);
                    items[index] = target;
                    XmlElement n148 = xmlElement22["Rank3"];
                    items = CHRank.Items;
                    ComboBox.ObjectCollection objectCollection7 = items;
                    index = 3;
                    target = Conversions.ToString(objectCollection7[index]);
                    XMLLoadLocale(n148, ref target);
                    items[index] = target;
                    XmlElement n149 = xmlElement22["Rank4"];
                    items = CHRank.Items;
                    ComboBox.ObjectCollection objectCollection8 = items;
                    index = 4;
                    target = Conversions.ToString(objectCollection8[index]);
                    XMLLoadLocale(n149, ref target);
                    items[index] = target;
                    CHRank.SelectedIndexChanged += THGenre_TextChanged;
                    CHDifficulty.SelectedIndexChanged -= THGenre_TextChanged;
                    XmlElement n150 = xmlElement22["Difficulty0"];
                    items = CHDifficulty.Items;
                    ComboBox.ObjectCollection objectCollection9 = items;
                    index = 0;
                    target = Conversions.ToString(objectCollection9[index]);
                    XMLLoadLocale(n150, ref target);
                    items[index] = target;
                    XmlElement n151 = xmlElement22["Difficulty1"];
                    items = CHDifficulty.Items;
                    ComboBox.ObjectCollection objectCollection10 = items;
                    index = 1;
                    target = Conversions.ToString(objectCollection10[index]);
                    XMLLoadLocale(n151, ref target);
                    items[index] = target;
                    XmlElement n152 = xmlElement22["Difficulty2"];
                    items = CHDifficulty.Items;
                    ComboBox.ObjectCollection objectCollection11 = items;
                    index = 2;
                    target = Conversions.ToString(objectCollection11[index]);
                    XMLLoadLocale(n152, ref target);
                    items[index] = target;
                    XmlElement n153 = xmlElement22["Difficulty3"];
                    items = CHDifficulty.Items;
                    ComboBox.ObjectCollection objectCollection12 = items;
                    index = 3;
                    target = Conversions.ToString(objectCollection12[index]);
                    XMLLoadLocale(n153, ref target);
                    items[index] = target;
                    XmlElement n154 = xmlElement22["Difficulty4"];
                    items = CHDifficulty.Items;
                    ComboBox.ObjectCollection objectCollection13 = items;
                    index = 4;
                    target = Conversions.ToString(objectCollection13[index]);
                    XMLLoadLocale(n154, ref target);
                    items[index] = target;
                    XmlElement n155 = xmlElement22["Difficulty5"];
                    items = CHDifficulty.Items;
                    ComboBox.ObjectCollection objectCollection14 = items;
                    index = 5;
                    target = Conversions.ToString(objectCollection14[index]);
                    XMLLoadLocale(n155, ref target);
                    items[index] = target;
                    CHDifficulty.SelectedIndexChanged += THGenre_TextChanged;
                }
                XmlElement xmlElement23 = xmlElement21["Grid"];
                if (xmlElement23 != null)
                {
                    XmlElement n156 = xmlElement23["Title"];
                    cWAVMultiSelect = POGridSwitch;
                    target = cWAVMultiSelect.Text;
                    XMLLoadLocale(n156, ref target);
                    cWAVMultiSelect.Text = target;
                    XmlElement n157 = xmlElement23["Snap"];
                    cWAVMultiSelect = CGSnap;
                    target = cWAVMultiSelect.Text;
                    XMLLoadLocale(n157, ref target);
                    cWAVMultiSelect.Text = target;
                    XmlElement n158 = xmlElement23["BCols"];
                    Label label = Label1;
                    target = label.Text;
                    XMLLoadLocale(n158, ref target);
                    label.Text = target;
                    XmlElement n159 = xmlElement23["DisableVertical"];
                    cWAVMultiSelect = CGDisableVertical;
                    target = cWAVMultiSelect.Text;
                    XMLLoadLocale(n159, ref target);
                    cWAVMultiSelect.Text = target;
                    XmlElement n160 = xmlElement23["Scroll"];
                    label = Label5;
                    target = label.Text;
                    XMLLoadLocale(n160, ref target);
                    label.Text = target;
                    XMLLoadLocaleToolTipUniversal(xmlElement23["LockLeft"], cVSLockL);
                    XMLLoadLocaleToolTipUniversal(xmlElement23["LockMiddle"], cVSLock);
                    XMLLoadLocaleToolTipUniversal(xmlElement23["LockRight"], cVSLockR);
                }
                XmlElement xmlElement24 = xmlElement21["WaveForm"];
                if (xmlElement24 != null)
                {
                    XmlElement n161 = xmlElement24["Title"];
                    cWAVMultiSelect = POWaveFormSwitch;
                    target = cWAVMultiSelect.Text;
                    XMLLoadLocale(n161, ref target);
                    cWAVMultiSelect.Text = target;
                    XMLLoadLocaleToolTipUniversal(xmlElement24["Load"], BWLoad);
                    XMLLoadLocaleToolTipUniversal(xmlElement24["Clear"], BWClear);
                    XMLLoadLocaleToolTipUniversal(xmlElement24["Lock"], BWLock);
                }
                XmlElement xmlElement25 = xmlElement21["WAV"];
                if (xmlElement25 != null)
                {
                    XmlElement n162 = xmlElement25["Title"];
                    cWAVMultiSelect = POWAVSwitch;
                    target = cWAVMultiSelect.Text;
                    XMLLoadLocale(n162, ref target);
                    cWAVMultiSelect.Text = target;
                    XMLLoadLocaleToolTipUniversal(xmlElement25["MoveUp"], BWAVUp);
                    XMLLoadLocaleToolTipUniversal(xmlElement25["MoveDown"], BWAVDown);
                    XMLLoadLocaleToolTipUniversal(xmlElement25["Browse"], BWAVBrowse);
                    XMLLoadLocaleToolTipUniversal(xmlElement25["Remove"], BWAVRemove);
                }
                XmlElement n163 = xmlElement21["Beat"];
                cWAVMultiSelect = POBeatSwitch;
                target = cWAVMultiSelect.Text;
                XMLLoadLocale(n163, ref target);
                cWAVMultiSelect.Text = target;
                XmlElement n164 = xmlElement21["Beat.Apply"];
                Button bBeatApply = BBeatApply;
                target = bBeatApply.Text;
                XMLLoadLocale(n164, ref target);
                bBeatApply.Text = target;
                XmlElement n165 = xmlElement21["Beat.Apply"];
                bBeatApply = BBeatApplyV;
                target = bBeatApply.Text;
                XMLLoadLocale(n165, ref target);
                bBeatApply.Text = target;
                XmlElement n166 = xmlElement21["Expansion"];
                cWAVMultiSelect = POExpansionSwitch;
                target = cWAVMultiSelect.Text;
                XMLLoadLocale(n166, ref target);
                cWAVMultiSelect.Text = target;
            }
            XmlElement xmlElement26 = xmlElement["Messages"];
            if (xmlElement26 != null)
            {
                XMLLoadLocale(xmlElement26["Err"], ref Strings.Messages.Err);
                XMLLoadLocale(xmlElement26["SaveOnExit"], ref Strings.Messages.SaveOnExit);
                XMLLoadLocale(xmlElement26["SaveOnExit1"], ref Strings.Messages.SaveOnExit1);
                XMLLoadLocale(xmlElement26["SaveOnExit2"], ref Strings.Messages.SaveOnExit2);
                XMLLoadLocale(xmlElement26["PromptEnter"], ref Strings.Messages.PromptEnter);
                XMLLoadLocale(xmlElement26["PromptEnterNumeric"], ref Strings.Messages.PromptEnterNumeric);
                XMLLoadLocale(xmlElement26["PromptEnterBPM"], ref Strings.Messages.PromptEnterBPM);
                XMLLoadLocale(xmlElement26["PromptEnterSTOP"], ref Strings.Messages.PromptEnterSTOP);
                XMLLoadLocale(xmlElement26["PromptEnterSCROLL"], ref Strings.Messages.PromptEnterSCROLL);
                XMLLoadLocale(xmlElement26["PromptSlashValue"], ref Strings.Messages.PromptSlashValue);
                XMLLoadLocale(xmlElement26["InvalidLabel"], ref Strings.Messages.InvalidLabel);
                XMLLoadLocale(xmlElement26["CannotFind"], ref Strings.Messages.CannotFind);
                XMLLoadLocale(xmlElement26["PleaseRespecifyPath"], ref Strings.Messages.PleaseRespecifyPath);
                XMLLoadLocale(xmlElement26["PlayerNotFound"], ref Strings.Messages.PlayerNotFound);
                XMLLoadLocale(xmlElement26["PreviewDelError"], ref Strings.Messages.PreviewDelError);
                XMLLoadLocale(xmlElement26["NegativeFactorError"], ref Strings.Messages.NegativeFactorError);
                XMLLoadLocale(xmlElement26["NegativeDivisorError"], ref Strings.Messages.NegativeDivisorError);
                XMLLoadLocale(xmlElement26["PreferencePostpone"], ref Strings.Messages.PreferencePostpone);
                XMLLoadLocale(xmlElement26["EraserObsolete"], ref Strings.Messages.EraserObsolete);
                XMLLoadLocale(xmlElement26["SaveWarning"], ref Strings.Messages.SaveWarning);
                XMLLoadLocale(xmlElement26["NoteOverlapError"], ref Strings.Messages.NoteOverlapError);
                XMLLoadLocale(xmlElement26["BPMOverflowError"], ref Strings.Messages.BPMOverflowError);
                XMLLoadLocale(xmlElement26["STOPOverflowError"], ref Strings.Messages.STOPOverflowError);
                XMLLoadLocale(xmlElement26["SCROLLOverflowError"], ref Strings.Messages.SCROLLOverflowError);
                XMLLoadLocale(xmlElement26["SavedFileWillContainErrors"], ref Strings.Messages.SavedFileWillContainErrors);
                XMLLoadLocale(xmlElement26["FileAssociationPrompt"], ref Strings.Messages.FileAssociationPrompt);
                XMLLoadLocale(xmlElement26["FileAssociationError"], ref Strings.Messages.FileAssociationError);
                XMLLoadLocale(xmlElement26["RestoreDefaultSettings"], ref Strings.Messages.RestoreDefaultSettings);
                XMLLoadLocale(xmlElement26["RestoreAutosavedFile"], ref Strings.Messages.RestoreAutosavedFile);
            }
            XmlElement xmlElement27 = xmlElement["FileType"];
            if (xmlElement27 != null)
            {
                XMLLoadLocale(xmlElement27["_all"], ref Strings.FileType._all);
                XMLLoadLocale(xmlElement27["_bms"], ref Strings.FileType._bms);
                XMLLoadLocale(xmlElement27["BMS"], ref Strings.FileType.BMS);
                XMLLoadLocale(xmlElement27["BME"], ref Strings.FileType.BME);
                XMLLoadLocale(xmlElement27["BML"], ref Strings.FileType.BML);
                XMLLoadLocale(xmlElement27["PMS"], ref Strings.FileType.PMS);
                XMLLoadLocale(xmlElement27["TXT"], ref Strings.FileType.TXT);
                XMLLoadLocale(xmlElement27["SM"], ref Strings.FileType.SM);
                XMLLoadLocale(xmlElement27["IBMSC"], ref Strings.FileType.IBMSC);
                XMLLoadLocale(xmlElement27["XML"], ref Strings.FileType.XML);
                XMLLoadLocale(xmlElement27["THEME_XML"], ref Strings.FileType.THEME_XML);
                XMLLoadLocale(xmlElement27["TH"], ref Strings.FileType.TH);
                XMLLoadLocale(xmlElement27["_audio"], ref Strings.FileType._audio);
                XMLLoadLocale(xmlElement27["_wave"], ref Strings.FileType._wave);
                XMLLoadLocale(xmlElement27["WAV"], ref Strings.FileType.WAV);
                XMLLoadLocale(xmlElement27["OGG"], ref Strings.FileType.OGG);
                XMLLoadLocale(xmlElement27["MP3"], ref Strings.FileType.MP3);
                XMLLoadLocale(xmlElement27["MID"], ref Strings.FileType.MID);
                XMLLoadLocale(xmlElement27["_image"], ref Strings.FileType._image);
                XMLLoadLocale(xmlElement27["EXE"], ref Strings.FileType.EXE);
            }
            XmlElement xmlElement28 = xmlElement["Statistics"];
            if (xmlElement28 != null)
            {
                XMLLoadLocale(xmlElement28["Title"], ref Strings.fStatistics.Title);
                XMLLoadLocale(xmlElement28["lBPM"], ref Strings.fStatistics.lBPM);
                XMLLoadLocale(xmlElement28["lSTOP"], ref Strings.fStatistics.lSTOP);
                XMLLoadLocale(xmlElement28["lSCROLL"], ref Strings.fStatistics.lSCROLL);
                XMLLoadLocale(xmlElement28["lA"], ref Strings.fStatistics.lA);
                XMLLoadLocale(xmlElement28["lD"], ref Strings.fStatistics.lD);
                XMLLoadLocale(xmlElement28["lBGM"], ref Strings.fStatistics.lBGM);
                XMLLoadLocale(xmlElement28["lTotal"], ref Strings.fStatistics.lTotal);
                XMLLoadLocale(xmlElement28["lShort"], ref Strings.fStatistics.lShort);
                XMLLoadLocale(xmlElement28["lLong"], ref Strings.fStatistics.lLong);
                XMLLoadLocale(xmlElement28["lLnObj"], ref Strings.fStatistics.lLnObj);
                XMLLoadLocale(xmlElement28["lHidden"], ref Strings.fStatistics.lHidden);
                XMLLoadLocale(xmlElement28["lErrors"], ref Strings.fStatistics.lErrors);
            }
            XmlElement xmlElement29 = xmlElement["PlayerOptions"];
            if (xmlElement29 != null)
            {
                XMLLoadLocale(xmlElement29["Title"], ref Strings.fopPlayer.Title);
                XMLLoadLocale(xmlElement29["Add"], ref Strings.fopPlayer.Add);
                XMLLoadLocale(xmlElement29["Remove"], ref Strings.fopPlayer.Remove);
                XMLLoadLocale(xmlElement29["Path"], ref Strings.fopPlayer.Path);
                XMLLoadLocale(xmlElement29["PlayFromBeginning"], ref Strings.fopPlayer.PlayFromBeginning);
                XMLLoadLocale(xmlElement29["PlayFromHere"], ref Strings.fopPlayer.PlayFromHere);
                XMLLoadLocale(xmlElement29["StopPlaying"], ref Strings.fopPlayer.StopPlaying);
                XMLLoadLocale(xmlElement29["References"], ref Strings.fopPlayer.References);
                XMLLoadLocale(xmlElement29["DirectoryOfApp"], ref Strings.fopPlayer.DirectoryOfApp);
                XMLLoadLocale(xmlElement29["CurrMeasure"], ref Strings.fopPlayer.CurrMeasure);
                XMLLoadLocale(xmlElement29["FileName"], ref Strings.fopPlayer.FileName);
                XMLLoadLocale(xmlElement29["RestoreDefault"], ref Strings.fopPlayer.RestoreDefault);
            }
            XmlElement xmlElement30 = xmlElement["VisualOptions"];
            if (xmlElement30 != null)
            {
                XMLLoadLocale(xmlElement30["Title"], ref Strings.fopVisual.Title);
                XMLLoadLocale(xmlElement30["Width"], ref Strings.fopVisual.Width);
                XMLLoadLocale(xmlElement30["Caption"], ref Strings.fopVisual.Caption);
                XMLLoadLocale(xmlElement30["Note"], ref Strings.fopVisual.Note);
                XMLLoadLocale(xmlElement30["Label"], ref Strings.fopVisual.Label);
                XMLLoadLocale(xmlElement30["LongNote"], ref Strings.fopVisual.LongNote);
                XMLLoadLocale(xmlElement30["LongNoteLabel"], ref Strings.fopVisual.LongNoteLabel);
                XMLLoadLocale(xmlElement30["Bg"], ref Strings.fopVisual.Bg);
                XMLLoadLocale(xmlElement30["ColumnCaption"], ref Strings.fopVisual.ColumnCaption);
                XMLLoadLocale(xmlElement30["ColumnCaptionFont"], ref Strings.fopVisual.ColumnCaptionFont);
                XMLLoadLocale(xmlElement30["Background"], ref Strings.fopVisual.Background);
                XMLLoadLocale(xmlElement30["Grid"], ref Strings.fopVisual.Grid);
                XMLLoadLocale(xmlElement30["SubGrid"], ref Strings.fopVisual.SubGrid);
                XMLLoadLocale(xmlElement30["VerticalLine"], ref Strings.fopVisual.VerticalLine);
                XMLLoadLocale(xmlElement30["MeasureBarLine"], ref Strings.fopVisual.MeasureBarLine);
                XMLLoadLocale(xmlElement30["BGMWaveform"], ref Strings.fopVisual.BGMWaveform);
                XMLLoadLocale(xmlElement30["NoteHeight"], ref Strings.fopVisual.NoteHeight);
                XMLLoadLocale(xmlElement30["NoteLabel"], ref Strings.fopVisual.NoteLabel);
                XMLLoadLocale(xmlElement30["MeasureLabel"], ref Strings.fopVisual.MeasureLabel);
                XMLLoadLocale(xmlElement30["LabelVerticalShift"], ref Strings.fopVisual.LabelVerticalShift);
                XMLLoadLocale(xmlElement30["LabelHorizontalShift"], ref Strings.fopVisual.LabelHorizontalShift);
                XMLLoadLocale(xmlElement30["LongNoteLabelHorizontalShift"], ref Strings.fopVisual.LongNoteLabelHorizontalShift);
                XMLLoadLocale(xmlElement30["HiddenNoteOpacity"], ref Strings.fopVisual.HiddenNoteOpacity);
                XMLLoadLocale(xmlElement30["NoteBorderOnMouseOver"], ref Strings.fopVisual.NoteBorderOnMouseOver);
                XMLLoadLocale(xmlElement30["NoteBorderOnSelection"], ref Strings.fopVisual.NoteBorderOnSelection);
                XMLLoadLocale(xmlElement30["NoteBorderOnAdjustingLength"], ref Strings.fopVisual.NoteBorderOnAdjustingLength);
                XMLLoadLocale(xmlElement30["SelectionBoxBorder"], ref Strings.fopVisual.SelectionBoxBorder);
                XMLLoadLocale(xmlElement30["TSCursor"], ref Strings.fopVisual.TSCursor);
                XMLLoadLocale(xmlElement30["TSSplitter"], ref Strings.fopVisual.TSSplitter);
                XMLLoadLocale(xmlElement30["TSCursorSensitivity"], ref Strings.fopVisual.TSCursorSensitivity);
                XMLLoadLocale(xmlElement30["TSMouseOverBorder"], ref Strings.fopVisual.TSMouseOverBorder);
                XMLLoadLocale(xmlElement30["TSFill"], ref Strings.fopVisual.TSFill);
                XMLLoadLocale(xmlElement30["TSBPM"], ref Strings.fopVisual.TSBPM);
                XMLLoadLocale(xmlElement30["TSBPMFont"], ref Strings.fopVisual.TSBPMFont);
                XMLLoadLocale(xmlElement30["MiddleSensitivity"], ref Strings.fopVisual.MiddleSensitivity);
            }
            XmlElement xmlElement31 = xmlElement["GeneralOptions"];
            if (xmlElement31 != null)
            {
                XMLLoadLocale(xmlElement31["Title"], ref Strings.fopGeneral.Title);
                XMLLoadLocale(xmlElement31["MouseWheel"], ref Strings.fopGeneral.MouseWheel);
                XMLLoadLocale(xmlElement31["TextEncoding"], ref Strings.fopGeneral.TextEncoding);
                XMLLoadLocale(xmlElement31["PageUpDown"], ref Strings.fopGeneral.PageUpDown);
                XMLLoadLocale(xmlElement31["MiddleButton"], ref Strings.fopGeneral.MiddleButton);
                XMLLoadLocale(xmlElement31["MiddleButtonAuto"], ref Strings.fopGeneral.MiddleButtonAuto);
                XMLLoadLocale(xmlElement31["MiddleButtonDrag"], ref Strings.fopGeneral.MiddleButtonDrag);
                XMLLoadLocale(xmlElement31["AssociateFileType"], ref Strings.fopGeneral.AssociateFileType);
                XMLLoadLocale(xmlElement31["MaxGridPartition"], ref Strings.fopGeneral.MaxGridPartition);
                XMLLoadLocale(xmlElement31["BeepWhileSaved"], ref Strings.fopGeneral.BeepWhileSaved);
                XMLLoadLocale(xmlElement31["ExtendBPM"], ref Strings.fopGeneral.ExtendBPM);
                XMLLoadLocale(xmlElement31["ExtendSTOP"], ref Strings.fopGeneral.ExtendSTOP);
                XMLLoadLocale(xmlElement31["AutoFocusOnMouseEnter"], ref Strings.fopGeneral.AutoFocusOnMouseEnter);
                XMLLoadLocale(xmlElement31["DisableFirstClick"], ref Strings.fopGeneral.DisableFirstClick);
                XMLLoadLocale(xmlElement31["AutoSave"], ref Strings.fopGeneral.AutoSave);
                XMLLoadLocale(xmlElement31["minutes"], ref Strings.fopGeneral.minutes);
                XMLLoadLocale(xmlElement31["StopPreviewOnClick"], ref Strings.fopGeneral.StopPreviewOnClick);
            }
            XmlElement xmlElement32 = xmlElement["Find"];
            if (xmlElement32 != null)
            {
                XMLLoadLocale(xmlElement32["NoteRange"], ref Strings.fFind.NoteRange);
                XMLLoadLocale(xmlElement32["MeasureRange"], ref Strings.fFind.MeasureRange);
                XMLLoadLocale(xmlElement32["LabelRange"], ref Strings.fFind.LabelRange);
                XMLLoadLocale(xmlElement32["ValueRange"], ref Strings.fFind.ValueRange);
                XMLLoadLocale(xmlElement32["to"], ref Strings.fFind.to_);
                XMLLoadLocale(xmlElement32["Selected"], ref Strings.fFind.Selected);
                XMLLoadLocale(xmlElement32["UnSelected"], ref Strings.fFind.UnSelected);
                XMLLoadLocale(xmlElement32["ShortNote"], ref Strings.fFind.ShortNote);
                XMLLoadLocale(xmlElement32["LongNote"], ref Strings.fFind.LongNote);
                XMLLoadLocale(xmlElement32["Hidden"], ref Strings.fFind.Hidden);
                XMLLoadLocale(xmlElement32["Visible"], ref Strings.fFind.Visible);
                XMLLoadLocale(xmlElement32["Column"], ref Strings.fFind.Column);
                XMLLoadLocale(xmlElement32["SelectAll"], ref Strings.fFind.SelectAll);
                XMLLoadLocale(xmlElement32["SelectInverse"], ref Strings.fFind.SelectInverse);
                XMLLoadLocale(xmlElement32["UnselectAll"], ref Strings.fFind.UnselectAll);
                XMLLoadLocale(xmlElement32["Operation"], ref Strings.fFind.Operation);
                XMLLoadLocale(xmlElement32["ReplaceWithLabel"], ref Strings.fFind.ReplaceWithLabel);
                XMLLoadLocale(xmlElement32["ReplaceWithValue"], ref Strings.fFind.ReplaceWithValue);
                XMLLoadLocale(xmlElement32["Select"], ref Strings.fFind.Select_);
                XMLLoadLocale(xmlElement32["Unselect"], ref Strings.fFind.Unselect_);
                XMLLoadLocale(xmlElement32["Delete"], ref Strings.fFind.Delete_);
                XMLLoadLocale(xmlElement32["Close"], ref Strings.fFind.Close_);
            }
            XmlElement xmlElement33 = xmlElement["ImportSM"];
            if (xmlElement33 != null)
            {
                XMLLoadLocale(xmlElement33["Title"], ref Strings.fImportSM.Title);
                XMLLoadLocale(xmlElement33["Difficulty"], ref Strings.fImportSM.Difficulty);
                XMLLoadLocale(xmlElement33["Note"], ref Strings.fImportSM.Note);
            }
            XmlElement xmlElement34 = xmlElement["FileAssociation"];
            if (xmlElement34 != null)
            {
                XMLLoadLocale(xmlElement34["BMS"], ref Strings.FileAssociation.BMS);
                XMLLoadLocale(xmlElement34["BME"], ref Strings.FileAssociation.BME);
                XMLLoadLocale(xmlElement34["BML"], ref Strings.FileAssociation.BML);
                XMLLoadLocale(xmlElement34["PMS"], ref Strings.FileAssociation.PMS);
                XMLLoadLocale(xmlElement34["IBMSC"], ref Strings.FileAssociation.IBMSC);
                XMLLoadLocale(xmlElement34["Open"], ref Strings.FileAssociation.Open);
                XMLLoadLocale(xmlElement34["Preview"], ref Strings.FileAssociation.Preview);
                XMLLoadLocale(xmlElement34["ViewCode"], ref Strings.FileAssociation.ViewCode);
            }
            DispLang = Path.Replace(MyProject.Application.Info.DirectoryPath + "\\", "");
        }
        catch (Exception ex7)
        {
            ProjectData.SetProjectError(ex7);
            Interaction.MsgBox(Path + "\r\n\r\n" + ex7.Message, MsgBoxStyle.Exclamation);
            ProjectData.ClearProjectError();
        }
        finally
        {
            fileStream?.Close();
            POHeaderPart2.Visible = visible;
            POGridPart2.Visible = visible2;
            POWaveFormPart2.Visible = visible3;
        }
    }

    private void LoadThemeComptability(string xPath)
    {
        try
        {
            string[] array = Microsoft.VisualBasic.Strings.Split(MyProject.Computer.FileSystem.ReadAllText(xPath), "\r\n");
            if ((Operators.CompareString(array[0].Trim(), "iBMSC Configuration Settings Format", TextCompare: false) != 0) & (Operators.CompareString(array[0].Trim(), "iBMSC Theme Format", TextCompare: false) != 0))
            {
                return;
            }
            string text = "";
            string text2 = "";
            foreach (string text3 in array)
            {
                text = Microsoft.VisualBasic.Strings.UCase(Microsoft.VisualBasic.Strings.Mid(text3, 1, Microsoft.VisualBasic.Strings.InStr(text3, "=") - 1));
                text2 = Microsoft.VisualBasic.Strings.Mid(text3, Microsoft.VisualBasic.Strings.InStr(text3, "=") + 1);
                switch (text)
                {
                    case "VOTITLE":
                        vo.ColumnTitle.Color = Color.FromArgb((int)Math.Round(Conversion.Val(text2)));
                        break;
                    case "VOTITLEFONT":
                        vo.ColumnTitleFont = Functions.StringToFont(text2, Font);
                        break;
                    case "VOBG":
                        vo.Bg.Color = Color.FromArgb((int)Math.Round(Conversion.Val(text2)));
                        break;
                    case "VOGRID":
                        vo.pGrid.Color = Color.FromArgb((int)Math.Round(Conversion.Val(text2)));
                        break;
                    case "VOSUB":
                        vo.pSub.Color = Color.FromArgb((int)Math.Round(Conversion.Val(text2)));
                        break;
                    case "VOVLINE":
                        vo.pVLine.Color = Color.FromArgb((int)Math.Round(Conversion.Val(text2)));
                        break;
                    case "VOMLINE":
                        vo.pMLine.Color = Color.FromArgb((int)Math.Round(Conversion.Val(text2)));
                        break;
                    case "VOBGMWAV":
                        vo.pBGMWav.Color = Color.FromArgb((int)Math.Round(Conversion.Val(text2)));
                        TWTransparency.Value = new decimal(vo.pBGMWav.Color.A);
                        TWTransparency2.Value = vo.pBGMWav.Color.A;
                        TWSaturation.Value = new decimal(vo.pBGMWav.Color.GetSaturation() * 1000f);
                        TWSaturation2.Value = (int)Math.Round(vo.pBGMWav.Color.GetSaturation() * 1000f);
                        break;
                    case "VOSELBOX":
                        vo.SelBox.Color = Color.FromArgb((int)Math.Round(Conversion.Val(text2)));
                        break;
                    case "VOPECURSOR":
                        vo.PECursor.Color = Color.FromArgb((int)Math.Round(Conversion.Val(text2)));
                        break;
                    case "VOPEHALF":
                        vo.PEHalf.Color = Color.FromArgb((int)Math.Round(Conversion.Val(text2)));
                        break;
                    case "VOPEDELTAMOUSEOVER":
                        vo.PEDeltaMouseOver = (int)Math.Round(Conversion.Val(text2));
                        break;
                    case "VOPEMOUSEOVER":
                        vo.PEMouseOver.Color = Color.FromArgb((int)Math.Round(Conversion.Val(text2)));
                        break;
                    case "VOPESEL":
                        vo.PESel.Color = Color.FromArgb((int)Math.Round(Conversion.Val(text2)));
                        break;
                    case "VOPEBPM":
                        vo.PEBPM.Color = Color.FromArgb((int)Math.Round(Conversion.Val(text2)));
                        break;
                    case "VOPEBPMFONT":
                        vo.PEBPMFont = Functions.StringToFont(text2, Font);
                        break;
                    case "VKHEIGHT":
                        vo.kHeight = (int)Math.Round(Conversion.Val(text2));
                        break;
                    case "VKFONT":
                        vo.kFont = Functions.StringToFont(text2, Font);
                        break;
                    case "VKMFONT":
                        vo.kMFont = Functions.StringToFont(text2, Font);
                        break;
                    case "VKLABELVSHIFT":
                        vo.kLabelVShift = (int)Math.Round(Conversion.Val(text2));
                        break;
                    case "VKLABELHSHIFT":
                        vo.kLabelHShift = (int)Math.Round(Conversion.Val(text2));
                        break;
                    case "VKLABELHSHIFTL":
                        vo.kLabelHShiftL = (int)Math.Round(Conversion.Val(text2));
                        break;
                    case "VKMOUSEOVER":
                        vo.kMouseOver.Color = Color.FromArgb((int)Math.Round(Conversion.Val(text2)));
                        break;
                    case "VKMOUSEOVERE ":
                        vo.kMouseOverE.Color = Color.FromArgb((int)Math.Round(Conversion.Val(text2)));
                        break;
                    case "VKSELECTED":
                        vo.kSelected.Color = Color.FromArgb((int)Math.Round(Conversion.Val(text2)));
                        break;
                    case "KLENGTH":
                        {
                            string[] array9 = LoadThemeComptability_SplitStringInto26Parts(text2);
                            int num7 = 0;
                            do
                            {
                                column[num7].Width = (int)Math.Round(Conversion.Val(array9[num7]));
                                num7++;
                            }
                            while (num7 <= 26);
                            break;
                        }
                    case "KTITLE":
                        {
                            string[] array8 = LoadThemeComptability_SplitStringInto26Parts(text2);
                            int num6 = 0;
                            do
                            {
                                column[num6].Title = array8[num6];
                                num6++;
                            }
                            while (num6 <= 26);
                            break;
                        }
                    case "KCOLOR":
                        {
                            string[] array7 = LoadThemeComptability_SplitStringInto26Parts(text2);
                            int num5 = 0;
                            do
                            {
                                column[num5].setNoteColor((int)Math.Round(Conversion.Val(array7[num5])));
                                num5++;
                            }
                            while (num5 <= 26);
                            break;
                        }
                    case "KCOLORL":
                        {
                            string[] array6 = LoadThemeComptability_SplitStringInto26Parts(text2);
                            int num4 = 0;
                            do
                            {
                                column[num4].setLNoteColor((int)Math.Round(Conversion.Val(array6[num4])));
                                num4++;
                            }
                            while (num4 <= 26);
                            break;
                        }
                    case "KFORECOLOR":
                        {
                            string[] array5 = LoadThemeComptability_SplitStringInto26Parts(text2);
                            int num3 = 0;
                            do
                            {
                                column[num3].cText = Color.FromArgb((int)Math.Round(Conversion.Val(array5[num3])));
                                num3++;
                            }
                            while (num3 <= 26);
                            break;
                        }
                    case "KFORECOLORL":
                        {
                            string[] array4 = LoadThemeComptability_SplitStringInto26Parts(text2);
                            int num2 = 0;
                            do
                            {
                                column[num2].cLText = Color.FromArgb((int)Math.Round(Conversion.Val(array4[num2])));
                                num2++;
                            }
                            while (num2 <= 26);
                            break;
                        }
                    case "KBGCOLOR":
                        {
                            string[] array3 = LoadThemeComptability_SplitStringInto26Parts(text2);
                            int num = 0;
                            do
                            {
                                column[num].cBG = Color.FromArgb((int)Math.Round(Conversion.Val(array3[num])));
                                num++;
                            }
                            while (num <= 26);
                            break;
                        }
                }
            }
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Interaction.MsgBox(ex.Message, MsgBoxStyle.Exclamation, Strings.Messages.Err);
            ProjectData.ClearProjectError();
        }
        finally
        {
            UpdateColumnsX();
        }
    }

    private string[] LoadThemeComptability_SplitStringInto26Parts(string xLine)
    {
        string[] array = Microsoft.VisualBasic.Strings.Split(xLine, ",");
        return (string[])Utils.CopyArray(array, new string[27]);
    }

    private void LoadLang(object sender, EventArgs e)
    {
        string path = Conversions.ToString(NewLateBinding.LateGet(sender, null, "ToolTipText", Array.Empty<object>(), null, null, null));
        LoadLocale(path);
    }

    private void LoadLocaleXML(FileInfo xStr)
    {
        XmlDocument xmlDocument = new XmlDocument();
        FileStream fileStream = new FileStream(xStr.FullName, FileMode.Open, FileAccess.Read);
        try
        {
            xmlDocument.Load(fileStream);
            string left = xmlDocument["iBMSC.Locale"].GetAttribute("Name");
            if (Operators.CompareString(left, "", TextCompare: false) == 0)
            {
                left = xStr.Name;
            }
            cmnLanguage.Items.Add(left, null, LoadLang);
            cmnLanguage.Items[cmnLanguage.Items.Count - 1].ToolTipText = xStr.FullName;
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Interaction.MsgBox(xStr.FullName + "\r\n\r\n" + ex.Message, MsgBoxStyle.Exclamation);
            ProjectData.ClearProjectError();
        }
        fileStream.Close();
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    private void LoadTheme(object sender, EventArgs e)
    {
        LoadSettings(Conversions.ToString(Operators.ConcatenateObject(MyProject.Application.Info.DirectoryPath + "\\Data\\", NewLateBinding.LateGet(sender, null, "Text", Array.Empty<object>(), null, null, null))));
        RefreshPanelAll();
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
        toolStripMenuItem.Text = Conversions.ToString(Interaction.IIf(Operators.CompareString(Text, "", TextCompare: false) == 0, "<" + Strings.None + ">", GetFileName(Text)));
        toolStripMenuItem.ToolTipText = Text;
        toolStripMenuItem.Enabled = Operators.CompareString(Text, "", TextCompare: false) != 0;
        toolStripMenuItem2.Text = Conversions.ToString(Interaction.IIf(Operators.CompareString(Text, "", TextCompare: false) == 0, "<" + Strings.None + ">", GetFileName(Text)));
        toolStripMenuItem2.ToolTipText = Text;
        toolStripMenuItem2.Enabled = Operators.CompareString(Text, "", TextCompare: false) != 0;
    }

    private void OpenRecent(string xFileName)
    {
        SelectedNotes = Array.Empty<Note>();
        KMouseOver = -1;
        if (!MyProject.Computer.FileSystem.FileExists(xFileName))
        {
            Interaction.MsgBox(Strings.Messages.CannotFind.Replace("{}", xFileName), MsgBoxStyle.Critical);
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
        base.FormClosed += Form1_FormClosed;
        base.FormClosing += Form1_FormClosing;
        base.DragEnter += Form1_DragEnter;
        base.DragLeave += Form1_DragLeave;
        base.DragDrop += Form1_DragDrop;
        base.KeyDown += Form1_KeyDown;
        base.KeyUp += Form1_KeyUp;
        base.Disposed += [SpecialName][DebuggerStepThrough] (object a0, EventArgs a1) =>
        {
            Unload();
        };
        base.Load += Form1_Load;
        BMSChannelList = new string[72]
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
        Column[] array = new Column[28];
        ref Column reference = ref array[0];
        Column column = new Column(0, 50, "Measure", xNoteCol: false, xisNumeric: true, xVisible: true, 0, 0, -16711681, 0, -16711681, 0);
        reference = column;
        ref Column reference2 = ref array[1];
        Column column2 = new Column(50, 60, "SCROLL", xNoteCol: true, xisNumeric: true, xVisible: true, 99, 0, -65536, 0, -65536, 0);
        reference2 = column2;
        ref Column reference3 = ref array[2];
        Column column3 = new Column(110, 60, "BPM", xNoteCol: true, xisNumeric: true, xVisible: true, 3, 0, -65536, 0, -65536, 0);
        reference3 = column3;
        ref Column reference4 = ref array[3];
        Column column4 = new Column(170, 50, "STOP", xNoteCol: true, xisNumeric: true, xVisible: true, 9, 0, -65536, 0, -65536, 0);
        reference4 = column4;
        ref Column reference5 = ref array[4];
        Column column5 = new Column(220, 5, "", xNoteCol: false, xisNumeric: false, xVisible: true, 0, 0, 0, 0, 0, 0);
        reference5 = column5;
        ref Column reference6 = ref array[5];
        Column column6 = new Column(225, 42, "A1", xNoteCol: true, xisNumeric: false, xVisible: true, 16, -5197648, -16777216, -4144960, -16777216, 352321535);
        reference6 = column6;
        ref Column reference7 = ref array[6];
        Column column7 = new Column(267, 30, "A2", xNoteCol: true, xisNumeric: false, xVisible: true, 11, -10309377, -16777216, -9785097, -16777216, 335557631);
        reference7 = column7;
        ref Column reference8 = ref array[7];
        Column column8 = new Column(297, 42, "A3", xNoteCol: true, xisNumeric: false, xVisible: true, 12, -5197648, -16777216, -4144960, -16777216, 352321535);
        reference8 = column8;
        ref Column reference9 = ref array[8];
        Column column9 = new Column(339, 45, "A4", xNoteCol: true, xisNumeric: false, xVisible: true, 13, -14238, -16777216, -539030, -16777216, 385059596);
        reference9 = column9;
        ref Column reference10 = ref array[9];
        Column column10 = new Column(384, 42, "A5", xNoteCol: true, xisNumeric: false, xVisible: true, 14, -5197648, -16777216, -4144960, -16777216, 352321535);
        reference10 = column10;
        ref Column reference11 = ref array[10];
        Column column11 = new Column(426, 30, "A6", xNoteCol: true, xisNumeric: false, xVisible: true, 15, -10309377, -16777216, -9785097, -16777216, 335557631);
        reference11 = column11;
        ref Column reference12 = ref array[11];
        Column column12 = new Column(456, 42, "A7", xNoteCol: true, xisNumeric: false, xVisible: true, 18, -5197648, -16777216, -4144960, -16777216, 352321535);
        reference12 = column12;
        ref Column reference13 = ref array[12];
        Column column13 = new Column(498, 40, "A8", xNoteCol: true, xisNumeric: false, xVisible: true, 19, -8355712, -16777216, -7303024, -16777216, 0);
        reference13 = column13;
        ref Column reference14 = ref array[13];
        Column column14 = new Column(498, 5, "", xNoteCol: false, xisNumeric: false, xVisible: true, 0, 0, 0, 0, 0, 0);
        reference14 = column14;
        ref Column reference15 = ref array[14];
        Column column15 = new Column(503, 42, "D1", xNoteCol: true, xisNumeric: false, xVisible: false, 21, -5197648, -16777216, -4144960, -16777216, 352321535);
        reference15 = column15;
        ref Column reference16 = ref array[15];
        Column column16 = new Column(503, 30, "D2", xNoteCol: true, xisNumeric: false, xVisible: false, 22, -10309377, -16777216, -9785097, -16777216, 335557631);
        reference16 = column16;
        ref Column reference17 = ref array[16];
        Column column17 = new Column(503, 42, "D3", xNoteCol: true, xisNumeric: false, xVisible: false, 23, -5197648, -16777216, -4144960, -16777216, 352321535);
        reference17 = column17;
        ref Column reference18 = ref array[17];
        Column column18 = new Column(503, 45, "D4", xNoteCol: true, xisNumeric: false, xVisible: false, 24, -14238, -16777216, -539030, -16777216, 385059596);
        reference18 = column18;
        ref Column reference19 = ref array[18];
        Column column19 = new Column(503, 42, "D5", xNoteCol: true, xisNumeric: false, xVisible: false, 25, -5197648, -16777216, -4144960, -16777216, 352321535);
        reference19 = column19;
        ref Column reference20 = ref array[19];
        Column column20 = new Column(503, 30, "D6", xNoteCol: true, xisNumeric: false, xVisible: false, 28, -10309377, -16777216, -9785097, -16777216, 335557631);
        reference20 = column20;
        ref Column reference21 = ref array[20];
        Column column21 = new Column(503, 42, "D7", xNoteCol: true, xisNumeric: false, xVisible: false, 29, -5197648, -16777216, -4144960, -16777216, 352321535);
        reference21 = column21;
        ref Column reference22 = ref array[21];
        Column column22 = new Column(503, 40, "D8", xNoteCol: true, xisNumeric: false, xVisible: false, 26, -8355712, -16777216, -7303024, -16777216, 0);
        reference22 = column22;
        ref Column reference23 = ref array[22];
        Column column23 = new Column(503, 5, "", xNoteCol: false, xisNumeric: false, xVisible: false, 0, 0, 0, 0, 0, 0);
        reference23 = column23;
        ref Column reference24 = ref array[23];
        Column column24 = new Column(503, 40, "BGA", xNoteCol: true, xisNumeric: false, xVisible: false, 4, -7546998, -16777216, -7285874, -16777216, 0);
        reference24 = column24;
        ref Column reference25 = ref array[24];
        Column column25 = new Column(503, 40, "LAYER", xNoteCol: true, xisNumeric: false, xVisible: false, 7, -7546998, -16777216, -7285874, -16777216, 0);
        reference25 = column25;
        ref Column reference26 = ref array[25];
        Column column26 = new Column(503, 40, "POOR", xNoteCol: true, xisNumeric: false, xVisible: false, 6, -7546998, -16777216, -7285874, -16777216, 0);
        reference26 = column26;
        ref Column reference27 = ref array[26];
        Column column27 = new Column(503, 5, "", xNoteCol: false, xisNumeric: false, xVisible: false, 0, 0, 0, 0, 0, 0);
        reference27 = column27;
        ref Column reference28 = ref array[27];
        Column column28 = new Column(503, 40, "B", xNoteCol: true, xisNumeric: false, xVisible: true, 1, -1998720, -16777216, -2325115, -16777216, 0);
        reference28 = column28;
        this.column = array;
        MeasureLength = new double[1000];
        MeasureBottom = new double[1000];
        Note[] array2 = new Note[1];
        ref Note reference29 = ref array2[0];
        Note note = new Note(2, -1.0, 1200000L);
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
        Point point = new Point(-1, -1);
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
        PlayerArguments[] array3 = new PlayerArguments[2];
        ref PlayerArguments reference31 = ref array3[0];
        PlayerArguments playerArguments = new PlayerArguments("<apppath>\\uBMplay.exe", "-P -N0 \"<filename>\"", "-P -N<measure> \"<filename>\"", "-S");
        reference31 = playerArguments;
        ref PlayerArguments reference32 = ref array3[1];
        PlayerArguments playerArguments2 = new PlayerArguments("<apppath>\\o2play.exe", "-P -N0 \"<filename>\"", "-P -N<measure> \"<filename>\"", "-S");
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
