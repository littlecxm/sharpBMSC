using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
public partial  class MainWindow : Form
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
        string[] array = Microsoft.VisualBasic.Strings.Split(xStrAll, "\r\n", -1, CompareMethod.Text);
        string text = "";
        Notes = new Note[1];
        mColumn = new int[1000];
        hWAV = new string[1296];
        hBPM = new long[1296];
        hSTOP = new long[1296];
        hSCROLL = new long[1296];
        InitializeNewBMS();
        InitializeOpenBMS();
        Note[] notes = Notes;
        int num = 0;
        notes[num].ColumnIndex = 2;
        notes[num].VPosition = -1.0;
        notes[num].Value = 1200000L;
        int num2 = 0;
        checked
        {
            foreach (string text2 in array)
            {
                string text3 = text2.Trim();
                if (num2 <= 0)
                {
                    if (text3.StartsWith("#") & (Operators.CompareString(Microsoft.VisualBasic.Strings.Mid(text3, 5, 3), "02:", TextCompare: false) == 0))
                    {
                        int num3 = (int)Math.Round(Conversion.Val(Microsoft.VisualBasic.Strings.Mid(text3, 2, 3)));
                        double num4 = Conversion.Val(Microsoft.VisualBasic.Strings.Mid(text3, 8));
                        long denominator = Functions.GetDenominator(num4, 2147483647L);
                        MeasureLength[num3] = num4 * 192.0;
                        LBeat.Items[num3] = Operators.ConcatenateObject(string.Concat(Functions.Add3Zeros(num3) + ": ", Conversions.ToString(num4)), Interaction.IIf(denominator > 10000, "", " ( " + Conversions.ToString((long)Math.Round(num4 * (double)denominator)) + " / " + Conversions.ToString(denominator) + " ) "));
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
                        THBPM.Value = new decimal((double)Notes[0].Value / 10000.0);
                        continue;
                    }
                    if (text3.StartsWith("#PLAYER", StringComparison.CurrentCultureIgnoreCase))
                    {
                        int num5 = (int)Math.Round(Conversion.Val(Microsoft.VisualBasic.Strings.Mid(text3, Microsoft.VisualBasic.Strings.Len("#PLAYER") + 1).Trim()));
                        if (unchecked(num5 >= 1 && num5 <= 4))
                        {
                            CHPlayer.SelectedIndex = num5 - 1;
                        }
                        continue;
                    }
                    if (text3.StartsWith("#RANK", StringComparison.CurrentCultureIgnoreCase))
                    {
                        int num6 = (int)Math.Round(Conversion.Val(Microsoft.VisualBasic.Strings.Mid(text3, Microsoft.VisualBasic.Strings.Len("#RANK") + 1).Trim()));
                        if (unchecked(num6 >= 0 && num6 <= 4))
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
                            Exception ex2 = ex;
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
                        string text4 = Microsoft.VisualBasic.Strings.Mid(text3, Microsoft.VisualBasic.Strings.Len("#TOTAL") + 1).Trim();
                        THTotal.Text = text4;
                        continue;
                    }
                    if (text3.StartsWith("#COMMENT", StringComparison.CurrentCultureIgnoreCase))
                    {
                        string text5 = Microsoft.VisualBasic.Strings.Mid(text3, Microsoft.VisualBasic.Strings.Len("#COMMENT") + 1).Trim();
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
                        int selectedIndex = Functions.C36to10(Microsoft.VisualBasic.Strings.Mid(text3, Microsoft.VisualBasic.Strings.Len("#LNOBJ") + 1).Trim());
                        CHLnObj.SelectedIndex = selectedIndex;
                        continue;
                    }
                    if (text3.StartsWith("#") & (Operators.CompareString(Microsoft.VisualBasic.Strings.Mid(text3, 7, 1), ":", TextCompare: false) == 0))
                    {
                        string i2 = Microsoft.VisualBasic.Strings.Mid(text3, 5, 2);
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
            foreach (string text2 in array)
            {
                string text6 = text2.Trim();
                if (num2 > 0 || !(text6.StartsWith("#") & (Operators.CompareString(Microsoft.VisualBasic.Strings.Mid(text6, 7, 1), ":", TextCompare: false) == 0)))
                {
                    continue;
                }
                int num7 = (int)Math.Round(Conversion.Val(Microsoft.VisualBasic.Strings.Mid(text6, 2, 3)));
                string text7 = Microsoft.VisualBasic.Strings.Mid(text6, 5, 2);
                if (BMSChannelToColumn(text7) == 0)
                {
                    continue;
                }
                if (Operators.CompareString(text7, "01", TextCompare: false) == 0)
                {
                    int[] array4 = mColumn;
                    array4[num7]++;
                }
                int num9 = Microsoft.VisualBasic.Strings.Len(text6) - 1;
                for (k = 8; k <= num9; k += 2)
                {
                    if (Operators.CompareString(Microsoft.VisualBasic.Strings.Mid(text6, k, 2), "00", TextCompare: false) != 0)
                    {
                        Notes = (Note[])Utils.CopyArray(Notes, new Note[Notes.Length + 1]);
                        Note[] notes2 = Notes;
                        int num10 = Information.UBound(Notes);
                        notes2[num10].ColumnIndex = Conversions.ToInteger(Operators.AddObject(BMSChannelToColumn(text7), Operators.MultiplyObject(Interaction.IIf(Operators.CompareString(text7, "01", TextCompare: false) == 0, 1, 0), mColumn[num7] - 1)));
                        notes2[num10].LongNote = BMS.IsChannelLongNote(text7);
                        notes2[num10].Hidden = BMS.IsChannelHidden(text7);
                        notes2[num10].Landmine = BMS.IsChannelLandmine(text7);
                        notes2[num10].Selected = false;
                        notes2[num10].VPosition = MeasureBottom[num7] + MeasureLength[num7] * ((double)k / 2.0 - 4.0) / ((double)(Microsoft.VisualBasic.Strings.Len(text6) - 7) / 2.0);
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
    }

    private string SaveBMS()
    {
        CalculateGreatestVPosition();
        SortByVPositionInsertion();
        UpdatePairing();
        bool hasOverlapping = false;
        checked
        {
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
            Note[] xprevNotes = new Note[0];
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
                    xprevNotes = new Note[0];
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
    }

    private string GenerateHeaderMeta()
    {
        string text = "\r\n*---------------------- HEADER FIELD\r\n\r\n";
        text = text + "#PLAYER " + Conversions.ToString(checked(CHPlayer.SelectedIndex + 1)) + "\r\n";
        text = text + "#GENRE " + THGenre.Text + "\r\n";
        text = text + "#TITLE " + THTitle.Text + "\r\n";
        text = text + "#ARTIST " + THArtist.Text + "\r\n";
        text = text + "#BPM " + Functions.WriteDecimalWithDot((double)Notes[0].Value / 10000.0) + "\r\n";
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
        text = ((CHLnObj.SelectedIndex <= 0) ? (text + "#LNTYPE 1\r\n") : (text + "#LNOBJ " + Functions.C10to36(CHLnObj.SelectedIndex) + "\r\n"));
        return text + "\r\n";
    }

    private string GenerateHeaderIndexedData()
    {
        string text = "";
        int num = Information.UBound(hWAV);
        checked
        {
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
                text = Conversions.ToString(Operators.ConcatenateObject(text, Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("#BPM", Interaction.IIf(BPMx1296, Functions.C10to36(j), Microsoft.VisualBasic.Strings.Mid("0" + Conversion.Hex(j), Microsoft.VisualBasic.Strings.Len(Conversion.Hex(j))))), " "), Functions.WriteDecimalWithDot((double)hBPM[j] / 10000.0)), "\r\n")));
            }
            int num3 = Information.UBound(hSTOP);
            for (int k = 1; k <= num3; k++)
            {
                text = Conversions.ToString(Operators.ConcatenateObject(text, Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("#STOP", Interaction.IIf(STOPx1296, Functions.C10to36(k), Microsoft.VisualBasic.Strings.Mid("0" + Conversion.Hex(k), Microsoft.VisualBasic.Strings.Len(Conversion.Hex(k))))), " "), Functions.WriteDecimalWithDot((double)hSTOP[k] / 10000.0)), "\r\n")));
            }
            int num4 = Information.UBound(hSCROLL);
            for (int l = 1; l <= num4; l++)
            {
                text = text + "#SCROLL" + Functions.C10to36(l) + " " + Functions.WriteDecimalWithDot((double)hSCROLL[l] / 10000.0) + "\r\n";
            }
            return text;
        }
    }

    private void GetMeasureLimits(int MeasureIndex, ref int LowerLimit, ref int UpperLimit)
    {
        int num = Information.UBound(Notes);
        LowerLimit = 0;
        checked
        {
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
    }

    private string GenerateKeyTracks(int MeasureIndex, ref bool hasOverlapping, Note[] NotesInMeasure, ref Note[] xprevNotes)
    {
        string text = "";
        checked
        {
            object CounterResult3 = default(object);
            object LoopForResult3 = default(object);
            object CounterResult2 = default(object);
            object LoopForResult2 = default(object);
            object CounterResult = default(object);
            object LoopForResult = default(object);
            foreach (string text2 in BMSChannelList)
            {
                object[] array = new object[0];
                object[] array2 = new object[0];
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
                            array2[Information.UBound(array2)] = unchecked(Microsoft.VisualBasic.Strings.Mid("0" + Conversion.Hex(note.Value / 10000), Microsoft.VisualBasic.Strings.Len(Conversion.Hex(note.Value / 10000))));
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
                            array2[Information.UBound(array2)] = Functions.C10to36(unchecked(note.Value / 10000));
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
    }

    private string GenerateBackgroundTracks(int MeasureIndex, ref bool hasOverlapping, Note[] NotesInMeasure, int GreatestColumn, ref Note[] xprevNotes)
    {
        string text = "";
        checked
        {
            for (int i = 27; i <= GreatestColumn; i++)
            {
                double[] array = new double[0];
                string[] array2 = new string[0];
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
                        array2[Information.UBound(array2)] = Functions.C10to36(unchecked(NotesInMeasure[j].Value / 10000));
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
    }

    private bool OpenSM(string xStrAll)
    {
        KMouseOver = -1;
        string[] array = Microsoft.VisualBasic.Strings.Split(xStrAll, "\r\n");
        int num = Information.UBound(array);
        checked
        {
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
            string[] array3 = new string[0];
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
                                notes3[num17].VPosition = unchecked(checked(unchecked(192 / (Microsoft.VisualBasic.Strings.Len(array8[num14]) / 4)) * num16) / 4) + num14 * 192;
                                notes3[num17].Value = 10000L;
                            }
                            if (Operators.CompareString(Conversions.ToString(array8[num14][num16 + 1]), "0", TextCompare: false) != 0)
                            {
                                Notes = (Note[])Utils.CopyArray(Notes, new Note[Notes.Length + 1]);
                                Note[] notes4 = Notes;
                                int num18 = Information.UBound(Notes);
                                notes4[num18].ColumnIndex = 6;
                                notes4[num18].LongNote = (Operators.CompareString(Conversions.ToString(array8[num14][num16 + 1]), "2", TextCompare: false) == 0) | (Operators.CompareString(Conversions.ToString(array8[num14][num16 + 1]), "3", TextCompare: false) == 0);
                                notes4[num18].VPosition = unchecked(checked(unchecked(192 / (Microsoft.VisualBasic.Strings.Len(array8[num14]) / 4)) * num16) / 4) + num14 * 192;
                                notes4[num18].Value = 10000L;
                            }
                            if (Operators.CompareString(Conversions.ToString(array8[num14][num16 + 2]), "0", TextCompare: false) != 0)
                            {
                                Notes = (Note[])Utils.CopyArray(Notes, new Note[Notes.Length + 1]);
                                Note[] notes5 = Notes;
                                int num19 = Information.UBound(Notes);
                                notes5[num19].ColumnIndex = 7;
                                notes5[num19].LongNote = (Operators.CompareString(Conversions.ToString(array8[num14][num16 + 2]), "2", TextCompare: false) == 0) | (Operators.CompareString(Conversions.ToString(array8[num14][num16 + 2]), "3", TextCompare: false) == 0);
                                notes5[num19].VPosition = unchecked(checked(unchecked(192 / (Microsoft.VisualBasic.Strings.Len(array8[num14]) / 4)) * num16) / 4) + num14 * 192;
                                notes5[num19].Value = 10000L;
                            }
                            if (Operators.CompareString(Conversions.ToString(array8[num14][num16 + 3]), "0", TextCompare: false) != 0)
                            {
                                Notes = (Note[])Utils.CopyArray(Notes, new Note[Notes.Length + 1]);
                                Note[] notes6 = Notes;
                                int num20 = Information.UBound(Notes);
                                notes6[num20].ColumnIndex = 8;
                                notes6[num20].LongNote = (Operators.CompareString(Conversions.ToString(array8[num14][num16 + 3]), "2", TextCompare: false) == 0) | (Operators.CompareString(Conversions.ToString(array8[num14][num16 + 3]), "3", TextCompare: false) == 0);
                                notes6[num20].VPosition = unchecked(checked(unchecked(192 / (Microsoft.VisualBasic.Strings.Len(array8[num14]) / 4)) * num16) / 4) + num14 * 192;
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
            THBPM.Value = new decimal((double)Notes[0].Value / 10000.0);
            SortByVPositionQuick(0, Information.UBound(Notes));
            UpdatePairing();
            CalculateTotalPlayableNotes();
            CalculateGreatestVPosition();
            RefreshPanelAll();
            POStatusRefresh();
            return false;
        }
    }

    private void OpeniBMSC(string Path)
    {
        KMouseOver = -1;
        BinaryReader br = new BinaryReader(new FileStream(Path, FileMode.Open, FileAccess.Read), Encoding.Unicode);
        checked
        {
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
                                    LBeat.Items[num21] = Operators.ConcatenateObject(string.Concat(Functions.Add3Zeros(num21) + ": ", Conversions.ToString(num22)), Interaction.IIf(denominator > 10000, "", " ( " + Conversions.ToString((long)Math.Round(num22 * (double)denominator)) + " / " + Conversions.ToString(denominator) + " ) "));
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
            THBPM.Value = new decimal((double)Notes[0].Value / 10000.0);
            SortByVPositionQuick(0, Information.UBound(Notes));
            UpdatePairing();
            UpdateMeasureBottom();
            CalculateTotalPlayableNotes();
            CalculateGreatestVPosition();
            RefreshPanelAll();
            POStatusRefresh();
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    private void SaveiBMSC(string Path)
    {
        CalculateGreatestVPosition();
        SortByVPositionInsertion();
        UpdatePairing();
        checked
        {
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
    }

    private string GetBMSChannelBy(Note note)
    {
        int columnIndex = note.ColumnIndex;
        long value = note.Value;
        bool longNote = note.LongNote;
        bool hidden = note.Hidden;
        int num = GetColumn(columnIndex).Identifier;
        bool landmine = note.Landmine;
        if (columnIndex == 2 && ((double)value / 10000.0 != (double)(value / 10000) || value >= 2560000 || value < 0))
        {
            num = checked(num + 5);
        }
        if (columnIndex == 1)
        {
            return "SC";
        }
        if (columnIndex >= 5 && columnIndex <= 12)
        {
            checked
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
        }
        if (columnIndex >= 14 && columnIndex <= 21)
        {
            checked
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
        }
        return Functions.Add2Zeros(num);
    }

    private int nLeft(int iCol)
    {
        if (iCol < 27)
        {
            return column[iCol].Left;
        }
        return checked(column[27].Left + (iCol - 27) * column[27].Width);
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
        return column[27].Title + checked(iCol - 27 + 1);
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
        checked
        {
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
            int v3 = checked((int)Math.Round(Font.Size));
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
        checked
        {
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
        checked
        {
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
    }

    private void LoadThemeComptability(string xPath)
    {
        checked
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
    }

    private string[] LoadThemeComptability_SplitStringInto26Parts(string xLine)
    {
        string[] array = Microsoft.VisualBasic.Strings.Split(xLine, ",");
        return (string[])Utils.CopyArray(array, new string[27]);
    }

    private void LoadLang(object sender, EventArgs e)
    {
        string path = Conversions.ToString(NewLateBinding.LateGet(sender, null, "ToolTipText", new object[0], null, null, null));
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
            cmnLanguage.Items[checked(cmnLanguage.Items.Count - 1)].ToolTipText = xStr.FullName;
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
        LoadSettings(Conversions.ToString(Operators.ConcatenateObject(MyProject.Application.Info.DirectoryPath + "\\Data\\", NewLateBinding.LateGet(sender, null, "Text", new object[0], null, null, null))));
        RefreshPanelAll();
    }

    private void NewRecent(string xFileName)
    {
        bool flag = false;
        int num = 0;
        checked
        {
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
        SelectedNotes = new Note[0];
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
        checked
        {
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
                                LBeat.Items[num12] = Operators.ConcatenateObject(string.Concat(Functions.Add3Zeros(num12) + ": ", Conversions.ToString(changeMeasureLength.Value / 192.0)), Interaction.IIf(denominator > 10000, "", " ( " + Conversions.ToString((long)Math.Round(changeMeasureLength.Value / 192.0 * (double)denominator)) + " / " + Conversions.ToString(denominator) + " ) "));
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
                                    Notes[j].Selected = ((Notes[j].VPosition >= num4 && Notes[j].VPosition < num5 && nEnabled(Notes[j].ColumnIndex)) ? true : false);
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
            THBPM.Value = new decimal((double)Notes[0].Value / 10000.0);
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
        for (int i = 0; i <= num; i = checked(i + 1))
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
        for (int i = 1; i <= num; i = checked(i + 1))
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
        for (int i = 1; i <= num; i = checked(i + 1))
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
        for (int i = 0; i <= num; i = checked(i + 1))
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
        for (int i = 1; i <= num; i = checked(i + 1))
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
        for (int i = 1; i <= num; i = checked(i + 1))
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
        checked
        {
            int[] array = new int[LBeat.SelectedIndices.Count - 1 + 1];
            LBeat.SelectedIndices.CopyTo(array, 0);
            if (array.Length == 0)
            {
                return;
            }
            double[] array2 = new double[0];
            UndoRedo.ChangeMeasureLength[] array3 = new UndoRedo.ChangeMeasureLength[0];
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
        DDFileName = new string[0];
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
        SelectedNotes = new Note[0];
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
        vSelK = new Note[0];
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
        pTempFileNames = new string[0];
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
        spMain = new Panel[0];
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

    private int HorizontalPositiontoDisplay(int xHPosition, long xHSVal)
    {
        return checked((int)Math.Round((float)xHPosition * gxWidth - (float)xHSVal * gxWidth));
    }

    private int NoteRowToPanelHeight(double xVPosition, long xVSVal, int xTHeight)
    {
        return checked(xTHeight - (int)Math.Round((xVPosition + (double)xVSVal) * (double)gxHeight) - 1);
    }

    public int MeasureAtDisplacement(double xVPos)
    {
        int num = 1;
        checked
        {
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
    }

    private double GetMaxVPosition()
    {
        return MeasureUpper(999);
    }

    private double SnapToGrid(double xVPos)
    {
        double num = MeasureBottom[MeasureAtDisplacement(xVPos)];
        double num2 = 192.0 / (double)gDivide;
        return Math.Floor((xVPos - num) / num2) * num2 + num;
    }

    private void CalculateGreatestVPosition()
    {
        GreatestVPosition = 0.0;
        checked
        {
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
    }

    private void SortByVPositionInsertion()
    {
        if (Information.UBound(Notes) <= 0)
        {
            return;
        }
        int num = Information.UBound(Notes);
        checked
        {
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
    }

    private void SortByVPositionQuick(int xMin, int xMax)
    {
        if (xMin >= xMax)
        {
            return;
        }
        checked
        {
            int num = (int)Math.Round((double)(xMax - xMin) / 2.0) + xMin;
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
    }

    private void SortByVPositionQuick3(int xMin, int xMax)
    {
        int num = xMin;
        int num2 = xMax;
        checked
        {
            int num3 = xMax - xMin + 1;
            int num4 = (int)Math.Round(Conversion.Int((float)num3 * VBMath.Rnd())) + xMin;
            int num5 = (int)Math.Round(Conversion.Int((float)num3 * VBMath.Rnd())) + xMin;
            int num6 = (int)Math.Round(Conversion.Int((float)num3 * VBMath.Rnd())) + xMin;
            num3 = (((Notes[num4].VPosition <= Notes[num5].VPosition) & (Notes[num5].VPosition <= Notes[num6].VPosition)) ? num5 : ((!((Notes[num5].VPosition <= Notes[num4].VPosition) & (Notes[num4].VPosition <= Notes[num6].VPosition))) ? num6 : num4));
            Note note = Notes[num3];
            while (true)
            {
                if (unchecked(Notes[num].VPosition < note.VPosition && num < xMax))
                {
                    num++;
                    continue;
                }
                while (unchecked(note.VPosition < Notes[num2].VPosition && num2 > xMin))
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
    }

    private void UpdateMeasureBottom()
    {
        MeasureBottom[0] = 0.0;
        int num = 0;
        checked
        {
            do
            {
                MeasureBottom[num + 1] = MeasureBottom[num] + MeasureLength[num];
                num++;
            }
            while (num <= 998);
        }
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
        checked
        {
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
    }

    private void RemoveNote(int I, bool SortAndUpdatePairing = true)
    {
        KMouseOver = -1;
        checked
        {
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
    }

    private void AddNotesFromClipboard(bool xSelected = true, bool SortAndUpdatePairing = true)
    {
        string[] array = Microsoft.VisualBasic.Strings.Split(Clipboard.GetText(), "\r\n");
        int num = Information.UBound(Notes);
        checked
        {
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
                        if (unchecked(Information.UBound(array2) == 5 && num4 >= 0.0) & (num4 < GetMaxVPosition()))
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
                        if (unchecked(Information.UBound(array3) == 5 && num4 >= 0.0) & (num4 < GetMaxVPosition()))
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
    }

    private void CopyNotes(bool Unselect = true)
    {
        string text = Conversions.ToString(Operators.ConcatenateObject("iBMSC Clipboard Data", Interaction.IIf(NTInput, " xNT", "")));
        double num = 999.0;
        int num2 = Information.UBound(Notes);
        checked
        {
            for (int i = 1; i <= num2; i++)
            {
                if (Notes[i].Selected & ((double)MeasureAtDisplacement(Notes[i].VPosition) < num))
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
    }

    private void RemoveNotes(bool SortAndUpdatePairing = true)
    {
        if (Information.UBound(Notes) == 0)
        {
            return;
        }
        KMouseOver = -1;
        int num = 1;
        checked
        {
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
    }

    private int EnabledColumnIndexToColumnArrayIndex(int cEnabled)
    {
        checked
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
    }

    private int ColumnArrayIndexToEnabledColumnIndex(int cReal)
    {
        checked
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
        string[] array = new string[0];
        int num = Information.UBound(xFile);
        checked
        {
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
            MeasureBottom[num] = (double)num * 192.0;
            LBeat.Items.Add(Functions.Add3Zeros(num) + ": 1 ( 4 / 4 )");
            num = checked(num + 1);
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
        DDFileName = new string[0];
        RefreshPanelAll();
    }

    private void Form1_DragDrop(object sender, DragEventArgs e)
    {
        DDFileName = new string[0];
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
        int lErl = default(int);
        try
        {
            string text = Functions.RandomFileName(".cur");
            MyProject.Computer.FileSystem.WriteAllBytes(text, Resources.CursorResizeDown, append: false);
            Cursor cursor = ActuallyLoadCursor(text);
            MyProject.Computer.FileSystem.WriteAllBytes(text, Resources.CursorResizeLeft, append: false);
            Cursor cursor2 = ActuallyLoadCursor(text);
            MyProject.Computer.FileSystem.WriteAllBytes(text, Resources.CursorResizeRight, append: false);
            Cursor cursor3 = ActuallyLoadCursor(text);
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
            Exception ex2 = ex;
            ProjectData.ClearProjectError();
        }
        spMain = new Panel[3] { PMainInL, PMainIn, PMainInR };
        sUndo[0] = new UndoRedo.NoOperation();
        sUndo[1] = new UndoRedo.NoOperation();
        sRedo[0] = new UndoRedo.NoOperation();
        sRedo[1] = new UndoRedo.NoOperation();
        sI = 0;
        LWAV.Items.Clear();
        int num = 1;
        checked
        {
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
            string[] commandLineArgs = Environment.GetCommandLineArgs();
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
                FileInfo[] files = MyProject.Computer.FileSystem.GetDirectoryInfo(MyProject.Application.Info.DirectoryPath).GetFiles("AutoSave_*.IBMSC");
                if (files != null && files.Length != 0)
                {
                    if (Interaction.MsgBox(Microsoft.VisualBasic.Strings.Replace(Strings.Messages.RestoreAutosavedFile, "{}", Conversions.ToString(files.Length)), MsgBoxStyle.YesNo | MsgBoxStyle.MsgBoxSetForeground) == MsgBoxResult.Yes)
                    {
                        foreach (FileInfo fileInfo in files)
                        {
                            Process.Start(Application.ExecutablePath, "\"" + fileInfo.FullName + "\"");
                        }
                    }

                    foreach (FileInfo fileInfo2 in files)
                    {
                        pTempFileNames = (string[])Utils.CopyArray(pTempFileNames, new string[Information.UBound(pTempFileNames) + 1 + 1]);
                        pTempFileNames[Information.UBound(pTempFileNames)] = fileInfo2.FullName;
                    }
                }
            }
            goto IL_03ba;
        }
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
        checked
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
                    if (unchecked(Notes[i].Value / 10000) != LnObj || IsColumnNumeric(Notes[i].ColumnIndex))
                    {
                        continue;
                    }
                    for (j = i - 1; j >= 1; j += -1)
                    {
                        if (Notes[j].ColumnIndex == Notes[i].ColumnIndex && !Notes[j].Hidden)
                        {
                            if (Notes[j].Length != 0.0 || unchecked(Notes[j].Value / 10000) == LnObj)
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
                                    if (!Notes[j].LongNote && unchecked(Notes[j].Value / 10000) != LnObj)
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
                    if ((unchecked(Notes[i].Value / 10000) == LnObj) & !IsColumnNumeric(Notes[i].ColumnIndex))
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
                                if (unchecked(Notes[j].Value / 10000) == LnObj)
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
            double num12 = (double)Notes[0].Value / 10000.0;
            double num13 = 0.0;
            int num14 = Information.UBound(Notes);
            for (int i = 1; i <= num14; i++)
            {
                if (Notes[i].ColumnIndex == 2)
                {
                    num11 += (Notes[i].VPosition - num13) / num12 * 1250.0;
                    num12 = (double)Notes[i].Value / 10000.0;
                    num13 = Notes[i].VPosition;
                }
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
        SelectedNotes = new Note[0];
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
                num2 = checked(num2 + 1);
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
        SelectedNotes = new Note[0];
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
        SelectedNotes = new Note[0];
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
        SelectedNotes = new Note[0];
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
        SelectedNotes = new Note[0];
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
        SelectedNotes = new Note[0];
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
        SelectedNotes = new Note[0];
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
        SelectedNotes = new Note[0];
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
        PanelFocus = Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null));
        spMain[PanelFocus].Focus();
    }

    private void VSValueChanged(object sender, EventArgs e)
    {
        int num = Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null));
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
            LastMouseDownLocation.Y = Conversions.ToSingle(Operators.AddObject(LastMouseDownLocation.Y, Operators.MultiplyObject(Operators.SubtractObject(VSValue, NewLateBinding.LateGet(sender, null, "Value", new object[0], null, null, null)), gxHeight)));
        }
        PanelVScroll[num] = Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "Value", new object[0], null, null, null));
        if (spLock[checked(num + 1) % 3])
        {
            int num3 = checked(PanelVScroll[num] + spDiff[num]);
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
        if (spLock[checked(num + 2) % 3])
        {
            checked
            {
                int num4 = PanelVScroll[num] - spDiff[unchecked(checked(num + 2) % 3)];
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
        }
        checked
        {
            spDiff[num] = PanelVScroll[unchecked(checked(num + 1) % 3)] - PanelVScroll[num];
            spDiff[unchecked(checked(num + 2) % 3)] = PanelVScroll[num] - PanelVScroll[unchecked(checked(num + 2) % 3)];
            VSValue = Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "Value", new object[0], null, null, null));
            RefreshPanel(num, spMain[num].DisplayRectangle);
        }
    }

    private void cVSLock_CheckedChanged(object sender, EventArgs e)
    {
        int num = Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null));
        spLock[num] = Conversions.ToBoolean(NewLateBinding.LateGet(sender, null, "Checked", new object[0], null, null, null));
        checked
        {
            if (spLock[num])
            {
                spDiff[num] = PanelVScroll[unchecked(checked(num + 1) % 3)] - PanelVScroll[num];
                spDiff[unchecked(checked(num + 2) % 3)] = PanelVScroll[num] - PanelVScroll[unchecked(checked(num + 2) % 3)];
            }
        }
    }

    private void HSGotFocus(object sender, EventArgs e)
    {
        PanelFocus = Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null));
        spMain[PanelFocus].Focus();
    }

    private void HSValueChanged(object sender, EventArgs e)
    {
        int num = Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null));
        PointF lastMouseDownLocation = LastMouseDownLocation;
        Point point = new Point(-1, -1);
        if (!(lastMouseDownLocation == point) & (HSValue != -1))
        {
            LastMouseDownLocation.X = Conversions.ToSingle(Operators.AddObject(LastMouseDownLocation.X, Operators.MultiplyObject(Operators.SubtractObject(HSValue, NewLateBinding.LateGet(sender, null, "Value", new object[0], null, null, null)), gxWidth)));
        }
        PanelHScroll[num] = Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "Value", new object[0], null, null, null));
        HSValue = Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "Value", new object[0], null, null, null));
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
        vSelStart = MeasureBottom[checked(MeasureAtDisplacement(-PanelVScroll[PanelFocus]) + 1)];
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
        vSelStart = MeasureBottom[checked(MeasureAtDisplacement(-PanelVScroll[PanelFocus]) + 1)];
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
        for (int i = 0; i <= num; i = checked(i + 1))
        {
            Notes[i].Selected = false;
        }
        RefreshPanelAll();
        POStatusRefresh();
    }

    private void CGHeight_ValueChanged(object sender, EventArgs e)
    {
        gxHeight = Convert.ToSingle(CGHeight.Value);
        CGHeight2.Value = Conversions.ToInteger(Interaction.IIf(decimal.Compare(decimal.Multiply(CGHeight.Value, 4m), CGHeight2.Maximum)) < 0, decimal.Multiply(CGHeight.Value, new decimal(4m), CGHeight2.Maximum));
        RefreshPanelAll();
    }

    private void CGHeight2_Scroll(object sender, EventArgs e)
    {
        CGHeight.Value = new decimal((double)CGHeight2.Value / 4.0);
    }

    private void CGWidth_ValueChanged(object sender, EventArgs e)
    {
        gxWidth = Convert.ToSingle(CGWidth.Value);
        CGWidth2.Value = Conversions.ToInteger(Interaction.IIf(decimal.Compare(decimal.Multiply(CGWidth.Value, 4m), CGWidth2.Maximum)) < 0, decimal.Multiply(CGWidth.Value, new decimal(4m), CGWidth2.Maximum));
        checked
        {
            HS.LargeChange = (int)Math.Round((float)PMainIn.Width / gxWidth);
            if (HS.Value > HS.Maximum - HS.LargeChange + 1)
            {
                HS.Value = HS.Maximum - HS.LargeChange + 1;
            }
            HSL.LargeChange = (int)Math.Round((float)PMainInL.Width / gxWidth);
            if (HSL.Value > HSL.Maximum - HSL.LargeChange + 1)
            {
                HSL.Value = HSL.Maximum - HSL.LargeChange + 1;
            }
            HSR.LargeChange = (int)Math.Round((float)PMainInR.Width / gxWidth);
            if (HSR.Value > HSR.Maximum - HSR.LargeChange + 1)
            {
                HSR.Value = HSR.Maximum - HSR.LargeChange + 1;
            }
            RefreshPanelAll();
        }
    }

    private void CGWidth2_Scroll(object sender, EventArgs e)
    {
        CGWidth.Value = new decimal((double)CGWidth2.Value / 4.0);
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
        int num = checked((int)Math.Round(Conversion.Val(Interaction.InputBox(Strings.Messages.PromptSlashValue, "", Conversions.ToString(gSlash)))));
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
        checked
        {
            switch (PanelFocus)
            {
                case 0:
                    {
                        VScrollBar leftPanelScroll = LeftPanelScroll;
                        int num = (int)Math.Round((double)leftPanelScroll.Value + (double)tempY / 5.0 / (double)gxHeight);
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
                        num = (int)Math.Round((double)hSL.Value + (double)tempX / 10.0 / (double)gxWidth);
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
                        int num = (int)Math.Round((double)mainPanelScroll.Value + (double)tempY / 5.0 / (double)gxHeight);
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
                        num = (int)Math.Round((double)hS.Value + (double)tempX / 10.0 / (double)gxWidth);
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
                        int num = (int)Math.Round((double)rightPanelScroll.Value + (double)tempY / 5.0 / (double)gxHeight);
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
                        num = (int)Math.Round((double)hSR.Value + (double)tempX / 10.0 / (double)gxWidth);
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
    }

    private void TimerMiddle_Tick(object sender, EventArgs e)
    {
        if (!MiddleButtonClicked)
        {
            TimerMiddle.Enabled = false;
            return;
        }
        checked
        {
            switch (PanelFocus)
            {
                case 0:
                    {
                        VScrollBar leftPanelScroll = LeftPanelScroll;
                        int num = (int)Math.Round((double)leftPanelScroll.Value + (double)(Cursor.Position.Y - MiddleButtonLocation.Y) / 5.0 / (double)gxHeight);
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
                        num = (int)Math.Round((double)hSL.Value + (double)(Cursor.Position.X - MiddleButtonLocation.X) / 5.0 / (double)gxWidth);
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
                        int num = (int)Math.Round((double)mainPanelScroll.Value + (double)(Cursor.Position.Y - MiddleButtonLocation.Y) / 5.0 / (double)gxHeight);
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
                        num = (int)Math.Round((double)hS.Value + (double)(Cursor.Position.X - MiddleButtonLocation.X) / 5.0 / (double)gxWidth);
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
                        int num = (int)Math.Round((double)rightPanelScroll.Value + (double)(Cursor.Position.Y - MiddleButtonLocation.Y) / 5.0 / (double)gxHeight);
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
                        num = (int)Math.Round((double)hSR.Value + (double)(Cursor.Position.X - MiddleButtonLocation.X) / 5.0 / (double)gxWidth);
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
    }

    private void ValidateWavListView()
    {
        try
        {
            Rectangle itemRectangle = LWAV.GetItemRectangle(LWAV.SelectedIndex);
            if (checked(itemRectangle.Top + itemRectangle.Height) > LWAV.DisplayRectangle.Height)
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
        checked
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
    }

    private void LWAV_DoubleClick(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.DefaultExt = "wav";
        openFileDialog.Filter = Strings.FileType._wave + "|*.wav;*.ogg;*.mp3|" + Strings.FileType.WAV + "|*.wav|" + Strings.FileType.OGG + "|*.ogg|" + Strings.FileType.MP3 + "|*.mp3|" + Strings.FileType._all + "|*.*";
        openFileDialog.InitialDirectory = Conversions.ToString(Interaction.IIf(Operators.CompareString(ExcludeFileName(FileName), "", TextCompare: false) == 0, InitPath, ExcludeFileName(FileName)));
        checked
        {
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
    }

    private void LWAV_KeyDown(object sender, KeyEventArgs e)
    {
        Keys keyCode = e.KeyCode;
        checked
        {
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
    }

    private void TBErrorCheck_Click(object sender, EventArgs e)
    {
        ErrorCheck = Conversions.ToBoolean(NewLateBinding.LateGet(sender, null, "Checked", new object[0], null, null, null));
        TBErrorCheck.Checked = ErrorCheck;
        mnErrorCheck.Checked = ErrorCheck;
        TBErrorCheck.Image = (Image)Interaction.IIf(TBErrorCheck.Checked, Resources.x16CheckError, Resources.x16CheckErrorN);
        mnErrorCheck.Image = (Image)Interaction.IIf(TBErrorCheck.Checked, Resources.x16CheckError, Resources.x16CheckErrorN);
        RefreshPanelAll();
    }

    private void TBPreviewOnClick_Click(object sender, EventArgs e)
    {
        PreviewNote("", bStop: true);
        PreviewOnClick = Conversions.ToBoolean(NewLateBinding.LateGet(sender, null, "Checked", new object[0], null, null, null));
        TBPreviewOnClick.Checked = PreviewOnClick;
        mnPreviewOnClick.Checked = PreviewOnClick;
        TBPreviewOnClick.Image = (Image)Interaction.IIf(PreviewOnClick, Resources.x16PreviewOnClick, Resources.x16PreviewOnClickN);
        mnPreviewOnClick.Image = (Image)Interaction.IIf(PreviewOnClick, Resources.x16PreviewOnClick, Resources.x16PreviewOnClickN);
    }

    private void TBShowFileName_Click(object sender, EventArgs e)
    {
        ShowFileName = Conversions.ToBoolean(NewLateBinding.LateGet(sender, null, "Checked", new object[0], null, null, null));
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
            pTempFileNames = (string[])Utils.CopyArray(pTempFileNames, new string[checked(Information.UBound(pTempFileNames) + 1 + 1)]);
            pTempFileNames[Information.UBound(pTempFileNames)] = s;
        }
    }

    private void TBStatistics_Click(object sender, EventArgs e)
    {
        SortByVPositionInsertion();
        UpdatePairing();
        int[,] array = new int[7, 6];
        int num = Information.UBound(Notes);
        checked
        {
            for (int i = 1; i <= num; i++)
            {
                Note[] notes = Notes;
                int num3 = -1;
                int columnIndex = notes[i].ColumnIndex;
                num3 = ((columnIndex != 1) ? ((columnIndex == 2) ? 1 : ((columnIndex == 3) ? 2 : ((columnIndex != 5 && columnIndex != 6 && columnIndex != 7 && columnIndex != 8 && columnIndex != 9 && columnIndex != 10 && columnIndex != 11 && columnIndex != 12) ? ((columnIndex == 14 || columnIndex == 15 || columnIndex == 16 || columnIndex == 17 || columnIndex == 18 || columnIndex == 19 || columnIndex == 20 || columnIndex == 21) ? 4 : ((columnIndex < 27) ? 6 : 5)) : 3))) : 0);
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
                        if (unchecked(notes[i].Value / 10000) == LnObj)
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
                        if (unchecked(notes[i].Value / 10000) == LnObj)
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
    }

    private void CalculateTotalPlayableNotes()
    {
        int num = 0;
        checked
        {
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
    }

    public object GetMouseVPosition(bool snap = true)
    {
        int num = spMain[PanelFocus].Height;
        int num2 = PanelVScroll[PanelFocus];
        float num3 = ((float)num - (float)num2 * gxHeight - (float)MouseMoveStatus.Y - 1f) / gxHeight;
        if (snap)
        {
            return SnapToGrid(num3);
        }
        return num3;
    }

    private void POStatusRefresh()
    {
        checked
        {
            if (TBSelect.Checked)
            {
                int kMouseOver = KMouseOver;
                if (kMouseOver < 0)
                {
                    TempVPosition = Conversions.ToDouble(GetMouseVPosition(gSnap));
                    SelectedColumn = GetColumnAtX(MouseMoveStatus.X, PanelHScroll[PanelFocus]);
                    int num = MeasureAtDisplacement(TempVPosition);
                    double num2 = MeasureLength[num];
                    double num3 = TempVPosition - MeasureBottom[num];
                    double num4 = GCD(Conversions.ToDouble(Interaction.IIf(num3 == 0.0, num2, num3)), num2);
                    FSP1.Text = num3 * (double)gDivide / 192.0 + " / " + num2 * (double)gDivide / 192.0 + "  ";
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
                    int num5 = MeasureAtDisplacement(Notes[kMouseOver].VPosition);
                    double num6 = MeasureLength[num5];
                    double num7 = Notes[kMouseOver].VPosition - MeasureBottom[num5];
                    double num8 = GCD(Conversions.ToDouble(Interaction.IIf(num7 == 0.0, num6, num7)), num6);
                    FSP1.Text = num7 * (double)gDivide / 192.0 + " / " + num6 * (double)gDivide / 192.0 + "  ";
                    FSP2.Text = num7 + " / " + Conversions.ToString(num6) + "  ";
                    FSP3.Text = (int)Math.Round(num7 / num8) + " / " + (int)Math.Round(num6 / num8) + "  ";
                    FSP4.Text = Notes[kMouseOver].VPosition + "  ";
                    TimeStatusLabel.Text = GetTimeFromVPosition(TempVPosition).ToString("F4");
                    FSC.Text = nTitle(Notes[kMouseOver].ColumnIndex);
                    FSW.Text = Conversions.ToString(Interaction.IIf(IsColumnNumeric(Notes[kMouseOver].ColumnIndex), (double)Notes[kMouseOver].Value / 10000.0, Functions.C10to36(unchecked(Notes[kMouseOver].Value / 10000))));
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
                int num9 = MeasureAtDisplacement(TempVPosition);
                double num10 = MeasureLength[num9];
                double num11 = TempVPosition - MeasureBottom[num9];
                double num12 = GCD(Conversions.ToDouble(Interaction.IIf(num11 == 0.0, num10, num11)), num10);
                FSP1.Text = num11 * (double)gDivide / 192.0 + " / " + num10 * (double)gDivide / 192.0 + "  ";
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
        checked
        {
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
                double current_bps = 60.0 / ((double)current_note.Value / 10000.0);
                //bpm_contrib += current_bps * closure_0024__._0024VB_0024Local_duration / 48.0;
                bpm_contrib += current_bps * duration / 48d;
                if (stop_notes != null)
                {
                    var stops = from stp in stop_notes
                        where stp.VPosition >= notevpos & stp.VPosition < notevpos + duration
                        select stp;
                    //IEnumerable<Note> stops = enumerable.Where(closure_0024__._Lambda_0024__8);
                    double stop_beats = stops.Sum([SpecialName] (Note x) => (double)x.Value / 10000.0) / 48.0;
                    stop_contrib += current_bps * stop_beats;
                }
            }
            return stop_contrib + bpm_contrib;
        }
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
        for (int i = 1; i <= num2; i = checked(i + 1))
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
                TVCBPM.Text = Conversions.ToString((double)Notes[0].Value / 10000.0);
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
            TVCBPM.Text = Conversions.ToString((double)Notes[0].Value / 10000.0);
            TVCBPM.Focus();
            TVCBPM.SelectAll();
        }
    }

    private int FindNoteIndex(Note note)
    {
        checked
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
    }

    private int sIA()
    {
        return Conversions.ToInteger(Interaction.IIf(sI > 98, 0, checked(sI + 1)));
    }

    private int sIM()
    {
        return Conversions.ToInteger(Interaction.IIf(sI < 1, 99, checked(sI - 1)));
    }

    private void TBUndo_Click(object sender, EventArgs e)
    {
        KMouseOver = -1;
        SelectedNotes = new Note[0];
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
        SelectedNotes = new Note[0];
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
        checked
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
                for (array = (int[])Utils.CopyArray(array, new int[Information.UBound(xPath) + 1]); unchecked(i < array.Length && j <= 1294); i++)
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
    }

    private void POWAV_DragDrop(object sender, DragEventArgs e)
    {
        DDFileName = new string[0];
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
        DDFileName = new string[0];
        RefreshPanelAll();
    }

    private void POWAV_Resize(object sender, EventArgs e)
    {
        LWAV.Height = Conversions.ToInteger(Operators.SubtractObject(NewLateBinding.LateGet(sender, null, "Height", new object[0], null, null, null), 25));
    }

    private void POBeat_Resize(object sender, EventArgs e)
    {
        LBeat.Height = checked(POBeat.Height - 25);
    }

    private void POExpansion_Resize(object sender, EventArgs e)
    {
        TExpansion.Height = checked(POExpansion.Height - 2);
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
        if (!Conversions.ToBoolean(NewLateBinding.LateGet(sender, null, "Pressed", new object[0], null, null, null)))
        {
            NewLateBinding.LateSet(sender, null, "ForeColor", new object[1] { Color.Black }, null, null);
        }
    }

    private void mn_MouseLeave(object sender, EventArgs e)
    {
        if (!Conversions.ToBoolean(NewLateBinding.LateGet(sender, null, "Pressed", new object[0], null, null, null)))
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
        SelectedNotes = new Note[0];
        SortByVPositionInsertion();
        int num = Information.UBound(Notes);
        checked
        {
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
                    if (unchecked(Notes[num3].Value / 10000) == LnObj)
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
    }

    private void ConvertNT2BMSE()
    {
        SelectedNotes = new Note[0];
        Note[] array = new Note[1] { Notes[0] };
        int num = Information.UBound(Notes);
        checked
        {
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
    }

    private void TBWavIncrease_Click(object sender, EventArgs e)
    {
        UndoRedo.LinkedURCmd BaseUndo = null;
        UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
        UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
        TBWavIncrease.Checked = Conversions.ToBoolean(Operators.NotObject(NewLateBinding.LateGet(sender, null, "Checked", new object[0], null, null, null)));
        RedoWavIncrease(TBWavIncrease.Checked, ref BaseUndo, ref BaseRedo);
        AddUndo(BaseUndo, linkedURCmd.Next);
    }

    private void TBNTInput_Click(object sender, EventArgs e)
    {
        UndoRedo.LinkedURCmd BaseUndo = null;
        UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
        UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
        RedoRemoveNoteAll(xSel: false, ref BaseUndo, ref BaseRedo);
        NTInput = Conversions.ToBoolean(NewLateBinding.LateGet(sender, null, "Checked", new object[0], null, null, null));
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
        TWPosition2.Value = Conversions.ToInteger(Interaction.IIf(wPosition > (double)TWPosition2.Maximum, TWPosition2.Maximum, wPosition));
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
        vo.pBGMWav.Color = checked(Functions.HSL2RGB((int)Math.Round(color.GetHue()), Convert.ToInt32(TWSaturation.Value), (int)Math.Round(color.GetBrightness() * 1000f), color.A));
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
        checked
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
    }

    private void UpdateColumnsX()
    {
        column[0].Left = 0;
        int num = Information.UBound(column);
        checked
        {
            for (int i = 1; i <= num; i++)
            {
                column[i].Left = Conversions.ToInteger(Operators.AddObject(column[i - 1].Left, Interaction.IIf(column[i - 1].isVisible, column[i - 1].Width, 0)));
            }
            HSL.Maximum = nLeft(gColumns) + column[27].Width;
            HS.Maximum = nLeft(gColumns) + column[27].Width;
            HSR.Maximum = nLeft(gColumns) + column[27].Width;
        }
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
        for (int i = 1; i <= num; i = checked(i + 1))
        {
            Notes[i].Selected = Notes[i].Selected & nEnabled(Notes[i].ColumnIndex);
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
        }, xMsWheel: gWheel, xPgUpDn: gPgUpDn, xMiddleButton: MiddleButtonMoveMethod, xGridPartition: checked((int)Math.Round(192.0 / BMSGridLimit)), xAutoSave: AutoSaveInterval, xBeep: BeepWhileSaved, xBPMx: BPMx1296, xSTOPx: STOPx1296, xMFEnter: AutoFocusMouseEnter, xMFClick: FirstClickDisabled, xMStopPreview: ClickStopPreview);
        if (opGeneral.ShowDialog() == DialogResult.OK)
        {
            OpGeneral opGeneral2 = opGeneral;
            gWheel = opGeneral2.zWheel;
            gPgUpDn = opGeneral2.zPgUpDn;
            TextEncoding = opGeneral2.zEncoding;
            MiddleButtonMoveMethod = opGeneral2.zMiddle;
            AutoSaveInterval = opGeneral2.zAutoSave;
            BMSGridLimit = 192.0 / (double)opGeneral2.zGridPartition;
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
        for (int i = 1; i <= num; i = checked(i + 1))
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
        checked
        {
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
        for (int i = 1; i <= num; i = checked(i + 1))
        {
            if (Notes[i].Selected)
            {
                RedoLongNoteModify(Notes[i], Notes[i].VPosition, 0 - ((!Notes[i].LongNote) ? 1 : 0), ref BaseUndo, ref BaseRedo);
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
        for (int i = 1; i <= num; i = checked(i + 1))
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
        for (int i = 1; i <= num; i = checked(i + 1))
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
        for (int i = 1; i <= num; i = checked(i + 1))
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
        checked
        {
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
            if (!unchecked(flag || flag2))
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
                        checked
                        {
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
        return Conversions.ToBoolean((!Conversions.ToBoolean((xNote.VPosition >= MeasureBottom[fdriMesL]) & (xNote.VPosition < MeasureBottom[fdriMesU] + MeasureLength[fdriMesU])) || !Conversions.ToBoolean(Interaction.IIf(IsColumnNumeric(xNote.ColumnIndex), (xNote.Value >= fdriValL) & (xNote.Value <= fdriValU), (xNote.Value >= fdriLblL) & (xNote.Value <= fdriLblU))) || !Conversions.ToBoolean(Array.IndexOf(fdriCol, xNote.ColumnIndex) != -1)) ? ((object)false) : ((object)true));
    }

    private bool fdrRangeS(bool xbLim1, bool xbLim2, bool xVal)
    {
        return (!xbLim1 && xbLim2 && xVal) || (xbLim1 && !xbLim2 && !xVal) || (xbLim1 && xbLim2);
    }

    public void fdrSelect(int iRange, int xMesL, int xMesU, string xLblL, string xLblU, int xValL, int xValU, int[] iCol)
    {
        fdriMesL = xMesL;
        fdriMesU = xMesU;
        checked
        {
            fdriLblL = Functions.C36to10(xLblL) * 10000;
            fdriLblU = Functions.C36to10(xLblU) * 10000;
            fdriValL = xValL;
            fdriValU = xValU;
            fdriCol = iCol;
        }
        bool flag = iRange % 2 == 0;
        bool flag2 = iRange % 3 == 0;
        bool xbLim = iRange % 5 == 0;
        bool xbLim2 = iRange % 7 == 0;
        bool xbLim3 = iRange % 11 == 0;
        bool xbLim4 = iRange % 13 == 0;
        checked
        {
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
                if (((((flag & array[j]) | (flag2 & !array[j])) && nEnabled(Notes[j].ColumnIndex) && fdrRangeS(xbLim, xbLim2, Conversions.ToBoolean(Interaction.IIf(NTInput, Notes[j].Length, Notes[j].LongNote)))) ? true : false) & fdrRangeS(xbLim4, xbLim3, Notes[j].Hidden))
                {
                    Notes[j].Selected = fdrCheck(Notes[j]);
                }
            }
            RefreshPanelAll();
            Interaction.Beep();
        }
    }

    public void fdrUnselect(int iRange, int xMesL, int xMesU, string xLblL, string xLblU, int xValL, int xValU, int[] iCol)
    {
        fdriMesL = xMesL;
        fdriMesU = xMesU;
        checked
        {
            fdriLblL = Functions.C36to10(xLblL) * 10000;
            fdriLblU = Functions.C36to10(xLblU) * 10000;
            fdriValL = xValL;
            fdriValU = xValU;
            fdriCol = iCol;
        }
        bool flag = iRange % 2 == 0;
        bool flag2 = iRange % 3 == 0;
        bool xbLim = iRange % 5 == 0;
        bool xbLim2 = iRange % 7 == 0;
        bool xbLim3 = iRange % 11 == 0;
        bool xbLim4 = iRange % 13 == 0;
        checked
        {
            bool[] array = new bool[Information.UBound(Notes) + 1];
            int num = Information.UBound(Notes);
            for (int i = 1; i <= num; i++)
            {
                array[i] = Notes[i].Selected;
            }
            int num2 = Information.UBound(Notes);
            for (int j = 1; j <= num2; j++)
            {
                if (((((flag & array[j]) | (flag2 & !array[j])) && nEnabled(Notes[j].ColumnIndex) && fdrRangeS(xbLim, xbLim2, Conversions.ToBoolean(Interaction.IIf(NTInput, Notes[j].Length, Notes[j].LongNote)))) ? true : false) & fdrRangeS(xbLim4, xbLim3, Notes[j].Hidden))
                {
                    Notes[j].Selected = !fdrCheck(Notes[j]);
                }
            }
            RefreshPanelAll();
            Interaction.Beep();
        }
    }

    public void fdrDelete(int iRange, int xMesL, int xMesU, string xLblL, string xLblU, int xValL, int xValU, int[] iCol)
    {
        fdriMesL = xMesL;
        fdriMesU = xMesU;
        checked
        {
            fdriLblL = Functions.C36to10(xLblL) * 10000;
            fdriLblU = Functions.C36to10(xLblU) * 10000;
            fdriValL = xValL;
            fdriValU = xValU;
            fdriCol = iCol;
        }
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
            if (((((flag & Notes[num].Selected) | (flag2 & !Notes[num].Selected)) && fdrCheck(Notes[num]) && nEnabled(Notes[num].ColumnIndex) && fdrRangeS(xbLim, xbLim2, Conversions.ToBoolean(Interaction.IIf(NTInput, Notes[num].Length, Notes[num].LongNote)))) ? true : false) & fdrRangeS(xbLim4, xbLim3, Notes[num].Hidden))
            {
                RedoRemoveNote(Notes[num], ref BaseUndo, ref BaseRedo);
                RemoveNote(num, SortAndUpdatePairing: false);
            }
            else
            {
                num = checked(num + 1);
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
        checked
        {
            fdriLblL = Functions.C36to10(xLblL) * 10000;
            fdriLblU = Functions.C36to10(xLblU) * 10000;
            fdriValL = xValL;
            fdriValU = xValU;
            fdriCol = iCol;
        }
        bool flag = iRange % 2 == 0;
        bool flag2 = iRange % 3 == 0;
        bool xbLim = iRange % 5 == 0;
        bool xbLim2 = iRange % 7 == 0;
        bool xbLim3 = iRange % 11 == 0;
        bool xbLim4 = iRange % 13 == 0;
        checked
        {
            int num = Functions.C36to10(xReplaceLbl) * 10000;
            UndoRedo.LinkedURCmd BaseUndo = null;
            UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
            UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
            int num2 = Information.UBound(Notes);
            for (int i = 1; i <= num2; i++)
            {
                if ((((((((flag & Notes[i].Selected) | (flag2 & !Notes[i].Selected)) && fdrCheck(Notes[i]) && nEnabled(Notes[i].ColumnIndex)) ? true : false) & !IsColumnNumeric(Notes[i].ColumnIndex)) && fdrRangeS(xbLim, xbLim2, Conversions.ToBoolean(Interaction.IIf(NTInput, Notes[i].Length, Notes[i].LongNote)))) ? true : false) & fdrRangeS(xbLim4, xbLim3, Notes[i].Hidden))
                {
                    RedoRelabelNote(Notes[i], num, ref BaseUndo, ref BaseRedo);
                    Notes[i].Value = num;
                }
            }
            AddUndo(BaseUndo, linkedURCmd.Next);
            RefreshPanelAll();
            Interaction.Beep();
        }
    }

    public void fdrReplaceV(int iRange, int xMesL, int xMesU, string xLblL, string xLblU, int xValL, int xValU, int[] iCol, int xReplaceVal)
    {
        fdriMesL = xMesL;
        fdriMesU = xMesU;
        checked
        {
            fdriLblL = Functions.C36to10(xLblL) * 10000;
            fdriLblU = Functions.C36to10(xLblU) * 10000;
            fdriValL = xValL;
            fdriValU = xValU;
            fdriCol = iCol;
        }
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
        for (int i = 1; i <= num; i = checked(i + 1))
        {
            if ((((((((flag & Notes[i].Selected) | (flag2 & !Notes[i].Selected)) && fdrCheck(Notes[i]) && nEnabled(Notes[i].ColumnIndex)) ? true : false) & IsColumnNumeric(Notes[i].ColumnIndex)) && fdrRangeS(xbLim, xbLim2, Conversions.ToBoolean(Interaction.IIf(NTInput, Notes[i].Length, Notes[i].LongNote)))) ? true : false) & fdrRangeS(xbLim4, xbLim3, Notes[i].Hidden))
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
        checked
        {
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
                        notes[num4].VPosition = notes[num4].VPosition + num2;
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
                        notes[num4].Length = notes[num4].Length + num7;
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
                        notes[num8].VPosition = notes[num8].VPosition + num2;
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
    }

    private void MRemove_Click(object sender, EventArgs e)
    {
        UndoRedo.LinkedURCmd BaseUndo = null;
        UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
        UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
        int num = MeasureAtDisplacement(menuVPosition);
        double num2 = MeasureLength[num];
        double num3 = MeasureBottom[num];
        checked
        {
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
                        notes[num4].VPosition = notes[num4].VPosition - num2;
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
                        notes[num4].Length = notes[num4].Length - num7;
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
                        notes[num8].VPosition = notes[num8].VPosition - num2;
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
        checked
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
                ProjectData.SetProjectError((Exception)obj);
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
        checked
        {
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
                            if (Operators.CompareString(Functions.C10to36(unchecked(Notes[j].Value / 10000)), right, TextCompare: false) == 0)
                            {
                                RedoRelabelNote(Notes[j], i * 10000 + 10000, ref BaseUndo, ref BaseRedo);
                                Notes[j].Value = i * 10000 + 10000;
                            }
                            else if (Operators.CompareString(Functions.C10to36(unchecked(Notes[j].Value / 10000)), right2, TextCompare: false) == 0)
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
        checked
        {
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
                            if (Operators.CompareString(Functions.C10to36(unchecked(Notes[j].Value / 10000)), right, TextCompare: false) == 0)
                            {
                                RedoRelabelNote(Notes[j], i * 10000 + 10000, ref BaseUndo, ref BaseRedo);
                                Notes[j].Value = i * 10000 + 10000;
                            }
                            else if (Operators.CompareString(Functions.C10to36(unchecked(Notes[j].Value / 10000)), right2, TextCompare: false) == 0)
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
    }

    private void BWAVBrowse_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.DefaultExt = "wav";
        openFileDialog.Filter = Strings.FileType._wave + "|*.wav;*.ogg;*.mp3|" + Strings.FileType.WAV + "|*.wav|" + Strings.FileType.OGG + "|*.ogg|" + Strings.FileType.MP3 + "|*.mp3|" + Strings.FileType._all + "|*.*";
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
        checked
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
        if (((PMainIn.Focused || PMainInL.Focused) ? true : false) | PMainInR.Focused)
        {
            int num = Information.UBound(Notes);
            for (int i = 1; i <= num; i = checked(i + 1))
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
        if (((PMainIn.Focused || PMainInL.Focused) ? true : false) | PMainInR.Focused)
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
            for (int i = 1; i <= num; i = checked(i + 1))
            {
                Notes[i].Selected = Notes[i].Selected & nEnabled(Notes[i].ColumnIndex);
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
            for (int i = 1; i <= num; i = checked(i + 1))
            {
                Notes[i].Selected = Notes[i].Selected & nEnabled(Notes[i].ColumnIndex);
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
            for (int i = 1; i <= num; i = checked(i + 1))
            {
                Notes[i].Selected = Notes[i].Selected & nEnabled(Notes[i].ColumnIndex);
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
            for (int i = 1; i <= num; i = checked(i + 1))
            {
                Notes[i].Selected = Notes[i].Selected & nEnabled(Notes[i].ColumnIndex);
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
        checked
        {
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
                                        notes[num25].Length = notes[num25].Length + num2;
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
                                notes[num29].VPosition = notes[num29].VPosition + num2;
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
                                        notes[k].Length = notes[k].Length + num2;
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
                                    notes[k].VPosition = notes[k].VPosition + num2;
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
                                notes[num23].VPosition = notes[num23].VPosition + num2;
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
    }

    private void BBeatApply_Click(object sender, EventArgs e)
    {
        int num = Convert.ToInt32(nBeatD.Value);
        int num2 = Convert.ToInt32(nBeatN.Value);
        double num3 = (double)num2 / (double)num;
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
            ApplyBeat(result, Conversions.ToString(Operators.ConcatenateObject(result, Interaction.IIf(denominator > 10000, "", " ( " + Conversions.ToString(checked((long)Math.Round(result * (double)denominator))) + " / " + Conversions.ToString(denominator) + " ) "))));
        }
    }

    private void BHStageFile_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = Strings.FileType._image + "|*.bmp;*.png;*.jpg;*.gif|" + Strings.FileType._all + "|*.*";
        openFileDialog.InitialDirectory = Conversions.ToString(Interaction.IIf(Operators.CompareString(ExcludeFileName(FileName), "", TextCompare: false) == 0, InitPath, ExcludeFileName(FileName)));
        openFileDialog.DefaultExt = "png";
        if (openFileDialog.ShowDialog() != DialogResult.Cancel)
        {
            InitPath = ExcludeFileName(openFileDialog.FileName);
            if (object.ReferenceEquals(RuntimeHelpers.GetObjectValue(sender), BHStageFile))
            {
                THStageFile.Text = GetFileName(openFileDialog.FileName);
            }
            else if (object.ReferenceEquals(RuntimeHelpers.GetObjectValue(sender), BHBanner))
            {
                THBanner.Text = GetFileName(openFileDialog.FileName);
            }
            else if (object.ReferenceEquals(RuntimeHelpers.GetObjectValue(sender), BHBackBMP))
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
            if (!object.ReferenceEquals(RuntimeHelpers.GetObjectValue(sender), null))
            {
                if (object.ReferenceEquals(RuntimeHelpers.GetObjectValue(sender), POHeaderSwitch))
                {
                    panel = POHeaderInner;
                }
                else if (object.ReferenceEquals(RuntimeHelpers.GetObjectValue(sender), POGridSwitch))
                {
                    panel = POGridInner;
                }
                else if (object.ReferenceEquals(RuntimeHelpers.GetObjectValue(sender), POWaveFormSwitch))
                {
                    panel = POWaveFormInner;
                }
                else if (object.ReferenceEquals(RuntimeHelpers.GetObjectValue(sender), POWAVSwitch))
                {
                    panel = POWAVInner;
                }
                else if (object.ReferenceEquals(RuntimeHelpers.GetObjectValue(sender), POBeatSwitch))
                {
                    panel = POBeatInner;
                }
                else if (object.ReferenceEquals(RuntimeHelpers.GetObjectValue(sender), POExpansionSwitch))
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
            if (!object.ReferenceEquals(RuntimeHelpers.GetObjectValue(sender), null))
            {
                if (object.ReferenceEquals(RuntimeHelpers.GetObjectValue(sender), POHeaderExpander))
                {
                    panel = POHeaderPart2;
                }
                else if (object.ReferenceEquals(RuntimeHelpers.GetObjectValue(sender), POGridExpander))
                {
                    panel = POGridPart2;
                }
                else if (object.ReferenceEquals(RuntimeHelpers.GetObjectValue(sender), POWaveFormExpander))
                {
                    panel = POWaveFormPart2;
                }
                else if (object.ReferenceEquals(RuntimeHelpers.GetObjectValue(sender), POWAVExpander))
                {
                    panel = POWAVPart2;
                }
                else if (object.ReferenceEquals(RuntimeHelpers.GetObjectValue(sender), POBeatExpander))
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
            int num = checked(panel.Height + e.Y - tempResize);
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
            int num = checked(POptionsScroll.Width - e.X + tempResize);
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
            int num = checked(PMainR.Width - e.X + tempResize);
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
            int num = checked(PMainL.Width + e.X - tempResize);
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
        string s = Interaction.InputBox(Strings.Messages.PromptEnterMeasure, "Enter Measure");
        if (int.TryParse(s, out var result) && !(result < 0 || result > 999))
        {
            PanelVScroll[PanelFocus] = checked((int)Math.Round(0.0 - MeasureBottom[result]));
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
        checked
        {
            int num3 = (int)Notes[0].Value;
            int i;
            if (!NTInput)
            {
                int num4 = Information.UBound(Notes);
                for (i = 1; i <= num4; i++)
                {
                    if (Notes[i].ColumnIndex == 2)
                    {
                        num += (Notes[i].VPosition - num2) / (double)num3;
                        num2 = Notes[i].VPosition;
                        num3 = (int)Notes[i].Value;
                    }
                    else
                    {
                        Notes[i].VPosition = (double)vBPM * (num + (Notes[i].VPosition - num2) / (double)num3);
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
                        num += (Notes[i].VPosition - num2) / (double)num3;
                        num2 = Notes[i].VPosition;
                        num3 = (int)Notes[i].Value;
                        continue;
                    }
                    if (Notes[i].Length == 0.0)
                    {
                        Notes[i].VPosition = (double)vBPM * (num + (Notes[i].VPosition - num2) / (double)num3);
                        continue;
                    }
                    double num6 = num + (Notes[i].VPosition - num2) / (double)num3;
                    double num7 = num;
                    double num8 = num2;
                    int num9 = num3;
                    int num10 = i + 1;
                    int num11 = Information.UBound(Notes);
                    for (int j = num10; j <= num11 && !(Notes[j].VPosition >= Notes[i].VPosition + Notes[i].Length); j++)
                    {
                        if (Notes[j].ColumnIndex == 2)
                        {
                            num7 += (Notes[j].VPosition - num8) / (double)num9;
                            num8 = Notes[j].VPosition;
                            num9 = (int)Notes[j].Value;
                        }
                    }
                    double num12 = num7 + (Notes[i].VPosition + Notes[i].Length - num8) / (double)num9;
                    Notes[i].VPosition = (double)vBPM * num6;
                    Notes[i].Length = (double)vBPM * num12 - Notes[i].VPosition;
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
            THBPM.Value = new decimal((double)vBPM / 10000.0);
            CalculateTotalPlayableNotes();
            CalculateGreatestVPosition();
            RefreshPanelAll();
            POStatusRefresh();
        }
    }

    public string[] MyO2GridCheck()
    {
        CalculateGreatestVPosition();
        SortByVPositionInsertion();
        string[] array = new string[0];
        string[] array2 = new string[0];
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
        checked
        {
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
                        double[] array5 = new double[0];
                        int num7 = num2 - 1;
                        for (int l = num; l <= num7; l++)
                        {
                            if ((Operators.CompareString(GetBMSChannelBy(Notes[l]), text, TextCompare: false) == 0) & (Math.Abs(Notes[l].VPosition - (double)(MeasureAtDisplacement(Notes[l].VPosition) * 192)) > 0.0))
                            {
                                array5 = (double[])Utils.CopyArray(array5, new double[Information.UBound(array5) + 1 + 1]);
                                array5[Information.UBound(array5)] = Notes[l].VPosition - (double)(i * 192);
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
                                num10 = (int)Math.Round((double)num10 + Math.Abs(array5[n] - (double)((int)Math.Round(array5[n] / 4.0) * 4)));
                                num11 = (int)Math.Round((double)num11 + Math.Abs(array5[n] - (double)((int)Math.Round(array5[n] / 3.0) * 3)));
                            }
                            bool flag = num10 > num11;
                            array = (string[])Utils.CopyArray(array, new string[Information.UBound(array) + 1 + 1]);
                            unchecked
                            {
                                array[Information.UBound(array)] = Conversions.ToString(i) + "_" + Conversions.ToString(BMSChannelToColumn(text)) + "_" + nTitle(BMSChannelToColumn(text)) + "_" + Conversions.ToString(checked((int)Math.Round(192.0 / num8))) + "_" + Conversions.ToString(0 - (BMS.IsChannelLongNote(text) ? 1 : 0)) + "_" + Conversions.ToString(0 - (BMS.IsChannelHidden(text) ? 1 : 0)) + "_" + Conversions.ToString(0 - (flag ? 1 : 0)) + "_" + Conversions.ToString(num11) + "_" + Conversions.ToString(num10);
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
                        double[] array7 = new double[0];
                        int num16 = Information.UBound(Notes);
                        for (int num17 = 1; num17 <= num16 && MeasureAtDisplacement(Notes[num17].VPosition) <= num14; num17++)
                        {
                            if (Operators.CompareString(GetBMSChannelBy(Notes[num17]), text2, TextCompare: false) != 0 || (BMS.IsChannelLongNote(text2) ^ (Notes[num17].Length != 0.0)))
                            {
                                continue;
                            }
                            if (MeasureAtDisplacement(Notes[num17].VPosition) == num14 && Math.Abs(Notes[num17].VPosition - (double)(MeasureAtDisplacement(Notes[num17].VPosition) * 192)) > 0.0)
                            {
                                array7 = (double[])Utils.CopyArray(array7, new double[Information.UBound(array7) + 1 + 1]);
                                array7[Information.UBound(array7)] = Notes[num17].VPosition - (double)(num14 * 192);
                                if (array7[Information.UBound(array7)] < 0.0)
                                {
                                    array7[Information.UBound(array7)] = 0.0;
                                }
                            }
                            if (Notes[num17].Length != 0.0 && MeasureAtDisplacement(Notes[num17].VPosition + Notes[num17].Length) == num14 && Notes[num17].VPosition + Notes[num17].Length - (double)(num14 * 192) != 0.0)
                            {
                                array7 = (double[])Utils.CopyArray(array7, new double[Information.UBound(array7) + 1 + 1]);
                                array7[Information.UBound(array7)] = Notes[num17].VPosition + Notes[num17].Length - (double)(num14 * 192);
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
                                num21 = (int)Math.Round((double)num21 + Math.Abs(array7[num24] - (double)((int)Math.Round(array7[num24] / 4.0) * 4)));
                                num22 = (int)Math.Round((double)num22 + Math.Abs(array7[num24] - (double)((int)Math.Round(array7[num24] / 3.0) * 3)));
                            }
                            bool flag2 = num21 > num22;
                            array = (string[])Utils.CopyArray(array, new string[Information.UBound(array) + 1 + 1]);
                            unchecked
                            {
                                array[Information.UBound(array)] = Conversions.ToString(num14) + "_" + Conversions.ToString(BMSChannelToColumn(text2)) + "_" + nTitle(BMSChannelToColumn(text2)) + "_" + Conversions.ToString(checked((int)Math.Round(192.0 / num18))) + "_" + Conversions.ToString(0 - (BMS.IsChannelLongNote(text2) ? 1 : 0)) + "_" + Conversions.ToString(0 - (BMS.IsChannelHidden(text2) ? 1 : 0)) + "_" + Conversions.ToString(0 - (flag2 ? 1 : 0)) + "_" + Conversions.ToString(num22) + "_" + Conversions.ToString(num21);
                            }
                        }
                    }
                }
            }
            return array;
        }
    }

    public void MyO2GridAdjust(dgMyO2.Adj[] xaj)
    {
        UndoRedo.LinkedURCmd BaseUndo = null;
        UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
        UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
        RedoRemoveNoteAll(xSel: false, ref BaseUndo, ref BaseRedo);
        checked
        {
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
                            if (((Notes[l].Length > 0.0 && MeasureAtDisplacement(Notes[l].VPosition + Notes[l].Length) == adj2.Measure) ? true : false) & (Notes[l].ColumnIndex == adj2.ColumnIndex) & (Notes[l].Hidden == adj2.Hidden))
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
            int num2 = checked(-PanelVScroll[xIndex]);
            int xVSu = Conversions.ToInteger(Interaction.IIf((double)((float)num2 + (float)num / gxHeight) > GetMaxVPosition(), GetMaxVPosition(), (float)num2 + (float)num / gxHeight));
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
            if (ShouldDrawTempNote && ((SelectedColumn > -1) & (TempVPosition > -1.0)))
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
        int num = checked((LWAV.SelectedIndex + 1) * 10000);
        float opacity = 1f;
        if (PanelKeyStates.ModifierHiddenActive())
        {
            opacity = vo.kOpacity;
        }
        string s = Functions.C10to36(num / 10000);
        if (IsColumnNumeric(SelectedColumn))
        {
            s = GetColumn(SelectedColumn).Title;
        }
        checked
        {
            Point point = new Point(HorizontalPositiontoDisplay(nLeft(SelectedColumn), xHS), NoteRowToPanelHeight(TempVPosition, xVS, xTHeight) - vo.kHeight - 10);
            Point point2 = new Point(HorizontalPositiontoDisplay(nLeft(SelectedColumn) + GetColumnWidth(SelectedColumn), xHS), NoteRowToPanelHeight(TempVPosition, xVS, xTHeight) + 10);
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
            LinearGradientBrush brush2 = new LinearGradientBrush(point, point2, color, color2);
            e1.Graphics.FillRectangle(brush2, HorizontalPositiontoDisplay(nLeft(SelectedColumn), xHS) + 2, NoteRowToPanelHeight(TempVPosition, xVS, xTHeight) - vo.kHeight + 1, (float)GetColumnWidth(SelectedColumn) * gxWidth - 3f, vo.kHeight - 1);
            e1.Graphics.DrawRectangle(pen, HorizontalPositiontoDisplay(nLeft(SelectedColumn), xHS) + 1, NoteRowToPanelHeight(TempVPosition, xVS, xTHeight) - vo.kHeight, (float)GetColumnWidth(SelectedColumn) * gxWidth - 2f, vo.kHeight);
            e1.Graphics.DrawString(s, vo.kFont, brush, HorizontalPositiontoDisplay(nLeft(SelectedColumn), xHS) + vo.kLabelHShiftL - 2, NoteRowToPanelHeight(TempVPosition, xVS, xTHeight) - vo.kHeight + vo.kLabelVShift);
        }
    }

    private void DrawDragAndDrop(int xIndex, BufferedGraphics e1)
    {
        if (Information.UBound(DDFileName) > -1)
        {
            SolidBrush brush = new SolidBrush(Color.FromArgb(-1056964609));
            float num = (float)((double)spMain[xIndex].DisplayRectangle.Width / 2.0);
            float num2 = (float)((double)spMain[xIndex].DisplayRectangle.Height / 2.0);
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
            Conversions.ToInteger(clamp((double)(int)col.A * factor)), 
            Conversions.ToInteger(clamp((double)(int)col.R * factor)), 
            Conversions.ToInteger(clamp((double)(int)col.G * factor)), 
            Conversions.ToInteger(clamp((double)(int)col.B * factor))
          );
    }

    private void DrawBackgroundColor(BufferedGraphics e1, int xTHeight, int xTWidth, int xHS, int xI1)
    {
        if (!gShowBG)
        {
            return;
        }
        int num = gColumns;
        checked
        {
            Color color2 = default(Color);
            for (xI1 = 0; xI1 <= num; xI1++)
            {
                if (!((float)nLeft(xI1 + 1) * gxWidth - (float)xHS * gxWidth + 1f < 0f))
                {
                    if ((float)nLeft(xI1) * gxWidth - (float)xHS * gxWidth + 1f > (float)xTWidth)
                    {
                        break;
                    }
                    if ((GetColumn(xI1).cBG.GetBrightness() != 0f) & (GetColumnWidth(xI1) > 0))
                    {
                        Color color = GetColumn(xI1).cBG;
                        if (xI1 == GetColumnAtX(MouseMoveStatus.X, xHS))
                        {
                            double num2 = 1.2;
                            object columnHighlightColor = GetColumnHighlightColor(color);
                            color = ((columnHighlightColor != null) ? ((Color)columnHighlightColor) : color2);
                        }
                        SolidBrush brush = new SolidBrush(color);
                        e1.Graphics.FillRectangle(brush, (float)nLeft(xI1) * gxWidth - (float)xHS * gxWidth + 1f, 0f, (float)GetColumnWidth(xI1) * gxWidth, xTHeight);
                    }
                }
            }
        }
    }

    private int DrawColumnCaptions(BufferedGraphics e1, int xTWidth, int xHS, int xI1)
    {
        checked
        {
            if (gShowC)
            {
                int num = gColumns;
                for (xI1 = 0; xI1 <= num; xI1++)
                {
                    if (!((float)nLeft(xI1 + 1) * gxWidth - (float)xHS * gxWidth + 1f < 0f))
                    {
                        if ((float)nLeft(xI1) * gxWidth - (float)xHS * gxWidth + 1f > (float)xTWidth)
                        {
                            break;
                        }
                        if (GetColumnWidth(xI1) > 0)
                        {
                            e1.Graphics.DrawString(nTitle(xI1), vo.ColumnTitleFont, vo.ColumnTitle, (float)nLeft(xI1) * gxWidth - (float)xHS * gxWidth, 0f);
                        }
                    }
                }
            }
            return xI1;
        }
    }

    private int DrawPanelLines(BufferedGraphics e1, int xTHeight, int xTWidth, int xHS, int xVS, int xVSu)
    {
        checked
        {
            if (gShowVerticalLine)
            {
                int num = gColumns;
                for (int i = 0; i <= num; i++)
                {
                    float num2 = (float)nLeft(i) * gxWidth - (float)xHS * gxWidth;
                    if (!(num2 + 1f < 0f))
                    {
                        if (num2 + 1f > (float)xTWidth)
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
            object CounterResult = default(object);
            object LoopForResult = default(object);
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
                    double xVPosition = MeasureBottom[Conversions.ToInteger(CounterResult)];
                    int num3 = NoteRowToPanelHeight(xVPosition, xVS, xTHeight);
                    if (gShowMeasureBar)
                    {
                        e1.Graphics.DrawLine(vo.pMLine, 0, num3, xTWidth, num3);
                    }
                    if (gShowMeasureNumber)
                    {
                        e1.Graphics.DrawString("[" + Functions.Add3Zeros(Conversions.ToInteger(CounterResult)).ToString() + "]", vo.kMFont, new SolidBrush(GetColumn(0).cText), (float)(-xHS) * gxWidth, num3 - vo.kMFont.Height);
                    }
                }
                while (ObjectFlowControl.ForLoopControl.ForNextCheckObj(CounterResult, LoopForResult, ref CounterResult));
            }
            object objectValue = RuntimeHelpers.GetObjectValue(GetMouseVPosition(gSnap));
            int num4 = NoteRowToPanelHeight(Conversions.ToDouble(objectValue), xVS, xTHeight);
            Pen pen = new Pen(Color.White);
            e1.Graphics.DrawLine(pen, 0, num4, xTWidth, num4);
            return Conversions.ToInteger(CounterResult);
        }
    }

    private void DrawGridLines(BufferedGraphics e1, int xTHeight, int xTWidth, int xVS, int measureIndex, int divisions, Pen pen)
    {
        int num = 0;
        double num2 = MeasureUpper(measureIndex);
        double num3 = MeasureBottom[measureIndex];
        double num4 = 192.0 / (double)divisions;
        while (num3 < num2)
        {
            int num5 = NoteRowToPanelHeight(num3, xVS, xTHeight);
            e1.Graphics.DrawLine(pen, 0, num5, xTWidth, num5);
            num = checked(num + 1);
            num3 = MeasureBottom[measureIndex] + (double)num * num4;
        }
    }

    private bool IsNoteVisible(Note note, int xTHeight, int xVS)
    {
        float num = (float)Math.Abs(xVS) + (float)xTHeight / gxHeight;
        float num2 = (float)Math.Abs(xVS) - (float)vo.kHeight / gxHeight;
        bool flag = note.VPosition >= (double)num2;
        bool flag2 = note.VPosition <= (double)num2;
        bool flag3 = note.VPosition + note.Length >= (double)num2;
        bool flag4 = flag2 && flag3;
        bool flag5 = (note.VPosition <= (double)num2) & (Notes[note.LNPair].VPosition >= (double)num2);
        bool flag6 = note.VPosition > (double)num;
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
        float num = (float)Math.Abs(xVS) + (float)xTHeight / gxHeight;
        float num2 = (float)Math.Abs(xVS) - (float)vo.kHeight / gxHeight;
        int num3 = Information.UBound(Notes);
        for (int i = 0; i <= num3 && !(Notes[i].VPosition > (double)num); i = checked(i + 1))
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
        int num = HorizontalPositiontoDisplay(nLeft(note.ColumnIndex), xHS);
        checked
        {
            int num2 = Conversions.ToInteger(Interaction.IIf(!NTInput | (bAdjustLength & !bAdjustUpper), NoteRowToPanelHeight(note.VPosition, xVS, xTHeight) - vo.kHeight - 1, NoteRowToPanelHeight(note.VPosition + note.Length, xVS, xTHeight) - vo.kHeight - 1));
            int num3 = (int)Math.Round((float)GetColumnWidth(note.ColumnIndex) * gxWidth + 1f);
            int num4 = Conversions.ToInteger(Interaction.IIf(!NTInput | bAdjustLength, vo.kHeight + 3, note.Length * (double)gxHeight + (double)vo.kHeight + 3.0));
            return new Rectangle(num, num2, num3, num4);
        }
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
        checked
        {
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
    }

    private void DrawTimeSelection(BufferedGraphics e1, int xTHeight, int xTWidth, int xHS, int xVS)
    {
        long value = Notes[0].Value;
        long value2 = Notes[0].Value;
        long value3 = Notes[0].Value;
        int num = Information.UBound(Notes);
        checked
        {
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
            e1.Graphics.FillRectangle(vo.PESel, 0, NoteRowToPanelHeight(Conversions.ToDouble(Operators.AddObject(vSelStart, Interaction.IIf(vSelLength > 0.0, vSelLength, 0))), xVS, xTHeight) + Math.Abs(unchecked(0 - ((vSelLength != 0.0) ? 1 : 0))), xTWidth, (int)Math.Round(Math.Abs(vSelLength) * (double)gxHeight));
            e1.Graphics.DrawLine(vo.PECursor, 0, NoteRowToPanelHeight(vSelStart + vSelLength, xVS, xTHeight), xTWidth, NoteRowToPanelHeight(vSelStart + vSelLength, xVS, xTHeight));
            e1.Graphics.DrawLine(vo.PEHalf, 0, NoteRowToPanelHeight(vSelStart + vSelHalf, xVS, xTHeight), xTWidth, NoteRowToPanelHeight(vSelStart + vSelHalf, xVS, xTHeight));
            e1.Graphics.DrawString(Conversions.ToString((double)value / 10000.0), vo.PEBPMFont, vo.PEBPM, (float)(-xHS + nLeft(2)) * gxWidth, NoteRowToPanelHeight(vSelStart, xVS, xTHeight) - vo.PEBPMFont.Height + 3);
            e1.Graphics.DrawString(Conversions.ToString((double)value2 / 10000.0), vo.PEBPMFont, vo.PEBPM, (float)(-xHS + nLeft(2)) * gxWidth, NoteRowToPanelHeight(vSelStart + vSelHalf, xVS, xTHeight) - vo.PEBPMFont.Height + 3);
            e1.Graphics.DrawString(Conversions.ToString((double)value3 / 10000.0), vo.PEBPMFont, vo.PEBPM, (float)(-xHS + nLeft(2)) * gxWidth, NoteRowToPanelHeight(vSelStart + vSelLength, xVS, xTHeight) - vo.PEBPMFont.Height + 3);
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
    }

    private BufferedGraphics DrawClickAndScroll(int xIndex, BufferedGraphics e1)
    {
        Panel obj = spMain[xIndex];
        Point p = new Point(0, 0);
        Point point = obj.PointToScreen(p);
        checked
        {
            float num = MiddleButtonLocation.X - point.X;
            float num2 = MiddleButtonLocation.Y - point.Y;
            float num3 = Cursor.Position.X - point.X;
            float num4 = Cursor.Position.Y - point.Y;
            double num5 = Math.Atan2(num4 - num2, num3 - num);
            e1.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            if (!unchecked(num == num3 && num2 == num4))
            {
                PointF[] array = new PointF[3];
                ref PointF reference = ref array[0];
                PointF pointF = new PointF(num3, num4);
                reference = pointF;
                ref PointF reference2 = ref array[1];
                PointF pointF2 = new PointF((float)(Math.Cos(num5 + Math.PI / 2.0) * 10.0 + (double)num), (float)(Math.Sin(num5 + Math.PI / 2.0) * 10.0 + (double)num2));
                reference2 = pointF2;
                ref PointF reference3 = ref array[2];
                PointF pointF3 = new PointF((float)(Math.Cos(num5 - Math.PI / 2.0) * 10.0 + (double)num), (float)(Math.Sin(num5 - Math.PI / 2.0) * 10.0 + (double)num2));
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
    }

    private void DrawWaveform(BufferedGraphics e1, int xTHeight, int xVSR, int xI1)
    {
        if (!((wWavL != null) & (wWavR != null) & (wPrecision > 0)))
        {
            return;
        }
        checked
        {
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
                new decimal((double)Notes[0].Value / 10000.0)
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
                        reference = new decimal((double)Notes[xI1].Value / 10000.0);
                        ref decimal reference2 = ref array5[Information.UBound(array5)];
                        reference2 = new decimal((Notes[xI1].VPosition - array3[Information.UBound(array3) - 1]) * 1.25 * (double)wSampleRate / Convert.ToDouble(array4[Information.UBound(array4) - 1]) + Convert.ToDouble(array5[Information.UBound(array5) - 1]));
                    }
                    else
                    {
                        ref decimal reference3 = ref array4[0];
                        reference3 = new decimal((double)Notes[xI1].Value / 10000.0);
                    }
                }
            }
            int num3 = 0;
            for (xI1 = xTHeight * wPrecision; xI1 >= 0; xI1 += -1)
            {
                double num4 = ((double)(-xI1) / (double)wPrecision + (double)xTHeight + (double)((float)xVSR * gxHeight) - 1.0) / (double)gxHeight;
                int num5 = Information.UBound(array3);
                for (num3 = 1; num3 <= num5 && !(array3[num3] >= num4); num3++)
                {
                }
                num3--;
                double num6 = Convert.ToDouble(array5[num3]) + (num4 - array3[num3]) * 1.25 * (double)wSampleRate / Convert.ToDouble(array4[num3]);
                if (unchecked(num6 <= (double)Information.UBound(wWavL) && num6 >= 0.0))
                {
                    ref PointF reference4 = ref array[xI1];
                    reference4 = new PointF(wWavL[(int)Math.Round(Conversion.Int(num6))] * (float)wWidth + (float)wLeft, (float)((double)xI1 / (double)wPrecision));
                    ref PointF reference5 = ref array2[xI1];
                    reference5 = new PointF(wWavR[(int)Math.Round(Conversion.Int(num6))] * (float)wWidth + (float)wLeft, (float)((double)xI1 / (double)wPrecision));
                }
                else
                {
                    ref PointF reference6 = ref array[xI1];
                    reference6 = new PointF(wLeft, (float)((double)xI1 / (double)wPrecision));
                    ref PointF reference7 = ref array2[xI1];
                    reference7 = new PointF(wLeft, (float)((double)xI1 / (double)wPrecision));
                }
            }
            e1.Graphics.DrawLines(vo.pBGMWav, array);
            e1.Graphics.DrawLines(vo.pBGMWav, array2);
        }
    }

    private void DrawNote(Note sNote, BufferedGraphics e, long xHS, long xVS, int xHeight)
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
        checked
        {
            Point point = new Point(HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS), NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) - vo.kHeight - 10);
            Point point2 = new Point(HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex) + GetColumnWidth(sNote.ColumnIndex), xHS), NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) + 10);
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
            LinearGradientBrush brush2 = new LinearGradientBrush(point, point2, color, color2);
            e.Graphics.FillRectangle(brush2, HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS) + 2, NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) - vo.kHeight + 1, (float)GetColumnWidth(sNote.ColumnIndex) * gxWidth - 3f, vo.kHeight - 1);
            e.Graphics.DrawRectangle(pen, HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS) + 1, NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) - vo.kHeight, (float)GetColumnWidth(sNote.ColumnIndex) * gxWidth - 2f, vo.kHeight);
            e.Graphics.DrawString(Conversions.ToString(Interaction.IIf(IsColumnNumeric(sNote.ColumnIndex), (double)sNote.Value / 10000.0, text)), vo.kFont, brush, HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS) + vo.kLabelHShift, NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) - vo.kHeight + vo.kLabelVShift);
            if (sNote.ColumnIndex < 27 && sNote.LNPair != 0)
            {
                DrawPairedLNBody(sNote, e, xHS, xVS, xHeight, num);
            }
            if (ErrorCheck && sNote.HasError)
            {
                e.Graphics.DrawImage(Resources.ImageError, HorizontalPositiontoDisplay((int)Math.Round((double)nLeft(sNote.ColumnIndex) + (double)GetColumnWidth(sNote.ColumnIndex) / 2.0), xHS) - 12, (int)Math.Round((double)NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) - (double)vo.kHeight / 2.0 - 12.0), 24, 24);
            }
            if (sNote.Selected)
            {
                e.Graphics.DrawRectangle(vo.kSelected, HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS), NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) - vo.kHeight - 1, (float)GetColumnWidth(sNote.ColumnIndex) * gxWidth, vo.kHeight + 2);
            }
        }
    }

    private void DrawPairedLNBody(Note sNote, BufferedGraphics e, long xHS, long xVS, int xHeight, float xAlpha)
    {
        Pen pen = new Pen(GetColumn(sNote.ColumnIndex).getLongBright(xAlpha));
        checked
        {
            Point point = new Point(HorizontalPositiontoDisplay((int)Math.Round((double)nLeft(sNote.ColumnIndex) - 0.5 * (double)GetColumnWidth(sNote.ColumnIndex)), xHS), NoteRowToPanelHeight(Notes[sNote.LNPair].VPosition, xVS, xHeight));
            Point point2 = new Point(HorizontalPositiontoDisplay((int)Math.Round((double)nLeft(sNote.ColumnIndex) + 1.5 * (double)GetColumnWidth(sNote.ColumnIndex)), xHS), NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) + vo.kHeight);
            LinearGradientBrush brush = new LinearGradientBrush(point, point2, GetColumn(sNote.ColumnIndex).getLongBright(xAlpha), GetColumn(sNote.ColumnIndex).getLongDark(xAlpha));
            e.Graphics.FillRectangle(brush, HorizontalPositiontoDisplay(nLeft(Notes[sNote.LNPair].ColumnIndex), xHS) + 3, NoteRowToPanelHeight(Notes[sNote.LNPair].VPosition, xVS, xHeight) + 1, (float)GetColumnWidth(Notes[sNote.LNPair].ColumnIndex) * gxWidth - 5f, NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) - NoteRowToPanelHeight(Notes[sNote.LNPair].VPosition, xVS, xHeight) - vo.kHeight - 1);
            e.Graphics.DrawRectangle(pen, HorizontalPositiontoDisplay(nLeft(Notes[sNote.LNPair].ColumnIndex), xHS) + 2, NoteRowToPanelHeight(Notes[sNote.LNPair].VPosition, xVS, xHeight), (float)GetColumnWidth(Notes[sNote.LNPair].ColumnIndex) * gxWidth - 4f, NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) - NoteRowToPanelHeight(Notes[sNote.LNPair].VPosition, xVS, xHeight) - vo.kHeight);
        }
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
        checked
        {
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
                point = new Point(HorizontalPositiontoDisplay((int)Math.Round((double)nLeft(sNote.ColumnIndex) - 0.5 * (double)GetColumnWidth(sNote.ColumnIndex)), xHS), NoteRowToPanelHeight(sNote.VPosition + sNote.Length, xVS, xHeight) - vo.kHeight);
                point2 = new Point(HorizontalPositiontoDisplay((int)Math.Round((double)nLeft(sNote.ColumnIndex) + 1.5 * (double)GetColumnWidth(sNote.ColumnIndex)), xHS), NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight));
                color = GetColumn(sNote.ColumnIndex).getLongBright(num);
                color2 = GetColumn(sNote.ColumnIndex).getLongDark(num);
                brush = new SolidBrush(GetColumn(sNote.ColumnIndex).cLText);
            }
            Pen pen = new Pen(color);
            LinearGradientBrush brush2 = new LinearGradientBrush(point, point2, color, color2);
            e.Graphics.FillRectangle(brush2, HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS) + 1, NoteRowToPanelHeight(sNote.VPosition + sNote.Length, xVS, xHeight) - vo.kHeight + 1, (float)GetColumnWidth(sNote.ColumnIndex) * gxWidth - 1f, (int)Math.Round(sNote.Length * (double)gxHeight) + vo.kHeight - 1);
            e.Graphics.DrawRectangle(pen, HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS) + 1, NoteRowToPanelHeight(sNote.VPosition + sNote.Length, xVS, xHeight) - vo.kHeight, (float)GetColumnWidth(sNote.ColumnIndex) * gxWidth - 3f, (int)Math.Round(sNote.Length * (double)gxHeight) + vo.kHeight);
            e.Graphics.DrawString(Conversions.ToString(Interaction.IIf(IsColumnNumeric(sNote.ColumnIndex), (double)sNote.Value / 10000.0, text)), vo.kFont, brush, HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS) + vo.kLabelHShiftL - 2, NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) - vo.kHeight + vo.kLabelVShift);
            if (sNote.ColumnIndex < 27 && ((sNote.Length == 0.0) & (sNote.LNPair != 0)))
            {
                DrawPairedLNBody(sNote, e, xHS, xVS, xHeight, num);
            }
            if (sNote.Selected)
            {
                e.Graphics.DrawRectangle(vo.kSelected, HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex), xHS), NoteRowToPanelHeight(sNote.VPosition + sNote.Length, xVS, xHeight) - vo.kHeight - 1, (float)GetColumnWidth(sNote.ColumnIndex) * gxWidth, (int)Math.Round(sNote.Length * (double)gxHeight) + vo.kHeight + 2);
            }
            if (ErrorCheck && sNote.HasError)
            {
                e.Graphics.DrawImage(Resources.ImageError, HorizontalPositiontoDisplay((int)Math.Round((double)nLeft(sNote.ColumnIndex) + (double)GetColumnWidth(sNote.ColumnIndex) / 2.0), xHS) - 12, (int)Math.Round((double)NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) - (double)vo.kHeight / 2.0 - 12.0), 24, 24);
            }
        }
    }

    private void PMainInPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        checked
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
                int num = Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null));
                int num2 = -1;
                UndoRedo.LinkedURCmd BaseUndo = null;
                UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
                UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
                SelectedNotes = new Note[0];
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        {
                            double num3 = 192.0 / (double)gDivide;
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
                            double num10 = -192.0 / (double)gDivide;
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
                        mnDelete_Click(mnDelete, new EventArgs());
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
                            TBUndo_Click(TBUndo, new EventArgs());
                            break;
                        case Keys.Y:
                            TBRedo_Click(TBRedo, new EventArgs());
                            break;
                        case Keys.X:
                            TBCut_Click(TBCut, new EventArgs());
                            break;
                        case Keys.C:
                            TBCopy_Click(TBCopy, new EventArgs());
                            break;
                        case Keys.V:
                            TBPaste_Click(TBPaste, new EventArgs());
                            break;
                        case Keys.A:
                            mnSelectAll_Click(mnSelectAll, new EventArgs());
                            break;
                        case Keys.F:
                            TBFind_Click(TBFind, new EventArgs());
                            break;
                        case Keys.T:
                            TBStatistics_Click(TBStatistics, new EventArgs());
                            break;
                    }
                }
                if (PanelKeyStates.ModifierMultiselectActive() && ((e.KeyCode == Keys.A) & (KMouseOver != -1)))
                {
                    SelectAllWithHoveredNoteLabel();
                }
                PMainInMouseMove((Panel)sender);
                POStatusRefresh();
            }
        }
    }

    private void SelectAllWithHoveredNoteLabel()
    {
        int num = Information.UBound(Notes);
        for (int i = 0; i <= num; i = checked(i + 1))
        {
            Notes[i].Selected = Conversions.ToBoolean(Interaction.IIf(IsLabelMatch(Notes[i], KMouseOver), true, Notes[i].Selected));
        }
    }

    private bool IsLabelMatch(Note note, int index)
    {
        checked
        {
            if (TBShowFileName.Checked)
            {
                double a = (double)Notes[index].Value / 10000.0;
                string right = hWAV[(int)Math.Round(a)];
                if (Operators.CompareString(hWAV[(int)Math.Round((double)note.Value / 10000.0)], right, TextCompare: false) == 0)
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
    }

    private void DecreaseCurrentWav()
    {
        if (LWAV.SelectedIndex == -1)
        {
            LWAV.SelectedIndex = 0;
            return;
        }
        int num = checked(LWAV.SelectedIndex - 1);
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
        checked
        {
            int num = LWAV.SelectedIndex + 1;
            if (num > LWAV.Items.Count - 1)
            {
                num = LWAV.Items.Count - 1;
            }
            LWAV.SelectedIndices.Clear();
            LWAV.SelectedIndex = num;
            ValidateWavListView();
        }
    }

    private void MoveToBGM(UndoRedo.LinkedURCmd xUndo, UndoRedo.LinkedURCmd xRedo)
    {
        UndoRedo.LinkedURCmd linkedURCmd = xRedo;
        int num = Information.UBound(Notes);
        checked
        {
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
                        if (unchecked(((Notes[j].ColumnIndex == num3 && flag) ? true : false) && flag2))
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
        checked
        {
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
    }

    private void PMainInResize(object sender, EventArgs e)
    {
        if (!Created)
        {
            return;
        }
        int num = Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null));
        PanelWidth[0] = PMainL.Width;
        PanelWidth[1] = PMain.Width;
        PanelWidth[2] = PMainR.Width;
        checked
        {
            switch (num)
            {
                case 0:
                    LeftPanelScroll.LargeChange = Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(sender, null, "Height", new object[0], null, null, null), 0.9));
                    LeftPanelScroll.Maximum = LeftPanelScroll.LargeChange - 1;
                    HSL.LargeChange = Conversions.ToInteger(Operators.DivideObject(NewLateBinding.LateGet(sender, null, "Width", new object[0], null, null, null), gxWidth));
                    if (HSL.Value > HSL.Maximum - HSL.LargeChange + 1)
                    {
                        HSL.Value = HSL.Maximum - HSL.LargeChange + 1;
                    }
                    break;
                case 1:
                    MainPanelScroll.LargeChange = Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(sender, null, "Height", new object[0], null, null, null), 0.9));
                    MainPanelScroll.Maximum = MainPanelScroll.LargeChange - 1;
                    HS.LargeChange = Conversions.ToInteger(Operators.DivideObject(NewLateBinding.LateGet(sender, null, "Width", new object[0], null, null, null), gxWidth));
                    if (HS.Value > HS.Maximum - HS.LargeChange + 1)
                    {
                        HS.Value = HS.Maximum - HS.LargeChange + 1;
                    }
                    break;
                case 2:
                    RightPanelScroll.LargeChange = Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(sender, null, "Height", new object[0], null, null, null), 0.9));
                    RightPanelScroll.Maximum = RightPanelScroll.LargeChange - 1;
                    HSR.LargeChange = Conversions.ToInteger(Operators.DivideObject(NewLateBinding.LateGet(sender, null, "Width", new object[0], null, null, null), gxWidth));
                    if (HSR.Value > HSR.Maximum - HSR.LargeChange + 1)
                    {
                        HSR.Value = HSR.Maximum - HSR.LargeChange + 1;
                    }
                    break;
            }
            object obj = NewLateBinding.LateGet(sender, null, "DisplayRectangle", new object[0], null, null, null);
            Rectangle rectangle = default(Rectangle);
            RefreshPanel(num, (obj != null) ? ((Rectangle)obj) : rectangle);
        }
    }

    private void PMainInLostFocus(object sender, EventArgs e)
    {
        RefreshPanelAll();
    }

    private void PMainInMouseDown(object sender, MouseEventArgs e)
    {
        tempFirstMouseDown = Conversions.ToBoolean(Operators.AndObject(FirstClickDisabled, Operators.NotObject(NewLateBinding.LateGet(sender, null, "Focused", new object[0], null, null, null))));
        PanelFocus = Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null));
        NewLateBinding.LateCall(sender, null, "Focus", new object[0], null, null, null, IgnoreReturn: true);
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
        checked
        {
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
    }

    private void DeselectOrRemove(MouseEventArgs e, long xHS, long xVS, int xHeight)
    {
        KMouseOver = -1;
        SelectedNotes = new Note[0];
        if (tempFirstMouseDown)
        {
            return;
        }
        checked
        {
            for (int i = Information.UBound(Notes); i >= 1; i += -1)
            {
                if (MouseInNote(e, xHS, xVS, xHeight, Notes[i]))
                {
                    if (MyProject.Computer.Keyboard.ShiftKeyDown)
                    {
                        LWAV.SelectedIndices.Clear();
                        LWAV.SelectedIndex = Functions.C36to10(Functions.C10to36(unchecked(Notes[i].Value / 10000))) - 1;
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
    }

    private int GetClickedNote(MouseEventArgs e, long xHS, long xVS, int xHeight)
    {
        int result = -1;
        checked
        {
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
        checked
        {
            int num = (int)unchecked(Notes[NoteIndex].Value / 10000);
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
    }

    private void HandleCurrentModeOnClick(MouseEventArgs e, long xHS, long xVS, int xHeight, ref int NoteIndex)
    {
        checked
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
                    string prompt = Strings.Messages.PromptEnterNumeric;
                    if (Operators.ConditionalCompareObjectEqual(objectValue2, 2, TextCompare: false))
                    {
                        prompt = Strings.Messages.PromptEnterBPM;
                    }
                    if (Operators.ConditionalCompareObjectEqual(objectValue2, 3, TextCompare: false))
                    {
                        prompt = Strings.Messages.PromptEnterSTOP;
                    }
                    if (Operators.ConditionalCompareObjectEqual(objectValue2, 1, TextCompare: false))
                    {
                        prompt = Strings.Messages.PromptEnterSCROLL;
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
                double num5 = ((NoteIndex < 0) ? ((double)(((float)xHeight - (float)xVS * gxHeight - (float)e.Y - 1f) / gxHeight)) : Notes[NoteIndex].VPosition);
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
    }

    private void OnSelectModeLeftClick(MouseEventArgs e, int NoteIndex, int xTHeight, int xVS)
    {
        if ((NoteIndex >= 0) & (e.Clicks == 2))
        {
            DoubleClickNoteIndex(NoteIndex);
            return;
        }
        checked
        {
            if (NoteIndex > 0)
            {
                SelectedNotes = new Note[0];
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
            SelectedNotes = new Note[0];
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
    }

    private void DoubleClickNoteIndex(int NoteIndex)
    {
        Note xN = Notes[NoteIndex];
        int columnIndex = xN.ColumnIndex;
        checked
        {
            if (IsColumnNumeric(columnIndex))
            {
                string prompt = Strings.Messages.PromptEnterNumeric;
                if (columnIndex == 2)
                {
                    prompt = Strings.Messages.PromptEnterBPM;
                }
                if (columnIndex == 3)
                {
                    prompt = Strings.Messages.PromptEnterSTOP;
                }
                if (columnIndex == 1)
                {
                    prompt = Strings.Messages.PromptEnterSCROLL;
                }
                string text = Interaction.InputBox(prompt, Text);
                double num = Conversion.Val(text) * 10000.0;
                if (unchecked(((columnIndex == 1) & (Operators.CompareString(text, "0", TextCompare: false) == 0)) || num != 0.0))
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
            string text2 = Microsoft.VisualBasic.Strings.UCase(Microsoft.VisualBasic.Strings.Trim(Interaction.InputBox(Strings.Messages.PromptEnter, Text)));
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
                    Interaction.MsgBox(Strings.Messages.InvalidLabel, MsgBoxStyle.Critical, Strings.Messages.Err);
                }
            }
        }
    }

    private bool MouseInNote(MouseEventArgs e, long xHS, long xVS, int xHeight, Note note)
    {
        return checked((e.X >= HorizontalPositiontoDisplay(nLeft(note.ColumnIndex), xHS) + 1) & (e.X <= HorizontalPositiontoDisplay(nLeft(note.ColumnIndex) + GetColumnWidth(note.ColumnIndex), xHS) - 1) & (e.Y >= NoteRowToPanelHeight(Conversions.ToDouble(Operators.AddObject(note.VPosition, Interaction.IIf(NTInput, note.Length, 0))), xVS, xHeight) - vo.kHeight)) & (e.Y <= NoteRowToPanelHeight(note.VPosition, xVS, xHeight));
    }

    private void PMainInMouseEnter(object sender, EventArgs e)
    {
        spMouseOver = Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null));
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
        SelectedNotes = new Note[0];
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
        int num = Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null));
        long num2 = PanelHScroll[num];
        long num3 = PanelVScroll[num];
        int num4 = spMain[num].Height;
        int num5 = spMain[num].Width;
        checked
        {
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
                                        bool flag3 = (e.Y >= checked(num7 - vo.kHeight) || flag2) & PanelKeyStates.ModifierLongNoteActive();
                                        flag = flag & (flag2 == bAdjustUpper) & (flag3 == bAdjustLength);
                                        bAdjustUpper = flag2;
                                        bAdjustLength = flag3;
                                    }
                                    break;
                                }
                            }
                        }
                        bool @checked = TBTimeSelect.Checked;
                        if (unchecked(TBSelect.Checked || @checked))
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
                            TempVPosition = ((float)num4 - (float)num3 * gxHeight - (float)e.Y - 1f) / gxHeight;
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
                        TempVPosition = ((float)num4 - (float)num3 * gxHeight - (float)e.Y - 1f) / gxHeight;
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
    }

    private void UpdateSelectedNotes(double xHeight, double xvs, double xhs, MouseEventArgs e)
    {
        int num = Information.UBound(Notes);
        checked
        {
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
    }

    private void OnPanelMousePan(MouseEventArgs e)
    {
        if (MiddleButtonMoveMethod != 1)
        {
            return;
        }
        checked
        {
            int num = (int)Math.Round((float)tempV + (float)(tempY - e.Y) / gxHeight);
            int num2 = (int)Math.Round((float)tempH + (float)(tempX - e.X) / gxWidth);
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
    }

    private void OnTimeSelectClick(double xHeight, double xHS, double xvs, MouseEventArgs e)
    {
        int num = -1;
        checked
        {
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
                        double num2 = (xHeight - xvs * (double)gxHeight - (double)e.Y - 1.0) / (double)gxHeight;
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
                        vSelHalf = (xHeight - xvs * (double)gxHeight - (double)e.Y - 1.0) / (double)gxHeight;
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
                        vSelLength = (xHeight - xvs * (double)gxHeight - (double)e.Y - 1.0) / (double)gxHeight;
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
                            vSelLength = (xHeight - xvs * (double)gxHeight - (double)e.Y - 1.0) / (double)gxHeight;
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
                double num3 = (xHeight - xvs * (double)gxHeight - (double)e.Y - 1.0) / (double)gxHeight;
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
    }

    private void OnAdjustUpperEnd(double dVPosition)
    {
        double num = 0.0;
        double num2 = 191999.0;
        int num3 = Information.UBound(Notes);
        checked
        {
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
    }

    private void OnAdjustLowerEnd(double dVPosition)
    {
        double num = 0.0;
        double num2 = 0.0;
        int num3 = Information.UBound(Notes);
        checked
        {
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
        checked
        {
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
        }
        if ((!DuplicatedSelectedNotes & (checked(num5 - num6) == 0)) && num2 - num7 - num8 == 0.0)
        {
            return;
        }
        UndoRedo.LinkedURCmd BaseUndo = null;
        UndoRedo.LinkedURCmd BaseRedo = new UndoRedo.Void();
        UndoRedo.LinkedURCmd linkedURCmd = BaseRedo;
        checked
        {
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
    }

    private void OnWriteModeMouseMove(int xHeight, long xVS, MouseEventArgs e)
    {
        if (SelectedNotes.Length == 0)
        {
            return;
        }
        int num = Information.UBound(Notes);
        int num2 = default(int);
        for (int i = 1; i <= num; i = checked(i + 1))
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
            notes[num3].VPosition = notes[num3].VPosition + notes[num3].Length;
            notes[num3].Length = notes[num3].Length * -1.0;
        }
        else if (!bAdjustUpper && Operators.ConditionalCompareObjectGreater(objectValue, notes[num3].VPosition + notes[num3].Length, TextCompare: false))
        {
            bAdjustUpper = true;
            notes[num3].VPosition = notes[num3].VPosition + notes[num3].Length;
            notes[num3].Length = notes[num3].Length * -1.0;
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
            notes[num3].Length = notes[num3].Length + notes[num3].VPosition;
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
        checked
        {
            int num = (int)Math.Round((float)e.X / gxWidth + (float)xHS);
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
    }

    private void UpdateSelectionBox(long xHS, long xVS, int xHeight)
    {
        checked
        {
            Rectangle rect = new Rectangle(Conversions.ToInteger(Interaction.IIf(pMouseMove.X > LastMouseDownLocation.X, LastMouseDownLocation.X, pMouseMove.X)), Conversions.ToInteger(Interaction.IIf(pMouseMove.Y > LastMouseDownLocation.Y, LastMouseDownLocation.Y, pMouseMove.Y)), (int)Math.Round(Math.Abs(pMouseMove.X - LastMouseDownLocation.X)), (int)Math.Round(Math.Abs(pMouseMove.Y - LastMouseDownLocation.Y)));
            int num = Information.UBound(Notes);
            for (int i = 1; i <= num; i++)
            {
                if (new Rectangle(HorizontalPositiontoDisplay(nLeft(Notes[i].ColumnIndex), xHS) + 1, NoteRowToPanelHeight(Conversions.ToDouble(Operators.AddObject(Notes[i].VPosition, Interaction.IIf(NTInput, Notes[i].Length, 0))), xVS, xHeight) - vo.kHeight, (int)Math.Round((float)GetColumnWidth(Notes[i].ColumnIndex) * gxWidth - 2f), Conversions.ToInteger(Operators.AddObject(vo.kHeight, Interaction.IIf(NTInput, Notes[i].Length * (double)gxHeight, 0)))).IntersectsWith(rect))
                {
                    Notes[i].Selected = !Notes[i].TempSelected & nEnabled(Notes[i].ColumnIndex);
                }
                else
                {
                    Notes[i].Selected = Notes[i].TempSelected & nEnabled(Notes[i].ColumnIndex);
                }
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
        checked
        {
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
    }

    private void DrawNoteHoverHighlight(int iI, long xHS, long xVS, int xHeight, int foundNoteIndex)
    {
        int num = HorizontalPositiontoDisplay(nLeft(Notes[foundNoteIndex].ColumnIndex), xHS);
        checked
        {
            int num2 = Conversions.ToInteger(Interaction.IIf(!NTInput | (bAdjustLength & !bAdjustUpper), NoteRowToPanelHeight(Notes[foundNoteIndex].VPosition, xVS, xHeight) - vo.kHeight - 1, NoteRowToPanelHeight(Notes[foundNoteIndex].VPosition + Notes[foundNoteIndex].Length, xVS, xHeight) - vo.kHeight - 1));
            int num3 = (int)Math.Round((float)GetColumnWidth(Notes[foundNoteIndex].ColumnIndex) * gxWidth + 1f);
            int num4 = Conversions.ToInteger(Interaction.IIf(!NTInput | bAdjustLength, vo.kHeight + 3, Notes[foundNoteIndex].Length * (double)gxHeight + (double)vo.kHeight + 3.0));
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
    }

    private int GetColumnAtX(int x, int xHS)
    {
        int i = 0;
        checked
        {
            int num = (int)Math.Round((float)x / gxWidth + (float)xHS);
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
    }

    private object GetColumnAtEvent(MouseEventArgs e, int xHS)
    {
        return GetColumnAtX(e.X, xHS);
    }

    private void PMain_Scroll(object sender, MouseEventArgs e)
    {
        if (MyProject.Computer.Keyboard.CtrlKeyDown)
        {
            double val = Math.Round((double)CGHeight2.Value + (double)e.Delta / 120.0);
            CGHeight2.Value = checked((int)Math.Round(Math.Min(CGHeight2.Maximum, Math.Max(CGHeight2.Minimum, val))));
            CGHeight.Value = new decimal((double)CGHeight2.Value / 4.0);
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
        SelectedNotes = new Note[0];
        int num = Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null));
        checked
        {
            if (MiddleButtonClicked && e.Button == MouseButtons.Middle && Math.Pow(MiddleButtonLocation.X - Cursor.Position.X, 2.0) + Math.Pow(MiddleButtonLocation.Y - Cursor.Position.Y, 2.0) >= (double)vo.MiddleDeltaRelease)
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
                    double num3 = Conversions.ToDouble(Operators.DivideObject(Operators.SubtractObject(Operators.SubtractObject(Operators.SubtractObject(NewLateBinding.LateGet(sender, null, "Height", new object[0], null, null, null), (float)PanelVScroll[num] * gxHeight), e.Y), 1), gxHeight));
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
                            string prompt = Strings.Messages.PromptEnterNumeric;
                            if (Operators.ConditionalCompareObjectEqual(objectValue, 2, TextCompare: false))
                            {
                                prompt = Strings.Messages.PromptEnterBPM;
                            }
                            if (Operators.ConditionalCompareObjectEqual(objectValue, 3, TextCompare: false))
                            {
                                prompt = Strings.Messages.PromptEnterSTOP;
                            }
                            if (Operators.ConditionalCompareObjectEqual(objectValue, 1, TextCompare: false))
                            {
                                prompt = Strings.Messages.PromptEnterSCROLL;
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
    }

    private void PMainInMouseWheel(object sender, MouseEventArgs e)
    {
        if (MiddleButtonClicked)
        {
            MiddleButtonClicked = false;
        }
        checked
        {
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
    }

    private void PMainInPaint(object sender, PaintEventArgs e)
    {
        RefreshPanel(Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null)), e.ClipRectangle);
    }

    private void BVCCalculate_Click(object sender, EventArgs e)
    {
        if (TBTimeSelect.Checked)
        {
            SortByVPositionInsertion();
            BPMChangeByValue(checked((int)Math.Round(Conversion.Val(TVCBPM.Text) * 10000.0)));
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
            checked
            {
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
                            Notes[i].Value = (long)Math.Round((double)Notes[i].Value * xRatio);
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
                        notes[i].VPosition = notes[i].VPosition + (xRatio - 1.0) * (num2 - num);
                    }
                    Note note = new Note(2, num, (long)Math.Round((double)num4 * xRatio));
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
                                    Notes[i].Value = Conversions.ToLong(Interaction.IIf((double)Notes[i].Value * xRatio <= 655359999.0, (double)Notes[i].Value * xRatio, 655359999));
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
                                    Notes[i].Value = Conversions.ToLong(Interaction.IIf((double)Notes[i].Value * xRatio <= 655359999.0, (double)Notes[i].Value * xRatio, 655359999));
                                }
                            }
                            Note[] notes = Notes;
                            notes[i].Length = Conversions.ToDouble(Operators.AddObject(notes[i].Length, Operators.MultiplyObject(Operators.SubtractObject(Interaction.IIf(num2 < Notes[i].Length + Notes[i].VPosition, num2, Notes[i].Length + Notes[i].VPosition), Notes[i].VPosition), xRatio - 1.0)));
                            Notes[i].VPosition = (Notes[i].VPosition - num) * xRatio + num;
                        }
                        else
                        {
                            Note[] notes = Notes;
                            notes[i].VPosition = notes[i].VPosition + (num2 - num) * (xRatio - 1.0);
                        }
                    }
                    if (flag)
                    {
                        Note note = new Note(2, num, (long)Math.Round((double)num4 * xRatio));
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
                checked
                {
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
                                Notes[i].Value = (long)Math.Round((double)Notes[i].Value * num8);
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
                                Notes[i].Value = Conversions.ToLong(Interaction.IIf((double)Notes[i].Value * num9 <= 655359999.0, (double)Notes[i].Value * num9, 655359999));
                            }
                            Notes[i].VPosition = (Notes[i].VPosition - num2) * num9 + num2 + dVPosition;
                        }
                        num7 = num4;
                        num11 = i;
                        Note note = new Note(2, num, (long)Math.Round((double)num5 * num8));
                        AddNote(note, xSelected: false, OverWrite: true, SortAndUpdatePairing: false);
                        note = new Note(2, num2 + dVPosition, (long)Math.Round((double)num6 * num9));
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
                                        Notes[i].Value = (long)Math.Round((double)Notes[i].Value * num8);
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
                                        Notes[i].Value = (long)Math.Round((double)Notes[i].Value * num9);
                                    }
                                    else
                                    {
                                        Notes[i].Value = (long)Math.Round((double)Notes[i].Value * num8);
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
                                    notes[i].Length = notes[i].Length * num8;
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
                                        Notes[i].Value = Conversions.ToLong(Interaction.IIf((double)Notes[i].Value * num9 <= 655359999.0, (double)Notes[i].Value * num9, 655359999));
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
                                    notes[i].Length = notes[i].Length * num9;
                                }
                                Notes[i].VPosition = (Notes[i].VPosition - num2) * num9 + num2 + dVPosition;
                            }
                        }
                        if (flag)
                        {
                            Note note = new Note(2, num, (long)Math.Round((double)num5 * num8));
                            AddNote(note, xSelected: false, OverWrite: true, SortAndUpdatePairing: false);
                        }
                        if (flag2)
                        {
                            Note note = new Note(2, num2 + dVPosition, (long)Math.Round((double)num6 * num9));
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
        checked
        {
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
                num4 += (array[i + 1] - array[i]) / (double)array2[i];
            }
            num4 = (num3 - num) / num4;
            if ((num3 - num) / num4 <= (num2 - num) / (double)xValue)
            {
                double num11 = (num2 - num) * num4 / (num3 - num) / 10000.0;
                Interaction.MsgBox("Please enter a value that is greater than " + Conversions.ToString(num11) + ".", MsgBoxStyle.Critical, Strings.Messages.Err);
                return;
            }
            double num12 = num4 * (num2 - num) - (double)xValue * (num3 - num);
            if (num12 == 0.0)
            {
                return;
            }
            double num13 = (num2 - num3) * (double)xValue / num12 * num4;
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
                            num17 += (array[j + 1] - array[j]) / (double)array2[j];
                        }
                        num17 += (vPosition - array[j]) / (double)array2[j];
                        if (num17 - (num2 - num) / (double)xValue > 0.0)
                        {
                            Notes[i].VPosition = (num17 - (num2 - num) / (double)xValue) * num13 + num2;
                        }
                        else
                        {
                            Notes[i].VPosition = num17 * (double)xValue + num;
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
                            num21 += (array[j + 1] - array[j]) / (double)array2[j];
                        }
                        num21 += (vPosition2 - array[j]) / (double)array2[j];
                        if (num21 - (num2 - num) / (double)xValue > 0.0)
                        {
                            Notes[i].VPosition = (num21 - (num2 - num) / (double)xValue) * num13 + num2;
                        }
                        else
                        {
                            Notes[i].VPosition = num21 * (double)xValue + num;
                        }
                    }
                    if (Notes[i].Length == 0.0)
                    {
                        continue;
                    }
                    if (unchecked(num20 > num && num20 < num3))
                    {
                        double num21 = 0.0;
                        int j;
                        for (j = 0; j <= num7 && !(num20 < array[j + 1]); j++)
                        {
                            num21 += (array[j + 1] - array[j]) / (double)array2[j];
                        }
                        num21 += (num20 - array[j]) / (double)array2[j];
                        if (num21 - (num2 - num) / (double)xValue > 0.0)
                        {
                            Notes[i].Length = (num21 - (num2 - num) / (double)xValue) * num13 + num2 - Notes[i].VPosition;
                        }
                        else
                        {
                            Notes[i].Length = num21 * (double)xValue + num - Notes[i].VPosition;
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
                                   select (note);
        if (source.Count() > 0)
        {
            MessageBox.Show("The selected area can't have notes anywhere but at the start.");
            return;
        }
        RedoRemoveNoteAll(xSel: false, ref BaseUndo, ref BaseRedo);
        int num3 = Information.UBound(Notes);
        checked
        {
            for (int i = 1; i <= num3; i++)
            {
                if (Notes[i].VPosition > num2)
                {
                    Note[] notes = Notes;
                    notes[i].VPosition = notes[i].VPosition - vSelLength;
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
        checked
        {
            float[] array = new float[(int)codec.Length + 1];
            codec.ToSampleSource().Read(array, 0, (int)codec.Length);
            double num = (double)(codec.Length - 1) / (double)codec.WaveFormat.Channels;
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
    }

    private void BWClear_Click(object sender, EventArgs e)
    {
        wWavL = null;
        wWavR = null;
        TWFileName.Text = "(" + Strings.None + ")";
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
