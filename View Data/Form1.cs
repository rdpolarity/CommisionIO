using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace View_Data
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(@"C:\Users\admin\source\repos\COMMISSION.io WPF add\COMMISSION.io WPF add\COMMISSIONData.xml");
            dataGridView1.DataSource = dataSet.Tables[0];
        }
    }
}
