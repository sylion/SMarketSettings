namespace SMarketSettings
{
    partial class frm_load
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_load));
            this.label1 = new System.Windows.Forms.Label();
            this.cbox_obj = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbox_pos = new System.Windows.Forms.ComboBox();
            this.btn_load = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Объект:";
            // 
            // cbox_obj
            // 
            this.cbox_obj.FormattingEnabled = true;
            this.cbox_obj.Location = new System.Drawing.Point(16, 30);
            this.cbox_obj.Name = "cbox_obj";
            this.cbox_obj.Size = new System.Drawing.Size(209, 21);
            this.cbox_obj.TabIndex = 1;
            this.cbox_obj.SelectedIndexChanged += new System.EventHandler(this.cbox_obj_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "POS терминал:";
            // 
            // cbox_pos
            // 
            this.cbox_pos.FormattingEnabled = true;
            this.cbox_pos.Location = new System.Drawing.Point(16, 88);
            this.cbox_pos.Name = "cbox_pos";
            this.cbox_pos.Size = new System.Drawing.Size(209, 21);
            this.cbox_pos.TabIndex = 3;
            this.cbox_pos.SelectedIndexChanged += new System.EventHandler(this.cbox_pos_SelectedIndexChanged);
            // 
            // btn_load
            // 
            this.btn_load.Enabled = false;
            this.btn_load.Location = new System.Drawing.Point(150, 127);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(75, 23);
            this.btn_load.TabIndex = 4;
            this.btn_load.Text = "Загрузить";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // frm_load
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 162);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.cbox_pos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbox_obj);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(249, 201);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(249, 201);
            this.Name = "frm_load";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Загрузить настройки";
            this.Load += new System.EventHandler(this.frm_load_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbox_obj;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbox_pos;
        private System.Windows.Forms.Button btn_load;
    }
}