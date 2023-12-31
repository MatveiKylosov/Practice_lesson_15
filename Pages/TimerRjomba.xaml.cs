﻿using System;
using System.Collections;
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
    /// Логика взаимодействия для TimerRjomba.xaml
    /// </summary>
    public partial class TimerRjomba : Page
    {
        public DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public float full_second = 0;

        public TimerRjomba()
        {
            InitializeComponent();
            dispatcherTimer.Tick += TimerSecond;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
        }

        private void TimerSecond(object sender, EventArgs e)
        {
            full_second--;
            float hours = (int)(full_second / 60 / 60);
            float minuts = (int)(full_second / 60) - (hours * 60);
            float seconds = full_second - (hours * 60 * 60) - (minuts * 60);

            string s_seconds = seconds.ToString();
            if (seconds < 0) s_seconds = "0" + seconds;

            string s_minuts = minuts.ToString();
            if (minuts < 0) s_minuts = "0" + minuts;

            string s_hours = hours.ToString();
            if (hours < 0) s_hours = "0" + hours;

            time.Content = s_hours + ":" + s_minuts + ":" + s_seconds;


            if (full_second == 0)
            {
                dispatcherTimer.Stop();
                BTT.Content = "Старт";
            }
        }

        private void StartStopTimer(object sender, RoutedEventArgs e)
        {
            int[] time = new int[3];
            if (BTT.Content.ToString() == "Старт" & 
                int.TryParse(TimerTime.Text.Split(':')[0], out time[0]) &
                int.TryParse(TimerTime.Text.Split(':')[1], out time[1]) &
                int.TryParse(TimerTime.Text.Split(':')[2], out time[2]))
            {
                full_second = time[2] + time[1] * 60 + time[0] * 60 * 60 + 1;

                dispatcherTimer.Start();
                BTT.Content = $"Стоп";
            }
            else if (BTT.Content.ToString() == "Стоп")
            {
                BTT.Content = $"Старт";
                dispatcherTimer.Stop();
            }
        }
    }
}
