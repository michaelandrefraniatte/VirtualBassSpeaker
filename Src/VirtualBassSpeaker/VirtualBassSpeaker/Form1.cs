using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using NAudio.Wave;
using NAudio.Extras;

namespace VirtualBassSpeaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("winmm.dll", EntryPoint = "timeBeginPeriod")]
        public static extern uint TimeBeginPeriod(uint ms);
        [DllImport("winmm.dll", EntryPoint = "timeEndPeriod")]
        public static extern uint TimeEndPeriod(uint ms);
        [DllImport("ntdll.dll", EntryPoint = "NtSetTimerResolution")]
        public static extern void NtSetTimerResolution(uint DesiredResolution, bool SetResolution, ref uint CurrentResolution);
        public static uint CurrentResolution = 0;
        private static WasapiOut soundOutEq;
        private Equalizer equalizer;
        private EqualizerBand[] bands;
        public static BufferedWaveProvider src;
        private static VolumeStereoSampleProvider stereo;
        public static float volumeleft, volumeright;
        private static WasapiLoopbackCapture soundInRec;
        private bool startstopbool = false;
        public static NAudio.CoreAudioApi.MMDevice[] wasapi = { null, null, null, null, null, null, null, null, null };
        private void Form1_Shown(object sender, EventArgs e)
        {
            TimeBeginPeriod(1);
            NtSetTimerResolution(1, true, ref CurrentResolution);
            var enumerator = new NAudio.CoreAudioApi.MMDeviceEnumerator();
            int index = 0;
            foreach (var mmdevice in enumerator.EnumerateAudioEndPoints(NAudio.CoreAudioApi.DataFlow.Render, NAudio.CoreAudioApi.DeviceState.Active))
            {
                comboBox1.Items.Add(mmdevice.DeviceFriendlyName);
                wasapi[index] = mmdevice;
                index++;
            }
            if (System.IO.File.Exists("tempsave"))
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader("tempsave"))
                {
                    comboBox1.SelectedIndex = Convert.ToInt32(file.ReadLine());
                    trackBar1.Value = Convert.ToInt32(file.ReadLine());
                    trackBar2.Value = Convert.ToInt32(file.ReadLine());
                    trackBar3.Value = Convert.ToInt32(file.ReadLine());
                    trackBar4.Value = Convert.ToInt32(file.ReadLine());
                    trackBar5.Value = Convert.ToInt32(file.ReadLine());
                    trackBar6.Value = Convert.ToInt32(file.ReadLine());
                    trackBar7.Value = Convert.ToInt32(file.ReadLine());
                    trackBar8.Value = Convert.ToInt32(file.ReadLine());
                    trackBar9.Value = Convert.ToInt32(file.ReadLine());
                    trackBar10.Value = Convert.ToInt32(file.ReadLine());
                    trackBar11.Value = Convert.ToInt32(file.ReadLine());
                    trackBar12.Value = Convert.ToInt32(file.ReadLine());
                    trackBar13.Value = Convert.ToInt32(file.ReadLine());
                }
            }
            label1.Text = trackBar1.Value > 0 ? "+" + trackBar1.Value.ToString() : trackBar1.Value.ToString();
            label2.Text = trackBar2.Value > 0 ? "+" + trackBar2.Value.ToString() : trackBar2.Value.ToString();
            label3.Text = trackBar3.Value > 0 ? "+" + trackBar3.Value.ToString() : trackBar3.Value.ToString();
            label4.Text = trackBar4.Value > 0 ? "+" + trackBar4.Value.ToString() : trackBar4.Value.ToString();
            label5.Text = trackBar5.Value > 0 ? "+" + trackBar5.Value.ToString() : trackBar5.Value.ToString();
            label6.Text = trackBar6.Value > 0 ? "+" + trackBar6.Value.ToString() : trackBar6.Value.ToString();
            label7.Text = trackBar7.Value > 0 ? "+" + trackBar7.Value.ToString() : trackBar7.Value.ToString();
            label8.Text = trackBar8.Value > 0 ? "+" + trackBar8.Value.ToString() : trackBar8.Value.ToString();
            label9.Text = trackBar9.Value > 0 ? "+" + trackBar9.Value.ToString() : trackBar9.Value.ToString();
            label10.Text = trackBar10.Value > 0 ? "+" + trackBar10.Value.ToString() : trackBar10.Value.ToString();
            label11.Text = trackBar11.Value > 0 ? "+" + trackBar11.Value.ToString() : trackBar11.Value.ToString();
            label12.Text = trackBar12.Value > 0 ? trackBar12.Value.ToString() + " %" : "0 %";
            label13.Text = trackBar13.Value > 0 ? trackBar13.Value.ToString() + " %" : "0 %";
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
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                soundOutEq.Stop();
            }
            catch { }
            try
            {
                soundInRec.StopRecording();
            }
            catch { }
            using (System.IO.StreamWriter createdfile = new System.IO.StreamWriter("tempsave"))
            {
                createdfile.WriteLine(comboBox1.SelectedIndex);
                createdfile.WriteLine(trackBar1.Value);
                createdfile.WriteLine(trackBar2.Value);
                createdfile.WriteLine(trackBar3.Value);
                createdfile.WriteLine(trackBar4.Value);
                createdfile.WriteLine(trackBar5.Value);
                createdfile.WriteLine(trackBar6.Value);
                createdfile.WriteLine(trackBar7.Value);
                createdfile.WriteLine(trackBar8.Value);
                createdfile.WriteLine(trackBar9.Value);
                createdfile.WriteLine(trackBar10.Value);
                createdfile.WriteLine(trackBar11.Value);
                createdfile.WriteLine(trackBar12.Value);
                createdfile.WriteLine(trackBar13.Value);
            }
        }
        private void SetEq()
        {
            bands = new EqualizerBand[]
                    {
                        new EqualizerBand {Bandwidth = 0.8f, Frequency = 50, Gain = trackBar1.Value},
                        new EqualizerBand {Bandwidth = 0.8f, Frequency = 100, Gain = trackBar2.Value},
                        new EqualizerBand {Bandwidth = 0.8f, Frequency = 200, Gain = trackBar3.Value},
                        new EqualizerBand {Bandwidth = 0.8f, Frequency = 400, Gain = trackBar4.Value},
                        new EqualizerBand {Bandwidth = 0.8f, Frequency = 800, Gain = trackBar5.Value},
                        new EqualizerBand {Bandwidth = 0.8f, Frequency = 1200, Gain = trackBar6.Value},
                        new EqualizerBand {Bandwidth = 0.8f, Frequency = 2400, Gain = trackBar7.Value},
                        new EqualizerBand {Bandwidth = 0.8f, Frequency = 4800, Gain = trackBar8.Value},
                        new EqualizerBand {Bandwidth = 0.8f, Frequency = 9600, Gain = trackBar9.Value},
                        new EqualizerBand {Bandwidth = 0.8f, Frequency = 13500, Gain = trackBar10.Value},
                        new EqualizerBand {Bandwidth = 0.8f, Frequency = 21000, Gain = trackBar11.Value},
                    };
            volumeleft = trackBar12.Value / 100f;
            volumeright = trackBar13.Value / 100f;
            soundOutEq = new WasapiOut(wasapi[comboBox1.SelectedIndex], NAudio.CoreAudioApi.AudioClientShareMode.Exclusive, false, 2);
            src = new BufferedWaveProvider(soundInRec.WaveFormat);
            stereo = new VolumeStereoSampleProvider(src.ToSampleProvider());
            equalizer = new Equalizer(stereo, bands);
            soundOutEq.Init(equalizer);
            soundOutEq.Play();
        }
        private static void SetRec()
        {
            soundInRec = new WasapiLoopbackCapture();
            soundInRec.StartRecording();
            soundInRec.DataAvailable += (sound, card) =>
            {
                if (card.BytesRecorded > 0 & src != null)
                {
                    Task.Run(() => Write(card));
                }
            };
        }
        private static void Write(WaveInEventArgs data)
        {
            src.AddSamples(data.Buffer, 0, data.BytesRecorded);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!startstopbool)
            {
                startstopbool = true;
                SetRec();
                SetEq();
            }
        }
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value > 0 ? "+" + trackBar1.Value.ToString() : trackBar1.Value.ToString();
        }
        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = trackBar2.Value > 0 ? "+" + trackBar2.Value.ToString() : trackBar2.Value.ToString();
        }
        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            label3.Text = trackBar3.Value > 0 ? "+" + trackBar3.Value.ToString() : trackBar3.Value.ToString();
        }
        private void trackBar4_ValueChanged(object sender, EventArgs e)
        {
            label4.Text = trackBar4.Value > 0 ? "+" + trackBar4.Value.ToString() : trackBar4.Value.ToString();
        }
        private void trackBar5_ValueChanged(object sender, EventArgs e)
        {
            label5.Text = trackBar5.Value > 0 ? "+" + trackBar5.Value.ToString() : trackBar5.Value.ToString();
        }
        private void trackBar6_ValueChanged(object sender, EventArgs e)
        {
            label6.Text = trackBar6.Value > 0 ? "+" + trackBar6.Value.ToString() : trackBar6.Value.ToString();
        }
        private void trackBar7_ValueChanged(object sender, EventArgs e)
        {
            label7.Text = trackBar7.Value > 0 ? "+" + trackBar7.Value.ToString() : trackBar7.Value.ToString();
        }
        private void trackBar8_ValueChanged(object sender, EventArgs e)
        {
            label8.Text = trackBar8.Value > 0 ? "+" + trackBar8.Value.ToString() : trackBar8.Value.ToString();
        }
        private void trackBar9_ValueChanged(object sender, EventArgs e)
        {
            label9.Text = trackBar9.Value > 0 ? "+" + trackBar9.Value.ToString() : trackBar9.Value.ToString();
        }
        private void trackBar10_ValueChanged(object sender, EventArgs e)
        {
            label10.Text = trackBar10.Value > 0 ? "+" + trackBar10.Value.ToString() : trackBar10.Value.ToString();
        }
        private void trackBar11_ValueChanged(object sender, EventArgs e)
        {
            label11.Text = trackBar11.Value > 0 ? "+" + trackBar11.Value.ToString() : trackBar11.Value.ToString();
        }
        private void trackBar12_ValueChanged(object sender, EventArgs e)
        {
            label12.Text = trackBar12.Value > 0 ? trackBar12.Value.ToString() + " %" : "0 %";
        }
        private void trackBar13_ValueChanged(object sender, EventArgs e)
        {
            label13.Text = trackBar13.Value > 0 ? trackBar13.Value.ToString() + " %" : "0 %";
        }
    }
    /// <summary>
    /// Very simple sample provider supporting adjustable gain
    /// </summary>
    public class VolumeStereoSampleProvider : ISampleProvider
    {
        private readonly ISampleProvider source;

        /// <summary>
        /// Allows adjusting the volume left channel, 1.0f = full volume
        /// </summary>
        public float VolumeLeft { get; set; }

        /// <summary>
        /// Allows adjusting the volume right channel, 1.0f = full volume
        /// </summary>
        public float VolumeRight { get; set; }

        /// <summary>
        /// Initializes a new instance of VolumeStereoSampleProvider
        /// </summary>
        /// <param name="source">Source sample provider, must be stereo</param>
        public VolumeStereoSampleProvider(ISampleProvider source)
        {
            this.source = source;
            VolumeLeft = Form1.volumeleft;
            VolumeRight = Form1.volumeright;
        }

        /// <summary>
        /// WaveFormat
        /// </summary>
        public WaveFormat WaveFormat => source.WaveFormat;

        /// <summary>
        /// Reads samples from this sample provider
        /// </summary>
        /// <param name="buffer">Sample buffer</param>
        /// <param name="offset">Offset into sample buffer</param>
        /// <param name="sampleCount">Number of samples desired</param>
        /// <returns>Number of samples read</returns>
        public int Read(float[] buffer, int offset, int sampleCount)
        {
            int samplesRead = source.Read(buffer, offset, sampleCount);

            for (int n = 0; n < sampleCount; n += 2)
            {
                buffer[offset + n] *= VolumeLeft;
                buffer[offset + n + 1] *= VolumeRight;
            }

            return samplesRead;
        }
    }
}