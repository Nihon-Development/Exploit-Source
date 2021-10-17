using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Net;
using System.IO.Compression;

namespace Project_Horizon_Bootstrapper
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StartDownload();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private async void StartDownload()
        {
            await Task.Delay(2000);
            String ProgramName = "Project Horizon.zip";
            String DownloadLink = "https://pastebin.com/raw/3ahBB1kp";
            WebClient WebClient = new WebClient();
            String Key = WebClient.DownloadString(DownloadLink);
            String DirectoryPath = @"" + ProgramName + "";
            WebClient Download = new WebClient();
            String Patch = (@"Project Horizon");
            Download.DownloadFile(Key, DirectoryPath);
            string zipPath = @"Project Horizon.zip";
            string extract = "Project Horizon";
            if (Directory.Exists(@"Project Horizon"))
            {
                Directory.Delete(@"Project Horizon", true);
            }
            ZipFile.ExtractToDirectory(zipPath, extract);
            if (File.Exists(@"Project Horizon.zip"))
            {
                File.Delete(@"Project Horizon.zip");
            }
            await Task.Delay(4000);
            Close();
        }
    }
}
