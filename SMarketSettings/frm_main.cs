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
    public partial class frm_main : Form
    {
        public string current_obj = "";
        public string current_pos = "10.0.20.253";

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
            comment.Owner = this;
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
                Form wait = new frm_wait();
                wait.Owner = this;
                wait.ShowDialog();
                if (wait.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    btn_upload.Enabled = true;
                }
            }
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(@"\\" + current_pos + @"\POS\In"))
            {
                File.Move(Directory.GetCurrentDirectory() + "\\Settings\\" + current_pos + ".ini", @"\\" + current_pos + @"\POS\In\Settings.ini");
                btn_upload.Enabled = false;
            }
            else
            {
                MessageBox.Show("Не могу выгрузить файл, возможно проблемы с соеинением" + 
                    "\n" + "или удаленный компьютер выключен", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );

            }
            current_pos = "";
            current_obj = "";
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1 || tabControl1.SelectedIndex == 3 || tabControl1.SelectedIndex == 4)
            {
                tabControl1.SelectedIndex = 0;
            }
        }
    }
}
