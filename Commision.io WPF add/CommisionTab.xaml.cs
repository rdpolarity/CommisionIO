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

namespace COMMISSION.io_WPF_add
{
    /// <summary>
    /// Interaction logic for COMMISSIONTab.xaml
    /// </summary>
    public partial class COMMISSIONTab : UserControl
    {
        

        public COMMISSIONTab()
        {
            InitializeComponent();


            COMMISSION_Client_Box.Text = MainWindow.client;
            COMMISSION_Title_Box.Text = MainWindow.title;
            COMMISSION_Date_Box.Text = MainWindow.deadline;
            COMMISSION_Cost.Text = "$" + MainWindow.cost;
        }

        private void Client_Profile_Checked(object sender, RoutedEventArgs e)
        {
            MainWindow.edit = true;
        }

        private void Client_Profile_Unchecked(object sender, RoutedEventArgs e)
        {
            MainWindow.edit = false;
        }
    }
}
