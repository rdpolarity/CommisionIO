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
using System.Xml;
using static COMMISSION.io_WPF_add.MainWindow;
using MessageBox = System.Windows.Forms.MessageBox;

namespace COMMISSION.io_WPF_add
{
    //This page is pretty much the same as CommissionPage.xaml.cs!
    public partial class ContactPage : Page
    {
        public ContactPage()
        {
            InitializeComponent();
        }

        #region Variables
        //Referance for currently open instance of MainWindow.xaml
        MainWindow currentMainWindow = System.Windows.Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
        #endregion

        #region Index Sorting
        //Method for adjusting index of items within the list
        public void MoveItem(int direction)
        {
            // Checking selected item
            if (instances.conpage.lstbox_contacts.SelectedItem == null || instances.conpage.lstbox_contacts.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            int newIndex = instances.conpage.lstbox_contacts.SelectedIndex + direction;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= instances.conpage.lstbox_contacts.Items.Count)
                return; // Index out of range - nothing to do

            object selected = instances.conpage.lstbox_contacts.SelectedItem;

            // Removing removable element
            instances.compage.lstbox_commission.Items.Remove(selected);
            // Insert it in new position
            instances.compage.lstbox_commission.Items.Insert(newIndex, selected);
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
        #endregion

        #region XML Save/Load Methods
        public void savecontactxml()
        {
            XmlDocument XmlDocObj = new XmlDocument();
            XmlDocObj.Load(@"ContactData.xml");

            //Selects the node with the attribute ID='first'
            XmlNode node = XmlDocObj.SelectSingleNode("/Contact/entry[@ID='first']");

            // if found....
            if (node != null)
            {
                // get its parent node
                XmlNode parent = node.ParentNode;

                // remove the child node
                parent.RemoveChild(node);

                // verify the new XML structure
                string newXML = XmlDocObj.OuterXml;

                XmlDocObj.Save(@"ContactData.xml");
            }

            XmlNode RootNode = XmlDocObj.SelectSingleNode("Contact");

            XmlNode bookNode = RootNode.AppendChild(XmlDocObj.CreateNode(XmlNodeType.Element, "entry", ""));

            //Creates an attribute on the entry root node so that I can be selected / targeted
            XmlAttribute attr = XmlDocObj.CreateAttribute("ID");
            attr.Value = "first";

            for (int i = 0; i < instances.conpage.lstbox_contacts.Items.Count; i++)
            {
                bookNode.AppendChild(XmlDocObj.CreateNode(XmlNodeType.Element, "Title", "")).InnerText = ((TodoItem2)instances.conpage.lstbox_contacts.Items[i]).ContactTitle;
                bookNode.AppendChild(XmlDocObj.CreateNode(XmlNodeType.Element, "Email", "")).InnerText = ((TodoItem2)instances.conpage.lstbox_contacts.Items[i]).ContactEmail;
                bookNode.AppendChild(XmlDocObj.CreateNode(XmlNodeType.Element, "Phone", "")).InnerText = ((TodoItem2)instances.conpage.lstbox_contacts.Items[i]).ContactPhone;
                bookNode.AppendChild(XmlDocObj.CreateNode(XmlNodeType.Element, "DeviantArt", "")).InnerText = ((TodoItem2)instances.conpage.lstbox_contacts.Items[i]).ContactDeviantArt;
            }

            //Add the attribute to the node     
            bookNode.Attributes.SetNamedItem(attr);



            XmlDocObj.Save(@"ContactData.xml");
        }

        //Loads Commisions into Commision Listbox
        public void loadcontactxml()
        {
            XmlDocument XmlDocObj = new XmlDocument();
            XmlDocObj.Load(@"ContactData.xml");


            XmlNodeList xmlTitle = XmlDocObj.GetElementsByTagName("Title");
            XmlNodeList xmlEmail = XmlDocObj.GetElementsByTagName("Email");
            XmlNodeList xmlPhone = XmlDocObj.GetElementsByTagName("Phone");
            XmlNodeList xmlDeviantArt = XmlDocObj.GetElementsByTagName("DeviantArt");


            for (int i = 0; i < xmlTitle.Count; i++)
            {
                instances.conpage.lstbox_contacts.Items.Add(new TodoItem2()
                {
                    ContactTitle = xmlTitle[i].InnerXml,
                    ContactEmail = xmlEmail[i].InnerXml,
                    ContactPhone = xmlPhone[i].InnerXml,
                    ContactDeviantArt = xmlDeviantArt[i].InnerXml,
                    contactimagepath = @"Resources\Profile_Unknown.png"
                });
                currentMainWindow.COMMISSION_Client.Items.Add(xmlTitle[i].InnerXml);
            }
        }
        #endregion

        //Allows use of the scroll wheel or mouse 3
        private void moveplease(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        //This makes sure that the item is selected
        //So when the index is referenced, it referances the intended commission item index
        private void ItemOnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            instances.conpage.lstbox_contacts.UnselectAll();
            ((ListBoxItem)sender).IsSelected = true;

        }


        private void contact_proflie_open_Click(object sender, RoutedEventArgs e)
        {
            var index = instances.conpage.lstbox_contacts.Items.IndexOf(instances.conpage.lstbox_contacts.SelectedItem);

            contact_edit_title.Text = ((MainWindow.TodoItem2) instances.conpage.lstbox_contacts.Items[index]).ContactTitle;
            contact_edit_email.Text = ((MainWindow.TodoItem2)instances.conpage.lstbox_contacts.Items[index]).ContactEmail;
            contact_edit_phone.Text = ((MainWindow.TodoItem2)instances.conpage.lstbox_contacts.Items[index]).ContactPhone;
            string shorten = ((MainWindow.TodoItem2) instances.conpage.lstbox_contacts.Items[index]).ContactDeviantArt;
            contact_edit_deviantart.Text = shorten;
        }

        private void contact_delete(object sender, RoutedEventArgs e)
        {
            var index = instances.conpage.lstbox_contacts.Items.IndexOf(instances.conpage.lstbox_contacts.SelectedItem);
            string removetitle = ((MainWindow.TodoItem2)instances.conpage.lstbox_contacts.Items[index]).ContactTitle;
            currentMainWindow.COMMISSION_Client.Items.Remove(removetitle);

            while (instances.conpage.lstbox_contacts.SelectedItems.Count > 0)
            {
                instances.conpage.lstbox_contacts.Items.RemoveAt(index);
            }
        }

        

        private void edit_confirm_Click(object sender, RoutedEventArgs e)
        {
            int index = instances.conpage.lstbox_contacts.SelectedIndex;

            instances.conpage.lstbox_contacts.Items.RemoveAt(index);

            instances.conpage.lstbox_contacts.Items.Insert(index, new MainWindow.TodoItem2()
            {
                    ContactTitle = contact_edit_title.Text,
                    ContactEmail = contact_edit_email.Text,
                    ContactPhone = contact_edit_phone.Text,
                    ContactDeviantArt = contact_edit_deviantart.Text,
                    contactimagepath = @"Resources\Profile_Unknown.png"
            });


        }

        //Deviant Art button
        private void btn_deviantart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = instances.conpage.lstbox_contacts.SelectedIndex;
                string link = ((MainWindow.TodoItem2) instances.conpage.lstbox_contacts.Items[index]).ContactDeviantArt;
                System.Diagnostics.Process.Start("https://www.deviantart.com/" + link); //Opens up default browser from set link
            }
            catch
            {

            }
        }

        
    }
}
