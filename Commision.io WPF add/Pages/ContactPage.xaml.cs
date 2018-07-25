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
using MessageBox = System.Windows.Forms.MessageBox;

namespace COMMISSION.io_WPF_add
{
    /// <summary>
    /// Interaction logic for ContactPage.xaml
    /// </summary>
    public partial class ContactPage : Page
    {
        public ContactPage()
        {
            InitializeComponent();
        }

        private void moveplease(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void ItemOnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            instances.conpage.lbTodoList2.UnselectAll();
            ((ListBoxItem)sender).IsSelected = true;

        }

        private void contact_proflie_open_Click(object sender, RoutedEventArgs e)
        {
            var index = instances.conpage.lbTodoList2.Items.IndexOf(instances.conpage.lbTodoList2.SelectedItem);

            contact_edit_title.Text = ((MainWindow.TodoItem2) instances.conpage.lbTodoList2.Items[index]).ContactTitle;
            contact_edit_email.Text = ((MainWindow.TodoItem2)instances.conpage.lbTodoList2.Items[index]).ContactEmail;
            contact_edit_phone.Text = ((MainWindow.TodoItem2)instances.conpage.lbTodoList2.Items[index]).ContactPhone;
            string shorten = ((MainWindow.TodoItem2) instances.conpage.lbTodoList2.Items[index]).ContactDeviantArt;
            contact_edit_deviantart.Text = shorten;
        }

        MainWindow currentMainWindow = System.Windows.Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

        private void contact_delete(object sender, RoutedEventArgs e)
        {
            var index = instances.conpage.lbTodoList2.Items.IndexOf(instances.conpage.lbTodoList2.SelectedItem);
            string removetitle = ((MainWindow.TodoItem2)instances.conpage.lbTodoList2.Items[index]).ContactTitle;
            currentMainWindow.COMMISSION_Client.Items.Remove(removetitle);

            while (instances.conpage.lbTodoList2.SelectedItems.Count > 0)
            {
                instances.conpage.lbTodoList2.Items.RemoveAt(index);
            }
        }

        public void MoveItem(int direction)
        {
            // Checking selected item
            if (instances.conpage.lbTodoList2.SelectedItem == null || instances.conpage.lbTodoList2.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            int newIndex = instances.conpage.lbTodoList2.SelectedIndex + direction;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= instances.conpage.lbTodoList2.Items.Count)
                return; // Index out of range - nothing to do

            object selected = instances.conpage.lbTodoList2.SelectedItem;

            // Removing removable element
            instances.compage.lbTodoList.Items.Remove(selected);
            // Insert it in new position
            instances.compage.lbTodoList.Items.Insert(newIndex, selected);
            // Restore selection
        }

        private void moveup_Click(object sender, RoutedEventArgs e)
        {
            MoveItem(-1);
        }

        private void movedown_Click(object sender, RoutedEventArgs e)
        {
            MoveItem(1);
        }

        private void edit_confirm_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Edit_Picture_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void btn_deviantart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = instances.conpage.lbTodoList2.SelectedIndex;
                string link = ((MainWindow.TodoItem2) instances.conpage.lbTodoList2.Items[index]).ContactDeviantArt;
                System.Diagnostics.Process.Start("https://www.deviantart.com/" + link);
            }
            catch
            {

            }
        }
    }
}
