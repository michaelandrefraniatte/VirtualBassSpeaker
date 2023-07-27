using System;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace EchoEqualizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private WaveIn waveIn = null;
        private BufferedWaveProvider waveProvider = null;
        private WasapiOut waveOut = null;
        private void button1_Click(object sender, EventArgs e)
        {
            waveIn = new WaveIn(this.Handle);
            waveIn.BufferMilliseconds = 10;
            waveIn.DataAvailable += waveIn_DataAvailable;
            waveProvider = new BufferedWaveProvider(waveIn.WaveFormat);
            var enumerator = new MMDeviceEnumerator();
            MMDevice wasapi = null;
            foreach (var mmdevice in enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
            {
                MessageBox.Show(mmdevice.DeviceFriendlyName);
                wasapi = mmdevice;
                break;
            }
            waveOut = new WasapiOut(wasapi, AudioClientShareMode.Shared, false, 2);
            waveOut.Init(waveProvider);
            waveOut.Play();
            waveIn.StartRecording();
        }
        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (e.BytesRecorded > 0 & waveProvider != null)
                waveProvider.AddSamples(e.Buffer, 0, e.BytesRecorded);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (waveIn != null)
                waveIn.StopRecording();
            if (waveOut != null)
                waveOut.Stop();
            if (waveProvider != null)
                waveProvider = null;
        }
    }
}