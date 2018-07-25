﻿using System;
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
using static COMMISSION.io_WPF_add.MainWindow;
using MessageBox = System.Windows.Forms.MessageBox;

namespace COMMISSION.io_WPF_add
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();

            timersettings();
        }

        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        private void timersettings()
        {
            timer.IsEnabled = true;
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += OnTimerTick;
        }

        private void OnTimerTick(object sender, EventArgs e)
        {

            Time_Update.Text = DateTime.Now.ToString("h:mm tt");
            Total_COMMISSIONs.Text = Convert.ToString(instances.compage.lbTodoList.Items.Count);

            int totalcost = 0;
            for (int i = 0; i < instances.compage.lbTodoList.Items.Count; i++)
            {
                totalcost = totalcost + Convert.ToInt32(((TodoItem)instances.compage.lbTodoList.Items[i]).Cost.Trim(new Char[] { '$' }));

                if (((TodoItem)instances.compage.lbTodoList.Items[i]).setcolour.ToString() == "#FFEBFFE8")
                {
                    totalcompleted += 1;
                }
            }

            Total_Earnings.Text = "$" + Convert.ToString(totalcost);

            Total_finished.Text = Convert.ToString(totalcompleted);

            Total_Unfinished.Text = Convert.ToString(instances.compage.lbTodoList.Items.Count - totalcompleted);

            totalcompleted = 0;
        }

        int totalcompleted = 0;

        SolidColorBrush completed = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ffebffe8"));
        SolidColorBrush todo = Brushes.White;
        SolidColorBrush wip = (SolidColorBrush)(new BrushConverter().ConvertFrom("#feffdd"));

    }
}
