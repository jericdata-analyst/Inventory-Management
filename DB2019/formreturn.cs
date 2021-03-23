using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB2019
{
    public partial class formreturn : Form
    {
        public formreturn(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        string username;

        Class1 Account = new Class1("127.0.0.1", "cp3", "test", "12345");

        private void formreturn_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = Account.GetData("select * from tblactivity order by date desc");

                dataGridView1.DataSource = dt;
                refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            label4.Text = username;
            label2.Text = DateTime.Now.ToLongDateString();
        }
        public void refresh()
        {
            try
            {
                DataTable dt = Account.GetData("SELECT * FROM `tblactivity` order by date desc");
                dataGridView1.Columns["date"].Visible = false;
                dataGridView1.DataSource = dt;    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string selected_user; //del, act, deac, 
        int selected_row; // update

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

       //int row, last;
      //  string bilang, activity, borrowformno, equipid;

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            if (selected_user == null)
            {
                MessageBox.Show("Select Activity");
            }
            else
            {
                try
                {

                    DataTable dt = Account.GetData("select * FROM equipment_borrowed WHERE activity_id = '" + selected_user + "'");

                    for (int x = 0; x < dt.Rows.Count; x++)
                    {
                        string a = dt.Rows[x].Field<string>("equipment_id");


                        Account.executeSQL("UPDATE equipment_borrowed SET date_released = '" + DateTime.Now.ToString() + " ' WHERE equipment_id = '" + a + "'");
                    }

                    Account.executeSQL("update tblactivity set date_released = '" + DateTime.Now.ToString() + "' WHERE id = '" + selected_user + "' ");
                    Account.executeSQL("update tblactivity set released_by = '" + username + "' WHERE id = '" + selected_user + "' ");
                    if (Account.rowAffected > 0)    
                    {

                        MessageBox.Show("Equipments Released", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Account.executeSQL("INSERT INTO tbllogs VALUES ('" + DateTime.Now.ToString() +
                                    "' , 'Released an activity with an id of:' '" + selected_user + "' , '" + username + "' , 'Borrowing Management ')");

                        refresh();

                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

       
        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable dt = Account.GetData("select * FROM equipment_borrowed WHERE activity_id = '" + selected_user + "'");

                string lol = dt.Rows[7].Field<string>("date_released");
            
                if (lol == string.Empty)
                
                {
                    MessageBox.Show("You can't return item if it is not already released!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    for (int x = 0; x < dt.Rows.Count; x++)
                    {
                        string a = dt.Rows[x].Field<string>("equipment_id");

                        Account.executeSQL("UPDATE tblequipments SET available = 'YES' WHERE asset_number = '" + a + "'");
                        Account.executeSQL("UPDATE equipment_borrowed SET date_return = '" + DateTime.Now.ToString() + " ' WHERE equipment_id = '" + a + "'");
                    }

                    Account.executeSQL("update tblactivity set date_return = '" + DateTime.Now.ToString() + "' WHERE id = '" + selected_user + "' ");
                    Account.executeSQL("update tblactivity set return_by = '" + username + "' WHERE id = '" + selected_user + "' ");
                    // Account.executeSQL("DELETE FROM equipment_borrowed WHERE activity_id = '" + selected_user + "'");

                    if (Account.rowAffected > 0)
                    {

                        MessageBox.Show("Equipments Returned", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Account.executeSQL("INSERT INTO tbllogs VALUES ('" + DateTime.Now.ToString() +
                                    "' , 'Return an activity with an id of:' '" + selected_user + "' , '" + username + "' , 'Borrowing Management ')");

                        refresh();

                    }

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }


        //private void dataGridView1_CellLeave_1(object sender, DataGridViewCellEventArgs e)
        //{

        //    if (e.ColumnIndex == 8 || e.ColumnIndex == 9)
        //    {

        //        if (dataGridView1.CurrentCell.Value == null ||
        //            dataGridView1.CurrentCell.Value == DBNull.Value ||
        //            String.IsNullOrWhiteSpace(dataGridView1.CurrentCell.Value.ToString()))
        //        {
        //            MessageBox.Show("You must release item first");
        //        }
        //    }
        //}
    }

}
