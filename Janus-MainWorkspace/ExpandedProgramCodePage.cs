using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CxTitan
{
    public partial class ExpandedProgramCodePage : Form
    {
        public ExpandedProgramCodePage()
        {
            InitializeComponent();
        }

        private void cmdCompile_Click(object sender, EventArgs e)
        {
            string startupPath = Environment.CurrentDirectory;
            string curCompileDecompileSettingFile = "sa_compile_decompile_setup.txt";
            string curCompileDecompileSettingDir = startupPath + "\\" + curCompileDecompileSettingFile;

            string[] CompileDecompileSettingRows = new string[] { "MOD:DMX-K-SA-17/23", "OPE:COMPILE", "FIL:Program.prg", "VER:401BLA" };// row settings can be edit later
            using (StreamWriter sw = new StreamWriter(curCompileDecompileSettingFile))
            {
                foreach (string s in CompileDecompileSettingRows)
                {
                    sw.WriteLine(s);
                }
            }

            if (string.IsNullOrEmpty(txtProgramCode.Text))
            {
                MessageBox.Show("Nothing to Compile!");
            }
            else
            {
                string curCompileFile = "Program.prg";
                string curCompileDir = startupPath + "\\" + curCompileFile;
                File.WriteAllText(curCompileFile, txtProgramCode.Text);
                string arg = @"user=Software-2";// just an example this can be anything
                string command = "SA_Compile_Decompile.exe";
                ProcessStartInfo compileProc = new ProcessStartInfo(command, arg);
                compileProc.UseShellExecute = false;
                compileProc.CreateNoWindow = true; // Important if you want to keep shell window hidden
                Process.Start(compileProc).WaitForExit(); //important to add WaitForExit()

                string curCompileOutFile = "CompileOut.txt";
                string curCompileOutDir = startupPath + "\\" + curCompileOutFile;
                string retMsg = "";// Messgebox display
                bool IsCompileOk = true;
                string resultString = "";
                if (File.Exists(curCompileOutFile))
                {
                    string[] lines = File.ReadAllLines(curCompileOutFile);
                    foreach (string line in lines)
                    {
                        // later polish it for focus the line number
                        //if (line.Contains("Line"))
                        //{
                        //    resultString = Regex.Match(line, @"\d+").Value;
                        //    txtCode.SelectionStart = line.Length - 1;// line number
                        //    txtCode.SelectionLength = 1;
                        //    txtCode.Focus();
                        //}
                        if (line.Contains("Failed Compile!"))
                        {
                            IsCompileOk = false;
                        }
                        retMsg += line + "\n";
                    }
                    if (!IsCompileOk)// IsCompileOk become false, only when have "Failed Compile!" display Msg, otherwise no display
                    {
                        MessageBox.Show(retMsg);
                    }
                    else
                    {
                        MessageBox.Show("Done!");
                    }
                }
                else
                {
                    MessageBox.Show("Can not find the File CompileOut.txt.");
                    return;
                }
                //MessageBox.Show("OK");
            }
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            if (MotorControls.IsMotorSerialInitialized)
            {
                MotorControls.oHyperTerminalAdapter.CloseSerialPort();// close serial port

                string startupPath = Environment.CurrentDirectory;
                // Download
                // write some settings to sa_download_upload_setup.txt here
                string curDownloadUploadSettingFile = "sa_download_upload_setup.txt";
                string curDownloadUploadSettingDir = startupPath + "\\" + curDownloadUploadSettingFile;
                string[] DownloadUploadSettingRows = new string[] { "LIN:1275", "COM:SERIAL", "POR:5", "BAU:" + MotorControls.oHyperTerminalAdapter.BaudRate.ToString(), "DEV:01", 
                "OPE:DOWNLOAD", "FIL:CompileOut.txt", "MOD:DMX-K-SA-17/23" };// row settings can be edit later
                using (StreamWriter sw = new StreamWriter(curDownloadUploadSettingFile))
                {
                    foreach (string s in DownloadUploadSettingRows)
                    {
                        sw.WriteLine(s);
                    }
                }

                string arg = @"user=Software-2";// just an example this can be anything
                string command = "SA_Download_Upload.exe";
                ProcessStartInfo downloadProc = new ProcessStartInfo(command, arg);
                downloadProc.UseShellExecute = false;
                downloadProc.CreateNoWindow = true; // Important if you want to keep shell window hidden
                Process.Start(downloadProc).WaitForExit(); //important to add WaitForExit()

                string curDownloadOutFile = "DownloadOut.txt";
                string curDownloadOutDir = startupPath + "\\" + curDownloadOutFile;
                string retMsg = "";// Messgebox display
                bool IsDownloadOk = true;
                string resultString = "";
                if (File.Exists(curDownloadOutFile))
                {
                    string[] lines = File.ReadAllLines(curDownloadOutFile);
                    foreach (string line in lines)
                    {
                        if (line.Contains("DOWNLOAD FAILED!"))
                        {
                            IsDownloadOk = false;
                        }
                        retMsg += line + "\n";
                    }
                    if (!IsDownloadOk)// IsCompileOk become false, only when have "Failed Compile!" display Msg, otherwise no display
                    {
                        MessageBox.Show(retMsg);
                    }
                    else
                    {
                        MessageBox.Show("Done!");
                    }
                }
                else
                {
                    MessageBox.Show("Can not find the File DownloadOut.txt.");
                    return;
                }

                MotorControls.oHyperTerminalAdapter.OpenSerialPort();// open serial port
            }
            else
            {
                MessageBox.Show("Communication port not open! Cannot download program to the motor!");
            }
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            if (MotorControls.IsMotorSerialInitialized)
            {
                MotorControls.oHyperTerminalAdapter.CloseSerialPort();// close serial port

                string startupPath = Environment.CurrentDirectory;
                txtProgramCode.Clear();
                // Upload
                // write some settings to sa_download_upload_setup.txt here
                //string curDownloadUploadSettingFile =
                //    @"D:\JanusProjects\TestRunExeProcess\TestRunExeProcess\TestRunExeProcess\bin\Debug\sa_download_upload_setup.txt";
                string curDownloadUploadSettingFile = "sa_download_upload_setup.txt";
                string curDownloadUploadSettingDir = startupPath + "\\" + curDownloadUploadSettingFile;

                string[] DownloadUploadSettingRows = new string[] { "LIN:1275", "COM:SERIAL", "DEV:01", "POR:5", "BAU:" + MotorControls.oHyperTerminalAdapter.BaudRate.ToString(), 
                "OPE:UPLOAD", "FIL:CompileOut.txt", "MOD:DMX-K-SA-17/23" };// row settings can be edit later
                using (StreamWriter sw = new StreamWriter(curDownloadUploadSettingFile))
                {
                    foreach (string s in DownloadUploadSettingRows)
                    {
                        sw.WriteLine(s);
                    }
                }

                // Decompile
                // write some settings to sa_compile_decompile_setup.txt here
                string curCompileDecompileSettingFile = "sa_compile_decompile_setup.txt";
                string curCompileDecompileSettingDir = startupPath + "\\" + curCompileDecompileSettingFile;

                string[] CompileDecompileSettingRows = new string[] { "MOD:DMX-K-SA-17/23", "OPE:DECOMPILE", "FIL:UploadOut.txt", "VER:401BLA" };// row settings can be edit later
                using (StreamWriter sw = new StreamWriter(curCompileDecompileSettingFile))
                {
                    foreach (string s in CompileDecompileSettingRows)
                    {
                        sw.WriteLine(s);
                    }
                }

                // Run Shell
                string arg1 = @"user=Software-2";// just an example this can be anything
                string command1 = "SA_Download_Upload.exe";
                ProcessStartInfo uploadProc = new ProcessStartInfo(command1, arg1);
                uploadProc.UseShellExecute = false;
                uploadProc.CreateNoWindow = true; // Important if you want to keep shell window hidden
                Process.Start(uploadProc).WaitForExit(); //important to add WaitForExit()

                // Compile
                string arg2 = @"user=Software-2";// just an example this can be anything
                string command = "SA_Compile_Decompile.exe";
                ProcessStartInfo compileProc = new ProcessStartInfo(command, arg2);
                compileProc.UseShellExecute = false;
                compileProc.CreateNoWindow = true; // Important if you want to keep shell window hidden
                Process.Start(compileProc).WaitForExit(); //important to add WaitForExit()

                // Read Decompile File
                string curDeCompileOutFile = "DecompileOut.prg";
                string curDeCompileOutDir = startupPath + "\\" + curDeCompileOutFile;
                if (File.Exists(curDeCompileOutFile))
                {
                    string[] lines = File.ReadAllLines(curDeCompileOutFile);
                    foreach (string line in lines)
                    {
                        txtProgramCode.AppendText(line + "\r\n");
                    }
                }
                else
                {
                    MessageBox.Show("File DecompileOut.prg does not exist.");
                    return;
                }

                MotorControls.oHyperTerminalAdapter.OpenSerialPort();// open serial port
            }
            else
            {
                MessageBox.Show("Communication port not open! Cannot upload program from the motor!");
            }
        }

        private void cmdOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileOpenDialog = new OpenFileDialog();
            fileOpenDialog.Filter = "DMX-K-SA Program Files (*.prg)|*.prg";
            fileOpenDialog.Title = "Open DMX-K-SA Program";
            fileOpenDialog.InitialDirectory = "C:\\Program Files (x86)\\Arcus Technology\\Drivemax Series\\";
            fileOpenDialog.ShowDialog();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "DMX-K-SA Program Files (*.prg)|*.prg";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.Title = "Save DMX-K-SA Program As";
            saveFileDialog.InitialDirectory = "C:\\Program Files (x86)\\Arcus Technology\\Drivemax Series\\";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    myStream.Close();
                }
            }
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            txtProgramCode.Clear();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            SystemGlobals.objMagazinePage.txtCode.Text = txtProgramCode.Text;
            this.Close();
            this.Dispose();
            if (MotorControls.IsMotorSerialInitialized)
            {
                SystemGlobals.objMagazinePage.TimerStates.Enabled = true;
            }
            else
            {
                SystemGlobals.objMagazinePage.TimerStates.Enabled = false;
            }
        }

        private void ExpandedProgramCodePage_Load(object sender, EventArgs e)
        {
            txtProgramCode.Text = SystemGlobals.objMagazinePage.txtCode.Text;
            txtProgramCode.SelectionStart = txtProgramCode.TextLength;
            txtProgramCode.SelectionLength = 0;
        }
    }
}
