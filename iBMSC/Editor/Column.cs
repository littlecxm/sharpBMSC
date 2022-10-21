using System;
using System.Drawing;

namespace iBMSC.Editor;

public struct Column
{
    private int _Width;

    private bool _isNoteCol;

    private bool _isVisible;

    private bool _isEnabledAfterAll;

    public int Left;

    public string Title;

    public bool isNumeric;

    public int Identifier;

    public int cNote;

    public Color cText;

    public int cLNote;

    public Color cLText;

    public Color cBG;

    private int cCacheB;

    private int cCacheD;

    private int cCacheLB;

    private int cCacheLD;

    public int Width
    {
        get
        {
            return _Width;
        }
        set
        {
            _Width = value;
            _isEnabledAfterAll = _isVisible & _isNoteCol & (_Width != 0);
        }
    }

    public bool isVisible
    {
        get
        {
            return _isVisible;
        }
        set
        {
            _isVisible = value;
            _isEnabledAfterAll = _isVisible & _isNoteCol & (_Width != 0);
        }
    }

    public bool isNoteCol
    {
        get
        {
            return _isNoteCol;
        }
        set
        {
            _isNoteCol = value;
            _isEnabledAfterAll = _isVisible & _isNoteCol & (_Width != 0);
        }
    }

    public bool isEnabledAfterAll => _isEnabledAfterAll;

    public Color getBright(float opacity)
    {
        return Color.FromArgb((checked((int)Math.Round(((cCacheB >> 24) & 0xFF) * opacity)) << 24) | (cCacheB & 0xFFFFFF));
    }

    public Color getDark(float opacity)
    {
        return Color.FromArgb((checked((int)Math.Round(((cCacheD >> 24) & 0xFF) * opacity)) << 24) | (cCacheD & 0xFFFFFF));
    }

    public Color getLongBright(float opacity)
    {
        return Color.FromArgb((checked((int)Math.Round(((cCacheLB >> 24) & 0xFF) * opacity)) << 24) | (cCacheLB & 0xFFFFFF));
    }

    public Color getLongDark(float opacity)
    {
        return Color.FromArgb((checked((int)Math.Round(((cCacheLD >> 24) & 0xFF) * opacity)) << 24) | (cCacheLD & 0xFFFFFF));
    }

    public void setNoteColor(int c)
    {
        cNote = c;
        cCacheB = Functions.AdjustBrightness(Color.FromArgb(c), 50f, (float)(((c >> 24) & 0xFF) / 255.0)).ToArgb();
        cCacheD = Functions.AdjustBrightness(Color.FromArgb(c), -25f, (float)(((c >> 24) & 0xFF) / 255.0)).ToArgb();
    }

    public void setLNoteColor(int c)
    {
        cLNote = c;
        cCacheLB = Functions.AdjustBrightness(Color.FromArgb(c), 50f, (float)(((c >> 24) & 0xFF) / 255.0)).ToArgb();
        cCacheLD = Functions.AdjustBrightness(Color.FromArgb(c), -25f, (float)(((c >> 24) & 0xFF) / 255.0)).ToArgb();
    }

    public Column(int xLeft, int xWidth, string xTitle, bool xNoteCol, bool xisNumeric, bool xVisible, int xIdentifier, int xcNote, int xcText, int xcLNote, int xcLText, int xcBG)
    {
        this = default(Column);
        Left = xLeft;
        Title = xTitle;
        isNumeric = xisNumeric;
        Identifier = xIdentifier;
        _Width = xWidth;
        _isVisible = xVisible;
        _isNoteCol = xNoteCol;
        _isEnabledAfterAll = xVisible && xNoteCol && xWidth != 0;
        setNoteColor(xcNote);
        cText = Color.FromArgb(xcText);
        setLNoteColor(xcLNote);
        cLText = Color.FromArgb(xcLText);
        cBG = Color.FromArgb(xcBG);
    }
}
