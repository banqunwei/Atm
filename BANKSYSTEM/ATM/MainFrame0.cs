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
    public partial class MainFrame0 : Form
    {
        Form _mainform1;
        public MainFrame0()
        {
            InitializeComponent();
        }
        public MainFrame0(Form form1)
        {
            
            InitializeComponent();
            _mainform1 = form1;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (DAO.insert_users(textBox1.Text, textBox2.Text) is true )
                MessageBox.Show("注册成功！");
            else
            {
                if (DAO.insert_users(textBox1.Text, textBox2.Text) is false)
                    MessageBox.Show("该用户已存在，请重新输入！");
                else
                    MessageBox.Show("注册失败！");
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainFrame0_Load(object sender, EventArgs e)
        {
            this.Text = "注册新用户界面";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Close();
            _mainform1.Show();
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
