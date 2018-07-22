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
using static COMMISSION.io_WPF_add.MainWindow;

namespace COMMISSION.io_WPF_add
{
    /// <summary>
    /// Interaction logic for COMMISSIONPage.xaml
    /// </summary>
    public partial class COMMISSIONPage : Page
    {
        public COMMISSIONPage()
        {
            InitializeComponent();
        }

        public string profiletitle { get; set; }
        public string profilename { get; set; }
        public string profilenote { get; set; }
        public string backgroundimage { get; set; }

        //SCROLLENABLE

        private void moveplease(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        //EVENTS

        //Open COMMISSION Profile

        public void lbTodoList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            addhost.IsOpen = true;

            int index = instances.compage.lbTodoList.SelectedIndex;

            string titleget = ((TodoItem)instances.compage.lbTodoList.Items[index]).Title;
            string clientget = ((TodoItem)instances.compage.lbTodoList.Items[index]).Client;
            string noteget = ((TodoItem)instances.compage.lbTodoList.Items[index]).Notes;
            string setbackgroundimage = ((TodoItem)instances.compage.lbTodoList.Items[index]).imagepath;
            string costget = ((TodoItem)instances.compage.lbTodoList.Items[index]).Deadline;
            string deadlineget = ((TodoItem)instances.compage.lbTodoList.Items[index]).Cost;

            BitmapImage setimage = new BitmapImage(new Uri(setbackgroundimage));
            ImageBrush newimage = new ImageBrush(setimage);

            background_image.Source = setimage;
            Profile_Picture_Edit.Background = newimage;

            Profile_Title.Text = titleget;
            Profile_Name.Text = clientget;
            Profile_Notes.Text = noteget;
            Profile_Cost.Text = costget;
            Profile_Deadline.Text = deadlineget;


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

        //Profile Edit Toggle

        private void btn_edit_Checked(object sender, RoutedEventArgs e)
        {
            //Delete
            Profile_Delete.Visibility = Visibility.Visible;

            //Profile Picture
            Profile_Picture_Edit.IsEnabled = true;

            //Editable Fields
            Profile_Name.IsReadOnly = false;

            Profile_Title.IsReadOnly = false;

            Profile_Notes.IsReadOnly = false;

            Profile_Cost.IsReadOnly = false;

            Profile_Deadline.IsReadOnly = false;

        }

        private void btn_edit_Unchecked(object sender, RoutedEventArgs e)
        {
            //Delete
            Profile_Delete.Visibility = Visibility.Hidden;

            //Profile Picture
            Profile_Picture_Edit.IsEnabled = false;

            //Editable Fields
            Profile_Name.IsReadOnly = true;

            Profile_Title.IsReadOnly = true;

            Profile_Notes.IsReadOnly = true;

            Profile_Cost.IsReadOnly = true;

            Profile_Deadline.IsReadOnly = true;

        }

        //Profile Edit Confirm

        private void Accept_Edit_Click(object sender, RoutedEventArgs e)
        {
            int index = instances.compage.lbTodoList.SelectedIndex;

            instances.compage.lbTodoList.Items.RemoveAt(index);

            instances.compage.lbTodoList.Items.Insert(index, new TodoItem()
            {
                Title = Profile_Title.Text,
                Cost = "1",
                Client = Profile_Name.Text,
                Deadline = Profile_Deadline.Text,
                Notes = Profile_Deadline.Text,
                imagepath = @"E:\DESKTOP\Pictures\Cloudy.png",
                outline = "transparent"
            });
        }

        //Sorting Chips

        MaterialDesignThemes.Wpf.Chip addchip = new MaterialDesignThemes.Wpf.Chip();
        MaterialDesignThemes.Wpf.Chip addchip2 = new MaterialDesignThemes.Wpf.Chip();
        MaterialDesignThemes.Wpf.Chip addchip3 = new MaterialDesignThemes.Wpf.Chip();

        private void sort_fav_Click(object sender, RoutedEventArgs e)
        {
            sort_fav.IsEnabled = false;
            
            addchip.Background = Brushes.White;
            addchip.IsDeletable = true;
            addchip.DeleteClick += new RoutedEventHandler(sort_fav_delete);
            addchip.Margin = new Thickness(5,0,0,0);

            addchip.Content = "Faviorate";
            add_chip_panel.Children.Add(addchip);
        }

        private void sort_fav_delete(object sender, RoutedEventArgs e)
        {
            add_chip_panel.Children.Remove(addchip);
            sort_fav.IsEnabled = true;
        }

        private void sort_alpha_Click(object sender, RoutedEventArgs e)
        {
            sort_alpha.IsEnabled = false;

            addchip2.Background = Brushes.White;
            addchip2.IsDeletable = true;
            addchip2.DeleteClick += new RoutedEventHandler(sort_alpha_delete);
            addchip2.Margin = new Thickness(5, 0, 0, 0);

            addchip2.Content = "Alphabetically (A-Z)";
            add_chip_panel.Children.Add(addchip2);
        }

        private void sort_alpha_delete(object sender, RoutedEventArgs e)
        {
            add_chip_panel.Children.Remove(addchip2);
            sort_alpha.IsEnabled = true;
        }

        private void sort_date_Click(object sender, RoutedEventArgs e)
        {
            sort_date.IsEnabled = false;

            addchip3.Background = Brushes.White;
            addchip3.IsDeletable = true;
            addchip3.DeleteClick += new RoutedEventHandler(sort_date_delete);
            addchip3.Margin = new Thickness(5, 0, 0, 0);

            addchip3.Content = "Date (Latest)";
            add_chip_panel.Children.Add(addchip3);
        }

        private void sort_date_delete(object sender, RoutedEventArgs e)
        {
            add_chip_panel.Children.Remove(addchip3);
            sort_date.IsEnabled = true;
        }

        private void Profile_Delete_Click(object sender, RoutedEventArgs e)
        {
            while (instances.compage.lbTodoList.SelectedItems.Count > 0)
            {
                var index = instances.compage.lbTodoList.Items.IndexOf(instances.compage.lbTodoList.SelectedItem);
                instances.compage.lbTodoList.Items.RemoveAt(index);
            }
        }
    }
}
