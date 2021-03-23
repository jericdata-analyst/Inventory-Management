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
    public partial class form_borrow : Form
    {
        public form_borrow(string activity_id, string date, string username, string dept, string actv_name, string actv_date, string actv_purpose, string action)
        {
            InitializeComponent();
            this.activity_id = activity_id;
            this.date = date;
            this.username = username;
            this.dept = dept;
            this.actv_name = actv_name;
            this.actv_date = actv_date;
            this.actv_purpose = actv_purpose;
            this.action = action;
            //this.model = model;
        }

        string activity_id, date, username, dept, actv_name, actv_date, actv_purpose, action;




        private void button1_Click(object sender, EventArgs e)
        {
            refresh();
        }
       
        
        private void button2_Click(object sender, EventArgs e)
        {


            if (selected_user == null)
            {
                MessageBox.Show("please select any of equipments");
            }
            else
            {

                try
                {
                    Account.executeSQL("UPDATE tblequipments SET available = 'NO' WHERE asset_number = '" + selected_user + "'");
                    Account.executeSQL("INSERT INTO equipment_borrowed  VALUES ('" + activity_id + "', '" + selected_user + "' , '" + selected_model + "' ,'', '')");


                    if (Account.rowAffected > 0)
                    {
                   refresh();
                   
                    }
                refresh();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
           }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Account.executeSQL("UPDATE tblequipments SET available = 'YES' WHERE asset_number = '" + selected_user + "'");
                Account.executeSQL("DELETE FROM equipment_borrowed WHERE equipment_id = '" + selected_user + "'");

                if (Account.rowAffected > 0)
               {
                    refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = Account.GetData("SELECT asset_number, branch, model FROM tblequipments WHERE model = '" + comboBox1.SelectedItem.ToString() + "'");
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();

            //frmaddborrow activity = new frmaddborrow(username,dept);
           // activity.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {

                if (action == "add")
                {
                    Account.executeSQL("INSERT INTO tblactivity VALUES ('" + activity_id + "' , '" + date + "' , '" + username + "' , '" + dept + "' , '" + actv_name + "' , '" + actv_date + "' , '" + actv_purpose + "','','','','')");

                    if (Account.rowAffected > 0)
                    {
                        MessageBox.Show("Activity  Saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Account.executeSQL("INSERT INTO tbllogs VALUES ('" + DateTime.Now.ToString() +
                            "' , 'Added an Activity with an id of : " + activity_id + "' , '" + username + "' , 'Borrowing Management')");
                        this.Hide();

                        frmaddborrow exit = new frmaddborrow(username, dept);
                        exit.Close();
                        //refresh datagrid
                        formactivity add = (formactivity)Application.OpenForms["formactivity"];
                        add.refresh();
                        refresh();
                    }
                }
            

            else if (action == "edit")
            {

                MessageBox.Show("Activity Updated!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Account.executeSQL("INSERT INTO tbllogs VALUES ('" + DateTime.Now.ToString() + "' ,'Updated an activity with an id of-" + activity_id + "' , '3' ,'Borrowing Management ')");
                this.Hide();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }






        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        Class1 Account = new Class1("127.0.0.1", "cp3", "test", "12345");

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            refresh();
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

        private void label2_Click(object sender, EventArgs e)
        {
           
        }
        

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            button2.Enabled = false;
            dataGridView1.ClearSelection();
        }
        
        private void form_borrow_Load(object sender, EventArgs e)
        {
            if (action == "add")
            {
                button5.Visible = true;
                //button4.Visible = false;
            }
            label2.Text = username;
            
            refresh();
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
        }
         
        string selected_user,selected_model; //del, act, deac, 
        int selected_row;// update

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button2.Enabled = true;
            try
            {
                selected_row = e.RowIndex;
                selected_model = dataGridView1.Rows[selected_row].Cells[2].Value.ToString();
                selected_row = e.RowIndex;
                selected_user = dataGridView1.Rows[selected_row].Cells[0].Value.ToString();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //AYAN LANG YUN CODES KO DYAN CJ ISISINGIT LANG SA ISANG STRING PAPUNT SA DATA GRID VIEW2

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                try
                {
                    selected_row = e.RowIndex;
                    selected_user = dataGridView2.Rows[selected_row].Cells[1].Value.ToString();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

       
        public void refresh()
        {

            try
            {

                DataTable dt = Account.GetData("SELECT asset_number, branch, model FROM `tblequipments` where available = 'YES' order by asset_number");
                dataGridView1.DataSource = dt;

                DataTable dt2 = Account.GetData("SELECT * FROM `equipment_borrowed` where activity_id = '" + activity_id + "' order by equipment_id");
                //DataTable dt2 = Account.GetData("SELECT asset_number , branch , model FROM `tblequipments` where available = 'NO' order by asset_number");

                dataGridView2.DataSource = dt2;
                dataGridView2.Columns["date_released"].Visible = false;
                dataGridView2.Columns["date_return"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
         
    }
}
 