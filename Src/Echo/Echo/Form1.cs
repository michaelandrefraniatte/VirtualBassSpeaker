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
            waveOut = new WasapiOut(wasapi, AudioClientShareMode.Exclusive, false, 2);
            waveProvider = new BufferedWaveProvider(waveOut.OutputWaveFormat);
            waveOut.Init(waveProvider);
            waveOut.Play();
            waveIn = new WasapiCapture();
            waveIn.DataAvailable += waveIn_DataAvailable;
            waveIn.StartRecording();
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