using System;
using System.Windows;
using System.Windows.Input;
using System.Xml;
using COMMISSION.io_WPF_add.Properties;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Windows.Media;
using COMMISSION.io_WPF_add;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Media.Animation;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace COMMISSION.io_WPF_add
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            testermode = false;
            buildversion = 2.37;

            //time start
            SetTimerInterrupts();

            txt_warning.Visibility = Visibility.Hidden;

            //loadxml();

            Add_Contact.Visibility = System.Windows.Visibility.Hidden;

            ApplyPrimary("Orange");
            ApplyAccent("Orange");

            //Settings.Default.LISTID = 0;
            //Settings.Default.Save();

            Swatches = new SwatchesProvider().Swatches;
        }

        public bool testermode;
        public double buildversion;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            EnableBlur();

            if (testermode == true)
            {
                System.Windows.Forms.MessageBox.Show("Hello alpha tester! Thank you so much for helping me out! Just before you begin, please do not use the current build for anything work related as it's highly buggy and will not save any data on restart~");
            }

            if (testermode == true)
            {
                txt_tester.Text = "ALPHA TESTER BUILD v" + buildversion;
                txt_tester.Visibility = Visibility.Visible;
            }

            instances.compage.lbTodoList.Items.Add(new TodoItem() { Title = "[Full] Mei Mei", Cost = "$20", Client = "AydieMe", Deadline = "3/25/2016", Notes = "- Smol Blue Earth Pony", imagepath = @"E:\DESKTOP\Pictures\Mei Mei.png", outline = "red" });
            instances.compage.lbTodoList.Items.Add(new TodoItem() { Title = "[Full] Cloudy", Cost = "$15", Client = "OhHoneyBee", Deadline = "3/25/2016", Notes = "- Ver Smol BatPony", imagepath = @"E:\DESKTOP\Pictures\Cloudy.png", outline = "transparent"});



            hidehelp = true;

            Add_COMMISSION.Visibility = System.Windows.Visibility.Hidden;
            Add_Contact.Visibility = System.Windows.Visibility.Hidden;

            Body.Content = instances.hompage;

            com_instance.Content = instances.compage;
            con_instance.Content = instances.conpage;
            log_instance.Content = instances.logpage;
            set_instance.Content = instances.setpage;
            hom_instance.Content = instances.hompage;
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

        //saves the add COMMISSION form to xml
        public void savexml()
        {
            XmlDocument XmlDocObj = new XmlDocument();
            XmlDocObj.Load(@"C:\Users\admin\source\repos\COMMISSION.io WPF add\COMMISSION.io WPF add\COMMISSIONData.xml");
            XmlNode RootNode = XmlDocObj.SelectSingleNode("COMMISSIONs");
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

            XmlDocObj.Save(@"C:\Users\admin\source\repos\COMMISSION.io WPF add\COMMISSION.io WPF add\COMMISSIONData.xml");
        }

        //loads all saved COMMISSIONs in xml file
        public void loadxml()
        {
            XmlDocument XmlDocObj = new XmlDocument();
            XmlDocObj.Load(@"C:\Users\admin\source\repos\COMMISSION.io WPF add\COMMISSION.io WPF add\COMMISSIONData.xml");


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

            //title = Convert.ToString(XmlDocObj.SelectSingleNode("COMMISSIONs/entry/Title").InnerText);
            //cost = Convert.ToString(XmlDocObj.SelectSingleNode("COMMISSIONs/entry/Cost").InnerText);
            //client = Convert.ToString(XmlDocObj.SelectSingleNode("COMMISSIONs/entry/Client").InnerText);
            //deadline = Convert.ToString(XmlDocObj.SelectSingleNode("COMMISSIONs/entry/Deadline").InnerText);
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
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {

        }

        //ADDS A COMMISSION
        private void Add_COMMISSION_Click(object sender, RoutedEventArgs e)
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
            for (int intCounter = App.Current.Windows.Count - 1; intCounter >= 0; intCounter--)
                App.Current.Windows[intCounter].Close();
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
        public static string notes;


        public static bool edit;

        public class TodoItem
        {
            public string Title { get; set; }
            public string Cost { get; set; }
            public string Client { get; set; }
            public string Deadline { get; set; }
            public string Notes { get; set; }
            public int Completion { get; set; }
            public string BindedID { get; set; }
            public string imagepath { get; set; }
            public string outline { get; set; }
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

            COMMISSION_Client.Items.Add(contacttitle);

            if (contacttitle == "") { contacttitle= "?"; }
            if (phonenumber == "") { phonenumber = "?"; }
            if (email == "") { email = "?"; }

            instances.conpage.lbTodoList2.Items.Add(new TodoItem2() {ContactTitle = contacttitle, ContactEmail = email, ContactPhone = phonenumber});

            //savexml();
        }


        //Adds a COMMISSION to list and xml
        public void ADD_COMMISSION_ACCEPT_BUTTON_Click(object sender, RoutedEventArgs e)
        {
            title = COMMISSION_Title.Text;
            cost = "$" + COMMISSION_Cost.Text;
            client = COMMISSION_Client.Text;
            deadline = COMMISSION_Deadline.Text;
            notes = COMMISSION_Notes.Text;

            if (COMMISSION_Title.Text == "") { COMMISSION_Title.Foreground = Brushes.Red; }
            else if (COMMISSION_Title.Text != "") { COMMISSION_Title.Foreground = Brushes.Black; }

            if (COMMISSION_Cost.Text == "") { COMMISSION_Cost.Foreground = Brushes.Red; }
            else if (COMMISSION_Cost.Text != "") { COMMISSION_Cost.Foreground = Brushes.Black; }

            if (COMMISSION_Client.Text == "") { COMMISSION_Client.Foreground = Brushes.Red; ; }
            else if (COMMISSION_Client.Text != "") { COMMISSION_Client.Foreground = Brushes.Black; }

            if (COMMISSION_Deadline.Text == "") { COMMISSION_Deadline.Foreground = Brushes.Red; ; }
            else if (COMMISSION_Deadline.Text != "") { COMMISSION_Deadline.Foreground = Brushes.Black; }

            if (title != "")
            {
                if (cost != "")
                {
                    if (client != "")
                    {
                        if (deadline != "")
                        {
                            DialogHost.CloseDialogCommand.Execute(new object(), null);
                            instances.compage.lbTodoList.Items.Add(new TodoItem() { Title = title, Completion = 45, Cost = cost, Client = client, Deadline = deadline, Notes = notes, imagepath = op.FileName, outline = setoutlinecolour});
                            txt_warning.Visibility = Visibility.Hidden;
                            op.FileName = "";
                    }
                    }
                }
            }
            else
            {
                txt_warning.Visibility = Visibility.Visible;
            }

            //savexml();
        }

        public string setoutlinecolour;

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
        private void COMMISSION_Delete_ActionClick(object sender, RoutedEventArgs e)
        {
            ////XML delete
            //XmlDocument XmlDocObj = new XmlDocument();
            //XmlDocObj.Load(@"C:\Users\admin\source\repos\COMMISSION.io WPF add\COMMISSION.io WPF add\COMMISSIONData.xml");

            //XmlNode root = XmlDocObj.DocumentElement;

            //Settings.Default.LISTID -= 1;
            //Properties.Settings.Default.Save();

            //root.RemoveChild(XmlDocObj.SelectSingleNode("COMMISSIONs/entry[@ID='"+ deleteID +"']"));

            //list delete
            while (instances.compage.lbTodoList.SelectedItems.Count > 0)
            {
                var index = instances.compage.lbTodoList.Items.IndexOf(instances.compage.lbTodoList.SelectedItem);
                instances.compage.lbTodoList.Items.RemoveAt(index);
            }

            //XmlDocObj.Save(@"C:\Users\admin\source\repos\COMMISSION.io WPF add\COMMISSION.io WPF add\COMMISSIONData.xml");
        }


        private void cost_5_Click(object sender, RoutedEventArgs e)
        {
            COMMISSION_Cost.Text = "5";
        }

        private void cost_25_Click(object sender, RoutedEventArgs e)
        {
            COMMISSION_Cost.Text = "25";
        }

        private void cost_50_Click(object sender, RoutedEventArgs e)
        {
            COMMISSION_Cost.Text = "50";
        }

        private void cost_75_Click(object sender, RoutedEventArgs e)
        {
            COMMISSION_Cost.Text = "75";
        }

        private void cost_100_Click(object sender, RoutedEventArgs e)
        {
            COMMISSION_Cost.Text = "100";
        }

        public static bool hidehelp = false;

        private void tabheader_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tabItem = ((sender as System.Windows.Controls.TabControl).SelectedItem as TabItem).Header as string;
            string tabName = ((sender as System.Windows.Controls.TabControl).SelectedItem as TabItem).Name as string;
            switch (tabName)
            {
                case "setting":
                    hidehelp = true;
                    Add_COMMISSION.Visibility = System.Windows.Visibility.Hidden;
                    Add_Contact.Visibility = System.Windows.Visibility.Hidden;
                    break;
            }
            switch (tabItem)
            {
                case "COMMISSIONS":
                    hidehelp = false;
                    Add_COMMISSION.Visibility = System.Windows.Visibility.Visible;
                    Add_Contact.Visibility = System.Windows.Visibility.Hidden;
                    break;

                case "CONTACTS":
                    hidehelp = true;
                    Add_COMMISSION.Visibility = System.Windows.Visibility.Hidden;
                    Add_Contact.Visibility = System.Windows.Visibility.Visible;
                    break;

                case "UPDATELOG":
                    hidehelp = true;
                    Add_COMMISSION.Visibility = System.Windows.Visibility.Hidden;
                    Add_Contact.Visibility = System.Windows.Visibility.Hidden;
                    break;

                case "HOME":
                    hidehelp = true;
                    Add_COMMISSION.Visibility = System.Windows.Visibility.Hidden;
                    Add_Contact.Visibility = System.Windows.Visibility.Hidden;
                    break;

                default:
                    return;
            }
        }



        OpenFileDialog op = new OpenFileDialog();

        public void Ellipse_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                op.ShowDialog();
                op.Title = "Select a picture";
                op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                  "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                  "Portable Network Graphic (*.png)|*.png";

                var path = op.FileName;

                BitmapImage setimage = new BitmapImage(new Uri(op.FileName));

                ImageBrush newimage = new ImageBrush(setimage);

                newimage.Stretch = Stretch.UniformToFill;

                Profile_Picture.Fill = newimage;
            }
            catch { }
        }

        private void Com_Green_Click(object sender, RoutedEventArgs e)
        {
            setoutlinecolour = "green";
            Profile_Picture.Stroke = Brushes.Green;
        }

        private void Com_Clear_Click(object sender, RoutedEventArgs e)
        {
            setoutlinecolour = "Transparent";
            Profile_Picture.Stroke = Brushes.Transparent;
        }

        private void Com_Purple_Click(object sender, RoutedEventArgs e)
        {
            setoutlinecolour = "Purple";
            Profile_Picture.Stroke = Brushes.Purple;
        }

        private void Com_Yellow_Click(object sender, RoutedEventArgs e)
        {
            setoutlinecolour = "Yellow";
            Profile_Picture.Stroke = Brushes.Yellow;
        }

        private void Com_Orange_Click(object sender, RoutedEventArgs e)
        {
            setoutlinecolour = "Orange";
            Profile_Picture.Stroke = Brushes.Orange;
        }

        private void Com_Red_Click(object sender, RoutedEventArgs e)
        {
            setoutlinecolour = "Red";
            Profile_Picture.Stroke = Brushes.Red;
        }
    }
}
