using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;

namespace obliterate
{
    class Program
    {
        static ProgressForm pForm;

        static void Main(string[] args)
        {
            string path = args[0];
            pForm = new ProgressForm();

            if (File.GetAttributes(path).HasFlag(FileAttributes.Directory))
            {
                OblDir(path);
                try
                {
                    Directory.Delete(path);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                OblFile(path);
            }

            MessageBox.Show("Obliterated.");
            Close(0);
        }

        private static void OblFile(string path)
        {
            if (!File.Exists(path))
            {
                return;
            }

            try
            {
                using (FileStream fs = new FileStream(path,
                                                  FileMode.Open,
                                                  FileAccess.Write,
                                                  FileShare.None))
                {
                    byte[] zeroBytes = new byte[fs.Length];
                    fs.Write(zeroBytes, 0, zeroBytes.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            File.Delete(path);
        }

        private static void OblDir(string path)
        {
            List<string> files = GetDirFiles(path);

            pForm.Caption = "Obliterating " + path;
            pForm.ProgressMaximum = files.Count;
            pForm.ProgressValue = 0;
            pForm.Show();

            foreach (string f in files)
            {
                BackgroundWorker backgroundWorker = new BackgroundWorker();
                backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
                backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
                backgroundWorker.RunWorkerAsync(f);
            }

            try
            {
                Directory.Delete(path, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            OblFile((string)e.Argument);
        }

        private static void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pForm.DoStep();
        }

        private static List<string> GetDirFiles(string path)
        {
            List<string> filesList = new List<string>();
            try
            {
                foreach (string f in Directory.GetFiles(path))
                    filesList.Add(f);
                foreach (string d in Directory.GetDirectories(path))
                {
                    GetDirFiles(d);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return filesList;
        }

        // Overkill
        static void Close(int exitCode)
        {
            if (Application.MessageLoop)
                Application.Exit();
            Environment.Exit(exitCode);
        }
    }
}
