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

        int totalcompleted = 0;

        //Referances for colour (just to make things easier than typing out the full HEX number)
        SolidColorBrush completed = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ffebffe8"));
        SolidColorBrush todo = Brushes.White;
        SolidColorBrush wip = (SolidColorBrush)(new BrushConverter().ConvertFrom("#feffdd"));

        //Creates a new timer
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

        //Sets timer properties
        private void timersettings()
        {
            timer.IsEnabled = true;
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += OnTimerTick;
        }

        //Anything inside the timer tick event will be constantly checked / updated
        private void OnTimerTick(object sender, EventArgs e)
        {
            //Sets hour - minute - AM/PM
            Time_Update.Text = DateTime.Now.ToString("h:mm tt");
            Total_COMMISSIONs.Text = Convert.ToString(instances.compage.lstbox_commission.Items.Count);

            //Finds total cost of all commissions
            int totalcost = 0;
            for (int i = 0; i < instances.compage.lstbox_commission.Items.Count; i++)
            {
                totalcost = totalcost + Convert.ToInt32(((TodoItem)instances.compage.lstbox_commission.Items[i]).Cost.Trim(new Char[] { '$' }));

                if (((TodoItem)instances.compage.lstbox_commission.Items[i]).setcolour.ToString() == "#FFEBFFE8")
                {
                    totalcompleted += 1;
                }
            }

            Total_Earnings.Text = "$" + Convert.ToString(totalcost);

            Total_finished.Text = Convert.ToString(totalcompleted);

            Total_Unfinished.Text = Convert.ToString(instances.compage.lstbox_commission.Items.Count - totalcompleted);

            totalcompleted = 0;
        }
    }
}
