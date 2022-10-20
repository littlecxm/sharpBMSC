using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml;
using iBMSC.Editor;
using Microsoft.VisualBasic.CompilerServices;

namespace iBMSC;

internal static class XMLUtil
{
    [SpecialName]
    private static NumberFormatInfo _0024STATIC_0024XMLLoadAttribute_0024021E10C_0024nfi;

    [SpecialName]
    private static StaticLocalInitFlag _0024STATIC_0024XMLLoadAttribute_0024021E10C_0024nfi_0024Init = new StaticLocalInitFlag();

    [SpecialName]
    private static NumberFormatInfo _0024STATIC_0024XMLLoadAttribute_0024021E10D_0024nfi;

    [SpecialName]
    private static StaticLocalInitFlag _0024STATIC_0024XMLLoadAttribute_0024021E10D_0024nfi_0024Init = new StaticLocalInitFlag();

    public static void XMLWriteValue(XmlTextWriter w, string local, string val)
    {
        w.WriteStartElement(local);
        w.WriteAttributeString("Value", Functions.WriteDecimalWithDot(Conversions.ToDouble(val)));
        w.WriteEndElement();
    }

    public static void XMLLoadAttribute(string s, ref string v)
    {
        if (s.Length != 0)
        {
            v = s;
        }
    }

    public static void XMLLoadAttribute(string s, ref bool v)
    {
        if (s.Length != 0)
        {
            v = Conversions.ToBoolean(s);
        }
    }

    public static void XMLLoadAttribute(string s, ref int v)
    {
        if (s.Length != 0)
        {
            v = Conversions.ToInteger(s);
        }
    }

    public static void XMLLoadAttribute(string s, ref float v)
    {
        if (s.Length == 0)
        {
            return;
        }
        bool lockTaken = false;
        try
        {
            Monitor.Enter(_0024STATIC_0024XMLLoadAttribute_0024021E10C_0024nfi_0024Init, ref lockTaken);
            if (_0024STATIC_0024XMLLoadAttribute_0024021E10C_0024nfi_0024Init.State == 0)
            {
                _0024STATIC_0024XMLLoadAttribute_0024021E10C_0024nfi_0024Init.State = 2;
                _0024STATIC_0024XMLLoadAttribute_0024021E10C_0024nfi = new NumberFormatInfo();
            }
            else if (_0024STATIC_0024XMLLoadAttribute_0024021E10C_0024nfi_0024Init.State == 2)
            {
                throw new IncompleteInitialization();
            }
        }
        finally
        {
            _0024STATIC_0024XMLLoadAttribute_0024021E10C_0024nfi_0024Init.State = 1;
            if (lockTaken)
            {
                Monitor.Exit(_0024STATIC_0024XMLLoadAttribute_0024021E10C_0024nfi_0024Init);
            }
        }
        _0024STATIC_0024XMLLoadAttribute_0024021E10C_0024nfi.NumberDecimalSeparator = ".";
        v = (float)double.Parse(s, _0024STATIC_0024XMLLoadAttribute_0024021E10C_0024nfi);
    }

    public static void XMLLoadAttribute(string s, ref double v)
    {
        if (s.Length == 0)
        {
            return;
        }
        bool lockTaken = false;
        try
        {
            Monitor.Enter(_0024STATIC_0024XMLLoadAttribute_0024021E10D_0024nfi_0024Init, ref lockTaken);
            if (_0024STATIC_0024XMLLoadAttribute_0024021E10D_0024nfi_0024Init.State == 0)
            {
                _0024STATIC_0024XMLLoadAttribute_0024021E10D_0024nfi_0024Init.State = 2;
                _0024STATIC_0024XMLLoadAttribute_0024021E10D_0024nfi = new NumberFormatInfo();
            }
            else if (_0024STATIC_0024XMLLoadAttribute_0024021E10D_0024nfi_0024Init.State == 2)
            {
                throw new IncompleteInitialization();
            }
        }
        finally
        {
            _0024STATIC_0024XMLLoadAttribute_0024021E10D_0024nfi_0024Init.State = 1;
            if (lockTaken)
            {
                Monitor.Exit(_0024STATIC_0024XMLLoadAttribute_0024021E10D_0024nfi_0024Init);
            }
        }
        _0024STATIC_0024XMLLoadAttribute_0024021E10D_0024nfi.NumberDecimalSeparator = ".";
        v = double.Parse(s, _0024STATIC_0024XMLLoadAttribute_0024021E10D_0024nfi);
    }

    public static void XMLLoadAttribute(string s, ref long v)
    {
        if (s.Length != 0)
        {
            v = Conversions.ToLong(s);
        }
    }

    public static void XMLLoadAttribute(string s, ref decimal v)
    {
        if (s.Length != 0)
        {
            v = Conversions.ToDecimal(s);
        }
    }

    public static void XMLLoadAttribute(string s, ref Color v)
    {
        if (s.Length != 0)
        {
            v = Color.FromArgb(Conversions.ToInteger(s));
        }
    }

    public static void XMLLoadElementValue(XmlElement n, ref int v)
    {
        if (n != null)
        {
            XMLLoadAttribute(n.GetAttribute("Value"), ref v);
        }
    }

    public static void XMLLoadElementValue(XmlElement n, ref float v)
    {
        if (n != null)
        {
            XMLLoadAttribute(n.GetAttribute("Value"), ref v);
        }
    }

    public static void XMLLoadElementValue(XmlElement n, ref Color v)
    {
        if (n != null)
        {
            XMLLoadAttribute(n.GetAttribute("Value"), ref v);
        }
    }
}
