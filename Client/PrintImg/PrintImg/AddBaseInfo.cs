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
    public partial class AddBaseInfo : Form
    {
        private readonly BaseInfoBll baseInfobll = new BaseInfoBll();
        public int _Id { get; set; }
        public string _qx { get; set; }
        public AddBaseInfo(int imgId, string qx)
        {
            this._Id = imgId;
            this._qx = qx;
            InitializeComponent();
        }
        /// <summary>
        /// 得到一个汉字的拼音第一个字母， 如果是一个英文字母则直接返回大写字母
        /// </summary>
        /// <param name="CnChar">单个汉字</param>
        /// <returns>单个大写字母</returns>
        public static string GetPYChar(string c)
        {
            try
            {
                byte[] array = new byte[2];
                array = System.Text.Encoding.Default.GetBytes(c);
                int i = (short)(array[0] - '\0') * 256 + ((short)(array[1] - '\0'));
                if (i < 0xB0A1) return "*";
                if (i < 0xB0C5) return "A";
                if (i < 0xB2C1) return "B";
                if (i < 0xB4EE) return "C";
                if (i < 0xB6EA) return "D";
                if (i < 0xB7A2) return "E";
                if (i < 0xB8C1) return "F";
                if (i < 0xB9FE) return "G";
                if (i < 0xBBF7) return "H";
                if (i < 0xBFA6) return "J";
                if (i < 0xC0AC) return "K";
                if (i < 0xC2E8) return "L";
                if (i < 0xC4C3) return "M";
                if (i < 0xC5B6) return "N";
                if (i < 0xC5BE) return "O";
                if (i < 0xC6DA) return "P";
                if (i < 0xC8BB) return "Q";
                if (i < 0xC8F6) return "R";
                if (i < 0xCBFA) return "S";
                if (i < 0xCDDA) return "T";
                if (i < 0xCEF4) return "W";
                if (i < 0xD1B9) return "X";
                if (i < 0xD4D1) return "Y";
                if (i < 0xD7FA) return "Z";
                return "*";
            }
            catch (Exception)
            {
                return c.ToUpper();
            }
        }
        /// <summary>
        /// 新增基本信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtname.Text.Trim();
            string pinyin = txtJP.Text.Trim();
            string GG = txtGG.Text.Trim();
            string changjia = txtChangjia.Text.Trim();
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pinyin) || string.IsNullOrEmpty(GG) || string.IsNullOrEmpty(changjia))
            {
                MessageBox.Show("请完善信息！");
            }
            else
            {
                BaseInfo m = new BaseInfo();
                m.name = name;
                m.pinyin = pinyin;
                m.guige = GG;
                m.changjia = changjia;
                m.beizhu = "";

                if (Convert.ToInt32(labId.Text) > 0)
                {
                    //编辑
                    m.id = Convert.ToInt32(labId.Text);
                    m.createtime = DateTime.Now;
                    if (baseInfobll.Update(m))
                    {
                        MessageBox.Show("修改成功！");
                        Common.Add("角色:" + _qx, ",修改基本信息成功" + DateTime.Now);

                    }
                    else
                    {
                        MessageBox.Show("修改失败！");
                    }
                }
                else
                {
                    if (baseInfobll.Add(m))
                    {
                        MessageBox.Show("基本信息添加成功！");
                        Common.Add("角色:" + _qx, "基本资料添加成功" + DateTime.Now);

                    }
                    else
                    {
                        MessageBox.Show("操作失败！");
                    }
                }
                this.Close();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 根据名称获得简码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtname_Leave(object sender, EventArgs e)
        {
            if (txtname.Text.Length > 0)
            {
                txtJP.Text = "";
                for (int i = 0; i < txtname.Text.Length; i++)
                {

                    txtJP.Text += GetPYChar(txtname.Text.Substring(i, 1).Trim());
                }
                if (txtJP.Text.Contains("*"))
                {
                    txtJP.ReadOnly = false;
                }
            }
            else
            {
                txtJP.Text = "";
            }
        }

        private void AddBaseInfo_Load(object sender, EventArgs e)
        {
            labId.Text = this._Id.ToString();
            if (this._Id > 0)
            {
                button1.Text = "确 定";
                //绑定原来数据
                BingDataById(this._Id);
            }
            else
            {
                button1.Text = "保 存";
            }
        }

        private void BingDataById(int id)
        {
            BaseInfo m = baseInfobll.GetModel(id);
            if (m != null)
            {
                try
                {
                    txtChangjia.Text = m.changjia;
                    txtGG.Text = m.guige;
                    txtname.Text = m.name;
                    txtJP.Text = m.pinyin;

                }
                catch (Exception)
                {
                    MessageBox.Show("出现异常");
                }
            }
        }
    }
}
