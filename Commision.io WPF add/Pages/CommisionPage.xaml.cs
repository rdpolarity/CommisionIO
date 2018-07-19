using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public string profiletitle { get; set; }
        public string profilename { get; set; }
        public string profilenote { get; set; }

        //SCROLLENABLE

        private void moveplease(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        //EVENTS

        public void lbTodoList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            addhost.IsOpen = true;

            int index = instances.compage.lbTodoList.SelectedIndex;

            string titleget = ((TodoItem)instances.compage.lbTodoList.Items[index]).Title;
            string clientget = ((TodoItem)instances.compage.lbTodoList.Items[index]).Client;
            string noteget = ((TodoItem)instances.compage.lbTodoList.Items[index]).Notes;

            Profile_Title.Text = titleget;
            Profile_Name.Text = clientget;
            Profile_Notes.Text = noteget;


        }

        private void btn_reciet_Click(object sender, RoutedEventArgs e)
        {

        }



        private void Client_Profile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lbTodoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void btn_edit_Checked(object sender, RoutedEventArgs e)
        {
            Profile_Name.IsEnabled = true;

            Profile_Title.IsEnabled = true;

            Profile_Notes.IsEnabled = true;
        }

        private void btn_edit_Unchecked(object sender, RoutedEventArgs e)
        {
            Profile_Name.IsEnabled = false;

            Profile_Title.IsEnabled = false;

            Profile_Notes.IsEnabled = false;
        }

        private void Accept_Edit_Click(object sender, RoutedEventArgs e)
        {
            int index = instances.compage.lbTodoList.SelectedIndex;

            instances.compage.lbTodoList.Items.RemoveAt(index);

            instances.compage.lbTodoList.Items.Insert(index, new TodoItem() {
                Title = Profile_Title.Text,
                Client = Profile_Name.Text,
                Notes = Profile_Notes.Text
            });
        }
    }
}
