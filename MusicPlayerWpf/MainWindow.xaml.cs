using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicPlayerWpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayer _player;
        List<FileInfo> filesInfolders = new List<FileInfo>();
        public MainWindow()
        {
            InitializeComponent();

            _player = new MediaPlayer();
            this.DataContext = this;
            FilesDG.ItemsSource = filesInfolders;
        }

        private void OpenFileMI_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".mp3",
                Multiselect = false
            };

            bool? fileDialogOk = fileDialog.ShowDialog();

            if (fileDialogOk == true) {
                var name = fileDialog.FileName.Split('\\').Last();
                var filename = fileDialog.FileName;
                FileNameLb.Content = $"File: {name} now start to play!";
                _player.Open(new Uri(filename));
            }
        }

        private void OpenFolderMI_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fileDialog = new FolderBrowserDialog();

            var fileDialogOk = fileDialog.ShowDialog();

            var filename = fileDialog.SelectedPath;

            DirectoryInfo dirInfo = new DirectoryInfo(filename);

            // таким образом мы можем получить файлы в директории
            FileInfo[] fileInfo = dirInfo.GetFiles("*.mp3");
            foreach (FileInfo f in fileInfo)
            {
                filesInfolders.Add(f);
            }

            FilesDG.Items.Refresh();
        }

        private void PlayBtn_Click(object sender, RoutedEventArgs e)
        {
            _player.Play();
        }

        private void StopBtn_Click(object sender, RoutedEventArgs e)
        {
            _player.Stop();
        }

        private void PauseBtn_Click(object sender, RoutedEventArgs e)
        {
            _player.Pause();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
