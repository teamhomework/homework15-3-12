using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SqlClient;

namespace personremainer
{
    public partial class UI : Form
    {
        //string[] ExistTableName = new string[ExistTableNum];
        bool IsTableExist = false;

        ToolStripMenuItem subItem;
        public struct UserTable
        {
            public string name;
            public Form1 WindowName;
            public ToolStripMenuItem TSM;
        };
        UserTable[] UT = new UserTable[100];
        int i = 0;

        public UI()
        {
            InitializeComponent();
            CheckAndShowExistTble();
            AutoSize(this);
            this.LayoutMdi(MdiLayout.TileVertical);
        }
        private void 開戶ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //還需要 改 增記錄的判斷 和 在父窗口增加 不同子窗口的對應顯示 (免去關後打不開) 提示是關掉 還是隱藏 可能要改DISPOSE 函數
            AccountName AN = new AccountName();
            AN.ShowDialog();
            IsTableExist = false;
            if (personremainer.commo_data.AccountName!= null &&personremainer.commo_data.AccountName.Length>0)
            {
                foreach(UserTable MyUT in UT)
                {
                    if (MyUT.name == personremainer.commo_data.AccountName)
                    {
                        IsTableExist = true;
                    }
                }
                if (IsTableExist == false)
                {

                    string HeaderName = personremainer.commo_data.AccountName;
                    Form1 fm = new Form1(HeaderName);
                    UT[i].name = personremainer.commo_data.AccountName;
                    UT[i].WindowName = fm;
                    fm.MdiParent = this;
                    fm.Text = HeaderName;
                    UT[i].TSM = AddContextMenu(fm.Text, subItem.DropDownItems, new EventHandler(MenuClicked));
                    ++i;
                    fm.Show();
                    this.LayoutMdi(MdiLayout.TileVertical);
                    
                }
                else if (IsTableExist == true)
                {
                    MessageBox.Show("該公司已存在");
                }

            }
            else
            {
                MessageBox.Show("請輸入公司名");
            }
        }

        private void CreateNewForm()
        {
            string HeaderName = personremainer.commo_data.AccountName;
            Form1 fm = new Form1(HeaderName);
            fm.ShowDialog();
        }

      public  void CheckAndShowExistTble()
        {

            string consqlser = "server = .\\SQLEXPRESS;integrated security=SSPI;database=test";

            SqlConnection sqlconn = new SqlConnection(consqlser);
            DataTable dt = new DataTable();
            sqlconn.Open();
            dt = sqlconn.GetSchema("Tables");

            subItem = AddContextMenu("帳戶管理", menuStrip1.Items, null);
            foreach (System.Data.DataRow row in dt.Rows)
            {
                UT[i].TSM = AddContextMenu(row["Table_Name"].ToString(), subItem.DropDownItems, new EventHandler(MenuClicked));

                Form1 fm = new Form1(row["Table_Name"].ToString());
                fm.Text = row["Table_Name"].ToString();
                UT[i].name = fm.Text;
                UT[i].WindowName = fm;
                
                fm.toolStripMenuItem3.Enabled = true;
                fm.toolStripMenuItem4.Enabled = true;
                fm.toolStripMenuItem5.Enabled = true;
                fm.ToolStripMenuItem6.Enabled = true;

                ++i;

            }
            sqlconn.Close();

        }
        ToolStripMenuItem AddContextMenu(string text, ToolStripItemCollection cms, EventHandler callback)
        {
            if (text == "-")
            {
                ToolStripSeparator tsp = new ToolStripSeparator();
                cms.Add(tsp);
                return null;
            }
            else if (!string.IsNullOrEmpty(text))
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem(text);
                tsmi.Tag = text + "TAG";
                if (callback != null) tsmi.Click += callback;
                cms.Add(tsmi);

                return tsmi;
            }

            return null;
        }

        void MenuClicked(object sender, EventArgs e)
        {
            //以下主要是动态生成事件并打开窗体
            string target = sender.ToString();
            foreach (UserTable MyUT in UT)
            {
                if (MyUT.name == target)
                {
                    MyUT.WindowName.MdiParent = this;
                    MyUT.WindowName.Show();
                    MyUT.WindowName.show_take_inf() ;
                    this.LayoutMdi(MdiLayout.TileVertical);
                }
            }
        }

        private void CloseAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 fm = new Form7();
            DialogResult DR = fm.ShowDialog();
            if(DR == DialogResult.OK)
            {
                //刪數據庫表 刪 對應子菜單 關掉對應窗口
                string target = fm.textBox1.Text;
                foreach (UserTable TempUT in UT)
                {
                    if (TempUT.name == target)
                    {
                        TempUT.WindowName.Dispose();
                        ToolStripItemCollection TC = subItem.DropDownItems;
                        TC.Remove(TempUT.TSM);
                        //刪數據庫表
                        string consqlser = "server = .\\SQLEXPRESS;integrated security=SSPI;database=test";
                        SqlConnection sqlconn = new SqlConnection(consqlser);
                        sqlconn.Open();
                        try
                        {
                            string droptable = "DROP TABLE " + "\"" + TempUT.name + "\"";
                            SqlCommand droptablecomm = new SqlCommand(droptable, sqlconn);
                            droptablecomm.ExecuteNonQuery();
                        }
                        catch(Exception er)
                        {
                        }
                    }
                }


            }


        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void UI_Load(object sender, EventArgs e)
        {
        }

        public void AutoSize(Form frm)
        {
            frm.Tag = frm.Width.ToString() + "," + frm.Height.ToString();
            frm.SizeChanged += new EventHandler(frm_SizeChanged);

        }
        void frm_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                string[] tmp = ((Form)sender).Tag.ToString().Split(',');
                float width = (float)((Form)sender).Width / (float)Convert.ToInt16(tmp[0]);
                float heigth = (float)((Form)sender).Height / (float)Convert.ToInt16(tmp[1]);

                ((Form)sender).Tag = ((Form)sender).Width.ToString() + "," + ((Form)sender).Height;

                foreach (Control control in ((Form)sender).Controls)
                {
                    control.Scale(new SizeF(width, heigth));

                }
                this.LayoutMdi(MdiLayout.TileVertical);
            }
            catch (Exception err)
            {
            }
        }

    }


}
