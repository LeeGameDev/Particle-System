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
        static class NativeMethods
        {
            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr CreateDefaultParticleEmitter_Object();

            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.Cdecl)]
            public static extern void DeleteParticleEmitter_Object(IntPtr Object);

            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.ThisCall,
                EntryPoint = "?Update@ParticleEmitter@@QAEXM@Z")]
            public static extern void ParticleEmitter_Update(IntPtr This, float delta);

            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.ThisCall,
                EntryPoint = "?GetMaxParticles@ParticleEmitter@@QAEHXZ")]
            public static extern int GetMaxParticles(IntPtr This);

            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.ThisCall,
                EntryPoint = "?GetEmissionRate@ParticleEmitter@@QAEHXZ")]
            public static extern int GetEmissionRate(IntPtr This);

            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.ThisCall,
                EntryPoint = "?GetParticleCount@ParticleEmitter@@QAEHXZ")]
            public static extern int GetParticleCount(IntPtr This);

            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.ThisCall,
                EntryPoint = "?GetParticleType@ParticleEmitter@@QAEHXZ")]
            public static extern int GetParticleType(IntPtr This);

            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.ThisCall,
                EntryPoint = "?GetIsEmitting@ParticleEmitter@@QAE_NXZ")]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern bool GetIsEmitting(IntPtr This);

            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr GetFirstParticle(IntPtr Object);

            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.Cdecl)]
            public static extern int GetInitialColourR(IntPtr Object);

            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.Cdecl)]
            public static extern int GetInitialColourG(IntPtr Object);

            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.Cdecl)]
            public static extern int GetInitialColourB(IntPtr Object);

            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.Cdecl)]
            public static extern int GetInitialColourA(IntPtr Object);

            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.Cdecl)]
            public static extern int GetFinalColourR(IntPtr Object);

            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.Cdecl)]
            public static extern int GetFinalColourG(IntPtr Object);

            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.Cdecl)]
            public static extern int GetFinalColourB(IntPtr Object);

            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.Cdecl)]
            public static extern int GetFinalColourA(IntPtr Object);

            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.Cdecl)]
            public static extern void SetInitialColour(IntPtr Object, int r, int g, int b, int a);

            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.Cdecl)]
            public static extern void SetFinalColour(IntPtr Object, int r, int g, int b, int a);

            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.Cdecl)]
            public static extern float GetX(IntPtr Object);

            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.Cdecl)]
            public static extern float GetY(IntPtr Object);

            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.Cdecl)]
            public static extern float GetInitialTTL(IntPtr Object);

            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.Cdecl)]
            public static extern float GetCurrentTTL(IntPtr Object);

            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.ThisCall,
                EntryPoint = "?StartEmitting@ParticleEmitter@@QAEXXZ")]
            public static extern int StartEmitting(IntPtr This);

            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.ThisCall,
                EntryPoint = "?StopEmitting@ParticleEmitter@@QAEXXZ")]
            public static extern int StopEmitting(IntPtr This);

            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.ThisCall,
                EntryPoint = "?changeType@ParticleEmitter@@QAEXH@Z")]
            public static extern int changeType(IntPtr This, int type);

            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.ThisCall,
                EntryPoint = "?setMaxParticles@ParticleEmitter@@QAEXH@Z")]
            public static extern int setMaxParticles(IntPtr This, int maxParticles);

            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.ThisCall,
                EntryPoint = "?setEmissionRate@ParticleEmitter@@QAEXH@Z")]
            public static extern int setEmissionRate(IntPtr This, int emissionRate);

            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.Cdecl)]
            public static extern float GetEmitterX(IntPtr Object);

            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.Cdecl)]
            public static extern float GetEmitterY(IntPtr Object);

            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.Cdecl)]
            public static extern void SetEmitterX(IntPtr Object, float x);

            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.Cdecl)]
            public static extern void SetEmitterY(IntPtr Object, float y);

            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.Cdecl)]
            public static extern int GetEmitterInitialColourR(IntPtr Object);

            [DllImport("ParticleEngineLibrary.dll",
               CallingConvention = CallingConvention.Cdecl)]
            public static extern int GetEmitterInitialColourG(IntPtr Object);

            [DllImport("ParticleEngineLibrary.dll",
               CallingConvention = CallingConvention.Cdecl)]
            public static extern int GetEmitterInitialColourB(IntPtr Object);

            [DllImport("ParticleEngineLibrary.dll",
               CallingConvention = CallingConvention.Cdecl)]
            public static extern int GetEmitterInitialColourA(IntPtr Object);

            [DllImport("ParticleEngineLibrary.dll",
                CallingConvention = CallingConvention.Cdecl)]
            public static extern int GetEmitterFinalColourR(IntPtr Object);

            [DllImport("ParticleEngineLibrary.dll",
               CallingConvention = CallingConvention.Cdecl)]
            public static extern int GetEmitterFinalColourG(IntPtr Object);

            [DllImport("ParticleEngineLibrary.dll",
               CallingConvention = CallingConvention.Cdecl)]
            public static extern int GetEmitterFinalColourB(IntPtr Object);

            [DllImport("ParticleEngineLibrary.dll",
               CallingConvention = CallingConvention.Cdecl)]
            public static extern int GetEmitterFinalColourA(IntPtr Object);
        }
    }
}