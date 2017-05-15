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





namespace Program_6

{



    public partial class Form1 : Form

    {



        SalaryEmployee[] employees = {

        new SalaryEmployee("Ram", 23, 23568),

        new SalaryEmployee("Joe", 25, 56989),

        new SalaryEmployee("Nat", 30, 89996),

        new SalaryEmployee("Sam", 35, 56889),

        new SalaryEmployee("Ann", 45, 235),



        };

        public Form1()

        {

            InitializeComponent();

        }

        protected override void OnPaint(PaintEventArgs e)

        {

            base.OnPaint(e);

            Graphics g = e.Graphics;

            Font fnt = new Font("MonoType Corsiva", 20.0f);

            g.DrawString("Name", fnt, Brushes.Black, 20, 20);

            g.DrawString("Age", fnt, Brushes.Black, 200, 20);

            g.DrawString("Income", fnt, Brushes.Black, 450, 20);





            for (int i = 0; i < employees.Length; i++)

            {

                g.DrawString(employees[i].Name, fnt, Brushes.Black, 20, 80 + i * fnt.Height);

                g.DrawString(employees[i].Age + "", fnt, Brushes.Black, 220, 80 + i * fnt.Height); // call string directly .ToString()



                var emp = employees[i] as SalaryEmployee;

                StringFormat sf = new StringFormat();

                sf.Alignment = StringAlignment.Far;





                g.DrawString(String.Format("{0:c0}", emp.Salary), fnt, Brushes.Black, 560, 80 + i * fnt.Height, sf); //employees[i].Salary







            }

        }





  #region

      
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

            InputBox inputBox = new InputBox();
            if (inputBox.ShowDialog() == DialogResult.OK)
            {

                // String s = input.Item;
                
               // String[] data = System.Text.RegularExpressions.Regex.Split(s.Trim(), @"\s+");

                // employees = new SalaryEmployee[data.Length / 3];

               // for (int i = 0; i < employees.Length; i++)

                   // employees[i] = new SalaryEmployee(data[3 * i], Convert.ToInt32(data[3 * i + 1]), Convert.ToDecimal(data[3 * i + 2]));

                Refresh();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}

#endregion