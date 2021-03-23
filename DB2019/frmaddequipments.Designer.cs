namespace DB2019
{
    partial class frmaddequipments
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmaddequipments));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtb_desc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_status = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_available = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_branch = new System.Windows.Forms.ComboBox();
            this.cmb_model = new System.Windows.Forms.ComboBox();
            this.txtb_serial = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(329, 62);
            this.panel1.TabIndex = 23;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(294, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(32, 31);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 11;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(6, 10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(44, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Add/Edit Equipment";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtb_desc
            // 
            this.txtb_desc.BackColor = System.Drawing.Color.White;
            this.txtb_desc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtb_desc.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F);
            this.txtb_desc.ForeColor = System.Drawing.Color.Black;
            this.txtb_desc.Location = new System.Drawing.Point(127, 202);
            this.txtb_desc.Multiline = true;
            this.txtb_desc.Name = "txtb_desc";
            this.txtb_desc.Size = new System.Drawing.Size(177, 50);
            this.txtb_desc.TabIndex = 113;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(27, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 19);
            this.label1.TabIndex = 111;
            this.label1.Text = "Description";
            // 
            // cmb_status
            // 
            this.cmb_status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(12)))), ((int)(((byte)(40)))));
            this.cmb_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_status.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F);
            this.cmb_status.ForeColor = System.Drawing.Color.Cornsilk;
            this.cmb_status.FormattingEnabled = true;
            this.cmb_status.Items.AddRange(new object[] {
            "WORKING",
            "REPAIR",
            "RETIRE"});
            this.cmb_status.Location = new System.Drawing.Point(127, 267);
            this.cmb_status.Name = "cmb_status";
            this.cmb_status.Size = new System.Drawing.Size(177, 27);
            this.cmb_status.TabIndex = 109;
            this.cmb_status.SelectedIndexChanged += new System.EventHandler(this.cmb_status_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(53, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 19);
            this.label2.TabIndex = 107;
            this.label2.Text = "Status ";
            // 
            // cmb_available
            // 
            this.cmb_available.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(12)))), ((int)(((byte)(40)))));
            this.cmb_available.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_available.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F);
            this.cmb_available.ForeColor = System.Drawing.Color.Cornsilk;
            this.cmb_available.FormattingEnabled = true;
            this.cmb_available.Items.AddRange(new object[] {
            "YES",
            "NO"});
            this.cmb_available.Location = new System.Drawing.Point(127, 300);
            this.cmb_available.Name = "cmb_available";
            this.cmb_available.Size = new System.Drawing.Size(177, 27);
            this.cmb_available.TabIndex = 106;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(38, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 19);
            this.label3.TabIndex = 103;
            this.label3.Text = "Available ";
            // 
            // cmb_branch
            // 
            this.cmb_branch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(12)))), ((int)(((byte)(40)))));
            this.cmb_branch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_branch.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F);
            this.cmb_branch.ForeColor = System.Drawing.Color.Cornsilk;
            this.cmb_branch.FormattingEnabled = true;
            this.cmb_branch.Items.AddRange(new object[] {
            "MABINI",
            "PSG",
            "PLA",
            "LEG",
            "ABAD",
            "JRC",
            "EEC"});
            this.cmb_branch.Location = new System.Drawing.Point(127, 121);
            this.cmb_branch.Name = "cmb_branch";
            this.cmb_branch.Size = new System.Drawing.Size(177, 27);
            this.cmb_branch.TabIndex = 102;
            // 
            // cmb_model
            // 
            this.cmb_model.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(12)))), ((int)(((byte)(40)))));
            this.cmb_model.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_model.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F);
            this.cmb_model.ForeColor = System.Drawing.Color.Cornsilk;
            this.cmb_model.FormattingEnabled = true;
            this.cmb_model.Items.AddRange(new object[] {
            "Laptop",
            "Projector",
            "Monitor",
            "CPU",
            "Mouse",
            "Keyboard"});
            this.cmb_model.Location = new System.Drawing.Point(128, 162);
            this.cmb_model.Name = "cmb_model";
            this.cmb_model.Size = new System.Drawing.Size(176, 27);
            this.cmb_model.TabIndex = 101;
            this.cmb_model.SelectedIndexChanged += new System.EventHandler(this.cmb_model_SelectedIndexChanged);
            // 
            // txtb_serial
            // 
            this.txtb_serial.BackColor = System.Drawing.Color.White;
            this.txtb_serial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtb_serial.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F);
            this.txtb_serial.ForeColor = System.Drawing.Color.Black;
            this.txtb_serial.Location = new System.Drawing.Point(127, 85);
            this.txtb_serial.Name = "txtb_serial";
            this.txtb_serial.Size = new System.Drawing.Size(177, 19);
            this.txtb_serial.TabIndex = 94;
            this.txtb_serial.TextChanged += new System.EventHandler(this.txtb_serial_TextChanged);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.MidnightBlue;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(218, 351);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(86, 40);
            this.button4.TabIndex = 92;
            this.button4.Text = "Clear";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MidnightBlue;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(115, 351);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 40);
            this.button1.TabIndex = 91;
            this.button1.Text = "Save";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(50, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 19);
            this.label4.TabIndex = 90;
            this.label4.Text = "Branch ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(55, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 19);
            this.label7.TabIndex = 89;
            this.label7.Text = "Model ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(55, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 19);
            this.label8.TabIndex = 88;
            this.label8.Text = "Serial ";
            // 
            // frmaddequipments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(329, 420);
            this.Controls.Add(this.txtb_desc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_status);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_available);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmb_branch);
            this.Controls.Add(this.cmb_model);
            this.Controls.Add(this.txtb_serial);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmaddequipments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "addequipments";
            this.Load += new System.EventHandler(this.frmaddequipments_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtb_desc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_status;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_available;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_branch;
        private System.Windows.Forms.ComboBox cmb_model;
        private System.Windows.Forms.TextBox txtb_serial;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}