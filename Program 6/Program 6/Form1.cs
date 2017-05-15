using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using People;
using System.Text.RegularExpressions;
using System.IO;

namespace Program_6
{

    public partial class Form1 : Form
    {
        /*{   
        SalaryEmployee[] employees = {
        new SalaryEmployee("Ram", 23, 23568),
        new SalaryEmployee("Joe", 25, 56989),
        new SalaryEmployee("Nat", 30, 89996),
        new SalaryEmployee("Sam", 35, 56889),
        new SalaryEmployee("Ann", 45, 235),
        
        };*/
        EmployeeList employees = new EmployeeList();


        public Form1()
        {
            InitializeComponent();
            employees.Add(new SalaryEmployee("Ram", 23, 23568));
            employees.Add(new SalaryEmployee("Sam", 73, 23968));
            employees.Add(new HourlyEmployee("Dan", 63, 235, 50));
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Font fnt = new Font("MonoType Corsiva", 42.0f);
            g.DrawString("Name", fnt, Brushes.Black, 20, 20);
            g.DrawString("Age", fnt, Brushes.Black, 200, 20);
            g.DrawString("Income", fnt, Brushes.Black, 400, 20);


            for (int i = 0; i < employees.Length; i++)
            {
                g.DrawString(employees[i].Name, fnt, Brushes.Black, 20, 80 + i * fnt.Height);
                g.DrawString(employees[i].Age + "", fnt, Brushes.Black, 220, 80 + i * fnt.Height); // call string directly .ToString()

                //var emp = employees[i] as SalaryEmployee;



                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Far;


                g.DrawString(String.Format("{0:c0}", employees[i].GetIncome()), fnt, Brushes.Black, 560, 80 + i * fnt.Height, sf); //employees[i].Salary



            }
        }



        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputBox input = new InputBox();
            if (input.ShowDialog() == DialogResult.OK)
            { 
                String s = input.Item;
                employees.Clear();   
                employees.AddRange(s);



                // employees = new Employee[data.Length / 3];
                // for (int i = 0; i < employees.Length; i++)
                //    employees[i] = new SalaryEmployee(data[3 * i], Convert.ToInt32(data[3 * i + 1]), Convert.ToDecimal(data[3 * i + 2]));
                Refresh();
        }
    }

    private void nameToolStripMenuItem_Click(object sender, EventArgs e)
    {
        employees.SortByName();
        Refresh();
    }

    private void ageToolStripMenuItem_Click(object sender, EventArgs e)
    {
        employees.SortByAge();
        Refresh();
    }

    private void incomeToolStripMenuItem_Click(object sender, EventArgs e)
    {
        employees.SortByIncome();
        Refresh();
    }
        




        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(ofd.FileName);
                fileName = ofd.FileName;
                String s = sr.ReadToEnd();
                sr.Close();
            employees.AddRange(s);
            Refresh();

            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sfd.FileName);
                sw.Write(employees.ToString());
                sw.Close();

            }

        }
        String fileName;
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName == null)
            { 
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                
                
                    fileName = sfd.FileName;
                }
                else return;
            }
            StreamWriter sw = new StreamWriter(fileName);
            sw.Write(employees.ToString());
            sw.Close();
        
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Program 6\nCopyright \u00a9 2017 RV", "About");
        }
    }
}
