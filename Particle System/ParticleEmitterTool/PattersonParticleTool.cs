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
    public partial class Form1
    {
        // Add an emitter to the Form
        private void AddEmitter()
        {
            IntPtr emitter = NativeMethods.CreateDefaultParticleEmitter_Object();
            if (emitter != IntPtr.Zero)
            {
                activeEmitter = emitter;
                emitters.Add(emitter);
                NativeMethods.SetInitialColour(emitter, 255, 255, 255, 255);
                NativeMethods.SetFinalColour(emitter, 255, 255, 255, 255);
                cbParticleType.SelectedIndex = 0;
            }
            RefreshAll();
        }

        // Remove an emitter from the Form
        private void RemoveEmitter(IntPtr emitter)
        {
            if (emitter != IntPtr.Zero)
            {
                emitters.Remove(emitter);
                NativeMethods.DeleteParticleEmitter_Object(emitter);

                if (emitter == activeEmitter)
                {
                    activeEmitter = IntPtr.Zero;
                }
            }
            RefreshAll();
        }

        // Select emitter
        private void SelectEmitter(MouseEventArgs e)
        {
            foreach (var emitter in emitters)
            {
                Rectangle r = new Rectangle(
                    new Point((int)NativeMethods.GetEmitterX(emitter) - 25, (int)NativeMethods.GetEmitterY(emitter) - 25),
                    new Size(50, 50));

                if (r.Contains(e.Location))
                {
                    activeEmitter = emitter;
                    activeEmitterIsMoving = true;
                    mousePointerLastPosition = e.Location;
                    break;
                }
            }
            RefreshAll();
        }

        // Move active emitter
        private void MoveEmitter(MouseEventArgs e)
        {
            if (activeEmitterIsMoving && activeEmitter != null)
            {
                NativeMethods.SetEmitterX(activeEmitter,
                    NativeMethods.GetEmitterX(activeEmitter) + e.Location.X - mousePointerLastPosition.X);

                NativeMethods.SetEmitterY(activeEmitter,
                    NativeMethods.GetEmitterY(activeEmitter) + e.Location.Y - mousePointerLastPosition.Y);

                mousePointerLastPosition = e.Location;
                SetDirty(true);
                RefreshAll();
            }
        }

        // Release active emitter
        private void SetActiveEmitterIsMoving(bool isMoving)
        {
            activeEmitterIsMoving = isMoving;
        }

        // Save a new File
        private void SaveAs()
        {
            DialogResult dr = saveEmitterFile_dialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                quickSaveFile = saveEmitterFile_dialog.FileName;
                SaveFileToXML(saveEmitterFile_dialog.FileName);
            }
        }

        // Open an existing File
        private void OpenFile()
        {
            DialogResult dr = openEmitterFile_dialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                quickSaveFile = openEmitterFile_dialog.FileName;
                LoadFileFromXML(openEmitterFile_dialog.FileName);
            }
        }

        // Saves the current settings
        private void SaveFileToXML(string filename)
        {
            // Create xml
            XmlDocument doc = new XmlDocument();
            XmlNode decNode = doc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
            doc.AppendChild(decNode);

            XmlElement EmitterSet = doc.CreateElement("EmitterSet");
            foreach (var em in emitters)
            {
                XmlElement emElement = doc.CreateElement("Emitter");
                emElement.SetAttribute("X", NativeMethods.GetEmitterX(em).ToString());
                emElement.SetAttribute("Y", NativeMethods.GetEmitterY(em).ToString());
                emElement.SetAttribute("EmRate", NativeMethods.GetEmissionRate(em).ToString());
                emElement.SetAttribute("MaxParticles", NativeMethods.GetMaxParticles(em).ToString());
                emElement.SetAttribute("ParticleType", NativeMethods.GetParticleType(em).ToString());

                emElement.SetAttribute("initialR", NativeMethods.GetEmitterInitialColourR(em).ToString());
                emElement.SetAttribute("initialG", NativeMethods.GetEmitterInitialColourG(em).ToString());
                emElement.SetAttribute("initialB", NativeMethods.GetEmitterInitialColourB(em).ToString());
                emElement.SetAttribute("initialA", NativeMethods.GetEmitterInitialColourA(em).ToString());

                emElement.SetAttribute("finalR", NativeMethods.GetEmitterFinalColourR(em).ToString());
                emElement.SetAttribute("finalG", NativeMethods.GetEmitterFinalColourG(em).ToString());
                emElement.SetAttribute("finalB", NativeMethods.GetEmitterFinalColourB(em).ToString());
                emElement.SetAttribute("finalA", NativeMethods.GetEmitterFinalColourA(em).ToString());
                EmitterSet.AppendChild(emElement);
            }
            doc.AppendChild(EmitterSet);
            doc.Save(filename);
            SetDirty(false);
        }

        // Loads the selected XML file
        private void LoadFileFromXML(string fileName)
        {
            for (int i = 0; i < emitters.Count; i++)
            {
                NativeMethods.DeleteParticleEmitter_Object(emitters[0]);
                emitters.Remove(emitters[0]);
            }
            activeEmitter = IntPtr.Zero;

            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            XmlNode emNode = (XmlNode)doc.FirstChild.NextSibling;

            emNode = emNode.FirstChild;
            while (emNode != null)
            {
                XmlAttributeCollection att = emNode.Attributes;
                string sX = att["X"].Value;
                string sY = att["Y"].Value;
                int x = int.Parse(sX);
                int y = int.Parse(sY);

                string sRate = att["EmRate"].Value;
                string sMax = att["MaxParticles"].Value;
                string sType = att["ParticleType"].Value;
                int rate = int.Parse(sRate);
                int max = int.Parse(sMax);
                int type = int.Parse(sType);

                // Initial colors
                string sInitialR = att["initialR"].Value;
                string sInitialG = att["initialG"].Value;
                string sInitialB = att["initialB"].Value;
                string sInitialA = att["initialA"].Value;
                int initialR = int.Parse(sInitialR);
                int initialG = int.Parse(sInitialG);
                int initialB = int.Parse(sInitialB);
                int initialA = int.Parse(sInitialA);

                // Final colors
                string sFinalR = att["finalR"].Value;
                string sFinalG = att["finalG"].Value;
                string sFinalB = att["finalB"].Value;
                string sFinalA = att["finalA"].Value;
                int finalR = int.Parse(sFinalR);
                int finalG = int.Parse(sFinalG);
                int finalB = int.Parse(sFinalB);
                int finalA = int.Parse(sFinalA);

                IntPtr emitter = NativeMethods.CreateDefaultParticleEmitter_Object();
                NativeMethods.SetEmitterX(emitter, x);
                NativeMethods.SetEmitterY(emitter, y);
                NativeMethods.setEmissionRate(emitter, rate);
                NativeMethods.changeType(emitter, type);
                NativeMethods.setMaxParticles(emitter, max);
                NativeMethods.SetInitialColour(emitter, initialR, initialG, initialB, initialA);
                NativeMethods.SetFinalColour(emitter, finalR, finalG, finalB, finalA);

                if (emitter != IntPtr.Zero)
                {
                    activeEmitter = emitter;
                    emitters.Add(emitter);
                }
                emNode = emNode.NextSibling;
            }

            SetDirty(false);
            RefreshAll();
        }
    }
}
