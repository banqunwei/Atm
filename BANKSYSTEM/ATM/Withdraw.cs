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
    public partial class Withdraw : Form
    {
        Account acwithdraw = new Account();
        MainFrame2 _mainform2;

        public Withdraw()
        {
            InitializeComponent();
        }

        public Withdraw(string usernamefrommf2, int accountfrommf2, MainFrame2 form2)
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Withdraw_Load(object sender, EventArgs e)
        {
            this.Text = "取款界面";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            float balance = DAO.get_balance(acwithdraw.Accid);
            float newbalance = float.Parse(textBox1.Text.ToString());
            Console.WriteLine(balance);           
            if (balance - newbalance > 0)
            {
                newbalance = balance - newbalance;
                if (DAO.deposit(acwithdraw.Accid, newbalance))
                    MessageBox.Show("取款成功！\n现金账户余额：" + newbalance);
                else MessageBox.Show("取款成功！\n现金账户余额：" + balance);
            }
            else
            {
                string accounttype = DAO.get_accounttype(acwithdraw.Accid);
                Console.WriteLine(accounttype);
                float limit = DAO.get_limit(acwithdraw.Accid);
                if (String.Equals(accounttype, "信用卡"))
                {
                    DialogResult r1 = MessageBox.Show("现金余额不足，是否使用信用卡额度", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r1.ToString() == "Yes")
                    {
                        if (limit + balance > newbalance)
                        {
                            if (DAO.deposit(acwithdraw.Accid, 0))
                            {
                                limit = limit - (newbalance - balance);
                                if (DAO.quota(acwithdraw.Accid, limit))
                                {
                                    MessageBox.Show("取款成功！\n现金账户余额：0\n信用卡余额：" + limit);
                                }
                            }
                           
                        }
                        else
                        {
                            MessageBox.Show("信用卡余额不足！");
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("取款失败！\n当前账户余额：" + balance);
                }
                
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Close();
            _mainform2.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
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
