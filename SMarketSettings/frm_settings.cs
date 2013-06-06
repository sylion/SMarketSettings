using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Ini;
using POS;

namespace SMarketSettings
{
    public partial class frm_settings : Form
    {
        IniFile cfg = new IniFile(Directory.GetCurrentDirectory() + "\\cfg.ini");
        int number_of_objects = 0;
        ObjectPOS[] objectp;
        public string tmp;

        public frm_settings()
        {
            InitializeComponent();
        }
        //Загрузка данных из файла
        private void frm_settings_Load(object sender, EventArgs e)
        {
            try
            {
                number_of_objects = POScnt.get_num_of_pos();
            }
            catch
            {
            }
            try
            {
                objectp = POScnt.get_obj();

                if (number_of_objects >= 0)
                {
                    for (int i = 0; i < number_of_objects; i++)
                    {
                        lst_objects.Items.Add(objectp[i].name);
                    }
                    lst_objects.Focus();
                    lst_objects.SelectedIndex = 0;
                }
                else
                {
                    number_of_objects = 0;
                    MessageBox.Show("Неполадки с файлом настроек или он пуст!\nФайл будет персоздан", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    File.Delete(Directory.GetCurrentDirectory() + "\\cfg.ini");
                    using (File.Create(Directory.GetCurrentDirectory() + "\\cfg.ini"))
                    { }
                    objectp = new ObjectPOS[number_of_objects];
                }
            }
            catch
            {
                number_of_objects = 0;
                MessageBox.Show("Неполадки с файлом настроек или он пуст!\nФайл будет персоздан", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                File.Delete(Directory.GetCurrentDirectory() + "\\cfg.ini");
                using (File.Create(Directory.GetCurrentDirectory() + "\\cfg.ini"))
                { }
                objectp = new ObjectPOS[number_of_objects];
            }
        }
        //Закрыть без сохранения
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Отображение посов при выборе обьекта
        private void lst_objects_SelectedValueChanged(object sender, EventArgs e)
        {
            lst_pos.Items.Clear();
            try
            {
                lst_pos.Items.AddRange(objectp[lst_objects.SelectedIndex].pos);
            }
            catch
            {
            }
        }
        //Удаление поса
        private void btn_del_pos_Click(object sender, EventArgs e)
        {
            objectp[lst_objects.SelectedIndex].delete_addr(lst_pos.SelectedIndex);
            lst_pos.Items.Clear();
            lst_pos.Items.AddRange(objectp[lst_objects.SelectedIndex].pos);
        }
        //Удаление обьекта
        private void btn_del_obj_Click(object sender, EventArgs e)
        {
            ObjectPOS[] temp = new ObjectPOS[objectp.Length - 1];
            number_of_objects--;
            for (int i = 0, z = 0; i < objectp.Length - 1; i++, z++)
            {
                if (i == lst_objects.SelectedIndex)
                {
                    z++;
                    temp[i] = objectp[z];

                }
                temp[i] = objectp[z];
            }
            objectp = temp;
            lst_objects.Items.Clear();
            lst_pos.Items.Clear();
            for (int i = 0; i < number_of_objects; i++)
            {
                lst_objects.Items.Add(objectp[i].name);
            }
            try
            {
                lst_objects.Focus();
                lst_objects.SelectedIndex = 0;
            }
            catch
            {
            }
        }
        //Добавление поса
        private void btn_new_pos_Click(object sender, EventArgs e)
        {
            Form add = new frm_add();
            add.Owner = this;
            add.ShowDialog();
            if (add.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                objectp[lst_objects.SelectedIndex].add_addr(tmp);
            }
            lst_pos.Items.Clear();
            lst_pos.Items.AddRange(objectp[lst_objects.SelectedIndex].pos);
        }
        //Добавление обьекта
        private void btn_new_obj_Click(object sender, EventArgs e)
        {
            Form add = new frm_add();
            add.Owner = this;
            add.ShowDialog();
            if (add.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                ObjectPOS[] temp = objectp;
                Array.Resize(ref temp, temp.Length + 1);
                temp[number_of_objects] = new ObjectPOS();
                temp[number_of_objects].name = tmp;
                temp[number_of_objects].pos_number = 0;
                objectp = temp;
                number_of_objects++;
            }
            lst_objects.Items.Clear();
            for (int i = 0; i < number_of_objects; i++)
            {
                lst_objects.Items.Add(objectp[i].name);
            }
            lst_objects.Focus();
            lst_objects.SelectedIndex = 0;
        }
        //Сохранение настроек
        private void btn_save_Click(object sender, EventArgs e)
        {
            File.Delete(Directory.GetCurrentDirectory() + "\\cfg.ini");
            using (File.Create(Directory.GetCurrentDirectory() + "\\cfg.ini"))
            {}
            cfg.IniWriteValue("objects", "numberofobjects", number_of_objects.ToString());
            for (int i = 0; i < number_of_objects; i++)
            {
                cfg.IniWriteValue("objects", "obj" + (i + 1), objectp[i].name);
                cfg.IniWriteValue(objectp[i].name, "numofpos", objectp[i].pos_number.ToString());
                for (int z = 0; z < objectp[i].pos_number; z++)
                {
                    cfg.IniWriteValue(objectp[i].name, "pos" + (z + 1), objectp[i].pos[z]);
                }
            }
            this.Close();
        }
    }
}
