namespace SMarketSettings
{
    partial class frm_check_comment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_check_comment));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_prefix1 = new System.Windows.Forms.TextBox();
            this.tb_prefix3 = new System.Windows.Forms.TextBox();
            this.tb_prefix2 = new System.Windows.Forms.TextBox();
            this.tb_prefix4 = new System.Windows.Forms.TextBox();
            this.tb_prefix5 = new System.Windows.Forms.TextBox();
            this.tb_prefix6 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_postfix2 = new System.Windows.Forms.TextBox();
            this.tb_postfix1 = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(75, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Комментарии в чеке";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "В начале чека (симв. 22-Mini, 28-Zebra)";
            // 
            // tb_prefix1
            // 
            this.tb_prefix1.Location = new System.Drawing.Point(12, 40);
            this.tb_prefix1.Name = "tb_prefix1";
            this.tb_prefix1.Size = new System.Drawing.Size(266, 20);
            this.tb_prefix1.TabIndex = 2;
            // 
            // tb_prefix3
            // 
            this.tb_prefix3.Location = new System.Drawing.Point(12, 92);
            this.tb_prefix3.Name = "tb_prefix3";
            this.tb_prefix3.Size = new System.Drawing.Size(266, 20);
            this.tb_prefix3.TabIndex = 3;
            // 
            // tb_prefix2
            // 
            this.tb_prefix2.Location = new System.Drawing.Point(12, 66);
            this.tb_prefix2.Name = "tb_prefix2";
            this.tb_prefix2.Size = new System.Drawing.Size(266, 20);
            this.tb_prefix2.TabIndex = 4;
            // 
            // tb_prefix4
            // 
            this.tb_prefix4.Location = new System.Drawing.Point(12, 118);
            this.tb_prefix4.Name = "tb_prefix4";
            this.tb_prefix4.Size = new System.Drawing.Size(266, 20);
            this.tb_prefix4.TabIndex = 5;
            // 
            // tb_prefix5
            // 
            this.tb_prefix5.Location = new System.Drawing.Point(12, 144);
            this.tb_prefix5.Name = "tb_prefix5";
            this.tb_prefix5.Size = new System.Drawing.Size(266, 20);
            this.tb_prefix5.TabIndex = 6;
            // 
            // tb_prefix6
            // 
            this.tb_prefix6.Location = new System.Drawing.Point(12, 170);
            this.tb_prefix6.Name = "tb_prefix6";
            this.tb_prefix6.Size = new System.Drawing.Size(266, 20);
            this.tb_prefix6.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "В конце чека (симв. 22-Mini, 28-Zebra)";
            // 
            // tb_postfix2
            // 
            this.tb_postfix2.Location = new System.Drawing.Point(12, 254);
            this.tb_postfix2.Name = "tb_postfix2";
            this.tb_postfix2.Size = new System.Drawing.Size(266, 20);
            this.tb_postfix2.TabIndex = 10;
            // 
            // tb_postfix1
            // 
            this.tb_postfix1.Location = new System.Drawing.Point(12, 228);
            this.tb_postfix1.Name = "tb_postfix1";
            this.tb_postfix1.Size = new System.Drawing.Size(266, 20);
            this.tb_postfix1.TabIndex = 9;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(203, 293);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 11;
            this.btn_cancel.Text = "Отмена";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(122, 293);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 12;
            this.btn_ok.Text = "ОК";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // frm_check_comment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 328);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.tb_postfix2);
            this.Controls.Add(this.tb_postfix1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_prefix6);
            this.Controls.Add(this.tb_prefix5);
            this.Controls.Add(this.tb_prefix4);
            this.Controls.Add(this.tb_prefix2);
            this.Controls.Add(this.tb_prefix3);
            this.Controls.Add(this.tb_prefix1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(306, 367);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(306, 367);
            this.Name = "frm_check_comment";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройка комментариев";
            this.Load += new System.EventHandler(this.frm_check_comment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_prefix1;
        private System.Windows.Forms.TextBox tb_prefix3;
        private System.Windows.Forms.TextBox tb_prefix2;
        private System.Windows.Forms.TextBox tb_prefix4;
        private System.Windows.Forms.TextBox tb_prefix5;
        private System.Windows.Forms.TextBox tb_prefix6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_postfix2;
        private System.Windows.Forms.TextBox tb_postfix1;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
    }
}