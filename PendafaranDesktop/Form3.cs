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
    public partial class Form3 : Form
    {
        private DataClasses1DataContext db;
        public Form3()
        {
            db = new DataClasses1DataContext();
            InitializeComponent();
        }

        private void userBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.userBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.pendaftaranDataSet);

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pendaftaranDataSet.User' table. You can move, or remove it, as needed.
            //this.userTableAdapter.Fill(this.pendaftaranDataSet.User);
            get();
        }

        private void userDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void get()
        {
            var maskapai = db.Users.Where(item => item.status != null);
            userDataGridView.DataSource = null; // Unbind the DataGridView from its data source
            userDataGridView.Rows.Clear();
            userDataGridView.Refresh();

            foreach (var item in maskapai)
            {
                userDataGridView.Rows.Add(item.id, item.username, item.email,item.status);
            }
        }

    }
}
