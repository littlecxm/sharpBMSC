using System.IO;

namespace iBMSC.Editor;

public struct Note
{
    public double VPosition;

    public int ColumnIndex;

    public long Value;

    public bool LongNote;

    public bool Hidden;

    public double Length;

    public bool Landmine;

    public int LNPair;

    public bool Selected;

    public bool HasError;

    public bool TempSelected;

    public bool TempMouseDown;

    public int TempIndex;

    public bool equalsBMSE(Note note)
    {
        return (VPosition == note.VPosition) & (ColumnIndex == note.ColumnIndex) & (Value == note.Value) & (LongNote == note.LongNote) & (Hidden == note.Hidden) & (Landmine == note.Landmine);
    }

    public bool equalsNT(Note note)
    {
        return (VPosition == note.VPosition) & (ColumnIndex == note.ColumnIndex) & (Value == note.Value) & (Hidden == note.Hidden) & (Length == note.Length) & (Landmine == note.Landmine);
    }

    public Note(int nColumnIndex, double nVposition, long nValue, double nLongNote = 0.0, bool nHidden = false, bool nSelected = false, bool nLandmine = false)
    {
        this = default(Note);
        VPosition = nVposition;
        ColumnIndex = nColumnIndex;
        Value = nValue;
        LongNote = nLongNote != 0.0;
        Length = nLongNote;
        Hidden = nHidden;
        Landmine = nLandmine;
    }

    internal byte[] ToBytes()
    {
        var memoryStream = new MemoryStream();
        var bw = new BinaryWriter(memoryStream);
        WriteBinWriter(ref bw);
        return memoryStream.GetBuffer();
    }

    internal void WriteBinWriter(ref BinaryWriter bw)
    {
        bw.Write(VPosition);
        bw.Write(ColumnIndex);
        bw.Write(Value);
        bw.Write(LongNote);
        bw.Write(Length);
        bw.Write(Hidden);
        bw.Write(Landmine);
    }

    internal void FromBinReader(ref BinaryReader br)
    {
        VPosition = br.ReadDouble();
        ColumnIndex = br.ReadInt32();
        Value = br.ReadInt64();
        LongNote = br.ReadBoolean();
        Length = br.ReadDouble();
        Hidden = br.ReadBoolean();
        Landmine = br.ReadBoolean();
    }

    internal void FromBytes(ref byte[] bytes)
    {
        var br = new BinaryReader(new MemoryStream(bytes));
        FromBinReader(ref br);
    }
}
