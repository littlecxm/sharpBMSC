namespace iBMSC;

public class Strings1
{
    public class StatusBar
    {
        public static string Length = "Length";

        public static string LongNote = "LongNote";

        public static string Hidden = "Hidden";

        public static string Err = "Error";
    }

    public class Messages
    {
        public static string Err = "Error";

        public static string SaveOnExit = "Do you want to save changes?";

        public static string SaveOnExit1 = "You should tell me if you want to save changes before closing the computer. -_,-";

        public static string SaveOnExit2 = "You still need to tell me if you want to save changes even though you are closing the application with task manager. -_,-";

        public static string PromptEnter = "Please enter a label.";

        public static string PromptEnterNumeric = "Please enter a value.";

        public static string PromptEnterMeasure = "Please enter a measure (0-999).";

        public static string PromptEnterBPM = "Please enter a BPM value.";

        public static string PromptEnterSTOP = "Please enter a STOP value.";

        public static string PromptEnterSCROLL = "Please enter a SCROLL value.";

        public static string PromptSlashValue = "When the slash key (\"/\") is pressed, change grid division to:";

        public static string InvalidLabel = "Invalid label.";

        public static string CannotFind = "Cannot find file {}.";

        public static string PleaseRespecifyPath = "Please respecify path.";

        public static string PlayerNotFound = "Player not found";

        public static string PreviewDelError = "There must exist at least one player.";

        public static string NegativeFactorError = "Factor must be greater than zero.";

        public static string NegativeDivisorError = "Divisor must be greater than zero.";

        public static string PreferencePostpone = "The preference will take effect on the next start-up of the program.";

        public static string EraserObsolete = "The eraser tool has been replaced by right-clicking on the note.";

        public static string SaveWarning = "Warning: ";

        public static string NoteOverlapError = "Note operlapping detected. Increasing Maximum Grid Partition will resolve this.";

        public static string BPMOverflowError = "Numbers of multi-byte BPMs has exceeded supported maximum: ";

        public static string STOPOverflowError = "Numbers of STOPs has exceeded supported maximum: ";

        public static string SCROLLOverflowError = "Numbers of multi-byte SCROLLs has exceeded supported maximum: ";

        public static string SavedFileWillContainErrors = "The saved file will contain errors.";

        public static string FileAssociationPrompt = "Do you want to set iBMSC as default program to all {} files?";

        public static string FileAssociationError = "Error changing file type association:";

        public static string RestoreDefaultSettings = "Restore default settings?";

        public static string RestoreAutosavedFile = "{} autosaved file(s) have been found. Do you want to recover these files?";
    }

    public class FileType
    {
        public static string _all = "All files (*.*)";

        public static string _bms = "Supported BMS Format (*.bms, *.bme, *.bml, *.pms, *.txt)";

        public static string BMS = "Be-Music Script (*.bms)";

        public static string BME = "Be-Music Extended Format (*.bme)";

        public static string BML = "Be-Music Longnote Format (*.bml)";

        public static string PMS = "Po-Mu Script (*.pms)";

        public static string TXT = "Text document (*.txt)";

        public static string SM = "StepMania Script (*.sm)";

        public static string IBMSC = "iBMSC Binary Format (*.ibmsc)";

        public static string XML = "Extensible Markup Language (*.xml)";

        public static string THEME_XML = "iBMSC Theme File (*.Theme.xml)";

        public static string TH = "iBMSC 2.x Theme File (*.Theme.xml)";

        public static string _audio = "Supported Audio Format (*.wav, *.ogg, *.mp3, *.mid)";

        public static string _wave = "Supported Wave Audio Format (*.wav, *.ogg, *.mp3)";

        public static string WAV = "Waveform Audio (*.wav)";

        public static string OGG = "Ogg Vorbis Audio (*.ogg)";

        public static string MP3 = "MPEG Layer-3 Audio (*.mp3)";

        public static string MID = "MIDI (*.mid)";

        public static string _image = "Supported Image Format (*.png, *.bmp, *.jpg, *.gif)";

        public static string EXE = "Executable file (*.exe)";
    }

    public class fStatistics
    {
        public static string Title = "Statistics";

        public static string lBPM = "BPM";

        public static string lSTOP = "STOP";

        public static string lSCROLL = "SCROLL";

        public static string lA = "A1-A8";

        public static string lD = "D1-D8";

        public static string lBGM = "BGM";

        public static string lTotal = "Total";

        public static string lShort = "Short";

        public static string lLong = "Long";

        public static string lLnObj = "LnObj";

        public static string lHidden = "Hidden";

        public static string lErrors = "Errors";
    }

    public class fopPlayer
    {
        public static string Title = "Player Arguments Options";

        public static string Add = "Add";

        public static string Remove = "Remove";

        public static string Path = "Path";

        public static string PlayFromBeginning = "Play from beginning";

        public static string PlayFromHere = "Play from current measure";

        public static string StopPlaying = "Stop";

        public static string References = "References (case-sensitive):";

        public static string DirectoryOfApp = "Directory of the application";

        public static string CurrMeasure = "Current measure";

        public static string FileName = "File Name";

        public static string RestoreDefault = "Restore Default";
    }

    public class fopVisual
    {
        public static string Title = "Visual Options";

        public static string Width = "Width";

        public static string Caption = "Caption";

        public static string Note = "Note";

        public static string Label = "Label";

        public static string LongNote = "Long Note";

        public static string LongNoteLabel = "Long Note Label";

        public static string Bg = "Bg";

        public static string ColumnCaption = "Column Caption";

        public static string ColumnCaptionFont = "Column Caption Font";

        public static string Background = "Background";

        public static string Grid = "Grid";

        public static string SubGrid = "Sub";

        public static string VerticalLine = "Vertical Line";

        public static string MeasureBarLine = "Measure BarLine";

        public static string BGMWaveform = "BGM Waveform";

        public static string NoteHeight = "Note Height";

        public static string NoteLabel = "Note Label";

        public static string MeasureLabel = "Measure Label";

        public static string LabelVerticalShift = "Note Label Vertical Shift";

        public static string LabelHorizontalShift = "Note Label Horizontal Shift";

        public static string LongNoteLabelHorizontalShift = "LongNote Label Horizontal Shift";

        public static string HiddenNoteOpacity = "Hidden Note Opacity";

        public static string NoteBorderOnMouseOver = "Note Border on MouseOver";

        public static string NoteBorderOnSelection = "Note Border on Selection";

        public static string NoteBorderOnAdjustingLength = "Note Border on Adjusting Length";

        public static string SelectionBoxBorder = "Selection Box Border";

        public static string TSCursor = "Time Selection Cursor";

        public static string TSSplitter = "Time Selection Splitter";

        public static string TSCursorSensitivity = "Time Selection Cursor Sensitivity";

        public static string TSMouseOverBorder = "Time Selection MouseOver Border";

        public static string TSFill = "Time Selection Fill";

        public static string TSBPM = "Time Selection BPM";

        public static string TSBPMFont = "Time Selection BPM Font";

        public static string MiddleSensitivity = "Middle Button Release Sensitivity";
    }

    public class fopGeneral
    {
        public static string Title = "General Options";

        public static string MouseWheel = "Mouse Wheel";

        public static string TextEncoding = "Text Encoding";

        public static string PageUpDown = "PageUp / PageDown";

        public static string MiddleButton = "Mouse Middle Button";

        public static string MiddleButtonAuto = "Click and Auto Scroll";

        public static string MiddleButtonDrag = "Click and Drag";

        public static string AssociateFileType = "Associate Filetype";

        public static string MaxGridPartition = "Max Grid Partition in BMS";

        public static string BeepWhileSaved = "Beep while saved";

        public static string ExtendBPM = "Extend number of multi-byte BPMs to 1296";

        public static string ExtendSTOP = "Extend number of STOPs to 1296";

        public static string AutoFocusOnMouseEnter = "Automatically set focus to editing panel on mouse enter";

        public static string DisableFirstClick = "Disable first click if the editing panel is not focused";

        public static string AutoSave = "AutoSave";

        public static string minutes = "minutes";

        public static string StopPreviewOnClick = "Stop preview if clicked on the editing panel";
    }

    public class fFind
    {
        public static string NoteRange = "Note Range";

        public static string MeasureRange = "Measure Range";

        public static string LabelRange = "Label Range";

        public static string ValueRange = "Value Range";

        public static string to_ = "to";

        public static string Selected = "Selected";

        public static string UnSelected = "Unselected";

        public static string ShortNote = "Short";

        public static string LongNote = "Long";

        public static string Hidden = "Hidden";

        public static string Visible = "Visible";

        public static string Column = "Column";

        public static string SelectAll = "Select All";

        public static string SelectInverse = "Select Inverse";

        public static string UnselectAll = "Unselect All";

        public static string Operation = "Operation";

        public static string ReplaceWithLabel = "Replace with Label:";

        public static string ReplaceWithValue = "Replace with Value:";

        public static string Select_ = "Select";

        public static string Unselect_ = "Unselect";

        public static string Delete_ = "Delete";

        public static string Close_ = "Close";
    }

    public class fImportSM
    {
        public static string Title = "Import *.SM file";

        public static string Difficulty = "Difficulty";

        public static string Note = "Please note that bg musics and STOP values will not be imported.";
    }

    public class FileAssociation
    {
        public static string BMS = "Be-Music Script";

        public static string BME = "Be-Music Extended Format";

        public static string BML = "Be-Music Longnote Format";

        public static string PMS = "Po-Mu Script";

        public static string IBMSC = "iBMSC Binary Format";

        public static string Open = "Open";

        public static string Preview = "Preview";

        public static string ViewCode = "View Code";
    }

    public static string OK = "OK";

    public static string Cancel = "Cancel";

    public static string None = "None";
}
