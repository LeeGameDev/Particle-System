using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Xml;

namespace ParticleEmitterTool
{
    public partial class Form1 : Form
    {
        private List<IntPtr>    emitters = new List<IntPtr>();
        private IntPtr          activeEmitter = IntPtr.Zero;
        private bool            activeEmitterIsMoving;
        private Point           mousePointerLastPosition;
        private string          quickSaveFile;
        private bool            isDirty;

        public Form1()
        {
            InitializeComponent();
            Reset();
            RefreshAll();
        }

        private void trackBarMaxParticles_Scroll(object sender, EventArgs e)
        {
            SetMaxParticles();
            SetDirty(true);
        }
        private void trackBarEmissionRate_Scroll(object sender, EventArgs e)
        {
            SetEmissionRate();
            SetDirty(true);
        }

        private void cmdSetStartColour_Click(object sender, EventArgs e)
        {
            ChangeColour(true);
            SetDirty(true);
        }
        private void cmdSetEndColour_Click(object sender, EventArgs e)
        {
            ChangeColour(false);
            SetDirty(true);
        }

        private void cbParticleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeShape(cbParticleType.SelectedIndex);
            SetDirty(true);
        }

        private void cmdAddEmitter_Click(object sender, EventArgs e)
        {
            AddEmitter();
            SetDirty(true);
        }
        private void cmdDeleteEmitter_Click(object sender, EventArgs e)
        {
            RemoveEmitter(activeEmitter);
            SetDirty(true);
        }

        private void checkBoxEmit_CheckedChanged(object sender, EventArgs e)
        {
            EmitAllowed();
        }

        private void newDemoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFile();
            SetDirty(false);
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuickSave();
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void particleClock_Tick(object sender, EventArgs e)
        {
            UpdateEmitters();
        }
        private void particles_pb_Paint(object sender, PaintEventArgs e)
        {
            Draw(e);
        }

        private void particles_pb_MouseDown(object sender, MouseEventArgs e)
        {
            SelectEmitter(e);
        }
        private void particles_pb_MouseMove(object sender, MouseEventArgs e)
        {
            MoveEmitter(e);
        }
        private void particles_pb_MouseUp(object sender, MouseEventArgs e)
        {
            SetActiveEmitterIsMoving(false);
        }
    }
}