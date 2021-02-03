using System;
using System.Collections;
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
    public partial class MainFrame1 : Form
    {
        User u1 = new User();
        int selectedaccount;

        public MainFrame1(string usernameValue)
        { 
           InitializeComponent();
           u1.Username = usernameValue;
        }

        
        private void MainFrame1_Load(object sender, EventArgs e)
        {
            this.Text = "欢迎您：" + u1.Username.ToString();
            this.dataGridView1.RowHeadersVisible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DAO.viewAccount(u1.Username.ToString()).Tables["Account"];
            dataGridView1.ReadOnly = false;
            DataGridViewCheckBoxColumn CheckColunms = new DataGridViewCheckBoxColumn();
            CheckColunms.Name = "选择";
            CheckColunms.Width = 50;

            this.dataGridView1.Columns.Insert(0, CheckColunms);
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                dataGridView1.Rows[i].Cells[0].Value = false;

           
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;

            dataGridView1.Columns[1].HeaderText = "账号";
            dataGridView1.Columns[2].HeaderText = "银行";
            dataGridView1.Columns[3].HeaderText = "卡类型";
            dataGridView1.Columns[4].HeaderText = "余额";
            dataGridView1.Columns[5].HeaderText = "用户";
            dataGridView1.Columns[6].HeaderText = "额度";

            this.button2.Enabled = false;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dataGridView1.Rows[e.RowIndex].Cells[0].Selected == true)
                    selectedaccount = (int)dataGridView1.Rows[e.RowIndex].Cells[1].Value;//存储所选账号到10000
                else
                    selectedaccount = 8888;
            }
            catch {
                Console.WriteLine( "异常{0}", e.ToString());

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult r1 = MessageBox.Show("是否选择账号" + selectedaccount + "进行业务办理操作", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r1.ToString() == "Yes")
            {
                Account accountfrommf1 = new Account();
                accountfrommf1.Accid = selectedaccount;
                accountfrommf1.Username = this.u1.Username;
                MainFrame2 m2 = new MainFrame2(accountfrommf1,this);
                this.Hide();
                m2.Show();
            }
            else
            {
                return;
            }
            this.Visible = false;
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

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            Account accountfrommf1 = new Account();
            accountfrommf1.Accid = selectedaccount;
            accountfrommf1.Username = this.u1.Username;
            */
            MainFrame3 m3 = new MainFrame3(u1.Username, this);
            this.Hide();
            m3.Show();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainFrame4 m4 = new MainFrame4(u1.Username, this);
            this.Hide();
            m4.Show();

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


