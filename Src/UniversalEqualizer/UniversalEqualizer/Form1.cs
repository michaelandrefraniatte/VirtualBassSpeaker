using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSCore;
using System.Runtime.InteropServices;
using CSCore.CoreAudioAPI;
using CSCore.Codecs;
using CSCore.DirectSound;
using CSCore.DMO;
using CSCore.DSP;
using CSCore.MediaFoundation;
using CSCore.SoundIn;
using CSCore.SoundOut;
using CSCore.Streams;
using CSCore.Tags;
using CSCore.Utils;
using CSCore.Win32;
using CSCore.XAudio2;
using CSCore.Codecs.MP3;
using NAudio;
using NAudio.Wave;
using NAudio.Extras;
namespace UniversalEqualizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static WasapiCapture soundInEq;
        private static NAudio.Wave.WaveOut soundOutEq;
        private NAudio.Extras.Equalizer equalizer;
        private EqualizerBand[] bands;
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Stop();
            using (System.IO.StreamWriter createdfile = new System.IO.StreamWriter("tempsave"))
            {
                createdfile.WriteLine(trackBar1.Value);
                createdfile.WriteLine(trackBar2.Value);
                createdfile.WriteLine(trackBar3.Value);
                createdfile.WriteLine(trackBar4.Value);
                createdfile.WriteLine(trackBar5.Value);
                createdfile.WriteLine(trackBar6.Value);
                createdfile.WriteLine(trackBar7.Value);
                createdfile.WriteLine(trackBar8.Value);
            }
            try
            {
                using (Process p = Process.GetCurrentProcess())
                {
                    p.Kill();
                }
            }
            catch { }
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            if (System.IO.File.Exists("tempsave"))
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader("tempsave"))
                {
                    trackBar1.Value = Convert.ToInt32(file.ReadLine());
                    trackBar2.Value = Convert.ToInt32(file.ReadLine());
                    trackBar3.Value = Convert.ToInt32(file.ReadLine());
                    trackBar4.Value = Convert.ToInt32(file.ReadLine());
                    trackBar5.Value = Convert.ToInt32(file.ReadLine());
                    trackBar6.Value = Convert.ToInt32(file.ReadLine());
                    trackBar7.Value = Convert.ToInt32(file.ReadLine());
                    trackBar8.Value = Convert.ToInt32(file.ReadLine());
                }
            }
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
        private void Form1_Load(object sender, EventArgs e)
        {
            Task.Run(() => GetAudioApps());
        }
        private void GetAudioApps()
        {
            for (int i = 0; i < NAudio.Wave.WaveOut.DeviceCount; i++)
            {
                WaveOutCapabilities waveoutCapabilities = NAudio.Wave.WaveOut.GetCapabilities(i);
                comboBox1.Items.Add(waveoutCapabilities.ProductName);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SetEq();
        }
        private void SetEq()
        {
            Stop();
            SetEqualizerBand();
            try
            {
                soundInEq = new WasapiCapture(true, AudioClientShareMode.Shared, 0);
                soundInEq.Initialize();
                var src = new BufferedWaveProvider(NAudio.Wave.WaveFormat.CreateIeeeFloatWaveFormat(48000, 2));
                equalizer = new Equalizer(src.ToSampleProvider(), bands);
                soundInEq.DataAvailable += (sound, card) =>
                {
                    byte[] rawdata = new byte[card.ByteCount];
                    Array.Copy(card.Data, card.Offset, rawdata, 0, card.ByteCount);
                    src.AddSamples(rawdata, 0, rawdata.Length);
                };
                soundInEq.Start();
                soundOutEq = new NAudio.Wave.WaveOut();
                soundOutEq.DeviceNumber = comboBox1.SelectedIndex;
                soundOutEq.Init(equalizer);
                soundOutEq.Play();
            }
            catch { }
        }
        private void SetEqualizerBand()
        {
            bands = new EqualizerBand[]
                    {
                        new EqualizerBand {Bandwidth = 0.8f, Frequency = 100, Gain = trackBar1.Value},
                        new EqualizerBand {Bandwidth = 0.8f, Frequency = 200, Gain = trackBar2.Value},
                        new EqualizerBand {Bandwidth = 0.8f, Frequency = 400, Gain = trackBar3.Value},
                        new EqualizerBand {Bandwidth = 0.8f, Frequency = 800, Gain = trackBar4.Value},
                        new EqualizerBand {Bandwidth = 0.8f, Frequency = 1200, Gain = trackBar5.Value},
                        new EqualizerBand {Bandwidth = 0.8f, Frequency = 2400, Gain = trackBar6.Value},
                        new EqualizerBand {Bandwidth = 0.8f, Frequency = 4800, Gain = trackBar7.Value},
                        new EqualizerBand {Bandwidth = 0.8f, Frequency = 9600, Gain = trackBar8.Value},
                    };
        }
        private static void Stop()
        {
            try
            {
                soundOutEq.Stop();
            }
            catch { }
            try
            {
                soundInEq.Stop();
            }
            catch { }
        }
    }
}