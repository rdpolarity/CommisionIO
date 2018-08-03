using System;
using System.Windows;
using System.Windows.Input;
using System.Xml;
using COMMISSION.io_WPF_add.Properties;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Media;
using COMMISSION.io_WPF_add;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Media.Animation;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Linq;
using Control = System.Windows.Controls.Control;
using MessageBox = System.Windows.Forms.MessageBox;
using MySql.Data.MySqlClient;
using MaterialDesignColors;

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
            buildversion = 3.52;

            //time start
            SetTimerInterrupts();

            txt_warning.Visibility = Visibility.Hidden;

            Add_Contact.Visibility = System.Windows.Visibility.Hidden;

            ApplyPrimary("Orange");
            ApplyAccent("Orange");

            //Settings.Default.LISTID = 0;
            //Settings.Default.Save();

            Swatches = new SwatchesProvider().Swatches;
        }

        ContactPage currentContactWindow = System.Windows.Application.Current.Windows.OfType<ContactPage>().FirstOrDefault();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            EnableBlur();

            loadxml();

            instances.conpage.loadcontactxml();



            if (testermode == true)
            {
                System.Windows.Forms.MessageBox.Show("Warning! this is an alpha build, meaning bugs and faults could lead to loss of work, use at your own risk");
            }

            if (testermode == true)
            {
                txt_tester.Text = "ALPHA TEST BUILD v" + buildversion;
                txt_tester.Visibility = Visibility.Visible;
            }

            //instances.compage.lstbox_commission.Items.Add(new TodoItem() { Title = "[Full] Mei Mei", Cost = "$20", Client = "AydieMe", Deadline = "3/25/2016", Notes = "- AA", imagepath = @"E:\DESKTOP\PP.png", outline = "red", setcolour = todo});
            //instances.compage.lstbox_commission.Items.Add(new TodoItem() { Title = "[Full] Cloudy", Cost = "$15", Client = "FileZekk", Deadline = "3/25/2016", Notes = "- AAAAA", imagepath = @"E:\DESKTOP\1371414.jpg", outline = "transparent", setcolour = todo});

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

        #region Project Variables
        //Program Properties
        public bool testermode;
        public double buildversion; 

        //Commision Variables
        public static string title;
        public static string cost;
        public static string client;
        public static string deadline;
        public static string notes;
        public static bool edit;
        public string setoutlinecolour;

        //Commision List Class Variables
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
            public int setopenheight { get; set; }
            public SolidColorBrush setcolour { get; set; }
        }

        //Contact Variables
        public static string contacttitle;
        public static string phonenumber;
        public static string email;

        //Contact List Class Variables
        public class TodoItem2
        {
            public string ContactTitle { get; set; }
            public string ContactPhone { get; set; }
            public string ContactEmail { get; set; }
            public string ContactDeviantArt { get; set; }
            public string contactimagepath { get; set; }
        }

        //Find File Dialog
        OpenFileDialog op = new OpenFileDialog();

        //Help Message visibillity bool
        public static bool hidehelp = false;

        //New Brush Colour
        SolidColorBrush completed = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ebffe8"));
        SolidColorBrush todo = Brushes.White;
        SolidColorBrush wip = (SolidColorBrush)(new BrushConverter().ConvertFrom("#feffdd"));
        #endregion

        #region Windows 10 Background Blur
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
        #endregion

        #region Window Events
        //Detect when window is closing then save XML
        private void WindowSet_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            savexml();
            instances.conpage.savecontactxml();

            //saveMySQL();
        }

        //window drag / move
        private void WindowBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        //close window
        private void CLOSEBUTTON_Click(object sender, RoutedEventArgs e)
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter >= 0; intCounter--)
                App.Current.Windows[intCounter].Close();
        }

        //maximize window
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

        //minimize window
        private void Minamize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        #endregion

        #region Set Theme Methods
        public ICommand ToggleBaseCommand { get; } = new AnotherCommandImplementation(o => ApplyBase((bool)o));
        public IEnumerable<Swatch> Swatches { get; }

        private static void ApplyBase(bool isDark)
        {
            new PaletteHelper().SetLightDark(isDark);
        }

        private static void ApplyPrimary(String swatch)
        {
            new PaletteHelper().ReplacePrimaryColor(swatch);
        }

        private static void ApplyAccent(String swatch)
        {
            new PaletteHelper().ReplaceAccentColor(swatch);
        }
        #endregion

        #region XML Methods
        //Saves Commision to XML
        public void savexml()
        {
            XmlDocument XmlDocObj = new XmlDocument();
            XmlDocObj.Load(@"CommisionData.xml");

            XmlNode node = XmlDocObj.SelectSingleNode("/COMMISSIONs/entry[@ID='first']");

            // if found....
            if (node != null)
            {
                XmlNode parent = node.ParentNode;

                // remove the child node
                parent.RemoveChild(node);

                // verify the new XML structure
                string newXML = XmlDocObj.OuterXml;

                XmlDocObj.Save(@"CommisionData.xml");
            }

            XmlNode RootNode = XmlDocObj.SelectSingleNode("COMMISSIONs");

            XmlNode bookNode = RootNode.AppendChild(XmlDocObj.CreateNode(XmlNodeType.Element, "entry", ""));

            //Create a new attribute
            XmlAttribute attr = XmlDocObj.CreateAttribute("ID");
            attr.Value = "first";

            for (int i = 0; i < instances.compage.lstbox_commission.Items.Count; i++)
            {
                bookNode.AppendChild(XmlDocObj.CreateNode(XmlNodeType.Element, "Title", "")).InnerText = ((TodoItem)instances.compage.lstbox_commission.Items[i]).Title;
                bookNode.AppendChild(XmlDocObj.CreateNode(XmlNodeType.Element, "Cost", "")).InnerText = ((TodoItem)instances.compage.lstbox_commission.Items[i]).Cost;
                bookNode.AppendChild(XmlDocObj.CreateNode(XmlNodeType.Element, "Client", "")).InnerText = ((TodoItem)instances.compage.lstbox_commission.Items[i]).Client;
                bookNode.AppendChild(XmlDocObj.CreateNode(XmlNodeType.Element, "Deadline", "")).InnerText = ((TodoItem)instances.compage.lstbox_commission.Items[i]).Deadline;
                bookNode.AppendChild(XmlDocObj.CreateNode(XmlNodeType.Element, "Notes", "")).InnerText = ((TodoItem)instances.compage.lstbox_commission.Items[i]).Notes;
                bookNode.AppendChild(XmlDocObj.CreateNode(XmlNodeType.Element, "Imagepath", "")).InnerText = ((TodoItem)instances.compage.lstbox_commission.Items[i]).imagepath;
                bookNode.AppendChild(XmlDocObj.CreateNode(XmlNodeType.Element, "Outline", "")).InnerText = ((TodoItem)instances.compage.lstbox_commission.Items[i]).outline;
                bookNode.AppendChild(XmlDocObj.CreateNode(XmlNodeType.Element, "SetColour", "")).InnerText = ((TodoItem)instances.compage.lstbox_commission.Items[i]).setcolour.ToString();
            }

            //Add the attribute to the node     
            bookNode.Attributes.SetNamedItem(attr);



            XmlDocObj.Save(@"CommisionData.xml");
        }

        //Loads Commisions into Commision Listbox
        public void loadxml()
        {
            XmlDocument XmlDocObj = new XmlDocument();
            XmlDocObj.Load(@"CommisionData.xml");


            XmlNodeList xmlTitle = XmlDocObj.GetElementsByTagName("Title");
            XmlNodeList xmlCost = XmlDocObj.GetElementsByTagName("Cost");
            XmlNodeList xmlClient = XmlDocObj.GetElementsByTagName("Client");
            XmlNodeList xmlDeadline = XmlDocObj.GetElementsByTagName("Deadline");
            XmlNodeList xmlNotes = XmlDocObj.GetElementsByTagName("Notes");
            XmlNodeList xmlImagepath = XmlDocObj.GetElementsByTagName("Imagepath");
            XmlNodeList xmlOutline = XmlDocObj.GetElementsByTagName("Outline");
            XmlNodeList xmlSetColour = XmlDocObj.GetElementsByTagName("SetColour");

            for (int i = 0; i < xmlTitle.Count; i++)
            {
                instances.compage.lstbox_commission.Items.Add(new TodoItem()
                {
                    Title = xmlTitle[i].InnerXml,
                    Cost = xmlCost[i].InnerXml,
                    Client = xmlClient[i].InnerXml,
                    Deadline = xmlDeadline[i].InnerXml,
                    Notes = xmlNotes[i].InnerXml,
                    imagepath = xmlImagepath[i].InnerXml,
                    outline = xmlOutline[i].InnerXml,
                    setcolour = (SolidColorBrush)(new BrushConverter().ConvertFrom(xmlSetColour[i].InnerXml))
                });
            }

            //title = Convert.ToString(XmlDocObj.SelectSingleNode("COMMISSIONs/entry/Title").InnerText);
            //cost = Convert.ToString(XmlDocObj.SelectSingleNode("COMMISSIONs/entry/Cost").InnerText);
            //client = Convert.ToString(XmlDocObj.SelectSingleNode("COMMISSIONs/entry/Client").InnerText);
            //deadline = Convert.ToString(XmlDocObj.SelectSingleNode("COMMISSIONs/entry/Deadline").InnerText);
        }
        #endregion

        #region MySQL Methods

        MySqlConnection connection = new MySqlConnection("server=db4free.net;UID=rdpolarity2;PWD=eatme123;database=commisionws2;old guids=true");

        public void saveMySQL()
        {
            try
            {
                connection.Open();
                Console.WriteLine("[Connected!]");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Disconnected!] " + ex);
            }

            //Clear Table
            string ClearQuery = "TRUNCATE TABLE commisionws2.CommissionList;";

            MySqlCommand SendClearCommand = new MySqlCommand(ClearQuery, connection);
            SendClearCommand.ExecuteNonQuery();

            for (int i = 0; i < instances.compage.lstbox_commission.Items.Count; i++)
            {
                string Title = "ates";//((TodoItem)instances.compage.lstbox_commission.Items[i]).Title;
                int Cost = 3; //Convert.ToInt32(((TodoItem)instances.compage.lstbox_commission.Items[1]).Cost.Trim(new Char[] { '$' }));
                string Client = "dawd"; //((TodoItem)instances.compage.lstbox_commission.Items[1]).Client;
                string Deadline = "fewf"; //((TodoItem)instances.compage.lstbox_commission.Items[1]).Deadline;
                string Notes = "wefw"; //((TodoItem)instances.compage.lstbox_commission.Items[1]).Notes;
                string Setcolour = "awdasd"; //((TodoItem)instances.compage.lstbox_commission.Items[1]).setcolour.ToString();

                //Add to Table
                string AddQuery = "insert into commisionws2.CommissionList(Title,Cost,Client,Deadline,Notes,Setcolour) " + "values(" +
                    "'" + Title + "'," +
                    "'" + Cost + "'," +
                    "'" + Client + "'," +
                    "'" + Deadline + "'," +
                    "'" + Notes + "'," +
                    "'" + Setcolour + "');";

                MySqlCommand SendAddCommand = new MySqlCommand(AddQuery, connection);
                SendAddCommand.ExecuteNonQuery();

                Console.WriteLine("[Sent {0} Data!]",i);
            }
        }

        public void loadMySQL()
        {

        }

       #endregion

        #region Commision Add
        //Commision Add Cost button presets
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

        //Add Commision Profile Picture
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


        //Commision Dialog Host Accept
        public void ADD_COMMISSION_ACCEPT_BUTTON_Click(object sender, RoutedEventArgs e)
        {
            title = COMMISSION_Title.Text;
            cost = "$" + COMMISSION_Cost.Text;
            client = COMMISSION_Client.Text;
            deadline = COMMISSION_Deadline.Text;
            notes = COMMISSION_Notes.Text;

            if (COMMISSION_Title.Text == "") { COMMISSION_Title.Foreground = Brushes.Yellow; }
            else if (COMMISSION_Title.Text != "") { COMMISSION_Title.Foreground = Brushes.Black; }

            if (COMMISSION_Cost.Text == "") { COMMISSION_Cost.Foreground = Brushes.Red; }
            else if (COMMISSION_Cost.Text != "") { COMMISSION_Cost.Foreground = Brushes.Black; }

            if (COMMISSION_Client.Text == "") { COMMISSION_Client.Foreground = Brushes.Red; ; }
            else if (COMMISSION_Client.Text != "") { COMMISSION_Client.Foreground = Brushes.Black; }

            if (COMMISSION_Deadline.Text == "") { COMMISSION_Deadline.Foreground = Brushes.Red; ; }
            else if (COMMISSION_Deadline.Text != "") { COMMISSION_Deadline.Foreground = Brushes.Black; }

            if (op.FileName == "")
            {
                op.FileName = @"Resources\Profile_Unknown.png";
            }

            MessageBox.Show(op.FileName);

            if (title != "")
            {
                if (cost != "")
                {
                    if (client != "")
                    {
                        if (deadline != "")
                        {
                            DialogHost.CloseDialogCommand.Execute(new object(), null);
                            instances.compage.lstbox_commission.Items.Add(new TodoItem() { Title = title, Completion = 45, Cost = cost, Client = client, Deadline = deadline, Notes = notes, imagepath = op.FileName, outline = setoutlinecolour, setcolour = Brushes.White });
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

        //Commision DialogBox Reset/Clear values
        private void Add_COMMISSION_Click_1(object sender, RoutedEventArgs e)
        {
            sparkle.Opacity = 0;

            COMMISSION_Title.Text = null;
            COMMISSION_Cost.Text = null;
            COMMISSION_Client.Text = null;
            COMMISSION_Deadline.Text = null;
            COMMISSION_Notes.Text = null;

            //Profile_Picture.Fill = null;
            //SetValue(System.Windows.Controls.Control.BackgroundProperty, "SecondaryAccentBrush");
        }

        #endregion

        #region Edit Commision
        //INTEGER ONLY INPUT TEXTBOX
        private void edit_cost_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                Convert.ToInt32(e.Text);
            }
            catch
            {
                e.Handled = true;
            }
        }

        //Delete selected commision
        private void Profile_Delete_Click(object sender, RoutedEventArgs e)
        {
            while (instances.compage.lstbox_commission.SelectedItems.Count > 0)
            {
                var index = instances.compage.lstbox_commission.Items.IndexOf(instances.compage.lstbox_commission.SelectedItem);
                instances.compage.lstbox_commission.Items.RemoveAt(index);
            }

            profilehost.IsOpen = false;
        }

        //Profile image edit
        public void Edit_Picture_MouseUp(object sender, MouseButtonEventArgs e)
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

                Edit_Picture.Fill = newimage;
            }
            catch { }
        }

        //Commision Edit cost button presets
        private void editcost_5_Click(object sender, RoutedEventArgs e)
        {
            edit_cost.Text = "5";
        }
        private void editcost_25_Click(object sender, RoutedEventArgs e)
        {
            edit_cost.Text = "25";
        }
        private void editcost_50_Click(object sender, RoutedEventArgs e)
        {
            edit_cost.Text = "50";
        }
        private void editcost_75_Click(object sender, RoutedEventArgs e)
        {
            edit_cost.Text = "75";
        }
        private void editcost_100_Click(object sender, RoutedEventArgs e)
        {
            edit_cost.Text = "100";
        }

        //Set edit dialog as profile dialog 
        private void proflie_edit_Click(object sender, RoutedEventArgs e)
        {
            Edit_Picture.Fill = Host_Profile_Picture.Fill;
            edit_title.Text = Profile_Title.Text;
            edit_cost.Text = Profile_Cost.Text.Trim(new char[] { '$' });
            edit_deadline.Text = Profile_Deadline.Text;
            edit_client.Text = Profile_Name.Text;
            edit_notes.Text = Profile_Notes.Text;
        }

        //Set profile as edit dialog
        private void edit_confirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BitmapImage setimage = new BitmapImage(new Uri(op.FileName));
                ImageBrush newimage = new ImageBrush(setimage);

                Host_Profile_Picture.Fill = Edit_Picture.Fill;
                background_image.Source = setimage;
            }
            catch
            {

            }

            Profile_Title.Text = edit_title.Text;
            Profile_Cost.Text = "$" + edit_cost.Text;
            Profile_Deadline.Text = edit_deadline.Text;
            Profile_Name.Text = edit_client.Text;
            Profile_Notes.Text = edit_notes.Text;
        }

        //Confirm edited settings
        private void Accept_Edit_Click(object sender, RoutedEventArgs e)
        {
            int index = instances.compage.lstbox_commission.SelectedIndex;

            string imagereset = ((TodoItem)instances.compage.lstbox_commission.Items[index]).imagepath;



            if (op.FileName != "")
            {
                instances.compage.lstbox_commission.Items.Insert(index, new TodoItem()
                {
                    Title = Profile_Title.Text,
                    Cost = Profile_Cost.Text,
                    Client = Profile_Name.Text,
                    Deadline = Profile_Deadline.Text,
                    Notes = Profile_Notes.Text,
                    imagepath = op.FileName,
                    outline = "transparent",
                    setcolour = ((TodoItem)instances.compage.lstbox_commission.Items[index]).setcolour
                });
            }
            if (op.FileName == "")
            {
                instances.compage.lstbox_commission.Items.Insert(index, new TodoItem()
                {
                    Title = Profile_Title.Text,
                    Cost = Profile_Cost.Text,
                    Client = Profile_Name.Text,
                    Deadline = Profile_Deadline.Text,
                    Notes = Profile_Notes.Text,
                    imagepath = imagereset,
                    outline = "transparent",
                    setcolour = ((TodoItem)instances.compage.lstbox_commission.Items[index]).setcolour
                });
            }

            instances.compage.lstbox_commission.Items.RemoveAt(index + 1);

            op.FileName = "";
        }
        #endregion

        #region Timer
        //timer settings
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        private void SetTimerInterrupts()
        {
            timer.IsEnabled = true;
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += OnTimerTick;
        }

        //Helpbox Checker (TimerTick)
        private void OnTimerTick(object sender, EventArgs e)
        {
            //finds total and hides / shows help message

            int sum = instances.compage.lstbox_commission.Items.Count;

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
        #endregion

        #region Other Code


        //Contact Dialog Host Accept
        public void ADD_CONTACT_ACCEPT_BUTTON_Click(object sender, RoutedEventArgs e)
        {
            COMMISSION_Client.Items.Add(Client_Name.Text);

            if (Client_Name.Text == "") { Client_Name.Foreground = Brushes.Red; ; }
            else if (COMMISSION_Deadline.Text != "") { COMMISSION_Deadline.Foreground = Brushes.Black; }

            if (Client_Email.Text == "") { Client_Email.Text = "[Unknown]"; }
            if (Client_Phone.Text == "") { Client_Phone.Text = "[Unknown]"; }

            if (Client_Name.Text != "")
            {
                instances.conpage.lstbox_contacts.Items.Add(new TodoItem2()
                {
                    ContactTitle = Client_Name.Text,
                    ContactEmail = Client_Phone.Text,
                    ContactPhone = Client_Email.Text,
                    ContactDeviantArt = Client_DeviantArt.Text,
                    contactimagepath = @"Resources\Profile_Unknown.png"
            });
                DialogHost.CloseDialogCommand.Execute(new object(), null);
            }
        }

        //Menu Tab Properties
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
                    sparkle.Visibility = Visibility.Hidden;
                    break;
            }
            switch (tabItem)
            {
                case "COMMISSIONS":
                    hidehelp = false;
                    Add_COMMISSION.Visibility = System.Windows.Visibility.Visible;
                    Add_Contact.Visibility = System.Windows.Visibility.Hidden;
                    sparkle.Visibility = Visibility.Visible;
                    break;

                case "CONTACTS":
                    hidehelp = true;
                    Add_COMMISSION.Visibility = System.Windows.Visibility.Hidden;
                    Add_Contact.Visibility = System.Windows.Visibility.Visible;
                    sparkle.Visibility = Visibility.Hidden;
                    break;

                case "UPDATELOG":
                    hidehelp = true;
                    Add_COMMISSION.Visibility = System.Windows.Visibility.Hidden;
                    Add_Contact.Visibility = System.Windows.Visibility.Hidden;
                    sparkle.Visibility = Visibility.Hidden;
                    break;

                case "HOME":
                    hidehelp = true;
                    Add_COMMISSION.Visibility = System.Windows.Visibility.Hidden;
                    Add_Contact.Visibility = System.Windows.Visibility.Hidden;
                    sparkle.Visibility = Visibility.Hidden;
                    break;

                default:
                    return;
            }
        }







        //INTEGER ONLY INPUT TEXTBOX
        private void COMMISSION_Cost_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                Convert.ToInt32(e.Text);
            }
            catch
            {
                e.Handled = true;
            }
        }


        #endregion


        private void Close_Unselect_Click(object sender, RoutedEventArgs e)
        {
            instances.compage.lstbox_commission.UnselectAll();
        }

        private void Add_Contact_Click(object sender, RoutedEventArgs e)
        {
            Client_Name.Text = "";
            Client_Email.Text = "";
            Client_Phone.Text = "";
            Client_DeviantArt.Text = "";
        }
    }
}
