using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PanelAuthGG
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            #region ProtectionIGuess
            // kill unwanted programs
            PanelAuthGG.AntiDebugTools.Scanner.ScanAndKill();

            if (PanelAuthGG.AntiDebug.DebugProtect1.PerformChecks() == 1)
            {
                Environment.FailFast("");
            }

            if (PanelAuthGG.AntiDebug.DebugProtect2.PerformChecks() == 1)
            {
                Environment.FailFast("");
            }

            System.Threading.Thread workerThread = new System.Threading.Thread(() =>
            {
                while (true)
                {
                    PanelAuthGG.AntiDebugTools.Scanner.ScanAndKill();

                    if (PanelAuthGG.AntiDebug.DebugProtect1.PerformChecks() == 1)
                    {
                        Environment.FailFast("");
                    }

                    if (PanelAuthGG.AntiDebug.DebugProtect2.PerformChecks() == 1)
                    {
                        Environment.FailFast("");
                    }

                    System.Threading.Thread.Sleep(1000);
                }
            });

            PanelAuthGG.AntiDebug.DebugProtect3.HideOSThreads();
            #endregion

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Initialform());
        }
    }
}
