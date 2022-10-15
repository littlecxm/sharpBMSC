using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace iBMSC
{

    public partial class MainWindow
    {

        private void RefreshPanelAll()
        {
            if (this.IsInitializing)
                return;
            this.RefreshPanel(0, this.PMainInL.DisplayRectangle);
            this.RefreshPanel(1, this.PMainIn.DisplayRectangle);
            this.RefreshPanel(2, this.PMainInR.DisplayRectangle);
        }

        private Dictionary<int, BufferedGraphics> bufferlist = new Dictionary<int, BufferedGraphics>();
        private Dictionary<int, Rectangle> rectList = new Dictionary<int, Rectangle>();
        private object GetBuffer(int xIndex, Rectangle DisplayRect)
        {
            if (bufferlist.ContainsKey(xIndex) && rectList[xIndex] == DisplayRect)
            {
                return bufferlist[xIndex];
            }
            else
            {
                if (bufferlist.ContainsKey(xIndex))
                {
                    bufferlist[xIndex].Dispose();
                    bufferlist.Remove(xIndex);
                    rectList.Remove(xIndex);
                }

                var gfx = BufferedGraphicsManager.Current.Allocate(this.spMain[xIndex].CreateGraphics(), DisplayRect);
                bufferlist.Add(xIndex, gfx);
                rectList.Add(xIndex, DisplayRect);
                return gfx;
            }
        }

        private void RefreshPanel(int xIndex, Rectangle DisplayRect)
        {
            if (this.WindowState == FormWindowState.Minimized)
                return;
            if (DisplayRect.Width <= 0 | DisplayRect.Height <= 0)
                return;
            // If spMain.Count = 0 Then Return
            // Dim currentContext As BufferedGraphicsContext = BufferedGraphicsManager.Current
            BufferedGraphics e1 = (BufferedGraphics)GetBuffer(xIndex, DisplayRect);
            e1.Graphics.FillRectangle(this.vo.Bg, DisplayRect);

            int xTHeight = this.spMain[xIndex].Height;
            int xTWidth = this.spMain[xIndex].Width;
            int xPanelHScroll = this.PanelHScroll[xIndex];
            int xPanelDisplacement = this.PanelVScroll[xIndex];
            int xVSR = -this.PanelVScroll[xIndex];
            int xVSu = Conversions.ToInteger(Interaction.IIf((double)((float)xVSR + (float)xTHeight / this.gxHeight) > this.GetMaxVPosition(), (object)this.GetMaxVPosition(), (object)((float)xVSR + (float)xTHeight / this.gxHeight)));

            // e1.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            var xI1 = default(int);

            // Bg color
            DrawBackgroundColor(e1, xTHeight, xTWidth, xPanelHScroll, xI1);

            xI1 = DrawPanelLines(e1, xTHeight, xTWidth, xPanelHScroll, xPanelDisplacement, xVSu);

            // Column Caption
            xI1 = DrawColumnCaptions(e1, xTWidth, xPanelHScroll, xI1);

            // WaveForm
            DrawWaveform(e1, xTHeight, xVSR, xI1);

            // K
            // If Not K Is Nothing Then
            DrawNotes(e1, xTHeight, xPanelHScroll, xPanelDisplacement);

            // End If

            // Selection Box
            DrawSelectionBox(xIndex, e1);

            // Mouse Over
            if (this.TBSelect.Checked && !(this.KMouseOver == -1))
            {
                DrawMouseOver(e1, xTHeight, xPanelHScroll, xPanelDisplacement);
            }

            if (this.ShouldDrawTempNote && this.SelectedColumn > -1 & this.TempVPosition > (double)-1)
            {
                DrawTempNote(e1, xTHeight, xPanelHScroll, xPanelDisplacement);
            }

            // Time Selection
            if (this.TBTimeSelect.Checked)
            {
                DrawTimeSelection(e1, xTHeight, xTWidth, xPanelHScroll, xPanelDisplacement);
            }

            // Middle button: CLick and Scroll
            if (this.MiddleButtonClicked)
            {
                e1 = DrawClickAndScroll(xIndex, e1);
            }

            // Drag/Drop
            DrawDragAndDrop(xIndex, e1);

            e1.Render(this.spMain[xIndex].CreateGraphics());
            // e1.Dispose()
        }

        private void DrawTempNote(BufferedGraphics e1, int xTHeight, int xHS, int xVS)
        {
            int xValue = (this.LWAV.SelectedIndex + 1) * 10000;

            float xAlpha = 1.0f;
            if (iBMSC.PanelKeyStates.ModifierHiddenActive())
            {
                xAlpha = this.vo.kOpacity;
            }

            string xText = iBMSC.Editor.Functions.C10to36((long)(xValue / 10000));
            if (this.IsColumnNumeric(this.SelectedColumn))
            {
                xText = this.GetColumn(this.SelectedColumn).Title;
            }

            Pen xPen;
            System.Drawing.Drawing2D.LinearGradientBrush xBrush;
            SolidBrush xBrush2;
            var point1 = new Point(this.HorizontalPositiontoDisplay(this.nLeft(this.SelectedColumn), (long)xHS), this.NoteRowToPanelHeight(this.TempVPosition, (long)xVS, xTHeight) - this.vo.kHeight - 10);
            var point2 = new Point(this.HorizontalPositiontoDisplay(this.nLeft(this.SelectedColumn) + this.GetColumnWidth(this.SelectedColumn), (long)xHS), this.NoteRowToPanelHeight(this.TempVPosition, (long)xVS, xTHeight) + 10);

            Color bright;
            Color dark;
            if (this.NTInput | !iBMSC.PanelKeyStates.ModifierLongNoteActive())
            {
                xPen = new Pen(this.GetColumn(this.SelectedColumn).getBright(xAlpha));
                bright = this.GetColumn(this.SelectedColumn).getBright(xAlpha);
                dark = this.GetColumn(this.SelectedColumn).getDark(xAlpha);

                xBrush2 = new SolidBrush(this.GetColumn(this.SelectedColumn).cText);
            }
            else
            {
                xPen = new Pen(this.GetColumn(this.SelectedColumn).getLongBright(xAlpha));
                bright = this.GetColumn(this.SelectedColumn).getLongBright(xAlpha);
                dark = this.GetColumn(this.SelectedColumn).getLongDark(xAlpha);

                xBrush2 = new SolidBrush(this.GetColumn(this.SelectedColumn).cLText);
            }

            // Temp landmine
            if (iBMSC.PanelKeyStates.ModifierLandmineActive())
            {
                bright = Color.Red;
                dark = Color.Red;
            }

            xBrush = new System.Drawing.Drawing2D.LinearGradientBrush(point1, point2, bright, dark);

            e1.Graphics.FillRectangle(xBrush, (float)(this.HorizontalPositiontoDisplay(this.nLeft(this.SelectedColumn), (long)xHS) + 2), (float)(this.NoteRowToPanelHeight(this.TempVPosition, (long)xVS, xTHeight) - this.vo.kHeight + 1), (float)this.GetColumnWidth(this.SelectedColumn) * this.gxWidth - 3f, (float)(this.vo.kHeight - 1));
            e1.Graphics.DrawRectangle(xPen, (float)(this.HorizontalPositiontoDisplay(this.nLeft(this.SelectedColumn), (long)xHS) + 1), (float)(this.NoteRowToPanelHeight(this.TempVPosition, (long)xVS, xTHeight) - this.vo.kHeight), (float)this.GetColumnWidth(this.SelectedColumn) * this.gxWidth - 2f, (float)this.vo.kHeight);

            e1.Graphics.DrawString(xText, this.vo.kFont, xBrush2, (float)(this.HorizontalPositiontoDisplay(this.nLeft(this.SelectedColumn), (long)xHS) + this.vo.kLabelHShiftL - 2), (float)(this.NoteRowToPanelHeight(this.TempVPosition, (long)xVS, xTHeight) - this.vo.kHeight + this.vo.kLabelVShift));
        }

        private void DrawDragAndDrop(int xIndex, BufferedGraphics e1)
        {
            if (Information.UBound(this.DDFileName) > -1)
            {
                // Dim xFont As New Font("Cambria", 12)
                var xBrush = new SolidBrush(Color.FromArgb(int.MinValue + 0x40FFFFFF));
                float xCenterX = (float)((double)this.spMain[xIndex].DisplayRectangle.Width / 2d);
                float xCenterY = (float)((double)this.spMain[xIndex].DisplayRectangle.Height / 2d);
                var xFormat = new StringFormat();
                xFormat.Alignment = StringAlignment.Center;
                xFormat.LineAlignment = StringAlignment.Center;
                e1.Graphics.DrawString(Strings.Join(this.DDFileName, Constants.vbCrLf), this.Font, xBrush, this.spMain[xIndex].DisplayRectangle, xFormat);
            }
        }

        private void DrawSelectionBox(int xIndex, BufferedGraphics e1)
        {
            if (this.TBSelect.Checked && xIndex == this.PanelFocus && !(this.pMouseMove == new Point(-1, -1) | this.LastMouseDownLocation == new Point(-1, -1)))
            {
                e1.Graphics.DrawRectangle(this.vo.SelBox, Conversions.ToSingle(Interaction.IIf(this.pMouseMove.X > this.LastMouseDownLocation.X, (object)this.LastMouseDownLocation.X, (object)this.pMouseMove.X)), Conversions.ToSingle(Interaction.IIf(this.pMouseMove.Y > this.LastMouseDownLocation.Y, (object)this.LastMouseDownLocation.Y, (object)this.pMouseMove.Y)), Math.Abs(this.pMouseMove.X - this.LastMouseDownLocation.X), Math.Abs(this.pMouseMove.Y - this.LastMouseDownLocation.Y));
            }
        }

        public object GetColumnHighlightColor(Color col, double factor = 2.0d)
        {
            object clamp(object x) => Interaction.IIf(Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(x, 255, false)), 255, x);
            return Color.FromArgb(Conversions.ToInteger(clamp(col.A * factor)), Conversions.ToInteger(clamp(col.R * factor)), Conversions.ToInteger(clamp(col.G * factor)), Conversions.ToInteger(clamp(col.B * factor)));
        }

        private void DrawBackgroundColor(BufferedGraphics e1, int xTHeight, int xTWidth, int xHS, int xI1)
        {
            if (this.gShowBG)
            {
                var loopTo = this.gColumns;
                for (xI1 = 0; xI1 <= loopTo; xI1++)
                {
                    if ((float)this.nLeft(xI1 + 1) * this.gxWidth - (float)xHS * this.gxWidth + 1f < 0f)
                        continue;
                    if ((float)this.nLeft(xI1) * this.gxWidth - (float)xHS * this.gxWidth + 1f > (float)xTWidth)
                        break;
                    if (!(this.GetColumn(xI1).cBG.GetBrightness() == 0f) & this.GetColumnWidth(xI1) > 0)
                    {
                        var col = this.GetColumn(xI1).cBG;
                        if (xI1 == this.GetColumnAtX(this.MouseMoveStatus.X, xHS))
                        {
                            double bf = 1.2d;
                            col = (Color)this.GetColumnHighlightColor(col);
                        }
                        var brush = new SolidBrush(col);

                        e1.Graphics.FillRectangle(brush, (float)this.nLeft(xI1) * this.gxWidth - (float)xHS * this.gxWidth + 1f, 0f, (float)this.GetColumnWidth(xI1) * this.gxWidth, (float)xTHeight);
                    }
                }
            }
        }

        private int DrawColumnCaptions(BufferedGraphics e1, int xTWidth, int xHS, int xI1)
        {
            if (this.gShowC)
            {
                var loopTo = this.gColumns;
                for (xI1 = 0; xI1 <= loopTo; xI1++)
                {
                    if ((float)this.nLeft(xI1 + 1) * this.gxWidth - (float)xHS * this.gxWidth + 1f < 0f)
                        continue;
                    if ((float)this.nLeft(xI1) * this.gxWidth - (float)xHS * this.gxWidth + 1f > (float)xTWidth)
                        break;
                    if (this.GetColumnWidth(xI1) > 0)
                        e1.Graphics.DrawString(this.nTitle(xI1), this.vo.ColumnTitleFont, this.vo.ColumnTitle, (float)this.nLeft(xI1) * this.gxWidth - (float)xHS * this.gxWidth, 0f);
                }
            }

            return xI1;
        }

        private int DrawPanelLines(BufferedGraphics e1, int xTHeight, int xTWidth, int xHS, int xVS, int xVSu)
        {
            // Vertical line
            if (this.gShowVerticalLine)
            {
                for (int xI1 = 0, loopTo = this.gColumns; xI1 <= loopTo; xI1++)
                {
                    float xpos = (float)this.nLeft(xI1) * this.gxWidth - (float)xHS * this.gxWidth;
                    if (xpos + 1f < 0f)
                        continue;
                    if (xpos + 1f > xTWidth)
                        break;
                    if (this.GetColumnWidth(xI1) > 0)
                        e1.Graphics.DrawLine(this.vo.pVLine, xpos, 0f, xpos, (float)xTHeight);
                }
            }

            // Grid, Sub, Measure
            object Measure;
            var loopTo1 = this.MeasureAtDisplacement((double)xVSu);
            for (Measure = this.MeasureAtDisplacement((double)-xVS); Measure <= loopTo1; Measure++)
            {
                // grid
                if (this.gShowGrid)
                    this.DrawGridLines(e1, xTHeight, xTWidth, xVS, Conversions.ToInteger(Measure), this.gDivide, this.vo.pGrid);

                // sub
                if (this.gShowSubGrid)
                    this.DrawGridLines(e1, xTHeight, xTWidth, xVS, Conversions.ToInteger(Measure), this.gSub, this.vo.pSub);


                // measure and measurebar
                double xCurr = this.MeasureBottom[Conversions.ToInteger(Measure)];
                int Height = this.NoteRowToPanelHeight(xCurr, (long)xVS, xTHeight);
                if (this.gShowMeasureBar)
                    e1.Graphics.DrawLine(this.vo.pMLine, 0, Height, xTWidth, Height);
                if (this.gShowMeasureNumber)
                    e1.Graphics.DrawString("[" + iBMSC.Editor.Functions.Add3Zeros(Conversions.ToInteger(Measure)).ToString() + "]", this.vo.kMFont, new SolidBrush(this.GetColumn(0).cText), (float)-xHS * this.gxWidth, (float)(Height - this.vo.kMFont.Height));
            }

            var vpos = this.GetMouseVPosition(this.gSnap);
            int mouseLineHeight = this.NoteRowToPanelHeight(Conversions.ToDouble(vpos), (long)xVS, xTHeight);
            var p = new Pen(Color.White);
            e1.Graphics.DrawLine(p, 0, mouseLineHeight, xTWidth, mouseLineHeight);

            return Conversions.ToInteger(Measure);
        }

        private void DrawGridLines(BufferedGraphics e1, int xTHeight, int xTWidth, int xVS, int measureIndex, int divisions, Pen pen)
        {
            int Line = 0;
            double xUpper = this.MeasureUpper(measureIndex);
            double xCurr = this.MeasureBottom[measureIndex];
            double xDiff = 192d / divisions;
            while (xCurr < xUpper)
            {
                int Height = this.NoteRowToPanelHeight(xCurr, (long)xVS, xTHeight);
                e1.Graphics.DrawLine(pen, 0, Height, xTWidth, Height);
                Line += 1;
                xCurr = this.MeasureBottom[measureIndex] + Line * xDiff;
            }
        }

        private bool IsNoteVisible(iBMSC.Editor.Note note, int xTHeight, int xVS)
        {
            float xUpperBorder = (float)Math.Abs(xVS) + (float)xTHeight / this.gxHeight;
            float xLowerBorder = (float)Math.Abs(xVS) - (float)this.vo.kHeight / this.gxHeight;

            bool AboveLower = note.VPosition >= (double)xLowerBorder;
            bool HeadBelow = note.VPosition <= (double)xLowerBorder;
            bool TailAbove = note.VPosition + note.Length >= (double)xLowerBorder;
            bool IntersectsNT = HeadBelow & TailAbove;
            bool Intersecs = note.VPosition <= (double)xLowerBorder & this.Notes[note.LNPair].VPosition >= (double)xLowerBorder;
            bool AboveUpper = note.VPosition > (double)xUpperBorder;

            bool NoteInside = !AboveUpper & AboveLower;

            return NoteInside || IntersectsNT || IntersectsNT;
        }

        private bool IsNoteVisible(int noteindex, int xTHeight, int xVS)
        {
            return this.IsNoteVisible(this.Notes[noteindex], xTHeight, xVS);
        }

        private void DrawNotes(BufferedGraphics e1, int xTHeight, int xHS, int xVS)
        {
            int xI1;
            float xUpperBorder = (float)Math.Abs(xVS) + (float)xTHeight / this.gxHeight;
            float xLowerBorder = (float)Math.Abs(xVS) - (float)this.vo.kHeight / this.gxHeight;

            var loopTo = Information.UBound(this.Notes);
            for (xI1 = 0; xI1 <= loopTo; xI1++)
            {
                if (this.Notes[xI1].VPosition > (double)xUpperBorder)
                    break;
                if (!IsNoteVisible(xI1, xTHeight, xVS))
                    continue;
                if (this.NTInput)
                {
                    this.DrawNoteNT(this.Notes[xI1], e1, (long)xHS, (long)xVS, xTHeight);
                }
                else
                {
                    this.DrawNote(this.Notes[xI1], e1, (long)xHS, (long)xVS, xTHeight);
                }
            }
        }

        private Rectangle GetNoteRectangle(iBMSC.Editor.Note note, int xTHeight, int xHS, int xVS)
        {
            int xDispX = this.HorizontalPositiontoDisplay(this.nLeft(note.ColumnIndex), (long)xHS);

            int xDispY = Conversions.ToInteger(Interaction.IIf(!this.NTInput | this.bAdjustLength & !this.bAdjustUpper, (object)(this.NoteRowToPanelHeight(note.VPosition, (long)xVS, xTHeight) - this.vo.kHeight - 1), (object)(this.NoteRowToPanelHeight(note.VPosition + note.Length, (long)xVS, xTHeight) - this.vo.kHeight - 1)));

            int xDispW = (int)Math.Round((float)this.GetColumnWidth(note.ColumnIndex) * this.gxWidth + 1f);
            int xDispH = Conversions.ToInteger(Interaction.IIf(!this.NTInput | this.bAdjustLength, (object)(this.vo.kHeight + 3), (object)(note.Length * (double)this.gxHeight + (double)this.vo.kHeight + 3d)));

            return new Rectangle(xDispX, xDispY, xDispW, xDispH);
        }

        private Rectangle GetNoteRectangle(int noteIndex, int xTHeight, int xHS, int xVS)
        {
            return this.GetNoteRectangle(this.Notes[noteIndex], xTHeight, xHS, xVS);
        }


        private void DrawMouseOver(BufferedGraphics e1, int xTHeight, int xHS, int xVS)
        {
            if (this.NTInput)
            {
                if (!this.bAdjustLength)
                    this.DrawNoteNT(this.Notes[this.KMouseOver], e1, (long)xHS, (long)xVS, xTHeight);
            }
            else
            {
                this.DrawNote(this.Notes[this.KMouseOver], e1, (long)xHS, (long)xVS, xTHeight);
            }

            var rect = this.GetNoteRectangle(this.KMouseOver, xTHeight, xHS, xVS);
            var pen = Interaction.IIf(this.bAdjustLength, this.vo.kMouseOverE, this.vo.kMouseOver);
            e1.Graphics.DrawRectangle(pen, rect.X, rect.Y, (object)(rect.Width - 1), (object)(rect.Height - 1));

            if (iBMSC.PanelKeyStates.ModifierMultiselectActive())
            {
                foreach (var note in this.Notes)
                {
                    if (this.IsNoteVisible(note, xTHeight, xVS) && this.IsLabelMatch(note, this.KMouseOver))
                    {
                        var nrect = this.GetNoteRectangle(note, xTHeight, xHS, xVS);
                        e1.Graphics.DrawRectangle(pen, nrect.X, nrect.Y, (object)(nrect.Width - 1), (object)(nrect.Height - 1));
                    }
                }
            }

        }

        private void DrawTimeSelection(BufferedGraphics e1, int xTHeight, int xTWidth, int xHS, int xVS)
        {
            int xI1;
            long xBPMStart = this.Notes[0].Value;
            long xBPMHalf = this.Notes[0].Value;
            long xBPMEnd = this.Notes[0].Value;

            var loopTo = Information.UBound(this.Notes);
            for (xI1 = 1; xI1 <= loopTo; xI1++)
            {
                if (this.Notes[xI1].ColumnIndex == MainWindow.niBPM)
                {
                    if (this.Notes[xI1].VPosition <= this.vSelStart)
                        xBPMStart = this.Notes[xI1].Value;
                    if (this.Notes[xI1].VPosition <= this.vSelStart + this.vSelHalf)
                        xBPMHalf = this.Notes[xI1].Value;
                    if (this.Notes[xI1].VPosition <= this.vSelStart + this.vSelLength)
                        xBPMEnd = this.Notes[xI1].Value;
                }
                if (this.Notes[xI1].VPosition > this.vSelStart + this.vSelLength)
                    break;
            }

            // Selection area
            e1.Graphics.FillRectangle(this.vo.PESel, 0, this.NoteRowToPanelHeight(Conversions.ToDouble(Operators.AddObject(this.vSelStart, Interaction.IIf(this.vSelLength > 0d, (object)this.vSelLength, 0))), (long)xVS, xTHeight) + Math.Abs(Conversions.ToInteger(this.vSelLength != 0d)), xTWidth, (int)Math.Round(Math.Abs(this.vSelLength) * (double)this.gxHeight));
            // End Cursor
            e1.Graphics.DrawLine(this.vo.PECursor, 0, this.NoteRowToPanelHeight(this.vSelStart + this.vSelLength, (long)xVS, xTHeight), xTWidth, this.NoteRowToPanelHeight(this.vSelStart + this.vSelLength, (long)xVS, xTHeight));
            // Half Cursor
            e1.Graphics.DrawLine(this.vo.PEHalf, 0, this.NoteRowToPanelHeight(this.vSelStart + this.vSelHalf, (long)xVS, xTHeight), xTWidth, this.NoteRowToPanelHeight(this.vSelStart + this.vSelHalf, (long)xVS, xTHeight));
            // Start BPM
            e1.Graphics.DrawString((xBPMStart / 10000d).ToString(), this.vo.PEBPMFont, this.vo.PEBPM, (float)(-xHS + this.nLeft(MainWindow.niBPM)) * this.gxWidth, (float)(this.NoteRowToPanelHeight(this.vSelStart, (long)xVS, xTHeight) - this.vo.PEBPMFont.Height + 3));
            // Half BPM
            e1.Graphics.DrawString((xBPMHalf / 10000d).ToString(), this.vo.PEBPMFont, this.vo.PEBPM, (float)(-xHS + this.nLeft(MainWindow.niBPM)) * this.gxWidth, (float)(this.NoteRowToPanelHeight(this.vSelStart + this.vSelHalf, (long)xVS, xTHeight) - this.vo.PEBPMFont.Height + 3));
            // End BPM
            e1.Graphics.DrawString((xBPMEnd / 10000d).ToString(), this.vo.PEBPMFont, this.vo.PEBPM, (float)(-xHS + this.nLeft(MainWindow.niBPM)) * this.gxWidth, (float)(this.NoteRowToPanelHeight(this.vSelStart + this.vSelLength, (long)xVS, xTHeight) - this.vo.PEBPMFont.Height + 3));

            // SelLine
            if (this.vSelMouseOverLine == 1) // Start Cursor
            {
                e1.Graphics.DrawRectangle(this.vo.PEMouseOver, 0, this.NoteRowToPanelHeight(this.vSelStart, (long)xVS, xTHeight) - 1, xTWidth - 1, 2);
            }
            else if (this.vSelMouseOverLine == 2) // Half Cursor
            {
                e1.Graphics.DrawRectangle(this.vo.PEMouseOver, 0, this.NoteRowToPanelHeight(this.vSelStart + this.vSelHalf, (long)xVS, xTHeight) - 1, xTWidth - 1, 2);
            }
            else if (this.vSelMouseOverLine == 3) // End Cursor
            {
                e1.Graphics.DrawRectangle(this.vo.PEMouseOver, 0, this.NoteRowToPanelHeight(this.vSelStart + this.vSelLength, (long)xVS, xTHeight) - 1, xTWidth - 1, 2);
            }
        }

        private BufferedGraphics DrawClickAndScroll(int xIndex, BufferedGraphics e1)
        {
            var xDeltaLocation = this.spMain[xIndex].PointToScreen(new Point(0, 0));

            float xInitX = (float)(this.MiddleButtonLocation.X - xDeltaLocation.X);
            float xInitY = (float)(this.MiddleButtonLocation.Y - xDeltaLocation.Y);
            float xCurrX = (float)(Cursor.Position.X - xDeltaLocation.X);
            float xCurrY = (float)(Cursor.Position.Y - xDeltaLocation.Y);
            double xAngle = Math.Atan2((double)(xCurrY - xInitY), (double)(xCurrX - xInitX));
            e1.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            if (!(xInitX == xCurrX & xInitY == xCurrY))
            {
                var xPointx = new PointF[] { new PointF(xCurrX, xCurrY), new PointF((float)(Math.Cos(xAngle + Math.PI / 2d) * 10d + (double)xInitX), (float)(Math.Sin(xAngle + Math.PI / 2d) * 10d + (double)xInitY)), new PointF((float)(Math.Cos(xAngle - Math.PI / 2d) * 10d + (double)xInitX), (float)(Math.Sin(xAngle - Math.PI / 2d) * 10d + (double)xInitY)) };
                e1.Graphics.FillPolygon(new System.Drawing.Drawing2D.LinearGradientBrush(new Point((int)Math.Round(xInitX), (int)Math.Round(xInitY)), new Point((int)Math.Round(xCurrX), (int)Math.Round(xCurrY)), Color.FromArgb(0), Color.FromArgb(-1)), xPointx);
            }

            e1.Graphics.FillEllipse(Brushes.LightGray, xInitX - 10f, xInitY - 10f, 20f, 20f);
            e1.Graphics.DrawEllipse(Pens.Black, xInitX - 8f, xInitY - 8f, 16f, 16f);

            e1.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            return e1;
        }

        private void DrawWaveform(BufferedGraphics e1, int xTHeight, int xVSR, int xI1)
        {
            if (this.wWavL is not null & this.wWavR is not null & this.wPrecision > 0)
            {
                if (this.wLock)
                {
                    for (int xI0 = 1, loopTo = Information.UBound(this.Notes); xI0 <= loopTo; xI0++)
                    {
                        if (this.Notes[xI0].ColumnIndex >= MainWindow.niB)
                        {
                            this.wPosition = this.Notes[xI0].VPosition;
                            break;
                        }
                    }
                }

                var xPtsL = new PointF[xTHeight * this.wPrecision + 1];
                var xPtsR = new PointF[xTHeight * this.wPrecision + 1];

                double xD1;

                var bVPosition = new double[] { this.wPosition };
                var bBPM = new decimal[] { (decimal)((double)this.Notes[0].Value / 10000d) };
                var bWavDataIndex = new decimal[] { 0m };

                var loopTo1 = Information.UBound(this.Notes);
                for (xI1 = 1; xI1 <= loopTo1; xI1++)
                {
                    if (this.Notes[xI1].ColumnIndex == MainWindow.niBPM)
                    {
                        if (this.Notes[xI1].VPosition >= this.wPosition)
                        {
                            Array.Resize(ref bVPosition, Information.UBound(bVPosition) + 1 + 1);
                            Array.Resize(ref bBPM, Information.UBound(bBPM) + 1 + 1);
                            Array.Resize(ref bWavDataIndex, Information.UBound(bWavDataIndex) + 1 + 1);
                            bVPosition[Information.UBound(bVPosition)] = this.Notes[xI1].VPosition;
                            bBPM[Information.UBound(bBPM)] = (decimal)((double)this.Notes[xI1].Value / 10000d);
                            bWavDataIndex[Information.UBound(bWavDataIndex)] = (decimal)((this.Notes[xI1].VPosition - bVPosition[Information.UBound(bVPosition) - 1]) * 1.25d * (double)this.wSampleRate / (double)bBPM[Information.UBound(bBPM) - 1] + (double)bWavDataIndex[Information.UBound(bWavDataIndex) - 1]);
                        }
                        else
                        {
                            bBPM[0] = (decimal)((double)this.Notes[xI1].Value / 10000d);
                        }
                    }
                }

                int xI2 = 0;
                double xI3;

                for (xI1 = xTHeight * this.wPrecision; xI1 >= 0; xI1 -= 1)
                {
                    xI3 = ((double)-xI1 / (double)this.wPrecision + (double)xTHeight + (double)((float)xVSR * this.gxHeight) - 1d) / (double)this.gxHeight;
                    var loopTo2 = Information.UBound(bVPosition);
                    for (xI2 = 1; xI2 <= loopTo2; xI2++)
                    {
                        if (bVPosition[xI2] >= xI3)
                            break;
                    }
                    xI2 -= 1;
                    xD1 = (double)bWavDataIndex[xI2] + (xI3 - bVPosition[xI2]) * 1.25d * (double)this.wSampleRate / (double)bBPM[xI2];

                    if (xD1 <= (double)Information.UBound(this.wWavL) & xD1 >= 0d)
                    {
                        xPtsL[xI1] = new PointF(this.wWavL[(int)Math.Round(Conversion.Int(xD1))] * (float)this.wWidth + (float)this.wLeft, (float)((double)xI1 / (double)this.wPrecision));
                        xPtsR[xI1] = new PointF(this.wWavR[(int)Math.Round(Conversion.Int(xD1))] * (float)this.wWidth + (float)this.wLeft, (float)((double)xI1 / (double)this.wPrecision));
                    }
                    else
                    {
                        xPtsL[xI1] = new PointF((float)this.wLeft, (float)((double)xI1 / (double)this.wPrecision));
                        xPtsR[xI1] = new PointF((float)this.wLeft, (float)((double)xI1 / (double)this.wPrecision));
                    }
                }
                e1.Graphics.DrawLines(this.vo.pBGMWav, xPtsL);
                e1.Graphics.DrawLines(this.vo.pBGMWav, xPtsR);
            }
        }

        /// <summary>
        /// Draw a note in a buffer.
        /// </summary>
        /// <param name="sNote">Note to be drawn.</param>
        /// <param name="e">Buffer.</param>
        /// <param name="xHS">HS.Value.</param>
        /// <param name="xVS">VS.Value.</param>
        /// <param name="xHeight">Display height of the panel. (not ClipRectangle.Height)</param>

        private void DrawNote(iBMSC.Editor.Note sNote, BufferedGraphics e, long xHS, long xVS, int xHeight) // , Optional ByVal CheckError As Boolean = True) ', Optional ByVal ConnectToIndex As Long = 0)
        {
            if (!this.nEnabled(sNote.ColumnIndex))
                return;
            float xAlpha = 1.0f;
            if (sNote.Hidden)
                xAlpha = this.vo.kOpacity;

            string xLabel = iBMSC.Editor.Functions.C10to36(sNote.Value / 10000L);
            if (this.ShowFileName)
            {
                if (this.IsColumnSound(sNote.ColumnIndex))
                {
                    if (!string.IsNullOrEmpty(this.hWAV[iBMSC.Editor.Functions.C36to10(xLabel)]))
                        xLabel = Path.GetFileNameWithoutExtension(this.hWAV[iBMSC.Editor.Functions.C36to10(xLabel)]);
                }
                else if (!string.IsNullOrEmpty(this.hBMP[iBMSC.Editor.Functions.C36to10(xLabel)]))
                    xLabel = Path.GetFileNameWithoutExtension(this.hBMP[iBMSC.Editor.Functions.C36to10(xLabel)]);
            }

            Pen xPen;
            System.Drawing.Drawing2D.LinearGradientBrush xBrush;
            SolidBrush xBrush2;

            Color bright;
            Color dark;
            var p1 = new Point(this.HorizontalPositiontoDisplay(this.nLeft(sNote.ColumnIndex), xHS), this.NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) - this.vo.kHeight - 10);
            var p2 = new Point(this.HorizontalPositiontoDisplay(this.nLeft(sNote.ColumnIndex) + this.GetColumnWidth(sNote.ColumnIndex), xHS), this.NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) + 10);

            if (!sNote.LongNote)
            {
                xPen = new Pen(this.GetColumn(sNote.ColumnIndex).getBright(xAlpha));

                bright = this.GetColumn(sNote.ColumnIndex).getBright(xAlpha);
                dark = this.GetColumn(sNote.ColumnIndex).getDark(xAlpha);

                if (sNote.Landmine)
                {
                    bright = Color.Red;
                    dark = Color.Red;
                }

                xBrush2 = new SolidBrush(this.GetColumn(sNote.ColumnIndex).cText);
            }
            else
            {
                bright = this.GetColumn(sNote.ColumnIndex).getLongBright(xAlpha);
                dark = this.GetColumn(sNote.ColumnIndex).getLongDark(xAlpha);

                xBrush2 = new SolidBrush(this.GetColumn(sNote.ColumnIndex).cLText);
            }

            xPen = new Pen(bright);
            xBrush = new System.Drawing.Drawing2D.LinearGradientBrush(p1, p2, bright, dark);

            // Fill
            e.Graphics.FillRectangle(xBrush, (float)(this.HorizontalPositiontoDisplay(this.nLeft(sNote.ColumnIndex), xHS) + 2), (float)(this.NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) - this.vo.kHeight + 1), (float)this.GetColumnWidth(sNote.ColumnIndex) * this.gxWidth - 3f, (float)(this.vo.kHeight - 1));
            // Outline
            e.Graphics.DrawRectangle(xPen, (float)(this.HorizontalPositiontoDisplay(this.nLeft(sNote.ColumnIndex), xHS) + 1), (float)(this.NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) - this.vo.kHeight), (float)this.GetColumnWidth(sNote.ColumnIndex) * this.gxWidth - 2f, (float)this.vo.kHeight);

            // Label
            e.Graphics.DrawString(Conversions.ToString(Interaction.IIf(this.IsColumnNumeric(sNote.ColumnIndex), (object)((double)sNote.Value / 10000d), xLabel)), this.vo.kFont, xBrush2, (float)(this.HorizontalPositiontoDisplay(this.nLeft(sNote.ColumnIndex), xHS) + this.vo.kLabelHShift), (float)(this.NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) - this.vo.kHeight + this.vo.kLabelVShift));

            if (sNote.ColumnIndex < MainWindow.niB)
            {
                if (sNote.LNPair != 0)
                {
                    DrawPairedLNBody(sNote, e, xHS, xVS, xHeight, xAlpha);
                }
            }


            // e.Graphics.DrawString(sNote.TimeOffset.ToString("0.##"), New Font("Verdana", 9), Brushes.Cyan, _
            // New Point(HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex + 1), xHS), VerticalPositiontoDisplay(sNote.VPosition, xVS, xHeight) - vo.kHeight - 2))

            // If ErrorCheck AndAlso (sNote.LongNote Xor sNote.PairWithI <> 0) Then e.Graphics.DrawImage(My.Resources.ImageError, _
            if (this.ErrorCheck && sNote.HasError)
                e.Graphics.DrawImage(iBMSC.My.Resources.Resources.ImageError, this.HorizontalPositiontoDisplay((int)Math.Round((double)this.nLeft(sNote.ColumnIndex) + (double)this.GetColumnWidth(sNote.ColumnIndex) / 2d), xHS) - 12, (int)Math.Round((double)this.NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) - (double)this.vo.kHeight / 2d - 12d), 24, 24);

            if (sNote.Selected)
                e.Graphics.DrawRectangle(this.vo.kSelected, (float)this.HorizontalPositiontoDisplay(this.nLeft(sNote.ColumnIndex), xHS), (float)(this.NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) - this.vo.kHeight - 1), (float)this.GetColumnWidth(sNote.ColumnIndex) * this.gxWidth, (float)(this.vo.kHeight + 2));

        }

        private void DrawPairedLNBody(iBMSC.Editor.Note sNote, BufferedGraphics e, long xHS, long xVS, int xHeight, float xAlpha)
        {
            var xPen2 = new Pen(this.GetColumn(sNote.ColumnIndex).getLongBright(xAlpha));
            var xBrush3 = new System.Drawing.Drawing2D.LinearGradientBrush(new Point(this.HorizontalPositiontoDisplay((int)Math.Round((double)this.nLeft(sNote.ColumnIndex) - 0.5d * (double)this.GetColumnWidth(sNote.ColumnIndex)), xHS), this.NoteRowToPanelHeight(this.Notes[sNote.LNPair].VPosition, xVS, xHeight)), new Point(this.HorizontalPositiontoDisplay((int)Math.Round((double)this.nLeft(sNote.ColumnIndex) + 1.5d * (double)this.GetColumnWidth(sNote.ColumnIndex)), xHS), this.NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) + this.vo.kHeight), this.GetColumn(sNote.ColumnIndex).getLongBright(xAlpha), this.GetColumn(sNote.ColumnIndex).getLongDark(xAlpha));
            e.Graphics.FillRectangle(xBrush3, (float)(this.HorizontalPositiontoDisplay(this.nLeft(this.Notes[sNote.LNPair].ColumnIndex), xHS) + 3), (float)(this.NoteRowToPanelHeight(this.Notes[sNote.LNPair].VPosition, xVS, xHeight) + 1), (float)this.GetColumnWidth(this.Notes[sNote.LNPair].ColumnIndex) * this.gxWidth - 5f, (float)(this.NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) - this.NoteRowToPanelHeight(this.Notes[sNote.LNPair].VPosition, xVS, xHeight) - this.vo.kHeight - 1));
            e.Graphics.DrawRectangle(xPen2, (float)(this.HorizontalPositiontoDisplay(this.nLeft(this.Notes[sNote.LNPair].ColumnIndex), xHS) + 2), (float)this.NoteRowToPanelHeight(this.Notes[sNote.LNPair].VPosition, xVS, xHeight), (float)this.GetColumnWidth(this.Notes[sNote.LNPair].ColumnIndex) * this.gxWidth - 4f, (float)(this.NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) - this.NoteRowToPanelHeight(this.Notes[sNote.LNPair].VPosition, xVS, xHeight) - this.vo.kHeight));
        }

        /// <summary>
        /// Draw a note in a buffer under NT mode.
        /// </summary>
        /// <param name="sNote">Note to be drawn.</param>
        /// <param name="e">Buffer.</param>
        /// <param name="xHS">HS.Value.</param>
        /// <param name="xVS">VS.Value.</param>
        /// <param name="xHeight">Display height of the panel. (not ClipRectangle.Height)</param>

        private void DrawNoteNT(iBMSC.Editor.Note sNote, BufferedGraphics e, long xHS, long xVS, int xHeight) // , Optional ByVal CheckError As Boolean = True)
        {
            if (!this.nEnabled(sNote.ColumnIndex))
                return;
            float xAlpha = 1.0f;
            if (sNote.Hidden)
                xAlpha = this.vo.kOpacity;

            string xLabel = iBMSC.Editor.Functions.C10to36(sNote.Value / 10000L);
            if (this.ShowFileName)
            {
                if (this.IsColumnSound(sNote.ColumnIndex))
                {
                    if (!string.IsNullOrEmpty(this.hWAV[iBMSC.Editor.Functions.C36to10(xLabel)]))
                        xLabel = Path.GetFileNameWithoutExtension(this.hWAV[iBMSC.Editor.Functions.C36to10(xLabel)]);
                }
                else if (!string.IsNullOrEmpty(this.hBMP[iBMSC.Editor.Functions.C36to10(xLabel)]))
                    xLabel = Path.GetFileNameWithoutExtension(this.hBMP[iBMSC.Editor.Functions.C36to10(xLabel)]);
            }

            Pen xPen1;
            System.Drawing.Drawing2D.LinearGradientBrush xBrush;
            SolidBrush xBrush2;

            Point p1;
            Point p2;
            Color bright;
            Color dark;

            if (sNote.Length == 0d)
            {
                p1 = new Point(this.HorizontalPositiontoDisplay(this.nLeft(sNote.ColumnIndex), xHS), this.NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) - this.vo.kHeight - 10);

                p2 = new Point(this.HorizontalPositiontoDisplay(this.nLeft(sNote.ColumnIndex) + this.GetColumnWidth(sNote.ColumnIndex), xHS), this.NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) + 10);

                bright = this.GetColumn(sNote.ColumnIndex).getBright(xAlpha);
                dark = this.GetColumn(sNote.ColumnIndex).getDark(xAlpha);

                if (sNote.Landmine)
                {
                    bright = Color.Red;
                    dark = Color.Red;
                }

                xBrush2 = new SolidBrush(this.GetColumn(sNote.ColumnIndex).cText);
            }
            else
            {
                p1 = new Point(this.HorizontalPositiontoDisplay((int)Math.Round((double)this.nLeft(sNote.ColumnIndex) - 0.5d * (double)this.GetColumnWidth(sNote.ColumnIndex)), xHS), this.NoteRowToPanelHeight(sNote.VPosition + sNote.Length, xVS, xHeight) - this.vo.kHeight);
                p2 = new Point(this.HorizontalPositiontoDisplay((int)Math.Round((double)this.nLeft(sNote.ColumnIndex) + 1.5d * (double)this.GetColumnWidth(sNote.ColumnIndex)), xHS), this.NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight));

                bright = this.GetColumn(sNote.ColumnIndex).getLongBright(xAlpha);
                dark = this.GetColumn(sNote.ColumnIndex).getLongDark(xAlpha);

                xBrush2 = new SolidBrush(this.GetColumn(sNote.ColumnIndex).cLText);
            }

            xPen1 = new Pen(bright);
            xBrush = new System.Drawing.Drawing2D.LinearGradientBrush(p1, p2, bright, dark);

            // Note gradient
            e.Graphics.FillRectangle(xBrush, (float)(this.HorizontalPositiontoDisplay(this.nLeft(sNote.ColumnIndex), xHS) + 1), (float)(this.NoteRowToPanelHeight(sNote.VPosition + sNote.Length, xVS, xHeight) - this.vo.kHeight + 1), (float)this.GetColumnWidth(sNote.ColumnIndex) * this.gxWidth - 1f, (float)((int)Math.Round(sNote.Length * (double)this.gxHeight) + this.vo.kHeight - 1));

            // Outline
            e.Graphics.DrawRectangle(xPen1, (float)(this.HorizontalPositiontoDisplay(this.nLeft(sNote.ColumnIndex), xHS) + 1), (float)(this.NoteRowToPanelHeight(sNote.VPosition + sNote.Length, xVS, xHeight) - this.vo.kHeight), (float)this.GetColumnWidth(sNote.ColumnIndex) * this.gxWidth - 3f, (float)((int)Math.Round(sNote.Length * (double)this.gxHeight) + this.vo.kHeight));

            // Note B36
            e.Graphics.DrawString(Conversions.ToString(Interaction.IIf(this.IsColumnNumeric(sNote.ColumnIndex), (object)((double)sNote.Value / 10000d), xLabel)), this.vo.kFont, xBrush2, (float)(this.HorizontalPositiontoDisplay(this.nLeft(sNote.ColumnIndex), xHS) + this.vo.kLabelHShiftL - 2), (float)(this.NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) - this.vo.kHeight + this.vo.kLabelVShift));

            // Draw paired body
            if (sNote.ColumnIndex < MainWindow.niB)
            {
                if (sNote.Length == 0d & sNote.LNPair != 0)
                {
                    DrawPairedLNBody(sNote, e, xHS, xVS, xHeight, xAlpha);
                }
            }


            // Select Box
            if (sNote.Selected)
            {
                e.Graphics.DrawRectangle(this.vo.kSelected, (float)this.HorizontalPositiontoDisplay(this.nLeft(sNote.ColumnIndex), xHS), (float)(this.NoteRowToPanelHeight(sNote.VPosition + sNote.Length, xVS, xHeight) - this.vo.kHeight - 1), (float)this.GetColumnWidth(sNote.ColumnIndex) * this.gxWidth, (float)((int)Math.Round(sNote.Length * (double)this.gxHeight) + this.vo.kHeight + 2));
            }

            // Errors
            if (this.ErrorCheck && sNote.HasError)
            {
                e.Graphics.DrawImage(iBMSC.My.Resources.Resources.ImageError, this.HorizontalPositiontoDisplay((int)Math.Round((double)this.nLeft(sNote.ColumnIndex) + (double)this.GetColumnWidth(sNote.ColumnIndex) / 2d), xHS) - 12, (int)Math.Round((double)this.NoteRowToPanelHeight(sNote.VPosition, xVS, xHeight) - (double)this.vo.kHeight / 2d - 12d), 24, 24);
            }

            // e.Graphics.DrawString(sNote.TimeOffset.ToString("0.##"), New Font("Verdana", 9), Brushes.Cyan, _
            // New Point(HorizontalPositiontoDisplay(nLeft(sNote.ColumnIndex + 1), xHS), VerticalPositiontoDisplay(sNote.VPosition, xVS, xHeight) - vo.kHeight - 2))

        }
    }
}