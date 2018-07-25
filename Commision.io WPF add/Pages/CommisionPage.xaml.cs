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
using Microsoft.Win32;
using static COMMISSION.io_WPF_add.MainWindow;
using MessageBox = System.Windows.Forms.MessageBox;
using System.Windows.Interactivity;
using System.Windows.Controls.Primitives;

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
        public string setopenheight { get; set; }

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

        }

        private void btn_reciet_Click(object sender, RoutedEventArgs e)
        {
            int index = instances.compage.lbTodoList.SelectedIndex;
            title = ((TodoItem) instances.compage.lbTodoList.Items[index]).Title;
            client = ((TodoItem) instances.compage.lbTodoList.Items[index]).Client;
            cost = ((TodoItem)instances.compage.lbTodoList.Items[index]).Cost;

            get_receipt.Text = $"Thank you {client} for commisioning me! You've ordered \"{title}\" for a total cost of {cost}";
        }



        private void Client_Profile_Click(object sender, RoutedEventArgs e)
        {

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









        OpenFileDialog op = new OpenFileDialog();

        private void lbTodoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lbTodoList_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void lbTodoList_MouseLeave(object sender, MouseEventArgs e)
        {
        
        }

        MainWindow currentMainWindow = System.Windows.Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

       



        public void proflie_open_Click(object sender, RoutedEventArgs e)
        {
            currentMainWindow.profilehost.IsOpen = true;

            int index = instances.compage.lbTodoList.SelectedIndex;


            string titleget = ((TodoItem)instances.compage.lbTodoList.Items[index]).Title;
            string clientget = ((TodoItem)instances.compage.lbTodoList.Items[index]).Client;
            string noteget = ((TodoItem)instances.compage.lbTodoList.Items[index]).Notes;
            string setbackgroundimage = ((TodoItem)instances.compage.lbTodoList.Items[index]).imagepath;
            string costget = ((TodoItem)instances.compage.lbTodoList.Items[index]).Cost;
            string deadlineget = ((TodoItem)instances.compage.lbTodoList.Items[index]).Deadline;

            BitmapImage setimage = new BitmapImage(new Uri(setbackgroundimage));
            ImageBrush newimage = new ImageBrush(setimage);

            currentMainWindow.background_image.Source = setimage;
            currentMainWindow.Host_Profile_Picture.Fill = newimage;

            currentMainWindow.Profile_Title.Text = titleget;
            currentMainWindow.Profile_Name.Text = clientget;
            currentMainWindow.Profile_Notes.Text = noteget;
            currentMainWindow.Profile_Cost.Text = costget;
            currentMainWindow.Profile_Deadline.Text = deadlineget;
        }

        public void MoveItem(int direction)
        {
            // Checking selected item
            if (instances.compage.lbTodoList.SelectedItem == null || instances.compage.lbTodoList.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            int newIndex = instances.compage.lbTodoList.SelectedIndex + direction;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= instances.compage.lbTodoList.Items.Count)
                return; // Index out of range - nothing to do

            object selected = instances.compage.lbTodoList.SelectedItem;

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

        private void set_working_Click(object sender, RoutedEventArgs e)
        {
            int index = instances.compage.lbTodoList.SelectedIndex;

            instances.compage.lbTodoList.Items.Insert(index, new TodoItem()
            {
                Title = ((TodoItem)instances.compage.lbTodoList.Items[index]).Title,
                Cost = ((TodoItem)instances.compage.lbTodoList.Items[index]).Cost,
                Client = ((TodoItem)instances.compage.lbTodoList.Items[index]).Client,
                Deadline = ((TodoItem)instances.compage.lbTodoList.Items[index]).Deadline,
                Notes = ((TodoItem)instances.compage.lbTodoList.Items[index]).Notes,
                imagepath = ((TodoItem)instances.compage.lbTodoList.Items[index]).imagepath,
                outline = "transparent",
                setcolour = (SolidColorBrush)(new BrushConverter().ConvertFrom("#feffdd"))
            });

            instances.compage.lbTodoList.Items.RemoveAt(index + 1);
        }

        private void set_complete_Click(object sender, RoutedEventArgs e)
        {
            int index = instances.compage.lbTodoList.SelectedIndex;

            instances.compage.lbTodoList.Items.Insert(index, new TodoItem()
            {
                Title = ((TodoItem)instances.compage.lbTodoList.Items[index]).Title,
                Cost = ((TodoItem)instances.compage.lbTodoList.Items[index]).Cost,
                Client = ((TodoItem)instances.compage.lbTodoList.Items[index]).Client,
                Deadline = ((TodoItem)instances.compage.lbTodoList.Items[index]).Deadline,
                Notes = ((TodoItem)instances.compage.lbTodoList.Items[index]).Notes,
                imagepath = ((TodoItem)instances.compage.lbTodoList.Items[index]).imagepath,
                outline = "transparent",
                setcolour = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ebffe8"))
            });

            instances.compage.lbTodoList.Items.RemoveAt(index + 1);
        }

        private void set_todo_Click(object sender, RoutedEventArgs e)
        {
            int index = instances.compage.lbTodoList.SelectedIndex;

            instances.compage.lbTodoList.Items.Insert(index, new TodoItem()
            {
                Title = ((TodoItem)instances.compage.lbTodoList.Items[index]).Title,
                Cost = ((TodoItem)instances.compage.lbTodoList.Items[index]).Cost,
                Client = ((TodoItem)instances.compage.lbTodoList.Items[index]).Client,
                Deadline = ((TodoItem)instances.compage.lbTodoList.Items[index]).Deadline,
                Notes = ((TodoItem)instances.compage.lbTodoList.Items[index]).Notes,
                imagepath = ((TodoItem)instances.compage.lbTodoList.Items[index]).imagepath,
                outline = "transparent",
                setcolour = Brushes.White
            });

            instances.compage.lbTodoList.Items.RemoveAt(index + 1);
        }

        private void ItemOnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            instances.compage.lbTodoList.UnselectAll();
            ((ListBoxItem)sender).IsSelected = true;
        }
    }
}
