using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace iBMSC
{
    public partial class MainWindow : Form
    {


        // Public Structure MARGINS
        // Public Left As Integer
        // Public Right As Integer
        // Public Top As Integer
        // Public Bottom As Integer
        // End Structure

        // <System.Runtime.InteropServices.DllImport("dwmapi.dll")> _
        // Public Shared Function DwmIsCompositionEnabled(ByRef en As Integer) As Integer
        // End Function
        // <System.Runtime.InteropServices.DllImport("dwmapi.dll")> _
        // Public Shared Function DwmExtendFrameIntoClientArea(ByVal hwnd As IntPtr, ByRef margin As MARGINS) As Integer
        // End Function
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        public static extern int ReleaseCapture();

        // Private Declare Auto Function GetWindowLong Lib "user32" (ByVal hWnd As IntPtr, ByVal nIndex As Integer) As Integer
        // Private Declare Auto Function SetWindowLong Lib "user32" (ByVal hWnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer
        // Private Declare Function SetWindowPos Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer
        // <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
        // Private Shared Function SetWindowText(ByVal hwnd As IntPtr, ByVal lpString As String) As Boolean
        // End Function

        // Private Const GWL_STYLE As Integer = -16
        // Private Const WS_CAPTION As Integer = &HC00000
        // Private Const SWP_NOSIZE As Integer = &H1
        // Private Const SWP_NOMOVE As Integer = &H2
        // Private Const SWP_NOZORDER As Integer = &H4
        // Private Const SWP_NOACTIVATE As Integer = &H10
        // Private Const SWP_FRAMECHANGED As Integer = &H20
        // Private Const SWP_REFRESH As Integer = SWP_NOZORDER Or SWP_NOSIZE Or SWP_NOMOVE Or SWP_NOACTIVATE Or SWP_FRAMECHANGED


        private double[] MeasureLength = new double[1000];
        private double[] MeasureBottom = new double[1000];

        public double MeasureUpper(int idx)
        {
            return MeasureBottom[idx] + MeasureLength[idx];
        }


        private iBMSC.Editor.Note[] Notes = new iBMSC.Editor.Note[] { new iBMSC.Editor.Note(MainWindow.niBPM, (double)-1, 1200000L, 0d, false) };
        private int[] mColumn = new int[1000];  // 0 = no column, 1 = 1 column, etc.
        private double GreatestVPosition;    // + 2000 = -VS.Minimum

        private int VSValue = 0; // Store value before ValueChange event
        private int HSValue = 0; // Store value before ValueChange event

        // Dim SortingMethod As Integer = 1
        private int MiddleButtonMoveMethod = 0;
        private System.Text.Encoding TextEncoding = System.Text.Encoding.UTF8;
        private string DispLang = "";     // Display Language
        private string[] Recent = new string[] { "", "", "", "", "" };
        private bool NTInput = true;
        private bool ShowFileName = false;

        private bool BeepWhileSaved = true;
        private bool BPMx1296 = false;
        private bool STOPx1296 = false;

        private bool IsInitializing = true;
        private bool FirstMouseEnter = true;

        private bool WAVMultiSelect = true;
        private bool WAVChangeLabel = true;
        private int BeatChangeMode = 0;

        // Dim FloatTolerance As Double = 0.0001R
        private double BMSGridLimit = 1.0d;

        private int LnObj = 0;    // 0 for none, 1-1295 for 01-ZZ

        // IO
        private string FileName = "Untitled.bms";
        // Dim TitlePath As New Drawing2D.GraphicsPath
        private string InitPath = "";
        private bool IsSaved = true;

        // Variables for Drag/Drop
        private string[] DDFileName = Array.Empty<string>();
        private string[] SupportedFileExtension = new string[] { ".bms", ".bme", ".bml", ".pms", ".txt", ".sm", ".ibmsc" };
        private string[] SupportedAudioExtension = new string[] { ".wav", ".mp3", ".ogg" };
        private string[] SupportedImageExtension = new string[] { ".bmp", ".png", ".jpg", ".jpeg", ".gif", ".mpg", ".mpeg", ".avi", ".m1v", ".m2v", ".m4v", ".mp4", ".webm", ".wmv" };

        // Variables for theme
        // Dim SaveTheme As Boolean = True

        // Variables for undo/redo
        private iBMSC.UndoRedo.LinkedURCmd[] sUndo = new iBMSC.UndoRedo.LinkedURCmd[100];
        private iBMSC.UndoRedo.LinkedURCmd[] sRedo = new iBMSC.UndoRedo.LinkedURCmd[100];
        private int sI = 0;

        // Variables for select tool
        private bool DisableVerticalMove = false;
        private int KMouseOver = -1;   // Mouse is on which note (for drawing green outline)
        private PointF LastMouseDownLocation = new Point(-1, -1);          // Mouse is clicked on which point (location for display) (for selection box)
        private PointF pMouseMove = new Point(-1, -1);          // Mouse is moved to which point   (location for display) (for selection box)
                                                                // Dim KMouseDown As Integer = -1   'Mouse is clicked on which note (for moving)
        private double deltaVPosition = 0d;   // difference between mouse and VPosition of K
        private bool bAdjustLength;     // If adjusting note length instead of moving it
        private bool bAdjustUpper;      // true = Adjusting upper end, false = adjusting lower end
        private bool bAdjustSingle;     // true if there is only one note to be adjusted
        private int tempY;
        private int tempV;
        private int tempX;
        private int tempH;
        private Point MiddleButtonLocation = new Point(0, 0);
        private bool MiddleButtonClicked = false;
        private Point MouseMoveStatus = new Point(0, 0);  // mouse is moved to which point (For Status Panel)
                                                          // Dim uCol As Integer         'temp variables for undo, original enabled columnindex
                                                          // Dim uVPos As Double         'temp variables for undo, original vposition
                                                          // Dim uPairWithI As Double    'temp variables for undo, original note length
        private bool uAdded;       // temp variables for undo, if undo command is added
                                   // Dim uNote As Note           'temp variables for undo, original note
        private iBMSC.Editor.Note[] SelectedNotes = new iBMSC.Editor.Note[0];        // temp notes for undo
        private bool ctrlPressed = false;          // Indicates if the CTRL key is pressed while mousedown
        private bool DuplicatedSelectedNotes = false;     // Indicates if duplicate notes of select/unselect note

        // Variables for write tool
        private bool ShouldDrawTempNote = false;
        private int SelectedColumn = -1;
        private double TempVPosition = -1.0d;
        private double TempLength = 0.0d;

        // Variables for post effects tool
        private double vSelStart = 192.0d;
        private double vSelLength = 0.0d;
        private double vSelHalf = 0.0d;
        private int vSelMouseOverLine = 0;  // 0 = nothing, 1 = start, 2 = half, 3 = end
        private bool vSelAdjust = false;
        private iBMSC.Editor.Note[] vSelK = Array.Empty<iBMSC.Editor.Note>();
        private double vSelPStart = 192.0d;
        private double vSelPLength = 0.0d;
        private double vSelPHalf = 0.0d;

        // Variables for Full-Screen Mode
        private bool isFullScreen = false;
        private FormWindowState previousWindowState = FormWindowState.Normal;
        private Rectangle previousWindowPosition = new Rectangle(0, 0, 0, 0);

        // Variables misc
        private double menuVPosition = 0.0d;
        private int tempResize = 0;

        // ----AutoSave Options
        private string PreviousAutoSavedFileName = "";
        private int AutoSaveInterval = 120000;

        // ----ErrorCheck Options
        private bool ErrorCheck = true;

        // ----Header Options
        private string[] hWAV = new string[1296];
        private string[] hBMP = new string[1296];
        private long[] hBPM = new long[1296];   // x10000
        private long[] hSTOP = new long[1296];
        private long[] hSCROLL = new long[1296];

        // ----Grid Options
        private bool gSnap = true;
        private bool gShowGrid = true; // Grid
        private bool gShowSubGrid = true; // Sub
        private bool gShowBG = true; // BG Color
        private bool gShowMeasureNumber = true; // Measure Label
        private bool gShowVerticalLine = true; // Vertical
        private bool gShowMeasureBar = true; // Measure Barline
        private bool gShowC = true; // Column Caption
        private int gDivide = 16;
        private int gSub = 4;
        private int gSlash = 192;
        private float gxHeight = 1.0f;
        private float gxWidth = 1.0f;
        private int gWheel = 96;
        private int gPgUpDn = 384;

        private bool gDisplayBGAColumn = true;
        private bool gSCROLL = true;
        private bool gSTOP = true;
        private bool gBPM = true;
        // Dim gA8 As Boolean = False
        private int iPlayer = 0;
        private int gColumns = 46;

        // ----Visual Options
        private iBMSC.Editor.visualSettings vo = new iBMSC.Editor.visualSettings();

        public void setVO(iBMSC.Editor.visualSettings xvo)
        {
            vo = xvo;
        }

        // ----Preview Options
        public struct PlayerArguments
        {
            public string Path;
            public string aBegin;
            public string aHere;
            public string aStop;
            public PlayerArguments(string xPath, string xBegin, string xHere, string xStop)
            {
                Path = xPath;
                aBegin = xBegin;
                aHere = xHere;
                aStop = xStop;
            }
        }

        public PlayerArguments[] pArgs = new PlayerArguments[] { new PlayerArguments(@"<apppath>\uBMplay.exe", "-P -N0 \"<filename>\"", "-P -N<measure> \"<filename>\"", "-S"), new PlayerArguments(@"<apppath>\o2play.exe", "-P -N0 \"<filename>\"", "-P -N<measure> \"<filename>\"", "-S") };
        public int CurrentPlayer = 0;
        private bool PreviewOnClick = true;
        private bool PreviewErrorCheck = false;
        private bool ClickStopPreview = true;
        private string[] pTempFileNames = Array.Empty<string>();

        // ----Split Panel Options
        private float[] PanelWidth = new float[] { 0f, 100f, 0f };
        private int[] PanelHScroll = new int[] { 0, 0, 0 };
        private int[] PanelVScroll = new int[] { 0, 0, 0 };
        private bool[] spLock = new bool[] { false, false, false };
        private int[] spDiff = new int[] { 0, 0, 0 };
        private int PanelFocus = 1; // 0 = Left, 1 = Middle, 2 = Right
        private int spMouseOver = 1;

        private bool AutoFocusMouseEnter = false;
        private bool FirstClickDisabled = true;
        private bool tempFirstMouseDown = false;

        private Panel[] spMain = Array.Empty<Panel>();

        // ----Find Delete Replace Options
        private int fdriMesL;
        private int fdriMesU;
        private int fdriLblL;
        private int fdriLblU;
        private int fdriValL;
        private int fdriValU;
        private int[] fdriCol;


        public MainWindow()
        {
            InitializeComponent();
            iBMSC.Audio.Initialize();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xHPosition">Original horizontal position.</param>
        /// <param name="xHSVal">HS.Value</param>


        private int HorizontalPositiontoDisplay(int xHPosition, long xHSVal)
        {
            return (int)Math.Round(xHPosition * gxWidth - xHSVal * gxWidth);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xVPosition">Original vertical position.</param>
        /// <param name="xVSVal">VS.Value</param>
        /// <param name="xTHeight">Height of the panel. (DisplayRectangle, but not ClipRectangle)</param>


        private int NoteRowToPanelHeight(double xVPosition, long xVSVal, int xTHeight)
        {
            return xTHeight - (int)Math.Round((xVPosition + xVSVal) * gxHeight) - 1;
        }

        public int MeasureAtDisplacement(double xVPos)
        {
            // Return Math.Floor((xVPos + FloatTolerance) / 192)
            // Return Math.Floor(xVPos / 192)
            int xI1;
            for (xI1 = 1; xI1 <= 999; xI1++)
            {
                if (xVPos < MeasureBottom[xI1])
                    break;
            }
            return xI1 - 1;
        }

        private double GetMaxVPosition()
        {
            return MeasureUpper(999);
        }

        private double SnapToGrid(double xVPos)
        {
            double xOffset = MeasureBottom[MeasureAtDisplacement(xVPos)];
            double xRatio = 192.0d / gDivide;
            return Math.Floor((xVPos - xOffset) / xRatio) * xRatio + xOffset;
        }

        private void CalculateGreatestVPosition()
        {
            // If K Is Nothing Then Exit Sub
            int xI1;
            GreatestVPosition = 0d;

            if (NTInput)
            {
                for (xI1 = Information.UBound(Notes); xI1 >= 0; xI1 -= 1)
                {
                    if (Notes[xI1].VPosition + Notes[xI1].Length > GreatestVPosition)
                        GreatestVPosition = Notes[xI1].VPosition + Notes[xI1].Length;
                }
            }
            else
            {
                for (xI1 = Information.UBound(Notes); xI1 >= 0; xI1 -= 1)
                {
                    if (Notes[xI1].VPosition > GreatestVPosition)
                        GreatestVPosition = Notes[xI1].VPosition;
                }
            }

            int xI2 = -Conversions.ToInteger(Interaction.IIf(GreatestVPosition + 2000d > GetMaxVPosition(), GetMaxVPosition(), GreatestVPosition + 2000d));
            MainPanelScroll.Minimum = xI2;
            LeftPanelScroll.Minimum = xI2;
            RightPanelScroll.Minimum = xI2;
        }


        private void SortByVPositionInsertion() // Insertion Sort
        {
            if (Information.UBound(Notes) <= 0)
                return;
            iBMSC.Editor.Note xNote;
            int xI1;
            int xI2;
            var loopTo = Information.UBound(Notes);
            for (xI1 = 2; xI1 <= loopTo; xI1++)
            {
                xNote = Notes[xI1];
                for (xI2 = xI1 - 1; xI2 >= 1; xI2 -= 1)
                {
                    if (Notes[xI2].VPosition > xNote.VPosition)
                    {
                        Notes[xI2 + 1] = Notes[xI2];
                        // If KMouseDown = xI2 Then KMouseDown += 1
                        if (xI2 == 1)
                        {
                            Notes[xI2] = xNote;
                            // If KMouseDown = xI1 Then KMouseDown = xI2
                            break;
                        }
                    }
                    else
                    {
                        Notes[xI2 + 1] = xNote;
                        // If KMouseDown = xI1 Then KMouseDown = xI2 + 1
                        break;
                    }
                }
            }

        }

        private void SortByVPositionQuick(int xMin, int xMax) // Quick Sort
        {
            iBMSC.Editor.Note xNote;
            int iHi;
            int iLo;
            int xI1;

            // If min >= max, the list contains 0 or 1 items so it is sorted.
            if (xMin >= xMax)
                return;

            // Pick the dividing value.
            xI1 = (int)Math.Round((xMax - xMin) / 2d) + xMin;
            xNote = Notes[xI1];

            // Swap it to the front.
            Notes[xI1] = Notes[xMin];

            iLo = xMin;
            iHi = xMax;
            do
            {
                // Look down from hi for a value < med_value.
                while (Notes[iHi].VPosition >= xNote.VPosition)
                {
                    iHi = iHi - 1;
                    if (iHi <= iLo)
                        break;
                }
                if (iHi <= iLo)
                {
                    Notes[iLo] = xNote;
                    break;
                }

                // Swap the lo and hi values.
                Notes[iLo] = Notes[iHi];

                // Look up from lo for a value >= med_value.
                iLo = iLo + 1;
                while (Notes[iLo].VPosition < xNote.VPosition)
                {
                    iLo = iLo + 1;
                    if (iLo >= iHi)
                        break;
                }
                if (iLo >= iHi)
                {
                    iLo = iHi;
                    Notes[iHi] = xNote;
                    break;
                }

                // Swap the lo and hi values.
                Notes[iHi] = Notes[iLo];
            }
            while (true);

            // Sort the two sublists.
            SortByVPositionQuick(xMin, iLo - 1);
            SortByVPositionQuick(iLo + 1, xMax);
        }

        private void SortByVPositionQuick3(int xMin, int xMax)
        {
            int xxMin;
            int xxMax;
            int xxMid;
            iBMSC.Editor.Note xNote;
            iBMSC.Editor.Note xNoteMid;
            int xI1;
            int xI2;
            int xI3;

            // If xMax = 0 Then
            // xMin = LBound(K1)
            // xMax = UBound(K1)
            // End If
            xxMin = xMin;
            xxMax = xMax;
            xxMid = xMax - xMin + 1;
            xI1 = (int)Math.Round(Conversion.Int(xxMid * VBMath.Rnd())) + xMin;
            xI2 = (int)Math.Round(Conversion.Int(xxMid * VBMath.Rnd())) + xMin;
            xI3 = (int)Math.Round(Conversion.Int(xxMid * VBMath.Rnd())) + xMin;
            if (Notes[xI1].VPosition <= Notes[xI2].VPosition & Notes[xI2].VPosition <= Notes[xI3].VPosition)
            {
                xxMid = xI2;
            }
            else if (Notes[xI2].VPosition <= Notes[xI1].VPosition & Notes[xI1].VPosition <= Notes[xI3].VPosition)
            {
                xxMid = xI1;
            }
            else
            {
                xxMid = xI3;
            }
            xNoteMid = Notes[xxMid];
            do
            {
                while (Notes[xxMin].VPosition < xNoteMid.VPosition & xxMin < xMax)
                    xxMin = xxMin + 1;
                while (xNoteMid.VPosition < Notes[xxMax].VPosition & xxMax > xMin)
                    xxMax = xxMax - 1;
                if (xxMin <= xxMax)
                {
                    xNote = Notes[xxMin];
                    Notes[xxMin] = Notes[xxMax];
                    Notes[xxMax] = xNote;
                    xxMin = xxMin + 1;
                    xxMax = xxMax - 1;
                }
            }
            while (xxMin <= xxMax);
            if (xxMax - xMin < xMax - xxMin)
            {
                if (xMin < xxMax)
                    SortByVPositionQuick3(xMin, xxMax);
                if (xxMin < xMax)
                    SortByVPositionQuick3(xxMin, xMax);
            }
            else
            {
                if (xxMin < xMax)
                    SortByVPositionQuick3(xxMin, xMax);
                if (xMin < xxMax)
                    SortByVPositionQuick3(xMin, xxMax);
            }
        }


        private void UpdateMeasureBottom()
        {
            MeasureBottom[0] = 0.0d;
            for (int xI1 = 0; xI1 <= 998; xI1++)
                MeasureBottom[xI1 + 1] = MeasureBottom[xI1] + MeasureLength[xI1];
        }

        private bool PathIsValid(string sPath)
        {
            return File.Exists(sPath) | Directory.Exists(sPath);
        }

        public string PrevCodeToReal(string InitStr)
        {
            string xFileName = Conversions.ToString(Operators.ConcatenateObject(Interaction.IIf(!PathIsValid(FileName), Interaction.IIf(string.IsNullOrEmpty(InitPath), Application.ExecutablePath, InitPath), ExcludeFileName(FileName)), @"\___TempBMS.bms"));
            int xMeasure = MeasureAtDisplacement(Math.Abs(PanelVScroll[PanelFocus]));
            string xS1 = InitStr.Replace("<apppath>", Application.ExecutablePath);
            string xS2 = xS1.Replace("<measure>", xMeasure.ToString());
            string xS3 = xS2.Replace("<filename>", xFileName);
            return xS3;
        }

        private void SetFileName(string xFileName)
        {
            FileName = xFileName.Trim();
            InitPath = ExcludeFileName(FileName);
            SetIsSaved(IsSaved);
        }

        private void SetIsSaved(bool isSaved)
        {
            // pttl.Refresh()
            // pIsSaved.Visible = Not xBool
            Version appVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            string xVersion = Conversions.ToString(Operators.ConcatenateObject(appVersion.Major + "." + appVersion.Minor, Interaction.IIf(appVersion.Build == 0, "", "." + appVersion.Build)));
            Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Interaction.IIf(isSaved, "", "*"), GetFileName(FileName)), " - "), "iBMSC.My.MyProject.Application.Info.Title"), " "), xVersion));
            IsSaved = isSaved;
        }

        private void PreviewNote(string xFileLocation, bool bStop)
        {
            if (bStop)
            {
                iBMSC.Audio.StopPlaying();
            }
            iBMSC.Audio.Play(xFileLocation);
        }

        private void AddNote(iBMSC.Editor.Note note, bool xSelected = false, bool OverWrite = true, bool SortAndUpdatePairing = true)
        {

            if (note.VPosition < 0d | note.VPosition >= GetMaxVPosition())
                return;

            int xI1 = 1;

            if (OverWrite)
            {
                while (xI1 <= Information.UBound(Notes))
                {
                    if (Notes[xI1].VPosition == note.VPosition & Notes[xI1].ColumnIndex == note.ColumnIndex)
                    {
                        RemoveNote(xI1);
                    }
                    else
                    {
                        xI1 += 1;
                    }
                }
            }

            Array.Resize(ref Notes, Information.UBound(Notes) + 1 + 1);
            note.Selected = note.Selected & this.nEnabled(note.ColumnIndex);
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
            int xI2;

            if (TBWavIncrease.Checked)
            {
                if (Notes[I].Value == (long)(LWAV.SelectedIndex * 10000))
                {
                    this.DecreaseCurrentWav();
                }
            }

            var loopTo = Information.UBound(Notes);
            for (xI2 = I + 1; xI2 <= loopTo; xI2++)
                Notes[xI2 - 1] = Notes[xI2];
            Array.Resize(ref Notes, Information.UBound(Notes));
            if (SortAndUpdatePairing)
            {
                SortByVPositionInsertion();
                UpdatePairing();
            }

        }

        private void AddNotesFromClipboard(bool xSelected = true, bool SortAndUpdatePairing = true)
        {
            var xStrLine = Clipboard.GetText().Split(Constants.vbCrLf);

            int xI1;
            var loopTo = Information.UBound(Notes);
            for (xI1 = 0; xI1 <= loopTo; xI1++)
                Notes[xI1].Selected = false;

            long xVS = PanelVScroll[PanelFocus];
            double xTempVP;
            var xKbu = Notes;

            if (xStrLine[0] == "iBMSC Clipboard Data")
            {
                if (NTInput)
                    Array.Resize(ref Notes, 1);

                // paste
                string[] xStrSub;
                var loopTo1 = Information.UBound(xStrLine);
                for (xI1 = 1; xI1 <= loopTo1; xI1++)
                {
                    if (string.IsNullOrEmpty(xStrLine[xI1].Trim()))
                        continue;
                    xStrSub = xStrLine[xI1].Split(" ");
                    xTempVP = Conversion.Val(xStrSub[1]) + MeasureBottom[MeasureAtDisplacement(-xVS) + 1];
                    if (Information.UBound(xStrSub) == 5 & xTempVP >= 0d & xTempVP < GetMaxVPosition())
                    {
                        Array.Resize(ref Notes, Information.UBound(Notes) + 1 + 1);
                        {
                            ref var withBlock = ref Notes[Information.UBound(Notes)];
                            withBlock.ColumnIndex = (int)Math.Round(Conversion.Val(xStrSub[0]));
                            withBlock.VPosition = xTempVP;
                            withBlock.Value = (long)Math.Round(Conversion.Val(xStrSub[2]));
                            withBlock.LongNote = Conversions.ToBoolean(Conversion.Val(xStrSub[3]));
                            withBlock.Hidden = Conversions.ToBoolean(Conversion.Val(xStrSub[4]));
                            withBlock.Landmine = Conversions.ToBoolean(Conversion.Val(xStrSub[5]));
                            withBlock.Selected = xSelected;
                        }
                    }
                }

                // convert
                if (NTInput)
                {
                    ConvertBMSE2NT();

                    var loopTo2 = Information.UBound(Notes);
                    for (xI1 = 1; xI1 <= loopTo2; xI1++)
                        Notes[xI1 - 1] = Notes[xI1];
                    Array.Resize(ref Notes, Information.UBound(Notes));

                    var xKn = Notes;
                    Notes = xKbu;

                    int xIStart = Notes.Length;
                    Array.Resize(ref Notes, Information.UBound(Notes) + xKn.Length + 1);

                    var loopTo3 = Information.UBound(Notes);
                    for (xI1 = xIStart; xI1 <= loopTo3; xI1++)
                        Notes[xI1] = xKn[xI1 - xIStart];
                }
            }

            else if (xStrLine[0] == "iBMSC Clipboard Data xNT")
            {
                if (!NTInput)
                    Array.Resize(ref Notes, 1);

                // paste
                string[] xStrSub;
                var loopTo4 = Information.UBound(xStrLine);
                for (xI1 = 1; xI1 <= loopTo4; xI1++)
                {
                    if (string.IsNullOrEmpty(xStrLine[xI1].Trim()))
                        continue;
                    xStrSub = xStrLine[xI1].Split(" ");
                    xTempVP = Conversion.Val(xStrSub[1]) + MeasureBottom[MeasureAtDisplacement(-xVS) + 1];
                    if (Information.UBound(xStrSub) == 5 & xTempVP >= 0d & xTempVP < GetMaxVPosition())
                    {
                        Array.Resize(ref Notes, Information.UBound(Notes) + 1 + 1);
                        {
                            ref var withBlock1 = ref Notes[Information.UBound(Notes)];
                            withBlock1.ColumnIndex = (int)Math.Round(Conversion.Val(xStrSub[0]));
                            withBlock1.VPosition = xTempVP;
                            withBlock1.Value = (long)Math.Round(Conversion.Val(xStrSub[2]));
                            withBlock1.Length = Conversion.Val(xStrSub[3]);
                            withBlock1.Hidden = Conversions.ToBoolean(Conversion.Val(xStrSub[4]));
                            withBlock1.Landmine = Conversions.ToBoolean(Conversion.Val(xStrSub[5]));
                            withBlock1.Selected = xSelected;
                        }
                    }
                }

                // convert
                if (!NTInput)
                {
                    ConvertNT2BMSE();

                    var loopTo5 = Information.UBound(Notes);
                    for (xI1 = 1; xI1 <= loopTo5; xI1++)
                        Notes[xI1 - 1] = Notes[xI1];
                    Array.Resize(ref Notes, Information.UBound(Notes));

                    var xKn = Notes;
                    Notes = xKbu;

                    int xIStart = Notes.Length;
                    Array.Resize(ref Notes, Information.UBound(Notes) + xKn.Length + 1);

                    var loopTo6 = Information.UBound(Notes);
                    for (xI1 = xIStart; xI1 <= loopTo6; xI1++)
                        Notes[xI1] = xKn[xI1 - xIStart];
                }
            }

            else if (xStrLine[0] == "BMSE ClipBoard Object Data Format")
            {
                if (NTInput)
                    Array.Resize(ref Notes, 1);

                // paste
                var loopTo7 = Information.UBound(xStrLine);
                for (xI1 = 1; xI1 <= loopTo7; xI1++)
                {
                    // zdr: holy crap this is obtuse
                    string posStr = xStrLine[xI1].Substring(5, 7);
                    double vPos = Conversion.Val(posStr) + MeasureBottom[MeasureAtDisplacement(-xVS) + 1];

                    string bmsIdent = xStrLine[xI1].Substring(1, 3);
                    var lineCol = this.BMSEChannelToColumnIndex(bmsIdent);

                    double Value = Conversion.Val(xStrLine[xI1].Substring(12)) * 10000d;

                    string attribute = xStrLine[xI1].Substring(4, 1);

                    var validCol = Operators.AndObject(xStrLine[xI1].Length > 11, Operators.ConditionalCompareObjectGreater(lineCol, 0, false));
                    bool inRange = vPos >= 0d & vPos < GetMaxVPosition();
                    if (Conversions.ToBoolean(Operators.AndObject(validCol, inRange)))
                    {
                        Array.Resize(ref Notes, Information.UBound(Notes) + 1 + 1);

                        {
                            ref var withBlock2 = ref Notes[Information.UBound(Notes)];
                            withBlock2.ColumnIndex = Conversions.ToInteger(lineCol);
                            withBlock2.VPosition = vPos;
                            withBlock2.Value = (long)Math.Round(Value);
                            withBlock2.LongNote = attribute == "2";
                            withBlock2.Hidden = attribute == "1";
                            withBlock2.Selected = xSelected & this.nEnabled(withBlock2.ColumnIndex);
                        }
                    }
                }

                // convert
                if (NTInput)
                {
                    ConvertBMSE2NT();

                    var loopTo8 = Information.UBound(Notes);
                    for (xI1 = 1; xI1 <= loopTo8; xI1++)
                        Notes[xI1 - 1] = Notes[xI1];
                    Array.Resize(ref Notes, Information.UBound(Notes));

                    var xKn = Notes;
                    Notes = xKbu;

                    int xIStart = Notes.Length;
                    Array.Resize(ref Notes, Information.UBound(Notes) + xKn.Length + 1);

                    var loopTo9 = Information.UBound(Notes);
                    for (xI1 = xIStart; xI1 <= loopTo9; xI1++)
                        Notes[xI1] = xKn[xI1 - xIStart];
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
            string xStrAll = Conversions.ToString(Operators.ConcatenateObject("iBMSC Clipboard Data", Interaction.IIf(NTInput, " xNT", "")));
            int xI1;
            double MinMeasure = 999d;

            var loopTo = Information.UBound(Notes);
            for (xI1 = 1; xI1 <= loopTo; xI1++)
            {
                if (Notes[xI1].Selected & (double)this.MeasureAtDisplacement(Notes[xI1].VPosition) < MinMeasure)
                    MinMeasure = this.MeasureAtDisplacement(Notes[xI1].VPosition);
            }
            MinMeasure = MeasureBottom[(int)Math.Round(MinMeasure)];

            if (!NTInput)
            {
                var loopTo1 = Information.UBound(Notes);
                for (xI1 = 1; xI1 <= loopTo1; xI1++)
                {
                    if (Notes[xI1].Selected)
                    {
                        xStrAll += Constants.vbCrLf + Notes[xI1].ColumnIndex.ToString() + " " + (Notes[xI1].VPosition - MinMeasure).ToString() + " " + Notes[xI1].Value.ToString() + " " + Conversions.ToInteger(Notes[xI1].LongNote).ToString() + " " + Conversions.ToInteger(Notes[xI1].Hidden).ToString() + " " + Conversions.ToInteger(Notes[xI1].Landmine).ToString();
                        Notes[xI1].Selected = !Unselect;
                    }
                }
            }

            else
            {
                var loopTo2 = Information.UBound(Notes);
                for (xI1 = 1; xI1 <= loopTo2; xI1++)
                {
                    if (Notes[xI1].Selected)
                    {
                        xStrAll += Constants.vbCrLf + Notes[xI1].ColumnIndex.ToString() + " " + (Notes[xI1].VPosition - MinMeasure).ToString() + " " + Notes[xI1].Value.ToString() + " " + Notes[xI1].Length.ToString() + " " + Conversions.ToInteger(Notes[xI1].Hidden).ToString() + " " + Conversions.ToInteger(Notes[xI1].Landmine).ToString();
                        Notes[xI1].Selected = !Unselect;
                    }
                }
            }

            Clipboard.SetText(xStrAll);
        }

        private void RemoveNotes(bool SortAndUpdatePairing = true)
        {
            if (Information.UBound(Notes) == 0)
                return;

            KMouseOver = -1;
            int xI1 = 1;
            int xI2;
            do
            {
                if (Notes[xI1].Selected)
                {
                    var loopTo = Information.UBound(Notes);
                    for (xI2 = xI1 + 1; xI2 <= loopTo; xI2++)
                        Notes[xI2 - 1] = Notes[xI2];
                    Array.Resize(ref Notes, Information.UBound(Notes));
                    xI1 = 0;
                }
                xI1 += 1;
            }
            while (xI1 < Information.UBound(Notes) + 1);
            if (SortAndUpdatePairing)
            {
                SortByVPositionInsertion();
                UpdatePairing();
            }
            CalculateTotalPlayableNotes();
        }

        private int EnabledColumnIndexToColumnArrayIndex(int cEnabled)
        {
            int xI1 = 0;
            do
            {
                if (xI1 >= gColumns)
                    break;
                if (!this.nEnabled(xI1))
                    cEnabled += 1;
                if (xI1 >= cEnabled)
                    break;
                xI1 += 1;
            }
            while (true);
            return cEnabled;
        }

        private int ColumnArrayIndexToEnabledColumnIndex(int cReal)
        {
            int xI1;
            var loopTo = cReal - 1;
            for (xI1 = 0; xI1 <= loopTo; xI1++)
            {
                if (!this.nEnabled(xI1))
                    cReal -= 1;
            }
            return cReal;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (pTempFileNames is not null)
            {
                foreach (string xStr in pTempFileNames)
                    File.Delete(xStr);
            }
            if (!string.IsNullOrEmpty(PreviousAutoSavedFileName))
                File.Delete(PreviousAutoSavedFileName);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsSaved)
            {
                string xStr = iBMSC.Strings.Messages.SaveOnExit;
                if (e.CloseReason == CloseReason.WindowsShutDown)
                    xStr = iBMSC.Strings.Messages.SaveOnExit1;
                if (e.CloseReason == CloseReason.TaskManagerClosing)
                    xStr = iBMSC.Strings.Messages.SaveOnExit2;

                var xResult = Interaction.MsgBox(xStr, MsgBoxStyle.YesNoCancel | MsgBoxStyle.Question, Text);

                if (xResult == MsgBoxResult.Yes)
                {
                    if (string.IsNullOrEmpty(ExcludeFileName(FileName)))
                    {
                        var xDSave = new SaveFileDialog();
                        xDSave.Filter = iBMSC.Strings.FileType._bms + "|*.bms;*.bme;*.bml;*.pms;*.txt|" + iBMSC.Strings.FileType.BMS + "|*.bms|" + iBMSC.Strings.FileType.BME + "|*.bme|" + iBMSC.Strings.FileType.BML + "|*.bml|" + iBMSC.Strings.FileType.PMS + "|*.pms|" + iBMSC.Strings.FileType.TXT + "|*.txt|" + iBMSC.Strings.FileType._all + "|*.*";
                        xDSave.DefaultExt = "bms";
                        xDSave.InitialDirectory = InitPath;

                        if (xDSave.ShowDialog() == DialogResult.Cancel)
                        {
                            e.Cancel = true;
                            return;
                        }
                        SetFileName(xDSave.FileName);
                    }
                    string xStrAll = this.SaveBMS();
                    File.WriteAllText(FileName, xStrAll, TextEncoding);
                    this.NewRecent(FileName);
                    if (BeepWhileSaved)
                        Interaction.Beep();
                }

                if (xResult == MsgBoxResult.Cancel)
                    e.Cancel = true;
            }

            if (!e.Cancel)
            {
                // If SaveTheme Then
                // My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\Skin.cff", SaveSkinCFF, False, System.Text.Encoding.Unicode)
                // Else
                // My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\Skin.cff", "", False, System.Text.Encoding.Unicode)
                // End If
                // 
                // My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\PlayerArgs.cff", SavePlayerCFF, False, System.Text.Encoding.Unicode)
                // My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\Config.cff", SaveCFF, False, System.Text.Encoding.Unicode)
                // My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\PreConfig.cff", "", False, System.Text.Encoding.Unicode)
                this.SaveSettings(Application.ExecutablePath + @"\iBMSC.Settings.xml", false);
            }
        }

        private string[] FilterFileBySupported(string[] xFile, string[] xFilter)
        {
            var xPath = new string[0];
            for (int xI1 = 0, loopTo = Information.UBound(xFile); xI1 <= loopTo; xI1++)
            {
                if (File.Exists(xFile[xI1]) & Array.IndexOf(xFilter, Path.GetExtension(xFile[xI1])) != -1)
                {
                    Array.Resize(ref xPath, Information.UBound(xPath) + 1 + 1);
                    xPath[Information.UBound(xPath)] = xFile[xI1];
                }

                if (Directory.Exists(xFile[xI1]))
                {
                    var xFileNames = new DirectoryInfo(xFile[xI1]).GetFiles();
                    foreach (FileInfo xStr in xFileNames)
                    {
                        if (Array.IndexOf(xFilter, xStr.Extension) == -1)
                            continue;
                        Array.Resize(ref xPath, Information.UBound(xPath) + 1 + 1);
                        xPath[Information.UBound(xPath)] = xStr.FullName;
                    }
                }
            }

            return xPath;
        }

        private void InitializeNewBMS()
        {
            // ReDim K(0)
            // With K(0)
            // .ColumnIndex = niBPM
            // .VPosition = -1
            // .LongNote = False
            // .Selected = False
            // .Value = 1200000
            // End With

            THTitle.Text = "";
            THArtist.Text = "";
            THGenre.Text = "";
            THBPM.Value = 120m;
            if (CHPlayer.SelectedIndex == -1)
                CHPlayer.SelectedIndex = 0;
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
            // THLnType.Text = "1"
            CHLnObj.SelectedIndex = 0;

            TExpansion.Text = "";

            LBeat.Items.Clear();
            for (int xI1 = 0; xI1 <= 999; xI1++)
            {
                MeasureLength[xI1] = 192.0d;
                MeasureBottom[xI1] = xI1 * 192.0d;
                LBeat.Items.Add(iBMSC.Editor.Functions.Add3Zeros(xI1) + ": 1 ( 4 / 4 )");
            }
        }

        private void InitializeOpenBMS()
        {
            CHPlayer.SelectedIndex = 0;
            // THLnType.Text = ""
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
            this.RefreshPanelAll();
        }

        private void Form1_DragLeave(object sender, EventArgs e)
        {
            DDFileName = new string[0];
            this.RefreshPanelAll();
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            DDFileName = new string[0];
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
                return;

            string[] xOrigPath = (string[])e.Data.GetData(DataFormats.FileDrop);
            var xPath = FilterFileBySupported(xOrigPath, SupportedFileExtension);
            if (xPath.Length > 0)
            {
                var xProg = new iBMSC.fLoadFileProgress(xPath, IsSaved);
                xProg.ShowDialog(this);
            }

            this.RefreshPanelAll();
        }

        private void setFullScreen(bool value)
        {
            if (value)
            {
                if (WindowState == FormWindowState.Minimized)
                    return;

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
            switch (e.KeyCode)
            {
                case Keys.F11:
                    {
                        setFullScreen(!isFullScreen);
                        break;
                    }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            this.RefreshPanelAll();
            POStatusRefresh();
        }

        internal void ReadFile(string xPath)
        {
            switch (Path.GetExtension(xPath).ToLower() ?? "")
            {
                case ".bms":
                case ".bme":
                case ".bml":
                case ".pms":
                case ".txt":
                    {
                        this.OpenBMS(File.ReadAllText(xPath, TextEncoding));
                        this.ClearUndo();
                        this.NewRecent(xPath);
                        SetFileName(xPath);
                        SetIsSaved(true);
                        break;
                    }

                case ".sm":
                    {
                        if (this.OpenSM(File.ReadAllText(xPath, TextEncoding)))
                            return;
                        InitPath = ExcludeFileName(xPath);
                        this.ClearUndo();
                        SetFileName("Untitled.bms");
                        SetIsSaved(false);
                        break;
                    }

                case ".ibmsc":
                    {
                        this.OpeniBMSC(xPath);
                        InitPath = ExcludeFileName(xPath);
                        this.NewRecent(xPath);
                        SetFileName("Imported_" + GetFileName(xPath));
                        SetIsSaved(false);
                        break;
                    }

            }
        }


        public double GCD(double NumA, double NumB)
        {
            double GCDRet = default;
            double xNMax = NumA;
            double xNMin = NumB;
            if (NumA < NumB)
            {
                xNMax = NumB;
                xNMin = NumA;
            }
            while (xNMin >= BMSGridLimit)
            {
                GCDRet = xNMax - Math.Floor(xNMax / xNMin) * xNMin;
                xNMax = xNMin;
                xNMin = GCDRet;
            }
            GCDRet = xNMax;
            return GCDRet;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr LoadCursorFromFile(string fileName);
        public static Cursor ActuallyLoadCursor(string path)
        {
            return new Cursor(LoadCursorFromFile(path));
        }

        private void Unload()
        {
            iBMSC.Audio.Finalize();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // On Error Resume Next
            TopMost = true;
            SuspendLayout();
            Visible = false;

            // POBMP.Dispose()
            // POBGA.Dispose()

            // Me.MaximizedBounds = Screen.GetWorkingArea(Me)
            // Me.Visible = False
            SetFileName(FileName);
            // Me.ShowCaption = False
            // SetWindowText(Me.Handle.ToInt32, FileName)

            InitializeNewBMS();
            // nBeatD.SelectedIndex = 4

            try
            {
                string xTempFileName = iBMSC.Editor.Functions.RandomFileName(".cur");
                File.WriteAllBytes(xTempFileName, iBMSC.Properties.Resources.CursorResizeDown);
                var xDownCursor = ActuallyLoadCursor(xTempFileName);
                File.WriteAllBytes(xTempFileName, iBMSC.Properties.Resources.CursorResizeLeft);
                var xLeftCursor = ActuallyLoadCursor(xTempFileName);
                File.WriteAllBytes(xTempFileName, iBMSC.Properties.Resources.CursorResizeRight);
                var xRightCursor = ActuallyLoadCursor(xTempFileName);
                File.Delete(xTempFileName);

                POWAVResizer.Cursor = xDownCursor;
                POBMPResizer.Cursor = xDownCursor;
                POBeatResizer.Cursor = xDownCursor;
                POExpansionResizer.Cursor = xDownCursor;

                POptionsResizer.Cursor = xLeftCursor;

                SpL.Cursor = xRightCursor;
                SpR.Cursor = xLeftCursor;
            }
            catch (Exception ex)
            {

            }

            spMain = new Panel[] { PMainInL, PMainIn, PMainInR };

            int xI1;

            sUndo[0] = new iBMSC.UndoRedo.NoOperation();
            sUndo[1] = new iBMSC.UndoRedo.NoOperation();
            sRedo[0] = new iBMSC.UndoRedo.NoOperation();
            sRedo[1] = new iBMSC.UndoRedo.NoOperation();
            sI = 0;

            LWAV.Items.Clear();
            LBMP.Items.Clear();
            for (xI1 = 1; xI1 <= 1295; xI1++)
            {
                LWAV.Items.Add(iBMSC.Editor.Functions.C10to36((long)xI1) + ":");
                LBMP.Items.Add(iBMSC.Editor.Functions.C10to36((long)xI1) + ":");
            }
            LWAV.SelectedIndex = 0;
            LBMP.SelectedIndex = 0;
            CHPlayer.SelectedIndex = 0;

            CalculateGreatestVPosition();
            TBLangRefresh_Click(TBLangRefresh, null);
            TBThemeRefresh_Click(TBThemeRefresh, null);

            POHeaderPart2.Visible = false;
            POGridPart2.Visible = false;
            POWaveFormPart2.Visible = false;

            if (File.Exists(Application.ExecutablePath + @"\iBMSC.Settings.xml"))
            {
                this.LoadSettings(Application.ExecutablePath + @"\iBMSC.Settings.xml");
                // Else
                // ---- Settings for first-time start-up ---------------------------------------------------------------------------
                // Me.LoadLocale(My.Application.Info.DirectoryPath & "\Data\chs.Lang.xml")
                // -----------------------------------------------------------------------------------------------------------------
            }
            // On Error GoTo 0
            SetIsSaved(true);

            var xStr = Environment.GetCommandLineArgs();
            // Dim xStr() As String = {Application.ExecutablePath, "C:\Users\User\Desktop\yang run xuan\SoFtwArES\Games\O2Mania\music\SHOOT!\shoot! -NM-.bms"}

            if (xStr.Length == 2)
            {
                ReadFile(xStr[1]);
                if (Path.GetExtension(xStr[1]).ToLower() == ".ibmsc" && GetFileName(xStr[1]).StartsWith("AutoSave_", true, null))
                    goto state1000;
            }

            // pIsSaved.Visible = Not IsSaved
            IsInitializing = false;

            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
                goto state1000;
            var xFiles = new DirectoryInfo(Application.ExecutablePath).GetFiles("AutoSave_*.IBMSC");
            if (xFiles is null || xFiles.Length == 0)
                goto state1000;

            // Me.TopMost = True
            if (Interaction.MsgBox(iBMSC.Strings.Messages.RestoreAutosavedFile.Replace("{}", xFiles.Length.ToString()), MsgBoxStyle.YesNo | MsgBoxStyle.MsgBoxSetForeground) == MsgBoxResult.Yes)
            {
                foreach (FileInfo xF in xFiles)
                    // MsgBox(xF.FullName)
                    Process.Start(Application.ExecutablePath, "\"" + xF.FullName + "\"");
            }

            foreach (FileInfo xF in xFiles)
            {
                Array.Resize(ref pTempFileNames, Information.UBound(pTempFileNames) + 1 + 1);
                pTempFileNames[Information.UBound(pTempFileNames)] = xF.FullName;
            }

        state1000:
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
            int i;
            int j;

            if (NTInput)
            {
                var loopTo = Information.UBound(Notes);
                for (i = 0; i <= loopTo; i++)
                {
                    Notes[i].HasError = false;
                    Notes[i].LNPair = 0;
                    if (Notes[i].Length < 0d)
                        Notes[i].Length = 0d;
                }

                var loopTo1 = Information.UBound(Notes);
                for (i = 1; i <= loopTo1; i++)
                {
                    if (Notes[i].Length != 0d)
                    {
                        var loopTo2 = Information.UBound(Notes);
                        for (j = i + 1; j <= loopTo2; j++)
                        {
                            if (Notes[j].VPosition > Notes[i].VPosition + Notes[i].Length)
                                break;
                            if (Notes[j].ColumnIndex == Notes[i].ColumnIndex)
                                Notes[j].HasError = true;
                        }
                    }
                    else
                    {
                        var loopTo3 = Information.UBound(Notes);
                        for (j = i + 1; j <= loopTo3; j++)
                        {
                            if (Notes[j].VPosition > Notes[i].VPosition)
                                break;
                            if (Notes[j].ColumnIndex == Notes[i].ColumnIndex)
                                Notes[j].HasError = true;
                        }

                        if (Notes[i].Value / 10000L == (long)LnObj && !this.IsColumnNumeric(Notes[i].ColumnIndex))
                        {
                            for (j = i - 1; j >= 1; j -= 1)
                            {
                                if (Notes[j].ColumnIndex != Notes[i].ColumnIndex)
                                    continue;
                                if (Notes[j].Hidden)
                                    continue;

                                if (Notes[j].Length != 0d || Notes[j].Value / 10000L == (long)LnObj)
                                {
                                    Notes[i].HasError = true;
                                }
                                else
                                {
                                    Notes[i].LNPair = j;
                                    Notes[j].LNPair = i;
                                }
                                break;
                            }
                            if (j == 0)
                            {
                                Notes[i].HasError = true;
                            }
                        }
                    }
                }
            }

            else
            {
                var loopTo4 = Information.UBound(Notes);
                for (i = 0; i <= loopTo4; i++)
                {
                    Notes[i].HasError = false;
                    Notes[i].LNPair = 0;
                }

                var loopTo5 = Information.UBound(Notes);
                for (i = 1; i <= loopTo5; i++)
                {

                    if (Notes[i].LongNote)
                    {
                        // LongNote: If overlapping a note, then error.
                        // Else if already matched by a LongNote below, then match it.
                        // Otherwise match anything above.
                        // If ShortNote above then error on above.
                        // If nothing above then error.
                        for (j = i - 1; j >= 1; j -= 1)
                        {
                            if (Notes[j].ColumnIndex != Notes[i].ColumnIndex)
                                continue;
                            if (Notes[j].VPosition == Notes[i].VPosition)
                            {
                                Notes[i].HasError = true;
                                goto EndSearch;
                            }
                            else if (Notes[j].LongNote & Notes[j].LNPair == i)
                            {
                                Notes[i].LNPair = j;
                                goto EndSearch;
                            }
                            else
                            {
                                break;
                            }
                        }

                        var loopTo6 = Information.UBound(Notes);
                        for (j = i + 1; j <= loopTo6; j++)
                        {
                            if (Notes[j].ColumnIndex != Notes[i].ColumnIndex)
                                continue;
                            Notes[i].LNPair = j;
                            Notes[j].LNPair = i;
                            if (!Notes[j].LongNote && Notes[j].Value / 10000L != (long)LnObj)
                            {
                                Notes[j].HasError = true;
                            }
                            break;
                        }

                        if (j == Information.UBound(Notes) + 1)
                        {
                            Notes[i].HasError = true;
                        }

                    EndSearch:
                        ;
                    }


                    else if (Notes[i].Value / 10000L == (long)LnObj & !this.IsColumnNumeric(Notes[i].ColumnIndex))
                    {
                        // LnObj: Match anything below.
                        // If matching a LongNote not matching back, then error on below.
                        // If overlapping a note, then error.
                        // If mathcing a LnObj below, then error on below.
                        // If nothing below, then error.
                        for (j = i - 1; j >= 1; j -= 1)
                        {
                            if (Notes[i].ColumnIndex != Notes[j].ColumnIndex)
                                continue;
                            if (Notes[j].LNPair != 0 & Notes[j].LNPair != i)
                            {
                                Notes[j].HasError = true;
                            }
                            Notes[i].LNPair = j;
                            Notes[j].LNPair = i;
                            if (Notes[i].VPosition == Notes[j].VPosition)
                            {
                                Notes[i].HasError = true;
                            }
                            if (Notes[j].Value / 10000L == (long)LnObj)
                            {
                                Notes[j].HasError = true;
                            }
                            break;
                        }

                        if (j == 0)
                        {
                            Notes[i].HasError = true;
                        }
                    }

                    else
                    {
                        // ShortNote: If overlapping a note, then error.
                        for (j = i - 1; j >= 1; j -= 1)
                        {
                            if (Notes[j].VPosition < Notes[i].VPosition)
                                break;
                            if (Notes[j].ColumnIndex != Notes[i].ColumnIndex)
                                continue;
                            Notes[i].HasError = true;
                            break;
                        }

                    }
                }


            }

            double currentMS = 0.0d;
            double currentBPM = (double)Notes[0].Value / 10000d;
            double currentBPMVPosition = 0.0d;
            var loopTo7 = Information.UBound(Notes);
            for (i = 1; i <= loopTo7; i++)
            {
                if (Notes[i].ColumnIndex == MainWindow.niBPM)
                {
                    currentMS += (Notes[i].VPosition - currentBPMVPosition) / currentBPM * 1250d;
                    currentBPM = (double)Notes[i].Value / 10000d;
                    currentBPMVPosition = Notes[i].VPosition;
                }
                // K(i).TimeOffset = currentMS + (K(i).VPosition - currentBPMVPosition) / currentBPM * 1250
            }
        }



        public void ExceptionSave(string Path)
        {
            this.SaveiBMSC(Path);
        }

        /// <summary>
        /// True if pressed cancel. False elsewise.
        /// </summary>
        /// <returns>True if pressed cancel. False elsewise.</returns>

        private bool ClosingPopSave()
        {
            if (!IsSaved)
            {
                var xResult = Interaction.MsgBox(iBMSC.Strings.Messages.SaveOnExit, MsgBoxStyle.YesNoCancel | MsgBoxStyle.Question, Text);

                if (xResult == MsgBoxResult.Yes)
                {
                    if (string.IsNullOrEmpty(ExcludeFileName(FileName)))
                    {
                        var xDSave = new SaveFileDialog();
                        xDSave.Filter = iBMSC.Strings.FileType._bms + "|*.bms;*.bme;*.bml;*.pms;*.txt|" + iBMSC.Strings.FileType.BMS + "|*.bms|" + iBMSC.Strings.FileType.BME + "|*.bme|" + iBMSC.Strings.FileType.BML + "|*.bml|" + iBMSC.Strings.FileType.PMS + "|*.pms|" + iBMSC.Strings.FileType.TXT + "|*.txt|" + iBMSC.Strings.FileType._all + "|*.*";
                        xDSave.DefaultExt = "bms";
                        xDSave.InitialDirectory = InitPath;

                        if (xDSave.ShowDialog() == DialogResult.Cancel)
                            return true;
                        SetFileName(xDSave.FileName);
                    }
                    string xStrAll = this.SaveBMS();
                    File.WriteAllText(FileName, xStrAll, TextEncoding);
                    this.NewRecent(FileName);
                    if (BeepWhileSaved)
                        Interaction.Beep();
                }

                if (xResult == MsgBoxResult.Cancel)
                    return true;
            }
            return false;
        }

        private void TBNew_Click(object sender, EventArgs e)
        {

            // KMouseDown = -1
            SelectedNotes = new iBMSC.Editor.Note[0];
            KMouseOver = -1;
            if (ClosingPopSave())
                return;

            this.ClearUndo();
            InitializeNewBMS();

            Notes = new iBMSC.Editor.Note[1];
            mColumn = new int[1000];
            hWAV = new string[1296];
            hBMP = new string[1296];
            hBPM = new long[1296];    // x10000
            hSTOP = new long[1296];
            hSCROLL = new long[1296];
            THGenre.Text = "";
            THTitle.Text = "";
            THArtist.Text = "";
            THPlayLevel.Text = "";

            {
                ref var withBlock = ref Notes[0];
                withBlock.ColumnIndex = MainWindow.niBPM;
                withBlock.VPosition = (double)-1;
                // .LongNote = False
                // .Selected = False
                withBlock.Value = 1200000L;
            }
            THBPM.Value = 120m;

            LWAV.Items.Clear();
            LBMP.Items.Clear();
            int xI1;
            for (xI1 = 1; xI1 <= 1295; xI1++)
            {
                LWAV.Items.Add(iBMSC.Editor.Functions.C10to36((long)xI1) + ": " + hWAV[xI1]);
                LBMP.Items.Add(iBMSC.Editor.Functions.C10to36((long)xI1) + ": " + hBMP[xI1]);
            }
            LWAV.SelectedIndex = 0;
            LBMP.SelectedIndex = 0;

            SetFileName("Untitled.bms");
            SetIsSaved(true);
            // pIsSaved.Visible = Not IsSaved

            CalculateTotalPlayableNotes();
            CalculateGreatestVPosition();
            this.RefreshPanelAll();
            POStatusRefresh();
        }

        private void TBNewC_Click(object sender, EventArgs e) // Handles TBNewC.Click
        {
            // KMouseDown = -1
            SelectedNotes = new iBMSC.Editor.Note[0];
            KMouseOver = -1;
            if (ClosingPopSave())
                return;

            this.ClearUndo();

            Notes = new iBMSC.Editor.Note[1];
            mColumn = new int[1000];
            hWAV = new string[1296];
            hBMP = new string[1296];
            hBPM = new long[1296];    // x10000
            hSTOP = new long[1296];
            hSCROLL = new long[1296];
            THGenre.Text = "";
            THTitle.Text = "";
            THArtist.Text = "";
            THPlayLevel.Text = "";

            {
                ref var withBlock = ref Notes[0];
                withBlock.ColumnIndex = MainWindow.niBPM;
                withBlock.VPosition = (double)-1;
                // .LongNote = False
                // .Selected = False
                withBlock.Value = 1200000L;
            }
            THBPM.Value = 120m;

            SetFileName("Untitled.bms");
            SetIsSaved(true);
            // pIsSaved.Visible = Not IsSaved

            if (Interaction.MsgBox("Please copy your code to clipboard and click OK.", MsgBoxStyle.OkCancel, "Create from code") == MsgBoxResult.Cancel)
                return;
            this.OpenBMS(Clipboard.GetText());
        }

        private void TBOpen_ButtonClick(object sender, EventArgs e)
        {
            // KMouseDown = -1
            SelectedNotes = new iBMSC.Editor.Note[0];
            KMouseOver = -1;
            if (ClosingPopSave())
                return;

            var xDOpen = new OpenFileDialog();
            xDOpen.Filter = iBMSC.Strings.FileType._bms + "|*.bms;*.bme;*.bml;*.pms;*.txt";
            xDOpen.DefaultExt = "bms";
            xDOpen.InitialDirectory = Conversions.ToString(Interaction.IIf(string.IsNullOrEmpty(ExcludeFileName(FileName)), InitPath, ExcludeFileName(FileName)));

            if (xDOpen.ShowDialog() == DialogResult.Cancel)
                return;
            InitPath = ExcludeFileName(xDOpen.FileName);
            this.OpenBMS(File.ReadAllText(xDOpen.FileName, TextEncoding));
            this.ClearUndo();
            SetFileName(xDOpen.FileName);
            this.NewRecent(FileName);
            SetIsSaved(true);
            // pIsSaved.Visible = Not IsSaved
        }

        private void TBImportIBMSC_Click(object sender, EventArgs e)
        {
            // KMouseDown = -1
            SelectedNotes = new iBMSC.Editor.Note[0];
            KMouseOver = -1;
            if (ClosingPopSave())
                return;

            var xDOpen = new OpenFileDialog();
            xDOpen.Filter = iBMSC.Strings.FileType.IBMSC + "|*.ibmsc";
            xDOpen.DefaultExt = "ibmsc";
            xDOpen.InitialDirectory = Conversions.ToString(Interaction.IIf(string.IsNullOrEmpty(ExcludeFileName(FileName)), InitPath, ExcludeFileName(FileName)));

            if (xDOpen.ShowDialog() == DialogResult.Cancel)
                return;
            InitPath = ExcludeFileName(xDOpen.FileName);
            SetFileName("Imported_" + GetFileName(xDOpen.FileName));
            this.OpeniBMSC(xDOpen.FileName);
            this.NewRecent(xDOpen.FileName);
            SetIsSaved(false);
            // pIsSaved.Visible = Not IsSaved
        }

        private void TBImportSM_Click(object sender, EventArgs e)
        {
            // KMouseDown = -1
            SelectedNotes = new iBMSC.Editor.Note[0];
            KMouseOver = -1;
            if (ClosingPopSave())
                return;

            var xDOpen = new OpenFileDialog();
            xDOpen.Filter = iBMSC.Strings.FileType.SM + "|*.sm";
            xDOpen.DefaultExt = "sm";
            xDOpen.InitialDirectory = Conversions.ToString(Interaction.IIf(string.IsNullOrEmpty(ExcludeFileName(FileName)), InitPath, ExcludeFileName(FileName)));

            if (xDOpen.ShowDialog() == DialogResult.Cancel)
                return;
            if (this.OpenSM(File.ReadAllText(xDOpen.FileName, TextEncoding)))
                return;
            InitPath = ExcludeFileName(xDOpen.FileName);
            SetFileName("Untitled.bms");
            this.ClearUndo();
            SetIsSaved(false);
            // pIsSaved.Visible = Not IsSaved
        }

        private void TBSave_ButtonClick(object sender, EventArgs e)
        {
            // KMouseDown = -1
            SelectedNotes = new iBMSC.Editor.Note[0];
            KMouseOver = -1;

            if (string.IsNullOrEmpty(ExcludeFileName(FileName)))
            {
                var xDSave = new SaveFileDialog();
                xDSave.Filter = iBMSC.Strings.FileType._bms + "|*.bms;*.bme;*.bml;*.pms;*.txt|" + iBMSC.Strings.FileType.BMS + "|*.bms|" + iBMSC.Strings.FileType.BME + "|*.bme|" + iBMSC.Strings.FileType.BML + "|*.bml|" + iBMSC.Strings.FileType.PMS + "|*.pms|" + iBMSC.Strings.FileType.TXT + "|*.txt|" + iBMSC.Strings.FileType._all + "|*.*";
                xDSave.DefaultExt = "bms";
                xDSave.InitialDirectory = InitPath;

                if (xDSave.ShowDialog() == DialogResult.Cancel)
                    return;
                InitPath = ExcludeFileName(xDSave.FileName);
                SetFileName(xDSave.FileName);
            }
            string xStrAll = this.SaveBMS();
            File.WriteAllText(FileName, xStrAll, TextEncoding);
            this.NewRecent(FileName);
            SetFileName(FileName);
            SetIsSaved(true);
            // pIsSaved.Visible = Not IsSaved
            if (BeepWhileSaved)
                Interaction.Beep();
        }

        private void TBSaveAs_Click(object sender, EventArgs e)
        {
            // KMouseDown = -1
            SelectedNotes = new iBMSC.Editor.Note[0];
            KMouseOver = -1;

            var xDSave = new SaveFileDialog();
            xDSave.Filter = iBMSC.Strings.FileType._bms + "|*.bms;*.bme;*.bml;*.pms;*.txt|" + iBMSC.Strings.FileType.BMS + "|*.bms|" + iBMSC.Strings.FileType.BME + "|*.bme|" + iBMSC.Strings.FileType.BML + "|*.bml|" + iBMSC.Strings.FileType.PMS + "|*.pms|" + iBMSC.Strings.FileType.TXT + "|*.txt|" + iBMSC.Strings.FileType._all + "|*.*";
            xDSave.DefaultExt = "bms";
            xDSave.InitialDirectory = Conversions.ToString(Interaction.IIf(string.IsNullOrEmpty(ExcludeFileName(FileName)), InitPath, ExcludeFileName(FileName)));

            if (xDSave.ShowDialog() == DialogResult.Cancel)
                return;
            InitPath = ExcludeFileName(xDSave.FileName);
            SetFileName(xDSave.FileName);
            string xStrAll = this.SaveBMS();
            File.WriteAllText(FileName, xStrAll, TextEncoding);
            this.NewRecent(FileName);
            SetFileName(FileName);
            SetIsSaved(true);
            // pIsSaved.Visible = Not IsSaved
            if (BeepWhileSaved)
                Interaction.Beep();
        }

        private void TBExport_Click(object sender, EventArgs e)
        {
            // KMouseDown = -1
            SelectedNotes = new iBMSC.Editor.Note[0];
            KMouseOver = -1;

            var xDSave = new SaveFileDialog();
            xDSave.Filter = iBMSC.Strings.FileType.IBMSC + "|*.ibmsc";
            xDSave.DefaultExt = "ibmsc";
            xDSave.InitialDirectory = Conversions.ToString(Interaction.IIf(string.IsNullOrEmpty(ExcludeFileName(FileName)), InitPath, ExcludeFileName(FileName)));
            if (xDSave.ShowDialog() == DialogResult.Cancel)
                return;

            this.SaveiBMSC(xDSave.FileName);
            // My.Computer.FileSystem.WriteAllText(xDSave.FileName, xStrAll, False, TextEncoding)
            this.NewRecent(FileName);
            if (BeepWhileSaved)
                Interaction.Beep();
        }



        private void VSGotFocus(object sender, EventArgs e)
        {
            PanelFocus = Conversions.ToInteger(sender.Tag);
            spMain[PanelFocus].Focus();
        }

        private void VSValueChanged(object sender, EventArgs e)
        {
            int iI = Conversions.ToInteger(sender.Tag);

            // az: We got a wheel event when we're zooming in/out
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                sender.Value = (object)VSValue; // Undo the scroll
                return;
            }

            if (iI == PanelFocus & !(LastMouseDownLocation == new Point(-1, -1)) & !(VSValue == -1))
                LastMouseDownLocation.Y = Conversions.ToSingle(LastMouseDownLocation.Y + Operators.MultiplyObject(Operators.SubtractObject(VSValue, sender.Value), gxHeight));
            PanelVScroll[iI] = Conversions.ToInteger(sender.Value);

            if (spLock[(iI + 1) % 3])
            {
                int xVS = PanelVScroll[iI] + spDiff[iI];
                if (xVS > 0)
                    xVS = 0;
                if (xVS < MainPanelScroll.Minimum)
                    xVS = MainPanelScroll.Minimum;
                switch (iI)
                {
                    case 0:
                        {
                            MainPanelScroll.Value = xVS;
                            break;
                        }
                    case 1:
                        {
                            RightPanelScroll.Value = xVS;
                            break;
                        }
                    case 2:
                        {
                            LeftPanelScroll.Value = xVS;
                            break;
                        }
                }
            }

            if (spLock[(iI + 2) % 3])
            {
                int xVS = PanelVScroll[iI] - spDiff[(iI + 2) % 3];
                if (xVS > 0)
                    xVS = 0;
                if (xVS < MainPanelScroll.Minimum)
                    xVS = MainPanelScroll.Minimum;
                switch (iI)
                {
                    case 0:
                        {
                            RightPanelScroll.Value = xVS;
                            break;
                        }
                    case 1:
                        {
                            LeftPanelScroll.Value = xVS;
                            break;
                        }
                    case 2:
                        {
                            MainPanelScroll.Value = xVS;
                            break;
                        }
                }
            }

            spDiff[iI] = PanelVScroll[(iI + 1) % 3] - PanelVScroll[iI];
            spDiff[(iI + 2) % 3] = PanelVScroll[iI] - PanelVScroll[(iI + 2) % 3];

            VSValue = Conversions.ToInteger(sender.Value);
            this.RefreshPanel(iI, spMain[iI].DisplayRectangle);
        }

        private void cVSLock_CheckedChanged(object sender, EventArgs e)
        {
            int iI = Conversions.ToInteger(sender.Tag);
            spLock[iI] = Conversions.ToBoolean(sender.Checked);
            if (!spLock[iI])
                return;

            spDiff[iI] = PanelVScroll[(iI + 1) % 3] - PanelVScroll[iI];
            spDiff[(iI + 2) % 3] = PanelVScroll[iI] - PanelVScroll[(iI + 2) % 3];

            // POHeaderB.Text = spDiff(0) & "_" & spDiff(1) & "_" & spDiff(2)
        }

        private void HSGotFocus(object sender, EventArgs e)
        {
            PanelFocus = Conversions.ToInteger(sender.Tag);
            spMain[PanelFocus].Focus();
        }

        private void HSValueChanged(object sender, EventArgs e)
        {
            int iI = Conversions.ToInteger(sender.Tag);
            if (!(LastMouseDownLocation == new Point(-1, -1)) & !(HSValue == -1))
                LastMouseDownLocation.X = Conversions.ToSingle(LastMouseDownLocation.X + Operators.MultiplyObject(Operators.SubtractObject(HSValue, sender.Value), gxWidth));
            PanelHScroll[iI] = Conversions.ToInteger(sender.Value);
            HSValue = Conversions.ToInteger(sender.Value);
            this.RefreshPanel(iI, spMain[iI].DisplayRectangle);
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
            TempVPosition = -1;
            TempLength = 0d;

            vSelStart = MeasureBottom[MeasureAtDisplacement(-PanelVScroll[PanelFocus]) + 1];
            vSelLength = 0d;

            this.RefreshPanelAll();
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
            TempVPosition = -1;
            TempLength = 0d;

            vSelStart = MeasureBottom[MeasureAtDisplacement(-PanelVScroll[PanelFocus]) + 1];
            vSelLength = 0d;

            this.RefreshPanelAll();
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
            TempVPosition = -1;
            TempLength = 0d;
            ValidateSelection();

            int xI1;
            var loopTo = Information.UBound(Notes);
            for (xI1 = 0; xI1 <= loopTo; xI1++)
                Notes[xI1].Selected = false;
            this.RefreshPanelAll();
            POStatusRefresh();
        }

        private void CGHeight_ValueChanged(object sender, EventArgs e)
        {
            gxHeight = (float)CGHeight.Value;
            CGHeight2.Value = Conversions.ToInteger(Interaction.IIf(CGHeight.Value * 4m < CGHeight2.Maximum, CGHeight.Value * 4m, CGHeight2.Maximum));
            this.RefreshPanelAll();
        }

        private void CGHeight2_Scroll(object sender, EventArgs e)
        {
            CGHeight.Value = (decimal)(CGHeight2.Value / 4d);
        }

        private void CGWidth_ValueChanged(object sender, EventArgs e)
        {
            gxWidth = (float)CGWidth.Value;
            CGWidth2.Value = Conversions.ToInteger(Interaction.IIf(CGWidth.Value * 4m < CGWidth2.Maximum, CGWidth.Value * 4m, CGWidth2.Maximum));

            HS.LargeChange = (int)Math.Round(PMainIn.Width / gxWidth);
            if (HS.Value > HS.Maximum - HS.LargeChange + 1)
                HS.Value = HS.Maximum - HS.LargeChange + 1;
            HSL.LargeChange = (int)Math.Round(PMainInL.Width / gxWidth);
            if (HSL.Value > HSL.Maximum - HSL.LargeChange + 1)
                HSL.Value = HSL.Maximum - HSL.LargeChange + 1;
            HSR.LargeChange = (int)Math.Round(PMainInR.Width / gxWidth);
            if (HSR.Value > HSR.Maximum - HSR.LargeChange + 1)
                HSR.Value = HSR.Maximum - HSR.LargeChange + 1;

            this.RefreshPanelAll();
        }

        private void CGWidth2_Scroll(object sender, EventArgs e)
        {
            CGWidth.Value = (decimal)(CGWidth2.Value / 4d);
        }

        private void CGDivide_ValueChanged(object sender, EventArgs e)
        {
            gDivide = (int)Math.Round(CGDivide.Value);
            this.RefreshPanelAll();
        }
        private void CGSub_ValueChanged(object sender, EventArgs e)
        {
            gSub = (int)Math.Round(CGSub.Value);
            this.RefreshPanelAll();
        }
        private void BGSlash_Click(object sender, EventArgs e)
        {
            int xd = (int)Math.Round(Conversion.Val(Interaction.InputBox(iBMSC.Strings.Messages.PromptSlashValue, DefaultResponse: gSlash.ToString())));
            if (xd == 0)
                return;
            if (xd > CGDivide.Maximum)
                xd = (int)Math.Round(CGDivide.Maximum);
            if (xd < CGDivide.Minimum)
                xd = (int)Math.Round(CGDivide.Minimum);
            gSlash = xd;
        }


        private void CGSnap_CheckedChanged(object sender, EventArgs e)
        {
            gSnap = CGSnap.Checked;
            this.RefreshPanelAll();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            int xI1;

            switch (PanelFocus)
            {
                case 0:
                    {
                        {
                            var withBlock = LeftPanelScroll;
                            xI1 = (int)Math.Round(withBlock.Value + tempY / 5d / gxHeight);
                            if (xI1 > 0)
                                xI1 = 0;
                            if (xI1 < withBlock.Minimum)
                                xI1 = withBlock.Minimum;
                            withBlock.Value = xI1;
                        }
                        {
                            var withBlock1 = HSL;
                            xI1 = (int)Math.Round(withBlock1.Value + tempX / 10d / gxWidth);
                            if (xI1 > withBlock1.Maximum - withBlock1.LargeChange + 1)
                                xI1 = withBlock1.Maximum - withBlock1.LargeChange + 1;
                            if (xI1 < withBlock1.Minimum)
                                xI1 = withBlock1.Minimum;
                            withBlock1.Value = xI1;
                        }

                        break;
                    }

                case 1:
                    {
                        {
                            var withBlock2 = MainPanelScroll;
                            xI1 = (int)Math.Round(withBlock2.Value + tempY / 5d / gxHeight);
                            if (xI1 > 0)
                                xI1 = 0;
                            if (xI1 < withBlock2.Minimum)
                                xI1 = withBlock2.Minimum;
                            withBlock2.Value = xI1;
                        }
                        {
                            var withBlock3 = HS;
                            xI1 = (int)Math.Round(withBlock3.Value + tempX / 10d / gxWidth);
                            if (xI1 > withBlock3.Maximum - withBlock3.LargeChange + 1)
                                xI1 = withBlock3.Maximum - withBlock3.LargeChange + 1;
                            if (xI1 < withBlock3.Minimum)
                                xI1 = withBlock3.Minimum;
                            withBlock3.Value = xI1;
                        }

                        break;
                    }

                case 2:
                    {
                        {
                            var withBlock4 = RightPanelScroll;
                            xI1 = (int)Math.Round(withBlock4.Value + tempY / 5d / gxHeight);
                            if (xI1 > 0)
                                xI1 = 0;
                            if (xI1 < withBlock4.Minimum)
                                xI1 = withBlock4.Minimum;
                            withBlock4.Value = xI1;
                        }
                        {
                            var withBlock5 = HSR;
                            xI1 = (int)Math.Round(withBlock5.Value + tempX / 10d / gxWidth);
                            if (xI1 > withBlock5.Maximum - withBlock5.LargeChange + 1)
                                xI1 = withBlock5.Maximum - withBlock5.LargeChange + 1;
                            if (xI1 < withBlock5.Minimum)
                                xI1 = withBlock5.Minimum;
                            withBlock5.Value = xI1;
                        }

                        break;
                    }
            }

            var xMEArgs = new MouseEventArgs(MouseButtons.Left, 0, MouseMoveStatus.X, MouseMoveStatus.Y, 0);
            this.PMainInMouseMove(spMain[PanelFocus], xMEArgs);

        }

        private void TimerMiddle_Tick(object sender, EventArgs e)
        {
            if (!MiddleButtonClicked)
            {
                TimerMiddle.Enabled = false;
                return;
            }

            int xI1;

            switch (PanelFocus)
            {
                case 0:
                    {
                        {
                            var withBlock = LeftPanelScroll;
                            xI1 = (int)Math.Round(withBlock.Value + (Cursor.Position.Y - MiddleButtonLocation.Y) / 5d / gxHeight);
                            if (xI1 > 0)
                                xI1 = 0;
                            if (xI1 < withBlock.Minimum)
                                xI1 = withBlock.Minimum;
                            withBlock.Value = xI1;
                        }
                        {
                            var withBlock1 = HSL;
                            xI1 = (int)Math.Round(withBlock1.Value + (Cursor.Position.X - MiddleButtonLocation.X) / 5d / gxWidth);
                            if (xI1 > withBlock1.Maximum - withBlock1.LargeChange + 1)
                                xI1 = withBlock1.Maximum - withBlock1.LargeChange + 1;
                            if (xI1 < withBlock1.Minimum)
                                xI1 = withBlock1.Minimum;
                            withBlock1.Value = xI1;
                        }

                        break;
                    }

                case 1:
                    {
                        {
                            var withBlock2 = MainPanelScroll;
                            xI1 = (int)Math.Round(withBlock2.Value + (Cursor.Position.Y - MiddleButtonLocation.Y) / 5d / gxHeight);
                            if (xI1 > 0)
                                xI1 = 0;
                            if (xI1 < withBlock2.Minimum)
                                xI1 = withBlock2.Minimum;
                            withBlock2.Value = xI1;
                        }
                        {
                            var withBlock3 = HS;
                            xI1 = (int)Math.Round(withBlock3.Value + (Cursor.Position.X - MiddleButtonLocation.X) / 5d / gxWidth);
                            if (xI1 > withBlock3.Maximum - withBlock3.LargeChange + 1)
                                xI1 = withBlock3.Maximum - withBlock3.LargeChange + 1;
                            if (xI1 < withBlock3.Minimum)
                                xI1 = withBlock3.Minimum;
                            withBlock3.Value = xI1;
                        }

                        break;
                    }

                case 2:
                    {
                        {
                            var withBlock4 = RightPanelScroll;
                            xI1 = (int)Math.Round(withBlock4.Value + (Cursor.Position.Y - MiddleButtonLocation.Y) / 5d / gxHeight);
                            if (xI1 > 0)
                                xI1 = 0;
                            if (xI1 < withBlock4.Minimum)
                                xI1 = withBlock4.Minimum;
                            withBlock4.Value = xI1;
                        }
                        {
                            var withBlock5 = HSR;
                            xI1 = (int)Math.Round(withBlock5.Value + (Cursor.Position.X - MiddleButtonLocation.X) / 5d / gxWidth);
                            if (xI1 > withBlock5.Maximum - withBlock5.LargeChange + 1)
                                xI1 = withBlock5.Maximum - withBlock5.LargeChange + 1;
                            if (xI1 < withBlock5.Minimum)
                                xI1 = withBlock5.Minimum;
                            withBlock5.Value = xI1;
                        }

                        break;
                    }
            }

            var xMEArgs = new MouseEventArgs(MouseButtons.Left, 0, MouseMoveStatus.X, MouseMoveStatus.Y, 0);
            this.PMainInMouseMove(spMain[PanelFocus], xMEArgs);
        }

        private void ValidateWavListView()
        {
            try
            {
                var xRect = LWAV.GetItemRectangle(LWAV.SelectedIndex);
                if (xRect.Top + xRect.Height > LWAV.DisplayRectangle.Height)
                    SendMessage(LWAV.Handle, 0x115, 1, 0);
            }
            catch (Exception ex)
            {
            }
        }

        private void LWAV_Click(object sender, EventArgs e)
        {
            if (TBWrite.Checked)
                FSW.Text = iBMSC.Editor.Functions.C10to36((long)(LWAV.SelectedIndex + 1));

            PreviewNote("", true);
            if (!PreviewOnClick)
                return;
            if (string.IsNullOrEmpty(hWAV[LWAV.SelectedIndex + 1]))
                return;

            string xFileLocation = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Interaction.IIf(string.IsNullOrEmpty(ExcludeFileName(FileName)), InitPath, ExcludeFileName(FileName)), @"\"), hWAV[LWAV.SelectedIndex + 1]));
            PreviewNote(xFileLocation, false);
        }

        private void LWAV_DoubleClick(object sender, EventArgs e)
        {
            var xDWAV = new OpenFileDialog();
            xDWAV.DefaultExt = "wav";
            xDWAV.Filter = iBMSC.Strings.FileType._wave + "|*.wav;*.ogg;*.mp3|" + iBMSC.Strings.FileType.WAV + "|*.wav|" + iBMSC.Strings.FileType.OGG + "|*.ogg|" + iBMSC.Strings.FileType.MP3 + "|*.mp3|" + iBMSC.Strings.FileType._all + "|*.*";
            xDWAV.InitialDirectory = Conversions.ToString(Interaction.IIf(string.IsNullOrEmpty(ExcludeFileName(FileName)), InitPath, ExcludeFileName(FileName)));

            if (xDWAV.ShowDialog() == DialogResult.Cancel)
                return;
            InitPath = ExcludeFileName(xDWAV.FileName);
            hWAV[LWAV.SelectedIndex + 1] = GetFileName(xDWAV.FileName);
            LWAV.Items[LWAV.SelectedIndex] = iBMSC.Editor.Functions.C10to36((long)(LWAV.SelectedIndex + 1)) + ": " + GetFileName(xDWAV.FileName);
            if (IsSaved)
                SetIsSaved(false);
        }

        private void LWAV_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    {
                        hWAV[LWAV.SelectedIndex + 1] = "";
                        LWAV.Items[LWAV.SelectedIndex] = iBMSC.Editor.Functions.C10to36((long)(LWAV.SelectedIndex + 1)) + ": ";
                        if (IsSaved)
                            SetIsSaved(false);
                        break;
                    }
            }
        }

        private void LBMP_DoubleClick(object sender, EventArgs e)
        {
            var xDBMP = new OpenFileDialog();
            xDBMP.DefaultExt = "bmp";
            xDBMP.Filter = iBMSC.Strings.FileType._image + "|*.bmp;*.png;*.jpg;*.jpeg;.gif|" + iBMSC.Strings.FileType._movie + "|*.mpg;*.m1v;*.m2v;*.avi;*.mp4;*.m4v;*.wmv;*.webm|" + iBMSC.Strings.FileType.BMP + "|*.bmp|" + iBMSC.Strings.FileType.PNG + "|*.png|" + iBMSC.Strings.FileType.JPG + "|*.jpg;*.jpeg|" + iBMSC.Strings.FileType.GIF + "|*.gif|" + iBMSC.Strings.FileType.MP4 + "|*.mp4;*.m4v|" + iBMSC.Strings.FileType.AVI + "|*.avi|" + iBMSC.Strings.FileType.MPG + "|*.mpg;*.m1v;*.m2v|" + iBMSC.Strings.FileType.WMV + "|*.wmv|" + iBMSC.Strings.FileType.WEBM + "|*.webm|" + iBMSC.Strings.FileType._all + "|*.*";
            xDBMP.InitialDirectory = Conversions.ToString(Interaction.IIf(string.IsNullOrEmpty(ExcludeFileName(FileName)), InitPath, ExcludeFileName(FileName)));

            if (xDBMP.ShowDialog() == DialogResult.Cancel)
                return;
            InitPath = ExcludeFileName(xDBMP.FileName);
            hBMP[LBMP.SelectedIndex + 1] = GetFileName(xDBMP.FileName);
            LBMP.Items[LBMP.SelectedIndex] = iBMSC.Editor.Functions.C10to36((long)(LBMP.SelectedIndex + 1)) + ": " + GetFileName(xDBMP.FileName);
            if (IsSaved)
                SetIsSaved(false);
        }

        private void LBMP_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    {
                        hBMP[LBMP.SelectedIndex + 1] = "";
                        LBMP.Items[LBMP.SelectedIndex] = iBMSC.Editor.Functions.C10to36((long)(LBMP.SelectedIndex + 1)) + ": ";
                        if (IsSaved)
                            SetIsSaved(false);
                        break;
                    }
            }
        }

        private void TBErrorCheck_Click(object sender, EventArgs e)
        {
            ErrorCheck = Conversions.ToBoolean(sender.Checked);
            TBErrorCheck.Checked = ErrorCheck;
            mnErrorCheck.Checked = ErrorCheck;
            TBErrorCheck.Image = (Image)Interaction.IIf(TBErrorCheck.Checked, iBMSC.Properties.Resources.x16CheckError, iBMSC.Properties.Resources.x16CheckErrorN);
            mnErrorCheck.Image = (Image)Interaction.IIf(TBErrorCheck.Checked, iBMSC.Properties.Resources.x16CheckError, iBMSC.Properties.Resources.x16CheckErrorN);
            this.RefreshPanelAll();
        }

        private void TBPreviewOnClick_Click(object sender, EventArgs e)
        {
            PreviewNote("", true);
            PreviewOnClick = Conversions.ToBoolean(sender.Checked);
            TBPreviewOnClick.Checked = PreviewOnClick;
            mnPreviewOnClick.Checked = PreviewOnClick;
            TBPreviewOnClick.Image = (Image)Interaction.IIf(PreviewOnClick, iBMSC.Properties.Resources.x16PreviewOnClick, iBMSC.Properties.Resources.x16PreviewOnClickN);
            mnPreviewOnClick.Image = (Image)Interaction.IIf(PreviewOnClick, iBMSC.Properties.Resources.x16PreviewOnClick, iBMSC.Properties.Resources.x16PreviewOnClickN);
        }

        // Private Sub TBPreviewErrorCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        // PreviewErrorCheck = TBPreviewErrorCheck.Checked
        // TBPreviewErrorCheck.Image = IIf(PreviewErrorCheck, My.Resources.x16PreviewCheck, My.Resources.x16PreviewCheckN)
        // End Sub

        private void TBShowFileName_Click(object sender, EventArgs e)
        {
            ShowFileName = Conversions.ToBoolean(sender.Checked);
            TBShowFileName.Checked = ShowFileName;
            mnShowFileName.Checked = ShowFileName;
            TBShowFileName.Image = (Image)Interaction.IIf(ShowFileName, iBMSC.Properties.Resources.x16ShowFileName, iBMSC.Properties.Resources.x16ShowFileNameN);
            mnShowFileName.Image = (Image)Interaction.IIf(ShowFileName, iBMSC.Properties.Resources.x16ShowFileName, iBMSC.Properties.Resources.x16ShowFileNameN);
            this.RefreshPanelAll();
        }

        private void TBCut_Click(object sender, EventArgs e)
        {
            iBMSC.UndoRedo.LinkedURCmd xUndo = null;
            iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
            var xBaseRedo = xRedo;
            this.RedoRemoveNoteSelected(true, ref xUndo, ref xRedo);
            // Dim xRedo As String = sCmdKDs()
            // Dim xUndo As String = sCmdKs(True)

            CopyNotes(false);
            RemoveNotes(false);
            this.AddUndo(xUndo, xBaseRedo.Next);

            SortByVPositionInsertion();
            UpdatePairing();
            CalculateTotalPlayableNotes();
            this.RefreshPanelAll();
            POStatusRefresh();
            CalculateGreatestVPosition();
        }

        private void TBCopy_Click(object sender, EventArgs e)
        {
            CopyNotes();
            this.RefreshPanelAll();
            POStatusRefresh();
        }

        private void TBPaste_Click(object sender, EventArgs e)
        {
            AddNotesFromClipboard();

            iBMSC.UndoRedo.LinkedURCmd xUndo = null;
            iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
            var xBaseRedo = xRedo;
            this.RedoAddNoteSelected(true, ref xUndo, ref xRedo);
            this.AddUndo(xUndo, xBaseRedo.Next);

            // AddUndo(sCmdKDs(), sCmdKs(True))

            SortByVPositionInsertion();
            UpdatePairing();
            CalculateTotalPlayableNotes();
            this.RefreshPanelAll();
            POStatusRefresh();
            CalculateGreatestVPosition();
        }

        // Private Function pArgPath(ByVal I As Integer)
        // Return Mid(pArgs(I), 1, InStr(pArgs(I), vbCrLf) - 1)
        // End Function

        private string GetFileName(string s)
        {
            int fslash = s.LastIndexOf("/");
            int bslash = s.LastIndexOf(@"\");
            return s.Substring(Conversions.ToInteger(Operators.AddObject(Interaction.IIf(fslash > bslash, fslash, bslash), 1)));
        }

        private string ExcludeFileName(string s)
        {
            int fslash = s.LastIndexOf("/");
            int bslash = s.LastIndexOf(@"\");
            if ((bslash | fslash) == 0)
                return "";
            return s.Substring(1, Conversions.ToInteger(Operators.SubtractObject(Interaction.IIf(fslash > bslash, fslash, bslash), 1)));
        }

        private void PlayerMissingPrompt()
        {
            var xArg = pArgs[CurrentPlayer];
            Interaction.MsgBox(iBMSC.Strings.Messages.CannotFind.Replace("{}", PrevCodeToReal(xArg.Path)) + Constants.vbCrLf + iBMSC.Strings.Messages.PleaseRespecifyPath, MsgBoxStyle.Critical, iBMSC.Strings.Messages.PlayerNotFound);

            var xDOpen = new OpenFileDialog();
            xDOpen.InitialDirectory = Conversions.ToString(Interaction.IIf(string.IsNullOrEmpty(ExcludeFileName(PrevCodeToReal(xArg.Path))), Application.ExecutablePath, ExcludeFileName(PrevCodeToReal(xArg.Path))));
            xDOpen.FileName = PrevCodeToReal(xArg.Path);
            xDOpen.Filter = iBMSC.Strings.FileType.EXE + "|*.exe";
            xDOpen.DefaultExt = "exe";
            if (xDOpen.ShowDialog() == DialogResult.Cancel)
                return;

            // pArgs(CurrentPlayer) = Replace(xDOpen.FileName, My.Application.Info.DirectoryPath, "<apppath>") & _
            // Mid(pArgs(CurrentPlayer), InStr(pArgs(CurrentPlayer), vbCrLf))
            // xStr = Split(pArgs(CurrentPlayer), vbCrLf)
            pArgs[CurrentPlayer].Path = xDOpen.FileName.Replace(Application.ExecutablePath, "<apppath>");
            xArg = pArgs[CurrentPlayer];
        }

        private void TBPlay_Click(object sender, EventArgs e)
        {
            // Dim xStr() As String = Split(pArgs(CurrentPlayer), vbCrLf)
            var xArg = pArgs[CurrentPlayer];

            if (!File.Exists(PrevCodeToReal(xArg.Path)))
            {
                PlayerMissingPrompt();
                xArg = pArgs[CurrentPlayer];
            }

            // az: Treat it like we cancelled the operation
            if (!File.Exists(PrevCodeToReal(xArg.Path)))
            {
                return;
            }

            string xStrAll = this.SaveBMS();
            string xFileName = Conversions.ToString(Operators.ConcatenateObject(Interaction.IIf(!PathIsValid(FileName), Interaction.IIf(string.IsNullOrEmpty(InitPath), Application.ExecutablePath, InitPath), ExcludeFileName(FileName)), @"\___TempBMS.bms"));
            File.WriteAllText(xFileName, xStrAll, TextEncoding);

            AddTempFileList(xFileName);
            Process.Start(PrevCodeToReal(xArg.Path), PrevCodeToReal(xArg.aHere));
        }

        private void TBPlayB_Click(object sender, EventArgs e)
        {
            // Dim xStr() As String = Split(pArgs(CurrentPlayer), vbCrLf)
            var xArg = pArgs[CurrentPlayer];

            if (!File.Exists(PrevCodeToReal(xArg.Path)))
            {
                PlayerMissingPrompt();
                xArg = pArgs[CurrentPlayer];
            }

            if (!File.Exists(PrevCodeToReal(xArg.Path)))
            {
                return;
            }

            string xStrAll = this.SaveBMS();
            string xFileName = Conversions.ToString(Operators.ConcatenateObject(Interaction.IIf(!PathIsValid(FileName), Interaction.IIf(string.IsNullOrEmpty(InitPath), Application.ExecutablePath, InitPath), ExcludeFileName(FileName)), @"\___TempBMS.bms"));
            File.WriteAllText(xFileName, xStrAll, TextEncoding);

            AddTempFileList(xFileName);

            Process.Start(PrevCodeToReal(xArg.Path), PrevCodeToReal(xArg.aBegin));
        }

        private void TBStop_Click(object sender, EventArgs e)
        {
            // Dim xStr() As String = Split(pArgs(CurrentPlayer), vbCrLf)
            var xArg = pArgs[CurrentPlayer];

            if (!File.Exists(PrevCodeToReal(xArg.Path)))
            {
                PlayerMissingPrompt();
                xArg = pArgs[CurrentPlayer];
            }

            if (!File.Exists(PrevCodeToReal(xArg.Path)))
            {
                return;
            }

            Process.Start(PrevCodeToReal(xArg.Path), PrevCodeToReal(xArg.aStop));
        }

        private void AddTempFileList(string s)
        {
            bool xAdd = true;
            if (pTempFileNames is not null)
            {
                foreach (string xStr1 in pTempFileNames)
                {
                    if ((xStr1 ?? "") == (s ?? ""))
                    {
                        xAdd = false;
                        break;
                    }
                }
            }

            if (xAdd)
            {
                Array.Resize(ref pTempFileNames, Information.UBound(pTempFileNames) + 1 + 1);
                pTempFileNames[Information.UBound(pTempFileNames)] = s;
            }
        }

        private void TBStatistics_Click(object sender, EventArgs e)
        {
            SortByVPositionInsertion();
            UpdatePairing();

            var data = new int[7, 6];
            for (int i = 1, loopTo = Information.UBound(Notes); i <= loopTo; i++)
            {
                {
                    ref var withBlock = ref Notes[i];
                    int row = -1;
                    switch (withBlock.ColumnIndex)
                    {
                        case MainWindow.niBPM:
                            {
                                row = 0;
                                break;
                            }
                        case MainWindow.niSTOP:
                            {
                                row = 1;
                                break;
                            }
                        case MainWindow.niSCROLL:
                            {
                                row = 2;
                                break;
                            }
                        case MainWindow.niA1:
                        case MainWindow.niA2:
                        case MainWindow.niA3:
                        case MainWindow.niA4:
                        case MainWindow.niA5:
                        case MainWindow.niA6:
                        case MainWindow.niA7:
                        case MainWindow.niA8:
                            {
                                row = 3;
                                break;
                            }
                        case MainWindow.niD1:
                        case MainWindow.niD2:
                        case MainWindow.niD3:
                        case MainWindow.niD4:
                        case MainWindow.niD5:
                        case MainWindow.niD6:
                        case MainWindow.niD7:
                        case MainWindow.niD8:
                            {
                                row = 4;
                                break;
                            }
                        case var @case when @case >= MainWindow.niB:
                            {
                                row = 5;
                                break;
                            }

                        default:
                            {
                                row = 6;
                                break;
                            }
                    }


                StartCount:
                    ;
                    if (!NTInput)
                    {
                        if (!withBlock.LongNote)
                            data[row, 0] += 1;
                        if (withBlock.LongNote)
                            data[row, 1] += 1;
                        if (withBlock.Value / 10000L == (long)LnObj)
                            data[row, 2] += 1;
                        if (withBlock.Hidden)
                            data[row, 3] += 1;
                        if (withBlock.HasError)
                            data[row, 4] += 1;
                        data[row, 5] += 1;
                    }

                    else
                    {
                        int noteUnit = 1;
                        if (withBlock.Length == 0d)
                            data[row, 0] += 1;
                        if (withBlock.Length != 0d)
                        {
                            data[row, 1] += 2;
                            noteUnit = 2;
                        }

                        if (withBlock.Value / 10000L == (long)LnObj)
                            data[row, 2] += noteUnit;
                        if (withBlock.Hidden)
                            data[row, 3] += noteUnit;
                        if (withBlock.HasError)
                            data[row, 4] += noteUnit;
                        data[row, 5] += noteUnit;

                    }

                    if (row != 6)
                    {
                        row = 6;
                        goto StartCount;
                    }
                }
            }

            var dStat = new iBMSC.dgStatistics(data);
            dStat.ShowDialog();
        }

        /// <summary>
        /// Remark: Pls sort and updatepairing before this process.
        /// </summary>

        private void CalculateTotalPlayableNotes()
        {
            int xI1;
            int xIAll = 0;

            if (!NTInput)
            {
                var loopTo = Information.UBound(Notes);
                for (xI1 = 1; xI1 <= loopTo; xI1++)
                {
                    if (Notes[xI1].ColumnIndex >= MainWindow.niA1 & Notes[xI1].ColumnIndex <= MainWindow.niA8)
                        xIAll += 1;
                }
            }

            else
            {
                var loopTo1 = Information.UBound(Notes);
                for (xI1 = 1; xI1 <= loopTo1; xI1++)
                {
                    if (Notes[xI1].ColumnIndex >= MainWindow.niA1 & Notes[xI1].ColumnIndex <= MainWindow.niA8)
                    {
                        xIAll += 1;
                        if (Notes[xI1].Length != 0d)
                            xIAll += 1;
                    }
                }
            }

            TBStatistics.Text = xIAll.ToString();
        }

        public object GetMouseVPosition(bool snap = true)
        {
            int panHeight = spMain[PanelFocus].Height;
            int panDisplacement = PanelVScroll[PanelFocus];
            float vpos = (panHeight - panDisplacement * gxHeight - MouseMoveStatus.Y - 1f) / gxHeight;
            if (snap)
            {
                return SnapToGrid((double)vpos);
            }
            else
            {
                return vpos;
            }
        }

        private void POStatusRefresh()
        {

            if (TBSelect.Checked)
            {
                int xI1 = KMouseOver;
                if (xI1 < 0)
                {

                    TempVPosition = Conversions.ToDouble(GetMouseVPosition(gSnap));

                    SelectedColumn = this.GetColumnAtX(MouseMoveStatus.X, PanelHScroll[PanelFocus]);

                    int xMeasure = MeasureAtDisplacement(TempVPosition);
                    double xMLength = MeasureLength[xMeasure];
                    double xVposMod = TempVPosition - MeasureBottom[xMeasure];
                    double xGCD = GCD(Conversions.ToDouble(Interaction.IIf(xVposMod == 0d, xMLength, xVposMod)), xMLength);

                    FSP1.Text = (xVposMod * gDivide / 192d).ToString() + " / " + (xMLength * gDivide / 192d).ToString() + "  ";
                    FSP2.Text = xVposMod.ToString() + " / " + xMLength + "  ";
                    FSP3.Text = ((int)Math.Round(xVposMod / xGCD)).ToString() + " / " + ((int)Math.Round(xMLength / xGCD)).ToString() + "  ";
                    FSP4.Text = TempVPosition.ToString() + "  ";
                    TimeStatusLabel.Text = GetTimeFromVPosition(TempVPosition).ToString("F4");
                    FSC.Text = this.nTitle(SelectedColumn);
                    FSW.Text = "";
                    FSM.Text = iBMSC.Editor.Functions.Add3Zeros(xMeasure);
                    FST.Text = "";
                    FSH.Text = "";
                    FSE.Text = "";
                }

                else
                {
                    int xMeasure = this.MeasureAtDisplacement(Notes[xI1].VPosition);
                    double xMLength = MeasureLength[xMeasure];
                    double xVposMod = Notes[xI1].VPosition - MeasureBottom[xMeasure];
                    double xGCD = GCD(Conversions.ToDouble(Interaction.IIf(xVposMod == 0d, xMLength, xVposMod)), xMLength);

                    FSP1.Text = (xVposMod * gDivide / 192d).ToString() + " / " + (xMLength * gDivide / 192d).ToString() + "  ";
                    FSP2.Text = xVposMod.ToString() + " / " + xMLength + "  ";
                    FSP3.Text = ((int)Math.Round(xVposMod / xGCD)).ToString() + " / " + ((int)Math.Round(xMLength / xGCD)).ToString() + "  ";
                    FSP4.Text = Notes[xI1].VPosition.ToString() + "  ";
                    TimeStatusLabel.Text = GetTimeFromVPosition(TempVPosition).ToString("F4");
                    FSC.Text = this.nTitle(Notes[xI1].ColumnIndex);
                    FSW.Text = Conversions.ToString(Interaction.IIf(this.IsColumnNumeric(Notes[xI1].ColumnIndex), (object)((double)Notes[xI1].Value / 10000d), iBMSC.Editor.Functions.C10to36(Notes[xI1].Value / 10000L)));
                    FSM.Text = iBMSC.Editor.Functions.Add3Zeros(xMeasure);
                    FST.Text = Conversions.ToString(Interaction.IIf(NTInput, iBMSC.Strings.StatusBar.Length + " = " + Notes[xI1].Length, Interaction.IIf(Notes[xI1].LongNote, iBMSC.Strings.StatusBar.LongNote, "")));
                    FSH.Text = Conversions.ToString(Interaction.IIf(Notes[xI1].Hidden, iBMSC.Strings.StatusBar.Hidden, ""));
                    FSE.Text = Conversions.ToString(Interaction.IIf(Notes[xI1].HasError, iBMSC.Strings.StatusBar.Err, ""));

                }
            }

            else if (TBWrite.Checked)
            {
                if (SelectedColumn < 0)
                    return;

                int xMeasure = MeasureAtDisplacement(TempVPosition);
                double xMLength = MeasureLength[xMeasure];
                double xVposMod = TempVPosition - MeasureBottom[xMeasure];
                double xGCD = GCD(Conversions.ToDouble(Interaction.IIf(xVposMod == 0d, xMLength, xVposMod)), xMLength);

                FSP1.Text = (xVposMod * gDivide / 192d).ToString() + " / " + (xMLength * gDivide / 192d).ToString() + "  ";
                FSP2.Text = xVposMod.ToString() + " / " + xMLength + "  ";
                FSP3.Text = ((int)Math.Round(xVposMod / xGCD)).ToString() + " / " + ((int)Math.Round(xMLength / xGCD)).ToString() + "  ";
                FSP4.Text = TempVPosition.ToString() + "  ";
                TimeStatusLabel.Text = GetTimeFromVPosition(TempVPosition).ToString("F4");
                FSC.Text = this.nTitle(SelectedColumn);
                FSW.Text = iBMSC.Editor.Functions.C10to36((long)(LWAV.SelectedIndex + 1));
                FSM.Text = iBMSC.Editor.Functions.Add3Zeros(xMeasure);
                FST.Text = Conversions.ToString(Interaction.IIf(NTInput, TempLength, Interaction.IIf(iBMSC.My.MyProject.Computer.Keyboard.ShiftKeyDown, iBMSC.Strings.StatusBar.LongNote, "")));
                FSH.Text = Conversions.ToString(Interaction.IIf(iBMSC.My.MyProject.Computer.Keyboard.CtrlKeyDown, iBMSC.Strings.StatusBar.Hidden, ""));
            }

            else if (TBTimeSelect.Checked)
            {
                FSSS.Text = vSelStart.ToString();
                FSSL.Text = vSelLength.ToString();
                FSSH.Text = vSelHalf.ToString();

            }
            FStatus.Invalidate();
        }

        private double GetTimeFromVPosition(double vpos)
        {
            var timing_notes = (from note in Notes
                                where note.ColumnIndex == niBPM | note.ColumnIndex == niSTOP
                                group note by note.ColumnIndex).ToDictionary(x => x.Column, x => x.NoteGroups);

            var bpm_notes = timing_notes[MainWindow.niBPM];

            IEnumerable<iBMSC.Editor.Note> stop_notes = null;

            if (timing_notes.ContainsKey(MainWindow.niSTOP))
            {
                stop_notes = timing_notes[MainWindow.niSTOP];
            }


            var stop_contrib = default(double);
            var bpm_contrib = default(double);

            for (int i = 0, loopTo = bpm_notes.Count() - 1; i <= loopTo; i++)
            {
                // az: sum bpm contribution first
                double duration = 0.0d;
                var current_note = bpm_notes.ElementAt(i);
                double notevpos = Math.Max(0d, current_note.VPosition);

                if (i + 1 != bpm_notes.Count())
                {
                    var next_note = bpm_notes.ElementAt(i + 1);
                    duration = next_note.VPosition - notevpos;
                }
                else
                {
                    duration = vpos - notevpos;
                }

                double current_bps = 60d / ((double)current_note.Value / 10000d);
                bpm_contrib += current_bps * duration / 48d;

                if (stop_notes is null)
                    continue;

                var stops = from stp in stop_notes
                            where stp.VPosition >= notevpos & stp.VPosition < notevpos + duration
                            select stp;

                double stop_beats = stops.Sum(x => (double)x.Value / 10000.0d) / 48d;
                stop_contrib += current_bps * stop_beats;

            }

            return stop_contrib + bpm_contrib;
        }

        private void POBStorm_Click(object sender, EventArgs e)
        {

        }

        private void POBMirror_Click(object sender, EventArgs e)
        {
            int xI1;
            iBMSC.UndoRedo.LinkedURCmd xUndo = null;
            iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
            var xBaseRedo = xRedo;
            // xRedo &= sCmdKM(niA1, .VPosition, .Value, IIf(NTInput, .Length, .LongNote), .Hidden, RealColumnToEnabled(niA7) - RealColumnToEnabled(niA1), 0, True) & vbCrLf
            // xUndo &= sCmdKM(niA7, .VPosition, .Value, IIf(NTInput, .Length, .LongNote), .Hidden, RealColumnToEnabled(niA1) - RealColumnToEnabled(niA7), 0, True) & vbCrLf

            int xCol = 0;
            var loopTo = Information.UBound(Notes);
            for (xI1 = 1; xI1 <= loopTo; xI1++)
            {
                if (!Notes[xI1].Selected)
                    continue;

                switch (Notes[xI1].ColumnIndex)
                {
                    case MainWindow.niA1:
                        {
                            xCol = MainWindow.niA7;
                            break;
                        }
                    case MainWindow.niA2:
                        {
                            xCol = MainWindow.niA6;
                            break;
                        }
                    case MainWindow.niA3:
                        {
                            xCol = MainWindow.niA5;
                            break;
                        }
                    case MainWindow.niA4:
                        {
                            xCol = MainWindow.niA4;
                            break;
                        }
                    case MainWindow.niA5:
                        {
                            xCol = MainWindow.niA3;
                            break;
                        }
                    case MainWindow.niA6:
                        {
                            xCol = MainWindow.niA2;
                            break;
                        }
                    case MainWindow.niA7:
                        {
                            xCol = MainWindow.niA1;
                            break;
                        }

                    default:
                        {
                            continue;
                        }
                }

                this.RedoMoveNote(Notes[xI1], xCol, Notes[xI1].VPosition, ref xUndo, ref xRedo);
                Notes[xI1].ColumnIndex = xCol;
            }

            this.AddUndo(xUndo, xBaseRedo.Next);
            UpdatePairing();
            this.RefreshPanelAll();
        }







        private void ValidateSelection()
        {
            if (vSelStart < 0d)
            {
                vSelLength += vSelStart;
                vSelHalf += vSelStart;
                vSelStart = 0d;
            }
            if (vSelStart > GetMaxVPosition() - 1d)
            {
                vSelLength += vSelStart - GetMaxVPosition() + 1d;
                vSelHalf += vSelStart - GetMaxVPosition() + 1d;
                vSelStart = GetMaxVPosition() - 1d;
            }
            if (vSelStart + vSelLength < 0d)
                vSelLength = -vSelStart;
            if (vSelStart + vSelLength > GetMaxVPosition() - 1d)
                vSelLength = GetMaxVPosition() - 1d - vSelStart;

            if (Math.Sign(vSelHalf) != Math.Sign(vSelLength))
                vSelHalf = 0d;
            if (Math.Abs(vSelHalf) > Math.Abs(vSelLength))
                vSelHalf = vSelLength;
        }



        private void TVCM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TVCM.Text = Conversion.Val(TVCM.Text).ToString();
                if (Conversion.Val(TVCM.Text) <= 0d)
                {
                    Interaction.MsgBox(iBMSC.Strings.Messages.NegativeFactorError, MsgBoxStyle.Critical, iBMSC.Strings.Messages.Err);
                    TVCM.Text = 1.ToString();
                    TVCM.Focus();
                    TVCM.SelectAll();
                }
                else
                {
                    this.BVCApply_Click(BVCApply, new EventArgs());
                }
            }
        }

        private void TVCM_LostFocus(object sender, EventArgs e)
        {
            TVCM.Text = Conversion.Val(TVCM.Text).ToString();
            if (Conversion.Val(TVCM.Text) <= 0d)
            {
                Interaction.MsgBox(iBMSC.Strings.Messages.NegativeFactorError, MsgBoxStyle.Critical, iBMSC.Strings.Messages.Err);
                TVCM.Text = 1.ToString();
                TVCM.Focus();
                TVCM.SelectAll();
            }
        }

        private void TVCD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TVCD.Text = Conversion.Val(TVCD.Text).ToString();
                if (Conversion.Val(TVCD.Text) <= 0d)
                {
                    Interaction.MsgBox(iBMSC.Strings.Messages.NegativeDivisorError, MsgBoxStyle.Critical, iBMSC.Strings.Messages.Err);
                    TVCD.Text = 1.ToString();
                    TVCD.Focus();
                    TVCD.SelectAll();
                }
                else
                {
                    this.BVCApply_Click(BVCApply, new EventArgs());
                }
            }
        }

        private void TVCD_LostFocus(object sender, EventArgs e)
        {
            TVCD.Text = Conversion.Val(TVCD.Text).ToString();
            if (Conversion.Val(TVCD.Text) <= 0d)
            {
                Interaction.MsgBox(iBMSC.Strings.Messages.NegativeDivisorError, MsgBoxStyle.Critical, iBMSC.Strings.Messages.Err);
                TVCD.Text = 1.ToString();
                TVCD.Focus();
                TVCD.SelectAll();
            }
        }

        private void TVCBPM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TVCBPM.Text = Conversion.Val(TVCBPM.Text).ToString();
                if (Conversion.Val(TVCBPM.Text) <= 0d)
                {
                    Interaction.MsgBox(iBMSC.Strings.Messages.NegativeDivisorError, MsgBoxStyle.Critical, iBMSC.Strings.Messages.Err);
                    TVCBPM.Text = ((double)Notes[0].Value / 10000d).ToString();
                    TVCBPM.Focus();
                    TVCBPM.SelectAll();
                }
                else
                {
                    this.BVCCalculate_Click(BVCCalculate, new EventArgs());
                }
            }
        }

        private void TVCBPM_LostFocus(object sender, EventArgs e)
        {
            TVCBPM.Text = Conversion.Val(TVCBPM.Text).ToString();
            if (Conversion.Val(TVCBPM.Text) <= 0d)
            {
                Interaction.MsgBox(iBMSC.Strings.Messages.NegativeDivisorError, MsgBoxStyle.Critical, iBMSC.Strings.Messages.Err);
                TVCBPM.Text = ((double)Notes[0].Value / 10000d).ToString();
                TVCBPM.Focus();
                TVCBPM.SelectAll();
            }
        }

        private int FindNoteIndex(iBMSC.Editor.Note note)
        {
            int xI1;
            if (NTInput)
            {
                var loopTo = Information.UBound(Notes);
                for (xI1 = 1; xI1 <= loopTo; xI1++)
                {
                    if (Notes[xI1].equalsNT(note))
                        return xI1;
                }
            }
            else
            {
                var loopTo1 = Information.UBound(Notes);
                for (xI1 = 1; xI1 <= loopTo1; xI1++)
                {
                    if (Notes[xI1].equalsBMSE(note))
                        return xI1;
                }
            }
            return xI1;
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
            // KMouseDown = -1
            SelectedNotes = new iBMSC.Editor.Note[0];
            if (sUndo[sI].ofType() == iBMSC.UndoRedo.opNoOperation)
                return;
            this.PerformCommand(sUndo[sI]);
            sI = sIM();

            TBUndo.Enabled = sUndo[sI].ofType() != iBMSC.UndoRedo.opNoOperation;
            TBRedo.Enabled = sRedo[sIA()].ofType() != iBMSC.UndoRedo.opNoOperation;
            mnUndo.Enabled = sUndo[sI].ofType() != iBMSC.UndoRedo.opNoOperation;
            mnRedo.Enabled = sRedo[sIA()].ofType() != iBMSC.UndoRedo.opNoOperation;
        }

        private void TBRedo_Click(object sender, EventArgs e)
        {
            KMouseOver = -1;
            // KMouseDown = -1
            SelectedNotes = new iBMSC.Editor.Note[0];
            if (sRedo[sIA()].ofType() == iBMSC.UndoRedo.opNoOperation)
                return;
            this.PerformCommand(sRedo[sIA()]);
            sI = sIA();

            TBUndo.Enabled = sUndo[sI].ofType() != iBMSC.UndoRedo.opNoOperation;
            TBRedo.Enabled = sRedo[sIA()].ofType() != iBMSC.UndoRedo.opNoOperation;
            mnUndo.Enabled = sUndo[sI].ofType() != iBMSC.UndoRedo.opNoOperation;
            mnRedo.Enabled = sRedo[sIA()].ofType() != iBMSC.UndoRedo.opNoOperation;
        }

        // Undo appends before, Redo appends after.
        // After a sequence of Commands, 
        // Undo will be the first one to execute, 
        // Redo will be the last one to execute.
        // Remember to save the first Redo.

        // In case where undo is Nothing: Dont worry.
        // In case where redo is Nothing: 
        // If only one redo is in a sequence, put Nothing.
        // If several redo are in a sequence, 
        // Create Void first. 
        // Record its reference into a seperate copy. (xBaseRedo = xRedo)
        // Use this xRedo as the BaseRedo.
        // When calling AddUndo subroutine, use xBaseRedo.Next as cRedo.

        // Dim xUndo As UndoRedo.LinkedURCmd = Nothing
        // Dim xRedo As UndoRedo.LinkedURCmd = Nothing
        // ... 'Me.RedoRemoveNote(K(xI1), True, xUndo, xRedo)
        // AddUndo(xUndo, xRedo)

        // Dim xUndo As UndoRedo.LinkedURCmd = Nothing
        // Dim xRedo As New UndoRedo.Void
        // Dim xBaseRedo As UndoRedo.LinkedURCmd = xRedo
        // ... 'Me.RedoRemoveNote(K(xI1), True, xUndo, xRedo)
        // AddUndo(xUndo, xBaseRedo.Next)



        private void TBAbout_Click(object sender, EventArgs e)
        {
            var Aboutboxx1 = new iBMSC.AboutBox1();
            // If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\About.png") Then
            Aboutboxx1.bBitmap = iBMSC.Properties.Resources.About0;
            // Aboutboxx1.SelectBitmap()
            Aboutboxx1.ClientSize = new Size(1000, 500);
            Aboutboxx1.ClickToCopy.Visible = true;
            Aboutboxx1.ShowDialog(this);
            // Else
            // MsgBox(locale.Messages.cannotfind & " ""About.png""", MsgBoxStyle.Critical, locale.Messages.err)
            // End If
        }

        private void TBOptions_Click(object sender, EventArgs e)
        {

            var xDiag = new iBMSC.OpVisual(vo, this.column, LWAV.Font);
            xDiag.ShowDialog(this);
            UpdateColumnsX();
            this.RefreshPanelAll();
        }

        private void AddToPOWAV(string[] xPath)
        {
            var xIndices = new int[LWAV.SelectedIndices.Count];
            LWAV.SelectedIndices.CopyTo(xIndices, 0);
            if (xIndices.Length == 0)
                return;

            if (xIndices.Length < xPath.Length)
            {
                int i = xIndices.Length;
                int currWavIndex = xIndices[Information.UBound(xIndices)] + 1;
                Array.Resize(ref xIndices, Information.UBound(xPath) + 1);

                while (i < xIndices.Length & currWavIndex <= 1294)
                {
                    while (currWavIndex <= 1294 && !string.IsNullOrEmpty(hWAV[currWavIndex + 1]))
                        currWavIndex += 1;
                    if (currWavIndex > 1294)
                        break;

                    xIndices[i] = currWavIndex;
                    currWavIndex += 1;
                    i += 1;
                }

                if (currWavIndex > 1294)
                {
                    Array.Resize(ref xPath, i);
                    Array.Resize(ref xIndices, i);
                }
            }

            // Dim xI2 As Integer = 0
            for (int xI1 = 0, loopTo = Information.UBound(xPath); xI1 <= loopTo; xI1++)
            {
                // If xI2 > UBound(xIndices) Then Exit For
                // hWAV(xIndices(xI2) + 1) = GetFileName(xPath(xI1))
                // LWAV.Items.Item(xIndices(xI2)) = C10to36(xIndices(xI2) + 1) & ": " & GetFileName(xPath(xI1))
                hWAV[xIndices[xI1] + 1] = GetFileName(xPath[xI1]);
                LWAV.Items[xIndices[xI1]] = iBMSC.Editor.Functions.C10to36((long)(xIndices[xI1] + 1)) + ": " + GetFileName(xPath[xI1]);
                // xI2 += 1
            }

            LWAV.SelectedIndices.Clear();
            for (int xI1 = 0, loopTo1 = Conversions.ToInteger(Interaction.IIf(Information.UBound(xIndices) < Information.UBound(xPath), Information.UBound(xIndices), Information.UBound(xPath))); xI1 <= loopTo1; xI1++)
                LWAV.SelectedIndices.Add(xIndices[xI1]);

            if (IsSaved)
                SetIsSaved(false);
            this.RefreshPanelAll();
        }

        private void POWAV_DragDrop(object sender, DragEventArgs e)
        {
            DDFileName = new string[0];
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
                return;

            string[] xOrigPath = (string[])e.Data.GetData(DataFormats.FileDrop);
            var xPath = FilterFileBySupported(xOrigPath, SupportedAudioExtension);
            Array.Sort(xPath);
            if (xPath.Length == 0)
            {
                this.RefreshPanelAll();
                return;
            }

            AddToPOWAV(xPath);
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
            this.RefreshPanelAll();
        }

        private void POWAV_DragLeave(object sender, EventArgs e)
        {
            DDFileName = new string[0];
            this.RefreshPanelAll();
        }

        private void POWAV_Resize(object sender, EventArgs e)
        {
            LWAV.Height = Conversions.ToInteger(Operators.SubtractObject(sender.Height, 25));
        }

        private void AddToPOBMP(string[] xPath)
        {
            var xIndices = new int[LBMP.SelectedIndices.Count];
            LBMP.SelectedIndices.CopyTo(xIndices, 0);
            if (xIndices.Length == 0)
                return;

            if (xIndices.Length < xPath.Length)
            {
                int i = xIndices.Length;
                int currBmpIndex = xIndices[Information.UBound(xIndices)] + 1;
                Array.Resize(ref xIndices, Information.UBound(xPath) + 1);

                while (i < xIndices.Length & currBmpIndex <= 1294)
                {
                    while (currBmpIndex <= 1294 && !string.IsNullOrEmpty(hBMP[currBmpIndex + 1]))
                        currBmpIndex += 1;
                    if (currBmpIndex > 1294)
                        break;

                    xIndices[i] = currBmpIndex;
                    currBmpIndex += 1;
                    i += 1;
                }

                if (currBmpIndex > 1294)
                {
                    Array.Resize(ref xPath, i);
                    Array.Resize(ref xIndices, i);
                }
            }

            // Dim xI2 As Integer = 0
            for (int xI1 = 0, loopTo = Information.UBound(xPath); xI1 <= loopTo; xI1++)
            {
                // If xI2 > UBound(xIndices) Then Exit For
                // hBMP(xIndices(xI2) + 1) = GetFileName(xPath(xI1))
                // LBMP.Items.Item(xIndices(xI2)) = C10to36(xIndices(xI2) + 1) & ": " & GetFileName(xPath(xI1))
                hBMP[xIndices[xI1] + 1] = GetFileName(xPath[xI1]);
                LBMP.Items[xIndices[xI1]] = iBMSC.Editor.Functions.C10to36((long)(xIndices[xI1] + 1)) + ": " + GetFileName(xPath[xI1]);
                // xI2 += 1
            }

            LBMP.SelectedIndices.Clear();
            for (int xI1 = 0, loopTo1 = Conversions.ToInteger(Interaction.IIf(Information.UBound(xIndices) < Information.UBound(xPath), Information.UBound(xIndices), Information.UBound(xPath))); xI1 <= loopTo1; xI1++)
                LBMP.SelectedIndices.Add(xIndices[xI1]);

            if (IsSaved)
                SetIsSaved(false);
            this.RefreshPanelAll();
        }

        private void POBMP_DragDrop(object sender, DragEventArgs e)
        {
            DDFileName = new string[0];
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
                return;

            string[] xOrigPath = (string[])e.Data.GetData(DataFormats.FileDrop);
            var xPath = FilterFileBySupported(xOrigPath, SupportedImageExtension);
            Array.Sort(xPath);
            if (xPath.Length == 0)
            {
                this.RefreshPanelAll();
                return;
            }

            AddToPOBMP(xPath);
        }

        private void POBMP_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                DDFileName = FilterFileBySupported((string[])e.Data.GetData(DataFormats.FileDrop), SupportedImageExtension);
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
            this.RefreshPanelAll();
        }

        private void POBMP_DragLeave(object sender, EventArgs e)
        {
            DDFileName = new string[0];
            this.RefreshPanelAll();
        }

        private void POBMP_Resize(object sender, EventArgs e)
        {
            LBMP.Height = Conversions.ToInteger(Operators.SubtractObject(sender.Height, 25));
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
            sender.ForeColor = (object)Color.White;
        }
        private void mn_DropDownOpened(object sender, EventArgs e)
        {
            sender.ForeColor = (object)Color.Black;
        }
        private void mn_MouseEnter(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(sender.Pressed))
                return;
            sender.ForeColor = (object)Color.Black;
        }
        private void mn_MouseLeave(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(sender.Pressed))
                return;
            sender.ForeColor = (object)Color.White;
        }

        private void TBPOptions_Click(object sender, EventArgs e)
        {
            var xDOp = new iBMSC.OpPlayer(CurrentPlayer);
            xDOp.ShowDialog(this);
        }

        private void THGenre_TextChanged(object sender, EventArgs e)
        {
            if (IsSaved)
                SetIsSaved(false);
        }

        private void CHLnObj_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsSaved)
                SetIsSaved(false);
            LnObj = CHLnObj.SelectedIndex;
            UpdatePairing();
            this.RefreshPanelAll();
        }

        private void ConvertBMSE2NT()
        {
            SelectedNotes = new iBMSC.Editor.Note[0];
            SortByVPositionInsertion();

            for (int i2 = 0, loopTo = Information.UBound(Notes); i2 <= loopTo; i2++)
                Notes[i2].Length = 0.0d;

            int i = 1;
            int j = 0;
            int xUbound = Information.UBound(Notes);

            while (i <= xUbound)
            {
                if (!Notes[i].LongNote)
                {
                    i += 1;
                    continue;
                }

                var loopTo1 = xUbound;
                for (j = i + 1; j <= loopTo1; j++)
                {
                    if (Notes[j].ColumnIndex != Notes[i].ColumnIndex)
                        continue;

                    if (Notes[j].LongNote)
                    {
                        Notes[i].Length = Notes[j].VPosition - Notes[i].VPosition;
                        for (int j2 = j, loopTo2 = xUbound - 1; j2 <= loopTo2; j2++)
                            Notes[j2] = Notes[j2 + 1];
                        xUbound -= 1;
                        break;
                    }

                    else if (Notes[j].Value / 10000L == (long)LnObj)
                    {
                        break;

                    }
                }

                i += 1;
            }

            Array.Resize(ref Notes, xUbound + 1);

            var loopTo3 = xUbound;
            for (i = 0; i <= loopTo3; i++)
                Notes[i].LongNote = false;

            SortByVPositionInsertion();
            UpdatePairing();
            CalculateTotalPlayableNotes();
        }

        private void ConvertNT2BMSE()
        {
            SelectedNotes = new iBMSC.Editor.Note[0];
            var xK = new iBMSC.Editor.Note[1];
            xK[0] = Notes[0];

            for (int xI1 = 1, loopTo = Information.UBound(Notes); xI1 <= loopTo; xI1++)
            {
                Array.Resize(ref xK, Information.UBound(xK) + 1 + 1);
                {
                    ref var withBlock = ref xK[Information.UBound(xK)];
                    withBlock.ColumnIndex = Notes[xI1].ColumnIndex;
                    withBlock.LongNote = Notes[xI1].Length > 0d;
                    withBlock.Landmine = Notes[xI1].Landmine;
                    withBlock.Value = Notes[xI1].Value;
                    withBlock.VPosition = Notes[xI1].VPosition;
                    withBlock.Selected = Notes[xI1].Selected;
                    withBlock.Hidden = Notes[xI1].Hidden;
                }

                if (Notes[xI1].Length > 0d)
                {
                    Array.Resize(ref xK, Information.UBound(xK) + 1 + 1);
                    {
                        ref var withBlock1 = ref xK[Information.UBound(xK)];
                        withBlock1.ColumnIndex = Notes[xI1].ColumnIndex;
                        withBlock1.LongNote = true;
                        withBlock1.Landmine = false;
                        withBlock1.Value = Notes[xI1].Value;
                        withBlock1.VPosition = Notes[xI1].VPosition + Notes[xI1].Length;
                        withBlock1.Selected = Notes[xI1].Selected;
                        withBlock1.Hidden = Notes[xI1].Hidden;
                    }
                }
            }

            Notes = xK;

            SortByVPositionInsertion();
            UpdatePairing();
            CalculateTotalPlayableNotes();
        }

        private void TBWavIncrease_Click(object sender, EventArgs e)
        {
            iBMSC.UndoRedo.LinkedURCmd xUndo = null;
            iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
            var xBaseRedo = xRedo;

            TBWavIncrease.Checked = Conversions.ToBoolean(!sender.Checked);
            this.RedoWavIncrease(TBWavIncrease.Checked, ref xUndo, ref xRedo);
            this.AddUndo(xUndo, xBaseRedo.Next);
        }

        private void TBNTInput_Click(object sender, EventArgs e)
        {
            // Dim xUndo As String = "NT_" & CInt(NTInput) & "_0" & vbCrLf & "KZ" & vbCrLf & sCmdKsAll(False)
            // Dim xRedo As String = "NT_" & CInt(Not NTInput) & "_1"
            iBMSC.UndoRedo.LinkedURCmd xUndo = null;
            iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
            var xBaseRedo = xRedo;

            this.RedoRemoveNoteAll(false, ref xUndo, ref xRedo);

            NTInput = Conversions.ToBoolean(sender.Checked);

            TBNTInput.Checked = NTInput;
            mnNTInput.Checked = NTInput;
            POBLong.Enabled = !NTInput;
            POBLongShort.Enabled = !NTInput;

            bAdjustLength = false;
            bAdjustUpper = false;

            this.RedoNT(NTInput, false, ref xUndo, ref xRedo);
            if (NTInput)
            {
                ConvertBMSE2NT();
            }
            else
            {
                ConvertNT2BMSE();
            }
            this.RedoAddNoteAll(false, ref xUndo, ref xRedo);

            this.AddUndo(xUndo, xBaseRedo.Next);
            this.RefreshPanelAll();
        }

        private void THBPM_ValueChanged(object sender, EventArgs e)
        {
            if (Notes is not null)
            {
                Notes[0].Value = (long)Math.Round(THBPM.Value * 10000m);
                this.RefreshPanelAll();
            }
            if (IsSaved)
                SetIsSaved(false);
        }

        private void TWPosition_ValueChanged(object sender, EventArgs e)
        {
            this.wPosition = (double)TWPosition.Value;
            TWPosition2.Value = Conversions.ToInteger(Interaction.IIf(this.wPosition > (double)TWPosition2.Maximum, TWPosition2.Maximum, (object)this.wPosition));
            this.RefreshPanelAll();
        }

        private void TWLeft_ValueChanged(object sender, EventArgs e)
        {
            this.wLeft = (int)Math.Round(TWLeft.Value);
            TWLeft2.Value = Conversions.ToInteger(Interaction.IIf(this.wLeft > TWLeft2.Maximum, TWLeft2.Maximum, (object)this.wLeft));
            this.RefreshPanelAll();
        }

        private void TWWidth_ValueChanged(object sender, EventArgs e)
        {
            this.wWidth = (int)Math.Round(TWWidth.Value);
            TWWidth2.Value = Conversions.ToInteger(Interaction.IIf(this.wWidth > TWWidth2.Maximum, TWWidth2.Maximum, (object)this.wWidth));
            this.RefreshPanelAll();
        }

        private void TWPrecision_ValueChanged(object sender, EventArgs e)
        {
            this.wPrecision = (int)Math.Round(TWPrecision.Value);
            TWPrecision2.Value = Conversions.ToInteger(Interaction.IIf(this.wPrecision > TWPrecision2.Maximum, TWPrecision2.Maximum, (object)this.wPrecision));
            this.RefreshPanelAll();
        }

        private void TWTransparency_ValueChanged(object sender, EventArgs e)
        {
            TWTransparency2.Value = (int)Math.Round(TWTransparency.Value);
            vo.pBGMWav.Color = Color.FromArgb((int)Math.Round(TWTransparency.Value), vo.pBGMWav.Color);
            this.RefreshPanelAll();
        }

        private void TWSaturation_ValueChanged(object sender, EventArgs e)
        {
            var xColor = vo.pBGMWav.Color;
            TWSaturation2.Value = (int)Math.Round(TWSaturation.Value);
            vo.pBGMWav.Color = iBMSC.Editor.Functions.HSL2RGB((int)Math.Round(xColor.GetHue()), (int)Math.Round(TWSaturation.Value), (int)Math.Round(xColor.GetBrightness() * 1000f), (int)xColor.A);
            this.RefreshPanelAll();
        }

        private void TWPosition2_Scroll(object sender, EventArgs e)
        {
            TWPosition.Value = TWPosition2.Value;
        }

        private void TWLeft2_Scroll(object sender, EventArgs e)
        {
            TWLeft.Value = TWLeft2.Value;
        }

        private void TWWidth2_Scroll(object sender, EventArgs e)
        {
            TWWidth.Value = TWWidth2.Value;
        }

        private void TWPrecision2_Scroll(object sender, EventArgs e)
        {
            TWPrecision.Value = TWPrecision2.Value;
        }

        private void TWTransparency2_Scroll(object sender, EventArgs e)
        {
            TWTransparency.Value = TWTransparency2.Value;
        }

        private void TWSaturation2_Scroll(object sender, EventArgs e)
        {
            TWSaturation.Value = TWSaturation2.Value;
        }

        private void TBLangDef_Click(object sender, EventArgs e)
        {
            DispLang = "";
            Interaction.MsgBox(iBMSC.Strings.Messages.PreferencePostpone, MsgBoxStyle.Information);
        }

        private void TBLangRefresh_Click(object sender, EventArgs e)
        {
            for (int xI1 = cmnLanguage.Items.Count - 1; xI1 >= 3; xI1 -= 1)
            {
                try
                {
                    cmnLanguage.Items.RemoveAt(xI1);
                }
                catch (Exception ex)
                {
                }
            }

            if (!Directory.Exists(Application.ExecutablePath + @"\Data"))
                Directory.CreateDirectory(Application.ExecutablePath + @"\Data");
            var xFileNames = new DirectoryInfo(Application.ExecutablePath + @"\Data").GetFiles("*.Lang.xml");

            foreach (FileInfo xStr in xFileNames)
                this.LoadLocaleXML(xStr);
        }


        private void UpdateColumnsX()
        {
            this.column[0].Left = 0;
            // If col(0).Width = 0 Then col(0).Visible = False

            for (int xI1 = 1, loopTo = Information.UBound(this.column); xI1 <= loopTo; xI1++)
                // If col(xI1).Width = 0 Then col(xI1).Visible = False
                this.column[xI1].Left = Conversions.ToInteger(Operators.AddObject(this.column[xI1 - 1].Left, Interaction.IIf(this.column[xI1 - 1].isVisible, (object)this.column[xI1 - 1].Width, (object)0)));
            HSL.Maximum = this.nLeft(gColumns) + this.column[MainWindow.niB].Width;
            HS.Maximum = this.nLeft(gColumns) + this.column[MainWindow.niB].Width;
            HSR.Maximum = this.nLeft(gColumns) + this.column[MainWindow.niB].Width;
        }

        private void CHPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CHPlayer.SelectedIndex == -1)
                CHPlayer.SelectedIndex = 0;

            iPlayer = CHPlayer.SelectedIndex;
            bool xGP2 = iPlayer != 0;
            this.column[MainWindow.niD1].isVisible = xGP2;
            this.column[MainWindow.niD2].isVisible = xGP2;
            this.column[MainWindow.niD3].isVisible = xGP2;
            this.column[MainWindow.niD4].isVisible = xGP2;
            this.column[MainWindow.niD5].isVisible = xGP2;
            this.column[MainWindow.niD6].isVisible = xGP2;
            this.column[MainWindow.niD7].isVisible = xGP2;
            this.column[MainWindow.niD8].isVisible = xGP2;
            this.column[MainWindow.niS3].isVisible = xGP2;

            for (int xI1 = 1, loopTo = Information.UBound(Notes); xI1 <= loopTo; xI1++)
                Notes[xI1].Selected = Notes[xI1].Selected & this.nEnabled(Notes[xI1].ColumnIndex);
            // AddUndo(xUndo, xRedo)
            UpdateColumnsX();

            if (IsInitializing)
                return;
            this.RefreshPanelAll();
        }

        private void CGB_ValueChanged(object sender, EventArgs e)
        {
            gColumns = (int)Math.Round((decimal)MainWindow.niB + CGB.Value - 1m);
            UpdateColumnsX();
            this.RefreshPanelAll();
        }

        private void TBGOptions_Click(object sender, EventArgs e)
        {
            int xTE;
            switch (iBMSC.Editor.Functions.EncodingToString(TextEncoding).ToUpper() ?? "") // az: wow seriously? is there really no better way? 
            {
                case "SYSTEM ANSI":
                    {
                        xTE = 0;
                        break;
                    }
                case "LITTLE ENDIAN UTF16":
                    {
                        xTE = 1;
                        break;
                    }
                case "ASCII":
                    {
                        xTE = 2;
                        break;
                    }
                case "BIG ENDIAN UTF16":
                    {
                        xTE = 3;
                        break;
                    }
                case "LITTLE ENDIAN UTF32":
                    {
                        xTE = 4;
                        break;
                    }
                case "UTF7":
                    {
                        xTE = 5;
                        break;
                    }
                case "UTF8":
                    {
                        xTE = 6;
                        break;
                    }
                case "SJIS":
                    {
                        xTE = 7;
                        break;
                    }
                case "EUC-KR":
                    {
                        xTE = 8;
                        break;
                    }

                default:
                    {
                        xTE = 0;
                        break;
                    }
            }

            var xDiag = new iBMSC.OpGeneral(gWheel, gPgUpDn, MiddleButtonMoveMethod, xTE, (int)Math.Round(192.0d / BMSGridLimit), AutoSaveInterval, BeepWhileSaved, BPMx1296, STOPx1296, AutoFocusMouseEnter, FirstClickDisabled, ClickStopPreview);

            if (xDiag.ShowDialog() == DialogResult.OK)
            {
                gWheel = xDiag.zWheel;
                gPgUpDn = xDiag.zPgUpDn;
                TextEncoding = xDiag.zEncoding;
                // SortingMethod = .zSort
                MiddleButtonMoveMethod = xDiag.zMiddle;
                AutoSaveInterval = xDiag.zAutoSave;
                BMSGridLimit = 192.0d / (double)xDiag.zGridPartition;
                BeepWhileSaved = xDiag.cBeep.Checked;
                BPMx1296 = xDiag.cBpm1296.Checked;
                STOPx1296 = xDiag.cStop1296.Checked;
                AutoFocusMouseEnter = xDiag.cMEnterFocus.Checked;
                FirstClickDisabled = xDiag.cMClickFocus.Checked;
                ClickStopPreview = xDiag.cMStopPreview.Checked;
                if (Conversions.ToBoolean(AutoSaveInterval))
                    AutoSaveTimer.Interval = AutoSaveInterval;
                AutoSaveTimer.Enabled = Conversions.ToBoolean(AutoSaveInterval);
            }
        }

        private void POBLong_Click(object sender, EventArgs e)
        {
            if (NTInput)
                return;

            iBMSC.UndoRedo.LinkedURCmd xUndo = null;
            iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
            var xBaseRedo = xRedo;

            for (int xI1 = 1, loopTo = Information.UBound(Notes); xI1 <= loopTo; xI1++)
            {
                if (!Notes[xI1].Selected)
                    continue;

                this.RedoLongNoteModify(Notes[xI1], Notes[xI1].VPosition, Conversions.ToDouble(true), ref xUndo, ref xRedo);
                Notes[xI1].LongNote = true;
            }
            this.AddUndo(xUndo, xBaseRedo.Next);
            SortByVPositionInsertion();
            UpdatePairing();
            this.RefreshPanelAll();
        }

        private void POBNormal_Click(object sender, EventArgs e)
        {
            iBMSC.UndoRedo.LinkedURCmd xUndo = null;
            iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
            var xBaseRedo = xRedo;

            if (!NTInput)
            {
                for (int xI1 = 1, loopTo = Information.UBound(Notes); xI1 <= loopTo; xI1++)
                {
                    if (!Notes[xI1].Selected)
                        continue;

                    this.RedoLongNoteModify(Notes[xI1], Notes[xI1].VPosition, 0d, ref xUndo, ref xRedo);
                    Notes[xI1].LongNote = false;
                }
            }

            else
            {
                for (int xI1 = 1, loopTo1 = Information.UBound(Notes); xI1 <= loopTo1; xI1++)
                {
                    if (!Notes[xI1].Selected)
                        continue;

                    this.RedoLongNoteModify(Notes[xI1], Notes[xI1].VPosition, 0d, ref xUndo, ref xRedo);
                    Notes[xI1].Length = 0d;
                }
            }

            this.AddUndo(xUndo, xBaseRedo.Next);
            SortByVPositionInsertion();
            UpdatePairing();
            this.RefreshPanelAll();
        }

        private void POBNormalLong_Click(object sender, EventArgs e)
        {
            if (NTInput)
                return;

            iBMSC.UndoRedo.LinkedURCmd xUndo = null;
            iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
            var xBaseRedo = xRedo;

            for (int xI1 = 1, loopTo = Information.UBound(Notes); xI1 <= loopTo; xI1++)
            {
                if (!Notes[xI1].Selected)
                    continue;

                this.RedoLongNoteModify(Notes[xI1], Notes[xI1].VPosition, Conversions.ToDouble(!Notes[xI1].LongNote), ref xUndo, ref xRedo);
                Notes[xI1].LongNote = !Notes[xI1].LongNote;
            }

            this.AddUndo(xUndo, xBaseRedo.Next);
            SortByVPositionInsertion();
            UpdatePairing();
            this.RefreshPanelAll();
        }

        private void POBHidden_Click(object sender, EventArgs e)
        {
            iBMSC.UndoRedo.LinkedURCmd xUndo = null;
            iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
            var xBaseRedo = xRedo;

            for (int xI1 = 1, loopTo = Information.UBound(Notes); xI1 <= loopTo; xI1++)
            {
                if (!Notes[xI1].Selected)
                    continue;

                this.RedoHiddenNoteModify(Notes[xI1], true, true, ref xUndo, ref xRedo);
                Notes[xI1].Hidden = true;
            }
            this.AddUndo(xUndo, xBaseRedo.Next);
            SortByVPositionInsertion();
            UpdatePairing();
            this.RefreshPanelAll();
        }

        private void POBVisible_Click(object sender, EventArgs e)
        {
            iBMSC.UndoRedo.LinkedURCmd xUndo = null;
            iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
            var xBaseRedo = xRedo;

            for (int xI1 = 1, loopTo = Information.UBound(Notes); xI1 <= loopTo; xI1++)
            {
                if (!Notes[xI1].Selected)
                    continue;

                this.RedoHiddenNoteModify(Notes[xI1], false, true, ref xUndo, ref xRedo);
                Notes[xI1].Hidden = false;
            }
            this.AddUndo(xUndo, xBaseRedo.Next);
            SortByVPositionInsertion();
            UpdatePairing();
            this.RefreshPanelAll();
        }

        private void POBHiddenVisible_Click(object sender, EventArgs e)
        {
            iBMSC.UndoRedo.LinkedURCmd xUndo = null;
            iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
            var xBaseRedo = xRedo;

            for (int xI1 = 1, loopTo = Information.UBound(Notes); xI1 <= loopTo; xI1++)
            {
                if (!Notes[xI1].Selected)
                    continue;

                this.RedoHiddenNoteModify(Notes[xI1], !Notes[xI1].Hidden, true, ref xUndo, ref xRedo);
                Notes[xI1].Hidden = !Notes[xI1].Hidden;
            }
            this.AddUndo(xUndo, xBaseRedo.Next);
            SortByVPositionInsertion();
            UpdatePairing();
            this.RefreshPanelAll();
        }

        private void POBModify_Click(object sender, EventArgs e)
        {
            bool xNum = false;
            bool xLbl = false;
            int xI1;

            var loopTo = Information.UBound(Notes);
            for (xI1 = 1; xI1 <= loopTo; xI1++)
            {
                if (Notes[xI1].Selected && this.IsColumnNumeric(Notes[xI1].ColumnIndex))
                {
                    xNum = true;
                    break;
                }
            }
            var loopTo1 = Information.UBound(Notes);
            for (xI1 = 1; xI1 <= loopTo1; xI1++)
            {
                if (Notes[xI1].Selected && !this.IsColumnNumeric(Notes[xI1].ColumnIndex))
                {
                    xLbl = true;
                    break;
                }
            }
            if (!(xNum | xLbl))
                return;

            if (xNum)
            {
                double xD1 = Conversion.Val(Interaction.InputBox(iBMSC.Strings.Messages.PromptEnterNumeric, Text)) * 10000d;
                if (!(xD1 == 0d))
                {
                    if (xD1 <= 0d)
                        xD1 = 1d;

                    iBMSC.UndoRedo.LinkedURCmd xUndo = null;
                    iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
                    var xBaseRedo = xRedo;

                    var loopTo2 = Information.UBound(Notes);
                    for (xI1 = 1; xI1 <= loopTo2; xI1++)
                    {
                        if (!this.IsColumnNumeric(Notes[xI1].ColumnIndex))
                            continue;
                        if (!Notes[xI1].Selected)
                            continue;

                        this.RedoRelabelNote(Notes[xI1], (long)Math.Round(xD1), ref xUndo, ref xRedo);
                        Notes[xI1].Value = (long)Math.Round(xD1);
                    }
                    this.AddUndo(xUndo, xBaseRedo.Next);
                }
            }

            if (xLbl)
            {
                string xStr = Interaction.InputBox(iBMSC.Strings.Messages.PromptEnter, Text).Trim().ToUpper();

                if (xStr.Length == 0)
                    goto Jump2;
                if (xStr == "00" | xStr == "0")
                    goto Jump1;
                if (!(xStr.Length == 1) & !(xStr.Length == 2))
                    goto Jump1;

                int xI3 = (int)Convert.ToChar(xStr.Substring(1, 1)); // convet to ascii
                if (!(xI3 >= 48 & xI3 <= 57 | xI3 >= 65 & xI3 <= 90))
                    goto Jump1;
                if (xStr.Length == 2)
                {
                    int xI4 = (int)Convert.ToChar(xStr.Substring(2, 1)); // convet to ascii
                    if (!(xI4 >= 48 & xI4 <= 57 | xI4 >= 65 & xI4 <= 90))
                        goto Jump1;
                }
                int xVal = iBMSC.Editor.Functions.C36to10(xStr) * 10000;

                iBMSC.UndoRedo.LinkedURCmd xUndo = null;
                iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
                var xBaseRedo = xRedo;

                var loopTo3 = Information.UBound(Notes);
                for (xI1 = 1; xI1 <= loopTo3; xI1++)
                {
                    if (this.IsColumnNumeric(Notes[xI1].ColumnIndex))
                        continue;
                    if (!Notes[xI1].Selected)
                        continue;

                    this.RedoRelabelNote(Notes[xI1], (long)xVal, ref xUndo, ref xRedo);
                    Notes[xI1].Value = (long)xVal;
                }
                this.AddUndo(xUndo, xBaseRedo.Next);
                goto Jump2;
            Jump1:
                ;

                Interaction.MsgBox(iBMSC.Strings.Messages.InvalidLabel, MsgBoxStyle.Critical, iBMSC.Strings.Messages.Err);
            Jump2:
                ;

            }

            this.RefreshPanelAll();
        }

        private void TBMyO2_Click(object sender, EventArgs e)
        {
            var xDiag = new iBMSC.dgMyO2();
            xDiag.Show();
        }


        private void TBFind_Click(object sender, EventArgs e)
        {
            var xDiag = new iBMSC.diagFind(gColumns, iBMSC.Strings.Messages.Err, iBMSC.Strings.Messages.InvalidLabel);
            xDiag.Show();
        }

        private bool fdrCheck(iBMSC.Editor.Note xNote)
        {
            return Conversions.ToBoolean((object)(xNote.VPosition >= MeasureBottom[fdriMesL] & xNote.VPosition < MeasureBottom[fdriMesU] + MeasureLength[fdriMesU]) && Interaction.IIf(this.IsColumnNumeric(xNote.ColumnIndex), (object)(xNote.Value >= (long)fdriValL & xNote.Value <= (long)fdriValU), (object)(xNote.Value >= (long)fdriLblL & xNote.Value <= (long)fdriLblU)) && (object)(Array.IndexOf(fdriCol, xNote.ColumnIndex) != -1));
        }

        private bool fdrRangeS(bool xbLim1, bool xbLim2, bool xVal)
        {
            return !xbLim1 & xbLim2 & xVal | xbLim1 & !xbLim2 & !xVal | xbLim1 & xbLim2;
        }

        public void fdrSelect(int iRange, int xMesL, int xMesU, string xLblL, string xLblU, int xValL, int xValU, int[] iCol)
        {

            fdriMesL = xMesL;
            fdriMesU = xMesU;
            fdriLblL = iBMSC.Editor.Functions.C36to10(xLblL) * 10000;
            fdriLblU = iBMSC.Editor.Functions.C36to10(xLblU) * 10000;
            fdriValL = xValL;
            fdriValU = xValU;
            fdriCol = iCol;

            bool xbSel = iRange % 2 == 0;
            bool xbUnsel = iRange % 3 == 0;
            bool xbShort = iRange % 5 == 0;
            bool xbLong = iRange % 7 == 0;
            bool xbHidden = iRange % 11 == 0;
            bool xbVisible = iRange % 13 == 0;

            var xSel = new bool[Information.UBound(Notes) + 1];
            for (int xI1 = 1, loopTo = Information.UBound(Notes); xI1 <= loopTo; xI1++)
                xSel[xI1] = Notes[xI1].Selected;

            // Main process
            for (int xI1 = 1, loopTo1 = Information.UBound(Notes); xI1 <= loopTo1; xI1++)
            {
                bool bbba = xbSel & xSel[xI1];
                bool bbbb = xbUnsel & !xSel[xI1];
                bool bbbc = this.nEnabled(Notes[xI1].ColumnIndex);
                bool bbbd = fdrRangeS(xbShort, xbLong, Conversions.ToBoolean(Interaction.IIf(NTInput, (object)Notes[xI1].Length, (object)Notes[xI1].LongNote)));
                bool bbbe = this.fdrRangeS(xbVisible, xbHidden, Notes[xI1].Hidden);
                bool bbbf = fdrCheck(Notes[xI1]);

                if ((xbSel & xSel[xI1] | xbUnsel & !xSel[xI1] && this.nEnabled(Notes[xI1].ColumnIndex) && fdrRangeS(xbShort, xbLong, Conversions.ToBoolean(Interaction.IIf(NTInput, (object)Notes[xI1].Length, (object)Notes[xI1].LongNote)))) & this.fdrRangeS(xbVisible, xbHidden, Notes[xI1].Hidden))
                {
                    Notes[xI1].Selected = fdrCheck(Notes[xI1]);
                }
            }

            this.RefreshPanelAll();
            Interaction.Beep();
        }

        public void fdrUnselect(int iRange, int xMesL, int xMesU, string xLblL, string xLblU, int xValL, int xValU, int[] iCol)
        {

            fdriMesL = xMesL;
            fdriMesU = xMesU;
            fdriLblL = iBMSC.Editor.Functions.C36to10(xLblL) * 10000;
            fdriLblU = iBMSC.Editor.Functions.C36to10(xLblU) * 10000;
            fdriValL = xValL;
            fdriValU = xValU;
            fdriCol = iCol;

            bool xbSel = iRange % 2 == 0;
            bool xbUnsel = iRange % 3 == 0;
            bool xbShort = iRange % 5 == 0;
            bool xbLong = iRange % 7 == 0;
            bool xbHidden = iRange % 11 == 0;
            bool xbVisible = iRange % 13 == 0;

            var xSel = new bool[Information.UBound(Notes) + 1];
            for (int xI1 = 1, loopTo = Information.UBound(Notes); xI1 <= loopTo; xI1++)
                xSel[xI1] = Notes[xI1].Selected;

            // Main process
            for (int xI1 = 1, loopTo1 = Information.UBound(Notes); xI1 <= loopTo1; xI1++)
            {
                if ((xbSel & xSel[xI1] | xbUnsel & !xSel[xI1] && this.nEnabled(Notes[xI1].ColumnIndex) && fdrRangeS(xbShort, xbLong, Conversions.ToBoolean(Interaction.IIf(NTInput, (object)Notes[xI1].Length, (object)Notes[xI1].LongNote)))) & this.fdrRangeS(xbVisible, xbHidden, Notes[xI1].Hidden))
                {
                    Notes[xI1].Selected = !fdrCheck(Notes[xI1]);
                }
            }

            this.RefreshPanelAll();
            Interaction.Beep();
        }

        public void fdrDelete(int iRange, int xMesL, int xMesU, string xLblL, string xLblU, int xValL, int xValU, int[] iCol)
        {

            fdriMesL = xMesL;
            fdriMesU = xMesU;
            fdriLblL = iBMSC.Editor.Functions.C36to10(xLblL) * 10000;
            fdriLblU = iBMSC.Editor.Functions.C36to10(xLblU) * 10000;
            fdriValL = xValL;
            fdriValU = xValU;
            fdriCol = iCol;

            bool xbSel = iRange % 2 == 0;
            bool xbUnsel = iRange % 3 == 0;
            bool xbShort = iRange % 5 == 0;
            bool xbLong = iRange % 7 == 0;
            bool xbHidden = iRange % 11 == 0;
            bool xbVisible = iRange % 13 == 0;

            iBMSC.UndoRedo.LinkedURCmd xUndo = null;
            iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
            var xBaseRedo = xRedo;

            // Main process
            int xI1 = 1;
            while (xI1 <= Information.UBound(Notes))
            {
                if ((xbSel & Notes[xI1].Selected | xbUnsel & !Notes[xI1].Selected && fdrCheck(Notes[xI1]) && this.nEnabled(Notes[xI1].ColumnIndex) && fdrRangeS(xbShort, xbLong, Conversions.ToBoolean(Interaction.IIf(NTInput, (object)Notes[xI1].Length, (object)Notes[xI1].LongNote)))) & this.fdrRangeS(xbVisible, xbHidden, Notes[xI1].Hidden))
                {
                    this.RedoRemoveNote(Notes[xI1], ref xUndo, ref xRedo);
                    RemoveNote(xI1, false);
                }
                else
                {
                    xI1 += 1;
                }
            }

            this.AddUndo(xUndo, xBaseRedo.Next);
            SortByVPositionInsertion();
            UpdatePairing();
            this.RefreshPanelAll();
            CalculateTotalPlayableNotes();
            Interaction.Beep();
        }

        public void fdrReplaceL(int iRange, int xMesL, int xMesU, string xLblL, string xLblU, int xValL, int xValU, int[] iCol, string xReplaceLbl)
        {

            fdriMesL = xMesL;
            fdriMesU = xMesU;
            fdriLblL = iBMSC.Editor.Functions.C36to10(xLblL) * 10000;
            fdriLblU = iBMSC.Editor.Functions.C36to10(xLblU) * 10000;
            fdriValL = xValL;
            fdriValU = xValU;
            fdriCol = iCol;

            bool xbSel = iRange % 2 == 0;
            bool xbUnsel = iRange % 3 == 0;
            bool xbShort = iRange % 5 == 0;
            bool xbLong = iRange % 7 == 0;
            bool xbHidden = iRange % 11 == 0;
            bool xbVisible = iRange % 13 == 0;

            int xxLbl = iBMSC.Editor.Functions.C36to10(xReplaceLbl) * 10000;

            iBMSC.UndoRedo.LinkedURCmd xUndo = null;
            iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
            var xBaseRedo = xRedo;

            // Main process
            for (int xI1 = 1, loopTo = Information.UBound(Notes); xI1 <= loopTo; xI1++)
            {
                if (((xbSel & Notes[xI1].Selected | xbUnsel & !Notes[xI1].Selected && fdrCheck(Notes[xI1]) && this.nEnabled(Notes[xI1].ColumnIndex)) & !this.IsColumnNumeric(Notes[xI1].ColumnIndex) && fdrRangeS(xbShort, xbLong, Conversions.ToBoolean(Interaction.IIf(NTInput, (object)Notes[xI1].Length, (object)Notes[xI1].LongNote)))) & this.fdrRangeS(xbVisible, xbHidden, Notes[xI1].Hidden))
                {
                    // xUndo &= sCmdKC(K(xI1).ColumnIndex, K(xI1).VPosition, xxLbl, IIf(NTInput, K(xI1).Length, K(xI1).LongNote), K(xI1).Hidden, 0, 0, K(xI1).Value, IIf(NTInput, K(xI1).Length, K(xI1).LongNote), K(xI1).Hidden, True) & vbCrLf
                    // xRedo &= sCmdKC(K(xI1).ColumnIndex, K(xI1).VPosition, K(xI1).Value, IIf(NTInput, K(xI1).Length, K(xI1).LongNote), K(xI1).Hidden, 0, 0, xxLbl, IIf(NTInput, K(xI1).Length, K(xI1).LongNote), K(xI1).Hidden, True) & vbCrLf
                    this.RedoRelabelNote(Notes[xI1], (long)xxLbl, ref xUndo, ref xRedo);
                    Notes[xI1].Value = (long)xxLbl;
                }
            }

            this.AddUndo(xUndo, xBaseRedo.Next);
            this.RefreshPanelAll();
            Interaction.Beep();
        }

        public void fdrReplaceV(int iRange, int xMesL, int xMesU, string xLblL, string xLblU, int xValL, int xValU, int[] iCol, int xReplaceVal)
        {

            fdriMesL = xMesL;
            fdriMesU = xMesU;
            fdriLblL = iBMSC.Editor.Functions.C36to10(xLblL) * 10000;
            fdriLblU = iBMSC.Editor.Functions.C36to10(xLblU) * 10000;
            fdriValL = xValL;
            fdriValU = xValU;
            fdriCol = iCol;

            bool xbSel = iRange % 2 == 0;
            bool xbUnsel = iRange % 3 == 0;
            bool xbShort = iRange % 5 == 0;
            bool xbLong = iRange % 7 == 0;
            bool xbHidden = iRange % 11 == 0;
            bool xbVisible = iRange % 13 == 0;

            iBMSC.UndoRedo.LinkedURCmd xUndo = null;
            iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
            var xBaseRedo = xRedo;

            // Main process
            for (int xI1 = 1, loopTo = Information.UBound(Notes); xI1 <= loopTo; xI1++)
            {
                if (((xbSel & Notes[xI1].Selected | xbUnsel & !Notes[xI1].Selected && fdrCheck(Notes[xI1]) && this.nEnabled(Notes[xI1].ColumnIndex)) & this.IsColumnNumeric(Notes[xI1].ColumnIndex) && fdrRangeS(xbShort, xbLong, Conversions.ToBoolean(Interaction.IIf(NTInput, (object)Notes[xI1].Length, (object)Notes[xI1].LongNote)))) & this.fdrRangeS(xbVisible, xbHidden, Notes[xI1].Hidden))
                {
                    // xUndo &= sCmdKC(K(xI1).ColumnIndex, K(xI1).VPosition, xReplaceVal, IIf(NTInput, K(xI1).Length, K(xI1).LongNote), K(xI1).Hidden, 0, 0, K(xI1).Value, IIf(NTInput, K(xI1).Length, K(xI1).LongNote), K(xI1).Hidden, True) & vbCrLf
                    // xRedo &= sCmdKC(K(xI1).ColumnIndex, K(xI1).VPosition, K(xI1).Value, IIf(NTInput, K(xI1).Length, K(xI1).LongNote), K(xI1).Hidden, 0, 0, xReplaceVal, IIf(NTInput, K(xI1).Length, K(xI1).LongNote), K(xI1).Hidden, True) & vbCrLf
                    this.RedoRelabelNote(Notes[xI1], (long)xReplaceVal, ref xUndo, ref xRedo);
                    Notes[xI1].Value = (long)xReplaceVal;
                }
            }

            this.AddUndo(xUndo, xBaseRedo.Next);
            this.RefreshPanelAll();
            Interaction.Beep();
        }

        private void MInsert_Click(object sender, EventArgs e)
        {
            iBMSC.UndoRedo.LinkedURCmd xUndo = null;
            iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
            var xBaseRedo = xRedo;

            int xMeasure = MeasureAtDisplacement(menuVPosition);
            double xMLength = MeasureLength[xMeasure];
            double xVP = MeasureBottom[xMeasure];

            if (NTInput)
            {
                int xI1 = 1;
                while (xI1 <= Information.UBound(Notes))
                {
                    if (this.MeasureAtDisplacement(Notes[xI1].VPosition) >= 999)
                    {
                        this.RedoRemoveNote(Notes[xI1], ref xUndo, ref xRedo);
                        RemoveNote(xI1, false);
                    }
                    else
                    {
                        xI1 += 1;
                    }
                }

                double xdVP;
                var loopTo = Information.UBound(Notes);
                for (xI1 = 1; xI1 <= loopTo; xI1++)
                {
                    if (Notes[xI1].VPosition >= xVP & Notes[xI1].VPosition + Notes[xI1].Length <= MeasureBottom[999])
                    {
                        this.RedoMoveNote(Notes[xI1], Notes[xI1].ColumnIndex, Notes[xI1].VPosition + xMLength, ref xUndo, ref xRedo);
                        Notes[xI1].VPosition += xMLength;
                    }

                    else if (Notes[xI1].VPosition >= xVP)
                    {
                        xdVP = MeasureBottom[999] - 1d - Notes[xI1].VPosition - Notes[xI1].Length;
                        this.RedoLongNoteModify(Notes[xI1], Notes[xI1].VPosition + xMLength, Notes[xI1].Length + xdVP, ref xUndo, ref xRedo);
                        Notes[xI1].VPosition += xMLength;
                        Notes[xI1].Length += xdVP;
                    }

                    else if (Notes[xI1].VPosition + Notes[xI1].Length >= xVP)
                    {
                        xdVP = Conversions.ToDouble(Interaction.IIf(Notes[xI1].VPosition + Notes[xI1].Length > MeasureBottom[999] - 1d, (object)(GetMaxVPosition() - 1d - Notes[xI1].VPosition - Notes[xI1].Length), xMLength));
                        this.RedoLongNoteModify(Notes[xI1], Notes[xI1].VPosition, Notes[xI1].Length + xdVP, ref xUndo, ref xRedo);
                        Notes[xI1].Length += xdVP;
                    }
                }
            }

            else
            {
                int xI1 = 1;
                while (xI1 <= Information.UBound(Notes))
                {
                    if (this.MeasureAtDisplacement(Notes[xI1].VPosition) >= 999)
                    {
                        this.RedoRemoveNote(Notes[xI1], ref xUndo, ref xRedo);
                        RemoveNote(xI1, false);
                    }
                    else
                    {
                        xI1 += 1;
                    }
                }

                var loopTo1 = Information.UBound(Notes);
                for (xI1 = 1; xI1 <= loopTo1; xI1++)
                {
                    if (Notes[xI1].VPosition >= xVP)
                    {
                        this.RedoMoveNote(Notes[xI1], Notes[xI1].ColumnIndex, Notes[xI1].VPosition + xMLength, ref xUndo, ref xRedo);
                        Notes[xI1].VPosition += xMLength;
                    }
                }
            }

            for (int xI1 = 999, loopTo2 = xMeasure + 1; xI1 >= loopTo2; xI1 -= 1)
                MeasureLength[xI1] = MeasureLength[xI1 - 1];
            UpdateMeasureBottom();

            this.AddUndo(xUndo, xBaseRedo.Next);
            UpdatePairing();
            CalculateGreatestVPosition();
            CalculateTotalPlayableNotes();
            this.RefreshPanelAll();
        }

        private void MRemove_Click(object sender, EventArgs e)
        {
            iBMSC.UndoRedo.LinkedURCmd xUndo = null;
            iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
            var xBaseRedo = xRedo;

            int xMeasure = MeasureAtDisplacement(menuVPosition);
            double xMLength = MeasureLength[xMeasure];
            double xVP = MeasureBottom[xMeasure];

            if (NTInput)
            {
                int xI1 = 1;
                while (xI1 <= Information.UBound(Notes))
                {
                    if (this.MeasureAtDisplacement(Notes[xI1].VPosition) == xMeasure & this.MeasureAtDisplacement(Notes[xI1].VPosition + Notes[xI1].Length) == xMeasure)
                    {
                        this.RedoRemoveNote(Notes[xI1], ref xUndo, ref xRedo);
                        RemoveNote(xI1, false);
                    }
                    else
                    {
                        xI1 += 1;
                    }
                }

                double xdVP;
                xVP = MeasureBottom[xMeasure];
                var loopTo = Information.UBound(Notes);
                for (xI1 = 1; xI1 <= loopTo; xI1++)
                {
                    if (Notes[xI1].VPosition >= xVP + xMLength)
                    {
                        this.RedoMoveNote(Notes[xI1], Notes[xI1].ColumnIndex, Notes[xI1].VPosition - xMLength, ref xUndo, ref xRedo);
                        Notes[xI1].VPosition -= xMLength;
                    }

                    else if (Notes[xI1].VPosition >= xVP)
                    {
                        xdVP = xMLength + xVP - Notes[xI1].VPosition;
                        this.RedoLongNoteModify(Notes[xI1], Notes[xI1].VPosition + xdVP - xMLength, Notes[xI1].Length - xdVP, ref xUndo, ref xRedo);
                        Notes[xI1].VPosition += xdVP - xMLength;
                        Notes[xI1].Length -= xdVP;
                    }

                    else if (Notes[xI1].VPosition + Notes[xI1].Length >= xVP)
                    {
                        xdVP = Conversions.ToDouble(Interaction.IIf(Notes[xI1].VPosition + Notes[xI1].Length >= xVP + xMLength, xMLength, (object)(Notes[xI1].VPosition + Notes[xI1].Length - xVP + 1d)));
                        this.RedoLongNoteModify(Notes[xI1], Notes[xI1].VPosition, Notes[xI1].Length - xdVP, ref xUndo, ref xRedo);
                        Notes[xI1].Length -= xdVP;
                    }
                }
            }

            else
            {
                int xI1 = 1;
                while (xI1 <= Information.UBound(Notes))
                {
                    if (this.MeasureAtDisplacement(Notes[xI1].VPosition) == xMeasure)
                    {
                        this.RedoRemoveNote(Notes[xI1], ref xUndo, ref xRedo);
                        RemoveNote(xI1, false);
                    }
                    else
                    {
                        xI1 += 1;
                    }
                }

                xVP = MeasureBottom[xMeasure];
                var loopTo1 = Information.UBound(Notes);
                for (xI1 = 1; xI1 <= loopTo1; xI1++)
                {
                    if (Notes[xI1].VPosition >= xVP)
                    {
                        this.RedoMoveNote(Notes[xI1], Notes[xI1].ColumnIndex, Notes[xI1].VPosition - xMLength, ref xUndo, ref xRedo);
                        Notes[xI1].VPosition -= xMLength;
                    }
                }
            }

            for (int xI1 = 999, loopTo2 = xMeasure + 1; xI1 >= loopTo2; xI1 -= 1)
                MeasureLength[xI1 - 1] = MeasureLength[xI1];
            UpdateMeasureBottom();

            this.AddUndo(xUndo, xBaseRedo.Next);
            SortByVPositionInsertion();
            UpdatePairing();
            CalculateGreatestVPosition();
            CalculateTotalPlayableNotes();
            this.RefreshPanelAll();
        }

        private void TBThemeDef_Click(object sender, EventArgs e)
        {
            string xTempFileName = Application.ExecutablePath + @"\____TempFile.Theme.xml";
            File.WriteAllText(xTempFileName, iBMSC.Properties.Resources.O2Mania_Theme, System.Text.Encoding.Unicode);
            this.LoadSettings(xTempFileName);
            File.Delete(xTempFileName);

            this.RefreshPanelAll();
        }

        private void TBThemeSave_Click(object sender, EventArgs e)
        {
            var xDiag = new SaveFileDialog();
            xDiag.Filter = iBMSC.Strings.FileType.THEME_XML + "|*.Theme.xml";
            xDiag.DefaultExt = "Theme.xml";
            xDiag.InitialDirectory = Application.ExecutablePath + @"\Data";
            if (xDiag.ShowDialog() == DialogResult.Cancel)
                return;

            this.SaveSettings(xDiag.FileName, true);
            if (BeepWhileSaved)
                Interaction.Beep();
            TBThemeRefresh_Click(TBThemeRefresh, new EventArgs());
        }

        private void TBThemeRefresh_Click(object sender, EventArgs e)
        {
            for (int xI1 = cmnTheme.Items.Count - 1; xI1 >= 5; xI1 -= 1)
            {
                try
                {
                    cmnTheme.Items.RemoveAt(xI1);
                }
                catch (Exception ex)
                {
                }
            }

            if (!Directory.Exists(Application.ExecutablePath + @"\Data"))
                Directory.CreateDirectory(Application.ExecutablePath + @"\Data");
            var xFileNames = new DirectoryInfo(Application.ExecutablePath + @"\Data").GetFiles("*.Theme.xml");
            foreach (FileInfo xStr in xFileNames)
                cmnTheme.Items.Add(xStr.Name, null, this.LoadTheme);
        }

        private void TBThemeLoadComptability_Click(object sender, EventArgs e)
        {
            var xDiag = new OpenFileDialog();
            xDiag.Filter = iBMSC.Strings.FileType.TH + "|*.th";
            xDiag.DefaultExt = "th";
            xDiag.InitialDirectory = Application.ExecutablePath;
            if (Directory.Exists(Application.ExecutablePath + @"\Theme"))
                xDiag.InitialDirectory = Application.ExecutablePath + @"\Theme";
            if (xDiag.ShowDialog() == DialogResult.Cancel)
                return;

            this.LoadThemeComptability(xDiag.FileName);
            this.RefreshPanelAll();
        }

        /// <summary>
        /// Will return Double.PositiveInfinity if canceled.
        /// </summary>
        private double InputBoxDouble(string Prompt, double LBound, double UBound, string Title = "", string DefaultResponse = "")
        {
            double InputBoxDoubleRet = default;
            string xStr = Interaction.InputBox(Prompt, Title, DefaultResponse);
            if (string.IsNullOrEmpty(xStr))
                return double.PositiveInfinity;

            InputBoxDoubleRet = Conversion.Val(xStr);
            if (InputBoxDoubleRet > UBound)
                InputBoxDoubleRet = UBound;
            if (InputBoxDoubleRet < LBound)
                InputBoxDoubleRet = LBound;
            return InputBoxDoubleRet;
        }

        private void FSSS_Click(object sender, EventArgs e)
        {
            double xMax = Conversions.ToDouble(Interaction.IIf(vSelLength > 0d, GetMaxVPosition() - vSelLength, GetMaxVPosition()));
            double xMin = Conversions.ToDouble(Interaction.IIf(vSelLength < 0d, -vSelLength, 0));
            double xDouble = InputBoxDouble("Please enter a number between " + xMin + " and " + xMax + ".", xMin, xMax, DefaultResponse: vSelStart.ToString());
            if (xDouble == double.PositiveInfinity)
                return;

            vSelStart = xDouble;
            ValidateSelection();
            this.RefreshPanelAll();
            POStatusRefresh();
        }

        private void FSSL_Click(object sender, EventArgs e)
        {
            double xMax = GetMaxVPosition() - vSelStart;
            double xMin = -vSelStart;
            double xDouble = InputBoxDouble("Please enter a number between " + xMin + " and " + xMax + ".", xMin, xMax, DefaultResponse: vSelLength.ToString());
            if (xDouble == double.PositiveInfinity)
                return;

            vSelLength = xDouble;
            ValidateSelection();
            this.RefreshPanelAll();
            POStatusRefresh();
        }

        private void FSSH_Click(object sender, EventArgs e)
        {
            double xMax = Conversions.ToDouble(Interaction.IIf(vSelLength > 0d, vSelLength, 0));
            double xMin = Conversions.ToDouble(Interaction.IIf(vSelLength > 0d, 0, -vSelLength));
            double xDouble = InputBoxDouble("Please enter a number between " + xMin + " and " + xMax + ".", xMin, xMax, DefaultResponse: vSelHalf.ToString());
            if (xDouble == double.PositiveInfinity)
                return;

            vSelHalf = xDouble;
            ValidateSelection();
            this.RefreshPanelAll();
            POStatusRefresh();
        }

        private void BVCReverse_Click(object sender, EventArgs e)
        {
            vSelStart += vSelLength;
            vSelHalf -= vSelLength;
            vSelLength *= -1;
            ValidateSelection();
            this.RefreshPanelAll();
            POStatusRefresh();
        }

        private void AutoSaveTimer_Tick(object sender, EventArgs e)
        {
            var xTime = DateTime.Now;
            string xFileName;
            xFileName = Application.ExecutablePath + @"\AutoSave_" + xTime.Year + "_" + xTime.Month + "_" + xTime.Day + "_" + xTime.Hour + "_" + xTime.Minute + "_" + xTime.Second + "_" + xTime.Millisecond + ".IBMSC";
            // My.Computer.FileSystem.WriteAllText(xFileName, SaveiBMSC, False, System.Text.Encoding.Unicode)
            this.SaveiBMSC(xFileName);
            ;

            try
            {
                if (!string.IsNullOrEmpty(PreviousAutoSavedFileName))
                    File.Delete(PreviousAutoSavedFileName);
                ;
            }
            catch (Exception ex)
            {

            }

            PreviousAutoSavedFileName = xFileName;
        }

        private void CWAVMultiSelect_CheckedChanged(object sender, EventArgs e)
        {
            WAVMultiSelect = CWAVMultiSelect.Checked;
            LWAV.SelectionMode = (SelectionMode)Conversions.ToInteger(Interaction.IIf(WAVMultiSelect, SelectionMode.MultiExtended, SelectionMode.One));
            LBMP.SelectionMode = (SelectionMode)Conversions.ToInteger(Interaction.IIf(WAVMultiSelect, SelectionMode.MultiExtended, SelectionMode.One));
        }

        private void CWAVChangeLabel_CheckedChanged(object sender, EventArgs e)
        {
            WAVChangeLabel = CWAVChangeLabel.Checked;
        }

        private void BWAVUp_Click(object sender, EventArgs e)
        {
            if (LWAV.SelectedIndex == -1)
                return;

            iBMSC.UndoRedo.LinkedURCmd xUndo = null;
            iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
            var xBaseRedo = xRedo;

            var xIndices = new int[LWAV.SelectedIndices.Count];
            LWAV.SelectedIndices.CopyTo(xIndices, 0);

            int xS;
            for (xS = 0; xS <= 1294; xS++)
            {
                if (Array.IndexOf(xIndices, xS) == -1)
                    break;
            }

            string xStr = "";
            int xIndex = -1;
            for (int xI1 = xS; xI1 <= 1294; xI1++)
            {
                xIndex = Array.IndexOf(xIndices, xI1);
                if (xIndex != -1)
                {
                    xStr = hWAV[xI1 + 1];
                    hWAV[xI1 + 1] = hWAV[xI1];
                    hWAV[xI1] = xStr;

                    LWAV.Items[xI1] = iBMSC.Editor.Functions.C10to36((long)(xI1 + 1)) + ": " + hWAV[xI1 + 1];
                    LWAV.Items[xI1 - 1] = iBMSC.Editor.Functions.C10to36((long)xI1) + ": " + hWAV[xI1];

                    if (!WAVChangeLabel)
                        goto state1100;

                    string xL1 = iBMSC.Editor.Functions.C10to36((long)xI1);
                    string xL2 = iBMSC.Editor.Functions.C10to36((long)(xI1 + 1));
                    for (int xI2 = 1, loopTo = Information.UBound(Notes); xI2 <= loopTo; xI2++)
                    {
                        if (this.IsColumnNumeric(Notes[xI2].ColumnIndex))
                            continue;

                        if ((iBMSC.Editor.Functions.C10to36(Notes[xI2].Value / 10000L) ?? "") == (xL1 ?? ""))
                        {
                            this.RedoRelabelNote(Notes[xI2], (long)(xI1 * 10000 + 10000), ref xUndo, ref xRedo);
                            Notes[xI2].Value = (long)(xI1 * 10000 + 10000);
                        }

                        else if ((iBMSC.Editor.Functions.C10to36(Notes[xI2].Value / 10000L) ?? "") == (xL2 ?? ""))
                        {
                            this.RedoRelabelNote(Notes[xI2], (long)(xI1 * 10000), ref xUndo, ref xRedo);
                            Notes[xI2].Value = (long)(xI1 * 10000);

                        }
                    }

                state1100: xIndices[xIndex] += -1;
                }
            }

            LWAV.SelectedIndices.Clear();
            for (int xI1 = 0, loopTo1 = Information.UBound(xIndices); xI1 <= loopTo1; xI1++)
                LWAV.SelectedIndices.Add(xIndices[xI1]);

            this.AddUndo(xUndo, xBaseRedo.Next);
            this.RefreshPanelAll();
            POStatusRefresh();
        }

        private void BWAVDown_Click(object sender, EventArgs e)
        {
            if (LWAV.SelectedIndex == -1)
                return;

            iBMSC.UndoRedo.LinkedURCmd xUndo = null;
            iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
            var xBaseRedo = xRedo;

            var xIndices = new int[LWAV.SelectedIndices.Count];
            LWAV.SelectedIndices.CopyTo(xIndices, 0);

            int xS;
            for (xS = 1294; xS >= 0; xS -= 1)
            {
                if (Array.IndexOf(xIndices, xS) == -1)
                    break;
            }

            string xStr = "";
            int xIndex = -1;
            for (int xI1 = xS; xI1 >= 0; xI1 -= 1)
            {
                xIndex = Array.IndexOf(xIndices, xI1);
                if (xIndex != -1)
                {
                    xStr = hWAV[xI1 + 1];
                    hWAV[xI1 + 1] = hWAV[xI1 + 2];
                    hWAV[xI1 + 2] = xStr;

                    LWAV.Items[xI1] = iBMSC.Editor.Functions.C10to36((long)(xI1 + 1)) + ": " + hWAV[xI1 + 1];
                    LWAV.Items[xI1 + 1] = iBMSC.Editor.Functions.C10to36((long)(xI1 + 2)) + ": " + hWAV[xI1 + 2];

                    if (!WAVChangeLabel)
                        goto state1100;

                    string xL1 = iBMSC.Editor.Functions.C10to36((long)(xI1 + 2));
                    string xL2 = iBMSC.Editor.Functions.C10to36((long)(xI1 + 1));
                    for (int xI2 = 1, loopTo = Information.UBound(Notes); xI2 <= loopTo; xI2++)
                    {
                        if (this.IsColumnNumeric(Notes[xI2].ColumnIndex))
                            continue;

                        if ((iBMSC.Editor.Functions.C10to36(Notes[xI2].Value / 10000L) ?? "") == (xL1 ?? ""))
                        {
                            this.RedoRelabelNote(Notes[xI2], (long)(xI1 * 10000 + 10000), ref xUndo, ref xRedo);
                            Notes[xI2].Value = (long)(xI1 * 10000 + 10000);
                        }

                        else if ((iBMSC.Editor.Functions.C10to36(Notes[xI2].Value / 10000L) ?? "") == (xL2 ?? ""))
                        {
                            this.RedoRelabelNote(Notes[xI2], (long)(xI1 * 10000 + 20000), ref xUndo, ref xRedo);
                            Notes[xI2].Value = (long)(xI1 * 10000 + 20000);

                        }
                    }

                state1100:
                    xIndices[xIndex] += 1;
                }
            }

            LWAV.SelectedIndices.Clear();
            for (int xI1 = 0, loopTo1 = Information.UBound(xIndices); xI1 <= loopTo1; xI1++)
                LWAV.SelectedIndices.Add(xIndices[xI1]);

            this.AddUndo(xUndo, xBaseRedo.Next);
            this.RefreshPanelAll();
            POStatusRefresh();
        }

        private void BWAVBrowse_Click(object sender, EventArgs e)
        {
            var xDWAV = new OpenFileDialog();
            xDWAV.DefaultExt = "wav";
            xDWAV.Filter = iBMSC.Strings.FileType._wave + "|*.wav;*.ogg;*.mp3|" + iBMSC.Strings.FileType.WAV + "|*.wav|" + iBMSC.Strings.FileType.OGG + "|*.ogg|" + iBMSC.Strings.FileType.MP3 + "|*.mp3|" + iBMSC.Strings.FileType._all + "|*.*";
            xDWAV.InitialDirectory = Conversions.ToString(Interaction.IIf(string.IsNullOrEmpty(ExcludeFileName(FileName)), InitPath, ExcludeFileName(FileName)));
            xDWAV.Multiselect = WAVMultiSelect;

            if (xDWAV.ShowDialog() == DialogResult.Cancel)
                return;
            InitPath = ExcludeFileName(xDWAV.FileName);

            AddToPOWAV(xDWAV.FileNames);
        }

        private void BWAVRemove_Click(object sender, EventArgs e)
        {
            var xIndices = new int[LWAV.SelectedIndices.Count];
            LWAV.SelectedIndices.CopyTo(xIndices, 0);
            for (int xI1 = 0, loopTo = Information.UBound(xIndices); xI1 <= loopTo; xI1++)
            {
                hWAV[xIndices[xI1] + 1] = "";
                LWAV.Items[xIndices[xI1]] = iBMSC.Editor.Functions.C10to36((long)(xIndices[xI1] + 1)) + ": ";
            }

            LWAV.SelectedIndices.Clear();
            for (int xI1 = 0, loopTo1 = Information.UBound(xIndices); xI1 <= loopTo1; xI1++)
                LWAV.SelectedIndices.Add(xIndices[xI1]);

            if (IsSaved)
                SetIsSaved(false);
            this.RefreshPanelAll();
            POStatusRefresh();
        }

        private void BBMPUp_Click(object sender, EventArgs e)
        {
            if (LBMP.SelectedIndex == -1)
                return;

            iBMSC.UndoRedo.LinkedURCmd xUndo = null;
            iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
            var xBaseRedo = xRedo;

            var xIndices = new int[LBMP.SelectedIndices.Count];
            LBMP.SelectedIndices.CopyTo(xIndices, 0);

            int xS;
            for (xS = 0; xS <= 1294; xS++)
            {
                if (Array.IndexOf(xIndices, xS) == -1)
                    break;
            }

            string xStr = "";
            int xIndex = -1;
            for (int xI1 = xS; xI1 <= 1294; xI1++)
            {
                xIndex = Array.IndexOf(xIndices, xI1);
                if (xIndex != -1)
                {
                    xStr = hBMP[xI1 + 1];
                    hBMP[xI1 + 1] = hBMP[xI1];
                    hBMP[xI1] = xStr;

                    LBMP.Items[xI1] = iBMSC.Editor.Functions.C10to36((long)(xI1 + 1)) + ": " + hBMP[xI1 + 1];
                    LBMP.Items[xI1 - 1] = iBMSC.Editor.Functions.C10to36((long)xI1) + ": " + hBMP[xI1];

                    if (!WAVChangeLabel)
                        goto state1100;

                    string xL1 = iBMSC.Editor.Functions.C10to36((long)xI1);
                    string xL2 = iBMSC.Editor.Functions.C10to36((long)(xI1 + 1));
                    for (int xI2 = 1, loopTo = Information.UBound(Notes); xI2 <= loopTo; xI2++)
                    {
                        if (this.IsColumnNumeric(Notes[xI2].ColumnIndex))
                            continue;

                        if ((iBMSC.Editor.Functions.C10to36(Notes[xI2].Value / 10000L) ?? "") == (xL1 ?? ""))
                        {
                            this.RedoRelabelNote(Notes[xI2], (long)(xI1 * 10000 + 10000), ref xUndo, ref xRedo);
                            Notes[xI2].Value = (long)(xI1 * 10000 + 10000);
                        }

                        else if ((iBMSC.Editor.Functions.C10to36(Notes[xI2].Value / 10000L) ?? "") == (xL2 ?? ""))
                        {
                            this.RedoRelabelNote(Notes[xI2], (long)(xI1 * 10000), ref xUndo, ref xRedo);
                            Notes[xI2].Value = (long)(xI1 * 10000);

                        }
                    }

                state1100:
                    xIndices[xIndex] += -1;
                }
            }

            LBMP.SelectedIndices.Clear();
            for (int xI1 = 0, loopTo1 = Information.UBound(xIndices); xI1 <= loopTo1; xI1++)
                LBMP.SelectedIndices.Add(xIndices[xI1]);

            this.AddUndo(xUndo, xBaseRedo.Next);
            this.RefreshPanelAll();
            POStatusRefresh();
        }

        private void BBMPDown_Click(object sender, EventArgs e)
        {
            if (LBMP.SelectedIndex == -1)
                return;

            iBMSC.UndoRedo.LinkedURCmd xUndo = null;
            iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
            var xBaseRedo = xRedo;

            var xIndices = new int[LBMP.SelectedIndices.Count];
            LBMP.SelectedIndices.CopyTo(xIndices, 0);

            int xS;
            for (xS = 1294; xS >= 0; xS -= 1)
            {
                if (Array.IndexOf(xIndices, xS) == -1)
                    break;
            }

            string xStr = "";
            int xIndex = -1;
            for (int xI1 = xS; xI1 >= 0; xI1 -= 1)
            {
                xIndex = Array.IndexOf(xIndices, xI1);
                if (xIndex != -1)
                {
                    xStr = hBMP[xI1 + 1];
                    hBMP[xI1 + 1] = hBMP[xI1 + 2];
                    hBMP[xI1 + 2] = xStr;

                    LBMP.Items[xI1] = iBMSC.Editor.Functions.C10to36((long)(xI1 + 1)) + ": " + hBMP[xI1 + 1];
                    LBMP.Items[xI1 + 1] = iBMSC.Editor.Functions.C10to36((long)(xI1 + 2)) + ": " + hBMP[xI1 + 2];

                    if (!WAVChangeLabel)
                        goto state1100;

                    string xL1 = iBMSC.Editor.Functions.C10to36((long)(xI1 + 2));
                    string xL2 = iBMSC.Editor.Functions.C10to36((long)(xI1 + 1));
                    for (int xI2 = 1, loopTo = Information.UBound(Notes); xI2 <= loopTo; xI2++)
                    {
                        if (this.IsColumnNumeric(Notes[xI2].ColumnIndex))
                            continue;

                        if ((iBMSC.Editor.Functions.C10to36(Notes[xI2].Value / 10000L) ?? "") == (xL1 ?? ""))
                        {
                            this.RedoRelabelNote(Notes[xI2], (long)(xI1 * 10000 + 10000), ref xUndo, ref xRedo);
                            Notes[xI2].Value = (long)(xI1 * 10000 + 10000);
                        }

                        else if ((iBMSC.Editor.Functions.C10to36(Notes[xI2].Value / 10000L) ?? "") == (xL2 ?? ""))
                        {
                            this.RedoRelabelNote(Notes[xI2], (long)(xI1 * 10000 + 20000), ref xUndo, ref xRedo);
                            Notes[xI2].Value = (long)(xI1 * 10000 + 20000);

                        }
                    }

                state1100:
                    xIndices[xIndex] += 1;
                }
            }

            LBMP.SelectedIndices.Clear();
            for (int xI1 = 0, loopTo1 = Information.UBound(xIndices); xI1 <= loopTo1; xI1++)
                LBMP.SelectedIndices.Add(xIndices[xI1]);

            this.AddUndo(xUndo, xBaseRedo.Next);
            this.RefreshPanelAll();
            POStatusRefresh();
        }

        private void BBMPBrowse_Click(object sender, EventArgs e)
        {
            var xDBMP = new OpenFileDialog();
            xDBMP.DefaultExt = "bmp";
            xDBMP.Filter = iBMSC.Strings.FileType._image + "|*.bmp;*.png;*.jpg;*.jpeg;.gif|" + iBMSC.Strings.FileType._movie + "|*.mpg;*.m1v;*.m2v;*.avi;*.mp4;*.m4v;*.wmv;*.webm|" + iBMSC.Strings.FileType.BMP + "|*.bmp|" + iBMSC.Strings.FileType.PNG + "|*.png|" + iBMSC.Strings.FileType.JPG + "|*.jpg;*.jpeg|" + iBMSC.Strings.FileType.GIF + "|*.gif|" + iBMSC.Strings.FileType.MP4 + "|*.mp4;*.m4v|" + iBMSC.Strings.FileType.AVI + "|*.avi|" + iBMSC.Strings.FileType.MPG + "|*.mpg;*.m1v;*.m2v|" + iBMSC.Strings.FileType.WMV + "|*.wmv|" + iBMSC.Strings.FileType.WEBM + "|*.webm|" + iBMSC.Strings.FileType._all + "|*.*";
            xDBMP.InitialDirectory = Conversions.ToString(Interaction.IIf(string.IsNullOrEmpty(ExcludeFileName(FileName)), InitPath, ExcludeFileName(FileName)));
            xDBMP.Multiselect = WAVMultiSelect;

            if (xDBMP.ShowDialog() == DialogResult.Cancel)
                return;
            InitPath = ExcludeFileName(xDBMP.FileName);

            AddToPOBMP(xDBMP.FileNames);
        }

        private void BBMPRemove_Click(object sender, EventArgs e)
        {
            var xIndices = new int[LBMP.SelectedIndices.Count];
            LBMP.SelectedIndices.CopyTo(xIndices, 0);
            for (int xI1 = 0, loopTo = Information.UBound(xIndices); xI1 <= loopTo; xI1++)
            {
                hBMP[xIndices[xI1] + 1] = "";
                LBMP.Items[xIndices[xI1]] = iBMSC.Editor.Functions.C10to36((long)(xIndices[xI1] + 1)) + ": ";
            }

            LBMP.SelectedIndices.Clear();
            for (int xI1 = 0, loopTo1 = Information.UBound(xIndices); xI1 <= loopTo1; xI1++)
                LBMP.SelectedIndices.Add(xIndices[xI1]);

            if (IsSaved)
                SetIsSaved(false);
            this.RefreshPanelAll();
            POStatusRefresh();
        }

        private void mnMain_MouseDown(object sender, MouseEventArgs e) // , TBMain.MouseDown  ', pttl.MouseDown, pIsSaved.MouseDown
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0x112, 0xF012, 0);
                if (e.Clicks == 2)
                {
                    if (WindowState == FormWindowState.Maximized)
                        WindowState = FormWindowState.Normal;
                    else
                        WindowState = FormWindowState.Maximized;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                // mnSys.Show(sender, e.Location)
            }
        }

        private void mnSelectAll_Click(object sender, EventArgs e)
        {
            if (!((PMainIn.Focused || PMainInL.Focused) | PMainInR.Focused))
                return;
            for (int xI1 = 1, loopTo = Information.UBound(Notes); xI1 <= loopTo; xI1++)
                Notes[xI1].Selected = this.nEnabled(Notes[xI1].ColumnIndex);
            if (TBTimeSelect.Checked)
            {
                CalculateGreatestVPosition();
                vSelStart = 0d;
                vSelLength = MeasureBottom[MeasureAtDisplacement(GreatestVPosition)] + MeasureLength[MeasureAtDisplacement(GreatestVPosition)];
            }
            this.RefreshPanelAll();
            POStatusRefresh();
        }

        private void mnDelete_Click(object sender, EventArgs e)
        {
            if (!((PMainIn.Focused || PMainInL.Focused) | PMainInR.Focused))
                return;

            iBMSC.UndoRedo.LinkedURCmd xUndo = null;
            iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
            var xBaseRedo = xRedo;

            this.RedoRemoveNoteSelected(true, ref xUndo, ref xRedo);
            RemoveNotes(true);

            this.AddUndo(xUndo, xBaseRedo.Next);
            CalculateGreatestVPosition();
            CalculateTotalPlayableNotes();
            this.RefreshPanelAll();
            POStatusRefresh();
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
            // TBMain.BackColor = Color.FromArgb(64, 64, 64)

            foreach (ToolStripMenuItem xmn in mnMain.Items)
            {
                xmn.ForeColor = Color.White;
                xmn.DropDownClosed += mn_DropDownClosed;
                xmn.DropDownOpened += mn_DropDownOpened;
                xmn.MouseEnter += mn_MouseEnter;
                xmn.MouseLeave += mn_MouseLeave;
            }
        }

        private void DisableDWM()
        {
            mnMain.BackColor = SystemColors.Control;
            // TBMain.BackColor = SystemColors.Control

            foreach (ToolStripMenuItem xmn in mnMain.Items)
            {
                xmn.ForeColor = SystemColors.ControlText;
                xmn.DropDownClosed -= mn_DropDownClosed;
                xmn.DropDownOpened -= mn_DropDownOpened;
                xmn.MouseEnter -= mn_MouseEnter;
                xmn.MouseLeave -= mn_MouseLeave;
            }
        }

        private void ttlIcon_MouseDown(object sender, MouseEventArgs e)
        {
            // ttlIcon.Image = My.Resources.icon2_16
            // mnSys.Show(ttlIcon, 0, ttlIcon.Height)
        }
        private void ttlIcon_MouseEnter(object sender, EventArgs e)
        {
            // ttlIcon.Image = My.Resources.icon2_16_highlight
        }
        private void ttlIcon_MouseLeave(object sender, EventArgs e)
        {
            // ttlIcon.Image = My.Resources.icon2_16
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
            this.RefreshPanelAll();
        }
        private void CGShowS_CheckedChanged(object sender, EventArgs e)
        {
            gShowSubGrid = CGShowS.Checked;
            this.RefreshPanelAll();
        }
        private void CGShowBG_CheckedChanged(object sender, EventArgs e)
        {
            gShowBG = CGShowBG.Checked;
            this.RefreshPanelAll();
        }
        private void CGShowM_CheckedChanged(object sender, EventArgs e)
        {
            gShowMeasureNumber = CGShowM.Checked;
            this.RefreshPanelAll();
        }
        private void CGShowV_CheckedChanged(object sender, EventArgs e)
        {
            gShowVerticalLine = CGShowV.Checked;
            this.RefreshPanelAll();
        }
        private void CGShowMB_CheckedChanged(object sender, EventArgs e)
        {
            gShowMeasureBar = CGShowMB.Checked;
            this.RefreshPanelAll();
        }
        private void CGShowC_CheckedChanged(object sender, EventArgs e)
        {
            gShowC = CGShowC.Checked;
            this.RefreshPanelAll();
        }
        private void CGBLP_CheckedChanged(object sender, EventArgs e)
        {
            gDisplayBGAColumn = CGBLP.Checked;

            this.column[MainWindow.niBGA].isVisible = gDisplayBGAColumn;
            this.column[MainWindow.niLAYER].isVisible = gDisplayBGAColumn;
            this.column[MainWindow.niPOOR].isVisible = gDisplayBGAColumn;
            this.column[MainWindow.niS4].isVisible = gDisplayBGAColumn;

            if (IsInitializing)
                return;
            for (int xI1 = 1, loopTo = Information.UBound(Notes); xI1 <= loopTo; xI1++)
                Notes[xI1].Selected = Notes[xI1].Selected & this.nEnabled(Notes[xI1].ColumnIndex);
            // AddUndo(xUndo, xRedo)
            UpdateColumnsX();
            this.RefreshPanelAll();
        }
        private void CGSCROLL_CheckedChanged(object sender, EventArgs e)
        {
            gSCROLL = CGSCROLL.Checked;

            this.column[MainWindow.niSCROLL].isVisible = gSCROLL;

            if (IsInitializing)
                return;
            for (int xI1 = 1, loopTo = Information.UBound(Notes); xI1 <= loopTo; xI1++)
                Notes[xI1].Selected = Notes[xI1].Selected & this.nEnabled(Notes[xI1].ColumnIndex);
            // AddUndo(xUndo, xRedo)
            UpdateColumnsX();
            this.RefreshPanelAll();
        }
        private void CGSTOP_CheckedChanged(object sender, EventArgs e)
        {
            gSTOP = CGSTOP.Checked;

            this.column[MainWindow.niSTOP].isVisible = gSTOP;

            if (IsInitializing)
                return;
            for (int xI1 = 1, loopTo = Information.UBound(Notes); xI1 <= loopTo; xI1++)
                Notes[xI1].Selected = Notes[xI1].Selected & this.nEnabled(Notes[xI1].ColumnIndex);
            // AddUndo(xUndo, xRedo)
            UpdateColumnsX();
            this.RefreshPanelAll();
        }
        private void CGBPM_CheckedChanged(object sender, EventArgs e)
        {
            // Dim xUndo As UndoRedo.LinkedURCmd = Nothing
            // Dim xRedo As UndoRedo.LinkedURCmd = Nothing
            // Me.RedoChangeVisibleColumns(gBLP, gSTOP, iPlayer, gBLP, CGSTOP.Checked, iPlayer, xUndo, xRedo)
            gBPM = CGBPM.Checked;

            this.column[MainWindow.niBPM].isVisible = gBPM;

            if (IsInitializing)
                return;
            for (int xI1 = 1, loopTo = Information.UBound(Notes); xI1 <= loopTo; xI1++)
                Notes[xI1].Selected = Notes[xI1].Selected & this.nEnabled(Notes[xI1].ColumnIndex);
            // AddUndo(xUndo, xRedo)
            UpdateColumnsX();
            this.RefreshPanelAll();
        }

        private void CGDisableVertical_CheckedChanged(object sender, EventArgs e)
        {
            DisableVerticalMove = CGDisableVertical.Checked;
        }

        private void CBeatPreserve_Click(object sender, EventArgs e)
        {
            // If Not sender.Checked Then Exit Sub
            var xBeatList = new RadioButton[] { CBeatPreserve, CBeatMeasure, CBeatCut, CBeatScale };
            BeatChangeMode = Array.IndexOf(xBeatList, (RadioButton)sender);
            // For xI1 As Integer = 0 To mnBeat.Items.Count - 1
            // If xI1 <> BeatChangeMode Then CType(mnBeat.Items(xI1), ToolStripMenuItem).Checked = False
            // Next
            // sender.Checked = True
        }


        private void tBeatValue_LostFocus(object sender, EventArgs e)
        {
            double a;
            if (double.TryParse(tBeatValue.Text, out a))
            {
                if (a <= 0.0d | a >= 1000.0d)
                    tBeatValue.BackColor = Color.FromArgb(int.MinValue + 0x7FFFC0C0);
                else
                    tBeatValue.BackColor = default;

                tBeatValue.Text = a.ToString();
            }
        }



        private void ApplyBeat(double xRatio, string xDisplay)
        {
            SortByVPositionInsertion();

            iBMSC.UndoRedo.LinkedURCmd xUndo = null;
            iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
            var xBaseRedo = xRedo;

            this.RedoChangeMeasureLengthSelected(192d * xRatio, ref xUndo, ref xRedo);

            var xIndices = new int[LBeat.SelectedIndices.Count];
            LBeat.SelectedIndices.CopyTo(xIndices, 0);


            foreach (int xI1 in xIndices)
            {
                double dLength = xRatio * 192.0d - MeasureLength[xI1];
                double dRatio = xRatio * 192.0d / MeasureLength[xI1];

                double xBottom = 0d;
                for (int xI2 = 0, loopTo = xI1 - 1; xI2 <= loopTo; xI2++)
                    xBottom += MeasureLength[xI2];
                double xUpBefore = xBottom + MeasureLength[xI1];
                double xUpAfter = xUpBefore + dLength;

                switch (BeatChangeMode)
                {
                    case 1:
                        {
                        case2:
                            ;
                            int xI0;

                            if (NTInput)
                            {
                                var loopTo1 = Information.UBound(Notes);
                                for (xI0 = 1; xI0 <= loopTo1; xI0++)
                                {
                                    if (Notes[xI0].VPosition >= xUpBefore)
                                        break;
                                    if (Notes[xI0].VPosition + Notes[xI0].Length >= xUpBefore)
                                    {
                                        this.RedoLongNoteModify(Notes[xI0], Notes[xI0].VPosition, Notes[xI0].Length + dLength, ref xUndo, ref xRedo);
                                        Notes[xI0].Length += dLength;
                                    }
                                }
                            }
                            else
                            {
                                var loopTo2 = Information.UBound(Notes);
                                for (xI0 = 1; xI0 <= loopTo2; xI0++)
                                {
                                    if (Notes[xI0].VPosition >= xUpBefore)
                                        break;
                                }
                            }

                            for (int xI9 = xI0, loopTo3 = Information.UBound(Notes); xI9 <= loopTo3; xI9++)
                            {
                                this.RedoLongNoteModify(Notes[xI9], Notes[xI9].VPosition + dLength, Notes[xI9].Length, ref xUndo, ref xRedo);
                                Notes[xI9].VPosition += dLength;
                            }

                            break;
                        }

                    case 2:
                        {
                            if (dLength < 0d)
                            {
                                if (NTInput)
                                {
                                    int xI0 = 1;
                                    int xU = Information.UBound(Notes);
                                    while (xI0 <= xU)
                                    {
                                        if (Notes[xI0].VPosition < xUpAfter)
                                        {
                                            if (Notes[xI0].VPosition + Notes[xI0].Length >= xUpAfter & Notes[xI0].VPosition + Notes[xI0].Length < xUpBefore)
                                            {
                                                double nLen = xUpAfter - Notes[xI0].VPosition - 1.0d;
                                                this.RedoLongNoteModify(Notes[xI0], Notes[xI0].VPosition, nLen, ref xUndo, ref xRedo);
                                                Notes[xI0].Length = nLen;
                                            }
                                        }
                                        else if (Notes[xI0].VPosition < xUpBefore)
                                        {
                                            if (Notes[xI0].VPosition + Notes[xI0].Length < xUpBefore)
                                            {
                                                this.RedoRemoveNote(Notes[xI0], ref xUndo, ref xRedo);
                                                RemoveNote(xI0);
                                                xI0 -= 1;
                                                xU -= 1;
                                            }
                                            else
                                            {
                                                double nLen = Notes[xI0].Length - xUpBefore + Notes[xI0].VPosition;
                                                this.RedoLongNoteModify(Notes[xI0], xUpBefore, nLen, ref xUndo, ref xRedo);
                                                Notes[xI0].Length = nLen;
                                                Notes[xI0].VPosition = xUpBefore;
                                            }
                                        }
                                        xI0 += 1;
                                    }
                                }
                                else
                                {
                                    int xI0;
                                    int xI9;
                                    var loopTo4 = Information.UBound(Notes);
                                    for (xI0 = 1; xI0 <= loopTo4; xI0++)
                                    {
                                        if (Notes[xI0].VPosition >= xUpAfter)
                                            break;
                                    }
                                    var loopTo5 = Information.UBound(Notes);
                                    for (xI9 = xI0; xI9 <= loopTo5; xI9++)
                                    {
                                        if (Notes[xI9].VPosition >= xUpBefore)
                                            break;
                                    }

                                    for (int xI8 = xI0, loopTo6 = xI9 - 1; xI8 <= loopTo6; xI8++)
                                        this.RedoRemoveNote(Notes[xI8], ref xUndo, ref xRedo);
                                    for (int xI8 = xI9, loopTo7 = Information.UBound(Notes); xI8 <= loopTo7; xI8++)
                                        Notes[xI8 - xI9 + xI0] = Notes[xI8];
                                    Array.Resize(ref Notes, Information.UBound(Notes) - xI9 + xI0 + 1);
                                }
                            }

                            goto case 2;
                        }

                    case 3:
                        {
                            if (NTInput)
                            {
                                for (int xI0 = 1, loopTo8 = Information.UBound(Notes); xI0 <= loopTo8; xI0++)
                                {
                                    if (Notes[xI0].VPosition < xBottom)
                                    {
                                        if (Notes[xI0].VPosition + Notes[xI0].Length > xUpBefore)
                                        {
                                            this.RedoLongNoteModify(Notes[xI0], Notes[xI0].VPosition, Notes[xI0].Length + dLength, ref xUndo, ref xRedo);
                                            Notes[xI0].Length += dLength;
                                        }
                                        else if (Notes[xI0].VPosition + Notes[xI0].Length > xBottom)
                                        {
                                            double nLen = (Notes[xI0].Length + Notes[xI0].VPosition - xBottom) * dRatio + xBottom - Notes[xI0].VPosition;
                                            this.RedoLongNoteModify(Notes[xI0], Notes[xI0].VPosition, nLen, ref xUndo, ref xRedo);
                                            Notes[xI0].Length = nLen;
                                        }
                                    }
                                    else if (Notes[xI0].VPosition < xUpBefore)
                                    {
                                        if (Notes[xI0].VPosition + Notes[xI0].Length > xUpBefore)
                                        {
                                            double nLen = (xUpBefore - Notes[xI0].VPosition) * dRatio + Notes[xI0].VPosition + Notes[xI0].Length - xUpBefore;
                                            double nVPos = (Notes[xI0].VPosition - xBottom) * dRatio + xBottom;
                                            this.RedoLongNoteModify(Notes[xI0], nVPos, nLen, ref xUndo, ref xRedo);
                                            Notes[xI0].Length = nLen;
                                            Notes[xI0].VPosition = nVPos;
                                        }
                                        else
                                        {
                                            double nLen = Notes[xI0].Length * dRatio;
                                            double nVPos = (Notes[xI0].VPosition - xBottom) * dRatio + xBottom;
                                            this.RedoLongNoteModify(Notes[xI0], nVPos, nLen, ref xUndo, ref xRedo);
                                            Notes[xI0].Length = nLen;
                                            Notes[xI0].VPosition = nVPos;
                                        }
                                    }
                                    else
                                    {
                                        this.RedoLongNoteModify(Notes[xI0], Notes[xI0].VPosition + dLength, Notes[xI0].Length, ref xUndo, ref xRedo);
                                        Notes[xI0].VPosition += dLength;
                                    }
                                }
                            }
                            else
                            {
                                int xI0;
                                int xI9;
                                var loopTo9 = Information.UBound(Notes);
                                for (xI0 = 1; xI0 <= loopTo9; xI0++)
                                {
                                    if (Notes[xI0].VPosition >= xBottom)
                                        break;
                                }
                                var loopTo10 = Information.UBound(Notes);
                                for (xI9 = xI0; xI9 <= loopTo10; xI9++)
                                {
                                    if (Notes[xI9].VPosition >= xUpBefore)
                                        break;
                                }

                                for (int xI8 = xI0, loopTo11 = xI9 - 1; xI8 <= loopTo11; xI8++)
                                {
                                    double nVP = (Notes[xI8].VPosition - xBottom) * dRatio + xBottom;
                                    this.RedoLongNoteModify(Notes[xI0], nVP, Notes[xI0].Length, ref xUndo, ref xRedo);
                                    Notes[xI8].VPosition = nVP;
                                }

                                // GoTo case2

                                for (int xI8 = xI9, loopTo12 = Information.UBound(Notes); xI8 <= loopTo12; xI8++)
                                {
                                    this.RedoLongNoteModify(Notes[xI8], Notes[xI8].VPosition + dLength, Notes[xI8].Length, ref xUndo, ref xRedo);
                                    Notes[xI8].VPosition += dLength;
                                }
                            }

                            break;
                        }

                }

                MeasureLength[xI1] = xRatio * 192.0d;
                LBeat.Items[xI1] = iBMSC.Editor.Functions.Add3Zeros(xI1) + ": " + xDisplay;
            }
            UpdateMeasureBottom();
            // xUndo &= vbCrLf & xUndo2
            // xRedo &= vbCrLf & xRedo2

            LBeat.SelectedIndices.Clear();
            for (int xI1 = 0, loopTo13 = Information.UBound(xIndices); xI1 <= loopTo13; xI1++)
                LBeat.SelectedIndices.Add(xIndices[xI1]);

            this.AddUndo(xUndo, xBaseRedo.Next);
            SortByVPositionInsertion();
            UpdatePairing();
            CalculateTotalPlayableNotes();
            CalculateGreatestVPosition();
            this.RefreshPanelAll();
            POStatusRefresh();
        }

        private void BBeatApply_Click(object sender, EventArgs e)
        {
            int xxD = (int)Math.Round(nBeatD.Value);
            int xxN = (int)Math.Round(nBeatN.Value);
            double xxRatio = xxN / (double)xxD;

            ApplyBeat(xxRatio, xxRatio + " ( " + xxN + " / " + xxD + " ) ");
        }

        private void BBeatApplyV_Click(object sender, EventArgs e)
        {
            double a;
            if (double.TryParse(tBeatValue.Text, out a))
            {
                if (a <= 0.0d | a >= 1000.0d)
                {
                    System.Media.SystemSounds.Hand.Play();
                    return;
                }

                long xxD = iBMSC.Editor.Functions.GetDenominator(a);

                ApplyBeat(a, Conversions.ToString(Operators.ConcatenateObject(a, Interaction.IIf(xxD > 10000L, "", " ( " + (long)Math.Round(a * xxD) + " / " + xxD + " ) "))));
            }
        }


        private void BHStageFile_Click(object sender, EventArgs e)
        {
            var xDiag = new OpenFileDialog();
            xDiag.Filter = iBMSC.Strings.FileType._image + "|*.bmp;*.png;*.jpeg;*.jpg;*.gif|" + iBMSC.Strings.FileType._all + "|*.*";
            xDiag.InitialDirectory = Conversions.ToString(Interaction.IIf(string.IsNullOrEmpty(ExcludeFileName(FileName)), InitPath, ExcludeFileName(FileName)));
            xDiag.DefaultExt = "png";

            if (xDiag.ShowDialog() == DialogResult.Cancel)
                return;
            InitPath = ExcludeFileName(xDiag.FileName);

            if (ReferenceEquals(sender, BHStageFile))
            {
                THStageFile.Text = GetFileName(xDiag.FileName);
            }
            else if (ReferenceEquals(sender, BHBanner))
            {
                THBanner.Text = GetFileName(xDiag.FileName);
            }
            else if (ReferenceEquals(sender, BHBackBMP))
            {
                THBackBMP.Text = GetFileName(xDiag.FileName);
            }
        }

        private void Switches_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                CheckBox Source = (CheckBox)sender;
                Panel Target = null;

                if (ReferenceEquals(sender, null))
                {
                    return;
                }
                else if (ReferenceEquals(sender, POHeaderSwitch))
                {
                    Target = POHeaderInner;
                }
                else if (ReferenceEquals(sender, POGridSwitch))
                {
                    Target = POGridInner;
                }
                else if (ReferenceEquals(sender, POWaveFormSwitch))
                {
                    Target = POWaveFormInner;
                }
                else if (ReferenceEquals(sender, POWAVSwitch))
                {
                    Target = POWAVInner;
                }
                else if (ReferenceEquals(sender, POBMPSwitch))
                {
                    Target = POBMPInner;
                }
                else if (ReferenceEquals(sender, POBeatSwitch))
                {
                    Target = POBeatInner;
                }
                else if (ReferenceEquals(sender, POExpansionSwitch))
                {
                    Target = POExpansionInner;
                }

                if (Source.Checked)
                {
                    Target.Visible = true;
                }
                else
                {
                    Target.Visible = false;
                }
            }

            catch (Exception ex)
            {

            }
        }

        private void Expanders_CheckChanged(object sender, EventArgs e)
        {

            try
            {
                CheckBox Source = (CheckBox)sender;
                Panel Target = null;
                // Dim TargetParent As Panel = Nothing

                if (ReferenceEquals(sender, null))
                {
                    return;
                }
                else if (ReferenceEquals(sender, POHeaderExpander))
                {
                    Target = POHeaderPart2; // : TargetParent = POHeaderInner
                }
                else if (ReferenceEquals(sender, POGridExpander))
                {
                    Target = POGridPart2; // : TargetParent = POGridInner
                }
                else if (ReferenceEquals(sender, POWaveFormExpander))
                {
                    Target = POWaveFormPart2; // : TargetParent = POWaveFormInner
                }
                else if (ReferenceEquals(sender, POWAVExpander))
                {
                    Target = POWAVPart2; // : TargetParent = POWaveFormInner
                }
                else if (ReferenceEquals(sender, POBeatExpander))
                {
                    Target = POBeatPart2; // : TargetParent = POWaveFormInner
                }

                if (Source.Checked)
                {
                    Target.Visible = true;
                }
                // Source.Image = My.Resources.Collapse
                else
                {
                    Target.Visible = false;
                    // Source.Image = My.Resources.Expand
                }
            }

            catch (Exception ex)
            {

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
            if (e.Button != MouseButtons.Left)
                return;
            if (e.Y == tempResize)
                return;

            try
            {
                Button Source = (Button)sender;
                Panel Target = (Panel)Source.Parent;

                int xHeight = Target.Height + e.Y - tempResize;
                if (xHeight < 10)
                    xHeight = 10;
                Target.Height = xHeight;

                Target.Refresh();
            }
            catch (Exception ex)
            {

            }
        }

        private void POptionsResizer_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            if (e.X == tempResize)
                return;

            try
            {
                int xWidth = POptionsScroll.Width - e.X + tempResize;
                if (xWidth < 25)
                    xWidth = 25;
                POptionsScroll.Width = xWidth;

                Refresh();
                Application.DoEvents();
            }
            catch (Exception ex)
            {

            }
        }

        private void SpR_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            if (e.X == tempResize)
                return;

            try
            {
                int xWidth = PMainR.Width - e.X + tempResize;
                if (xWidth < 0)
                    xWidth = 0;
                PMainR.Width = xWidth;

                ToolStripContainer1.Refresh();
                Application.DoEvents();
            }
            catch (Exception ex)
            {

            }
        }

        private void SpL_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            if (e.X == tempResize)
                return;

            try
            {
                int xWidth = PMainL.Width + e.X - tempResize;
                if (xWidth < 0)
                    xWidth = 0;
                PMainL.Width = xWidth;

                ToolStripContainer1.Refresh();
                Application.DoEvents();
            }
            catch (Exception ex)
            {

            }
        }

        private void mnGotoMeasure_Click(object sender, EventArgs e)
        {
            string s = Interaction.InputBox(iBMSC.Strings.Messages.PromptEnterMeasure, "Enter Measure");

            int i;
            if (int.TryParse(s, out i))
            {
                if (i < 0 | i > 999)
                {
                    return;
                }

                PanelVScroll[PanelFocus] = (int)Math.Round(-MeasureBottom[i]);
            }
        }
    }
}