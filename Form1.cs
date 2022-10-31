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
    public partial class Form1 : Form
    {
        SqlConnection con;
        int i = 0;
        public static int id = 0;
        public Form1()
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Authentication\Authentication\Database1.mdf;Integrated Security=True");
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM [user] WHERE [UserName]=@username AND [Password]=@password", con);
            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            cmd.Parameters.AddWithValue("@password", textBox2.Text);
            con.Open();
            id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            if (id != 0)
            {
                Form3 f3 = new Form3();
                f3.ShowDialog();
            }
            else
            {
                MessageBox.Show("Username and Password are incorrect");
            }
        }
    }
}

