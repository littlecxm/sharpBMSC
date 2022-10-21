using System;
using System.IO;
using CSCore;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NVorbis;

namespace iBMSC;

internal class NVorbisSource : ISampleSource
{
    private Stream _stream;

    private VorbisReader _vorbisReader;

    private WaveFormat _waveFormat;

    private bool _disposed;

    public bool CanSeek => _stream.CanSeek;

    public WaveFormat WaveFormat => _waveFormat;

    public long Length => Conversions.ToLong(Interaction.IIf(CanSeek, _vorbisReader.TotalTime.TotalSeconds * _waveFormat.SampleRate * _waveFormat.Channels, 0));

    public long Position
    {
        get => Conversions.ToLong(Interaction.IIf(CanSeek, _vorbisReader.DecodedTime.TotalSeconds * _vorbisReader.SampleRate * _vorbisReader.Channels, 0));
        set
        {
            if (!CanSeek)
            {
                throw new InvalidOperationException("Can't seek this stream.");
            }
            if ((value < 0) | (value >= Length))
            {
                throw new ArgumentOutOfRangeException("value");
            }
            _vorbisReader.DecodedTime = TimeSpan.FromSeconds(value / (double)_vorbisReader.SampleRate / _vorbisReader.Channels);
        }
    }

    public NVorbisSource(Stream stream)
    {
        if ((stream == null) | !stream.CanRead)
        {
            throw new ArgumentException("stream");
        }
        _stream = stream;
        _vorbisReader = new VorbisReader(stream, closeOnDispose: false);
        _waveFormat = new WaveFormat(_vorbisReader.SampleRate, 32, _vorbisReader.Channels, AudioEncoding.IeeeFloat);
    }

    public int Read(float[] buffer, int offset, int count)
    {
        return _vorbisReader.ReadSamples(buffer, offset, count);
    }

    int IReadableAudioSource<float>.Read(float[] buffer, int offset, int count)
    {
        //ILSpy generated this explicit interface implementation from .override directive in Read
        return Read(buffer, offset, count);
    }

    public void Dispose()
    {
        if (!_disposed)
        {
        }
        _disposed = true;
    }

    void IDisposable.Dispose()
    {
        //ILSpy generated this explicit interface implementation from .override directive in Dispose
        Dispose();
    }
}
