
namespace SoundBooster
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.trackBarEcho = new System.Windows.Forms.TrackBar();
            this.checkBoxEcho = new System.Windows.Forms.CheckBox();
            this.trackBarReverb = new System.Windows.Forms.TrackBar();
            this.trackBarFlanger = new System.Windows.Forms.TrackBar();
            this.trackBarGargle = new System.Windows.Forms.TrackBar();
            this.checkBoxReverb = new System.Windows.Forms.CheckBox();
            this.trackBarNormal = new System.Windows.Forms.TrackBar();
            this.checkBoxNormal = new System.Windows.Forms.CheckBox();
            this.checkBoxFlanger = new System.Windows.Forms.CheckBox();
            this.checkBoxGargle = new System.Windows.Forms.CheckBox();
            this.trackBarDistortion = new System.Windows.Forms.TrackBar();
            this.trackBarCompressor = new System.Windows.Forms.TrackBar();
            this.trackBarChorus = new System.Windows.Forms.TrackBar();
            this.checkBoxDistortion = new System.Windows.Forms.CheckBox();
            this.checkBoxCompressor = new System.Windows.Forms.CheckBox();
            this.checkBoxChorus = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEcho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarReverb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFlanger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGargle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarNormal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDistortion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCompressor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarChorus)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarEcho
            // 
            this.trackBarEcho.LargeChange = 100;
            this.trackBarEcho.Location = new System.Drawing.Point(211, 15);
            this.trackBarEcho.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackBarEcho.Maximum = 500;
            this.trackBarEcho.Minimum = -500;
            this.trackBarEcho.Name = "trackBarEcho";
            this.trackBarEcho.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarEcho.Size = new System.Drawing.Size(56, 475);
            this.trackBarEcho.SmallChange = 10;
            this.trackBarEcho.TabIndex = 0;
            this.trackBarEcho.TickFrequency = 10;
            this.trackBarEcho.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarEcho.ValueChanged += new System.EventHandler(this.trackBarEcho_ValueChanged);
            // 
            // checkBoxEcho
            // 
            this.checkBoxEcho.AutoSize = true;
            this.checkBoxEcho.Location = new System.Drawing.Point(211, 497);
            this.checkBoxEcho.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxEcho.Name = "checkBoxEcho";
            this.checkBoxEcho.Size = new System.Drawing.Size(59, 20);
            this.checkBoxEcho.TabIndex = 1;
            this.checkBoxEcho.Text = "echo";
            this.checkBoxEcho.UseVisualStyleBackColor = true;
            this.checkBoxEcho.CheckStateChanged += new System.EventHandler(this.checkBoxEcho_CheckStateChanged);
            // 
            // trackBarReverb
            // 
            this.trackBarReverb.LargeChange = 100;
            this.trackBarReverb.Location = new System.Drawing.Point(367, 15);
            this.trackBarReverb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackBarReverb.Maximum = 500;
            this.trackBarReverb.Minimum = -500;
            this.trackBarReverb.Name = "trackBarReverb";
            this.trackBarReverb.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarReverb.Size = new System.Drawing.Size(56, 475);
            this.trackBarReverb.SmallChange = 10;
            this.trackBarReverb.TabIndex = 2;
            this.trackBarReverb.TickFrequency = 10;
            this.trackBarReverb.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarReverb.ValueChanged += new System.EventHandler(this.trackBarReverb_ValueChanged);
            // 
            // trackBarFlanger
            // 
            this.trackBarFlanger.LargeChange = 100;
            this.trackBarFlanger.Location = new System.Drawing.Point(519, 15);
            this.trackBarFlanger.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackBarFlanger.Maximum = 500;
            this.trackBarFlanger.Minimum = -500;
            this.trackBarFlanger.Name = "trackBarFlanger";
            this.trackBarFlanger.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarFlanger.Size = new System.Drawing.Size(56, 475);
            this.trackBarFlanger.SmallChange = 10;
            this.trackBarFlanger.TabIndex = 5;
            this.trackBarFlanger.TickFrequency = 10;
            this.trackBarFlanger.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarFlanger.ValueChanged += new System.EventHandler(this.trackBarFlanger_ValueChanged);
            // 
            // trackBarGargle
            // 
            this.trackBarGargle.LargeChange = 100;
            this.trackBarGargle.Location = new System.Drawing.Point(683, 15);
            this.trackBarGargle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackBarGargle.Maximum = 500;
            this.trackBarGargle.Minimum = -500;
            this.trackBarGargle.Name = "trackBarGargle";
            this.trackBarGargle.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarGargle.Size = new System.Drawing.Size(56, 475);
            this.trackBarGargle.SmallChange = 10;
            this.trackBarGargle.TabIndex = 8;
            this.trackBarGargle.TickFrequency = 10;
            this.trackBarGargle.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarGargle.ValueChanged += new System.EventHandler(this.trackBarGargle_ValueChanged);
            // 
            // checkBoxReverb
            // 
            this.checkBoxReverb.AutoSize = true;
            this.checkBoxReverb.Location = new System.Drawing.Point(352, 497);
            this.checkBoxReverb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxReverb.Name = "checkBoxReverb";
            this.checkBoxReverb.Size = new System.Drawing.Size(68, 20);
            this.checkBoxReverb.TabIndex = 26;
            this.checkBoxReverb.Text = "reverb";
            this.checkBoxReverb.UseVisualStyleBackColor = true;
            this.checkBoxReverb.CheckStateChanged += new System.EventHandler(this.checkBoxReverb_CheckStateChanged);
            // 
            // trackBarNormal
            // 
            this.trackBarNormal.LargeChange = 100;
            this.trackBarNormal.Location = new System.Drawing.Point(59, 15);
            this.trackBarNormal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackBarNormal.Maximum = 500;
            this.trackBarNormal.Minimum = -500;
            this.trackBarNormal.Name = "trackBarNormal";
            this.trackBarNormal.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarNormal.Size = new System.Drawing.Size(56, 475);
            this.trackBarNormal.SmallChange = 10;
            this.trackBarNormal.TabIndex = 29;
            this.trackBarNormal.TickFrequency = 10;
            this.trackBarNormal.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarNormal.ValueChanged += new System.EventHandler(this.trackBarNormal_ValueChanged);
            // 
            // checkBoxNormal
            // 
            this.checkBoxNormal.AutoSize = true;
            this.checkBoxNormal.Location = new System.Drawing.Point(59, 497);
            this.checkBoxNormal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxNormal.Name = "checkBoxNormal";
            this.checkBoxNormal.Size = new System.Drawing.Size(70, 20);
            this.checkBoxNormal.TabIndex = 30;
            this.checkBoxNormal.Text = "normal";
            this.checkBoxNormal.UseVisualStyleBackColor = true;
            this.checkBoxNormal.CheckStateChanged += new System.EventHandler(this.checkBoxNormal_CheckStateChanged);
            // 
            // checkBoxFlanger
            // 
            this.checkBoxFlanger.AutoSize = true;
            this.checkBoxFlanger.Location = new System.Drawing.Point(501, 497);
            this.checkBoxFlanger.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxFlanger.Name = "checkBoxFlanger";
            this.checkBoxFlanger.Size = new System.Drawing.Size(70, 20);
            this.checkBoxFlanger.TabIndex = 31;
            this.checkBoxFlanger.Text = "flanger";
            this.checkBoxFlanger.UseVisualStyleBackColor = true;
            this.checkBoxFlanger.CheckStateChanged += new System.EventHandler(this.checkBoxFlanger_CheckStateChanged);
            // 
            // checkBoxGargle
            // 
            this.checkBoxGargle.AutoSize = true;
            this.checkBoxGargle.Location = new System.Drawing.Point(683, 497);
            this.checkBoxGargle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxGargle.Name = "checkBoxGargle";
            this.checkBoxGargle.Size = new System.Drawing.Size(68, 20);
            this.checkBoxGargle.TabIndex = 32;
            this.checkBoxGargle.Text = "gargle";
            this.checkBoxGargle.UseVisualStyleBackColor = true;
            this.checkBoxGargle.CheckStateChanged += new System.EventHandler(this.checkBoxGargle_CheckStateChanged);
            // 
            // trackBarDistortion
            // 
            this.trackBarDistortion.LargeChange = 100;
            this.trackBarDistortion.Location = new System.Drawing.Point(853, 15);
            this.trackBarDistortion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackBarDistortion.Maximum = 500;
            this.trackBarDistortion.Minimum = -500;
            this.trackBarDistortion.Name = "trackBarDistortion";
            this.trackBarDistortion.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarDistortion.Size = new System.Drawing.Size(56, 475);
            this.trackBarDistortion.SmallChange = 10;
            this.trackBarDistortion.TabIndex = 33;
            this.trackBarDistortion.TickFrequency = 10;
            this.trackBarDistortion.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarDistortion.ValueChanged += new System.EventHandler(this.trackBarDistortion_ValueChanged);
            // 
            // trackBarCompressor
            // 
            this.trackBarCompressor.LargeChange = 100;
            this.trackBarCompressor.Location = new System.Drawing.Point(1024, 15);
            this.trackBarCompressor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackBarCompressor.Maximum = 500;
            this.trackBarCompressor.Minimum = -500;
            this.trackBarCompressor.Name = "trackBarCompressor";
            this.trackBarCompressor.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarCompressor.Size = new System.Drawing.Size(56, 475);
            this.trackBarCompressor.SmallChange = 10;
            this.trackBarCompressor.TabIndex = 34;
            this.trackBarCompressor.TickFrequency = 10;
            this.trackBarCompressor.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarCompressor.ValueChanged += new System.EventHandler(this.trackBarCompressor_ValueChanged);
            // 
            // trackBarChorus
            // 
            this.trackBarChorus.LargeChange = 100;
            this.trackBarChorus.Location = new System.Drawing.Point(1188, 15);
            this.trackBarChorus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackBarChorus.Maximum = 500;
            this.trackBarChorus.Minimum = -500;
            this.trackBarChorus.Name = "trackBarChorus";
            this.trackBarChorus.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarChorus.Size = new System.Drawing.Size(56, 475);
            this.trackBarChorus.SmallChange = 10;
            this.trackBarChorus.TabIndex = 35;
            this.trackBarChorus.TickFrequency = 10;
            this.trackBarChorus.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarChorus.ValueChanged += new System.EventHandler(this.trackBarChorus_ValueChanged);
            // 
            // checkBoxDistortion
            // 
            this.checkBoxDistortion.AutoSize = true;
            this.checkBoxDistortion.Location = new System.Drawing.Point(840, 497);
            this.checkBoxDistortion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxDistortion.Name = "checkBoxDistortion";
            this.checkBoxDistortion.Size = new System.Drawing.Size(83, 20);
            this.checkBoxDistortion.TabIndex = 36;
            this.checkBoxDistortion.Text = "distortion";
            this.checkBoxDistortion.UseVisualStyleBackColor = true;
            this.checkBoxDistortion.CheckStateChanged += new System.EventHandler(this.checkBoxDistortion_CheckStateChanged);
            // 
            // checkBoxCompressor
            // 
            this.checkBoxCompressor.AutoSize = true;
            this.checkBoxCompressor.Location = new System.Drawing.Point(995, 497);
            this.checkBoxCompressor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxCompressor.Name = "checkBoxCompressor";
            this.checkBoxCompressor.Size = new System.Drawing.Size(101, 20);
            this.checkBoxCompressor.TabIndex = 37;
            this.checkBoxCompressor.Text = "compressor";
            this.checkBoxCompressor.UseVisualStyleBackColor = true;
            this.checkBoxCompressor.CheckStateChanged += new System.EventHandler(this.checkBoxCompressor_CheckStateChanged);
            // 
            // checkBoxChorus
            // 
            this.checkBoxChorus.AutoSize = true;
            this.checkBoxChorus.Location = new System.Drawing.Point(1177, 497);
            this.checkBoxChorus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxChorus.Name = "checkBoxChorus";
            this.checkBoxChorus.Size = new System.Drawing.Size(69, 20);
            this.checkBoxChorus.TabIndex = 38;
            this.checkBoxChorus.Text = "chorus";
            this.checkBoxChorus.UseVisualStyleBackColor = true;
            this.checkBoxChorus.CheckStateChanged += new System.EventHandler(this.checkBoxChorus_CheckStateChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 533);
            this.Controls.Add(this.checkBoxChorus);
            this.Controls.Add(this.checkBoxCompressor);
            this.Controls.Add(this.checkBoxDistortion);
            this.Controls.Add(this.trackBarChorus);
            this.Controls.Add(this.trackBarCompressor);
            this.Controls.Add(this.trackBarDistortion);
            this.Controls.Add(this.checkBoxGargle);
            this.Controls.Add(this.checkBoxFlanger);
            this.Controls.Add(this.checkBoxNormal);
            this.Controls.Add(this.trackBarNormal);
            this.Controls.Add(this.checkBoxReverb);
            this.Controls.Add(this.trackBarGargle);
            this.Controls.Add(this.trackBarFlanger);
            this.Controls.Add(this.trackBarReverb);
            this.Controls.Add(this.checkBoxEcho);
            this.Controls.Add(this.trackBarEcho);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SoundBooster";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEcho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarReverb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFlanger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGargle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarNormal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDistortion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCompressor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarChorus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBarEcho;
        private System.Windows.Forms.CheckBox checkBoxEcho;
        private System.Windows.Forms.TrackBar trackBarReverb;
        private System.Windows.Forms.TrackBar trackBarFlanger;
        private System.Windows.Forms.TrackBar trackBarGargle;
        private System.Windows.Forms.CheckBox checkBoxReverb;
        private System.Windows.Forms.TrackBar trackBarNormal;
        private System.Windows.Forms.CheckBox checkBoxNormal;
        private System.Windows.Forms.CheckBox checkBoxFlanger;
        private System.Windows.Forms.CheckBox checkBoxGargle;
        private System.Windows.Forms.TrackBar trackBarDistortion;
        private System.Windows.Forms.TrackBar trackBarCompressor;
        private System.Windows.Forms.TrackBar trackBarChorus;
        private System.Windows.Forms.CheckBox checkBoxDistortion;
        private System.Windows.Forms.CheckBox checkBoxCompressor;
        private System.Windows.Forms.CheckBox checkBoxChorus;
    }
}

