using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSCore;
using CSCore.CoreAudioAPI;
using CSCore.SoundIn;
using CSCore.SoundOut;
using CSCore.Streams;
using CSCore.Streams.Effects;
using System.Threading;
using CSCore.Codecs;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using CSCore.DSP;
using System.IO;
using CSCore.Codecs.MP3;

namespace SoundBooster
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static WasapiCapture soundInEcho;
        private static NAudio.Wave.WaveOut soundOutEcho;
        private static IWaveSource sourceEcho;
        private static CSCore.Streams.Effects.DmoEchoEffect _EchoSource;
        public static WasapiCapture soundInNormal;
        private static NAudio.Wave.WaveOut soundOutNormal;
        public static WasapiCapture soundInReverb;
        private static NAudio.Wave.WaveOut soundOutReverb;
        private static IWaveSource sourceReverb;
        private static CSCore.Streams.Effects.DmoWavesReverbEffect _ReverbSource;
        public static WasapiCapture soundInFlanger;
        private static NAudio.Wave.WaveOut soundOutFlanger;
        private static IWaveSource sourceFlanger;
        private static CSCore.Streams.Effects.DmoFlangerEffect _FlangerSource;
        public static WasapiCapture soundInGargle;
        private static NAudio.Wave.WaveOut soundOutGargle;
        private static IWaveSource sourceGargle;
        private static CSCore.Streams.Effects.DmoGargleEffect _GargleSource;
        public static WasapiCapture soundInDistortion;
        private static NAudio.Wave.WaveOut soundOutDistortion;
        private static IWaveSource sourceDistortion;
        private static CSCore.Streams.Effects.DmoDistortionEffect _DistortionSource;
        public static WasapiCapture soundInCompressor;
        private static NAudio.Wave.WaveOut soundOutCompressor;
        private static IWaveSource sourceCompressor;
        private static CSCore.Streams.Effects.DmoCompressorEffect _CompressorSource;
        public static WasapiCapture soundInChorus;
        private static NAudio.Wave.WaveOut soundOutChorus;
        private static IWaveSource sourceChorus;
        private static CSCore.Streams.Effects.DmoChorusEffect _ChorusSource;
        private void Form1_Shown(object sender, EventArgs e)
        {
            if (System.IO.File.Exists("tempsave"))
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader("tempsave"))
                {
                    checkBoxEcho.Checked = bool.Parse(file.ReadLine());
                    trackBarEcho.Value = Convert.ToInt32(file.ReadLine());
                    checkBoxNormal.Checked = bool.Parse(file.ReadLine());
                    trackBarNormal.Value = Convert.ToInt32(file.ReadLine());
                    checkBoxReverb.Checked = bool.Parse(file.ReadLine());
                    trackBarReverb.Value = Convert.ToInt32(file.ReadLine());
                    checkBoxFlanger.Checked = bool.Parse(file.ReadLine());
                    trackBarFlanger.Value = Convert.ToInt32(file.ReadLine());
                    checkBoxGargle.Checked = bool.Parse(file.ReadLine());
                    trackBarGargle.Value = Convert.ToInt32(file.ReadLine());
                    checkBoxDistortion.Checked = bool.Parse(file.ReadLine());
                    trackBarDistortion.Value = Convert.ToInt32(file.ReadLine());
                    checkBoxCompressor.Checked = bool.Parse(file.ReadLine());
                    trackBarCompressor.Value = Convert.ToInt32(file.ReadLine());
                    checkBoxChorus.Checked = bool.Parse(file.ReadLine());
                    trackBarChorus.Value = Convert.ToInt32(file.ReadLine());
                }
            }
        }
        private static void SetEcho(int latency)
        {
            try
            {
                soundOutEcho.Stop();
            }
            catch { }
            soundInEcho = new WasapiCapture(true, AudioClientShareMode.Shared, latency);
            soundInEcho.Initialize();
            sourceEcho = new SoundInSource(soundInEcho);
            _EchoSource = new DmoEchoEffect(sourceEcho);
            var src = new NAudio.Wave.BufferedWaveProvider(NAudio.Wave.WaveFormat.CreateIeeeFloatWaveFormat(48000, 2));
            soundInEcho.DataAvailable += (sound, card) =>
            {
                var sampleSource = _EchoSource;
                byte[] buffer = new byte[card.ByteCount];
                sampleSource.Read(buffer, card.Offset, card.ByteCount);
                byte[] rawdata = new byte[card.ByteCount];
                Array.Copy(buffer, card.Offset, rawdata, 0, card.ByteCount);
                src.AddSamples(rawdata, 0, rawdata.Length);
            };
            soundInEcho.Start();
            soundOutEcho = new NAudio.Wave.WaveOut();
            soundOutEcho.Init(src);
            soundOutEcho.Play();
        }
        private static void StopEcho()
        {
            try
            {
                soundOutEcho.Stop();
            }
            catch { }
        }
        private void checkBoxEcho_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxEcho.Checked)
            {
                int latency = trackBarEcho.Value;
                SetEcho(latency);
            }
            else
            {
                StopEcho();
            }
        }
        private void trackBarEcho_ValueChanged(object sender, EventArgs e)
        {
            if (checkBoxEcho.Checked)
            {
                int latency = trackBarEcho.Value;
                SetEcho(latency);
            }
            else
            {
                StopEcho();
            }
        }
        private void SetNormal(int latency)
        {
            try
            {
                soundOutNormal.Stop();
            }
            catch { }
            soundInNormal = new WasapiCapture(true, AudioClientShareMode.Shared, latency);
            soundInNormal.Initialize();
            var src = new NAudio.Wave.BufferedWaveProvider(NAudio.Wave.WaveFormat.CreateIeeeFloatWaveFormat(48000, 2));
            soundInNormal.DataAvailable += (sound, card) =>
            {
                byte[] rawdata = new byte[card.ByteCount];
                Array.Copy(card.Data, card.Offset, rawdata, 0, card.ByteCount);
                src.AddSamples(rawdata, 0, rawdata.Length);
            };
            soundInNormal.Start();
            soundOutNormal = new NAudio.Wave.WaveOut();
            soundOutNormal.Init(src);
            soundOutNormal.Play();
        }
        private void StopNormal()
        {
            try
            {
                soundOutNormal.Stop();
            }
            catch { }
        }
        private void checkBoxNormal_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxNormal.Checked)
            {
                int latency = trackBarNormal.Value;
                SetNormal(latency);
            }
            else
            {
                StopNormal();
            }
        }
        private void trackBarNormal_ValueChanged(object sender, EventArgs e)
        {
            if (checkBoxNormal.Checked)
            {
                int latency = trackBarNormal.Value;
                SetNormal(latency);
            }
            else
            {
                StopNormal();
            }
        }
        private void SetReverb(int latency)
        {
            try
            {
                soundOutReverb.Stop();
            }
            catch { }
            soundInReverb = new WasapiCapture(true, AudioClientShareMode.Shared, latency);
            soundInReverb.Initialize();
            sourceReverb = new SoundInSource(soundInReverb);
            _ReverbSource = new DmoWavesReverbEffect(sourceReverb);
            var src = new NAudio.Wave.BufferedWaveProvider(NAudio.Wave.WaveFormat.CreateIeeeFloatWaveFormat(48000, 2));
            soundInReverb.DataAvailable += (sound, card) =>
            {
                var sampleSource = _ReverbSource;
                byte[] buffer = new byte[card.ByteCount];
                sampleSource.Read(buffer, card.Offset, card.ByteCount);
                byte[] rawdata = new byte[card.ByteCount];
                Array.Copy(buffer, card.Offset, rawdata, 0, card.ByteCount);
                src.AddSamples(rawdata, 0, rawdata.Length);
            };
            soundInReverb.Start();
            soundOutReverb = new NAudio.Wave.WaveOut();
            soundOutReverb.Init(src);
            soundOutReverb.Play();
        }
        private static void StopReverb()
        {
            try
            {
                soundOutReverb.Stop();
            }
            catch { }
        }
        private void checkBoxReverb_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxReverb.Checked)
            {
                int latency = trackBarReverb.Value;
                SetReverb(latency);
            }
            else
            {
                StopReverb();
            }
        }
        private void trackBarReverb_ValueChanged(object sender, EventArgs e)
        {
            if (checkBoxReverb.Checked)
            {
                int latency = trackBarReverb.Value;
                SetReverb(latency);
            }
            else
            {
                StopReverb();
            }
        }
        private void SetFlanger(int latency)
        {
            try
            {
                soundOutFlanger.Stop();
            }
            catch { }
            soundInFlanger = new WasapiCapture(true, AudioClientShareMode.Shared, latency);
            soundInFlanger.Initialize();
            sourceFlanger = new SoundInSource(soundInFlanger);
            _FlangerSource = new DmoFlangerEffect(sourceFlanger);
            var src = new NAudio.Wave.BufferedWaveProvider(NAudio.Wave.WaveFormat.CreateIeeeFloatWaveFormat(48000, 2));
            soundInFlanger.DataAvailable += (sound, card) =>
            {
                var sampleSource = _FlangerSource;
                byte[] buffer = new byte[card.ByteCount];
                sampleSource.Read(buffer, card.Offset, card.ByteCount);
                byte[] rawdata = new byte[card.ByteCount];
                Array.Copy(buffer, card.Offset, rawdata, 0, card.ByteCount);
                src.AddSamples(rawdata, 0, rawdata.Length);
            };
            soundInFlanger.Start();
            soundOutFlanger = new NAudio.Wave.WaveOut();
            soundOutFlanger.Init(src);
            soundOutFlanger.Play();
        }
        private static void StopFlanger()
        {
            try
            {
                soundOutFlanger.Stop();
            }
            catch { }
        }
        private void checkBoxFlanger_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxFlanger.Checked)
            {
                int latency = trackBarFlanger.Value;
                SetFlanger(latency);
            }
            else
            {
                StopFlanger();
            }
        }
        private void trackBarFlanger_ValueChanged(object sender, EventArgs e)
        {
            if (checkBoxFlanger.Checked)
            {
                int latency = trackBarFlanger.Value;
                SetFlanger(latency);
            }
            else
            {
                StopFlanger();
            }
        }
        private void SetGargle(int latency)
        {
            try
            {
                soundOutGargle.Stop();
            }
            catch { }
            soundInGargle = new WasapiCapture(true, AudioClientShareMode.Shared, latency);
            soundInGargle.Initialize();
            sourceGargle = new SoundInSource(soundInGargle);
            _GargleSource = new DmoGargleEffect(sourceGargle);
            var src = new NAudio.Wave.BufferedWaveProvider(NAudio.Wave.WaveFormat.CreateIeeeFloatWaveFormat(48000, 2));
            soundInGargle.DataAvailable += (sound, card) =>
            {
                var sampleSource = _GargleSource;
                byte[] buffer = new byte[card.ByteCount];
                sampleSource.Read(buffer, card.Offset, card.ByteCount);
                byte[] rawdata = new byte[card.ByteCount];
                Array.Copy(buffer, card.Offset, rawdata, 0, card.ByteCount);
                src.AddSamples(rawdata, 0, rawdata.Length);
            };
            soundInGargle.Start();
            soundOutGargle = new NAudio.Wave.WaveOut();
            soundOutGargle.Init(src);
            soundOutGargle.Play();
        }
        private static void StopGargle()
        {
            try
            {
                soundOutGargle.Stop();
            }
            catch { }
        }
        private void checkBoxGargle_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxGargle.Checked)
            {
                int latency = trackBarGargle.Value;
                SetGargle(latency);
            }
            else
            {
                StopGargle();
            }
        }
        private void trackBarGargle_ValueChanged(object sender, EventArgs e)
        {
            if (checkBoxGargle.Checked)
            {
                int latency = trackBarGargle.Value;
                SetGargle(latency);
            }
            else
            {
                StopGargle();
            }
        }
        private void SetDistortion(int latency)
        {
            try
            {
                soundOutDistortion.Stop();
            }
            catch { }
            soundInDistortion = new WasapiCapture(true, AudioClientShareMode.Shared, latency);
            soundInDistortion.Initialize();
            sourceDistortion = new SoundInSource(soundInDistortion);
            _DistortionSource = new DmoDistortionEffect(sourceDistortion);
            var src = new NAudio.Wave.BufferedWaveProvider(NAudio.Wave.WaveFormat.CreateIeeeFloatWaveFormat(48000, 2));
            soundInDistortion.DataAvailable += (sound, card) =>
            {
                var sampleSource = _DistortionSource;
                byte[] buffer = new byte[card.ByteCount];
                sampleSource.Read(buffer, card.Offset, card.ByteCount);
                byte[] rawdata = new byte[card.ByteCount];
                Array.Copy(buffer, card.Offset, rawdata, 0, card.ByteCount);
                src.AddSamples(rawdata, 0, rawdata.Length);
            };
            soundInDistortion.Start();
            soundOutDistortion = new NAudio.Wave.WaveOut();
            soundOutDistortion.Init(src);
            soundOutDistortion.Play();
        }
        private static void StopDistortion()
        {
            try
            {
                soundOutDistortion.Stop();
            }
            catch { }
        }
        private void checkBoxDistortion_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxDistortion.Checked)
            {
                int latency = trackBarDistortion.Value;
                SetDistortion(latency);
            }
            else
            {
                StopDistortion();
            }
        }
        private void trackBarDistortion_ValueChanged(object sender, EventArgs e)
        {
            if (checkBoxDistortion.Checked)
            {
                int latency = trackBarDistortion.Value;
                SetDistortion(latency);
            }
            else
            {
                StopDistortion();
            }
        }
        private void SetCompressor(int latency)
        {
            try
            {
                soundOutCompressor.Stop();
            }
            catch { }
            soundInCompressor = new WasapiCapture(true, AudioClientShareMode.Shared, latency);
            soundInCompressor.Initialize();
            sourceCompressor = new SoundInSource(soundInCompressor);
            _CompressorSource = new DmoCompressorEffect(sourceCompressor);
            var src = new NAudio.Wave.BufferedWaveProvider(NAudio.Wave.WaveFormat.CreateIeeeFloatWaveFormat(48000, 2));
            soundInCompressor.DataAvailable += (sound, card) =>
            {
                var sampleSource = _CompressorSource;
                byte[] buffer = new byte[card.ByteCount];
                sampleSource.Read(buffer, card.Offset, card.ByteCount);
                byte[] rawdata = new byte[card.ByteCount];
                Array.Copy(buffer, card.Offset, rawdata, 0, card.ByteCount);
                src.AddSamples(rawdata, 0, rawdata.Length);
            };
            soundInCompressor.Start();
            soundOutCompressor = new NAudio.Wave.WaveOut();
            soundOutCompressor.Init(src);
            soundOutCompressor.Play();
        }
        private static void StopCompressor()
        {
            try
            {
                soundOutCompressor.Stop();
            }
            catch { }
        }
        private void checkBoxCompressor_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxCompressor.Checked)
            {
                int latency = trackBarCompressor.Value;
                SetCompressor(latency);
            }
            else
            {
                StopCompressor();
            }
        }
        private void trackBarCompressor_ValueChanged(object sender, EventArgs e)
        {
            if (checkBoxCompressor.Checked)
            {
                int latency = trackBarCompressor.Value;
                SetCompressor(latency);
            }
            else
            {
                StopCompressor();
            }
        }
        private void SetChorus(int latency)
        {
            try
            {
                soundOutChorus.Stop();
            }
            catch { }
            soundInChorus = new WasapiCapture(true, AudioClientShareMode.Shared, latency);
            soundInChorus.Initialize();
            sourceChorus = new SoundInSource(soundInChorus);
            _ChorusSource = new DmoChorusEffect(sourceChorus);
            var src = new NAudio.Wave.BufferedWaveProvider(NAudio.Wave.WaveFormat.CreateIeeeFloatWaveFormat(48000, 2));
            soundInChorus.DataAvailable += (sound, card) =>
            {
                var sampleSource = _ChorusSource;
                byte[] buffer = new byte[card.ByteCount];
                sampleSource.Read(buffer, card.Offset, card.ByteCount);
                byte[] rawdata = new byte[card.ByteCount];
                Array.Copy(buffer, card.Offset, rawdata, 0, card.ByteCount);
                src.AddSamples(rawdata, 0, rawdata.Length);
            };
            soundInChorus.Start();
            soundOutChorus = new NAudio.Wave.WaveOut();
            soundOutChorus.Init(src);
            soundOutChorus.Play();
        }
        private static void StopChorus()
        {
            try
            {
                soundOutChorus.Stop();
            }
            catch { }
        }
        private void checkBoxChorus_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxChorus.Checked)
            {
                int latency = trackBarChorus.Value;
                SetChorus(latency);
            }
            else
            {
                StopChorus();
            }
        }
        private void trackBarChorus_ValueChanged(object sender, EventArgs e)
        {
            if (checkBoxChorus.Checked)
            {
                int latency = trackBarChorus.Value;
                SetChorus(latency);
            }
            else
            {
                StopChorus();
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            using (System.IO.StreamWriter createdfile = new System.IO.StreamWriter("tempsave"))
            {
                createdfile.WriteLine(checkBoxEcho.Checked);
                createdfile.WriteLine(trackBarEcho.Value);
                createdfile.WriteLine(checkBoxNormal.Checked);
                createdfile.WriteLine(trackBarNormal.Value);
                createdfile.WriteLine(checkBoxReverb.Checked);
                createdfile.WriteLine(trackBarReverb.Value);
                createdfile.WriteLine(checkBoxFlanger.Checked);
                createdfile.WriteLine(trackBarFlanger.Value);
                createdfile.WriteLine(checkBoxGargle.Checked);
                createdfile.WriteLine(trackBarGargle.Value);
                createdfile.WriteLine(checkBoxDistortion.Checked);
                createdfile.WriteLine(trackBarDistortion.Value);
                createdfile.WriteLine(checkBoxCompressor.Checked);
                createdfile.WriteLine(trackBarCompressor.Value);
                createdfile.WriteLine(checkBoxChorus.Checked);
                createdfile.WriteLine(trackBarChorus.Value);
            }
            StopEcho();
            StopNormal();
            StopReverb();
            StopFlanger();
            StopGargle();
            StopDistortion();
            StopCompressor();
            StopChorus();
            try
            {
                using (Process p = Process.GetCurrentProcess())
                {
                    p.Kill();
                }
            }
            catch { }
        }
    }
}