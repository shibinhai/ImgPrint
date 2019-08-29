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
    public partial class Form2 : Form
    {
        BaseInfoBll bll = new BaseInfoBll();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "打开文件";
            openFileDialog1.ShowHelp = true;
            openFileDialog1.RestoreDirectory = true;

            //openFileDialog1.Filter = "Excel文件(*.xlsx)|(*.xls)";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txt_path.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = openFileDialog1.FileName;
            DataTable dt = Common.ReadExcel(path);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    BaseInfo baseInfo = new BaseInfo();
                    baseInfo.beizhu = "";
                    baseInfo.name = row.ItemArray[0].ToString();
                    baseInfo.pinyin = row.ItemArray[1].ToString();
                    baseInfo.guige = row.ItemArray[2].ToString();
                    baseInfo.changjia = row.ItemArray[3].ToString();
                    bll.Add(baseInfo);
                }
                MessageBox.Show("导入成功");
            }
        }
    }
}
