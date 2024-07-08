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
    public partial class Form5 : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShopDatabase.accdb";
        private OleDbConnection myConnection;
        public Form5()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shopDatabaseDataSet.TblCustomers". При необходимости она может быть перемещена или удалена.
            this.tblCustomersTableAdapter.Fill(this.shopDatabaseDataSet.TblCustomers);

        }

        private void Form5_Activated(object sender, EventArgs e)
        {
            this.tblCustomersTableAdapter.Fill(this.shopDatabaseDataSet.TblCustomers);
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void byItemTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Owner = this;
            f6.Show();
        }
    }
}
