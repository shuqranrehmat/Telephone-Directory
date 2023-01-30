using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace TelephoneDirectory
{
    public partial class Phone : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-FRML8TL\\sqlexpress;Initial Catalog=phone;Integrated Security=True");
        public Phone()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox3.Text = "";
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "INSERT INTO phonetbl(FirstName, LastName, Phone_No, Email, Catagory) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully saved...!");
                Dispay();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
          
        }

       void Dispay()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from phonetbl",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["FirstName"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["LastName"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["Phone_No"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["Email"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["Catagory"].ToString();

            }
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
           textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
           textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
           textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
           comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

        }
        private void Phone_Load(object sender, EventArgs e)
        {
            Dispay();
        }
    
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "DELETE FROM phonetbl WHERE (Phone_No = '" + textBox3.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Deleted Successfully...!");
                Dispay();
            }catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "UPDATE phonetbl SET FirstName ='"+textBox1.Text+"' ,LastName='"+textBox2.Text+"' ,Email='"+textBox4.Text+"' ,Catagory='"+comboBox1.Text+"' WHERE(Phone_No = '" + textBox3.Text+"')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Updated Successfully...!");
                Dispay();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from phonetbl Where Phone_No like '%"+textBox5.Text+"%'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["FirstName"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["LastName"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["Phone_No"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["Email"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["Catagory"].ToString();

            }
        }
    }
}
