using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using iBMSC.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace iBMSC;

[DesignerGenerated]
public partial  class dgMyO2 : Form
{
    public struct Adj
    {
        public int Measure;

        public int ColumnIndex;

        public string ColumnName;

        public string Grid;

        public bool LongNote;

        public bool Hidden;

        public bool AdjTo64;

        public int D64;

        public int D48;
    }

    private Adj[] Aj;

    private void fMyO2_Load(object sender, EventArgs e)
    {
        Font = MyProject.Forms.MainWindow.Font;
        vBPM.Value = MyProject.Forms.MainWindow.THBPM.Value;
    }

    private void AddAdjItem(Adj xAj, int Index)
    {
        lResult.Rows.Add();
        int rowIndex = checked(lResult.Rows.Count - 1);
        lResult[0, rowIndex].Value = Index;
        lResult[1, rowIndex].Value = xAj.Measure;
        lResult[2, rowIndex].Value = xAj.ColumnName;
        lResult[3, rowIndex].Value = xAj.Grid;
        lResult[4, rowIndex].Value = xAj.LongNote;
        lResult[5, rowIndex].Value = xAj.Hidden;
        lResult[6, rowIndex].Value = xAj.AdjTo64;
        lResult[7, rowIndex].Value = xAj.D64;
        lResult[8, rowIndex].Value = xAj.D48;
    }

    private void bApply1_Click(object sender, EventArgs e)
    {
        MyProject.Forms.MainWindow.MyO2ConstBPM(Convert.ToInt32(decimal.Multiply(vBPM.Value, new decimal(10000L))));
    }

    private void bApply2_Click(object sender, EventArgs e)
    {
        string[] array = MyProject.Forms.MainWindow.MyO2GridCheck();
        checked
        {
            Aj = new Adj[Information.UBound(array) + 1];
            lResult.Rows.Clear();
            int num = Information.UBound(Aj);
            for (int i = 0; i <= num; i++)
            {
                string[] array2 = Microsoft.VisualBasic.Strings.Split(array[i], "_");
                Adj[] aj = Aj;
                int num2 = i;
                aj[num2].Measure = (int)Math.Round(Conversion.Val(array2[0]));
                aj[num2].ColumnIndex = (int)Math.Round(Conversion.Val(array2[1]));
                aj[num2].ColumnName = array2[2];
                aj[num2].Grid = array2[3];
                aj[num2].LongNote = Conversion.Val(array2[4]) != 0.0;
                aj[num2].Hidden = Conversion.Val(array2[5]) != 0.0;
                aj[num2].AdjTo64 = Conversion.Val(array2[6]) != 0.0;
                aj[num2].D64 = (int)Math.Round(Conversion.Val(array2[7]));
                aj[num2].D48 = (int)Math.Round(Conversion.Val(array2[8]));
                AddAdjItem(Aj[i], i);
            }
        }
    }

    private void bApply3_Click(object sender, EventArgs e)
    {
        MyProject.Forms.MainWindow.MyO2GridAdjust(Aj);
    }

    public dgMyO2()
    {
        base.Load += fMyO2_Load;
        Aj = new Adj[0];
        InitializeComponent();
    }

    private void lResult_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 6 && e.RowIndex >= 0)
        {
            Aj[checked((int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(lResult[0, e.RowIndex].Value))))].AdjTo64 = Conversions.ToBoolean(lResult[6, e.RowIndex].Value);
        }
    }
}
