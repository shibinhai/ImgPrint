using Bll;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Util;

namespace PrintImg
{
    public partial class AddUser : Form
    {
        private readonly UserInfoBll userInfobll = new UserInfoBll();
        public int _userId = 0;
        public AddUser(int userId)
        {
            this._userId = userId;
            InitializeComponent();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            labuserid.Text = this._userId.ToString();
            comboBox1.SelectedIndex = 0;

            if (this._userId > 0)
            {
                txtoldpwd.ReadOnly = false;
                LoadData();
            }
            else
            {
                txtoldpwd.ReadOnly = true;
            }
        }

        private void LoadData()
        {
           UserInfo m=userInfobll.GetModel(this._userId);
            if(m!=null)
            {
                txtname.Text = m.username;
                txtpwd1.Text = m.userpwd;
                txtpwd2.Text = m.userpwd;
                label6.Text = m.userpwd;
                comboBox1.SelectedIndex = Convert.ToInt32(m.qx);
            }
        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            txtname.Text = "";
            txtpwd1.Text = "";
            txtpwd2.Text = "";
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtname.Text.Trim();
            string pwd1 = txtpwd1.Text.Trim();
            string pwd2 = txtpwd2.Text.Trim();
            string qx = comboBox1.SelectedIndex.ToString();  //0 普通用户  1管理员

            string userId = labuserid.Text;
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pwd1) || string.IsNullOrEmpty(pwd2))
            {
                MessageBox.Show("请完善信息");
            }
            else
            {
                if (pwd1.Length != 6)
                {
                    MessageBox.Show("密码必须是6位");
                    txtpwd1.Text = "";
                    txtpwd2.Text = "";
                }
                else
                {
                    if (pwd1 != pwd2)
                    {
                        MessageBox.Show("两次密码不一致");
                        txtpwd1.Text = "";
                        txtpwd2.Text = "";
                    }
                    else
                    {
                        if (userInfobll.Exists(name) && Convert.ToInt32(userId) <= 0)
                        {
                            //已存在
                            MessageBox.Show("该用户已存在");
                        }
                        else
                        {
                            UserInfo m = new UserInfo();
                            m.createtime = DateTime.Now;
                            m.username = name;
                            m.userpwd = Common.GetMD532(pwd1, "");
                            m.qx = qx;
                            if (Convert.ToInt32(userId) > 0)
                            {
                                m.id = Convert.ToInt32(userId);
                                m.createtime = DateTime.Now;

                                string oldpwd = Common.GetMD532(txtoldpwd.Text, "");
                                if (oldpwd !=label6.Text)
                                {
                                    MessageBox.Show("和原来密码不一致");
                                    return;
                                }

                                //编辑
                                if (userInfobll.Update(m))
                                {
                                    MessageBox.Show("修改成功");
                                    Common.Add("登陆用户:" + _userId, ",用户信息修改成功" + DateTime.Now);
                                }
                                else
                                {
                                    MessageBox.Show("修改失败");
                                }
                                this.Close();
                            }
                            else
                            {
                                //新增
                                if (userInfobll.Add(m))
                                {
                                    MessageBox.Show("添加成功");
                                    Common.Add("登陆用户:" + _userId, ",新用户添加成功" + DateTime.Now);
                                }
                                else
                                {
                                    MessageBox.Show("添加失败");
                                }
                                this.Close();
                            }
                        }


                    }
                }
            }
        }
    }
}
