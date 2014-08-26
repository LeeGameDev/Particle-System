namespace ParticleEmitterTool
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.particles_pb = new System.Windows.Forms.PictureBox();
            this.particleClock = new System.Windows.Forms.Timer(this.components);
            this.checkBoxEmit = new System.Windows.Forms.CheckBox();
            this.cdColour = new System.Windows.Forms.ColorDialog();
            this.cmdSetStartColour = new System.Windows.Forms.Button();
            this.cmdSetEndColour = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdAddEmitter = new System.Windows.Forms.Button();
            this.cmdDeleteEmitter = new System.Windows.Forms.Button();
            this.trackBarMaxParticles = new System.Windows.Forms.TrackBar();
            this.trackBarEmissionRate = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.saveEmitterFile_dialog = new System.Windows.Forms.SaveFileDialog();
            this.openEmitterFile_dialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDemoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.cbParticleType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.particles_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMaxParticles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEmissionRate)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // particles_pb
            // 
            this.particles_pb.BackColor = System.Drawing.Color.Black;
            this.particles_pb.Location = new System.Drawing.Point(7, 33);
            this.particles_pb.Name = "particles_pb";
            this.particles_pb.Size = new System.Drawing.Size(312, 312);
            this.particles_pb.TabIndex = 3;
            this.particles_pb.TabStop = false;
            this.particles_pb.Paint += new System.Windows.Forms.PaintEventHandler(this.particles_pb_Paint);
            this.particles_pb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.particles_pb_MouseDown);
            this.particles_pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.particles_pb_MouseMove);
            this.particles_pb.MouseUp += new System.Windows.Forms.MouseEventHandler(this.particles_pb_MouseUp);
            // 
            // particleClock
            // 
            this.particleClock.Interval = 33;
            this.particleClock.Tick += new System.EventHandler(this.particleClock_Tick);
            // 
            // checkBoxEmit
            // 
            this.checkBoxEmit.AutoSize = true;
            this.checkBoxEmit.BackColor = System.Drawing.SystemColors.Control;
            this.checkBoxEmit.Location = new System.Drawing.Point(521, 216);
            this.checkBoxEmit.Name = "checkBoxEmit";
            this.checkBoxEmit.Size = new System.Drawing.Size(46, 17);
            this.checkBoxEmit.TabIndex = 4;
            this.checkBoxEmit.Text = "Emit";
            this.checkBoxEmit.UseVisualStyleBackColor = false;
            this.checkBoxEmit.CheckedChanged += new System.EventHandler(this.checkBoxEmit_CheckedChanged);
            // 
            // cmdSetStartColour
            // 
            this.cmdSetStartColour.Location = new System.Drawing.Point(408, 136);
            this.cmdSetStartColour.Name = "cmdSetStartColour";
            this.cmdSetStartColour.Size = new System.Drawing.Size(25, 25);
            this.cmdSetStartColour.TabIndex = 8;
            this.cmdSetStartColour.UseVisualStyleBackColor = true;
            this.cmdSetStartColour.Click += new System.EventHandler(this.cmdSetStartColour_Click);
            // 
            // cmdSetEndColour
            // 
            this.cmdSetEndColour.Location = new System.Drawing.Point(542, 136);
            this.cmdSetEndColour.Name = "cmdSetEndColour";
            this.cmdSetEndColour.Size = new System.Drawing.Size(25, 25);
            this.cmdSetEndColour.TabIndex = 9;
            this.cmdSetEndColour.UseVisualStyleBackColor = true;
            this.cmdSetEndColour.Click += new System.EventHandler(this.cmdSetEndColour_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(334, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Particle Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Start Colour";
            // 
            // cmdAddEmitter
            // 
            this.cmdAddEmitter.Location = new System.Drawing.Point(328, 212);
            this.cmdAddEmitter.Name = "cmdAddEmitter";
            this.cmdAddEmitter.Size = new System.Drawing.Size(75, 23);
            this.cmdAddEmitter.TabIndex = 12;
            this.cmdAddEmitter.Text = "Add Emitter";
            this.cmdAddEmitter.UseVisualStyleBackColor = true;
            this.cmdAddEmitter.Click += new System.EventHandler(this.cmdAddEmitter_Click);
            // 
            // cmdDeleteEmitter
            // 
            this.cmdDeleteEmitter.Location = new System.Drawing.Point(409, 212);
            this.cmdDeleteEmitter.Name = "cmdDeleteEmitter";
            this.cmdDeleteEmitter.Size = new System.Drawing.Size(81, 23);
            this.cmdDeleteEmitter.TabIndex = 13;
            this.cmdDeleteEmitter.Text = "Delete Emitter";
            this.cmdDeleteEmitter.UseVisualStyleBackColor = true;
            this.cmdDeleteEmitter.Click += new System.EventHandler(this.cmdDeleteEmitter_Click);
            // 
            // trackBarMaxParticles
            // 
            this.trackBarMaxParticles.Location = new System.Drawing.Point(408, 40);
            this.trackBarMaxParticles.Maximum = 3000;
            this.trackBarMaxParticles.Minimum = 1000;
            this.trackBarMaxParticles.Name = "trackBarMaxParticles";
            this.trackBarMaxParticles.Size = new System.Drawing.Size(166, 45);
            this.trackBarMaxParticles.TabIndex = 15;
            this.trackBarMaxParticles.TickFrequency = 100;
            this.trackBarMaxParticles.Value = 2000;
            this.trackBarMaxParticles.Scroll += new System.EventHandler(this.trackBarMaxParticles_Scroll);
            // 
            // trackBarEmissionRate
            // 
            this.trackBarEmissionRate.Location = new System.Drawing.Point(408, 91);
            this.trackBarEmissionRate.Maximum = 100;
            this.trackBarEmissionRate.Name = "trackBarEmissionRate";
            this.trackBarEmissionRate.Size = new System.Drawing.Size(166, 45);
            this.trackBarEmissionRate.TabIndex = 16;
            this.trackBarEmissionRate.TickFrequency = 10;
            this.trackBarEmissionRate.Value = 50;
            this.trackBarEmissionRate.Scroll += new System.EventHandler(this.trackBarEmissionRate_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(328, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Emission Rate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(332, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Max Particles";
            // 
            // openEmitterFile_dialog
            // 
            this.openEmitterFile_dialog.FileName = "openEmitterFile_dialog";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(579, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDemoToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newDemoToolStripMenuItem
            // 
            this.newDemoToolStripMenuItem.Name = "newDemoToolStripMenuItem";
            this.newDemoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newDemoToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.newDemoToolStripMenuItem.Text = "New Demo";
            this.newDemoToolStripMenuItem.Click += new System.EventHandler(this.newDemoToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.openToolStripMenuItem.Text = "Open File...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(477, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "End Colour";
            // 
            // cbParticleType
            // 
            this.cbParticleType.FormattingEnabled = true;
            this.cbParticleType.Items.AddRange(new object[] {
            "Circle",
            "Diamond"});
            this.cbParticleType.Location = new System.Drawing.Point(409, 185);
            this.cbParticleType.MaxDropDownItems = 3;
            this.cbParticleType.Name = "cbParticleType";
            this.cbParticleType.Size = new System.Drawing.Size(158, 21);
            this.cbParticleType.TabIndex = 23;
            this.cbParticleType.SelectedIndexChanged += new System.EventHandler(this.cbParticleType_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 352);
            this.Controls.Add(this.cbParticleType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackBarEmissionRate);
            this.Controls.Add(this.trackBarMaxParticles);
            this.Controls.Add(this.cmdDeleteEmitter);
            this.Controls.Add(this.cmdAddEmitter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdSetEndColour);
            this.Controls.Add(this.cmdSetStartColour);
            this.Controls.Add(this.checkBoxEmit);
            this.Controls.Add(this.particles_pb);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Particle Emitter Tool";
            ((System.ComponentModel.ISupportInitialize)(this.particles_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMaxParticles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEmissionRate)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox particles_pb;
        private System.Windows.Forms.Timer particleClock;
        private System.Windows.Forms.CheckBox checkBoxEmit;
        private System.Windows.Forms.ColorDialog cdColour;
        private System.Windows.Forms.Button cmdSetStartColour;
        private System.Windows.Forms.Button cmdSetEndColour;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdAddEmitter;
        private System.Windows.Forms.Button cmdDeleteEmitter;
        private System.Windows.Forms.TrackBar trackBarMaxParticles;
        private System.Windows.Forms.TrackBar trackBarEmissionRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SaveFileDialog saveEmitterFile_dialog;
        private System.Windows.Forms.OpenFileDialog openEmitterFile_dialog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDemoToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbParticleType;
    }
}

