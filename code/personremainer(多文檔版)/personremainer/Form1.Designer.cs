namespace personremainer
{
   public partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码
    
        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.導入數據ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TaStodataView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaStochart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.KLineGraph = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.stockdataView = new System.Windows.Forms.DataGridView();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.change = new System.Windows.Forms.DataGridViewButtonColumn();
            this.del = new System.Windows.Forms.DataGridViewButtonColumn();
            this.StoDataName = new System.Windows.Forms.Label();
            this.StoInc = new System.Windows.Forms.RichTextBox();
            this.StockDataInf = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DrawGrainChart = new System.Windows.Forms.Button();
            this.EndDate = new System.Windows.Forms.DateTimePicker();
            this.StartDate = new System.Windows.Forms.DateTimePicker();
            this.StoGrachart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TaStodataView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaStochart)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KLineGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockdataView)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StoGrachart)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(966, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.ToolStripMenuItem6,
            this.toolStripMenuItem5,
            this.導入數據ToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(44, 21);
            this.toolStripMenuItem1.Text = "選項";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Enabled = false;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem3.Text = "個人中心";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Enabled = false;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem4.Text = "持倉情況";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // ToolStripMenuItem6
            // 
            this.ToolStripMenuItem6.Enabled = false;
            this.ToolStripMenuItem6.Name = "ToolStripMenuItem6";
            this.ToolStripMenuItem6.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItem6.Text = "收益圖";
            this.ToolStripMenuItem6.Click += new System.EventHandler(this.ToolStripMenuItem6_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Enabled = false;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem5.Text = "股票資訊";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // 導入數據ToolStripMenuItem
            // 
            this.導入數據ToolStripMenuItem.Name = "導入數據ToolStripMenuItem";
            this.導入數據ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.導入數據ToolStripMenuItem.Text = "導入數據";
            this.導入數據ToolStripMenuItem.Click += new System.EventHandler(this.導入數據ToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(966, 553);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 1;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "日盈虧:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "現金";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "市值";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "帳戶總資產";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "盈虧";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "浮動盈虧";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "本金:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(693, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 2;
            this.textBox1.Visible = false;
            this.textBox1.WordWrap = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(807, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "搜索";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.TaStodataView);
            this.panel1.Controls.Add(this.TaStochart);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(936, 543);
            this.panel1.TabIndex = 2;
            this.panel1.Visible = false;
            // 
            // TaStodataView
            // 
            this.TaStodataView.AllowUserToAddRows = false;
            this.TaStodataView.AllowUserToDeleteRows = false;
            this.TaStodataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TaStodataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TaStodataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column10,
            this.Column11,
            this.Column4,
            this.Column5});
            this.TaStodataView.Location = new System.Drawing.Point(52, 55);
            this.TaStodataView.Name = "TaStodataView";
            this.TaStodataView.ReadOnly = true;
            this.TaStodataView.RowTemplate.Height = 23;
            this.TaStodataView.Size = new System.Drawing.Size(786, 150);
            this.TaStodataView.TabIndex = 1;
            this.TaStodataView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TaStodataView_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "股票";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "當前價";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "持倉成本";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "持有量";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "持有市值";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "盈虧";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "浮動盈虧(%)";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // TaStochart
            // 
            this.TaStochart.BackColor = System.Drawing.Color.Empty;
            this.TaStochart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            chartArea5.Name = "ChartArea1";
            this.TaStochart.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.TaStochart.Legends.Add(legend5);
            this.TaStochart.Location = new System.Drawing.Point(55, 211);
            this.TaStochart.Name = "TaStochart";
            this.TaStochart.Size = new System.Drawing.Size(783, 301);
            this.TaStochart.TabIndex = 0;
            this.TaStochart.Text = "chart1";
            this.TaStochart.Click += new System.EventHandler(this.TaStochart_Click);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.button8);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.KLineGraph);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.stockdataView);
            this.panel2.Controls.Add(this.StoDataName);
            this.panel2.Controls.Add(this.StoInc);
            this.panel2.Controls.Add(this.StockDataInf);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(932, 546);
            this.panel2.TabIndex = 3;
            this.panel2.Visible = false;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(534, 23);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(23, 23);
            this.button8.TabIndex = 13;
            this.button8.Text = "月";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(512, 23);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(23, 23);
            this.button7.TabIndex = 12;
            this.button7.Text = "周";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(492, 23);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(21, 23);
            this.button6.TabIndex = 11;
            this.button6.Text = "日";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(473, 23);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(19, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "分";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // KLineGraph
            // 
            this.KLineGraph.Location = new System.Drawing.Point(18, 47);
            this.KLineGraph.Name = "KLineGraph";
            this.KLineGraph.Size = new System.Drawing.Size(538, 315);
            this.KLineGraph.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.KLineGraph.TabIndex = 7;
            this.KLineGraph.TabStop = false;
            this.KLineGraph.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(786, 359);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "增添交易記錄";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // stockdataView
            // 
            this.stockdataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.stockdataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stockdataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date,
            this.Column9,
            this.price,
            this.quantity,
            this.tax,
            this.commission,
            this.change,
            this.del});
            this.stockdataView.Location = new System.Drawing.Point(18, 383);
            this.stockdataView.Name = "stockdataView";
            this.stockdataView.RowTemplate.Height = 23;
            this.stockdataView.Size = new System.Drawing.Size(843, 150);
            this.stockdataView.TabIndex = 5;
            this.stockdataView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellContentClick);
            // 
            // date
            // 
            this.date.HeaderText = "日期";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "操作";
            this.Column9.Name = "Column9";
            // 
            // price
            // 
            this.price.HeaderText = "價格";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "數量";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // tax
            // 
            this.tax.HeaderText = "稅率";
            this.tax.Name = "tax";
            this.tax.ReadOnly = true;
            // 
            // commission
            // 
            this.commission.HeaderText = "佣金";
            this.commission.Name = "commission";
            this.commission.ReadOnly = true;
            // 
            // change
            // 
            this.change.HeaderText = "修改";
            this.change.Name = "change";
            this.change.Text = "修改";
            this.change.UseColumnTextForButtonValue = true;
            // 
            // del
            // 
            this.del.HeaderText = "刪除";
            this.del.Name = "del";
            this.del.Text = "刪除";
            this.del.UseColumnTextForButtonValue = true;
            // 
            // StoDataName
            // 
            this.StoDataName.AutoSize = true;
            this.StoDataName.Location = new System.Drawing.Point(84, 18);
            this.StoDataName.Name = "StoDataName";
            this.StoDataName.Size = new System.Drawing.Size(0, 12);
            this.StoDataName.TabIndex = 4;
            // 
            // StoInc
            // 
            this.StoInc.Font = new System.Drawing.Font("宋体", 20F);
            this.StoInc.Location = new System.Drawing.Point(585, 52);
            this.StoInc.Name = "StoInc";
            this.StoInc.ReadOnly = true;
            this.StoInc.Size = new System.Drawing.Size(100, 96);
            this.StoInc.TabIndex = 3;
            this.StoInc.Text = "";
            this.StoInc.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // StockDataInf
            // 
            this.StockDataInf.Location = new System.Drawing.Point(585, 170);
            this.StockDataInf.Name = "StockDataInf";
            this.StockDataInf.ReadOnly = true;
            this.StockDataInf.Size = new System.Drawing.Size(200, 161);
            this.StockDataInf.TabIndex = 2;
            this.StockDataInf.Text = "";
            this.StockDataInf.TextChanged += new System.EventHandler(this.StockDataInf_TextChanged);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this.DrawGrainChart);
            this.panel3.Controls.Add(this.EndDate);
            this.panel3.Controls.Add(this.StartDate);
            this.panel3.Controls.Add(this.StoGrachart);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(933, 540);
            this.panel3.TabIndex = 4;
            this.panel3.Visible = false;
            // 
            // DrawGrainChart
            // 
            this.DrawGrainChart.Location = new System.Drawing.Point(519, 21);
            this.DrawGrainChart.Name = "DrawGrainChart";
            this.DrawGrainChart.Size = new System.Drawing.Size(75, 23);
            this.DrawGrainChart.TabIndex = 6;
            this.DrawGrainChart.Text = "計算";
            this.DrawGrainChart.UseVisualStyleBackColor = true;
            this.DrawGrainChart.Click += new System.EventHandler(this.DrawGrainChart_Click);
            // 
            // EndDate
            // 
            this.EndDate.Location = new System.Drawing.Point(286, 20);
            this.EndDate.Name = "EndDate";
            this.EndDate.Size = new System.Drawing.Size(200, 21);
            this.EndDate.TabIndex = 5;
            // 
            // StartDate
            // 
            this.StartDate.Location = new System.Drawing.Point(52, 20);
            this.StartDate.Name = "StartDate";
            this.StartDate.Size = new System.Drawing.Size(200, 21);
            this.StartDate.TabIndex = 4;
            // 
            // StoGrachart
            // 
            chartArea6.Name = "ChartArea1";
            this.StoGrachart.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.StoGrachart.Legends.Add(legend6);
            this.StoGrachart.Location = new System.Drawing.Point(32, 64);
            this.StoGrachart.Name = "StoGrachart";
            this.StoGrachart.Size = new System.Drawing.Size(799, 448);
            this.StoGrachart.TabIndex = 3;
            this.StoGrachart.Text = "chart1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 578);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "個人炒股記錄器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TaStodataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaStochart)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KLineGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockdataView)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StoGrachart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem 導入數據ToolStripMenuItem;
        private System.Windows.Forms.DataGridView TaStodataView;
        private System.Windows.Forms.DataVisualization.Charting.Chart TaStochart;

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.DataGridView stockdataView;
        public System.Windows.Forms.Label StoDataName;
        private System.Windows.Forms.RichTextBox StoInc;
        private System.Windows.Forms.RichTextBox StockDataInf;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.Label label1;



        //窗口狀態
        static bool show_PerFor = false;//個人資信
        static bool show_TakSto = false;//持倉情況
        static bool show_StoInf = false;//股票資訊
        static bool show_StoGra = false;//股票收益

        void Display(System.Windows.Forms.Panel target)
        {

            button1.Visible = true;
            textBox1.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            target.Visible = true;
        }
        void NotDisplay()
        {
            button1.Visible = false;
            textBox1.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            show_PerFor = false;
            show_StoGra = false;
            show_StoInf = false;
            show_TakSto = false;

        }


        private System.Windows.Forms.PictureBox KLineGraph;
        public System.Windows.Forms.DataVisualization.Charting.Chart StoGrachart;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn tax;
        private System.Windows.Forms.DataGridViewTextBoxColumn commission;
        private System.Windows.Forms.DataGridViewButtonColumn change;
        private System.Windows.Forms.DataGridViewButtonColumn del;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem6;
        private System.Windows.Forms.Button DrawGrainChart;
        private System.Windows.Forms.DateTimePicker EndDate;
        private System.Windows.Forms.DateTimePicker StartDate; 



    }
}

