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
using System.Windows.Shapes;

namespace MusicPlayerWpf
{
    /// <summary>
    /// Логика взаимодействия для PianoWindow.xaml
    /// </summary>
    public partial class PianoWindow : Window
    {
        Random rnd = new Random();
        public PianoWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.Beep(rnd.Next(37, 1000), rnd.Next(37, 1000));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Console.Beep(rnd.Next(37, 1000), rnd.Next(37, 1000));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Console.Beep(rnd.Next(37, 1000), rnd.Next(37, 1000));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Console.Beep(rnd.Next(37, 1000), rnd.Next(37, 1000));
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Console.Beep(rnd.Next(37, 1000), rnd.Next(37, 1000));
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Console.Beep(rnd.Next(37, 1000), rnd.Next(37, 1000));
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Console.Beep(rnd.Next(37, 1000), rnd.Next(37, 1000));
        }
}
