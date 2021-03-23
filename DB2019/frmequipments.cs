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

    public partial class frmequipments : Form
    {
        public frmequipments(string user)
        {
            InitializeComponent();
            this.user = user;
        }

        
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();


        string user;
        int row=0;

        Class1 equip = new Class1("127.0.0.1", "cp3", "test", "12345");

        private void F2_UpdateEventHandler1(object sender, frmaddequipments.UpdateEventArgs args)
        {
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            DataTable dt = equip.GetData("SELECT * FROM tblequipments ORDER BY asset_number DESC");
            dataGridView1.DataSource = dt;
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void frmequipments_Load(object sender, EventArgs e)
        {

            {

                try
                {
                    DataTable dt = equip.GetData("select * from tblequipments order by serial_number desc");

                    dataGridView1.DataSource = dt;

                    dataGridView1.Refresh();
                    //dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
  
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                labelvalue.Visible = false;
                cmbavailable.Visible = false;
                cmbstatus.Visible = false;
                cmbSearchBranch.Visible = false;
                cmbSearchModel.Visible = false;
                txtSearchAsset.Visible = false;
                txtSearchSerial.Visible = false;

                cmbsearch.Focus();
            }
            {
               
            }
        }

        string selected_user; //del, act, deac, 
        int selected_row; // update

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {

                equip.executeSQL("Delete From tblequipments WHERE asset_number = '" + selected_user + "'");
                if (equip.rowAffected > 0)
                {
                    MessageBox.Show("Equipment Deleted", "Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);

                    equip.executeSQL("INSERT INTO tbllogs VALUES('" + DateTime.Now.ToString() +
                        "','Deleted a equipments with asset_number:" + selected_user + "','" + user +
                    "','Equipments Management')");

                    // DataTable dt = equip.GetData("select * from tblaccounts order by username");
                    // dataGridView1.DataSource = dt;

                    refresh();

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DataTable dt = equip.GetData("select * from tblequipments order by asset_number desc");
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selected_row = e.RowIndex;
                selected_user = dataGridView1.Rows[selected_row].Cells[0].Value.ToString();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //refreshhhh
            DataTable dt = equip.GetData("select * from tblequipments order by asset_number desc");
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }


        public void refresh()
        {
            try
            {
                DataTable dt = equip.GetData("SELECT * FROM `tblequipments` ");
                dataGridView1.DataSource = dt;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }



        private void btnadd_Click(object sender, EventArgs e)
        {

            frmaddequipments form_add_equipment = new frmaddequipments("", "", "", "", "", "","", user, "add");
            form_add_equipment.UpdateEventHandler += F2_UpdateEventHandler1;
            form_add_equipment.Show();
           
        }

    
        private void btnedit_Click(object sender, EventArgs e)
        {
            try
            { 
                string asset_number, serial_number, branch, model, desc, status, available;
                asset_number = dataGridView1.Rows[selected_row].Cells[0].Value.ToString();
                serial_number = dataGridView1.Rows[selected_row].Cells[1].Value.ToString();
                model = dataGridView1.Rows[selected_row].Cells[2].Value.ToString();
                desc = dataGridView1.Rows[selected_row].Cells[3].Value.ToString();
                branch = dataGridView1.Rows[selected_row].Cells[4].Value.ToString();
                status = dataGridView1.Rows[selected_row].Cells[5].Value.ToString();
                available = dataGridView1.Rows[selected_row].Cells[6].Value.ToString();
                frmaddequipments edit = new frmaddequipments(asset_number, serial_number, branch, model, desc, status, available, user,"update");
                edit.UpdateEventHandler += F2_UpdateEventHandler1;
                edit.Show();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbsearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbsearch.SelectedIndex == 0) //STATUS
            {
                labelvalue.Visible = true;

                cmbavailable.Visible = false;
                cmbstatus.Visible = true;
                cmbSearchBranch.Visible = false;
                cmbSearchModel.Visible = false;
                txtSearchAsset.Visible = false;
                txtSearchSerial.Visible = false;

                cmbsearch.Focus();
            }
            else if (cmbsearch.SelectedIndex == 1) //AVAILABLE
            {
                labelvalue.Visible = true;

                cmbavailable.Visible = true;
                cmbstatus.Visible = false;
                cmbSearchBranch.Visible = false;
                cmbSearchModel.Visible = false;
                txtSearchAsset.Visible = false;
                txtSearchSerial.Visible = false;

                cmbsearch.Focus();

            }
            else if (cmbsearch.SelectedIndex == 2) //BRANCH
            {
                labelvalue.Visible = true;

                cmbavailable.Visible = false;
                cmbstatus.Visible = false;
                cmbSearchBranch.Visible = true;
                cmbSearchModel.Visible = false;
                txtSearchAsset.Visible = false;
                txtSearchSerial.Visible = false;

                cmbsearch.Focus();
            }

            else if (cmbsearch.SelectedIndex == 3) //Model
            {
                labelvalue.Visible = true;

                cmbavailable.Visible = false;
                cmbstatus.Visible = false;
                cmbSearchBranch.Visible = false;
                cmbSearchModel.Visible = true;
                txtSearchAsset.Visible = false;
                txtSearchSerial.Visible = false;

                cmbsearch.Focus();
            }
            else if (cmbsearch.SelectedIndex == 4) //serial
            {
                labelvalue.Visible = true;

                cmbavailable.Visible = false;
                cmbstatus.Visible = false;
                cmbSearchBranch.Visible = false;
                cmbSearchModel.Visible = false;
                txtSearchAsset.Visible = false;
                txtSearchSerial.Visible = true;
                
                cmbsearch.Focus();
            }
            else if (cmbsearch.SelectedIndex == 5) //asset
            {
                labelvalue.Visible = true;

                cmbavailable.Visible = false;
                cmbstatus.Visible = false;
                cmbSearchBranch.Visible = false;
                cmbSearchModel.Visible = false;
                txtSearchAsset.Visible = true;
                txtSearchSerial.Visible = false;

                cmbsearch.Focus();
            }
        }

        private void cmbavailable_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbavailable.SelectedIndex == 0)
                {
                    DataTable dt = equip.GetData("select * from tblequipments WHERE available= 'yes' ORDER BY serial_number");
                    dataGridView1.DataSource = dt;
                }
                else if (cmbavailable.SelectedIndex == 1)
                {
                    DataTable dt = equip.GetData("select * from tblequipments WHERE available = 'no' ORDER BY serial_number");
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

        private void cmbstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbstatus.SelectedIndex == 0)
            {
                DataTable dt = equip.GetData("select * from tblequipments WHERE status= 'working' ORDER BY serial_number");
                dataGridView1.DataSource = dt;
            }
            else if (cmbstatus.SelectedIndex == 1)
            {
                DataTable dt = equip.GetData("select * from tblequipments WHERE status = 'repair' ORDER BY serial_number");
                dataGridView1.DataSource = dt;
            }
            else if (cmbstatus.SelectedIndex == 2)
            {
                DataTable dt = equip.GetData("select * from tblequipments WHERE status = 'retire' ORDER BY serial_number");
                dataGridView1.DataSource = dt;
            }

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.Value != null)

            {
                dataGridView1.Columns[4].Visible = false;
                // set the exact display value

                

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

        private void cmbSearchBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbSearchBranch.SelectedIndex == 0)
                {
                    DataTable dt = equip.GetData("select * from tblequipments WHERE branch = 'Mabini ' ORDER BY serial_number");
                    dataGridView1.DataSource = dt;
                }
                else if (cmbSearchBranch.SelectedIndex == 1)
                {
                    DataTable dt = equip.GetData("select * from tblequipments WHERE branch = 'PSG' ORDER BY serial_number");
                    dataGridView1.DataSource = dt;
                }
                else if (cmbSearchBranch.SelectedIndex == 2)
                {
                    DataTable dt = equip.GetData("select * from tblequipments WHERE branch = 'PLA' ORDER BY serial_number");
                    dataGridView1.DataSource = dt;
                }
                else if (cmbSearchBranch.SelectedIndex == 3)
                {
                    DataTable dt = equip.GetData("select * from tblequipments WHERE branch = 'LEG' ORDER BY serial_number");
                    dataGridView1.DataSource = dt;
                }
                else if (cmbSearchBranch.SelectedIndex == 4)
                {
                    DataTable dt = equip.GetData("select * from tblequipments WHERE branch = 'ABAD' ORDER BY serial_number");
                    dataGridView1.DataSource = dt;
                }
                else if (cmbSearchBranch.SelectedIndex == 5)
                {
                    DataTable dt = equip.GetData("select * from tblequipments WHERE branch = 'JRC' ORDER BY serial_number");
                    dataGridView1.DataSource = dt;
                }
                else if (cmbSearchBranch.SelectedIndex == 6)
                {
                    DataTable dt = equip.GetData("select * from tblequipments WHERE branch = 'EEC' ORDER BY serial_number");
                    dataGridView1.DataSource = dt;
                }
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void cmbSearchModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbSearchModel.SelectedIndex == 0)
                {
                    DataTable dt = equip.GetData("select * from tblequipments WHERE model = ' laptop' ORDER BY serial_number desc");
                    dataGridView1.DataSource = dt;
                }
                else if (cmbSearchModel.SelectedIndex == 1)
                {
                    DataTable dt = equip.GetData("select * from tblequipments WHERE model = 'Projector' ORDER BY serial_number desc");
                    dataGridView1.DataSource = dt;
                }
                else if (cmbSearchModel.SelectedIndex == 2)
                {
                    DataTable dt = equip.GetData("select * from tblequipments WHERE model = 'Monitor' ORDER BY serial_number desc");
                    dataGridView1.DataSource = dt;
                }
                else if (cmbSearchModel.SelectedIndex == 3)
                {
                    DataTable dt = equip.GetData("select * from tblequipments WHERE model = 'CPU' ORDER BY serial_number desc");
                    dataGridView1.DataSource = dt;
                }
                else if (cmbSearchModel.SelectedIndex == 4)
                {
                    DataTable dt = equip.GetData("select * from tblequipments WHERE model = 'Printer' ORDER BY serial_number desc");
                    dataGridView1.DataSource = dt;
                }
                else if (cmbSearchModel.SelectedIndex == 5)
                {
                    DataTable dt = equip.GetData("select * from tblequipments WHERE model = 'Mouse' ORDER BY serial_number desc ");
                    dataGridView1.DataSource = dt;
                }
                else if (cmbSearchModel.SelectedIndex == 6)
                {
                    DataTable dt = equip.GetData("select * from tblequipments WHERE model = Keyboard' ORDER BY serial_number desc");
                    dataGridView1.DataSource = dt;
                }
                else
                { 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void txtSearchAsset_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = equip.GetData("select * from tblequipments WHERE asset_number LIKE '%" + txtSearchAsset.Text + "%' ORDER BY asset_number desc");
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void txtSearchSerial_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = equip.GetData("select * from tblequipments WHERE serial_number LIKE '%" + txtSearchSerial.Text + "%' ORDER BY serial_number desc");
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
    }