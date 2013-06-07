using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net.NetworkInformation;

namespace SMarketSettings
{
    public partial class frm_wait : Form
    {
        string address;
        string curr_pos;

        public frm_wait()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bg_worker.CancelAsync();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void frm_wait_Shown(object sender, EventArgs e)
        {
            frm_main frm = (frm_main)this.Owner;
            address = frm.current_pos;
            curr_pos = address;
            //Ping POS
            Ping png = new Ping();
            PingOptions opt = new PingOptions();
            opt.DontFragment = true;
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes (data);
            int timeout = 120;
            PingReply reply = png.Send(address, timeout, buffer, opt);
            if (reply.Status == IPStatus.Success)
            {
                if (Directory.Exists(@"\\" + address + @"\POS\Command\"))
                {
                    address = @"\\" + address + @"\POS\Command\req18";
                }
                else
                {
                    MessageBox.Show("Нету связи с POS терминалом или папка Command не доступна", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Нету связи с POS терминалом или папка Command не доступна", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            using (File.Create(address)) { }
            bg_worker.WorkerSupportsCancellation = true;
            bg_worker.RunWorkerAsync();
        }

        private void bg_worker_DoWork(object sender, DoWorkEventArgs e)
        {
            frm_main frm = (frm_main)this.Owner;
            address = @"\\" + curr_pos + @"\POS\Out\settings.ini";
            bool stopTrying = false;
            while (!stopTrying)
            {
                if (File.Exists(address))
                {
                    if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\Settings"))
                    {
                        Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Settings");
                    }
                    if (File.Exists(Directory.GetCurrentDirectory() + "\\Settings\\" + frm.current_pos + ".ini"))
                    {
                        File.Delete(Directory.GetCurrentDirectory() + "\\Settings\\" + frm.current_pos + ".ini");
                    }
                    File.Move(address, Directory.GetCurrentDirectory() + "\\Settings\\" + frm.current_pos + ".ini");
                    stopTrying = true;
                }
                else
                {
                    System.Threading.Thread.Sleep(500);
                    stopTrying = false;
                }
            }
        }

        private void bg_worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void frm_wait_Load(object sender, EventArgs e)
        {
            timer.Start();
        }
    }
}
