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
    public partial class frmaddaccount : Form
    {

        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;

        string user, username, action,  usertype;

        public frmaddaccount(string username, string password, string usertype,string email,string action,string user)
        {
            InitializeComponent();
            this.username = username;
            this.action = action;
          
            this.usertype = usertype;
            this.user = user;
            txtusername.Text = username;
            txtpassword.Text = password;
            cmbdept.Text = email;
            cmbusertype.Text = usertype;
        }
        
        Class1 Account = new Class1("127.0.0.1", "cp3", "test", "12345");

		private void btnclear_Click(object sender, EventArgs e)
		{
			
			txtpassword.Clear();
			txtusername.Clear();
		
		}

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            txtpassword.UseSystemPasswordChar = false;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            txtpassword.UseSystemPasswordChar = true;
        }

       

        int error = 0;
        void validate()
        {
            errorProvider1.Clear();
            error = 0;
            if (string.IsNullOrEmpty(txtusername.Text))
            {
                errorProvider1.SetError(txtusername, "Username is empty");
                error++;
            }
            if (string.IsNullOrEmpty(txtpassword.Text))
            {
                errorProvider1.SetError(txtpassword, "Password is empty");
                error++;
            }
            if (txtpassword.TextLength < 6)
            {
                errorProvider1.SetError(txtpassword, "Password length should be greater than 6");
                error++;
            }
            if (cmbusertype.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbusertype, "Select usertype");
                error++;
            }

            if (cmbusertype.SelectedIndex == 1)
            {
                if (cmbdept.SelectedIndex < 0)
                {
                    errorProvider1.SetError(cmbdept, "Select Department");
                    error++;
                }
                
            }
           

            if (action == "add")
            {
                DataTable dt = Account.GetData("select * from tblaccounts where username ='" + txtusername.Text + "'");
                if (dt.Rows.Count>0)
                {
                    errorProvider1.SetError(txtusername, "Username already exists");
                    error++;
                }
            }
        }




        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (action == "add")
                {
                    validate();
                    if (error == 0)
                    {
                        Account.executeSQL("INSERT INTO tblaccounts VALUES ('" + txtusername.Text + "' , '" + txtpassword.Text +
                            "' , '" + cmbusertype.Text + "' ,'" + cmbdept.Text + "'  , 'active')");
                        if (Account.rowAffected > 0)
                        {
                            MessageBox.Show("New Account Added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);


                            Account.executeSQL("INSERT INTO tbllogs VALUES ('" + DateTime.Now.ToString() +
                               "' , 'Added new user with username of " + txtusername.Text + "' , '" + user + "','Accounts Management')");
                            raiseUpdate();
                            this.Close();
                            
                            DataTable dt = Account.GetData("select * from tblaccounts order by username");
                        }
                    }
                }
                else if(action == "edit")
                {
                    validate();
                    if (error == 0)
                    {
                        string status = "active";
                        // Account.executeSQL("update  tblaccounts set username = '" + txtusername.Text + "' , '" + txtpassword.Text +
                        //"' , '" + cmbusertype.Text + "', '" + cmbdept.Text + "'  , 'active'");

                        Account.executeSQL("update tblaccounts set password = '" + txtpassword.Text + "', user_type= '" + cmbusertype.Text + "', department = '" + cmbdept.Text + "',  status = '" + status + "' Where username = '" +txtusername.Text + "'");

                        MessageBox.Show("Account Updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Account.executeSQL("INSERT INTO tbllogs VALUES ('" + DateTime.Now.ToString() +
                            "' , 'Update user with username of " + txtusername.Text + "' , '" + user + "','Accounts Management')");
                        raiseUpdate();
                        this.Hide();
                    }
                    
                }
                }
            catch (Exception ex)
            {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        private void frmaddaccount_Load(object sender, EventArgs e)
        {
            if (action == "change")
            {
                cmbdept.Enabled = true;
                cmbusertype.Enabled = false;
                txtusername.Enabled = true;
                
            }
            else
            {
                cmbusertype.Enabled = true;
                cmbdept.Enabled = false;
                txtusername.Enabled = true;
            }

            if (action == "edit")
            {
                txtusername.Enabled = false;

                if (cmbusertype.SelectedIndex == 1) //USERNAME
                {
                    cmbdept.Enabled = false;
                    
                    errorProvider1.Clear();
                }
                else
                {
                    cmbdept.Text = " ";
                }
            }
            else {

            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public class UpdateEventArgs : EventArgs
        {
            public string Data { get; set; }
        }

        protected void raiseUpdate ()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler?.Invoke(this, args);
        }

        private void cmbusertype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbusertype.SelectedIndex == 0) //USERNAME
            {
                cmbdept.Enabled = false;
                errorProvider1.Clear();
            }
            else if (cmbusertype.SelectedIndex == 2) //USERNAME
            {
                cmbdept.Enabled = false;
                errorProvider1.Clear();
            }
            else
            {
                cmbdept.Enabled = true;
                cmbdept.Text = " ";
                errorProvider1.Clear();
            }
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cmbdept_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
    }
        }


