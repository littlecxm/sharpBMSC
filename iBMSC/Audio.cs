using System;
using System.IO;
using CSCore;
using CSCore.Codecs;
using CSCore.SoundOut;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NVorbis;

namespace iBMSC
{

    static class Audio
    {
        private static WasapiOut Output;
        private static IWaveSource Source;

        public static void Initialize()
        {
            Output = new WasapiOut();
            CodecFactory.Instance.Register("ogg", new CodecFactoryEntry(s => new NVorbisSource(s).ToWaveSource(), ".ogg"));
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
            string ext = Path.GetExtension(filename);
            if (string.Compare(ext, ".ogg") == 0)
            {
                string wpath = Path.ChangeExtension(filename, ".wav");
                return Conversions.ToString(Interaction.IIf(File.Exists(wpath), wpath, filename));
            }
            if (string.Compare(ext, ".wav") == 0)
            {
                string opath = Path.ChangeExtension(filename, ".ogg");
                return Conversions.ToString(Interaction.IIf(File.Exists(opath), opath, filename));
            }
            return filename;
        }

        public static void Play(string filename)
        {

            if (Source is not null)
            {
                Output.Stop();
                Source.Dispose();
                Source = null;
            }

            if (ReferenceEquals(filename, ""))
            {
                return;
            }

            string fn = CheckFilename(filename);

            if (!File.Exists(fn))
            {
                return;
            }

            Source = CodecFactory.Instance.GetCodec(fn);
            Output.Initialize(Source);
            Output.Play();
        }

        public static void StopPlaying()
        {
            Output.Stop();
        }
    }

    class NVorbisSource : ISampleSource
    {
        private Stream _stream;
        private VorbisReader _vorbisReader;
        private WaveFormat _waveFormat;
        private bool _disposed;

        public NVorbisSource(Stream stream)
        {
            if (stream is null | !stream.CanRead)
            {
                throw new ArgumentException("stream");
            }
            _stream = stream;
            _vorbisReader = new VorbisReader(stream, default);
            _waveFormat = new WaveFormat(_vorbisReader.SampleRate, 32, _vorbisReader.Channels, AudioEncoding.IeeeFloat);
        }

        public bool CanSeek
        {
            get
            {
                return _stream.CanSeek;
            }
        }

        public WaveFormat WaveFormat
        {
            get
            {
                return _waveFormat;
            }
        }

        public long Length
        {
            get
            {
                return Conversions.ToLong(Interaction.IIf(CanSeek, _vorbisReader.TotalTime.TotalSeconds * _waveFormat.SampleRate * _waveFormat.Channels, 0));
            }
        }

        public long Position
        {
            get
            {
                return Conversions.ToLong(Interaction.IIf(CanSeek, _vorbisReader.DecodedTime.TotalSeconds * _vorbisReader.SampleRate * _vorbisReader.Channels, 0));
            }
            set
            {
                if (!CanSeek)
                {
                    throw new InvalidOperationException("Can't seek this stream.");
                }
                if (value < 0L | value >= Length)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                _vorbisReader.DecodedTime = TimeSpan.FromSeconds(value / (double)_vorbisReader.SampleRate / _vorbisReader.Channels);
            }
        }


        public int Read(float[] buffer, int offset, int count)
        {
            return _vorbisReader.ReadSamples(buffer, offset, count);
        }

        public void Dispose()
        {
            if (!_disposed)
            {
            }
            // _vorbisReader.Dispose()
            else
            {
                // Throw New ObjectDisposedException("NVorbisSource")
            }
            _disposed = true;
        }

    }
}