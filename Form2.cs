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

namespace Authentication
{
    public partial class Form2 : Form
    {
        SqlConnection con;
        public Form2()
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Authentication\Authentication\Database1.mdf;Integrated Security=True");
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO [user] ([FullName],[UserName],[Password]) VALUES (@fullname,@username,@password)",con);
            cmd.Parameters.AddWithValue("@fullname", textBox1.Text);
            cmd.Parameters.AddWithValue("@username",textBox2.Text);
            cmd.Parameters.AddWithValue("@password",textBox3.Text);

            con.Open();

            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Record inserted ");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                this.Close();
                Form1 f1 = new Form1();
                f1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
            con.Close();
        }
    }
}
