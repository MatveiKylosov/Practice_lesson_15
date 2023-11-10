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

namespace TimeLord_Кылосов
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            OpenPages(pages.stopwatch);
        }

        public enum pages { stopwatch, timer}

        public void OpenPages(pages _page)
        {
            Change.Content = $"{(_page == pages.stopwatch ? "Таймер" : "Секундомер")}";
            if (_page == pages.stopwatch) frame.Navigate(new Pages.Stopwatch());
            else frame.Navigate(new Pages.TimerRjomba());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenPages(frame.Content is Pages.Stopwatch ? pages.timer : pages.stopwatch );
        }
    }
}
