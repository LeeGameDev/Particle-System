using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ParticleEmitterTool
{
    partial class Form1
    {
        private const float EMITTER_WIDTH   = 10.0f;
        private const float EMITTER_HEIGHT  = 10.0f;
        private const float CIRCLE_RADIUS   = 4.0f;
        private const float DIAMOND_WIDTH   = 2.0f;

        // Set the max particles an emitter can spawn
        private void SetMaxParticles()
        {
            if (activeEmitter != IntPtr.Zero)
            {
                NativeMethods.setMaxParticles(activeEmitter, trackBarMaxParticles.Value);
                RefreshAll();
            }
        }
        // Set the emission rate of the emitter
        private void SetEmissionRate()
        {
            if (activeEmitter != IntPtr.Zero)
            {
                NativeMethods.setEmissionRate(activeEmitter, trackBarEmissionRate.Value);
                RefreshAll();
            }
        }

        // Sets the colours to lerp between
        private void ChangeColour(bool isStartColour)
        {
            if (activeEmitter != IntPtr.Zero)
            {
                DialogResult dr = cdColour.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Color c = cdColour.Color;

                    if (isStartColour)
                    {
                        NativeMethods.SetInitialColour(activeEmitter, Convert.ToInt32(c.R), Convert.ToInt32(c.G), Convert.ToInt32(c.B), Convert.ToInt32(c.A));
                        cmdSetStartColour.BackColor = c;
                    }
                    else
                    {
                        NativeMethods.SetFinalColour(activeEmitter, Convert.ToInt32(c.R), Convert.ToInt32(c.G), Convert.ToInt32(c.B), Convert.ToInt32(c.A));
                        cmdSetEndColour.BackColor = c;
                    }
                }
            }
        }
        // Interpolates between two colours based on time to live
        private Color LerpColour(IntPtr particle, float initialTTL, float currentTTL)
        {
            float step = currentTTL / initialTTL;

            int a = (int)((NativeMethods.GetInitialColourA(particle) * step) + (NativeMethods.GetFinalColourA(particle) * (1 - step)));
            int r = (int)Convert.ToInt32(((NativeMethods.GetInitialColourR(particle) * step) + (NativeMethods.GetFinalColourR(particle) * (1 - step))));
            int g = (int)Convert.ToInt32(((NativeMethods.GetInitialColourG(particle) * step) + (NativeMethods.GetFinalColourG(particle) * (1 - step))));
            int b = (int)Convert.ToInt32(((NativeMethods.GetInitialColourB(particle) * step) + (NativeMethods.GetFinalColourB(particle) * (1 - step))));

            return Color.FromArgb(a, r, g, b);
        }

        // Changes the shape of the particles
        private void ChangeShape(int shape)
        {
            NativeMethods.changeType(activeEmitter, shape);
        }

        // Tells the emitter to emit or not
        private void EmitAllowed()
        {
            if (activeEmitter != IntPtr.Zero)
            {
                bool shouldEmit = checkBoxEmit.Checked;
                if (shouldEmit)
                {
                    NativeMethods.StartEmitting(activeEmitter);
                }
                else
                {
                    NativeMethods.StopEmitting(activeEmitter);
                }
            }
        }

        // Creates a fresh form
        private void NewFile()
        {
            // Check if dirty
            if (isDirty)
            {
                PromptSaveChanges();
            }

            // Reset form
            Reset();
        }

        // Quicksaves a file
        private void QuickSave()
        {
            if (quickSaveFile.Equals(""))
            {
                SaveAs();
            }
            else
            {
                SaveFileToXML(quickSaveFile);
            }
        }

        // Exits the application
        private void Exit()
        {
            // Check if dirty
            if (isDirty)
            {
                PromptSaveChanges();
            }
        }

        // Updates all the emitters
        private void UpdateEmitters()
        {
            float delta = particleClock.Interval / 1000.0f;

            // Cycle through emitters
            for (int i = 0; i < emitters.Count; i++)
            {
                NativeMethods.ParticleEmitter_Update(emitters[i], delta);
            }

            particles_pb.Refresh();
        }

        // Draw call
        private void Draw(PaintEventArgs e)
        {
            for (int i = 0; i < emitters.Count; i++)
            {
                IntPtr emitter = emitters[i];
                DrawParticles(e, emitter);
                DrawEmitter(e, emitter);
            }
        }

        // Draws all particles
        private void DrawParticles(PaintEventArgs e, IntPtr emitter)
        {
            int size = NativeMethods.GetParticleCount(emitter);
            IntPtr particle = NativeMethods.GetFirstParticle(emitter);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            for (int j = 0; j < size; j++)
            {
                // Lerp colour based on time to live
                float initialTTL = NativeMethods.GetInitialTTL(particle);
                float currentTTL = NativeMethods.GetCurrentTTL(particle);
                Color deltaColour = LerpColour(particle, initialTTL, currentTTL);
                using (Brush brush = new SolidBrush(deltaColour))
                {
                    float x = NativeMethods.GetX(particle);
                    float y = NativeMethods.GetY(particle);

                    // Draw particle shape
                    switch (NativeMethods.GetParticleType(emitter))
                    {
                        case 1: // Diamond
                            PointF[] diamond = CalculateDiamondPoints(new PointF(x, y), DIAMOND_WIDTH);
                            e.Graphics.FillPolygon(brush, diamond);
                            break;
                        default: // Circle
                            e.Graphics.FillEllipse(brush, x - (0.5f * CIRCLE_RADIUS), y - (0.5f * CIRCLE_RADIUS), CIRCLE_RADIUS, CIRCLE_RADIUS);
                            break;
                    }
                }
                particle = IntPtr.Add(particle, IntPtr.Size);
            }
        }
        // Defines a set of points for a diamond polygon
        private PointF[] CalculateDiamondPoints(PointF Orig, float width)
        {
            // Fill array with 4 origin points
            PointF[] pnts = { Orig, Orig, Orig, Orig };
            pnts[0].X -= width;
            pnts[1].Y += width * 2.0f;
            pnts[2].X += width;
            pnts[3].Y -= width * 2.0f;

            return pnts;
        }

        // Draws the emitter
        private void DrawEmitter(PaintEventArgs e, IntPtr emitter)
        {
            Color c = (activeEmitter == emitter) ? Color.Green : Color.White;
            using (Brush emitterBrush = new SolidBrush(c))
            {
                float emX = NativeMethods.GetEmitterX(emitter);
                float emY = NativeMethods.GetEmitterY(emitter);
                e.Graphics.FillEllipse(emitterBrush, emX - (0.5f * EMITTER_WIDTH), emY - (0.5f * EMITTER_HEIGHT), EMITTER_WIDTH, EMITTER_HEIGHT);
            }
        }


        // Sets the application to dirty (requires saving to keep changes)
        private void SetDirty(bool dirty)
        {
            isDirty = dirty;
        }

        // Prompts the user to save to keep changes
        private void PromptSaveChanges()
        {
            string fileName = (quickSaveFile.Equals("")) ? "Untitled.XML" : quickSaveFile;
            DialogResult dr = MessageBox.Show("Do you want to save changes you made to " + fileName + "?", "ParticleTool", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                QuickSave();
            }
            else if (dr == DialogResult.No)
            {
                Application.Exit();
            }
        }

        // Removes all emitters
        private void RemoveAllEmitters()
        {
            for (int i = 0; i < emitters.Count; i++)
            {
                RemoveEmitter(emitters[i]);
            }
            SetDirty(true);
        }

        // Enable/Disable Control functionality
        private void SetControlsEnabled(bool enable)
        {
            trackBarEmissionRate.Enabled = enable;
            trackBarMaxParticles.Enabled = enable;
            cmdSetStartColour.Enabled = enable;
            cmdSetEndColour.Enabled = enable;
            cmdDeleteEmitter.Enabled = enable;
            cbParticleType.Enabled = enable;
            checkBoxEmit.Enabled = enable;
        }

        // Resets the form to its default state
        private void Reset()
        {
            RemoveAllEmitters();
            emitters.Clear();
            activeEmitter = IntPtr.Zero;
            activeEmitterIsMoving = false;
            quickSaveFile = "";
            SetDirty(false);
            particleClock.Start();
        }

        // Refresh Output
        private void RefreshAll()
        {
            particles_pb.Refresh();

            if (activeEmitter != IntPtr.Zero)
            {
                // Set trackbar values
                trackBarEmissionRate.Value = NativeMethods.GetEmissionRate(activeEmitter);
                trackBarMaxParticles.Value = NativeMethods.GetMaxParticles(activeEmitter);

                // Enable controls
                SetControlsEnabled(true);

                if (NativeMethods.GetIsEmitting(activeEmitter) != checkBoxEmit.Checked)
                {
                    checkBoxEmit.Checked = !checkBoxEmit.Checked;
                }
            }
            else
            {
                // Disable controls
                SetControlsEnabled(false);
            }
        }
    }
}