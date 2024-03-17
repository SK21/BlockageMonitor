using AgOpenGPS;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BlockageMonitor
{
    public partial class frmSeedRows : Form
    {
        private bool FormEdited;
        private bool Initializing;
        private frmStart mf;

        public frmSeedRows(frmStart CF)
        {
            InitializeComponent();
            mf = CF;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!FormEdited)
            {
                this.Close();
            }
            else
            {
                Save();
                SetButtons(false);
                UpdateForm();
            }
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

        private void Save()
        {
            try
            {
                for (int i = 0; i < DGV.Rows.Count; i++)
                {
                    // enabled
                    string val = DGV.Rows[i].Cells[2].EditedFormattedValue.ToString();
                    if (val == "") val = "0";
                    if (bool.TryParse(val, out bool en)) mf.SeedRows.Items[i].Enabled = en;
                }
                mf.SeedRows.Save();

                if (int.TryParse(tbRows.Text, out int rs)) mf.RowCount = rs;
                if (int.TryParse(tbSeconds.Text, out int sec)) mf.BlockSeconds = sec;
            }
            catch (Exception ex)
            {
                mf.Tls.ShowHelp(ex.Message, this.Text, 3000, true);
                UpdateForm();
            }
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

        private void tbRows_Enter(object sender, EventArgs e)
        {
            double tempD;
            double.TryParse(tbRows.Text, out tempD);
            using (var form = new FormNumeric(1, mf.MaxRows, tempD))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tbRows.Text = form.ReturnValue.ToString();
                }
            }
        }

        private void tbRows_TextChanged(object sender, EventArgs e)
        {
            SetButtons(true);
        }

        private void tbRows_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                double tempD;
                double.TryParse(tbRows.Text, out tempD);
                if (tempD < 1 || tempD > mf.MaxRows)
                {
                    System.Media.SystemSounds.Exclamation.Play();
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                mf.Tls.ShowHelp(ex.Message, this.Text, 3000, true);
            }
        }

        private void tbSeconds_Enter(object sender, EventArgs e)
        {
            double tempD;
            double.TryParse(tbSeconds.Text, out tempD);
            using (var form = new FormNumeric(1, 120, tempD))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tbSeconds.Text = form.ReturnValue.ToString();
                }
            }
        }

        private void tbSeconds_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                double tempD;
                double.TryParse(tbSeconds.Text, out tempD);
                if (tempD < 1 || tempD > 120)
                {
                    System.Media.SystemSounds.Exclamation.Play();
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                mf.Tls.ShowHelp(ex.Message, this.Text, 3000, true);
            }
        }

        private void UpdateForm()
        {
            try
            {
                Initializing = true;
                tbRows.Text = mf.RowCount.ToString();
                tbSeconds.Text = mf.BlockSeconds.ToString();

                dataSet1.Clear();
                foreach (clsSeedRow Rw in mf.SeedRows.Items)
                {
                    DataRow DR = dataSet1.Tables[0].NewRow();
                    DR[0] = Rw.ID;
                    DR[1] = Rw.ModuleID;
                    DR[2] = Rw.Enabled;

                    dataSet1.Tables[0].Rows.Add(DR);
                }

                Initializing = false;
            }
            catch (Exception ex)
            {
                mf.Tls.WriteErrorLog("frmSeedRows/UpdateForm" + ex.Message);
            }
        }
    }
}