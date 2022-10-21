using System;
using System.Collections;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using iBMSC.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace iBMSC;

[DesignerGenerated]
public partial class diagFind : Form
{
    private int bCol;

    private string msg1;

    private string msg2;

    public diagFind(int xbCol, string xmsg1, string xmsg2)
    {
        Load += diagFind_Load;
        bCol = 46;
        msg1 = "Error";
        msg2 = "Invalid label.";
        InitializeComponent();
        bCol = xbCol;
        msg1 = xmsg1;
        msg2 = xmsg2;
    }

    private void CloseDialog(object sender, EventArgs e)
    {
        Close();
    }

    private void BSAll_Click(object sender, EventArgs e)
    {
        var enumerator = default(IEnumerator);
        try
        {
            enumerator = Panel1.Controls.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var checkBox = (CheckBox)enumerator.Current;
                checkBox.Checked = true;
            }
        }
        finally
        {
            if (enumerator is IDisposable)
            {
                (enumerator as IDisposable).Dispose();
            }
        }
    }

    private void BSInv_Click(object sender, EventArgs e)
    {
        var enumerator = default(IEnumerator);
        try
        {
            enumerator = Panel1.Controls.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var checkBox = (CheckBox)enumerator.Current;
                checkBox.Checked = !checkBox.Checked;
            }
        }
        finally
        {
            if (enumerator is IDisposable)
            {
                (enumerator as IDisposable).Dispose();
            }
        }
    }

    private void BSNone_Click(object sender, EventArgs e)
    {
        var enumerator = default(IEnumerator);
        try
        {
            enumerator = Panel1.Controls.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var checkBox = (CheckBox)enumerator.Current;
                checkBox.Checked = false;
            }
        }
        finally
        {
            if (enumerator is IDisposable)
            {
                (enumerator as IDisposable).Dispose();
            }
        }
    }

    private void diagFind_Load(object sender, EventArgs e)
    {
        Font = MyProject.Forms.MainWindow.Font;
        var font = new Font(Font, FontStyle.Bold);
        TBSelect.Font = font;
        Label8.Font = font;
        Label9.Font = font;
        Text = MyProject.Forms.MainWindow.TBFind.Text;
        Label1.Text = Strings1.fFind.NoteRange;
        Label2.Text = Strings1.fFind.MeasureRange;
        Label3.Text = Strings1.fFind.LabelRange;
        Label4.Text = Strings1.fFind.ValueRange;
        Label5.Text = Strings1.fFind.to_;
        Label6.Text = Strings1.fFind.to_;
        Label7.Text = Strings1.fFind.to_;
        cbx1.Text = Strings1.fFind.Selected;
        cbx2.Text = Strings1.fFind.UnSelected;
        cbx3.Text = Strings1.fFind.ShortNote;
        cbx4.Text = Strings1.fFind.LongNote;
        cbx5.Text = Strings1.fFind.Hidden;
        cbx6.Text = Strings1.fFind.Visible;
        Label8.Text = Strings1.fFind.Column;
        BSAll.Text = Strings1.fFind.SelectAll;
        BSInv.Text = Strings1.fFind.SelectInverse;
        BSNone.Text = Strings1.fFind.UnselectAll;
        Label9.Text = Strings1.fFind.Operation;
        TBrl.Text = Strings1.fFind.ReplaceWithLabel;
        TBrv.Text = Strings1.fFind.ReplaceWithValue;
        TBSelect.Text = Strings1.fFind.Select_;
        TBUnselect.Text = Strings1.fFind.Unselect_;
        TBDelete.Text = Strings1.fFind.Delete_;
        TBClose.Text = Strings1.fFind.Close_;
        var num = bCol;

        for (var i = 27; i <= num; i++)
        {
            var checkBox = new CheckBox();
            var checkBox2 = checkBox;
            checkBox2.Appearance = Appearance.Button;
            checkBox2.Checked = true;
            checkBox2.FlatStyle = FlatStyle.System;
            var checkBox3 = checkBox2;
            var location = new Point((i - 26) % 8 * 35 + 3, (i - 26) / 8 * 25 + 103);
            checkBox3.Location = location;
            var checkBox4 = checkBox2;
            var size = new Size(35, 25);
            checkBox4.Size = size;
            checkBox2.Tag = i;
            checkBox2.Text = "B" + (i - 25);
            checkBox2.TextAlign = ContentAlignment.MiddleCenter;
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2 = null;
            Panel1.Controls.Add(checkBox);
        }

        lr1.KeyDown += lblKeyDown;
        lr2.KeyDown += lblKeyDown;
        Ttl.KeyDown += lblKeyDown;
    }

    private bool ValidLabel(string xStr)
    {
        xStr = Microsoft.VisualBasic.Strings.UCase(Microsoft.VisualBasic.Strings.Trim(xStr));
        if (Microsoft.VisualBasic.Strings.Len(xStr) == 0)
        {
            return false;
        }
        if ((Operators.CompareString(xStr, "00", TextCompare: false) == 0) | (Operators.CompareString(xStr, "0", TextCompare: false) == 0))
        {
            return false;
        }
        if ((Microsoft.VisualBasic.Strings.Len(xStr) != 1) & (Microsoft.VisualBasic.Strings.Len(xStr) != 2))
        {
            return false;
        }
        var num = Microsoft.VisualBasic.Strings.Asc(Microsoft.VisualBasic.Strings.Mid(xStr, 1, 1));
        if (!(num is >= 48 and <= 57 || num is >= 65 and <= 90))
        {
            return false;
        }
        if (Microsoft.VisualBasic.Strings.Len(xStr) == 2)
        {
            var num2 = Microsoft.VisualBasic.Strings.Asc(Microsoft.VisualBasic.Strings.Mid(xStr, 2, 1));
            if (!(num2 is >= 48 and <= 57 || num2 is >= 65 and <= 90))
            {
                return false;
            }
        }
        return true;
    }

    private void lblKeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Return)
        {
            ValidateLabel(RuntimeHelpers.GetObjectValue(sender));
        }
    }

    private bool ValidateLabel(object sender)
    {
        var flag = ValidLabel(Conversions.ToString(NewLateBinding.LateGet(sender, null, "Text", Array.Empty<object>(), null, null, null)));
        if (!flag)
        {
            Interaction.MsgBox(msg2, MsgBoxStyle.Critical, msg1);
            NewLateBinding.LateCall(sender, null, "Focus", Array.Empty<object>(), null, null, null, IgnoreReturn: true);
            NewLateBinding.LateCall(sender, null, "SelectAll", Array.Empty<object>(), null, null, null, IgnoreReturn: true);
        }
        return flag;
    }

    private void TBSelect_Click(object sender, EventArgs e)
    {
        if (!ValidateLabel(lr1) || !ValidateLabel(lr2))
        {
            return;
        }
        var array = Array.Empty<int>();

        var enumerator = default(IEnumerator);
        try
        {
            enumerator = Panel1.Controls.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var checkBox = (CheckBox)enumerator.Current;
                if (checkBox.Checked)
                {
                    array = (int[])Utils.CopyArray(array, new int[Information.UBound(array) + 1 + 1]);
                    array[Information.UBound(array)] = Conversions.ToInteger(checkBox.Tag);
                }
            }
        }
        finally
        {
            if (enumerator is IDisposable)
            {
                (enumerator as IDisposable).Dispose();
            }
        }
        var num = 1;
        if (cbx1.Checked)
        {
            num *= 2;
        }
        if (cbx2.Checked)
        {
            num *= 3;
        }
        if (cbx3.Checked)
        {
            num *= 5;
        }
        if (cbx4.Checked)
        {
            num *= 7;
        }
        if (cbx5.Checked)
        {
            num *= 11;
        }
        if (cbx6.Checked)
        {
            num *= 13;
        }
        MyProject.Forms.MainWindow.fdrSelect(num, Convert.ToInt32(mr1.Value), Convert.ToInt32(mr2.Value), lr1.Text, lr2.Text, Convert.ToInt32(decimal.Multiply(vr1.Value, 10000m)), Convert.ToInt32(decimal.Multiply(vr2.Value, 10000m)), array);
    }

    private void TBUnselect_Click(object sender, EventArgs e)
    {
        if (!ValidateLabel(lr1) || !ValidateLabel(lr2))
        {
            return;
        }
        var array = Array.Empty<int>();

        var enumerator = default(IEnumerator);
        try
        {
            enumerator = Panel1.Controls.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var checkBox = (CheckBox)enumerator.Current;
                if (checkBox.Checked)
                {
                    array = (int[])Utils.CopyArray(array, new int[Information.UBound(array) + 1 + 1]);
                    array[Information.UBound(array)] = Conversions.ToInteger(checkBox.Tag);
                }
            }
        }
        finally
        {
            if (enumerator is IDisposable)
            {
                (enumerator as IDisposable).Dispose();
            }
        }
        var num = 1;
        if (cbx1.Checked)
        {
            num *= 2;
        }
        if (cbx2.Checked)
        {
            num *= 3;
        }
        if (cbx3.Checked)
        {
            num *= 5;
        }
        if (cbx4.Checked)
        {
            num *= 7;
        }
        if (cbx5.Checked)
        {
            num *= 11;
        }
        if (cbx6.Checked)
        {
            num *= 13;
        }
        MyProject.Forms.MainWindow.fdrUnselect(num, Convert.ToInt32(mr1.Value), Convert.ToInt32(mr2.Value), lr1.Text, lr2.Text, Convert.ToInt32(decimal.Multiply(vr1.Value, 10000m)), Convert.ToInt32(decimal.Multiply(vr2.Value, 10000m)), array);
    }

    private void TBDelete_Click(object sender, EventArgs e)
    {
        if (!ValidateLabel(lr1) || !ValidateLabel(lr2))
        {
            return;
        }
        var array = Array.Empty<int>();

        var enumerator = default(IEnumerator);
        try
        {
            enumerator = Panel1.Controls.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var checkBox = (CheckBox)enumerator.Current;
                if (checkBox.Checked)
                {
                    array = (int[])Utils.CopyArray(array, new int[Information.UBound(array) + 1 + 1]);
                    array[Information.UBound(array)] = Conversions.ToInteger(checkBox.Tag);
                }
            }
        }
        finally
        {
            if (enumerator is IDisposable)
            {
                (enumerator as IDisposable).Dispose();
            }
        }
        var num = 1;
        if (cbx1.Checked)
        {
            num *= 2;
        }
        if (cbx2.Checked)
        {
            num *= 3;
        }
        if (cbx3.Checked)
        {
            num *= 5;
        }
        if (cbx4.Checked)
        {
            num *= 7;
        }
        if (cbx5.Checked)
        {
            num *= 11;
        }
        if (cbx6.Checked)
        {
            num *= 13;
        }
        MyProject.Forms.MainWindow.fdrDelete(num, Convert.ToInt32(mr1.Value), Convert.ToInt32(mr2.Value), lr1.Text, lr2.Text, Convert.ToInt32(decimal.Multiply(vr1.Value, 10000m)), Convert.ToInt32(decimal.Multiply(vr2.Value, 10000m)), array);
    }

    private void TBrl_Click(object sender, EventArgs e)
    {
        if (!ValidateLabel(lr1) || !ValidateLabel(lr2) || !ValidateLabel(Ttl))
        {
            return;
        }
        var array = Array.Empty<int>();

        var enumerator = default(IEnumerator);
        try
        {
            enumerator = Panel1.Controls.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var checkBox = (CheckBox)enumerator.Current;
                if (checkBox.Checked)
                {
                    array = (int[])Utils.CopyArray(array, new int[Information.UBound(array) + 1 + 1]);
                    array[Information.UBound(array)] = Conversions.ToInteger(checkBox.Tag);
                }
            }
        }
        finally
        {
            if (enumerator is IDisposable)
            {
                (enumerator as IDisposable).Dispose();
            }
        }
        var num = 1;
        if (cbx1.Checked)
        {
            num *= 2;
        }
        if (cbx2.Checked)
        {
            num *= 3;
        }
        if (cbx3.Checked)
        {
            num *= 5;
        }
        if (cbx4.Checked)
        {
            num *= 7;
        }
        if (cbx5.Checked)
        {
            num *= 11;
        }
        if (cbx6.Checked)
        {
            num *= 13;
        }
        MyProject.Forms.MainWindow.fdrReplaceL(num, Convert.ToInt32(mr1.Value), Convert.ToInt32(mr2.Value), lr1.Text, lr2.Text, Convert.ToInt32(decimal.Multiply(vr1.Value, 10000m)), Convert.ToInt32(decimal.Multiply(vr2.Value, 10000m)), array, Ttl.Text);
    }

    private void TBrv_Click(object sender, EventArgs e)
    {
        if (!ValidateLabel(lr1) || !ValidateLabel(lr2))
        {
            return;
        }
        var array = Array.Empty<int>();

        var enumerator = default(IEnumerator);
        try
        {
            enumerator = Panel1.Controls.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var checkBox = (CheckBox)enumerator.Current;
                if (checkBox.Checked)
                {
                    array = (int[])Utils.CopyArray(array, new int[Information.UBound(array) + 1 + 1]);
                    array[Information.UBound(array)] = Conversions.ToInteger(checkBox.Tag);
                }
            }
        }
        finally
        {
            if (enumerator is IDisposable)
            {
                (enumerator as IDisposable).Dispose();
            }
        }
        var num = 1;
        if (cbx1.Checked)
        {
            num *= 2;
        }
        if (cbx2.Checked)
        {
            num *= 3;
        }
        if (cbx3.Checked)
        {
            num *= 5;
        }
        if (cbx4.Checked)
        {
            num *= 7;
        }
        if (cbx5.Checked)
        {
            num *= 11;
        }
        if (cbx6.Checked)
        {
            num *= 13;
        }
        MyProject.Forms.MainWindow.fdrReplaceV(num, Convert.ToInt32(mr1.Value), Convert.ToInt32(mr2.Value), lr1.Text, lr2.Text, Convert.ToInt32(decimal.Multiply(vr1.Value, 10000m)), Convert.ToInt32(decimal.Multiply(vr2.Value, 10000m)), array, Convert.ToInt32(decimal.Multiply(Ttv.Value, 10000m)));
    }
}
