using AgOpenGPS;
using System;
using System.Data;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;

namespace BlockageMonitor
{
    public partial class frmModuleConfig : Form
    {
        public frmStart mf;
        private bool FormEdited;
        private bool Initializing;

        public frmModuleConfig(frmStart cf)
        {
            InitializeComponent();
            mf = cf;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mf.BlockageModules.Load(mf.MaxModules);
            UpdateForm();
            SetButtons(false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!FormEdited)
            {
                // exit
                this.Close();
            }
            else
            {
                // save
                // IP
                mf.UDPsensors.NetworkEP = cbEthernet.Text;

                Save();
                SetButtons(false);
                UpdateForm();
            }
        }

        private void btnRescan_Click(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void btnSendSubnet_Click(object sender, EventArgs e)
        {
            PGN32503 SetSubnet = new PGN32503(mf);
            if (SetSubnet.Send(mf.UDPsensors.NetworkEP))
            {
                mf.Tls.ShowHelp("New Subnet address sent.", "Subnet", 10000);
            }
            else
            {
                mf.Tls.ShowHelp("New Subnet address not sent.", "Subnet", 10000);
            }
        }

        private void cbEthernet_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtons(true);
        }

        private void DGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
            {
                if (e.Value.ToString() == "0")
                {
                    e.Value = "";
                    e.FormattingApplied = true;
                }
            }
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1)
            {
                e.CellStyle.BackColor = this.BackColor;
            }
        }

        private void frmModuleConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            mf.Tls.SaveFormData(this);
        }

        private void frmModuleConfig_Load(object sender, EventArgs e)
        {
            mf.Tls.LoadFormData(this);
            DGV.BackgroundColor = DGV.DefaultCellStyle.BackColor;
            SetDayMode();
            UpdateForm();
        }

        private void LoadCombo()
        {
            // https://stackoverflow.com/questions/6803073/get-local-ip-address
            try
            {
                cbEthernet.Items.Clear();
                foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if ((item.NetworkInterfaceType == NetworkInterfaceType.Ethernet || item.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) && item.OperationalStatus == OperationalStatus.Up)
                    {
                        foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                cbEthernet.Items.Add(ip.Address.ToString());
                            }
                        }
                    }
                }
                cbEthernet.SelectedIndex = cbEthernet.FindString(SubAddress(mf.UDPsensors.NetworkEP));
            }
            catch (Exception ex)
            {
                mf.Tls.WriteErrorLog("frmModuleConfig/LoadCombo " + ex.Message);
            }
        }

        private void Save()
        {
            try
            {
                for (int i = 0; i < DGV.Rows.Count; i++)
                {
                    for (int j = 1; j < 4; j++)
                    {
                        string val = DGV.Rows[i].Cells[j].EditedFormattedValue.ToString();
                        if (val == "") val = "0";
                        switch (j)
                        {
                            case 1:
                                // start row
                                if (int.TryParse(val, out int sr)) mf.BlockageModules.Items[i].StartRow = sr;
                                break;

                            case 2:
                                // end row
                                if (int.TryParse(val, out int er)) mf.BlockageModules.Items[i].EndRow = er;
                                break;

                            case 3:
                                // enabled
                                if (bool.TryParse(val, out bool en)) mf.BlockageModules.Items[i].Enabled = en;
                                break;
                        }
                    }
                }
                mf.BlockageModules.Save();

                if (int.TryParse(tbRows.Text, out int rws)) mf.RowsPerModule = rws;
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
                    btnRescan.Enabled = false;
                    btnSendSubnet.Enabled = false;
                }
                else
                {
                    btnCancel.Enabled = false;
                    btnClose.Image = Properties.Resources.OK;
                    btnRescan.Enabled = true;
                    btnSendSubnet.Enabled = true;
                }

                FormEdited = Edited;
            }
        }

        private void SetDayMode()
        {
            try
            {
                this.BackColor = Properties.Settings.Default.DayColour;

                for (int i = 0; i < tabControl1.TabCount; i++)
                {
                    tabControl1.TabPages[i].BackColor = Properties.Settings.Default.DayColour;
                }
            }
            catch (Exception ex)
            {
                mf.Tls.ShowHelp(ex.Message, this.Text, 3000, true);
            }
        }

        private string SubAddress(string Address)
        {
            IPAddress IP;
            string[] data;
            string Result = "";

            if (IPAddress.TryParse(Address, out IP))
            {
                data = Address.Split('.');
                Result = data[0] + "." + data[1] + "." + data[2] + ".";
            }
            return Result;
        }

        private void UpdateForm()
        {
            Initializing = true;
            LoadCombo();

            dataSet1.Clear();
            foreach (clsModule Md in mf.BlockageModules.Items)
            {
                DataRow DR = dataSet1.Tables[0].NewRow();
                DR[0] = Md.ID + 1;
                DR[1] = Md.StartRow;
                DR[2] = Md.EndRow;
                DR[3] = Md.Enabled;

                dataSet1.Tables[0].Rows.Add(DR);
            }

            tbRows.Text = mf.RowsPerModule.ToString();

            Initializing = false;
        }

        private void DGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!Initializing) SetButtons(true);
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                double tempD;
                string val = DGV.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                switch (e.ColumnIndex)
                {
                    case 2:
                        // end row
                        double.TryParse(val, out tempD);
                        using (var form = new FormNumeric(1, mf.SeedRows.Count, tempD))
                        {
                            var result = form.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                DGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = form.ReturnValue;
                                string zz = DGV.Rows[e.RowIndex].Cells[0].EditedFormattedValue.ToString();
                                int.TryParse(zz, out int ID);
                                mf.BlockageModules.UpdateRows(ID-1, (int)form.ReturnValue, 16);
                                UpdateForm();
                            }
                        }
                        break;

                    case 3:
                        // enabled
                        if (bool.TryParse(val, out bool en))
                        {
                            string zz = DGV.Rows[e.RowIndex].Cells[0].EditedFormattedValue.ToString();
                            int.TryParse(zz, out int ID);
                            mf.BlockageModules.Items[ID-1].Enabled = en;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                mf.Tls.WriteErrorLog("frmModuleConfig/DGV_CellClick: " + ex.Message);
            }
        }

        private void btnRenumber_Click(object sender, EventArgs e)
        {
            mf.BlockageModules.BuildRows(mf.RowsPerModule);
            UpdateForm();
            SetButtons(true);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRenumber.Enabled = tabControl1.SelectedIndex == 1;
        }

        private void tbRows_Enter(object sender, EventArgs e)
        {
            double tempD;
            double.TryParse(tbRows.Text, out tempD);
            using (var form = new FormNumeric(1, mf.MaxRowsPerModule, tempD))
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
                if (tempD < 1 || tempD > mf.MaxRowsPerModule)
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
    }
}