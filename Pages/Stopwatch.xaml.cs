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
using System.Windows.Threading;

namespace TimeLord_Кылосов.Pages
{
    /// <summary>
    /// Логика взаимодействия для Stopwatch.xaml
    /// </summary>
    public partial class Stopwatch : Page
    {
        public DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public float full_second = 0;
        public int crug = 0;
        public bool rezim = true;
        public Stopwatch()
        {
            InitializeComponent();
            dispatcherTimer.Tick += TimerSecond;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
        }

        private void TimerSecond(object sender, EventArgs e)
        {
            if(rezim)full_second++;
            else full_second--;

            float hours = (int)(full_second / 60 / 60);
            float minuts = (int)(full_second / 60) - (hours * 60);
            float seconds = full_second - (hours * 60 * 60) - (minuts * 60);

            string s_seconds = seconds.ToString();
            if(seconds < 0) s_seconds = "0" + seconds;

            string s_minuts = minuts.ToString();
            if (minuts < 0) s_minuts = "0" + minuts;

            string s_hours = hours.ToString();
            if (hours < 0) s_hours = "0" + hours;

            time.Content = s_hours + ":" + s_minuts + ":" + s_seconds;

            if (!rezim & time.Content.ToString() == "0:0:0")
                dispatcherTimer.Stop();
        }

        private void StartStopwatch(object sender, RoutedEventArgs e)
        {
            if (start.Content.ToString() == "Начать" & !(BTT.Content.ToString() == "Таймер стоп"))
            {
                crug = 0;
                full_second = 0;
                start.Content = "Стоп";

                CheckView.Items.Clear();
                dispatcherTimer.Start();
            }
            else if(start.Content.ToString() == "Стоп")
            {
                crug = 0;
                full_second = 0;
                start.Content = "Начать";

                dispatcherTimer.Stop();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            crug++;
            CheckView.Items.Add($"Круг - {crug}, время {time.Content}");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(int.TryParse(TimerTime.Text, out int time) & !(start.Content.ToString() == "Стоп"))
            {
                CheckView.Items.Clear();
                full_second = time;
                dispatcherTimer.Start();

                BTT.Content = "Таймер стоп";
            }
            else if(BTT.Content.ToString() == "Таймер стоп")
            {
                dispatcherTimer.Stop();
            }
        }

    }
}
