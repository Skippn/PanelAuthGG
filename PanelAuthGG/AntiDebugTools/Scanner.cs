using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;
using System.Threading;
using System.Windows.Forms;
using System.Management;
using System.Runtime.InteropServices;

namespace PanelAuthGG.AntiDebugTools
{
    class Scanner
    {
        private static bool TurnedOnFreezeMouse { get; set; }

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("kernel32.dll")]
        static extern IntPtr GetCurrentProcessId();

        [DllImport("user32.dll")]
        static extern int GetWindowThreadProcessId(IntPtr hWnd, ref IntPtr processId);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern void BlockInput([In, MarshalAs(UnmanagedType.Bool)] bool fBlockIt);

        private static HashSet<string> BadProcessnameList = new HashSet<string>();
        private static HashSet<string> BadWindowTextList = new HashSet<string>();

        public static void ScanAndKill()
        {
            if (Scan(true) != 0)
            {
                Thread.Sleep(5000);
                MessageBox.Show("Application has crashed!\nError code: 0", "PanelAuthGG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            if (DetectVirtualMachine())
            {
                MessageBox.Show("Application can not run in a VM!\nError code: 1", "PanelAuthGG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            if (DetectSandbox())
            {
                MessageBox.Show("Application can not run in a Sandbox!\nError code: 2", "PanelAuthGG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            if (DetectEmulation())
            {
                MessageBox.Show("Application can not run in an Emulation!\nError code: 3", "PanelAuthGG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Simple scanner for "bad" processes (debuggers) using .NET code only. (for now)
        /// </summary>
        private static int Scan(bool KillProcess)
        {
            int isBadProcess = 0;

            if (BadProcessnameList.Count == 0 && BadWindowTextList.Count == 0)
            {
                Init();
            }

            Process[] processList = Process.GetProcesses();

            foreach (Process process in processList)
            {
                if (BadProcessnameList.Contains(process.ProcessName) || BadWindowTextList.Contains(process.MainWindowTitle))
                {
                    //Console.ForegroundColor = ConsoleColor.Red;
                    //Console.Write("BAD PROCESS FOUND: " + process.ProcessName);
                    //MessageBox.Show("Application has crashed!\nError code: 1", OnProgramStart.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    isBadProcess = 1;

                    if (KillProcess)
                    {
                        try
                        {
                            process.Kill();
                        }
                        catch (System.ComponentModel.Win32Exception w32ex)
                        {
                            MessageBox.Show("Win32Exception: " + w32ex.Message, "PanelAuthGG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            
                            break;
                        }
                        catch (System.NotSupportedException nex)
                        {
                            MessageBox.Show("NotSupportedException: " + nex.Message, "PanelAuthGG", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            break;
                        }
                        catch (System.InvalidOperationException ioex)
                        {
                            MessageBox.Show("InvalidOperationException: " + ioex.Message, "PanelAuthGG", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            break;
                        }
                    }

                    break;
                }
            }

            return isBadProcess;
        }

        /// <summary>
        /// Populate "database" with process names/window names.
        /// Using HashSet for maximum performance
        /// </summary>
        private static int Init()
        {
            if (BadProcessnameList.Count > 0 && BadWindowTextList.Count > 0)
            {
                return 1;
            }

            BadProcessnameList.Add("ollydbg");
            BadProcessnameList.Add("ida");
            BadProcessnameList.Add("ida64");
            BadProcessnameList.Add("idag");
            BadProcessnameList.Add("idag64");
            BadProcessnameList.Add("idaw");
            BadProcessnameList.Add("idaw64");
            BadProcessnameList.Add("idaq");
            BadProcessnameList.Add("idaq64");
            BadProcessnameList.Add("idau");
            BadProcessnameList.Add("idau64");
            BadProcessnameList.Add("scylla");
            BadProcessnameList.Add("scylla_x64");
            BadProcessnameList.Add("scylla_x86");
            BadProcessnameList.Add("protection_id");
            BadProcessnameList.Add("x64dbg");
            BadProcessnameList.Add("x32dbg");
            BadProcessnameList.Add("windbg");
            BadProcessnameList.Add("reshacker");
            BadProcessnameList.Add("ImportREC");
            BadProcessnameList.Add("IMMUNITYDEBUGGER");
            BadProcessnameList.Add("MegaDumper");
            BadProcessnameList.Add("dnSpy");
            BadProcessnameList.Add("cheatengine-x86_64-SSE4-AVX2");
            BadProcessnameList.Add("ReClass.NET");
            BadProcessnameList.Add("dotPeek64");
            BadProcessnameList.Add("dotPeek32");
            BadProcessnameList.Add("die");
            BadProcessnameList.Add("CrackTools");
            BadProcessnameList.Add("CFF Explorer");
            BadProcessnameList.Add("HxD64");
            BadProcessnameList.Add("HxD32");
            BadProcessnameList.Add("Taskmgr");

            BadWindowTextList.Add("HTTPDebuggerUI");
            BadWindowTextList.Add("HTTPDebuggerSvc");
            BadWindowTextList.Add("HTTP Debugger");
            BadWindowTextList.Add("HTTP Debugger (32 bit)");
            BadWindowTextList.Add("HTTP Debugger (64 bit)");
            BadWindowTextList.Add("OLLYDBG");
            BadWindowTextList.Add("ida");
            BadWindowTextList.Add("disassembly");
            BadWindowTextList.Add("scylla");
            BadWindowTextList.Add("Debug");
            BadWindowTextList.Add("[CPU");
            BadWindowTextList.Add("Immunity");
            BadWindowTextList.Add("WinDbg");
            BadWindowTextList.Add("x32dbg");
            BadWindowTextList.Add("x64dbg");
            BadWindowTextList.Add("Import reconstructor");
            BadWindowTextList.Add("MegaDumper");
            BadWindowTextList.Add("MegaDumper 1.0 by CodeCracker / SnD");
            BadWindowTextList.Add("dnSpy");
            BadWindowTextList.Add("cheatengine-x86_64-SSE4-AVX2");
            BadWindowTextList.Add("ReClass.NET");
            BadWindowTextList.Add("dotPeek64");
            BadWindowTextList.Add("dotPeek32");
            BadWindowTextList.Add("die");
            BadWindowTextList.Add("CrackTools");
            BadWindowTextList.Add("CFF Explorer");
            BadWindowTextList.Add("HxD64");
            BadWindowTextList.Add("HxD32");
            BadWindowTextList.Add("Taskmgr");

            return 0;
        }

        public static bool DetectVirtualMachine()
        {
            using (var managementObjectSearcher = new ManagementObjectSearcher("Select * from Win32_ComputerSystem"))
            {
                using (var managementObjectCollection = managementObjectSearcher.Get())
                {
                    foreach (var managementBaseObject in managementObjectCollection)
                    {
                        if (managementBaseObject["Manufacturer"]?.ToString()?.ToLower() == "microsoft corporation" &&
                            managementBaseObject["Model"]?.ToString()?.ToUpperInvariant().Contains("VIRTUAL") == true ||
                            managementBaseObject["Manufacturer"]?.ToString()?.ToLower().Contains("vmware") == true ||
                            managementBaseObject["Model"]?.ToString() == "VirtualBox")
                        {
                            return true; 
                        }
                    }
                }
            }
            foreach (var managementBaseObject2 in new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController").Get())
            {
                if (managementBaseObject2.GetPropertyValue("Name")?.ToString()?.Contains("VMware") == true &&
                    managementBaseObject2.GetPropertyValue("Name")?.ToString()?.Contains("VBox") == true)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool DetectSandbox()
        {
            return GetModuleHandle("SbieDll.dll").ToInt32() != 0;
        }

        public static bool DetectEmulation()
        {
            long tickCount = Environment.TickCount;
            Thread.Sleep(500);
            long tickCount2 = Environment.TickCount;
            return tickCount2 - tickCount < 500L;
        }

    }
}
