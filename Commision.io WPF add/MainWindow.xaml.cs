using System;
using System.Windows;
using System.Windows.Input;
using System.Xml;
using Commision.io_WPF_add.Properties;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Windows.Media;
using Commision.io_WPF_add;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Media.Animation;

namespace Commision.io_WPF_add
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //time start
            SetTimerInterrupts();

            //loadxml();

            Add_Contact.Visibility = System.Windows.Visibility.Hidden;

            ApplyPrimary("Purple");
            ApplyAccent("Purple");

            Body.Content = instances.compage;

            //Settings.Default.LISTID = 0;
            //Settings.Default.Save();

            Swatches = new SwatchesProvider().Swatches;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            EnableBlur();

            com_instance.Content = instances.compage;
            con_instance.Content = instances.conpage;
            log_instance.Content = instances.logpage;
            set_instance.Content = instances.setpage;
        }

        internal enum AccentState
        {
            ACCENT_DISABLED = 0,
            ACCENT_ENABLE_GRADIENT = 1,
            ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
            ACCENT_ENABLE_BLURBEHIND = 3,
            ACCENT_ENABLE_ACRYLICBLURBEHIND = 4,
            ACCENT_INVALID_STATE = 5
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct AccentPolicy
        {
            public AccentState AccentState;
            public uint AccentFlags;
            public uint GradientColor;
            public uint AnimationId;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct WindowCompositionAttributeData
        {
            public WindowCompositionAttribute Attribute;
            public IntPtr Data;
            public int SizeOfData;
        }

        internal enum WindowCompositionAttribute
        {
            // ...
            WCA_ACCENT_POLICY = 19
            // ...
        }

        [DllImport("user32.dll")]
        internal static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        private uint _blurOpacity;
        public double BlurOpacity
        {
            get { return _blurOpacity; }
            set { _blurOpacity = (uint)value; EnableBlur(); }
        }

        private uint _blurBackgroundColor = 0x990000; /* BGR color format */

        internal void EnableBlur()
        {
            var windowHelper = new WindowInteropHelper(this);

            var accent = new AccentPolicy();
            accent.AccentState = AccentState.ACCENT_ENABLE_ACRYLICBLURBEHIND;
            accent.GradientColor = (_blurOpacity << 24) | (_blurBackgroundColor & 0xFFFFFF);

            var accentStructSize = Marshal.SizeOf(accent);

            var accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accent, accentPtr, false);

            var data = new WindowCompositionAttributeData();
            data.Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY;
            data.SizeOfData = accentStructSize;
            data.Data = accentPtr;

            SetWindowCompositionAttribute(windowHelper.Handle, ref data);

            Marshal.FreeHGlobal(accentPtr);
        }


        public ICommand ToggleBaseCommand { get; } = new AnotherCommandImplementation(o => ApplyBase((bool)o));

        private static void ApplyBase(bool isDark)
        {
            new PaletteHelper().SetLightDark(isDark);
        }

        public IEnumerable<Swatch> Swatches { get; }

        private static void ApplyPrimary(String swatch)
        {
            new PaletteHelper().ReplacePrimaryColor(swatch);
        }

        private static void ApplyAccent(String swatch)
        {
            new PaletteHelper().ReplaceAccentColor(swatch);
        }

        //saves the add commision form to xml
        public void savexml()
        {
            XmlDocument XmlDocObj = new XmlDocument();
            XmlDocObj.Load(@"C:\Users\admin\source\repos\Commision.io WPF add\Commision.io WPF add\CommisionData.xml");
            XmlNode RootNode = XmlDocObj.SelectSingleNode("Commisions");
            XmlNode bookNode = RootNode.AppendChild(XmlDocObj.CreateNode(XmlNodeType.Element, "entry", ""));

            Settings.Default.LISTID += 1;
            Properties.Settings.Default.Save();

            //Create a new attribute
            XmlAttribute attr = XmlDocObj.CreateAttribute("ID");
            attr.Value = Convert.ToString(Settings.Default.LISTID);

            //Add the attribute to the node     
            bookNode.Attributes.SetNamedItem(attr);

            bookNode.AppendChild(XmlDocObj.CreateNode(XmlNodeType.Element, "listID", "")).InnerText = Convert.ToString(Settings.Default.LISTID);
            bookNode.AppendChild(XmlDocObj.CreateNode(XmlNodeType.Element, "Title", "")).InnerText = title;
            bookNode.AppendChild(XmlDocObj.CreateNode(XmlNodeType.Element, "Cost", "")).InnerText = cost;
            bookNode.AppendChild(XmlDocObj.CreateNode(XmlNodeType.Element, "Client", "")).InnerText = client;
            bookNode.AppendChild(XmlDocObj.CreateNode(XmlNodeType.Element, "Deadline", "")).InnerText = deadline;

            XmlDocObj.Save(@"C:\Users\admin\source\repos\Commision.io WPF add\Commision.io WPF add\CommisionData.xml");
        }

        //loads all saved commisions in xml file
        public void loadxml()
        {
            XmlDocument XmlDocObj = new XmlDocument();
            XmlDocObj.Load(@"C:\Users\admin\source\repos\Commision.io WPF add\Commision.io WPF add\CommisionData.xml");


            XmlNodeList elemList = XmlDocObj.GetElementsByTagName("Title");
            XmlNodeList elemList2 = XmlDocObj.GetElementsByTagName("Cost");
            XmlNodeList elemList3 = XmlDocObj.GetElementsByTagName("Client");
            XmlNodeList elemList4 = XmlDocObj.GetElementsByTagName("Deadline");
            XmlNodeList elemList5 = XmlDocObj.GetElementsByTagName("listID");

            for (int i = 0; i < elemList.Count; i++)
            {
                title = (elemList[i].InnerXml);
                cost = (elemList2[i].InnerXml);
                client = (elemList3[i].InnerXml);
                deadline = (elemList4[i].InnerXml);
                Settings.Default.LISTID = Convert.ToInt32(elemList5[i].InnerXml);
                instances.compage.lbTodoList.Items.Add(new TodoItem() { BindedID = Convert.ToString(Settings.Default.LISTID), Title = title, Completion = 45, Cost = cost, Client = client, Deadline = deadline });
            }

            //title = Convert.ToString(XmlDocObj.SelectSingleNode("Commisions/entry/Title").InnerText);
            //cost = Convert.ToString(XmlDocObj.SelectSingleNode("Commisions/entry/Cost").InnerText);
            //client = Convert.ToString(XmlDocObj.SelectSingleNode("Commisions/entry/Client").InnerText);
            //deadline = Convert.ToString(XmlDocObj.SelectSingleNode("Commisions/entry/Deadline").InnerText);
        }

        //timer settings
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        private void SetTimerInterrupts()
        {
            timer.IsEnabled = true;
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += OnTimerTick;
        }

        //constant checker
        private void OnTimerTick(object sender, EventArgs e)
        {
            var var2 = instances.compage.lbTodoList.SelectedIndex;
            if (instances.compage.lbTodoList.SelectedItems.Count > 0)
            {
                var2 = instances.compage.lbTodoList.Items.IndexOf(instances.compage.lbTodoList.SelectedItems[0]);
                deleteID = Convert.ToString(var2);
                Console.WriteLine(var2);
            }

            //finds total and hides / shows help message

            int sum = instances.compage.lbTodoList.Items.Count;

            if (hidehelp == true)
            {
                help_box.Visibility = System.Windows.Visibility.Hidden;
            }

            else if (hidehelp == false)
            {
                help_box.Visibility = System.Windows.Visibility.Visible;
            }

            else if (sum == 0)
            {
                help_box.Visibility = Visibility.Visible;
            }
            if (sum > 0)
            {
                help_box.Visibility = Visibility.Hidden;
            }

            //If an item is selected then open edit box

            if (instances.compage.lbTodoList.SelectedItems.Count > 0)
            {
                editmode.IsActive = true;
            }
            if ((instances.compage.lbTodoList.SelectedItems.Count == 0))
            {
                editmode.IsActive = false;
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {

        }

        //ADDS A COMMISION
        private void Add_Commision_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void WindowBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void CLOSEBUTTON_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[0].Close();
        }

        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        private void Minamize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        public static string title;
        public static string cost;
        public static string client;
        public static string deadline;


        public static bool edit;

        public class TodoItem
        {
            public string Title { get; set; }
            public string Cost { get; set; }
            public string Client { get; set; }
            public string Deadline { get; set; }
            public int Completion { get; set; }
            public string BindedID { get; set; }
        }

        public class TodoItem2
        {
            public string ContactTitle { get; set; }
            public string ContactPhone { get; set; }
            public string ContactEmail { get; set; }
        }

        public static string contacttitle;
        public static string phonenumber;
        public static string email;


        public string deleteID;

        public void ADD_CONTACT_ACCEPT_BUTTON_Click(object sender, RoutedEventArgs e)
        {
            contacttitle = Client_Name.Text;
            phonenumber = Client_Phone.Text;
            email = Client_Email.Text;

            Commision_Client.Items.Add(contacttitle);

            if (contacttitle == "") { contacttitle= "?"; }
            if (phonenumber == "") { phonenumber = "?"; }
            if (email == "") { email = "?"; }

            instances.conpage.lbTodoList2.Items.Add(new TodoItem2() {ContactTitle = contacttitle, ContactEmail = email, ContactPhone = phonenumber});

            //savexml();
        }

        //Adds a commision to list and xml
        public void ADD_COMMISION_ACCEPT_BUTTON_Click(object sender, RoutedEventArgs e)
        {
            title = Commision_Title.Text;
            cost = "$" + Commision_Cost.Text;
            client = Commision_Client.Text;
            deadline = Commision_Deadline.Text;

            if (title == "") { title = "?"; }
            if (cost == "") { cost = "?"; }
            if (client == "") { client = "?"; }
            if (deadline == "") { deadline = "?"; }
          
            instances.compage.lbTodoList.Items.Add(new TodoItem() { Title = title, Completion = 45, Cost = cost, Client = client, Deadline = deadline });

            //savexml();
        }

        private void lbTodoList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        public string makeID()
        {
            string ID;
            Random x = new Random();
            ID = Convert.ToString(x.Next(1, 1000));
            return ID;
        }

        //Delete a selected item from list
        private void Commision_Delete_ActionClick(object sender, RoutedEventArgs e)
        {
            ////XML delete
            //XmlDocument XmlDocObj = new XmlDocument();
            //XmlDocObj.Load(@"C:\Users\admin\source\repos\Commision.io WPF add\Commision.io WPF add\CommisionData.xml");

            //XmlNode root = XmlDocObj.DocumentElement;

            //Settings.Default.LISTID -= 1;
            //Properties.Settings.Default.Save();

            //root.RemoveChild(XmlDocObj.SelectSingleNode("Commisions/entry[@ID='"+ deleteID +"']"));

            //list delete
            while (instances.compage.lbTodoList.SelectedItems.Count > 0)
            {
                var index = instances.compage.lbTodoList.Items.IndexOf(instances.compage.lbTodoList.SelectedItem);
                instances.compage.lbTodoList.Items.RemoveAt(index);
            }

            //XmlDocObj.Save(@"C:\Users\admin\source\repos\Commision.io WPF add\Commision.io WPF add\CommisionData.xml");
        }

        private void ADD_COMMISION_ACCEPT_BUTTON_Edit_Click(object sender, RoutedEventArgs e)
        {
            int index = instances.compage.lbTodoList.SelectedIndex;
            instances.compage.lbTodoList.Items.RemoveAt(index);

            title = Commision_Title_Edit.Text;
            cost = "$" + Commision_Cost_Edit.Text;
            client = Commision_Client_Edit.Text;
            deadline = Commision_Deadline_Edit.Text;

            instances.compage.lbTodoList.Items.Insert(index, new TodoItem() { Title = title, Completion = 45, Cost = cost, Client = client, Deadline = deadline });
        }

        private void lbTodoList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void cost_5_Click(object sender, RoutedEventArgs e)
        {
            Commision_Cost.Text = "5";
            Commision_Cost_Edit.Text = "5";
        }

        private void cost_25_Click(object sender, RoutedEventArgs e)
        {
            Commision_Cost.Text = "25";
            Commision_Cost_Edit.Text = "25";
        }

        private void cost_50_Click(object sender, RoutedEventArgs e)
        {
            Commision_Cost.Text = "50";
            Commision_Cost_Edit.Text = "50";
        }

        private void cost_75_Click(object sender, RoutedEventArgs e)
        {
            Commision_Cost.Text = "75";
            Commision_Cost_Edit.Text = "75";
        }

        private void cost_100_Click(object sender, RoutedEventArgs e)
        {
            Commision_Cost.Text = "100";
            Commision_Cost_Edit.Text = "100";
        }

        public static bool hidehelp = false;

        private void Commision_list_Click(object sender, RoutedEventArgs e)
        {
            hidehelp = false;
            Add_Commision.Visibility = System.Windows.Visibility.Visible;
            Add_Contact.Visibility = System.Windows.Visibility.Hidden;

            Body.Content = instances.compage;
        }

        private void Contact_list_Click(object sender, RoutedEventArgs e)
        {
            hidehelp = true;

            Add_Commision.Visibility = System.Windows.Visibility.Hidden;
            Add_Contact.Visibility = System.Windows.Visibility.Visible;

            Body.Content = instances.conpage;
        }

        private void Update_list_Click(object sender, RoutedEventArgs e)
        {
            hidehelp = true;

            Add_Commision.Visibility = System.Windows.Visibility.Hidden;
            Add_Contact.Visibility = System.Windows.Visibility.Hidden;

            Body.Content = instances.logpage;
        }

        private void tabheader_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tabItem = ((sender as TabControl).SelectedItem as TabItem).Header as string;
            string tabName = ((sender as TabControl).SelectedItem as TabItem).Name as string;
            switch (tabName)
            {
                case "setting":
                    hidehelp = true;
                    Add_Commision.Visibility = System.Windows.Visibility.Hidden;
                    Add_Contact.Visibility = System.Windows.Visibility.Hidden;
                    break;
            }
            switch (tabItem)
            {
                case "COMMISIONS":
                    hidehelp = false;
                    Add_Commision.Visibility = System.Windows.Visibility.Visible;
                    Add_Contact.Visibility = System.Windows.Visibility.Hidden;
                    break;

                case "CONTACTS":
                    hidehelp = true;
                    Add_Commision.Visibility = System.Windows.Visibility.Hidden;
                    Add_Contact.Visibility = System.Windows.Visibility.Visible;
                    break;

                case "UPDATELOG":
                    hidehelp = true;
                    Add_Commision.Visibility = System.Windows.Visibility.Hidden;
                    Add_Contact.Visibility = System.Windows.Visibility.Hidden;
                    break;

                default:
                    return;
            }
        }

        DoubleAnimation close = new DoubleAnimation(70, TimeSpan.FromSeconds(0.2));
        DoubleAnimation open = new DoubleAnimation(509.457, TimeSpan.FromSeconds(0.2));

        private void MenuToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            WindowSet.BeginAnimation(Window.HeightProperty, close);
        }



        private void MenuToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            WindowSet.BeginAnimation(Window.HeightProperty, open);
        }
    }
}
