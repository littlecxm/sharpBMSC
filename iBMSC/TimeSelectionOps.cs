using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace iBMSC
{

    public partial class MainWindow : Form
    {

        private void BVCCalculate_Click(object sender, EventArgs e)
        {
            if (!this.TBTimeSelect.Checked)
                return;

            this.SortByVPositionInsertion();
            BPMChangeByValue((int)Math.Round(Conversion.Val(this.TVCBPM.Text) * 10000d));

            this.SortByVPositionInsertion();
            this.UpdatePairing();
            this.RefreshPanelAll();
            this.POStatusRefresh();

            Interaction.Beep();
            this.TVCBPM.Focus();
        }

        private void BVCApply_Click(object sender, EventArgs e)
        {
            if (!this.TBTimeSelect.Checked)
                return;

            this.SortByVPositionInsertion();
            this.BPMChangeTop(Conversion.Val(this.TVCM.Text) / Conversion.Val(this.TVCD.Text));

            this.SortByVPositionInsertion();
            this.UpdatePairing();
            this.RefreshPanelAll();
            this.POStatusRefresh();
            this.CalculateGreatestVPosition();

            Interaction.Beep();
            this.TVCM.Focus();
            // Select Case spFocus
            // Case 0 : PMainInL.Focus()
            // Case 1 : PMainIn.Focus()
            // Case 2 : PMainInR.Focus()
            // End Select
        }

        private void BPMChangeTop(double xRatio, bool bAddUndo = true, bool bOverWriteUndo = false)
        {
            // Dim xUndo As String = vbCrLf
            // Dim xRedo As String = vbCrLf
            iBMSC.UndoRedo.LinkedURCmd xUndo = null;
            iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
            var xBaseRedo = xRedo;

            if (this.vSelLength == 0d)
                goto EndofSub;
            if (xRatio == 1d | xRatio <= 0d)
                goto EndofSub;

            double xVLower = Conversions.ToDouble(Interaction.IIf(this.vSelLength > 0d, (object)this.vSelStart, (object)(this.vSelStart + this.vSelLength)));
            double xVUpper = Conversions.ToDouble(Interaction.IIf(this.vSelLength < 0d, (object)this.vSelStart, (object)(this.vSelStart + this.vSelLength)));
            if (xVLower < 0d)
                xVLower = 0d;
            if (xVUpper >= this.GetMaxVPosition())
                xVUpper = this.GetMaxVPosition() - 1d;

            int xBPM = (int)this.Notes[0].Value;
            int xI1;
            int xI2;
            int xI3;

            int xValueL = xBPM;
            int xValueU = xBPM;

            // Save undo
            // For xI3 = 1 To UBound(K)
            // K(xI3).Selected = True
            // Next
            // xUndo = "KZ" & vbCrLf & _
            // sCmdKs(False) & vbCrLf & _
            // "SA_" & vSelStart & "_" & vSelLength & "_" & vSelHalf & "_1"

            this.RedoRemoveNoteAll(false, ref xUndo, ref xRedo);

            // Start
            if (!this.NTInput)
            {
                // Below Selection
                var loopTo = Information.UBound(this.Notes);
                for (xI1 = 1; xI1 <= loopTo; xI1++)
                {
                    if (this.Notes[xI1].VPosition > xVLower)
                        break;
                    if (this.Notes[xI1].ColumnIndex == MainWindow.niBPM)
                        xBPM = (int)this.Notes[xI1].Value;
                }
                xValueL = xBPM;
                xI2 = xI1;

                // Within Selection
                var loopTo1 = Information.UBound(this.Notes);
                for (xI1 = xI2; xI1 <= loopTo1; xI1++)
                {
                    if (this.Notes[xI1].VPosition > xVUpper)
                        break;
                    if (this.Notes[xI1].ColumnIndex == MainWindow.niBPM)
                    {
                        xBPM = (int)this.Notes[xI1].Value;
                        this.Notes[xI1].Value = (long)Math.Round((double)this.Notes[xI1].Value * xRatio);
                    }
                    this.Notes[xI1].VPosition = (this.Notes[xI1].VPosition - xVLower) * xRatio + xVLower;
                }
                xValueU = xBPM;
                xI2 = xI1;

                // Above Selection
                var loopTo2 = Information.UBound(this.Notes);
                for (xI1 = xI2; xI1 <= loopTo2; xI1++)
                    this.Notes[xI1].VPosition += (xRatio - 1d) * (xVUpper - xVLower);

                // Add BPMs
                this.AddNote(new iBMSC.Editor.Note(MainWindow.niBPM, xVLower, (long)Math.Round(xValueL * xRatio)), false, true, false);
                this.AddNote(new iBMSC.Editor.Note(MainWindow.niBPM, xVUpper + (xRatio - 1d) * (xVUpper - xVLower), (long)xValueU), false, true, false);
            }

            else
            {
                bool xAddBPML = true;
                bool xAddBPMU = true;

                var loopTo3 = Information.UBound(this.Notes);
                for (xI1 = 1; xI1 <= loopTo3; xI1++)
                {
                    // Modify notes
                    if (this.Notes[xI1].VPosition <= xVLower)
                    {
                        // check BPM
                        if (this.Notes[xI1].ColumnIndex == MainWindow.niBPM)
                        {
                            xValueL = (int)this.Notes[xI1].Value;
                            xValueU = (int)this.Notes[xI1].Value;
                            if (this.Notes[xI1].VPosition == xVLower)
                            {
                                xAddBPML = false;
                                this.Notes[xI1].Value = Conversions.ToLong(Interaction.IIf((double)this.Notes[xI1].Value * xRatio <= 655359999d, (object)((double)this.Notes[xI1].Value * xRatio), 655359999));
                            }
                        }

                        // If longnote then adjust length
                        if (this.Notes[xI1].VPosition + this.Notes[xI1].Length > xVLower)
                        {
                            // this.Notes[xI1].Length = Conversions.ToDouble(this.Notes[xI1].Length + Operators.MultiplyObject(Operators.SubtractObject(Interaction.IIf(xVUpper < this.Notes[xI1].VPosition + this.Notes[xI1].Length, xVUpper, (object)(this.Notes[xI1].VPosition + this.Notes[xI1].Length)), xVLower), xRatio - 1d));
                            // this.Notes[xI1].Length += (-xVLower) * (xRatio - 1);
                            var adj = Conversions.ToDouble(Interaction.IIf(
                                xVUpper < this.Notes[xI1].VPosition + this.Notes[xI1].Length,
                                xVUpper,
                                this.Notes[xI1].VPosition + this.Notes[xI1].Length
                                ));
                            this.Notes[xI1].Length += (adj - xVLower) * (xRatio - 1);
                        }
                    }

                    else if (this.Notes[xI1].VPosition <= xVUpper)
                    {
                        // check BPM
                        if (this.Notes[xI1].ColumnIndex == MainWindow.niBPM)
                        {
                            xValueU = (int)this.Notes[xI1].Value;
                            if (this.Notes[xI1].VPosition == xVUpper)
                                xAddBPMU = false;
                            else
                                this.Notes[xI1].Value = Conversions.ToLong(Interaction.IIf((double)this.Notes[xI1].Value * xRatio <= 655359999d, (object)((double)this.Notes[xI1].Value * xRatio), 655359999));
                        }

                        // Adjust Length
                        // this.Notes[xI1].Length = Conversions.ToDouble(this.Notes[xI1].Length + Operators.MultiplyObject(Operators.SubtractObject(Interaction.IIf(xVUpper < this.Notes[xI1].Length + this.Notes[xI1].VPosition, xVUpper, (object)(this.Notes[xI1].Length + this.Notes[xI1].VPosition)), this.Notes[xI1].VPosition), xRatio - 1d));
                        var adj = Conversions.ToDouble(Interaction.IIf(
                            xVUpper < this.Notes[xI1].Length + this.Notes[xI1].VPosition,
                            xVUpper,
                            this.Notes[xI1].Length + this.Notes[xI1].VPosition
                        ));
                        this.Notes[xI1].Length += (adj - this.Notes[xI1].VPosition) * (xRatio - 1);

                        // Adjust VPosition
                        this.Notes[xI1].VPosition = (this.Notes[xI1].VPosition - xVLower) * xRatio + xVLower;
                    }

                    else
                    {
                        this.Notes[xI1].VPosition += (xVUpper - xVLower) * (xRatio - 1d);
                    }
                }

                // Add BPMs
                if (xAddBPML)
                    this.AddNote(new iBMSC.Editor.Note(MainWindow.niBPM, xVLower, (long)Math.Round(xValueL * xRatio)), false, true, false);
                if (xAddBPMU)
                    this.AddNote(new iBMSC.Editor.Note(MainWindow.niBPM, (xVUpper - xVLower) * xRatio + xVLower, (long)xValueU), false, true, false);
            }

            // Check BPM Overflow
            var loopTo4 = Information.UBound(this.Notes);
            for (xI3 = 1; xI3 <= loopTo4; xI3++)
            {
                if (this.Notes[xI3].ColumnIndex == MainWindow.niBPM && this.Notes[xI3].Value < 1L)
                    this.Notes[xI3].Value = 1L;
            }

            this.RedoAddNoteAll(false, ref xUndo, ref xRedo);

            // Restore selection
            double pSelStart = this.vSelStart;
            double pSelLength = this.vSelLength;
            double pSelHalf = this.vSelHalf;
            if (this.vSelLength < 0d)
                this.vSelStart += (xRatio - 1d) * (xVUpper - xVLower);
            this.vSelLength = this.vSelLength * xRatio;
            this.vSelHalf = this.vSelHalf * xRatio;
            this.ValidateSelection();
            this.RedoChangeTimeSelection(pSelStart, pSelLength, pSelHalf, this.vSelStart, this.vSelLength, this.vSelHalf, true, ref xUndo, ref xRedo);

            // Save redo
            // For xI3 = 1 To UBound(K)
            // K(xI3).Selected = True
            // Next
            // xRedo = "KZ" & vbCrLf & _
            // sCmdKs(False) & vbCrLf & _
            // "SA_" & vSelStart & "_" & vSelLength & "_" & vSelHalf & "_1"

            // Restore note selection
            xVLower = Conversions.ToDouble(Interaction.IIf(this.vSelLength > 0d, (object)this.vSelStart, (object)(this.vSelStart + this.vSelLength)));
            xVUpper = Conversions.ToDouble(Interaction.IIf(this.vSelLength < 0d, (object)this.vSelStart, (object)(this.vSelStart + this.vSelLength)));
            if (!this.NTInput)
            {
                var loopTo5 = Information.UBound(this.Notes);
                for (xI3 = 1; xI3 <= loopTo5; xI3++)
                    this.Notes[xI3].Selected = this.Notes[xI3].VPosition >= xVLower & this.Notes[xI3].VPosition < xVUpper & this.nEnabled(this.Notes[xI3].ColumnIndex);
            }
            else
            {
                var loopTo6 = Information.UBound(this.Notes);
                for (xI3 = 1; xI3 <= loopTo6; xI3++)
                    this.Notes[xI3].Selected = this.Notes[xI3].VPosition < xVUpper & this.Notes[xI3].VPosition + this.Notes[xI3].Length >= xVLower & this.nEnabled(this.Notes[xI3].ColumnIndex);
            }

        EndofSub:
            ;

            if (bAddUndo)
                this.AddUndo(xUndo, xBaseRedo.Next, bOverWriteUndo);
        }

        private void BPMChangeHalf(double dVPosition, bool bAddUndo = true, bool bOverWriteUndo = false)
        {
            // Dim xUndo As String = vbCrLf
            // Dim xRedo As String = vbCrLf
            iBMSC.UndoRedo.LinkedURCmd xUndo = null;
            iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
            var xBaseRedo = xRedo;

            if (this.vSelLength == 0d)
                goto EndofSub;
            if (dVPosition == 0d)
                goto EndofSub;

            double xVLower = Conversions.ToDouble(Interaction.IIf(this.vSelLength > 0d, (object)this.vSelStart, (object)(this.vSelStart + this.vSelLength)));
            double xVHalf = this.vSelStart + this.vSelHalf;
            double xVUpper = Conversions.ToDouble(Interaction.IIf(this.vSelLength < 0d, (object)this.vSelStart, (object)(this.vSelStart + this.vSelLength)));
            if (dVPosition + xVHalf <= xVLower | dVPosition + xVHalf >= xVUpper)
                goto EndofSub;

            if (xVLower < 0d)
                xVLower = 0d;
            if (xVUpper >= this.GetMaxVPosition())
                xVUpper = this.GetMaxVPosition() - 1d;
            if (xVHalf > xVUpper)
                xVHalf = xVUpper;
            if (xVHalf < xVLower)
                xVHalf = xVLower;

            int xBPM = (int)this.Notes[0].Value;
            int xI1;
            int xI2;
            int xI3;

            int xValueL = xBPM;
            int xValueM = xBPM;
            int xValueU = xBPM;

            double xRatio1 = (xVHalf - xVLower + dVPosition) / (xVHalf - xVLower);
            double xRatio2 = (xVUpper - xVHalf - dVPosition) / (xVUpper - xVHalf);

            // Save undo
            // For xI3 = 1 To UBound(K)
            // K(xI3).Selected = True
            // Next
            // xUndo = "KZ" & vbCrLf & _
            // sCmdKs(False) & vbCrLf & _
            // "SA_" & vSelStart & "_" & vSelLength & "_" & vSelHalf & "_1"

            this.RedoRemoveNoteAll(false, ref xUndo, ref xRedo);

            if (!this.NTInput)
            {
                // Below Selection
                var loopTo = Information.UBound(this.Notes);
                for (xI1 = 1; xI1 <= loopTo; xI1++)
                {
                    if (this.Notes[xI1].VPosition > xVLower)
                        break;
                    if (this.Notes[xI1].ColumnIndex == MainWindow.niBPM)
                        xBPM = (int)this.Notes[xI1].Value;
                }
                xValueL = xBPM;
                xI2 = xI1;

                // Below Half
                var loopTo1 = Information.UBound(this.Notes);
                for (xI1 = xI2; xI1 <= loopTo1; xI1++)
                {
                    if (this.Notes[xI1].VPosition > xVHalf)
                        break;
                    if (this.Notes[xI1].ColumnIndex == MainWindow.niBPM)
                    {
                        xBPM = (int)this.Notes[xI1].Value;
                        this.Notes[xI1].Value = (long)Math.Round((double)this.Notes[xI1].Value * xRatio1);
                    }
                    this.Notes[xI1].VPosition = (this.Notes[xI1].VPosition - xVLower) * xRatio1 + xVLower;
                }
                xValueM = xBPM;
                xI2 = xI1;

                // Above Half
                var loopTo2 = Information.UBound(this.Notes);
                for (xI1 = xI2; xI1 <= loopTo2; xI1++)
                {
                    if (this.Notes[xI1].VPosition > xVUpper)
                        break;
                    if (this.Notes[xI1].ColumnIndex == MainWindow.niBPM)
                    {
                        xBPM = (int)this.Notes[xI1].Value;
                        this.Notes[xI1].Value = Conversions.ToLong(Interaction.IIf((double)this.Notes[xI1].Value * xRatio2 <= 655359999d, (object)((double)this.Notes[xI1].Value * xRatio2), 655359999));
                    }
                    this.Notes[xI1].VPosition = (this.Notes[xI1].VPosition - xVHalf) * xRatio2 + xVHalf + dVPosition;
                }
                xValueU = xBPM;
                xI2 = xI1;

                // Above Selection
                // For xI1 = xI2 To UBound(K)
                // K(xI1).VPosition += (xRatio - 1) * (xVUpper - xVLower)
                // Next

                // Add BPMs
                // az: cond. removed; 
                // IIf(xVHalf <> xVLower AndAlso xValueL * xRatio1 <= 655359999, xValueL * xRatio1, 655359999)
                this.AddNote(new iBMSC.Editor.Note(MainWindow.niBPM, xVLower, (long)Math.Round(xValueL * xRatio1)), false, true, false);
                // az: cond removed;
                // IIf(xVHalf <> xVUpper AndAlso xValueM * xRatio2 <= 655359999, xValueM * xRatio2, 655359999)
                this.AddNote(new iBMSC.Editor.Note(MainWindow.niBPM, xVHalf + dVPosition, (long)Math.Round(xValueM * xRatio2)), false, true, false);
                this.AddNote(new iBMSC.Editor.Note(MainWindow.niBPM, xVUpper, (long)xValueU), false, true, false);
            }

            else
            {
                bool xAddBPML = true;
                bool xAddBPMM = true;
                bool xAddBPMU = true;

                // Modify notes
                var loopTo3 = Information.UBound(this.Notes);
                for (xI1 = 1; xI1 <= loopTo3; xI1++)
                {
                    if (this.Notes[xI1].VPosition <= xVLower)
                    {
                        // check BPM
                        if (this.Notes[xI1].ColumnIndex == MainWindow.niBPM)
                        {
                            xValueL = (int)this.Notes[xI1].Value;
                            xValueM = (int)this.Notes[xI1].Value;
                            xValueU = (int)this.Notes[xI1].Value;
                            if (this.Notes[xI1].VPosition == xVLower)
                            {
                                xAddBPML = false;

                                // az: condition removed;
                                // IIf(xVHalf <> xVLower AndAlso Notes(xI1).Value * xRatio1 <= 655359999, Notes(xI1).Value * xRatio1, 655359999)
                                this.Notes[xI1].Value = (long)Math.Round((double)this.Notes[xI1].Value * xRatio1);
                            }
                        }

                        // If longnote then adjust length
                        double xEnd = this.Notes[xI1].VPosition + this.Notes[xI1].Length;
                        if (xEnd > xVUpper)
                        {
                        }
                        else if (xEnd > xVHalf)
                        {
                            this.Notes[xI1].Length = (xEnd - xVHalf) * xRatio2 + xVHalf + dVPosition - this.Notes[xI1].VPosition;
                        }
                        else if (xEnd > xVLower)
                        {
                            this.Notes[xI1].Length = (xEnd - xVLower) * xRatio1 + xVLower - this.Notes[xI1].VPosition;
                        }
                    }

                    else if (this.Notes[xI1].VPosition <= xVHalf)
                    {
                        // check BPM
                        if (this.Notes[xI1].ColumnIndex == MainWindow.niBPM)
                        {
                            xValueM = (int)this.Notes[xI1].Value;
                            xValueU = (int)this.Notes[xI1].Value;
                            if (this.Notes[xI1].VPosition == xVHalf)
                            {
                                xAddBPMM = false;
                                // az: cond. remove
                                // IIf(xVHalf <> xVUpper AndAlso Notes(xI1).Value * xRatio2 <= 655359999, Notes(xI1).Value * xRatio2, 655359999)
                                this.Notes[xI1].Value = (long)Math.Round((double)this.Notes[xI1].Value * xRatio2);
                            }
                            else
                            {
                                // az: cond. remove
                                // IIf(Notes(xI1).Value * xRatio1 <= 655359999, Notes(xI1).Value * xRatio1, 655359999)
                                this.Notes[xI1].Value = (long)Math.Round((double)this.Notes[xI1].Value * xRatio1);
                            }
                        }

                        // Adjust Length
                        double xEnd = this.Notes[xI1].VPosition + this.Notes[xI1].Length;
                        if (xEnd > xVUpper)
                        {
                            this.Notes[xI1].Length = xEnd - xVLower - (this.Notes[xI1].VPosition - xVLower) * xRatio1;
                        }
                        else if (xEnd > xVHalf)
                        {
                            this.Notes[xI1].Length = (xVHalf - this.Notes[xI1].VPosition) * xRatio1 + (xEnd - xVHalf) * xRatio2;
                        }
                        else
                        {
                            this.Notes[xI1].Length *= xRatio1;
                        }

                        // Adjust VPosition
                        this.Notes[xI1].VPosition = (this.Notes[xI1].VPosition - xVLower) * xRatio1 + xVLower;
                    }

                    else if (this.Notes[xI1].VPosition <= xVUpper)
                    {
                        // check BPM
                        if (this.Notes[xI1].ColumnIndex == MainWindow.niBPM)
                        {
                            xValueU = (int)this.Notes[xI1].Value;
                            if (this.Notes[xI1].VPosition == xVUpper)
                                xAddBPMU = false;
                            else
                                this.Notes[xI1].Value = Conversions.ToLong(Interaction.IIf((double)this.Notes[xI1].Value * xRatio2 <= 655359999d, (object)((double)this.Notes[xI1].Value * xRatio2), 655359999));
                        }

                        // Adjust Length
                        double xEnd = this.Notes[xI1].VPosition + this.Notes[xI1].Length;
                        if (xEnd > xVUpper)
                        {
                            this.Notes[xI1].Length = (xVUpper - this.Notes[xI1].VPosition) * xRatio2 + xEnd - xVUpper;
                        }
                        else
                        {
                            this.Notes[xI1].Length *= xRatio2;
                        }

                        // Adjust VPosition
                        this.Notes[xI1].VPosition = (this.Notes[xI1].VPosition - xVHalf) * xRatio2 + xVHalf + dVPosition;

                        // Else
                        // K(xI1).VPosition += (xVUpper - xVLower) * (xRatio - 1)
                    }
                }

                // Add BPMs
                // IIf(xVHalf <> xVLower AndAlso xValueL * xRatio1 <= 655359999, xValueL * xRatio1, 655359999)
                if (xAddBPML)
                    this.AddNote(new iBMSC.Editor.Note(MainWindow.niBPM, xVLower, (long)Math.Round(xValueL * xRatio1)), false, true, false);
                // IIf(xVHalf <> xVUpper AndAlso xValueM * xRatio2 <= 655359999, xValueM * xRatio2, 655359999)
                if (xAddBPMM)
                    this.AddNote(new iBMSC.Editor.Note(MainWindow.niBPM, xVHalf + dVPosition, (long)Math.Round(xValueM * xRatio2)), false, true, false);
                if (xAddBPMU)
                    this.AddNote(new iBMSC.Editor.Note(MainWindow.niBPM, xVUpper, (long)xValueU), false, true, false);
            }

            // Check BPM Overflow
            // For xI3 = 1 To UBound(Notes)
            // If Notes(xI3).ColumnIndex = niBPM Then
            // If Notes(xI3).Value > 655359999 Then Notes(xI3).Value = 655359999
            // If Notes(xI3).Value < 1 Then Notes(xI3).Value = 1
            // End If
            // Next

            // Restore selection
            // If vSelLength < 0 Then vSelStart += (xRatio - 1) * (xVUpper - xVLower)
            // vSelLength = vSelLength * xRatio
            double pSelHalf = this.vSelHalf;
            this.vSelHalf += dVPosition;
            this.ValidateSelection();
            this.RedoChangeTimeSelection(this.vSelStart, this.vSelLength, pSelHalf, this.vSelStart, this.vSelStart, this.vSelHalf, true, ref xUndo, ref xRedo);

            this.RedoAddNoteAll(false, ref xUndo, ref xRedo);


            // Restore note selection
            xVLower = Conversions.ToDouble(Interaction.IIf(this.vSelLength > 0d, (object)this.vSelStart, (object)(this.vSelStart + this.vSelLength)));
            xVUpper = Conversions.ToDouble(Interaction.IIf(this.vSelLength < 0d, (object)this.vSelStart, (object)(this.vSelStart + this.vSelLength)));
            if (!this.NTInput)
            {
                var loopTo4 = Information.UBound(this.Notes);
                for (xI3 = 1; xI3 <= loopTo4; xI3++)
                    this.Notes[xI3].Selected = this.Notes[xI3].VPosition >= xVLower & this.Notes[xI3].VPosition < xVUpper & this.nEnabled(this.Notes[xI3].ColumnIndex);
            }
            else
            {
                var loopTo5 = Information.UBound(this.Notes);
                for (xI3 = 1; xI3 <= loopTo5; xI3++)
                    this.Notes[xI3].Selected = this.Notes[xI3].VPosition < xVUpper & this.Notes[xI3].VPosition + this.Notes[xI3].Length >= xVLower & this.nEnabled(this.Notes[xI3].ColumnIndex);
            }

        EndofSub:
            ;

            if (bAddUndo)
                this.AddUndo(xUndo, xBaseRedo.Next, bOverWriteUndo);
        }

        private void BPMChangeByValue(int xValue)
        {
            // Dim xUndo As String = vbCrLf
            // Dim xRedo As String = vbCrLf
            iBMSC.UndoRedo.LinkedURCmd xUndo = null;
            iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
            var xBaseRedo = xRedo;

            if (this.vSelLength == 0d)
                return;

            double xVLower = Conversions.ToDouble(Interaction.IIf(this.vSelLength > 0d, (object)this.vSelStart, (object)(this.vSelStart + this.vSelLength)));
            double xVHalf = this.vSelStart + this.vSelHalf;
            double xVUpper = Conversions.ToDouble(Interaction.IIf(this.vSelLength < 0d, (object)this.vSelStart, (object)(this.vSelStart + this.vSelLength)));
            if (xVHalf == xVUpper)
                xVHalf = xVLower;
            // If dVPosition + xVHalf <= xVLower Or dVPosition + xVHalf >= xVUpper Then GoTo EndofSub

            if (xVLower < 0d)
                xVLower = 0d;
            if (xVUpper >= this.GetMaxVPosition())
                xVUpper = this.GetMaxVPosition() - 1d;
            if (xVHalf > xVUpper)
                xVHalf = xVUpper;
            if (xVHalf < xVLower)
                xVHalf = xVLower;

            long xBPM = this.Notes[0].Value;
            int xI1;
            int xI2;
            int xI3;

            double xConstBPM = 0d;

            // Below Selection
            var loopTo = Information.UBound(this.Notes);
            for (xI1 = 1; xI1 <= loopTo; xI1++)
            {
                if (this.Notes[xI1].VPosition > xVLower)
                    break;
                if (this.Notes[xI1].ColumnIndex == MainWindow.niBPM)
                    xBPM = this.Notes[xI1].Value;
            }
            xI2 = xI1;
            var xVPos = new double[] { xVLower };
            var xVal = new long[] { xBPM };

            // Within Selection
            int xU = 0;
            var loopTo1 = Information.UBound(this.Notes);
            for (xI1 = xI2; xI1 <= loopTo1; xI1++)
            {
                if (this.Notes[xI1].VPosition > xVUpper)
                    break;

                if (this.Notes[xI1].ColumnIndex == MainWindow.niBPM)
                {
                    xU = Information.UBound(xVPos) + 1;
                    Array.Resize(ref xVPos, xU + 1);
                    Array.Resize(ref xVal, xU + 1);
                    xVPos[xU] = this.Notes[xI1].VPosition;
                    xVal[xU] = this.Notes[xI1].Value;
                }
            }
            Array.Resize(ref xVPos, xU + 1 + 1);
            xVPos[xU + 1] = xVUpper;

            // Calculate Constant BPM
            var loopTo2 = xU;
            for (xI1 = 0; xI1 <= loopTo2; xI1++)
                xConstBPM += (xVPos[xI1 + 1] - xVPos[xI1]) / xVal[xI1];
            xConstBPM = (xVUpper - xVLower) / xConstBPM;

            // Compare BPM        '(xVHalf - xVLower) / xValue + (xVUpper - xVHalf) / xResult = (xVUpper - xVLower) / xConstBPM
            if ((xVUpper - xVLower) / xConstBPM <= (xVHalf - xVLower) / xValue)
            {
                double Limit = (xVHalf - xVLower) * xConstBPM / (xVUpper - xVLower) / 10000d;
                Interaction.MsgBox("Please enter a value that is greater than " + Limit + ".", MsgBoxStyle.Critical, iBMSCStrings.Messages.Err);
                return;
            }
            double xTempDivider = xConstBPM * (xVHalf - xVLower) - xValue * (xVUpper - xVLower);

            // az: I want to allow negative values, maybe...
            if (xTempDivider == 0d)
            {
                return; // nullop this
            }

            // apply div. by 10k to nullify mult. caused by divider being divided by 10k
            double xResult = (xVHalf - xVUpper) * xValue / xTempDivider * xConstBPM; // order here is important to avoid an overflow

            this.RedoRemoveNoteAll(false, ref xUndo, ref xRedo);

            // Adjust note
            if (!this.NTInput)
            {
                // Below Selection
                var loopTo3 = Information.UBound(this.Notes);
                for (xI1 = 1; xI1 <= loopTo3; xI1++)
                {
                    if (this.Notes[xI1].VPosition > xVLower)
                        break;
                }
                xI2 = xI1;
                if (xI2 > Information.UBound(this.Notes))
                    goto EndOfAdjustment;

                // Within Selection
                double xTempTime;
                double xTempVPos;
                var loopTo4 = Information.UBound(this.Notes);
                for (xI1 = xI2; xI1 <= loopTo4; xI1++)
                {
                    if (this.Notes[xI1].VPosition >= xVUpper)
                        break;
                    xTempTime = 0d;

                    xTempVPos = this.Notes[xI1].VPosition;
                    var loopTo5 = xU;
                    for (xI3 = 0; xI3 <= loopTo5; xI3++)
                    {
                        if (xTempVPos < xVPos[xI3 + 1])
                            break;
                        xTempTime += (xVPos[xI3 + 1] - xVPos[xI3]) / xVal[xI3];
                    }
                    xTempTime += (xTempVPos - xVPos[xI3]) / xVal[xI3];

                    if (xTempTime - (xVHalf - xVLower) / xValue > 0d)
                    {
                        this.Notes[xI1].VPosition = (xTempTime - (xVHalf - xVLower) / xValue) * xResult + xVHalf;
                    }
                    else
                    {
                        this.Notes[xI1].VPosition = xTempTime * xValue + xVLower;
                    }
                }
            }

            else
            {
                double xTempTime;
                double xTempVPos;
                var xTempEnd = default(double);

                var loopTo6 = Information.UBound(this.Notes);
                for (xI1 = 1; xI1 <= loopTo6; xI1++)
                {
                    if (Conversions.ToBoolean(this.Notes[xI1].Length))
                        xTempEnd = this.Notes[xI1].VPosition + this.Notes[xI1].Length;

                    if (this.Notes[xI1].VPosition > xVLower & this.Notes[xI1].VPosition < xVUpper)
                    {
                        xTempTime = 0d;

                        xTempVPos = this.Notes[xI1].VPosition;
                        var loopTo7 = xU;
                        for (xI3 = 0; xI3 <= loopTo7; xI3++)
                        {
                            if (xTempVPos < xVPos[xI3 + 1])
                                break;
                            xTempTime += (xVPos[xI3 + 1] - xVPos[xI3]) / xVal[xI3];
                        }
                        xTempTime += (xTempVPos - xVPos[xI3]) / xVal[xI3];

                        if (xTempTime - (xVHalf - xVLower) / xValue > 0d)
                        {
                            this.Notes[xI1].VPosition = (xTempTime - (xVHalf - xVLower) / xValue) * xResult + xVHalf;
                        }
                        else
                        {
                            this.Notes[xI1].VPosition = xTempTime * xValue + xVLower;
                        }
                    }

                    if (Conversions.ToBoolean(this.Notes[xI1].Length))
                    {
                        if (xTempEnd > xVLower & xTempEnd < xVUpper)
                        {
                            xTempTime = 0d;

                            var loopTo8 = xU;
                            for (xI3 = 0; xI3 <= loopTo8; xI3++)
                            {
                                if (xTempEnd < xVPos[xI3 + 1])
                                    break;
                                xTempTime += (xVPos[xI3 + 1] - xVPos[xI3]) / xVal[xI3];
                            }
                            xTempTime += (xTempEnd - xVPos[xI3]) / xVal[xI3];

                            if (xTempTime - (xVHalf - xVLower) / xValue > 0d)
                            {
                                this.Notes[xI1].Length = (xTempTime - (xVHalf - xVLower) / xValue) * xResult + xVHalf - this.Notes[xI1].VPosition;
                            }
                            else
                            {
                                this.Notes[xI1].Length = xTempTime * xValue + xVLower - this.Notes[xI1].VPosition;
                            }
                        }

                        else
                        {
                            this.Notes[xI1].Length = xTempEnd - this.Notes[xI1].VPosition;
                        }
                    }

                }
            }

        EndOfAdjustment:
            ;


            // Delete BPMs
            xI1 = 1;
            while (xI1 <= Information.UBound(this.Notes))
            {
                if (this.Notes[xI1].VPosition > xVUpper)
                    break;
                if (this.Notes[xI1].VPosition >= xVLower & this.Notes[xI1].ColumnIndex == MainWindow.niBPM)
                {
                    var loopTo9 = Information.UBound(this.Notes);
                    for (xI3 = xI1 + 1; xI3 <= loopTo9; xI3++)
                        this.Notes[xI3 - 1] = this.Notes[xI3];
                    Array.Resize(ref this.Notes, Information.UBound(this.Notes));
                }
                else
                {
                    xI1 += 1;
                }
            }

            // Add BPMs
            Array.Resize(ref this.Notes, Information.UBound(this.Notes) + 2 + 1);
            {
                ref var withBlock = ref this.Notes[Information.UBound(this.Notes) - 1];
                withBlock.ColumnIndex = MainWindow.niBPM;
                withBlock.VPosition = xVHalf;
                withBlock.Value = (long)Math.Round(xResult);
            }
            {
                ref var withBlock1 = ref this.Notes[Information.UBound(this.Notes)];
                withBlock1.ColumnIndex = MainWindow.niBPM;
                withBlock1.VPosition = xVUpper;
                withBlock1.Value = xVal[xU];
            }
            if (xVLower != xVHalf)
            {
                Array.Resize(ref this.Notes, Information.UBound(this.Notes) + 1 + 1);
                {
                    ref var withBlock2 = ref this.Notes[Information.UBound(this.Notes)];
                    withBlock2.ColumnIndex = MainWindow.niBPM;
                    withBlock2.VPosition = xVLower;
                    withBlock2.Value = (long)xValue;
                }
            }

            // Save redo
            // For xI3 = 1 To UBound(K)
            // K(xI3).Selected = True
            // Next
            // xRedo = "KZ" & vbCrLf & _
            // sCmdKs(False) & vbCrLf & _
            // "SA_" & vSelStart & "_" & vSelLength & "_" & vSelHalf & "_1"
            this.RedoAddNoteAll(false, ref xUndo, ref xRedo);

            // Restore note selection
            xVLower = Conversions.ToDouble(Interaction.IIf(this.vSelLength > 0d, (object)this.vSelStart, (object)(this.vSelStart + this.vSelLength)));
            xVUpper = Conversions.ToDouble(Interaction.IIf(this.vSelLength < 0d, (object)this.vSelStart, (object)(this.vSelStart + this.vSelLength)));
            if (!this.NTInput)
            {
                var loopTo10 = Information.UBound(this.Notes);
                for (xI3 = 1; xI3 <= loopTo10; xI3++)
                    this.Notes[xI3].Selected = this.Notes[xI3].VPosition >= xVLower & this.Notes[xI3].VPosition < xVUpper & this.nEnabled(this.Notes[xI3].ColumnIndex);
            }
            else
            {
                var loopTo11 = Information.UBound(this.Notes);
                for (xI3 = 1; xI3 <= loopTo11; xI3++)
                    this.Notes[xI3].Selected = this.Notes[xI3].VPosition < xVUpper & this.Notes[xI3].VPosition + this.Notes[xI3].Length >= xVLower & this.nEnabled(this.Notes[xI3].ColumnIndex);
            }

            // EndofSub:
            this.AddUndo(xUndo, xBaseRedo.Next);
        }

        private void ConvertAreaToStop()
        {
            iBMSC.UndoRedo.LinkedURCmd xUndo = null;
            iBMSC.UndoRedo.LinkedURCmd xRedo = new iBMSC.UndoRedo.Void();
            var xBaseRedo = xRedo;

            if (this.vSelLength == 0d)
                return;

            double xVLower = Conversions.ToDouble(Interaction.IIf(this.vSelLength > 0d, (object)this.vSelStart, (object)(this.vSelStart + this.vSelLength)));
            double xVUpper = Conversions.ToDouble(Interaction.IIf(this.vSelLength < 0d, (object)this.vSelStart, (object)(this.vSelStart + this.vSelLength)));

            var notesInRange = from note in this.Notes
                               where note.VPosition > xVLower & note.VPosition <= xVUpper
                               select note;

            if (notesInRange.Count() > 0)
            {
                MessageBox.Show("The selected area can't have notes anywhere but at the start.");
                return;
            }

            this.RedoRemoveNoteAll(false, ref xUndo, ref xRedo);

            // Translate notes
            for (int I = 1, loopTo = Information.UBound(this.Notes); I <= loopTo; I++)
            {
                if (this.Notes[I].VPosition > xVUpper)
                {
                    this.Notes[I].VPosition -= this.vSelLength;
                }
            }

            // Add Stop
            Array.Resize(ref this.Notes, Information.UBound(this.Notes) + 1 + 1);
            {
                ref var withBlock = ref this.Notes[Information.UBound(this.Notes)];
                withBlock.ColumnIndex = MainWindow.niSTOP;
                withBlock.VPosition = xVLower;
                withBlock.Value = (long)Math.Round(this.vSelLength * 10000d);
            }

            this.RedoAddNoteAll(false, ref xUndo, ref xRedo);

            this.AddUndo(xUndo, xBaseRedo.Next);

        }

        private void BConvertStop_Click(object sender, EventArgs e)
        {
            this.SortByVPositionInsertion();
            ConvertAreaToStop();

            this.SortByVPositionInsertion();
            this.UpdatePairing();
            this.RefreshPanelAll();
            this.POStatusRefresh();

            Interaction.Beep();
            this.TVCBPM.Focus();
        }

        private void Unload(object sender, EventArgs e) => Unload();

    }
}