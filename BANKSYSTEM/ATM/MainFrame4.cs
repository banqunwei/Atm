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
    
    public partial class MainFrame4 : Form
    {
        User u1 = new User();
        MainFrame1 _mainform1;

        public MainFrame4()
        {
            InitializeComponent();
        }
        public MainFrame4(string usernameValue, MainFrame1 form1)
        {
            u1.Username = usernameValue;
            InitializeComponent();
            _mainform1 = form1;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if(DAO.insert_account(u1.Username, textBox1.Text, textBox2.Text))
                MessageBox.Show("添加成功！");
            else MessageBox.Show("添加失败！");
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

        private void button14_Click(object sender, EventArgs e)
        {
            this.Close();
            _mainform1.Show();
        }

        private void MainFrame4_Load(object sender, EventArgs e)
        {
            this.Text = "新建账号界面";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
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
    }
}
