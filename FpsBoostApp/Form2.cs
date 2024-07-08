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
    public partial class Form2 : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShopDatabase.accdb";
        private OleDbConnection myConnection;
        public Form2()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shopDatabaseDataSet.TblStock". При необходимости она может быть перемещена или удалена.
            this.tblStockTableAdapter.Fill(this.shopDatabaseDataSet.TblStock);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form f3 = new Form3();
            f3.Owner = this;
            f3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox1.Text);
            string query = "UPDATE TblStock SET Qty = '" + textBox2.Text + "' WHERE [StockID] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Product Qty has been changed.");
            this.tblStockTableAdapter.Fill(this.shopDatabaseDataSet.TblStock);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox1.Text);
            string query = "DELETE FROM TblStock WHERE [StockID] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Product data has been removed.");
            this.tblStockTableAdapter.Fill(this.shopDatabaseDataSet.TblStock);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void byItemTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Owner = this;
            f4.Show();
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            this.tblStockTableAdapter.Fill(this.shopDatabaseDataSet.TblStock);
        }
    }
}
