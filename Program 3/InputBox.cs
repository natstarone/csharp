using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Program_3
{
    public partial class InputBox : Form
    {
        public InputBox()
        {
            InitializeComponent();
        }
        public String[] Items
        {
            get
            {
                return new String[]
                {
                    textBox1.Text,
                    textBox2.Text,
                    textBox3.Text
                };
            }
        }
        decimal x, y, z;
        private void button1_Click(object sender, EventArgs e)
        {

            x = Convert.ToDecimal(Items[0]);
            y = Convert.ToDecimal(Items[1]);
            z = Convert.ToDecimal(Items[2]);

            string l, m;

            if (x > 0 && y > 0 && z > 0)
            {
                l = "" + (x + y + z);

                l = string.Format("{0:f2}", x + y + z);
                MessageBox.Show("Sum: " + l);
            }
            else if (x < 0 || y < 0 || z < 0)
            {
                if (x > 0 && y > 0)
                {
                    m = "" + (x * y);
                    m = string.Format("{0:f2}", x * y);
                    MessageBox.Show("Product: " + m);
                }
                if (z > 0 && y > 0)
                {
                    m = "" + (z * y);
                    m = string.Format("{0:f2}", z * y);
                    MessageBox.Show("Product: " + m);
                }
                if (x > 0 && z > 0)
                {
                    m = "" + (x * z);
                    m = string.Format("{0:f2}", x * z);
                    MessageBox.Show("Product: " + m);
                }
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}

