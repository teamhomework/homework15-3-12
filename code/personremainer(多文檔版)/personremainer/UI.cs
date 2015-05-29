using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace personremainer
{
    public partial class UI : Form
    {
        static int ExistTableNum = 1;
        string[] ExistTableName = new string[ExistTableNum];
        
        bool IsTableExist = false;
        public UI()
        {
            InitializeComponent();
        }
        private void 開戶ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //還需要 改 增記錄的判斷 和 在父窗口增加 不同子窗口的對應顯示 (免去關後打不開) 提示是關掉 還是隱藏 可能要改DISPOSE 函數
            AccountName AN = new AccountName();
            AN.ShowDialog();
            IsTableExist = false;
            if (personremainer.commo_data.AccountName.Length > 0)
            {
                foreach (string Index in ExistTableName)
                {
                    MessageBox.Show(Index);
                    if (Index == personremainer.commo_data.AccountName)
                    {
                        IsTableExist = true;
                    }
                }
                if (IsTableExist == false)
                {
                    ExistTableName[(ExistTableNum - 1)] = personremainer.commo_data.AccountName;
                    ExistTableNum++;
                    string HeaderName = personremainer.commo_data.AccountName;
                    Form1 fm = new Form1(HeaderName);
                    fm.MdiParent = this;
                    fm.Text = HeaderName;
                    fm.Show();
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
    }
}
