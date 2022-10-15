using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace iBMSC
{

    public partial class MainWindow : Form
    {

        private void XMLWriteColumn(XmlTextWriter w, int I)
        {
            w.WriteStartElement("Column");
            w.WriteAttributeString("Index", I.ToString());
            {
                ref var withBlock = ref this.column[I];
                // w.WriteAttributeString("Left", .Left)
                w.WriteAttributeString("Width", withBlock.Width.ToString());
                w.WriteAttributeString("Title", withBlock.Title);
                // w.WriteAttributeString("Text", .Text)
                // w.WriteAttributeString("Enabled", .Enabled)
                // w.WriteAttributeString("isNumeric", .isNumeric)
                // w.WriteAttributeString("Visible", .Visible)
                // w.WriteAttributeString("Identifier", .Identifier)
                w.WriteAttributeString("NoteColor", withBlock.cNote.ToString());
                w.WriteAttributeString("TextColor", withBlock.cText.ToArgb().ToString());
                w.WriteAttributeString("LongNoteColor", withBlock.cLNote.ToString());
                w.WriteAttributeString("LongTextColor", withBlock.cLText.ToArgb().ToString());
                w.WriteAttributeString("BG", withBlock.cBG.ToArgb().ToString());
            }
            w.WriteEndElement();
        }

        private void XMLWriteFont(XmlTextWriter w, string local, Font f)
        {
            w.WriteStartElement(local);
            w.WriteAttributeString("Name", f.FontFamily.Name);
            w.WriteAttributeString("Size", f.SizeInPoints.ToString());
            w.WriteAttributeString("Style", ((int)f.Style).ToString());
            w.WriteEndElement();
        }

        private void XMLWritePlayerArguments(XmlTextWriter w, int I)
        {
            w.WriteStartElement("Player");
            w.WriteAttributeString("Index", I.ToString());
            w.WriteAttributeString("Path", this.pArgs[I].Path);
            w.WriteAttributeString("FromBeginning", this.pArgs[I].aBegin);
            w.WriteAttributeString("FromHere", this.pArgs[I].aHere);
            w.WriteAttributeString("Stop", this.pArgs[I].aStop);
            w.WriteEndElement();
        }

        private void SaveSettings(string Path, bool ThemeOnly)
        {
            var w = new XmlTextWriter(Path, System.Text.Encoding.Unicode);
            w.WriteStartDocument();
            w.Formatting = Formatting.Indented;
            w.Indentation = 4;

            w.WriteStartElement("iBMSC");
            w.WriteAttributeString("Major", iBMSC.My.MyProject.Application.Info.Version.Major.ToString());
            w.WriteAttributeString("Minor", iBMSC.My.MyProject.Application.Info.Version.Minor.ToString());
            w.WriteAttributeString("Build", iBMSC.My.MyProject.Application.Info.Version.Build.ToString());

            if (ThemeOnly)
                goto state5000;

            w.WriteStartElement("Form");
            w.WriteAttributeString("WindowState", Conversions.ToString(Interaction.IIf(this.isFullScreen, this.previousWindowState, this.WindowState)));
            w.WriteAttributeString("Width", Conversions.ToString(Interaction.IIf(this.isFullScreen, (object)this.previousWindowPosition.Width, (object)this.Width)));
            w.WriteAttributeString("Height", Conversions.ToString(Interaction.IIf(this.isFullScreen, (object)this.previousWindowPosition.Height, (object)this.Height)));
            w.WriteAttributeString("Top", Conversions.ToString(Interaction.IIf(this.isFullScreen, (object)this.previousWindowPosition.Top, (object)this.Top)));
            w.WriteAttributeString("Left", Conversions.ToString(Interaction.IIf(this.isFullScreen, (object)this.previousWindowPosition.Left, (object)this.Left)));
            w.WriteEndElement();

            w.WriteStartElement("Recent");
            w.WriteAttributeString("Recent0", this.Recent[0]);
            w.WriteAttributeString("Recent1", this.Recent[1]);
            w.WriteAttributeString("Recent2", this.Recent[2]);
            w.WriteAttributeString("Recent3", this.Recent[3]);
            w.WriteAttributeString("Recent4", this.Recent[4]);
            w.WriteEndElement();

            w.WriteStartElement("Edit");
            w.WriteAttributeString("NTInput", Conversions.ToString(this.NTInput));
            w.WriteAttributeString("Language", this.DispLang);
            // .WriteAttributeString("SortingMethod", SortingMethod)
            w.WriteAttributeString("ErrorCheck", Conversions.ToString(this.ErrorCheck));
            w.WriteAttributeString("AutoFocusMouseEnter", Conversions.ToString(this.AutoFocusMouseEnter));
            w.WriteAttributeString("FirstClickDisabled", Conversions.ToString(this.FirstClickDisabled));
            w.WriteAttributeString("ShowFileName", Conversions.ToString(this.ShowFileName));
            w.WriteAttributeString("MiddleButtonMoveMethod", this.MiddleButtonMoveMethod.ToString());
            w.WriteAttributeString("AutoSaveInterval", this.AutoSaveInterval.ToString());
            w.WriteAttributeString("PreviewOnClick", Conversions.ToString(this.PreviewOnClick));
            // .WriteAttributeString("PreviewErrorCheck", PreviewErrorCheck)
            w.WriteAttributeString("ClickStopPreview", Conversions.ToString(this.ClickStopPreview));
            w.WriteEndElement();

            w.WriteStartElement("Save");
            w.WriteAttributeString("TextEncoding", iBMSC.Editor.Functions.EncodingToString(this.TextEncoding));
            w.WriteAttributeString("BMSGridLimit", this.BMSGridLimit.ToString());
            w.WriteAttributeString("BeepWhileSaved", Conversions.ToString(this.BeepWhileSaved));
            w.WriteAttributeString("BPMx1296", Conversions.ToString(this.BPMx1296));
            w.WriteAttributeString("STOPx1296", Conversions.ToString(this.STOPx1296));
            w.WriteEndElement();

            w.WriteStartElement("WAV");
            w.WriteAttributeString("WAVMultiSelect", Conversions.ToString(this.WAVMultiSelect));
            w.WriteAttributeString("WAVChangeLabel", Conversions.ToString(this.WAVChangeLabel));
            w.WriteAttributeString("BeatChangeMode", this.BeatChangeMode.ToString());
            w.WriteEndElement();

            w.WriteStartElement("ShowHide");
            w.WriteAttributeString("showMenu", Conversions.ToString(this.mnSMenu.Checked));
            w.WriteAttributeString("showTB", Conversions.ToString(this.mnSTB.Checked));
            w.WriteAttributeString("showOpPanel", Conversions.ToString(this.mnSOP.Checked));
            w.WriteAttributeString("showStatus", Conversions.ToString(this.mnSStatus.Checked));
            w.WriteAttributeString("showLSplit", Conversions.ToString(this.mnSLSplitter.Checked));
            w.WriteAttributeString("showRSplit", Conversions.ToString(this.mnSRSplitter.Checked));
            w.WriteEndElement();

            w.WriteStartElement("Grid");
            w.WriteAttributeString("gSnap", Conversions.ToString(this.gSnap));
            w.WriteAttributeString("gWheel", this.gWheel.ToString());
            w.WriteAttributeString("gPgUpDn", this.gPgUpDn.ToString());
            w.WriteAttributeString("gShow", Conversions.ToString(this.gShowGrid));
            w.WriteAttributeString("gShowS", Conversions.ToString(this.gShowSubGrid));
            w.WriteAttributeString("gShowBG", Conversions.ToString(this.gShowBG));
            w.WriteAttributeString("gShowM", Conversions.ToString(this.gShowMeasureNumber));
            w.WriteAttributeString("gShowV", Conversions.ToString(this.gShowVerticalLine));
            w.WriteAttributeString("gShowMB", Conversions.ToString(this.gShowMeasureBar));
            w.WriteAttributeString("gShowC", Conversions.ToString(this.gShowC));
            w.WriteAttributeString("gBPM", Conversions.ToString(this.gBPM));
            w.WriteAttributeString("gSTOP", Conversions.ToString(this.gSTOP));
            w.WriteAttributeString("gSCROLL", Conversions.ToString(this.gSCROLL));
            w.WriteAttributeString("gBLP", Conversions.ToString(this.gDisplayBGAColumn));
            w.WriteAttributeString("gP2", this.CHPlayer.SelectedIndex.ToString());
            w.WriteAttributeString("gCol", this.CGB.Value.ToString());
            w.WriteAttributeString("gDivide", this.gDivide.ToString());
            w.WriteAttributeString("gSub", this.gSub.ToString());
            w.WriteAttributeString("gSlash", this.gSlash.ToString());
            w.WriteAttributeString("gxHeight", this.gxHeight.ToString());
            w.WriteAttributeString("gxWidth", this.gxWidth.ToString());
            w.WriteEndElement();

            w.WriteStartElement("WaveForm");
            w.WriteAttributeString("wLock", Conversions.ToString(this.wLock));
            w.WriteAttributeString("wPosition", this.wPosition.ToString());
            w.WriteAttributeString("wLeft", this.wLeft.ToString());
            w.WriteAttributeString("wWidth", this.wWidth.ToString());
            w.WriteAttributeString("wPrecision", this.wPrecision.ToString());
            w.WriteEndElement();

            w.WriteStartElement("Player");
            w.WriteAttributeString("Count", this.pArgs.Length.ToString());
            w.WriteAttributeString("CurrentPlayer", this.CurrentPlayer.ToString());
            for (int i = 0, loopTo = Information.UBound(this.pArgs); i <= loopTo; i++)
                XMLWritePlayerArguments(w, i);
            w.WriteEndElement();

        state5000:
            ;
            w.WriteStartElement("Columns");
            // .WriteAttributeString("Count", col.Length)
            for (int i = 0, loopTo1 = Information.UBound(this.column); i <= loopTo1; i++)
                XMLWriteColumn(w, i);
            w.WriteEndElement();

            w.WriteStartElement("VisualSettings");
            iBMSC.XMLUtil.XMLWriteValue(w, "ColumnTitle", this.vo.ColumnTitle.Color.ToArgb().ToString());
            this.XMLWriteFont(w, "ColumnTitleFont", this.vo.ColumnTitleFont);
            iBMSC.XMLUtil.XMLWriteValue(w, "Bg", this.vo.Bg.Color.ToArgb().ToString());
            iBMSC.XMLUtil.XMLWriteValue(w, "Grid", this.vo.pGrid.Color.ToArgb().ToString());
            iBMSC.XMLUtil.XMLWriteValue(w, "Sub", this.vo.pSub.Color.ToArgb().ToString());
            iBMSC.XMLUtil.XMLWriteValue(w, "VLine", this.vo.pVLine.Color.ToArgb().ToString());
            iBMSC.XMLUtil.XMLWriteValue(w, "MLine", this.vo.pMLine.Color.ToArgb().ToString());
            iBMSC.XMLUtil.XMLWriteValue(w, "BGMWav", this.vo.pBGMWav.Color.ToArgb().ToString());
            iBMSC.XMLUtil.XMLWriteValue(w, "SelBox", this.vo.SelBox.Color.ToArgb().ToString());
            iBMSC.XMLUtil.XMLWriteValue(w, "TSCursor", this.vo.PECursor.Color.ToArgb().ToString());
            iBMSC.XMLUtil.XMLWriteValue(w, "TSHalf", this.vo.PEHalf.Color.ToArgb().ToString());
            iBMSC.XMLUtil.XMLWriteValue(w, "TSDeltaMouseOver", this.vo.PEDeltaMouseOver.ToString());
            iBMSC.XMLUtil.XMLWriteValue(w, "TSMouseOver", this.vo.PEMouseOver.Color.ToArgb().ToString());
            iBMSC.XMLUtil.XMLWriteValue(w, "TSSel", this.vo.PESel.Color.ToArgb().ToString());
            iBMSC.XMLUtil.XMLWriteValue(w, "TSBPM", this.vo.PEBPM.Color.ToArgb().ToString());
            this.XMLWriteFont(w, "TSBPMFont", this.vo.PEBPMFont);
            iBMSC.XMLUtil.XMLWriteValue(w, "MiddleDeltaRelease", this.vo.MiddleDeltaRelease.ToString());
            iBMSC.XMLUtil.XMLWriteValue(w, "kHeight", this.vo.kHeight.ToString());
            this.XMLWriteFont(w, "kFont", this.vo.kFont);
            this.XMLWriteFont(w, "kMFont", this.vo.kMFont);
            iBMSC.XMLUtil.XMLWriteValue(w, "kLabelVShift", this.vo.kLabelVShift.ToString());
            iBMSC.XMLUtil.XMLWriteValue(w, "kLabelHShift", this.vo.kLabelHShift.ToString());
            iBMSC.XMLUtil.XMLWriteValue(w, "kLabelHShiftL", this.vo.kLabelHShiftL.ToString());
            iBMSC.XMLUtil.XMLWriteValue(w, "kMouseOver", this.vo.kMouseOver.Color.ToArgb().ToString());
            iBMSC.XMLUtil.XMLWriteValue(w, "kMouseOverE", this.vo.kMouseOverE.Color.ToArgb().ToString());
            iBMSC.XMLUtil.XMLWriteValue(w, "kSelected", this.vo.kSelected.Color.ToArgb().ToString());
            iBMSC.XMLUtil.XMLWriteValue(w, "kOpacity", this.vo.kOpacity.ToString());
            w.WriteEndElement();

            w.WriteEndElement();
            w.WriteEndDocument();
            w.Close();
        }

        private void XMLLoadElementValue(XmlElement n, ref int v)
        {
            if (n is null)
                return;
            iBMSC.XMLUtil.XMLLoadAttribute(n.GetAttribute("Value"), ref v);
        }
        private void XMLLoadElementValue(XmlElement n, ref float v)
        {
            if (n is null)
                return;
            iBMSC.XMLUtil.XMLLoadAttribute(n.GetAttribute("Value"), ref v);
        }
        private void XMLLoadElementValue(XmlElement n, ref Color v)
        {
            if (n is null)
                return;
            iBMSC.XMLUtil.XMLLoadAttribute(n.GetAttribute("Value"), ref v);
        }

        private void XMLLoadElementValue(XmlElement n, ref Font v)
        {
            if (n is null)
                return;

            string xName = this.Font.FontFamily.Name;
            int xSize = (int)Math.Round(this.Font.Size);
            int xStyle = (int)this.Font.Style;
            iBMSC.XMLUtil.XMLLoadAttribute(n.GetAttribute("Name"), ref xName);
            iBMSC.XMLUtil.XMLLoadAttribute(n.GetAttribute("Size"), ref xSize);
            iBMSC.XMLUtil.XMLLoadAttribute(n.GetAttribute("Style"), ref xStyle);
            v = new Font(xName, xSize, (FontStyle)xStyle);
        }

        private void XMLLoadPlayer(XmlElement n)
        {
            int i = -1;
            iBMSC.XMLUtil.XMLLoadAttribute(n.GetAttribute("Index"), ref i);
            if (i < 0 | i > Information.UBound(this.pArgs))
                return;

            iBMSC.XMLUtil.XMLLoadAttribute(n.GetAttribute("Path"), ref this.pArgs[i].Path);
            iBMSC.XMLUtil.XMLLoadAttribute(n.GetAttribute("FromBeginning"), ref this.pArgs[i].aBegin);
            iBMSC.XMLUtil.XMLLoadAttribute(n.GetAttribute("FromHere"), ref this.pArgs[i].aHere);
            iBMSC.XMLUtil.XMLLoadAttribute(n.GetAttribute("Stop"), ref this.pArgs[i].aStop);
        }

        private void XMLLoadColumn(XmlElement n)
        {
            int i = -1;
            iBMSC.XMLUtil.XMLLoadAttribute(n.GetAttribute("Index"), ref i);
            if (i < 0 | i > Information.UBound(this.column))
                return;

            {
                ref var withBlock = ref this.column[i];
                // XMLLoadAttribute(n.GetAttribute("Left"), .Left)
                int argv = withBlock.Width;
                iBMSC.XMLUtil.XMLLoadAttribute(n.GetAttribute("Width"), ref argv);
                withBlock.Width = argv;
                iBMSC.XMLUtil.XMLLoadAttribute(n.GetAttribute("Title"), ref withBlock.Title);
                // XMLLoadAttribute(n.GetAttribute("Text"), .Text)
                var Display = default(bool);
                string attr = n.GetAttribute("Display");
                iBMSC.XMLUtil.XMLLoadAttribute(attr, ref Display);
                withBlock.isVisible = Conversions.ToBoolean(Interaction.IIf(string.IsNullOrEmpty(attr), (object)withBlock.isVisible, Display));

                // XMLLoadAttribute(n.GetAttribute("isNumeric"), .isNumeric)
                // XMLLoadAttribute(n.GetAttribute("Visible"), .Visible)
                // XMLLoadAttribute(n.GetAttribute("Identifier"), .Identifier)
                iBMSC.XMLUtil.XMLLoadAttribute(n.GetAttribute("NoteColor"), ref withBlock.cNote);
                withBlock.setNoteColor(withBlock.cNote);
                iBMSC.XMLUtil.XMLLoadAttribute(n.GetAttribute("TextColor"), ref withBlock.cText);
                iBMSC.XMLUtil.XMLLoadAttribute(n.GetAttribute("LongNoteColor"), ref withBlock.cLNote);
                withBlock.setLNoteColor(withBlock.cLNote);
                iBMSC.XMLUtil.XMLLoadAttribute(n.GetAttribute("LongTextColor"), ref withBlock.cLText);
                iBMSC.XMLUtil.XMLLoadAttribute(n.GetAttribute("BG"), ref withBlock.cBG);
            }
        }

        private void LoadSettings(string Path)
        {
            if (!File.Exists(Path))
                return;

            // Dim xTempFileName As String = ""
            // Do
            // Try
            // xTempFileName = Me.RandomFileName(".xml")
            // File.Copy(Path, xTempFileName)
            // Catch
            // Continue Do
            // End Try
            // Exit Do
            // Loop
            var Doc = new XmlDocument();
            var FileStream = new FileStream(Path, FileMode.Open, FileAccess.Read);
            Doc.Load(FileStream);

            var Root = Doc["iBMSC"];
            if (Root is null)
                goto EndOfSub;

            // version
            var assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName();
            int Major = assemblyName.Version.Major;
            int Minor = assemblyName.Version.Minor;
            int Build = assemblyName.Version.Build;
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
            }

            // form
            var eForm = Root["Form"];
            if (eForm is not null)
            {
                switch (Conversion.Val(eForm.GetAttribute("WindowState")))
                {
                    case (double)FormWindowState.Normal:
                        {
                            this.WindowState = FormWindowState.Normal;
                            int argv = this.Width;
                            iBMSC.XMLUtil.XMLLoadAttribute(eForm.GetAttribute("Width"), ref argv);
                            this.Width = argv;
                            int argv1 = this.Height;
                            iBMSC.XMLUtil.XMLLoadAttribute(eForm.GetAttribute("Height"), ref argv1);
                            this.Height = argv1;
                            int argv2 = this.Top;
                            iBMSC.XMLUtil.XMLLoadAttribute(eForm.GetAttribute("Top"), ref argv2);
                            this.Top = argv2;
                            int argv3 = this.Left;
                            iBMSC.XMLUtil.XMLLoadAttribute(eForm.GetAttribute("Left"), ref argv3);
                            this.Left = argv3;
                            break;
                        }
                    case (double)FormWindowState.Maximized:
                        {
                            this.WindowState = FormWindowState.Maximized;
                            break;
                        }
                }
            }

            // recent
            var eRecent = Root["Recent"];
            if (eRecent is not null)
            {
                iBMSC.XMLUtil.XMLLoadAttribute(eRecent.GetAttribute("Recent0"), ref this.Recent[0]);
                this.SetRecent(0, this.Recent[0]);
                iBMSC.XMLUtil.XMLLoadAttribute(eRecent.GetAttribute("Recent1"), ref this.Recent[1]);
                this.SetRecent(1, this.Recent[1]);
                iBMSC.XMLUtil.XMLLoadAttribute(eRecent.GetAttribute("Recent2"), ref this.Recent[2]);
                this.SetRecent(2, this.Recent[2]);
                iBMSC.XMLUtil.XMLLoadAttribute(eRecent.GetAttribute("Recent3"), ref this.Recent[3]);
                this.SetRecent(3, this.Recent[3]);
                iBMSC.XMLUtil.XMLLoadAttribute(eRecent.GetAttribute("Recent4"), ref this.Recent[4]);
                this.SetRecent(4, this.Recent[4]);
            }

            // edit
            var eEdit = Root["Edit"];
            if (eEdit is not null)
            {
                iBMSC.XMLUtil.XMLLoadAttribute(eEdit.GetAttribute("NTInput"), ref this.NTInput);
                this.TBNTInput.Checked = this.NTInput;
                this.mnNTInput.Checked = this.NTInput;
                this.POBLong.Enabled = !this.NTInput;
                this.POBLongShort.Enabled = !this.NTInput;

                this.LoadLocale(Application.ExecutablePath + @"\" + eEdit.GetAttribute("Language"));

                // XMLLoadAttribute(.GetAttribute("SortingMethod"), SortingMethod)

                iBMSC.XMLUtil.XMLLoadAttribute(eEdit.GetAttribute("ErrorCheck"), ref this.ErrorCheck);
                this.TBErrorCheck.Checked = this.ErrorCheck;
                this.TBErrorCheck_Click(this.TBErrorCheck, new EventArgs());

                iBMSC.XMLUtil.XMLLoadAttribute(eEdit.GetAttribute("ShowFileName"), ref this.ShowFileName);
                this.TBShowFileName.Checked = this.ShowFileName;
                this.TBShowFileName_Click(this.TBShowFileName, new EventArgs());

                iBMSC.XMLUtil.XMLLoadAttribute(eEdit.GetAttribute("MiddleButtonMoveMethod"), ref this.MiddleButtonMoveMethod);
                iBMSC.XMLUtil.XMLLoadAttribute(eEdit.GetAttribute("AutoFocusMouseEnter"), ref this.AutoFocusMouseEnter);
                iBMSC.XMLUtil.XMLLoadAttribute(eEdit.GetAttribute("FirstClickDisabled"), ref this.FirstClickDisabled);

                iBMSC.XMLUtil.XMLLoadAttribute(eEdit.GetAttribute("AutoSaveInterval"), ref this.AutoSaveInterval);
                if (Conversions.ToBoolean(this.AutoSaveInterval))
                    this.AutoSaveTimer.Interval = this.AutoSaveInterval;
                else
                    this.AutoSaveTimer.Enabled = false;

                iBMSC.XMLUtil.XMLLoadAttribute(eEdit.GetAttribute("PreviewOnClick"), ref this.PreviewOnClick);
                this.TBPreviewOnClick.Checked = this.PreviewOnClick;
                this.TBPreviewOnClick_Click(this.TBPreviewOnClick, new EventArgs());

                iBMSC.XMLUtil.XMLLoadAttribute(eEdit.GetAttribute("ClickStopPreview"), ref this.ClickStopPreview);
            }

            // save
            var eSave = Root["Save"];
            if (eSave is not null)
            {
                switch (eSave.GetAttribute("TextEncoding").ToUpper() ?? "")
                {
                    case "SYSTEM ANSI":
                        {
                            this.TextEncoding = System.Text.Encoding.Default;
                            break;
                        }
                    case "LITTLE ENDIAN UTF16":
                        {
                            this.TextEncoding = System.Text.Encoding.Unicode;
                            break;
                        }
                    case "ASCII":
                        {
                            this.TextEncoding = System.Text.Encoding.ASCII;
                            break;
                        }
                    case "BIG ENDIAN UTF16":
                        {
                            this.TextEncoding = System.Text.Encoding.BigEndianUnicode;
                            break;
                        }
                    case "LITTLE ENDIAN UTF32":
                        {
                            this.TextEncoding = System.Text.Encoding.UTF32;
                            break;
                        }
                    case "UTF7":
                        {
                            this.TextEncoding = System.Text.Encoding.UTF7;
                            break;
                        }
                    case "UTF8":
                        {
                            this.TextEncoding = System.Text.Encoding.UTF8;
                            break;
                        }
                    case "SJIS":
                        {
                            this.TextEncoding = System.Text.Encoding.GetEncoding(932);
                            break;
                        }
                    case "EUC-KR":
                        {
                            this.TextEncoding = System.Text.Encoding.GetEncoding(51949);
                            break;
                        }
                        // leave current encoding
                        // Case Else 
                }

                iBMSC.XMLUtil.XMLLoadAttribute(eSave.GetAttribute("BMSGridLimit"), ref this.BMSGridLimit);
                iBMSC.XMLUtil.XMLLoadAttribute(eSave.GetAttribute("BeepWhileSaved"), ref this.BeepWhileSaved);
                iBMSC.XMLUtil.XMLLoadAttribute(eSave.GetAttribute("BPMx1296"), ref this.BPMx1296);
                iBMSC.XMLUtil.XMLLoadAttribute(eSave.GetAttribute("STOPx1296"), ref this.STOPx1296);
            }

            // WAV
            var eWAV = Root["WAV"];
            if (eWAV is not null)
            {
                iBMSC.XMLUtil.XMLLoadAttribute(eWAV.GetAttribute("WAVMultiSelect"), ref this.WAVMultiSelect);
                this.CWAVMultiSelect.Checked = this.WAVMultiSelect;
                this.CWAVMultiSelect_CheckedChanged(this.CWAVMultiSelect, new EventArgs());

                iBMSC.XMLUtil.XMLLoadAttribute(eWAV.GetAttribute("WAVChangeLabel"), ref this.WAVChangeLabel);
                this.CWAVChangeLabel.Checked = this.WAVChangeLabel;
                this.CWAVChangeLabel_CheckedChanged(this.CWAVChangeLabel, new EventArgs());

                int xInt = Conversions.ToInteger(eWAV.GetAttribute("BeatChangeMode"));
                var xBeatOpList = new[] { this.CBeatPreserve, this.CBeatMeasure, this.CBeatCut, this.CBeatScale };
                if (xInt >= 0 & xInt < xBeatOpList.Length)
                {
                    xBeatOpList[xInt].Checked = true;
                    this.CBeatPreserve_Click(xBeatOpList[xInt], new EventArgs());
                }
            }

            // ShowHide
            var eShowHide = Root["ShowHide"];
            if (eShowHide is not null)
            {
                bool argv4 = this.mnSMenu.Checked;
                iBMSC.XMLUtil.XMLLoadAttribute(eShowHide.GetAttribute("showMenu"), ref argv4);
                this.mnSMenu.Checked = argv4;
                bool argv5 = this.mnSTB.Checked;
                iBMSC.XMLUtil.XMLLoadAttribute(eShowHide.GetAttribute("showTB"), ref argv5);
                this.mnSTB.Checked = argv5;
                bool argv6 = this.mnSOP.Checked;
                iBMSC.XMLUtil.XMLLoadAttribute(eShowHide.GetAttribute("showOpPanel"), ref argv6);
                this.mnSOP.Checked = argv6;
                bool argv7 = this.mnSStatus.Checked;
                iBMSC.XMLUtil.XMLLoadAttribute(eShowHide.GetAttribute("showStatus"), ref argv7);
                this.mnSStatus.Checked = argv7;
                bool argv8 = this.mnSLSplitter.Checked;
                iBMSC.XMLUtil.XMLLoadAttribute(eShowHide.GetAttribute("showLSplit"), ref argv8);
                this.mnSLSplitter.Checked = argv8;
                bool argv9 = this.mnSRSplitter.Checked;
                iBMSC.XMLUtil.XMLLoadAttribute(eShowHide.GetAttribute("showRSplit"), ref argv9);
                this.mnSRSplitter.Checked = argv9;
            }

            // Grid
            var eGrid = Root["Grid"];
            if (eGrid is not null)
            {
                bool argv10 = this.CGSnap.Checked;
                iBMSC.XMLUtil.XMLLoadAttribute(eGrid.GetAttribute("gSnap"), ref argv10);
                this.CGSnap.Checked = argv10;
                iBMSC.XMLUtil.XMLLoadAttribute(eGrid.GetAttribute("gWheel"), ref this.gWheel);
                iBMSC.XMLUtil.XMLLoadAttribute(eGrid.GetAttribute("gPgUpDn"), ref this.gPgUpDn);
                bool argv11 = this.CGShow.Checked;
                iBMSC.XMLUtil.XMLLoadAttribute(eGrid.GetAttribute("gShow"), ref argv11);
                this.CGShow.Checked = argv11;
                bool argv12 = this.CGShowS.Checked;
                iBMSC.XMLUtil.XMLLoadAttribute(eGrid.GetAttribute("gShowS"), ref argv12);
                this.CGShowS.Checked = argv12;
                bool argv13 = this.CGShowBG.Checked;
                iBMSC.XMLUtil.XMLLoadAttribute(eGrid.GetAttribute("gShowBG"), ref argv13);
                this.CGShowBG.Checked = argv13;
                bool argv14 = this.CGShowM.Checked;
                iBMSC.XMLUtil.XMLLoadAttribute(eGrid.GetAttribute("gShowM"), ref argv14);
                this.CGShowM.Checked = argv14;
                bool argv15 = this.CGShowV.Checked;
                iBMSC.XMLUtil.XMLLoadAttribute(eGrid.GetAttribute("gShowV"), ref argv15);
                this.CGShowV.Checked = argv15;
                bool argv16 = this.CGShowMB.Checked;
                iBMSC.XMLUtil.XMLLoadAttribute(eGrid.GetAttribute("gShowMB"), ref argv16);
                this.CGShowMB.Checked = argv16;
                bool argv17 = this.CGShowC.Checked;
                iBMSC.XMLUtil.XMLLoadAttribute(eGrid.GetAttribute("gShowC"), ref argv17);
                this.CGShowC.Checked = argv17;
                bool argv18 = this.CGBPM.Checked;
                iBMSC.XMLUtil.XMLLoadAttribute(eGrid.GetAttribute("gBPM"), ref argv18);
                this.CGBPM.Checked = argv18;
                bool argv19 = this.CGSTOP.Checked;
                iBMSC.XMLUtil.XMLLoadAttribute(eGrid.GetAttribute("gSTOP"), ref argv19);
                this.CGSTOP.Checked = argv19;
                bool argv20 = this.CGSCROLL.Checked;
                iBMSC.XMLUtil.XMLLoadAttribute(eGrid.GetAttribute("gSCROLL"), ref argv20);
                this.CGSCROLL.Checked = argv20;
                bool argv21 = this.CGBLP.Checked;
                iBMSC.XMLUtil.XMLLoadAttribute(eGrid.GetAttribute("gBLP"), ref argv21);
                this.CGBLP.Checked = argv21;
                int argv22 = this.CHPlayer.SelectedIndex;
                iBMSC.XMLUtil.XMLLoadAttribute(eGrid.GetAttribute("gP2"), ref argv22);
                this.CHPlayer.SelectedIndex = argv22;
                decimal argv23 = this.CGB.Value;
                iBMSC.XMLUtil.XMLLoadAttribute(eGrid.GetAttribute("gCol"), ref argv23);
                this.CGB.Value = argv23;
                decimal argv24 = this.CGHeight.Value;
                iBMSC.XMLUtil.XMLLoadAttribute(eGrid.GetAttribute("gxHeight"), ref argv24);
                this.CGHeight.Value = argv24;
                decimal argv25 = this.CGWidth.Value;
                iBMSC.XMLUtil.XMLLoadAttribute(eGrid.GetAttribute("gxWidth"), ref argv25);
                this.CGWidth.Value = argv25;
                iBMSC.XMLUtil.XMLLoadAttribute(eGrid.GetAttribute("gSlash"), ref this.gSlash);

                int xgDivide = Conversions.ToInteger(eGrid.GetAttribute("gDivide"));
                if ((decimal)xgDivide >= this.CGDivide.Minimum & (decimal)xgDivide <= this.CGDivide.Maximum)
                    this.CGDivide.Value = (decimal)xgDivide;

                int xgSub = Conversions.ToInteger(eGrid.GetAttribute("gSub"));
                if ((decimal)xgSub >= this.CGSub.Minimum & (decimal)xgSub <= this.CGSub.Maximum)
                    this.CGSub.Value = (decimal)xgSub;
            }

            // WaveForm
            var eWaveForm = Root["WaveForm"];
            if (eWaveForm is not null)
            {
                bool argv26 = this.BWLock.Checked;
                iBMSC.XMLUtil.XMLLoadAttribute(eWaveForm.GetAttribute("wLock"), ref argv26);
                this.BWLock.Checked = argv26;
                decimal argv27 = this.TWPosition.Value;
                iBMSC.XMLUtil.XMLLoadAttribute(eWaveForm.GetAttribute("wPosition"), ref argv27);
                this.TWPosition.Value = argv27;
                decimal argv28 = this.TWLeft.Value;
                iBMSC.XMLUtil.XMLLoadAttribute(eWaveForm.GetAttribute("wLeft"), ref argv28);
                this.TWLeft.Value = argv28;
                decimal argv29 = this.TWWidth.Value;
                iBMSC.XMLUtil.XMLLoadAttribute(eWaveForm.GetAttribute("wWidth"), ref argv29);
                this.TWWidth.Value = argv29;
                decimal argv30 = this.TWPrecision.Value;
                iBMSC.XMLUtil.XMLLoadAttribute(eWaveForm.GetAttribute("wPrecision"), ref argv30);
                this.TWPrecision.Value = argv30;
            }

            // Player
            var ePlayer = Root["Player"];
            if (ePlayer is not null)
            {
                iBMSC.XMLUtil.XMLLoadAttribute(ePlayer.GetAttribute("CurrentPlayer"), ref this.CurrentPlayer);

                int xCount = Conversions.ToInteger(ePlayer.GetAttribute("Count"));
                if (xCount > 0)
                    Array.Resize(ref this.pArgs, xCount);

                foreach (XmlElement eePlayer in ePlayer.ChildNodes)
                    XMLLoadPlayer(eePlayer);
            }

            // Columns
            var eColumns = Root["Columns"];
            if (eColumns is not null)
            {
                foreach (XmlElement eeCol in eColumns.ChildNodes)
                    XMLLoadColumn(eeCol);
            }

            // VisualSettings
            var eVisualSettings = Root["VisualSettings"];
            if (eVisualSettings is not null)
            {
                var argv31 = this.vo.ColumnTitle.Color;
                this.XMLLoadElementValue(eVisualSettings["ColumnTitle"], ref argv31);
                this.vo.ColumnTitle.Color = argv31;
                this.XMLLoadElementValue(eVisualSettings["ColumnTitleFont"], ref this.vo.ColumnTitleFont);
                var argv32 = this.vo.Bg.Color;
                this.XMLLoadElementValue(eVisualSettings["Bg"], ref argv32);
                this.vo.Bg.Color = argv32;
                var argv33 = this.vo.pGrid.Color;
                this.XMLLoadElementValue(eVisualSettings["Grid"], ref argv33);
                this.vo.pGrid.Color = argv33;
                var argv34 = this.vo.pSub.Color;
                this.XMLLoadElementValue(eVisualSettings["Sub"], ref argv34);
                this.vo.pSub.Color = argv34;
                var argv35 = this.vo.pVLine.Color;
                this.XMLLoadElementValue(eVisualSettings["VLine"], ref argv35);
                this.vo.pVLine.Color = argv35;
                var argv36 = this.vo.pMLine.Color;
                this.XMLLoadElementValue(eVisualSettings["MLine"], ref argv36);
                this.vo.pMLine.Color = argv36;

                var argv37 = this.vo.pBGMWav.Color;
                this.XMLLoadElementValue(eVisualSettings["BGMWav"], ref argv37);
                this.vo.pBGMWav.Color = argv37;
                this.TWTransparency.Value = (decimal)this.vo.pBGMWav.Color.A;
                this.TWTransparency2.Value = (int)this.vo.pBGMWav.Color.A;
                this.TWSaturation.Value = (decimal)(this.vo.pBGMWav.Color.GetSaturation() * 1000f);
                this.TWSaturation2.Value = (int)Math.Round(this.vo.pBGMWav.Color.GetSaturation() * 1000f);

                var argv38 = this.vo.SelBox.Color;
                this.XMLLoadElementValue(eVisualSettings["SelBox"], ref argv38);
                this.vo.SelBox.Color = argv38;
                var argv39 = this.vo.PECursor.Color;
                this.XMLLoadElementValue(eVisualSettings["TSCursor"], ref argv39);
                this.vo.PECursor.Color = argv39;
                var argv40 = this.vo.PEHalf.Color;
                this.XMLLoadElementValue(eVisualSettings["TSHalf"], ref argv40);
                this.vo.PEHalf.Color = argv40;
                this.XMLLoadElementValue(eVisualSettings["TSDeltaMouseOver"], ref this.vo.PEDeltaMouseOver);
                var argv41 = this.vo.PEMouseOver.Color;
                this.XMLLoadElementValue(eVisualSettings["TSMouseOver"], ref argv41);
                this.vo.PEMouseOver.Color = argv41;
                var argv42 = this.vo.PESel.Color;
                this.XMLLoadElementValue(eVisualSettings["TSSel"], ref argv42);
                this.vo.PESel.Color = argv42;
                var argv43 = this.vo.PEBPM.Color;
                this.XMLLoadElementValue(eVisualSettings["TSBPM"], ref argv43);
                this.vo.PEBPM.Color = argv43;
                this.XMLLoadElementValue(eVisualSettings["TSBPMFont"], ref this.vo.PEBPMFont);
                this.XMLLoadElementValue(eVisualSettings["MiddleDeltaRelease"], ref this.vo.MiddleDeltaRelease);
                this.XMLLoadElementValue(eVisualSettings["kHeight"], ref this.vo.kHeight);
                this.XMLLoadElementValue(eVisualSettings["kFont"], ref this.vo.kFont);
                this.XMLLoadElementValue(eVisualSettings["kMFont"], ref this.vo.kMFont);
                this.XMLLoadElementValue(eVisualSettings["kLabelVShift"], ref this.vo.kLabelVShift);
                this.XMLLoadElementValue(eVisualSettings["kLabelHShift"], ref this.vo.kLabelHShift);
                this.XMLLoadElementValue(eVisualSettings["kLabelHShiftL"], ref this.vo.kLabelHShiftL);
                var argv44 = this.vo.kMouseOver.Color;
                this.XMLLoadElementValue(eVisualSettings["kMouseOver"], ref argv44);
                this.vo.kMouseOver.Color = argv44;
                var argv45 = this.vo.kMouseOverE.Color;
                this.XMLLoadElementValue(eVisualSettings["kMouseOverE"], ref argv45);
                this.vo.kMouseOverE.Color = argv45;
                var argv46 = this.vo.kSelected.Color;
                this.XMLLoadElementValue(eVisualSettings["kSelected"], ref argv46);
                this.vo.kSelected.Color = argv46;
                this.XMLLoadElementValue(eVisualSettings["kOpacity"], ref this.vo.kOpacity);
            }

        EndOfSub:
            ;

            this.UpdateColumnsX();
            FileStream.Close();
            // File.Delete(xTempFileName)
        }

        private void XMLLoadLocaleMenu(XmlElement n, ref string target)
        {
            if (n is null)
                return;
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
            if (n is not null)
                target = n.InnerText;
        }

        private void XMLLoadLocaleToolTipUniversal(XmlElement n, Control target)
        {
            if (n is null)
                return;
            this.ToolTipUniversal.SetToolTip(target, n.InnerText);
        }

        private void LoadLocale(string Path)
        {
            if (!File.Exists(Path))
                return;

            XmlDocument Doc = null;
            FileStream FileStream = null;

            bool xPOHeaderPart2 = this.POHeaderPart2.Visible;
            bool xPOGridPart2 = this.POGridPart2.Visible;
            bool xPOWaveFormPart2 = this.POWaveFormPart2.Visible;
            this.POHeaderPart2.Visible = true;
            this.POGridPart2.Visible = true;
            this.POWaveFormPart2.Visible = true;

            try
            {
                Doc = new XmlDocument();
                FileStream = new FileStream(Path, FileMode.Open, FileAccess.Read);
                Doc.Load(FileStream);

                var Root = Doc["iBMSC.Locale"];
                if (Root is null)
                    throw new NullReferenceException();

                this.XMLLoadLocale(Root["OK"], ref iBMSCStrings.OK);
                this.XMLLoadLocale(Root["Cancel"], ref iBMSCStrings.Cancel);
                this.XMLLoadLocale(Root["None"], ref iBMSCStrings.None);

                var eFont = Root["Font"];
                if (eFont is not null)
                {
                    int xSize = 9;
                    if (eFont.HasAttribute("Size"))
                        xSize = (int)Math.Round(Conversion.Val(eFont.GetAttribute("Size")));

                    var fRegular = new Font(this.Font.FontFamily, (float)xSize, FontStyle.Regular);
                    var xChildNode = eFont.LastChild;
                    while (xChildNode is not null)
                    {
                        if (xChildNode.LocalName != "Family")
                            continue;
                        if (iBMSC.Editor.Functions.isFontInstalled(xChildNode.InnerText))
                        {
                            fRegular = new Font(xChildNode.InnerText, xSize);
                        }
                        xChildNode = xChildNode.PreviousSibling;
                    }

                    var rList = new object[] {
                        this, this.mnSys, this.Menu1,
                        this.mnMain, this.cmnLanguage,
                        this.cmnTheme, this.cmnConversion, this.TBMain,
                        this.FStatus, this.FStatus2,
                        };
                    foreach (object c in rList)
                    {
                        try
                        {
                            c.Font = fRegular;
                        }
                        catch (Exception ex)
                        {
                        }
                    }

                    var fBold = new Font(fRegular, FontStyle.Bold);

                    var bList = new object[] { this.TBStatistics, this.FSSS, this.FSSL, this.FSSH, this.TVCM, this.TVCD, this.TVCBPM, this.FSP1, this.FSP3, this.FSP2, this.PMain, this.PMainIn, this.PMainR, this.PMainInR, this.PMainL, this.PMainInL };
                    foreach (object c in bList)
                    {
                        try
                        {
                            c.Font = fBold;
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }

                var eMonoFont = Root["MonoFont"];
                if (eMonoFont is not null)
                {
                    int xSize = 9;
                    if (eMonoFont.HasAttribute("Size"))
                        xSize = (int)Math.Round(Conversion.Val(eMonoFont.GetAttribute("Size")));

                    var fMono = new Font(this.POWAVInner.Font.FontFamily, (float)xSize);
                    var xChildNode = eMonoFont.LastChild;
                    while (xChildNode is not null)
                    {
                        if (xChildNode.LocalName != "Family")
                            continue;
                        if (iBMSC.Editor.Functions.isFontInstalled(xChildNode.InnerText))
                        {
                            fMono = new Font(xChildNode.InnerText, xSize);
                        }
                        xChildNode = xChildNode.PreviousSibling;
                    }

                    var mList = new object[] { this.LWAV, this.LBMP, this.LBeat, this.TExpansion };
                    foreach (object c in mList)
                    {
                        try
                        {
                            c.font = fMono;
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }

                var eMenu = Root["Menu"];
                if (eMenu is not null)
                {

                    var eFile = eMenu["File"];
                    if (eFile is not null)
                    {
                        string argtarget = this.mnFile.Text;
                        XMLLoadLocaleMenu(eFile["Title"], ref argtarget);
                        this.mnFile.Text = argtarget;
                        string argtarget1 = this.mnNew.Text;
                        XMLLoadLocaleMenu(eFile["New"], ref argtarget1);
                        this.mnNew.Text = argtarget1;
                        string argtarget2 = this.mnOpen.Text;
                        XMLLoadLocaleMenu(eFile["Open"], ref argtarget2);
                        this.mnOpen.Text = argtarget2;
                        string argtarget3 = this.mnImportSM.Text;
                        XMLLoadLocaleMenu(eFile["ImportSM"], ref argtarget3);
                        this.mnImportSM.Text = argtarget3;
                        string argtarget4 = this.mnImportIBMSC.Text;
                        XMLLoadLocaleMenu(eFile["ImportIBMSC"], ref argtarget4);
                        this.mnImportIBMSC.Text = argtarget4;
                        string argtarget5 = this.mnSave.Text;
                        XMLLoadLocaleMenu(eFile["Save"], ref argtarget5);
                        this.mnSave.Text = argtarget5;
                        string argtarget6 = this.mnSaveAs.Text;
                        XMLLoadLocaleMenu(eFile["SaveAs"], ref argtarget6);
                        this.mnSaveAs.Text = argtarget6;
                        string argtarget7 = this.mnExport.Text;
                        XMLLoadLocaleMenu(eFile["ExportIBMSC"], ref argtarget7);
                        this.mnExport.Text = argtarget7;
                        if (string.IsNullOrEmpty(this.Recent[0]))
                        {
                            string argtarget8 = this.mnOpenR0.Text;
                            XMLLoadLocaleMenu(eFile["Recent0"], ref argtarget8);
                            this.mnOpenR0.Text = argtarget8;
                        }
                        if (string.IsNullOrEmpty(this.Recent[1]))
                        {
                            string argtarget9 = this.mnOpenR1.Text;
                            XMLLoadLocaleMenu(eFile["Recent1"], ref argtarget9);
                            this.mnOpenR1.Text = argtarget9;
                        }
                        if (string.IsNullOrEmpty(this.Recent[2]))
                        {
                            string argtarget10 = this.mnOpenR2.Text;
                            XMLLoadLocaleMenu(eFile["Recent2"], ref argtarget10);
                            this.mnOpenR2.Text = argtarget10;
                        }
                        if (string.IsNullOrEmpty(this.Recent[3]))
                        {
                            string argtarget11 = this.mnOpenR3.Text;
                            XMLLoadLocaleMenu(eFile["Recent3"], ref argtarget11);
                            this.mnOpenR3.Text = argtarget11;
                        }
                        if (string.IsNullOrEmpty(this.Recent[4]))
                        {
                            string argtarget12 = this.mnOpenR4.Text;
                            XMLLoadLocaleMenu(eFile["Recent4"], ref argtarget12);
                            this.mnOpenR4.Text = argtarget12;
                        }
                        string argtarget13 = this.mnQuit.Text;
                        XMLLoadLocaleMenu(eFile["Quit"], ref argtarget13);
                        this.mnQuit.Text = argtarget13;
                    }

                    var eEdit = eMenu["Edit"];
                    if (eEdit is not null)
                    {
                        string argtarget14 = this.mnEdit.Text;
                        XMLLoadLocaleMenu(eEdit["Title"], ref argtarget14);
                        this.mnEdit.Text = argtarget14;
                        string argtarget15 = this.mnUndo.Text;
                        XMLLoadLocaleMenu(eEdit["Undo"], ref argtarget15);
                        this.mnUndo.Text = argtarget15;
                        string argtarget16 = this.mnRedo.Text;
                        XMLLoadLocaleMenu(eEdit["Redo"], ref argtarget16);
                        this.mnRedo.Text = argtarget16;
                        string argtarget17 = this.mnCut.Text;
                        XMLLoadLocaleMenu(eEdit["Cut"], ref argtarget17);
                        this.mnCut.Text = argtarget17;
                        string argtarget18 = this.mnCopy.Text;
                        XMLLoadLocaleMenu(eEdit["Copy"], ref argtarget18);
                        this.mnCopy.Text = argtarget18;
                        string argtarget19 = this.mnPaste.Text;
                        XMLLoadLocaleMenu(eEdit["Paste"], ref argtarget19);
                        this.mnPaste.Text = argtarget19;
                        string argtarget20 = this.mnDelete.Text;
                        XMLLoadLocaleMenu(eEdit["Delete"], ref argtarget20);
                        this.mnDelete.Text = argtarget20;
                        string argtarget21 = this.mnSelectAll.Text;
                        XMLLoadLocaleMenu(eEdit["SelectAll"], ref argtarget21);
                        this.mnSelectAll.Text = argtarget21;
                        string argtarget22 = this.mnFind.Text;
                        XMLLoadLocaleMenu(eEdit["Find"], ref argtarget22);
                        this.mnFind.Text = argtarget22;
                        string argtarget23 = this.mnStatistics.Text;
                        XMLLoadLocaleMenu(eEdit["Stat"], ref argtarget23);
                        this.mnStatistics.Text = argtarget23;
                        string argtarget24 = this.mnTimeSelect.Text;
                        XMLLoadLocaleMenu(eEdit["TimeSelectionTool"], ref argtarget24);
                        this.mnTimeSelect.Text = argtarget24;
                        string argtarget25 = this.mnSelect.Text;
                        XMLLoadLocaleMenu(eEdit["SelectTool"], ref argtarget25);
                        this.mnSelect.Text = argtarget25;
                        string argtarget26 = this.mnWrite.Text;
                        XMLLoadLocaleMenu(eEdit["WriteTool"], ref argtarget26);
                        this.mnWrite.Text = argtarget26;
                        string argtarget27 = this.mnMyO2.Text;
                        XMLLoadLocaleMenu(eEdit["MyO2"], ref argtarget27);
                        this.mnMyO2.Text = argtarget27;
                    }

                    var eView = eMenu["View"];
                    if (eView is not null)
                    {
                        string argtarget28 = this.mnSys.Text;
                        XMLLoadLocaleMenu(eView["Title"], ref argtarget28);
                        this.mnSys.Text = argtarget28;
                    }

                    var eOptions = eMenu["Options"];
                    if (eOptions is not null)
                    {
                        string argtarget29 = this.mnOptions.Text;
                        XMLLoadLocaleMenu(eOptions["Title"], ref argtarget29);
                        this.mnOptions.Text = argtarget29;
                        string argtarget30 = this.mnNTInput.Text;
                        XMLLoadLocaleMenu(eOptions["NT"], ref argtarget30);
                        this.mnNTInput.Text = argtarget30;
                        string argtarget31 = this.mnErrorCheck.Text;
                        XMLLoadLocaleMenu(eOptions["ErrorCheck"], ref argtarget31);
                        this.mnErrorCheck.Text = argtarget31;
                        string argtarget32 = this.mnPreviewOnClick.Text;
                        XMLLoadLocaleMenu(eOptions["PreviewOnClick"], ref argtarget32);
                        this.mnPreviewOnClick.Text = argtarget32;
                        string argtarget33 = this.mnShowFileName.Text;
                        XMLLoadLocaleMenu(eOptions["ShowFileName"], ref argtarget33);
                        this.mnShowFileName.Text = argtarget33;
                        string argtarget34 = this.mnGOptions.Text;
                        XMLLoadLocaleMenu(eOptions["GeneralOptions"], ref argtarget34);
                        this.mnGOptions.Text = argtarget34;
                        string argtarget35 = this.mnVOptions.Text;
                        XMLLoadLocaleMenu(eOptions["VisualOptions"], ref argtarget35);
                        this.mnVOptions.Text = argtarget35;
                        string argtarget36 = this.mnPOptions.Text;
                        XMLLoadLocaleMenu(eOptions["PlayerOptions"], ref argtarget36);
                        this.mnPOptions.Text = argtarget36;
                        string argtarget37 = this.mnLanguage.Text;
                        XMLLoadLocaleMenu(eOptions["Language"], ref argtarget37);
                        this.mnLanguage.Text = argtarget37;
                        string argtarget38 = this.mnTheme.Text;
                        XMLLoadLocaleMenu(eOptions["Theme"], ref argtarget38);
                        this.mnTheme.Text = argtarget38;
                    }

                    string argtarget39 = this.mnConversion.Text;
                    XMLLoadLocaleMenu(eMenu["Conversion"], ref argtarget39);
                    this.mnConversion.Text = argtarget39;

                    var ePreview = eMenu["Preview"];
                    if (ePreview is not null)
                    {
                        string argtarget40 = this.mnPreview.Text;
                        XMLLoadLocaleMenu(ePreview["Title"], ref argtarget40);
                        this.mnPreview.Text = argtarget40;
                        string argtarget41 = this.mnPlayB.Text;
                        XMLLoadLocaleMenu(ePreview["PlayBegin"], ref argtarget41);
                        this.mnPlayB.Text = argtarget41;
                        string argtarget42 = this.mnPlay.Text;
                        XMLLoadLocaleMenu(ePreview["PlayHere"], ref argtarget42);
                        this.mnPlay.Text = argtarget42;
                        string argtarget43 = this.mnStop.Text;
                        XMLLoadLocaleMenu(ePreview["PlayStop"], ref argtarget43);
                        this.mnStop.Text = argtarget43;
                    }

                    var eAbout = eMenu["About"];
                    if (eAbout is not null)
                    {
                        // XMLLoadLocaleMenu(eAbout.Item("Title"), mnAbout.Text)
                        // XMLLoadLocaleMenu(eAbout.Item("About"), mnAbout1.Text)
                        // XMLLoadLocaleMenu(eAbout.Item("CheckUpdates"), mnUpdate.Text)
                        // XMLLoadLocaleMenu(eAbout.Item("CheckUpdatesC"), mnUpdateC.Text)
                    }
                }

                var eToolBar = Root["ToolBar"];
                if (eToolBar is not null)
                {
                    string argtarget44 = this.TBNew.Text;
                    XMLLoadLocale(eToolBar["New"], ref argtarget44);
                    this.TBNew.Text = argtarget44;
                    string argtarget45 = this.TBOpen.Text;
                    XMLLoadLocale(eToolBar["Open"], ref argtarget45);
                    this.TBOpen.Text = argtarget45;
                    string argtarget46 = this.TBSave.Text;
                    XMLLoadLocale(eToolBar["Save"], ref argtarget46);
                    this.TBSave.Text = argtarget46;
                    string argtarget47 = this.TBCut.Text;
                    XMLLoadLocale(eToolBar["Cut"], ref argtarget47);
                    this.TBCut.Text = argtarget47;
                    string argtarget48 = this.TBCopy.Text;
                    XMLLoadLocale(eToolBar["Copy"], ref argtarget48);
                    this.TBCopy.Text = argtarget48;
                    string argtarget49 = this.TBPaste.Text;
                    XMLLoadLocale(eToolBar["Paste"], ref argtarget49);
                    this.TBPaste.Text = argtarget49;
                    string argtarget50 = this.TBFind.Text;
                    XMLLoadLocale(eToolBar["Find"], ref argtarget50);
                    this.TBFind.Text = argtarget50;
                    string argtarget51 = this.TBStatistics.ToolTipText;
                    XMLLoadLocale(eToolBar["Stat"], ref argtarget51);
                    this.TBStatistics.ToolTipText = argtarget51;
                    string argtarget52 = this.POConvert.Text;
                    XMLLoadLocale(eToolBar["Conversion"], ref argtarget52);
                    this.POConvert.Text = argtarget52;
                    string argtarget53 = this.TBMyO2.Text;
                    XMLLoadLocale(eToolBar["MyO2"], ref argtarget53);
                    this.TBMyO2.Text = argtarget53;
                    string argtarget54 = this.TBErrorCheck.Text;
                    XMLLoadLocale(eToolBar["ErrorCheck"], ref argtarget54);
                    this.TBErrorCheck.Text = argtarget54;
                    string argtarget55 = this.TBPreviewOnClick.Text;
                    XMLLoadLocale(eToolBar["PreviewOnClick"], ref argtarget55);
                    this.TBPreviewOnClick.Text = argtarget55;
                    string argtarget56 = this.TBShowFileName.Text;
                    XMLLoadLocale(eToolBar["ShowFileName"], ref argtarget56);
                    this.TBShowFileName.Text = argtarget56;
                    string argtarget57 = this.TBUndo.Text;
                    XMLLoadLocale(eToolBar["Undo"], ref argtarget57);
                    this.TBUndo.Text = argtarget57;
                    string argtarget58 = this.TBRedo.Text;
                    XMLLoadLocale(eToolBar["Redo"], ref argtarget58);
                    this.TBRedo.Text = argtarget58;
                    string argtarget59 = this.TBNTInput.Text;
                    XMLLoadLocale(eToolBar["NT"], ref argtarget59);
                    this.TBNTInput.Text = argtarget59;
                    string argtarget60 = this.TBTimeSelect.Text;
                    XMLLoadLocale(eToolBar["TimeSelectionTool"], ref argtarget60);
                    this.TBTimeSelect.Text = argtarget60;
                    string argtarget61 = this.TBSelect.Text;
                    XMLLoadLocale(eToolBar["SelectTool"], ref argtarget61);
                    this.TBSelect.Text = argtarget61;
                    string argtarget62 = this.TBWrite.Text;
                    XMLLoadLocale(eToolBar["WriteTool"], ref argtarget62);
                    this.TBWrite.Text = argtarget62;
                    string argtarget63 = this.TBPlayB.Text;
                    XMLLoadLocale(eToolBar["PlayBegin"], ref argtarget63);
                    this.TBPlayB.Text = argtarget63;
                    string argtarget64 = this.TBPlay.Text;
                    XMLLoadLocale(eToolBar["PlayHere"], ref argtarget64);
                    this.TBPlay.Text = argtarget64;
                    string argtarget65 = this.TBStop.Text;
                    XMLLoadLocale(eToolBar["PlayStop"], ref argtarget65);
                    this.TBStop.Text = argtarget65;
                    string argtarget66 = this.TBPOptions.Text;
                    XMLLoadLocale(eToolBar["PlayerOptions"], ref argtarget66);
                    this.TBPOptions.Text = argtarget66;
                    string argtarget67 = this.TBVOptions.Text;
                    XMLLoadLocale(eToolBar["VisualOptions"], ref argtarget67);
                    this.TBVOptions.Text = argtarget67;
                    string argtarget68 = this.TBGOptions.Text;
                    XMLLoadLocale(eToolBar["GeneralOptions"], ref argtarget68);
                    this.TBGOptions.Text = argtarget68;
                    string argtarget69 = this.TBLanguage.Text;
                    XMLLoadLocale(eToolBar["Language"], ref argtarget69);
                    this.TBLanguage.Text = argtarget69;
                    string argtarget70 = this.TBTheme.Text;
                    XMLLoadLocale(eToolBar["Theme"], ref argtarget70);
                    this.TBTheme.Text = argtarget70;
                    // XMLLoadLocale(eToolBar.Item("About"), TBAbout.Text)
                }

                var eStatusBar = Root["StatusBar"];
                if (eStatusBar is not null)
                {
                    string argtarget71 = this.FSC.ToolTipText;
                    XMLLoadLocale(eStatusBar["ColumnCaption"], ref argtarget71);
                    this.FSC.ToolTipText = argtarget71;
                    string argtarget72 = this.FSW.ToolTipText;
                    XMLLoadLocale(eStatusBar["NoteIndex"], ref argtarget72);
                    this.FSW.ToolTipText = argtarget72;
                    string argtarget73 = this.FSM.ToolTipText;
                    XMLLoadLocale(eStatusBar["MeasureIndex"], ref argtarget73);
                    this.FSM.ToolTipText = argtarget73;
                    string argtarget74 = this.FSP1.ToolTipText;
                    XMLLoadLocale(eStatusBar["GridResolution"], ref argtarget74);
                    this.FSP1.ToolTipText = argtarget74;
                    string argtarget75 = this.FSP3.ToolTipText;
                    XMLLoadLocale(eStatusBar["ReducedResolution"], ref argtarget75);
                    this.FSP3.ToolTipText = argtarget75;
                    string argtarget76 = this.FSP2.ToolTipText;
                    XMLLoadLocale(eStatusBar["MeasureResolution"], ref argtarget76);
                    this.FSP2.ToolTipText = argtarget76;
                    string argtarget77 = this.FSP4.ToolTipText;
                    XMLLoadLocale(eStatusBar["AbsolutePosition"], ref argtarget77);
                    this.FSP4.ToolTipText = argtarget77;
                    this.XMLLoadLocale(eStatusBar["Length"], ref iBMSCStrings.StatusBar.Length);
                    this.XMLLoadLocale(eStatusBar["LongNote"], ref iBMSCStrings.StatusBar.LongNote);
                    this.XMLLoadLocale(eStatusBar["Hidden"], ref iBMSCStrings.StatusBar.Hidden);
                    this.XMLLoadLocale(eStatusBar["Error"], ref iBMSCStrings.StatusBar.Err);
                    string argtarget78 = this.FSSS.ToolTipText;
                    XMLLoadLocale(eStatusBar["SelStart"], ref argtarget78);
                    this.FSSS.ToolTipText = argtarget78;
                    string argtarget79 = this.FSSL.ToolTipText;
                    XMLLoadLocale(eStatusBar["SelLength"], ref argtarget79);
                    this.FSSL.ToolTipText = argtarget79;
                    string argtarget80 = this.FSSH.ToolTipText;
                    XMLLoadLocale(eStatusBar["SelSplit"], ref argtarget80);
                    this.FSSH.ToolTipText = argtarget80;
                    string argtarget81 = this.BVCReverse.Text;
                    XMLLoadLocale(eStatusBar["Reverse"], ref argtarget81);
                    this.BVCReverse.Text = argtarget81;
                    string argtarget82 = this.BVCApply.Text;
                    XMLLoadLocale(eStatusBar["ByMultiple"], ref argtarget82);
                    this.BVCApply.Text = argtarget82;
                    string argtarget83 = this.BVCCalculate.Text;
                    XMLLoadLocale(eStatusBar["ByValue"], ref argtarget83);
                    this.BVCCalculate.Text = argtarget83;
                }

                var eSubMenu = Root["SubMenu"];
                if (eSubMenu is not null)
                {

                    var eShowHide = eSubMenu["ShowHide"];
                    if (eShowHide is not null)
                    {
                        // Dim xToolTip As String = ToolTipUniversal.GetToolTip(ttlIcon)
                        // XMLLoadLocaleMenu(eShowHide.Item("ToolTip"), xToolTip)
                        // ToolTipUniversal.SetToolTip(ttlIcon, xToolTip)

                        string argtarget84 = this.mnSMenu.Text;
                        XMLLoadLocaleMenu(eShowHide["Menu"], ref argtarget84);
                        this.mnSMenu.Text = argtarget84;
                        string argtarget85 = this.mnSTB.Text;
                        XMLLoadLocaleMenu(eShowHide["ToolBar"], ref argtarget85);
                        this.mnSTB.Text = argtarget85;
                        string argtarget86 = this.mnSOP.Text;
                        XMLLoadLocaleMenu(eShowHide["OptionsPanel"], ref argtarget86);
                        this.mnSOP.Text = argtarget86;
                        string argtarget87 = this.mnSStatus.Text;
                        XMLLoadLocaleMenu(eShowHide["StatusBar"], ref argtarget87);
                        this.mnSStatus.Text = argtarget87;
                        string argtarget88 = this.mnSLSplitter.Text;
                        XMLLoadLocaleMenu(eShowHide["LSplit"], ref argtarget88);
                        this.mnSLSplitter.Text = argtarget88;
                        string argtarget89 = this.mnSRSplitter.Text;
                        XMLLoadLocaleMenu(eShowHide["RSplit"], ref argtarget89);
                        this.mnSRSplitter.Text = argtarget89;
                        string argtarget90 = this.CGShow.Text;
                        XMLLoadLocaleMenu(eShowHide["Grid"], ref argtarget90);
                        this.CGShow.Text = argtarget90;
                        string argtarget91 = this.CGShowS.Text;
                        XMLLoadLocaleMenu(eShowHide["Sub"], ref argtarget91);
                        this.CGShowS.Text = argtarget91;
                        string argtarget92 = this.CGShowBG.Text;
                        XMLLoadLocaleMenu(eShowHide["BG"], ref argtarget92);
                        this.CGShowBG.Text = argtarget92;
                        string argtarget93 = this.CGShowM.Text;
                        XMLLoadLocaleMenu(eShowHide["MeasureIndex"], ref argtarget93);
                        this.CGShowM.Text = argtarget93;
                        string argtarget94 = this.CGShowMB.Text;
                        XMLLoadLocaleMenu(eShowHide["MeasureLine"], ref argtarget94);
                        this.CGShowMB.Text = argtarget94;
                        string argtarget95 = this.CGShowV.Text;
                        XMLLoadLocaleMenu(eShowHide["Vertical"], ref argtarget95);
                        this.CGShowV.Text = argtarget95;
                        string argtarget96 = this.CGShowC.Text;
                        XMLLoadLocaleMenu(eShowHide["ColumnCaption"], ref argtarget96);
                        this.CGShowC.Text = argtarget96;
                        string argtarget97 = this.CGBPM.Text;
                        XMLLoadLocaleMenu(eShowHide["BPM"], ref argtarget97);
                        this.CGBPM.Text = argtarget97;
                        string argtarget98 = this.CGSTOP.Text;
                        XMLLoadLocaleMenu(eShowHide["STOP"], ref argtarget98);
                        this.CGSTOP.Text = argtarget98;
                        string argtarget99 = this.CGSCROLL.Text;
                        XMLLoadLocaleMenu(eShowHide["SCROLL"], ref argtarget99);
                        this.CGSCROLL.Text = argtarget99;
                        string argtarget100 = this.CGBLP.Text;
                        XMLLoadLocaleMenu(eShowHide["BLP"], ref argtarget100);
                        this.CGBLP.Text = argtarget100;
                    }

                    var eInsertMeasure = eSubMenu["InsertMeasure"];
                    if (eInsertMeasure is not null)
                    {
                        string argtarget101 = this.MInsert.Text;
                        XMLLoadLocaleMenu(eInsertMeasure["Insert"], ref argtarget101);
                        this.MInsert.Text = argtarget101;
                        string argtarget102 = this.MRemove.Text;
                        XMLLoadLocaleMenu(eInsertMeasure["Remove"], ref argtarget102);
                        this.MRemove.Text = argtarget102;
                    }

                    var eLanguage = eSubMenu["Language"];
                    if (eLanguage is not null)
                    {
                        string argtarget103 = this.TBLangDef.Text;
                        XMLLoadLocaleMenu(eLanguage["Default"], ref argtarget103);
                        this.TBLangDef.Text = argtarget103;
                        string argtarget104 = this.TBLangRefresh.Text;
                        XMLLoadLocaleMenu(eLanguage["Refresh"], ref argtarget104);
                        this.TBLangRefresh.Text = argtarget104;
                    }

                    var eTheme = eSubMenu["Theme"];
                    if (eTheme is not null)
                    {
                        string argtarget105 = this.TBThemeDef.Text;
                        XMLLoadLocaleMenu(eTheme["Default"], ref argtarget105);
                        this.TBThemeDef.Text = argtarget105;
                        string argtarget106 = this.TBThemeSave.Text;
                        XMLLoadLocaleMenu(eTheme["Save"], ref argtarget106);
                        this.TBThemeSave.Text = argtarget106;
                        string argtarget107 = this.TBThemeRefresh.Text;
                        XMLLoadLocaleMenu(eTheme["Refresh"], ref argtarget107);
                        this.TBThemeRefresh.Text = argtarget107;
                        string argtarget108 = this.TBThemeLoadComptability.Text;
                        XMLLoadLocaleMenu(eTheme["LoadComptability"], ref argtarget108);
                        this.TBThemeLoadComptability.Text = argtarget108;
                    }

                    var eConvert = eSubMenu["Convert"];
                    if (eConvert is not null)
                    {
                        string argtarget109 = this.POBLong.Text;
                        XMLLoadLocaleMenu(eConvert["Long"], ref argtarget109);
                        this.POBLong.Text = argtarget109;
                        string argtarget110 = this.POBShort.Text;
                        XMLLoadLocaleMenu(eConvert["Short"], ref argtarget110);
                        this.POBShort.Text = argtarget110;
                        string argtarget111 = this.POBLongShort.Text;
                        XMLLoadLocaleMenu(eConvert["LongShort"], ref argtarget111);
                        this.POBLongShort.Text = argtarget111;
                        string argtarget112 = this.POBHidden.Text;
                        XMLLoadLocaleMenu(eConvert["Hidden"], ref argtarget112);
                        this.POBHidden.Text = argtarget112;
                        string argtarget113 = this.POBVisible.Text;
                        XMLLoadLocaleMenu(eConvert["Visible"], ref argtarget113);
                        this.POBVisible.Text = argtarget113;
                        string argtarget114 = this.POBHiddenVisible.Text;
                        XMLLoadLocaleMenu(eConvert["HiddenVisible"], ref argtarget114);
                        this.POBHiddenVisible.Text = argtarget114;
                        string argtarget115 = this.POBModify.Text;
                        XMLLoadLocaleMenu(eConvert["Relabel"], ref argtarget115);
                        this.POBModify.Text = argtarget115;
                        string argtarget116 = this.POBMirror.Text;
                        XMLLoadLocaleMenu(eConvert["Mirror"], ref argtarget116);
                        this.POBMirror.Text = argtarget116;
                    }

                    var eWAV = eSubMenu["WAV"];
                    if (eWAV is not null)
                    {
                        string argtarget117 = this.CWAVMultiSelect.Text;
                        XMLLoadLocaleMenu(eWAV["MultiSelection"], ref argtarget117);
                        this.CWAVMultiSelect.Text = argtarget117;
                        string argtarget118 = this.CWAVChangeLabel.Text;
                        XMLLoadLocaleMenu(eWAV["Synchronize"], ref argtarget118);
                        this.CWAVChangeLabel.Text = argtarget118;
                    }

                    var eBeat = eSubMenu["Beat"];
                    if (eBeat is not null)
                    {
                        string argtarget119 = this.CBeatPreserve.Text;
                        XMLLoadLocaleMenu(eBeat["Absolute"], ref argtarget119);
                        this.CBeatPreserve.Text = argtarget119;
                        string argtarget120 = this.CBeatMeasure.Text;
                        XMLLoadLocaleMenu(eBeat["Measure"], ref argtarget120);
                        this.CBeatMeasure.Text = argtarget120;
                        string argtarget121 = this.CBeatCut.Text;
                        XMLLoadLocaleMenu(eBeat["Cut"], ref argtarget121);
                        this.CBeatCut.Text = argtarget121;
                        string argtarget122 = this.CBeatScale.Text;
                        XMLLoadLocaleMenu(eBeat["Scale"], ref argtarget122);
                        this.CBeatScale.Text = argtarget122;
                    }
                }

                var eOptionsPanel = Root["OptionsPanel"];
                if (eOptionsPanel is not null)
                {

                    var eHeader = eOptionsPanel["Header"];
                    if (eHeader is not null)
                    {
                        string argtarget123 = this.POHeaderSwitch.Text;
                        XMLLoadLocale(eHeader["Header"], ref argtarget123);
                        this.POHeaderSwitch.Text = argtarget123;
                        string argtarget124 = this.Label3.Text;
                        XMLLoadLocale(eHeader["Title"], ref argtarget124);
                        this.Label3.Text = argtarget124;
                        string argtarget125 = this.Label4.Text;
                        XMLLoadLocale(eHeader["Artist"], ref argtarget125);
                        this.Label4.Text = argtarget125;
                        string argtarget126 = this.Label2.Text;
                        XMLLoadLocale(eHeader["Genre"], ref argtarget126);
                        this.Label2.Text = argtarget126;
                        string argtarget127 = this.Label9.Text;
                        XMLLoadLocale(eHeader["BPM"], ref argtarget127);
                        this.Label9.Text = argtarget127;
                        string argtarget128 = this.Label8.Text;
                        XMLLoadLocale(eHeader["Player"], ref argtarget128);
                        this.Label8.Text = argtarget128;
                        string argtarget129 = this.Label10.Text;
                        XMLLoadLocale(eHeader["Rank"], ref argtarget129);
                        this.Label10.Text = argtarget129;
                        string argtarget130 = this.Label6.Text;
                        XMLLoadLocale(eHeader["PlayLevel"], ref argtarget130);
                        this.Label6.Text = argtarget130;
                        string argtarget131 = this.Label15.Text;
                        XMLLoadLocale(eHeader["SubTitle"], ref argtarget131);
                        this.Label15.Text = argtarget131;
                        string argtarget132 = this.Label17.Text;
                        XMLLoadLocale(eHeader["SubArtist"], ref argtarget132);
                        this.Label17.Text = argtarget132;
                        // XMLLoadLocale(eHeader.Item("Maker"), Label14.Text)
                        string argtarget133 = this.Label16.Text;
                        XMLLoadLocale(eHeader["StageFile"], ref argtarget133);
                        this.Label16.Text = argtarget133;
                        string argtarget134 = this.Label12.Text;
                        XMLLoadLocale(eHeader["Banner"], ref argtarget134);
                        this.Label12.Text = argtarget134;
                        string argtarget135 = this.Label11.Text;
                        XMLLoadLocale(eHeader["BackBMP"], ref argtarget135);
                        this.Label11.Text = argtarget135;
                        // XMLLoadLocale(eHeader.Item("MidiFile"), Label18.Text)
                        string argtarget136 = this.Label21.Text;
                        XMLLoadLocale(eHeader["Difficulty"], ref argtarget136);
                        this.Label21.Text = argtarget136;
                        string argtarget137 = this.Label23.Text;
                        XMLLoadLocale(eHeader["ExRank"], ref argtarget137);
                        this.Label23.Text = argtarget137;
                        string argtarget138 = this.Label20.Text;
                        XMLLoadLocale(eHeader["Total"], ref argtarget138);
                        this.Label20.Text = argtarget138;
                        // XMLLoadLocale(eHeader.Item("VolWav"), Label22.Text)
                        string argtarget139 = this.Label19.Text;
                        XMLLoadLocale(eHeader["Comment"], ref argtarget139);
                        this.Label19.Text = argtarget139;
                        // XMLLoadLocale(eHeader.Item("LnType"), Label13.Text)
                        string argtarget140 = this.Label24.Text;
                        XMLLoadLocale(eHeader["LnObj"], ref argtarget140);
                        this.Label24.Text = argtarget140;

                        this.CHPlayer.SelectedIndexChanged -= this.CHPlayer_SelectedIndexChanged;
                        var tmp = this.CHPlayer.Items;
                        string argtarget141 = Conversions.ToString(tmp[0]);
                        XMLLoadLocale(eHeader["Player1"], ref argtarget141);
                        tmp[0] = argtarget141;
                        var tmp1 = this.CHPlayer.Items;
                        string argtarget142 = Conversions.ToString(tmp1[1]);
                        XMLLoadLocale(eHeader["Player2"], ref argtarget142);
                        tmp1[1] = argtarget142;
                        var tmp2 = this.CHPlayer.Items;
                        string argtarget143 = Conversions.ToString(tmp2[2]);
                        XMLLoadLocale(eHeader["Player3"], ref argtarget143);
                        tmp2[2] = argtarget143;
                        this.CHPlayer.SelectedIndexChanged += this.CHPlayer_SelectedIndexChanged;

                        this.CHRank.SelectedIndexChanged -= this.THGenre_TextChanged;
                        var tmp3 = this.CHRank.Items;
                        string argtarget144 = Conversions.ToString(tmp3[0]);
                        XMLLoadLocale(eHeader["Rank0"], ref argtarget144);
                        tmp3[0] = argtarget144;
                        var tmp4 = this.CHRank.Items;
                        string argtarget145 = Conversions.ToString(tmp4[1]);
                        XMLLoadLocale(eHeader["Rank1"], ref argtarget145);
                        tmp4[1] = argtarget145;
                        var tmp5 = this.CHRank.Items;
                        string argtarget146 = Conversions.ToString(tmp5[2]);
                        XMLLoadLocale(eHeader["Rank2"], ref argtarget146);
                        tmp5[2] = argtarget146;
                        var tmp6 = this.CHRank.Items;
                        string argtarget147 = Conversions.ToString(tmp6[3]);
                        XMLLoadLocale(eHeader["Rank3"], ref argtarget147);
                        tmp6[3] = argtarget147;
                        var tmp7 = this.CHRank.Items;
                        string argtarget148 = Conversions.ToString(tmp7[4]);
                        XMLLoadLocale(eHeader["Rank4"], ref argtarget148);
                        tmp7[4] = argtarget148;
                        this.CHRank.SelectedIndexChanged += this.THGenre_TextChanged;

                        this.CHDifficulty.SelectedIndexChanged -= this.THGenre_TextChanged;
                        var tmp8 = this.CHDifficulty.Items;
                        string argtarget149 = Conversions.ToString(tmp8[0]);
                        XMLLoadLocale(eHeader["Difficulty0"], ref argtarget149);
                        tmp8[0] = argtarget149;
                        var tmp9 = this.CHDifficulty.Items;
                        string argtarget150 = Conversions.ToString(tmp9[1]);
                        XMLLoadLocale(eHeader["Difficulty1"], ref argtarget150);
                        tmp9[1] = argtarget150;
                        var tmp10 = this.CHDifficulty.Items;
                        string argtarget151 = Conversions.ToString(tmp10[2]);
                        XMLLoadLocale(eHeader["Difficulty2"], ref argtarget151);
                        tmp10[2] = argtarget151;
                        var tmp11 = this.CHDifficulty.Items;
                        string argtarget152 = Conversions.ToString(tmp11[3]);
                        XMLLoadLocale(eHeader["Difficulty3"], ref argtarget152);
                        tmp11[3] = argtarget152;
                        var tmp12 = this.CHDifficulty.Items;
                        string argtarget153 = Conversions.ToString(tmp12[4]);
                        XMLLoadLocale(eHeader["Difficulty4"], ref argtarget153);
                        tmp12[4] = argtarget153;
                        var tmp13 = this.CHDifficulty.Items;
                        string argtarget154 = Conversions.ToString(tmp13[5]);
                        XMLLoadLocale(eHeader["Difficulty5"], ref argtarget154);
                        tmp13[5] = argtarget154;
                        this.CHDifficulty.SelectedIndexChanged += this.THGenre_TextChanged;
                    }

                    var eGrid = eOptionsPanel["Grid"];
                    if (eGrid is not null)
                    {
                        string argtarget155 = this.POGridSwitch.Text;
                        XMLLoadLocale(eGrid["Title"], ref argtarget155);
                        this.POGridSwitch.Text = argtarget155;
                        string argtarget156 = this.CGSnap.Text;
                        XMLLoadLocale(eGrid["Snap"], ref argtarget156);
                        this.CGSnap.Text = argtarget156;
                        string argtarget157 = this.Label1.Text;
                        XMLLoadLocale(eGrid["BCols"], ref argtarget157);
                        this.Label1.Text = argtarget157;
                        string argtarget158 = this.CGDisableVertical.Text;
                        XMLLoadLocale(eGrid["DisableVertical"], ref argtarget158);
                        this.CGDisableVertical.Text = argtarget158;
                        string argtarget159 = this.Label5.Text;
                        XMLLoadLocale(eGrid["Scroll"], ref argtarget159);
                        this.Label5.Text = argtarget159;
                        this.XMLLoadLocaleToolTipUniversal(eGrid["LockLeft"], this.cVSLockL);
                        this.XMLLoadLocaleToolTipUniversal(eGrid["LockMiddle"], this.cVSLock);
                        this.XMLLoadLocaleToolTipUniversal(eGrid["LockRight"], this.cVSLockR);
                    }

                    var eWaveForm = eOptionsPanel["WaveForm"];
                    if (eWaveForm is not null)
                    {
                        string argtarget160 = this.POWaveFormSwitch.Text;
                        XMLLoadLocale(eWaveForm["Title"], ref argtarget160);
                        this.POWaveFormSwitch.Text = argtarget160;
                        this.XMLLoadLocaleToolTipUniversal(eWaveForm["Load"], this.BWLoad);
                        this.XMLLoadLocaleToolTipUniversal(eWaveForm["Clear"], this.BWClear);
                        this.XMLLoadLocaleToolTipUniversal(eWaveForm["Lock"], this.BWLock);
                    }

                    var eWAV = eOptionsPanel["WAV"];
                    if (eWAV is not null)
                    {
                        string argtarget161 = this.POWAVSwitch.Text;
                        XMLLoadLocale(eWAV["Title"], ref argtarget161);
                        this.POWAVSwitch.Text = argtarget161;
                        this.XMLLoadLocaleToolTipUniversal(eWAV["MoveUp"], this.BBMPUp);
                        this.XMLLoadLocaleToolTipUniversal(eWAV["MoveDown"], this.BBMPDown);
                        this.XMLLoadLocaleToolTipUniversal(eWAV["Browse"], this.BBMPBrowse);
                        this.XMLLoadLocaleToolTipUniversal(eWAV["Remove"], this.BBMPRemove);
                        this.XMLLoadLocaleToolTipUniversal(eWAV["MoveUp"], this.BWAVUp);
                        this.XMLLoadLocaleToolTipUniversal(eWAV["MoveDown"], this.BWAVDown);
                        this.XMLLoadLocaleToolTipUniversal(eWAV["Browse"], this.BWAVBrowse);
                        this.XMLLoadLocaleToolTipUniversal(eWAV["Remove"], this.BWAVRemove);
                    }

                    var eBMP = eOptionsPanel["BMP"];
                    if (eBMP is not null)
                    {
                        string argtarget162 = this.POBMPSwitch.Text;
                        XMLLoadLocale(eBMP["Title"], ref argtarget162);
                        this.POBMPSwitch.Text = argtarget162;
                    }

                    string argtarget163 = this.POBeatSwitch.Text;
                    XMLLoadLocale(eOptionsPanel["Beat"], ref argtarget163);
                    this.POBeatSwitch.Text = argtarget163;
                    string argtarget164 = this.BBeatApply.Text;
                    XMLLoadLocale(eOptionsPanel["Beat.Apply"], ref argtarget164);
                    this.BBeatApply.Text = argtarget164;
                    string argtarget165 = this.BBeatApplyV.Text;
                    XMLLoadLocale(eOptionsPanel["Beat.Apply"], ref argtarget165);
                    this.BBeatApplyV.Text = argtarget165;
                    string argtarget166 = this.POExpansionSwitch.Text;
                    XMLLoadLocale(eOptionsPanel["Expansion"], ref argtarget166);
                    this.POExpansionSwitch.Text = argtarget166;
                }

                var eMessages = Root["Messages"];
                if (eMessages is not null)
                {
                    this.XMLLoadLocale(eMessages["Err"], ref iBMSCStrings.Messages.Err);
                    this.XMLLoadLocale(eMessages["SaveOnExit"], ref iBMSCStrings.Messages.SaveOnExit);
                    this.XMLLoadLocale(eMessages["SaveOnExit1"], ref iBMSCStrings.Messages.SaveOnExit1);
                    this.XMLLoadLocale(eMessages["SaveOnExit2"], ref iBMSCStrings.Messages.SaveOnExit2);
                    this.XMLLoadLocale(eMessages["PromptEnter"], ref iBMSCStrings.Messages.PromptEnter);
                    this.XMLLoadLocale(eMessages["PromptEnterNumeric"], ref iBMSCStrings.Messages.PromptEnterNumeric);
                    this.XMLLoadLocale(eMessages["PromptEnterBPM"], ref iBMSCStrings.Messages.PromptEnterBPM);
                    this.XMLLoadLocale(eMessages["PromptEnterSTOP"], ref iBMSCStrings.Messages.PromptEnterSTOP);
                    this.XMLLoadLocale(eMessages["PromptEnterSCROLL"], ref iBMSCStrings.Messages.PromptEnterSCROLL);
                    this.XMLLoadLocale(eMessages["PromptSlashValue"], ref iBMSCStrings.Messages.PromptSlashValue);
                    this.XMLLoadLocale(eMessages["InvalidLabel"], ref iBMSCStrings.Messages.InvalidLabel);
                    this.XMLLoadLocale(eMessages["CannotFind"], ref iBMSCStrings.Messages.CannotFind);
                    this.XMLLoadLocale(eMessages["PleaseRespecifyPath"], ref iBMSCStrings.Messages.PleaseRespecifyPath);
                    this.XMLLoadLocale(eMessages["PlayerNotFound"], ref iBMSCStrings.Messages.PlayerNotFound);
                    this.XMLLoadLocale(eMessages["PreviewDelError"], ref iBMSCStrings.Messages.PreviewDelError);
                    this.XMLLoadLocale(eMessages["NegativeFactorError"], ref iBMSCStrings.Messages.NegativeFactorError);
                    this.XMLLoadLocale(eMessages["NegativeDivisorError"], ref iBMSCStrings.Messages.NegativeDivisorError);
                    this.XMLLoadLocale(eMessages["PreferencePostpone"], ref iBMSCStrings.Messages.PreferencePostpone);
                    this.XMLLoadLocale(eMessages["EraserObsolete"], ref iBMSCStrings.Messages.EraserObsolete);
                    this.XMLLoadLocale(eMessages["SaveWarning"], ref iBMSCStrings.Messages.SaveWarning);
                    this.XMLLoadLocale(eMessages["NoteOverlapError"], ref iBMSCStrings.Messages.NoteOverlapError);
                    this.XMLLoadLocale(eMessages["BPMOverflowError"], ref iBMSCStrings.Messages.BPMOverflowError);
                    this.XMLLoadLocale(eMessages["STOPOverflowError"], ref iBMSCStrings.Messages.STOPOverflowError);
                    this.XMLLoadLocale(eMessages["SCROLLOverflowError"], ref iBMSCStrings.Messages.SCROLLOverflowError);
                    this.XMLLoadLocale(eMessages["SavedFileWillContainErrors"], ref iBMSCStrings.Messages.SavedFileWillContainErrors);
                    this.XMLLoadLocale(eMessages["FileAssociationPrompt"], ref iBMSCStrings.Messages.FileAssociationPrompt);
                    this.XMLLoadLocale(eMessages["FileAssociationError"], ref iBMSCStrings.Messages.FileAssociationError);
                    this.XMLLoadLocale(eMessages["RestoreDefaultSettings"], ref iBMSCStrings.Messages.RestoreDefaultSettings);
                    this.XMLLoadLocale(eMessages["RestoreAutosavedFile"], ref iBMSCStrings.Messages.RestoreAutosavedFile);
                }

                var eFileType = Root["FileType"];
                if (eFileType is not null)
                {
                    this.XMLLoadLocale(eFileType["_all"], ref iBMSCStrings.FileType._all);
                    this.XMLLoadLocale(eFileType["_bms"], ref iBMSCStrings.FileType._bms);
                    this.XMLLoadLocale(eFileType["BMS"], ref iBMSCStrings.FileType.BMS);
                    this.XMLLoadLocale(eFileType["BME"], ref iBMSCStrings.FileType.BME);
                    this.XMLLoadLocale(eFileType["BML"], ref iBMSCStrings.FileType.BML);
                    this.XMLLoadLocale(eFileType["PMS"], ref iBMSCStrings.FileType.PMS);
                    this.XMLLoadLocale(eFileType["TXT"], ref iBMSCStrings.FileType.TXT);
                    this.XMLLoadLocale(eFileType["SM"], ref iBMSCStrings.FileType.SM);
                    this.XMLLoadLocale(eFileType["IBMSC"], ref iBMSCStrings.FileType.IBMSC);
                    this.XMLLoadLocale(eFileType["XML"], ref iBMSCStrings.FileType.XML);
                    this.XMLLoadLocale(eFileType["THEME_XML"], ref iBMSCStrings.FileType.THEME_XML);
                    this.XMLLoadLocale(eFileType["TH"], ref iBMSCStrings.FileType.TH);
                    this.XMLLoadLocale(eFileType["_audio"], ref iBMSCStrings.FileType._audio);
                    this.XMLLoadLocale(eFileType["_wave"], ref iBMSCStrings.FileType._wave);
                    this.XMLLoadLocale(eFileType["WAV"], ref iBMSCStrings.FileType.WAV);
                    this.XMLLoadLocale(eFileType["OGG"], ref iBMSCStrings.FileType.OGG);
                    this.XMLLoadLocale(eFileType["MP3"], ref iBMSCStrings.FileType.MP3);
                    this.XMLLoadLocale(eFileType["MID"], ref iBMSCStrings.FileType.MID);
                    this.XMLLoadLocale(eFileType["_image"], ref iBMSCStrings.FileType._image);
                    this.XMLLoadLocale(eFileType["_movie"], ref iBMSCStrings.FileType._movie);
                    this.XMLLoadLocale(eFileType["BMP"], ref iBMSCStrings.FileType.BMP);
                    this.XMLLoadLocale(eFileType["PNG"], ref iBMSCStrings.FileType.PNG);
                    this.XMLLoadLocale(eFileType["JPG"], ref iBMSCStrings.FileType.JPG);
                    this.XMLLoadLocale(eFileType["GIF"], ref iBMSCStrings.FileType.GIF);
                    this.XMLLoadLocale(eFileType["MPG"], ref iBMSCStrings.FileType.MPG);
                    this.XMLLoadLocale(eFileType["AVI"], ref iBMSCStrings.FileType.AVI);
                    this.XMLLoadLocale(eFileType["MP4"], ref iBMSCStrings.FileType.MP4);
                    this.XMLLoadLocale(eFileType["WMV"], ref iBMSCStrings.FileType.WMV);
                    this.XMLLoadLocale(eFileType["WEBM"], ref iBMSCStrings.FileType.WEBM);
                    this.XMLLoadLocale(eFileType["EXE"], ref iBMSCStrings.FileType.EXE);
                }

                var eStatistics = Root["Statistics"];
                if (eStatistics is not null)
                {
                    this.XMLLoadLocale(eStatistics["Title"], ref iBMSCStrings.fStatistics.Title);
                    this.XMLLoadLocale(eStatistics["lBPM"], ref iBMSCStrings.fStatistics.lBPM);
                    this.XMLLoadLocale(eStatistics["lSTOP"], ref iBMSCStrings.fStatistics.lSTOP);
                    this.XMLLoadLocale(eStatistics["lSCROLL"], ref iBMSCStrings.fStatistics.lSCROLL);
                    this.XMLLoadLocale(eStatistics["lA"], ref iBMSCStrings.fStatistics.lA);
                    this.XMLLoadLocale(eStatistics["lD"], ref iBMSCStrings.fStatistics.lD);
                    this.XMLLoadLocale(eStatistics["lBGM"], ref iBMSCStrings.fStatistics.lBGM);
                    this.XMLLoadLocale(eStatistics["lTotal"], ref iBMSCStrings.fStatistics.lTotal);
                    this.XMLLoadLocale(eStatistics["lShort"], ref iBMSCStrings.fStatistics.lShort);
                    this.XMLLoadLocale(eStatistics["lLong"], ref iBMSCStrings.fStatistics.lLong);
                    this.XMLLoadLocale(eStatistics["lLnObj"], ref iBMSCStrings.fStatistics.lLnObj);
                    this.XMLLoadLocale(eStatistics["lHidden"], ref iBMSCStrings.fStatistics.lHidden);
                    this.XMLLoadLocale(eStatistics["lErrors"], ref iBMSCStrings.fStatistics.lErrors);
                }

                var ePlayerOptions = Root["PlayerOptions"];
                if (ePlayerOptions is not null)
                {
                    this.XMLLoadLocale(ePlayerOptions["Title"], ref iBMSCStrings.fopPlayer.Title);
                    this.XMLLoadLocale(ePlayerOptions["Add"], ref iBMSCStrings.fopPlayer.Add);
                    this.XMLLoadLocale(ePlayerOptions["Remove"], ref iBMSCStrings.fopPlayer.Remove);
                    this.XMLLoadLocale(ePlayerOptions["Path"], ref iBMSCStrings.fopPlayer.Path);
                    this.XMLLoadLocale(ePlayerOptions["PlayFromBeginning"], ref iBMSCStrings.fopPlayer.PlayFromBeginning);
                    this.XMLLoadLocale(ePlayerOptions["PlayFromHere"], ref iBMSCStrings.fopPlayer.PlayFromHere);
                    this.XMLLoadLocale(ePlayerOptions["StopPlaying"], ref iBMSCStrings.fopPlayer.StopPlaying);
                    this.XMLLoadLocale(ePlayerOptions["References"], ref iBMSCStrings.fopPlayer.References);
                    this.XMLLoadLocale(ePlayerOptions["DirectoryOfApp"], ref iBMSCStrings.fopPlayer.DirectoryOfApp);
                    this.XMLLoadLocale(ePlayerOptions["CurrMeasure"], ref iBMSCStrings.fopPlayer.CurrMeasure);
                    this.XMLLoadLocale(ePlayerOptions["FileName"], ref iBMSCStrings.fopPlayer.FileName);
                    this.XMLLoadLocale(ePlayerOptions["RestoreDefault"], ref iBMSCStrings.fopPlayer.RestoreDefault);
                }

                var eVisualOptions = Root["VisualOptions"];
                if (eVisualOptions is not null)
                {
                    this.XMLLoadLocale(eVisualOptions["Title"], ref iBMSCStrings.fopVisual.Title);
                    this.XMLLoadLocale(eVisualOptions["Width"], ref iBMSCStrings.fopVisual.Width);
                    this.XMLLoadLocale(eVisualOptions["Caption"], ref iBMSCStrings.fopVisual.Caption);
                    this.XMLLoadLocale(eVisualOptions["Note"], ref iBMSCStrings.fopVisual.Note);
                    this.XMLLoadLocale(eVisualOptions["Label"], ref iBMSCStrings.fopVisual.Label);
                    this.XMLLoadLocale(eVisualOptions["LongNote"], ref iBMSCStrings.fopVisual.LongNote);
                    this.XMLLoadLocale(eVisualOptions["LongNoteLabel"], ref iBMSCStrings.fopVisual.LongNoteLabel);
                    this.XMLLoadLocale(eVisualOptions["Bg"], ref iBMSCStrings.fopVisual.Bg);
                    this.XMLLoadLocale(eVisualOptions["ColumnCaption"], ref iBMSCStrings.fopVisual.ColumnCaption);
                    this.XMLLoadLocale(eVisualOptions["ColumnCaptionFont"], ref iBMSCStrings.fopVisual.ColumnCaptionFont);
                    this.XMLLoadLocale(eVisualOptions["Background"], ref iBMSCStrings.fopVisual.Background);
                    this.XMLLoadLocale(eVisualOptions["Grid"], ref iBMSCStrings.fopVisual.Grid);
                    this.XMLLoadLocale(eVisualOptions["SubGrid"], ref iBMSCStrings.fopVisual.SubGrid);
                    this.XMLLoadLocale(eVisualOptions["VerticalLine"], ref iBMSCStrings.fopVisual.VerticalLine);
                    this.XMLLoadLocale(eVisualOptions["MeasureBarLine"], ref iBMSCStrings.fopVisual.MeasureBarLine);
                    this.XMLLoadLocale(eVisualOptions["BGMWaveform"], ref iBMSCStrings.fopVisual.BGMWaveform);
                    this.XMLLoadLocale(eVisualOptions["NoteHeight"], ref iBMSCStrings.fopVisual.NoteHeight);
                    this.XMLLoadLocale(eVisualOptions["NoteLabel"], ref iBMSCStrings.fopVisual.NoteLabel);
                    this.XMLLoadLocale(eVisualOptions["MeasureLabel"], ref iBMSCStrings.fopVisual.MeasureLabel);
                    this.XMLLoadLocale(eVisualOptions["LabelVerticalShift"], ref iBMSCStrings.fopVisual.LabelVerticalShift);
                    this.XMLLoadLocale(eVisualOptions["LabelHorizontalShift"], ref iBMSCStrings.fopVisual.LabelHorizontalShift);
                    this.XMLLoadLocale(eVisualOptions["LongNoteLabelHorizontalShift"], ref iBMSCStrings.fopVisual.LongNoteLabelHorizontalShift);
                    this.XMLLoadLocale(eVisualOptions["HiddenNoteOpacity"], ref iBMSCStrings.fopVisual.HiddenNoteOpacity);
                    this.XMLLoadLocale(eVisualOptions["NoteBorderOnMouseOver"], ref iBMSCStrings.fopVisual.NoteBorderOnMouseOver);
                    this.XMLLoadLocale(eVisualOptions["NoteBorderOnSelection"], ref iBMSCStrings.fopVisual.NoteBorderOnSelection);
                    this.XMLLoadLocale(eVisualOptions["NoteBorderOnAdjustingLength"], ref iBMSCStrings.fopVisual.NoteBorderOnAdjustingLength);
                    this.XMLLoadLocale(eVisualOptions["SelectionBoxBorder"], ref iBMSCStrings.fopVisual.SelectionBoxBorder);
                    this.XMLLoadLocale(eVisualOptions["TSCursor"], ref iBMSCStrings.fopVisual.TSCursor);
                    this.XMLLoadLocale(eVisualOptions["TSSplitter"], ref iBMSCStrings.fopVisual.TSSplitter);
                    this.XMLLoadLocale(eVisualOptions["TSCursorSensitivity"], ref iBMSCStrings.fopVisual.TSCursorSensitivity);
                    this.XMLLoadLocale(eVisualOptions["TSMouseOverBorder"], ref iBMSCStrings.fopVisual.TSMouseOverBorder);
                    this.XMLLoadLocale(eVisualOptions["TSFill"], ref iBMSCStrings.fopVisual.TSFill);
                    this.XMLLoadLocale(eVisualOptions["TSBPM"], ref iBMSCStrings.fopVisual.TSBPM);
                    this.XMLLoadLocale(eVisualOptions["TSBPMFont"], ref iBMSCStrings.fopVisual.TSBPMFont);
                    this.XMLLoadLocale(eVisualOptions["MiddleSensitivity"], ref iBMSCStrings.fopVisual.MiddleSensitivity);
                }

                var eGeneralOptions = Root["GeneralOptions"];
                if (eGeneralOptions is not null)
                {
                    this.XMLLoadLocale(eGeneralOptions["Title"], ref iBMSCStrings.fopGeneral.Title);
                    this.XMLLoadLocale(eGeneralOptions["MouseWheel"], ref iBMSCStrings.fopGeneral.MouseWheel);
                    this.XMLLoadLocale(eGeneralOptions["TextEncoding"], ref iBMSCStrings.fopGeneral.TextEncoding);
                    this.XMLLoadLocale(eGeneralOptions["PageUpDown"], ref iBMSCStrings.fopGeneral.PageUpDown);
                    this.XMLLoadLocale(eGeneralOptions["MiddleButton"], ref iBMSCStrings.fopGeneral.MiddleButton);
                    this.XMLLoadLocale(eGeneralOptions["MiddleButtonAuto"], ref iBMSCStrings.fopGeneral.MiddleButtonAuto);
                    this.XMLLoadLocale(eGeneralOptions["MiddleButtonDrag"], ref iBMSCStrings.fopGeneral.MiddleButtonDrag);
                    this.XMLLoadLocale(eGeneralOptions["AssociateFileType"], ref iBMSCStrings.fopGeneral.AssociateFileType);
                    this.XMLLoadLocale(eGeneralOptions["MaxGridPartition"], ref iBMSCStrings.fopGeneral.MaxGridPartition);
                    this.XMLLoadLocale(eGeneralOptions["BeepWhileSaved"], ref iBMSCStrings.fopGeneral.BeepWhileSaved);
                    this.XMLLoadLocale(eGeneralOptions["ExtendBPM"], ref iBMSCStrings.fopGeneral.ExtendBPM);
                    this.XMLLoadLocale(eGeneralOptions["ExtendSTOP"], ref iBMSCStrings.fopGeneral.ExtendSTOP);
                    this.XMLLoadLocale(eGeneralOptions["AutoFocusOnMouseEnter"], ref iBMSCStrings.fopGeneral.AutoFocusOnMouseEnter);
                    this.XMLLoadLocale(eGeneralOptions["DisableFirstClick"], ref iBMSCStrings.fopGeneral.DisableFirstClick);
                    this.XMLLoadLocale(eGeneralOptions["AutoSave"], ref iBMSCStrings.fopGeneral.AutoSave);
                    this.XMLLoadLocale(eGeneralOptions["minutes"], ref iBMSCStrings.fopGeneral.minutes);
                    this.XMLLoadLocale(eGeneralOptions["StopPreviewOnClick"], ref iBMSCStrings.fopGeneral.StopPreviewOnClick);
                }

                var eFind = Root["Find"];
                if (eFind is not null)
                {
                    this.XMLLoadLocale(eFind["NoteRange"], ref iBMSCStrings.fFind.NoteRange);
                    this.XMLLoadLocale(eFind["MeasureRange"], ref iBMSCStrings.fFind.MeasureRange);
                    this.XMLLoadLocale(eFind["LabelRange"], ref iBMSCStrings.fFind.LabelRange);
                    this.XMLLoadLocale(eFind["ValueRange"], ref iBMSCStrings.fFind.ValueRange);
                    this.XMLLoadLocale(eFind["to"], ref iBMSCStrings.fFind.to_);
                    this.XMLLoadLocale(eFind["Selected"], ref iBMSCStrings.fFind.Selected);
                    this.XMLLoadLocale(eFind["UnSelected"], ref iBMSCStrings.fFind.UnSelected);
                    this.XMLLoadLocale(eFind["ShortNote"], ref iBMSCStrings.fFind.ShortNote);
                    this.XMLLoadLocale(eFind["LongNote"], ref iBMSCStrings.fFind.LongNote);
                    this.XMLLoadLocale(eFind["Hidden"], ref iBMSCStrings.fFind.Hidden);
                    this.XMLLoadLocale(eFind["Visible"], ref iBMSCStrings.fFind.Visible);
                    this.XMLLoadLocale(eFind["Column"], ref iBMSCStrings.fFind.Column);
                    this.XMLLoadLocale(eFind["SelectAll"], ref iBMSCStrings.fFind.SelectAll);
                    this.XMLLoadLocale(eFind["SelectInverse"], ref iBMSCStrings.fFind.SelectInverse);
                    this.XMLLoadLocale(eFind["UnselectAll"], ref iBMSCStrings.fFind.UnselectAll);
                    this.XMLLoadLocale(eFind["Operation"], ref iBMSCStrings.fFind.Operation);
                    this.XMLLoadLocale(eFind["ReplaceWithLabel"], ref iBMSCStrings.fFind.ReplaceWithLabel);
                    this.XMLLoadLocale(eFind["ReplaceWithValue"], ref iBMSCStrings.fFind.ReplaceWithValue);
                    this.XMLLoadLocale(eFind["Select"], ref iBMSCStrings.fFind.Select_);
                    this.XMLLoadLocale(eFind["Unselect"], ref iBMSCStrings.fFind.Unselect_);
                    this.XMLLoadLocale(eFind["Delete"], ref iBMSCStrings.fFind.Delete_);
                    this.XMLLoadLocale(eFind["Close"], ref iBMSCStrings.fFind.Close_);
                }

                var eImportSM = Root["ImportSM"];
                if (eImportSM is not null)
                {
                    this.XMLLoadLocale(eImportSM["Title"], ref iBMSCStrings.fImportSM.Title);
                    this.XMLLoadLocale(eImportSM["Difficulty"], ref iBMSCStrings.fImportSM.Difficulty);
                    this.XMLLoadLocale(eImportSM["Note"], ref iBMSCStrings.fImportSM.Note);
                }

                var eFileAssociation = Root["FileAssociation"];
                if (eFileAssociation is not null)
                {
                    this.XMLLoadLocale(eFileAssociation["BMS"], ref iBMSCStrings.FileAssociation.BMS);
                    this.XMLLoadLocale(eFileAssociation["BME"], ref iBMSCStrings.FileAssociation.BME);
                    this.XMLLoadLocale(eFileAssociation["BML"], ref iBMSCStrings.FileAssociation.BML);
                    this.XMLLoadLocale(eFileAssociation["PMS"], ref iBMSCStrings.FileAssociation.PMS);
                    this.XMLLoadLocale(eFileAssociation["IBMSC"], ref iBMSCStrings.FileAssociation.IBMSC);
                    this.XMLLoadLocale(eFileAssociation["Open"], ref iBMSCStrings.FileAssociation.Open);
                    this.XMLLoadLocale(eFileAssociation["Preview"], ref iBMSCStrings.FileAssociation.Preview);
                    this.XMLLoadLocale(eFileAssociation["ViewCode"], ref iBMSCStrings.FileAssociation.ViewCode);
                }

                this.DispLang = Path.Replace(Application.ExecutablePath + @"\", "");
            }

            catch (Exception ex)
            {
                Interaction.MsgBox(Path + Constants.vbCrLf + Constants.vbCrLf + ex.Message, MsgBoxStyle.Exclamation);
            }

            finally
            {
                if (FileStream is not null)
                    FileStream.Close();

                this.POHeaderPart2.Visible = xPOHeaderPart2;
                this.POGridPart2.Visible = xPOGridPart2;
                this.POWaveFormPart2.Visible = xPOWaveFormPart2;
            }

            // File.Delete(xTempFileName)
        }

        private void LoadThemeComptability(string xPath)
        {
            try
            {
                var xStrLine = Strings.Split(File.ReadAllText(xPath), Constants.vbCrLf);
                if (xStrLine[0].Trim() != "iBMSC Configuration Settings Format" & xStrLine[0].Trim() != "iBMSC Theme Format")
                    return;

                string xW1 = "";
                string xW2 = "";

                foreach (string xLine in xStrLine)
                {
                    xW1 = Strings.UCase(Strings.Mid(xLine, 1, Strings.InStr(xLine, "=") - 1));
                    xW2 = Strings.Mid(xLine, Strings.InStr(xLine, "=") + 1);

                    switch (xW1 ?? "")
                    {
                        case "VOTITLE":
                            {
                                this.vo.ColumnTitle.Color = Color.FromArgb((int)Math.Round(Conversion.Val(xW2)));
                                break;
                            }
                        case "VOTITLEFONT":
                            {
                                this.vo.ColumnTitleFont = iBMSC.Editor.Functions.StringToFont(xW2, this.Font);
                                break;
                            }
                        case "VOBG":
                            {
                                this.vo.Bg.Color = Color.FromArgb((int)Math.Round(Conversion.Val(xW2)));
                                break;
                            }
                        case "VOGRID":
                            {
                                this.vo.pGrid.Color = Color.FromArgb((int)Math.Round(Conversion.Val(xW2)));
                                break;
                            }
                        case "VOSUB":
                            {
                                this.vo.pSub.Color = Color.FromArgb((int)Math.Round(Conversion.Val(xW2)));
                                break;
                            }
                        case "VOVLINE":
                            {
                                this.vo.pVLine.Color = Color.FromArgb((int)Math.Round(Conversion.Val(xW2)));
                                break;
                            }
                        case "VOMLINE":
                            {
                                this.vo.pMLine.Color = Color.FromArgb((int)Math.Round(Conversion.Val(xW2)));
                                break;
                            }
                        case "VOBGMWAV":
                            {
                                this.vo.pBGMWav.Color = Color.FromArgb((int)Math.Round(Conversion.Val(xW2)));
                                this.TWTransparency.Value = (decimal)this.vo.pBGMWav.Color.A;
                                this.TWTransparency2.Value = (int)this.vo.pBGMWav.Color.A;
                                this.TWSaturation.Value = (decimal)(this.vo.pBGMWav.Color.GetSaturation() * 1000f);
                                this.TWSaturation2.Value = (int)Math.Round(this.vo.pBGMWav.Color.GetSaturation() * 1000f);
                                break;
                            }
                        case "VOSELBOX":
                            {
                                this.vo.SelBox.Color = Color.FromArgb((int)Math.Round(Conversion.Val(xW2)));
                                break;
                            }
                        case "VOPECURSOR":
                            {
                                this.vo.PECursor.Color = Color.FromArgb((int)Math.Round(Conversion.Val(xW2)));
                                break;
                            }
                        case "VOPEHALF":
                            {
                                this.vo.PEHalf.Color = Color.FromArgb((int)Math.Round(Conversion.Val(xW2)));
                                break;
                            }
                        case "VOPEDELTAMOUSEOVER":
                            {
                                this.vo.PEDeltaMouseOver = (int)Math.Round(Conversion.Val(xW2));
                                break;
                            }
                        case "VOPEMOUSEOVER":
                            {
                                this.vo.PEMouseOver.Color = Color.FromArgb((int)Math.Round(Conversion.Val(xW2)));
                                break;
                            }
                        case "VOPESEL":
                            {
                                this.vo.PESel.Color = Color.FromArgb((int)Math.Round(Conversion.Val(xW2)));
                                break;
                            }
                        case "VOPEBPM":
                            {
                                this.vo.PEBPM.Color = Color.FromArgb((int)Math.Round(Conversion.Val(xW2)));
                                break;
                            }
                        case "VOPEBPMFONT":
                            {
                                this.vo.PEBPMFont = iBMSC.Editor.Functions.StringToFont(xW2, this.Font);
                                break;
                            }
                        case "VKHEIGHT":
                            {
                                this.vo.kHeight = (int)Math.Round(Conversion.Val(xW2));
                                break;
                            }
                        case "VKFONT":
                            {
                                this.vo.kFont = iBMSC.Editor.Functions.StringToFont(xW2, this.Font);
                                break;
                            }
                        case "VKMFONT":
                            {
                                this.vo.kMFont = iBMSC.Editor.Functions.StringToFont(xW2, this.Font);
                                break;
                            }
                        case "VKLABELVSHIFT":
                            {
                                this.vo.kLabelVShift = (int)Math.Round(Conversion.Val(xW2));
                                break;
                            }
                        case "VKLABELHSHIFT":
                            {
                                this.vo.kLabelHShift = (int)Math.Round(Conversion.Val(xW2));
                                break;
                            }
                        case "VKLABELHSHIFTL":
                            {
                                this.vo.kLabelHShiftL = (int)Math.Round(Conversion.Val(xW2));
                                break;
                            }
                        case "VKMOUSEOVER":
                            {
                                this.vo.kMouseOver.Color = Color.FromArgb((int)Math.Round(Conversion.Val(xW2)));
                                break;
                            }
                        case "VKMOUSEOVERE ":
                            {
                                this.vo.kMouseOverE.Color = Color.FromArgb((int)Math.Round(Conversion.Val(xW2)));
                                break;
                            }
                        case "VKSELECTED":
                            {
                                this.vo.kSelected.Color = Color.FromArgb((int)Math.Round(Conversion.Val(xW2)));
                                break;
                            }
                        // Case "VKHIDTRANSPARENCY" : vo.kOpacity = Val(xW2)

                        case "KLENGTH":
                            {
                                var xE = LoadThemeComptability_SplitStringInto26Parts(xW2);
                                for (int i = 0; i <= 26; i++)
                                    this.column[i].Width = (int)Math.Round(Conversion.Val(xE[i]));
                                break;
                            }

                        case "KTITLE":
                            {
                                var xE = LoadThemeComptability_SplitStringInto26Parts(xW2);
                                for (int i = 0; i <= 26; i++)
                                    this.column[i].Title = xE[i];
                                break;
                            }

                        case "KCOLOR":
                            {
                                var xE = LoadThemeComptability_SplitStringInto26Parts(xW2);
                                for (int i = 0; i <= 26; i++)
                                    this.column[i].setNoteColor((int)Math.Round(Conversion.Val(xE[i])));
                                break;
                            }

                        case "KCOLORL":
                            {
                                var xE = LoadThemeComptability_SplitStringInto26Parts(xW2);
                                for (int i = 0; i <= 26; i++)
                                    this.column[i].setLNoteColor((int)Math.Round(Conversion.Val(xE[i])));
                                break;
                            }

                        case "KFORECOLOR":
                            {
                                var xE = LoadThemeComptability_SplitStringInto26Parts(xW2);
                                for (int i = 0; i <= 26; i++)
                                    this.column[i].cText = Color.FromArgb((int)Math.Round(Conversion.Val(xE[i])));
                                break;
                            }

                        case "KFORECOLORL":
                            {
                                var xE = LoadThemeComptability_SplitStringInto26Parts(xW2);
                                for (int i = 0; i <= 26; i++)
                                    this.column[i].cLText = Color.FromArgb((int)Math.Round(Conversion.Val(xE[i])));
                                break;
                            }

                        case "KBGCOLOR":
                            {
                                var xE = LoadThemeComptability_SplitStringInto26Parts(xW2);
                                for (int i = 0; i <= 26; i++)
                                    this.column[i].cBG = Color.FromArgb((int)Math.Round(Conversion.Val(xE[i])));
                                break;
                            }

                    }

                }
            }

            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message, MsgBoxStyle.Exclamation, iBMSCStrings.Messages.Err);
            }

            finally
            {
                this.UpdateColumnsX();

            }
        }

        private string[] LoadThemeComptability_SplitStringInto26Parts(string xLine)
        {
            var xE = Strings.Split(xLine, ",");
            Array.Resize(ref xE, 27);
            return xE;
        }

        private void LoadLang(object sender, EventArgs e)
        {
            string xFN2 = Conversions.ToString(sender.ToolTipText);
            // ReadLanguagePack(xFN2)
            LoadLocale(xFN2);
        }

        private void LoadLocaleXML(FileInfo xStr)
        {
            var d = new XmlDocument();
            var fs = new FileStream(xStr.FullName, FileMode.Open, FileAccess.Read);

            try
            {
                d.Load(fs);
                string xName = d["iBMSC.Locale"].GetAttribute("Name");
                if (string.IsNullOrEmpty(xName))
                    xName = xStr.Name;

                this.cmnLanguage.Items.Add(xName, null, this.LoadLang);
                this.cmnLanguage.Items[this.cmnLanguage.Items.Count - 1].ToolTipText = xStr.FullName;
            }

            catch (Exception ex)
            {
                Interaction.MsgBox(xStr.FullName + Constants.vbCrLf + Constants.vbCrLf + ex.Message, MsgBoxStyle.Exclamation);

            }

            fs.Close();
        }

        private void LoadTheme(object sender, EventArgs e)
        {
            // If Not File.Exists(My.Application.Info.DirectoryPath & "\Data\" & sender.Text) Then Exit Sub
            // SaveTheme = True
            // LoadCFF(My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\Theme\" & sender.Text, System.Text.Encoding.Unicode))
            LoadSettings(Conversions.ToString(Operators.ConcatenateObject(Application.ExecutablePath + @"\Data\", sender.Text)));
            this.RefreshPanelAll();
        }
    }
}