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
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            OnKeyDown(e.KeyData);
        }
        private void OnKeyDown(Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                const string message = "• Author: Michaël André Franiatte.\n\r\n\r• Contact: michael.franiatte@gmail.com.\n\r\n\r• Publisher: https://github.com/michaelandrefraniatte.\n\r\n\r• Copyrights: All rights reserved, no permissions granted.\n\r\n\r• License: Not open source, not free of charge to use.";
                const string caption = "About";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (keyData == Keys.Escape)
            {
                this.Close();
            }
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