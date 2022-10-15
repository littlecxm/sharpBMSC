using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace iBMSC
{

    public partial class MainWindow
    {

        private void PMainInPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey | e.KeyCode == Keys.ControlKey)
            {
                this.RefreshPanelAll();
                this.POStatusRefresh();
                return;
            }

            if ((int)e.KeyCode == 18)
                return;

            int iI = Conversions.ToInteger(sender.Tag);
            int xI1;
            int xTargetColumn = -1;
            iBMSC.UndoRedo.LinkedURCmd xUndo = null;
            iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
            var xBaseRedo = xRedo;
            this.SelectedNotes = new iBMSC.Editor.Note[0];

            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        double xVPosition = 192d / (double)this.gDivide;
                        if (iBMSC.My.MyProject.Computer.Keyboard.CtrlKeyDown)
                            xVPosition = 1d;

                        // Ks cannot be beyond the upper boundary
                        double muVPosition = this.GetMaxVPosition() - 1d;
                        var loopTo = Information.UBound(this.Notes);
                        for (xI1 = 1; xI1 <= loopTo; xI1++)
                        {
                            if (this.Notes[xI1].Selected)
                            {
                                // K(xI1).VPosition = Math.Floor(K(xI1).VPosition / (192 / gDivide)) * 192 / gDivide
                                muVPosition = Conversions.ToDouble(Interaction.IIf(Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(Operators.AddObject(Operators.AddObject(this.Notes[xI1].VPosition, Interaction.IIf(this.NTInput, (object)this.Notes[xI1].Length, (object)0)), xVPosition), muVPosition, false)), Operators.AddObject(Operators.AddObject(this.Notes[xI1].VPosition, Interaction.IIf(this.NTInput, (object)this.Notes[xI1].Length, (object)0)), xVPosition), muVPosition));
                            }
                        }
                        muVPosition -= 191999d;

                        // xRedo = sCmdKMs(0, xVPosition - muVPosition, True)
                        double xVPos;
                        var loopTo1 = Information.UBound(this.Notes);
                        for (xI1 = 1; xI1 <= loopTo1; xI1++)
                        {
                            if (!this.Notes[xI1].Selected)
                                continue;

                            xVPos = this.Notes[xI1].VPosition + xVPosition - muVPosition;
                            this.RedoMoveNote(this.Notes[xI1], this.Notes[xI1].ColumnIndex, xVPos, ref xUndo, ref xRedo);
                            this.Notes[xI1].VPosition = xVPos;
                        }
                        // xUndo = sCmdKMs(0, -xVPosition + muVPosition, True)

                        if (xVPosition - muVPosition != 0d)
                            this.AddUndo(xUndo, xBaseRedo.Next);
                        this.SortByVPositionInsertion();
                        this.UpdatePairing();
                        this.CalculateTotalPlayableNotes();
                        this.CalculateGreatestVPosition();
                        this.RefreshPanelAll();
                        break;
                    }

                case Keys.Down:
                    {
                        double xVPosition = (double)-192 / (double)this.gDivide;
                        if (iBMSC.My.MyProject.Computer.Keyboard.CtrlKeyDown)
                            xVPosition = -1;

                        // Ks cannot be beyond the lower boundary
                        double mVPosition = 0d;
                        var loopTo2 = Information.UBound(this.Notes);
                        for (xI1 = 1; xI1 <= loopTo2; xI1++)
                        {
                            if (this.Notes[xI1].Selected)
                            {
                                // K(xI1).VPosition = Math.Ceiling(K(xI1).VPosition / (192 / gDivide)) * 192 / gDivide
                                mVPosition = Conversions.ToDouble(Interaction.IIf(this.Notes[xI1].VPosition + xVPosition < mVPosition, (object)(this.Notes[xI1].VPosition + xVPosition), mVPosition));
                            }
                        }

                        // xRedo = sCmdKMs(0, xVPosition - mVPosition, True)
                        double xVPos;
                        var loopTo3 = Information.UBound(this.Notes);
                        for (xI1 = 1; xI1 <= loopTo3; xI1++)
                        {
                            if (!this.Notes[xI1].Selected)
                                continue;

                            xVPos = this.Notes[xI1].VPosition + xVPosition - mVPosition;
                            this.RedoMoveNote(this.Notes[xI1], this.Notes[xI1].ColumnIndex, xVPos, ref xUndo, ref xRedo);
                            this.Notes[xI1].VPosition = xVPos;
                        }
                        // xUndo = sCmdKMs(0, -xVPosition + mVPosition, True)

                        if (xVPosition - mVPosition != 0d)
                            this.AddUndo(xUndo, xBaseRedo.Next);
                        this.SortByVPositionInsertion();
                        this.UpdatePairing();
                        this.CalculateTotalPlayableNotes();
                        this.CalculateGreatestVPosition();
                        this.RefreshPanelAll();
                        break;
                    }

                case Keys.Left:
                    {
                        // For xI1 = 1 To UBound(K)
                        // If K(xI1).Selected Then K(xI1).ColumnIndex = RealColumnToEnabled(K(xI1).ColumnIndex) - 1
                        // Next

                        // Ks cannot be beyond the left boundary
                        int mLeft = 0;
                        var loopTo4 = Information.UBound(this.Notes);
                        for (xI1 = 1; xI1 <= loopTo4; xI1++)
                        {
                            if (this.Notes[xI1].Selected)
                                mLeft = Conversions.ToInteger(Interaction.IIf(this.ColumnArrayIndexToEnabledColumnIndex(this.Notes[xI1].ColumnIndex) - 1 < mLeft, (object)(this.ColumnArrayIndexToEnabledColumnIndex(this.Notes[xI1].ColumnIndex) - 1), mLeft));
                        }
                        // xRedo = sCmdKMs(-1 - mLeft, 0, True)
                        int xCol;
                        var loopTo5 = Information.UBound(this.Notes);
                        for (xI1 = 1; xI1 <= loopTo5; xI1++)
                        {
                            if (!this.Notes[xI1].Selected)
                                continue;

                            xCol = this.EnabledColumnIndexToColumnArrayIndex(this.ColumnArrayIndexToEnabledColumnIndex(this.Notes[xI1].ColumnIndex) - 1 - mLeft);
                            this.RedoMoveNote(this.Notes[xI1], xCol, this.Notes[xI1].VPosition, ref xUndo, ref xRedo);
                            this.Notes[xI1].ColumnIndex = xCol;
                        }
                        // xUndo = sCmdKMs(1 + mLeft, 0, True)

                        if (-1 - mLeft != 0)
                            this.AddUndo(xUndo, xBaseRedo.Next);
                        this.UpdatePairing();
                        this.CalculateTotalPlayableNotes();
                        this.RefreshPanelAll();
                        break;
                    }

                case Keys.Right:
                    {
                        // xRedo = sCmdKMs(1, 0, True)
                        int xCol;
                        var loopTo6 = Information.UBound(this.Notes);
                        for (xI1 = 1; xI1 <= loopTo6; xI1++)
                        {
                            if (!this.Notes[xI1].Selected)
                                continue;

                            xCol = this.EnabledColumnIndexToColumnArrayIndex(this.ColumnArrayIndexToEnabledColumnIndex(this.Notes[xI1].ColumnIndex) + 1);
                            this.RedoMoveNote(this.Notes[xI1], xCol, this.Notes[xI1].VPosition, ref xUndo, ref xRedo);
                            this.Notes[xI1].ColumnIndex = xCol;
                        }
                        // xUndo = sCmdKMs(-1, 0, True)

                        this.AddUndo(xUndo, xBaseRedo.Next);
                        this.UpdatePairing();
                        this.CalculateTotalPlayableNotes();
                        this.RefreshPanelAll();
                        break;
                    }

                case Keys.Delete:
                    {
                        this.mnDelete_Click(this.mnDelete, new EventArgs());
                        break;
                    }

                case Keys.Home:
                    {
                        if (this.PanelFocus == 0)
                            this.LeftPanelScroll.Value = 0;
                        if (this.PanelFocus == 1)
                            this.MainPanelScroll.Value = 0;
                        if (this.PanelFocus == 2)
                            this.RightPanelScroll.Value = 0;
                        break;
                    }

                case Keys.End:
                    {
                        if (this.PanelFocus == 0)
                            this.LeftPanelScroll.Value = this.LeftPanelScroll.Minimum;
                        if (this.PanelFocus == 1)
                            this.MainPanelScroll.Value = this.MainPanelScroll.Minimum;
                        if (this.PanelFocus == 2)
                            this.RightPanelScroll.Value = this.RightPanelScroll.Minimum;
                        break;
                    }

                case Keys.PageUp:
                    {
                        if (this.PanelFocus == 0)
                            this.LeftPanelScroll.Value = Conversions.ToInteger(Interaction.IIf(this.LeftPanelScroll.Value - this.gPgUpDn > this.LeftPanelScroll.Minimum, (object)(this.LeftPanelScroll.Value - this.gPgUpDn), (object)this.LeftPanelScroll.Minimum));
                        if (this.PanelFocus == 1)
                            this.MainPanelScroll.Value = Conversions.ToInteger(Interaction.IIf(this.MainPanelScroll.Value - this.gPgUpDn > this.MainPanelScroll.Minimum, (object)(this.MainPanelScroll.Value - this.gPgUpDn), (object)this.MainPanelScroll.Minimum));
                        if (this.PanelFocus == 2)
                            this.RightPanelScroll.Value = Conversions.ToInteger(Interaction.IIf(this.RightPanelScroll.Value - this.gPgUpDn > this.RightPanelScroll.Minimum, (object)(this.RightPanelScroll.Value - this.gPgUpDn), (object)this.RightPanelScroll.Minimum));
                        break;
                    }

                case Keys.PageDown:
                    {
                        if (this.PanelFocus == 0)
                            this.LeftPanelScroll.Value = Conversions.ToInteger(Interaction.IIf(this.LeftPanelScroll.Value + this.gPgUpDn < 0, (object)(this.LeftPanelScroll.Value + this.gPgUpDn), 0));
                        if (this.PanelFocus == 1)
                            this.MainPanelScroll.Value = Conversions.ToInteger(Interaction.IIf(this.MainPanelScroll.Value + this.gPgUpDn < 0, (object)(this.MainPanelScroll.Value + this.gPgUpDn), 0));
                        if (this.PanelFocus == 2)
                            this.RightPanelScroll.Value = Conversions.ToInteger(Interaction.IIf(this.RightPanelScroll.Value + this.gPgUpDn < 0, (object)(this.RightPanelScroll.Value + this.gPgUpDn), 0));
                        break;
                    }

                case Keys.Oemcomma:
                    {
                        if ((decimal)(this.gDivide * 2) <= this.CGDivide.Maximum)
                            this.CGDivide.Value = (decimal)(this.gDivide * 2);
                        break;
                    }

                case Keys.OemPeriod:
                    {
                        if ((decimal)(this.gDivide / 2) >= this.CGDivide.Minimum)
                            this.CGDivide.Value = (decimal)(this.gDivide / 2);
                        break;
                    }

                case Keys.OemQuestion:
                    {
                        // Dim xTempSwap As Integer = gSlash
                        // gSlash = CGDivide.Value
                        // CGDivide.Value = xTempSwap
                        this.CGDivide.Value = (decimal)this.gSlash;
                        break;
                    }

                case Keys.Oemplus:
                    {
                        {
                            var withBlock = this.CGHeight;
                            withBlock.Value = Conversions.ToDecimal(withBlock.Value + Interaction.IIf(withBlock.Value > withBlock.Maximum - withBlock.Increment, (object)(withBlock.Maximum - withBlock.Value), (object)withBlock.Increment));
                        }

                        break;
                    }

                case Keys.OemMinus:
                    {
                        {
                            var withBlock1 = this.CGHeight;
                            withBlock1.Value = Conversions.ToDecimal(withBlock1.Value - Interaction.IIf(withBlock1.Value < withBlock1.Minimum + withBlock1.Increment, (object)(withBlock1.Value - withBlock1.Minimum), (object)withBlock1.Increment));
                        }

                        break;
                    }

                case Keys.Add:
                    {
                        IncreaseCurrentWav();
                        break;
                    }
                case Keys.Subtract:
                    {
                        DecreaseCurrentWav();
                        break;
                    }

                case Keys.G:
                    {
                        // az: don't trigger when we use Go To Measure
                        if (!iBMSC.My.MyProject.Computer.Keyboard.CtrlKeyDown)
                            this.CGSnap.Checked = !this.gSnap;
                        break;
                    }

                case Keys.L:
                    {
                        if (!iBMSC.My.MyProject.Computer.Keyboard.CtrlKeyDown)
                            this.POBLong_Click(null, null);
                        break;
                    }

                case Keys.S:
                    {
                        if (!iBMSC.My.MyProject.Computer.Keyboard.CtrlKeyDown)
                            this.POBNormal_Click(null, null);
                        break;
                    }

                case Keys.D:
                    {
                        this.CGDisableVertical.Checked = !this.CGDisableVertical.Checked;
                        break;
                    }

                case Keys.NumPad0:
                case Keys.D0:
                    {
                        MoveToBGM(xUndo, xRedo);
                        break;
                    }

                case Keys.Oem1:
                case Keys.NumPad1:
                case Keys.D1:
                    {
                        this.MoveToColumn(MainWindow.niA1, xUndo, xRedo);
                        break;
                    }
                case var @case when @case == Keys.Oem2:
                case Keys.NumPad2:
                case Keys.D2:
                    {
                        this.MoveToColumn(MainWindow.niA2, xUndo, xRedo);
                        break;
                    }
                case Keys.Oem3:
                case Keys.NumPad3:
                case Keys.D3:
                    {
                        this.MoveToColumn(MainWindow.niA3, xUndo, xRedo);
                        break;
                    }
                case Keys.Oem4:
                case Keys.NumPad4:
                case Keys.D4:
                    {
                        this.MoveToColumn(MainWindow.niA4, xUndo, xRedo);
                        break;
                    }
                case Keys.Oem5:
                case Keys.NumPad5:
                case Keys.D5:
                    {
                        this.MoveToColumn(MainWindow.niA5, xUndo, xRedo);
                        break;
                    }
                case Keys.Oem6:
                case Keys.NumPad6:
                case Keys.D6:
                    {
                        this.MoveToColumn(MainWindow.niA6, xUndo, xRedo);
                        break;
                    }
                case Keys.Oem7:
                case Keys.NumPad7:
                case Keys.D7:
                    {
                        this.MoveToColumn(MainWindow.niA7, xUndo, xRedo);
                        break;
                    }
                case Keys.Oem8:
                case Keys.NumPad8:
                case Keys.D8:
                    {
                        this.MoveToColumn(MainWindow.niA8, xUndo, xRedo);
                        break;
                    }

            }

            if (iBMSC.My.MyProject.Computer.Keyboard.CtrlKeyDown & !iBMSC.My.MyProject.Computer.Keyboard.AltKeyDown & !iBMSC.My.MyProject.Computer.Keyboard.ShiftKeyDown)
            {
                switch (e.KeyCode)
                {
                    case Keys.Z:
                        {
                            this.TBUndo_Click(this.TBUndo, new EventArgs());
                            break;
                        }
                    case Keys.Y:
                        {
                            this.TBRedo_Click(this.TBRedo, new EventArgs());
                            break;
                        }
                    case Keys.X:
                        {
                            this.TBCut_Click(this.TBCut, new EventArgs());
                            break;
                        }
                    case Keys.C:
                        {
                            this.TBCopy_Click(this.TBCopy, new EventArgs());
                            break;
                        }
                    case Keys.V:
                        {
                            this.TBPaste_Click(this.TBPaste, new EventArgs());
                            break;
                        }
                    case Keys.A:
                        {
                            this.mnSelectAll_Click(this.mnSelectAll, new EventArgs());
                            break;
                        }
                    case Keys.F:
                        {
                            this.TBFind_Click(this.TBFind, new EventArgs());
                            break;
                        }
                    case Keys.T:
                        {
                            this.TBStatistics_Click(this.TBStatistics, new EventArgs());
                            break;
                        }
                }
            }

            if (iBMSC.PanelKeyStates.ModifierMultiselectActive())
            {
                if (e.KeyCode == Keys.A & this.KMouseOver != -1)
                {
                    SelectAllWithHoveredNoteLabel();
                }
            }

            PMainInMouseMove((Panel)sender);
            this.POStatusRefresh();
        }

        private void SelectAllWithHoveredNoteLabel()
        {
            for (int xI1 = 0, loopTo = Information.UBound(this.Notes); xI1 <= loopTo; xI1++)
                this.Notes[xI1].Selected = Conversions.ToBoolean(Interaction.IIf(this.IsLabelMatch(this.Notes[xI1], this.KMouseOver), true, (object)this.Notes[xI1].Selected));
        }

        private bool IsLabelMatch(iBMSC.Editor.Note note, int index)
        {
            if (this.TBShowFileName.Checked)
            {
                double wavidx = (double)this.Notes[index].Value / 10000d;
                string wav = this.hWAV[(int)Math.Round(wavidx)];
                if ((this.hWAV[(int)Math.Round((double)note.Value / 10000d)] ?? "") == (wav ?? ""))
                {
                    return true;
                }
            }
            else if (note.Value == this.Notes[index].Value)
            {
                return true;
            }

            return false;
        }

        private void DecreaseCurrentWav()
        {
            if (this.LWAV.SelectedIndex == -1)
            {
                this.LWAV.SelectedIndex = 0;
            }
            else
            {
                int newIndex = this.LWAV.SelectedIndex - 1;
                if (newIndex < 0)
                    newIndex = 0;
                this.LWAV.SelectedIndices.Clear();
                this.LWAV.SelectedIndex = newIndex;
            }
        }

        private void IncreaseCurrentWav()
        {
            if (this.LWAV.SelectedIndex == -1)
            {
                this.LWAV.SelectedIndex = 0;
            }
            else
            {
                int newIndex = this.LWAV.SelectedIndex + 1;
                if (newIndex > this.LWAV.Items.Count - 1)
                    newIndex = this.LWAV.Items.Count - 1;
                this.LWAV.SelectedIndices.Clear();
                this.LWAV.SelectedIndex = newIndex;
                this.ValidateWavListView();
            }
        }

        private void MoveToBGM(iBMSC.UndoRedo.LinkedURCmd xUndo, iBMSC.UndoRedo.LinkedURCmd xRedo)
        {
            var xBaseRedo = xRedo;

            for (int xI2 = 1, loopTo = Information.UBound(this.Notes); xI2 <= loopTo; xI2++)
            {
                if (!this.Notes[xI2].Selected)
                    continue;

                {
                    ref var withBlock = ref this.Notes[xI2];
                    int currentBGMColumn = MainWindow.niB;

                    // TODO: optimize the for loops below
                    if (this.NTInput)
                    {
                        for (int xI0 = 1, loopTo1 = Information.UBound(this.Notes); xI0 <= loopTo1; xI0++)
                        {
                            bool IntersectA = this.Notes[xI0].VPosition <= this.Notes[xI2].VPosition + this.Notes[xI2].Length;
                            bool IntersectB = this.Notes[xI0].VPosition + this.Notes[xI0].Length >= this.Notes[xI2].VPosition;
                            if ((this.Notes[xI0].ColumnIndex == currentBGMColumn && IntersectA) & IntersectB)
                            {
                                currentBGMColumn += 1;
                                xI0 = 1;
                            }
                        }
                    }
                    else
                    {
                        for (int xI0 = 1, loopTo2 = Information.UBound(this.Notes); xI0 <= loopTo2; xI0++)
                        {
                            if (this.Notes[xI0].ColumnIndex == currentBGMColumn && this.Notes[xI0].VPosition == this.Notes[xI2].VPosition)
                            {
                                currentBGMColumn += 1;
                                xI0 = 1;
                            }
                        }
                    }

                    this.RedoMoveNote(this.Notes[xI2], currentBGMColumn, withBlock.VPosition, ref xUndo, ref xRedo);
                    withBlock.ColumnIndex = currentBGMColumn;
                }
            }
            this.AddUndo(xUndo, xBaseRedo.Next);
            this.UpdatePairing();
            this.CalculateTotalPlayableNotes();
            this.RefreshPanelAll();
        }

        private void MoveToColumn(int xTargetColumn, iBMSC.UndoRedo.LinkedURCmd xUndo, iBMSC.UndoRedo.LinkedURCmd xRedo)
        {
            var xBaseRedo = xRedo;
            if (xTargetColumn == -1)
                return;
            if (!this.nEnabled(xTargetColumn))
                return;
            bool bMoveAndDeselectFirstNote = iBMSC.My.MyProject.Computer.Keyboard.ShiftKeyDown;

            for (int xI2 = 1, loopTo = Information.UBound(this.Notes); xI2 <= loopTo; xI2++)
            {
                if (!this.Notes[xI2].Selected)
                    continue;

                this.RedoMoveNote(this.Notes[xI2], xTargetColumn, this.Notes[xI2].VPosition, ref xUndo, ref xRedo);
                this.Notes[xI2].ColumnIndex = xTargetColumn;

                if (bMoveAndDeselectFirstNote)
                {
                    this.Notes[xI2].Selected = false;
                    PanelPreviewNoteIndex(xI2);

                    // az: Add selected notes to undo
                    // to preserve selection status
                    // this works because the note find
                    // does not account for selection status
                    // when checking equality! (equalsBMSE, equalsNT)
                    for (int xI3 = 1, loopTo1 = Information.UBound(this.Notes); xI3 <= loopTo1; xI3++)
                    {
                        if (xI3 == xI2)
                            continue;
                        if (this.Notes[xI3].Selected)
                        {
                            this.RedoMoveNote(this.Notes[xI3], this.Notes[xI3].ColumnIndex, this.Notes[xI3].VPosition, ref xUndo, ref xRedo);
                        }
                    }

                    break;
                }
            }
            this.AddUndo(xUndo, xBaseRedo.Next);
            this.UpdatePairing();
            this.CalculateTotalPlayableNotes();
            this.RefreshPanelAll();
        }

        private void PMainInResize(object sender, EventArgs e)
        {
            if (!this.Created)
                return;

            int iI = Conversions.ToInteger(sender.Tag);
            this.PanelWidth[0] = (float)this.PMainL.Width;
            this.PanelWidth[1] = (float)this.PMain.Width;
            this.PanelWidth[2] = (float)this.PMainR.Width;

            switch (iI)
            {
                case 0:
                    {
                        this.LeftPanelScroll.LargeChange = Conversions.ToInteger(Operators.MultiplyObject(sender.Height, 0.9d));
                        this.LeftPanelScroll.Maximum = this.LeftPanelScroll.LargeChange - 1;
                        this.HSL.LargeChange = Conversions.ToInteger(Operators.DivideObject(sender.Width, this.gxWidth));
                        if (this.HSL.Value > this.HSL.Maximum - this.HSL.LargeChange + 1)
                            this.HSL.Value = this.HSL.Maximum - this.HSL.LargeChange + 1;
                        break;
                    }
                case 1:
                    {
                        this.MainPanelScroll.LargeChange = Conversions.ToInteger(Operators.MultiplyObject(sender.Height, 0.9d));
                        this.MainPanelScroll.Maximum = this.MainPanelScroll.LargeChange - 1;
                        this.HS.LargeChange = Conversions.ToInteger(Operators.DivideObject(sender.Width, this.gxWidth));
                        if (this.HS.Value > this.HS.Maximum - this.HS.LargeChange + 1)
                            this.HS.Value = this.HS.Maximum - this.HS.LargeChange + 1;
                        break;
                    }
                case 2:
                    {
                        this.RightPanelScroll.LargeChange = Conversions.ToInteger(Operators.MultiplyObject(sender.Height, 0.9d));
                        this.RightPanelScroll.Maximum = this.RightPanelScroll.LargeChange - 1;
                        this.HSR.LargeChange = Conversions.ToInteger(Operators.DivideObject(sender.Width, this.gxWidth));
                        if (this.HSR.Value > this.HSR.Maximum - this.HSR.LargeChange + 1)
                            this.HSR.Value = this.HSR.Maximum - this.HSR.LargeChange + 1;
                        break;
                    }
            }
            this.RefreshPanel(iI, (Rectangle)sender.DisplayRectangle);
        }

        private void PMainInLostFocus(object sender, EventArgs e)
        {
            this.RefreshPanelAll();
        }

        private void PMainInMouseDown(object sender, MouseEventArgs e)
        {
            this.tempFirstMouseDown = Conversions.ToBoolean(Operators.AndObject(this.FirstClickDisabled, !sender.Focused));

            this.PanelFocus = Conversions.ToInteger(sender.Tag);
            sender.Focus();
            this.LastMouseDownLocation = new Point(-1, -1);
            this.VSValue = this.PanelVScroll[this.PanelFocus];

            if (this.NTInput)
            {
                this.bAdjustUpper = false;
                this.bAdjustLength = false;
            }
            this.ctrlPressed = false;
            this.DuplicatedSelectedNotes = false;

            if (this.MiddleButtonClicked)
            {
                this.MiddleButtonClicked = false;
                return;
            }

            long xHS = (long)this.PanelHScroll[this.PanelFocus];
            long xVS = (long)this.PanelVScroll[this.PanelFocus];
            int xHeight = this.spMain[this.PanelFocus].Height;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    {
                        if (this.tempFirstMouseDown & !this.TBTimeSelect.Checked)
                        {
                            this.RefreshPanelAll();
                            break;
                        }

                        this.KMouseOver = -1;
                        // If K Is Nothing Then pMouseDown = e.Location : Exit Select

                        // Find the clicked K
                        int NoteIndex = GetClickedNote(e, xHS, xVS, xHeight);

                        PanelPreviewNoteIndex(NoteIndex);

                        for (int xI1 = 0, loopTo = Information.UBound(this.Notes); xI1 <= loopTo; xI1++)
                            this.Notes[xI1].TempMouseDown = false;

                        HandleCurrentModeOnClick(e, xHS, xVS, xHeight, ref NoteIndex);
                        this.RefreshPanelAll();
                        this.POStatusRefresh();
                        break;
                    }

                case MouseButtons.Middle:
                    {
                        if (this.MiddleButtonMoveMethod == 1)
                        {
                            this.tempX = e.X;
                            this.tempY = e.Y;
                            this.tempV = (int)xVS;
                            this.tempH = (int)xHS;
                        }
                        else
                        {
                            this.MiddleButtonLocation = Cursor.Position;
                            this.MiddleButtonClicked = true;
                            this.TimerMiddle.Enabled = true;
                        }

                        break;
                    }

                case MouseButtons.Right:
                    {
                        DeselectOrRemove(e, xHS, xVS, xHeight);
                        break;
                    }
            }
        }

        private void DeselectOrRemove(MouseEventArgs e, long xHS, long xVS, int xHeight)
        {
            this.KMouseOver = -1;
            // KMouseDown = -1
            this.SelectedNotes = new iBMSC.Editor.Note[0];
            // If K Is Nothing Then pMouseDown = e.Location : Exit Select

            if (!this.tempFirstMouseDown)
            {

                int xI1;
                for (xI1 = Information.UBound(this.Notes); xI1 >= 1; xI1 -= 1)
                {
                    // If mouse is clicking on a K
                    if (this.MouseInNote(e, xHS, xVS, xHeight, this.Notes[xI1]))
                    {

                        if (iBMSC.My.MyProject.Computer.Keyboard.ShiftKeyDown)
                        {
                            this.LWAV.SelectedIndices.Clear();
                            this.LWAV.SelectedIndex = iBMSC.Editor.Functions.C36to10(iBMSC.Editor.Functions.C10to36(this.Notes[xI1].Value / 10000L)) - 1;
                            this.ValidateWavListView();
                        }

                        else
                        {
                            iBMSC.UndoRedo.LinkedURCmd xUndo = null;
                            iBMSC.UndoRedo.LinkedURCmd xRedo = null;

                            this.RedoRemoveNote(this.Notes[xI1], ref xUndo, ref xRedo);
                            this.RemoveNote(xI1);

                            this.AddUndo(xUndo, xRedo);
                            this.RefreshPanelAll();
                        }

                        break;
                    }
                }

                this.CalculateTotalPlayableNotes();
            }
        }

        private int GetClickedNote(MouseEventArgs e, long xHS, long xVS, int xHeight)
        {
            int NoteIndex = -1;
            for (int xI1 = Information.UBound(this.Notes); xI1 >= 0; xI1 -= 1)
            {
                // If mouse is clicking on a K
                if (this.MouseInNote(e, xHS, xVS, xHeight, this.Notes[xI1]))
                {
                    // found it!
                    NoteIndex = xI1;
                    this.deltaVPosition = Conversions.ToDouble(Interaction.IIf(this.NTInput, Operators.SubtractObject(this.GetMouseVPosition(false), this.Notes[xI1].VPosition), (object)0));

                    if (this.NTInput & iBMSC.My.MyProject.Computer.Keyboard.ShiftKeyDown)
                    {
                        this.bAdjustUpper = e.Y <= this.NoteRowToPanelHeight(this.Notes[xI1].VPosition + this.Notes[xI1].Length, xVS, xHeight);
                        this.bAdjustLength = e.Y >= this.NoteRowToPanelHeight(this.Notes[xI1].VPosition, xVS, xHeight) - this.vo.kHeight | this.bAdjustUpper;
                    }

                    break;

                }
            }

            return NoteIndex;
        }

        private void PanelPreviewNoteIndex(int NoteIndex)
        {
            // Play wav
            if (this.ClickStopPreview)
                this.PreviewNote("", true);
            // My.Computer.Audio.Stop()
            if (NoteIndex > 0 & this.PreviewOnClick && this.IsColumnSound(this.Notes[NoteIndex].ColumnIndex))
            {
                int xI2 = (int)(this.Notes[NoteIndex].Value / 10000L);
                if (xI2 <= 0)
                    xI2 = 1;
                if (xI2 >= 1296)
                    xI2 = 1295;

                if (!string.IsNullOrEmpty(this.hWAV[xI2])) // AndAlso Path.GetExtension(hWAV(xI2)).ToLower = ".wav" Then
                {
                    string xFileLocation = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Interaction.IIf(string.IsNullOrEmpty(this.ExcludeFileName(this.FileName)), this.InitPath, this.ExcludeFileName(this.FileName)), @"\"), this.hWAV[xI2]));
                    if (!this.ClickStopPreview)
                        this.PreviewNote("", true);
                    this.PreviewNote(xFileLocation, false);
                }
            }
        }

        private void HandleCurrentModeOnClick(MouseEventArgs e, long xHS, long xVS, int xHeight, ref int NoteIndex)
        {
            if (this.TBSelect.Checked)
            {
                OnSelectModeLeftClick(e, NoteIndex, xHeight, (int)xVS);
            }
            else if (this.NTInput & this.TBWrite.Checked)
            {
                this.TempVPosition = (double)-1;
                this.SelectedColumn = -1;
                this.ShouldDrawTempNote = false;

                var xVPosition = this.GetMouseVPosition(this.gSnap);

                if (Conversions.ToBoolean(Operators.OrObject(Operators.ConditionalCompareObjectLess(xVPosition, 0, false), Operators.ConditionalCompareObjectGreaterEqual(xVPosition, this.GetMaxVPosition(), false))))
                    return;

                var xColumn = GetColumnAtEvent(e, (int)xHS);

                for (int xI2 = Information.UBound(this.Notes); xI2 >= 1; xI2 -= 1)
                {
                    if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectEqual(this.Notes[xI2].VPosition, xVPosition, false), Operators.ConditionalCompareObjectEqual(this.Notes[xI2].ColumnIndex, xColumn, false))))
                    {
                        NoteIndex = xI2;
                        break;
                    }
                }

                bool Hidden = iBMSC.PanelKeyStates.ModifierHiddenActive();

                if (NoteIndex > 0)
                {
                    this.SelectedNotes = new iBMSC.Editor.Note[1];
                    this.SelectedNotes[0] = this.Notes[NoteIndex];
                    this.Notes[NoteIndex].TempIndex = 0;

                    // KMouseDown = xITemp
                    this.Notes[NoteIndex].TempMouseDown = true;
                    this.Notes[NoteIndex].Length = Conversions.ToDouble(Operators.SubtractObject(xVPosition, this.Notes[NoteIndex].VPosition));

                    // uVPos = K(xITemp).VPosition
                    this.bAdjustUpper = true;

                    iBMSC.UndoRedo.LinkedURCmd xUndo = null;
                    iBMSC.UndoRedo.LinkedURCmd xRedo = null;


                    this.RedoLongNoteModify(this.SelectedNotes[0], this.Notes[NoteIndex].VPosition, this.Notes[NoteIndex].Length, ref xUndo, ref xRedo);
                    this.AddUndo(xUndo, xRedo);
                }
                // With uNote
                // AddUndo(sCmdKL(.ColumnIndex, .VPosition, .Value, K(xITemp).Length, .Hidden, .Length, True, True), _
                // sCmdKL(.ColumnIndex, .VPosition, .Value, .Length, .Hidden, K(xITemp).Length, True, True))
                // End With

                else if (this.IsColumnNumeric(Conversions.ToInteger(xColumn)))
                {

                    string xMessage = iBMSC.Strings.Messages.PromptEnterNumeric;
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(xColumn, MainWindow.niBPM, false)))
                        xMessage = iBMSC.Strings.Messages.PromptEnterBPM;
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(xColumn, MainWindow.niSTOP, false)))
                        xMessage = iBMSC.Strings.Messages.PromptEnterSTOP;
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(xColumn, MainWindow.niSCROLL, false)))
                        xMessage = iBMSC.Strings.Messages.PromptEnterSCROLL;

                    string valstr = Interaction.InputBox(xMessage, this.Text);
                    double value = Conversion.Val(valstr) * 10000d;

                    if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(Operators.ConditionalCompareObjectEqual(xColumn, MainWindow.niSCROLL, false), valstr == "0"), value != 0d)))
                    {
                        if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectNotEqual(xColumn, MainWindow.niSCROLL, false), value <= 0d)))
                            value = 1d;

                        iBMSC.UndoRedo.LinkedURCmd xUndo = null;
                        iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
                        var xBaseRedo = xRedo;

                        for (int xI1 = 1, loopTo = Information.UBound(this.Notes); xI1 <= loopTo; xI1++)
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(this.Notes[xI1].VPosition, xVPosition, false)) && Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(this.Notes[xI1].ColumnIndex, xColumn, false)))
                                this.RedoRemoveNote(this.Notes[xI1], ref xUndo, ref xRedo);
                        }

                        var n = new iBMSC.Editor.Note(Conversions.ToInteger(xColumn), Conversions.ToDouble(xVPosition), (long)Math.Round(value), 0d, Hidden);
                        this.RedoAddNote(n, ref xUndo, ref xRedo);

                        this.AddNote(n);
                        this.AddUndo(xUndo, xBaseRedo.Next);
                    }

                    this.ShouldDrawTempNote = true;
                }

                else
                {
                    int xLbl = (this.LWAV.SelectedIndex + 1) * 10000;

                    bool Landmine = iBMSC.PanelKeyStates.ModifierLandmineActive();

                    Array.Resize(ref this.Notes, Information.UBound(this.Notes) + 1 + 1);
                    {
                        ref var withBlock = ref this.Notes[Information.UBound(this.Notes)];
                        withBlock.VPosition = Conversions.ToDouble(xVPosition);
                        withBlock.ColumnIndex = Conversions.ToInteger(xColumn);
                        withBlock.Value = (long)xLbl;
                        withBlock.Hidden = Hidden;
                        withBlock.Landmine = Landmine;
                        withBlock.TempMouseDown = true;
                    }

                    this.SelectedNotes = new iBMSC.Editor.Note[1];
                    this.SelectedNotes[0] = this.Notes[Information.UBound(this.Notes)];
                    this.SelectedNotes[0].LNPair = -1;

                    if (this.TBWavIncrease.Checked)
                    {
                        IncreaseCurrentWav();
                    }

                    // KMouseDown = 1

                    // uNote.Value = 0
                    // uVPos = xVPosition
                    this.uAdded = false;

                    iBMSC.UndoRedo.LinkedURCmd xUndo = null;
                    iBMSC.UndoRedo.LinkedURCmd xRedo = null;
                    this.RedoAddNote(this.Notes[Information.UBound(this.Notes)], ref xUndo, ref xRedo, this.TBWavIncrease.Checked);
                    this.AddUndo(xUndo, xRedo);
                }

                this.SortByVPositionInsertion();
                this.UpdatePairing();
                this.CalculateTotalPlayableNotes();
            }

            else if (this.TBTimeSelect.Checked)
            {

                double xL1;
                if (NoteIndex >= 0)
                    xL1 = this.Notes[NoteIndex].VPosition;
                else
                    xL1 = (double)(((float)xHeight - (float)xVS * this.gxHeight - (float)e.Y - 1f) / this.gxHeight);

                this.vSelAdjust = iBMSC.PanelKeyStates.ModifierLongNoteActive();

                this.vSelMouseOverLine = 0;
                if (Math.Abs(e.Y - this.NoteRowToPanelHeight(this.vSelStart + this.vSelLength, xVS, xHeight)) <= this.vo.PEDeltaMouseOver)
                {
                    this.vSelMouseOverLine = 3;
                }
                else if (Math.Abs(e.Y - this.NoteRowToPanelHeight(this.vSelStart + this.vSelHalf, xVS, xHeight)) <= this.vo.PEDeltaMouseOver)
                {
                    this.vSelMouseOverLine = 2;
                }
                else if (Math.Abs(e.Y - this.NoteRowToPanelHeight(this.vSelStart, xVS, xHeight)) <= this.vo.PEDeltaMouseOver)
                {
                    this.vSelMouseOverLine = 1;
                }

                if (!this.vSelAdjust)
                {
                    if (this.vSelMouseOverLine == 1)
                    {
                        if (this.gSnap & NoteIndex <= 0)
                            xL1 = this.SnapToGrid(xL1);
                        this.vSelLength += this.vSelStart - xL1;
                        this.vSelHalf += this.vSelStart - xL1;
                        this.vSelStart = xL1;
                    }

                    else if (this.vSelMouseOverLine == 2)
                    {
                        this.vSelHalf = xL1;
                        if (this.gSnap & NoteIndex <= 0)
                            this.vSelHalf = this.SnapToGrid(this.vSelHalf);
                        this.vSelHalf -= this.vSelStart;
                    }

                    else if (this.vSelMouseOverLine == 3)
                    {
                        this.vSelLength = xL1;
                        if (this.gSnap & NoteIndex <= 0)
                            this.vSelLength = this.SnapToGrid(this.vSelLength);
                        this.vSelLength -= this.vSelStart;
                    }

                    else
                    {
                        this.vSelLength = 0d;
                        this.vSelStart = xL1;
                        if (this.gSnap & NoteIndex <= 0)
                            this.vSelStart = this.SnapToGrid(this.vSelStart);
                    }
                    this.ValidateSelection();
                }

                else if (this.vSelMouseOverLine == 2)
                {
                    this.SortByVPositionInsertion();
                    this.vSelPStart = this.vSelStart;
                    this.vSelPLength = this.vSelLength;
                    this.vSelPHalf = this.vSelHalf;
                    this.vSelK = this.Notes;
                    Array.Resize(ref this.vSelK, Information.UBound(this.vSelK) + 1);

                    if (this.gSnap & NoteIndex <= 0 & !iBMSC.My.MyProject.Computer.Keyboard.CtrlKeyDown)
                        xL1 = this.SnapToGrid(xL1);
                    this.AddUndo(new iBMSC.UndoRedo.Void(), new iBMSC.UndoRedo.Void());
                    this.BPMChangeHalf(xL1 - this.vSelHalf - this.vSelStart, bOverWriteUndo: true);
                    this.SortByVPositionInsertion();
                    this.UpdatePairing();
                    this.CalculateGreatestVPosition();
                }

                else if (this.vSelMouseOverLine == 3 | this.vSelMouseOverLine == 1)
                {
                    this.SortByVPositionInsertion();
                    this.vSelPStart = this.vSelStart;
                    this.vSelPLength = this.vSelLength;
                    this.vSelPHalf = this.vSelHalf;
                    this.vSelK = this.Notes;
                    Array.Resize(ref this.vSelK, Information.UBound(this.vSelK) + 1);

                    if (this.gSnap & NoteIndex <= 0 & !iBMSC.My.MyProject.Computer.Keyboard.CtrlKeyDown)
                        xL1 = this.SnapToGrid(xL1);
                    this.AddUndo(new iBMSC.UndoRedo.Void(), new iBMSC.UndoRedo.Void());
                    this.BPMChangeTop(Conversions.ToDouble(Operators.DivideObject(Interaction.IIf(this.vSelMouseOverLine == 3, (object)(xL1 - this.vSelStart), (object)(this.vSelStart + this.vSelLength - xL1)), this.vSelLength)), bOverWriteUndo: true);
                    this.SortByVPositionInsertion();
                    this.UpdatePairing();
                    this.CalculateGreatestVPosition();
                }

                else
                {
                    this.vSelLength = xL1;
                    if (this.gSnap & NoteIndex <= 0 & !iBMSC.My.MyProject.Computer.Keyboard.CtrlKeyDown)
                        this.vSelLength = this.SnapToGrid(this.vSelLength);
                    this.vSelLength -= this.vSelStart;

                }

                if (Conversions.ToBoolean(this.vSelLength))
                {
                    double xVLower = Conversions.ToDouble(Interaction.IIf(this.vSelLength > 0d, (object)this.vSelStart, (object)(this.vSelStart + this.vSelLength)));
                    double xVUpper = Conversions.ToDouble(Interaction.IIf(this.vSelLength < 0d, (object)this.vSelStart, (object)(this.vSelStart + this.vSelLength)));
                    if (this.NTInput)
                    {
                        for (int xI2 = 1, loopTo1 = Information.UBound(this.Notes); xI2 <= loopTo1; xI2++)
                            this.Notes[xI2].Selected = !(this.Notes[xI2].VPosition >= xVUpper) & !(this.Notes[xI2].VPosition + this.Notes[xI2].Length < xVLower) & this.nEnabled(this.Notes[xI2].ColumnIndex);
                    }
                    else
                    {
                        for (int xI2 = 1, loopTo2 = Information.UBound(this.Notes); xI2 <= loopTo2; xI2++)
                            this.Notes[xI2].Selected = this.Notes[xI2].VPosition >= xVLower & this.Notes[xI2].VPosition < xVUpper & this.nEnabled(this.Notes[xI2].ColumnIndex);
                    }
                }
                else
                {
                    for (int xI2 = 1, loopTo3 = Information.UBound(this.Notes); xI2 <= loopTo3; xI2++)
                        this.Notes[xI2].Selected = false;
                }

            }
        }

        private void OnSelectModeLeftClick(MouseEventArgs e, int NoteIndex, int xTHeight, int xVS)
        {
            if (NoteIndex >= 0 & e.Clicks == 2)
            {
                DoubleClickNoteIndex(NoteIndex);
            }
            else if (NoteIndex > 0)
            {
                // KMouseDown = -1
                this.SelectedNotes = new iBMSC.Editor.Note[0];

                // KMouseDown = xITemp
                this.Notes[NoteIndex].TempMouseDown = true;

                if (iBMSC.My.MyProject.Computer.Keyboard.CtrlKeyDown & !iBMSC.PanelKeyStates.ModifierMultiselectActive())
                {
                    // If Not K(xITemp).Selected Then K(xITemp).Selected = True
                    this.ctrlPressed = true;
                }

                else if (iBMSC.PanelKeyStates.ModifierMultiselectActive())
                {
                    for (int xI1 = 0, loopTo6 = Information.UBound(this.Notes); xI1 <= loopTo6; xI1++)
                    {
                        if (this.IsNoteVisible(xI1, xTHeight, xVS))
                        {
                            if (this.IsLabelMatch(this.Notes[xI1], NoteIndex))
                            {
                                this.Notes[xI1].Selected = !this.Notes[xI1].Selected;
                            }
                        }
                    }
                }
                else
                {
                    // az description: If the clicked note is not selected, select only this one.
                    // Otherwise, we clicked an already selected note
                    // and we should rebuild the selected note array.
                    if (!this.Notes[NoteIndex].Selected)
                    {
                        for (int xI1 = 0, loopTo2 = Information.UBound(this.Notes); xI1 <= loopTo2; xI1++)
                        {
                            if (this.Notes[xI1].Selected)
                                this.Notes[xI1].Selected = false;
                        }
                        this.Notes[NoteIndex].Selected = true;
                    }

                    int SelectedCount = 0;
                    for (int xI1 = 0, loopTo3 = Information.UBound(this.Notes); xI1 <= loopTo3; xI1++)
                    {
                        if (this.Notes[xI1].Selected)
                            SelectedCount += 1;
                    }

                    // adjustsingle if selectedcount is 1
                    this.bAdjustSingle = SelectedCount == 1;

                    this.SelectedNotes = new iBMSC.Editor.Note[SelectedCount + 1];
                    this.SelectedNotes[0] = this.Notes[NoteIndex];
                    this.Notes[NoteIndex].TempIndex = 0;
                    int idx = 1;

                    // Add already selected notes including this one
                    for (int xI1 = 1, loopTo4 = NoteIndex - 1; xI1 <= loopTo4; xI1++)
                    {
                        if (this.Notes[xI1].Selected)
                        {
                            this.Notes[xI1].TempIndex = idx;
                            this.SelectedNotes[idx] = this.Notes[xI1];
                            idx += 1;
                        }
                    }
                    for (int xI1 = NoteIndex + 1, loopTo5 = Information.UBound(this.Notes); xI1 <= loopTo5; xI1++)
                    {
                        if (this.Notes[xI1].Selected)
                        {
                            this.Notes[xI1].TempIndex = idx;
                            this.SelectedNotes[idx] = this.Notes[xI1];
                            idx += 1;
                        }
                    }

                    // uCol = RealColumnToEnabled(K(xITemp).ColumnIndex)
                    // uVPos = K(xITemp).VPosition
                    // uNote = K(xITemp)
                    this.uAdded = false;

                }
            }

            else
            {
                this.SelectedNotes = new iBMSC.Editor.Note[0];
                this.LastMouseDownLocation = e.Location;
                if (!iBMSC.My.MyProject.Computer.Keyboard.CtrlKeyDown)
                {
                    for (int xI1 = 0, loopTo = Information.UBound(this.Notes); xI1 <= loopTo; xI1++)
                    {
                        this.Notes[xI1].Selected = false;
                        this.Notes[xI1].TempSelected = false;
                    }
                }
                else
                {
                    for (int xI1 = 0, loopTo1 = Information.UBound(this.Notes); xI1 <= loopTo1; xI1++)
                        this.Notes[xI1].TempSelected = this.Notes[xI1].Selected;
                }
            }
        }

        // Handles a double click on a note in select mode.
        private void DoubleClickNoteIndex(int NoteIndex)
        {
            var Note = this.Notes[NoteIndex];
            int NoteColumn = Note.ColumnIndex;

            if (this.IsColumnNumeric(NoteColumn))
            {
                // BPM/Stop prompt
                string xMessage = iBMSC.Strings.Messages.PromptEnterNumeric;
                if (NoteColumn == MainWindow.niBPM)
                    xMessage = iBMSC.Strings.Messages.PromptEnterBPM;
                if (NoteColumn == MainWindow.niSTOP)
                    xMessage = iBMSC.Strings.Messages.PromptEnterSTOP;
                if (NoteColumn == MainWindow.niSCROLL)
                    xMessage = iBMSC.Strings.Messages.PromptEnterSCROLL;


                string valstr = Interaction.InputBox(xMessage, this.Text);
                double PromptValue = Conversion.Val(valstr) * 10000d;
                if (NoteColumn == MainWindow.niSCROLL & valstr == "0" | PromptValue != 0d)
                {

                    iBMSC.UndoRedo.LinkedURCmd xUndo = null;
                    iBMSC.UndoRedo.LinkedURCmd xRedo = null;
                    this.RedoRelabelNote(Note, (long)Math.Round(PromptValue), ref xUndo, ref xRedo);
                    if (NoteIndex == 0)
                    {
                        this.THBPM.Value = (decimal)(PromptValue / 10000d);
                    }
                    else
                    {
                        this.Notes[NoteIndex].Value = (long)Math.Round(PromptValue);
                    }
                    this.AddUndo(xUndo, xRedo);
                }
            }
            else
            {
                // Label prompt
                string xStr = Strings.UCase(Strings.Trim(Interaction.InputBox(iBMSC.Strings.Messages.PromptEnter, this.Text)));

                if (Strings.Len(xStr) == 0)
                    return;

                if (iBMSC.Editor.Functions.IsBase36(xStr) & !(xStr == "00" | xStr == "0"))
                {
                    iBMSC.UndoRedo.LinkedURCmd xUndo = null;
                    iBMSC.UndoRedo.LinkedURCmd xRedo = null;
                    this.RedoRelabelNote(Note, (long)(iBMSC.Editor.Functions.C36to10(xStr) * 10000), ref xUndo, ref xRedo);
                    this.Notes[NoteIndex].Value = (long)(iBMSC.Editor.Functions.C36to10(xStr) * 10000);
                    this.AddUndo(xUndo, xRedo);
                    return;
                }
                else
                {
                    Interaction.MsgBox(iBMSC.Strings.Messages.InvalidLabel, MsgBoxStyle.Critical, iBMSC.Strings.Messages.Err);
                }

            }
        }

        private bool MouseInNote(MouseEventArgs e, long xHS, long xVS, int xHeight, iBMSC.Editor.Note note)
        {
            return e.X >= this.HorizontalPositiontoDisplay(this.nLeft(note.ColumnIndex), xHS) + 1 & e.X <= this.HorizontalPositiontoDisplay(this.nLeft(note.ColumnIndex) + this.GetColumnWidth(note.ColumnIndex), xHS) - 1 & e.Y >= this.NoteRowToPanelHeight(Conversions.ToDouble(Operators.AddObject(note.VPosition, Interaction.IIf(this.NTInput, (object)note.Length, (object)0))), xVS, xHeight) - this.vo.kHeight & e.Y <= this.NoteRowToPanelHeight(note.VPosition, xVS, xHeight);
        }

        private void PMainInMouseEnter(object sender, EventArgs e)
        {
            this.spMouseOver = Conversions.ToInteger(sender.Tag);
            Panel xPMainIn = (Panel)sender;
            if (this.AutoFocusMouseEnter && this.Focused)
            {
                xPMainIn.Focus();
                this.PanelFocus = this.spMouseOver;
            }
            if (this.FirstMouseEnter)
            {
                this.FirstMouseEnter = false;
                xPMainIn.Focus();
                this.PanelFocus = this.spMouseOver;
            }
        }

        private void PMainInMouseLeave(object sender, EventArgs e)
        {
            this.KMouseOver = -1;
            // KMouseDown = -1
            this.SelectedNotes = new iBMSC.Editor.Note[0];
            this.TempVPosition = (double)-1;
            this.SelectedColumn = -1;
            this.RefreshPanelAll();
        }

        private void PMainInMouseMove(Panel sender)
        {
            var p = sender.PointToClient(Cursor.Position);
            PMainInMouseMove(sender, new MouseEventArgs(MouseButtons.None, 0, p.X, p.Y, 0));
        }

        private void PMainInMouseMove(object sender, MouseEventArgs e)
        {
            this.MouseMoveStatus = e.Location;

            int iI = Conversions.ToInteger(sender.Tag);

            long xHS = (long)this.PanelHScroll[iI];
            long xVS = (long)this.PanelVScroll[iI];
            int xHeight = this.spMain[iI].Height;
            int xWidth = this.spMain[iI].Width;

            switch (e.Button)
            {
                case MouseButtons.None:
                    {
                        // If K Is Nothing Then Exit Select
                        if (this.MiddleButtonClicked)
                            break;

                        if (this.isFullScreen)
                        {
                            if (e.Y < 5)
                                this.ToolStripContainer1.TopToolStripPanelVisible = true;
                            else
                                this.ToolStripContainer1.TopToolStripPanelVisible = false;
                        }

                        bool xMouseRemainInSameRegion = false;

                        int noteIndex;
                        int foundNoteIndex = -1;
                        for (noteIndex = Information.UBound(this.Notes); noteIndex >= 0; noteIndex -= 1)
                        {
                            if (this.MouseInNote(e, xHS, xVS, xHeight, this.Notes[noteIndex]))
                            {
                                foundNoteIndex = noteIndex;

                                xMouseRemainInSameRegion = foundNoteIndex == this.KMouseOver;
                                if (this.NTInput)
                                {
                                    int vy = this.NoteRowToPanelHeight(this.Notes[noteIndex].VPosition + this.Notes[noteIndex].Length, xVS, xHeight);

                                    bool xbAdjustUpper = e.Y <= vy & iBMSC.PanelKeyStates.ModifierLongNoteActive();
                                    bool xbAdjustLength = (e.Y >= vy - this.vo.kHeight | xbAdjustUpper) & iBMSC.PanelKeyStates.ModifierLongNoteActive();
                                    xMouseRemainInSameRegion = xMouseRemainInSameRegion & xbAdjustUpper == this.bAdjustUpper & xbAdjustLength == this.bAdjustLength;
                                    this.bAdjustUpper = xbAdjustUpper;
                                    this.bAdjustLength = xbAdjustLength;
                                }

                                break;
                            }
                        }

                        bool xTempbTimeSelectionMode = this.TBTimeSelect.Checked;

                        if (this.TBSelect.Checked | xTempbTimeSelectionMode)
                        {

                            if (xMouseRemainInSameRegion)
                                break;
                            if (this.KMouseOver >= 0)
                                this.KMouseOver = -1;

                            if (xTempbTimeSelectionMode)
                            {

                                int xMouseOverLine = this.vSelMouseOverLine;
                                this.vSelMouseOverLine = 0;

                                if (Math.Abs(e.Y - this.NoteRowToPanelHeight(this.vSelStart + this.vSelLength, xVS, xHeight)) <= this.vo.PEDeltaMouseOver)
                                {
                                    this.vSelMouseOverLine = 3;
                                }
                                else if (Math.Abs(e.Y - this.NoteRowToPanelHeight(this.vSelStart + this.vSelHalf, xVS, xHeight)) <= this.vo.PEDeltaMouseOver)
                                {
                                    this.vSelMouseOverLine = 2;
                                }
                                else if (Math.Abs(e.Y - this.NoteRowToPanelHeight(this.vSelStart, xVS, xHeight)) <= this.vo.PEDeltaMouseOver)
                                {
                                    this.vSelMouseOverLine = 1;
                                }

                            }

                            // draw green highlight
                            if (foundNoteIndex > -1)
                            {
                                DrawNoteHoverHighlight(iI, xHS, xVS, xHeight, foundNoteIndex);
                            }

                            this.KMouseOver = foundNoteIndex;
                        }

                        else if (this.TBWrite.Checked)
                        {
                            this.TempVPosition = (double)(((float)xHeight - (float)xVS * this.gxHeight - (float)e.Y - 1f) / this.gxHeight); // VPosition of the mouse
                            if (this.gSnap)
                                this.TempVPosition = this.SnapToGrid(this.TempVPosition);

                            this.SelectedColumn = Conversions.ToInteger(GetColumnAtEvent(e, (int)xHS));  // get the enabled column where mouse is 

                            this.TempLength = 0d;
                            if (foundNoteIndex > -1)
                                this.TempLength = this.Notes[foundNoteIndex].Length;

                            this.RefreshPanelAll();
                        }

                        break;
                    }

                case MouseButtons.Left:
                    {
                        if (this.tempFirstMouseDown & !this.TBTimeSelect.Checked)
                            break;

                        this.tempX = 0;
                        this.tempY = 0;
                        if (e.X < 0 | e.X > xWidth | e.Y < 0 | e.Y > xHeight)
                        {
                            if (e.X < 0)
                                this.tempX = e.X;
                            if (e.X > xWidth)
                                this.tempX = e.X - xWidth;
                            if (e.Y < 0)
                                this.tempY = e.Y;
                            if (e.Y > xHeight)
                                this.tempY = e.Y - xHeight;
                            this.Timer1.Enabled = true;
                        }
                        else
                        {
                            this.Timer1.Enabled = false;
                        }

                        if (this.TBSelect.Checked)
                        {

                            this.pMouseMove = e.Location;

                            // If K Is Nothing Then RefreshPanelAll() : Exit Select

                            if (!(this.LastMouseDownLocation == new Point(-1, -1)))
                            {
                                UpdateSelectionBox(xHS, xVS, xHeight);
                            }

                            // ElseIf Not KMouseDown = -1 Then
                            else if (this.SelectedNotes.Length != 0)
                            {
                                UpdateSelectedNotes(xHeight, xVS, xHS, e);
                            }

                            else if (this.ctrlPressed)
                            {
                                OnDuplicateSelectedNotes(xHeight, xVS, xHS, e);
                            }
                        }

                        else if (this.TBWrite.Checked)
                        {

                            if (this.NTInput)
                            {
                                OnWriteModeMouseMove(xHeight, xVS, e);
                            }

                            else
                            {
                                this.TempVPosition = (double)(((float)xHeight - (float)xVS * this.gxHeight - (float)e.Y - 1f) / this.gxHeight); // VPosition of the mouse
                                if (this.gSnap)
                                    this.TempVPosition = this.SnapToGrid(this.TempVPosition);
                                this.SelectedColumn = Conversions.ToInteger(GetColumnAtEvent(e, (int)xHS));

                            }  // get the enabled column where mouse is 
                        }

                        else if (this.TBTimeSelect.Checked)
                        {
                            OnTimeSelectClick(xHeight, xHS, xVS, e);
                        }

                        break;
                    }

                case MouseButtons.Middle:
                    {
                        OnPanelMousePan(e);
                        break;
                    }
            }
            var col = GetColumnAtEvent(e, (int)xHS);
            var vps = this.GetMouseVPosition(this.gSnap);
            if (Conversions.ToBoolean(Operators.OrObject(Operators.ConditionalCompareObjectNotEqual(vps, lastVPos, false), Operators.ConditionalCompareObjectNotEqual(col, lastColumn, false))))
            {
                lastVPos = vps;
                lastColumn = col;
                this.POStatusRefresh();
                this.RefreshPanelAll(); // az: refreshing the line is important now...
            }

        }

        private object lastVPos = -1;
        private object lastColumn = -1;

        private void UpdateSelectedNotes(double xHeight, double xvs, double xhs, MouseEventArgs e)
        {
            double mouseVPosition;

            var xITemp = default(int);
            for (int xI1 = 1, loopTo = Information.UBound(this.Notes); xI1 <= loopTo; xI1++)
            {
                if (this.Notes[xI1].TempMouseDown)
                {
                    xITemp = xI1;
                    break;
                }
            }

            mouseVPosition = Conversions.ToDouble(this.GetMouseVPosition(this.gSnap));

            if (this.bAdjustLength & this.bAdjustSingle)
            {
                if (this.bAdjustUpper && mouseVPosition < this.Notes[xITemp].VPosition)
                {
                    this.bAdjustUpper = false;
                    this.Notes[xITemp].VPosition += this.Notes[xITemp].Length;
                    this.Notes[xITemp].Length *= (double)-1;
                }
                else if (!this.bAdjustUpper && mouseVPosition > this.Notes[xITemp].VPosition + this.Notes[xITemp].Length)
                {
                    this.bAdjustUpper = true;
                    this.Notes[xITemp].VPosition += this.Notes[xITemp].Length;
                    this.Notes[xITemp].Length *= (double)-1;
                }
            }

            // If moving
            if (!this.bAdjustLength)
            {
                OnSelectModeMoveNotes(e, (long)Math.Round(xhs), xITemp);
            }

            else if (this.bAdjustUpper)    // If adjusting upper end
            {
                double dVPosition = mouseVPosition - this.Notes[xITemp].VPosition - this.Notes[xITemp].Length;  // delta Length
                                                                                                                // < 0 means shorten, > 0 means lengthen

                OnAdjustUpperEnd(dVPosition);
            }

            else    // If adjusting lower end
            {
                double dVPosition = mouseVPosition - this.Notes[xITemp].VPosition;  // delta VPosition
                                                                                    // > 0 means shorten, < 0 means lengthen

                OnAdjustLowerEnd(dVPosition);
            }

            this.SortByVPositionInsertion();
            this.UpdatePairing();
            this.CalculateTotalPlayableNotes();
            // Label1.Text = KInfo(KMouseDown)
        }

        private void OnPanelMousePan(MouseEventArgs e)
        {
            if (this.MiddleButtonMoveMethod == 1)
            {
                int xI1 = (int)Math.Round((float)this.tempV + (float)(this.tempY - e.Y) / this.gxHeight);
                int xI2 = (int)Math.Round((float)this.tempH + (float)(this.tempX - e.X) / this.gxWidth);
                if (xI1 > 0)
                    xI1 = 0;
                if (xI2 < 0)
                    xI2 = 0;

                switch (this.PanelFocus)
                {
                    case 0:
                        {
                            if (xI1 < this.LeftPanelScroll.Minimum)
                                xI1 = this.LeftPanelScroll.Minimum;
                            this.LeftPanelScroll.Value = xI1;

                            if (xI2 > this.HSL.Maximum - this.HSL.LargeChange + 1)
                                xI2 = this.HSL.Maximum - this.HSL.LargeChange + 1;
                            this.HSL.Value = xI2;
                            break;
                        }

                    case 1:
                        {
                            if (xI1 < this.MainPanelScroll.Minimum)
                                xI1 = this.MainPanelScroll.Minimum;
                            this.MainPanelScroll.Value = xI1;

                            if (xI2 > this.HS.Maximum - this.HS.LargeChange + 1)
                                xI2 = this.HS.Maximum - this.HS.LargeChange + 1;
                            this.HS.Value = xI2;
                            break;
                        }

                    case 2:
                        {
                            if (xI1 < this.RightPanelScroll.Minimum)
                                xI1 = this.RightPanelScroll.Minimum;
                            this.RightPanelScroll.Value = xI1;

                            if (xI2 > this.HSR.Maximum - this.HSR.LargeChange + 1)
                                xI2 = this.HSR.Maximum - this.HSR.LargeChange + 1;
                            this.HSR.Value = xI2;
                            break;
                        }

                }
            }
        }

        private void OnTimeSelectClick(double xHeight, double xHS, double xvs, MouseEventArgs e)
        {
            int xI1;
            int xITemp = -1;
            if (this.Notes is not null)
            {
                for (xI1 = Information.UBound(this.Notes); xI1 >= 0; xI1 -= 1) // az: MouseInNote implied, but I'm not sure yet
                {
                    if (this.MouseInNote(e, (long)Math.Round(xHS), (long)Math.Round(xvs), (int)Math.Round(xHeight), this.Notes[xI1]))
                    {
                        xITemp = xI1;
                        break;
                    }
                }
            }

            if (!this.vSelAdjust)
            {
                if (this.vSelMouseOverLine == 1)
                {
                    double xV = (xHeight - xvs * (double)this.gxHeight - (double)e.Y - 1d) / (double)this.gxHeight;
                    if (xITemp >= 0)
                        xV = this.Notes[xITemp].VPosition;
                    if (this.gSnap & xITemp <= 0 & !iBMSC.My.MyProject.Computer.Keyboard.CtrlKeyDown)
                        xV = this.SnapToGrid(xV);
                    this.vSelLength += this.vSelStart - xV;
                    this.vSelHalf += this.vSelStart - xV;
                    this.vSelStart = xV;
                }

                else if (this.vSelMouseOverLine == 2)
                {
                    this.vSelHalf = (xHeight - xvs * (double)this.gxHeight - (double)e.Y - 1d) / (double)this.gxHeight;
                    if (xITemp >= 0)
                        this.vSelHalf = this.Notes[xITemp].VPosition;
                    if (this.gSnap & xITemp <= 0 & !iBMSC.My.MyProject.Computer.Keyboard.CtrlKeyDown)
                        this.vSelHalf = this.SnapToGrid(this.vSelHalf);
                    this.vSelHalf -= this.vSelStart;
                }

                else if (this.vSelMouseOverLine == 3)
                {
                    this.vSelLength = (xHeight - xvs * (double)this.gxHeight - (double)e.Y - 1d) / (double)this.gxHeight;
                    if (xITemp >= 0)
                        this.vSelLength = this.Notes[xITemp].VPosition;
                    if (this.gSnap & xITemp <= 0 & !iBMSC.My.MyProject.Computer.Keyboard.CtrlKeyDown)
                        this.vSelLength = this.SnapToGrid(this.vSelLength);
                    this.vSelLength -= this.vSelStart;
                }

                else
                {
                    if (xITemp >= 0)
                    {
                        this.vSelLength = this.Notes[xITemp].VPosition;
                    }
                    else
                    {
                        this.vSelLength = (xHeight - xvs * (double)this.gxHeight - (double)e.Y - 1d) / (double)this.gxHeight;
                        if (this.gSnap & !iBMSC.My.MyProject.Computer.Keyboard.CtrlKeyDown)
                            this.vSelLength = this.SnapToGrid(this.vSelLength);
                    }
                    this.vSelLength -= this.vSelStart;
                    this.vSelHalf = this.vSelLength / 2d;
                }
                this.ValidateSelection();
            }

            else
            {
                double xL1 = (xHeight - xvs * (double)this.gxHeight - (double)e.Y - 1d) / (double)this.gxHeight;

                if (this.vSelMouseOverLine == 2)
                {
                    this.vSelStart = this.vSelPStart;
                    this.vSelLength = this.vSelPLength;
                    this.vSelHalf = this.vSelPHalf;
                    this.Notes = this.vSelK;
                    Array.Resize(ref this.Notes, Information.UBound(this.Notes) + 1);

                    if (this.gSnap & !iBMSC.My.MyProject.Computer.Keyboard.CtrlKeyDown)
                        xL1 = this.SnapToGrid(xL1);
                    this.BPMChangeHalf(xL1 - this.vSelHalf - this.vSelStart, bOverWriteUndo: true);
                    this.SortByVPositionInsertion();
                    this.UpdatePairing();
                    this.CalculateGreatestVPosition();
                }

                else if (this.vSelMouseOverLine == 3 | this.vSelMouseOverLine == 1)
                {
                    this.vSelStart = this.vSelPStart;
                    this.vSelLength = this.vSelPLength;
                    this.vSelHalf = this.vSelPHalf;
                    this.Notes = this.vSelK;
                    Array.Resize(ref this.Notes, Information.UBound(this.Notes) + 1);

                    if (this.gSnap & !iBMSC.My.MyProject.Computer.Keyboard.CtrlKeyDown)
                        xL1 = this.SnapToGrid(xL1);
                    this.BPMChangeTop(Conversions.ToDouble(Operators.DivideObject(Interaction.IIf(this.vSelMouseOverLine == 3, (object)(xL1 - this.vSelStart), (object)(this.vSelStart + this.vSelLength - xL1)), this.vSelLength)), bOverWriteUndo: true);
                    this.SortByVPositionInsertion();
                    this.UpdatePairing();
                    this.CalculateGreatestVPosition();
                }

                else
                {
                    this.vSelLength = xL1;
                    if (this.gSnap & !iBMSC.My.MyProject.Computer.Keyboard.CtrlKeyDown)
                        this.vSelLength = this.SnapToGrid(this.vSelLength);
                    if (xITemp >= 0)
                        this.vSelLength = this.Notes[xITemp].VPosition;
                    this.vSelLength -= this.vSelStart;
                    this.ValidateSelection();
                }
            }

            if (Conversions.ToBoolean(this.vSelLength))
            {
                double xVLower = Conversions.ToDouble(Interaction.IIf(this.vSelLength > 0d, (object)this.vSelStart, (object)(this.vSelStart + this.vSelLength)));
                double xVUpper = Conversions.ToDouble(Interaction.IIf(this.vSelLength < 0d, (object)this.vSelStart, (object)(this.vSelStart + this.vSelLength)));
                if (this.NTInput)
                {
                    for (int xI2 = 1, loopTo = Information.UBound(this.Notes); xI2 <= loopTo; xI2++)
                        this.Notes[xI2].Selected = this.Notes[xI2].VPosition < xVUpper & this.Notes[xI2].VPosition + this.Notes[xI2].Length >= xVLower & this.nEnabled(this.Notes[xI2].ColumnIndex);
                }
                else
                {
                    for (int xI2 = 1, loopTo1 = Information.UBound(this.Notes); xI2 <= loopTo1; xI2++)
                        this.Notes[xI2].Selected = this.Notes[xI2].VPosition >= xVLower & this.Notes[xI2].VPosition < xVUpper & this.nEnabled(this.Notes[xI2].ColumnIndex);
                }
            }
            else
            {
                for (int xI2 = 1, loopTo2 = Information.UBound(this.Notes); xI2 <= loopTo2; xI2++)
                    this.Notes[xI2].Selected = false;
            }

        }

        private void OnAdjustUpperEnd(double dVPosition)
        {
            double minLength = 0d;
            double maxHeight = 191999d;
            for (int xI1 = 1, loopTo = Information.UBound(this.Notes); xI1 <= loopTo; xI1++)
            {
                if (!this.Notes[xI1].Selected)
                    continue;
                if (this.Notes[xI1].Length + dVPosition < minLength)
                    minLength = this.Notes[xI1].Length + dVPosition;
                if (this.Notes[xI1].Length + this.Notes[xI1].VPosition + dVPosition > maxHeight)
                    maxHeight = this.Notes[xI1].Length + this.Notes[xI1].VPosition + dVPosition;
            }
            maxHeight -= 191999d;

            // declare undo variables
            iBMSC.UndoRedo.LinkedURCmd xUndo = null;
            iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
            var xBaseRedo = xRedo;

            // start moving
            double xLen;
            for (int xI1 = 1, loopTo1 = Information.UBound(this.Notes); xI1 <= loopTo1; xI1++)
            {
                if (!this.Notes[xI1].Selected)
                    continue;

                xLen = this.Notes[xI1].Length + dVPosition - minLength - maxHeight;
                this.RedoLongNoteModify(this.SelectedNotes[this.Notes[xI1].TempIndex], this.Notes[xI1].VPosition, xLen, ref xUndo, ref xRedo);

                this.Notes[xI1].Length = xLen;
            }

            // Add undo
            if (dVPosition - minLength - maxHeight != 0d)
            {
                this.AddUndo(xUndo, xBaseRedo.Next, this.uAdded);
                if (!this.uAdded)
                    this.uAdded = true;
            }
        }


        private void OnAdjustLowerEnd(double dVPosition)
        {
            int xI1;
            double minLength = 0d;
            double minVPosition = 0d;
            var loopTo = Information.UBound(this.Notes);
            for (xI1 = 1; xI1 <= loopTo; xI1++)
            {
                if (this.Notes[xI1].Selected && this.Notes[xI1].Length - dVPosition < minLength)
                {
                    minLength = this.Notes[xI1].Length - dVPosition;
                }
                if (this.Notes[xI1].Selected && this.Notes[xI1].VPosition + dVPosition < minVPosition)
                {
                    minVPosition = this.Notes[xI1].VPosition + dVPosition;
                }
            }

            // declare undo variables
            iBMSC.UndoRedo.LinkedURCmd xUndo = null;
            iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
            var xBaseRedo = xRedo;

            // start moving
            double xVPos;
            double xLen;
            var loopTo1 = Information.UBound(this.Notes);
            for (xI1 = 0; xI1 <= loopTo1; xI1++)
            {
                if (!this.Notes[xI1].Selected)
                    continue;

                xVPos = this.Notes[xI1].VPosition + dVPosition + minLength - minVPosition;
                xLen = this.Notes[xI1].Length - dVPosition - minLength + minVPosition;
                this.RedoLongNoteModify(this.SelectedNotes[this.Notes[xI1].TempIndex], xVPos, xLen, ref xUndo, ref xRedo);

                this.Notes[xI1].VPosition = xVPos;
                this.Notes[xI1].Length = xLen;
            }

            // Add undo
            if (dVPosition + minLength - minVPosition != 0d)
            {
                this.AddUndo(xUndo, xBaseRedo.Next, this.uAdded);
                if (!this.uAdded)
                    this.uAdded = true;
            }
        }

        private void OnDuplicateSelectedNotes(double xHeight, double xVS, double xHS, MouseEventArgs e)
        {
            int tempNoteIndex;
            var loopTo = Information.UBound(this.Notes);
            for (tempNoteIndex = 1; tempNoteIndex <= loopTo; tempNoteIndex++)
            {
                if (this.Notes[tempNoteIndex].TempMouseDown)
                    break;
            }

            var mouseVPosition = this.GetMouseVPosition(this.gSnap);
            if (this.DisableVerticalMove)
                mouseVPosition = (object)this.Notes[tempNoteIndex].VPosition;

            double dVPosition = Conversions.ToDouble(Operators.SubtractObject(mouseVPosition, this.Notes[tempNoteIndex].VPosition));  // delta VPosition

            int currCol = this.ColumnArrayIndexToEnabledColumnIndex(Conversions.ToInteger(GetColumnAtEvent(e, (int)Math.Round(xHS))));
            int noteCol = this.ColumnArrayIndexToEnabledColumnIndex(this.Notes[tempNoteIndex].ColumnIndex);
            int colChange = currCol - noteCol; // delta Column

            // Ks cannot be beyond the left, the upper and the lower boundary
            int dstColumn = 0;
            double mVPosition = 0d;
            double muVPosition = 191999d;
            for (int xI1 = 1, loopTo1 = Information.UBound(this.Notes); xI1 <= loopTo1; xI1++)
            {
                if (!this.Notes[xI1].Selected)
                    continue;

                if (this.ColumnArrayIndexToEnabledColumnIndex(this.Notes[xI1].ColumnIndex) + colChange < dstColumn)
                    dstColumn = this.ColumnArrayIndexToEnabledColumnIndex(this.Notes[xI1].ColumnIndex) + colChange;

                if (this.Notes[xI1].VPosition + dVPosition < mVPosition)
                    mVPosition = this.Notes[xI1].VPosition + dVPosition;

                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(Operators.AddObject(Operators.AddObject(this.Notes[xI1].VPosition, Interaction.IIf(this.NTInput, (object)this.Notes[xI1].Length, (object)0)), dVPosition), muVPosition, false)))
                    muVPosition = Conversions.ToDouble(Operators.AddObject(Operators.AddObject(this.Notes[xI1].VPosition, Interaction.IIf(this.NTInput, (object)this.Notes[xI1].Length, (object)0)), dVPosition));

            }
            muVPosition -= 191999d;

            // If not moving then exit
            if (!this.DuplicatedSelectedNotes & colChange - dstColumn == 0 & dVPosition - mVPosition - muVPosition == 0d)
                return;

            iBMSC.UndoRedo.LinkedURCmd xUndo = null;
            iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
            var xBaseRedo = xRedo;

            if (!this.DuplicatedSelectedNotes)     // If uAdded = False
            {
                DuplicateSelectedNotes(tempNoteIndex, dVPosition, colChange, dstColumn, mVPosition, muVPosition);
                this.DuplicatedSelectedNotes = true;
            }

            else
            {
                for (int i = 1, loopTo2 = Information.UBound(this.Notes); i <= loopTo2; i++)
                {
                    if (!this.Notes[i].Selected)
                        continue;

                    this.Notes[i].ColumnIndex = this.EnabledColumnIndexToColumnArrayIndex(this.ColumnArrayIndexToEnabledColumnIndex(this.Notes[i].ColumnIndex) + colChange - dstColumn);
                    this.Notes[i].VPosition = this.Notes[i].VPosition + dVPosition - mVPosition - muVPosition;
                    this.RedoAddNote(this.Notes[i], ref xUndo, ref xRedo);
                }

                this.AddUndo(xUndo, xBaseRedo.Next, true);
            }

            this.SortByVPositionInsertion();
            this.UpdatePairing();
            this.CalculateTotalPlayableNotes();
        }


        private void OnWriteModeMouseMove(int xHeight, long xVS, MouseEventArgs e)
        {
            // If Not KMouseDown = -1 Then
            if (this.SelectedNotes.Length != 0)
            {

                int xI1;
                var xITemp = default(int);
                var loopTo = Information.UBound(this.Notes);
                for (xI1 = 1; xI1 <= loopTo; xI1++)
                {
                    if (this.Notes[xI1].TempMouseDown)
                    {
                        xITemp = xI1;
                        break;
                    }
                }

                var mouseVPosition = this.GetMouseVPosition(this.gSnap);

                {
                    ref var withBlock = ref this.Notes[xITemp];
                    if (this.bAdjustUpper && Conversions.ToBoolean(Operators.ConditionalCompareObjectLess(mouseVPosition, withBlock.VPosition, false)))
                    {
                        this.bAdjustUpper = false;
                        withBlock.VPosition += withBlock.Length;
                        withBlock.Length *= (double)-1;
                    }
                    else if (!this.bAdjustUpper && Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(mouseVPosition, withBlock.VPosition + withBlock.Length, false)))
                    {
                        this.bAdjustUpper = true;
                        withBlock.VPosition += withBlock.Length;
                        withBlock.Length *= (double)-1;
                    }

                    if (this.bAdjustUpper)
                    {
                        withBlock.Length = Conversions.ToDouble(Operators.SubtractObject(mouseVPosition, withBlock.VPosition));
                    }
                    else
                    {
                        withBlock.Length = Conversions.ToDouble(Operators.SubtractObject(withBlock.VPosition + withBlock.Length, mouseVPosition));
                        withBlock.VPosition = Conversions.ToDouble(mouseVPosition);
                    }

                    if (withBlock.VPosition < 0d)
                    {
                        withBlock.Length += withBlock.VPosition;
                        withBlock.VPosition = 0d;
                    }
                    if (withBlock.VPosition + withBlock.Length >= this.GetMaxVPosition())
                        withBlock.Length = this.GetMaxVPosition() - 1d - withBlock.VPosition;

                    if (this.SelectedNotes[0].LNPair == -1) // If new note
                    {
                        iBMSC.UndoRedo.LinkedURCmd xUndo = null;
                        iBMSC.UndoRedo.LinkedURCmd xRedo = null;
                        this.RedoAddNote(this.Notes[xITemp], ref xUndo, ref xRedo);
                        this.AddUndo(xUndo, xRedo, true);
                    }

                    else // If existing note
                    {
                        iBMSC.UndoRedo.LinkedURCmd xUndo = null;
                        iBMSC.UndoRedo.LinkedURCmd xRedo = null;
                        this.RedoLongNoteModify(this.SelectedNotes[0], withBlock.VPosition, withBlock.Length, ref xUndo, ref xRedo);
                        this.AddUndo(xUndo, xRedo, true);
                    }

                    this.SelectedColumn = withBlock.ColumnIndex;
                    this.TempVPosition = Conversions.ToDouble(mouseVPosition);
                    this.TempLength = withBlock.Length;

                }

                this.SortByVPositionInsertion();
                this.UpdatePairing();
                this.CalculateTotalPlayableNotes();

            }
        }

        private void OnSelectModeMoveNotes(MouseEventArgs e, long xHS, int xITemp)
        {
            var mouseVPosition = this.GetMouseVPosition(this.gSnap);
            if (this.DisableVerticalMove)
                mouseVPosition = (object)this.SelectedNotes[0].VPosition;
            var dVPosition = Operators.SubtractObject(mouseVPosition, this.Notes[xITemp].VPosition);  // delta VPosition

            var mouseColumn = default(int);
            int xI1 = 0;
            int mLeft = (int)Math.Round((float)e.X / this.gxWidth + (float)xHS); // horizontal position of the mouse
            if (mLeft >= 0)
            {
                do
                {
                    if (mLeft < this.nLeft(xI1 + 1) | xI1 >= this.gColumns)
                    {
                        mouseColumn = this.ColumnArrayIndexToEnabledColumnIndex(xI1);
                        break;
                    } // get the column where mouse is 
                    xI1 += 1;
                }
                while (true);
            }

            int dColumn = mouseColumn - this.ColumnArrayIndexToEnabledColumnIndex(this.Notes[xITemp].ColumnIndex); // get the enabled delta column where mouse is 

            // Ks cannot be beyond the left, the upper and the lower boundary
            mLeft = 0;
            double mVPosition = 0d;
            double muVPosition = 191999d;
            var loopTo = Information.UBound(this.Notes);
            for (xI1 = 1; xI1 <= loopTo; xI1++)
            {
                if (this.Notes[xI1].Selected)
                {
                    mLeft = Conversions.ToInteger(Interaction.IIf(this.ColumnArrayIndexToEnabledColumnIndex(this.Notes[xI1].ColumnIndex) + dColumn < mLeft, (object)(this.ColumnArrayIndexToEnabledColumnIndex(this.Notes[xI1].ColumnIndex) + dColumn), mLeft));
                    mVPosition = Conversions.ToDouble(Interaction.IIf(Conversions.ToBoolean(Operators.ConditionalCompareObjectLess(Operators.AddObject(this.Notes[xI1].VPosition, dVPosition), mVPosition, false)), Operators.AddObject(this.Notes[xI1].VPosition, dVPosition), mVPosition));
                    muVPosition = Conversions.ToDouble(Interaction.IIf(Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(Operators.AddObject(Operators.AddObject(this.Notes[xI1].VPosition, Interaction.IIf(this.NTInput, (object)this.Notes[xI1].Length, (object)0)), dVPosition), muVPosition, false)), Operators.AddObject(Operators.AddObject(this.Notes[xI1].VPosition, Interaction.IIf(this.NTInput, (object)this.Notes[xI1].Length, (object)0)), dVPosition), muVPosition));
                }
            }
            muVPosition -= 191999d;

            int xCol;
            double xVPos;

            iBMSC.UndoRedo.LinkedURCmd xUndo = null;
            iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
            var xBaseRedo = xRedo;

            // start moving
            var loopTo1 = Information.UBound(this.Notes);
            for (xI1 = 1; xI1 <= loopTo1; xI1++)
            {
                if (!this.Notes[xI1].Selected)
                    continue;

                xCol = this.EnabledColumnIndexToColumnArrayIndex(this.ColumnArrayIndexToEnabledColumnIndex(this.Notes[xI1].ColumnIndex) + dColumn - mLeft);
                xVPos = Conversions.ToDouble(Operators.SubtractObject(Operators.SubtractObject(Operators.AddObject(this.Notes[xI1].VPosition, dVPosition), mVPosition), muVPosition));
                this.RedoMoveNote(this.SelectedNotes[this.Notes[xI1].TempIndex], xCol, xVPos, ref xUndo, ref xRedo);

                this.Notes[xI1].ColumnIndex = xCol;
                this.Notes[xI1].VPosition = xVPos;
            }

            // If mouseColumn - uNotes(0).ColumnIndex - mLeft <> 0 Or mouseVPosition - uNotes(0).VPosition - mVPosition - muVPosition <> 0 Then
            this.AddUndo(xUndo, xBaseRedo.Next, this.uAdded);
            if (!this.uAdded)
                this.uAdded = true;

            // End If
        }

        private void UpdateSelectionBox(long xHS, long xVS, int xHeight)
        {
            var SelectionBox = new Rectangle(Conversions.ToInteger(Interaction.IIf(this.pMouseMove.X > this.LastMouseDownLocation.X, (object)this.LastMouseDownLocation.X, (object)this.pMouseMove.X)), Conversions.ToInteger(Interaction.IIf(this.pMouseMove.Y > this.LastMouseDownLocation.Y, (object)this.LastMouseDownLocation.Y, (object)this.pMouseMove.Y)), (int)Math.Round(Math.Abs(this.pMouseMove.X - this.LastMouseDownLocation.X)), (int)Math.Round(Math.Abs(this.pMouseMove.Y - this.LastMouseDownLocation.Y)));
            Rectangle NoteRect;

            int xI1;
            var loopTo = Information.UBound(this.Notes);
            for (xI1 = 1; xI1 <= loopTo; xI1++)
            {
                NoteRect = new Rectangle(this.HorizontalPositiontoDisplay(this.nLeft(this.Notes[xI1].ColumnIndex), xHS) + 1, this.NoteRowToPanelHeight(Conversions.ToDouble(Operators.AddObject(this.Notes[xI1].VPosition, Interaction.IIf(this.NTInput, (object)this.Notes[xI1].Length, (object)0))), xVS, xHeight) - this.vo.kHeight, (int)Math.Round((float)this.GetColumnWidth(this.Notes[xI1].ColumnIndex) * this.gxWidth - 2f), Conversions.ToInteger(Operators.AddObject(this.vo.kHeight, Interaction.IIf(this.NTInput, (object)(this.Notes[xI1].Length * (double)this.gxHeight), (object)0))));


                if (NoteRect.IntersectsWith(SelectionBox))
                {
                    this.Notes[xI1].Selected = !this.Notes[xI1].TempSelected & this.nEnabled(this.Notes[xI1].ColumnIndex);
                }
                else
                {
                    this.Notes[xI1].Selected = this.Notes[xI1].TempSelected & this.nEnabled(this.Notes[xI1].ColumnIndex);
                }
            }
        }

        private void DuplicateSelectedNotes(int tempNoteIndex, double dVPosition, int dColumn, int mLeft, double mVPosition, double muVPosition)
        {
            iBMSC.UndoRedo.LinkedURCmd xUndo = null;
            iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
            var xBaseRedo = xRedo;

            this.Notes[tempNoteIndex].Selected = true;

            int xSelectedNotesCount = 0;
            for (int i = 1, loopTo = Information.UBound(this.Notes); i <= loopTo; i++)
            {
                if (this.Notes[i].Selected)
                    xSelectedNotesCount += 1;
            }

            var xTempNotes = new iBMSC.Editor.Note[xSelectedNotesCount];
            int xI2 = 0;
            for (int i = 1, loopTo1 = Information.UBound(this.Notes); i <= loopTo1; i++)
            {
                if (!this.Notes[i].Selected)
                    continue;

                xTempNotes[xI2] = this.Notes[i];
                xTempNotes[xI2].ColumnIndex = this.EnabledColumnIndexToColumnArrayIndex(this.ColumnArrayIndexToEnabledColumnIndex(this.Notes[i].ColumnIndex) + dColumn - mLeft);
                xTempNotes[xI2].VPosition = this.Notes[i].VPosition + dVPosition - mVPosition - muVPosition;
                this.RedoAddNote(xTempNotes[xI2], ref xUndo, ref xRedo);

                this.Notes[i].Selected = false;
                xI2 += 1;
            }
            this.Notes[tempNoteIndex].TempMouseDown = false;

            // copy to K
            int xOrigUBound = Information.UBound(this.Notes);
            Array.Resize(ref this.Notes, xOrigUBound + xSelectedNotesCount + 1);
            xI2 = 0;
            for (int i = xOrigUBound + 1, loopTo2 = Information.UBound(this.Notes); i <= loopTo2; i++)
            {
                this.Notes[i] = xTempNotes[xI2];
                xI2 += 1;
            }

            this.AddUndo(xUndo, xBaseRedo.Next);
        }

        private void DrawNoteHoverHighlight(int iI, long xHS, long xVS, int xHeight, int foundNoteIndex)
        {
            int xDispX = this.HorizontalPositiontoDisplay(this.nLeft(this.Notes[foundNoteIndex].ColumnIndex), xHS);
            int xDispY = Conversions.ToInteger(Interaction.IIf(!this.NTInput | this.bAdjustLength & !this.bAdjustUpper, (object)(this.NoteRowToPanelHeight(this.Notes[foundNoteIndex].VPosition, xVS, xHeight) - this.vo.kHeight - 1), (object)(this.NoteRowToPanelHeight(this.Notes[foundNoteIndex].VPosition + this.Notes[foundNoteIndex].Length, xVS, xHeight) - this.vo.kHeight - 1)));
            int xDispW = (int)Math.Round((float)this.GetColumnWidth(this.Notes[foundNoteIndex].ColumnIndex) * this.gxWidth + 1f);
            int xDispH = Conversions.ToInteger(Interaction.IIf(!this.NTInput | this.bAdjustLength, (object)(this.vo.kHeight + 3), (object)(this.Notes[foundNoteIndex].Length * (double)this.gxHeight + (double)this.vo.kHeight + 3d)));

            var e1 = BufferedGraphicsManager.Current.Allocate(this.spMain[iI].CreateGraphics(), new Rectangle(xDispX, xDispY, xDispW, xDispH));
            e1.Graphics.FillRectangle(this.vo.Bg, new Rectangle(xDispX, xDispY, xDispW, xDispH));

            if (this.NTInput)
                this.DrawNoteNT(this.Notes[foundNoteIndex], e1, xHS, xVS, xHeight);
            else
                this.DrawNote(this.Notes[foundNoteIndex], e1, xHS, xVS, xHeight);

            e1.Graphics.DrawRectangle(Interaction.IIf(this.bAdjustLength, this.vo.kMouseOverE, this.vo.kMouseOver), xDispX, xDispY, (object)(xDispW - 1), (object)(xDispH - 1));

            e1.Render(this.spMain[iI].CreateGraphics());
            e1.Dispose();
        }

        private int GetColumnAtX(int x, int xHS)
        {
            int xI1 = 0;
            int mLeft = (int)Math.Round((float)x / this.gxWidth + (float)xHS); // horizontal position of the mouse
            int xColumn = 0;
            if (mLeft >= 0)
            {
                do
                {
                    if (mLeft < this.nLeft(xI1 + 1) | xI1 >= this.gColumns)
                    {
                        xColumn = xI1;
                        break;
                    } // get the column where mouse is 
                    xI1 += 1;
                }
                while (true);
            }

            return this.EnabledColumnIndexToColumnArrayIndex(this.ColumnArrayIndexToEnabledColumnIndex(xColumn));  // get the enabled column where mouse is 
        }

        private object GetColumnAtEvent(MouseEventArgs e, int xHS)
        {
            return GetColumnAtX(e.X, xHS);
        }

        // az: Handle zoom in/out. Should work with any of the three splitters.
        private void PMain_Scroll(object sender, MouseEventArgs e)
        {
            if (!iBMSC.My.MyProject.Computer.Keyboard.CtrlKeyDown)
                return;
            double dv = Math.Round((double)this.CGHeight2.Value + e.Delta / 120d);
            this.CGHeight2.Value = (int)Math.Round(Math.Min((double)this.CGHeight2.Maximum, Math.Max((double)this.CGHeight2.Minimum, dv)));
            this.CGHeight.Value = (decimal)((double)this.CGHeight2.Value / 4d);
        }


        private void PMainInMouseUp(object sender, MouseEventArgs e)
        {
            this.tempX = 0;
            this.tempY = 0;
            this.tempV = 0;
            this.tempH = 0;
            this.VSValue = -1;
            this.HSValue = -1;
            this.Timer1.Enabled = false;
            // KMouseDown = -1
            this.SelectedNotes = new iBMSC.Editor.Note[0];

            int iI = Conversions.ToInteger(sender.Tag);

            if (this.MiddleButtonClicked && e.Button == MouseButtons.Middle && Math.Pow((double)(this.MiddleButtonLocation.X - Cursor.Position.X), 2d) + Math.Pow((double)(this.MiddleButtonLocation.Y - Cursor.Position.Y), 2d) >= (double)this.vo.MiddleDeltaRelease)
            {
                this.MiddleButtonClicked = false;
            }

            if (this.TBSelect.Checked)
            {
                this.LastMouseDownLocation = new Point(-1, -1);
                this.pMouseMove = new Point(-1, -1);

                if (this.ctrlPressed & !this.DuplicatedSelectedNotes & !iBMSC.PanelKeyStates.ModifierMultiselectActive())
                {
                    for (int i = 1, loopTo = Information.UBound(this.Notes); i <= loopTo; i++)
                    {
                        if (this.Notes[i].TempMouseDown)
                        {
                            this.Notes[i].Selected = !this.Notes[i].Selected;
                            break;
                        }
                    }
                }

                this.ctrlPressed = false;
                this.DuplicatedSelectedNotes = false;
            }

            else if (this.TBWrite.Checked)
            {

                if (!this.NTInput & !this.tempFirstMouseDown)
                {
                    double xVPosition;


                    xVPosition = Conversions.ToDouble(Operators.DivideObject(Operators.SubtractObject(Operators.SubtractObject(Operators.SubtractObject(sender.Height, (float)this.PanelVScroll[iI] * this.gxHeight), e.Y), 1), this.gxHeight)); // VPosition of the mouse
                    if (this.gSnap)
                        xVPosition = this.SnapToGrid(xVPosition);

                    var xColumn = this.GetColumnAtEvent(e, this.PanelHScroll[iI]);

                    if (e.Button == MouseButtons.Left)
                    {
                        bool HiddenNote = iBMSC.PanelKeyStates.ModifierHiddenActive();
                        bool LongNote = iBMSC.PanelKeyStates.ModifierLongNoteActive();
                        bool Landmine = iBMSC.PanelKeyStates.ModifierLandmineActive();
                        iBMSC.UndoRedo.LinkedURCmd xUndo = null;
                        iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
                        var xBaseRedo = xRedo;

                        if (this.IsColumnNumeric(Conversions.ToInteger(xColumn)))
                        {
                            string xMessage = iBMSC.Strings.Messages.PromptEnterNumeric;
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(xColumn, MainWindow.niBPM, false)))
                                xMessage = iBMSC.Strings.Messages.PromptEnterBPM;
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(xColumn, MainWindow.niSTOP, false)))
                                xMessage = iBMSC.Strings.Messages.PromptEnterSTOP;
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(xColumn, MainWindow.niSCROLL, false)))
                                xMessage = iBMSC.Strings.Messages.PromptEnterSCROLL;

                            string valstr = Interaction.InputBox(xMessage, this.Text);
                            long value = (long)Math.Round(Conversion.Val(valstr) * 10000d);

                            if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(Operators.ConditionalCompareObjectEqual(xColumn, MainWindow.niSCROLL, false), valstr == "0"), value != 0L)))
                            {
                                for (int xI1 = 1, loopTo1 = Information.UBound(this.Notes); xI1 <= loopTo1; xI1++)
                                {
                                    if (this.Notes[xI1].VPosition == xVPosition && Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(this.Notes[xI1].ColumnIndex, xColumn, false)))
                                        this.RedoRemoveNote(this.Notes[xI1], ref xUndo, ref xRedo);
                                }

                                var n = new iBMSC.Editor.Note(Conversions.ToInteger(xColumn), xVPosition, value, Conversions.ToDouble(LongNote), HiddenNote);
                                this.RedoAddNote(n, ref xUndo, ref xRedo);
                                this.AddNote(n);

                                this.AddUndo(xUndo, xBaseRedo.Next);
                            }
                        }

                        else
                        {
                            int xValue = (this.LWAV.SelectedIndex + 1) * 10000;

                            for (int xI1 = 1, loopTo2 = Information.UBound(this.Notes); xI1 <= loopTo2; xI1++)
                            {
                                if (this.Notes[xI1].VPosition == xVPosition && Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(this.Notes[xI1].ColumnIndex, xColumn, false)))
                                    this.RedoRemoveNote(this.Notes[xI1], ref xUndo, ref xRedo);
                            }

                            var n = new iBMSC.Editor.Note(Conversions.ToInteger(xColumn), xVPosition, (long)xValue, Conversions.ToDouble(LongNote), HiddenNote, true, Landmine);

                            this.RedoAddNote(n, ref xUndo, ref xRedo);
                            this.AddNote(n);

                            this.AddUndo(xUndo, xRedo);
                        }
                    }
                }

                if (!this.ShouldDrawTempNote)
                    this.ShouldDrawTempNote = true;
                this.TempVPosition = (double)-1;
                this.SelectedColumn = -1;
            }
            this.CalculateGreatestVPosition();
            this.RefreshPanelAll();
        }

        private void PMainInMouseWheel(object sender, MouseEventArgs e)
        {
            if (this.MiddleButtonClicked)
                this.MiddleButtonClicked = false;

            int xI1;

            switch (this.spMouseOver)
            {
                case 0:
                    {
                        // xI1 = spV(iI) - Math.Sign(e.Delta) * VSL.SmallChange * 5 / gxHeight
                        xI1 = this.PanelVScroll[this.spMouseOver] - Math.Sign(e.Delta) * this.gWheel;
                        if (xI1 > 0)
                            xI1 = 0;
                        if (xI1 < this.LeftPanelScroll.Minimum)
                            xI1 = this.LeftPanelScroll.Minimum;
                        this.LeftPanelScroll.Value = xI1;
                        break;
                    }
                case 1:
                    {
                        // xI1 = spV(iI) - Math.Sign(e.Delta) * VS.SmallChange * 5 / gxHeight
                        xI1 = this.PanelVScroll[this.spMouseOver] - Math.Sign(e.Delta) * this.gWheel;
                        if (xI1 > 0)
                            xI1 = 0;
                        if (xI1 < this.MainPanelScroll.Minimum)
                            xI1 = this.MainPanelScroll.Minimum;
                        this.MainPanelScroll.Value = xI1;
                        break;
                    }
                case 2:
                    {
                        // xI1 = spV(iI) - Math.Sign(e.Delta) * VSR.SmallChange * 5 / gxHeight
                        xI1 = this.PanelVScroll[this.spMouseOver] - Math.Sign(e.Delta) * this.gWheel;
                        if (xI1 > 0)
                            xI1 = 0;
                        if (xI1 < this.RightPanelScroll.Minimum)
                            xI1 = this.RightPanelScroll.Minimum;
                        this.RightPanelScroll.Value = xI1;
                        break;
                    }
            }
        }

        private void PMainInPaint(object sender, PaintEventArgs e)
        {
            this.RefreshPanel(Conversions.ToInteger(sender.Tag), e.ClipRectangle);
        }
    }
}