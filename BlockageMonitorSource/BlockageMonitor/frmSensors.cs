using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BlockageMonitor
{
    public partial class frmSensors : Form
    {
        private bool FormEdited;
        private bool Initializing;
        private frmStart mf;

        public frmSensors(frmStart CF)
        {
            InitializeComponent();
            mf = CF;
        }

        private void frmSensors_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                mf.Tls.SaveFormData(this);
            }
        }

        private void frmSensors_Load(object sender, EventArgs e)
        {
            mf.Tls.LoadFormData(this);
            DGV.BackgroundColor = DGV.DefaultCellStyle.BackColor;

            this.BackColor = Properties.Settings.Default.DayColour;

            foreach (Control c in this.Controls)
            {
                c.ForeColor = Color.Black;
            }
            UpdateForm();
        }

        private void SetButtons(bool Edited)
        {
            if (!Initializing)
            {
                if (Edited)
                {
                    btnCancel.Enabled = true;
                    btnClose.Image = Properties.Resources.Save;
                }
                else
                {
                    btnCancel.Enabled = false;
                    btnClose.Image = Properties.Resources.OK;
                }

                FormEdited = Edited;
            }
        }

        private void UpdateForm()
        {
            try
            {
                Initializing = true;
                tbRows.Text = mf.RowCount.ToString();

                dataSet1.Clear();
                foreach (clsSeedRow Rw in mf.SeedRows.Items)
                {
                    DataRow DR = dataSet1.Tables[0].NewRow();
                    DR[0] = Rw.ModuleID;
                    DR[1] = Rw.ID;
                    DR[2] = Rw.IndicatorNumber;
                    DR[3] = Rw.Enabled;
                    DR[4] = Rw.ReceiveTime;

                    dataSet1.Tables[0].Rows.Add(DR);
                }

                Initializing = false;
            }
            catch (Exception ex)
            {
                mf.Tls.WriteErrorLog("frmSensors/UpdateForm" + ex.Message);
            }
        }
    }
}