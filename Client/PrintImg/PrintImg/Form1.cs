using Bll;
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
    public partial class Form1 : Form
    {
        private readonly BaseInfoBll baseInfobll = new BaseInfoBll();
        private readonly ImgInfoBll imgInfobll = new ImgInfoBll();
        private readonly UserInfoBll userInfobll = new UserInfoBll();

        public string UserName { get; set; }
        public string Qx { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 1;
            txtuser.SelectedIndex = 0;
            BindUser();
        }
        public void BindUser()
        {
           DataSet ds=userInfobll.GetAllList();
          
            txtuser.DataSource = ds.Tables[0];
            txtuser.ValueMember = "id";
            txtuser.DisplayMember = "username";
        }

        /// <summary>
        /// 重置按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            txtpwd.Text = "";
            txtuser.Text = "";
        }
        /// <summary>
        /// 登陆按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtuser.Text.Trim();
                string pwd = txtpwd.Text.Trim();
                string qx = comboBox1.SelectedIndex.ToString();  //0 普通用户  1管理员
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pwd))
                {
                    MessageBox.Show("请输入用户或密码");
                }
                if (userInfobll.IsLoginSucces(username, Common.GetMD532(pwd, ""), qx))
                {
                    this.DialogResult = DialogResult.OK;
                    this.UserName = username;
                    this.Qx = qx;
                    Common.Add(username, "登陆成功");
                }
                else
                {
                    MessageBox.Show("登陆失败,请核对信息！");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("登陆异常！");
            }
           
        }

    }
}
