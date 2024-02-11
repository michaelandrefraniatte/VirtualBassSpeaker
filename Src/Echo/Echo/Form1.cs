using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace Echo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("winmm.dll", EntryPoint = "timeBeginPeriod")]
        private static extern uint TimeBeginPeriod(uint ms);
        [DllImport("winmm.dll", EntryPoint = "timeEndPeriod")]
        private static extern uint TimeEndPeriod(uint ms);
        [DllImport("ntdll.dll", EntryPoint = "NtSetTimerResolution")]
        private static extern void NtSetTimerResolution(uint DesiredResolution, bool SetResolution, ref uint CurrentResolution);
        private static uint CurrentResolution = 0;
        private WasapiCapture waveIn = null;
        private BufferedWaveProvider waveProvider = null;
        private WasapiOut waveOut = null;
        private static bool capturedevicefirst = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            TimeBeginPeriod(1);
            NtSetTimerResolution(1, true, ref CurrentResolution);
            using (StreamReader file = new StreamReader("params.txt"))
            {
                file.ReadLine();
                capturedevicefirst = bool.Parse(file.ReadLine());
            }
            var enumerator = new MMDeviceEnumerator();
            MMDevice wasapi = null;
            foreach (var mmdevice in enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
            {
                wasapi = mmdevice;
                if (!capturedevicefirst)
                    break;
            }
            waveOut = new WasapiOut(wasapi, AudioClientShareMode.Shared, false, 2);
            waveProvider = new BufferedWaveProvider(waveOut.OutputWaveFormat);
            waveOut.Init(waveProvider);
            waveOut.Play();
            waveIn = new WasapiCapture();
            waveIn.DataAvailable += waveIn_DataAvailable;
            waveIn.StartRecording();
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
        private void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (e.BytesRecorded > 0 & waveProvider != null)
            {
                byte[] rawdata = new byte[e.BytesRecorded];
                Array.Copy(e.Buffer, 0, rawdata, 0, e.BytesRecorded);
                waveProvider.AddSamples(rawdata, 0, rawdata.Length);
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
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