using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ini;
using System.IO;

namespace SMarketSettings
{
    public partial class frm_check_comment : Form
    {
        public frm_check_comment()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_check_comment_Load(object sender, EventArgs e)
        {
            frm_main frm = (frm_main)this.Owner;
            IniFile settings = new IniFile(Directory.GetCurrentDirectory() + "\\Settings\\" + frm.current_pos + ".ini");
            tb_prefix1.Text = settings.IniReadValue("NFComments", "CheckPrefix1");
            tb_prefix2.Text = settings.IniReadValue("NFComments", "CheckPrefix2");
            tb_prefix3.Text = settings.IniReadValue("NFComments", "CheckPrefix3");
            tb_prefix4.Text = settings.IniReadValue("NFComments", "CheckPrefix4");
            tb_prefix5.Text = settings.IniReadValue("NFComments", "CheckPrefix5");
            tb_prefix6.Text = settings.IniReadValue("NFComments", "CheckPrefix6");
            tb_postfix1.Text = settings.IniReadValue("NFComments", "CheckPostfix1");
            tb_postfix2.Text = settings.IniReadValue("NFComments", "CheckPostfix2");
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            frm_main frm = (frm_main)this.Owner;
            IniFile settings = new IniFile(Directory.GetCurrentDirectory() + "\\Settings\\" + frm.current_pos + ".ini");
            settings.IniWriteValue("NFComments", "CheckPrefix1", tb_prefix1.Text);
            settings.IniWriteValue("NFComments", "CheckPrefix2", tb_prefix2.Text);
            settings.IniWriteValue("NFComments", "CheckPrefix3", tb_prefix3.Text);
            settings.IniWriteValue("NFComments", "CheckPrefix4", tb_prefix4.Text);
            settings.IniWriteValue("NFComments", "CheckPrefix5", tb_prefix5.Text);
            settings.IniWriteValue("NFComments", "CheckPrefix6", tb_prefix6.Text);
            settings.IniWriteValue("NFComments", "CheckPostfix1", tb_postfix1.Text);
            settings.IniWriteValue("NFComments", "CheckPostfix2", tb_postfix2.Text);
            this.Close();
        }
    }
}
