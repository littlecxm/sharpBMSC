using System.Drawing;

namespace iBMSC.Editor
{

    public class visualSettings
    {
        public SolidBrush ColumnTitle;
        public Font ColumnTitleFont;
        public SolidBrush Bg;
        public Pen pGrid;
        public Pen pSub;
        public Pen pVLine;
        public Pen pMLine;
        public Pen pBGMWav;

        public Pen SelBox;
        public Pen PECursor;
        public Pen PEHalf;
        public int PEDeltaMouseOver;
        public Pen PEMouseOver;
        public SolidBrush PESel;
        public SolidBrush PEBPM;
        public Font PEBPMFont;
        public int MiddleDeltaRelease;

        public int kHeight;
        public Font kFont;
        public Font kMFont;
        public int kLabelVShift;
        public int kLabelHShift;
        public int kLabelHShiftL;
        public Pen kMouseOver;
        public Pen kMouseOverE;
        public Pen kSelected;
        public float kOpacity;

        public visualSettings() : this(new SolidBrush(Color.Lime), new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.Pixel), new SolidBrush(Color.Black), new Pen(Color.FromArgb(893008442)), new Pen(Color.FromArgb(1530542650)), new Pen(Color.FromArgb(-13158601)), new Pen(Color.FromArgb(1599230546)), new Pen(Color.FromArgb(851493056)), new Pen(Color.FromArgb(-1056964609)), new Pen(Color.FromArgb(int.MinValue + 0x40FF8080)), new Pen(Color.FromArgb(int.MinValue + 0x008080FF)), 5, new Pen(Color.FromArgb(int.MinValue + 0x00FF8080)), new SolidBrush(Color.FromArgb(855605376)), new SolidBrush(Color.FromArgb(855605376)), new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Pixel), 10, 10, new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Pixel), new Font("Verdana", 12f, FontStyle.Regular, GraphicsUnit.Pixel), -2, 0, 2, new Pen(Color.Lime), new Pen(Color.FromArgb(-16711681)), new Pen(Color.Red), 0.5f)
        {
        }

        public visualSettings(SolidBrush voTitle, Font voTitleFont, SolidBrush voBg, Pen voGrid, Pen voSub, Pen voVLine, Pen voMLine, Pen voBGMWav, Pen voSelBox, Pen voPECursor, Pen voPEHalf, int voPEDeltaMouseOver, Pen voPEMouseOver, SolidBrush voPESel, SolidBrush voPEBPM, Font voPEBPMFont, int xMiddleDeltaRelease, int vKHeight, Font vKFont, Font vKMFont, int vKLabelVShift, int vKLabelHShift, int vKLabelHShiftL, Pen vKMouseOver, Pen vKMouseOverE, Pen vKSelected, float vKOpacity)



        {

            ColumnTitle = voTitle;
            ColumnTitleFont = voTitleFont;
            Bg = voBg;
            pGrid = voGrid;
            pSub = voSub;
            pVLine = voVLine;
            pMLine = voMLine;
            pBGMWav = voBGMWav;

            SelBox = voSelBox;
            PECursor = voPECursor;
            PEHalf = voPEHalf;
            PEDeltaMouseOver = voPEDeltaMouseOver;
            PEMouseOver = voPEMouseOver;
            PESel = voPESel;
            PEBPM = voPEBPM;
            PEBPMFont = voPEBPMFont;
            MiddleDeltaRelease = xMiddleDeltaRelease;

            kHeight = vKHeight;
            kFont = vKFont;
            kMFont = vKMFont;
            kLabelVShift = vKLabelVShift;
            kLabelHShift = vKLabelHShift;
            kLabelHShiftL = vKLabelHShiftL;
            kMouseOver = vKMouseOver;
            kMouseOverE = vKMouseOverE;
            kSelected = vKSelected;
            kOpacity = vKOpacity;
        }
    }

}