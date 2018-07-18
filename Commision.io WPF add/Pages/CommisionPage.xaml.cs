using MaterialDesignThemes.Wpf;
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
using static Commision.io_WPF_add.MainWindow;

namespace Commision.io_WPF_add
{
    /// <summary>
    /// Interaction logic for CommisionPage.xaml
    /// </summary>
    public partial class CommisionPage : Page
    {
        public CommisionPage()
        {
            InitializeComponent();
        }

        private void moveplease(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void lbTodoList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void btn_reciet_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
