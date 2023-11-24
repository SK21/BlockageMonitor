using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BlockageMonitor
{
    public partial class frmStart : Form
    {
        public PGN254 AutoSteerPGN;
        public clsIndicators Indicators;
        public clsSeedRows SeedRows;
        public PGN32100 Sensors;
        public clsTools Tls;
        public UDPComm UDPaog;
        public UDPComm UDPsensors;

        private bool AlarmOn;
        private int cBlockSeconds;
        private int cIndicatorCount = 10;
        private int cRowCount;
        private bool MonitoringOn;

        public frmStart()
        {
            InitializeComponent();
            Tls = new clsTools(this);

            int.TryParse(Tls.LoadProperty("SeedRowCount"), out int Count);
            if (Count == 0) Count = 20;
            cRowCount = Count;
            SeedRows = new clsSeedRows(this, cRowCount);

            int.TryParse(Tls.LoadProperty("BlockSeconds"), out int BS);
            if (BS == 0) BS = 5;
            cBlockSeconds = BS;

            Indicators = new clsIndicators(this);
            Sensors = new PGN32100(this);
            AutoSteerPGN = new PGN254(this);

            UDPaog = new UDPComm(this, 17777, 15555, 1460, "127.255.255.255", true, true);  // AOG
            UDPsensors = new UDPComm(this, 25600, 25700, 2388);    // arduino

            SeedRows.Items[1].Enabled = true;   // test msgbox
        }

        public int BlockSeconds
        { get { return cBlockSeconds; } }

        public int IndicatorCount
        { get { return cIndicatorCount; } }

        public int RowCount
        { get { return cRowCount; } }

        private void btnAlarm_Click(object sender, EventArgs e)
        {
            AlarmOn = !AlarmOn;
            UpdateButtons();
        }

        private void btnFan2_Click(object sender, EventArgs e)
        {
            MonitoringOn = !MonitoringOn;
            timer1.Enabled = MonitoringOn;
            UpdateButtons();
            if (MonitoringOn)
            {
                UpdateGrid();
                //UpdateMsgBox();
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            mnuSettings.Show(ptLowerLeft);
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void DGV_SelectionChanged(object sender, EventArgs e)
        {
            DGV.ClearSelection();
        }

        private void frmStart_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    Tls.SaveFormData(this);
                }

                SeedRows.Save();
                UDPaog.Close();
                UDPsensors.Close();
                timer1.Enabled = false;

                Tls.SaveProperty("SeedRowCount", cRowCount.ToString());
                Tls.SaveProperty("BlockSeconds", cBlockSeconds.ToString());
            }
            catch (Exception)
            {
            }

            Application.Exit();
        }

        private void frmStart_Load(object sender, EventArgs e)
        {
            Tls.LoadFormData(this);
            if (Tls.PrevInstance())
            {
                Tls.ShowHelp(Lang.lgAlreadyRunning, "Help", 3000);
                this.Close();
            }

            DGV.BackgroundColor = DGV.DefaultCellStyle.BackColor;
            DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            timer1.Enabled = MonitoringOn;
            LoadGrid();
            UpdateButtons();

            // UDP
            UDPsensors.StartUDPServer();
            if (!UDPsensors.IsUDPSendConnected)
            {
                Tls.ShowHelp("UDPnetwork failed to start.", "", 3000, true, true);
            }

            UDPaog.StartUDPServer();
            if (!UDPaog.IsUDPSendConnected)
            {
                Tls.ShowHelp("UDPagio failed to start.", "", 3000, true, true);
            }

            this.BackColor = Properties.Settings.Default.DayColour;

            foreach (Control c in this.Controls)
            {
                c.ForeColor = Color.Black;
            }
        }

        private void LoadGrid()
        {
            DGV.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV.RowTemplate.Height = 30;
            //DGV.RowHeadersVisible = false;

            dataSet1.Clear();
            foreach (clsIndicator Ind in Indicators.Items)
            {
                DataRow DR = dataSet1.Tables[0].NewRow();
                dataSet1.Tables[0].Rows.Add(DR);
            }

            foreach (DataGridViewRow Rw in DGV.Rows)
            {
                Rw.HeaderCell.Value = (Rw.Index + 1).ToString();
            }

            for (int i = 0; i < 11; i++)
            {
                DGV.Columns[i].HeaderText = ((10 - i) * -5 - 5).ToString();
            }

            DGV.Columns[11].HeaderText = DateTime.Now.ToString("hh:mm:ss");

            DGV.ClearSelection();
        }

        private void mnuSettings_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void networkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmWifi = new frmWifi(this);
            frmWifi.ShowDialog();
        }

        private void sensorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmSensors = new frmSensors(this);
            frmSensors.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateGrid();
            UpdateMsgBox();
        }

        private void UpdateButtons()
        {
            if (AlarmOn)
            {
                btnAlarm.Text = "";
            }
            else
            {
                btnAlarm.Text = "X";
            }

            if (MonitoringOn)
            {
                btnFan2.Image = Properties.Resources.FanOn;
            }
            else
            {
                btnFan2.Image = Properties.Resources.FanOff;
            }
        }

        private void UpdateGrid()
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < DGV.Rows.Count; j++)
                {
                    DGV.Rows[j].Cells[i].Style.BackColor = DGV.Rows[j].Cells[i + 1].Style.BackColor;
                }
            }

            DGV.Columns[11].HeaderText = DateTime.Now.ToString("hh:mm:ss");

            foreach (clsIndicator Ind in Indicators.Items)
            {
                if (Ind.Blocked())
                {
                    DGV.Rows[Ind.ID].Cells[11].Style.BackColor = Color.Red;
                }
                else
                {
                    DGV.Rows[Ind.ID].Cells[11].Style.BackColor = Color.LightGreen;
                }
            }
        }

        private void UpdateMsgBox()
        {
            foreach (clsSeedRow Rw in SeedRows.Items)
            {
                if (Rw.Enabled && !Rw.Notified)
                {
                    if (Rw.Blocked())
                    {
                        msgBox.AppendText("\r\n" + DateTime.Now.ToString("hh:mm:ss") + ">   Module " + (Rw.ModuleID + 1).ToString() + ",  Seed Row " + (Rw.ID + 1).ToString() + "  blocked.");
                        Rw.Notified = true;
                    }
                }
            }
        }
    }
}