using System;
using System.Drawing;
using System.Windows.Forms;

namespace BlockageMonitor
{
    public partial class frmStart : Form
    {
        public readonly int MaxModules = 16;
        public readonly int MaxRows = 100;
        public readonly int MaxRowsPerModule = 16;
        public PGN254 AutoSteerPGN;
        public clsModules BlockageModules;
        public clsSeedRows SeedRows;
        public clsAlarm SensorAlarm;
        public PGN32100 Sensors;
        public clsTools Tls;
        public UDPComm UDPaog;
        public UDPComm UDPsensors;

        private int ButtonRight;
        private int cBlockSeconds = 10;
        private bool cMonitoringOn;
        private int cRowCount = 10;
        private int cRowsPerModule = 16;
        private int LastRowCount;
        private bool PlayAlarm;

        public frmStart()
        {
            InitializeComponent();
            Tls = new clsTools(this);

            ButtonRight = this.Width - btnSettings.Left;

            LoadData();
            UDPsensors = new UDPComm(this, 25600, 25700, 2388, "Sensors");
            UDPaog = new UDPComm(this, 17777, 15555, 1460, "AOG");

            SeedRows = new clsSeedRows(this, cRowCount);
            Sensors = new PGN32100(this);
            AutoSteerPGN = new PGN254(this);
            BlockageModules = new clsModules(this, 16);
            SensorAlarm = new clsAlarm(this);
        }

        public int BlockSeconds
        {
            get { return cBlockSeconds; }
            set
            {
                cBlockSeconds = value;
                Tls.SaveProperty("BlockSeconds", cBlockSeconds.ToString());
            }
        }

        public int RowCount
        {
            get { return cRowCount; }
            set
            {
                cRowCount = value;
                Tls.SaveProperty("SeedRowCount", cRowCount.ToString());
            }
        }

        public int RowsPerModule
        {
            get { return cRowsPerModule; }
            set
            {
                if (value > 0 && value <= MaxRowsPerModule)
                {
                    cRowsPerModule = value;
                    Tls.SaveProperty("RowsPerModule", cRowsPerModule.ToString());
                }
            }
        }

        private void btnAlarm_Click(object sender, EventArgs e)
        {
            PlayAlarm = !PlayAlarm;
            SensorAlarm.PlayAlarm(PlayAlarm);
            SensorAlarm.CheckAlarms();
        }

        private void btnPower_Click(object sender, EventArgs e)
        {
            cMonitoringOn = !cMonitoringOn;
            timer1.Enabled = cMonitoringOn;
            if (cMonitoringOn)
            {
                SensorAlarm.PlayAlarm(PlayAlarm);
            }
            else
            {
                SensorAlarm.PlayAlarm(false);
            }
            UpdateForm();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            mnuSettings.Show(ptLowerLeft);
            UpdateForm();
        }

        private void frmStart_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal) Tls.SaveFormData(this);
            Tls.SaveProperty("StartWidth", this.Width.ToString());
            Tls.SaveProperty("StartHeight", this.Height.ToString());
            UDPaog.Close();
            UDPsensors.Close();
        }

        private void frmStart_Load(object sender, EventArgs e)
        {
            try
            {
                Tls.LoadFormData(this);
                if (Tls.PrevInstance())
                {
                    Tls.ShowHelp(Lang.lgAlreadyRunning, "Help", 3000);
                    this.Close();
                }
                // UDP
                UDPsensors.StartUDPServer();
                if (!UDPsensors.IsUDPSendConnected)
                {
                    Tls.ShowHelp("UDPsensors failed to start.", "", 3000, true, true);
                }

                UDPaog.StartUDPServer();
                if (!UDPaog.IsUDPSendConnected)
                {
                    Tls.ShowHelp("UDPagio failed to start.", "", 3000, true, true);
                }

                LoadChart();

                cMonitoringOn = true;
                timer1.Enabled = cMonitoringOn;
                SensorAlarm.PlayAlarm(PlayAlarm);

                UpdateForm();
            }
            catch (Exception ex)
            {
                Tls.ShowHelp("Failed to load properly: " + ex.Message, "Help", 30000, true);
                Close();
            }
        }

        private void frmStart_Resize(object sender, EventArgs e)
        {
            try
            {
                btnSettings.Left = this.Width - ButtonRight;
                btnAlarm.Left = this.Width - ButtonRight;
                btnPower.Left = this.Width - ButtonRight;

                chart1.Width = (int)(btnSettings.Left - 18);
                chart1.Height = this.Height - 61;
            }
            catch (Exception)
            {
            }
        }

        private void LoadChart()
        {
            chart1.ChartAreas[0].AxisY.Maximum = Double.NaN;
            chart1.ChartAreas[0].AxisY.Minimum = Double.NaN;
            chart1.ChartAreas[0].RecalculateAxesScale();
            chart1.ResetAutoValues();

            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            chart1.ChartAreas["ChartArea1"].AxisX.Maximum = cRowCount + 1;
            for (int i = 0; i <= cRowCount; i++)
            {
                chart1.Series["Series1"].Points.AddXY(i + 1, 0);
            }
            LastRowCount = cRowCount;
        }

        private void LoadData()
        {
            if (int.TryParse(Tls.LoadProperty("SeedRowCount"), out int rc)) cRowCount = rc;
            if (int.TryParse(Tls.LoadProperty("BlockSeconds"), out int bs)) cBlockSeconds = bs;
            if (int.TryParse(Tls.LoadProperty("RowsPerModule"), out int rws)) cRowsPerModule = rws;

            if (int.TryParse(Tls.LoadProperty("StartWidth"), out int wd))
            {
                if (wd > 100 && wd < 1500) this.Width = wd;
            }
            else
            {
                this.Width = 897;
            }

            if (int.TryParse(Tls.LoadProperty("StartHeight"), out int ht))
            {
                if (ht > 100 && ht < 1000) this.Height = ht;
            }
            else
            {
                this.Height = 261;
            }
        }

        private void networkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fs = Tls.IsFormOpen("frmModuleConfig");

            if (fs != null)
            {
                fs.Focus();
                return;
            }

            Form frm = new frmModuleConfig(this);
            frm.Show();
        }

        private void sensorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fs = Tls.IsFormOpen("frmSeedRows");

            if (fs != null)
            {
                fs.Focus();
                return;
            }

            Form frm = new frmSeedRows(this);
            frm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateForm();
            SensorAlarm.CheckAlarms();
        }

        private void UpdateForm()
        {
            // chart
            if (cRowCount != LastRowCount) LoadChart();

            chart1.Series["Series1"].Points.Clear();
            foreach (clsSeedRow RW in SeedRows.Items)
            {
                chart1.Series["Series1"].Points.AddXY(RW.ID + 1, RW.RateAverage);
            }

            // buttons
            if (PlayAlarm)
            {
                btnAlarm.Text = "";
            }
            else
            {
                btnAlarm.Text = "X";
            }

            if (cMonitoringOn)
            {
                btnPower.Image = Properties.Resources.FanOn;
            }
            else
            {
                btnPower.Image = Properties.Resources.FanOff;
            }
        }
    }
}