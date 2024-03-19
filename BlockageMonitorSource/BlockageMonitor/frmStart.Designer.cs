namespace BlockageMonitor
{
    partial class frmStart
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStart));
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.dataColumn11 = new System.Data.DataColumn();
            this.dataColumn12 = new System.Data.DataColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.mnuSettings = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sensorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnAlarm = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.mnuSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
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
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn8,
            this.dataColumn9,
            this.dataColumn10,
            this.dataColumn11,
            this.dataColumn12});
            this.dataTable1.TableName = "Table1";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "1";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "2";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "3";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "4";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "5";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "6";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "7";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "8";
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "9";
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "10";
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "11";
            // 
            // dataColumn12
            // 
            this.dataColumn12.ColumnName = "12";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // mnuSettings
            // 
            this.mnuSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sensorsToolStripMenuItem,
            this.networkToolStripMenuItem,
            this.transparentToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(182, 116);
            // 
            // sensorsToolStripMenuItem
            // 
            this.sensorsToolStripMenuItem.Image = global::BlockageMonitor.Properties.Resources.Sec1;
            this.sensorsToolStripMenuItem.Name = "sensorsToolStripMenuItem";
            this.sensorsToolStripMenuItem.Size = new System.Drawing.Size(181, 28);
            this.sensorsToolStripMenuItem.Text = "Seed Rows";
            this.sensorsToolStripMenuItem.Click += new System.EventHandler(this.sensorsToolStripMenuItem_Click);
            // 
            // networkToolStripMenuItem
            // 
            this.networkToolStripMenuItem.Image = global::BlockageMonitor.Properties.Resources.SubnetSend;
            this.networkToolStripMenuItem.Name = "networkToolStripMenuItem";
            this.networkToolStripMenuItem.Size = new System.Drawing.Size(181, 28);
            this.networkToolStripMenuItem.Text = "Modules";
            this.networkToolStripMenuItem.Click += new System.EventHandler(this.networkToolStripMenuItem_Click);
            // 
            // transparentToolStripMenuItem
            // 
            this.transparentToolStripMenuItem.Name = "transparentToolStripMenuItem";
            this.transparentToolStripMenuItem.Size = new System.Drawing.Size(181, 28);
            this.transparentToolStripMenuItem.Text = "Transparent";
            this.transparentToolStripMenuItem.Click += new System.EventHandler(this.transparentToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::BlockageMonitor.Properties.Resources.FanOff;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(181, 28);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // chart1
            // 
            chartArea1.AxisY.Maximum = 100D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(12, 12);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(797, 200);
            this.chart1.TabIndex = 189;
            this.chart1.Text = "chart1";
            this.chart1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseMove_MouseDown);
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMove_MouseMove);
            // 
            // btnAlarm
            // 
            this.btnAlarm.BackColor = System.Drawing.Color.Transparent;
            this.btnAlarm.FlatAppearance.BorderSize = 0;
            this.btnAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlarm.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlarm.Image = global::BlockageMonitor.Properties.Resources.Alarm1;
            this.btnAlarm.Location = new System.Drawing.Point(815, 83);
            this.btnAlarm.Name = "btnAlarm";
            this.btnAlarm.Size = new System.Drawing.Size(58, 58);
            this.btnAlarm.TabIndex = 188;
            this.btnAlarm.TabStop = false;
            this.btnAlarm.Text = "X";
            this.btnAlarm.UseVisualStyleBackColor = false;
            this.btnAlarm.Click += new System.EventHandler(this.btnAlarm_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Image = global::BlockageMonitor.Properties.Resources.SettingsGear64;
            this.btnSettings.Location = new System.Drawing.Point(815, 12);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(58, 58);
            this.btnSettings.TabIndex = 172;
            this.btnSettings.TabStop = false;
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // frmStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 222);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.btnAlarm);
            this.Controls.Add(this.btnSettings);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStart";
            this.Text = "Blockage Monitor";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmStart_FormClosed);
            this.Load += new System.EventHandler(this.frmStart_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseMove_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMove_MouseMove);
            this.Resize += new System.EventHandler(this.frmStart_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.mnuSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Data.DataColumn dataColumn9;
        private System.Data.DataColumn dataColumn10;
        private System.Data.DataColumn dataColumn11;
        private System.Data.DataColumn dataColumn12;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnAlarm;
        private System.Windows.Forms.ContextMenuStrip mnuSettings;
        private System.Windows.Forms.ToolStripMenuItem sensorsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem networkToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ToolStripMenuItem transparentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

