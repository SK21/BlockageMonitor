﻿using System;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;

namespace BlockageMonitor
{
    public partial class frmWifi : Form
    {
        private bool Initializing;
        private frmStart mf;
        private bool FormEdited;

        public frmWifi(frmStart CalledFrom)
        {
            InitializeComponent();
            mf = CalledFrom;

            #region // language
            
            grpHotSpot.Text = Lang.lgHotspot;
            lbPassword.Text = Lang.lgPassword;

            #endregion // language
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            UpdateForm();
            SetButtons(false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!FormEdited)
            {
                this.Close();
            }
            else
            {
                // save settings
                mf.Tls.SaveProperty("WifiSSID", tbSSID.Text);
                mf.Tls.SaveProperty("WifiPassword", tbPassword.Text);

                // IP
                mf.UDPsensors.WifiEP = cbNetworks.Text;
                mf.UDPsensors.EthernetEP = cbEthernet.Text;

                SetButtons(false);
                UpdateForm();
            }
        }

        private void btnRescan_Click(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void btnSetIP_Click(object sender, EventArgs e)
        {
            SetButtons(true);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                mf.Tls.StartWifi();
                UpdateForm();
            }
            catch (Exception ex)
            {
                mf.Tls.ShowHelp("Error starting wifi connection. " + ex.Message, "Wifi", 15000, true);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                mf.Tls.StopWifi();
                UpdateForm();
            }
            catch (Exception ex)
            {
                mf.Tls.ShowHelp("Error closing wifi connection. " + ex.Message, "Wifi", 15000, true);
            }
        }

        private void frmWifi_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                mf.Tls.SaveFormData(this);
            }
        }

        private void frmWifi_Load(object sender, EventArgs e)
        {
            mf.Tls.LoadFormData(this);
            SetDayMode();
            UpdateForm();
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            mf.Tls.DrawGroupBox(box, e.Graphics, this.BackColor, Color.Black, Color.Blue);
        }

        private void LoadCombo()
        {
            // https://stackoverflow.com/questions/6803073/get-local-ip-address
            try
            {
                cbNetworks.Items.Clear();
                foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (item.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 && item.OperationalStatus == OperationalStatus.Up)
                    {
                        foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                cbNetworks.Items.Add(ip.Address.ToString());
                            }
                        }
                    }
                }
                cbNetworks.SelectedIndex = cbNetworks.FindString(SubAddress(mf.UDPsensors.WifiEP));

                cbEthernet.Items.Clear();
                foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (item.NetworkInterfaceType == NetworkInterfaceType.Ethernet && item.OperationalStatus == OperationalStatus.Up)
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
                cbEthernet.SelectedIndex = cbEthernet.FindString(SubAddress(mf.UDPsensors.EthernetEP));

            }
            catch (Exception ex)
            {
                mf.Tls.WriteErrorLog("frmWifi/LoadCombo " + ex.Message);
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
                Result = data[0] + "." + data[1] + "." + data[2];
            }
            return Result;
        }

        private void SetButtons(bool Edited)
        {
            if (!Initializing)
            {
                if (Edited)
                {
                    btnCancel.Enabled = true;
                    btnClose.Image = Properties.Resources.Save;

                    btnStop.Enabled = false;
                    btnStart.Enabled = false;
                    btnRescan.Enabled = false;
                    btnSetIP.Enabled = false;
                    cbNetworks.Enabled = false;
                    tbSSID.Enabled = false;
                    tbPassword.Enabled = false;
                }
                else
                {
                    btnCancel.Enabled = false;
                    btnClose.Image = Properties.Resources.OK;

                    btnStop.Enabled = true;
                    btnStart.Enabled = true;
                    btnRescan.Enabled = true;
                    btnSetIP.Enabled = true;
                    cbNetworks.Enabled = true;
                    tbSSID.Enabled = true;
                    tbPassword.Enabled = true;
                }

                FormEdited = Edited;
            }
        }

        private void SetDayMode()
        {
            this.BackColor = Properties.Settings.Default.DayColour;

            foreach (Control c in this.Controls)
            {
                c.ForeColor = Color.Black;
            }
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            SetButtons(true);
        }

        private void tbSSID_TextChanged(object sender, EventArgs e)
        {
            SetButtons(true);
        }

        private void UpdateForm()
        {
            Initializing = true;
            tbSSID.Text = mf.Tls.LoadProperty("WifiSSID");
            if (tbSSID.Text == "") tbSSID.Text = "tractor";

            tbPassword.Text = mf.Tls.LoadProperty("WifiPassword");
            if (tbPassword.Text == "") tbPassword.Text = "111222333";

            // save in case credentials were blank
            mf.Tls.SaveProperty("WifiSSID", tbSSID.Text);
            mf.Tls.SaveProperty("WifiPassword", tbPassword.Text);

            lbIP.Text = "Selected subnet:  " + mf.UDPsensors.WifiEP;
            lbEthernet.Text = "Selected subnet:  " + mf.UDPsensors.EthernetEP;

            LoadCombo();
            Initializing = false;
        }

        private void btnSetEthernet_Click(object sender, EventArgs e)
        {
            SetButtons(true);
        }
    }
}