using System;
using System.Linq;
using System.Windows.Forms;

namespace PendafaranDesktop
{
    public partial class Form2 : Form
    {
        private DataClasses1DataContext db;
        private Utilities utils;
        public Form2()
        {
            InitializeComponent();
            this.utils = new Utilities();
            this.db = new DataClasses1DataContext();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pendaftaranDataSet.User' table. You can move, or remove it, as needed.
            //this.userTableAdapter.Fill(this.userTableAdapter.GetDataByStatusNull());
            get();
        }

        public void get()
        {
            var maskapai = db.Users.Where(item => item.status == null);
            userDataGridView.DataSource = null; // Unbind the DataGridView from its data source
            userDataGridView.Rows.Clear();
            userDataGridView.Refresh();

            foreach (var item in maskapai)
            {
                userDataGridView.Rows.Add(item.id, item.username, item.email);
            }
        }



        private void userDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = userDataGridView.Columns[e.ColumnIndex].Name;
            var id = userDataGridView.Rows[e.RowIndex].Cells[0].Value;
            utils.message("success", id.ToString());
            utils.message("success", name);
            var user = this.db.Users.FirstOrDefault(item => item.id == int.Parse(id.ToString()));

            if (name == "Column1")
            {
                try
                {
                    user.status = true;
                    db.SubmitChanges();
                    utils.message("success","Berhasil mengsetujui pendaftar");

                }catch(Exception ex)
                {
                    utils.message("error", ex.Message);
                }
            }

            if (name == "Column2")
            {
                try
                {
                    db.Users.DeleteOnSubmit(user);
                    db.SubmitChanges();
                    utils.message("success", "Berhasil menolak pendaftar");

                }
                catch (Exception ex)
                {
                    utils.message("error", ex.Message);
                }
            }
            get();
            //this.userTableAdapter.Fill(this.userTableAdapter.GetDataByStatusNull());
        }
    }
}
