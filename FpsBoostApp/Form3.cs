using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace FpsBoostApp
{
    public partial class Form3 : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShopDatabase.accdb";
        private OleDbConnection myConnection;
        public Form3()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox1.Text);
            string ItemType = textBox2.Text;
            string Item = textBox3.Text;
            int Qty = Convert.ToInt32(textBox4.Text);
            int PricePerItem = Convert.ToInt32(textBox5.Text);
            string query = "INSERT INTO TblStock VALUES (" + kod + ",'" + ItemType + "','" + Item + "'," + Qty + "," + PricePerItem + ")";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("New product has been added.");
        }
    }
}
