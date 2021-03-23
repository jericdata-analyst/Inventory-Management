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
    public partial class frmlogin : Form

    {
        public frmlogin()
        {
            InitializeComponent();

        }
        Class1 Login = new Class1("127.0.0.1", "cp3", "test", "12345");
        private void btnlogin_Click(object sender, EventArgs e)
        {

        }

        private void frmlogin_Load(object sender, EventArgs e)
        {


        }

        private void btnlogin_Click_1(object sender, EventArgs e)
        {
            //txtusername.Text = "2";
            //txtpassword.Text = "2";
            try
            {
                DataTable dt = Login.GetData("select * from tblaccounts where username = '" + txtusername.Text +
                 "' and password = '" + txtpassword.Text + "' and status = 'active'");
                if (dt.Rows.Count > 0)
                {
                    frmmain main = new frmmain(txtusername.Text, dt.Rows[0].Field<string>("user_type"), txtpassword.Text);
                    main.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Incorrect username or password or account is inactive", "Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            

        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {


        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            txtpassword.UseSystemPasswordChar = true;
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            txtpassword.UseSystemPasswordChar = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtpassword_MouseClick(object sender, MouseEventArgs e)
        {
            txtpassword.Clear();
        }

        private void txtusername_MouseClick(object sender, MouseEventArgs e)
        {
            txtusername.Clear();
        }

        private void txtusername_MouseUp(object sender, MouseEventArgs e)
        {
            //txtusername.Text= "Username";
        }

        private void txtpassword_MouseUp(object sender, MouseEventArgs e)
        {
            //txtpassword.Text = "******";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

       
        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

      

        
    }
    }
