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
    }
}
