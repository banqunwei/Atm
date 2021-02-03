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
    public partial class MainFrame2 : Form
    {
        Account a1 = new Account();
        MainFrame1 _mainform1;


        public MainFrame2()
        {
            InitializeComponent();
        }

        public MainFrame2(Account a2, MainFrame1 form1)
        {
            this.a1 = a2;
            InitializeComponent();
            _mainform1 = form1;
        }



        private void MainFrame2_Load(object sender, EventArgs e)
        {
            this.Text = "用户:" + a1.Username +"  账号:" + a1.Accid.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Deposit dp = new Deposit(a1.Username.ToString(), a1.Accid,this);
            dp.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            preTransfer tfr = new preTransfer(a1.Username.ToString(), a1.Accid, this);
            tfr.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Withdraw wd = new Withdraw(a1.Username.ToString(), a1.Accid,this );
            wd.Show();
            this.Hide();
            
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

     

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            _mainform1.Show();
        }

        public static implicit operator MainFrame2(Transfer v)
        {
            throw new NotImplementedException();
        }

        private void button5_Click(object sender, EventArgs e)
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
