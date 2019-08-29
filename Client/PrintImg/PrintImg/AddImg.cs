using Bll;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Util;

namespace PrintImg
{
    public partial class AddImg : Form
    {
        private readonly BaseInfoBll baseInfobll = new BaseInfoBll();
        private readonly ImgInfoBll imgInfobll = new ImgInfoBll();
        public static string strImgs = "";
        public int _imgId { get; set; }
        public string _qx { get; set; }
        public AddImg(int imgId, string qx)
        {
            this._imgId = imgId;
            this._qx = qx;
            InitializeComponent();
        }
        private static TextBox txtStation_Name, txtStation_Value;
        private static ListBox ltb_Stations;
        /// <summary>
        /// 根据名称检索厂家和规格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtname_Leave(object sender, EventArgs e)
        {
            string name = txtStation_S_Name.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("请输入名称");
                txtStation_S_Name.Focus();
            }
            else
            {
                DataSet ds = baseInfobll.GetList(" name like '%" + name + "%' or pinyin like '%" + name + "%' ");
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    txtChangjia.Text = ds.Tables[0].Rows[0]["changjia"].ToString();
                    txtGG.Text = ds.Tables[0].Rows[0]["guige"].ToString();
                }
                //else
                //{
                //    MessageBox.Show("未找到厂家信息,请核对名称");
                //}
            }

        }

        private void AddImg_Load(object sender, EventArgs e)
        {
            // 指定打印文档
            this.printDialog1.Document = this.printDocument1;
            this.pageSetupDialog1.Document = printDocument1;
            this.printPreviewDialog1.Document = this.printDocument1;

            
            labId.Text = this._imgId.ToString();
            if (this._imgId > 0)
            {
                isChange.Text = "0";
                button1.Text = "确 定";
                //绑定原来数据
                BingDataById(this._imgId);
            }
            else
            {
                button1.Text = "保 存";
            }
            if (Convert.ToInt32(this._qx) == 0)
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }
        }
        public void BingDataById(int imgId)
        {
            ImgInfo m = imgInfobll.GetModel(imgId);
            if (m != null)
            {
                try
                {
                    txtChangjia.Text = m.changjia;
                    txtGG.Text = m.guige;
                    txtStation_S_Name.Text = m.name;
                    txtPH.Text = m.pihao;
                    strImgs = m.url;
                    //this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    DownloadImg(m.url);
                }
                catch (Exception)
                {

                }
            }
        }
        /// <summary>
        /// 保存图片取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            txtChangjia.Text = "";
            txtGG.Text = "";
            txtChangjia.Text = "";
            txtPH.Text = "";
            txtStation_S_Name.Text = "";
        }

        /// <summary>
        /// 保存图片 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this._qx) == 1)
            {
                //管理员
                string name = txtStation_S_Name.Text.Trim();
                string GG = txtGG.Text.Trim();
                string changjia = txtChangjia.Text.Trim();
                string PH = txtPH.Text.Trim();
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(PH) || string.IsNullOrEmpty(GG) || string.IsNullOrEmpty(changjia) || pictureBox1.Image == null)
                {
                    MessageBox.Show("请完善信息！");
                }
                else
                {

                    //往服务器上传图片
                    string fil = openFileDialog1.FileName;
                    if (Convert.ToInt32(isChange.Text) == 0)
                    {
                        fil = "111";
                    }
                    if (this.uploadFileByHttp(Common.GetAppSetingServerIp() + "/Upload.aspx", fil))
                    {
                        //往数据库添加数据
                        ImgInfo m = new ImgInfo();
                        m.name = name;
                        m.beizhu = "";
                        m.guige = GG;
                        m.changjia = changjia;
                        m.pihao = PH;
                        m.url = strImgs;
                        if (Convert.ToInt32(labId.Text) > 0)
                        {
                            //编辑
                            m.id = Convert.ToInt32(labId.Text);
                            m.createtime = DateTime.Now;
                            if (imgInfobll.Update(m))
                            {
                                MessageBox.Show("修改成功！");
                                Common.Add("角色:" + _qx, ",修改图片成功" + DateTime.Now);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("修改失败!");
                            }
                        }
                        else
                        {
                            if (imgInfobll.Add(m))
                            {
                                MessageBox.Show("添加成功！");
                                Common.Add("角色:" + _qx, ",图片添加成功" + DateTime.Now);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("添加失败！");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("网络异常,图片上传失败！");
                    }
                }
            }
            else
            {
                MessageBox.Show("普通用户无权操作！");
            }
        }

        /// <summary>
        /// 从服务器下载图片
        /// </summary>
        public void DownloadImg(string url)
        {
            try
            {
                pictureBox1.LoadAsync(Common.GetAppSetingServerIp() + url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("网络异常,图片下载失败。" + ex.Message);
            }

        }
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //图片的转化
            openFileDialog1.Filter = "*jpg|*.jpg|*bmp|*.bmp|*gif|*.gif";//设置图片另存为文件类型格式,filter是文件筛选器
            DialogResult da = openFileDialog1.ShowDialog();
            if (da == DialogResult.OK)
            {
                isChange.Text = "1";
                string fil = openFileDialog1.FileName;
                string exc = System.IO.Path.GetExtension(openFileDialog1.FileName);  //文件扩展名

                string filename = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName); //文件名
                this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = Image.FromFile(fil);

                strImgs = "/images/" + DateTime.Now.ToString("yyyyMMdd") + "/" + filename + exc;

            }

        }

        /// <summary>
        /// 重命名图片名称
        /// </summary>
        /// <returns></returns>
        public string RetFileName(string filename)
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }

        /// <summary>
        /// 上传图片到服务器
        /// </summary>
        /// <param name="webUrl"></param>
        /// <param name="localFileName"></param>
        /// <returns></returns>
        public bool uploadFileByHttp(string webUrl, string localFileName)
        {
            if (localFileName == "111")
            {
                //这是在编辑并且编辑时 图片没有改变

            }
            else
            {
                // 检查文件是否存在
                if (!System.IO.File.Exists(localFileName))
                {
                    MessageBox.Show("{0} 文件不存在!", localFileName);
                    return false;
                }
                try
                {
                    System.Net.WebClient myWebClient = new System.Net.WebClient();
                    myWebClient.UploadFile(webUrl, "POST", localFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("网络异常,图片上传失败。" + ex.Message);
                    return false;
                }
            }
            return true;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;


            // 打印图片
            //e.Graphics.DrawImage(this.pictureBox1.Image, new Rectangle(Convert.ToInt32(Width * 0.06), Convert.ToInt32(Height * 0.06), Convert.ToInt32(Width * 1.1), Convert.ToInt32(Height * 1.6)));

            // e.Graphics.DrawImage(this.pictureBox1.Image, new Rectangle(1, 1, Convert.ToInt32(Width * 1.2), Convert.ToInt32(Height * 1.6)));

            e.Graphics.DrawImage(this.pictureBox1.Image, new Rectangle(Convert.ToInt32((double)Width * 0.06), Convert.ToInt32((double)Height * 0.1), Convert.ToInt32((double)Width * 1.1), Height * 2));
        }

        /// <summary>
        /// listbox点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lb_Start_Stations_Click(object sender, EventArgs e)
        {
            ListBox eObj = sender as ListBox;
            BaseInfo info = eObj.SelectedItem as BaseInfo;
            txtStation_Name.Text = info.name;
            txtStation_Value.Text = info.id.ToString();
            txtChangjia.Text = info.changjia.ToString();
            txtGG.Text = info.guige;
            eObj.Visible = false;
            txtStation_Name.Select(txtStation_Name.Text.Length, 1); //光标定位到最后
        }

        /// <summary>
        /// 鼠标在listbox上移动选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lb_Start_Stations_MouseMove(object sender, MouseEventArgs e)
        {
            ListBox eObj = sender as ListBox;
            eObj.SelectedIndex = eObj.IndexFromPoint(e.Location);
        }

        private void lb_Start_Stations_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            BaseInfo info = (sender as ListBox).Items[e.Index] as BaseInfo;
            e.Graphics.DrawString(info.name, e.Font, new SolidBrush(e.ForeColor),
                                    e.Bounds);
        }
        /// <summary>
        /// 输入名称回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtStation_S_Name_Enter(object sender, EventArgs e)
        {
            lb_Start_Stations.Visible = false;
        }

        /// <summary>
        /// 名称keyUp事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtname_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox eObj = sender as TextBox; //事件源对象
            txtStation_Name = eObj; //当前事件出发对象

            txtStation_Value = this.txtStation_S_Value; //保存值的textbox
            ltb_Stations = this.lb_Start_Stations;   //始发站 展示数据的

            //上下左右
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left)
            {
                if (ltb_Stations.SelectedIndex > 0)
                    ltb_Stations.SelectedIndex--;
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right)
            {
                if (ltb_Stations.SelectedIndex < ltb_Stations.Items.Count - 1)
                    ltb_Stations.SelectedIndex++;
            }
            //回车
            else if (e.KeyCode == Keys.Enter)
            {
                BaseInfo info = ltb_Stations.SelectedItem as BaseInfo;
                txtStation_Name.Text = info.name;
                txtStation_Value.Text = info.id.ToString();
                ltb_Stations.Visible = false;
            }
            else
            {

                if (txtStation_Name.Text != "")
                {
                    IList<BaseInfo> dataSource = baseInfobll.GetModelList(" name like '%" + txtStation_Name.Text.Trim() + "%' or pinyin like '%" + txtStation_Name.Text.Trim() + "%'");
                    if (dataSource.Count > 0)
                    {
                        ltb_Stations.DataSource = dataSource;  //listbox
                        ltb_Stations.DisplayMember = "name";
                        ltb_Stations.ValueMember = "id";
                        ltb_Stations.Visible = true;
                    }
                    else
                        ltb_Stations.Visible = false;
                }
                else
                {
                    ltb_Stations.Visible = false;
                }
            }
            txtStation_Name.Select(txtStation_Name.Text.Length, 1); //光标定位到文本框最后
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 打印预览设置
            if (this.printPreviewDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.printDocument1.Print();
            }
        }



        private void button5_Click(object sender, EventArgs e)
        {
            // 页面设置
            // 页边距设置
            this.pageSetupDialog1.PageSettings.Margins.Left = 1;
            this.pageSetupDialog1.PageSettings.Margins.Top = 1;
            this.pageSetupDialog1.PageSettings.Margins.Bottom = 1;
            this.pageSetupDialog1.PageSettings.Margins.Right = 1;
            // 确定后直接打印
            if (this.pageSetupDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.printDocument1.Print();
        }

        /// <summary>
        /// 导出图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDY_Click(object sender, EventArgs e)
        {
            try
            {
                string url = Common.GetAppSetingServerIp() + AddImg.strImgs;
                string fileName = FileHelper.DownloadFile(url);
                if (!string.IsNullOrEmpty(fileName))
                {
                    MessageBox.Show("导出成功!请在" + FileHelper._directory + "目录查看");
                }
                else
                {
                    MessageBox.Show("图片导出失败!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("图片导出失败!");
            }
        }
    }
}
