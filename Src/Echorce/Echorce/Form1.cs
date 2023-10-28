using NAudio.Wave.SampleProviders;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Echorce
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
        private static bool closeonicon = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            TimeBeginPeriod(1);
            NtSetTimerResolution(1, true, ref CurrentResolution);
            TrayMenuContext();
            if (System.IO.File.Exists("tempsave"))
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader("tempsave"))
                {
                    textBox1.Text = file.ReadLine();
                    textBox2.Text = file.ReadLine();
                    textBox3.Text = file.ReadLine();
                    textBox4.Text = file.ReadLine();
                    textBox5.Text = file.ReadLine();
                    textBox6.Text = file.ReadLine();
                    textBox7.Text = file.ReadLine();
                    textBox8.Text = file.ReadLine();
                    textBox9.Text = file.ReadLine();
                    textBox10.Text = file.ReadLine();
                    textBox11.Text = file.ReadLine();
                    textBox12.Text = file.ReadLine();
                    textBox13.Text = file.ReadLine();
                    textBox14.Text = file.ReadLine();
                    textBox15.Text = file.ReadLine();
                    textBox16.Text = file.ReadLine();
                }
            }
        }
        private void TrayMenuContext()
        {
            this.notifyIcon1.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.notifyIcon1.ContextMenuStrip.Items.Add("Quit", null, this.MenuTest1_Click);
        }
        void MenuTest1_Click(object sender, EventArgs e)
        {
            closeonicon = true;
            this.Close();
        }
        private void MinimzedTray()
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.Hide();
        }
        private void MaxmizedFromTray()
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.Show();
        }
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            MaxmizedFromTray();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closeonicon)
            {
                e.Cancel = true;
                MinimzedTray();
                return;
            }
            using (System.IO.StreamWriter createdfile = new System.IO.StreamWriter("tempsave"))
            {
                createdfile.WriteLine(textBox1.Text);
                createdfile.WriteLine(textBox2.Text);
                createdfile.WriteLine(textBox3.Text);
                createdfile.WriteLine(textBox4.Text);
                createdfile.WriteLine(textBox5.Text);
                createdfile.WriteLine(textBox6.Text);
                createdfile.WriteLine(textBox7.Text);
                createdfile.WriteLine(textBox8.Text);
                createdfile.WriteLine(textBox9.Text);
                createdfile.WriteLine(textBox10.Text);
                createdfile.WriteLine(textBox11.Text);
                createdfile.WriteLine(textBox12.Text);
                createdfile.WriteLine(textBox13.Text);
                createdfile.WriteLine(textBox14.Text);
                createdfile.WriteLine(textBox15.Text);
                createdfile.WriteLine(textBox16.Text);
            }
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            button1.PerformClick();
            button2.PerformClick();
            button3.PerformClick();
            button4.PerformClick();
            button5.PerformClick();
            button6.PerformClick();
            button7.PerformClick();
            button8.PerformClick();
            button9.PerformClick();
            button10.PerformClick();
            button11.PerformClick();
            button12.PerformClick();
            button13.PerformClick();
            button14.PerformClick();
            button15.PerformClick();
            button16.PerformClick();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Play")
            {
                button1.Text = "Stop";
                Task.Run(() =>
                {
                    while (button1.Text == "Stop")
                    {
                        var sine20Seconds = new SignalGenerator()
                        {
                            Gain = 1,
                            Frequency = Convert.ToDouble(textBox1.Text),
                            FrequencyEnd = Convert.ToDouble(textBox1.Text) + 1000,
                            Type = SignalGeneratorType.Sweep,
                            SweepLengthSecs = 20
                        }
                        .Take(TimeSpan.FromSeconds(20));
                        using (var wo = new WaveOutEvent())
                        {
                            wo.Init(sine20Seconds);
                            wo.Play();
                            while (wo.PlaybackState == PlaybackState.Playing)
                            {
                                Thread.Sleep(1);
                            }
                        }
                        Thread.Sleep(1);
                    }
                });
            }
            else
                button1.Text = "Play";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Play")
            {
                button2.Text = "Stop";
                Task.Run(() =>
                {
                    while (button2.Text == "Stop")
                    {
                        var sine20Seconds = new SignalGenerator()
                        {
                            Gain = 1,
                            Frequency = Convert.ToDouble(textBox2.Text),
                            FrequencyEnd = Convert.ToDouble(textBox2.Text) + 1000,
                            Type = SignalGeneratorType.Sweep,
                            SweepLengthSecs = 20
                        }
                        .Take(TimeSpan.FromSeconds(20));
                        using (var wo = new WaveOutEvent())
                        {
                            wo.Init(sine20Seconds);
                            wo.Play();
                            while (wo.PlaybackState == PlaybackState.Playing)
                            {
                                Thread.Sleep(1);
                            }
                        }
                        Thread.Sleep(1);
                    }
                });
            }
            else
                button2.Text = "Play";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Play")
            {
                button3.Text = "Stop";
                Task.Run(() =>
                {
                    while (button3.Text == "Stop")
                    {
                        var sine20Seconds = new SignalGenerator()
                        {
                            Gain = 1,
                            Frequency = Convert.ToDouble(textBox3.Text),
                            FrequencyEnd = Convert.ToDouble(textBox3.Text) + 1000,
                            Type = SignalGeneratorType.Sweep,
                            SweepLengthSecs = 20
                        }
                        .Take(TimeSpan.FromSeconds(20));
                        using (var wo = new WaveOutEvent())
                        {
                            wo.Init(sine20Seconds);
                            wo.Play();
                            while (wo.PlaybackState == PlaybackState.Playing)
                            {
                                Thread.Sleep(1);
                            }
                        }
                        Thread.Sleep(1);
                    }
                });
            }
            else
                button3.Text = "Play";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Play")
            {
                button4.Text = "Stop";
                Task.Run(() =>
                {
                    while (button4.Text == "Stop")
                    {
                        var sine20Seconds = new SignalGenerator()
                        {
                            Gain = 1,
                            Frequency = Convert.ToDouble(textBox4.Text),
                            FrequencyEnd = Convert.ToDouble(textBox4.Text) + 1000,
                            Type = SignalGeneratorType.Sweep,
                            SweepLengthSecs = 20
                        }
                        .Take(TimeSpan.FromSeconds(20));
                        using (var wo = new WaveOutEvent())
                        {
                            wo.Init(sine20Seconds);
                            wo.Play();
                            while (wo.PlaybackState == PlaybackState.Playing)
                            {
                                Thread.Sleep(1);
                            }
                        }
                        Thread.Sleep(1);
                    }
                });
            }
            else
                button4.Text = "Play";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "Play")
            {
                button5.Text = "Stop";
                Task.Run(() =>
                {
                    while (button5.Text == "Stop")
                    {
                        var sine20Seconds = new SignalGenerator()
                        {
                            Gain = 1,
                            Frequency = Convert.ToDouble(textBox5.Text),
                            FrequencyEnd = Convert.ToDouble(textBox5.Text) + 1000,
                            Type = SignalGeneratorType.Sweep,
                            SweepLengthSecs = 20
                        }
                        .Take(TimeSpan.FromSeconds(20));
                        using (var wo = new WaveOutEvent())
                        {
                            wo.Init(sine20Seconds);
                            wo.Play();
                            while (wo.PlaybackState == PlaybackState.Playing)
                            {
                                Thread.Sleep(1);
                            }
                        }
                        Thread.Sleep(1);
                    }
                });
            }
            else
                button5.Text = "Play";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text == "Play")
            {
                button6.Text = "Stop";
                Task.Run(() =>
                {
                    while (button6.Text == "Stop")
                    {
                        var sine20Seconds = new SignalGenerator()
                        {
                            Gain = 1,
                            Frequency = Convert.ToDouble(textBox6.Text),
                            FrequencyEnd = Convert.ToDouble(textBox6.Text) + 1000,
                            Type = SignalGeneratorType.Sweep,
                            SweepLengthSecs = 20
                        }
                        .Take(TimeSpan.FromSeconds(20));
                        using (var wo = new WaveOutEvent())
                        {
                            wo.Init(sine20Seconds);
                            wo.Play();
                            while (wo.PlaybackState == PlaybackState.Playing)
                            {
                                Thread.Sleep(1);
                            }
                        }
                        Thread.Sleep(1);
                    }
                });
            }
            else
                button6.Text = "Play";
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.Text == "Play")
            {
                button7.Text = "Stop";
                Task.Run(() =>
                {
                    while (button7.Text == "Stop")
                    {
                        var sine20Seconds = new SignalGenerator()
                        {
                            Gain = 1,
                            Frequency = Convert.ToDouble(textBox7.Text),
                            FrequencyEnd = Convert.ToDouble(textBox7.Text) + 1000,
                            Type = SignalGeneratorType.Sweep,
                            SweepLengthSecs = 20
                        }
                        .Take(TimeSpan.FromSeconds(20));
                        using (var wo = new WaveOutEvent())
                        {
                            wo.Init(sine20Seconds);
                            wo.Play();
                            while (wo.PlaybackState == PlaybackState.Playing)
                            {
                                Thread.Sleep(1);
                            }
                        }
                        Thread.Sleep(1);
                    }
                });
            }
            else
                button7.Text = "Play";
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.Text == "Play")
            {
                button8.Text = "Stop";
                Task.Run(() =>
                {
                    while (button8.Text == "Stop")
                    {
                        var sine20Seconds = new SignalGenerator()
                        {
                            Gain = 1,
                            Frequency = Convert.ToDouble(textBox8.Text),
                            FrequencyEnd = Convert.ToDouble(textBox8.Text) + 1000,
                            Type = SignalGeneratorType.Sweep,
                            SweepLengthSecs = 20
                        }
                        .Take(TimeSpan.FromSeconds(20));
                        using (var wo = new WaveOutEvent())
                        {
                            wo.Init(sine20Seconds);
                            wo.Play();
                            while (wo.PlaybackState == PlaybackState.Playing)
                            {
                                Thread.Sleep(1);
                            }
                        }
                        Thread.Sleep(1);
                    }
                });
            }
            else
                button8.Text = "Play";
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.Text == "Play")
            {
                button9.Text = "Stop";
                Task.Run(() =>
                {
                    while (button9.Text == "Stop")
                    {
                        var sine20Seconds = new SignalGenerator()
                        {
                            Gain = 1,
                            Frequency = Convert.ToDouble(textBox9.Text),
                            FrequencyEnd = Convert.ToDouble(textBox9.Text) + 1000,
                            Type = SignalGeneratorType.Sweep,
                            SweepLengthSecs = 20
                        }
                        .Take(TimeSpan.FromSeconds(20));
                        using (var wo = new WaveOutEvent())
                        {
                            wo.Init(sine20Seconds);
                            wo.Play();
                            while (wo.PlaybackState == PlaybackState.Playing)
                            {
                                Thread.Sleep(1);
                            }
                        }
                        Thread.Sleep(1);
                    }
                });
            }
            else
                button9.Text = "Play";
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (button10.Text == "Play")
            {
                button10.Text = "Stop";
                Task.Run(() =>
                {
                    while (button10.Text == "Stop")
                    {
                        var sine20Seconds = new SignalGenerator()
                        {
                            Gain = 1,
                            Frequency = Convert.ToDouble(textBox10.Text),
                            FrequencyEnd = Convert.ToDouble(textBox10.Text) + 1000,
                            Type = SignalGeneratorType.Sweep,
                            SweepLengthSecs = 20
                        }
                        .Take(TimeSpan.FromSeconds(20));
                        using (var wo = new WaveOutEvent())
                        {
                            wo.Init(sine20Seconds);
                            wo.Play();
                            while (wo.PlaybackState == PlaybackState.Playing)
                            {
                                Thread.Sleep(1);
                            }
                        }
                        Thread.Sleep(1);
                    }
                });
            }
            else
                button10.Text = "Play";
        }
        private void button11_Click(object sender, EventArgs e)
        {
            if (button11.Text == "Play")
            {
                button11.Text = "Stop";
                Task.Run(() =>
                {
                    while (button11.Text == "Stop")
                    {
                        var sine20Seconds = new SignalGenerator()
                        {
                            Gain = 1,
                            Frequency = Convert.ToDouble(textBox11.Text),
                            FrequencyEnd = Convert.ToDouble(textBox11.Text) + 1000,
                            Type = SignalGeneratorType.Sweep,
                            SweepLengthSecs = 20
                        }
                        .Take(TimeSpan.FromSeconds(20));
                        using (var wo = new WaveOutEvent())
                        {
                            wo.Init(sine20Seconds);
                            wo.Play();
                            while (wo.PlaybackState == PlaybackState.Playing)
                            {
                                Thread.Sleep(1);
                            }
                        }
                        Thread.Sleep(1);
                    }
                });
            }
            else
                button11.Text = "Play";
        }
        private void button12_Click(object sender, EventArgs e)
        {
            if (button12.Text == "Play")
            {
                button12.Text = "Stop";
                Task.Run(() =>
                {
                    while (button12.Text == "Stop")
                    {
                        var sine20Seconds = new SignalGenerator()
                        {
                            Gain = 1,
                            Frequency = Convert.ToDouble(textBox12.Text),
                            FrequencyEnd = Convert.ToDouble(textBox12.Text) + 1000,
                            Type = SignalGeneratorType.Sweep,
                            SweepLengthSecs = 20
                        }
                        .Take(TimeSpan.FromSeconds(20));
                        using (var wo = new WaveOutEvent())
                        {
                            wo.Init(sine20Seconds);
                            wo.Play();
                            while (wo.PlaybackState == PlaybackState.Playing)
                            {
                                Thread.Sleep(1);
                            }
                        }
                        Thread.Sleep(1);
                    }
                });
            }
            else
                button12.Text = "Play";
        }
        private void button13_Click(object sender, EventArgs e)
        {
            if (button13.Text == "Play")
            {
                button13.Text = "Stop";
                Task.Run(() =>
                {
                    while (button13.Text == "Stop")
                    {
                        var sine20Seconds = new SignalGenerator()
                        {
                            Gain = 1,
                            Frequency = Convert.ToDouble(textBox13.Text),
                            FrequencyEnd = Convert.ToDouble(textBox13.Text) + 1000,
                            Type = SignalGeneratorType.Sweep,
                            SweepLengthSecs = 20
                        }
                        .Take(TimeSpan.FromSeconds(20));
                        using (var wo = new WaveOutEvent())
                        {
                            wo.Init(sine20Seconds);
                            wo.Play();
                            while (wo.PlaybackState == PlaybackState.Playing)
                            {
                                Thread.Sleep(1);
                            }
                        }
                        Thread.Sleep(1);
                    }
                });
            }
            else
                button13.Text = "Play";
        }
        private void button14_Click(object sender, EventArgs e)
        {
            if (button14.Text == "Play")
            {
                button14.Text = "Stop";
                Task.Run(() =>
                {
                    while (button14.Text == "Stop")
                    {
                        var sine20Seconds = new SignalGenerator()
                        {
                            Gain = 1,
                            Frequency = Convert.ToDouble(textBox14.Text),
                            FrequencyEnd = Convert.ToDouble(textBox14.Text) + 1000,
                            Type = SignalGeneratorType.Sweep,
                            SweepLengthSecs = 20
                        }
                        .Take(TimeSpan.FromSeconds(20));
                        using (var wo = new WaveOutEvent())
                        {
                            wo.Init(sine20Seconds);
                            wo.Play();
                            while (wo.PlaybackState == PlaybackState.Playing)
                            {
                                Thread.Sleep(1);
                            }
                        }
                        Thread.Sleep(1);
                    }
                });
            }
            else
                button14.Text = "Play";
        }
        private void button15_Click(object sender, EventArgs e)
        {
            if (button15.Text == "Play")
            {
                button15.Text = "Stop";
                Task.Run(() =>
                {
                    while (button15.Text == "Stop")
                    {
                        var sine20Seconds = new SignalGenerator()
                        {
                            Gain = 1,
                            Frequency = Convert.ToDouble(textBox15.Text),
                            FrequencyEnd = Convert.ToDouble(textBox15.Text) + 1000,
                            Type = SignalGeneratorType.Sweep,
                            SweepLengthSecs = 20
                        }
                        .Take(TimeSpan.FromSeconds(20));
                        using (var wo = new WaveOutEvent())
                        {
                            wo.Init(sine20Seconds);
                            wo.Play();
                            while (wo.PlaybackState == PlaybackState.Playing)
                            {
                                Thread.Sleep(1);
                            }
                        }
                        Thread.Sleep(1);
                    }
                });
            }
            else
                button15.Text = "Play";
        }
        private void button16_Click(object sender, EventArgs e)
        {
            if (button16.Text == "Play")
            {
                button16.Text = "Stop";
                Task.Run(() =>
                {
                    while (button16.Text == "Stop")
                    {
                        var sine20Seconds = new SignalGenerator()
                        {
                            Gain = 1,
                            Frequency = Convert.ToDouble(textBox16.Text),
                            FrequencyEnd = Convert.ToDouble(textBox16.Text) + 1000,
                            Type = SignalGeneratorType.Sweep,
                            SweepLengthSecs = 20
                        }
                        .Take(TimeSpan.FromSeconds(20));
                        using (var wo = new WaveOutEvent())
                        {
                            wo.Init(sine20Seconds);
                            wo.Play();
                            while (wo.PlaybackState == PlaybackState.Playing)
                            {
                                Thread.Sleep(1);
                            }
                        }
                        Thread.Sleep(1);
                    }
                });
            }
            else
                button16.Text = "Play";
        }
    }
}