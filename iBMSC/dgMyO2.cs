using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using iBMSC.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace iBMSC;

[DesignerGenerated]
public partial class dgMyO2 : Form
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
        var rowIndex = lResult.Rows.Count - 1;
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
        MyProject.Forms.MainWindow.MyO2ConstBPM(Convert.ToInt32(decimal.Multiply(vBPM.Value, 10000m)));
    }

    private void bApply2_Click(object sender, EventArgs e)
    {
        var array = MyProject.Forms.MainWindow.MyO2GridCheck();

        Aj = new Adj[Information.UBound(array) + 1];
        lResult.Rows.Clear();
        var num = Information.UBound(Aj);
        for (var i = 0; i <= num; i++)
        {
            var array2 = Microsoft.VisualBasic.Strings.Split(array[i], "_");
            var aj = Aj;
            aj[i].Measure = (int)Math.Round(Conversion.Val(array2[0]));
            aj[i].ColumnIndex = (int)Math.Round(Conversion.Val(array2[1]));
            aj[i].ColumnName = array2[2];
            aj[i].Grid = array2[3];
            aj[i].LongNote = Conversion.Val(array2[4]) != 0.0;
            aj[i].Hidden = Conversion.Val(array2[5]) != 0.0;
            aj[i].AdjTo64 = Conversion.Val(array2[6]) != 0.0;
            aj[i].D64 = (int)Math.Round(Conversion.Val(array2[7]));
            aj[i].D48 = (int)Math.Round(Conversion.Val(array2[8]));
            AddAdjItem(Aj[i], i);
        }
    }

    private void bApply3_Click(object sender, EventArgs e)
    {
        MyProject.Forms.MainWindow.MyO2GridAdjust(Aj);
    }

    public dgMyO2()
    {
        base.Load += fMyO2_Load;
        Aj = Array.Empty<Adj>();
        InitializeComponent();
    }

    private void lResult_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 6 && e.RowIndex >= 0)
        {
            Aj[(int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(lResult[0, e.RowIndex].Value)))].AdjTo64 = Conversions.ToBoolean(lResult[6, e.RowIndex].Value);
        }
    }
}
