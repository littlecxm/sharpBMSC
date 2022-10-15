using System;
using System.IO;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace iBMSC
{

    public class UndoRedo
    {
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
        // Public Const opChangeVisibleColumns As Byte = 19
        public const byte opWavAutoincFlag = 20;

        public const byte opNoOperation = 255;

        private const byte trueByte = 1;
        private const byte falseByte = 0;



        public abstract class LinkedURCmd
        {
            public LinkedURCmd Next = null;
            public abstract byte ofType();
            public abstract byte[] toBytes();
            // Public MustOverride Sub fromBytes(ByVal b As Byte())
        }



        public static LinkedURCmd fromBytes(byte[] b)
        {
            if (b is null)
                return null;
            if (b.Length == 0)
                return null;

            switch (b[0])
            {
                case opVoid:
                    {
                        return new Void(b);
                    }
                case opAddNote:
                    {
                        return new AddNote(b);
                    }
                case opRemoveNote:
                    {
                        return new RemoveNote(b);
                    }
                case opChangeNote:
                    {
                        return new ChangeNote(b);
                    }
                case opMoveNote:
                    {
                        return new MoveNote(b);
                    }
                case opLongNoteModify:
                    {
                        return new LongNoteModify(b);
                    }
                case opHiddenNoteModify:
                    {
                        return new HiddenNoteModify(b);
                    }
                case opRelabelNote:
                    {
                        return new RelabelNote(b);
                    }
                case opRemoveAllNotes:
                    {
                        return new RemoveAllNotes(b);
                    }
                case opChangeMeasureLength:
                    {
                        return new ChangeMeasureLength(b);
                    }
                case opChangeTimeSelection:
                    {
                        return new ChangeTimeSelection(b);
                    }
                case opNT:
                    {
                        return new NT(b);
                    }
                // Case opChangeVisibleColumns : Return New ChangeVisibleColumns(b)
                case opWavAutoincFlag:
                    {
                        return new WavAutoincFlag(b);
                    }
                case opNoOperation:
                    {
                        return new NoOperation(b);
                    }

                default:
                    {
                        return null;
                    }
            }
        }


        public class Void : LinkedURCmd
        {
            // 1 = 1
            public override byte[] toBytes()
            {
                byte[] toBytesRet = default;
                toBytesRet = new byte[] { opVoid };
                return toBytesRet;
            }

            public Void()
            {
            }

            public Void(byte[] b)
            {
            }

            public override byte ofType()
            {
                return opVoid;
            }
        }

        public abstract class LinkedURNoteCmd : LinkedURCmd
        {
            public iBMSC.Editor.Note note;

            public LinkedURNoteCmd()
            {

            }

            public LinkedURNoteCmd(iBMSC.Editor.Note b)
            {
                note = b;
            }

            public LinkedURNoteCmd(byte[] b)
            {
                var argbr = new BinaryReader(new MemoryStream(b));
                FromBinaryReader(ref argbr);
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
                var ms = new MemoryStream();
                var bw = new BinaryWriter(ms);
                WriteBinWriter(ref bw);

                return ms.GetBuffer();
            }
        }

        public class AddNote : LinkedURNoteCmd
        {
            public AddNote(iBMSC.Editor.Note _note)
            {
                note = _note;
            }

            public AddNote(byte[] b) : base(b)
            {
            }

            public override byte ofType()
            {
                return opAddNote;
            }
        }



        public class RemoveNote : LinkedURNoteCmd
        {
            public RemoveNote(iBMSC.Editor.Note _note)
            {
                note = _note;
            }

            public RemoveNote(byte[] b) : base(b)
            {
            }

            public override byte ofType()
            {
                return opRemoveNote;
            }
        }



        public class ChangeNote : LinkedURNoteCmd
        {
            public iBMSC.Editor.Note NNote;

            public override byte[] toBytes()
            {
                var ms = new MemoryStream(base.toBytes());
                var bw = new BinaryWriter(ms);
                WriteBinWriter(ref bw);
                NNote.WriteBinWriter(ref bw);
                return ms.GetBuffer();
            }

            public ChangeNote(byte[] b)
            {
                var br = new BinaryReader(new MemoryStream(b));
                FromBinaryReader(ref br);
                NNote.FromBinReader(ref br);
            }

            public ChangeNote(iBMSC.Editor.Note note1, iBMSC.Editor.Note note2)
            {
                note = note1;
                NNote = note2;
            }

            public override byte ofType()
            {
                return opChangeNote;
            }
        }



        public class MoveNote : LinkedURNoteCmd
        {
            public int NColumnIndex = 0;
            public double NVPosition = 0d;

            public override byte[] toBytes()
            {
                var ms = new MemoryStream();
                var bw = new BinaryWriter(ms);
                WriteBinWriter(ref bw);
                bw.Write(NColumnIndex);
                bw.Write(NVPosition);

                return ms.GetBuffer();
            }

            public MoveNote(byte[] b)
            {
                var br = new BinaryReader(new MemoryStream(b));
                FromBinaryReader(ref br);
                NColumnIndex = br.ReadInt32();
                NVPosition = br.ReadDouble();
            }

            public MoveNote(iBMSC.Editor.Note _note, int _ColIndex, double _VPos)
            {
                note = _note;
                NColumnIndex = _ColIndex;
                NVPosition = _VPos;
            }

            public override byte ofType()
            {
                return opMoveNote;
            }
        }



        public class LongNoteModify : LinkedURNoteCmd
        {
            public double NVPosition = 0d;
            public double NLongNote = 0d;

            public override byte[] toBytes()
            {
                var ms = new MemoryStream();
                var bw = new BinaryWriter(ms);
                WriteBinWriter(ref bw);
                bw.Write(NVPosition);
                bw.Write(NLongNote);

                return ms.GetBuffer();
            }

            public LongNoteModify(byte[] b)
            {
                var br = new BinaryReader(new MemoryStream(b));
                FromBinaryReader(ref br);
                NLongNote = br.ReadDouble();
                NVPosition = br.ReadDouble();
            }

            public LongNoteModify(iBMSC.Editor.Note _note, double xNVPosition, double xNLongNote)
            {
                note = _note;
                NVPosition = xNVPosition;
                NLongNote = xNLongNote;
            }

            public override byte ofType()
            {
                return opLongNoteModify;
            }
        }



        public class HiddenNoteModify : LinkedURNoteCmd
        {
            public bool NHidden = false;

            public override byte[] toBytes()
            {
                var MS = new MemoryStream();
                var bw = new BinaryWriter(MS);
                WriteBinWriter(ref bw);
                bw.Write(NHidden);
                return MS.GetBuffer();
            }

            public HiddenNoteModify(byte[] b)
            {
                var br = new BinaryReader(new MemoryStream(b));
                FromBinaryReader(ref br);
                NHidden = br.ReadBoolean();
            }

            public HiddenNoteModify(iBMSC.Editor.Note _note, bool xNHidden)
            {
                note = _note;
                NHidden = xNHidden;
            }

            public override byte ofType()
            {
                return opHiddenNoteModify;
            }
        }



        public class RelabelNote : LinkedURNoteCmd
        {
            // 1 + 25 + 4 + 1 = 31

            public long NValue = 10000L;

            public override byte[] toBytes()
            {
                var ms = new MemoryStream();
                var bw = new BinaryWriter(ms);
                WriteBinWriter(ref bw);
                bw.Write(NValue);

                return ms.GetBuffer();
            }

            public RelabelNote(byte[] b)
            {
                var br = new BinaryReader(new MemoryStream(b));
                FromBinaryReader(ref br);
                NValue = br.ReadInt64();
            }

            public RelabelNote(iBMSC.Editor.Note _note, long xNValue)
            {
                note = _note;
                NValue = xNValue;
            }

            public override byte ofType()
            {
                return opRelabelNote;
            }
        }



        public class RemoveAllNotes : LinkedURCmd
        {
            // 1 = 1
            public override byte[] toBytes()
            {
                byte[] toBytesRet = default;
                toBytesRet = new byte[] { opRemoveAllNotes };
                return toBytesRet;
            }

            public RemoveAllNotes(byte[] b)
            {
            }

            public RemoveAllNotes()
            {
            }

            public override byte ofType()
            {
                return opRemoveAllNotes;
            }
        }



        public class ChangeMeasureLength : LinkedURCmd
        {
            // 1 + 8 + 4 + 4 * Indices.Length = 13 + 4 * Indices.Length
            public double Value = 192d;
            public int[] Indices = Array.Empty<int>();

            public override byte[] toBytes()
            {
                var xVal = BitConverter.GetBytes(Value);
                var xUbound = BitConverter.GetBytes(Information.UBound(Indices));
                var xToBytes = new byte[] { opChangeMeasureLength, xVal[0], xVal[1], xVal[2], xVal[3], xVal[4], xVal[5], xVal[6], xVal[7], xUbound[0], xUbound[1], xUbound[2], xUbound[3] };
                Array.Resize(ref xToBytes, 12 + 4 * Indices.Length + 1);
                for (int xI1 = 13, loopTo = Information.UBound(xToBytes); xI1 <= loopTo; xI1 += 4)
                {
                    var xId = BitConverter.GetBytes(Indices[(xI1 - 13) / 4]);
                    xToBytes[xI1 + 0] = xId[0];
                    xToBytes[xI1 + 1] = xId[1];
                    xToBytes[xI1 + 2] = xId[2];
                    xToBytes[xI1 + 3] = xId[3];
                }
                return xToBytes;
            }

            public ChangeMeasureLength(byte[] b)
            {
                Value = BitConverter.ToDouble(b, 1);
                int xUbound = BitConverter.ToInt32(b, 9);
                Array.Resize(ref Indices, xUbound + 1);
                for (int xI1 = 13, loopTo = xUbound; xI1 <= loopTo; xI1 += 4)
                    Indices[(xI1 - 13) / 4] = BitConverter.ToInt32(b, xI1);
            }

            public ChangeMeasureLength(double xValue, int[] xIndices)
            {
                Value = xValue;
                Indices = xIndices;
            }

            public override byte ofType()
            {
                return opChangeMeasureLength;
            }
        }



        public class ChangeTimeSelection : LinkedURCmd
        {
            // 1 + 8 + 8 + 8 + 1 = 26
            public double SelStart = 0d;
            public double SelLength = 0d;
            public double SelHalf = 0d;
            public bool Selected = false;

            public override byte[] toBytes()
            {
                byte[] toBytesRet = default;
                var xSta = BitConverter.GetBytes(SelStart);
                var xLen = BitConverter.GetBytes(SelLength);
                var xHalf = BitConverter.GetBytes(SelLength);
                toBytesRet = new byte[] { opChangeTimeSelection, xSta[0], xSta[1], xSta[2], xSta[3], xSta[4], xSta[5], xSta[6], xSta[7], xLen[0], xLen[1], xLen[2], xLen[3], xLen[4], xLen[5], xLen[6], xLen[7], xHalf[0], xHalf[1], xHalf[2], xHalf[3], xHalf[4], xHalf[5], xHalf[6], xHalf[7], Conversions.ToByte(Interaction.IIf(Selected, trueByte, falseByte)) };
                return toBytesRet;
            }

            public ChangeTimeSelection(byte[] b)
            {
                SelStart = BitConverter.ToDouble(b, 1);
                SelLength = BitConverter.ToDouble(b, 9);
                SelHalf = BitConverter.ToDouble(b, 17);
                Selected = Conversions.ToBoolean(b[25]);
            }

            public ChangeTimeSelection(double xSelStart, double xSelLength, double xSelHalf, bool xSelected)
            {
                SelStart = xSelStart;
                SelLength = xSelLength;
                SelHalf = xSelHalf;
                Selected = xSelected;
            }

            public override byte ofType()
            {
                return opChangeTimeSelection;
            }
        }



        public class NT : LinkedURCmd
        {
            // 1 + 1 + 1 = 3
            public bool BecomeNT = false;
            public bool AutoConvert = false;

            public override byte[] toBytes()
            {
                byte[] toBytesRet = default;
                toBytesRet = new byte[] { opNT, Conversions.ToByte(Interaction.IIf(BecomeNT, trueByte, falseByte)), Conversions.ToByte(Interaction.IIf(AutoConvert, trueByte, falseByte)) };
                return toBytesRet;
            }

            public NT(byte[] b)
            {
                BecomeNT = Conversions.ToBoolean(b[1]);
                AutoConvert = Conversions.ToBoolean(b[2]);
            }

            public NT(bool xBecomeNT, bool xAutoConvert)
            {
                BecomeNT = xBecomeNT;
                AutoConvert = xAutoConvert;
            }

            public override byte ofType()
            {
                return opNT;
            }
        }

        public class WavAutoincFlag : LinkedURCmd
        {
            public bool Checked = false;

            public WavAutoincFlag(bool _checked)
            {
                Checked = _checked;
            }
            public override byte[] toBytes()
            {
                byte[] toBytesRet = default;
                toBytesRet = new byte[] { opWavAutoincFlag, Conversions.ToByte(Interaction.IIf(Checked, trueByte, falseByte)) };
                return toBytesRet;
            }

            public WavAutoincFlag(byte[] b)
            {
                Checked = Conversions.ToBoolean(b[1]);
            }

            public override byte ofType()
            {
                return opWavAutoincFlag;
            }

        }




        public class NoOperation : LinkedURCmd
        {
            // 1 = 1
            public override byte[] toBytes()
            {
                byte[] toBytesRet = default;
                toBytesRet = new byte[] { opNoOperation };
                return toBytesRet;
            }

            public NoOperation()
            {
            }

            public NoOperation(byte[] b)
            {
            }

            public override byte ofType()
            {
                return opNoOperation;
            }
        }
    }
}