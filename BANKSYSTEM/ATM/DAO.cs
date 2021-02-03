 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace ATM
{
    class DAO
    {

        public static int login(string Username, string Password)
        {
            try
            {
                string conStr = "Data Source=(localdb)\\MSSQLlocalDB;Initial Catalog=mydatabase;Integrated Security=True";
                string sqlQuery1 = "select * from [Login] where username='" + Username + "'";
                string sqlQuery2 = "select * from [Login] where username='" + Username + "'and password='" + Password + "'";
                SqlConnection conn = new SqlConnection(conStr);
                conn.Open();
                Console.WriteLine(Username);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sqlQuery1;
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    Console.WriteLine("不存在该用户，请重新输入！");
                    reader.Close();
                    conn.Close();
                    return 2;
                }
                else
                {
                    reader.Close();
                    cmd.CommandText = sqlQuery2;
                    reader = cmd.ExecuteReader();
                    if (!reader.Read())
                    {
                        Console.WriteLine("用户名或密码输入有误，请重新输入！");
                        reader.Close();
                        conn.Close();
                        return 3;

                    }
                    else
                    {
                        conn.Close();
                        Console.WriteLine("成功登陆");
                        return 1;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("异常:{0}", e.Message.ToString());
                return 4;
            }


        }

        public static int registered(string Username, string Password)
        {
            try
            {
                string conStr = "Data Source=(localdb)\\MSSQLlocalDB;Initial Catalog=mydatabase;Integrated Security=True";
                string sqlQuery1 = "select * from [Login] where username='" + Username + "'";
              
                SqlConnection conn = new SqlConnection(conStr);
                conn.Open();
                Console.WriteLine(Username);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sqlQuery1;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Console.WriteLine("已存在该用户，可直接登录！");
                    conn.Close();
                    return 1;
                }
                else
                { conn.Close(); Console.WriteLine("成功注册"); return 2;  }

            }
            catch (Exception e)
            {
                Console.WriteLine("异常:{0}", e.Message.ToString());
                return 4;
            }


        }


        public static DataSet viewAccount(string Username)
         {
            string conStr = "Data Source = (localdb)\\MSSQLlocalDB; Initial Catalog = mydatabase; Integrated Security = True";
            SqlConnection con = new SqlConnection(conStr);//建立连接
            string sqlQuery = "SELECT * FROM [Account] WHERE username = '" + Username + "'";//SQL语句
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            DataSet ds = new DataSet();//用于装载所有da采集过来的数据
            
            da.Fill(ds, "Account");
            con.Close();//关闭连接
            return ds;
         }//熟练运用datadapter操作dataset

        public static int check_accountID(string Username,int Account)//判断账户ID是否存在
        {
            string conStr = "Data Source=(localdb)\\MSSQLlocalDB;Initial Catalog=mydatabase;Integrated Security=True";
            string sqlQuery1 = "select * from [Account] where username='" + Username + "' and AccountID = '" + Account + "'";
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sqlQuery1;
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                Console.WriteLine("不存在该账号，请重新输入！");
                reader.Close();
                conn.Close();
                return 0;
            }
            else
                return 1;
        }

        public static float get_balance(int Account)//查找账户余额
        {
            //创建连接对象
            string conStr = "Data Source = (localdb)\\MSSQLlocalDB; Initial Catalog = mydatabase; Integrated Security = True"; 
            string sqlQuery = "select Balance from [Account] where AccountID = '" + Account + "'";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                reader.Read();
                return  float.Parse(reader["Balance"].ToString());
            }

            catch (Exception e)
            {
                float f=3;
                Console.WriteLine("异常:{0}", e.Message.ToString());
                return f;
            }

            finally
            {
                con.Close();
            }
        }

        public static string get_accounttype(int Account)//查找账户类型
        {
            //创建连接对象
            string conStr = "Data Source = (localdb)\\MSSQLlocalDB; Initial Catalog = mydatabase; Integrated Security = True";
            string sqlQuery = "select AccountType from [Account] where AccountID = '" + Account + "'";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                reader.Read();
                return reader["accounttype"].ToString();
            }

            catch (Exception e)
            {
                Console.WriteLine("异常:{0}", e.Message.ToString());
                return null;
            }

            finally
            {
                con.Close();
            }
        }

        public static float get_limit(int Account)//查找信用卡额度
        {
            //创建连接对象
            string conStr = "Data Source = (localdb)\\MSSQLlocalDB; Initial Catalog = mydatabase; Integrated Security = True";
            string sqlQuery = "select Limit from [Account] where AccountID = '" + Account + "'";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                reader.Read();
                return float.Parse(reader["Limit"].ToString());
            }

            catch (Exception e)
            {
                float f = 3;
                Console.WriteLine("异常:{0}", e.Message.ToString());
                return f;
            }

            finally
            {
                con.Close();
            }
        }

        public static Boolean deposit(int Account, float deposit_money)//更新余额
        {
            string conStr = "Data Source = (localdb)\\MSSQLlocalDB; Initial Catalog = mydatabase; Integrated Security = True";
            string sqlQuery1 = "update [Account] set Balance = " + deposit_money + " where AccountID ='" + Account + "'";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(sqlQuery1, con);
            try
            {
                con.Open();
                cmd = new SqlCommand(sqlQuery1, con);
                cmd.ExecuteNonQuery();//返回影响的行数
                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine("异常:{0}", e.Message.ToString());
                return false;
            }

            finally
            {
                con.Close();
            }
        }

        public static Boolean change_password(string NewUserName,string NewPassWord)//修改密码
        {
            string conStr = "Data Source = (localdb)\\MSSQLlocalDB; Initial Catalog = mydatabase; Integrated Security = True";
            string sqlQuery1 = "update [Login] set password = " + NewPassWord + " where username ='" + NewUserName + "'";
 
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(sqlQuery1, con);
            try
            {
                con.Open();
                cmd = new SqlCommand(sqlQuery1, con);
                cmd.ExecuteNonQuery();//返回影响的行数
                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine("异常:{0}", e.Message.ToString());
                return false;
            }

            finally
            {
                con.Close();
            }
        }

        public static Boolean insert_users(string Username, string Password)//注册
        {
            try
            {
                string conStr = "Data Source=(localdb)\\MSSQLlocalDB;Initial Catalog=mydatabase;Integrated Security=True";
                string sqlQuery1 = "select * from [Login] where username='" + Username + "'";
                string sqlQuery2 = "insert into [Login] values ('" + Username + "','" + Password + "')";
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand(sqlQuery1, con);
                try
                {
                    con.Open();
                    cmd = new SqlCommand(sqlQuery2, con);
                    cmd.ExecuteNonQuery();//返回影响的行数
                    return true;
                }

                catch (Exception e)
                {
                    Console.WriteLine("异常:{0}", e.Message.ToString());
                    return false;
                }

                finally
                {
                    con.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("异常:{0}", e.Message.ToString());
                return false;
            }
        }
        public static Boolean insert_account(string NewUserName, string AccountBank, string AccountType)//添加账户
        {
            float balance1 = 0;
            float limit1;
            if (String.Equals(AccountType, "信用卡"))
                limit1 = 2000;
            else
                limit1 = 0;
            string conStr = "Data Source = (localdb)\\MSSQLlocalDB; Initial Catalog = mydatabase; Integrated Security = True";
            string sqlQuery1 = "insert into [Account] values ('10007',N'" + AccountBank + "',N'" + AccountType + "','" + balance1 + "','" + NewUserName + "','" + limit1  + "')";
            
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(sqlQuery1, con);
            try
            {
                con.Open();
                cmd = new SqlCommand(sqlQuery1, con);
                cmd.ExecuteNonQuery();//返回影响的行数
                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine("异常:{0}", e.Message.ToString());
                return false;
            }

            finally
            {
                con.Close();
            }
        }


        public static Boolean quota(int Account, float deposit_money)//更新信用卡额度
        {
            string conStr = "Data Source = (localdb)\\MSSQLlocalDB; Initial Catalog = mydatabase; Integrated Security = True";
            string sqlQuery1 = "update [Account] set Limit = " + deposit_money + " where AccountID ='" + Account + "'";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(sqlQuery1, con);
            try
            {
                con.Open();
                cmd = new SqlCommand(sqlQuery1, con);
                cmd.ExecuteNonQuery();//返回影响的行数
                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine("异常:{0}", e.Message.ToString());
                return false;
            }

            finally
            {
                con.Close();
            }
        }
    }
}
