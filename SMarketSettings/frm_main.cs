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
        Operator[] Operators;
        public string TempName, TempPwd;
        int z;

        public frm_main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.Enabled = true;
        }
        //Вызов формы комментариев чека
        private void btn_check_comment_Click(object sender, EventArgs e)
        {
            Form comment = new frm_check_comment();
            comment.Owner = this;
            comment.ShowDialog();
        }
        //Выход из программы
        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Вызов формы настроек
        private void btn_settings_Click(object sender, EventArgs e)
        {
            Form settings = new frm_settings();
            settings.ShowDialog();
        }
        //Загрузка настроек
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
            tabControl1.Enabled = true;
            tabControl1.SelectedIndex = 0;
        }
        //Выгрузка настроек
        private void btn_upload_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(@"\\" + current_pos + @"\POS\In"))
            {
                File.Move(Directory.GetCurrentDirectory() + "\\Settings\\" + current_pos + ".ini", @"\\" + current_pos + @"\POS\In\Settings.ini");
            }
            else
            {
                MessageBox.Show("Не могу выгрузить файл, возможно проблемы с соеинением" + 
                    "\n" + "или удаленный компьютер выключен", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );

            }
            current_pos = "";
            current_obj = "";
            btn_upload.Enabled = false;
            tabControl1.Enabled = false;
        }
        //Блокировка вкладок и загрузка данных по вкладкам
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1 || tabControl1.SelectedIndex == 3 || tabControl1.SelectedIndex == 4)
            {
                tabControl1.SelectedIndex = 0;
            }
            if (tabControl1.SelectedIndex == 2)
            {
                IniFile settings = new IniFile(Directory.GetCurrentDirectory() + "\\settings\\" + current_pos + ".ini");
                Operators = OperatorsControl.LoadOperators(current_pos);
                cb_name.Items.Clear();
                for (int i = 0; i < Operators.Length; i++)
                {
                    if (!Operators[i].ForDelete)
                    {
                        cb_name.Items.Add(Operators[i].Name);
                    }
                    else
                    {
                        cb_name.Items.Add(Operators[i].Name + " - ForDelete");
                    }
                }
                chk_once_operator.Checked = bool.Parse(settings.IniReadValue("operators", "UseOnceOperator"));
                cb_name.SelectedIndex = 0;
            }
        }
        //Выбор оператора
        private void cb_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            z = cb_name.SelectedIndex;
            if (Operators[z].Name == "Администратор")
            {
                btn_del_operator.Enabled = false;
            }
            else
            {
                btn_del_operator.Enabled = true;
            }
            
            if (Operators[cb_name.SelectedIndex].Password == "")
            {
                btn_cancel_pwd.Text = "Создать пароль";
            }
            else
            {
                btn_cancel_pwd.Text = "Отменить пароль";
            }
            tb_number.Text = Operators[z].ID.ToString();
            tb_cpwd.Text = Operators[z].CashPwd;
            chk_notactive.Checked = Operators[z].NotActive;
        }
        //Создать оператора
        private void btn_newOp_Click(object sender, EventArgs e)
        {
            Form NewOp = new frm_newoperator();
            NewOp.Owner = this;
            NewOp.ShowDialog();
            if (NewOp.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                Operators = OperatorsControl.addOperator(Operators, TempName, TempPwd);
                Operators[Operators.Length - 1].New = true;
                cb_name.Items.Clear();
                for (int i = 0; i < Operators.Length; i++)
                {
                    if (!Operators[i].ForDelete)
                    {
                        cb_name.Items.Add(Operators[i].Name);
                    }
                    else
                    {
                        cb_name.Items.Add(Operators[i].Name + " - ForDelete");
                    }
                }
                cb_name.SelectedIndex = 0;
            }
        }
        //Удаление оператора
        private void btn_del_operator_Click(object sender, EventArgs e)
        {
            Operators[z].ForDelete = true;
            cb_name.Items.Clear();
            for (int i = 0; i < Operators.Length; i++)
            {
                if (!Operators[i].ForDelete)
                {
                    cb_name.Items.Add(Operators[i].Name);
                }
                else
                {
                    cb_name.Items.Add(Operators[i].Name + " - ForDelete");
                }
            }
            cb_name.SelectedIndex = z;
        }
        //Удаление пароля оператора
        private void btn_cancel_pwd_Click(object sender, EventArgs e)
        {
            if (Operators[z].Password != "")
            {
                Operators[z].Password = "";
                btn_cancel_pwd.Text = "Создать пароль";
            }
            else
            {
                Form setpwd = new frm_setPassword();
                setpwd.Owner = this;
                setpwd.ShowDialog();
                if (setpwd.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    Operators[z].Password = TempPwd;
                    if (TempPwd != "")
                    {
                        btn_cancel_pwd.Text = "Отменить пароль";
                    }
                }
            }
        }
        //Применение настроек
        private void btn_apply_Click(object sender, EventArgs e)
        {
            IniFile settings = new IniFile(Directory.GetCurrentDirectory() + "\\settings\\" + current_pos + ".ini");
            if (tabControl1.SelectedIndex == 2)
            {
                settings.IniWriteValue("operators", "UseOnceOperator", chk_once_operator.Checked.ToString());
                OperatorsControl.SaveOperators(current_pos, Operators);
            }
        }
    }
}
