using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DB2019
{
    public partial class change_Pass : Form
    {
        public change_Pass(string user,string password)
        {
            InitializeComponent();
            this.user = user;
            this.password = password;
            
        }
        string user;

        Class1 Account = new Class1("127.0.0.1", "cp3", "test", "12345");

        private void button1_Click(object sender, EventArgs e)
        {
            txtconfirm.Clear();
            txtpassword.Clear();
            label7.Visible = false;
            txtboxOldPassword.Clear();
        }

        int error = 0;

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                    validate();
                    if (error == 0)
                    {
                        //string status = "active";
                        Account.executeSQL(" update tblaccounts set password = '" + txtpassword.Text + "' where username = '" + user + "'");

                        MessageBox.Show(" Account updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Account.executeSQL("INSERT INTO tbllogs VALUES ('" + DateTime.Now.ToString() +
                            "' ,' Changed password ','"+user+"' , 'Accounts Management' )");

                        this.Hide();

                    }  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void change_Pass_Load(object sender, EventArgs e)
        {
            txtusername.Text = user;
             txtusername.Enabled = false;
           // label8.Text = password;
            label7.Visible = false;
            
        }

        void validate()
        {
            errorProvider1.Clear();
            error = 0;
            
             if (string.IsNullOrEmpty(txtpassword.Text))
            {
                errorProvider1.SetError(txtpassword, "Password is empty");
                error++;
            }
            else if (txtpassword.TextLength < 6)
            {
                errorProvider1.SetError(txtpassword, "Password length should be greater than 6");
                error++;
            }
            else if (string.IsNullOrEmpty(txtconfirm.Text))
            {
                errorProvider1.SetError(txtconfirm, "Password is empty");
                error++;
            }
            else if (txtconfirm.TextLength < 6)
            {
                errorProvider1.SetError(txtconfirm, "Password length should be greater than 6");
                error++;
            }
            else if (txtpassword.Text != txtconfirm.Text)
            {
                errorProvider1.SetError(txtconfirm, "Password not Match");
                error++;
            }

             else if (password != txtboxOldPassword.Text)
            {
                errorProvider1.SetError(txtboxOldPassword, "Old Password not Match");
                error++;
            }
            else
            {
                error = 0;
            }
        }
        

        private void txtconfirm_KeyUp(object sender, KeyEventArgs e)
        {
            label7.Text = "";

            if (txtpassword.Text == txtconfirm.Text)
            {
                label7.ForeColor = System.Drawing.Color.Green;
                label7.Visible = true;
                label7.Text = "Password Are Matched";
            }
            else
            {
                label7.ForeColor = System.Drawing.Color.Red;
                label7.Visible = true;
                label7.Text = "Password Are Not Matched";
            }
        }
        string password;

        private void txtboxOldPassword_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            txtpassword.UseSystemPasswordChar = false;
            txtconfirm.UseSystemPasswordChar = false;
            txtboxOldPassword.UseSystemPasswordChar = false;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            txtpassword.UseSystemPasswordChar = true;
            txtconfirm.UseSystemPasswordChar = true;
            txtboxOldPassword.UseSystemPasswordChar = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
