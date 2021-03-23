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
    public partial class frmaddborrow : Form
    {
        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;
        public frmaddborrow(string username, string dept)
        {
            InitializeComponent();
            this.username = username;
            this.dept = dept;
        }
        string username, dept;
        Class1 Account = new Class1("127.0.0.1", "cp3", "test", "12345");


        string borrow_form_id_format = DateTime.Now.ToString("yyyyMMddHHmmss");
        string date_now = DateTime.Now.ToString("yyyy-MM-dd");

        private void frmaddborrow_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Now;
            borrow_form_id.Text = borrow_form_id_format;
            borrow_date.Text = DateTime.Now.ToString();
            username_label.Text = username;
            dept_label.Text = dept;
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

        int error = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            
           try
            {
                validate();
                if (error == 0)
                {

                    this.Hide();
                    form_borrow form_borrow = new form_borrow(borrow_form_id_format, date_now, username, dept, txtb_avtivity.Text, dateTimePicker1.Text, txtb_purpose.Text, "add");
                    form_borrow.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtb_avtivity.Clear();
            dateTimePicker1.ResetText();
            txtb_purpose.Clear();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void borrow_form_id_Click(object sender, EventArgs e)
        {

        }

        void validate()
        {
            errorProvider1.Clear();
            error = 0;
            if (string.IsNullOrEmpty(txtb_avtivity.Text))
            {
                errorProvider1.SetError(txtb_avtivity, "activity is empty");
                error++;
            }
            if (string.IsNullOrEmpty(dateTimePicker1.Text))
            {
                errorProvider1.SetError(dateTimePicker1, "date is empty");
                error++;
            }
            if (string.IsNullOrEmpty(txtb_purpose.Text))
            {
                errorProvider1.SetError(txtb_purpose, "purpose is empty");
                error++;
            }

        }



    }
}
