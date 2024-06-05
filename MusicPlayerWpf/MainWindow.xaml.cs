using Microsoft.Win32;
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

namespace MusicPlayerWpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayer _player;
        public MainWindow()
        {
            InitializeComponent();

            _player = new MediaPlayer();
        }

        private void OpenFileMI_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
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
    }
}
