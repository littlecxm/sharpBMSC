using System.Drawing;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace iBMSC
{
    static class XMLUtil
    {
        public static void XMLWriteValue(XmlTextWriter w, string local, string val)
        {
            w.WriteStartElement(local);
            w.WriteAttributeString("Value", iBMSC.Editor.Functions.WriteDecimalWithDot(Conversions.ToDouble(val)));
            w.WriteEndElement();
        }

        public static void XMLLoadAttribute(string s, ref string v)
        {
            if (s.Length == 0)
                return;
            v = s;
        }
        public static void XMLLoadAttribute(string s, ref bool v)
        {
            if (s.Length == 0)
                return;
            v = Conversions.ToBoolean(s);
        }
        public static void XMLLoadAttribute(string s, ref int v)
        {
            if (s.Length == 0)
                return;
            v = Conversions.ToInteger(s);
        }

        private static System.Globalization.NumberFormatInfo _XMLLoadAttribute_nfi = new System.Globalization.NumberFormatInfo();
        public static void XMLLoadAttribute(string s, ref float v)
        {
            if (s.Length == 0)
                return;
            _XMLLoadAttribute_nfi.NumberDecimalSeparator = ".";
            v = (float)double.Parse(s, _XMLLoadAttribute_nfi);
        }

        private static System.Globalization.NumberFormatInfo _XMLLoadAttribute_nfi1 = new System.Globalization.NumberFormatInfo();
        public static void XMLLoadAttribute(string s, ref double v)
        {
            if (s.Length == 0)
                return;
            _XMLLoadAttribute_nfi1.NumberDecimalSeparator = ".";
            v = double.Parse(s, _XMLLoadAttribute_nfi1);
        }
        public static void XMLLoadAttribute(string s, ref long v)
        {
            if (s.Length == 0)
                return;
            v = Conversions.ToLong(s);
        }
        public static void XMLLoadAttribute(string s, ref decimal v)
        {
            if (s.Length == 0)
                return;
            v = Conversions.ToDecimal(s);
        }
        public static void XMLLoadAttribute(string s, ref Color v)
        {
            if (s.Length == 0)
                return;
            v = Color.FromArgb(Conversions.ToInteger(s));
        }

        public static void XMLLoadElementValue(XmlElement n, ref int v)
        {
            if (n is null)
                return;
            XMLLoadAttribute(n.GetAttribute("Value"), ref v);
        }
        public static void XMLLoadElementValue(XmlElement n, ref float v)
        {
            if (n is null)
                return;
            XMLLoadAttribute(n.GetAttribute("Value"), ref v);
        }
        public static void XMLLoadElementValue(XmlElement n, ref Color v)
        {
            if (n is null)
                return;
            XMLLoadAttribute(n.GetAttribute("Value"), ref v);
        }
    }
}