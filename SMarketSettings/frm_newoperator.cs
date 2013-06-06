using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMarketSettings
{
    public partial class frm_newoperator : Form
    {
        public frm_newoperator()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            frm_main frm = (frm_main)this.Owner;
            if (tb_name.Text != "")
            {
                frm.TempName = tb_name.Text;
                frm.TempPwd = tb_pwd.Text;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Имя оператора не должно пыть пустым", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
