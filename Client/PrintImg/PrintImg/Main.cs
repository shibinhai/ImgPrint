using Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Util;

namespace PrintImg
{
    public partial class Main : Form
    {
        private readonly BaseInfoBll baseInfobll = new BaseInfoBll();
        private readonly ImgInfoBll imgInfobll = new ImgInfoBll();
        private readonly UserInfoBll userInfobll = new UserInfoBll();
        public string _UserName { get; set; }
        public string _Qx { get; set; }
        public static int pageindex = 1; //当前页
        public static int pagesize = 18; //每页显示记录数
        public static int pagecount = 1; //总页数


        public Main(string username, string qx)
        {
            this._UserName = username;
            this._Qx = qx;
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void Main_Load(object sender, EventArgs e)
        {

            ThreadStart childref = new ThreadStart(CallToChildThread);
            Thread childThread = new Thread(childref);
            childThread.Start();

            labUsername.Text = this._UserName;

            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;  //基本数据
            this.dataGridView1.AutoGenerateColumns = false;  //让它不自己产生多余的列
            this.dataGridView1.AllowUserToAddRows = false;  //不添加空白行

            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;  //基本数据
            this.dataGridView2.AutoGenerateColumns = false;  //让它不自己产生多余的列
            this.dataGridView2.AllowUserToAddRows = false;  //不添加空白行

            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;  //基本数据
            this.dataGridView3.AutoGenerateColumns = false;  //让它不自己产生多余的列
            this.dataGridView3.AllowUserToAddRows = false;  //不添加空白行
            
            if (this._Qx == "0")
            {
                //普通用户  隐藏新增按钮
                tab1_btnAdd.Enabled = false;
                button11.Enabled = false;
            }
            else
            {
                //管理员 
                tab1_btnAdd.Enabled = true;
                button11.Enabled = true;
            }

            BindTab1Data("", "", pageindex, pagesize);
            BindTab2Data("", "", pageindex, pagesize);
            BindTab3Data("", "", pageindex, pagesize);
        }

        public void CallToChildThread()
        {
            while (true)
            {
                // 线程暂停 3000 毫秒
                int sleepfor = 1000;
                Thread.Sleep(sleepfor);
                labtime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        #region 基本数据
        /// <summary>
        /// 绑定基本数据列表
        /// </summary>
        public void BindTab1Data(string where, string order, int pageindex, int pagesize)
        {
            GetPageCount(where);
            DataSet ds = baseInfobll.GetListByPage(where, order, pageindex, pagesize);
            dataGridView1.DataSource = ds.Tables[0];
        }
        /// <summary>
        /// 获得总记录数
        /// </summary>
        /// <param name="where"></param>
        public void GetPageCount(string where)
        {
            int count = baseInfobll.GetRecordCount(where);
            if (count > 0)
            {
                if (count % pagesize == 0)
                {
                    pagecount = count / pagesize;
                }
                else
                {
                    pagecount = count / pagesize + 1;
                }
            }
            labpagecount.Text = pagecount.ToString();
            labpageindex.Text = pageindex.ToString();
        }
        /// <summary>
        /// 修改基本信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            string id = dataGridView1.Rows[index].Cells["id2"].Value.ToString();
            AddBaseInfo frmaddbase = new AddBaseInfo(Convert.ToInt32(id), this._Qx);
            frmaddbase.ShowDialog();
        }
        /// <summary>
        /// 第一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnpageFirst_Click(object sender, EventArgs e)
        {
            pageindex = 1;
            string name = txtbaseName.Text.Trim();
            BindTab1Data(" name like '%" + name + "%' or pinyin like '%" + name + "%' ", "", pageindex, pagesize);
        }

        /// <summary>
        /// 最后一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnpageEnd_Click(object sender, EventArgs e)
        {
            pageindex = Convert.ToInt32(labpagecount.Text);
            string name = txtbaseName.Text.Trim();
            BindTab1Data(" name like '%" + name + "%' or pinyin like '%" + name + "%' ", "", pageindex, pagesize);
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnpageNext_Click(object sender, EventArgs e)
        {
            if (pageindex + 1 > Convert.ToInt32(labpagecount.Text))
            {
                pageindex = Convert.ToInt32(labpagecount.Text);

            }
            else
            {
                pageindex = pageindex + 1;
            }
            string name = txtbaseName.Text.Trim();
            BindTab1Data(" name like '%" + name + "%' or pinyin like '%" + name + "%' ", "", pageindex, pagesize);
        }

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnpagePre_Click(object sender, EventArgs e)
        {
            if (pageindex - 1 < 1)
            {
                pageindex = 1;

            }
            else
            {
                pageindex = pageindex - 1;
            }
            string name = txtbaseName.Text.Trim();
            BindTab1Data(" name like '%" + name + "%' or pinyin like '%" + name + "%' ", "", pageindex, pagesize);
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            BindTab1Data("", "", pageindex, pagesize);
        }

        /// <summary>
        /// 基本信息查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tab1_btnquery_Click(object sender, EventArgs e)
        {
            pageindex = 1;
            pagecount = 1;
            string name = txtbaseName.Text.Trim();
            BindTab1Data(" name like '%" + name + "%' or pinyin like '%" + name + "%' ", "", pageindex, pagesize);
        }

        /// <summary>
        /// 基本信息新增事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tab1_btnAdd_Click(object sender, EventArgs e)
        {
            AddBaseInfo frmAddbaseinfo = new AddBaseInfo(0, _Qx);
            frmAddbaseinfo.ShowDialog();
        }
        #endregion

        #region 保存图片
        /// <summary>.
        /// 绑定图片数据列表
        /// </summary>
        public void BindTab2Data(string wher, string order, int pageindex, int pagesize)
        {

            StringBuilder where = new StringBuilder();
            string name = txtImgname.Text.Trim();
            string dtstart = dtstar.Text.Trim();
            string dteng = dtend.Text.Trim();
            where.Append(" (name like '%" + name + "%' or pihao like '%" + name + "%') ");
            if (!string.IsNullOrEmpty(dtstart))
            {
                where.Append(" and (CONVERT(VARCHAR,createtime,23) >= '" + DateTime.Parse(dtstart).ToString("yyyy-MM-dd") + "'");
            }
            if (!string.IsNullOrEmpty(dteng))
            {
                where.Append(" and CONVERT(VARCHAR,createtime,23) <= '" + DateTime.Parse(dteng).ToString("yyyy-MM-dd") + "')");
            }
            GetPageImgCount(where.ToString());
            DataSet ds = imgInfobll.GetListByPage(where.ToString(), "", pageindex, pagesize);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dataGridView2.DataSource = ds.Tables[0];
            }
            else
            {
                dataGridView2.DataSource = null;
            }

        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            BindTab2Data("", "", pageindex, pagesize);
        }
        /// <summary>
        /// 图片查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            pageindex = 1;
            pagecount = 1;
            BindTab2Data("", "", pageindex, pagesize);
        }


        /// <summary>
        /// 图片新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            AddImg frmAddimg = new AddImg(0, this._Qx);
            frmAddimg.ShowDialog();
        }

        /// <summary>
        /// 双击图片列表编辑信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView2.CurrentCell.RowIndex;
            string imgId = dataGridView2.Rows[index].Cells["id"].Value.ToString();
            AddImg frmaddimg = new AddImg(Convert.ToInt32(imgId), this._Qx);
            frmaddimg.Show();
        }

        /// <summary>
        /// 获得总记录数
        /// </summary>
        /// <param name="where"></param>
        public void GetPageImgCount(string where)
        {
            int count = imgInfobll.GetRecordCount(where);
            if (count > 0)
            {
                if (count % pagesize == 0)
                {
                    pagecount = count / pagesize;
                }
                else
                {
                    pagecount = count / pagesize + 1;
                }
            }
            Imglabcount.Text = pagecount.ToString();
            Imglabindex.Text = pageindex.ToString();
        }

        private void Imgbtnfirst_Click(object sender, EventArgs e)
        {
            pageindex = 1;
            BindTab2Data("", "", pageindex, pagesize);
        }

        private void ImgbtnNext_Click(object sender, EventArgs e)
        {
            if (pageindex + 1 > Convert.ToInt32(Imglabcount.Text))
            {
                pageindex = Convert.ToInt32(Imglabcount.Text);

            }
            else
            {
                pageindex = pageindex + 1;
            }
            BindTab2Data("", "", pageindex, pagesize);
        }

        private void Imgbtnpre_Click(object sender, EventArgs e)
        {
            if (pageindex - 1 < 1)
            {
                pageindex = 1;

            }
            else
            {
                pageindex = pageindex - 1;
            }
            BindTab2Data("", "", pageindex, pagesize);
        }

        private void Imgbtnend_Click(object sender, EventArgs e)
        {
            pageindex = Convert.ToInt32(Imglabcount.Text);
            BindTab2Data("", "", pageindex, pagesize);
        }
        #endregion


        #region 清空数据
        /// <summary>
        /// 全部删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {

            // 查询按钮点击后，按钮文本由"查询"改为"加载中",并把按钮状态改为不可点击
         
            // 使用匿名方法定义一个委托事件，委托事件主要操作数据库查询，并返回查询的结果，不涉及任何UI操作    
            Func<int> act = () =>
            {
              
                return DeleteAll();
            };
            // 异步调用委托事件，在委托事件回调方法中，使用任意控件的异步方法把查询结果绑定到数据表控件中
            act.BeginInvoke((result) =>
            {
                int Result = act.EndInvoke(result);
                // this是当前WinForm窗口的实例，也可以替换为界面中的任意控件示例，如dgvMain.BeginInvoke
                this.BeginInvoke(new Action<int>((int res) =>
                {
                    if (res == 1)
                    {
                        MessageBox.Show("全部删除成功");
                        button3.Text = "全部删除";
                        button3.Enabled = true;
                    }
                    else
                    {
                        button3.Text = "全部删除";
                        button3.Enabled = true;
                        if (res!=-1)
                        {
                            MessageBox.Show("删除失败");
                        }
                     
                    }
                    
                }), Result);
            }, null);
            
        }

        public int DeleteAll()
        {
          
            show2();
            int result = 0;
            StringBuilder where = new StringBuilder();
            string name = txtImgname.Text.Trim();
            string dtstart = dtstar.Text.Trim();
            string dteng = dtend.Text.Trim();
            where.Append(" (name like '%" + name + "%' or pihao like '%" + name + "%') ");
            if (!string.IsNullOrEmpty(dtstart))
            {
                where.Append(" and (CONVERT(VARCHAR,createtime,23) >= '" + DateTime.Parse(dtstart).ToString("yyyy-MM-dd") + "'");
            }
            if (!string.IsNullOrEmpty(dteng))
            {
                where.Append(" and CONVERT(VARCHAR,createtime,23) <= '" + DateTime.Parse(dteng).ToString("yyyy-MM-dd") + "')");
            }

            DataSet ds = imgInfobll.GetList(where.ToString());
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (MessageBox.Show("您确定要全部删除" + ds.Tables[0].Rows.Count + "条记录吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    button3.Text = "删除中...";
                    button3.Enabled = false;
                    string ids = "";
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ids += row["id"] + ",";
                    }
                    //全部删除数据库图片记录
                    imgInfobll.DeleteList(ids.Substring(0, ids.Length - 1));
                    //根据开始时间结束时间删除图片文件夹
                    int start = Convert.ToInt32(Convert.ToDateTime(dtstar.Text).ToString("yyyyMMdd"));
                    int end = Convert.ToInt32(Convert.ToDateTime(dtend.Text).ToString("yyyyMMdd"));
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    dic.Add("start", start.ToString());
                    dic.Add("end", end.ToString());
                    dic.Add("type", "all");
                    string res = Post(Common.GetAppSetingServerIp() + "/DeleFile.aspx", dic);
                    if (res.Contains("删除成功"))
                    {
                        result = 1;
                    }
                }
                else
                {
                    result = -1;
                }
            }
            else
            {
             //  dataGridView2.DataSource = null;

            }
            return result;
        }

        void show2()
        {
           
            //说明的当前外部线程
            /*
             // 摘要:
        //     获取一个值，该值指示调用方在对控件进行方法调用时是否必须调用 Invoke 方法，因为调用方位于创建控件所在的线程以外的线程中。
        //
        // 返回结果:
        //     如果控件的 System.Windows.Forms.Control.Handle 是在与调用线程不同的线程上创建的（说明您必须通过 Invoke
        //     方法对控件进行调用），则为 true；否则为 false。
             */
            if (InvokeRequired)
            {
                /*既然是外部线程，那么就没有权限访问主线程上的控件
                 * 故要主线程访问，开启一个异步委托捆绑要执行的方法
                 * 交给主线程执行
                 */
                Action ac = new Action(show2);
                this.Invoke(ac); //这里执行后。则InvokeRequired就为false。因为此时已经是主线程访问当前创建的控件
         
            }
            else
            {
                button3.Text = "全部删除";
                button3.Enabled = true;
            }
        }

        /// <summary>
        /// 指定Post地址使用Get 方式获取全部字符串
        /// </summary>
        /// <param name="url">请求后台地址</param>
        /// <returns></returns>
        public static string Post(string url, Dictionary<string, string> dic)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";

            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (var item in dic)
            {
                if (i > 0)
                    builder.Append("&");
                builder.AppendFormat("{0}={1}", item.Key, item.Value);
                i++;
            }
            byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        #endregion

        /// <summary>
        /// Tab 切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageindex = 1; //当前页
            pagecount = 1; //总页数
            if (tabs.SelectedIndex == 0)
            {
                //基本数据
                BindTab1Data("", "", pageindex, pagesize);

            }
            else if (tabs.SelectedIndex == 1)
            {
                //保存图片
                BindTab2Data("", "", pageindex, pagesize);

            }
            else
            {
                //用户管理
                BindTab3Data("", "", pageindex, pagesize);
            }
        }

        #region 用户管理
        private void BindTab3Data(string wher, string order, int pageindex, int pagesize)
        {
            StringBuilder where = new StringBuilder();
            string name = txttab3name.Text.Trim();
            where.Append(" username like '%" + name + "%' ");
            GetPageUserCount(where.ToString());
            DataSet ds = userInfobll.GetListByPage(where.ToString(), "", pageindex, pagesize);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dataGridView3.DataSource = ds.Tables[0];
            }
            else
            {
                dataGridView3.DataSource = null;
            }
        }

        private void GetPageUserCount(string where)
        {
            int count = userInfobll.GetRecordCount(where);
            if (count > 0)
            {
                if (count % pagesize == 0)
                {
                    pagecount = count / pagesize;
                }
                else
                {
                    pagecount = count / pagesize + 1;
                }
            }
            labusercount.Text = pagecount.ToString();
            labuserindex.Text = pageindex.ToString();
        }

        /// <summary>
        /// 用户管理 第一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnuserfirst_Click(object sender, EventArgs e)
        {
            pageindex = 1;
            BindTab3Data("", "", pageindex, pagesize);
        }
        /// <summary>
        /// 用户管理 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnusernext_Click(object sender, EventArgs e)
        {
            if (pageindex + 1 > Convert.ToInt32(labusercount.Text))
            {
                pageindex = Convert.ToInt32(labusercount.Text);

            }
            else
            {
                pageindex = pageindex + 1;
            }
            BindTab3Data("", "", pageindex, pagesize);
        }

        /// <summary>
        /// 用户管理 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnuserpre_Click(object sender, EventArgs e)
        {
            if (pageindex - 1 < 1)
            {
                pageindex = 1;

            }
            else
            {
                pageindex = pageindex - 1;
            }
            BindTab3Data("", "", pageindex, pagesize);
        }
        /// <summary>
        /// 用户管理 最后一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnuserend_Click(object sender, EventArgs e)
        {
            pageindex = Convert.ToInt32(labusercount.Text);
            BindTab3Data("", "", pageindex, pagesize);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button12_Click(object sender, EventArgs e)
        {
            pageindex = 1;
            pagecount = 1;
            BindTab3Data("", "", pageindex, pagesize);
        }

        /// <summary>
        /// 刷新用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            BindTab3Data("", "", pageindex, pagesize);
        }

        /// <summary>
        /// 用户新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, EventArgs e)
        {
            AddUser frmadduser = new AddUser(0);
            frmadduser.ShowDialog();
        }
        /// <summary>
        /// 双击修改用户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = dataGridView3.CurrentCell.RowIndex;
                string userId = dataGridView3.Rows[index].Cells["id1"].Value.ToString();
                AddUser frmadduser = new AddUser(Convert.ToInt32(userId));
                frmadduser.ShowDialog();
            }
            catch (Exception)
            {
            }
        }

        #endregion

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("是否确认退出程序？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                // 关闭所有的线程
                this.Dispose();
                this.Close();
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 单击右下角图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                //还原窗体显示    
                WindowState = FormWindowState.Normal;
                //激活窗体并给予它焦点
                this.Activate();
                //任务栏区显示图标
                this.ShowInTaskbar = true;
                //托盘区图标隐藏
                notifyIcon1.Visible = false;
            }
        }

        /// <summary>
        /// 判断是否最小化,然后显示托盘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_SizeChanged(object sender, EventArgs e)
        {
            //判断是否选择的是最小化按钮
            if (WindowState == FormWindowState.Minimized)
            {
                //隐藏任务栏区图标
                this.ShowInTaskbar = false;
                //图标显示在托盘区
                notifyIcon1.Visible = true;
            }
        }

        private void 显示_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void 退出_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认退出程序？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                // 关闭所有的线程
                this.Dispose();
                this.Close();
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            //this.Visible = true;
            //this.TopMost = true;
            //this.WindowState = FormWindowState.Normal;
            //this.Activate();
        }

        private void dataGridView3_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    if (dataGridView3.Rows[e.RowIndex].Selected == false)
                    {
                        dataGridView3.ClearSelection();
                        dataGridView3.Rows[e.RowIndex].Selected = true;
                    }
                    if (dataGridView2.SelectedRows.Count == 1)
                    {
                        dataGridView2.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                    contextMenuStrip2.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        /// <summary>
        /// 右键删除用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = dataGridView3.CurrentCell.RowIndex;
            string id = dataGridView3.Rows[index].Cells["id1"].Value.ToString();
            if (MessageBox.Show("您确定要删除该信息吗？", "信息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (userInfobll.Delete(Convert.ToInt32(id)))
                {
                    MessageBox.Show("删除成功");
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView2_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        /// <summary>
        /// 右键删除单条图片记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int index = dataGridView2.CurrentCell.RowIndex;
            string id = dataGridView2.Rows[index].Cells["id"].Value.ToString();
            string imtUrl = dataGridView2.Rows[index].Cells["url"].Value.ToString();
            if (MessageBox.Show("您确定要删除该信息吗？", "信息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (imgInfobll.Delete(Convert.ToInt32(id)))
                {
                    //根据开始时间结束时间删除图片文件夹
                    int start = Convert.ToInt32(Convert.ToDateTime(dtstar.Text).ToString("yyyyMMdd"));
                    int end = Convert.ToInt32(Convert.ToDateTime(dtend.Text).ToString("yyyyMMdd"));
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    dic.Add("imgurl", imtUrl);
                    dic.Add("type", "one");
                    dic.Add("start", start.ToString());
                    dic.Add("end", end.ToString());
                    string res = Post(Common.GetAppSetingServerIp() + "/DeleFile.aspx", dic);
                    if (res.Contains("删除成功"))
                    {
                        MessageBox.Show("删除成功");
                    }
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
        }
    }
}
