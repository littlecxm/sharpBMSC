using System;
using System.IO;
using iBMSC.Editor;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace iBMSC;

public class UndoRedo
{
    public abstract class LinkedURCmd
    {
        public LinkedURCmd Next;

        protected LinkedURCmd()
        {
            Next = null;
        }

        public abstract byte ofType();

        public abstract byte[] toBytes();
    }

    public class Void : LinkedURCmd
    {
        public override byte[] toBytes()
        {
            return new byte[1] { 0 };
        }

        public Void()
        {
        }

        public Void(byte[] b)
        {
        }

        public override byte ofType()
        {
            return 0;
        }
    }

    public abstract class LinkedURNoteCmd : LinkedURCmd
    {
        public Note note;

        public LinkedURNoteCmd()
        {
        }

        public LinkedURNoteCmd(Note b)
        {
            note = b;
        }

        public LinkedURNoteCmd(byte[] b)
        {
            BinaryReader br = new BinaryReader(new MemoryStream(b));
            FromBinaryReader(ref br);
        }

        public void FromBinaryReader(ref BinaryReader br)
        {
            br.ReadByte();
            note.FromBinReader(ref br);
        }

        public void WriteBinWriter(ref BinaryWriter bw)
        {
            bw.Write(ofType());
            bw.Write(note.ToBytes());
        }

        public abstract override byte ofType();

        public override byte[] toBytes()
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter bw = new BinaryWriter(memoryStream);
            WriteBinWriter(ref bw);
            return memoryStream.GetBuffer();
        }
    }

    public class AddNote : LinkedURNoteCmd
    {
        public AddNote(Note _note)
        {
            note = _note;
        }

        public AddNote(byte[] b)
            : base(b)
        {
        }

        public override byte ofType()
        {
            return 1;
        }
    }

    public class RemoveNote : LinkedURNoteCmd
    {
        public RemoveNote(Note _note)
        {
            note = _note;
        }

        public RemoveNote(byte[] b)
            : base(b)
        {
        }

        public override byte ofType()
        {
            return 2;
        }
    }

    public class ChangeNote : LinkedURNoteCmd
    {
        public Note NNote;

        public override byte[] toBytes()
        {
            MemoryStream memoryStream = new MemoryStream(base.toBytes());
            BinaryWriter bw = new BinaryWriter(memoryStream);
            WriteBinWriter(ref bw);
            NNote.WriteBinWriter(ref bw);
            return memoryStream.GetBuffer();
        }

        public ChangeNote(byte[] b)
        {
            BinaryReader br = new BinaryReader(new MemoryStream(b));
            FromBinaryReader(ref br);
            NNote.FromBinReader(ref br);
        }

        public ChangeNote(Note note1, Note note2)
        {
            note = note1;
            NNote = note2;
        }

        public override byte ofType()
        {
            return 3;
        }
    }

    public class MoveNote : LinkedURNoteCmd
    {
        public int NColumnIndex;

        public double NVPosition;

        public override byte[] toBytes()
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter bw = new BinaryWriter(memoryStream);
            WriteBinWriter(ref bw);
            bw.Write(NColumnIndex);
            bw.Write(NVPosition);
            return memoryStream.GetBuffer();
        }

        public MoveNote(byte[] b)
        {
            NColumnIndex = 0;
            NVPosition = 0.0;
            BinaryReader br = new BinaryReader(new MemoryStream(b));
            FromBinaryReader(ref br);
            NColumnIndex = br.ReadInt32();
            NVPosition = br.ReadDouble();
        }

        public MoveNote(Note _note, int _ColIndex, double _VPos)
        {
            NColumnIndex = 0;
            NVPosition = 0.0;
            note = _note;
            NColumnIndex = _ColIndex;
            NVPosition = _VPos;
        }

        public override byte ofType()
        {
            return 4;
        }
    }

    public class LongNoteModify : LinkedURNoteCmd
    {
        public double NVPosition;

        public double NLongNote;

        public override byte[] toBytes()
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter bw = new BinaryWriter(memoryStream);
            WriteBinWriter(ref bw);
            bw.Write(NVPosition);
            bw.Write(NLongNote);
            return memoryStream.GetBuffer();
        }

        public LongNoteModify(byte[] b)
        {
            NVPosition = 0.0;
            NLongNote = 0.0;
            BinaryReader br = new BinaryReader(new MemoryStream(b));
            FromBinaryReader(ref br);
            NLongNote = br.ReadDouble();
            NVPosition = br.ReadDouble();
        }

        public LongNoteModify(Note _note, double xNVPosition, double xNLongNote)
        {
            NVPosition = 0.0;
            NLongNote = 0.0;
            note = _note;
            NVPosition = xNVPosition;
            NLongNote = xNLongNote;
        }

        public override byte ofType()
        {
            return 5;
        }
    }

    public class HiddenNoteModify : LinkedURNoteCmd
    {
        public bool NHidden;

        public override byte[] toBytes()
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter bw = new BinaryWriter(memoryStream);
            WriteBinWriter(ref bw);
            bw.Write(NHidden);
            return memoryStream.GetBuffer();
        }

        public HiddenNoteModify(byte[] b)
        {
            NHidden = false;
            BinaryReader br = new BinaryReader(new MemoryStream(b));
            FromBinaryReader(ref br);
            NHidden = br.ReadBoolean();
        }

        public HiddenNoteModify(Note _note, bool xNHidden)
        {
            NHidden = false;
            note = _note;
            NHidden = xNHidden;
        }

        public override byte ofType()
        {
            return 6;
        }
    }

    public class RelabelNote : LinkedURNoteCmd
    {
        public long NValue;

        public override byte[] toBytes()
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter bw = new BinaryWriter(memoryStream);
            WriteBinWriter(ref bw);
            bw.Write(NValue);
            return memoryStream.GetBuffer();
        }

        public RelabelNote(byte[] b)
        {
            NValue = 10000L;
            BinaryReader br = new BinaryReader(new MemoryStream(b));
            FromBinaryReader(ref br);
            NValue = br.ReadInt64();
        }

        public RelabelNote(Note _note, long xNValue)
        {
            NValue = 10000L;
            note = _note;
            NValue = xNValue;
        }

        public override byte ofType()
        {
            return 7;
        }
    }

    public class RemoveAllNotes : LinkedURCmd
    {
        public override byte[] toBytes()
        {
            return new byte[1] { 15 };
        }

        public RemoveAllNotes(byte[] b)
        {
        }

        public RemoveAllNotes()
        {
        }

        public override byte ofType()
        {
            return 15;
        }
    }

    public class ChangeMeasureLength : LinkedURCmd
    {
        public double Value;

        public int[] Indices;

        public override byte[] toBytes()
        {
            byte[] bytes = BitConverter.GetBytes(Value);
            byte[] bytes2 = BitConverter.GetBytes(Information.UBound(Indices));
            byte[] array = new byte[13]
            {
                16,
                bytes[0],
                bytes[1],
                bytes[2],
                bytes[3],
                bytes[4],
                bytes[5],
                bytes[6],
                bytes[7],
                bytes2[0],
                bytes2[1],
                bytes2[2],
                bytes2[3]
            };
            checked
            {
                array = (byte[])Utils.CopyArray(array, new byte[12 + 4 * Indices.Length + 1]);
                int num = Information.UBound(array);
                for (int i = 13; i <= num; i += 4)
                {
                    byte[] bytes3;
                    unchecked
                    {
                        bytes3 = BitConverter.GetBytes(Indices[checked(i - 13) / 4]);
                    }
                    array[i + 0] = bytes3[0];
                    array[i + 1] = bytes3[1];
                    array[i + 2] = bytes3[2];
                    array[i + 3] = bytes3[3];
                }
                return array;
            }
        }

        public ChangeMeasureLength(byte[] b)
        {
            Value = 192.0;
            Indices = new int[0];
            Value = BitConverter.ToDouble(b, 1);
            int num = BitConverter.ToInt32(b, 9);
            Indices = (int[])Utils.CopyArray(Indices, new int[checked(num + 1)]);
            for (int i = 13; i <= num; i = checked(i + 4))
            {
                Indices[checked(i - 13) / 4] = BitConverter.ToInt32(b, i);
            }
        }

        public ChangeMeasureLength(double xValue, int[] xIndices)
        {
            Value = 192.0;
            Indices = new int[0];
            Value = xValue;
            Indices = xIndices;
        }

        public override byte ofType()
        {
            return 16;
        }
    }

    public class ChangeTimeSelection : LinkedURCmd
    {
        public double SelStart;

        public double SelLength;

        public double SelHalf;

        public bool Selected;

        public override byte[] toBytes()
        {
            byte[] bytes = BitConverter.GetBytes(SelStart);
            byte[] bytes2 = BitConverter.GetBytes(SelLength);
            byte[] bytes3 = BitConverter.GetBytes(SelLength);
            return new byte[26]
            {
                17,
                bytes[0],
                bytes[1],
                bytes[2],
                bytes[3],
                bytes[4],
                bytes[5],
                bytes[6],
                bytes[7],
                bytes2[0],
                bytes2[1],
                bytes2[2],
                bytes2[3],
                bytes2[4],
                bytes2[5],
                bytes2[6],
                bytes2[7],
                bytes3[0],
                bytes3[1],
                bytes3[2],
                bytes3[3],
                bytes3[4],
                bytes3[5],
                bytes3[6],
                bytes3[7],
                Conversions.ToByte(Interaction.IIf(Selected, (byte)1, (byte)0))
            };
        }

        public ChangeTimeSelection(byte[] b)
        {
            SelStart = 0.0;
            SelLength = 0.0;
            SelHalf = 0.0;
            Selected = false;
            SelStart = BitConverter.ToDouble(b, 1);
            SelLength = BitConverter.ToDouble(b, 9);
            SelHalf = BitConverter.ToDouble(b, 17);
            Selected = b[25] != 0;
        }

        public ChangeTimeSelection(double xSelStart, double xSelLength, double xSelHalf, bool xSelected)
        {
            SelStart = 0.0;
            SelLength = 0.0;
            SelHalf = 0.0;
            Selected = false;
            SelStart = xSelStart;
            SelLength = xSelLength;
            SelHalf = xSelHalf;
            Selected = xSelected;
        }

        public override byte ofType()
        {
            return 17;
        }
    }

    public class NT : LinkedURCmd
    {
        public bool BecomeNT;

        public bool AutoConvert;

        public override byte[] toBytes()
        {
            return new byte[3]
            {
                18,
                Conversions.ToByte(Interaction.IIf(BecomeNT, (byte)1, (byte)0)),
                Conversions.ToByte(Interaction.IIf(AutoConvert, (byte)1, (byte)0))
            };
        }

        public NT(byte[] b)
        {
            BecomeNT = false;
            AutoConvert = false;
            BecomeNT = b[1] != 0;
            AutoConvert = b[2] != 0;
        }

        public NT(bool xBecomeNT, bool xAutoConvert)
        {
            BecomeNT = false;
            AutoConvert = false;
            BecomeNT = xBecomeNT;
            AutoConvert = xAutoConvert;
        }

        public override byte ofType()
        {
            return 18;
        }
    }

    public class WavAutoincFlag : LinkedURCmd
    {
        public bool Checked;

        public WavAutoincFlag(bool _checked)
        {
            Checked = false;
            Checked = _checked;
        }

        public override byte[] toBytes()
        {
            return new byte[2]
            {
                20,
                Conversions.ToByte(Interaction.IIf(Checked, (byte)1, (byte)0))
            };
        }

        public WavAutoincFlag(byte[] b)
        {
            Checked = false;
            Checked = b[1] != 0;
        }

        public override byte ofType()
        {
            return 20;
        }
    }

    public class NoOperation : LinkedURCmd
    {
        public override byte[] toBytes()
        {
            return new byte[1] { 255 };
        }

        public NoOperation()
        {
        }

        public NoOperation(byte[] b)
        {
        }

        public override byte ofType()
        {
            return byte.MaxValue;
        }
    }

    public const byte opVoid = 0;

    public const byte opAddNote = 1;

    public const byte opRemoveNote = 2;

    public const byte opChangeNote = 3;

    public const byte opMoveNote = 4;

    public const byte opLongNoteModify = 5;

    public const byte opHiddenNoteModify = 6;

    public const byte opRelabelNote = 7;

    public const byte opRemoveAllNotes = 15;

    public const byte opChangeMeasureLength = 16;

    public const byte opChangeTimeSelection = 17;

    public const byte opNT = 18;

    public const byte opWavAutoincFlag = 20;

    public const byte opNoOperation = byte.MaxValue;

    private const byte trueByte = 1;

    private const byte falseByte = 0;

    public static LinkedURCmd fromBytes(byte[] b)
    {
        if (b == null)
        {
            return null;
        }
        if (b.Length == 0)
        {
            return null;
        }
        return b[0] switch
        {
            0 => new Void(b), 
            1 => new AddNote(b), 
            2 => new RemoveNote(b), 
            3 => new ChangeNote(b), 
            4 => new MoveNote(b), 
            5 => new LongNoteModify(b), 
            6 => new HiddenNoteModify(b), 
            7 => new RelabelNote(b), 
            15 => new RemoveAllNotes(b), 
            16 => new ChangeMeasureLength(b), 
            17 => new ChangeTimeSelection(b), 
            18 => new NT(b), 
            20 => new WavAutoincFlag(b), 
            byte.MaxValue => new NoOperation(b), 
            _ => null, 
        };
    }
}
