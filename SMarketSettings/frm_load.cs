using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ini;
using POS;
using System.IO;

namespace SMarketSettings
{
    public partial class frm_load : Form
    {
        //IniFile cfg = new IniFile(Directory.GetCurrentDirectory() + "\\cfg.ini");
        int number_of_objects = 0;
        ObjectPOS[] objectp;

        public frm_load()
        {
            InitializeComponent();
        }

        private void frm_load_Load(object sender, EventArgs e)
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
                
                if (number_of_objects > 0)
                {
                    for (int i = 0; i < number_of_objects; i++)
                    {
                        cbox_obj.Items.Add(objectp[i].name);
                    }
                    cbox_obj.Focus();
                    cbox_obj.SelectedIndex = 0;
                }
                else
                {
                }
            }
            catch
            {
            }
        }

        private void cbox_obj_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbox_pos.Items.Clear();
            cbox_pos.Items.AddRange(objectp[cbox_obj.SelectedIndex].pos);
            if (cbox_pos.Text != "")
            {
                btn_load.Enabled = true;
            }
            else
            {
                btn_load.Enabled = false;
            }
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            frm_main frm = (frm_main)this.Owner;
            frm.current_obj = cbox_obj.Text;
            frm.current_pos = cbox_pos.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void cbox_pos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbox_pos.Text != "")
            {
                btn_load.Enabled = true;
            }
            else
            {
                btn_load.Enabled = false;
            }
        }
    }
}
