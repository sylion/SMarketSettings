namespace SMarketSettings
{
    partial class frm_settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_settings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_del_pos = new System.Windows.Forms.Button();
            this.btn_new_pos = new System.Windows.Forms.Button();
            this.btn_del_obj = new System.Windows.Forms.Button();
            this.lst_pos = new System.Windows.Forms.ListBox();
            this.btn_new_obj = new System.Windows.Forms.Button();
            this.lst_objects = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_del_pos);
            this.groupBox1.Controls.Add(this.btn_new_pos);
            this.groupBox1.Controls.Add(this.btn_del_obj);
            this.groupBox1.Controls.Add(this.lst_pos);
            this.groupBox1.Controls.Add(this.btn_new_obj);
            this.groupBox1.Controls.Add(this.lst_objects);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(459, 282);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Справочник POS";
            // 
            // btn_del_pos
            // 
            this.btn_del_pos.Location = new System.Drawing.Point(376, 251);
            this.btn_del_pos.Name = "btn_del_pos";
            this.btn_del_pos.Size = new System.Drawing.Size(75, 23);
            this.btn_del_pos.TabIndex = 16;
            this.btn_del_pos.Text = "Удалить";
            this.btn_del_pos.UseVisualStyleBackColor = true;
            this.btn_del_pos.Click += new System.EventHandler(this.btn_del_pos_Click);
            // 
            // btn_new_pos
            // 
            this.btn_new_pos.Location = new System.Drawing.Point(295, 251);
            this.btn_new_pos.Name = "btn_new_pos";
            this.btn_new_pos.Size = new System.Drawing.Size(75, 23);
            this.btn_new_pos.TabIndex = 15;
            this.btn_new_pos.Text = "Новый";
            this.btn_new_pos.UseVisualStyleBackColor = true;
            this.btn_new_pos.Click += new System.EventHandler(this.btn_new_pos_Click);
            // 
            // btn_del_obj
            // 
            this.btn_del_obj.Location = new System.Drawing.Point(145, 251);
            this.btn_del_obj.Name = "btn_del_obj";
            this.btn_del_obj.Size = new System.Drawing.Size(75, 23);
            this.btn_del_obj.TabIndex = 14;
            this.btn_del_obj.Text = "Удалить";
            this.btn_del_obj.UseVisualStyleBackColor = true;
            this.btn_del_obj.Click += new System.EventHandler(this.btn_del_obj_Click);
            // 
            // lst_pos
            // 
            this.lst_pos.FormattingEnabled = true;
            this.lst_pos.Location = new System.Drawing.Point(237, 33);
            this.lst_pos.Name = "lst_pos";
            this.lst_pos.Size = new System.Drawing.Size(214, 212);
            this.lst_pos.TabIndex = 13;
            // 
            // btn_new_obj
            // 
            this.btn_new_obj.Location = new System.Drawing.Point(64, 251);
            this.btn_new_obj.Name = "btn_new_obj";
            this.btn_new_obj.Size = new System.Drawing.Size(75, 23);
            this.btn_new_obj.TabIndex = 12;
            this.btn_new_obj.Text = "Новый";
            this.btn_new_obj.UseVisualStyleBackColor = true;
            this.btn_new_obj.Click += new System.EventHandler(this.btn_new_obj_Click);
            // 
            // lst_objects
            // 
            this.lst_objects.FormattingEnabled = true;
            this.lst_objects.Location = new System.Drawing.Point(6, 33);
            this.lst_objects.Name = "lst_objects";
            this.lst_objects.Size = new System.Drawing.Size(214, 212);
            this.lst_objects.TabIndex = 11;
            this.lst_objects.SelectedValueChanged += new System.EventHandler(this.lst_objects_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "POS Терминалы:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Обьекты:";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(379, 290);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 10;
            this.btn_cancel.Text = "Отмена";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(298, 290);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 11;
            this.btn_save.Text = "Сохранить";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // frm_settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 319);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(482, 358);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(482, 358);
            this.Name = "frm_settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки программы";
            this.Load += new System.EventHandler(this.frm_settings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_del_pos;
        private System.Windows.Forms.Button btn_new_pos;
        private System.Windows.Forms.Button btn_del_obj;
        private System.Windows.Forms.ListBox lst_pos;
        private System.Windows.Forms.Button btn_new_obj;
        private System.Windows.Forms.ListBox lst_objects;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_save;
    }
}