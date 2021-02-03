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
    public partial class Transfer : Form
    {
        Account acwithdraw = new Account();
        Account acwithdraw1 = new Account();
        MainFrame2 _mainform2;

        public Transfer()
        {
            InitializeComponent();
        }

        public Transfer(string usernamefrommf2, int accountfrommf2, int accountfrommf3, MainFrame2 form2)
        {
            InitializeComponent();
            acwithdraw.Username = usernamefrommf2;
            acwithdraw.Accid = accountfrommf2;
            acwithdraw1.Accid = accountfrommf3;
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

        private void Transfer_Load(object sender, EventArgs e)
        {
            this.Text = "转账界面";
        }
        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            
        }

 

        private void button14_Click_1(object sender, EventArgs e)
        {
            this.Close();
            _mainform2.Show();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            float balance1 = DAO.get_balance(acwithdraw.Accid);
            float balance2 = DAO.get_balance(acwithdraw1.Accid);
            Console.WriteLine(balance1);
            float transferbalance = float.Parse(textBox1.Text.ToString());
            if (balance1 - transferbalance>0)
            {
                float newbalance = balance1 - transferbalance;
                if (DAO.deposit(acwithdraw.Accid, balance1 - transferbalance)&& DAO.deposit(acwithdraw1.Accid, balance2 + transferbalance))
                    MessageBox.Show("转账成功！\n当前现金账户余额：" + newbalance);
                else MessageBox.Show("转账失败！\n当前现金账户余额：" + balance1);

            }
            else MessageBox.Show("余额不足！\n当前现金账户余额：" + balance1);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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
