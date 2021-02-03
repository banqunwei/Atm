using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM
{
    public partial class preTransfer : Form
    {
        Account acwithdraw = new Account();
        
        MainFrame2 _mainform2;
        public preTransfer()
        {
            InitializeComponent();
        }

        public preTransfer(string usernamefrommf2, int accountfrommf2, MainFrame2 form2)
        {
            InitializeComponent();
            acwithdraw.Username = usernamefrommf2;
            acwithdraw.Accid = accountfrommf2;
            this.button1.Click += new EventHandler(button_Click);
            this.button2.Click += new EventHandler(button_Click);
            this.button3.Click += new EventHandler(button_Click);
            this.button4.Click += new EventHandler(button_Click);
            this.button5.Click += new EventHandler(button_Click);
            this.button6.Click += new EventHandler(button_Click);
            this.button7.Click += new EventHandler(button_Click);
            this.button8.Click += new EventHandler(button_Click);
            this.button9.Click += new EventHandler(button_Click);
            this.button10.Click += new EventHandler(button_Click);
            this.button11.Click += new EventHandler(button_Click);
            _mainform2 = form2;
            
        }
        private void button_Click(object sender, EventArgs e)
        {
            textBox1.Text += ((Button)sender).Text;
        }


        private void preTransfer_Load(object sender, EventArgs e)
        {
            this.Text = "输入转入账号界面";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Close();
            _mainform2.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int accountID = int.Parse(textBox1.Text.ToString());
            Console.WriteLine(accountID);
            if (DAO.check_accountID(acwithdraw.Username, accountID) == 0)
                MessageBox.Show("不存在该账户！");
            else
            {
                Transfer tfr1 = new Transfer(acwithdraw.Username.ToString(), acwithdraw.Accid, accountID, _mainform2);
                tfr1.Show();
                this.Hide();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult r1 = MessageBox.Show("是否退出系统", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r1.ToString() == "Yes")
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            DialogResult r1 = MessageBox.Show("是否退出系统", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r1.ToString() == "Yes")
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }
    }
}
