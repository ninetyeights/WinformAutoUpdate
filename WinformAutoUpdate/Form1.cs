using System.IO;
using System.IO.Compression;
using System.Net;
using System.Diagnostics;
using System.Reflection;

namespace WinformAutoUpdate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            checkUpdate();
        }

        private void checkUpdate()
        {
            WebClient webClient = new WebClient();
            WebClient client = new WebClient();

            var urlVersion = "https://www.dropbox.com/scl/fi/1fr7a7i4pf64f7uya3woy/Update.txt?rlkey=hrx1g82bcx5ts75sb9c5k0irc&dl=1";
            var newVersion = webClient.DownloadString(urlVersion);
            var currentVersion = Application.ProductVersion.ToString();

            newVersion = newVersion.Replace(".", "");
            currentVersion = currentVersion.Replace(".", "");
            MessageBox.Show("New Version: " + newVersion + "");
            MessageBox.Show("Current Version: " + currentVersion + "");

            if (Convert.ToInt32(newVersion) > Convert.ToInt32(currentVersion))
            {
                MessageBox.Show("New Version can update");
                if (MessageBox.Show("新版本可用！是否更新？", "TestApp", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show("Click OK");
                    try
                    {
                        if (File.Exists(@".\TestAppSetup.msi")) { File.Delete(@".\TestAppSetup.msi"); }
                        client.DownloadFileCompleted += WebDownloadFileCompleted;
                        client.DownloadFileAsync(new Uri("https://www.dropbox.com/scl/fi/n22dvfrhlkprmfexx5xhj/TestAppSetup.msi?rlkey=wayb7zzeflzr94hifwjzmi0ch&dl=1"), @"TestAppSetup.msi");
                        //string zipPath = @".\TestAppSetup.zip";
                        //string extractPath = @".\";
                        //ZipFile.ExtractToDirectory(zipPath, extractPath);

                        //string path = Application.StartupPath + @"\update.bat";

                        //Process p = new Process();
                        //p.StartInfo.FileName = path;
                        //p.StartInfo.Arguments = "";
                        //p.StartInfo.UseShellExecute = false;
                        //p.StartInfo.CreateNoWindow = true;
                        //p.StartInfo.RedirectStandardOutput = true;
                        //p.StartInfo.Verb = "runas";
                        //p.Start();
                        //Environment.Exit(1);

                        //Process process = new Process();
                        //process.StartInfo.FileName = "msiexec";
                        //process.StartInfo.Arguments = String.Format("/i TestAppSetup.msi /qn");

                        //this.Close();
                        //process.Start();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void WebDownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download Completed!");
            try
            {
                string path = Application.StartupPath + @"update.bat";
                //MessageBox.Show(Assembly.GetEntryAssembly().GetName().Name);
                MessageBox.Show(path);

                Process p = new Process();
                p.StartInfo.FileName = path;
                p.StartInfo.Arguments = "";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.Verb = "runas";
                p.Start();
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RestartApplication()
        {
            // Restart the application using the same executable
            Process.Start(Application.ExecutablePath);

            // Close the current instance
            Environment.Exit(0);
        }
    }
}