using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 // System.Data is the root namespace for ADO.NET
using System.Data.OleDb; // for Access we
using System.Data.Common;
using System.Text.RegularExpressions;

namespace SQL_one
{
    public partial class Form1 : Form
    {
        DbCommand dbcmd;
        DbConnection dbconn;

        OleDbCommand cmd;
        OleDbConnection conn;
        
        public Form1()
        {
            InitializeComponent();

            // To send queries  you need a Connection Object
            // and a command Object
            OleDbConnectionStringBuilder strBuilder
                = new OleDbConnectionStringBuilder();

            // Provider = Mic

            strBuilder.Provider = "Microsoft.Jet.OLEDB.4.0";
            strBuilder.DataSource = @"T:\CSharp\nmo\db2.mdb";

            conn = new OleDbConnection(strBuilder.ConnectionString);

            cmd = new OleDbCommand("select * from worker", conn);
            

            treeView1.Nodes.Add(new TreeNode("db2.mdb"));


            conn.Open();
            DataTable dt = conn.GetSchema("Tables");
            conn.Close();

            foreach(DataRow dr in dt.Rows)
            {
                String tableName = dr["table_name"].ToString();
                if(char.IsLetter(tableName[0]) && dr ["table_type"].Equals("TABLE"))
                    treeView1.Nodes[0].Nodes.Add(tableName);
            }



            DataSet ds = new DataSet();

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            da.Fill(ds);



            dataGridView1.DataSource = ds; //ds
            dataGridView1.DataMember = ds.Tables[0].TableName;

            System.IO.StringWriter sw = new System.IO.StringWriter();
            ds.WriteXml(sw);
            MessageBox.Show(sw.ToString());

        }

        private void Run_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

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

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.SelectCommand = cmd;
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = ds.Tables[0].TableName;

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!treeView1.SelectedNode.Equals(treeView1.Nodes[0]))

            {
                String query = "Select * from " + treeView1.SelectedNode.Text;
                cmd.CommandText = query;
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();

                da.Fill(ds);
                
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = ds.Tables[0].TableName;


            }
        }
    }
}



// 52.
/*
class Part
{
    public String Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public Part(string name, int quantity, decimal price)
    {


        Name = name;
        Quantity = quantity;
        Price = price;
    }

    public Part() : this("", 0, 0) { } 

	public override string ToString()
    {
        return String.Format("Name:{0} Quan:{1} Price{2:c2}", Name, Quantity, Price);
    }
}

// 54.
class AutoPart : Part
{
    public String CarType { get; set; }
    public int Year { get; set; }
    public AutoPart(string name, int quantity, decimal price, string cartype, int year) : base(name, quantity, price)
    {
        CarType = cartype;
        Year = year;
    }
public AutoPart() : this("Chevy", 12, 32000, "Sedan", 1957)
{}
public override string ToString()
{
    return base.ToString() + String.Format("CarType:{0} Year:{1}", CarType, Year);
}
}

// 55.
class PartList
{
    List<Part> parts = new List<Part>();
    public int Count
    {
        get { return parts.Count;}
    }
    public Part this[int n]
    {
        get { return parts[n]; }
        set { parts[n] = value; }
    }
    public void Add(Part p)
    {
        parts.Add(p);
    }
    // for parse: asssume new data
    // for add: add data to the list
    public void parseData(String input)
    {
        parts.Clear();
        String[] data = Regex.Split(input.Trim(), @"\s+");
        for (int i = 0; i < data.Length; i += 3)
        {
            parts.Add(new Part(data[i],
                            Convert.ToInt32(data[i + 1]),
                            Convert.ToDecimal(data[i + 2]
                       )));
        }
    }
          public void addData(String input)
    {
        parts.Clear();
        String[] data = Regex.Split(input.Trim(), @"\s+");
        for (int i = 0; i < data.Length; i += 3)
        {
            parts.Add(new Part(data[i],
                            Convert.ToInt32(data[i + 1]),
                            Convert.ToDecimal(data[i + 2]
                       )));
        }

   }
        public void sortByName()
    {
        parts.Sort((e1, e2) => e1.Name.CompareTo(e2.Name));
    }
    public void sortByPrice()
    {
        parts.Sort((e1, e2) => e2.Price.CompareTo(e1.Price));
    }

}



    */






























