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
    public partial class frm_add : Form
    {
        public frm_add()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            frm_settings frm = (frm_settings)this.Owner;
            frm.tmp = tb_adres.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
