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
using System.Xml.Linq;

namespace MusicPlayerWpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayer _player;
        List<FileInfo> filesInfolders = new List<FileInfo>();

        public static RoutedCommand CloseCommand = new RoutedCommand();

        public MainWindow()
        {
            InitializeComponent();

            _player = new MediaPlayer();
            this.DataContext = this;
            FilesDG.ItemsSource = filesInfolders;
        }

        private void OpenFileMI_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3";
            if (openFileDialog.ShowDialog() == true)
            {
                ReadMP3File(openFileDialog.FileName);
                FileNameLb.Content = $"File: {openFileDialog.FileName} now start to play!";
                _player.Open(new Uri(openFileDialog.FileName));
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
            CloseWindow();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void MinimazieBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        public void CloseWindow()
        {
            this.Close();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Close");
        }

        // TagLibSharp NuGet Package
        private void ReadMP3File(string filePath)
        {
            var file = TagLib.File.Create(filePath);

            // Получение длины трека
            TimeSpan duration = file.Properties.Duration;

            // Получение артиста
            string artist = file.Tag.FirstAlbumArtist ?? file.Tag.FirstArtist ?? "Unknown Artist";

            // Получение названия трека
            string title = file.Tag.Title ?? "Unknown Title";

            // Получение обложки
            var pictures = file.Tag.Pictures;
            if (pictures.Length > 0)
            {
                var coverData = pictures[0].Data.Data;
                // Обработка обложки (например, показать в UI)
                // Для этого можно использовать coverData для создания изображения
            }

            // Вывод информации (можно и нужно адаптировать под ваш интерфейс)
            System.Windows.MessageBox.Show($"Title: {title}\nArtist: {artist}\nDuration: {duration}");
        }

        private void CloseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void CloseCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show($"Commits >= 3: 1 pont\nCustom disign: 1 point\nPlayer can play & work correctly: 2 point\nHot keys: 1 point\nLoad mp3 info & image: 1 point\n*Can choose track from folder: 1 point\n*Save new playlist: 1 point", 
                "Points total: 8 points", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
