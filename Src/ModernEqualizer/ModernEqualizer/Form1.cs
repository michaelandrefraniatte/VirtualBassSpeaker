using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using System.Management;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using System.ComponentModel;
using EO.WebBrowser;
using System.Media;
using System.Globalization;
using NetFwTypeLib;
namespace ModernEqualizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            this.pictureBox1.Dock = DockStyle.Fill;
            EO.WebEngine.BrowserOptions options = new EO.WebEngine.BrowserOptions();
            options.EnableWebSecurity = false;
            EO.WebBrowser.Runtime.DefaultEngineOptions.SetDefaultBrowserOptions(options);
            EO.WebEngine.Engine.Default.Options.AllowProprietaryMediaFormats();
            EO.WebEngine.Engine.Default.Options.SetDefaultBrowserOptions(new EO.WebEngine.BrowserOptions
            {
                EnableWebSecurity = false
            });
            this.webView1.Create(pictureBox1.Handle);
            this.webView1.Engine.Options.AllowProprietaryMediaFormats();
            this.webView1.SetOptions(new EO.WebEngine.BrowserOptions
            {
                EnableWebSecurity = false
            });
            this.webView1.Engine.Options.DisableGPU = false;
            this.webView1.Engine.Options.DisableSpellChecker = true;
            this.webView1.Engine.Options.CustomUserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";
            this.webView1.KeyDown += WebView1_KeyDown;
            Navigate("https://michaelandrefraniatte.web.app/ppia/");
            webView1.RegisterJSExtensionFunction("demoAbout", new JSExtInvokeHandler(WebView_JSDemoAbout));
        }
        private void WebView1_KeyDown(object sender, EO.Base.UI.WndMsgEventArgs e)
        {
            Keys key = (Keys)e.WParam;
            OnKeyDown(key);
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
        private void webView1_RequestPermissions(object sender, RequestPermissionEventArgs e)
        {
            e.Allow();
        }
        private void webView1_LoadCompleted(object sender, LoadCompletedEventArgs e)
        {
            Task.Run(() => LoadPage());
        }
        private void LoadPage()
        {
            string backgroundcolor = "";
            string overlaycolor = "";
            string previousnextbuttonshovercolor = "";
            string titlehoverbackgroundcolor = "";
            using (StreamReader file = new StreamReader("colors.txt"))
            {
                file.ReadLine();
                backgroundcolor = file.ReadLine();
                file.ReadLine();
                overlaycolor = file.ReadLine();
                file.ReadLine();
                previousnextbuttonshovercolor = file.ReadLine();
                file.ReadLine();
                titlehoverbackgroundcolor = file.ReadLine();
                file.Close();
            }
            string reverbreplaced = "false", distortionreplaced = "0", frequence10replaced = "0", frequence100replaced = "0", frequence200replaced = "0", frequence500replaced = "0", frequence1000replaced = "0", frequence5000replaced = "0", frequence10000replaced = "0", frequence20000replaced = "0";
            if (File.Exists("tempsave"))
            {
                using (StreamReader file = new StreamReader("tempsave"))
                {
                    reverbreplaced = file.ReadLine();
                    distortionreplaced = file.ReadLine();
                    frequence10replaced = file.ReadLine();
                    frequence100replaced = file.ReadLine();
                    frequence200replaced = file.ReadLine();
                    frequence500replaced = file.ReadLine();
                    frequence1000replaced = file.ReadLine();
                    frequence5000replaced = file.ReadLine();
                    frequence10000replaced = file.ReadLine();
                    frequence20000replaced = file.ReadLine();
                }
            }
            string stringinject;
            stringinject = @"
    <style>

body {
    font-family: sans-serif;
    background-color: backgroundcolor;
    color: #FFFFFF;
}

::-webkit-scrollbar {
    width: 10px;
}

::-webkit-scrollbar-track {
    background: overlaycolor;
}

::-webkit-scrollbar-thumb {
    background: #888;
}

::-webkit-scrollbar-thumb:hover {
    background: #eee;
}

#canvas {
  position: fixed;
  left: 0;
  bottom: 0;
  width: 100%;
  height: 25%;
}

#container-reverb {
    margin-top: 2.5%;
	display: flex; 
	flex-direction: column; 
	justify-content: center; 
	align-items: center;
    color: #000000;
}

#container-equalizer {
    position: fixed;
    display: flex;
    width: 100%;
    height : 60%;
    top: 12.5%;
    left: 0px;
    padding-right: 1.5%;
}

#container-equalizer input[type='range'] {
   appearance: slider-vertical;
   -moz-appearance: slider-vertical;
   -webkit-appearance: slider-vertical;
}

#container-equalizer label {
    flex-direction:column;
}

    </style>
".Replace("\r\n", " ").Replace("backgroundcolor", backgroundcolor).Replace("overlaycolor", overlaycolor).Replace("previousnextbuttonshovercolor", previousnextbuttonshovercolor).Replace("titlehoverbackgroundcolor", titlehoverbackgroundcolor);
            stringinject = @"""" + stringinject + @"""";
            stringinject = @"$(" + stringinject + @" ).appendTo('head');";
            this.webView1.EvalScript(stringinject);
            stringinject = @"

    <!-- Reverb container -->
    <div id='container-reverb'>
        <input type='checkbox' id='reverb' name='reverb' value='reverbreplaced'>
        <label for='reverb'>Reverb</label>
    <div>

    <!-- Equalizer container -->
    <div id='container-equalizer'>
        <input type='range' min='0' max='900' id='distorsion' name='distorsion' value='distortionreplaced' />
        <label for='distorsion'>Distorsion</label>
        <input type='range' min='-200' max='200' id='frequence10' name='frequence10' value='frequence10replaced' />
        <label for='frequence10'>10 Hz</label>
        <input type='range' min='-200' max='200' id='frequence100' name='frequence100' value='frequence100replaced' />
        <label for='frequence100'>100 Hz</label>
        <input type='range' min='-200' max='200' id='frequence200' name='frequence200' value='frequence200replaced' />
        <label for='frequence200'>200 Hz</label>
        <input type='range' min='-200' max='200' id='frequence500' name='frequence500' value='frequence500replaced' />
        <label for='frequence500'>500 Hz</label>
        <input type='range' min='-200' max='200' id='frequence1000' name='frequence1000' value='frequence1000replaced' />
        <label for='frequence1000'>1000 Hz</label>
        <input type='range' min='-200' max='200' id='frequence5000' name='frequence5000' value='frequence5000replaced' />
        <label for='frequence5000'>5000 Hz</label>
        <input type='range' min='-200' max='200' id='frequence10000' name='frequence10000' value='frequence10000replaced' />
        <label for='frequence10000'>10000 Hz</label>
        <input type='range' min='-200' max='200' id='frequence20000' name='frequence20000' value='frequence20000replaced' />
        <label for='frequence20000'>20000 Hz</label>
    <div>

    <!-- Visualizer container -->
	<canvas id=\'canvas\'></canvas>

    <script>

var smoothred = [];
var smoothgreen = [];
var smoothblue = [];
var coefficientred;
var coefficientgreen;
var coefficientblue;
const average = (array) => array.reduce((a, b) => a + b) / array.length;
var inc = 0;
var audioCtx;
var source;
var stream;
var ctx;
var analyser;
var biquadFilter;
var convolver;
var distortion;
var bufferLength;
var dataArray;
var WIDTH;
var HEIGHT;
var barWidth;
var barHeight;
var x;
var canvas;
var reverbCheck = document.getElementById('reverb');
var distorsionRange = document.getElementById('distorsion');
var frequence10Range = document.getElementById('frequence10');
var frequence100Range = document.getElementById('frequence100');
var frequence200Range = document.getElementById('frequence200');
var frequence500Range = document.getElementById('frequence500');
var frequence1000Range = document.getElementById('frequence1000');
var frequence5000Range = document.getElementById('frequence5000');
var frequence10000Range = document.getElementById('frequence10000');
var frequence20000Range = document.getElementById('frequence20000');

reverbCheck.onchange = function() {
    voiceChange();
};

distorsionRange.onchange = function() {
    voiceChange();
};

frequence10Range.onchange = function() {
    voiceChange();
};

frequence100Range.onchange = function() {
    voiceChange();
};

frequence200Range.onchange = function() {
    voiceChange();
};

frequence500Range.onchange = function() {
    voiceChange();
};

frequence1000Range.onchange = function() {
    voiceChange();
};

frequence5000Range.onchange = function() {
    voiceChange();
};

frequence10000Range.onchange = function() {
    voiceChange();
};

frequence20000Range.onchange = function() {
    voiceChange();
};

$(document).ready(function() {
    getCanevas();
    setVisualizer();
});

function getCanevas() {
      canvas = document.getElementById('canvas');
      canvas.width = 800;
      canvas.height = 600;
      ctx = canvas.getContext('2d');
      WIDTH = canvas.width;
      HEIGHT = canvas.height;
}

function setVisualizer() {

    navigator.mediaDevices.getUserMedia ({
            audio: true,
	    video: false
    })
    .then(stream => {

    audioCtx = new AudioContext();

    source = audioCtx.createMediaStreamSource(stream);
    analyser = audioCtx.createAnalyser();
    biquadFilter = audioCtx.createBiquadFilter();
    distortion = audioCtx.createWaveShaper();
    convolver = audioCtx.createConvolver();

    voiceChange();

    bufferLength = analyser.frequencyBinCount;

    dataArray = new Uint8Array(bufferLength);

    renderFrame();

    })
    .catch();
}

function renderFrame() {

    requestAnimationFrame(renderFrame);

    ctx.fillStyle = 'backgroundcolor';
    ctx.fillRect(0, 0, WIDTH, HEIGHT);

    analyser.getByteFrequencyData(dataArray);

    inc++;

    if (inc > 26) {
        smoothred.push(Math.random());
        smoothgreen.push(Math.random());
        smoothblue.push(Math.random());

        if (smoothred.length > 4) {
            smoothred.shift();
        }
        if (smoothgreen.length > 4) {
            smoothgreen.shift();
        }
        if (smoothblue.length > 4) {
            smoothblue.shift();
        }

        coefficientred =  average(smoothred);
        coefficientgreen =  average(smoothgreen);
        coefficientblue =  average(smoothblue);

        inc = 0;

    }

    barWidth = (WIDTH / bufferLength);
    barHeight = HEIGHT;
    x = 0;

    for (var i = 0; i < bufferLength; i++) {

    barHeight = dataArray[i];
        
    var r = 255 * coefficientred;
    var g = 255 * coefficientgreen;
    var b = 255 * coefficientblue;

    ctx.fillStyle = 'rgb(' + r + ',' + g + ',' + b + ')';
    ctx.strokeStyle = 'rgb(' + r + ', ' + g + ', ' + b + ')';
    ctx.fillRect(x, HEIGHT - barHeight, barWidth, barHeight);

    x += barWidth + 1;
      
    }

    ctx.stroke();

}

function voiceChange() {
    source.connect(analyser);
    if (reverbCheck.value) {
        analyser.connect(distortion);
        distortion.connect(convolver);
        convolver.connect(biquadFilter);
    }
    else {
        analyser.connect(distortion);
        distortion.connect(biquadFilter);
    }
    biquadFilter.connect(audioCtx.destination);
    makeDistortionCurve(distorsionRange.value);
    biquadFilter.type = 'lowshelf';
    biquadFilter.frequency.value = 10;
    biquadFilter.gain.value = frequence10Range.value;
    biquadFilter.type = 'lowshelf';
    biquadFilter.frequency.value = 100;
    biquadFilter.gain.value = frequence100Range.value;
    biquadFilter.type = 'lowshelf';
    biquadFilter.frequency.value = 200;
    biquadFilter.gain.value = frequence200Range.value;
    biquadFilter.type = 'lowshelf';
    biquadFilter.frequency.value = 500;
    biquadFilter.gain.value = frequence500Range.value;
    biquadFilter.type = 'highshelf';
    biquadFilter.frequency.value = 1000;
    biquadFilter.gain.value = frequence1000Range.value;
    biquadFilter.type = 'highshelf';
    biquadFilter.frequency.value = 5000;
    biquadFilter.gain.value = frequence5000Range.value;
    biquadFilter.type = 'highshelf';
    biquadFilter.frequency.value = 10000;
    biquadFilter.gain.value = frequence10000Range.value;
    biquadFilter.type = 'highshelf';
    biquadFilter.frequency.value = 20000;
    biquadFilter.gain.value = frequence20000Range.value;
    demoAbout(reverbCheck.value, distorsionRange.value, frequence10Range.value, frequence100Range.value, frequence200Range.value, frequence500Range.value, frequence1000Range.value, frequence5000Range.value, frequence10000Range.value, frequence20000Range.value);
}

function makeDistortionCurve(amount) {
    var k = typeof amount === 'number' ? amount : 50,
        n_samples = 44100,
        curve = new Float32Array(n_samples),
        deg = Math.PI / 180,
        i = 0,
        x;
    for ( ; i < n_samples; ++i ) {
        x = i * 2 / n_samples - 1;
        curve[i] = ( 3 + k ) * x * 20 * deg / ( Math.PI + k * Math.abs(x) );
    }
    return curve;
}

    </script>

".Replace("\r\n", " ").Replace("backgroundcolor", backgroundcolor).Replace("reverbreplaced", reverbreplaced).Replace("distortionreplaced", distortionreplaced).Replace("frequence10replaced", frequence10replaced).Replace("frequence100replaced", frequence100replaced).Replace("frequence200replaced", frequence200replaced).Replace("frequence500replaced", frequence500replaced).Replace("frequence1000replaced", frequence1000replaced).Replace("frequence5000replaced", frequence5000replaced).Replace("frequence10000replaced", frequence10000replaced).Replace("frequence20000replaced", frequence20000replaced);
            stringinject = @"""" + stringinject + @"""";
            stringinject = @"$(document).ready(function(){$('body').append(" + stringinject + @");});";
            this.webView1.EvalScript(stringinject);
        }
        private void Navigate(string address)
        {
            if (String.IsNullOrEmpty(address))
                return;
            if (address.Equals("about:blank"))
                return;
            if (!address.StartsWith("http://") & !address.StartsWith("https://"))
                address = "https://" + address;
            try
            {
                webView1.Url = address;
            }
            catch (System.UriFormatException)
            {
                return;
            }
        }
        void WebView_JSDemoAbout(object sender, JSExtInvokeArgs e)
        {
            using (StreamWriter createdfile = new StreamWriter("tempsave"))
            {
                createdfile.WriteLine(e.Arguments[0] as string);
                createdfile.WriteLine(e.Arguments[1] as string);
                createdfile.WriteLine(e.Arguments[2] as string);
                createdfile.WriteLine(e.Arguments[3] as string);
                createdfile.WriteLine(e.Arguments[4] as string);
                createdfile.WriteLine(e.Arguments[5] as string);
                createdfile.WriteLine(e.Arguments[6] as string);
                createdfile.WriteLine(e.Arguments[7] as string);
                createdfile.WriteLine(e.Arguments[8] as string);
                createdfile.WriteLine(e.Arguments[9] as string);
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.webView1.Dispose();
        }
    }
}