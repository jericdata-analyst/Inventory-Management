using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace DB2019
{
    public partial class frmlogs : Form
    {
        public frmlogs(string user, string usertype)
        {
            InitializeComponent();
 
            this.user = user;
            this.usertype = usertype;

        }
        
        string user,usertype;
        Class1 Account = new Class1("127.0.0.1", "cp3", "test", "12345");


        private void frmlogs_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Visible = false;

            try
            {

                if (usertype == "Administrator")
                {
                    DataTable dt = Account.GetData("select * from tbllogs order by date_time desc");
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    DataTable dt = Account.GetData("select * from tbllogs where user like '%" + user + "%'  order by date_time desc");
                    dataGridView1.DataSource = dt;
                    
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


            timer1.Start();
           label1.Text = DateTime.Now.ToLongDateString();
            label3.Visible = false;
            cmbSearchModule.Visible = false;
            

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbsearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbsearch.SelectedIndex == 0) //module
            {
                label3.Visible = true;
                cmbSearchModule.Visible = true;
                cmbsearch.Focus();
                dateTimePicker1.Visible = false;
            }

            if (cmbsearch.SelectedIndex == 1) //date
            {
                label3.Visible = true;
                dateTimePicker1.Visible = true;
                cmbSearchModule.Visible = false;
                cmbsearch.Focus();
            }
        }

        private void cmbSearchModule_SelectedIndexChanged(object sender, EventArgs e)
        {

            string ac = "Accounts Management";
            string ec = "Equipments Management";
           // string bc = "Borrowing Management";
            try
            {
                if (cmbSearchModule.SelectedIndex == 0)

                    if (usertype == "Administrator")
                    {
                        DataTable dt = Account.GetData("select * from tbllogs where module LIKE '%" + ac + "%' order by date_time");
                        dataGridView1.DataSource = dt;

                    }
                    else
                    {
                        DataTable dt = Account.GetData("select * from tbllogs where module LIKE '%" + ac + "%' and user LIKE '%" + user + "%' order by date_time");
                        dataGridView1.DataSource = dt;
                    }

                else
                {

                    if (usertype == "Administrator")
                    {
                        DataTable dt = Account.GetData("select * from tbllogs where module LIKE '%" + ec + "%' order by date_time");
                        dataGridView1.DataSource = dt;

                    }
                    else
                    {
                        DataTable dt = Account.GetData("select * from tbllogs where module LIKE '%" + ec + "%' and user LIKE '%" + user + "%' order by date_time");
                        dataGridView1.DataSource = dt;
                    }

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Refresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
             if (usertype == "Administrator")
            {
                DataTable dt = Account.GetData("select * from tbllogs ORDER BY date_time desc");
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
            }
            else
            {
                DataTable dt = Account.GetData("select * from tbllogs WHERE user LIKE '%" + user + "%' ORDER BY date_time desc");
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
            }
           
            cmbSearchModule.Visible = false;
            label3.Visible = false;
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (usertype == "Administrator")
                {
                    DataTable dt = Account.GetData("select * from tbllogs WHERE date_time LIKE '%" + dateTimePicker1.Text + "%' ORDER BY date_time");
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    DataTable dt = Account.GetData("select * from tbllogs WHERE user LIKE '%" + user + "%' and date_time '%" + dateTimePicker1 + "%'  ORDER BY date_time");
                    dataGridView1.DataSource = dt;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }
    }


}
    

