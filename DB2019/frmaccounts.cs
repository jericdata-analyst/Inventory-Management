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
    public partial class frmaccounts : Form
    {
        public frmaccounts(string user)
        {
            InitializeComponent();
            this.user = user;
        }



        string user;
        Class1 Account = new Class1("127.0.0.1", "cp3", "test", "12345");

        private void frmaccounts_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = Account.GetData("select * from tblaccounts order by username");

                dataGridView1.DataSource = dt;

                dataGridView1.Refresh();
                dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);


               //dataGridView1.Columns[].Visible = false ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            timer1.Start();
            label4.Text = DateTime.Now.ToLongDateString();
            label3.Text = DateTime.Now.ToLongTimeString();

            cmbusertype.Visible = false;
            cmbstatus.Visible = false;
            cmbdept.Visible = false;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            frmaddaccount addaccount = new frmaddaccount("", "", "", "", "add", user);
            addaccount.UpdateEventHandler += F2_UpdateEventHandler1;
            addaccount.Show();

        }

        private void cmbusertype_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbusertype.SelectedIndex == 0)
                {
                    DataTable dt = Account.GetData("select * from tblaccounts WHERE user_type = 'administrator' ORDER BY username");
                    dataGridView1.DataSource = dt;
                }
                else if (cmbusertype.SelectedIndex == 1)
                {
                    DataTable dt = Account.GetData("select * from tblaccounts WHERE user_type = 'technical' ORDER BY username");
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    DataTable dt = Account.GetData("select * from tblaccounts WHERE user_type = 'user' ORDER BY username");
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

        }

        private void cmbstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbstatus.SelectedIndex == 0)
                {
                    DataTable dt = Account.GetData("select * from tblaccounts WHERE status = 'active' ORDER BY username");
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    DataTable dt = Account.GetData("select * from tblaccounts WHERE status = 'inactive' ORDER BY username");
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void txtvalue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = Account.GetData("select * from tblaccounts WHERE username LIKE '%" + txtvalue.Text + "%' ORDER BY username");
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        string selecteduser; //delete,activate,deactivate
        int selectedrow;//update

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedrow = e.RowIndex;
                selecteduser = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void cmbsearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbsearch.SelectedIndex == 0) //USERNAME
            {
                txtvalue.Visible = true;
                cmbstatus.Visible = false;
                cmbusertype.Visible = false;
                cmbdept.Visible = false;
                txtvalue.Focus();
            }
            else if (cmbsearch.SelectedIndex == 1) //USERTYPE
            {
                txtvalue.Visible = false;
                cmbstatus.Visible = false;
                cmbusertype.Visible = true;
                cmbdept.Visible = false;
                cmbsearch.Focus();
            }
            else if (cmbsearch.SelectedIndex == 2)
            {
                txtvalue.Visible = false; //STATUS
                cmbstatus.Visible = true;
                cmbusertype.Visible = false;
                cmbdept.Visible = false;
                cmbstatus.Focus();
            }
            else
            {
                txtvalue.Visible = false; //dept
                cmbstatus.Visible = false;
                cmbusertype.Visible = false;
                cmbdept.Visible = true;
                cmbdept.Focus();
            }
        }

        private void btnactivate_Click(object sender, EventArgs e)
        {
            try
            {
                Account.executeSQL("UPDATE tblaccounts SET status = 'active' WHERE username = '" + selecteduser + "'");

                if (Account.rowAffected > 0)
                {
                    MessageBox.Show("Account activate", " Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Account.executeSQL("INSERT INTO tbllogs VALUES ('" + DateTime.Now.ToString() +
                        "' , 'Activate a user with username of " + selecteduser + "', '" + user + "','Accounts Management')");

                    DataTable dt = Account.GetData("select * from tblaccounts order by username");

                    dataGridView1.DataSource = dt;

                    dataGridView1.Refresh();
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btndeactivate_Click(object sender, EventArgs e)
        {
            try
            {
                Account.executeSQL("UPDATE tblaccounts SET status = 'inactive' WHERE username = '" + selecteduser + "'");

                if (Account.rowAffected > 0)
                {

                    MessageBox.Show("Account Deactivate", " Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Account.executeSQL("INSERT INTO tbllogs VALUES ('" + DateTime.Now.ToString() +

                        "' , 'deactivate a user with username of " + selecteduser + "', '" + user + "','Accounts Management')");

                    DataTable dt = Account.GetData("select * from tblaccounts order by username");
                    dataGridView1.DataSource = dt;

                    dataGridView1.Refresh();
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (user == selecteduser)
                {
                    MessageBox.Show("You Can't Delete Your Own Account", "Message", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                }
                else
                {


                    Account.executeSQL("Delete From tblaccounts WHERE username = '" + selecteduser + "'");
                    if (Account.rowAffected > 0)
                    {
                        MessageBox.Show("Account Deleted", "Message", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);

                        Account.executeSQL("INSERT INTO tbllogs VALUES('" + DateTime.Now.ToString() +
                            "','Deleted a user with username of " + selecteduser + "','" + user +
                        "','Accounts Management')");

                        DataTable dt = Account.GetData("select * from tblaccounts order by username");
                        dataGridView1.DataSource = dt;

                        dataGridView1.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            try
            {

                string username, password,usertype, department;
                username = dataGridView1.Rows[selectedrow].Cells[0].Value.ToString();
                password = dataGridView1.Rows[selectedrow].Cells[1].Value.ToString();
                usertype = dataGridView1.Rows[selectedrow].Cells[2].Value.ToString();
                department = dataGridView1.Rows[selectedrow].Cells[3].Value.ToString();
                frmaddaccount edit = new frmaddaccount(username, password, usertype, department, "edit", user);
                edit.UpdateEventHandler += F2_UpdateEventHandler1;
                edit.Text = "Edit Account";
                edit.Show();

                //DataTable dt = Account.GetData("select * from tblaccounts order by username");
                //dataGridView1.DataSource = dt;
                //dataGridView1.Refresh();
               // LoadDataGrid();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();

        }

        private void F2_UpdateEventHandler1(object sender, frmaddaccount.UpdateEventArgs args)
        {
            LoadDataGrid();       
        }
        
        private void LoadDataGrid()
        {
            DataTable dt = Account.GetData("SELECT * FROM tblaccounts ORDER BY username DESC");
            dataGridView1.DataSource = dt;
        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = Account.GetData("select * from tblaccounts order by username");

            dataGridView1.DataSource = dt;

            dataGridView1.Refresh();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //this.dataGridView1.Columns[0].Visible = false;
        }

        private void cmbdept_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbusertype.SelectedIndex == 0)
                {
                    DataTable dt = Account.GetData("select * from tblaccounts WHERE department= 'Computer Science' ORDER BY username");
                    dataGridView1.DataSource = dt;
                }
                else if (cmbdept.SelectedIndex == 1)
                {
                    DataTable dt = Account.GetData("select * from tblaccounts WHERE department = 'Education' ORDER BY username");
                    dataGridView1.DataSource = dt;
                }
                else if (cmbdept.SelectedIndex == 2)
                {
                    DataTable dt = Account.GetData("select * from tblaccounts WHERE department= 'Bussines Administration' ORDER BY username");
                    dataGridView1.DataSource = dt;
                }
                else if (cmbdept.SelectedIndex == 3)
                {
                    DataTable dt = Account.GetData("select * from tblaccounts WHERE department = 'BS Accountancy' ORDER BY username");
                    dataGridView1.DataSource = dt;
                }
                else if (cmbdept.SelectedIndex == 4)
                {
                    DataTable dt = Account.GetData("select * from tblaccounts WHERE department = 'Political Science' ORDER BY username");
                    dataGridView1.DataSource = dt;
                }
                else if (cmbdept.SelectedIndex == 5)
                {
                    DataTable dt = Account.GetData("select * from tblaccounts WHERE department = 'Radtech' ORDER BY username");
                    dataGridView1.DataSource = dt;
                }
                else if (cmbdept.SelectedIndex == 6)
                {
                    DataTable dt = Account.GetData("select * from tblaccounts WHERE department = 'AB Psychology' ORDER BY username");
                    dataGridView1.DataSource = dt;
                }
                else if (cmbdept.SelectedIndex == 7)
                {
                    DataTable dt = Account.GetData("select * from tblaccounts WHERE department = 'AB Psychology' ORDER BY username");
                    dataGridView1.DataSource = dt;
                }
                else if (cmbdept.SelectedIndex == 8)
                {
                    DataTable dt = Account.GetData("select * from tblaccounts WHERE department = 'BS Psychology' ORDER BY username");
                    dataGridView1.DataSource = dt;
                }
                else if (cmbdept.SelectedIndex == 9)
                {
                    DataTable dt = Account.GetData("select * from tblaccounts WHERE department = 'Midwifery' ORDER BY username");
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    //code here
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
           
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.Value != null)

            {

                // set the exact display value

                e.Value = new String('*', e.Value.ToString().Length);

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }
    
    

