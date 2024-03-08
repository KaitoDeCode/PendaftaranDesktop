using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PendafaranDesktop
{
    public partial class Form1 : Form
    {
        private Utilities util = new Utilities();
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            util.Link(form, panel2);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form3 form = new Form3();
            util.Link(form, panel2);

        }
    }
}
