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
        public string current_pos = "";
        Operator[] Operators;
        public string TempName, TempPwd;
        int z;
        int tmpMask, Mask;
        string SettingsVersion = "20130820";

        public frm_main()
        {
            InitializeComponent();
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
                if (File.Exists(Directory.GetCurrentDirectory() + "\\Settings\\" + current_pos + ".ini"))
                {
                    if (wait.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        btn_upload.Enabled = true;
                        btn_apply.Enabled = true;
                    }
                    tabControl1.Enabled = true;
                    tabControl1_SelectedIndexChanged(this, e);
                    this.Text = "Настройки SMarket - " + current_obj + " - " + current_pos;
                }
            }
        }
        //Выгрузка настроек
        private void btn_upload_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(@"\\" + current_pos + @"\POS\In"))
            {
                try
                {
                    File.Move(Directory.GetCurrentDirectory() + "\\Settings\\" + current_pos + ".ini", @"\\" + current_pos + @"\POS\In\Settings.ini");
                }
                catch
                {
                    if (MessageBox.Show("На терминал уже были отправлены настройки которые он еще не применил, заменить их новыми?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        File.Delete(@"\\" + current_pos + @"\POS\In\Settings.ini");
                        File.Move(Directory.GetCurrentDirectory() + "\\Settings\\" + current_pos + ".ini", @"\\" + current_pos + @"\POS\In\Settings.ini");
                    }

                }
            }
            else
            {
                MessageBox.Show("Не могу выгрузить файл, возможно проблемы с соеинением" +
                    "\n" + "или удаленный компьютер выключен", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            current_pos = "";
            current_obj = "";
            btn_upload.Enabled = false;
            btn_apply.Enabled = false;
            tabControl1.Enabled = false;
            this.Text = "Настройки SMarket";
        }
        //Блокировка вкладок и загрузка данных по вкладкам
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            IniFile settings = new IniFile(Directory.GetCurrentDirectory() + "\\settings\\" + current_pos + ".ini");
            if (settings.IniReadValue("default", "SettingsVersion") == SettingsVersion)
            {
                //Основные
                if (tabControl1.SelectedIndex == 1 || tabControl1.SelectedIndex == 3)
                {
                    tabControl1.SelectedIndex = 0;
                }
                //Основные
                if (tabControl1.SelectedIndex == 0)
                {
                    chkNotFiscal.Checked = bool.Parse(settings.IniReadValue("General", "flgNotFiscal"));
                    chkNewProt.Checked = bool.Parse(settings.IniReadValue("General", "NewProtEveryDay"));
                    chkRegCancel.Checked = bool.Parse(settings.IniReadValue("General", "flgRegCancel"));
                    edPathCommand.Text = settings.IniReadValue("General", "PathCommand");
                    edPathIn.Text = settings.IniReadValue("General", "PathIn");
                    edPathOut.Text = settings.IniReadValue("General", "PathOut");
                    edPathServer.Text = settings.IniReadValue("General", "PathServer");
                    chkNotDisplay.Checked = bool.Parse(settings.IniReadValue("General", "flgNotDisplay"));
                    chkFiscal.Checked = bool.Parse(settings.IniReadValue("General", "flgFiscal"));
                    chkAutoFiscal.Checked = bool.Parse(settings.IniReadValue("General", "AutoFiscal"));
                    edLogoY.Text = settings.IniReadValue("General", "logoY");
                    chkNoLimit.Checked = bool.Parse(settings.IniReadValue("General", "flgNoLimit"));
                    chkAnyQuality.Checked = bool.Parse(settings.IniReadValue("General", "flgAnyQuantity"));
                    chkMaxQuality.Checked = bool.Parse(settings.IniReadValue("General", "flgMaxQuantity"));
                    chkMaxSum.Checked = bool.Parse(settings.IniReadValue("General", "flgMaxSum"));
                    edMaxQuality.Text = settings.IniReadValue("General", "valMaxQuantity");
                    edMaxSum.Text = settings.IniReadValue("General", "valMaxSum");
                    edPollPeriod.Text = settings.IniReadValue("General", "valPollPeriod");
                    //Только для информации, не сохранять это:
                    cbDeviceType.Text = settings.IniReadValue("General", "DeviceType");
                    cbDeviceComport.Text = "COM" + settings.IniReadValue("General", "DeviceComPort");
                    cbPrinter.Text = settings.IniReadValue("General", "PrinterZebraName");
                    cbDrawerComport.Text = "COM" + settings.IniReadValue("General", "DrawerComPort");
                    edRep.Text = settings.IniReadValue("General", "valRep");
                }
                //Операторы
                if (tabControl1.SelectedIndex == 2)
                {
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
                    chk_magnet.Checked = bool.Parse(settings.IniReadValue("operators", "MagnetCode"));
                    chk_Otborka.Checked = bool.Parse(settings.IniReadValue("operators", "Otborka"));
                    cb_name.SelectedIndex = 0;
                }
                //Заказы
                if (tabControl1.SelectedIndex == 4)
                {
                    try
                    {
                        chk_orderisactive.Checked = bool.Parse(settings.IniReadValue("Restaurant", "order_isactive"));
                        tb_serveraddress.Text = settings.IniReadValue("Restaurant", "order_host");
                        tb_serverport.Text = settings.IniReadValue("Restaurant", "order_port");
                        tb_basename.Text = settings.IniReadValue("Restaurant", "order_bname");
                        tb_baselogin.Text = settings.IniReadValue("Restaurant", "order_login");
                        tb_basepwd.Text = settings.IniReadValue("Restaurant", "order_pwd");
                        tb_pingtimeout.Text = settings.IniReadValue("Restaurant", "ping_timeout");
                        chk_servicemode.Checked = bool.Parse(settings.IniReadValue("Restaurant", "servicemode"));
                        tb_precheckcommit1.Text = settings.IniReadValue("Restaurant", "precheck_coommit1");
                        tb_precheckcommit2.Text = settings.IniReadValue("Restaurant", "precheck_coommit2");
                        tb_precheckcommit3.Text = settings.IniReadValue("Restaurant", "precheck_coommit3");
                        tb_precheckcommit4.Text = settings.IniReadValue("Restaurant", "precheck_coommit4");
                        tb_precheckcommit5.Text = settings.IniReadValue("Restaurant", "precheck_coommit5");
                    }
                    catch
                    {
                    }
                }
            }
            else
            {
                MessageBox.Show("Файл настроек поврежден или имеет старую версию", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                File.Delete(settings.path);
                current_pos = "";
                current_obj = "";
                btn_upload.Enabled = false;
                btn_apply.Enabled = false;
                tabControl1.Enabled = false;
                this.Text = "Настройки SMarket";
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

            if (!Operators[cb_name.SelectedIndex].HasPassword)
            {
                btn_cancel_pwd.Text = "Создать пароль";
            }
            else
            {
                btn_cancel_pwd.Text = "Отменить пароль";
            }
            chkIsSec.Checked = Operators[z].IsSec;
            tb_number.Text = Operators[z].ID.ToString();
            tb_cpwd.Text = Operators[z].CashPwd;
            chk_notactive.Checked = Operators[z].NotActive;
            tmpMask = Operators[z].Mask;

            Mask = tmpMask;
            if (tmpMask == 8191)
            {
                c1.Checked = true;
            }
            else
            {
                c1.Checked = false;

                if (tmpMask >= 4096)
                {
                    c13.Checked = true;
                    tmpMask -= 4096;
                }
                else
                {
                    c13.Checked = false;
                }
                if (tmpMask >= 2048)
                {
                    c9.Checked = true;
                    tmpMask -= 2048;
                }
                else
                {
                    c9.Checked = false;
                }
                if (tmpMask >= 1024)
                {
                    c12.Checked = true;
                    tmpMask -= 1024;
                }
                else
                {
                    c12.Checked = false;
                }
                if (tmpMask >= 512)
                {
                    c11.Checked = true;
                    tmpMask -= 512;
                }
                else
                {
                    c11.Checked = false;
                }
                if (tmpMask >= 256)
                {
                    c10.Checked = true;
                    tmpMask -= 256;
                }
                else
                {
                    c10.Checked = false;
                }
                if (tmpMask >= 128)
                {
                    c8.Checked = true;
                    tmpMask -= 128;
                }
                else
                {
                    c8.Checked = false;
                }
                if (tmpMask >= 64)
                {
                    c7.Checked = true;
                    tmpMask -= 64;
                }
                else
                {
                    c7.Checked = false;
                }
                if (tmpMask >= 32)
                {
                    c6.Checked = true;
                    tmpMask -= 32;
                }
                else
                {
                    c6.Checked = false;
                }
                if (tmpMask >= 16)
                {
                    c5.Checked = true;
                    tmpMask -= 16;
                }
                else
                {
                    c5.Checked = false;
                }
                if (tmpMask >= 8)
                {
                    c4.Checked = true;
                    tmpMask -= 8;
                }
                else
                {
                    c4.Checked = false;
                }
                if (tmpMask >= 4)
                {
                    c3.Checked = true;
                    tmpMask -= 4;
                }
                else
                {
                    c3.Checked = false;
                }
                if (tmpMask >= 2)
                {
                    c2.Checked = true;
                    tmpMask -= 2;
                }
                else
                {
                    c2.Checked = false;
                }
                Operators[z].Mask = Mask;
            }
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
                Operators[Operators.Length - 1].ForDelete = false;
                Operators[Operators.Length - 1].Updated = false;
                Operators[Operators.Length - 1].NewPassword = true;
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
                cb_name.SelectedIndex = Operators.Length - 1;
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
            if (Operators[z].HasPassword)
            {
                Operators[z].Password = "";
                Operators[z].NewPassword = true;
                Operators[z].HasPassword = false;
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
                    Operators[z].NewPassword = true;
                    Operators[z].HasPassword = true;
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
            if (tabControl1.SelectedIndex == 0)
            {
                settings.IniWriteValue("General", "flgNotFiscal", chkNotFiscal.Checked.ToString());
                settings.IniWriteValue("General", "NewProtEveryDay", chkNewProt.Checked.ToString());
                settings.IniWriteValue("General", "flgRegCancel", chkRegCancel.Checked.ToString());
                settings.IniWriteValue("General", "PathCommand", edPathCommand.Text);
                settings.IniWriteValue("General", "PathIn", edPathIn.Text);
                settings.IniWriteValue("General", "PathOut", edPathOut.Text);
                settings.IniWriteValue("General", "PathServer", edPathServer.Text);
                settings.IniWriteValue("General", "flgNotDisplay", chkNotDisplay.Checked.ToString());
                settings.IniWriteValue("General", "flgFiscal", chkFiscal.Checked.ToString());
                settings.IniWriteValue("General", "AutoFiscal", chkAutoFiscal.Checked.ToString());
                settings.IniWriteValue("General", "logoY", edLogoY.Text);
                settings.IniWriteValue("General", "flgNoLimit", chkNoLimit.Checked.ToString());
                settings.IniWriteValue("General", "flgAnyQuantity", chkAnyQuality.Checked.ToString());
                settings.IniWriteValue("General", "flgMaxQuantity", chkMaxQuality.Checked.ToString());
                settings.IniWriteValue("General", "flgMaxSum", chkMaxSum.Checked.ToString());
                settings.IniWriteValue("General", "valMaxQuantity", edMaxQuality.Text);
                settings.IniWriteValue("General", "valMaxSum", edMaxSum.Text);
                settings.IniWriteValue("General", "valPollPeriod", edPollPeriod.Text);
            }
            if (tabControl1.SelectedIndex == 2)
            {
                settings.IniWriteValue("operators", "UseOnceOperator", chk_once_operator.Checked.ToString());
                settings.IniWriteValue("operators", "MagnetCode", chk_magnet.Checked.ToString());
                settings.IniWriteValue("operators", "Otborka", chk_Otborka.Checked.ToString());
                OperatorsControl.SaveOperators(current_pos, Operators);
            }
            if (tabControl1.SelectedIndex == 4)
            {
                settings.IniWriteValue("Restaurant", "order_isactive", chk_orderisactive.Checked.ToString());
                settings.IniWriteValue("Restaurant", "order_host", tb_serveraddress.Text);
                settings.IniWriteValue("Restaurant", "order_port", tb_serverport.Text);
                settings.IniWriteValue("Restaurant", "order_bname", tb_basename.Text);
                settings.IniWriteValue("Restaurant", "order_login", tb_baselogin.Text);
                settings.IniWriteValue("Restaurant", "order_pwd", tb_basepwd.Text);
                settings.IniWriteValue("Restaurant", "ping_timeout", tb_pingtimeout.Text);
                settings.IniWriteValue("Restaurant", "servicemode", chk_servicemode.Checked.ToString());
                settings.IniWriteValue("Restaurant", "precheck_coommit1", tb_precheckcommit1.Text);
                settings.IniWriteValue("Restaurant", "precheck_coommit2", tb_precheckcommit2.Text);
                settings.IniWriteValue("Restaurant", "precheck_coommit3", tb_precheckcommit3.Text);
                settings.IniWriteValue("Restaurant", "precheck_coommit4", tb_precheckcommit4.Text);
                settings.IniWriteValue("Restaurant", "precheck_coommit5", tb_precheckcommit5.Text);
            }
        }
        //Админ права
        private void c1_CheckedChanged(object sender, EventArgs e)
        {
            c2.Checked = c1.Checked;
            c3.Checked = c1.Checked;
            c4.Checked = c1.Checked;
            c5.Checked = c1.Checked;
            c6.Checked = c1.Checked;
            c7.Checked = c1.Checked;
            c8.Checked = c1.Checked;
            c9.Checked = c1.Checked;
            c10.Checked = c1.Checked;
            c11.Checked = c1.Checked;
            c12.Checked = c1.Checked;
            c13.Checked = c1.Checked;
            if (c1.Checked)
            {
                Operators[z].Mask = 8191;
                c2.Enabled = false;
                c3.Enabled = false;
                c4.Enabled = false;
                c5.Enabled = false;
                c6.Enabled = false;
                c7.Enabled = false;
                c8.Enabled = false;
                c9.Enabled = false;
                c10.Enabled = false;
                c11.Enabled = false;
                c12.Enabled = false;
                c13.Enabled = false;
                chkIsSec.Enabled = false;
                chkIsSec.Checked = false;
            }
            else
            {
                Operators[z].Mask = 0;
                c2.Enabled = true;
                c3.Enabled = true;
                c4.Enabled = true;
                c5.Enabled = true;
                c6.Enabled = true;
                c7.Enabled = true;
                c8.Enabled = true;
                c9.Enabled = true;
                c10.Enabled = true;
                c11.Enabled = true;
                c12.Enabled = true;
                c13.Enabled = true;
                chkIsSec.Enabled = true;
            }
        }
        private void c2_CheckedChanged(object sender, EventArgs e)
        {
            if (c2.Checked)
            {
                Operators[z].Mask += 2;
            }
            else
            {
                Operators[z].Mask -= 2;
            }
        }
        private void c3_CheckedChanged(object sender, EventArgs e)
        {
            if (c3.Checked)
            {
                Operators[z].Mask += 4;
            }
            else
            {
                Operators[z].Mask -= 4;
            }
        }
        private void c4_CheckedChanged(object sender, EventArgs e)
        {
            if (c4.Checked)
            {
                Operators[z].Mask += 8;
            }
            else
            {
                Operators[z].Mask -= 8;
            }
        }
        private void c5_CheckedChanged(object sender, EventArgs e)
        {
            if (c5.Checked)
            {
                Operators[z].Mask += 16;
            }
            else
            {
                Operators[z].Mask -= 16;
            }
        }
        private void c6_CheckedChanged(object sender, EventArgs e)
        {
            if (c6.Checked)
            {
                Operators[z].Mask += 32;
            }
            else
            {
                Operators[z].Mask -= 32;
            }
        }
        private void c7_CheckedChanged(object sender, EventArgs e)
        {
            if (c7.Checked)
            {
                Operators[z].Mask += 64;
            }
            else
            {
                Operators[z].Mask -= 64;
            }
        }
        private void c8_CheckedChanged(object sender, EventArgs e)
        {
            if (c8.Checked)
            {
                Operators[z].Mask += 128;
            }
            else
            {
                Operators[z].Mask -= 128;
            }
        }
        private void c9_CheckedChanged(object sender, EventArgs e)
        {
            if (c9.Checked)
            {
                Operators[z].Mask += 2048;
            }
            else
            {
                Operators[z].Mask -= 2048;
            }
        }
        private void c10_CheckedChanged(object sender, EventArgs e)
        {
            if (c10.Checked)
            {
                Operators[z].Mask += 256;
            }
            else
            {
                Operators[z].Mask -= 256;
            }
        }
        private void c11_CheckedChanged(object sender, EventArgs e)
        {
            if (c11.Checked)
            {
                Operators[z].Mask += 512;
            }
            else
            {
                Operators[z].Mask -= 512;
            }
        }
        private void c12_CheckedChanged(object sender, EventArgs e)
        {
            if (c12.Checked)
            {
                Operators[z].Mask += 1024;
            }
            else
            {
                Operators[z].Mask -= 1024;
            }
        }
        private void c13_CheckedChanged(object sender, EventArgs e)
        {
            if (c13.Checked)
            {
                Operators[z].Mask += 4096;
            }
            else
            {
                Operators[z].Mask -= 4096;
            }
        }
        //Установка флага неактивен
        private void chk_notactive_CheckedChanged(object sender, EventArgs e)
        {
            Operators[z].NotActive = chk_notactive.Checked;
        }
        //изменение ID
        private void tb_number_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Operators[z].ID = int.Parse(tb_number.Text);
            }
            catch
            {
            }
        }
        //Изменение пароля кассы
        private void tb_cpwd_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Operators[z].CashPwd = tb_cpwd.Text;
            }
            catch
            {
            }
        }
        //Флаг охранника
        private void chkIsSec_CheckedChanged(object sender, EventArgs e)
        {
            Operators[z].IsSec = chkIsSec.Checked;
        }

        private void frm_main_Load(object sender, EventArgs e)
        {
            IniFile cfg = new IniFile(Directory.GetCurrentDirectory() + "\\cfg.ini");
        }
    }
}
