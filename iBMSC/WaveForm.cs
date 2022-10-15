using System;
using System.Windows.Forms;
using CSCore;
using CSCore.Codecs;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace iBMSC
{


    public partial class MainWindow
    {

        // ----WaveForm Options
        private float[] wWavL;
        private float[] wWavR;
        private bool wLock = true;
        private int wSampleRate;
        private double wPosition = 0d;
        private int wLeft = 50;
        private int wWidth = 100;
        private int wPrecision = 1;

        private void BWLoad_Click(object sender, EventArgs e)
        {
            var xDWAV = new OpenFileDialog();
            xDWAV.Filter = "Wave files (*.wav, *.ogg)" + "|*.wav;*.ogg";
            xDWAV.DefaultExt = "wav";
            xDWAV.InitialDirectory = Conversions.ToString(Interaction.IIf(string.IsNullOrEmpty(this.ExcludeFileName(this.FileName)), this.InitPath, this.ExcludeFileName(this.FileName)));

            if (xDWAV.ShowDialog() == DialogResult.Cancel)
                return;
            this.InitPath = this.ExcludeFileName(xDWAV.FileName);

            var src = CodecFactory.Instance.GetCodec(xDWAV.FileName);

            src.ToStereo();
            var samples = new float[(int)(src.Length + 1)];
            src.ToSampleSource().Read(samples, 0, (int)src.Length);

            double flen = (src.Length - 1L) / (double)src.WaveFormat.Channels;

            // Copy interleaved data
            wWavL = new float[(int)Math.Round(flen + 1d + 1)];
            wWavR = new float[(int)Math.Round(flen + 1d + 1)];
            for (int i = 0, loopTo = (int)Math.Round(flen); i <= loopTo; i++)
            {
                if (2 * i < src.Length)
                {
                    wWavL[i] = samples[2 * i];
                }
                if (2 * i + 1 < src.Length)
                {
                    wWavR[i] = samples[2 * i + 1];
                }
            }

            wSampleRate = src.WaveFormat.SampleRate;
            this.RefreshPanelAll();

            this.TWFileName.Text = xDWAV.FileName;
            this.TWFileName.Select(Strings.Len(xDWAV.FileName), 0);
        }

        private void BWClear_Click(object sender, EventArgs e)
        {
            wWavL = null;
            wWavR = null;
            this.TWFileName.Text = "(" + iBMSC.Strings.None + ")";
            this.RefreshPanelAll();
        }

        private void BWLock_CheckedChanged(object sender, EventArgs e)
        {
            wLock = this.BWLock.Checked;
            this.TWPosition.Enabled = !wLock;
            this.TWPosition2.Enabled = !wLock;
            this.RefreshPanelAll();
        }
    }
}