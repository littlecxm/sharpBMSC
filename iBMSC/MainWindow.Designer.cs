using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace iBMSC
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class MainWindow : Form
    {

        // Form 重写 Dispose，以清理组件列表。
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            if (disposing && components is not null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Windows 窗体设计器所必需的
        private System.ComponentModel.IContainer components;

        // 注意: 以下过程是 Windows 窗体设计器所必需的
        // 可以使用 Windows 窗体设计器修改它。
        // 不要使用代码编辑器修改它。
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.cmnLanguage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TBLangDef = new System.Windows.Forms.ToolStripMenuItem();
            this.TBLangRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.mnLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.TBLanguage = new System.Windows.Forms.ToolStripDropDownButton();
            this.cmnTheme = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TBThemeDef = new System.Windows.Forms.ToolStripMenuItem();
            this.TBThemeSave = new System.Windows.Forms.ToolStripMenuItem();
            this.TBThemeRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.TBThemeLoadComptability = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnTheme = new System.Windows.Forms.ToolStripMenuItem();
            this.TBTheme = new System.Windows.Forms.ToolStripDropDownButton();
            this.POptionsScroll = new System.Windows.Forms.Panel();
            this.POptions = new System.Windows.Forms.Panel();
            this.POExpansion = new System.Windows.Forms.Panel();
            this.POExpansionInner = new System.Windows.Forms.Panel();
            this.TExpansion = new System.Windows.Forms.TextBox();
            this.POExpansionResizer = new System.Windows.Forms.Button();
            this.POExpansionSwitch = new System.Windows.Forms.CheckBox();
            this.POBeat = new System.Windows.Forms.Panel();
            this.POBeatInner = new System.Windows.Forms.TableLayoutPanel();
            this.POBeatExpander = new System.Windows.Forms.CheckBox();
            this.POBeatResizer = new System.Windows.Forms.Button();
            this.TableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.nBeatD = new System.Windows.Forms.NumericUpDown();
            this.BBeatApplyV = new System.Windows.Forms.Button();
            this.nBeatN = new System.Windows.Forms.NumericUpDown();
            this.BBeatApply = new System.Windows.Forms.Button();
            this.Label7 = new System.Windows.Forms.Label();
            this.tBeatValue = new System.Windows.Forms.TextBox();
            this.LBeat = new System.Windows.Forms.ListBox();
            this.POBeatPart2 = new System.Windows.Forms.TableLayoutPanel();
            this.CBeatScale = new System.Windows.Forms.RadioButton();
            this.CBeatCut = new System.Windows.Forms.RadioButton();
            this.CBeatMeasure = new System.Windows.Forms.RadioButton();
            this.CBeatPreserve = new System.Windows.Forms.RadioButton();
            this.POBeatSwitch = new System.Windows.Forms.CheckBox();
            this.POBMP = new System.Windows.Forms.Panel();
            this.POBMPInner = new System.Windows.Forms.TableLayoutPanel();
            this.LBMP = new System.Windows.Forms.ListBox();
            this.FlowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.BBMPUp = new System.Windows.Forms.Button();
            this.BBMPDown = new System.Windows.Forms.Button();
            this.BBMPBrowse = new System.Windows.Forms.Button();
            this.BBMPRemove = new System.Windows.Forms.Button();
            this.POBMPResizer = new System.Windows.Forms.Button();
            this.POBMPSwitch = new System.Windows.Forms.CheckBox();
            this.POWAV = new System.Windows.Forms.Panel();
            this.POWAVInner = new System.Windows.Forms.TableLayoutPanel();
            this.POWAVExpander = new System.Windows.Forms.CheckBox();
            this.LWAV = new System.Windows.Forms.ListBox();
            this.FlowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.BWAVUp = new System.Windows.Forms.Button();
            this.BWAVDown = new System.Windows.Forms.Button();
            this.BWAVBrowse = new System.Windows.Forms.Button();
            this.BWAVRemove = new System.Windows.Forms.Button();
            this.POWAVResizer = new System.Windows.Forms.Button();
            this.POWAVPart2 = new System.Windows.Forms.TableLayoutPanel();
            this.CWAVMultiSelect = new System.Windows.Forms.CheckBox();
            this.CWAVChangeLabel = new System.Windows.Forms.CheckBox();
            this.POWAVSwitch = new System.Windows.Forms.CheckBox();
            this.POWaveForm = new System.Windows.Forms.Panel();
            this.POWaveFormInner = new System.Windows.Forms.Panel();
            this.POWaveFormPart2 = new System.Windows.Forms.TableLayoutPanel();
            this.TWSaturation = new System.Windows.Forms.NumericUpDown();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.TWTransparency = new System.Windows.Forms.NumericUpDown();
            this.PictureBox3 = new System.Windows.Forms.PictureBox();
            this.TWPrecision = new System.Windows.Forms.NumericUpDown();
            this.PictureBox4 = new System.Windows.Forms.PictureBox();
            this.TWWidth = new System.Windows.Forms.NumericUpDown();
            this.PictureBox5 = new System.Windows.Forms.PictureBox();
            this.TWLeft = new System.Windows.Forms.NumericUpDown();
            this.PictureBox6 = new System.Windows.Forms.PictureBox();
            this.TWSaturation2 = new System.Windows.Forms.TrackBar();
            this.TWLeft2 = new System.Windows.Forms.TrackBar();
            this.TWTransparency2 = new System.Windows.Forms.TrackBar();
            this.TWWidth2 = new System.Windows.Forms.TrackBar();
            this.TWPrecision2 = new System.Windows.Forms.TrackBar();
            this.POWaveFormExpander = new System.Windows.Forms.CheckBox();
            this.POWaveFormPart1 = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.FlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BWLoad = new System.Windows.Forms.Button();
            this.BWClear = new System.Windows.Forms.Button();
            this.BWLock = new System.Windows.Forms.CheckBox();
            this.TWFileName = new System.Windows.Forms.TextBox();
            this.TableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.TWPosition2 = new System.Windows.Forms.TrackBar();
            this.TWPosition = new System.Windows.Forms.NumericUpDown();
            this.POWaveFormSwitch = new System.Windows.Forms.CheckBox();
            this.POGrid = new System.Windows.Forms.Panel();
            this.POGridInner = new System.Windows.Forms.Panel();
            this.POGridPart2 = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.FlowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.cVSLockL = new System.Windows.Forms.CheckBox();
            this.cVSLock = new System.Windows.Forms.CheckBox();
            this.cVSLockR = new System.Windows.Forms.CheckBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.TableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.Label1 = new System.Windows.Forms.Label();
            this.CGB = new System.Windows.Forms.NumericUpDown();
            this.POGridExpander = new System.Windows.Forms.CheckBox();
            this.POGridPart1 = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.PictureBox9 = new System.Windows.Forms.PictureBox();
            this.CGHeight2 = new System.Windows.Forms.TrackBar();
            this.CGHeight = new System.Windows.Forms.NumericUpDown();
            this.PictureBox10 = new System.Windows.Forms.PictureBox();
            this.CGWidth2 = new System.Windows.Forms.TrackBar();
            this.CGWidth = new System.Windows.Forms.NumericUpDown();
            this.CGDisableVertical = new System.Windows.Forms.CheckBox();
            this.CGSnap = new System.Windows.Forms.CheckBox();
            this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.PictureBox7 = new System.Windows.Forms.PictureBox();
            this.CGDivide = new System.Windows.Forms.NumericUpDown();
            this.CGSub = new System.Windows.Forms.NumericUpDown();
            this.BGSlash = new System.Windows.Forms.Button();
            this.POGridSwitch = new System.Windows.Forms.CheckBox();
            this.POHeader = new System.Windows.Forms.Panel();
            this.POHeaderInner = new System.Windows.Forms.Panel();
            this.POHeaderPart2 = new System.Windows.Forms.TableLayoutPanel();
            this.CHDifficulty = new System.Windows.Forms.ComboBox();
            this.Label13 = new System.Windows.Forms.Label();
            this.THExRank = new System.Windows.Forms.TextBox();
            this.Label25 = new System.Windows.Forms.Label();
            this.CHLnObj = new System.Windows.Forms.ComboBox();
            this.Label23 = new System.Windows.Forms.Label();
            this.Label21 = new System.Windows.Forms.Label();
            this.THComment = new System.Windows.Forms.TextBox();
            this.Label24 = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.THTotal = new System.Windows.Forms.TextBox();
            this.Label20 = new System.Windows.Forms.Label();
            this.BHStageFile = new System.Windows.Forms.Button();
            this.BHBanner = new System.Windows.Forms.Button();
            this.Label19 = new System.Windows.Forms.Label();
            this.BHBackBMP = new System.Windows.Forms.Button();
            this.Label17 = new System.Windows.Forms.Label();
            this.Label16 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.THBackBMP = new System.Windows.Forms.TextBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.THBanner = new System.Windows.Forms.TextBox();
            this.THStageFile = new System.Windows.Forms.TextBox();
            this.THSubTitle = new System.Windows.Forms.TextBox();
            this.THSubArtist = new System.Windows.Forms.TextBox();
            this.POHeaderExpander = new System.Windows.Forms.CheckBox();
            this.POHeaderPart1 = new System.Windows.Forms.TableLayoutPanel();
            this.Label3 = new System.Windows.Forms.Label();
            this.THPlayLevel = new System.Windows.Forms.TextBox();
            this.CHRank = new System.Windows.Forms.ComboBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.CHPlayer = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.THGenre = new System.Windows.Forms.TextBox();
            this.THBPM = new System.Windows.Forms.NumericUpDown();
            this.Label2 = new System.Windows.Forms.Label();
            this.THArtist = new System.Windows.Forms.TextBox();
            this.THTitle = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.POHeaderSwitch = new System.Windows.Forms.CheckBox();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.Menu1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.MRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoSaveTimer = new System.Windows.Forms.Timer(this.components);
            this.mnMain = new System.Windows.Forms.MenuStrip();
            this.mnFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnImportSM = new System.Windows.Forms.ToolStripMenuItem();
            this.mnImportIBMSC = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.mnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnExport = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.mnOpenR0 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnOpenR1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnOpenR2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnOpenR3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnOpenR4 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.mnQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.mnCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.mnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnGotoMeasure = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.mnFind = new System.Windows.Forms.ToolStripMenuItem();
            this.mnStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.mnTimeSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.mnWrite = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
            this.mnMyO2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSys = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSTB = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSOP = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSLSplitter = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSRSplitter = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.CGShow = new System.Windows.Forms.ToolStripMenuItem();
            this.CGShowS = new System.Windows.Forms.ToolStripMenuItem();
            this.CGShowBG = new System.Windows.Forms.ToolStripMenuItem();
            this.CGShowM = new System.Windows.Forms.ToolStripMenuItem();
            this.CGShowMB = new System.Windows.Forms.ToolStripMenuItem();
            this.CGShowV = new System.Windows.Forms.ToolStripMenuItem();
            this.CGShowC = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
            this.CGBPM = new System.Windows.Forms.ToolStripMenuItem();
            this.CGSTOP = new System.Windows.Forms.ToolStripMenuItem();
            this.CGSCROLL = new System.Windows.Forms.ToolStripMenuItem();
            this.CGBLP = new System.Windows.Forms.ToolStripMenuItem();
            this.mnOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnNTInput = new System.Windows.Forms.ToolStripMenuItem();
            this.mnErrorCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.mnPreviewOnClick = new System.Windows.Forms.ToolStripMenuItem();
            this.mnShowFileName = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.mnGOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnVOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnPOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnConversion = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnConversion = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.POBLong = new System.Windows.Forms.ToolStripMenuItem();
            this.POBShort = new System.Windows.Forms.ToolStripMenuItem();
            this.POBLongShort = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.POBHidden = new System.Windows.Forms.ToolStripMenuItem();
            this.POBVisible = new System.Windows.Forms.ToolStripMenuItem();
            this.POBHiddenVisible = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.POBModify = new System.Windows.Forms.ToolStripMenuItem();
            this.POBMirror = new System.Windows.Forms.ToolStripMenuItem();
            this.POConvert = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.mnPlayB = new System.Windows.Forms.ToolStripMenuItem();
            this.mnPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.mnStop = new System.Windows.Forms.ToolStripMenuItem();
            this.TBMain = new System.Windows.Forms.ToolStrip();
            this.TBNew = new System.Windows.Forms.ToolStripButton();
            this.TBOpen = new System.Windows.Forms.ToolStripSplitButton();
            this.TBOpenR0 = new System.Windows.Forms.ToolStripMenuItem();
            this.TBOpenR1 = new System.Windows.Forms.ToolStripMenuItem();
            this.TBOpenR2 = new System.Windows.Forms.ToolStripMenuItem();
            this.TBOpenR3 = new System.Windows.Forms.ToolStripMenuItem();
            this.TBOpenR4 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.TBImportSM = new System.Windows.Forms.ToolStripMenuItem();
            this.TBImportIBMSC = new System.Windows.Forms.ToolStripMenuItem();
            this.TBSave = new System.Windows.Forms.ToolStripSplitButton();
            this.TBSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.TBExport = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TBCut = new System.Windows.Forms.ToolStripButton();
            this.TBCopy = new System.Windows.Forms.ToolStripButton();
            this.TBPaste = new System.Windows.Forms.ToolStripButton();
            this.TBFind = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator24 = new System.Windows.Forms.ToolStripSeparator();
            this.TBStatistics = new System.Windows.Forms.ToolStripButton();
            this.TBMyO2 = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.TBErrorCheck = new System.Windows.Forms.ToolStripButton();
            this.TBPreviewOnClick = new System.Windows.Forms.ToolStripButton();
            this.TBShowFileName = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.TBNTInput = new System.Windows.Forms.ToolStripButton();
            this.TBWavIncrease = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TBUndo = new System.Windows.Forms.ToolStripButton();
            this.TBRedo = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.TBTimeSelect = new System.Windows.Forms.ToolStripButton();
            this.TBSelect = new System.Windows.Forms.ToolStripButton();
            this.TBWrite = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.TBPlayB = new System.Windows.Forms.ToolStripButton();
            this.TBPlay = new System.Windows.Forms.ToolStripButton();
            this.TBStop = new System.Windows.Forms.ToolStripButton();
            this.TBPOptions = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.TBVOptions = new System.Windows.Forms.ToolStripButton();
            this.TBGOptions = new System.Windows.Forms.ToolStripButton();
            this.POBStorm = new System.Windows.Forms.ToolStripButton();
            this.pStatus = new System.Windows.Forms.Panel();
            this.FStatus2 = new System.Windows.Forms.StatusStrip();
            this.FSSS = new System.Windows.Forms.ToolStripButton();
            this.FSSL = new System.Windows.Forms.ToolStripButton();
            this.FSSH = new System.Windows.Forms.ToolStripButton();
            this.BVCReverse = new System.Windows.Forms.ToolStripButton();
            this.LblMultiply = new System.Windows.Forms.ToolStripStatusLabel();
            this.TVCM = new System.Windows.Forms.ToolStripTextBox();
            this.LblDivide = new System.Windows.Forms.ToolStripStatusLabel();
            this.TVCD = new System.Windows.Forms.ToolStripTextBox();
            this.BVCApply = new System.Windows.Forms.ToolStripButton();
            this.TVCBPM = new System.Windows.Forms.ToolStripTextBox();
            this.BVCCalculate = new System.Windows.Forms.ToolStripButton();
            this.BConvertStop = new System.Windows.Forms.ToolStripButton();
            this.FStatus = new System.Windows.Forms.StatusStrip();
            this.FSC = new System.Windows.Forms.ToolStripStatusLabel();
            this.FSW = new System.Windows.Forms.ToolStripStatusLabel();
            this.FSM = new System.Windows.Forms.ToolStripStatusLabel();
            this.FSP1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.FSP3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.FSP2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.FSP4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TimeStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.FST = new System.Windows.Forms.ToolStripStatusLabel();
            this.FSH = new System.Windows.Forms.ToolStripStatusLabel();
            this.FSE = new System.Windows.Forms.ToolStripStatusLabel();
            this.TimerMiddle = new System.Windows.Forms.Timer(this.components);
            this.ToolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.PMain = new System.Windows.Forms.Panel();
            this.PMainIn = new System.Windows.Forms.Panel();
            this.MainPanelScroll = new System.Windows.Forms.VScrollBar();
            this.HS = new System.Windows.Forms.HScrollBar();
            this.SpR = new System.Windows.Forms.Button();
            this.SpL = new System.Windows.Forms.Button();
            this.PMainR = new System.Windows.Forms.Panel();
            this.PMainInR = new System.Windows.Forms.Panel();
            this.RightPanelScroll = new System.Windows.Forms.VScrollBar();
            this.HSR = new System.Windows.Forms.HScrollBar();
            this.PMainL = new System.Windows.Forms.Panel();
            this.PMainInL = new System.Windows.Forms.Panel();
            this.LeftPanelScroll = new System.Windows.Forms.VScrollBar();
            this.HSL = new System.Windows.Forms.HScrollBar();
            this.POptionsResizer = new System.Windows.Forms.Button();
            this.ToolTipUniversal = new System.Windows.Forms.ToolTip(this.components);
            this.cmnLanguage.SuspendLayout();
            this.cmnTheme.SuspendLayout();
            this.POptionsScroll.SuspendLayout();
            this.POptions.SuspendLayout();
            this.POExpansion.SuspendLayout();
            this.POExpansionInner.SuspendLayout();
            this.POBeat.SuspendLayout();
            this.POBeatInner.SuspendLayout();
            this.TableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nBeatD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nBeatN)).BeginInit();
            this.POBeatPart2.SuspendLayout();
            this.POBMP.SuspendLayout();
            this.POBMPInner.SuspendLayout();
            this.FlowLayoutPanel4.SuspendLayout();
            this.POWAV.SuspendLayout();
            this.POWAVInner.SuspendLayout();
            this.FlowLayoutPanel3.SuspendLayout();
            this.POWAVPart2.SuspendLayout();
            this.POWaveForm.SuspendLayout();
            this.POWaveFormInner.SuspendLayout();
            this.POWaveFormPart2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TWSaturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TWTransparency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TWPrecision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TWWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TWLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TWSaturation2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TWLeft2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TWTransparency2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TWWidth2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TWPrecision2)).BeginInit();
            this.POWaveFormPart1.SuspendLayout();
            this.TableLayoutPanel1.SuspendLayout();
            this.FlowLayoutPanel1.SuspendLayout();
            this.TableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TWPosition2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TWPosition)).BeginInit();
            this.POGrid.SuspendLayout();
            this.POGridInner.SuspendLayout();
            this.POGridPart2.SuspendLayout();
            this.TableLayoutPanel5.SuspendLayout();
            this.FlowLayoutPanel2.SuspendLayout();
            this.TableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CGB)).BeginInit();
            this.POGridPart1.SuspendLayout();
            this.TableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CGHeight2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CGHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CGWidth2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CGWidth)).BeginInit();
            this.TableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CGDivide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CGSub)).BeginInit();
            this.POHeader.SuspendLayout();
            this.POHeaderInner.SuspendLayout();
            this.POHeaderPart2.SuspendLayout();
            this.POHeaderPart1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.THBPM)).BeginInit();
            this.Menu1.SuspendLayout();
            this.mnMain.SuspendLayout();
            this.cmnConversion.SuspendLayout();
            this.TBMain.SuspendLayout();
            this.pStatus.SuspendLayout();
            this.FStatus2.SuspendLayout();
            this.FStatus.SuspendLayout();
            this.ToolStripContainer1.ContentPanel.SuspendLayout();
            this.ToolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.ToolStripContainer1.SuspendLayout();
            this.PMain.SuspendLayout();
            this.PMainR.SuspendLayout();
            this.PMainL.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmnLanguage
            // 
            this.cmnLanguage.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmnLanguage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TBLangDef,
            this.TBLangRefresh,
            this.ToolStripSeparator9});
            this.cmnLanguage.Name = "cmnLanguage";
            this.cmnLanguage.OwnerItem = this.TBLanguage;
            this.cmnLanguage.Size = new System.Drawing.Size(145, 62);
            // 
            // TBLangDef
            // 
            this.TBLangDef.Name = "TBLangDef";
            this.TBLangDef.Size = new System.Drawing.Size(144, 26);
            this.TBLangDef.Text = "(Default)";
            this.TBLangDef.Click += new System.EventHandler(this.TBLangDef_Click);
            // 
            // TBLangRefresh
            // 
            this.TBLangRefresh.Image = global::iBMSC.Properties.Resources.x16Refresh;
            this.TBLangRefresh.Name = "TBLangRefresh";
            this.TBLangRefresh.Size = new System.Drawing.Size(144, 26);
            this.TBLangRefresh.Text = "Refresh";
            this.TBLangRefresh.Click += new System.EventHandler(this.TBLangRefresh_Click);
            // 
            // ToolStripSeparator9
            // 
            this.ToolStripSeparator9.Name = "ToolStripSeparator9";
            this.ToolStripSeparator9.Size = new System.Drawing.Size(141, 6);
            // 
            // mnLanguage
            // 
            this.mnLanguage.DropDown = this.cmnLanguage;
            this.mnLanguage.Image = global::iBMSC.Properties.Resources.x16Language;
            this.mnLanguage.Name = "mnLanguage";
            this.mnLanguage.Size = new System.Drawing.Size(302, 26);
            this.mnLanguage.Text = "&Language";
            // 
            // TBLanguage
            // 
            this.TBLanguage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TBLanguage.DropDown = this.cmnLanguage;
            this.TBLanguage.Image = global::iBMSC.Properties.Resources.x16Language;
            this.TBLanguage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TBLanguage.Name = "TBLanguage";
            this.TBLanguage.Size = new System.Drawing.Size(34, 24);
            this.TBLanguage.Text = "Language";
            // 
            // cmnTheme
            // 
            this.cmnTheme.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmnTheme.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TBThemeDef,
            this.TBThemeSave,
            this.TBThemeRefresh,
            this.TBThemeLoadComptability,
            this.ToolStripSeparator6});
            this.cmnTheme.Name = "cmnLanguage";
            this.cmnTheme.OwnerItem = this.TBTheme;
            this.cmnTheme.Size = new System.Drawing.Size(317, 114);
            // 
            // TBThemeDef
            // 
            this.TBThemeDef.Name = "TBThemeDef";
            this.TBThemeDef.Size = new System.Drawing.Size(316, 26);
            this.TBThemeDef.Text = "(Default)";
            this.TBThemeDef.Click += new System.EventHandler(this.TBThemeDef_Click);
            // 
            // TBThemeSave
            // 
            this.TBThemeSave.Image = global::iBMSC.Properties.Resources.x16SaveAs;
            this.TBThemeSave.Name = "TBThemeSave";
            this.TBThemeSave.Size = new System.Drawing.Size(316, 26);
            this.TBThemeSave.Text = "Save Theme";
            this.TBThemeSave.Click += new System.EventHandler(this.TBThemeSave_Click);
            // 
            // TBThemeRefresh
            // 
            this.TBThemeRefresh.Image = global::iBMSC.Properties.Resources.x16Refresh;
            this.TBThemeRefresh.Name = "TBThemeRefresh";
            this.TBThemeRefresh.Size = new System.Drawing.Size(316, 26);
            this.TBThemeRefresh.Text = "Refresh";
            this.TBThemeRefresh.Click += new System.EventHandler(this.TBThemeRefresh_Click);
            // 
            // TBThemeLoadComptability
            // 
            this.TBThemeLoadComptability.Name = "TBThemeLoadComptability";
            this.TBThemeLoadComptability.Size = new System.Drawing.Size(316, 26);
            this.TBThemeLoadComptability.Text = "Load Theme File from iBMSC 2.x";
            this.TBThemeLoadComptability.Click += new System.EventHandler(this.TBThemeLoadComptability_Click);
            // 
            // ToolStripSeparator6
            // 
            this.ToolStripSeparator6.Name = "ToolStripSeparator6";
            this.ToolStripSeparator6.Size = new System.Drawing.Size(313, 6);
            // 
            // mnTheme
            // 
            this.mnTheme.DropDown = this.cmnTheme;
            this.mnTheme.Image = global::iBMSC.Properties.Resources.x16Theme;
            this.mnTheme.Name = "mnTheme";
            this.mnTheme.Size = new System.Drawing.Size(302, 26);
            this.mnTheme.Text = "&Theme";
            // 
            // TBTheme
            // 
            this.TBTheme.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TBTheme.DropDown = this.cmnTheme;
            this.TBTheme.Image = global::iBMSC.Properties.Resources.x16Theme;
            this.TBTheme.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TBTheme.Name = "TBTheme";
            this.TBTheme.Size = new System.Drawing.Size(34, 24);
            this.TBTheme.Text = "Theme";
            // 
            // POptionsScroll
            // 
            this.POptionsScroll.AutoScroll = true;
            this.POptionsScroll.Controls.Add(this.POptions);
            this.POptionsScroll.Dock = System.Windows.Forms.DockStyle.Right;
            this.POptionsScroll.Location = new System.Drawing.Point(882, 0);
            this.POptionsScroll.Name = "POptionsScroll";
            this.POptionsScroll.Size = new System.Drawing.Size(200, 730);
            this.POptionsScroll.TabIndex = 28;
            // 
            // POptions
            // 
            this.POptions.AutoSize = true;
            this.POptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.POptions.Controls.Add(this.POExpansion);
            this.POptions.Controls.Add(this.POBeat);
            this.POptions.Controls.Add(this.POBMP);
            this.POptions.Controls.Add(this.POWAV);
            this.POptions.Controls.Add(this.POWaveForm);
            this.POptions.Controls.Add(this.POGrid);
            this.POptions.Controls.Add(this.POHeader);
            this.POptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.POptions.Location = new System.Drawing.Point(0, 0);
            this.POptions.Name = "POptions";
            this.POptions.Size = new System.Drawing.Size(179, 2096);
            this.POptions.TabIndex = 29;
            // 
            // POExpansion
            // 
            this.POExpansion.AutoSize = true;
            this.POExpansion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.POExpansion.Controls.Add(this.POExpansionInner);
            this.POExpansion.Controls.Add(this.POExpansionSwitch);
            this.POExpansion.Dock = System.Windows.Forms.DockStyle.Top;
            this.POExpansion.Location = new System.Drawing.Point(0, 1826);
            this.POExpansion.Name = "POExpansion";
            this.POExpansion.Size = new System.Drawing.Size(179, 270);
            this.POExpansion.TabIndex = 6;
            this.POExpansion.Resize += new System.EventHandler(this.POExpansion_Resize);
            // 
            // POExpansionInner
            // 
            this.POExpansionInner.Controls.Add(this.TExpansion);
            this.POExpansionInner.Controls.Add(this.POExpansionResizer);
            this.POExpansionInner.Dock = System.Windows.Forms.DockStyle.Top;
            this.POExpansionInner.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.POExpansionInner.Location = new System.Drawing.Point(0, 20);
            this.POExpansionInner.Name = "POExpansionInner";
            this.POExpansionInner.Size = new System.Drawing.Size(179, 250);
            this.POExpansionInner.TabIndex = 7;
            this.POExpansionInner.Visible = false;
            // 
            // TExpansion
            // 
            this.TExpansion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TExpansion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TExpansion.HideSelection = false;
            this.TExpansion.Location = new System.Drawing.Point(0, 0);
            this.TExpansion.Multiline = true;
            this.TExpansion.Name = "TExpansion";
            this.TExpansion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TExpansion.Size = new System.Drawing.Size(179, 245);
            this.TExpansion.TabIndex = 0;
            this.TExpansion.WordWrap = false;
            this.TExpansion.TextChanged += new System.EventHandler(this.THGenre_TextChanged);
            // 
            // POExpansionResizer
            // 
            this.POExpansionResizer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.POExpansionResizer.FlatAppearance.BorderSize = 0;
            this.POExpansionResizer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.POExpansionResizer.Location = new System.Drawing.Point(0, 245);
            this.POExpansionResizer.Margin = new System.Windows.Forms.Padding(0);
            this.POExpansionResizer.Name = "POExpansionResizer";
            this.POExpansionResizer.Size = new System.Drawing.Size(179, 5);
            this.POExpansionResizer.TabIndex = 65;
            this.POExpansionResizer.TabStop = false;
            this.POExpansionResizer.UseVisualStyleBackColor = true;
            this.POExpansionResizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VerticalResizer_MouseDown);
            this.POExpansionResizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.POResizer_MouseMove);
            // 
            // POExpansionSwitch
            // 
            this.POExpansionSwitch.Appearance = System.Windows.Forms.Appearance.Button;
            this.POExpansionSwitch.BackColor = System.Drawing.SystemColors.Control;
            this.POExpansionSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.POExpansionSwitch.Dock = System.Windows.Forms.DockStyle.Top;
            this.POExpansionSwitch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.POExpansionSwitch.Location = new System.Drawing.Point(0, 0);
            this.POExpansionSwitch.Name = "POExpansionSwitch";
            this.POExpansionSwitch.Size = new System.Drawing.Size(179, 20);
            this.POExpansionSwitch.TabIndex = 6;
            this.POExpansionSwitch.TabStop = false;
            this.POExpansionSwitch.Text = "Expansion Code";
            this.POExpansionSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.POExpansionSwitch.UseCompatibleTextRendering = true;
            this.POExpansionSwitch.UseVisualStyleBackColor = false;
            this.POExpansionSwitch.CheckedChanged += new System.EventHandler(this.Switches_CheckedChanged);
            // 
            // POBeat
            // 
            this.POBeat.AutoSize = true;
            this.POBeat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.POBeat.Controls.Add(this.POBeatInner);
            this.POBeat.Controls.Add(this.POBeatSwitch);
            this.POBeat.Dock = System.Windows.Forms.DockStyle.Top;
            this.POBeat.Location = new System.Drawing.Point(0, 1556);
            this.POBeat.Name = "POBeat";
            this.POBeat.Size = new System.Drawing.Size(179, 270);
            this.POBeat.TabIndex = 5;
            this.POBeat.Resize += new System.EventHandler(this.POBeat_Resize);
            // 
            // POBeatInner
            // 
            this.POBeatInner.ColumnCount = 1;
            this.POBeatInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.POBeatInner.Controls.Add(this.POBeatExpander, 0, 1);
            this.POBeatInner.Controls.Add(this.POBeatResizer, 0, 4);
            this.POBeatInner.Controls.Add(this.TableLayoutPanel7, 0, 0);
            this.POBeatInner.Controls.Add(this.LBeat, 0, 3);
            this.POBeatInner.Controls.Add(this.POBeatPart2, 0, 2);
            this.POBeatInner.Dock = System.Windows.Forms.DockStyle.Top;
            this.POBeatInner.Location = new System.Drawing.Point(0, 20);
            this.POBeatInner.Name = "POBeatInner";
            this.POBeatInner.RowCount = 5;
            this.POBeatInner.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POBeatInner.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POBeatInner.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POBeatInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.POBeatInner.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POBeatInner.Size = new System.Drawing.Size(179, 250);
            this.POBeatInner.TabIndex = 6;
            this.POBeatInner.Visible = false;
            // 
            // POBeatExpander
            // 
            this.POBeatExpander.Appearance = System.Windows.Forms.Appearance.Button;
            this.POBeatExpander.AutoSize = true;
            this.POBeatExpander.Cursor = System.Windows.Forms.Cursors.Hand;
            this.POBeatExpander.Dock = System.Windows.Forms.DockStyle.Top;
            this.POBeatExpander.FlatAppearance.BorderSize = 0;
            this.POBeatExpander.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.POBeatExpander.Location = new System.Drawing.Point(0, 64);
            this.POBeatExpander.Margin = new System.Windows.Forms.Padding(0);
            this.POBeatExpander.Name = "POBeatExpander";
            this.POBeatExpander.Size = new System.Drawing.Size(179, 30);
            this.POBeatExpander.TabIndex = 65;
            this.POBeatExpander.TabStop = false;
            this.POBeatExpander.Text = "Expand...";
            this.POBeatExpander.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.POBeatExpander.UseVisualStyleBackColor = false;
            this.POBeatExpander.CheckedChanged += new System.EventHandler(this.Expanders_CheckChanged);
            // 
            // POBeatResizer
            // 
            this.POBeatInner.SetColumnSpan(this.POBeatResizer, 2);
            this.POBeatResizer.Dock = System.Windows.Forms.DockStyle.Top;
            this.POBeatResizer.FlatAppearance.BorderSize = 0;
            this.POBeatResizer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.POBeatResizer.Location = new System.Drawing.Point(0, 245);
            this.POBeatResizer.Margin = new System.Windows.Forms.Padding(0);
            this.POBeatResizer.Name = "POBeatResizer";
            this.POBeatResizer.Size = new System.Drawing.Size(179, 5);
            this.POBeatResizer.TabIndex = 64;
            this.POBeatResizer.TabStop = false;
            this.POBeatResizer.UseVisualStyleBackColor = true;
            this.POBeatResizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VerticalResizer_MouseDown);
            this.POBeatResizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.POResizer_MouseMove);
            // 
            // TableLayoutPanel7
            // 
            this.TableLayoutPanel7.AutoSize = true;
            this.TableLayoutPanel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TableLayoutPanel7.ColumnCount = 4;
            this.TableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.TableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.TableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.TableLayoutPanel7.Controls.Add(this.nBeatD, 2, 0);
            this.TableLayoutPanel7.Controls.Add(this.BBeatApplyV, 3, 1);
            this.TableLayoutPanel7.Controls.Add(this.nBeatN, 0, 0);
            this.TableLayoutPanel7.Controls.Add(this.BBeatApply, 3, 0);
            this.TableLayoutPanel7.Controls.Add(this.Label7, 1, 0);
            this.TableLayoutPanel7.Controls.Add(this.tBeatValue, 0, 1);
            this.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayoutPanel7.Name = "TableLayoutPanel7";
            this.TableLayoutPanel7.RowCount = 2;
            this.TableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel7.Size = new System.Drawing.Size(179, 64);
            this.TableLayoutPanel7.TabIndex = 63;
            // 
            // nBeatD
            // 
            this.nBeatD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nBeatD.Location = new System.Drawing.Point(67, 3);
            this.nBeatD.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nBeatD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nBeatD.Name = "nBeatD";
            this.nBeatD.Size = new System.Drawing.Size(43, 27);
            this.nBeatD.TabIndex = 37;
            this.nBeatD.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // BBeatApplyV
            // 
            this.BBeatApplyV.AutoSize = true;
            this.BBeatApplyV.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BBeatApplyV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BBeatApplyV.Location = new System.Drawing.Point(113, 34);
            this.BBeatApplyV.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.BBeatApplyV.Name = "BBeatApplyV";
            this.BBeatApplyV.Size = new System.Drawing.Size(63, 30);
            this.BBeatApplyV.TabIndex = 35;
            this.BBeatApplyV.Text = "Apply";
            this.BBeatApplyV.UseVisualStyleBackColor = true;
            this.BBeatApplyV.Click += new System.EventHandler(this.BBeatApplyV_Click);
            // 
            // nBeatN
            // 
            this.nBeatN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nBeatN.Location = new System.Drawing.Point(3, 3);
            this.nBeatN.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nBeatN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nBeatN.Name = "nBeatN";
            this.nBeatN.Size = new System.Drawing.Size(43, 27);
            this.nBeatN.TabIndex = 27;
            this.nBeatN.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // BBeatApply
            // 
            this.BBeatApply.AutoSize = true;
            this.BBeatApply.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BBeatApply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BBeatApply.Location = new System.Drawing.Point(113, 2);
            this.BBeatApply.Margin = new System.Windows.Forms.Padding(0, 2, 3, 2);
            this.BBeatApply.Name = "BBeatApply";
            this.BBeatApply.Size = new System.Drawing.Size(63, 30);
            this.BBeatApply.TabIndex = 30;
            this.BBeatApply.Text = "Apply";
            this.BBeatApply.UseVisualStyleBackColor = true;
            this.BBeatApply.Click += new System.EventHandler(this.BBeatApply_Click);
            // 
            // Label7
            // 
            this.Label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(49, 7);
            this.Label7.Margin = new System.Windows.Forms.Padding(0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(15, 20);
            this.Label7.TabIndex = 31;
            this.Label7.Text = "/";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tBeatValue
            // 
            this.TableLayoutPanel7.SetColumnSpan(this.tBeatValue, 3);
            this.tBeatValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tBeatValue.Location = new System.Drawing.Point(3, 35);
            this.tBeatValue.Margin = new System.Windows.Forms.Padding(3, 1, 3, 0);
            this.tBeatValue.Name = "tBeatValue";
            this.tBeatValue.Size = new System.Drawing.Size(107, 27);
            this.tBeatValue.TabIndex = 36;
            this.tBeatValue.Text = "1";
            this.tBeatValue.LostFocus += new System.EventHandler(this.tBeatValue_LostFocus);
            // 
            // LBeat
            // 
            this.LBeat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBeat.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LBeat.IntegralHeight = false;
            this.LBeat.ItemHeight = 18;
            this.LBeat.Items.AddRange(new object[] {
            "000: 15.984375 (1023/64)"});
            this.LBeat.Location = new System.Drawing.Point(3, 185);
            this.LBeat.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.LBeat.Name = "LBeat";
            this.LBeat.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LBeat.Size = new System.Drawing.Size(173, 60);
            this.LBeat.TabIndex = 26;
            // 
            // POBeatPart2
            // 
            this.POBeatPart2.AutoSize = true;
            this.POBeatPart2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.POBeatPart2.ColumnCount = 1;
            this.POBeatPart2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.POBeatPart2.Controls.Add(this.CBeatScale, 0, 3);
            this.POBeatPart2.Controls.Add(this.CBeatCut, 0, 2);
            this.POBeatPart2.Controls.Add(this.CBeatMeasure, 0, 1);
            this.POBeatPart2.Controls.Add(this.CBeatPreserve, 0, 0);
            this.POBeatPart2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.POBeatPart2.Location = new System.Drawing.Point(0, 94);
            this.POBeatPart2.Margin = new System.Windows.Forms.Padding(0);
            this.POBeatPart2.Name = "POBeatPart2";
            this.POBeatPart2.RowCount = 4;
            this.POBeatPart2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POBeatPart2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POBeatPart2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POBeatPart2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POBeatPart2.Size = new System.Drawing.Size(179, 91);
            this.POBeatPart2.TabIndex = 66;
            this.POBeatPart2.Visible = false;
            // 
            // CBeatScale
            // 
            this.CBeatScale.AutoSize = true;
            this.CBeatScale.Location = new System.Drawing.Point(3, 67);
            this.CBeatScale.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.CBeatScale.Name = "CBeatScale";
            this.CBeatScale.Size = new System.Drawing.Size(173, 24);
            this.CBeatScale.TabIndex = 3;
            this.CBeatScale.Text = "Scale to measure length";
            this.CBeatScale.UseVisualStyleBackColor = true;
            this.CBeatScale.Click += new System.EventHandler(this.CBeatPreserve_Click);
            // 
            // CBeatCut
            // 
            this.CBeatCut.AutoEllipsis = true;
            this.CBeatCut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CBeatCut.Location = new System.Drawing.Point(3, 48);
            this.CBeatCut.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.CBeatCut.Name = "CBeatCut";
            this.CBeatCut.Size = new System.Drawing.Size(173, 19);
            this.CBeatCut.TabIndex = 2;
            this.CBeatCut.Text = "Keep measure position and cut overflow";
            this.CBeatCut.UseVisualStyleBackColor = true;
            this.CBeatCut.Click += new System.EventHandler(this.CBeatPreserve_Click);
            // 
            // CBeatMeasure
            // 
            this.CBeatMeasure.AutoSize = true;
            this.CBeatMeasure.Location = new System.Drawing.Point(3, 24);
            this.CBeatMeasure.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.CBeatMeasure.Name = "CBeatMeasure";
            this.CBeatMeasure.Size = new System.Drawing.Size(173, 24);
            this.CBeatMeasure.TabIndex = 1;
            this.CBeatMeasure.Text = "Keep measure position";
            this.CBeatMeasure.UseVisualStyleBackColor = true;
            this.CBeatMeasure.Click += new System.EventHandler(this.CBeatPreserve_Click);
            // 
            // CBeatPreserve
            // 
            this.CBeatPreserve.AutoSize = true;
            this.CBeatPreserve.Checked = true;
            this.CBeatPreserve.Location = new System.Drawing.Point(3, 0);
            this.CBeatPreserve.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.CBeatPreserve.Name = "CBeatPreserve";
            this.CBeatPreserve.Size = new System.Drawing.Size(173, 24);
            this.CBeatPreserve.TabIndex = 0;
            this.CBeatPreserve.TabStop = true;
            this.CBeatPreserve.Text = "Keep absolute position";
            this.CBeatPreserve.UseVisualStyleBackColor = true;
            this.CBeatPreserve.Click += new System.EventHandler(this.CBeatPreserve_Click);
            // 
            // POBeatSwitch
            // 
            this.POBeatSwitch.Appearance = System.Windows.Forms.Appearance.Button;
            this.POBeatSwitch.BackColor = System.Drawing.SystemColors.Control;
            this.POBeatSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.POBeatSwitch.Dock = System.Windows.Forms.DockStyle.Top;
            this.POBeatSwitch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.POBeatSwitch.Location = new System.Drawing.Point(0, 0);
            this.POBeatSwitch.Name = "POBeatSwitch";
            this.POBeatSwitch.Size = new System.Drawing.Size(179, 20);
            this.POBeatSwitch.TabIndex = 5;
            this.POBeatSwitch.TabStop = false;
            this.POBeatSwitch.Text = "Beat";
            this.POBeatSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.POBeatSwitch.UseCompatibleTextRendering = true;
            this.POBeatSwitch.UseVisualStyleBackColor = false;
            this.POBeatSwitch.CheckedChanged += new System.EventHandler(this.Switches_CheckedChanged);
            // 
            // POBMP
            // 
            this.POBMP.AllowDrop = true;
            this.POBMP.AutoSize = true;
            this.POBMP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.POBMP.Controls.Add(this.POBMPInner);
            this.POBMP.Controls.Add(this.POBMPSwitch);
            this.POBMP.Dock = System.Windows.Forms.DockStyle.Top;
            this.POBMP.Location = new System.Drawing.Point(0, 1286);
            this.POBMP.Name = "POBMP";
            this.POBMP.Size = new System.Drawing.Size(179, 270);
            this.POBMP.TabIndex = 4;
            this.POBMP.DragDrop += new System.Windows.Forms.DragEventHandler(this.POBMP_DragDrop);
            this.POBMP.DragEnter += new System.Windows.Forms.DragEventHandler(this.POBMP_DragEnter);
            this.POBMP.DragLeave += new System.EventHandler(this.POBMP_DragLeave);
            this.POBMP.Resize += new System.EventHandler(this.POBMP_Resize);
            // 
            // POBMPInner
            // 
            this.POBMPInner.ColumnCount = 1;
            this.POBMPInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.POBMPInner.Controls.Add(this.LBMP, 0, 1);
            this.POBMPInner.Controls.Add(this.FlowLayoutPanel4, 0, 0);
            this.POBMPInner.Controls.Add(this.POBMPResizer, 0, 2);
            this.POBMPInner.Dock = System.Windows.Forms.DockStyle.Top;
            this.POBMPInner.Location = new System.Drawing.Point(0, 20);
            this.POBMPInner.Name = "POBMPInner";
            this.POBMPInner.RowCount = 3;
            this.POBMPInner.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POBMPInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.POBMPInner.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POBMPInner.Size = new System.Drawing.Size(179, 250);
            this.POBMPInner.TabIndex = 5;
            this.POBMPInner.Visible = false;
            // 
            // LBMP
            // 
            this.LBMP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBMP.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LBMP.IntegralHeight = false;
            this.LBMP.ItemHeight = 18;
            this.LBMP.Location = new System.Drawing.Point(3, 30);
            this.LBMP.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.LBMP.Name = "LBMP";
            this.LBMP.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LBMP.Size = new System.Drawing.Size(173, 215);
            this.LBMP.TabIndex = 25;
            this.LBMP.DoubleClick += new System.EventHandler(this.LBMP_DoubleClick);
            this.LBMP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LBMP_KeyDown);
            // 
            // FlowLayoutPanel4
            // 
            this.FlowLayoutPanel4.AutoSize = true;
            this.FlowLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FlowLayoutPanel4.Controls.Add(this.BBMPUp);
            this.FlowLayoutPanel4.Controls.Add(this.BBMPDown);
            this.FlowLayoutPanel4.Controls.Add(this.BBMPBrowse);
            this.FlowLayoutPanel4.Controls.Add(this.BBMPRemove);
            this.FlowLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.FlowLayoutPanel4.Name = "FlowLayoutPanel4";
            this.FlowLayoutPanel4.Size = new System.Drawing.Size(96, 24);
            this.FlowLayoutPanel4.TabIndex = 26;
            this.FlowLayoutPanel4.WrapContents = false;
            // 
            // BBMPUp
            // 
            this.BBMPUp.Image = global::iBMSC.Properties.Resources.x16Up;
            this.BBMPUp.Location = new System.Drawing.Point(0, 0);
            this.BBMPUp.Margin = new System.Windows.Forms.Padding(0);
            this.BBMPUp.Name = "BBMPUp";
            this.BBMPUp.Size = new System.Drawing.Size(24, 24);
            this.BBMPUp.TabIndex = 26;
            this.ToolTipUniversal.SetToolTip(this.BBMPUp, "Move Up");
            this.BBMPUp.UseVisualStyleBackColor = true;
            this.BBMPUp.Click += new System.EventHandler(this.BBMPUp_Click);
            // 
            // BBMPDown
            // 
            this.BBMPDown.Image = global::iBMSC.Properties.Resources.x16Down;
            this.BBMPDown.Location = new System.Drawing.Point(24, 0);
            this.BBMPDown.Margin = new System.Windows.Forms.Padding(0);
            this.BBMPDown.Name = "BBMPDown";
            this.BBMPDown.Size = new System.Drawing.Size(24, 24);
            this.BBMPDown.TabIndex = 27;
            this.ToolTipUniversal.SetToolTip(this.BBMPDown, "Move Down");
            this.BBMPDown.UseVisualStyleBackColor = true;
            this.BBMPDown.Click += new System.EventHandler(this.BBMPDown_Click);
            // 
            // BBMPBrowse
            // 
            this.BBMPBrowse.Image = global::iBMSC.Properties.Resources.x16PlayerBrowse;
            this.BBMPBrowse.Location = new System.Drawing.Point(48, 0);
            this.BBMPBrowse.Margin = new System.Windows.Forms.Padding(0);
            this.BBMPBrowse.Name = "BBMPBrowse";
            this.BBMPBrowse.Size = new System.Drawing.Size(24, 24);
            this.BBMPBrowse.TabIndex = 30;
            this.ToolTipUniversal.SetToolTip(this.BBMPBrowse, "Browse");
            this.BBMPBrowse.UseVisualStyleBackColor = true;
            this.BBMPBrowse.Click += new System.EventHandler(this.BBMPBrowse_Click);
            // 
            // BBMPRemove
            // 
            this.BBMPRemove.Image = global::iBMSC.Properties.Resources.x16Remove;
            this.BBMPRemove.Location = new System.Drawing.Point(72, 0);
            this.BBMPRemove.Margin = new System.Windows.Forms.Padding(0);
            this.BBMPRemove.Name = "BBMPRemove";
            this.BBMPRemove.Size = new System.Drawing.Size(24, 24);
            this.BBMPRemove.TabIndex = 31;
            this.ToolTipUniversal.SetToolTip(this.BBMPRemove, "Remove");
            this.BBMPRemove.UseVisualStyleBackColor = true;
            this.BBMPRemove.Click += new System.EventHandler(this.BBMPRemove_Click);
            // 
            // POBMPResizer
            // 
            this.POBMPResizer.Dock = System.Windows.Forms.DockStyle.Top;
            this.POBMPResizer.FlatAppearance.BorderSize = 0;
            this.POBMPResizer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.POBMPResizer.Location = new System.Drawing.Point(0, 245);
            this.POBMPResizer.Margin = new System.Windows.Forms.Padding(0);
            this.POBMPResizer.Name = "POBMPResizer";
            this.POBMPResizer.Size = new System.Drawing.Size(179, 5);
            this.POBMPResizer.TabIndex = 33;
            this.POBMPResizer.TabStop = false;
            this.POBMPResizer.UseVisualStyleBackColor = true;
            this.POBMPResizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VerticalResizer_MouseDown);
            this.POBMPResizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.POResizer_MouseMove);
            // 
            // POBMPSwitch
            // 
            this.POBMPSwitch.Appearance = System.Windows.Forms.Appearance.Button;
            this.POBMPSwitch.BackColor = System.Drawing.SystemColors.Control;
            this.POBMPSwitch.Checked = true;
            this.POBMPSwitch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.POBMPSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.POBMPSwitch.Dock = System.Windows.Forms.DockStyle.Top;
            this.POBMPSwitch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.POBMPSwitch.Location = new System.Drawing.Point(0, 0);
            this.POBMPSwitch.Name = "POBMPSwitch";
            this.POBMPSwitch.Size = new System.Drawing.Size(179, 20);
            this.POBMPSwitch.TabIndex = 4;
            this.POBMPSwitch.TabStop = false;
            this.POBMPSwitch.Text = "#BMP (Images List)";
            this.POBMPSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.POBMPSwitch.UseCompatibleTextRendering = true;
            this.POBMPSwitch.UseVisualStyleBackColor = false;
            this.POBMPSwitch.CheckedChanged += new System.EventHandler(this.Switches_CheckedChanged);
            // 
            // POWAV
            // 
            this.POWAV.AllowDrop = true;
            this.POWAV.AutoSize = true;
            this.POWAV.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.POWAV.Controls.Add(this.POWAVInner);
            this.POWAV.Controls.Add(this.POWAVSwitch);
            this.POWAV.Dock = System.Windows.Forms.DockStyle.Top;
            this.POWAV.Location = new System.Drawing.Point(0, 1016);
            this.POWAV.Name = "POWAV";
            this.POWAV.Size = new System.Drawing.Size(179, 270);
            this.POWAV.TabIndex = 4;
            this.POWAV.DragDrop += new System.Windows.Forms.DragEventHandler(this.POWAV_DragDrop);
            this.POWAV.DragEnter += new System.Windows.Forms.DragEventHandler(this.POWAV_DragEnter);
            this.POWAV.DragLeave += new System.EventHandler(this.POWAV_DragLeave);
            this.POWAV.Resize += new System.EventHandler(this.POWAV_Resize);
            // 
            // POWAVInner
            // 
            this.POWAVInner.ColumnCount = 1;
            this.POWAVInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.POWAVInner.Controls.Add(this.POWAVExpander, 0, 1);
            this.POWAVInner.Controls.Add(this.LWAV, 0, 3);
            this.POWAVInner.Controls.Add(this.FlowLayoutPanel3, 0, 0);
            this.POWAVInner.Controls.Add(this.POWAVResizer, 0, 4);
            this.POWAVInner.Controls.Add(this.POWAVPart2, 0, 2);
            this.POWAVInner.Dock = System.Windows.Forms.DockStyle.Top;
            this.POWAVInner.Location = new System.Drawing.Point(0, 20);
            this.POWAVInner.Name = "POWAVInner";
            this.POWAVInner.RowCount = 5;
            this.POWAVInner.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POWAVInner.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POWAVInner.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POWAVInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.POWAVInner.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POWAVInner.Size = new System.Drawing.Size(179, 250);
            this.POWAVInner.TabIndex = 5;
            // 
            // POWAVExpander
            // 
            this.POWAVExpander.Appearance = System.Windows.Forms.Appearance.Button;
            this.POWAVExpander.AutoSize = true;
            this.POWAVExpander.Cursor = System.Windows.Forms.Cursors.Hand;
            this.POWAVExpander.Dock = System.Windows.Forms.DockStyle.Top;
            this.POWAVExpander.FlatAppearance.BorderSize = 0;
            this.POWAVExpander.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.POWAVExpander.Location = new System.Drawing.Point(0, 30);
            this.POWAVExpander.Margin = new System.Windows.Forms.Padding(0);
            this.POWAVExpander.Name = "POWAVExpander";
            this.POWAVExpander.Size = new System.Drawing.Size(179, 30);
            this.POWAVExpander.TabIndex = 34;
            this.POWAVExpander.TabStop = false;
            this.POWAVExpander.Text = "Expand...";
            this.POWAVExpander.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.POWAVExpander.UseVisualStyleBackColor = false;
            this.POWAVExpander.CheckedChanged += new System.EventHandler(this.Expanders_CheckChanged);
            // 
            // LWAV
            // 
            this.LWAV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LWAV.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LWAV.IntegralHeight = false;
            this.LWAV.ItemHeight = 18;
            this.LWAV.Location = new System.Drawing.Point(3, 108);
            this.LWAV.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.LWAV.Name = "LWAV";
            this.LWAV.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LWAV.Size = new System.Drawing.Size(173, 137);
            this.LWAV.TabIndex = 25;
            this.LWAV.Click += new System.EventHandler(this.LWAV_Click);
            this.LWAV.DoubleClick += new System.EventHandler(this.LWAV_DoubleClick);
            this.LWAV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LWAV_KeyDown);
            // 
            // FlowLayoutPanel3
            // 
            this.FlowLayoutPanel3.AutoSize = true;
            this.FlowLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FlowLayoutPanel3.Controls.Add(this.BWAVUp);
            this.FlowLayoutPanel3.Controls.Add(this.BWAVDown);
            this.FlowLayoutPanel3.Controls.Add(this.BWAVBrowse);
            this.FlowLayoutPanel3.Controls.Add(this.BWAVRemove);
            this.FlowLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.FlowLayoutPanel3.Name = "FlowLayoutPanel3";
            this.FlowLayoutPanel3.Size = new System.Drawing.Size(96, 24);
            this.FlowLayoutPanel3.TabIndex = 26;
            this.FlowLayoutPanel3.WrapContents = false;
            // 
            // BWAVUp
            // 
            this.BWAVUp.Image = global::iBMSC.Properties.Resources.x16Up;
            this.BWAVUp.Location = new System.Drawing.Point(0, 0);
            this.BWAVUp.Margin = new System.Windows.Forms.Padding(0);
            this.BWAVUp.Name = "BWAVUp";
            this.BWAVUp.Size = new System.Drawing.Size(24, 24);
            this.BWAVUp.TabIndex = 26;
            this.ToolTipUniversal.SetToolTip(this.BWAVUp, "Move Up");
            this.BWAVUp.UseVisualStyleBackColor = true;
            this.BWAVUp.Click += new System.EventHandler(this.BWAVUp_Click);
            // 
            // BWAVDown
            // 
            this.BWAVDown.Image = global::iBMSC.Properties.Resources.x16Down;
            this.BWAVDown.Location = new System.Drawing.Point(24, 0);
            this.BWAVDown.Margin = new System.Windows.Forms.Padding(0);
            this.BWAVDown.Name = "BWAVDown";
            this.BWAVDown.Size = new System.Drawing.Size(24, 24);
            this.BWAVDown.TabIndex = 27;
            this.ToolTipUniversal.SetToolTip(this.BWAVDown, "Move Down");
            this.BWAVDown.UseVisualStyleBackColor = true;
            this.BWAVDown.Click += new System.EventHandler(this.BWAVDown_Click);
            // 
            // BWAVBrowse
            // 
            this.BWAVBrowse.Image = global::iBMSC.Properties.Resources.x16PlayerBrowse;
            this.BWAVBrowse.Location = new System.Drawing.Point(48, 0);
            this.BWAVBrowse.Margin = new System.Windows.Forms.Padding(0);
            this.BWAVBrowse.Name = "BWAVBrowse";
            this.BWAVBrowse.Size = new System.Drawing.Size(24, 24);
            this.BWAVBrowse.TabIndex = 30;
            this.ToolTipUniversal.SetToolTip(this.BWAVBrowse, "Browse");
            this.BWAVBrowse.UseVisualStyleBackColor = true;
            this.BWAVBrowse.Click += new System.EventHandler(this.BWAVBrowse_Click);
            // 
            // BWAVRemove
            // 
            this.BWAVRemove.Image = global::iBMSC.Properties.Resources.x16Remove;
            this.BWAVRemove.Location = new System.Drawing.Point(72, 0);
            this.BWAVRemove.Margin = new System.Windows.Forms.Padding(0);
            this.BWAVRemove.Name = "BWAVRemove";
            this.BWAVRemove.Size = new System.Drawing.Size(24, 24);
            this.BWAVRemove.TabIndex = 31;
            this.ToolTipUniversal.SetToolTip(this.BWAVRemove, "Remove");
            this.BWAVRemove.UseVisualStyleBackColor = true;
            this.BWAVRemove.Click += new System.EventHandler(this.BWAVRemove_Click);
            // 
            // POWAVResizer
            // 
            this.POWAVResizer.Dock = System.Windows.Forms.DockStyle.Top;
            this.POWAVResizer.FlatAppearance.BorderSize = 0;
            this.POWAVResizer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.POWAVResizer.Location = new System.Drawing.Point(0, 245);
            this.POWAVResizer.Margin = new System.Windows.Forms.Padding(0);
            this.POWAVResizer.Name = "POWAVResizer";
            this.POWAVResizer.Size = new System.Drawing.Size(179, 5);
            this.POWAVResizer.TabIndex = 33;
            this.POWAVResizer.TabStop = false;
            this.POWAVResizer.UseVisualStyleBackColor = true;
            this.POWAVResizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VerticalResizer_MouseDown);
            this.POWAVResizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.POResizer_MouseMove);
            // 
            // POWAVPart2
            // 
            this.POWAVPart2.AutoSize = true;
            this.POWAVPart2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.POWAVPart2.ColumnCount = 1;
            this.POWAVPart2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.POWAVPart2.Controls.Add(this.CWAVMultiSelect, 0, 0);
            this.POWAVPart2.Controls.Add(this.CWAVChangeLabel, 0, 1);
            this.POWAVPart2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.POWAVPart2.Location = new System.Drawing.Point(0, 60);
            this.POWAVPart2.Margin = new System.Windows.Forms.Padding(0);
            this.POWAVPart2.Name = "POWAVPart2";
            this.POWAVPart2.RowCount = 2;
            this.POWAVPart2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POWAVPart2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POWAVPart2.Size = new System.Drawing.Size(179, 48);
            this.POWAVPart2.TabIndex = 35;
            this.POWAVPart2.Visible = false;
            // 
            // CWAVMultiSelect
            // 
            this.CWAVMultiSelect.AutoSize = true;
            this.CWAVMultiSelect.Checked = true;
            this.CWAVMultiSelect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CWAVMultiSelect.Location = new System.Drawing.Point(3, 0);
            this.CWAVMultiSelect.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.CWAVMultiSelect.Name = "CWAVMultiSelect";
            this.CWAVMultiSelect.Size = new System.Drawing.Size(173, 24);
            this.CWAVMultiSelect.TabIndex = 0;
            this.CWAVMultiSelect.Text = "Allow Multiple Selection";
            this.CWAVMultiSelect.UseVisualStyleBackColor = true;
            this.CWAVMultiSelect.CheckedChanged += new System.EventHandler(this.CWAVMultiSelect_CheckedChanged);
            // 
            // CWAVChangeLabel
            // 
            this.CWAVChangeLabel.AutoSize = true;
            this.CWAVChangeLabel.Checked = true;
            this.CWAVChangeLabel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CWAVChangeLabel.Location = new System.Drawing.Point(3, 24);
            this.CWAVChangeLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.CWAVChangeLabel.Name = "CWAVChangeLabel";
            this.CWAVChangeLabel.Size = new System.Drawing.Size(173, 24);
            this.CWAVChangeLabel.TabIndex = 1;
            this.CWAVChangeLabel.Text = "Synchronize Note Labels";
            this.CWAVChangeLabel.UseVisualStyleBackColor = true;
            this.CWAVChangeLabel.CheckedChanged += new System.EventHandler(this.CWAVChangeLabel_CheckedChanged);
            // 
            // POWAVSwitch
            // 
            this.POWAVSwitch.Appearance = System.Windows.Forms.Appearance.Button;
            this.POWAVSwitch.BackColor = System.Drawing.SystemColors.Control;
            this.POWAVSwitch.Checked = true;
            this.POWAVSwitch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.POWAVSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.POWAVSwitch.Dock = System.Windows.Forms.DockStyle.Top;
            this.POWAVSwitch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.POWAVSwitch.Location = new System.Drawing.Point(0, 0);
            this.POWAVSwitch.Name = "POWAVSwitch";
            this.POWAVSwitch.Size = new System.Drawing.Size(179, 20);
            this.POWAVSwitch.TabIndex = 4;
            this.POWAVSwitch.TabStop = false;
            this.POWAVSwitch.Text = "#WAV (Sounds List)";
            this.POWAVSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.POWAVSwitch.UseCompatibleTextRendering = true;
            this.POWAVSwitch.UseVisualStyleBackColor = false;
            this.POWAVSwitch.CheckedChanged += new System.EventHandler(this.Switches_CheckedChanged);
            // 
            // POWaveForm
            // 
            this.POWaveForm.AutoSize = true;
            this.POWaveForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.POWaveForm.Controls.Add(this.POWaveFormInner);
            this.POWaveForm.Controls.Add(this.POWaveFormSwitch);
            this.POWaveForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.POWaveForm.Location = new System.Drawing.Point(0, 765);
            this.POWaveForm.Name = "POWaveForm";
            this.POWaveForm.Size = new System.Drawing.Size(179, 251);
            this.POWaveForm.TabIndex = 3;
            // 
            // POWaveFormInner
            // 
            this.POWaveFormInner.AutoSize = true;
            this.POWaveFormInner.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.POWaveFormInner.Controls.Add(this.POWaveFormPart2);
            this.POWaveFormInner.Controls.Add(this.POWaveFormExpander);
            this.POWaveFormInner.Controls.Add(this.POWaveFormPart1);
            this.POWaveFormInner.Dock = System.Windows.Forms.DockStyle.Top;
            this.POWaveFormInner.Location = new System.Drawing.Point(0, 20);
            this.POWaveFormInner.Name = "POWaveFormInner";
            this.POWaveFormInner.Size = new System.Drawing.Size(179, 231);
            this.POWaveFormInner.TabIndex = 29;
            this.POWaveFormInner.Visible = false;
            // 
            // POWaveFormPart2
            // 
            this.POWaveFormPart2.AutoSize = true;
            this.POWaveFormPart2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.POWaveFormPart2.ColumnCount = 3;
            this.POWaveFormPart2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.POWaveFormPart2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.POWaveFormPart2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.POWaveFormPart2.Controls.Add(this.TWSaturation, 2, 4);
            this.POWaveFormPart2.Controls.Add(this.PictureBox2, 0, 0);
            this.POWaveFormPart2.Controls.Add(this.TWTransparency, 2, 3);
            this.POWaveFormPart2.Controls.Add(this.PictureBox3, 0, 1);
            this.POWaveFormPart2.Controls.Add(this.TWPrecision, 2, 2);
            this.POWaveFormPart2.Controls.Add(this.PictureBox4, 0, 2);
            this.POWaveFormPart2.Controls.Add(this.TWWidth, 2, 1);
            this.POWaveFormPart2.Controls.Add(this.PictureBox5, 0, 3);
            this.POWaveFormPart2.Controls.Add(this.TWLeft, 2, 0);
            this.POWaveFormPart2.Controls.Add(this.PictureBox6, 0, 4);
            this.POWaveFormPart2.Controls.Add(this.TWSaturation2, 1, 4);
            this.POWaveFormPart2.Controls.Add(this.TWLeft2, 1, 0);
            this.POWaveFormPart2.Controls.Add(this.TWTransparency2, 1, 3);
            this.POWaveFormPart2.Controls.Add(this.TWWidth2, 1, 1);
            this.POWaveFormPart2.Controls.Add(this.TWPrecision2, 1, 2);
            this.POWaveFormPart2.Dock = System.Windows.Forms.DockStyle.Top;
            this.POWaveFormPart2.Location = new System.Drawing.Point(0, 91);
            this.POWaveFormPart2.Name = "POWaveFormPart2";
            this.POWaveFormPart2.RowCount = 5;
            this.POWaveFormPart2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.POWaveFormPart2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.POWaveFormPart2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.POWaveFormPart2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.POWaveFormPart2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.POWaveFormPart2.Size = new System.Drawing.Size(179, 140);
            this.POWaveFormPart2.TabIndex = 5;
            // 
            // TWSaturation
            // 
            this.TWSaturation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TWSaturation.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.TWSaturation.Location = new System.Drawing.Point(134, 112);
            this.TWSaturation.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.TWSaturation.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.TWSaturation.Name = "TWSaturation";
            this.TWSaturation.Size = new System.Drawing.Size(42, 27);
            this.TWSaturation.TabIndex = 68;
            this.TWSaturation.ValueChanged += new System.EventHandler(this.TWSaturation_ValueChanged);
            // 
            // PictureBox2
            // 
            this.PictureBox2.Image = global::iBMSC.Properties.Resources.WAVLeft;
            this.PictureBox2.Location = new System.Drawing.Point(3, 0);
            this.PictureBox2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(24, 24);
            this.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox2.TabIndex = 60;
            this.PictureBox2.TabStop = false;
            // 
            // TWTransparency
            // 
            this.TWTransparency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TWTransparency.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.TWTransparency.Location = new System.Drawing.Point(134, 84);
            this.TWTransparency.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.TWTransparency.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.TWTransparency.Name = "TWTransparency";
            this.TWTransparency.Size = new System.Drawing.Size(42, 27);
            this.TWTransparency.TabIndex = 69;
            this.TWTransparency.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.TWTransparency.ValueChanged += new System.EventHandler(this.TWTransparency_ValueChanged);
            // 
            // PictureBox3
            // 
            this.PictureBox3.Image = global::iBMSC.Properties.Resources.WAVWidth;
            this.PictureBox3.Location = new System.Drawing.Point(3, 28);
            this.PictureBox3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.PictureBox3.Name = "PictureBox3";
            this.PictureBox3.Size = new System.Drawing.Size(24, 24);
            this.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox3.TabIndex = 61;
            this.PictureBox3.TabStop = false;
            // 
            // TWPrecision
            // 
            this.TWPrecision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TWPrecision.Location = new System.Drawing.Point(134, 56);
            this.TWPrecision.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.TWPrecision.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.TWPrecision.Name = "TWPrecision";
            this.TWPrecision.Size = new System.Drawing.Size(42, 27);
            this.TWPrecision.TabIndex = 46;
            this.TWPrecision.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.TWPrecision.ValueChanged += new System.EventHandler(this.TWPrecision_ValueChanged);
            // 
            // PictureBox4
            // 
            this.PictureBox4.Image = global::iBMSC.Properties.Resources.WAVPrecision;
            this.PictureBox4.Location = new System.Drawing.Point(3, 56);
            this.PictureBox4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.PictureBox4.Name = "PictureBox4";
            this.PictureBox4.Size = new System.Drawing.Size(24, 24);
            this.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox4.TabIndex = 62;
            this.PictureBox4.TabStop = false;
            // 
            // TWWidth
            // 
            this.TWWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TWWidth.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.TWWidth.Location = new System.Drawing.Point(134, 28);
            this.TWWidth.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.TWWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.TWWidth.Name = "TWWidth";
            this.TWWidth.Size = new System.Drawing.Size(42, 27);
            this.TWWidth.TabIndex = 45;
            this.TWWidth.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.TWWidth.ValueChanged += new System.EventHandler(this.TWWidth_ValueChanged);
            // 
            // PictureBox5
            // 
            this.PictureBox5.Image = global::iBMSC.Properties.Resources.WAVTransparency;
            this.PictureBox5.Location = new System.Drawing.Point(3, 84);
            this.PictureBox5.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.PictureBox5.Name = "PictureBox5";
            this.PictureBox5.Size = new System.Drawing.Size(24, 24);
            this.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox5.TabIndex = 67;
            this.PictureBox5.TabStop = false;
            // 
            // TWLeft
            // 
            this.TWLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TWLeft.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.TWLeft.Location = new System.Drawing.Point(134, 0);
            this.TWLeft.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.TWLeft.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.TWLeft.Name = "TWLeft";
            this.TWLeft.Size = new System.Drawing.Size(42, 27);
            this.TWLeft.TabIndex = 44;
            this.TWLeft.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.TWLeft.ValueChanged += new System.EventHandler(this.TWLeft_ValueChanged);
            // 
            // PictureBox6
            // 
            this.PictureBox6.Image = global::iBMSC.Properties.Resources.WAVSaturation;
            this.PictureBox6.Location = new System.Drawing.Point(3, 112);
            this.PictureBox6.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.PictureBox6.Name = "PictureBox6";
            this.PictureBox6.Size = new System.Drawing.Size(24, 24);
            this.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox6.TabIndex = 66;
            this.PictureBox6.TabStop = false;
            // 
            // TWSaturation2
            // 
            this.TWSaturation2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TWSaturation2.LargeChange = 200;
            this.TWSaturation2.Location = new System.Drawing.Point(30, 112);
            this.TWSaturation2.Margin = new System.Windows.Forms.Padding(0);
            this.TWSaturation2.Maximum = 1000;
            this.TWSaturation2.Name = "TWSaturation2";
            this.TWSaturation2.Size = new System.Drawing.Size(104, 28);
            this.TWSaturation2.SmallChange = 50;
            this.TWSaturation2.TabIndex = 70;
            this.TWSaturation2.TickFrequency = 200;
            this.TWSaturation2.Scroll += new System.EventHandler(this.TWSaturation2_Scroll);
            // 
            // TWLeft2
            // 
            this.TWLeft2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TWLeft2.LargeChange = 50;
            this.TWLeft2.Location = new System.Drawing.Point(30, 0);
            this.TWLeft2.Margin = new System.Windows.Forms.Padding(0);
            this.TWLeft2.Maximum = 800;
            this.TWLeft2.Name = "TWLeft2";
            this.TWLeft2.Size = new System.Drawing.Size(104, 28);
            this.TWLeft2.SmallChange = 10;
            this.TWLeft2.TabIndex = 63;
            this.TWLeft2.TickFrequency = 100;
            this.TWLeft2.Value = 50;
            this.TWLeft2.Scroll += new System.EventHandler(this.TWLeft2_Scroll);
            // 
            // TWTransparency2
            // 
            this.TWTransparency2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TWTransparency2.LargeChange = 64;
            this.TWTransparency2.Location = new System.Drawing.Point(30, 84);
            this.TWTransparency2.Margin = new System.Windows.Forms.Padding(0);
            this.TWTransparency2.Maximum = 255;
            this.TWTransparency2.Name = "TWTransparency2";
            this.TWTransparency2.Size = new System.Drawing.Size(104, 28);
            this.TWTransparency2.SmallChange = 8;
            this.TWTransparency2.TabIndex = 71;
            this.TWTransparency2.TickFrequency = 64;
            this.TWTransparency2.Value = 80;
            this.TWTransparency2.Scroll += new System.EventHandler(this.TWTransparency2_Scroll);
            // 
            // TWWidth2
            // 
            this.TWWidth2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TWWidth2.LargeChange = 50;
            this.TWWidth2.Location = new System.Drawing.Point(30, 28);
            this.TWWidth2.Margin = new System.Windows.Forms.Padding(0);
            this.TWWidth2.Maximum = 1000;
            this.TWWidth2.Name = "TWWidth2";
            this.TWWidth2.Size = new System.Drawing.Size(104, 28);
            this.TWWidth2.SmallChange = 10;
            this.TWWidth2.TabIndex = 64;
            this.TWWidth2.TickFrequency = 100;
            this.TWWidth2.Value = 200;
            this.TWWidth2.Scroll += new System.EventHandler(this.TWWidth2_Scroll);
            // 
            // TWPrecision2
            // 
            this.TWPrecision2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TWPrecision2.LargeChange = 4;
            this.TWPrecision2.Location = new System.Drawing.Point(30, 56);
            this.TWPrecision2.Margin = new System.Windows.Forms.Padding(0);
            this.TWPrecision2.Maximum = 50;
            this.TWPrecision2.Name = "TWPrecision2";
            this.TWPrecision2.Size = new System.Drawing.Size(104, 28);
            this.TWPrecision2.TabIndex = 65;
            this.TWPrecision2.TickFrequency = 5;
            this.TWPrecision2.Value = 5;
            this.TWPrecision2.Scroll += new System.EventHandler(this.TWPrecision2_Scroll);
            // 
            // POWaveFormExpander
            // 
            this.POWaveFormExpander.Appearance = System.Windows.Forms.Appearance.Button;
            this.POWaveFormExpander.AutoSize = true;
            this.POWaveFormExpander.Cursor = System.Windows.Forms.Cursors.Hand;
            this.POWaveFormExpander.Dock = System.Windows.Forms.DockStyle.Top;
            this.POWaveFormExpander.FlatAppearance.BorderSize = 0;
            this.POWaveFormExpander.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.POWaveFormExpander.Location = new System.Drawing.Point(0, 61);
            this.POWaveFormExpander.Margin = new System.Windows.Forms.Padding(0);
            this.POWaveFormExpander.Name = "POWaveFormExpander";
            this.POWaveFormExpander.Size = new System.Drawing.Size(179, 30);
            this.POWaveFormExpander.TabIndex = 29;
            this.POWaveFormExpander.TabStop = false;
            this.POWaveFormExpander.Text = "Expand...";
            this.POWaveFormExpander.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.POWaveFormExpander.UseVisualStyleBackColor = false;
            this.POWaveFormExpander.CheckedChanged += new System.EventHandler(this.Expanders_CheckChanged);
            // 
            // POWaveFormPart1
            // 
            this.POWaveFormPart1.AutoSize = true;
            this.POWaveFormPart1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.POWaveFormPart1.ColumnCount = 1;
            this.POWaveFormPart1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.POWaveFormPart1.Controls.Add(this.TableLayoutPanel1, 0, 0);
            this.POWaveFormPart1.Controls.Add(this.TableLayoutPanel6, 0, 1);
            this.POWaveFormPart1.Dock = System.Windows.Forms.DockStyle.Top;
            this.POWaveFormPart1.Location = new System.Drawing.Point(0, 0);
            this.POWaveFormPart1.Name = "POWaveFormPart1";
            this.POWaveFormPart1.RowCount = 2;
            this.POWaveFormPart1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POWaveFormPart1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POWaveFormPart1.Size = new System.Drawing.Size(179, 61);
            this.POWaveFormPart1.TabIndex = 4;
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.AutoSize = true;
            this.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.Controls.Add(this.FlowLayoutPanel1, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.TWFileName, 1, 0);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel1.Size = new System.Drawing.Size(179, 33);
            this.TableLayoutPanel1.TabIndex = 0;
            // 
            // FlowLayoutPanel1
            // 
            this.FlowLayoutPanel1.AutoSize = true;
            this.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FlowLayoutPanel1.Controls.Add(this.BWLoad);
            this.FlowLayoutPanel1.Controls.Add(this.BWClear);
            this.FlowLayoutPanel1.Controls.Add(this.BWLock);
            this.FlowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            this.FlowLayoutPanel1.Size = new System.Drawing.Size(72, 24);
            this.FlowLayoutPanel1.TabIndex = 72;
            this.FlowLayoutPanel1.WrapContents = false;
            // 
            // BWLoad
            // 
            this.BWLoad.Image = global::iBMSC.Properties.Resources.x16Add;
            this.BWLoad.Location = new System.Drawing.Point(0, 0);
            this.BWLoad.Margin = new System.Windows.Forms.Padding(0);
            this.BWLoad.Name = "BWLoad";
            this.BWLoad.Size = new System.Drawing.Size(24, 24);
            this.BWLoad.TabIndex = 40;
            this.ToolTipUniversal.SetToolTip(this.BWLoad, "Load WaveForm");
            this.BWLoad.UseVisualStyleBackColor = true;
            this.BWLoad.Click += new System.EventHandler(this.BWLoad_Click);
            // 
            // BWClear
            // 
            this.BWClear.Image = global::iBMSC.Properties.Resources.x16Remove;
            this.BWClear.Location = new System.Drawing.Point(24, 0);
            this.BWClear.Margin = new System.Windows.Forms.Padding(0);
            this.BWClear.Name = "BWClear";
            this.BWClear.Size = new System.Drawing.Size(24, 24);
            this.BWClear.TabIndex = 41;
            this.ToolTipUniversal.SetToolTip(this.BWClear, "Clear WaveForm");
            this.BWClear.UseVisualStyleBackColor = true;
            this.BWClear.Click += new System.EventHandler(this.BWClear_Click);
            // 
            // BWLock
            // 
            this.BWLock.Appearance = System.Windows.Forms.Appearance.Button;
            this.BWLock.Checked = true;
            this.BWLock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BWLock.Image = global::iBMSC.Properties.Resources.x16Lock;
            this.BWLock.Location = new System.Drawing.Point(48, 0);
            this.BWLock.Margin = new System.Windows.Forms.Padding(0);
            this.BWLock.Name = "BWLock";
            this.BWLock.Size = new System.Drawing.Size(24, 24);
            this.BWLock.TabIndex = 0;
            this.ToolTipUniversal.SetToolTip(this.BWLock, "Lock to BGM");
            this.BWLock.UseVisualStyleBackColor = true;
            this.BWLock.CheckedChanged += new System.EventHandler(this.BWLock_CheckedChanged);
            // 
            // TWFileName
            // 
            this.TWFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TWFileName.Location = new System.Drawing.Point(81, 3);
            this.TWFileName.Name = "TWFileName";
            this.TWFileName.ReadOnly = true;
            this.TWFileName.Size = new System.Drawing.Size(95, 27);
            this.TWFileName.TabIndex = 42;
            this.TWFileName.Text = "(None)";
            // 
            // TableLayoutPanel6
            // 
            this.TableLayoutPanel6.AutoSize = true;
            this.TableLayoutPanel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TableLayoutPanel6.ColumnCount = 3;
            this.TableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.TableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.TableLayoutPanel6.Controls.Add(this.PictureBox1, 0, 0);
            this.TableLayoutPanel6.Controls.Add(this.TWPosition2, 1, 0);
            this.TableLayoutPanel6.Controls.Add(this.TWPosition, 2, 0);
            this.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel6.Location = new System.Drawing.Point(0, 33);
            this.TableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayoutPanel6.Name = "TableLayoutPanel6";
            this.TableLayoutPanel6.RowCount = 1;
            this.TableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.TableLayoutPanel6.Size = new System.Drawing.Size(179, 28);
            this.TableLayoutPanel6.TabIndex = 1;
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = global::iBMSC.Properties.Resources.WAVOffset;
            this.PictureBox1.Location = new System.Drawing.Point(3, 0);
            this.PictureBox1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(24, 24);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox1.TabIndex = 59;
            this.PictureBox1.TabStop = false;
            // 
            // TWPosition2
            // 
            this.TWPosition2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TWPosition2.Enabled = false;
            this.TWPosition2.LargeChange = 24;
            this.TWPosition2.Location = new System.Drawing.Point(30, 0);
            this.TWPosition2.Margin = new System.Windows.Forms.Padding(0);
            this.TWPosition2.Maximum = 960;
            this.TWPosition2.Name = "TWPosition2";
            this.TWPosition2.Size = new System.Drawing.Size(89, 28);
            this.TWPosition2.TabIndex = 58;
            this.TWPosition2.TickFrequency = 192;
            this.TWPosition2.Scroll += new System.EventHandler(this.TWPosition2_Scroll);
            // 
            // TWPosition
            // 
            this.TWPosition.DecimalPlaces = 2;
            this.TWPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TWPosition.Enabled = false;
            this.TWPosition.Location = new System.Drawing.Point(119, 0);
            this.TWPosition.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.TWPosition.Maximum = new decimal(new int[] {
            192000,
            0,
            0,
            0});
            this.TWPosition.Name = "TWPosition";
            this.TWPosition.Size = new System.Drawing.Size(57, 27);
            this.TWPosition.TabIndex = 43;
            this.TWPosition.ValueChanged += new System.EventHandler(this.TWPosition_ValueChanged);
            // 
            // POWaveFormSwitch
            // 
            this.POWaveFormSwitch.Appearance = System.Windows.Forms.Appearance.Button;
            this.POWaveFormSwitch.BackColor = System.Drawing.SystemColors.Control;
            this.POWaveFormSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.POWaveFormSwitch.Dock = System.Windows.Forms.DockStyle.Top;
            this.POWaveFormSwitch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.POWaveFormSwitch.Location = new System.Drawing.Point(0, 0);
            this.POWaveFormSwitch.Name = "POWaveFormSwitch";
            this.POWaveFormSwitch.Size = new System.Drawing.Size(179, 20);
            this.POWaveFormSwitch.TabIndex = 3;
            this.POWaveFormSwitch.TabStop = false;
            this.POWaveFormSwitch.Text = "WaveForm";
            this.POWaveFormSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.POWaveFormSwitch.UseCompatibleTextRendering = true;
            this.POWaveFormSwitch.UseVisualStyleBackColor = false;
            this.POWaveFormSwitch.CheckedChanged += new System.EventHandler(this.Switches_CheckedChanged);
            // 
            // POGrid
            // 
            this.POGrid.AutoSize = true;
            this.POGrid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.POGrid.Controls.Add(this.POGridInner);
            this.POGrid.Controls.Add(this.POGridSwitch);
            this.POGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.POGrid.Location = new System.Drawing.Point(0, 513);
            this.POGrid.Name = "POGrid";
            this.POGrid.Size = new System.Drawing.Size(179, 252);
            this.POGrid.TabIndex = 2;
            // 
            // POGridInner
            // 
            this.POGridInner.AutoSize = true;
            this.POGridInner.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.POGridInner.Controls.Add(this.POGridPart2);
            this.POGridInner.Controls.Add(this.POGridExpander);
            this.POGridInner.Controls.Add(this.POGridPart1);
            this.POGridInner.Dock = System.Windows.Forms.DockStyle.Top;
            this.POGridInner.Location = new System.Drawing.Point(0, 20);
            this.POGridInner.Name = "POGridInner";
            this.POGridInner.Size = new System.Drawing.Size(179, 232);
            this.POGridInner.TabIndex = 3;
            // 
            // POGridPart2
            // 
            this.POGridPart2.AutoSize = true;
            this.POGridPart2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.POGridPart2.ColumnCount = 1;
            this.POGridPart2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.POGridPart2.Controls.Add(this.TableLayoutPanel5, 0, 1);
            this.POGridPart2.Controls.Add(this.TableLayoutPanel4, 0, 0);
            this.POGridPart2.Dock = System.Windows.Forms.DockStyle.Top;
            this.POGridPart2.Location = new System.Drawing.Point(0, 170);
            this.POGridPart2.Name = "POGridPart2";
            this.POGridPart2.RowCount = 2;
            this.POGridPart2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POGridPart2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POGridPart2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.POGridPart2.Size = new System.Drawing.Size(179, 62);
            this.POGridPart2.TabIndex = 0;
            // 
            // TableLayoutPanel5
            // 
            this.TableLayoutPanel5.AutoSize = true;
            this.TableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TableLayoutPanel5.ColumnCount = 2;
            this.TableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel5.Controls.Add(this.FlowLayoutPanel2, 1, 0);
            this.TableLayoutPanel5.Controls.Add(this.Label5, 0, 0);
            this.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel5.Location = new System.Drawing.Point(0, 33);
            this.TableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayoutPanel5.Name = "TableLayoutPanel5";
            this.TableLayoutPanel5.RowCount = 1;
            this.TableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel5.Size = new System.Drawing.Size(179, 29);
            this.TableLayoutPanel5.TabIndex = 46;
            // 
            // FlowLayoutPanel2
            // 
            this.FlowLayoutPanel2.AutoSize = true;
            this.FlowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FlowLayoutPanel2.Controls.Add(this.cVSLockL);
            this.FlowLayoutPanel2.Controls.Add(this.cVSLock);
            this.FlowLayoutPanel2.Controls.Add(this.cVSLockR);
            this.FlowLayoutPanel2.Location = new System.Drawing.Point(142, 3);
            this.FlowLayoutPanel2.Name = "FlowLayoutPanel2";
            this.FlowLayoutPanel2.Size = new System.Drawing.Size(34, 23);
            this.FlowLayoutPanel2.TabIndex = 72;
            this.FlowLayoutPanel2.WrapContents = false;
            // 
            // cVSLockL
            // 
            this.cVSLockL.Appearance = System.Windows.Forms.Appearance.Button;
            this.cVSLockL.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cVSLockL.Image = global::iBMSC.Properties.Resources.x16Lock;
            this.cVSLockL.Location = new System.Drawing.Point(0, 0);
            this.cVSLockL.Margin = new System.Windows.Forms.Padding(0);
            this.cVSLockL.Name = "cVSLockL";
            this.cVSLockL.Size = new System.Drawing.Size(23, 23);
            this.cVSLockL.TabIndex = 38;
            this.cVSLockL.Tag = "0";
            this.ToolTipUniversal.SetToolTip(this.cVSLockL, "Lock Left Editing Panel");
            this.cVSLockL.CheckedChanged += new System.EventHandler(this.cVSLock_CheckedChanged);
            // 
            // cVSLock
            // 
            this.cVSLock.Appearance = System.Windows.Forms.Appearance.Button;
            this.cVSLock.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cVSLock.Image = global::iBMSC.Properties.Resources.x16Lock;
            this.cVSLock.Location = new System.Drawing.Point(23, 0);
            this.cVSLock.Margin = new System.Windows.Forms.Padding(0);
            this.cVSLock.Name = "cVSLock";
            this.cVSLock.Size = new System.Drawing.Size(23, 23);
            this.cVSLock.TabIndex = 40;
            this.cVSLock.Tag = "1";
            this.ToolTipUniversal.SetToolTip(this.cVSLock, "Lock Middle Editing Panel");
            this.cVSLock.CheckedChanged += new System.EventHandler(this.cVSLock_CheckedChanged);
            // 
            // cVSLockR
            // 
            this.cVSLockR.Appearance = System.Windows.Forms.Appearance.Button;
            this.cVSLockR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cVSLockR.Image = global::iBMSC.Properties.Resources.x16Lock;
            this.cVSLockR.Location = new System.Drawing.Point(46, 0);
            this.cVSLockR.Margin = new System.Windows.Forms.Padding(0);
            this.cVSLockR.Name = "cVSLockR";
            this.cVSLockR.Size = new System.Drawing.Size(23, 23);
            this.cVSLockR.TabIndex = 41;
            this.cVSLockR.Tag = "2";
            this.ToolTipUniversal.SetToolTip(this.cVSLockR, "Lock Right Editing Panel");
            this.cVSLockR.CheckedChanged += new System.EventHandler(this.cVSLock_CheckedChanged);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label5.Location = new System.Drawing.Point(3, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(133, 29);
            this.Label5.TabIndex = 39;
            this.Label5.Text = "Vertical Scroll Lock";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TableLayoutPanel4
            // 
            this.TableLayoutPanel4.AutoSize = true;
            this.TableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TableLayoutPanel4.ColumnCount = 2;
            this.TableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel4.Controls.Add(this.Label1, 0, 0);
            this.TableLayoutPanel4.Controls.Add(this.CGB, 1, 0);
            this.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayoutPanel4.Name = "TableLayoutPanel4";
            this.TableLayoutPanel4.RowCount = 1;
            this.TableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel4.Size = new System.Drawing.Size(179, 33);
            this.TableLayoutPanel4.TabIndex = 44;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label1.Location = new System.Drawing.Point(3, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(155, 33);
            this.Label1.TabIndex = 43;
            this.Label1.Text = "Number of B Columns";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CGB
            // 
            this.CGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CGB.Location = new System.Drawing.Point(164, 3);
            this.CGB.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.CGB.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CGB.Name = "CGB";
            this.CGB.Size = new System.Drawing.Size(12, 27);
            this.CGB.TabIndex = 35;
            this.CGB.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.CGB.ValueChanged += new System.EventHandler(this.CGB_ValueChanged);
            // 
            // POGridExpander
            // 
            this.POGridExpander.Appearance = System.Windows.Forms.Appearance.Button;
            this.POGridExpander.AutoSize = true;
            this.POGridExpander.Cursor = System.Windows.Forms.Cursors.Hand;
            this.POGridExpander.Dock = System.Windows.Forms.DockStyle.Top;
            this.POGridExpander.FlatAppearance.BorderSize = 0;
            this.POGridExpander.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.POGridExpander.Location = new System.Drawing.Point(0, 140);
            this.POGridExpander.Margin = new System.Windows.Forms.Padding(0);
            this.POGridExpander.Name = "POGridExpander";
            this.POGridExpander.Size = new System.Drawing.Size(179, 30);
            this.POGridExpander.TabIndex = 27;
            this.POGridExpander.TabStop = false;
            this.POGridExpander.Text = "Expand...";
            this.POGridExpander.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.POGridExpander.UseVisualStyleBackColor = false;
            this.POGridExpander.CheckedChanged += new System.EventHandler(this.Expanders_CheckChanged);
            // 
            // POGridPart1
            // 
            this.POGridPart1.AutoSize = true;
            this.POGridPart1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.POGridPart1.ColumnCount = 1;
            this.POGridPart1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.POGridPart1.Controls.Add(this.TableLayoutPanel3, 0, 1);
            this.POGridPart1.Controls.Add(this.CGDisableVertical, 0, 3);
            this.POGridPart1.Controls.Add(this.CGSnap, 0, 2);
            this.POGridPart1.Controls.Add(this.TableLayoutPanel2, 0, 0);
            this.POGridPart1.Dock = System.Windows.Forms.DockStyle.Top;
            this.POGridPart1.Location = new System.Drawing.Point(0, 0);
            this.POGridPart1.Name = "POGridPart1";
            this.POGridPart1.RowCount = 4;
            this.POGridPart1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POGridPart1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POGridPart1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POGridPart1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POGridPart1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.POGridPart1.Size = new System.Drawing.Size(179, 140);
            this.POGridPart1.TabIndex = 11;
            // 
            // TableLayoutPanel3
            // 
            this.TableLayoutPanel3.AutoSize = true;
            this.TableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TableLayoutPanel3.ColumnCount = 3;
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.TableLayoutPanel3.Controls.Add(this.PictureBox9, 0, 0);
            this.TableLayoutPanel3.Controls.Add(this.CGHeight2, 1, 0);
            this.TableLayoutPanel3.Controls.Add(this.CGHeight, 2, 0);
            this.TableLayoutPanel3.Controls.Add(this.PictureBox10, 0, 1);
            this.TableLayoutPanel3.Controls.Add(this.CGWidth2, 1, 1);
            this.TableLayoutPanel3.Controls.Add(this.CGWidth, 2, 1);
            this.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel3.Location = new System.Drawing.Point(0, 33);
            this.TableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayoutPanel3.Name = "TableLayoutPanel3";
            this.TableLayoutPanel3.RowCount = 2;
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.TableLayoutPanel3.Size = new System.Drawing.Size(179, 56);
            this.TableLayoutPanel3.TabIndex = 12;
            // 
            // PictureBox9
            // 
            this.PictureBox9.Image = global::iBMSC.Properties.Resources.lgheight;
            this.PictureBox9.Location = new System.Drawing.Point(3, 0);
            this.PictureBox9.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.PictureBox9.Name = "PictureBox9";
            this.PictureBox9.Size = new System.Drawing.Size(24, 24);
            this.PictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox9.TabIndex = 27;
            this.PictureBox9.TabStop = false;
            // 
            // CGHeight2
            // 
            this.CGHeight2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CGHeight2.LargeChange = 4;
            this.CGHeight2.Location = new System.Drawing.Point(30, 0);
            this.CGHeight2.Margin = new System.Windows.Forms.Padding(0);
            this.CGHeight2.Maximum = 20;
            this.CGHeight2.Minimum = 1;
            this.CGHeight2.Name = "CGHeight2";
            this.CGHeight2.Size = new System.Drawing.Size(104, 28);
            this.CGHeight2.TabIndex = 29;
            this.CGHeight2.TickFrequency = 2;
            this.CGHeight2.Value = 4;
            this.CGHeight2.Scroll += new System.EventHandler(this.CGHeight2_Scroll);
            // 
            // CGHeight
            // 
            this.CGHeight.DecimalPlaces = 2;
            this.CGHeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CGHeight.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.CGHeight.Location = new System.Drawing.Point(134, 0);
            this.CGHeight.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.CGHeight.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.CGHeight.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.CGHeight.Name = "CGHeight";
            this.CGHeight.Size = new System.Drawing.Size(42, 27);
            this.CGHeight.TabIndex = 23;
            this.CGHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CGHeight.ValueChanged += new System.EventHandler(this.CGHeight_ValueChanged);
            // 
            // PictureBox10
            // 
            this.PictureBox10.Image = global::iBMSC.Properties.Resources.lgwidth;
            this.PictureBox10.Location = new System.Drawing.Point(3, 28);
            this.PictureBox10.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.PictureBox10.Name = "PictureBox10";
            this.PictureBox10.Size = new System.Drawing.Size(24, 24);
            this.PictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox10.TabIndex = 28;
            this.PictureBox10.TabStop = false;
            // 
            // CGWidth2
            // 
            this.CGWidth2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CGWidth2.LargeChange = 4;
            this.CGWidth2.Location = new System.Drawing.Point(30, 28);
            this.CGWidth2.Margin = new System.Windows.Forms.Padding(0);
            this.CGWidth2.Maximum = 20;
            this.CGWidth2.Minimum = 1;
            this.CGWidth2.Name = "CGWidth2";
            this.CGWidth2.Size = new System.Drawing.Size(104, 28);
            this.CGWidth2.TabIndex = 30;
            this.CGWidth2.TickFrequency = 2;
            this.CGWidth2.Value = 4;
            this.CGWidth2.Scroll += new System.EventHandler(this.CGWidth2_Scroll);
            // 
            // CGWidth
            // 
            this.CGWidth.DecimalPlaces = 2;
            this.CGWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CGWidth.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.CGWidth.Location = new System.Drawing.Point(134, 28);
            this.CGWidth.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.CGWidth.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.CGWidth.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.CGWidth.Name = "CGWidth";
            this.CGWidth.Size = new System.Drawing.Size(42, 27);
            this.CGWidth.TabIndex = 24;
            this.CGWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CGWidth.ValueChanged += new System.EventHandler(this.CGWidth_ValueChanged);
            // 
            // CGDisableVertical
            // 
            this.CGDisableVertical.AutoSize = true;
            this.CGDisableVertical.Location = new System.Drawing.Point(3, 116);
            this.CGDisableVertical.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.CGDisableVertical.Name = "CGDisableVertical";
            this.CGDisableVertical.Size = new System.Drawing.Size(173, 24);
            this.CGDisableVertical.TabIndex = 45;
            this.CGDisableVertical.Text = "Disable vertical moves (D)";
            this.CGDisableVertical.UseVisualStyleBackColor = true;
            this.CGDisableVertical.CheckedChanged += new System.EventHandler(this.CGDisableVertical_CheckedChanged);
            // 
            // CGSnap
            // 
            this.CGSnap.AutoSize = true;
            this.CGSnap.Checked = true;
            this.CGSnap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CGSnap.Location = new System.Drawing.Point(3, 92);
            this.CGSnap.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.CGSnap.Name = "CGSnap";
            this.CGSnap.Size = new System.Drawing.Size(137, 24);
            this.CGSnap.TabIndex = 10;
            this.CGSnap.Text = "Snap to grid (G)";
            this.CGSnap.UseVisualStyleBackColor = true;
            this.CGSnap.CheckedChanged += new System.EventHandler(this.CGSnap_CheckedChanged);
            // 
            // TableLayoutPanel2
            // 
            this.TableLayoutPanel2.AutoSize = true;
            this.TableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TableLayoutPanel2.ColumnCount = 4;
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel2.Controls.Add(this.PictureBox7, 0, 0);
            this.TableLayoutPanel2.Controls.Add(this.CGDivide, 1, 0);
            this.TableLayoutPanel2.Controls.Add(this.CGSub, 2, 0);
            this.TableLayoutPanel2.Controls.Add(this.BGSlash, 3, 0);
            this.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayoutPanel2.Name = "TableLayoutPanel2";
            this.TableLayoutPanel2.RowCount = 1;
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel2.Size = new System.Drawing.Size(179, 33);
            this.TableLayoutPanel2.TabIndex = 11;
            // 
            // PictureBox7
            // 
            this.PictureBox7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PictureBox7.Image = global::iBMSC.Properties.Resources.lgpartition;
            this.PictureBox7.Location = new System.Drawing.Point(3, 4);
            this.PictureBox7.Name = "PictureBox7";
            this.PictureBox7.Size = new System.Drawing.Size(24, 24);
            this.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox7.TabIndex = 25;
            this.PictureBox7.TabStop = false;
            // 
            // CGDivide
            // 
            this.CGDivide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CGDivide.Location = new System.Drawing.Point(33, 3);
            this.CGDivide.Maximum = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            this.CGDivide.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CGDivide.Name = "CGDivide";
            this.CGDivide.Size = new System.Drawing.Size(56, 27);
            this.CGDivide.TabIndex = 36;
            this.CGDivide.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.CGDivide.ValueChanged += new System.EventHandler(this.CGDivide_ValueChanged);
            // 
            // CGSub
            // 
            this.CGSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CGSub.Location = new System.Drawing.Point(95, 3);
            this.CGSub.Maximum = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            this.CGSub.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CGSub.Name = "CGSub";
            this.CGSub.Size = new System.Drawing.Size(56, 27);
            this.CGSub.TabIndex = 37;
            this.CGSub.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.CGSub.ValueChanged += new System.EventHandler(this.CGSub_ValueChanged);
            // 
            // BGSlash
            // 
            this.BGSlash.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BGSlash.Image = global::iBMSC.Properties.Resources.Shortcut;
            this.BGSlash.Location = new System.Drawing.Point(154, 5);
            this.BGSlash.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.BGSlash.Name = "BGSlash";
            this.BGSlash.Size = new System.Drawing.Size(22, 22);
            this.BGSlash.TabIndex = 38;
            this.BGSlash.UseVisualStyleBackColor = true;
            this.BGSlash.Click += new System.EventHandler(this.BGSlash_Click);
            // 
            // POGridSwitch
            // 
            this.POGridSwitch.Appearance = System.Windows.Forms.Appearance.Button;
            this.POGridSwitch.BackColor = System.Drawing.SystemColors.Control;
            this.POGridSwitch.Checked = true;
            this.POGridSwitch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.POGridSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.POGridSwitch.Dock = System.Windows.Forms.DockStyle.Top;
            this.POGridSwitch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.POGridSwitch.Location = new System.Drawing.Point(0, 0);
            this.POGridSwitch.Name = "POGridSwitch";
            this.POGridSwitch.Size = new System.Drawing.Size(179, 20);
            this.POGridSwitch.TabIndex = 2;
            this.POGridSwitch.TabStop = false;
            this.POGridSwitch.Text = "Grid";
            this.POGridSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.POGridSwitch.UseCompatibleTextRendering = true;
            this.POGridSwitch.UseVisualStyleBackColor = false;
            this.POGridSwitch.CheckedChanged += new System.EventHandler(this.Switches_CheckedChanged);
            // 
            // POHeader
            // 
            this.POHeader.AutoSize = true;
            this.POHeader.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.POHeader.Controls.Add(this.POHeaderInner);
            this.POHeader.Controls.Add(this.POHeaderSwitch);
            this.POHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.POHeader.Location = new System.Drawing.Point(0, 0);
            this.POHeader.Name = "POHeader";
            this.POHeader.Size = new System.Drawing.Size(179, 513);
            this.POHeader.TabIndex = 1;
            // 
            // POHeaderInner
            // 
            this.POHeaderInner.AutoSize = true;
            this.POHeaderInner.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.POHeaderInner.Controls.Add(this.POHeaderPart2);
            this.POHeaderInner.Controls.Add(this.POHeaderExpander);
            this.POHeaderInner.Controls.Add(this.POHeaderPart1);
            this.POHeaderInner.Dock = System.Windows.Forms.DockStyle.Top;
            this.POHeaderInner.Location = new System.Drawing.Point(0, 20);
            this.POHeaderInner.Name = "POHeaderInner";
            this.POHeaderInner.Size = new System.Drawing.Size(179, 493);
            this.POHeaderInner.TabIndex = 2;
            // 
            // POHeaderPart2
            // 
            this.POHeaderPart2.AutoSize = true;
            this.POHeaderPart2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.POHeaderPart2.ColumnCount = 3;
            this.POHeaderPart2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.POHeaderPart2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.POHeaderPart2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.POHeaderPart2.Controls.Add(this.CHDifficulty, 1, 5);
            this.POHeaderPart2.Controls.Add(this.Label13, 2, 6);
            this.POHeaderPart2.Controls.Add(this.THExRank, 1, 6);
            this.POHeaderPart2.Controls.Add(this.Label25, 2, 7);
            this.POHeaderPart2.Controls.Add(this.CHLnObj, 1, 9);
            this.POHeaderPart2.Controls.Add(this.Label23, 0, 6);
            this.POHeaderPart2.Controls.Add(this.Label21, 0, 5);
            this.POHeaderPart2.Controls.Add(this.THComment, 1, 8);
            this.POHeaderPart2.Controls.Add(this.Label24, 0, 9);
            this.POHeaderPart2.Controls.Add(this.Label15, 0, 0);
            this.POHeaderPart2.Controls.Add(this.THTotal, 1, 7);
            this.POHeaderPart2.Controls.Add(this.Label20, 0, 7);
            this.POHeaderPart2.Controls.Add(this.BHStageFile, 2, 2);
            this.POHeaderPart2.Controls.Add(this.BHBanner, 2, 3);
            this.POHeaderPart2.Controls.Add(this.Label19, 0, 8);
            this.POHeaderPart2.Controls.Add(this.BHBackBMP, 2, 4);
            this.POHeaderPart2.Controls.Add(this.Label17, 0, 1);
            this.POHeaderPart2.Controls.Add(this.Label16, 0, 2);
            this.POHeaderPart2.Controls.Add(this.Label12, 0, 3);
            this.POHeaderPart2.Controls.Add(this.THBackBMP, 1, 4);
            this.POHeaderPart2.Controls.Add(this.Label11, 0, 4);
            this.POHeaderPart2.Controls.Add(this.THBanner, 1, 3);
            this.POHeaderPart2.Controls.Add(this.THStageFile, 1, 2);
            this.POHeaderPart2.Controls.Add(this.THSubTitle, 1, 0);
            this.POHeaderPart2.Controls.Add(this.THSubArtist, 1, 1);
            this.POHeaderPart2.Dock = System.Windows.Forms.DockStyle.Top;
            this.POHeaderPart2.Location = new System.Drawing.Point(0, 221);
            this.POHeaderPart2.Name = "POHeaderPart2";
            this.POHeaderPart2.RowCount = 10;
            this.POHeaderPart2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POHeaderPart2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POHeaderPart2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POHeaderPart2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POHeaderPart2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POHeaderPart2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POHeaderPart2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POHeaderPart2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POHeaderPart2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POHeaderPart2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POHeaderPart2.Size = new System.Drawing.Size(179, 272);
            this.POHeaderPart2.TabIndex = 27;
            // 
            // CHDifficulty
            // 
            this.POHeaderPart2.SetColumnSpan(this.CHDifficulty, 2);
            this.CHDifficulty.Dock = System.Windows.Forms.DockStyle.Top;
            this.CHDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CHDifficulty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CHDifficulty.Items.AddRange(new object[] {
            "None",
            "1 - EZ / Beginner",
            "2 - NM / Normal",
            "3 - HD / Hyper",
            "4 - MX / Another",
            "5 - SC / Insane"});
            this.CHDifficulty.Location = new System.Drawing.Point(80, 135);
            this.CHDifficulty.Margin = new System.Windows.Forms.Padding(0);
            this.CHDifficulty.Name = "CHDifficulty";
            this.CHDifficulty.Size = new System.Drawing.Size(99, 28);
            this.CHDifficulty.TabIndex = 63;
            this.CHDifficulty.SelectedIndexChanged += new System.EventHandler(this.THGenre_TextChanged);
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label13.Location = new System.Drawing.Point(148, 163);
            this.Label13.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(31, 27);
            this.Label13.TabIndex = 63;
            this.Label13.Text = "(%)";
            this.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // THExRank
            // 
            this.THExRank.Dock = System.Windows.Forms.DockStyle.Fill;
            this.THExRank.Location = new System.Drawing.Point(80, 163);
            this.THExRank.Margin = new System.Windows.Forms.Padding(0);
            this.THExRank.Name = "THExRank";
            this.THExRank.Size = new System.Drawing.Size(65, 27);
            this.THExRank.TabIndex = 27;
            this.THExRank.TextChanged += new System.EventHandler(this.THGenre_TextChanged);
            // 
            // Label25
            // 
            this.Label25.AutoSize = true;
            this.Label25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label25.Location = new System.Drawing.Point(148, 190);
            this.Label25.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(31, 27);
            this.Label25.TabIndex = 23;
            this.Label25.Text = "(%)";
            this.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CHLnObj
            // 
            this.POHeaderPart2.SetColumnSpan(this.CHLnObj, 2);
            this.CHLnObj.Dock = System.Windows.Forms.DockStyle.Top;
            this.CHLnObj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CHLnObj.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CHLnObj.Items.AddRange(new object[] {
            "None (#LnType 1)",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "0A",
            "0B",
            "0C",
            "0D",
            "0E",
            "0F",
            "0G",
            "0H",
            "0I",
            "0J",
            "0K",
            "0L",
            "0M",
            "0N",
            "0O",
            "0P",
            "0Q",
            "0R",
            "0S",
            "0T",
            "0U",
            "0V",
            "0W",
            "0X",
            "0Y",
            "0Z",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "1A",
            "1B",
            "1C",
            "1D",
            "1E",
            "1F",
            "1G",
            "1H",
            "1I",
            "1J",
            "1K",
            "1L",
            "1M",
            "1N",
            "1O",
            "1P",
            "1Q",
            "1R",
            "1S",
            "1T",
            "1U",
            "1V",
            "1W",
            "1X",
            "1Y",
            "1Z",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "2A",
            "2B",
            "2C",
            "2D",
            "2E",
            "2F",
            "2G",
            "2H",
            "2I",
            "2J",
            "2K",
            "2L",
            "2M",
            "2N",
            "2O",
            "2P",
            "2Q",
            "2R",
            "2S",
            "2T",
            "2U",
            "2V",
            "2W",
            "2X",
            "2Y",
            "2Z",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "3A",
            "3B",
            "3C",
            "3D",
            "3E",
            "3F",
            "3G",
            "3H",
            "3I",
            "3J",
            "3K",
            "3L",
            "3M",
            "3N",
            "3O",
            "3P",
            "3Q",
            "3R",
            "3S",
            "3T",
            "3U",
            "3V",
            "3W",
            "3X",
            "3Y",
            "3Z",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "4A",
            "4B",
            "4C",
            "4D",
            "4E",
            "4F",
            "4G",
            "4H",
            "4I",
            "4J",
            "4K",
            "4L",
            "4M",
            "4N",
            "4O",
            "4P",
            "4Q",
            "4R",
            "4S",
            "4T",
            "4U",
            "4V",
            "4W",
            "4X",
            "4Y",
            "4Z",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "5A",
            "5B",
            "5C",
            "5D",
            "5E",
            "5F",
            "5G",
            "5H",
            "5I",
            "5J",
            "5K",
            "5L",
            "5M",
            "5N",
            "5O",
            "5P",
            "5Q",
            "5R",
            "5S",
            "5T",
            "5U",
            "5V",
            "5W",
            "5X",
            "5Y",
            "5Z",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "6A",
            "6B",
            "6C",
            "6D",
            "6E",
            "6F",
            "6G",
            "6H",
            "6I",
            "6J",
            "6K",
            "6L",
            "6M",
            "6N",
            "6O",
            "6P",
            "6Q",
            "6R",
            "6S",
            "6T",
            "6U",
            "6V",
            "6W",
            "6X",
            "6Y",
            "6Z",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "7A",
            "7B",
            "7C",
            "7D",
            "7E",
            "7F",
            "7G",
            "7H",
            "7I",
            "7J",
            "7K",
            "7L",
            "7M",
            "7N",
            "7O",
            "7P",
            "7Q",
            "7R",
            "7S",
            "7T",
            "7U",
            "7V",
            "7W",
            "7X",
            "7Y",
            "7Z",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "8A",
            "8B",
            "8C",
            "8D",
            "8E",
            "8F",
            "8G",
            "8H",
            "8I",
            "8J",
            "8K",
            "8L",
            "8M",
            "8N",
            "8O",
            "8P",
            "8Q",
            "8R",
            "8S",
            "8T",
            "8U",
            "8V",
            "8W",
            "8X",
            "8Y",
            "8Z",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99",
            "9A",
            "9B",
            "9C",
            "9D",
            "9E",
            "9F",
            "9G",
            "9H",
            "9I",
            "9J",
            "9K",
            "9L",
            "9M",
            "9N",
            "9O",
            "9P",
            "9Q",
            "9R",
            "9S",
            "9T",
            "9U",
            "9V",
            "9W",
            "9X",
            "9Y",
            "9Z",
            "A0",
            "A1",
            "A2",
            "A3",
            "A4",
            "A5",
            "A6",
            "A7",
            "A8",
            "A9",
            "AA",
            "AB",
            "AC",
            "AD",
            "AE",
            "AF",
            "AG",
            "AH",
            "AI",
            "AJ",
            "AK",
            "AL",
            "AM",
            "AN",
            "AO",
            "AP",
            "AQ",
            "AR",
            "AS",
            "AT",
            "AU",
            "AV",
            "AW",
            "AX",
            "AY",
            "AZ",
            "B0",
            "B1",
            "B2",
            "B3",
            "B4",
            "B5",
            "B6",
            "B7",
            "B8",
            "B9",
            "BA",
            "BB",
            "BC",
            "BD",
            "BE",
            "BF",
            "BG",
            "BH",
            "BI",
            "BJ",
            "BK",
            "BL",
            "BM",
            "BN",
            "BO",
            "BP",
            "BQ",
            "BR",
            "BS",
            "BT",
            "BU",
            "BV",
            "BW",
            "BX",
            "BY",
            "BZ",
            "C0",
            "C1",
            "C2",
            "C3",
            "C4",
            "C5",
            "C6",
            "C7",
            "C8",
            "C9",
            "CA",
            "CB",
            "CC",
            "CD",
            "CE",
            "CF",
            "CG",
            "CH",
            "CI",
            "CJ",
            "CK",
            "CL",
            "CM",
            "CN",
            "CO",
            "CP",
            "CQ",
            "CR",
            "CS",
            "CT",
            "CU",
            "CV",
            "CW",
            "CX",
            "CY",
            "CZ",
            "D0",
            "D1",
            "D2",
            "D3",
            "D4",
            "D5",
            "D6",
            "D7",
            "D8",
            "D9",
            "DA",
            "DB",
            "DC",
            "DD",
            "DE",
            "DF",
            "DG",
            "DH",
            "DI",
            "DJ",
            "DK",
            "DL",
            "DM",
            "DN",
            "DO",
            "DP",
            "DQ",
            "DR",
            "DS",
            "DT",
            "DU",
            "DV",
            "DW",
            "DX",
            "DY",
            "DZ",
            "E0",
            "E1",
            "E2",
            "E3",
            "E4",
            "E5",
            "E6",
            "E7",
            "E8",
            "E9",
            "EA",
            "EB",
            "EC",
            "ED",
            "EE",
            "EF",
            "EG",
            "EH",
            "EI",
            "EJ",
            "EK",
            "EL",
            "EM",
            "EN",
            "EO",
            "EP",
            "EQ",
            "ER",
            "ES",
            "ET",
            "EU",
            "EV",
            "EW",
            "EX",
            "EY",
            "EZ",
            "F0",
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "FA",
            "FB",
            "FC",
            "FD",
            "FE",
            "FF",
            "FG",
            "FH",
            "FI",
            "FJ",
            "FK",
            "FL",
            "FM",
            "FN",
            "FO",
            "FP",
            "FQ",
            "FR",
            "FS",
            "FT",
            "FU",
            "FV",
            "FW",
            "FX",
            "FY",
            "FZ",
            "G0",
            "G1",
            "G2",
            "G3",
            "G4",
            "G5",
            "G6",
            "G7",
            "G8",
            "G9",
            "GA",
            "GB",
            "GC",
            "GD",
            "GE",
            "GF",
            "GG",
            "GH",
            "GI",
            "GJ",
            "GK",
            "GL",
            "GM",
            "GN",
            "GO",
            "GP",
            "GQ",
            "GR",
            "GS",
            "GT",
            "GU",
            "GV",
            "GW",
            "GX",
            "GY",
            "GZ",
            "H0",
            "H1",
            "H2",
            "H3",
            "H4",
            "H5",
            "H6",
            "H7",
            "H8",
            "H9",
            "HA",
            "HB",
            "HC",
            "HD",
            "HE",
            "HF",
            "HG",
            "HH",
            "HI",
            "HJ",
            "HK",
            "HL",
            "HM",
            "HN",
            "HO",
            "HP",
            "HQ",
            "HR",
            "HS",
            "HT",
            "HU",
            "HV",
            "HW",
            "HX",
            "HY",
            "HZ",
            "I0",
            "I1",
            "I2",
            "I3",
            "I4",
            "I5",
            "I6",
            "I7",
            "I8",
            "I9",
            "IA",
            "IB",
            "IC",
            "ID",
            "IE",
            "IF",
            "IG",
            "IH",
            "II",
            "IJ",
            "IK",
            "IL",
            "IM",
            "IN",
            "IO",
            "IP",
            "IQ",
            "IR",
            "IS",
            "IT",
            "IU",
            "IV",
            "IW",
            "IX",
            "IY",
            "IZ",
            "J0",
            "J1",
            "J2",
            "J3",
            "J4",
            "J5",
            "J6",
            "J7",
            "J8",
            "J9",
            "JA",
            "JB",
            "JC",
            "JD",
            "JE",
            "JF",
            "JG",
            "JH",
            "JI",
            "JJ",
            "JK",
            "JL",
            "JM",
            "JN",
            "JO",
            "JP",
            "JQ",
            "JR",
            "JS",
            "JT",
            "JU",
            "JV",
            "JW",
            "JX",
            "JY",
            "JZ",
            "K0",
            "K1",
            "K2",
            "K3",
            "K4",
            "K5",
            "K6",
            "K7",
            "K8",
            "K9",
            "KA",
            "KB",
            "KC",
            "KD",
            "KE",
            "KF",
            "KG",
            "KH",
            "KI",
            "KJ",
            "KK",
            "KL",
            "KM",
            "KN",
            "KO",
            "KP",
            "KQ",
            "KR",
            "KS",
            "KT",
            "KU",
            "KV",
            "KW",
            "KX",
            "KY",
            "KZ",
            "L0",
            "L1",
            "L2",
            "L3",
            "L4",
            "L5",
            "L6",
            "L7",
            "L8",
            "L9",
            "LA",
            "LB",
            "LC",
            "LD",
            "LE",
            "LF",
            "LG",
            "LH",
            "LI",
            "LJ",
            "LK",
            "LL",
            "LM",
            "LN",
            "LO",
            "LP",
            "LQ",
            "LR",
            "LS",
            "LT",
            "LU",
            "LV",
            "LW",
            "LX",
            "LY",
            "LZ",
            "M0",
            "M1",
            "M2",
            "M3",
            "M4",
            "M5",
            "M6",
            "M7",
            "M8",
            "M9",
            "MA",
            "MB",
            "MC",
            "MD",
            "ME",
            "MF",
            "MG",
            "MH",
            "MI",
            "MJ",
            "MK",
            "ML",
            "MM",
            "MN",
            "MO",
            "MP",
            "MQ",
            "MR",
            "MS",
            "MT",
            "MU",
            "MV",
            "MW",
            "MX",
            "MY",
            "MZ",
            "N0",
            "N1",
            "N2",
            "N3",
            "N4",
            "N5",
            "N6",
            "N7",
            "N8",
            "N9",
            "NA",
            "NB",
            "NC",
            "ND",
            "NE",
            "NF",
            "NG",
            "NH",
            "NI",
            "NJ",
            "NK",
            "NL",
            "NM",
            "NN",
            "NO",
            "NP",
            "NQ",
            "NR",
            "NS",
            "NT",
            "NU",
            "NV",
            "NW",
            "NX",
            "NY",
            "NZ",
            "O0",
            "O1",
            "O2",
            "O3",
            "O4",
            "O5",
            "O6",
            "O7",
            "O8",
            "O9",
            "OA",
            "OB",
            "OC",
            "OD",
            "OE",
            "OF",
            "OG",
            "OH",
            "OI",
            "OJ",
            "OK",
            "OL",
            "OM",
            "ON",
            "OO",
            "OP",
            "OQ",
            "OR",
            "OS",
            "OT",
            "OU",
            "OV",
            "OW",
            "OX",
            "OY",
            "OZ",
            "P0",
            "P1",
            "P2",
            "P3",
            "P4",
            "P5",
            "P6",
            "P7",
            "P8",
            "P9",
            "PA",
            "PB",
            "PC",
            "PD",
            "PE",
            "PF",
            "PG",
            "PH",
            "PI",
            "PJ",
            "PK",
            "PL",
            "PM",
            "PN",
            "PO",
            "PP",
            "PQ",
            "PR",
            "PS",
            "PT",
            "PU",
            "PV",
            "PW",
            "PX",
            "PY",
            "PZ",
            "Q0",
            "Q1",
            "Q2",
            "Q3",
            "Q4",
            "Q5",
            "Q6",
            "Q7",
            "Q8",
            "Q9",
            "QA",
            "QB",
            "QC",
            "QD",
            "QE",
            "QF",
            "QG",
            "QH",
            "QI",
            "QJ",
            "QK",
            "QL",
            "QM",
            "QN",
            "QO",
            "QP",
            "QQ",
            "QR",
            "QS",
            "QT",
            "QU",
            "QV",
            "QW",
            "QX",
            "QY",
            "QZ",
            "R0",
            "R1",
            "R2",
            "R3",
            "R4",
            "R5",
            "R6",
            "R7",
            "R8",
            "R9",
            "RA",
            "RB",
            "RC",
            "RD",
            "RE",
            "RF",
            "RG",
            "RH",
            "RI",
            "RJ",
            "RK",
            "RL",
            "RM",
            "RN",
            "RO",
            "RP",
            "RQ",
            "RR",
            "RS",
            "RT",
            "RU",
            "RV",
            "RW",
            "RX",
            "RY",
            "RZ",
            "S0",
            "S1",
            "S2",
            "S3",
            "S4",
            "S5",
            "S6",
            "S7",
            "S8",
            "S9",
            "SA",
            "SB",
            "SC",
            "SD",
            "SE",
            "SF",
            "SG",
            "SH",
            "SI",
            "SJ",
            "SK",
            "SL",
            "SM",
            "SN",
            "SO",
            "SP",
            "SQ",
            "SR",
            "SS",
            "ST",
            "SU",
            "SV",
            "SW",
            "SX",
            "SY",
            "SZ",
            "T0",
            "T1",
            "T2",
            "T3",
            "T4",
            "T5",
            "T6",
            "T7",
            "T8",
            "T9",
            "TA",
            "TB",
            "TC",
            "TD",
            "TE",
            "TF",
            "TG",
            "TH",
            "TI",
            "TJ",
            "TK",
            "TL",
            "TM",
            "TN",
            "TO",
            "TP",
            "TQ",
            "TR",
            "TS",
            "TT",
            "TU",
            "TV",
            "TW",
            "TX",
            "TY",
            "TZ",
            "U0",
            "U1",
            "U2",
            "U3",
            "U4",
            "U5",
            "U6",
            "U7",
            "U8",
            "U9",
            "UA",
            "UB",
            "UC",
            "UD",
            "UE",
            "UF",
            "UG",
            "UH",
            "UI",
            "UJ",
            "UK",
            "UL",
            "UM",
            "UN",
            "UO",
            "UP",
            "UQ",
            "UR",
            "US",
            "UT",
            "UU",
            "UV",
            "UW",
            "UX",
            "UY",
            "UZ",
            "V0",
            "V1",
            "V2",
            "V3",
            "V4",
            "V5",
            "V6",
            "V7",
            "V8",
            "V9",
            "VA",
            "VB",
            "VC",
            "VD",
            "VE",
            "VF",
            "VG",
            "VH",
            "VI",
            "VJ",
            "VK",
            "VL",
            "VM",
            "VN",
            "VO",
            "VP",
            "VQ",
            "VR",
            "VS",
            "VT",
            "VU",
            "VV",
            "VW",
            "VX",
            "VY",
            "VZ",
            "W0",
            "W1",
            "W2",
            "W3",
            "W4",
            "W5",
            "W6",
            "W7",
            "W8",
            "W9",
            "WA",
            "WB",
            "WC",
            "WD",
            "WE",
            "WF",
            "WG",
            "WH",
            "WI",
            "WJ",
            "WK",
            "WL",
            "WM",
            "WN",
            "WO",
            "WP",
            "WQ",
            "WR",
            "WS",
            "WT",
            "WU",
            "WV",
            "WW",
            "WX",
            "WY",
            "WZ",
            "X0",
            "X1",
            "X2",
            "X3",
            "X4",
            "X5",
            "X6",
            "X7",
            "X8",
            "X9",
            "XA",
            "XB",
            "XC",
            "XD",
            "XE",
            "XF",
            "XG",
            "XH",
            "XI",
            "XJ",
            "XK",
            "XL",
            "XM",
            "XN",
            "XO",
            "XP",
            "XQ",
            "XR",
            "XS",
            "XT",
            "XU",
            "XV",
            "XW",
            "XX",
            "XY",
            "XZ",
            "Y0",
            "Y1",
            "Y2",
            "Y3",
            "Y4",
            "Y5",
            "Y6",
            "Y7",
            "Y8",
            "Y9",
            "YA",
            "YB",
            "YC",
            "YD",
            "YE",
            "YF",
            "YG",
            "YH",
            "YI",
            "YJ",
            "YK",
            "YL",
            "YM",
            "YN",
            "YO",
            "YP",
            "YQ",
            "YR",
            "YS",
            "YT",
            "YU",
            "YV",
            "YW",
            "YX",
            "YY",
            "YZ",
            "Z0",
            "Z1",
            "Z2",
            "Z3",
            "Z4",
            "Z5",
            "Z6",
            "Z7",
            "Z8",
            "Z9",
            "ZA",
            "ZB",
            "ZC",
            "ZD",
            "ZE",
            "ZF",
            "ZG",
            "ZH",
            "ZI",
            "ZJ",
            "ZK",
            "ZL",
            "ZM",
            "ZN",
            "ZO",
            "ZP",
            "ZQ",
            "ZR",
            "ZS",
            "ZT",
            "ZU",
            "ZV",
            "ZW",
            "ZX",
            "ZY",
            "ZZ"});
            this.CHLnObj.Location = new System.Drawing.Point(80, 244);
            this.CHLnObj.Margin = new System.Windows.Forms.Padding(0);
            this.CHLnObj.Name = "CHLnObj";
            this.CHLnObj.Size = new System.Drawing.Size(99, 28);
            this.CHLnObj.TabIndex = 28;
            this.CHLnObj.SelectedIndexChanged += new System.EventHandler(this.CHLnObj_SelectedIndexChanged);
            // 
            // Label23
            // 
            this.Label23.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label23.AutoSize = true;
            this.Label23.Location = new System.Drawing.Point(21, 166);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(56, 20);
            this.Label23.TabIndex = 26;
            this.Label23.Text = "ExRank";
            this.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label21
            // 
            this.Label21.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label21.AutoSize = true;
            this.Label21.Location = new System.Drawing.Point(8, 139);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(69, 20);
            this.Label21.TabIndex = 25;
            this.Label21.Text = "Difficulty";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // THComment
            // 
            this.POHeaderPart2.SetColumnSpan(this.THComment, 2);
            this.THComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.THComment.Location = new System.Drawing.Point(80, 217);
            this.THComment.Margin = new System.Windows.Forms.Padding(0);
            this.THComment.Name = "THComment";
            this.THComment.Size = new System.Drawing.Size(99, 27);
            this.THComment.TabIndex = 19;
            this.THComment.TextChanged += new System.EventHandler(this.THGenre_TextChanged);
            // 
            // Label24
            // 
            this.Label24.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label24.AutoSize = true;
            this.Label24.Location = new System.Drawing.Point(29, 248);
            this.Label24.Name = "Label24";
            this.Label24.Size = new System.Drawing.Size(48, 20);
            this.Label24.TabIndex = 27;
            this.Label24.Text = "LnObj";
            this.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label15
            // 
            this.Label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(14, 3);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(63, 20);
            this.Label15.TabIndex = 6;
            this.Label15.Text = "SubTitle";
            this.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // THTotal
            // 
            this.THTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.THTotal.Location = new System.Drawing.Point(80, 190);
            this.THTotal.Margin = new System.Windows.Forms.Padding(0);
            this.THTotal.Name = "THTotal";
            this.THTotal.Size = new System.Drawing.Size(65, 27);
            this.THTotal.TabIndex = 5;
            this.THTotal.TextChanged += new System.EventHandler(this.THGenre_TextChanged);
            // 
            // Label20
            // 
            this.Label20.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label20.AutoSize = true;
            this.Label20.Location = new System.Drawing.Point(35, 193);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(42, 20);
            this.Label20.TabIndex = 5;
            this.Label20.Text = "Total";
            this.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BHStageFile
            // 
            this.BHStageFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BHStageFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BHStageFile.Location = new System.Drawing.Point(148, 54);
            this.BHStageFile.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BHStageFile.Name = "BHStageFile";
            this.BHStageFile.Size = new System.Drawing.Size(31, 27);
            this.BHStageFile.TabIndex = 20;
            this.BHStageFile.Text = "...";
            this.BHStageFile.UseVisualStyleBackColor = true;
            this.BHStageFile.Click += new System.EventHandler(this.BHStageFile_Click);
            // 
            // BHBanner
            // 
            this.BHBanner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BHBanner.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BHBanner.Location = new System.Drawing.Point(148, 81);
            this.BHBanner.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BHBanner.Name = "BHBanner";
            this.BHBanner.Size = new System.Drawing.Size(31, 27);
            this.BHBanner.TabIndex = 21;
            this.BHBanner.Text = "...";
            this.BHBanner.UseVisualStyleBackColor = true;
            this.BHBanner.Click += new System.EventHandler(this.BHStageFile_Click);
            // 
            // Label19
            // 
            this.Label19.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label19.AutoSize = true;
            this.Label19.Location = new System.Drawing.Point(3, 220);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(74, 20);
            this.Label19.TabIndex = 13;
            this.Label19.Text = "Comment";
            this.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BHBackBMP
            // 
            this.BHBackBMP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BHBackBMP.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BHBackBMP.Location = new System.Drawing.Point(148, 108);
            this.BHBackBMP.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BHBackBMP.Name = "BHBackBMP";
            this.BHBackBMP.Size = new System.Drawing.Size(31, 27);
            this.BHBackBMP.TabIndex = 22;
            this.BHBackBMP.Text = "...";
            this.BHBackBMP.UseVisualStyleBackColor = true;
            this.BHBackBMP.Click += new System.EventHandler(this.BHStageFile_Click);
            // 
            // Label17
            // 
            this.Label17.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label17.AutoSize = true;
            this.Label17.Location = new System.Drawing.Point(8, 30);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(69, 20);
            this.Label17.TabIndex = 7;
            this.Label17.Text = "SubArtist";
            this.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label16
            // 
            this.Label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label16.AutoSize = true;
            this.Label16.Location = new System.Drawing.Point(3, 57);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(74, 20);
            this.Label16.TabIndex = 9;
            this.Label16.Text = "Stage File";
            this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label12
            // 
            this.Label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(22, 84);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(55, 20);
            this.Label12.TabIndex = 13;
            this.Label12.Text = "Banner";
            this.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // THBackBMP
            // 
            this.THBackBMP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.THBackBMP.Location = new System.Drawing.Point(80, 108);
            this.THBackBMP.Margin = new System.Windows.Forms.Padding(0);
            this.THBackBMP.Name = "THBackBMP";
            this.THBackBMP.Size = new System.Drawing.Size(65, 27);
            this.THBackBMP.TabIndex = 17;
            this.THBackBMP.TextChanged += new System.EventHandler(this.THGenre_TextChanged);
            // 
            // Label11
            // 
            this.Label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(3, 111);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(74, 20);
            this.Label11.TabIndex = 16;
            this.Label11.Text = "Back BMP";
            this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // THBanner
            // 
            this.THBanner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.THBanner.Location = new System.Drawing.Point(80, 81);
            this.THBanner.Margin = new System.Windows.Forms.Padding(0);
            this.THBanner.Name = "THBanner";
            this.THBanner.Size = new System.Drawing.Size(65, 27);
            this.THBanner.TabIndex = 19;
            this.THBanner.TextChanged += new System.EventHandler(this.THGenre_TextChanged);
            // 
            // THStageFile
            // 
            this.THStageFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.THStageFile.Location = new System.Drawing.Point(80, 54);
            this.THStageFile.Margin = new System.Windows.Forms.Padding(0);
            this.THStageFile.Name = "THStageFile";
            this.THStageFile.Size = new System.Drawing.Size(65, 27);
            this.THStageFile.TabIndex = 18;
            this.THStageFile.TextChanged += new System.EventHandler(this.THGenre_TextChanged);
            // 
            // THSubTitle
            // 
            this.POHeaderPart2.SetColumnSpan(this.THSubTitle, 2);
            this.THSubTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.THSubTitle.Location = new System.Drawing.Point(80, 0);
            this.THSubTitle.Margin = new System.Windows.Forms.Padding(0);
            this.THSubTitle.Name = "THSubTitle";
            this.THSubTitle.Size = new System.Drawing.Size(99, 27);
            this.THSubTitle.TabIndex = 6;
            this.THSubTitle.TextChanged += new System.EventHandler(this.THGenre_TextChanged);
            // 
            // THSubArtist
            // 
            this.POHeaderPart2.SetColumnSpan(this.THSubArtist, 2);
            this.THSubArtist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.THSubArtist.Location = new System.Drawing.Point(80, 27);
            this.THSubArtist.Margin = new System.Windows.Forms.Padding(0);
            this.THSubArtist.Name = "THSubArtist";
            this.THSubArtist.Size = new System.Drawing.Size(99, 27);
            this.THSubArtist.TabIndex = 7;
            this.THSubArtist.TextChanged += new System.EventHandler(this.THGenre_TextChanged);
            // 
            // POHeaderExpander
            // 
            this.POHeaderExpander.Appearance = System.Windows.Forms.Appearance.Button;
            this.POHeaderExpander.AutoSize = true;
            this.POHeaderExpander.Cursor = System.Windows.Forms.Cursors.Hand;
            this.POHeaderExpander.Dock = System.Windows.Forms.DockStyle.Top;
            this.POHeaderExpander.FlatAppearance.BorderSize = 0;
            this.POHeaderExpander.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.POHeaderExpander.Location = new System.Drawing.Point(0, 191);
            this.POHeaderExpander.Margin = new System.Windows.Forms.Padding(0);
            this.POHeaderExpander.Name = "POHeaderExpander";
            this.POHeaderExpander.Size = new System.Drawing.Size(179, 30);
            this.POHeaderExpander.TabIndex = 26;
            this.POHeaderExpander.TabStop = false;
            this.POHeaderExpander.Text = "Expand...";
            this.POHeaderExpander.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.POHeaderExpander.UseVisualStyleBackColor = false;
            this.POHeaderExpander.CheckedChanged += new System.EventHandler(this.Expanders_CheckChanged);
            // 
            // POHeaderPart1
            // 
            this.POHeaderPart1.AutoSize = true;
            this.POHeaderPart1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.POHeaderPart1.ColumnCount = 2;
            this.POHeaderPart1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.POHeaderPart1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.POHeaderPart1.Controls.Add(this.Label3, 0, 0);
            this.POHeaderPart1.Controls.Add(this.THPlayLevel, 1, 6);
            this.POHeaderPart1.Controls.Add(this.CHRank, 1, 5);
            this.POHeaderPart1.Controls.Add(this.Label10, 0, 5);
            this.POHeaderPart1.Controls.Add(this.CHPlayer, 1, 4);
            this.POHeaderPart1.Controls.Add(this.Label4, 0, 1);
            this.POHeaderPart1.Controls.Add(this.THGenre, 1, 2);
            this.POHeaderPart1.Controls.Add(this.THBPM, 1, 3);
            this.POHeaderPart1.Controls.Add(this.Label2, 0, 2);
            this.POHeaderPart1.Controls.Add(this.THArtist, 1, 1);
            this.POHeaderPart1.Controls.Add(this.THTitle, 1, 0);
            this.POHeaderPart1.Controls.Add(this.Label9, 0, 3);
            this.POHeaderPart1.Controls.Add(this.Label8, 0, 4);
            this.POHeaderPart1.Controls.Add(this.Label6, 0, 6);
            this.POHeaderPart1.Dock = System.Windows.Forms.DockStyle.Top;
            this.POHeaderPart1.Location = new System.Drawing.Point(0, 0);
            this.POHeaderPart1.Name = "POHeaderPart1";
            this.POHeaderPart1.RowCount = 7;
            this.POHeaderPart1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POHeaderPart1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POHeaderPart1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POHeaderPart1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POHeaderPart1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POHeaderPart1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POHeaderPart1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.POHeaderPart1.Size = new System.Drawing.Size(179, 191);
            this.POHeaderPart1.TabIndex = 25;
            // 
            // Label3
            // 
            this.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(39, 3);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(38, 20);
            this.Label3.TabIndex = 6;
            this.Label3.Text = "Title";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // THPlayLevel
            // 
            this.THPlayLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.THPlayLevel.Location = new System.Drawing.Point(80, 164);
            this.THPlayLevel.Margin = new System.Windows.Forms.Padding(0);
            this.THPlayLevel.Name = "THPlayLevel";
            this.THPlayLevel.Size = new System.Drawing.Size(99, 27);
            this.THPlayLevel.TabIndex = 8;
            this.THPlayLevel.TextChanged += new System.EventHandler(this.THGenre_TextChanged);
            // 
            // CHRank
            // 
            this.CHRank.Dock = System.Windows.Forms.DockStyle.Top;
            this.CHRank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CHRank.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CHRank.Items.AddRange(new object[] {
            "0 - Very Hard",
            "1 - Hard",
            "2 - Normal",
            "3 - Easy",
            "4 - Very Easy"});
            this.CHRank.Location = new System.Drawing.Point(80, 136);
            this.CHRank.Margin = new System.Windows.Forms.Padding(0);
            this.CHRank.Name = "CHRank";
            this.CHRank.Size = new System.Drawing.Size(99, 28);
            this.CHRank.TabIndex = 15;
            this.CHRank.SelectedIndexChanged += new System.EventHandler(this.THGenre_TextChanged);
            // 
            // Label10
            // 
            this.Label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(36, 140);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(41, 20);
            this.Label10.TabIndex = 16;
            this.Label10.Text = "Rank";
            this.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CHPlayer
            // 
            this.CHPlayer.Dock = System.Windows.Forms.DockStyle.Top;
            this.CHPlayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CHPlayer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CHPlayer.Items.AddRange(new object[] {
            "1 - Single Play",
            "2 - Couple Play",
            "3 - Double Play"});
            this.CHPlayer.Location = new System.Drawing.Point(80, 108);
            this.CHPlayer.Margin = new System.Windows.Forms.Padding(0);
            this.CHPlayer.Name = "CHPlayer";
            this.CHPlayer.Size = new System.Drawing.Size(99, 28);
            this.CHPlayer.TabIndex = 14;
            this.CHPlayer.SelectedIndexChanged += new System.EventHandler(this.CHPlayer_SelectedIndexChanged);
            // 
            // Label4
            // 
            this.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(33, 30);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(44, 20);
            this.Label4.TabIndex = 7;
            this.Label4.Text = "Artist";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // THGenre
            // 
            this.THGenre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.THGenre.Location = new System.Drawing.Point(80, 54);
            this.THGenre.Margin = new System.Windows.Forms.Padding(0);
            this.THGenre.Name = "THGenre";
            this.THGenre.Size = new System.Drawing.Size(99, 27);
            this.THGenre.TabIndex = 5;
            this.THGenre.TextChanged += new System.EventHandler(this.THGenre_TextChanged);
            // 
            // THBPM
            // 
            this.THBPM.DecimalPlaces = 4;
            this.THBPM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.THBPM.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.THBPM.Location = new System.Drawing.Point(80, 81);
            this.THBPM.Margin = new System.Windows.Forms.Padding(0);
            this.THBPM.Maximum = new decimal(new int[] {
            655359999,
            0,
            0,
            262144});
            this.THBPM.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.THBPM.Name = "THBPM";
            this.THBPM.Size = new System.Drawing.Size(99, 27);
            this.THBPM.TabIndex = 10;
            this.THBPM.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.THBPM.ValueChanged += new System.EventHandler(this.THBPM_ValueChanged);
            // 
            // Label2
            // 
            this.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(29, 57);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(48, 20);
            this.Label2.TabIndex = 5;
            this.Label2.Text = "Genre";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // THArtist
            // 
            this.THArtist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.THArtist.Location = new System.Drawing.Point(80, 27);
            this.THArtist.Margin = new System.Windows.Forms.Padding(0);
            this.THArtist.Name = "THArtist";
            this.THArtist.Size = new System.Drawing.Size(99, 27);
            this.THArtist.TabIndex = 7;
            this.THArtist.TextChanged += new System.EventHandler(this.THGenre_TextChanged);
            // 
            // THTitle
            // 
            this.THTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.THTitle.Location = new System.Drawing.Point(80, 0);
            this.THTitle.Margin = new System.Windows.Forms.Padding(0);
            this.THTitle.Name = "THTitle";
            this.THTitle.Size = new System.Drawing.Size(99, 27);
            this.THTitle.TabIndex = 6;
            this.THTitle.TextChanged += new System.EventHandler(this.THGenre_TextChanged);
            // 
            // Label9
            // 
            this.Label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(38, 84);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(39, 20);
            this.Label9.TabIndex = 9;
            this.Label9.Text = "BPM";
            this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label8
            // 
            this.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(28, 112);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(49, 20);
            this.Label8.TabIndex = 13;
            this.Label8.Text = "Player";
            this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label6
            // 
            this.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(3, 167);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(74, 20);
            this.Label6.TabIndex = 8;
            this.Label6.Text = "Play Level";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // POHeaderSwitch
            // 
            this.POHeaderSwitch.Appearance = System.Windows.Forms.Appearance.Button;
            this.POHeaderSwitch.BackColor = System.Drawing.SystemColors.Control;
            this.POHeaderSwitch.Checked = true;
            this.POHeaderSwitch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.POHeaderSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.POHeaderSwitch.Dock = System.Windows.Forms.DockStyle.Top;
            this.POHeaderSwitch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.POHeaderSwitch.Location = new System.Drawing.Point(0, 0);
            this.POHeaderSwitch.Name = "POHeaderSwitch";
            this.POHeaderSwitch.Size = new System.Drawing.Size(179, 20);
            this.POHeaderSwitch.TabIndex = 1;
            this.POHeaderSwitch.TabStop = false;
            this.POHeaderSwitch.Text = "Header";
            this.POHeaderSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.POHeaderSwitch.UseCompatibleTextRendering = true;
            this.POHeaderSwitch.UseVisualStyleBackColor = false;
            this.POHeaderSwitch.CheckedChanged += new System.EventHandler(this.Switches_CheckedChanged);
            // 
            // Timer1
            // 
            this.Timer1.Interval = 15;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Menu1
            // 
            this.Menu1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Menu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MInsert,
            this.MRemove});
            this.Menu1.Name = "Menu1";
            this.Menu1.Size = new System.Drawing.Size(210, 56);
            // 
            // MInsert
            // 
            this.MInsert.Image = global::iBMSC.Properties.Resources.x16Add;
            this.MInsert.Name = "MInsert";
            this.MInsert.Size = new System.Drawing.Size(209, 26);
            this.MInsert.Text = "Insert Measure";
            this.MInsert.Click += new System.EventHandler(this.MInsert_Click);
            // 
            // MRemove
            // 
            this.MRemove.Image = global::iBMSC.Properties.Resources.x16Remove;
            this.MRemove.Name = "MRemove";
            this.MRemove.Size = new System.Drawing.Size(209, 26);
            this.MRemove.Text = "Remove Measure";
            this.MRemove.Click += new System.EventHandler(this.MRemove_Click);
            // 
            // AutoSaveTimer
            // 
            this.AutoSaveTimer.Enabled = true;
            this.AutoSaveTimer.Interval = 300000;
            this.AutoSaveTimer.Tick += new System.EventHandler(this.AutoSaveTimer_Tick);
            // 
            // mnMain
            // 
            this.mnMain.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.mnMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mnMain.Dock = System.Windows.Forms.DockStyle.None;
            this.mnMain.GripMargin = new System.Windows.Forms.Padding(2);
            this.mnMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnFile,
            this.mnEdit,
            this.mnSys,
            this.mnOptions,
            this.mnConversion,
            this.mnPreview});
            this.mnMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnMain.Location = new System.Drawing.Point(0, 27);
            this.mnMain.Name = "mnMain";
            this.mnMain.Size = new System.Drawing.Size(876, 28);
            this.mnMain.TabIndex = 57;
            this.mnMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mnMain_MouseDown);
            // 
            // mnFile
            // 
            this.mnFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnNew,
            this.mnOpen,
            this.mnImportSM,
            this.mnImportIBMSC,
            this.ToolStripSeparator14,
            this.mnSave,
            this.mnSaveAs,
            this.mnExport,
            this.ToolStripSeparator15,
            this.mnOpenR0,
            this.mnOpenR1,
            this.mnOpenR2,
            this.mnOpenR3,
            this.mnOpenR4,
            this.ToolStripSeparator16,
            this.mnQuit});
            this.mnFile.Name = "mnFile";
            this.mnFile.Size = new System.Drawing.Size(48, 24);
            this.mnFile.Text = "&File";
            // 
            // mnNew
            // 
            this.mnNew.Image = global::iBMSC.Properties.Resources.x16New;
            this.mnNew.Name = "mnNew";
            this.mnNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnNew.Size = new System.Drawing.Size(262, 26);
            this.mnNew.Text = "&New";
            this.mnNew.Click += new System.EventHandler(this.TBNew_Click);
            // 
            // mnOpen
            // 
            this.mnOpen.Image = global::iBMSC.Properties.Resources.x16Open;
            this.mnOpen.Name = "mnOpen";
            this.mnOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnOpen.Size = new System.Drawing.Size(262, 26);
            this.mnOpen.Text = "&Open";
            this.mnOpen.Click += new System.EventHandler(this.TBOpen_ButtonClick);
            // 
            // mnImportSM
            // 
            this.mnImportSM.Image = global::iBMSC.Properties.Resources.x16Import2;
            this.mnImportSM.Name = "mnImportSM";
            this.mnImportSM.Size = new System.Drawing.Size(262, 26);
            this.mnImportSM.Text = "Import from .S&M file";
            this.mnImportSM.Click += new System.EventHandler(this.TBImportSM_Click);
            // 
            // mnImportIBMSC
            // 
            this.mnImportIBMSC.Image = global::iBMSC.Properties.Resources.x16Import2;
            this.mnImportIBMSC.Name = "mnImportIBMSC";
            this.mnImportIBMSC.Size = new System.Drawing.Size(262, 26);
            this.mnImportIBMSC.Text = "Import from .&IBMSC file";
            this.mnImportIBMSC.Click += new System.EventHandler(this.TBImportIBMSC_Click);
            // 
            // ToolStripSeparator14
            // 
            this.ToolStripSeparator14.Name = "ToolStripSeparator14";
            this.ToolStripSeparator14.Size = new System.Drawing.Size(259, 6);
            // 
            // mnSave
            // 
            this.mnSave.Image = global::iBMSC.Properties.Resources.x16Save;
            this.mnSave.Name = "mnSave";
            this.mnSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnSave.Size = new System.Drawing.Size(262, 26);
            this.mnSave.Text = "&Save";
            this.mnSave.Click += new System.EventHandler(this.TBSave_ButtonClick);
            // 
            // mnSaveAs
            // 
            this.mnSaveAs.Image = global::iBMSC.Properties.Resources.x16SaveAs;
            this.mnSaveAs.Name = "mnSaveAs";
            this.mnSaveAs.Size = new System.Drawing.Size(262, 26);
            this.mnSaveAs.Text = "Save &As...";
            this.mnSaveAs.Click += new System.EventHandler(this.TBSaveAs_Click);
            // 
            // mnExport
            // 
            this.mnExport.Image = global::iBMSC.Properties.Resources.x16Export;
            this.mnExport.Name = "mnExport";
            this.mnExport.Size = new System.Drawing.Size(262, 26);
            this.mnExport.Text = "&Export .IBMSC file";
            this.mnExport.Click += new System.EventHandler(this.TBExport_Click);
            // 
            // ToolStripSeparator15
            // 
            this.ToolStripSeparator15.Name = "ToolStripSeparator15";
            this.ToolStripSeparator15.Size = new System.Drawing.Size(259, 6);
            // 
            // mnOpenR0
            // 
            this.mnOpenR0.Enabled = false;
            this.mnOpenR0.Name = "mnOpenR0";
            this.mnOpenR0.Size = new System.Drawing.Size(262, 26);
            this.mnOpenR0.Tag = "0";
            this.mnOpenR0.Text = "Recent #0";
            this.mnOpenR0.Click += new System.EventHandler(this.TBOpenR0_Click);
            // 
            // mnOpenR1
            // 
            this.mnOpenR1.Enabled = false;
            this.mnOpenR1.Name = "mnOpenR1";
            this.mnOpenR1.Size = new System.Drawing.Size(262, 26);
            this.mnOpenR1.Tag = "1";
            this.mnOpenR1.Text = "Recent #1";
            this.mnOpenR1.Click += new System.EventHandler(this.TBOpenR1_Click);
            // 
            // mnOpenR2
            // 
            this.mnOpenR2.Enabled = false;
            this.mnOpenR2.Name = "mnOpenR2";
            this.mnOpenR2.Size = new System.Drawing.Size(262, 26);
            this.mnOpenR2.Tag = "2";
            this.mnOpenR2.Text = "Recent #2";
            this.mnOpenR2.Click += new System.EventHandler(this.TBOpenR2_Click);
            // 
            // mnOpenR3
            // 
            this.mnOpenR3.Enabled = false;
            this.mnOpenR3.Name = "mnOpenR3";
            this.mnOpenR3.Size = new System.Drawing.Size(262, 26);
            this.mnOpenR3.Tag = "3";
            this.mnOpenR3.Text = "Recent #3";
            this.mnOpenR3.Click += new System.EventHandler(this.TBOpenR3_Click);
            // 
            // mnOpenR4
            // 
            this.mnOpenR4.Enabled = false;
            this.mnOpenR4.Name = "mnOpenR4";
            this.mnOpenR4.Size = new System.Drawing.Size(262, 26);
            this.mnOpenR4.Tag = "4";
            this.mnOpenR4.Text = "Recent #4";
            this.mnOpenR4.Click += new System.EventHandler(this.TBOpenR4_Click);
            // 
            // ToolStripSeparator16
            // 
            this.ToolStripSeparator16.Name = "ToolStripSeparator16";
            this.ToolStripSeparator16.Size = new System.Drawing.Size(259, 6);
            // 
            // mnQuit
            // 
            this.mnQuit.Name = "mnQuit";
            this.mnQuit.Size = new System.Drawing.Size(262, 26);
            this.mnQuit.Text = "&Quit";
            this.mnQuit.Click += new System.EventHandler(this.mnQuit_Click);
            // 
            // mnEdit
            // 
            this.mnEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnUndo,
            this.mnRedo,
            this.ToolStripSeparator17,
            this.mnCut,
            this.mnCopy,
            this.mnPaste,
            this.mnDelete,
            this.mnSelectAll,
            this.mnGotoMeasure,
            this.ToolStripSeparator18,
            this.mnFind,
            this.mnStatistics,
            this.ToolStripSeparator19,
            this.mnTimeSelect,
            this.mnSelect,
            this.mnWrite,
            this.ToolStripSeparator23,
            this.mnMyO2});
            this.mnEdit.Name = "mnEdit";
            this.mnEdit.Size = new System.Drawing.Size(51, 24);
            this.mnEdit.Text = "&Edit";
            // 
            // mnUndo
            // 
            this.mnUndo.Enabled = false;
            this.mnUndo.Image = global::iBMSC.Properties.Resources.x16Undo;
            this.mnUndo.Name = "mnUndo";
            this.mnUndo.ShortcutKeyDisplayString = "Ctrl+Z";
            this.mnUndo.Size = new System.Drawing.Size(311, 26);
            this.mnUndo.Text = "&Undo";
            this.mnUndo.Click += new System.EventHandler(this.TBUndo_Click);
            // 
            // mnRedo
            // 
            this.mnRedo.Enabled = false;
            this.mnRedo.Image = global::iBMSC.Properties.Resources.x16Redo;
            this.mnRedo.Name = "mnRedo";
            this.mnRedo.ShortcutKeyDisplayString = "Ctrl+Y";
            this.mnRedo.Size = new System.Drawing.Size(311, 26);
            this.mnRedo.Text = "&Redo";
            this.mnRedo.Click += new System.EventHandler(this.TBRedo_Click);
            // 
            // ToolStripSeparator17
            // 
            this.ToolStripSeparator17.Name = "ToolStripSeparator17";
            this.ToolStripSeparator17.Size = new System.Drawing.Size(308, 6);
            // 
            // mnCut
            // 
            this.mnCut.Image = global::iBMSC.Properties.Resources.x16Cut;
            this.mnCut.Name = "mnCut";
            this.mnCut.ShortcutKeyDisplayString = "Ctrl+X";
            this.mnCut.Size = new System.Drawing.Size(311, 26);
            this.mnCut.Text = "Cu&t";
            this.mnCut.Click += new System.EventHandler(this.TBCut_Click);
            // 
            // mnCopy
            // 
            this.mnCopy.Image = global::iBMSC.Properties.Resources.x16Copy;
            this.mnCopy.Name = "mnCopy";
            this.mnCopy.ShortcutKeyDisplayString = "Ctrl+C";
            this.mnCopy.Size = new System.Drawing.Size(311, 26);
            this.mnCopy.Text = "&Copy";
            this.mnCopy.Click += new System.EventHandler(this.TBCopy_Click);
            // 
            // mnPaste
            // 
            this.mnPaste.Image = global::iBMSC.Properties.Resources.x16Paste;
            this.mnPaste.Name = "mnPaste";
            this.mnPaste.ShortcutKeyDisplayString = "Ctrl+V";
            this.mnPaste.Size = new System.Drawing.Size(311, 26);
            this.mnPaste.Text = "&Paste";
            this.mnPaste.Click += new System.EventHandler(this.TBPaste_Click);
            // 
            // mnDelete
            // 
            this.mnDelete.Image = global::iBMSC.Properties.Resources.x16Remove;
            this.mnDelete.Name = "mnDelete";
            this.mnDelete.ShortcutKeyDisplayString = "Del";
            this.mnDelete.Size = new System.Drawing.Size(311, 26);
            this.mnDelete.Text = "De&lete";
            this.mnDelete.Click += new System.EventHandler(this.mnDelete_Click);
            // 
            // mnSelectAll
            // 
            this.mnSelectAll.Name = "mnSelectAll";
            this.mnSelectAll.ShortcutKeyDisplayString = "Ctrl+A";
            this.mnSelectAll.Size = new System.Drawing.Size(311, 26);
            this.mnSelectAll.Text = "Select &All";
            this.mnSelectAll.Click += new System.EventHandler(this.mnSelectAll_Click);
            // 
            // mnGotoMeasure
            // 
            this.mnGotoMeasure.Name = "mnGotoMeasure";
            this.mnGotoMeasure.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.mnGotoMeasure.Size = new System.Drawing.Size(311, 26);
            this.mnGotoMeasure.Text = "Go To Measure...";
            this.mnGotoMeasure.Click += new System.EventHandler(this.mnGotoMeasure_Click);
            // 
            // ToolStripSeparator18
            // 
            this.ToolStripSeparator18.Name = "ToolStripSeparator18";
            this.ToolStripSeparator18.Size = new System.Drawing.Size(308, 6);
            // 
            // mnFind
            // 
            this.mnFind.Image = global::iBMSC.Properties.Resources.x16Find;
            this.mnFind.Name = "mnFind";
            this.mnFind.ShortcutKeyDisplayString = "Ctrl+F";
            this.mnFind.Size = new System.Drawing.Size(311, 26);
            this.mnFind.Text = "&Find / Delete / Replace";
            this.mnFind.Click += new System.EventHandler(this.TBFind_Click);
            // 
            // mnStatistics
            // 
            this.mnStatistics.Image = global::iBMSC.Properties.Resources.x16Statistics;
            this.mnStatistics.Name = "mnStatistics";
            this.mnStatistics.ShortcutKeyDisplayString = "Ctrl+T";
            this.mnStatistics.Size = new System.Drawing.Size(311, 26);
            this.mnStatistics.Text = "St&atistics";
            this.mnStatistics.Click += new System.EventHandler(this.TBStatistics_Click);
            // 
            // ToolStripSeparator19
            // 
            this.ToolStripSeparator19.Name = "ToolStripSeparator19";
            this.ToolStripSeparator19.Size = new System.Drawing.Size(308, 6);
            // 
            // mnTimeSelect
            // 
            this.mnTimeSelect.CheckOnClick = true;
            this.mnTimeSelect.Image = global::iBMSC.Properties.Resources.x16TimeSelection;
            this.mnTimeSelect.Name = "mnTimeSelect";
            this.mnTimeSelect.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.mnTimeSelect.Size = new System.Drawing.Size(311, 26);
            this.mnTimeSelect.Text = "T&ime Selection Tool";
            this.mnTimeSelect.Click += new System.EventHandler(this.TBPostEffects_Click);
            // 
            // mnSelect
            // 
            this.mnSelect.Checked = true;
            this.mnSelect.CheckOnClick = true;
            this.mnSelect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnSelect.Image = global::iBMSC.Properties.Resources.x16Select;
            this.mnSelect.Name = "mnSelect";
            this.mnSelect.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.mnSelect.Size = new System.Drawing.Size(311, 26);
            this.mnSelect.Text = "&Select Tool";
            this.mnSelect.Click += new System.EventHandler(this.TBSelect_Click);
            // 
            // mnWrite
            // 
            this.mnWrite.CheckOnClick = true;
            this.mnWrite.Image = global::iBMSC.Properties.Resources.x16Pen;
            this.mnWrite.Name = "mnWrite";
            this.mnWrite.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.mnWrite.Size = new System.Drawing.Size(311, 26);
            this.mnWrite.Text = "&Write Tool";
            this.mnWrite.Click += new System.EventHandler(this.TBWrite_Click);
            // 
            // ToolStripSeparator23
            // 
            this.ToolStripSeparator23.Name = "ToolStripSeparator23";
            this.ToolStripSeparator23.Size = new System.Drawing.Size(308, 6);
            // 
            // mnMyO2
            // 
            this.mnMyO2.Image = global::iBMSC.Properties.Resources.x16MyO2;
            this.mnMyO2.Name = "mnMyO2";
            this.mnMyO2.Size = new System.Drawing.Size(311, 26);
            this.mnMyO2.Text = "MyO2 ToolBox (Chinese Only)";
            this.mnMyO2.Click += new System.EventHandler(this.TBMyO2_Click);
            // 
            // mnSys
            // 
            this.mnSys.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnSMenu,
            this.mnSTB,
            this.mnSOP,
            this.mnSStatus,
            this.mnSLSplitter,
            this.mnSRSplitter,
            this.ToolStripSeparator21,
            this.CGShow,
            this.CGShowS,
            this.CGShowBG,
            this.CGShowM,
            this.CGShowMB,
            this.CGShowV,
            this.CGShowC,
            this.ToolStripSeparator22,
            this.CGBPM,
            this.CGSTOP,
            this.CGSCROLL,
            this.CGBLP});
            this.mnSys.Name = "mnSys";
            this.mnSys.Size = new System.Drawing.Size(58, 24);
            this.mnSys.Text = "&View";
            // 
            // mnSMenu
            // 
            this.mnSMenu.Checked = true;
            this.mnSMenu.CheckOnClick = true;
            this.mnSMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnSMenu.Name = "mnSMenu";
            this.mnSMenu.Size = new System.Drawing.Size(225, 26);
            this.mnSMenu.Text = "&Main Menu";
            this.mnSMenu.Visible = false;
            this.mnSMenu.CheckedChanged += new System.EventHandler(this.mnSMenu_Click);
            // 
            // mnSTB
            // 
            this.mnSTB.Checked = true;
            this.mnSTB.CheckOnClick = true;
            this.mnSTB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnSTB.Name = "mnSTB";
            this.mnSTB.Size = new System.Drawing.Size(225, 26);
            this.mnSTB.Text = "&ToolBar";
            this.mnSTB.CheckedChanged += new System.EventHandler(this.mnSTB_Click);
            // 
            // mnSOP
            // 
            this.mnSOP.Checked = true;
            this.mnSOP.CheckOnClick = true;
            this.mnSOP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnSOP.Name = "mnSOP";
            this.mnSOP.Size = new System.Drawing.Size(225, 26);
            this.mnSOP.Text = "&Options Panel";
            this.mnSOP.CheckedChanged += new System.EventHandler(this.mnSOP_Click);
            // 
            // mnSStatus
            // 
            this.mnSStatus.Checked = true;
            this.mnSStatus.CheckOnClick = true;
            this.mnSStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnSStatus.Name = "mnSStatus";
            this.mnSStatus.Size = new System.Drawing.Size(225, 26);
            this.mnSStatus.Text = "&Status Bar";
            this.mnSStatus.CheckedChanged += new System.EventHandler(this.mnSStatus_Click);
            // 
            // mnSLSplitter
            // 
            this.mnSLSplitter.CheckOnClick = true;
            this.mnSLSplitter.Name = "mnSLSplitter";
            this.mnSLSplitter.Size = new System.Drawing.Size(225, 26);
            this.mnSLSplitter.Text = "&Left Splitter";
            this.mnSLSplitter.CheckedChanged += new System.EventHandler(this.mnSLSplitter_Click);
            // 
            // mnSRSplitter
            // 
            this.mnSRSplitter.CheckOnClick = true;
            this.mnSRSplitter.Name = "mnSRSplitter";
            this.mnSRSplitter.Size = new System.Drawing.Size(225, 26);
            this.mnSRSplitter.Text = "&Right Splitter";
            this.mnSRSplitter.CheckedChanged += new System.EventHandler(this.mnSRSplitter_Click);
            // 
            // ToolStripSeparator21
            // 
            this.ToolStripSeparator21.Name = "ToolStripSeparator21";
            this.ToolStripSeparator21.Size = new System.Drawing.Size(222, 6);
            // 
            // CGShow
            // 
            this.CGShow.Checked = true;
            this.CGShow.CheckOnClick = true;
            this.CGShow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CGShow.Name = "CGShow";
            this.CGShow.Size = new System.Drawing.Size(225, 26);
            this.CGShow.Text = "Grid";
            this.CGShow.CheckedChanged += new System.EventHandler(this.CGShow_CheckedChanged);
            // 
            // CGShowS
            // 
            this.CGShowS.Checked = true;
            this.CGShowS.CheckOnClick = true;
            this.CGShowS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CGShowS.Name = "CGShowS";
            this.CGShowS.Size = new System.Drawing.Size(225, 26);
            this.CGShowS.Text = "Sub";
            this.CGShowS.CheckedChanged += new System.EventHandler(this.CGShowS_CheckedChanged);
            // 
            // CGShowBG
            // 
            this.CGShowBG.Checked = true;
            this.CGShowBG.CheckOnClick = true;
            this.CGShowBG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CGShowBG.Name = "CGShowBG";
            this.CGShowBG.Size = new System.Drawing.Size(225, 26);
            this.CGShowBG.Text = "BackGround";
            this.CGShowBG.CheckedChanged += new System.EventHandler(this.CGShowBG_CheckedChanged);
            // 
            // CGShowM
            // 
            this.CGShowM.Checked = true;
            this.CGShowM.CheckOnClick = true;
            this.CGShowM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CGShowM.Name = "CGShowM";
            this.CGShowM.Size = new System.Drawing.Size(225, 26);
            this.CGShowM.Text = "Measure Index";
            this.CGShowM.CheckedChanged += new System.EventHandler(this.CGShowM_CheckedChanged);
            // 
            // CGShowMB
            // 
            this.CGShowMB.Checked = true;
            this.CGShowMB.CheckOnClick = true;
            this.CGShowMB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CGShowMB.Name = "CGShowMB";
            this.CGShowMB.Size = new System.Drawing.Size(225, 26);
            this.CGShowMB.Text = "Measure Line";
            this.CGShowMB.CheckedChanged += new System.EventHandler(this.CGShowMB_CheckedChanged);
            // 
            // CGShowV
            // 
            this.CGShowV.Checked = true;
            this.CGShowV.CheckOnClick = true;
            this.CGShowV.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CGShowV.Name = "CGShowV";
            this.CGShowV.Size = new System.Drawing.Size(225, 26);
            this.CGShowV.Text = "Vertical Line";
            this.CGShowV.CheckedChanged += new System.EventHandler(this.CGShowV_CheckedChanged);
            // 
            // CGShowC
            // 
            this.CGShowC.Checked = true;
            this.CGShowC.CheckOnClick = true;
            this.CGShowC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CGShowC.Name = "CGShowC";
            this.CGShowC.Size = new System.Drawing.Size(225, 26);
            this.CGShowC.Text = "Column Caption";
            this.CGShowC.CheckedChanged += new System.EventHandler(this.CGShowC_CheckedChanged);
            // 
            // ToolStripSeparator22
            // 
            this.ToolStripSeparator22.Name = "ToolStripSeparator22";
            this.ToolStripSeparator22.Size = new System.Drawing.Size(222, 6);
            // 
            // CGBPM
            // 
            this.CGBPM.Checked = true;
            this.CGBPM.CheckOnClick = true;
            this.CGBPM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CGBPM.Name = "CGBPM";
            this.CGBPM.Size = new System.Drawing.Size(225, 26);
            this.CGBPM.Text = "BPM";
            this.CGBPM.CheckedChanged += new System.EventHandler(this.CGBPM_CheckedChanged);
            // 
            // CGSTOP
            // 
            this.CGSTOP.Checked = true;
            this.CGSTOP.CheckOnClick = true;
            this.CGSTOP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CGSTOP.Name = "CGSTOP";
            this.CGSTOP.Size = new System.Drawing.Size(225, 26);
            this.CGSTOP.Text = "STOP";
            this.CGSTOP.CheckedChanged += new System.EventHandler(this.CGSTOP_CheckedChanged);
            // 
            // CGSCROLL
            // 
            this.CGSCROLL.Checked = true;
            this.CGSCROLL.CheckOnClick = true;
            this.CGSCROLL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CGSCROLL.Name = "CGSCROLL";
            this.CGSCROLL.Size = new System.Drawing.Size(225, 26);
            this.CGSCROLL.Text = "SCROLL";
            this.CGSCROLL.CheckedChanged += new System.EventHandler(this.CGSCROLL_CheckedChanged);
            // 
            // CGBLP
            // 
            this.CGBLP.Checked = true;
            this.CGBLP.CheckOnClick = true;
            this.CGBLP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CGBLP.Name = "CGBLP";
            this.CGBLP.Size = new System.Drawing.Size(225, 26);
            this.CGBLP.Text = "BGA / Layer / Poor";
            this.CGBLP.CheckedChanged += new System.EventHandler(this.CGBLP_CheckedChanged);
            // 
            // mnOptions
            // 
            this.mnOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnNTInput,
            this.mnErrorCheck,
            this.mnPreviewOnClick,
            this.mnShowFileName,
            this.ToolStripSeparator20,
            this.mnGOptions,
            this.mnVOptions,
            this.mnPOptions,
            this.mnLanguage,
            this.mnTheme});
            this.mnOptions.Name = "mnOptions";
            this.mnOptions.Size = new System.Drawing.Size(81, 24);
            this.mnOptions.Text = "&Options";
            // 
            // mnNTInput
            // 
            this.mnNTInput.Checked = true;
            this.mnNTInput.CheckOnClick = true;
            this.mnNTInput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnNTInput.Image = global::iBMSC.Properties.Resources.x16NTInput;
            this.mnNTInput.Name = "mnNTInput";
            this.mnNTInput.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.mnNTInput.Size = new System.Drawing.Size(302, 26);
            this.mnNTInput.Text = "L&N Input Style - NT/BMSE";
            this.mnNTInput.Click += new System.EventHandler(this.TBNTInput_Click);
            // 
            // mnErrorCheck
            // 
            this.mnErrorCheck.Checked = true;
            this.mnErrorCheck.CheckOnClick = true;
            this.mnErrorCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnErrorCheck.Image = global::iBMSC.Properties.Resources.x16CheckError;
            this.mnErrorCheck.Name = "mnErrorCheck";
            this.mnErrorCheck.Size = new System.Drawing.Size(302, 26);
            this.mnErrorCheck.Text = "&Error Check";
            this.mnErrorCheck.Click += new System.EventHandler(this.TBErrorCheck_Click);
            // 
            // mnPreviewOnClick
            // 
            this.mnPreviewOnClick.Checked = true;
            this.mnPreviewOnClick.CheckOnClick = true;
            this.mnPreviewOnClick.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnPreviewOnClick.Image = global::iBMSC.Properties.Resources.x16PreviewOnClick;
            this.mnPreviewOnClick.Name = "mnPreviewOnClick";
            this.mnPreviewOnClick.Size = new System.Drawing.Size(302, 26);
            this.mnPreviewOnClick.Text = "Preview on &Click";
            this.mnPreviewOnClick.Click += new System.EventHandler(this.TBPreviewOnClick_Click);
            // 
            // mnShowFileName
            // 
            this.mnShowFileName.CheckOnClick = true;
            this.mnShowFileName.Image = global::iBMSC.Properties.Resources.x16ShowFileNameN;
            this.mnShowFileName.Name = "mnShowFileName";
            this.mnShowFileName.Size = new System.Drawing.Size(302, 26);
            this.mnShowFileName.Text = "Show &File Name on Notes";
            this.mnShowFileName.Click += new System.EventHandler(this.TBShowFileName_Click);
            // 
            // ToolStripSeparator20
            // 
            this.ToolStripSeparator20.Name = "ToolStripSeparator20";
            this.ToolStripSeparator20.Size = new System.Drawing.Size(299, 6);
            // 
            // mnGOptions
            // 
            this.mnGOptions.Image = global::iBMSC.Properties.Resources.x16GeneralOptions;
            this.mnGOptions.Name = "mnGOptions";
            this.mnGOptions.Size = new System.Drawing.Size(302, 26);
            this.mnGOptions.Text = "&General Options";
            this.mnGOptions.Click += new System.EventHandler(this.TBGOptions_Click);
            // 
            // mnVOptions
            // 
            this.mnVOptions.Image = global::iBMSC.Properties.Resources.x16VisualOptions;
            this.mnVOptions.Name = "mnVOptions";
            this.mnVOptions.Size = new System.Drawing.Size(302, 26);
            this.mnVOptions.Text = "&Visual Options";
            this.mnVOptions.Click += new System.EventHandler(this.TBOptions_Click);
            // 
            // mnPOptions
            // 
            this.mnPOptions.Image = global::iBMSC.Properties.Resources.x16PlayerOptions;
            this.mnPOptions.Name = "mnPOptions";
            this.mnPOptions.Size = new System.Drawing.Size(302, 26);
            this.mnPOptions.Text = "&Player Options";
            this.mnPOptions.Click += new System.EventHandler(this.TBPOptions_Click);
            // 
            // mnConversion
            // 
            this.mnConversion.DropDown = this.cmnConversion;
            this.mnConversion.Name = "mnConversion";
            this.mnConversion.Size = new System.Drawing.Size(112, 24);
            this.mnConversion.Text = "&Conversions";
            // 
            // cmnConversion
            // 
            this.cmnConversion.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmnConversion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.POBLong,
            this.POBShort,
            this.POBLongShort,
            this.ToolStripSeparator10,
            this.POBHidden,
            this.POBVisible,
            this.POBHiddenVisible,
            this.ToolStripSeparator11,
            this.POBModify,
            this.POBMirror});
            this.cmnConversion.Name = "cmnLanguage";
            this.cmnConversion.OwnerItem = this.mnConversion;
            this.cmnConversion.Size = new System.Drawing.Size(288, 224);
            // 
            // POBLong
            // 
            this.POBLong.Enabled = false;
            this.POBLong.Image = global::iBMSC.Properties.Resources.ConvertNotesL;
            this.POBLong.Name = "POBLong";
            this.POBLong.Size = new System.Drawing.Size(287, 26);
            this.POBLong.Text = "→ &Long Note";
            this.POBLong.Click += new System.EventHandler(this.POBLong_Click);
            // 
            // POBShort
            // 
            this.POBShort.Image = global::iBMSC.Properties.Resources.ConvertNotesN;
            this.POBShort.Name = "POBShort";
            this.POBShort.Size = new System.Drawing.Size(287, 26);
            this.POBShort.Text = "→ &Short Note";
            this.POBShort.Click += new System.EventHandler(this.POBNormal_Click);
            // 
            // POBLongShort
            // 
            this.POBLongShort.Enabled = false;
            this.POBLongShort.Image = global::iBMSC.Properties.Resources.ConvertNotes;
            this.POBLongShort.Name = "POBLongShort";
            this.POBLongShort.Size = new System.Drawing.Size(287, 26);
            this.POBLongShort.Text = "Long Note ↔ Short Note";
            this.POBLongShort.Click += new System.EventHandler(this.POBNormalLong_Click);
            // 
            // ToolStripSeparator10
            // 
            this.ToolStripSeparator10.Name = "ToolStripSeparator10";
            this.ToolStripSeparator10.Size = new System.Drawing.Size(284, 6);
            // 
            // POBHidden
            // 
            this.POBHidden.Image = global::iBMSC.Properties.Resources.ConvertNotesH;
            this.POBHidden.Name = "POBHidden";
            this.POBHidden.Size = new System.Drawing.Size(287, 26);
            this.POBHidden.Text = "→ &Hidden Note";
            this.POBHidden.Click += new System.EventHandler(this.POBHidden_Click);
            // 
            // POBVisible
            // 
            this.POBVisible.Image = global::iBMSC.Properties.Resources.ConvertNotesV;
            this.POBVisible.Name = "POBVisible";
            this.POBVisible.Size = new System.Drawing.Size(287, 26);
            this.POBVisible.Text = "→ &Visible Note";
            this.POBVisible.Click += new System.EventHandler(this.POBVisible_Click);
            // 
            // POBHiddenVisible
            // 
            this.POBHiddenVisible.Image = global::iBMSC.Properties.Resources.ConvertNotesHV;
            this.POBHiddenVisible.Name = "POBHiddenVisible";
            this.POBHiddenVisible.Size = new System.Drawing.Size(287, 26);
            this.POBHiddenVisible.Text = "Hidden Note ↔ Visible Note";
            this.POBHiddenVisible.Click += new System.EventHandler(this.POBHiddenVisible_Click);
            // 
            // ToolStripSeparator11
            // 
            this.ToolStripSeparator11.Name = "ToolStripSeparator11";
            this.ToolStripSeparator11.Size = new System.Drawing.Size(284, 6);
            // 
            // POBModify
            // 
            this.POBModify.Image = global::iBMSC.Properties.Resources.x16ModifyLabel;
            this.POBModify.Name = "POBModify";
            this.POBModify.Size = new System.Drawing.Size(287, 26);
            this.POBModify.Text = "&Modify Labels";
            this.POBModify.Click += new System.EventHandler(this.POBModify_Click);
            // 
            // POBMirror
            // 
            this.POBMirror.Image = global::iBMSC.Properties.Resources.x16Mirror;
            this.POBMirror.Name = "POBMirror";
            this.POBMirror.Size = new System.Drawing.Size(287, 26);
            this.POBMirror.Text = "Mi&rror";
            this.POBMirror.Click += new System.EventHandler(this.POBMirror_Click);
            // 
            // POConvert
            // 
            this.POConvert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.POConvert.DropDown = this.cmnConversion;
            this.POConvert.Image = global::iBMSC.Properties.Resources.ConvertNotes;
            this.POConvert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.POConvert.Name = "POConvert";
            this.POConvert.Size = new System.Drawing.Size(34, 24);
            this.POConvert.Text = "Convert Notes";
            // 
            // mnPreview
            // 
            this.mnPreview.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnPlayB,
            this.mnPlay,
            this.mnStop});
            this.mnPreview.Name = "mnPreview";
            this.mnPreview.Size = new System.Drawing.Size(80, 24);
            this.mnPreview.Text = "&Preview";
            // 
            // mnPlayB
            // 
            this.mnPlayB.Image = global::iBMSC.Properties.Resources.x16PlayB;
            this.mnPlayB.Name = "mnPlayB";
            this.mnPlayB.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnPlayB.Size = new System.Drawing.Size(264, 26);
            this.mnPlayB.Text = "Play from &beginning";
            this.mnPlayB.Click += new System.EventHandler(this.TBPlayB_Click);
            // 
            // mnPlay
            // 
            this.mnPlay.Image = global::iBMSC.Properties.Resources.x16Play;
            this.mnPlay.Name = "mnPlay";
            this.mnPlay.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.mnPlay.Size = new System.Drawing.Size(264, 26);
            this.mnPlay.Text = "&Play from here";
            this.mnPlay.Click += new System.EventHandler(this.TBPlay_Click);
            // 
            // mnStop
            // 
            this.mnStop.Image = global::iBMSC.Properties.Resources.x16Stop;
            this.mnStop.Name = "mnStop";
            this.mnStop.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.mnStop.Size = new System.Drawing.Size(264, 26);
            this.mnStop.Text = "&Stop";
            this.mnStop.Click += new System.EventHandler(this.TBStop_Click);
            // 
            // TBMain
            // 
            this.TBMain.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.TBMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TBMain.Dock = System.Windows.Forms.DockStyle.None;
            this.TBMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.TBMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TBNew,
            this.TBOpen,
            this.TBSave,
            this.ToolStripSeparator1,
            this.TBCut,
            this.TBCopy,
            this.TBPaste,
            this.TBFind,
            this.ToolStripSeparator24,
            this.TBStatistics,
            this.POConvert,
            this.TBMyO2,
            this.ToolStripSeparator4,
            this.TBErrorCheck,
            this.TBPreviewOnClick,
            this.TBShowFileName,
            this.ToolStripSeparator8,
            this.TBNTInput,
            this.TBWavIncrease,
            this.ToolStripSeparator2,
            this.TBUndo,
            this.TBRedo,
            this.ToolStripSeparator5,
            this.TBTimeSelect,
            this.TBSelect,
            this.TBWrite,
            this.ToolStripSeparator3,
            this.TBPlayB,
            this.TBPlay,
            this.TBStop,
            this.TBPOptions,
            this.ToolStripSeparator7,
            this.TBVOptions,
            this.TBGOptions,
            this.TBLanguage,
            this.TBTheme,
            this.POBStorm});
            this.TBMain.Location = new System.Drawing.Point(4, 0);
            this.TBMain.Name = "TBMain";
            this.TBMain.Size = new System.Drawing.Size(872, 27);
            this.TBMain.TabIndex = 64;
            this.TBMain.Text = "Main Toolbar";
            // 
            // TBNew
            // 
            this.TBNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TBNew.Image = global::iBMSC.Properties.Resources.x16New;
            this.TBNew.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.TBNew.Name = "TBNew";
            this.TBNew.Size = new System.Drawing.Size(29, 24);
            this.TBNew.Text = "New (Ctrl+N)";
            this.TBNew.Click += new System.EventHandler(this.TBNew_Click);
            // 
            // TBOpen
            // 
            this.TBOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TBOpen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TBOpenR0,
            this.TBOpenR1,
            this.TBOpenR2,
            this.TBOpenR3,
            this.TBOpenR4,
            this.ToolStripSeparator12,
            this.TBImportSM,
            this.TBImportIBMSC});
            this.TBOpen.Image = global::iBMSC.Properties.Resources.x16Open;
            this.TBOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TBOpen.Name = "TBOpen";
            this.TBOpen.Size = new System.Drawing.Size(39, 24);
            this.TBOpen.Text = "Open (Ctrl+O)";
            this.TBOpen.ButtonClick += new System.EventHandler(this.TBOpen_ButtonClick);
            // 
            // TBOpenR0
            // 
            this.TBOpenR0.Enabled = false;
            this.TBOpenR0.Name = "TBOpenR0";
            this.TBOpenR0.Size = new System.Drawing.Size(262, 26);
            this.TBOpenR0.Tag = "0";
            this.TBOpenR0.Text = "Recent #0";
            this.TBOpenR0.Click += new System.EventHandler(this.TBOpenR0_Click);
            // 
            // TBOpenR1
            // 
            this.TBOpenR1.Enabled = false;
            this.TBOpenR1.Name = "TBOpenR1";
            this.TBOpenR1.Size = new System.Drawing.Size(262, 26);
            this.TBOpenR1.Tag = "1";
            this.TBOpenR1.Text = "Recent #1";
            this.TBOpenR1.Click += new System.EventHandler(this.TBOpenR1_Click);
            // 
            // TBOpenR2
            // 
            this.TBOpenR2.Enabled = false;
            this.TBOpenR2.Name = "TBOpenR2";
            this.TBOpenR2.Size = new System.Drawing.Size(262, 26);
            this.TBOpenR2.Tag = "2";
            this.TBOpenR2.Text = "Recent #2";
            this.TBOpenR2.Click += new System.EventHandler(this.TBOpenR2_Click);
            // 
            // TBOpenR3
            // 
            this.TBOpenR3.Enabled = false;
            this.TBOpenR3.Name = "TBOpenR3";
            this.TBOpenR3.Size = new System.Drawing.Size(262, 26);
            this.TBOpenR3.Tag = "3";
            this.TBOpenR3.Text = "Recent #3";
            this.TBOpenR3.Click += new System.EventHandler(this.TBOpenR3_Click);
            // 
            // TBOpenR4
            // 
            this.TBOpenR4.Enabled = false;
            this.TBOpenR4.Name = "TBOpenR4";
            this.TBOpenR4.Size = new System.Drawing.Size(262, 26);
            this.TBOpenR4.Tag = "4";
            this.TBOpenR4.Text = "Recent #4";
            this.TBOpenR4.Click += new System.EventHandler(this.TBOpenR4_Click);
            // 
            // ToolStripSeparator12
            // 
            this.ToolStripSeparator12.Name = "ToolStripSeparator12";
            this.ToolStripSeparator12.Size = new System.Drawing.Size(259, 6);
            // 
            // TBImportSM
            // 
            this.TBImportSM.Image = global::iBMSC.Properties.Resources.x16Import2;
            this.TBImportSM.Name = "TBImportSM";
            this.TBImportSM.Size = new System.Drawing.Size(262, 26);
            this.TBImportSM.Text = "Import from .SM file";
            this.TBImportSM.Click += new System.EventHandler(this.TBImportSM_Click);
            // 
            // TBImportIBMSC
            // 
            this.TBImportIBMSC.Image = global::iBMSC.Properties.Resources.x16Import2;
            this.TBImportIBMSC.Name = "TBImportIBMSC";
            this.TBImportIBMSC.Size = new System.Drawing.Size(262, 26);
            this.TBImportIBMSC.Text = "Import from .IBMSC file";
            this.TBImportIBMSC.Click += new System.EventHandler(this.TBImportIBMSC_Click);
            // 
            // TBSave
            // 
            this.TBSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TBSave.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TBSaveAs,
            this.TBExport});
            this.TBSave.Image = global::iBMSC.Properties.Resources.x16Save;
            this.TBSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TBSave.Name = "TBSave";
            this.TBSave.Size = new System.Drawing.Size(39, 24);
            this.TBSave.Text = "Save (Ctrl+S)";
            this.TBSave.ButtonClick += new System.EventHandler(this.TBSave_ButtonClick);
            // 
            // TBSaveAs
            // 
            this.TBSaveAs.Image = global::iBMSC.Properties.Resources.x16SaveAs;
            this.TBSaveAs.Name = "TBSaveAs";
            this.TBSaveAs.Size = new System.Drawing.Size(221, 26);
            this.TBSaveAs.Text = "Save As...";
            this.TBSaveAs.Click += new System.EventHandler(this.TBSaveAs_Click);
            // 
            // TBExport
            // 
            this.TBExport.Image = global::iBMSC.Properties.Resources.x16Export;
            this.TBExport.Name = "TBExport";
            this.TBExport.Size = new System.Drawing.Size(221, 26);
            this.TBExport.Text = "Export .IBMSC file";
            this.TBExport.Click += new System.EventHandler(this.TBExport_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // TBCut
            // 
            this.TBCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TBCut.Image = global::iBMSC.Properties.Resources.x16Cut;
            this.TBCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TBCut.Name = "TBCut";
            this.TBCut.Size = new System.Drawing.Size(29, 24);
            this.TBCut.Text = "Cut (Ctrl+X)";
            this.TBCut.Click += new System.EventHandler(this.TBCut_Click);
            // 
            // TBCopy
            // 
            this.TBCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TBCopy.Image = global::iBMSC.Properties.Resources.x16Copy;
            this.TBCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TBCopy.Name = "TBCopy";
            this.TBCopy.Size = new System.Drawing.Size(29, 24);
            this.TBCopy.Text = "Copy (Ctrl+C)";
            this.TBCopy.Click += new System.EventHandler(this.TBCopy_Click);
            // 
            // TBPaste
            // 
            this.TBPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TBPaste.Image = global::iBMSC.Properties.Resources.x16Paste;
            this.TBPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TBPaste.Name = "TBPaste";
            this.TBPaste.Size = new System.Drawing.Size(29, 24);
            this.TBPaste.Text = "Paste (Ctrl+V)";
            this.TBPaste.Click += new System.EventHandler(this.TBPaste_Click);
            // 
            // TBFind
            // 
            this.TBFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TBFind.Image = global::iBMSC.Properties.Resources.x16Find;
            this.TBFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TBFind.Name = "TBFind";
            this.TBFind.Size = new System.Drawing.Size(29, 24);
            this.TBFind.Text = "Find / Delete / Replace (Ctrl+F)";
            this.TBFind.Click += new System.EventHandler(this.TBFind_Click);
            // 
            // ToolStripSeparator24
            // 
            this.ToolStripSeparator24.Name = "ToolStripSeparator24";
            this.ToolStripSeparator24.Size = new System.Drawing.Size(6, 27);
            // 
            // TBStatistics
            // 
            this.TBStatistics.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TBStatistics.Image = global::iBMSC.Properties.Resources.x16Statistics;
            this.TBStatistics.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TBStatistics.Name = "TBStatistics";
            this.TBStatistics.Size = new System.Drawing.Size(42, 24);
            this.TBStatistics.Text = "0";
            this.TBStatistics.ToolTipText = "Statistics (Ctrl+T)";
            this.TBStatistics.Click += new System.EventHandler(this.TBStatistics_Click);
            // 
            // TBMyO2
            // 
            this.TBMyO2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TBMyO2.Image = global::iBMSC.Properties.Resources.x16MyO2;
            this.TBMyO2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TBMyO2.Name = "TBMyO2";
            this.TBMyO2.Size = new System.Drawing.Size(29, 24);
            this.TBMyO2.Text = "MyO2 ToolBox (Chinese Only)";
            this.TBMyO2.Click += new System.EventHandler(this.TBMyO2_Click);
            // 
            // ToolStripSeparator4
            // 
            this.ToolStripSeparator4.Name = "ToolStripSeparator4";
            this.ToolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // TBErrorCheck
            // 
            this.TBErrorCheck.Checked = true;
            this.TBErrorCheck.CheckOnClick = true;
            this.TBErrorCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TBErrorCheck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TBErrorCheck.Image = global::iBMSC.Properties.Resources.x16CheckError;
            this.TBErrorCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TBErrorCheck.Name = "TBErrorCheck";
            this.TBErrorCheck.Size = new System.Drawing.Size(29, 24);
            this.TBErrorCheck.Text = "Error Check";
            this.TBErrorCheck.Click += new System.EventHandler(this.TBErrorCheck_Click);
            // 
            // TBPreviewOnClick
            // 
            this.TBPreviewOnClick.Checked = true;
            this.TBPreviewOnClick.CheckOnClick = true;
            this.TBPreviewOnClick.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TBPreviewOnClick.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TBPreviewOnClick.Image = global::iBMSC.Properties.Resources.x16PreviewOnClick;
            this.TBPreviewOnClick.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TBPreviewOnClick.Name = "TBPreviewOnClick";
            this.TBPreviewOnClick.Size = new System.Drawing.Size(29, 24);
            this.TBPreviewOnClick.Text = "Preview On Click";
            this.TBPreviewOnClick.Click += new System.EventHandler(this.TBPreviewOnClick_Click);
            // 
            // TBShowFileName
            // 
            this.TBShowFileName.CheckOnClick = true;
            this.TBShowFileName.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TBShowFileName.Image = global::iBMSC.Properties.Resources.x16ShowFileNameN;
            this.TBShowFileName.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TBShowFileName.Name = "TBShowFileName";
            this.TBShowFileName.Size = new System.Drawing.Size(29, 24);
            this.TBShowFileName.Text = "Show File Name on Notes";
            this.TBShowFileName.Click += new System.EventHandler(this.TBShowFileName_Click);
            // 
            // ToolStripSeparator8
            // 
            this.ToolStripSeparator8.Name = "ToolStripSeparator8";
            this.ToolStripSeparator8.Size = new System.Drawing.Size(6, 27);
            // 
            // TBNTInput
            // 
            this.TBNTInput.Checked = true;
            this.TBNTInput.CheckOnClick = true;
            this.TBNTInput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TBNTInput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TBNTInput.Image = global::iBMSC.Properties.Resources.x16NTInput;
            this.TBNTInput.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TBNTInput.Name = "TBNTInput";
            this.TBNTInput.Size = new System.Drawing.Size(29, 24);
            this.TBNTInput.Text = "LongNote Input Style - NoteTool/BMSE";
            this.TBNTInput.Click += new System.EventHandler(this.TBNTInput_Click);
            // 
            // TBWavIncrease
            // 
            this.TBWavIncrease.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TBWavIncrease.Image = ((System.Drawing.Image)(resources.GetObject("TBWavIncrease.Image")));
            this.TBWavIncrease.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TBWavIncrease.Name = "TBWavIncrease";
            this.TBWavIncrease.Size = new System.Drawing.Size(29, 24);
            this.TBWavIncrease.Text = "Autoincrease WAV when writing";
            this.TBWavIncrease.Click += new System.EventHandler(this.TBWavIncrease_Click);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // TBUndo
            // 
            this.TBUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TBUndo.Enabled = false;
            this.TBUndo.Image = global::iBMSC.Properties.Resources.x16Undo;
            this.TBUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TBUndo.Name = "TBUndo";
            this.TBUndo.Size = new System.Drawing.Size(29, 24);
            this.TBUndo.Text = "Undo (Ctrl+Z)";
            this.TBUndo.Click += new System.EventHandler(this.TBUndo_Click);
            // 
            // TBRedo
            // 
            this.TBRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TBRedo.Enabled = false;
            this.TBRedo.Image = global::iBMSC.Properties.Resources.x16Redo;
            this.TBRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TBRedo.Name = "TBRedo";
            this.TBRedo.Size = new System.Drawing.Size(29, 24);
            this.TBRedo.Text = "Redo (Ctrl+Y)";
            this.TBRedo.Click += new System.EventHandler(this.TBRedo_Click);
            // 
            // ToolStripSeparator5
            // 
            this.ToolStripSeparator5.Name = "ToolStripSeparator5";
            this.ToolStripSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // TBTimeSelect
            // 
            this.TBTimeSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TBTimeSelect.Image = global::iBMSC.Properties.Resources.x16TimeSelection;
            this.TBTimeSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TBTimeSelect.Name = "TBTimeSelect";
            this.TBTimeSelect.Size = new System.Drawing.Size(29, 24);
            this.TBTimeSelect.Text = "Time Selection Tool (F1)";
            this.TBTimeSelect.Click += new System.EventHandler(this.TBPostEffects_Click);
            // 
            // TBSelect
            // 
            this.TBSelect.Checked = true;
            this.TBSelect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TBSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TBSelect.Image = global::iBMSC.Properties.Resources.x16Select;
            this.TBSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TBSelect.Name = "TBSelect";
            this.TBSelect.Size = new System.Drawing.Size(29, 24);
            this.TBSelect.Text = "Select Tool (F2)";
            this.TBSelect.Click += new System.EventHandler(this.TBSelect_Click);
            // 
            // TBWrite
            // 
            this.TBWrite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TBWrite.Image = global::iBMSC.Properties.Resources.x16Pen;
            this.TBWrite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TBWrite.Name = "TBWrite";
            this.TBWrite.Size = new System.Drawing.Size(29, 24);
            this.TBWrite.Text = "Write Tool (F3)";
            this.TBWrite.Click += new System.EventHandler(this.TBWrite_Click);
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // TBPlayB
            // 
            this.TBPlayB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TBPlayB.Image = global::iBMSC.Properties.Resources.x16PlayB;
            this.TBPlayB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TBPlayB.Name = "TBPlayB";
            this.TBPlayB.Size = new System.Drawing.Size(29, 24);
            this.TBPlayB.Text = "Play from beginning (F5)";
            this.TBPlayB.Click += new System.EventHandler(this.TBPlayB_Click);
            // 
            // TBPlay
            // 
            this.TBPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TBPlay.Image = global::iBMSC.Properties.Resources.x16Play;
            this.TBPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TBPlay.Name = "TBPlay";
            this.TBPlay.Size = new System.Drawing.Size(29, 24);
            this.TBPlay.Text = "Play from here (F6)";
            this.TBPlay.Click += new System.EventHandler(this.TBPlay_Click);
            // 
            // TBStop
            // 
            this.TBStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TBStop.Image = global::iBMSC.Properties.Resources.x16Stop;
            this.TBStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TBStop.Name = "TBStop";
            this.TBStop.Size = new System.Drawing.Size(29, 24);
            this.TBStop.Text = "Stop (F7)";
            this.TBStop.Click += new System.EventHandler(this.TBStop_Click);
            // 
            // TBPOptions
            // 
            this.TBPOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TBPOptions.Image = global::iBMSC.Properties.Resources.x16PlayerOptions;
            this.TBPOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TBPOptions.Name = "TBPOptions";
            this.TBPOptions.Size = new System.Drawing.Size(29, 24);
            this.TBPOptions.Text = "Player Options";
            this.TBPOptions.Click += new System.EventHandler(this.TBPOptions_Click);
            // 
            // ToolStripSeparator7
            // 
            this.ToolStripSeparator7.Name = "ToolStripSeparator7";
            this.ToolStripSeparator7.Size = new System.Drawing.Size(6, 27);
            // 
            // TBVOptions
            // 
            this.TBVOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TBVOptions.Image = global::iBMSC.Properties.Resources.x16VisualOptions;
            this.TBVOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TBVOptions.Name = "TBVOptions";
            this.TBVOptions.Size = new System.Drawing.Size(29, 24);
            this.TBVOptions.Text = "Visual Options";
            this.TBVOptions.Click += new System.EventHandler(this.TBOptions_Click);
            // 
            // TBGOptions
            // 
            this.TBGOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TBGOptions.Image = global::iBMSC.Properties.Resources.x16GeneralOptions;
            this.TBGOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TBGOptions.Name = "TBGOptions";
            this.TBGOptions.Size = new System.Drawing.Size(29, 24);
            this.TBGOptions.Text = "General Options";
            this.TBGOptions.Click += new System.EventHandler(this.TBGOptions_Click);
            // 
            // POBStorm
            // 
            this.POBStorm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.POBStorm.Image = global::iBMSC.Properties.Resources.x16Storm;
            this.POBStorm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.POBStorm.Name = "POBStorm";
            this.POBStorm.Size = new System.Drawing.Size(29, 24);
            this.POBStorm.Text = "Storm";
            this.POBStorm.Visible = false;
            this.POBStorm.Click += new System.EventHandler(this.POBStorm_Click);
            // 
            // pStatus
            // 
            this.pStatus.AutoSize = true;
            this.pStatus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pStatus.Controls.Add(this.FStatus2);
            this.pStatus.Controls.Add(this.FStatus);
            this.pStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pStatus.Location = new System.Drawing.Point(0, 704);
            this.pStatus.Name = "pStatus";
            this.pStatus.Size = new System.Drawing.Size(876, 26);
            this.pStatus.TabIndex = 62;
            // 
            // FStatus2
            // 
            this.FStatus2.AccessibleRole = System.Windows.Forms.AccessibleRole.StatusBar;
            this.FStatus2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.FStatus2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FSSS,
            this.FSSL,
            this.FSSH,
            this.BVCReverse,
            this.LblMultiply,
            this.TVCM,
            this.LblDivide,
            this.TVCD,
            this.BVCApply,
            this.TVCBPM,
            this.BVCCalculate,
            this.BConvertStop});
            this.FStatus2.Location = new System.Drawing.Point(0, 0);
            this.FStatus2.Name = "FStatus2";
            this.FStatus2.ShowItemToolTips = true;
            this.FStatus2.Size = new System.Drawing.Size(876, 22);
            this.FStatus2.TabIndex = 0;
            this.FStatus2.Text = "Status";
            this.FStatus2.Visible = false;
            // 
            // FSSS
            // 
            this.FSSS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FSSS.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FSSS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FSSS.Name = "FSSS";
            this.FSSS.Size = new System.Drawing.Size(29, 20);
            this.FSSS.Text = "0";
            this.FSSS.ToolTipText = "Selection Start Position";
            this.FSSS.Click += new System.EventHandler(this.FSSS_Click);
            // 
            // FSSL
            // 
            this.FSSL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FSSL.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FSSL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FSSL.Name = "FSSL";
            this.FSSL.Size = new System.Drawing.Size(29, 20);
            this.FSSL.Text = "0";
            this.FSSL.ToolTipText = "Selection Length";
            this.FSSL.Click += new System.EventHandler(this.FSSL_Click);
            // 
            // FSSH
            // 
            this.FSSH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FSSH.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FSSH.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FSSH.Name = "FSSH";
            this.FSSH.Size = new System.Drawing.Size(29, 20);
            this.FSSH.Text = "0";
            this.FSSH.ToolTipText = "Selection Split Position";
            this.FSSH.Click += new System.EventHandler(this.FSSH_Click);
            // 
            // BVCReverse
            // 
            this.BVCReverse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BVCReverse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BVCReverse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BVCReverse.Name = "BVCReverse";
            this.BVCReverse.Size = new System.Drawing.Size(143, 20);
            this.BVCReverse.Text = "Reverse Selection";
            this.BVCReverse.Click += new System.EventHandler(this.BVCReverse_Click);
            // 
            // LblMultiply
            // 
            this.LblMultiply.Name = "LblMultiply";
            this.LblMultiply.Size = new System.Drawing.Size(20, 16);
            this.LblMultiply.Text = "×";
            // 
            // TVCM
            // 
            this.TVCM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.TVCM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TVCM.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TVCM.Name = "TVCM";
            this.TVCM.Size = new System.Drawing.Size(60, 22);
            this.TVCM.Text = "2";
            this.TVCM.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TVCM.LostFocus += new System.EventHandler(this.TVCM_LostFocus);
            this.TVCM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TVCM_KeyDown);
            // 
            // LblDivide
            // 
            this.LblDivide.Name = "LblDivide";
            this.LblDivide.Size = new System.Drawing.Size(20, 16);
            this.LblDivide.Text = "÷";
            // 
            // TVCD
            // 
            this.TVCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.TVCD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TVCD.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TVCD.Name = "TVCD";
            this.TVCD.Size = new System.Drawing.Size(60, 22);
            this.TVCD.Text = "1";
            this.TVCD.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TVCD.LostFocus += new System.EventHandler(this.TVCD_LostFocus);
            this.TVCD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TVCD_KeyDown);
            // 
            // BVCApply
            // 
            this.BVCApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BVCApply.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BVCApply.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BVCApply.Name = "BVCApply";
            this.BVCApply.Size = new System.Drawing.Size(129, 20);
            this.BVCApply.Text = "Expand By Ratio";
            this.BVCApply.ToolTipText = "This will expand notes and selection by the ratio next to this button. Ignores ce" +
    "nter bar.";
            this.BVCApply.Click += new System.EventHandler(this.BVCApply_Click);
            // 
            // TVCBPM
            // 
            this.TVCBPM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.TVCBPM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TVCBPM.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TVCBPM.Name = "TVCBPM";
            this.TVCBPM.Size = new System.Drawing.Size(80, 22);
            this.TVCBPM.Text = "120";
            this.TVCBPM.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TVCBPM.LostFocus += new System.EventHandler(this.TVCBPM_LostFocus);
            this.TVCBPM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TVCBPM_KeyDown);
            // 
            // BVCCalculate
            // 
            this.BVCCalculate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BVCCalculate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BVCCalculate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BVCCalculate.Name = "BVCCalculate";
            this.BVCCalculate.Size = new System.Drawing.Size(142, 20);
            this.BVCCalculate.Text = "Relocate By Value";
            this.BVCCalculate.ToolTipText = "This will move notes within the selection and preserve the selection, given the B" +
    "PM value next to this button. Considers center bar.";
            this.BVCCalculate.Click += new System.EventHandler(this.BVCCalculate_Click);
            // 
            // BConvertStop
            // 
            this.BConvertStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BConvertStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BConvertStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BConvertStop.Name = "BConvertStop";
            this.BConvertStop.Size = new System.Drawing.Size(159, 20);
            this.BConvertStop.Text = "Transform Into Stop";
            this.BConvertStop.ToolTipText = "This will move notes within the selection and preserve the selection, given the B" +
    "PM value next to this button. Considers center bar.";
            this.BConvertStop.Click += new System.EventHandler(this.BConvertStop_Click);
            // 
            // FStatus
            // 
            this.FStatus.AccessibleRole = System.Windows.Forms.AccessibleRole.StatusBar;
            this.FStatus.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.FStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FSC,
            this.FSW,
            this.FSM,
            this.FSP1,
            this.FSP3,
            this.FSP2,
            this.FSP4,
            this.TimeStatusLabel,
            this.FST,
            this.FSH,
            this.FSE});
            this.FStatus.Location = new System.Drawing.Point(0, 0);
            this.FStatus.Name = "FStatus";
            this.FStatus.ShowItemToolTips = true;
            this.FStatus.Size = new System.Drawing.Size(876, 26);
            this.FStatus.SizingGrip = false;
            this.FStatus.TabIndex = 62;
            this.FStatus.Text = "Status";
            // 
            // FSC
            // 
            this.FSC.AutoSize = false;
            this.FSC.Name = "FSC";
            this.FSC.Size = new System.Drawing.Size(70, 20);
            this.FSC.Text = "BPM";
            this.FSC.ToolTipText = "Column Caption";
            // 
            // FSW
            // 
            this.FSW.AutoSize = false;
            this.FSW.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.FSW.Name = "FSW";
            this.FSW.Size = new System.Drawing.Size(40, 20);
            this.FSW.Text = "01";
            this.FSW.ToolTipText = "Note Index";
            // 
            // FSM
            // 
            this.FSM.AutoSize = false;
            this.FSM.ForeColor = System.Drawing.Color.Teal;
            this.FSM.Name = "FSM";
            this.FSM.Size = new System.Drawing.Size(40, 20);
            this.FSM.Text = "000";
            this.FSM.ToolTipText = "Measure Index";
            // 
            // FSP1
            // 
            this.FSP1.AutoSize = false;
            this.FSP1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FSP1.Name = "FSP1";
            this.FSP1.Size = new System.Drawing.Size(170, 20);
            this.FSP1.Text = "9.41176470588235 / 9999";
            this.FSP1.ToolTipText = "Grid Resolution";
            // 
            // FSP3
            // 
            this.FSP3.AutoSize = false;
            this.FSP3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FSP3.ForeColor = System.Drawing.Color.Maroon;
            this.FSP3.Name = "FSP3";
            this.FSP3.Size = new System.Drawing.Size(85, 20);
            this.FSP3.Text = "9999 / 9999";
            this.FSP3.ToolTipText = "Reduced Resolution";
            // 
            // FSP2
            // 
            this.FSP2.AutoSize = false;
            this.FSP2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FSP2.ForeColor = System.Drawing.Color.Green;
            this.FSP2.Name = "FSP2";
            this.FSP2.Size = new System.Drawing.Size(170, 20);
            this.FSP2.Text = "112.941176470588 / 9999";
            this.FSP2.ToolTipText = "Measure Resolution";
            // 
            // FSP4
            // 
            this.FSP4.AutoSize = false;
            this.FSP4.Name = "FSP4";
            this.FSP4.Size = new System.Drawing.Size(115, 20);
            this.FSP4.Text = "112.941176470588";
            this.FSP4.ToolTipText = "Absolute Position";
            // 
            // TimeStatusLabel
            // 
            this.TimeStatusLabel.Name = "TimeStatusLabel";
            this.TimeStatusLabel.Size = new System.Drawing.Size(80, 20);
            this.TimeStatusLabel.Text = "00:00:000";
            // 
            // FST
            // 
            this.FST.ForeColor = System.Drawing.Color.Olive;
            this.FST.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.FST.Name = "FST";
            this.FST.Size = new System.Drawing.Size(88, 20);
            this.FST.Text = "Length = 0";
            // 
            // FSH
            // 
            this.FSH.ForeColor = System.Drawing.Color.Blue;
            this.FSH.Name = "FSH";
            this.FSH.Size = new System.Drawing.Size(63, 20);
            this.FSH.Text = "Hidden";
            // 
            // FSE
            // 
            this.FSE.ForeColor = System.Drawing.Color.Red;
            this.FSE.Name = "FSE";
            this.FSE.Size = new System.Drawing.Size(45, 20);
            this.FSE.Text = "Error";
            // 
            // TimerMiddle
            // 
            this.TimerMiddle.Interval = 15;
            this.TimerMiddle.Tick += new System.EventHandler(this.TimerMiddle_Tick);
            // 
            // ToolStripContainer1
            // 
            // 
            // ToolStripContainer1.ContentPanel
            // 
            this.ToolStripContainer1.ContentPanel.Controls.Add(this.PMain);
            this.ToolStripContainer1.ContentPanel.Controls.Add(this.SpR);
            this.ToolStripContainer1.ContentPanel.Controls.Add(this.SpL);
            this.ToolStripContainer1.ContentPanel.Controls.Add(this.PMainR);
            this.ToolStripContainer1.ContentPanel.Controls.Add(this.PMainL);
            this.ToolStripContainer1.ContentPanel.Size = new System.Drawing.Size(876, 649);
            this.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.ToolStripContainer1.Name = "ToolStripContainer1";
            this.ToolStripContainer1.Size = new System.Drawing.Size(876, 704);
            this.ToolStripContainer1.TabIndex = 65;
            this.ToolStripContainer1.Text = "ToolStripContainer1";
            // 
            // ToolStripContainer1.TopToolStripPanel
            // 
            this.ToolStripContainer1.TopToolStripPanel.Controls.Add(this.TBMain);
            this.ToolStripContainer1.TopToolStripPanel.Controls.Add(this.mnMain);
            // 
            // PMain
            // 
            this.PMain.BackColor = System.Drawing.Color.Black;
            this.PMain.Controls.Add(this.PMainIn);
            this.PMain.Controls.Add(this.MainPanelScroll);
            this.PMain.Controls.Add(this.HS);
            this.PMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PMain.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PMain.ForeColor = System.Drawing.Color.White;
            this.PMain.Location = new System.Drawing.Point(5, 0);
            this.PMain.Name = "PMain";
            this.PMain.Size = new System.Drawing.Size(866, 649);
            this.PMain.TabIndex = 58;
            this.PMain.Tag = "1";
            // 
            // PMainIn
            // 
            this.PMainIn.BackColor = System.Drawing.Color.Black;
            this.PMainIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PMainIn.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PMainIn.ForeColor = System.Drawing.Color.White;
            this.PMainIn.Location = new System.Drawing.Point(0, 0);
            this.PMainIn.Name = "PMainIn";
            this.PMainIn.Size = new System.Drawing.Size(849, 632);
            this.PMainIn.TabIndex = 0;
            this.PMainIn.TabStop = true;
            this.PMainIn.Tag = "1";
            this.PMainIn.Paint += new System.Windows.Forms.PaintEventHandler(this.PMainInPaint);
            this.PMainIn.LostFocus += new System.EventHandler(this.PMainInLostFocus);
            this.PMainIn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PMainInMouseDown);
            this.PMainIn.MouseEnter += new System.EventHandler(this.PMainInMouseEnter);
            this.PMainIn.MouseLeave += new System.EventHandler(this.PMainInMouseLeave);
            this.PMainIn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PMainInMouseMove);
            this.PMainIn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PMainInMouseUp);
            this.PMainIn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.PMainInMouseWheel);
            this.PMainIn.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.PMainInPreviewKeyDown);
            this.PMainIn.Resize += new System.EventHandler(this.PMainInResize);
            // 
            // MainPanelScroll
            // 
            this.MainPanelScroll.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.MainPanelScroll.Dock = System.Windows.Forms.DockStyle.Right;
            this.MainPanelScroll.LargeChange = 592;
            this.MainPanelScroll.Location = new System.Drawing.Point(849, 0);
            this.MainPanelScroll.Maximum = 591;
            this.MainPanelScroll.Minimum = -10000;
            this.MainPanelScroll.Name = "MainPanelScroll";
            this.MainPanelScroll.Size = new System.Drawing.Size(17, 632);
            this.MainPanelScroll.SmallChange = 12;
            this.MainPanelScroll.TabIndex = 2;
            this.MainPanelScroll.Tag = "1";
            this.MainPanelScroll.ValueChanged += new System.EventHandler(this.VSValueChanged);
            this.MainPanelScroll.GotFocus += new System.EventHandler(this.VSGotFocus);
            // 
            // HS
            // 
            this.HS.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.HS.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.HS.LargeChange = 777;
            this.HS.Location = new System.Drawing.Point(0, 632);
            this.HS.Maximum = 1233;
            this.HS.Name = "HS";
            this.HS.Size = new System.Drawing.Size(866, 17);
            this.HS.TabIndex = 3;
            this.HS.Tag = "1";
            this.HS.ValueChanged += new System.EventHandler(this.HSValueChanged);
            this.HS.GotFocus += new System.EventHandler(this.HSGotFocus);
            // 
            // SpR
            // 
            this.SpR.Dock = System.Windows.Forms.DockStyle.Right;
            this.SpR.FlatAppearance.BorderSize = 0;
            this.SpR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SpR.Location = new System.Drawing.Point(871, 0);
            this.SpR.Name = "SpR";
            this.SpR.Size = new System.Drawing.Size(5, 649);
            this.SpR.TabIndex = 59;
            this.SpR.TabStop = false;
            this.SpR.UseVisualStyleBackColor = true;
            this.SpR.Visible = false;
            this.SpR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HorizontalResizer_MouseDown);
            this.SpR.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SpR_MouseMove);
            // 
            // SpL
            // 
            this.SpL.Dock = System.Windows.Forms.DockStyle.Left;
            this.SpL.FlatAppearance.BorderSize = 0;
            this.SpL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SpL.Location = new System.Drawing.Point(0, 0);
            this.SpL.Name = "SpL";
            this.SpL.Size = new System.Drawing.Size(5, 649);
            this.SpL.TabIndex = 60;
            this.SpL.TabStop = false;
            this.SpL.UseVisualStyleBackColor = true;
            this.SpL.Visible = false;
            this.SpL.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HorizontalResizer_MouseDown);
            this.SpL.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SpL_MouseMove);
            // 
            // PMainR
            // 
            this.PMainR.BackColor = System.Drawing.Color.Black;
            this.PMainR.Controls.Add(this.PMainInR);
            this.PMainR.Controls.Add(this.RightPanelScroll);
            this.PMainR.Controls.Add(this.HSR);
            this.PMainR.Dock = System.Windows.Forms.DockStyle.Right;
            this.PMainR.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PMainR.ForeColor = System.Drawing.Color.White;
            this.PMainR.Location = new System.Drawing.Point(876, 0);
            this.PMainR.Name = "PMainR";
            this.PMainR.Size = new System.Drawing.Size(0, 649);
            this.PMainR.TabIndex = 56;
            this.PMainR.Tag = "2";
            // 
            // PMainInR
            // 
            this.PMainInR.BackColor = System.Drawing.Color.Black;
            this.PMainInR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PMainInR.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PMainInR.ForeColor = System.Drawing.Color.White;
            this.PMainInR.Location = new System.Drawing.Point(0, 0);
            this.PMainInR.Name = "PMainInR";
            this.PMainInR.Size = new System.Drawing.Size(0, 632);
            this.PMainInR.TabIndex = 0;
            this.PMainInR.TabStop = true;
            this.PMainInR.Tag = "2";
            this.PMainInR.Paint += new System.Windows.Forms.PaintEventHandler(this.PMainInPaint);
            this.PMainInR.LostFocus += new System.EventHandler(this.PMainInLostFocus);
            this.PMainInR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PMainInMouseDown);
            this.PMainInR.MouseEnter += new System.EventHandler(this.PMainInMouseEnter);
            this.PMainInR.MouseLeave += new System.EventHandler(this.PMainInMouseLeave);
            this.PMainInR.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PMainInMouseMove);
            this.PMainInR.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PMainInMouseUp);
            this.PMainInR.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.PMainInMouseWheel);
            this.PMainInR.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.PMainInPreviewKeyDown);
            this.PMainInR.Resize += new System.EventHandler(this.PMainInResize);
            // 
            // RightPanelScroll
            // 
            this.RightPanelScroll.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightPanelScroll.LargeChange = 592;
            this.RightPanelScroll.Location = new System.Drawing.Point(-17, 0);
            this.RightPanelScroll.Maximum = 591;
            this.RightPanelScroll.Minimum = -10000;
            this.RightPanelScroll.Name = "RightPanelScroll";
            this.RightPanelScroll.Size = new System.Drawing.Size(17, 632);
            this.RightPanelScroll.SmallChange = 12;
            this.RightPanelScroll.TabIndex = 2;
            this.RightPanelScroll.Tag = "2";
            this.RightPanelScroll.ValueChanged += new System.EventHandler(this.VSValueChanged);
            this.RightPanelScroll.GotFocus += new System.EventHandler(this.VSGotFocus);
            // 
            // HSR
            // 
            this.HSR.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.HSR.LargeChange = 777;
            this.HSR.Location = new System.Drawing.Point(0, 632);
            this.HSR.Maximum = 1233;
            this.HSR.Name = "HSR";
            this.HSR.Size = new System.Drawing.Size(0, 17);
            this.HSR.TabIndex = 3;
            this.HSR.Tag = "2";
            this.HSR.ValueChanged += new System.EventHandler(this.HSValueChanged);
            this.HSR.GotFocus += new System.EventHandler(this.HSGotFocus);
            // 
            // PMainL
            // 
            this.PMainL.BackColor = System.Drawing.Color.Black;
            this.PMainL.Controls.Add(this.PMainInL);
            this.PMainL.Controls.Add(this.LeftPanelScroll);
            this.PMainL.Controls.Add(this.HSL);
            this.PMainL.Dock = System.Windows.Forms.DockStyle.Left;
            this.PMainL.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PMainL.ForeColor = System.Drawing.Color.White;
            this.PMainL.Location = new System.Drawing.Point(0, 0);
            this.PMainL.Name = "PMainL";
            this.PMainL.Size = new System.Drawing.Size(0, 649);
            this.PMainL.TabIndex = 54;
            this.PMainL.Tag = "0";
            // 
            // PMainInL
            // 
            this.PMainInL.BackColor = System.Drawing.Color.Black;
            this.PMainInL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PMainInL.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PMainInL.ForeColor = System.Drawing.Color.White;
            this.PMainInL.Location = new System.Drawing.Point(0, 0);
            this.PMainInL.Name = "PMainInL";
            this.PMainInL.Size = new System.Drawing.Size(0, 632);
            this.PMainInL.TabIndex = 0;
            this.PMainInL.TabStop = true;
            this.PMainInL.Tag = "0";
            this.PMainInL.Paint += new System.Windows.Forms.PaintEventHandler(this.PMainInPaint);
            this.PMainInL.LostFocus += new System.EventHandler(this.PMainInLostFocus);
            this.PMainInL.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PMainInMouseDown);
            this.PMainInL.MouseEnter += new System.EventHandler(this.PMainInMouseEnter);
            this.PMainInL.MouseLeave += new System.EventHandler(this.PMainInMouseLeave);
            this.PMainInL.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PMainInMouseMove);
            this.PMainInL.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PMainInMouseUp);
            this.PMainInL.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.PMainInMouseWheel);
            this.PMainInL.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.PMainInPreviewKeyDown);
            this.PMainInL.Resize += new System.EventHandler(this.PMainInResize);
            // 
            // LeftPanelScroll
            // 
            this.LeftPanelScroll.Dock = System.Windows.Forms.DockStyle.Right;
            this.LeftPanelScroll.LargeChange = 592;
            this.LeftPanelScroll.Location = new System.Drawing.Point(-17, 0);
            this.LeftPanelScroll.Maximum = 591;
            this.LeftPanelScroll.Minimum = -10000;
            this.LeftPanelScroll.Name = "LeftPanelScroll";
            this.LeftPanelScroll.Size = new System.Drawing.Size(17, 632);
            this.LeftPanelScroll.SmallChange = 12;
            this.LeftPanelScroll.TabIndex = 2;
            this.LeftPanelScroll.Tag = "0";
            this.LeftPanelScroll.ValueChanged += new System.EventHandler(this.VSValueChanged);
            this.LeftPanelScroll.GotFocus += new System.EventHandler(this.VSGotFocus);
            // 
            // HSL
            // 
            this.HSL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.HSL.LargeChange = 777;
            this.HSL.Location = new System.Drawing.Point(0, 632);
            this.HSL.Maximum = 1233;
            this.HSL.Name = "HSL";
            this.HSL.Size = new System.Drawing.Size(0, 17);
            this.HSL.TabIndex = 3;
            this.HSL.Tag = "0";
            this.HSL.ValueChanged += new System.EventHandler(this.HSValueChanged);
            this.HSL.GotFocus += new System.EventHandler(this.HSGotFocus);
            // 
            // POptionsResizer
            // 
            this.POptionsResizer.AutoSize = true;
            this.POptionsResizer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.POptionsResizer.Dock = System.Windows.Forms.DockStyle.Right;
            this.POptionsResizer.FlatAppearance.BorderSize = 0;
            this.POptionsResizer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.POptionsResizer.Location = new System.Drawing.Point(876, 0);
            this.POptionsResizer.Name = "POptionsResizer";
            this.POptionsResizer.Size = new System.Drawing.Size(6, 730);
            this.POptionsResizer.TabIndex = 67;
            this.POptionsResizer.TabStop = false;
            this.POptionsResizer.UseVisualStyleBackColor = true;
            this.POptionsResizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HorizontalResizer_MouseDown);
            this.POptionsResizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.POptionsResizer_MouseMove);
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1082, 730);
            this.Controls.Add(this.ToolStripContainer1);
            this.Controls.Add(this.pStatus);
            this.Controls.Add(this.POptionsResizer);
            this.Controls.Add(this.POptionsScroll);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.mnMain;
            this.Name = "MainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.DragLeave += new System.EventHandler(this.Form1_DragLeave);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.Disposed += new System.EventHandler(this.Unload);
            this.cmnLanguage.ResumeLayout(false);
            this.cmnTheme.ResumeLayout(false);
            this.POptionsScroll.ResumeLayout(false);
            this.POptionsScroll.PerformLayout();
            this.POptions.ResumeLayout(false);
            this.POptions.PerformLayout();
            this.POExpansion.ResumeLayout(false);
            this.POExpansionInner.ResumeLayout(false);
            this.POExpansionInner.PerformLayout();
            this.POBeat.ResumeLayout(false);
            this.POBeatInner.ResumeLayout(false);
            this.POBeatInner.PerformLayout();
            this.TableLayoutPanel7.ResumeLayout(false);
            this.TableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nBeatD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nBeatN)).EndInit();
            this.POBeatPart2.ResumeLayout(false);
            this.POBeatPart2.PerformLayout();
            this.POBMP.ResumeLayout(false);
            this.POBMPInner.ResumeLayout(false);
            this.POBMPInner.PerformLayout();
            this.FlowLayoutPanel4.ResumeLayout(false);
            this.POWAV.ResumeLayout(false);
            this.POWAVInner.ResumeLayout(false);
            this.POWAVInner.PerformLayout();
            this.FlowLayoutPanel3.ResumeLayout(false);
            this.POWAVPart2.ResumeLayout(false);
            this.POWAVPart2.PerformLayout();
            this.POWaveForm.ResumeLayout(false);
            this.POWaveForm.PerformLayout();
            this.POWaveFormInner.ResumeLayout(false);
            this.POWaveFormInner.PerformLayout();
            this.POWaveFormPart2.ResumeLayout(false);
            this.POWaveFormPart2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TWSaturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TWTransparency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TWPrecision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TWWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TWLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TWSaturation2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TWLeft2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TWTransparency2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TWWidth2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TWPrecision2)).EndInit();
            this.POWaveFormPart1.ResumeLayout(false);
            this.POWaveFormPart1.PerformLayout();
            this.TableLayoutPanel1.ResumeLayout(false);
            this.TableLayoutPanel1.PerformLayout();
            this.FlowLayoutPanel1.ResumeLayout(false);
            this.TableLayoutPanel6.ResumeLayout(false);
            this.TableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TWPosition2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TWPosition)).EndInit();
            this.POGrid.ResumeLayout(false);
            this.POGrid.PerformLayout();
            this.POGridInner.ResumeLayout(false);
            this.POGridInner.PerformLayout();
            this.POGridPart2.ResumeLayout(false);
            this.POGridPart2.PerformLayout();
            this.TableLayoutPanel5.ResumeLayout(false);
            this.TableLayoutPanel5.PerformLayout();
            this.FlowLayoutPanel2.ResumeLayout(false);
            this.TableLayoutPanel4.ResumeLayout(false);
            this.TableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CGB)).EndInit();
            this.POGridPart1.ResumeLayout(false);
            this.POGridPart1.PerformLayout();
            this.TableLayoutPanel3.ResumeLayout(false);
            this.TableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CGHeight2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CGHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CGWidth2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CGWidth)).EndInit();
            this.TableLayoutPanel2.ResumeLayout(false);
            this.TableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CGDivide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CGSub)).EndInit();
            this.POHeader.ResumeLayout(false);
            this.POHeader.PerformLayout();
            this.POHeaderInner.ResumeLayout(false);
            this.POHeaderInner.PerformLayout();
            this.POHeaderPart2.ResumeLayout(false);
            this.POHeaderPart2.PerformLayout();
            this.POHeaderPart1.ResumeLayout(false);
            this.POHeaderPart1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.THBPM)).EndInit();
            this.Menu1.ResumeLayout(false);
            this.mnMain.ResumeLayout(false);
            this.mnMain.PerformLayout();
            this.cmnConversion.ResumeLayout(false);
            this.TBMain.ResumeLayout(false);
            this.TBMain.PerformLayout();
            this.pStatus.ResumeLayout(false);
            this.pStatus.PerformLayout();
            this.FStatus2.ResumeLayout(false);
            this.FStatus2.PerformLayout();
            this.FStatus.ResumeLayout(false);
            this.FStatus.PerformLayout();
            this.ToolStripContainer1.ContentPanel.ResumeLayout(false);
            this.ToolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer1.TopToolStripPanel.PerformLayout();
            this.ToolStripContainer1.ResumeLayout(false);
            this.ToolStripContainer1.PerformLayout();
            this.PMain.ResumeLayout(false);
            this.PMainR.ResumeLayout(false);
            this.PMainL.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal Panel POptionsScroll;
        internal ListBox LWAV;
        internal ListBox LBMP;
        internal System.Windows.Forms.Timer Timer1;
        internal ToolStripMenuItem MInsert;
        internal ToolStripMenuItem MRemove;
        internal ContextMenuStrip Menu1;
        internal System.Windows.Forms.Timer AutoSaveTimer;
        internal MenuStrip mnMain;
        internal ToolStripMenuItem mnFile;
        internal ToolStripMenuItem mnNew;
        internal ToolStripMenuItem mnOpen;
        internal ToolStripMenuItem mnImportSM;
        internal ToolStripMenuItem mnImportIBMSC;
        internal ToolStripSeparator ToolStripSeparator14;
        internal ToolStripMenuItem mnSave;
        internal ToolStripMenuItem mnSaveAs;
        internal ToolStripMenuItem mnExport;
        internal ToolStripSeparator ToolStripSeparator15;
        internal ToolStripMenuItem mnOpenR0;
        internal ToolStripMenuItem mnOpenR1;
        internal ToolStripMenuItem mnOpenR2;
        internal ToolStripMenuItem mnOpenR3;
        internal ToolStripMenuItem mnOpenR4;
        internal ToolStripSeparator ToolStripSeparator16;
        internal ToolStripMenuItem mnQuit;
        internal ToolStripMenuItem mnEdit;
        internal ToolStripMenuItem mnUndo;
        internal ToolStripMenuItem mnRedo;
        internal ToolStripSeparator ToolStripSeparator17;
        internal ToolStripMenuItem mnCut;
        internal ToolStripMenuItem mnCopy;
        internal ToolStripMenuItem mnPaste;
        internal ToolStripSeparator ToolStripSeparator18;
        internal ToolStripMenuItem mnFind;
        internal ToolStripMenuItem mnStatistics;
        internal ToolStripMenuItem mnDelete;
        internal ToolStripMenuItem mnSelectAll;
        internal ToolStripMenuItem mnMyO2;
        internal ToolStripSeparator ToolStripSeparator19;
        internal ToolStripMenuItem mnOptions;
        internal ToolStripMenuItem mnPreview;
        internal ToolStripMenuItem mnPlayB;
        internal ToolStripMenuItem mnPlay;
        internal ToolStripMenuItem mnStop;
        internal ToolStripMenuItem mnTimeSelect;
        internal ToolStripMenuItem mnSelect;
        internal ToolStripMenuItem mnWrite;
        internal ToolStripSeparator ToolStripSeparator23;
        internal ToolStripMenuItem mnConversion;
        internal ToolStripMenuItem mnErrorCheck;
        internal ToolStripMenuItem mnPreviewOnClick;
        internal ToolStripMenuItem mnShowFileName;
        internal ToolStripSeparator ToolStripSeparator20;
        internal ToolStripMenuItem mnGOptions;
        internal ToolStripMenuItem mnVOptions;
        internal ToolStripMenuItem mnLanguage;
        internal ToolStripMenuItem mnTheme;
        internal ContextMenuStrip cmnLanguage;
        internal ToolStripMenuItem TBLangDef;
        internal ToolStripSeparator ToolStripSeparator9;
        internal ContextMenuStrip cmnTheme;
        internal ToolStripMenuItem TBThemeDef;
        internal ToolStripMenuItem TBThemeSave;
        internal ToolStripMenuItem TBThemeRefresh;
        internal ToolStripSeparator ToolStripSeparator6;
        internal ContextMenuStrip cmnConversion;
        internal ToolStripMenuItem POBLong;
        internal ToolStripMenuItem POBShort;
        internal ToolStripMenuItem POBLongShort;
        internal ToolStripSeparator ToolStripSeparator10;
        internal ToolStripMenuItem POBHidden;
        internal ToolStripMenuItem POBVisible;
        internal ToolStripMenuItem POBHiddenVisible;
        internal ToolStripSeparator ToolStripSeparator11;
        internal ToolStripMenuItem POBMirror;
        internal ToolStripMenuItem POBModify;
        internal ToolStripMenuItem mnSys;
        internal ToolStripMenuItem mnSMenu;
        internal ToolStripMenuItem mnSTB;
        internal ToolStripMenuItem mnSOP;
        internal ToolStripMenuItem mnSStatus;
        internal ToolStripMenuItem mnSLSplitter;
        internal ToolStripMenuItem mnSRSplitter;
        internal ToolStripMenuItem mnNTInput;
        internal ToolStripMenuItem TBLangRefresh;
        internal NumericUpDown CGSub;
        internal NumericUpDown CGDivide;
        internal PictureBox PictureBox7;
        internal CheckBox CGSnap;
        internal CheckBox BWLock;
        internal NumericUpDown TWSaturation;
        internal NumericUpDown TWTransparency;
        internal NumericUpDown TWPrecision;
        internal NumericUpDown TWWidth;
        internal NumericUpDown TWLeft;
        internal NumericUpDown TWPosition;
        internal PictureBox PictureBox5;
        internal PictureBox PictureBox6;
        internal PictureBox PictureBox4;
        internal PictureBox PictureBox3;
        internal PictureBox PictureBox2;
        internal PictureBox PictureBox1;
        internal TrackBar TWSaturation2;
        internal TrackBar TWTransparency2;
        internal TrackBar TWPrecision2;
        internal TrackBar TWWidth2;
        internal TrackBar TWLeft2;
        internal TrackBar TWPosition2;
        internal TextBox TWFileName;
        internal Button BWClear;
        internal Button BWLoad;
        internal ToolStrip TBMain;
        internal ToolStripButton TBNew;
        internal ToolStripSplitButton TBOpen;
        internal ToolStripMenuItem TBOpenR0;
        internal ToolStripMenuItem TBOpenR1;
        internal ToolStripMenuItem TBOpenR2;
        internal ToolStripMenuItem TBOpenR3;
        internal ToolStripMenuItem TBOpenR4;
        internal ToolStripSeparator ToolStripSeparator12;
        internal ToolStripMenuItem TBImportSM;
        internal ToolStripMenuItem TBImportIBMSC;
        internal ToolStripSplitButton TBSave;
        internal ToolStripMenuItem TBSaveAs;
        internal ToolStripMenuItem TBExport;
        internal ToolStripSeparator ToolStripSeparator1;
        internal ToolStripButton TBCut;
        internal ToolStripButton TBCopy;
        internal ToolStripButton TBPaste;
        internal ToolStripButton TBFind;
        internal ToolStripButton TBStatistics;
        internal Panel pStatus;
        internal StatusStrip FStatus;
        internal ToolStripStatusLabel FSC;
        internal ToolStripStatusLabel FSP1;
        internal ToolStripStatusLabel FSP2;
        internal ToolStripStatusLabel FSP3;
        internal ToolStripStatusLabel FSP4;
        internal ToolStripStatusLabel FST;
        internal ToolStripStatusLabel FSH;
        internal ToolStripStatusLabel FSE;
        internal StatusStrip FStatus2;
        internal ToolStripButton BVCReverse;
        internal ToolStripStatusLabel LblMultiply;
        internal ToolStripTextBox TVCBPM;
        internal ToolStripTextBox TVCM;
        internal ToolStripStatusLabel LblDivide;
        internal ToolStripTextBox TVCD;
        internal ToolStripButton BVCApply;
        internal ToolStripButton BVCCalculate;
        internal ToolStripStatusLabel FSW;
        internal ToolStripButton FSSS;
        internal ToolStripButton FSSL;
        internal ToolStripButton FSSH;
        internal TextBox TExpansion;
        internal System.Windows.Forms.Timer TimerMiddle;
        internal ToolStripSeparator ToolStripSeparator21;
        internal ToolStripMenuItem CGShow;
        internal ToolStripMenuItem CGShowS;
        internal ToolStripMenuItem CGShowBG;
        internal ToolStripMenuItem CGShowM;
        internal ToolStripMenuItem CGShowMB;
        internal ToolStripMenuItem CGShowV;
        internal ToolStripMenuItem CGShowC;
        internal ToolStripSeparator ToolStripSeparator22;
        internal ToolStripMenuItem CGBLP;
        internal ToolStripMenuItem CGSTOP;
        internal ToolStripMenuItem CGSCROLL;
        internal NumericUpDown nBeatN;
        internal ListBox LBeat;
        internal Label Label7;
        internal Button BBeatApply;
        internal ToolStripMenuItem mnPOptions;
        internal ToolStripContainer ToolStripContainer1;
        internal Panel PMain;
        internal Panel PMainIn;
        internal VScrollBar MainPanelScroll;
        internal HScrollBar HS;
        internal Panel PMainR;
        internal Panel PMainInR;
        internal VScrollBar RightPanelScroll;
        internal HScrollBar HSR;
        internal Panel PMainL;
        internal Panel PMainInL;
        internal VScrollBar LeftPanelScroll;
        internal HScrollBar HSL;
        internal ToolStripDropDownButton POConvert;
        internal ToolStripDropDownButton TBLanguage;
        internal ToolStripDropDownButton TBTheme;
        internal ToolStripButton TBMyO2;
        internal ToolStripSeparator ToolStripSeparator4;
        internal ToolStripButton TBErrorCheck;
        internal ToolStripButton TBPreviewOnClick;
        internal ToolStripButton TBShowFileName;
        internal ToolStripSeparator ToolStripSeparator2;
        internal ToolStripButton TBUndo;
        internal ToolStripButton TBRedo;
        internal ToolStripSeparator ToolStripSeparator5;
        internal ToolStripButton TBNTInput;
        internal ToolStripButton TBTimeSelect;
        internal ToolStripButton TBSelect;
        internal ToolStripButton TBWrite;
        internal ToolStripSeparator ToolStripSeparator3;
        internal ToolStripButton TBPlayB;
        internal ToolStripButton TBPlay;
        internal ToolStripButton TBStop;
        internal ToolStripButton TBPOptions;
        internal ToolStripSeparator ToolStripSeparator7;
        internal ToolStripButton TBVOptions;
        internal ToolStripButton TBGOptions;
        internal ToolStripButton POBStorm;
        internal Panel POptions;
        internal Panel POHeader;
        internal CheckBox POHeaderSwitch;
        internal Panel POGrid;
        internal CheckBox POGridSwitch;
        internal Panel POHeaderInner;
        internal TableLayoutPanel POHeaderPart2;
        internal TextBox THExRank;
        internal Label Label25;
        internal ComboBox CHLnObj;
        internal Label Label23;
        internal Label Label21;
        internal TextBox THComment;
        internal Label Label24;
        internal Label Label15;
        internal TextBox THTotal;
        internal Label Label20;
        internal Button BHStageFile;
        internal Button BHBanner;
        internal Label Label19;
        internal Button BHBackBMP;
        internal Label Label17;
        internal Label Label16;
        internal Label Label12;
        internal TextBox THBackBMP;
        internal Label Label11;
        internal TextBox THBanner;
        internal TextBox THStageFile;
        internal TextBox THSubTitle;
        internal TextBox THSubArtist;
        internal CheckBox POHeaderExpander;
        internal TableLayoutPanel POHeaderPart1;
        internal Label Label3;
        internal TextBox THPlayLevel;
        internal ComboBox CHRank;
        internal Label Label10;
        internal ComboBox CHPlayer;
        internal ComboBox CHDifficulty;
        internal Label Label4;
        internal TextBox THGenre;
        internal NumericUpDown THBPM;
        internal Label Label2;
        internal TextBox THArtist;
        internal TextBox THTitle;
        internal Label Label9;
        internal Label Label8;
        internal Label Label6;
        internal TableLayoutPanel POGridPart1;
        internal TableLayoutPanel TableLayoutPanel2;
        internal Panel POGridInner;
        internal TableLayoutPanel POGridPart2;
        internal TableLayoutPanel TableLayoutPanel5;
        internal CheckBox cVSLockR;
        internal Label Label5;
        internal CheckBox cVSLock;
        internal CheckBox cVSLockL;
        internal CheckBox CGDisableVertical;
        internal TableLayoutPanel TableLayoutPanel4;
        internal Label Label1;
        internal NumericUpDown CGB;
        internal CheckBox POGridExpander;
        internal TableLayoutPanel TableLayoutPanel3;
        internal PictureBox PictureBox9;
        internal TrackBar CGHeight2;
        internal NumericUpDown CGHeight;
        internal PictureBox PictureBox10;
        internal TrackBar CGWidth2;
        internal NumericUpDown CGWidth;
        internal Panel POWaveForm;
        internal CheckBox POWaveFormSwitch;
        internal Panel POWaveFormInner;
        internal TableLayoutPanel POWaveFormPart2;
        internal CheckBox POWaveFormExpander;
        internal TableLayoutPanel POWaveFormPart1;
        internal TableLayoutPanel TableLayoutPanel1;
        internal TableLayoutPanel TableLayoutPanel6;
        internal FlowLayoutPanel FlowLayoutPanel1;
        internal FlowLayoutPanel FlowLayoutPanel2;
        internal Panel POWAV;
        internal TableLayoutPanel POWAVInner;
        internal CheckBox POWAVSwitch;
        internal Panel POBMP;
        internal TableLayoutPanel POBMPInner;
        internal CheckBox POBMPSwitch;
        internal Panel POBeat;
        internal TableLayoutPanel POBeatInner;
        internal CheckBox POBeatSwitch;
        internal FlowLayoutPanel FlowLayoutPanel3;
        internal FlowLayoutPanel FlowLayoutPanel4;
        internal Button BWAVUp;
        internal Button BWAVDown;
        internal Button BWAVBrowse;
        internal Button BWAVRemove;
        internal Button BBMPUp;
        internal Button BBMPDown;
        internal Button BBMPBrowse;
        internal Button BBMPRemove;
        internal Panel POExpansion;
        internal Panel POExpansionInner;
        internal CheckBox POExpansionSwitch;
        internal Button POWAVResizer;
        internal Button POBMPResizer;
        internal TableLayoutPanel TableLayoutPanel7;
        internal Button POExpansionResizer;
        internal Button POBeatResizer;
        internal Button POptionsResizer;
        internal Button SpR;
        internal Button SpL;
        internal ToolStripMenuItem TBThemeLoadComptability;
        internal CheckBox POWAVExpander;
        internal TableLayoutPanel POWAVPart2;
        internal CheckBox CWAVMultiSelect;
        internal CheckBox CWAVChangeLabel;
        internal NumericUpDown nBeatD;
        internal Button BBeatApplyV;
        internal TextBox tBeatValue;
        internal CheckBox POBeatExpander;
        internal TableLayoutPanel POBeatPart2;
        internal RadioButton CBeatScale;
        internal RadioButton CBeatCut;
        internal RadioButton CBeatMeasure;
        internal RadioButton CBeatPreserve;
        internal Label Label13;
        internal ToolTip ToolTipUniversal;
        internal ToolStripMenuItem CGBPM;
        internal Button BGSlash;
        internal ToolStripStatusLabel FSM;
        internal ToolStripMenuItem mnGotoMeasure;
        internal ToolStripSeparator ToolStripSeparator24;
        internal ToolStripSeparator ToolStripSeparator8;
        internal ToolStripButton TBWavIncrease;
        internal ToolStripStatusLabel TimeStatusLabel;
        internal ToolStripButton BConvertStop;
    }
}