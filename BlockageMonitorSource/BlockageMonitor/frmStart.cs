using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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
        private bool cUseTransparent = false;
        private bool IsTransparent;
        private int LastRowCount;
        private bool PlayAlarm;
        private int TransLeftOffset = 6;
        private int TransTopOffset = 30;
        private int windowLeft = 0;
        private int windowTop = 0;
        private int mouseX = 0;
        private int mouseY = 0;

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
            this.BackColor = Properties.Settings.Default.DayColour;
            chart1.BackColor = Properties.Settings.Default.DayColour;
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

        public bool UseTransparent
        {
            get { return cUseTransparent; }
            set
            {
                cUseTransparent = value;
                Tls.SaveProperty("UseTransparent", cUseTransparent.ToString());
            }
        }

        private void btnAlarm_Click(object sender, EventArgs e)
        {
            PlayAlarm = !PlayAlarm;
            SensorAlarm.PlayAlarm(PlayAlarm);
            SensorAlarm.CheckAlarms();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            mnuSettings.Show(ptLowerLeft);
            UpdateForm();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStart_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (cUseTransparent)
            {
                // move the window back to the default location
                this.Top += -TransTopOffset;
                this.Left += -TransLeftOffset;
            }
            else
            {
                Tls.SaveProperty("StartWidth", this.Width.ToString());
                Tls.SaveProperty("StartHeight", this.Height.ToString());
            }

            if (this.WindowState == FormWindowState.Normal) Tls.SaveFormData(this);
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

            if (bool.TryParse(Tls.LoadProperty("UseTransparent"), out bool tp)) cUseTransparent = tp;
            IsTransparent = !tp;    // to cause update
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

        private void SetTransparent()
        {
            if (cUseTransparent)
            {
                this.TransparencyKey = Properties.Settings.Default.DayColour;
                this.ControlBox = false;
                this.FormBorderStyle = FormBorderStyle.None;
                this.Top += TransTopOffset;
                this.Left += TransLeftOffset;
                IsTransparent = true;

                chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
                chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;

                chart1.BackColor = Properties.Settings.Default.DayColour;
                chart1.ChartAreas[0].BackColor = Properties.Settings.Default.DayColour;
                chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = chart1.ChartAreas[0].BackColor;
                chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = chart1.ChartAreas[0].BackColor;

                chart1.TextAntiAliasingQuality = TextAntiAliasingQuality.SystemDefault;
            }
            else
            {
                this.Text = "Blockage Monitor";
                this.TransparencyKey = Color.Empty;
                this.ControlBox = true;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.Top += -TransTopOffset;
                this.Left += -TransLeftOffset;
                IsTransparent = false;

                chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Black;
                chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Black;

                chart1.BackColor = Color.White;
                chart1.ChartAreas[0].BackColor = Color.White;
                chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = chart1.ChartAreas[0].BackColor;
                chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = chart1.ChartAreas[0].BackColor;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateForm();
            SensorAlarm.CheckAlarms();
        }

        private void transparentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UseTransparent = !cUseTransparent;
            UpdateForm();
        }
        private void mouseMove_MouseDown(object sender, MouseEventArgs e)
        {
            // Log the current window location and the mouse location.
            if (e.Button == MouseButtons.Right)
            {
                windowTop = this.Top;
                windowLeft = this.Left;
                mouseX = e.X;
                mouseY = e.Y;
            }
        }

        private void mouseMove_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                windowTop = this.Top;
                windowLeft = this.Left;

                Point pos = new Point(0, 0);

                pos.X = windowLeft + e.X - mouseX;
                pos.Y = windowTop + e.Y - mouseY;
                this.Location = pos;
            }
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

            if (cUseTransparent != IsTransparent)
            {
                SetTransparent();
                if (IsTransparent)
                {
                    transparentToolStripMenuItem.Image = Properties.Resources.OK;
                }
                else
                {
                    transparentToolStripMenuItem.Image = Properties.Resources.Cancel64;
                }
            }
        }
    }
}