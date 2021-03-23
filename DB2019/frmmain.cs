using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DB2019
{
    public partial class frmmain : Form
    {
        string user, usertype, password;

        public frmmain(string user, string usertype, string password)
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = "Username: " + user;
            toolStripStatusLabel2.Text = "User Type: " + usertype;
           
            this.user = user;
            this.usertype = usertype;
            this.password = password;
            this.username = user;
            

        }
        string  dept,username;
       
        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmaccounts account = new frmaccounts(user);
            //account.MdiParent = this;
            account.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

		private void monitoringToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmlogin login = new frmlogin();
           
            frmequipments eq = new frmequipments(user );
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmlogs logs = new frmlogs(user,usertype);
            //account.MdiParent = this;
            logs.Show();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void borrowingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formreturn form_return = new formreturn(username);
            form_return.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void returnReleaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formreturn form_return = new formreturn(username);
            form_return.Show();
        }

        private void equipmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmequipments frmequipments = new frmequipments(user);
            frmequipments.Show();

        }

        private void fileManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void logsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmlogs logs = new frmlogs(user, usertype);
            logs.Show();
        }

        private void changePass_Click(object sender, EventArgs e)
        {
            

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            Application.Restart();
        }

        private void borrowingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            formactivity form_activity = new formactivity(username,dept);
            form_activity.Show();

        }
        
        private void changePass_Click_1(object sender, EventArgs e)
        {
            change_Pass addaccount = new change_Pass(user, password);
            addaccount.Show();
        }

        private void frmmain_Load(object sender, EventArgs e)
        {
            if(usertype == "User")
            {
                fileManagementToolStripMenuItem.Visible = false;
				
				logsToolStripMenuItem.Visible = true;
                accountsToolStripMenuItem.Visible = false;
                changePass.Visible = true;
                exitToolStripMenuItem.Visible = true;
                borrowingToolStripMenuItem1.Visible = true;
               

            }
            else if(usertype == "Technical")
            {
                accountsToolStripMenuItem.Visible = false;
                equipmentsToolStripMenuItem.Visible = true;
                borrowingToolStripMenuItem1.Visible = false;
                logsToolStripMenuItem.Visible = true;
                changePass.Visible = false;
               
                exitToolStripMenuItem.Visible = true;

            }
            else if(usertype == "Administrator")
            {
                fileManagementToolStripMenuItem.Visible = true;
                borrowingToolStripMenuItem1.Visible = false;
				logsToolStripMenuItem.Visible = true;
                changePass.Visible = false;
                exitToolStripMenuItem.Visible = true;
              

            }
        }
    }
}
