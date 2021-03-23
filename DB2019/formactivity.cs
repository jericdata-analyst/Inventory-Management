using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DB2019
{
    public partial class formactivity : Form
    {
        public formactivity(string username, string dept)
        {
            InitializeComponent();
            this.username = username;
        }

        string username;

        Class1 Account = new Class1("127.0.0.1", "cp3", "test", "12345");

        private void formactivity_Load(object sender, EventArgs e)
        {

            DataTable dt = Account.GetData("SELECT * FROM `tblactivity` order by date desc ");
            dataGridView1.DataSource = dt;
            label2.Visible = false;

            txtAct_ID.Visible = false;
            txt_Requestor.Visible = false;
            dateTimePicker1.Visible = false;
            dataGridView1.Columns[0].Width = 75;
            refresh();
        }
        public void refresh()
        {
            try
            {
                DataTable dt = Account.GetData("SELECT * FROM `tblactivity` order by date desc ");
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["date_released"].Visible = false;
                dataGridView1.Columns["date_return"].Visible = false;
                dataGridView1.Columns["released_by"].Visible = false;
                dataGridView1.Columns["return_by"].Visible = false;
                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            DataTable dt = Account.GetData("select * from tblaccounts where username = '" + username + "' ");
            string dept = dt.Rows[0].Field<string>("department");

            frmaddborrow formaddborrow = new frmaddborrow(username, dept);
            formaddborrow.Show();
        }


        string selected_user; //del, act, deac, 
        int selected_row; // update

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        int row, last;

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = Account.GetData("select * FROM equipment_borrowed WHERE activity_id = '" + selected_user + "'");

                for (int x = 0; x < dt.Rows.Count; x++)
                {
                    string a = dt.Rows[x].Field<string>("equipment_id");
                    Account.executeSQL("UPDATE tblequipments SET available = 'YES' WHERE asset_number = '" + a + "'");
                }

                Account.executeSQL("DELETE FROM tblactivity WHERE id = '" + selected_user + "'");
                Account.executeSQL("DELETE FROM equipment_borrowed WHERE activity_id = '" + selected_user + "'");

                if (Account.rowAffected > 0)
                {
                    MessageBox.Show("activity Deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Account.executeSQL("INSERT INTO tbllogs VALUES ('" + DateTime.Now.ToString() +
                                "' , 'Deleted an activity with an id of " + selected_user + "' , '"+username+ "','Borrowing Management ')");

                    refresh();

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            refresh();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cmbsearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbsearch.SelectedIndex == 0) //STATUS
            {
                label2.Visible = true;

                txtAct_ID.Visible = true;
                txt_Requestor.Visible = false;
                dateTimePicker1.Visible = false;

                cmbsearch.Focus();
            }
            if (cmbsearch.SelectedIndex == 1) //AVAILABLE
            {
                //labelvalue.Visible = true;
                label2.Visible = true;
                txtAct_ID.Visible = false;
                txt_Requestor.Visible = true;
                dateTimePicker1.Visible = false;

                cmbsearch.Focus();

            }
            if (cmbsearch.SelectedIndex == 2)//BRANCH
            {
                //labelvalue.Visible = true;
                label2.Visible = true;
                txtAct_ID.Visible = false;
                txt_Requestor.Visible = false;
                dateTimePicker1.Visible = true;

                cmbsearch.Focus();
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (selected_user == null)
            {
                MessageBox.Show("Please select an Activity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dataGridView1.ClearSelection();
            }
            else
            {

                form_borrow form_borrow = new form_borrow(selected_user, username, "", "", "", "", "", "edit");
                form_borrow.Show();
            }
        }

        private void txtAct_ID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = Account.GetData("select * from tblactivity WHERE activity_name LIKE '%" + txtAct_ID.Text + "%' ORDER BY id");
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void txt_Requestor_TextChanged(object sender, EventArgs e)
        {

            try
            {
                DataTable dt = Account.GetData("select * from tblactivity WHERE requestor LIKE '%" + txt_Requestor.Text + "%' ORDER BY requestor");
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DataTable dt = Account.GetData("select * from tblactivity WHERE date LIKE '%" + dateTimePicker1.Text + "%' ORDER BY date");
            dataGridView1.DataSource = dt;
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
    }
}
