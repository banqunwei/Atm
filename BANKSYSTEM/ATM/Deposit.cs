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
    public partial class Deposit : Form
    {
        Account acdeposit = new Account();
        MainFrame2 _mainform2;

        public Deposit()
        {
            InitializeComponent();
        }

        public Deposit(string usernamefrommf2, int accountfrommf2, MainFrame2 form2)
        {
            InitializeComponent();
            acdeposit.Username = usernamefrommf2;
            acdeposit.Accid = accountfrommf2;
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


        private void Deposit_Load(object sender, EventArgs e)
        {
            this.Text = "存款界面" ;
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            float balance = DAO.get_balance(acdeposit.Accid);
            Console.WriteLine(balance);
            float newbalance = balance + float.Parse(textBox1.Text.ToString());
            if (DAO.deposit(acdeposit.Accid, newbalance)) 
            MessageBox.Show("      存款成功！\n现金账户余额：" + newbalance);
            else MessageBox.Show("      存款失败！\n现金账户余额：" + balance);
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
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
