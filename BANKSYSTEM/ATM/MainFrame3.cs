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
    public partial class MainFrame3 : Form
    {
        
        User u1 = new User();
        MainFrame1 _mainform1;
        public MainFrame3()
        {
            InitializeComponent();
        }

        public MainFrame3(string usernameValue, MainFrame1 form1)
        {
            u1.Username = usernameValue;
            InitializeComponent();
            _mainform1 = form1;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (string.Equals(textBox2.Text.ToString(), textBox3.Text.ToString()))
            {
                if (DAO.change_password(u1.Username, textBox2.Text.ToString()))
                    MessageBox.Show("修改成功！");
                else MessageBox.Show("修改失败！");
            }
            else
            {
                MessageBox.Show("密码不一致，请重新输入！");
            }
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

        private void MainFrame3_Load(object sender, EventArgs e)
        {
            this.Text = "修改密码界面";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
