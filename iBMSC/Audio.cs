using System;
using System.IO;
using System.Runtime.CompilerServices;
using CSCore;
using CSCore.Codecs;
using CSCore.SoundOut;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace iBMSC;

internal static class Audio
{
    private static WasapiOut Output;

    private static IWaveSource Source;

    public static void Initialize()
    {
        Output = new WasapiOut();
        CodecFactory.Instance.Register("ogg", new CodecFactoryEntry([SpecialName] (Stream s) => new NVorbisSource(s).ToWaveSource(), new string[1] { ".ogg" }));
    }

    public static void Finalize()
    {
        Output.Stop();
        Output.Dispose();
        Output = null;
    }

    public static string CheckFilename(string filename)
    {
        if (File.Exists(filename))
        {
            return filename;
        }
        var extension = Path.GetExtension(filename);
        if (string.Compare(extension, ".ogg") == 0)
        {
            var text = Path.ChangeExtension(filename, ".wav");
            return Conversions.ToString(Interaction.IIf(File.Exists(text), text, filename));
        }
        if (string.Compare(extension, ".wav") == 0)
        {
            var text2 = Path.ChangeExtension(filename, ".ogg");
            return Conversions.ToString(Interaction.IIf(File.Exists(text2), text2, filename));
        }
        return filename;
    }

    public static void Play(string filename)
    {
        if (Source != null)
        {
            Output.Stop();
            Source.Dispose();
            Source = null;
        }
        if ((object)filename != "")
        {
            var text = CheckFilename(filename);
            if (File.Exists(text))
            {
                Source = CodecFactory.Instance.GetCodec(text);
                Output.Initialize(Source);
                Output.Play();
            }
        }
    }

    public static void StopPlaying()
    {
        Output.Stop();
    }
}
