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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Authentication
{
    public partial class Form3 : Form
    {

        SqlConnection con;
     
        public Form3()
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Authentication\Authentication\Database1.mdf;Integrated Security=True");
            InitializeComponent();
            //label1.Text = Form1.id.ToString();

            //SqlCommand cmd = new SqlCommand("SELECT [UserName] FROM [user] where [id]=@id", con);

            //cmd.Parameters.AddWithValue("@id", Form1.id);
            //con.Open();
            //SqlDataReader dr = cmd.ExecuteReader();

            //while (dr.Read())
            //{
            //    label1.Text = dr.GetString(0);
            //}
            //(above comment code is display individual data)
            Print();
        }
        public void Print()
        {
            SqlDataAdapter adpt = new SqlDataAdapter("SELECT* FROM [user]",con);

            DataTable dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;

            


        }

        
    }
}
