using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PendafaranDesktop
{
    internal class Utilities
    {

        public void Link(Form form, Panel panel)
        {
            panel.Controls.Clear();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            panel.Controls.Add(form);
            form.Show();
        }

        public DialogResult confirm(
           String message
       )
        {
            return MessageBox.Show(message, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public void message(String status, String message)
        {
            if (status is "success") MessageBox.Show(message, status, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (status is "error") MessageBox.Show(message, status, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


    }
}
