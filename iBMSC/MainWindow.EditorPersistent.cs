using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using iBMSC.Editor;
using iBMSC.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace iBMSC;

public partial class MainWindow
{
    private void XMLWriteColumn(XmlTextWriter w, int I)
    {
        w.WriteStartElement("Column");
        w.WriteAttributeString("Index", Conversions.ToString(I));
        Column[] array = column;
        //w.WriteAttributeString("Left", .Left)
        w.WriteAttributeString("Width", Conversions.ToString(array[I].Width));
        w.WriteAttributeString("Title", array[I].Title);
        //w.WriteAttributeString("Text", .Text)
        //w.WriteAttributeString("Enabled", .Enabled)
        //w.WriteAttributeString("isNumeric", .isNumeric)
        //w.WriteAttributeString("Visible", .Visible)
        //w.WriteAttributeString("Identifier", .Identifier)
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

    private void SaveSettings(string Path, bool ThemeOnly)
    {
        var w = new XmlTextWriter(Path, Encoding.Unicode);
        w.WriteStartDocument();
        w.Formatting = Formatting.Indented;
        w.Indentation = 4;
        w.WriteStartElement("iBMSC");
        w.WriteAttributeString("Major", Conversions.ToString(MyProject.Application.Info.Version.Major));
        w.WriteAttributeString("Minor", Conversions.ToString(MyProject.Application.Info.Version.Minor));
        w.WriteAttributeString("Build", Conversions.ToString(MyProject.Application.Info.Version.Build));

        if (!ThemeOnly)
        {
            w.WriteStartElement("Form");
            w.WriteAttributeString("WindowState", Conversions.ToString(Interaction.IIf(isFullScreen, previousWindowState, WindowState)));
            w.WriteAttributeString("Width", Conversions.ToString(Interaction.IIf(isFullScreen, previousWindowPosition.Width, Width)));
            w.WriteAttributeString("Height", Conversions.ToString(Interaction.IIf(isFullScreen, previousWindowPosition.Height, Height)));
            w.WriteAttributeString("Top", Conversions.ToString(Interaction.IIf(isFullScreen, previousWindowPosition.Top, Top)));
            w.WriteAttributeString("Left", Conversions.ToString(Interaction.IIf(isFullScreen, previousWindowPosition.Left, Left)));
            w.WriteEndElement();

            w.WriteStartElement("Recent");
            w.WriteAttributeString("Recent0", Recent[0]);
            w.WriteAttributeString("Recent1", Recent[1]);
            w.WriteAttributeString("Recent2", Recent[2]);
            w.WriteAttributeString("Recent3", Recent[3]);
            w.WriteAttributeString("Recent4", Recent[4]);
            w.WriteEndElement();

            w.WriteStartElement("Edit");
            w.WriteAttributeString("NTInput", Conversions.ToString(NTInput));
            w.WriteAttributeString("Language", DispLang);
            //.WriteAttributeString("SortingMethod", SortingMethod)
            w.WriteAttributeString("ErrorCheck", Conversions.ToString(ErrorCheck));
            w.WriteAttributeString("AutoFocusMouseEnter", Conversions.ToString(AutoFocusMouseEnter));
            w.WriteAttributeString("FirstClickDisabled", Conversions.ToString(FirstClickDisabled));
            w.WriteAttributeString("ShowFileName", Conversions.ToString(ShowFileName));
            w.WriteAttributeString("MiddleButtonMoveMethod", Conversions.ToString(MiddleButtonMoveMethod));
            w.WriteAttributeString("AutoSaveInterval", Conversions.ToString(AutoSaveInterval));
            w.WriteAttributeString("PreviewOnClick", Conversions.ToString(PreviewOnClick));
            //.WriteAttributeString("PreviewErrorCheck", PreviewErrorCheck)
            w.WriteAttributeString("ClickStopPreview", Conversions.ToString(ClickStopPreview));
            w.WriteEndElement();

            w.WriteStartElement("Save");
            w.WriteAttributeString("TextEncoding", Functions.EncodingToString(TextEncoding));
            w.WriteAttributeString("BMSGridLimit", Conversions.ToString(BMSGridLimit));
            w.WriteAttributeString("BeepWhileSaved", Conversions.ToString(BeepWhileSaved));
            w.WriteAttributeString("BPMx1296", Conversions.ToString(BPMx1296));
            w.WriteAttributeString("STOPx1296", Conversions.ToString(STOPx1296));
            w.WriteEndElement();

            w.WriteStartElement("WAV");
            w.WriteAttributeString("WAVMultiSelect", Conversions.ToString(WAVMultiSelect));
            w.WriteAttributeString("WAVChangeLabel", Conversions.ToString(WAVChangeLabel));
            w.WriteAttributeString("BeatChangeMode", Conversions.ToString(BeatChangeMode));
            w.WriteEndElement();

            w.WriteStartElement("ShowHide");
            w.WriteAttributeString("showMenu", Conversions.ToString(mnSMenu.Checked));
            w.WriteAttributeString("showTB", Conversions.ToString(mnSTB.Checked));
            w.WriteAttributeString("showOpPanel", Conversions.ToString(mnSOP.Checked));
            w.WriteAttributeString("showStatus", Conversions.ToString(mnSStatus.Checked));
            w.WriteAttributeString("showLSplit", Conversions.ToString(mnSLSplitter.Checked));
            w.WriteAttributeString("showRSplit", Conversions.ToString(mnSRSplitter.Checked));
            w.WriteEndElement();

            w.WriteStartElement("Grid");
            w.WriteAttributeString("gSnap", Conversions.ToString(gSnap));
            w.WriteAttributeString("gWheel", Conversions.ToString(gWheel));
            w.WriteAttributeString("gPgUpDn", Conversions.ToString(gPgUpDn));
            w.WriteAttributeString("gShow", Conversions.ToString(gShowGrid));
            w.WriteAttributeString("gShowS", Conversions.ToString(gShowSubGrid));
            w.WriteAttributeString("gShowBG", Conversions.ToString(gShowBG));
            w.WriteAttributeString("gShowM", Conversions.ToString(gShowMeasureNumber));
            w.WriteAttributeString("gShowV", Conversions.ToString(gShowVerticalLine));
            w.WriteAttributeString("gShowMB", Conversions.ToString(gShowMeasureBar));
            w.WriteAttributeString("gShowC", Conversions.ToString(gShowC));
            w.WriteAttributeString("gBPM", Conversions.ToString(gBPM));
            w.WriteAttributeString("gSTOP", Conversions.ToString(gSTOP));
            w.WriteAttributeString("gSCROLL", Conversions.ToString(gSCROLL));
            w.WriteAttributeString("gBLP", Conversions.ToString(gDisplayBGAColumn));
            w.WriteAttributeString("gP2", Conversions.ToString(CHPlayer.SelectedIndex));
            w.WriteAttributeString("gCol", Conversions.ToString(CGB.Value));
            w.WriteAttributeString("gDivide", Conversions.ToString(gDivide));
            w.WriteAttributeString("gSub", Conversions.ToString(gSub));
            w.WriteAttributeString("gSlash", Conversions.ToString(gSlash));
            w.WriteAttributeString("gxHeight", Conversions.ToString(gxHeight));
            w.WriteAttributeString("gxWidth", Conversions.ToString(gxWidth));
            w.WriteEndElement();

            w.WriteStartElement("WaveForm");
            w.WriteAttributeString("wLock", Conversions.ToString(wLock));
            w.WriteAttributeString("wPosition", Conversions.ToString(wPosition));
            w.WriteAttributeString("wLeft", Conversions.ToString(wLeft));
            w.WriteAttributeString("wWidth", Conversions.ToString(wWidth));
            w.WriteAttributeString("wPrecision", Conversions.ToString(wPrecision));
            w.WriteEndElement();

            w.WriteStartElement("Player");
            w.WriteAttributeString("Count", Conversions.ToString(pArgs.Length));
            w.WriteAttributeString("CurrentPlayer", Conversions.ToString(CurrentPlayer));

            for (int i = 0; i <= Information.UBound(pArgs); i++)
            {
                XMLWritePlayerArguments(w, i);
            }
            w.WriteEndElement();
        }

        w.WriteStartElement("Columns");
        for (int j = 0; j <= Information.UBound(column); j++)
        {
            XMLWriteColumn(w, j);
        }
        w.WriteEndElement();

        w.WriteStartElement("VisualSettings");
        XMLUtil.XMLWriteValue(w, "ColumnTitle", Conversions.ToString(vo.ColumnTitle.Color.ToArgb()));
        XMLWriteFont(w, "ColumnTitleFont", vo.ColumnTitleFont);
        XMLUtil.XMLWriteValue(w, "Bg", Conversions.ToString(vo.Bg.Color.ToArgb()));
        XMLUtil.XMLWriteValue(w, "Grid", Conversions.ToString(vo.pGrid.Color.ToArgb()));
        XMLUtil.XMLWriteValue(w, "Sub", Conversions.ToString(vo.pSub.Color.ToArgb()));
        XMLUtil.XMLWriteValue(w, "VLine", Conversions.ToString(vo.pVLine.Color.ToArgb()));
        XMLUtil.XMLWriteValue(w, "MLine", Conversions.ToString(vo.pMLine.Color.ToArgb()));
        XMLUtil.XMLWriteValue(w, "BGMWav", Conversions.ToString(vo.pBGMWav.Color.ToArgb()));
        XMLUtil.XMLWriteValue(w, "SelBox", Conversions.ToString(vo.SelBox.Color.ToArgb()));
        XMLUtil.XMLWriteValue(w, "TSCursor", Conversions.ToString(vo.PECursor.Color.ToArgb()));
        XMLUtil.XMLWriteValue(w, "TSHalf", Conversions.ToString(vo.PEHalf.Color.ToArgb()));
        XMLUtil.XMLWriteValue(w, "TSDeltaMouseOver", Conversions.ToString(vo.PEDeltaMouseOver));
        XMLUtil.XMLWriteValue(w, "TSMouseOver", Conversions.ToString(vo.PEMouseOver.Color.ToArgb()));
        XMLUtil.XMLWriteValue(w, "TSSel", Conversions.ToString(vo.PESel.Color.ToArgb()));
        XMLUtil.XMLWriteValue(w, "TSBPM", Conversions.ToString(vo.PEBPM.Color.ToArgb()));
        XMLWriteFont(w, "TSBPMFont", vo.PEBPMFont);
        XMLUtil.XMLWriteValue(w, "MiddleDeltaRelease", Conversions.ToString(vo.MiddleDeltaRelease));
        XMLUtil.XMLWriteValue(w, "kHeight", Conversions.ToString(vo.kHeight));
        XMLWriteFont(w, "kFont", vo.kFont);
        XMLWriteFont(w, "kMFont", vo.kMFont);
        XMLUtil.XMLWriteValue(w, "kLabelVShift", Conversions.ToString(vo.kLabelVShift));
        XMLUtil.XMLWriteValue(w, "kLabelHShift", Conversions.ToString(vo.kLabelHShift));
        XMLUtil.XMLWriteValue(w, "kLabelHShiftL", Conversions.ToString(vo.kLabelHShiftL));
        XMLUtil.XMLWriteValue(w, "kMouseOver", Conversions.ToString(vo.kMouseOver.Color.ToArgb()));
        XMLUtil.XMLWriteValue(w, "kMouseOverE", Conversions.ToString(vo.kMouseOverE.Color.ToArgb()));
        XMLUtil.XMLWriteValue(w, "kSelected", Conversions.ToString(vo.kSelected.Color.ToArgb()));
        XMLUtil.XMLWriteValue(w, "kOpacity", Conversions.ToString(vo.kOpacity));
        w.WriteEndElement();

        w.WriteEndElement();
        w.WriteEndDocument();
        w.Close();
    }

    private void XMLLoadElementValue(XmlElement n, ref int v)
    {
        if (n == null) return;
        XMLUtil.XMLLoadAttribute(n.GetAttribute("Value"), ref v);
    }

    private void XMLLoadElementValue(XmlElement n, ref float v)
    {
        if (n == null) return;
        XMLUtil.XMLLoadAttribute(n.GetAttribute("Value"), ref v);
    }

    private void XMLLoadElementValue(XmlElement n, ref Color v)
    {
        if (n == null) return;
        XMLUtil.XMLLoadAttribute(n.GetAttribute("Value"), ref v);
    }

    private void XMLLoadElementValue(XmlElement n, ref Font v)
    {
        if (n == null) return;
        string v2 = Font.FontFamily.Name;
        int v3 = (int)Math.Round(Font.Size);
        int v4 = (int)Font.Style;
        XMLUtil.XMLLoadAttribute(n.GetAttribute("Name"), ref v2);
        XMLUtil.XMLLoadAttribute(n.GetAttribute("Size"), ref v3);
        XMLUtil.XMLLoadAttribute(n.GetAttribute("Style"), ref v4);
        v = new Font(v2, v3, (FontStyle)v4);
    }

    private void XMLLoadPlayer(XmlElement n)
    {
        int v = -1;
        XMLUtil.XMLLoadAttribute(n.GetAttribute("Index"), ref v);
        if (v < 0 || v > Information.UBound(pArgs)) return;

        XMLUtil.XMLLoadAttribute(n.GetAttribute("Path"), ref pArgs[v].Path);
        XMLUtil.XMLLoadAttribute(n.GetAttribute("FromBeginning"), ref pArgs[v].aBegin);
        XMLUtil.XMLLoadAttribute(n.GetAttribute("FromHere"), ref pArgs[v].aHere);
        XMLUtil.XMLLoadAttribute(n.GetAttribute("Stop"), ref pArgs[v].aStop);
    }

    private void XMLLoadColumn(XmlElement n)
    {
        int v = -1;
        XMLUtil.XMLLoadAttribute(n.GetAttribute("Index"), ref v);
        if (v < 0 || v > Information.UBound(column)) return;

        Column[] array = column;
        int v2 = array[v].Width;
        XMLUtil.XMLLoadAttribute(n.GetAttribute("Width"), ref v2);
        array[v].Width = v2;
        XMLUtil.XMLLoadAttribute(n.GetAttribute("Title"), ref array[v].Title);
        string attribute2 = n.GetAttribute("Display");
        bool v3 = false;
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

    private void LoadSettings(string Path)
    {
        if (!MyProject.Computer.FileSystem.FileExists(Path)) return;

        XmlDocument Doc = new XmlDocument();
        FileStream FileStream = new FileStream(Path, FileMode.Open, FileAccess.Read);
        Doc.Load(FileStream);

        XmlElement Root = Doc["iBMSC"];
        if (Root == null) return;

        int Major = MyProject.Application.Info.Version.Major;
        int Minor = MyProject.Application.Info.Version.Minor;
        int Build = MyProject.Application.Info.Version.Build;
        try
        {
            int xMajor = (int)Math.Round(Conversion.Val(Root.Attributes["Major"].Value));
            int xMinor = (int)Math.Round(Conversion.Val(Root.Attributes["Minor"].Value));
            int xBuild = (int)Math.Round(Conversion.Val(Root.Attributes["Build"].Value));
            Major = xMajor;
            Minor = xMinor;
            Build = xBuild;
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            ProjectData.ClearProjectError();
        }

        XmlElement xmlElement2 = Root["Form"];
        if (xmlElement2 != null)
        {
            XmlElement xmlElement3 = xmlElement2;
            switch ((FormWindowState)(int)Conversion.Val(xmlElement3.GetAttribute("WindowState")))
            {
                case FormWindowState.Normal:
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
                        break;
                    }
                case FormWindowState.Maximized:
                    {
                        WindowState = FormWindowState.Maximized;
                        break;
                    }
            }
        }

        XmlElement xmlElement4 = Root["Recent"];
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

        XmlElement xmlElement6 = Root["Edit"];
        if (xmlElement6 != null)
        {
            XmlElement xmlElement7 = xmlElement6;
            XMLUtil.XMLLoadAttribute(xmlElement7.GetAttribute("NTInput"), ref NTInput);
            TBNTInput.Checked = NTInput;
            mnNTInput.Checked = NTInput;
            POBLong.Enabled = !NTInput;
            POBLongShort.Enabled = !NTInput;

            LoadLocale(MyProject.Application.Info.DirectoryPath + "\\" + xmlElement7.GetAttribute("Language"));

            //XMLLoadAttribute(.GetAttribute("SortingMethod"), SortingMethod)

            XMLUtil.XMLLoadAttribute(xmlElement7.GetAttribute("ErrorCheck"), ref ErrorCheck);
            TBErrorCheck.Checked = ErrorCheck;
            TBErrorCheck_Click(TBErrorCheck, EventArgs.Empty);

            XMLUtil.XMLLoadAttribute(xmlElement7.GetAttribute("ShowFileName"), ref ShowFileName);
            TBShowFileName.Checked = ShowFileName;
            TBShowFileName_Click(TBShowFileName, EventArgs.Empty);

            XMLUtil.XMLLoadAttribute(xmlElement7.GetAttribute("MiddleButtonMoveMethod"),
                ref MiddleButtonMoveMethod);
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
            TBPreviewOnClick_Click(TBPreviewOnClick, EventArgs.Empty);

            XMLUtil.XMLLoadAttribute(xmlElement7.GetAttribute("ClickStopPreview"), ref ClickStopPreview);
        }

        XmlElement eSave = Root["Save"];
        if (eSave != null)
        {
            TextEncoding = Microsoft.VisualBasic.Strings.UCase(eSave.GetAttribute("TextEncoding")) switch
            {
                "SYSTEM ANSI" => Encoding.Default,
                "LITTLE ENDIAN UTF16" => Encoding.Unicode,
                "ASCII" => Encoding.ASCII,
                "BIG ENDIAN UTF16" => Encoding.BigEndianUnicode,
                "LITTLE ENDIAN UTF32" => Encoding.UTF32,
                "UTF7" => Encoding.UTF7,
                "UTF8" => Encoding.UTF8,
                "SJIS" => Encoding.GetEncoding(932),
                "EUC-KR" => Encoding.GetEncoding(51949),
                _ => TextEncoding
            };

            XMLUtil.XMLLoadAttribute(eSave.GetAttribute("BMSGridLimit"), ref BMSGridLimit);
            XMLUtil.XMLLoadAttribute(eSave.GetAttribute("BeepWhileSaved"), ref BeepWhileSaved);
            XMLUtil.XMLLoadAttribute(eSave.GetAttribute("BPMx1296"), ref BPMx1296);
            XMLUtil.XMLLoadAttribute(eSave.GetAttribute("STOPx1296"), ref STOPx1296);
        }

        XmlElement eWAV = Root["WAV"];
        if (eWAV != null)
        {
            XMLUtil.XMLLoadAttribute(eWAV.GetAttribute("WAVMultiSelect"), ref WAVMultiSelect);
            CWAVMultiSelect.Checked = WAVMultiSelect;
            CWAVMultiSelect_CheckedChanged(CWAVMultiSelect, EventArgs.Empty);

            XMLUtil.XMLLoadAttribute(eWAV.GetAttribute("WAVChangeLabel"), ref WAVChangeLabel);
            CWAVChangeLabel.Checked = WAVChangeLabel;
            CWAVChangeLabel_CheckedChanged(CWAVChangeLabel, EventArgs.Empty);

            int num5 = Conversions.ToInteger(eWAV.GetAttribute("BeatChangeMode"));
            RadioButton[] array = { CBeatPreserve, CBeatMeasure, CBeatCut, CBeatScale };
            if (num5 >= 0 && num5 < array.Length)
            {
                array[num5].Checked = true;
                CBeatPreserve_Click(array[num5], EventArgs.Empty);
            }
        }

        XmlElement eShowHide = Root["ShowHide"];
        if (eShowHide != null)
        {
            string attribute5 = eShowHide.GetAttribute("showMenu");
            ToolStripMenuItem toolStripMenuItem = mnSMenu;
            bool v2 = toolStripMenuItem.Checked;
            XMLUtil.XMLLoadAttribute(attribute5, ref v2);
            toolStripMenuItem.Checked = v2;
            string attribute6 = eShowHide.GetAttribute("showTB");
            toolStripMenuItem = mnSTB;
            v2 = toolStripMenuItem.Checked;
            XMLUtil.XMLLoadAttribute(attribute6, ref v2);
            toolStripMenuItem.Checked = v2;
            string attribute7 = eShowHide.GetAttribute("showOpPanel");
            toolStripMenuItem = mnSOP;
            v2 = toolStripMenuItem.Checked;
            XMLUtil.XMLLoadAttribute(attribute7, ref v2);
            toolStripMenuItem.Checked = v2;
            string attribute8 = eShowHide.GetAttribute("showStatus");
            toolStripMenuItem = mnSStatus;
            v2 = toolStripMenuItem.Checked;
            XMLUtil.XMLLoadAttribute(attribute8, ref v2);
            toolStripMenuItem.Checked = v2;
            string attribute9 = eShowHide.GetAttribute("showLSplit");
            toolStripMenuItem = mnSLSplitter;
            v2 = toolStripMenuItem.Checked;
            XMLUtil.XMLLoadAttribute(attribute9, ref v2);
            toolStripMenuItem.Checked = v2;
            string attribute10 = eShowHide.GetAttribute("showRSplit");
            toolStripMenuItem = mnSRSplitter;
            v2 = toolStripMenuItem.Checked;
            XMLUtil.XMLLoadAttribute(attribute10, ref v2);
            toolStripMenuItem.Checked = v2;
        }

        XmlElement eGrid = Root["Grid"];
        if (eGrid != null)
        {
            string attribute11 = eGrid.GetAttribute("gSnap");
            CheckBox cGSnap = CGSnap;
            bool v2 = cGSnap.Checked;
            XMLUtil.XMLLoadAttribute(attribute11, ref v2);
            cGSnap.Checked = v2;
            XMLUtil.XMLLoadAttribute(eGrid.GetAttribute("gWheel"), ref gWheel);
            XMLUtil.XMLLoadAttribute(eGrid.GetAttribute("gPgUpDn"), ref gPgUpDn);
            string attribute12 = eGrid.GetAttribute("gShow");
            ToolStripMenuItem toolStripMenuItem = CGShow;
            v2 = toolStripMenuItem.Checked;
            XMLUtil.XMLLoadAttribute(attribute12, ref v2);
            toolStripMenuItem.Checked = v2;
            string attribute13 = eGrid.GetAttribute("gShowS");
            toolStripMenuItem = CGShowS;
            v2 = toolStripMenuItem.Checked;
            XMLUtil.XMLLoadAttribute(attribute13, ref v2);
            toolStripMenuItem.Checked = v2;
            string attribute14 = eGrid.GetAttribute("gShowBG");
            toolStripMenuItem = CGShowBG;
            v2 = toolStripMenuItem.Checked;
            XMLUtil.XMLLoadAttribute(attribute14, ref v2);
            toolStripMenuItem.Checked = v2;
            string attribute15 = eGrid.GetAttribute("gShowM");
            toolStripMenuItem = CGShowM;
            v2 = toolStripMenuItem.Checked;
            XMLUtil.XMLLoadAttribute(attribute15, ref v2);
            toolStripMenuItem.Checked = v2;
            string attribute16 = eGrid.GetAttribute("gShowV");
            toolStripMenuItem = CGShowV;
            v2 = toolStripMenuItem.Checked;
            XMLUtil.XMLLoadAttribute(attribute16, ref v2);
            toolStripMenuItem.Checked = v2;
            string attribute17 = eGrid.GetAttribute("gShowMB");
            toolStripMenuItem = CGShowMB;
            v2 = toolStripMenuItem.Checked;
            XMLUtil.XMLLoadAttribute(attribute17, ref v2);
            toolStripMenuItem.Checked = v2;
            string attribute18 = eGrid.GetAttribute("gShowC");
            toolStripMenuItem = CGShowC;
            v2 = toolStripMenuItem.Checked;
            XMLUtil.XMLLoadAttribute(attribute18, ref v2);
            toolStripMenuItem.Checked = v2;
            string attribute19 = eGrid.GetAttribute("gBPM");
            toolStripMenuItem = CGBPM;
            v2 = toolStripMenuItem.Checked;
            XMLUtil.XMLLoadAttribute(attribute19, ref v2);
            toolStripMenuItem.Checked = v2;
            string attribute20 = eGrid.GetAttribute("gSTOP");
            toolStripMenuItem = CGSTOP;
            v2 = toolStripMenuItem.Checked;
            XMLUtil.XMLLoadAttribute(attribute20, ref v2);
            toolStripMenuItem.Checked = v2;
            string attribute21 = eGrid.GetAttribute("gSCROLL");
            toolStripMenuItem = CGSCROLL;
            v2 = toolStripMenuItem.Checked;
            XMLUtil.XMLLoadAttribute(attribute21, ref v2);
            toolStripMenuItem.Checked = v2;
            string attribute22 = eGrid.GetAttribute("gBLP");
            toolStripMenuItem = CGBLP;
            v2 = toolStripMenuItem.Checked;
            XMLUtil.XMLLoadAttribute(attribute22, ref v2);
            toolStripMenuItem.Checked = v2;
            string attribute23 = eGrid.GetAttribute("gP2");
            ComboBox cHPlayer = CHPlayer;
            int v = cHPlayer.SelectedIndex;
            XMLUtil.XMLLoadAttribute(attribute23, ref v);
            cHPlayer.SelectedIndex = v;
            string attribute24 = eGrid.GetAttribute("gCol");
            NumericUpDown cGB = CGB;
            decimal v3 = cGB.Value;
            XMLUtil.XMLLoadAttribute(attribute24, ref v3);
            cGB.Value = v3;
            string attribute25 = eGrid.GetAttribute("gxHeight");
            cGB = CGHeight;
            v3 = cGB.Value;
            XMLUtil.XMLLoadAttribute(attribute25, ref v3);
            cGB.Value = v3;
            string attribute26 = eGrid.GetAttribute("gxWidth");
            cGB = CGWidth;
            v3 = cGB.Value;
            XMLUtil.XMLLoadAttribute(attribute26, ref v3);
            cGB.Value = v3;
            XMLUtil.XMLLoadAttribute(eGrid.GetAttribute("gSlash"), ref gSlash);

            int value = Conversions.ToInteger(eGrid.GetAttribute("gDivide"));
            if (decimal.Compare(new decimal(value), CGDivide.Minimum) >= 0 &
                decimal.Compare(new decimal(value), CGDivide.Maximum) <= 0)
            {
                CGDivide.Value = new decimal(value);
            }

            int value2 = Conversions.ToInteger(eGrid.GetAttribute("gSub"));
            if (decimal.Compare(new decimal(value2), CGSub.Minimum) >= 0 &
                decimal.Compare(new decimal(value2), CGSub.Maximum) <= 0)
            {
                CGSub.Value = new decimal(value2);
            }
        }

        XmlElement eWaveForm = Root["WaveForm"];
        if (eWaveForm != null)
        {
            string attribute27 = eWaveForm.GetAttribute("wLock");
            CheckBox cGSnap = BWLock;
            bool v2 = cGSnap.Checked;
            XMLUtil.XMLLoadAttribute(attribute27, ref v2);
            cGSnap.Checked = v2;
            string attribute28 = eWaveForm.GetAttribute("wPosition");
            NumericUpDown cGB = TWPosition;
            decimal v3 = cGB.Value;
            XMLUtil.XMLLoadAttribute(attribute28, ref v3);
            cGB.Value = v3;
            string attribute29 = eWaveForm.GetAttribute("wLeft");
            cGB = TWLeft;
            v3 = cGB.Value;
            XMLUtil.XMLLoadAttribute(attribute29, ref v3);
            cGB.Value = v3;
            string attribute30 = eWaveForm.GetAttribute("wWidth");
            cGB = TWWidth;
            v3 = cGB.Value;
            XMLUtil.XMLLoadAttribute(attribute30, ref v3);
            cGB.Value = v3;
            string attribute31 = eWaveForm.GetAttribute("wPrecision");
            cGB = TWPrecision;
            v3 = cGB.Value;
            XMLUtil.XMLLoadAttribute(attribute31, ref v3);
            cGB.Value = v3;
        }

        XmlElement ePlayer = Root["Player"];
        if (ePlayer != null)
        {
            XMLUtil.XMLLoadAttribute(ePlayer.GetAttribute("CurrentPlayer"), ref CurrentPlayer);
            int num6 = Conversions.ToInteger(ePlayer.GetAttribute("Count"));
            if (num6 > 0)
            {
                pArgs = (PlayerArguments[])Utils.CopyArray(pArgs, new PlayerArguments[num6 - 1 + 1]);
            }

            foreach (XmlElement eePlayer in ePlayer.ChildNodes)
            {
                XMLLoadPlayer(eePlayer);
            }
        }

        XmlElement eColumns = Root["Columns"];
        if (eColumns != null)
        {
            foreach (XmlElement eeCol in eColumns.ChildNodes)
            {
                XMLLoadColumn(eeCol);
            }
        }

        XmlElement eVisualSettings = Root["VisualSettings"];
        if (eVisualSettings != null)
        {
            XmlElement n3 = eVisualSettings["ColumnTitle"];
            SolidBrush columnTitle = vo.ColumnTitle;
            Color v4 = columnTitle.Color;
            XMLLoadElementValue(n3, ref v4);
            columnTitle.Color = v4;
            XMLLoadElementValue(eVisualSettings["ColumnTitleFont"], ref vo.ColumnTitleFont);
            XmlElement n4 = eVisualSettings["Bg"];
            columnTitle = vo.Bg;
            v4 = columnTitle.Color;
            XMLLoadElementValue(n4, ref v4);
            columnTitle.Color = v4;
            XmlElement n5 = eVisualSettings["Grid"];
            Pen pGrid = vo.pGrid;
            v4 = pGrid.Color;
            XMLLoadElementValue(n5, ref v4);
            pGrid.Color = v4;
            XmlElement n6 = eVisualSettings["Sub"];
            pGrid = vo.pSub;
            v4 = pGrid.Color;
            XMLLoadElementValue(n6, ref v4);
            pGrid.Color = v4;
            XmlElement n7 = eVisualSettings["VLine"];
            pGrid = vo.pVLine;
            v4 = pGrid.Color;
            XMLLoadElementValue(n7, ref v4);
            pGrid.Color = v4;
            XmlElement n8 = eVisualSettings["MLine"];
            pGrid = vo.pMLine;
            v4 = pGrid.Color;
            XMLLoadElementValue(n8, ref v4);
            pGrid.Color = v4;
            XmlElement n9 = eVisualSettings["BGMWav"];
            pGrid = vo.pBGMWav;
            v4 = pGrid.Color;
            XMLLoadElementValue(n9, ref v4);
            pGrid.Color = v4;
            TWTransparency.Value = new decimal(vo.pBGMWav.Color.A);
            TWTransparency2.Value = vo.pBGMWav.Color.A;
            TWSaturation.Value = new decimal(vo.pBGMWav.Color.GetSaturation() * 1000f);
            TWSaturation2.Value = (int)Math.Round(vo.pBGMWav.Color.GetSaturation() * 1000f);
            XmlElement n10 = eVisualSettings["SelBox"];
            pGrid = vo.SelBox;
            v4 = pGrid.Color;
            XMLLoadElementValue(n10, ref v4);
            pGrid.Color = v4;
            XmlElement n11 = eVisualSettings["TSCursor"];
            pGrid = vo.PECursor;
            v4 = pGrid.Color;
            XMLLoadElementValue(n11, ref v4);
            pGrid.Color = v4;
            XmlElement n12 = eVisualSettings["TSHalf"];
            pGrid = vo.PEHalf;
            v4 = pGrid.Color;
            XMLLoadElementValue(n12, ref v4);
            pGrid.Color = v4;
            XMLLoadElementValue(eVisualSettings["TSDeltaMouseOver"], ref vo.PEDeltaMouseOver);
            XmlElement n13 = eVisualSettings["TSMouseOver"];
            pGrid = vo.PEMouseOver;
            v4 = pGrid.Color;
            XMLLoadElementValue(n13, ref v4);
            pGrid.Color = v4;
            XmlElement n14 = eVisualSettings["TSSel"];
            columnTitle = vo.PESel;
            v4 = columnTitle.Color;
            XMLLoadElementValue(n14, ref v4);
            columnTitle.Color = v4;
            XmlElement n15 = eVisualSettings["TSBPM"];
            columnTitle = vo.PEBPM;
            v4 = columnTitle.Color;
            XMLLoadElementValue(n15, ref v4);
            columnTitle.Color = v4;
            XMLLoadElementValue(eVisualSettings["TSBPMFont"], ref vo.PEBPMFont);
            XMLLoadElementValue(eVisualSettings["MiddleDeltaRelease"], ref vo.MiddleDeltaRelease);
            XMLLoadElementValue(eVisualSettings["kHeight"], ref vo.kHeight);
            XMLLoadElementValue(eVisualSettings["kFont"], ref vo.kFont);
            XMLLoadElementValue(eVisualSettings["kMFont"], ref vo.kMFont);
            XMLLoadElementValue(eVisualSettings["kLabelVShift"], ref vo.kLabelVShift);
            XMLLoadElementValue(eVisualSettings["kLabelHShift"], ref vo.kLabelHShift);
            XMLLoadElementValue(eVisualSettings["kLabelHShiftL"], ref vo.kLabelHShiftL);
            XmlElement n16 = eVisualSettings["kMouseOver"];
            pGrid = vo.kMouseOver;
            v4 = pGrid.Color;
            XMLLoadElementValue(n16, ref v4);
            pGrid.Color = v4;
            XmlElement n17 = eVisualSettings["kMouseOverE"];
            pGrid = vo.kMouseOverE;
            v4 = pGrid.Color;
            XMLLoadElementValue(n17, ref v4);
            pGrid.Color = v4;
            XmlElement n18 = eVisualSettings["kSelected"];
            pGrid = vo.kSelected;
            v4 = pGrid.Color;
            XMLLoadElementValue(n18, ref v4);
            pGrid.Color = v4;
            XMLLoadElementValue(eVisualSettings["kOpacity"], ref vo.kOpacity);
        }

        UpdateColumnsX();
        FileStream.Close();
    }

    private void XMLLoadLocaleMenu(XmlElement n, ref string target)
    {
        if (n == null) return;
        if (n.HasAttribute("amp"))
        {
            target = n.InnerText.Insert(int.Parse(n.GetAttribute("amp")), "&");
        }
        else
        {
            target = n.InnerText;
        }
    }

    private void XMLLoadLocale(XmlElement n, ref string target)
    {
        if (n == null) return;
        target = n.InnerText;
    }

    private void XMLLoadLocaleToolTipUniversal(XmlElement n, Control target)
    {
        if (n == null) return;
        ToolTipUniversal.SetToolTip(target, n.InnerText);
    }

    private void LoadLocale(string Path)
    {
        if (!MyProject.Computer.FileSystem.FileExists(Path))
        {
            return;
        }
        XmlDocument Doc = null;
        FileStream FileStream = null;

        bool xPOHeaderPart2 = POHeaderPart2.Visible;
        bool xPOGridPart2 = POGridPart2.Visible;
        bool xPOWaveFormPart2 = POWaveFormPart2.Visible;
        POHeaderPart2.Visible = true;
        POGridPart2.Visible = true;
        POWaveFormPart2.Visible = true;

        try
        {
            Doc = new XmlDocument();
            FileStream = new FileStream(Path, FileMode.Open, FileAccess.Read);
            Doc.Load(FileStream);

            XmlElement Root = Doc["iBMSC.Locale"];
            if (Root == null)
            {
                throw new NullReferenceException();
            }

            XMLLoadLocale(Root["OK"], ref Strings.OK);
            XMLLoadLocale(Root["Cancel"], ref Strings.Cancel);
            XMLLoadLocale(Root["None"], ref Strings.None);
            XmlElement eFont = Root["Font"];
            if (eFont != null)
            {
                int xSize = 9;
                if (eFont.HasAttribute("Size"))
                {
                    xSize = (int)Math.Round(Conversion.Val(eFont.GetAttribute("Size")));
                }

                Font fRegular = new Font(Font.FontFamily, xSize, FontStyle.Regular);
                XmlNode xChildNode = eFont.LastChild;
                while (xChildNode != null)
                {
                    if (Operators.CompareString(xChildNode.LocalName, "Family", TextCompare: false) == 0)
                    {
                        if (Functions.isFontInstalled(xChildNode.InnerText))
                        {
                            fRegular = new Font(xChildNode.InnerText, xSize);
                        }

                        xChildNode = xChildNode.PreviousSibling;
                    }
                }

                object[] rList = { this, mnSys, Menu1, mnMain, cmnLanguage, cmnTheme, cmnConversion, TBMain, FStatus, FStatus2 };
                foreach (var c in rList)
                {
                    object objectValue = RuntimeHelpers.GetObjectValue(c);
                    try
                    {
                        NewLateBinding.LateSet(objectValue, null, "Font", new object[] { fRegular }, null, null);
                    }
                    catch (Exception ex)
                    {
                        ProjectData.SetProjectError(ex);
                        ProjectData.ClearProjectError();
                    }
                }

                Font fBold = new Font(fRegular, FontStyle.Bold);
                object[] bList = { TBStatistics, FSSS, FSSL, FSSH, TVCM, TVCD, TVCBPM, FSP1, FSP3, FSP2, PMain, PMainIn, PMainR, PMainInR, PMainL, PMainInL };
                foreach (var c in bList)
                {
                    object objectValue2 = RuntimeHelpers.GetObjectValue(c);
                    try
                    {
                        NewLateBinding.LateSet(objectValue2, null, "Font", new object[1] { fBold }, null, null);
                    }
                    catch (Exception ex3)
                    {
                        ProjectData.SetProjectError(ex3);
                        ProjectData.ClearProjectError();
                    }
                }
            }

            XmlElement eMonoFont = Root["MonoFont"];
            if (eMonoFont != null)
            {
                int xSize = 9;
                if (eMonoFont.HasAttribute("Size"))
                {
                    xSize = (int)Math.Round(Conversion.Val(eMonoFont.GetAttribute("Size")));
                }

                Font fMono = new Font(POWAVInner.Font.FontFamily, xSize);
                XmlNode xChildNode = eMonoFont.LastChild;
                while (xChildNode != null)
                {
                    if (Operators.CompareString(xChildNode.LocalName, "Family", TextCompare: false) == 0)
                    {
                        if (Functions.isFontInstalled(xChildNode.InnerText))
                        {
                            fMono = new Font(xChildNode.InnerText, xSize);
                        }
                        xChildNode = xChildNode.PreviousSibling;
                    }
                }

                object[] mList = { LWAV, LBeat, TExpansion };
                foreach (var c in mList)
                {
                    object objectValue3 = RuntimeHelpers.GetObjectValue(c);
                    try
                    {
                        NewLateBinding.LateSet(objectValue3, null, "font", new object[1] { fMono }, null, null);
                    }
                    catch (Exception ex5)
                    {
                        ProjectData.SetProjectError(ex5);
                        ProjectData.ClearProjectError();
                    }
                }
            }

            XmlElement eMenu = Root["Menu"];
            if (eMenu != null)
            {
                XmlElement eFile = eMenu["File"];
                ToolStripMenuItem toolStripMenuItem;
                string target;
                if (eFile != null)
                {
                    XmlElement n = eFile["Title"];
                    toolStripMenuItem = mnFile;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n2 = eFile["New"];
                    toolStripMenuItem = mnNew;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n2, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n3 = eFile["Open"];
                    toolStripMenuItem = mnOpen;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n3, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n4 = eFile["ImportSM"];
                    toolStripMenuItem = mnImportSM;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n4, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n5 = eFile["ImportIBMSC"];
                    toolStripMenuItem = mnImportIBMSC;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n5, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n6 = eFile["Save"];
                    toolStripMenuItem = mnSave;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n6, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n7 = eFile["SaveAs"];
                    toolStripMenuItem = mnSaveAs;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n7, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n8 = eFile["ExportIBMSC"];
                    toolStripMenuItem = mnExport;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n8, ref target);
                    toolStripMenuItem.Text = target;
                    if (Operators.CompareString(Recent[0], "", TextCompare: false) == 0)
                    {
                        XmlElement n9 = eFile["Recent0"];
                        toolStripMenuItem = mnOpenR0;
                        target = toolStripMenuItem.Text;
                        XMLLoadLocaleMenu(n9, ref target);
                        toolStripMenuItem.Text = target;
                    }
                    if (Operators.CompareString(Recent[1], "", TextCompare: false) == 0)
                    {
                        XmlElement n10 = eFile["Recent1"];
                        toolStripMenuItem = mnOpenR1;
                        target = toolStripMenuItem.Text;
                        XMLLoadLocaleMenu(n10, ref target);
                        toolStripMenuItem.Text = target;
                    }
                    if (Operators.CompareString(Recent[2], "", TextCompare: false) == 0)
                    {
                        XmlElement n11 = eFile["Recent2"];
                        toolStripMenuItem = mnOpenR2;
                        target = toolStripMenuItem.Text;
                        XMLLoadLocaleMenu(n11, ref target);
                        toolStripMenuItem.Text = target;
                    }
                    if (Operators.CompareString(Recent[3], "", TextCompare: false) == 0)
                    {
                        XmlElement n12 = eFile["Recent3"];
                        toolStripMenuItem = mnOpenR3;
                        target = toolStripMenuItem.Text;
                        XMLLoadLocaleMenu(n12, ref target);
                        toolStripMenuItem.Text = target;
                    }
                    if (Operators.CompareString(Recent[4], "", TextCompare: false) == 0)
                    {
                        XmlElement n13 = eFile["Recent4"];
                        toolStripMenuItem = mnOpenR4;
                        target = toolStripMenuItem.Text;
                        XMLLoadLocaleMenu(n13, ref target);
                        toolStripMenuItem.Text = target;
                    }
                    XmlElement n14 = eFile["Quit"];
                    toolStripMenuItem = mnQuit;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n14, ref target);
                    toolStripMenuItem.Text = target;
                }
                XmlElement eEdit = eMenu["Edit"];
                if (eEdit != null)
                {
                    XmlElement n15 = eEdit["Title"];
                    toolStripMenuItem = mnEdit;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n15, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n16 = eEdit["Undo"];
                    toolStripMenuItem = mnUndo;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n16, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n17 = eEdit["Redo"];
                    toolStripMenuItem = mnRedo;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n17, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n18 = eEdit["Cut"];
                    toolStripMenuItem = mnCut;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n18, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n19 = eEdit["Copy"];
                    toolStripMenuItem = mnCopy;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n19, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n20 = eEdit["Paste"];
                    toolStripMenuItem = mnPaste;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n20, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n21 = eEdit["Delete"];
                    toolStripMenuItem = mnDelete;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n21, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n22 = eEdit["SelectAll"];
                    toolStripMenuItem = mnSelectAll;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n22, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n23 = eEdit["Find"];
                    toolStripMenuItem = mnFind;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n23, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n24 = eEdit["Stat"];
                    toolStripMenuItem = mnStatistics;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n24, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n25 = eEdit["TimeSelectionTool"];
                    toolStripMenuItem = mnTimeSelect;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n25, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n26 = eEdit["SelectTool"];
                    toolStripMenuItem = mnSelect;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n26, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n27 = eEdit["WriteTool"];
                    toolStripMenuItem = mnWrite;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n27, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n28 = eEdit["MyO2"];
                    toolStripMenuItem = mnMyO2;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n28, ref target);
                    toolStripMenuItem.Text = target;
                }
                XmlElement eView = eMenu["View"];
                if (eView != null)
                {
                    XmlElement n29 = eView["Title"];
                    toolStripMenuItem = mnSys;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n29, ref target);
                    toolStripMenuItem.Text = target;
                }
                XmlElement eOptions = eMenu["Options"];
                if (eOptions != null)
                {
                    XmlElement n30 = eOptions["Title"];
                    toolStripMenuItem = mnOptions;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n30, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n31 = eOptions["NT"];
                    toolStripMenuItem = mnNTInput;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n31, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n32 = eOptions["ErrorCheck"];
                    toolStripMenuItem = mnErrorCheck;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n32, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n33 = eOptions["PreviewOnClick"];
                    toolStripMenuItem = mnPreviewOnClick;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n33, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n34 = eOptions["ShowFileName"];
                    toolStripMenuItem = mnShowFileName;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n34, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n35 = eOptions["GeneralOptions"];
                    toolStripMenuItem = mnGOptions;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n35, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n36 = eOptions["VisualOptions"];
                    toolStripMenuItem = mnVOptions;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n36, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n37 = eOptions["PlayerOptions"];
                    toolStripMenuItem = mnPOptions;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n37, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n38 = eOptions["Language"];
                    toolStripMenuItem = mnLanguage;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n38, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n39 = eOptions["Theme"];
                    toolStripMenuItem = mnTheme;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n39, ref target);
                    toolStripMenuItem.Text = target;
                }

                XmlElement n40 = eMenu["Conversion"];
                toolStripMenuItem = mnConversion;
                target = toolStripMenuItem.Text;
                XMLLoadLocaleMenu(n40, ref target);
                toolStripMenuItem.Text = target;

                XmlElement ePreview = eMenu["Preview"];
                if (ePreview != null)
                {
                    XmlElement n41 = ePreview["Title"];
                    toolStripMenuItem = mnPreview;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n41, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n42 = ePreview["PlayBegin"];
                    toolStripMenuItem = mnPlayB;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n42, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n43 = ePreview["PlayHere"];
                    toolStripMenuItem = mnPlay;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n43, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n44 = ePreview["PlayStop"];
                    toolStripMenuItem = mnStop;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n44, ref target);
                    toolStripMenuItem.Text = target;
                }
                XmlElement eAbout = eMenu["About"];
            }

            XmlElement eToolBar = Root["ToolBar"];
            if (eToolBar != null)
            {
                XmlElement n45 = eToolBar["New"];
                ToolStripButton tBNew = TBNew;
                string target = tBNew.Text;
                XMLLoadLocale(n45, ref target);
                tBNew.Text = target;
                XmlElement n46 = eToolBar["Open"];
                ToolStripSplitButton tBOpen = TBOpen;
                target = tBOpen.Text;
                XMLLoadLocale(n46, ref target);
                tBOpen.Text = target;
                XmlElement n47 = eToolBar["Save"];
                tBOpen = TBSave;
                target = tBOpen.Text;
                XMLLoadLocale(n47, ref target);
                tBOpen.Text = target;
                XmlElement n48 = eToolBar["Cut"];
                tBNew = TBCut;
                target = tBNew.Text;
                XMLLoadLocale(n48, ref target);
                tBNew.Text = target;
                XmlElement n49 = eToolBar["Copy"];
                tBNew = TBCopy;
                target = tBNew.Text;
                XMLLoadLocale(n49, ref target);
                tBNew.Text = target;
                XmlElement n50 = eToolBar["Paste"];
                tBNew = TBPaste;
                target = tBNew.Text;
                XMLLoadLocale(n50, ref target);
                tBNew.Text = target;
                XmlElement n51 = eToolBar["Find"];
                tBNew = TBFind;
                target = tBNew.Text;
                XMLLoadLocale(n51, ref target);
                tBNew.Text = target;
                XmlElement n52 = eToolBar["Stat"];
                tBNew = TBStatistics;
                target = tBNew.ToolTipText;
                XMLLoadLocale(n52, ref target);
                tBNew.ToolTipText = target;
                XmlElement n53 = eToolBar["Conversion"];
                ToolStripDropDownButton pOConvert = POConvert;
                target = pOConvert.Text;
                XMLLoadLocale(n53, ref target);
                pOConvert.Text = target;
                XmlElement n54 = eToolBar["MyO2"];
                tBNew = TBMyO2;
                target = tBNew.Text;
                XMLLoadLocale(n54, ref target);
                tBNew.Text = target;
                XmlElement n55 = eToolBar["ErrorCheck"];
                tBNew = TBErrorCheck;
                target = tBNew.Text;
                XMLLoadLocale(n55, ref target);
                tBNew.Text = target;
                XmlElement n56 = eToolBar["PreviewOnClick"];
                tBNew = TBPreviewOnClick;
                target = tBNew.Text;
                XMLLoadLocale(n56, ref target);
                tBNew.Text = target;
                XmlElement n57 = eToolBar["ShowFileName"];
                tBNew = TBShowFileName;
                target = tBNew.Text;
                XMLLoadLocale(n57, ref target);
                tBNew.Text = target;
                XmlElement n58 = eToolBar["Undo"];
                tBNew = TBUndo;
                target = tBNew.Text;
                XMLLoadLocale(n58, ref target);
                tBNew.Text = target;
                XmlElement n59 = eToolBar["Redo"];
                tBNew = TBRedo;
                target = tBNew.Text;
                XMLLoadLocale(n59, ref target);
                tBNew.Text = target;
                XmlElement n60 = eToolBar["NT"];
                tBNew = TBNTInput;
                target = tBNew.Text;
                XMLLoadLocale(n60, ref target);
                tBNew.Text = target;
                XmlElement n61 = eToolBar["TimeSelectionTool"];
                tBNew = TBTimeSelect;
                target = tBNew.Text;
                XMLLoadLocale(n61, ref target);
                tBNew.Text = target;
                XmlElement n62 = eToolBar["SelectTool"];
                tBNew = TBSelect;
                target = tBNew.Text;
                XMLLoadLocale(n62, ref target);
                tBNew.Text = target;
                XmlElement n63 = eToolBar["WriteTool"];
                tBNew = TBWrite;
                target = tBNew.Text;
                XMLLoadLocale(n63, ref target);
                tBNew.Text = target;
                XmlElement n64 = eToolBar["PlayBegin"];
                tBNew = TBPlayB;
                target = tBNew.Text;
                XMLLoadLocale(n64, ref target);
                tBNew.Text = target;
                XmlElement n65 = eToolBar["PlayHere"];
                tBNew = TBPlay;
                target = tBNew.Text;
                XMLLoadLocale(n65, ref target);
                tBNew.Text = target;
                XmlElement n66 = eToolBar["PlayStop"];
                tBNew = TBStop;
                target = tBNew.Text;
                XMLLoadLocale(n66, ref target);
                tBNew.Text = target;
                XmlElement n67 = eToolBar["PlayerOptions"];
                tBNew = TBPOptions;
                target = tBNew.Text;
                XMLLoadLocale(n67, ref target);
                tBNew.Text = target;
                XmlElement n68 = eToolBar["VisualOptions"];
                tBNew = TBVOptions;
                target = tBNew.Text;
                XMLLoadLocale(n68, ref target);
                tBNew.Text = target;
                XmlElement n69 = eToolBar["GeneralOptions"];
                tBNew = TBGOptions;
                target = tBNew.Text;
                XMLLoadLocale(n69, ref target);
                tBNew.Text = target;
                XmlElement n70 = eToolBar["Language"];
                pOConvert = TBLanguage;
                target = pOConvert.Text;
                XMLLoadLocale(n70, ref target);
                pOConvert.Text = target;
                XmlElement n71 = eToolBar["Theme"];
                pOConvert = TBTheme;
                target = pOConvert.Text;
                XMLLoadLocale(n71, ref target);
                pOConvert.Text = target;
            }
            XmlElement eStatusBar = Root["StatusBar"];
            if (eStatusBar != null)
            {
                XmlElement n72 = eStatusBar["ColumnCaption"];
                ToolStripStatusLabel fSC = FSC;
                string target = fSC.ToolTipText;
                XMLLoadLocale(n72, ref target);
                fSC.ToolTipText = target;
                XmlElement n73 = eStatusBar["NoteIndex"];
                fSC = FSW;
                target = fSC.ToolTipText;
                XMLLoadLocale(n73, ref target);
                fSC.ToolTipText = target;
                XmlElement n74 = eStatusBar["MeasureIndex"];
                fSC = FSM;
                target = fSC.ToolTipText;
                XMLLoadLocale(n74, ref target);
                fSC.ToolTipText = target;
                XmlElement n75 = eStatusBar["GridResolution"];
                fSC = FSP1;
                target = fSC.ToolTipText;
                XMLLoadLocale(n75, ref target);
                fSC.ToolTipText = target;
                XmlElement n76 = eStatusBar["ReducedResolution"];
                fSC = FSP3;
                target = fSC.ToolTipText;
                XMLLoadLocale(n76, ref target);
                fSC.ToolTipText = target;
                XmlElement n77 = eStatusBar["MeasureResolution"];
                fSC = FSP2;
                target = fSC.ToolTipText;
                XMLLoadLocale(n77, ref target);
                fSC.ToolTipText = target;
                XmlElement n78 = eStatusBar["AbsolutePosition"];
                fSC = FSP4;
                target = fSC.ToolTipText;
                XMLLoadLocale(n78, ref target);
                fSC.ToolTipText = target;
                XMLLoadLocale(eStatusBar["Length"], ref Strings.StatusBar.Length);
                XMLLoadLocale(eStatusBar["LongNote"], ref Strings.StatusBar.LongNote);
                XMLLoadLocale(eStatusBar["Hidden"], ref Strings.StatusBar.Hidden);
                XMLLoadLocale(eStatusBar["Error"], ref Strings.StatusBar.Err);
                XmlElement n79 = eStatusBar["SelStart"];
                ToolStripButton tBNew = FSSS;
                target = tBNew.ToolTipText;
                XMLLoadLocale(n79, ref target);
                tBNew.ToolTipText = target;
                XmlElement n80 = eStatusBar["SelLength"];
                tBNew = FSSL;
                target = tBNew.ToolTipText;
                XMLLoadLocale(n80, ref target);
                tBNew.ToolTipText = target;
                XmlElement n81 = eStatusBar["SelSplit"];
                tBNew = FSSH;
                target = tBNew.ToolTipText;
                XMLLoadLocale(n81, ref target);
                tBNew.ToolTipText = target;
                XmlElement n82 = eStatusBar["Reverse"];
                tBNew = BVCReverse;
                target = tBNew.Text;
                XMLLoadLocale(n82, ref target);
                tBNew.Text = target;
                XmlElement n83 = eStatusBar["ByMultiple"];
                tBNew = BVCApply;
                target = tBNew.Text;
                XMLLoadLocale(n83, ref target);
                tBNew.Text = target;
                XmlElement n84 = eStatusBar["ByValue"];
                tBNew = BVCCalculate;
                target = tBNew.Text;
                XMLLoadLocale(n84, ref target);
                tBNew.Text = target;
            }
            XmlElement eSubMenu = Root["SubMenu"];
            if (eSubMenu != null)
            {
                XmlElement eShowHide = eSubMenu["ShowHide"];
                if (eShowHide != null)
                {
                    XmlElement n85 = eShowHide["Menu"];
                    ToolStripMenuItem toolStripMenuItem = mnSMenu;
                    string target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n85, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n86 = eShowHide["ToolBar"];
                    toolStripMenuItem = mnSTB;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n86, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n87 = eShowHide["OptionsPanel"];
                    toolStripMenuItem = mnSOP;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n87, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n88 = eShowHide["StatusBar"];
                    toolStripMenuItem = mnSStatus;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n88, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n89 = eShowHide["LSplit"];
                    toolStripMenuItem = mnSLSplitter;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n89, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n90 = eShowHide["RSplit"];
                    toolStripMenuItem = mnSRSplitter;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n90, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n91 = eShowHide["Grid"];
                    toolStripMenuItem = CGShow;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n91, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n92 = eShowHide["Sub"];
                    toolStripMenuItem = CGShowS;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n92, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n93 = eShowHide["BG"];
                    toolStripMenuItem = CGShowBG;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n93, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n94 = eShowHide["MeasureIndex"];
                    toolStripMenuItem = CGShowM;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n94, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n95 = eShowHide["MeasureLine"];
                    toolStripMenuItem = CGShowMB;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n95, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n96 = eShowHide["Vertical"];
                    toolStripMenuItem = CGShowV;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n96, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n97 = eShowHide["ColumnCaption"];
                    toolStripMenuItem = CGShowC;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n97, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n98 = eShowHide["BPM"];
                    toolStripMenuItem = CGBPM;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n98, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n99 = eShowHide["STOP"];
                    toolStripMenuItem = CGSTOP;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n99, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n100 = eShowHide["SCROLL"];
                    toolStripMenuItem = CGSCROLL;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n100, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n101 = eShowHide["BLP"];
                    toolStripMenuItem = CGBLP;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n101, ref target);
                    toolStripMenuItem.Text = target;
                }
                XmlElement eInsertMeasure = eSubMenu["InsertMeasure"];
                if (eInsertMeasure != null)
                {
                    XmlElement n102 = eInsertMeasure["Insert"];
                    ToolStripMenuItem toolStripMenuItem = MInsert;
                    string target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n102, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n103 = eInsertMeasure["Remove"];
                    toolStripMenuItem = MRemove;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n103, ref target);
                    toolStripMenuItem.Text = target;
                }
                XmlElement eLanguage = eSubMenu["Language"];
                if (eLanguage != null)
                {
                    XmlElement n104 = eLanguage["Default"];
                    ToolStripMenuItem toolStripMenuItem = TBLangDef;
                    string target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n104, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n105 = eLanguage["Refresh"];
                    toolStripMenuItem = TBLangRefresh;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n105, ref target);
                    toolStripMenuItem.Text = target;
                }
                XmlElement eTheme = eSubMenu["Theme"];
                if (eTheme != null)
                {
                    XmlElement n106 = eTheme["Default"];
                    ToolStripMenuItem toolStripMenuItem = TBThemeDef;
                    string target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n106, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n107 = eTheme["Save"];
                    toolStripMenuItem = TBThemeSave;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n107, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n108 = eTheme["Refresh"];
                    toolStripMenuItem = TBThemeRefresh;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n108, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n109 = eTheme["LoadComptability"];
                    toolStripMenuItem = TBThemeLoadComptability;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n109, ref target);
                    toolStripMenuItem.Text = target;
                }
                XmlElement eConvert = eSubMenu["Convert"];
                if (eConvert != null)
                {
                    XmlElement n110 = eConvert["Long"];
                    ToolStripMenuItem toolStripMenuItem = POBLong;
                    string target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n110, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n111 = eConvert["Short"];
                    toolStripMenuItem = POBShort;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n111, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n112 = eConvert["LongShort"];
                    toolStripMenuItem = POBLongShort;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n112, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n113 = eConvert["Hidden"];
                    toolStripMenuItem = POBHidden;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n113, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n114 = eConvert["Visible"];
                    toolStripMenuItem = POBVisible;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n114, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n115 = eConvert["HiddenVisible"];
                    toolStripMenuItem = POBHiddenVisible;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n115, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n116 = eConvert["Relabel"];
                    toolStripMenuItem = POBModify;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n116, ref target);
                    toolStripMenuItem.Text = target;
                    XmlElement n117 = eConvert["Mirror"];
                    toolStripMenuItem = POBMirror;
                    target = toolStripMenuItem.Text;
                    XMLLoadLocaleMenu(n117, ref target);
                    toolStripMenuItem.Text = target;
                }

                XmlElement eWAV = eSubMenu["WAV"];
                if (eWAV != null)
                {
                    XmlElement n118 = eWAV["MultiSelection"];
                    CheckBox cWAVMultiSelect = CWAVMultiSelect;
                    string target = cWAVMultiSelect.Text;
                    XMLLoadLocaleMenu(n118, ref target);
                    cWAVMultiSelect.Text = target;
                    XmlElement n119 = eWAV["Synchronize"];
                    cWAVMultiSelect = CWAVChangeLabel;
                    target = cWAVMultiSelect.Text;
                    XMLLoadLocaleMenu(n119, ref target);
                    cWAVMultiSelect.Text = target;
                }

                XmlElement eBeat = eSubMenu["Beat"];
                if (eBeat != null)
                {
                    XmlElement n120 = eBeat["Absolute"];
                    RadioButton cBeatPreserve = CBeatPreserve;
                    string target = cBeatPreserve.Text;
                    XMLLoadLocaleMenu(n120, ref target);
                    cBeatPreserve.Text = target;
                    XmlElement n121 = eBeat["Measure"];
                    cBeatPreserve = CBeatMeasure;
                    target = cBeatPreserve.Text;
                    XMLLoadLocaleMenu(n121, ref target);
                    cBeatPreserve.Text = target;
                    XmlElement n122 = eBeat["Cut"];
                    cBeatPreserve = CBeatCut;
                    target = cBeatPreserve.Text;
                    XMLLoadLocaleMenu(n122, ref target);
                    cBeatPreserve.Text = target;
                    XmlElement n123 = eBeat["Scale"];
                    cBeatPreserve = CBeatScale;
                    target = cBeatPreserve.Text;
                    XMLLoadLocaleMenu(n123, ref target);
                    cBeatPreserve.Text = target;
                }
            }

            XmlElement eOptionsPanel = Root["OptionsPanel"];
            if (eOptionsPanel != null)
            {
                XmlElement eHeader = eOptionsPanel["Header"];
                CheckBox cWAVMultiSelect;
                string target;
                if (eHeader != null)
                {
                    XmlElement n124 = eHeader["Header"];
                    cWAVMultiSelect = POHeaderSwitch;
                    target = cWAVMultiSelect.Text;
                    XMLLoadLocale(n124, ref target);
                    cWAVMultiSelect.Text = target;
                    XmlElement n125 = eHeader["Title"];
                    Label label = Label3;
                    target = label.Text;
                    XMLLoadLocale(n125, ref target);
                    label.Text = target;
                    XmlElement n126 = eHeader["Artist"];
                    label = Label4;
                    target = label.Text;
                    XMLLoadLocale(n126, ref target);
                    label.Text = target;
                    XmlElement n127 = eHeader["Genre"];
                    label = Label2;
                    target = label.Text;
                    XMLLoadLocale(n127, ref target);
                    label.Text = target;
                    XmlElement n128 = eHeader["BPM"];
                    label = Label9;
                    target = label.Text;
                    XMLLoadLocale(n128, ref target);
                    label.Text = target;
                    XmlElement n129 = eHeader["Player"];
                    label = Label8;
                    target = label.Text;
                    XMLLoadLocale(n129, ref target);
                    label.Text = target;
                    XmlElement n130 = eHeader["Rank"];
                    label = Label10;
                    target = label.Text;
                    XMLLoadLocale(n130, ref target);
                    label.Text = target;
                    XmlElement n131 = eHeader["PlayLevel"];
                    label = Label6;
                    target = label.Text;
                    XMLLoadLocale(n131, ref target);
                    label.Text = target;
                    XmlElement n132 = eHeader["SubTitle"];
                    label = Label15;
                    target = label.Text;
                    XMLLoadLocale(n132, ref target);
                    label.Text = target;
                    XmlElement n133 = eHeader["SubArtist"];
                    label = Label17;
                    target = label.Text;
                    XMLLoadLocale(n133, ref target);
                    label.Text = target;
                    XmlElement n134 = eHeader["StageFile"];
                    label = Label16;
                    target = label.Text;
                    XMLLoadLocale(n134, ref target);
                    label.Text = target;
                    XmlElement n135 = eHeader["Banner"];
                    label = Label12;
                    target = label.Text;
                    XMLLoadLocale(n135, ref target);
                    label.Text = target;
                    XmlElement n136 = eHeader["BackBMP"];
                    label = Label11;
                    target = label.Text;
                    XMLLoadLocale(n136, ref target);
                    label.Text = target;
                    XmlElement n137 = eHeader["Difficulty"];
                    label = Label21;
                    target = label.Text;
                    XMLLoadLocale(n137, ref target);
                    label.Text = target;
                    XmlElement n138 = eHeader["ExRank"];
                    label = Label23;
                    target = label.Text;
                    XMLLoadLocale(n138, ref target);
                    label.Text = target;
                    XmlElement n139 = eHeader["Total"];
                    label = Label20;
                    target = label.Text;
                    XMLLoadLocale(n139, ref target);
                    label.Text = target;
                    XmlElement n140 = eHeader["Comment"];
                    label = Label19;
                    target = label.Text;
                    XMLLoadLocale(n140, ref target);
                    label.Text = target;
                    XmlElement n141 = eHeader["LnObj"];
                    label = Label24;
                    target = label.Text;
                    XMLLoadLocale(n141, ref target);
                    label.Text = target;
                    CHPlayer.SelectedIndexChanged -= CHPlayer_SelectedIndexChanged;
                    XmlElement n142 = eHeader["Player1"];
                    ComboBox.ObjectCollection items = CHPlayer.Items;
                    ComboBox.ObjectCollection objectCollection = items;
                    int index = 0;
                    target = Conversions.ToString(objectCollection[index]);
                    XMLLoadLocale(n142, ref target);
                    items[index] = target;
                    XmlElement n143 = eHeader["Player2"];
                    items = CHPlayer.Items;
                    ComboBox.ObjectCollection objectCollection2 = items;
                    index = 1;
                    target = Conversions.ToString(objectCollection2[index]);
                    XMLLoadLocale(n143, ref target);
                    items[index] = target;
                    XmlElement n144 = eHeader["Player3"];
                    items = CHPlayer.Items;
                    ComboBox.ObjectCollection objectCollection3 = items;
                    index = 2;
                    target = Conversions.ToString(objectCollection3[index]);
                    XMLLoadLocale(n144, ref target);
                    items[index] = target;
                    CHPlayer.SelectedIndexChanged += CHPlayer_SelectedIndexChanged;
                    CHRank.SelectedIndexChanged -= THGenre_TextChanged;
                    XmlElement n145 = eHeader["Rank0"];
                    items = CHRank.Items;
                    ComboBox.ObjectCollection objectCollection4 = items;
                    index = 0;
                    target = Conversions.ToString(objectCollection4[index]);
                    XMLLoadLocale(n145, ref target);
                    items[index] = target;
                    XmlElement n146 = eHeader["Rank1"];
                    items = CHRank.Items;
                    ComboBox.ObjectCollection objectCollection5 = items;
                    index = 1;
                    target = Conversions.ToString(objectCollection5[index]);
                    XMLLoadLocale(n146, ref target);
                    items[index] = target;
                    XmlElement n147 = eHeader["Rank2"];
                    items = CHRank.Items;
                    ComboBox.ObjectCollection objectCollection6 = items;
                    index = 2;
                    target = Conversions.ToString(objectCollection6[index]);
                    XMLLoadLocale(n147, ref target);
                    items[index] = target;
                    XmlElement n148 = eHeader["Rank3"];
                    items = CHRank.Items;
                    ComboBox.ObjectCollection objectCollection7 = items;
                    index = 3;
                    target = Conversions.ToString(objectCollection7[index]);
                    XMLLoadLocale(n148, ref target);
                    items[index] = target;
                    XmlElement n149 = eHeader["Rank4"];
                    items = CHRank.Items;
                    ComboBox.ObjectCollection objectCollection8 = items;
                    index = 4;
                    target = Conversions.ToString(objectCollection8[index]);
                    XMLLoadLocale(n149, ref target);
                    items[index] = target;
                    CHRank.SelectedIndexChanged += THGenre_TextChanged;
                    CHDifficulty.SelectedIndexChanged -= THGenre_TextChanged;
                    XmlElement n150 = eHeader["Difficulty0"];
                    items = CHDifficulty.Items;
                    ComboBox.ObjectCollection objectCollection9 = items;
                    index = 0;
                    target = Conversions.ToString(objectCollection9[index]);
                    XMLLoadLocale(n150, ref target);
                    items[index] = target;
                    XmlElement n151 = eHeader["Difficulty1"];
                    items = CHDifficulty.Items;
                    ComboBox.ObjectCollection objectCollection10 = items;
                    index = 1;
                    target = Conversions.ToString(objectCollection10[index]);
                    XMLLoadLocale(n151, ref target);
                    items[index] = target;
                    XmlElement n152 = eHeader["Difficulty2"];
                    items = CHDifficulty.Items;
                    ComboBox.ObjectCollection objectCollection11 = items;
                    index = 2;
                    target = Conversions.ToString(objectCollection11[index]);
                    XMLLoadLocale(n152, ref target);
                    items[index] = target;
                    XmlElement n153 = eHeader["Difficulty3"];
                    items = CHDifficulty.Items;
                    ComboBox.ObjectCollection objectCollection12 = items;
                    index = 3;
                    target = Conversions.ToString(objectCollection12[index]);
                    XMLLoadLocale(n153, ref target);
                    items[index] = target;
                    XmlElement n154 = eHeader["Difficulty4"];
                    items = CHDifficulty.Items;
                    ComboBox.ObjectCollection objectCollection13 = items;
                    index = 4;
                    target = Conversions.ToString(objectCollection13[index]);
                    XMLLoadLocale(n154, ref target);
                    items[index] = target;
                    XmlElement n155 = eHeader["Difficulty5"];
                    items = CHDifficulty.Items;
                    ComboBox.ObjectCollection objectCollection14 = items;
                    index = 5;
                    target = Conversions.ToString(objectCollection14[index]);
                    XMLLoadLocale(n155, ref target);
                    items[index] = target;
                    CHDifficulty.SelectedIndexChanged += THGenre_TextChanged;
                }

                XmlElement eGrid = eOptionsPanel["Grid"];
                if (eGrid != null)
                {
                    XmlElement n156 = eGrid["Title"];
                    cWAVMultiSelect = POGridSwitch;
                    target = cWAVMultiSelect.Text;
                    XMLLoadLocale(n156, ref target);
                    cWAVMultiSelect.Text = target;
                    XmlElement n157 = eGrid["Snap"];
                    cWAVMultiSelect = CGSnap;
                    target = cWAVMultiSelect.Text;
                    XMLLoadLocale(n157, ref target);
                    cWAVMultiSelect.Text = target;
                    XmlElement n158 = eGrid["BCols"];
                    Label label = Label1;
                    target = label.Text;
                    XMLLoadLocale(n158, ref target);
                    label.Text = target;
                    XmlElement n159 = eGrid["DisableVertical"];
                    cWAVMultiSelect = CGDisableVertical;
                    target = cWAVMultiSelect.Text;
                    XMLLoadLocale(n159, ref target);
                    cWAVMultiSelect.Text = target;
                    XmlElement n160 = eGrid["Scroll"];
                    label = Label5;
                    target = label.Text;
                    XMLLoadLocale(n160, ref target);
                    label.Text = target;
                    XMLLoadLocaleToolTipUniversal(eGrid["LockLeft"], cVSLockL);
                    XMLLoadLocaleToolTipUniversal(eGrid["LockMiddle"], cVSLock);
                    XMLLoadLocaleToolTipUniversal(eGrid["LockRight"], cVSLockR);
                }

                XmlElement eWaveForm = eOptionsPanel["WaveForm"];
                if (eWaveForm != null)
                {
                    XmlElement n161 = eWaveForm["Title"];
                    cWAVMultiSelect = POWaveFormSwitch;
                    target = cWAVMultiSelect.Text;
                    XMLLoadLocale(n161, ref target);
                    cWAVMultiSelect.Text = target;
                    XMLLoadLocaleToolTipUniversal(eWaveForm["Load"], BWLoad);
                    XMLLoadLocaleToolTipUniversal(eWaveForm["Clear"], BWClear);
                    XMLLoadLocaleToolTipUniversal(eWaveForm["Lock"], BWLock);
                }

                XmlElement eWAV = eOptionsPanel["WAV"];
                if (eWAV != null)
                {
                    XmlElement n162 = eWAV["Title"];
                    cWAVMultiSelect = POWAVSwitch;
                    target = cWAVMultiSelect.Text;
                    XMLLoadLocale(n162, ref target);
                    cWAVMultiSelect.Text = target;
                    XMLLoadLocaleToolTipUniversal(eWAV["MoveUp"], BWAVUp);
                    XMLLoadLocaleToolTipUniversal(eWAV["MoveDown"], BWAVDown);
                    XMLLoadLocaleToolTipUniversal(eWAV["Browse"], BWAVBrowse);
                    XMLLoadLocaleToolTipUniversal(eWAV["Remove"], BWAVRemove);
                }

                XmlElement n163 = eOptionsPanel["Beat"];
                cWAVMultiSelect = POBeatSwitch;
                target = cWAVMultiSelect.Text;
                XMLLoadLocale(n163, ref target);
                cWAVMultiSelect.Text = target;
                XmlElement n164 = eOptionsPanel["Beat.Apply"];
                Button bBeatApply = BBeatApply;
                target = bBeatApply.Text;
                XMLLoadLocale(n164, ref target);
                bBeatApply.Text = target;
                XmlElement n165 = eOptionsPanel["Beat.Apply"];
                bBeatApply = BBeatApplyV;
                target = bBeatApply.Text;
                XMLLoadLocale(n165, ref target);
                bBeatApply.Text = target;
                XmlElement n166 = eOptionsPanel["Expansion"];
                cWAVMultiSelect = POExpansionSwitch;
                target = cWAVMultiSelect.Text;
                XMLLoadLocale(n166, ref target);
                cWAVMultiSelect.Text = target;
            }
            XmlElement eMessages = Root["Messages"];
            if (eMessages != null)
            {
                XMLLoadLocale(eMessages["Err"], ref Strings.Messages.Err);
                XMLLoadLocale(eMessages["SaveOnExit"], ref Strings.Messages.SaveOnExit);
                XMLLoadLocale(eMessages["SaveOnExit1"], ref Strings.Messages.SaveOnExit1);
                XMLLoadLocale(eMessages["SaveOnExit2"], ref Strings.Messages.SaveOnExit2);
                XMLLoadLocale(eMessages["PromptEnter"], ref Strings.Messages.PromptEnter);
                XMLLoadLocale(eMessages["PromptEnterNumeric"], ref Strings.Messages.PromptEnterNumeric);
                XMLLoadLocale(eMessages["PromptEnterBPM"], ref Strings.Messages.PromptEnterBPM);
                XMLLoadLocale(eMessages["PromptEnterSTOP"], ref Strings.Messages.PromptEnterSTOP);
                XMLLoadLocale(eMessages["PromptEnterSCROLL"], ref Strings.Messages.PromptEnterSCROLL);
                XMLLoadLocale(eMessages["PromptSlashValue"], ref Strings.Messages.PromptSlashValue);
                XMLLoadLocale(eMessages["InvalidLabel"], ref Strings.Messages.InvalidLabel);
                XMLLoadLocale(eMessages["CannotFind"], ref Strings.Messages.CannotFind);
                XMLLoadLocale(eMessages["PleaseRespecifyPath"], ref Strings.Messages.PleaseRespecifyPath);
                XMLLoadLocale(eMessages["PlayerNotFound"], ref Strings.Messages.PlayerNotFound);
                XMLLoadLocale(eMessages["PreviewDelError"], ref Strings.Messages.PreviewDelError);
                XMLLoadLocale(eMessages["NegativeFactorError"], ref Strings.Messages.NegativeFactorError);
                XMLLoadLocale(eMessages["NegativeDivisorError"], ref Strings.Messages.NegativeDivisorError);
                XMLLoadLocale(eMessages["PreferencePostpone"], ref Strings.Messages.PreferencePostpone);
                XMLLoadLocale(eMessages["EraserObsolete"], ref Strings.Messages.EraserObsolete);
                XMLLoadLocale(eMessages["SaveWarning"], ref Strings.Messages.SaveWarning);
                XMLLoadLocale(eMessages["NoteOverlapError"], ref Strings.Messages.NoteOverlapError);
                XMLLoadLocale(eMessages["BPMOverflowError"], ref Strings.Messages.BPMOverflowError);
                XMLLoadLocale(eMessages["STOPOverflowError"], ref Strings.Messages.STOPOverflowError);
                XMLLoadLocale(eMessages["SCROLLOverflowError"], ref Strings.Messages.SCROLLOverflowError);
                XMLLoadLocale(eMessages["SavedFileWillContainErrors"], ref Strings.Messages.SavedFileWillContainErrors);
                XMLLoadLocale(eMessages["FileAssociationPrompt"], ref Strings.Messages.FileAssociationPrompt);
                XMLLoadLocale(eMessages["FileAssociationError"], ref Strings.Messages.FileAssociationError);
                XMLLoadLocale(eMessages["RestoreDefaultSettings"], ref Strings.Messages.RestoreDefaultSettings);
                XMLLoadLocale(eMessages["RestoreAutosavedFile"], ref Strings.Messages.RestoreAutosavedFile);
            }
            XmlElement eFileType = Root["FileType"];
            if (eFileType != null)
            {
                XMLLoadLocale(eFileType["_all"], ref Strings.FileType._all);
                XMLLoadLocale(eFileType["_bms"], ref Strings.FileType._bms);
                XMLLoadLocale(eFileType["BMS"], ref Strings.FileType.BMS);
                XMLLoadLocale(eFileType["BME"], ref Strings.FileType.BME);
                XMLLoadLocale(eFileType["BML"], ref Strings.FileType.BML);
                XMLLoadLocale(eFileType["PMS"], ref Strings.FileType.PMS);
                XMLLoadLocale(eFileType["TXT"], ref Strings.FileType.TXT);
                XMLLoadLocale(eFileType["SM"], ref Strings.FileType.SM);
                XMLLoadLocale(eFileType["IBMSC"], ref Strings.FileType.IBMSC);
                XMLLoadLocale(eFileType["XML"], ref Strings.FileType.XML);
                XMLLoadLocale(eFileType["THEME_XML"], ref Strings.FileType.THEME_XML);
                XMLLoadLocale(eFileType["TH"], ref Strings.FileType.TH);
                XMLLoadLocale(eFileType["_audio"], ref Strings.FileType._audio);
                XMLLoadLocale(eFileType["_wave"], ref Strings.FileType._wave);
                XMLLoadLocale(eFileType["WAV"], ref Strings.FileType.WAV);
                XMLLoadLocale(eFileType["OGG"], ref Strings.FileType.OGG);
                XMLLoadLocale(eFileType["MP3"], ref Strings.FileType.MP3);
                XMLLoadLocale(eFileType["MID"], ref Strings.FileType.MID);
                XMLLoadLocale(eFileType["_image"], ref Strings.FileType._image);
                XMLLoadLocale(eFileType["EXE"], ref Strings.FileType.EXE);
            }
            XmlElement eStatistics = Root["Statistics"];
            if (eStatistics != null)
            {
                XMLLoadLocale(eStatistics["Title"], ref Strings.fStatistics.Title);
                XMLLoadLocale(eStatistics["lBPM"], ref Strings.fStatistics.lBPM);
                XMLLoadLocale(eStatistics["lSTOP"], ref Strings.fStatistics.lSTOP);
                XMLLoadLocale(eStatistics["lSCROLL"], ref Strings.fStatistics.lSCROLL);
                XMLLoadLocale(eStatistics["lA"], ref Strings.fStatistics.lA);
                XMLLoadLocale(eStatistics["lD"], ref Strings.fStatistics.lD);
                XMLLoadLocale(eStatistics["lBGM"], ref Strings.fStatistics.lBGM);
                XMLLoadLocale(eStatistics["lTotal"], ref Strings.fStatistics.lTotal);
                XMLLoadLocale(eStatistics["lShort"], ref Strings.fStatistics.lShort);
                XMLLoadLocale(eStatistics["lLong"], ref Strings.fStatistics.lLong);
                XMLLoadLocale(eStatistics["lLnObj"], ref Strings.fStatistics.lLnObj);
                XMLLoadLocale(eStatistics["lHidden"], ref Strings.fStatistics.lHidden);
                XMLLoadLocale(eStatistics["lErrors"], ref Strings.fStatistics.lErrors);
            }
            XmlElement ePlayerOptions = Root["PlayerOptions"];
            if (ePlayerOptions != null)
            {
                XMLLoadLocale(ePlayerOptions["Title"], ref Strings.fopPlayer.Title);
                XMLLoadLocale(ePlayerOptions["Add"], ref Strings.fopPlayer.Add);
                XMLLoadLocale(ePlayerOptions["Remove"], ref Strings.fopPlayer.Remove);
                XMLLoadLocale(ePlayerOptions["Path"], ref Strings.fopPlayer.Path);
                XMLLoadLocale(ePlayerOptions["PlayFromBeginning"], ref Strings.fopPlayer.PlayFromBeginning);
                XMLLoadLocale(ePlayerOptions["PlayFromHere"], ref Strings.fopPlayer.PlayFromHere);
                XMLLoadLocale(ePlayerOptions["StopPlaying"], ref Strings.fopPlayer.StopPlaying);
                XMLLoadLocale(ePlayerOptions["References"], ref Strings.fopPlayer.References);
                XMLLoadLocale(ePlayerOptions["DirectoryOfApp"], ref Strings.fopPlayer.DirectoryOfApp);
                XMLLoadLocale(ePlayerOptions["CurrMeasure"], ref Strings.fopPlayer.CurrMeasure);
                XMLLoadLocale(ePlayerOptions["FileName"], ref Strings.fopPlayer.FileName);
                XMLLoadLocale(ePlayerOptions["RestoreDefault"], ref Strings.fopPlayer.RestoreDefault);
            }
            XmlElement eVisualOptions = Root["VisualOptions"];
            if (eVisualOptions != null)
            {
                XMLLoadLocale(eVisualOptions["Title"], ref Strings.fopVisual.Title);
                XMLLoadLocale(eVisualOptions["Width"], ref Strings.fopVisual.Width);
                XMLLoadLocale(eVisualOptions["Caption"], ref Strings.fopVisual.Caption);
                XMLLoadLocale(eVisualOptions["Note"], ref Strings.fopVisual.Note);
                XMLLoadLocale(eVisualOptions["Label"], ref Strings.fopVisual.Label);
                XMLLoadLocale(eVisualOptions["LongNote"], ref Strings.fopVisual.LongNote);
                XMLLoadLocale(eVisualOptions["LongNoteLabel"], ref Strings.fopVisual.LongNoteLabel);
                XMLLoadLocale(eVisualOptions["Bg"], ref Strings.fopVisual.Bg);
                XMLLoadLocale(eVisualOptions["ColumnCaption"], ref Strings.fopVisual.ColumnCaption);
                XMLLoadLocale(eVisualOptions["ColumnCaptionFont"], ref Strings.fopVisual.ColumnCaptionFont);
                XMLLoadLocale(eVisualOptions["Background"], ref Strings.fopVisual.Background);
                XMLLoadLocale(eVisualOptions["Grid"], ref Strings.fopVisual.Grid);
                XMLLoadLocale(eVisualOptions["SubGrid"], ref Strings.fopVisual.SubGrid);
                XMLLoadLocale(eVisualOptions["VerticalLine"], ref Strings.fopVisual.VerticalLine);
                XMLLoadLocale(eVisualOptions["MeasureBarLine"], ref Strings.fopVisual.MeasureBarLine);
                XMLLoadLocale(eVisualOptions["BGMWaveform"], ref Strings.fopVisual.BGMWaveform);
                XMLLoadLocale(eVisualOptions["NoteHeight"], ref Strings.fopVisual.NoteHeight);
                XMLLoadLocale(eVisualOptions["NoteLabel"], ref Strings.fopVisual.NoteLabel);
                XMLLoadLocale(eVisualOptions["MeasureLabel"], ref Strings.fopVisual.MeasureLabel);
                XMLLoadLocale(eVisualOptions["LabelVerticalShift"], ref Strings.fopVisual.LabelVerticalShift);
                XMLLoadLocale(eVisualOptions["LabelHorizontalShift"], ref Strings.fopVisual.LabelHorizontalShift);
                XMLLoadLocale(eVisualOptions["LongNoteLabelHorizontalShift"], ref Strings.fopVisual.LongNoteLabelHorizontalShift);
                XMLLoadLocale(eVisualOptions["HiddenNoteOpacity"], ref Strings.fopVisual.HiddenNoteOpacity);
                XMLLoadLocale(eVisualOptions["NoteBorderOnMouseOver"], ref Strings.fopVisual.NoteBorderOnMouseOver);
                XMLLoadLocale(eVisualOptions["NoteBorderOnSelection"], ref Strings.fopVisual.NoteBorderOnSelection);
                XMLLoadLocale(eVisualOptions["NoteBorderOnAdjustingLength"], ref Strings.fopVisual.NoteBorderOnAdjustingLength);
                XMLLoadLocale(eVisualOptions["SelectionBoxBorder"], ref Strings.fopVisual.SelectionBoxBorder);
                XMLLoadLocale(eVisualOptions["TSCursor"], ref Strings.fopVisual.TSCursor);
                XMLLoadLocale(eVisualOptions["TSSplitter"], ref Strings.fopVisual.TSSplitter);
                XMLLoadLocale(eVisualOptions["TSCursorSensitivity"], ref Strings.fopVisual.TSCursorSensitivity);
                XMLLoadLocale(eVisualOptions["TSMouseOverBorder"], ref Strings.fopVisual.TSMouseOverBorder);
                XMLLoadLocale(eVisualOptions["TSFill"], ref Strings.fopVisual.TSFill);
                XMLLoadLocale(eVisualOptions["TSBPM"], ref Strings.fopVisual.TSBPM);
                XMLLoadLocale(eVisualOptions["TSBPMFont"], ref Strings.fopVisual.TSBPMFont);
                XMLLoadLocale(eVisualOptions["MiddleSensitivity"], ref Strings.fopVisual.MiddleSensitivity);
            }
            XmlElement eGeneralOptions = Root["GeneralOptions"];
            if (eGeneralOptions != null)
            {
                XMLLoadLocale(eGeneralOptions["Title"], ref Strings.fopGeneral.Title);
                XMLLoadLocale(eGeneralOptions["MouseWheel"], ref Strings.fopGeneral.MouseWheel);
                XMLLoadLocale(eGeneralOptions["TextEncoding"], ref Strings.fopGeneral.TextEncoding);
                XMLLoadLocale(eGeneralOptions["PageUpDown"], ref Strings.fopGeneral.PageUpDown);
                XMLLoadLocale(eGeneralOptions["MiddleButton"], ref Strings.fopGeneral.MiddleButton);
                XMLLoadLocale(eGeneralOptions["MiddleButtonAuto"], ref Strings.fopGeneral.MiddleButtonAuto);
                XMLLoadLocale(eGeneralOptions["MiddleButtonDrag"], ref Strings.fopGeneral.MiddleButtonDrag);
                XMLLoadLocale(eGeneralOptions["AssociateFileType"], ref Strings.fopGeneral.AssociateFileType);
                XMLLoadLocale(eGeneralOptions["MaxGridPartition"], ref Strings.fopGeneral.MaxGridPartition);
                XMLLoadLocale(eGeneralOptions["BeepWhileSaved"], ref Strings.fopGeneral.BeepWhileSaved);
                XMLLoadLocale(eGeneralOptions["ExtendBPM"], ref Strings.fopGeneral.ExtendBPM);
                XMLLoadLocale(eGeneralOptions["ExtendSTOP"], ref Strings.fopGeneral.ExtendSTOP);
                XMLLoadLocale(eGeneralOptions["AutoFocusOnMouseEnter"], ref Strings.fopGeneral.AutoFocusOnMouseEnter);
                XMLLoadLocale(eGeneralOptions["DisableFirstClick"], ref Strings.fopGeneral.DisableFirstClick);
                XMLLoadLocale(eGeneralOptions["AutoSave"], ref Strings.fopGeneral.AutoSave);
                XMLLoadLocale(eGeneralOptions["minutes"], ref Strings.fopGeneral.minutes);
                XMLLoadLocale(eGeneralOptions["StopPreviewOnClick"], ref Strings.fopGeneral.StopPreviewOnClick);
            }
            XmlElement eFind = Root["Find"];
            if (eFind != null)
            {
                XMLLoadLocale(eFind["NoteRange"], ref Strings.fFind.NoteRange);
                XMLLoadLocale(eFind["MeasureRange"], ref Strings.fFind.MeasureRange);
                XMLLoadLocale(eFind["LabelRange"], ref Strings.fFind.LabelRange);
                XMLLoadLocale(eFind["ValueRange"], ref Strings.fFind.ValueRange);
                XMLLoadLocale(eFind["to"], ref Strings.fFind.to_);
                XMLLoadLocale(eFind["Selected"], ref Strings.fFind.Selected);
                XMLLoadLocale(eFind["UnSelected"], ref Strings.fFind.UnSelected);
                XMLLoadLocale(eFind["ShortNote"], ref Strings.fFind.ShortNote);
                XMLLoadLocale(eFind["LongNote"], ref Strings.fFind.LongNote);
                XMLLoadLocale(eFind["Hidden"], ref Strings.fFind.Hidden);
                XMLLoadLocale(eFind["Visible"], ref Strings.fFind.Visible);
                XMLLoadLocale(eFind["Column"], ref Strings.fFind.Column);
                XMLLoadLocale(eFind["SelectAll"], ref Strings.fFind.SelectAll);
                XMLLoadLocale(eFind["SelectInverse"], ref Strings.fFind.SelectInverse);
                XMLLoadLocale(eFind["UnselectAll"], ref Strings.fFind.UnselectAll);
                XMLLoadLocale(eFind["Operation"], ref Strings.fFind.Operation);
                XMLLoadLocale(eFind["ReplaceWithLabel"], ref Strings.fFind.ReplaceWithLabel);
                XMLLoadLocale(eFind["ReplaceWithValue"], ref Strings.fFind.ReplaceWithValue);
                XMLLoadLocale(eFind["Select"], ref Strings.fFind.Select_);
                XMLLoadLocale(eFind["Unselect"], ref Strings.fFind.Unselect_);
                XMLLoadLocale(eFind["Delete"], ref Strings.fFind.Delete_);
                XMLLoadLocale(eFind["Close"], ref Strings.fFind.Close_);
            }

            XmlElement eImportSM = Root["ImportSM"];
            if (eImportSM != null)
            {
                XMLLoadLocale(eImportSM["Title"], ref Strings.fImportSM.Title);
                XMLLoadLocale(eImportSM["Difficulty"], ref Strings.fImportSM.Difficulty);
                XMLLoadLocale(eImportSM["Note"], ref Strings.fImportSM.Note);
            }

            XmlElement eFileAssociation = Root["FileAssociation"];
            if (eFileAssociation != null)
            {
                XMLLoadLocale(eFileAssociation["BMS"], ref Strings.FileAssociation.BMS);
                XMLLoadLocale(eFileAssociation["BME"], ref Strings.FileAssociation.BME);
                XMLLoadLocale(eFileAssociation["BML"], ref Strings.FileAssociation.BML);
                XMLLoadLocale(eFileAssociation["PMS"], ref Strings.FileAssociation.PMS);
                XMLLoadLocale(eFileAssociation["IBMSC"], ref Strings.FileAssociation.IBMSC);
                XMLLoadLocale(eFileAssociation["Open"], ref Strings.FileAssociation.Open);
                XMLLoadLocale(eFileAssociation["Preview"], ref Strings.FileAssociation.Preview);
                XMLLoadLocale(eFileAssociation["ViewCode"], ref Strings.FileAssociation.ViewCode);
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
            FileStream?.Close();
            POHeaderPart2.Visible = xPOHeaderPart2;
            POGridPart2.Visible = xPOGridPart2;
            POWaveFormPart2.Visible = xPOWaveFormPart2;
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

    private void LoadTheme(object sender, EventArgs e)
    {
        LoadSettings(Conversions.ToString(Operators.ConcatenateObject(MyProject.Application.Info.DirectoryPath + "\\Data\\", NewLateBinding.LateGet(sender, null, "Text", Array.Empty<object>(), null, null, null))));
        RefreshPanelAll();
    }
}