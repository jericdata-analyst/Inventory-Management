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
    public partial class frmaddequipments : Form
    {
        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;

        Class1 Account = new Class1("127.0.0.1", "cp3", "test", "12345");


        public frmaddequipments(string asset_number, string serial_number, string branch, string model, string desc, string status, string available, string username, string action)
        {
            InitializeComponent();

            this.asset_number = asset_number;
            this.serial_number = serial_number;
            this.branch = branch;
            this.model = model;
            this.desc = desc;
            this.status = status;
            this.available = available;
            this.username = username;
            this.action = action;


        }
        string asset_number, serial_number, branch, model, desc, status, available, username, action, asset_format;

        private void button4_Click(object sender, EventArgs e)
        {
            
            
            txtb_serial.Clear();
            cmb_available.Text=" ";
            cmb_branch.Text= " ";
            txtb_desc.Clear();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cmb_model_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtb_serial_TextChanged(object sender, EventArgs e)
        {

        }

       

        int error = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            {
                asset_format = "AU-" + cmb_branch.Text + DateTime.Now.ToString("-yyyy-MM-") + txtb_serial.Text;
                try
                {
                    validate();
                    if (action == "add")
                    {
                        if (error == 0)
                        {
                            Account.executeSQL("INSERT INTO tblequipments VALUES ('" + asset_format + "' ,'" + txtb_serial.Text + "' , '" + cmb_model.Text + "' , '" + txtb_desc.Text + "' , '" + cmb_branch.Text + "' , '" + cmb_status.Text + "' , '" + cmb_available.Text + "')");
                            if (Account.rowAffected > 0)
                            {

                                MessageBox.Show("New equipment Added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Account.executeSQL("INSERT INTO tbllogs VALUES ('" + DateTime.Now.ToString() + "' , 'Added new equipment with asset number-" +asset_format+"' , '" + username + "' , 'Equipments Management')");

                                //refresh datagrid
                                raiseUpdate();
                                this.Close();


                            }
                        }
                    }
                    else if (action == "update")
                    {
                        validate();
                        if (error == 0)
                        {
                                try
                                { 
                                    Account.executeSQL(" update tblequipments set serial_number = '" + txtb_serial.Text + "' , branch = '" + cmb_branch.Text + "' , model = '" + cmb_model.Text + "' , description = '" + txtb_desc.Text + "'  , status = '" + cmb_status.Text + "' , available = '" + cmb_available.Text + "' where asset_number = '" + asset_number + "' ");
                                    if (Account.rowAffected > 0)
                                    {
                                        MessageBox.Show("Equipment Updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        //Account.executeSQL("INSERT INTO tbllogs VALUES ('" + DateTime.Now.ToString() + "' , 'Updated equipment with asset number '" + asset_number + "'' , '" + username + "' , 'Equipments Management')");

                                        Account.executeSQL("INSERT INTO tbllogs VALUES ('" + DateTime.Now.ToString() + "' , 'Update equipment with a asset number-" + asset_format + "' , '" + username + "','Equipments Management')");
                                        raiseUpdate();
                                        this.Close();

                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        

        public class UpdateEventArgs : EventArgs
        {
            public string Data { get; set; }
        }

        protected void raiseUpdate()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler?.Invoke(this, args);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmb_status_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                if (cmb_status.SelectedIndex == 0)
                {
                    cmb_available.Text = "YES";
                }
                if (cmb_status.SelectedIndex == 1)
                {
                    cmb_available.Text = "NO";
                }
                if (cmb_status.SelectedIndex == 2)
                {
                    cmb_available.Text = "NO";
                }

                cmb_status.Enabled = true;
                cmb_available.Enabled = false;
            }

        private void frmaddequipments_Load(object sender, EventArgs e)
        {
            
                cmb_status.SelectedIndex = 0;
                cmb_available.SelectedIndex = 0;
                cmb_status.Enabled = false;
                cmb_available.Enabled = false;
           
            if (action == "update")
            {
                
                txtb_serial.Text = serial_number;
                txtb_serial.Enabled = false;
                cmb_branch.Text = branch;
                cmb_branch.Enabled = true;
                cmb_model.Text = model;
                cmb_model.Enabled = true;
                txtb_desc.Text = desc;
                cmb_status.Text = status;
                cmb_available.Text = available;
                cmb_status.Enabled = true;
                cmb_available.Enabled = false;
                
            }
        }


            void validate()
            {
                errorProvider1.Clear();
                error = 0;
                if (string.IsNullOrEmpty(txtb_serial.Text))
                {
                    errorProvider1.SetError(txtb_serial, "serial is empty");
                    error++;
                }

                if (cmb_branch.SelectedIndex < 0)
                {
                    errorProvider1.SetError(cmb_branch, "Select branch");
                    error++;
                }
                if (cmb_model.SelectedIndex < 0)
                {
                    errorProvider1.SetError(cmb_model, "Select model");
                    error++;
                }
                if (cmb_status.SelectedIndex < 0)
                {
                    errorProvider1.SetError(cmb_status, "Select status");
                    error++;
                }
                if (cmb_available.SelectedIndex < 0)
                {
                    errorProvider1.SetError(cmb_available, "Select availabilty");
                    error++;
                }

            if (action == "add")
            {
                DataTable dt = Account.GetData("select * from tblequipments where serial_number ='" + txtb_serial.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    errorProvider1.SetError(txtb_serial, "Serial Number already exists");
                    error++;
                }
            }


        }
        }
    }
