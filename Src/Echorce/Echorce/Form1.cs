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
            }
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
                            Frequency = Convert.ToDouble(textBox1.Text) - 250,
                            FrequencyEnd = Convert.ToDouble(textBox1.Text) + 250,
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
                            Frequency = Convert.ToDouble(textBox2.Text) - 250,
                            FrequencyEnd = Convert.ToDouble(textBox2.Text) + 250,
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
                            Frequency = Convert.ToDouble(textBox3.Text) - 250,
                            FrequencyEnd = Convert.ToDouble(textBox3.Text) + 250,
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
    }
}