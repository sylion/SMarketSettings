using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ini;

namespace SMarketSettings
{
    public partial class frm_main : Form
    {
        public string current_obj = "";
        public string current_pos = "";

        public frm_main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_check_comment_Click(object sender, EventArgs e)
        {
            Form comment = new frm_check_comment();
            comment.ShowDialog();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            Form settings = new frm_settings();
            settings.ShowDialog();
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            Form load = new frm_load();
            load.Owner = this;
            load.ShowDialog();
            if (load.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                MessageBox.Show(current_obj + "\n" + current_pos);
            }
        }
    }
}
