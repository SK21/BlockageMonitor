namespace BlockageMonitor
{
    partial class frmModuleConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModuleConfig));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lbIP = new System.Windows.Forms.Label();
            this.lbModuleIP = new System.Windows.Forms.Label();
            this.lbSubnet = new System.Windows.Forms.Label();
            this.cbEthernet = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.moduleIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rWstartDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rWendDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enabledDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnRenumber = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSendSubnet = new System.Windows.Forms.Button();
            this.btnRescan = new System.Windows.Forms.Button();
            this.tbRows = new System.Windows.Forms.TextBox();
            this.lbRows = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(15, 15);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(490, 449);
            this.tabControl1.TabIndex = 148;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lbIP);
            this.tabPage3.Controls.Add(this.lbModuleIP);
            this.tabPage3.Controls.Add(this.lbSubnet);
            this.tabPage3.Controls.Add(this.cbEthernet);
            this.tabPage3.Controls.Add(this.btnSendSubnet);
            this.tabPage3.Controls.Add(this.btnRescan);
            this.tabPage3.Location = new System.Drawing.Point(4, 33);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(482, 412);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Network";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lbIP
            // 
            this.lbIP.AutoSize = true;
            this.lbIP.Location = new System.Drawing.Point(79, 172);
            this.lbIP.Name = "lbIP";
            this.lbIP.Size = new System.Drawing.Size(76, 24);
            this.lbIP.TabIndex = 217;
            this.lbIP.Text = "Local IP";
            // 
            // lbModuleIP
            // 
            this.lbModuleIP.Location = new System.Drawing.Point(244, 129);
            this.lbModuleIP.Name = "lbModuleIP";
            this.lbModuleIP.Size = new System.Drawing.Size(161, 24);
            this.lbModuleIP.TabIndex = 216;
            this.lbModuleIP.Text = "192.168.100.100";
            this.lbModuleIP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbSubnet
            // 
            this.lbSubnet.AutoSize = true;
            this.lbSubnet.Location = new System.Drawing.Point(79, 129);
            this.lbSubnet.Name = "lbSubnet";
            this.lbSubnet.Size = new System.Drawing.Size(149, 24);
            this.lbSubnet.TabIndex = 215;
            this.lbSubnet.Text = "Selected Subnet";
            // 
            // cbEthernet
            // 
            this.cbEthernet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEthernet.FormattingEnabled = true;
            this.cbEthernet.Location = new System.Drawing.Point(248, 169);
            this.cbEthernet.Name = "cbEthernet";
            this.cbEthernet.Size = new System.Drawing.Size(157, 32);
            this.cbEthernet.TabIndex = 212;
            this.cbEthernet.SelectedIndexChanged += new System.EventHandler(this.cbEthernet_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DGV);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(6);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(6);
            this.tabPage1.Size = new System.Drawing.Size(482, 412);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Config";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.AllowUserToResizeColumns = false;
            this.DGV.AllowUserToResizeRows = false;
            this.DGV.AutoGenerateColumns = false;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.moduleIDDataGridViewTextBoxColumn,
            this.rWstartDataGridViewTextBoxColumn,
            this.rWendDataGridViewTextBoxColumn,
            this.enabledDataGridViewTextBoxColumn});
            this.DGV.DataMember = "Table1";
            this.DGV.DataSource = this.dataSet1;
            this.DGV.Location = new System.Drawing.Point(9, 9);
            this.DGV.Name = "DGV";
            this.DGV.RowHeadersVisible = false;
            this.DGV.Size = new System.Drawing.Size(464, 395);
            this.DGV.TabIndex = 147;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            this.DGV.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGV_CellFormatting);
            this.DGV.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellValueChanged);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4});
            this.dataTable1.TableName = "Table1";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "ModuleID";
            // 
            // dataColumn2
            // 
            this.dataColumn2.Caption = "Row Start";
            this.dataColumn2.ColumnName = "RWstart";
            // 
            // dataColumn3
            // 
            this.dataColumn3.Caption = "Row End";
            this.dataColumn3.ColumnName = "RWend";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "Enabled";
            // 
            // moduleIDDataGridViewTextBoxColumn
            // 
            this.moduleIDDataGridViewTextBoxColumn.DataPropertyName = "ModuleID";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.moduleIDDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.moduleIDDataGridViewTextBoxColumn.HeaderText = "Module ID";
            this.moduleIDDataGridViewTextBoxColumn.Name = "moduleIDDataGridViewTextBoxColumn";
            this.moduleIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.moduleIDDataGridViewTextBoxColumn.Width = 120;
            // 
            // rWstartDataGridViewTextBoxColumn
            // 
            this.rWstartDataGridViewTextBoxColumn.DataPropertyName = "RWstart";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.rWstartDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.rWstartDataGridViewTextBoxColumn.HeaderText = "Start Row";
            this.rWstartDataGridViewTextBoxColumn.Name = "rWstartDataGridViewTextBoxColumn";
            this.rWstartDataGridViewTextBoxColumn.ReadOnly = true;
            this.rWstartDataGridViewTextBoxColumn.Width = 120;
            // 
            // rWendDataGridViewTextBoxColumn
            // 
            this.rWendDataGridViewTextBoxColumn.DataPropertyName = "RWend";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.rWendDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.rWendDataGridViewTextBoxColumn.HeaderText = "End Row";
            this.rWendDataGridViewTextBoxColumn.Name = "rWendDataGridViewTextBoxColumn";
            this.rWendDataGridViewTextBoxColumn.Width = 120;
            // 
            // enabledDataGridViewTextBoxColumn
            // 
            this.enabledDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.enabledDataGridViewTextBoxColumn.DataPropertyName = "Enabled";
            this.enabledDataGridViewTextBoxColumn.HeaderText = "Enabled";
            this.enabledDataGridViewTextBoxColumn.Name = "enabledDataGridViewTextBoxColumn";
            this.enabledDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.enabledDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btnRenumber
            // 
            this.btnRenumber.BackColor = System.Drawing.Color.Transparent;
            this.btnRenumber.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRenumber.FlatAppearance.BorderSize = 0;
            this.btnRenumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRenumber.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnRenumber.Image = global::BlockageMonitor.Properties.Resources.add;
            this.btnRenumber.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRenumber.Location = new System.Drawing.Point(251, 472);
            this.btnRenumber.Margin = new System.Windows.Forms.Padding(6);
            this.btnRenumber.Name = "btnRenumber";
            this.btnRenumber.Size = new System.Drawing.Size(72, 72);
            this.btnRenumber.TabIndex = 153;
            this.btnRenumber.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnRenumber.UseVisualStyleBackColor = false;
            this.btnRenumber.Click += new System.EventHandler(this.btnRenumber_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.Enabled = false;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCancel.Image = global::BlockageMonitor.Properties.Resources.Cancel64;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(335, 472);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 72);
            this.btnCancel.TabIndex = 152;
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnClose.Image = global::BlockageMonitor.Properties.Resources.OK;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(429, 472);
            this.btnClose.Margin = new System.Windows.Forms.Padding(6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 72);
            this.btnClose.TabIndex = 151;
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSendSubnet
            // 
            this.btnSendSubnet.BackColor = System.Drawing.Color.Transparent;
            this.btnSendSubnet.FlatAppearance.BorderSize = 0;
            this.btnSendSubnet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendSubnet.Image = global::BlockageMonitor.Properties.Resources.Update4;
            this.btnSendSubnet.Location = new System.Drawing.Point(153, 232);
            this.btnSendSubnet.Name = "btnSendSubnet";
            this.btnSendSubnet.Size = new System.Drawing.Size(72, 72);
            this.btnSendSubnet.TabIndex = 211;
            this.btnSendSubnet.UseVisualStyleBackColor = false;
            this.btnSendSubnet.Click += new System.EventHandler(this.btnSendSubnet_Click);
            // 
            // btnRescan
            // 
            this.btnRescan.BackColor = System.Drawing.Color.Transparent;
            this.btnRescan.FlatAppearance.BorderSize = 0;
            this.btnRescan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRescan.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRescan.Image = global::BlockageMonitor.Properties.Resources.Update;
            this.btnRescan.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRescan.Location = new System.Drawing.Point(252, 232);
            this.btnRescan.Name = "btnRescan";
            this.btnRescan.Size = new System.Drawing.Size(72, 72);
            this.btnRescan.TabIndex = 210;
            this.btnRescan.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnRescan.UseVisualStyleBackColor = false;
            this.btnRescan.Click += new System.EventHandler(this.btnRescan_Click);
            // 
            // tbRows
            // 
            this.tbRows.Location = new System.Drawing.Point(180, 494);
            this.tbRows.Name = "tbRows";
            this.tbRows.Size = new System.Drawing.Size(61, 29);
            this.tbRows.TabIndex = 155;
            this.tbRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbRows.TextChanged += new System.EventHandler(this.tbRows_TextChanged);
            this.tbRows.Enter += new System.EventHandler(this.tbRows_Enter);
            this.tbRows.Validating += new System.ComponentModel.CancelEventHandler(this.tbRows_Validating);
            // 
            // lbRows
            // 
            this.lbRows.AutoSize = true;
            this.lbRows.Location = new System.Drawing.Point(15, 496);
            this.lbRows.Name = "lbRows";
            this.lbRows.Size = new System.Drawing.Size(159, 24);
            this.lbRows.TabIndex = 154;
            this.lbRows.Text = "Rows per Module";
            // 
            // frmModuleConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 551);
            this.Controls.Add(this.tbRows);
            this.Controls.Add(this.lbRows);
            this.Controls.Add(this.btnRenumber);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModuleConfig";
            this.ShowInTaskbar = false;
            this.Text = "Module Config";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmModuleConfig_FormClosed);
            this.Load += new System.EventHandler(this.frmModuleConfig_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lbIP;
        private System.Windows.Forms.Label lbModuleIP;
        private System.Windows.Forms.Label lbSubnet;
        private System.Windows.Forms.ComboBox cbEthernet;
        private System.Windows.Forms.Button btnSendSubnet;
        private System.Windows.Forms.Button btnRescan;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView DGV;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn moduleIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rWstartDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rWendDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn enabledDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnRenumber;
        private System.Windows.Forms.TextBox tbRows;
        private System.Windows.Forms.Label lbRows;
    }
}