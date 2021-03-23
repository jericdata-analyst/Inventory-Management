namespace DB2019
{
    partial class frmequipments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmequipments));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbavailable = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbsearch = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbstatus = new System.Windows.Forms.ComboBox();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelvalue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cmbSearchBranch = new System.Windows.Forms.ComboBox();
            this.cmbSearchModel = new System.Windows.Forms.ComboBox();
            this.txtSearchAsset = new System.Windows.Forms.TextBox();
            this.txtSearchSerial = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbavailable
            // 
            this.cmbavailable.BackColor = System.Drawing.Color.MidnightBlue;
            this.cmbavailable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbavailable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbavailable.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F);
            this.cmbavailable.ForeColor = System.Drawing.Color.White;
            this.cmbavailable.FormattingEnabled = true;
            this.cmbavailable.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cmbavailable.Location = new System.Drawing.Point(483, 93);
            this.cmbavailable.Margin = new System.Windows.Forms.Padding(4);
            this.cmbavailable.Name = "cmbavailable";
            this.cmbavailable.Size = new System.Drawing.Size(205, 27);
            this.cmbavailable.TabIndex = 43;
            this.cmbavailable.SelectedIndexChanged += new System.EventHandler(this.cmbavailable_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(734, 62);
            this.panel1.TabIndex = 42;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(690, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(50, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "Equipment Management";
            // 
            // cmbsearch
            // 
            this.cmbsearch.BackColor = System.Drawing.Color.MidnightBlue;
            this.cmbsearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbsearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsearch.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F);
            this.cmbsearch.ForeColor = System.Drawing.Color.White;
            this.cmbsearch.FormattingEnabled = true;
            this.cmbsearch.Items.AddRange(new object[] {
            "Status",
            "Available",
            "Branch",
            "Model",
            "Serial Number",
            "Asset Number"});
            this.cmbsearch.Location = new System.Drawing.Point(216, 90);
            this.cmbsearch.Margin = new System.Windows.Forms.Padding(4);
            this.cmbsearch.Name = "cmbsearch";
            this.cmbsearch.Size = new System.Drawing.Size(201, 27);
            this.cmbsearch.TabIndex = 29;
            this.cmbsearch.SelectedIndexChanged += new System.EventHandler(this.cmbsearch_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MidnightBlue;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15.75F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(13, 301);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 45);
            this.button1.TabIndex = 41;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 433);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 407);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 39;
            // 
            // cmbstatus
            // 
            this.cmbstatus.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.cmbstatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbstatus.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F);
            this.cmbstatus.ForeColor = System.Drawing.Color.White;
            this.cmbstatus.FormattingEnabled = true;
            this.cmbstatus.Items.AddRange(new object[] {
            "Working",
            "Repair",
            "Retire"});
            this.cmbstatus.Location = new System.Drawing.Point(483, 93);
            this.cmbstatus.Margin = new System.Windows.Forms.Padding(4);
            this.cmbstatus.Name = "cmbstatus";
            this.cmbstatus.Size = new System.Drawing.Size(205, 27);
            this.cmbstatus.TabIndex = 38;
            this.cmbstatus.SelectedIndexChanged += new System.EventHandler(this.cmbstatus_SelectedIndexChanged);
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.MidnightBlue;
            this.btndelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btndelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btndelete.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15.75F);
            this.btndelete.ForeColor = System.Drawing.Color.White;
            this.btndelete.Image = ((System.Drawing.Image)(resources.GetObject("btndelete.Image")));
            this.btndelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndelete.Location = new System.Drawing.Point(13, 248);
            this.btndelete.Margin = new System.Windows.Forms.Padding(4);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(124, 45);
            this.btndelete.TabIndex = 34;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnedit
            // 
            this.btnedit.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnedit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnedit.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15.75F);
            this.btnedit.ForeColor = System.Drawing.Color.White;
            this.btnedit.Image = ((System.Drawing.Image)(resources.GetObject("btnedit.Image")));
            this.btnedit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnedit.Location = new System.Drawing.Point(13, 195);
            this.btnedit.Margin = new System.Windows.Forms.Padding(4);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(124, 45);
            this.btnedit.TabIndex = 33;
            this.btnedit.Text = "Edit";
            this.btnedit.UseVisualStyleBackColor = false;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnadd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnadd.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15.75F);
            this.btnadd.ForeColor = System.Drawing.Color.White;
            this.btnadd.Image = ((System.Drawing.Image)(resources.GetObject("btnadd.Image")));
            this.btnadd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnadd.Location = new System.Drawing.Point(13, 142);
            this.btnadd.Margin = new System.Windows.Forms.Padding(4);
            this.btnadd.Name = "btnadd";
            this.btnadd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnadd.Size = new System.Drawing.Size(124, 45);
            this.btnadd.TabIndex = 32;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(168, 142);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(541, 304);
            this.dataGridView1.TabIndex = 31;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // labelvalue
            // 
            this.labelvalue.AutoSize = true;
            this.labelvalue.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15.75F);
            this.labelvalue.Location = new System.Drawing.Point(425, 91);
            this.labelvalue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelvalue.Name = "labelvalue";
            this.labelvalue.Size = new System.Drawing.Size(50, 21);
            this.labelvalue.TabIndex = 28;
            this.labelvalue.Text = "Value:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15.75F);
            this.label1.Location = new System.Drawing.Point(124, 91);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 21);
            this.label1.TabIndex = 27;
            this.label1.Text = "Search By:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cmbSearchBranch
            // 
            this.cmbSearchBranch.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbSearchBranch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbSearchBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchBranch.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F);
            this.cmbSearchBranch.FormattingEnabled = true;
            this.cmbSearchBranch.Items.AddRange(new object[] {
            "MABINI",
            "PSG",
            "PLA",
            "LEG",
            "ABAD",
            "JRC",
            "EEC"});
            this.cmbSearchBranch.Location = new System.Drawing.Point(483, 93);
            this.cmbSearchBranch.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSearchBranch.Name = "cmbSearchBranch";
            this.cmbSearchBranch.Size = new System.Drawing.Size(205, 27);
            this.cmbSearchBranch.TabIndex = 48;
            this.cmbSearchBranch.SelectedIndexChanged += new System.EventHandler(this.cmbSearchBranch_SelectedIndexChanged);
            // 
            // cmbSearchModel
            // 
            this.cmbSearchModel.BackColor = System.Drawing.SystemColors.Window;
            this.cmbSearchModel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbSearchModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchModel.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F);
            this.cmbSearchModel.FormattingEnabled = true;
            this.cmbSearchModel.Items.AddRange(new object[] {
            "Laptop",
            "Projector",
            "Monitor",
            "CPU",
            "Printer",
            "Mouse",
            "Keyboard"});
            this.cmbSearchModel.Location = new System.Drawing.Point(483, 92);
            this.cmbSearchModel.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSearchModel.Name = "cmbSearchModel";
            this.cmbSearchModel.Size = new System.Drawing.Size(205, 27);
            this.cmbSearchModel.TabIndex = 49;
            this.cmbSearchModel.SelectedIndexChanged += new System.EventHandler(this.cmbSearchModel_SelectedIndexChanged);
            // 
            // txtSearchAsset
            // 
            this.txtSearchAsset.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F);
            this.txtSearchAsset.Location = new System.Drawing.Point(483, 92);
            this.txtSearchAsset.Name = "txtSearchAsset";
            this.txtSearchAsset.Size = new System.Drawing.Size(205, 26);
            this.txtSearchAsset.TabIndex = 50;
            this.txtSearchAsset.TextChanged += new System.EventHandler(this.txtSearchAsset_TextChanged);
            // 
            // txtSearchSerial
            // 
            this.txtSearchSerial.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F);
            this.txtSearchSerial.Location = new System.Drawing.Point(483, 93);
            this.txtSearchSerial.Name = "txtSearchSerial";
            this.txtSearchSerial.Size = new System.Drawing.Size(205, 26);
            this.txtSearchSerial.TabIndex = 51;
            this.txtSearchSerial.TextChanged += new System.EventHandler(this.txtSearchSerial_TextChanged);
            // 
            // frmequipments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 482);
            this.Controls.Add(this.cmbSearchModel);
            this.Controls.Add(this.cmbSearchBranch);
            this.Controls.Add(this.cmbavailable);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbsearch);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbstatus);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelvalue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearchSerial);
            this.Controls.Add(this.txtSearchAsset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmequipments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmequipments";
            this.Load += new System.EventHandler(this.frmequipments_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbavailable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbsearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbstatus;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelvalue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cmbSearchBranch;
        private System.Windows.Forms.ComboBox cmbSearchModel;
        private System.Windows.Forms.TextBox txtSearchAsset;
        private System.Windows.Forms.TextBox txtSearchSerial;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}