using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Windows.Forms;

namespace SQL_Server
{
    public partial class Form1 : Form
    {

        // Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30

        SqlConnection conn;
        SqlCommand cmd;
        public Form1()
        {
            InitializeComponent();

            var strBuilder = new SqlConnectionStringBuilder();
            strBuilder.DataSource = @"(LocalDB)\MSSQLLocalDB";
            strBuilder.AttachDBFilename = @"T:\CSHARP\NMO\SQL_ONE\SQL_SERVER\DATABASE1.MDF";
            strBuilder.IntegratedSecurity = true;
            strBuilder.ConnectTimeout = 30;
            
            conn = new SqlConnection(strBuilder.ConnectionString);
            

            cmd = new SqlCommand("Select * from People", conn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = ds.Tables[0].TableName;





        }

        private void Run_Click(object sender, EventArgs e)
        {
            String query = textBox1.Text.Trim();
            String oldquery = cmd.CommandText;
            cmd.CommandText = query;

            if (!query.ToLower().StartsWith("select")) // if it doesnt start with select its insert update or delete. 
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                query = oldquery;

                cmd.CommandText = oldquery;


            }
            //

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = ds.Tables[0].TableName;








        }
    }
}
