using System;

namespace BlockageMonitor
{
    public class clsSeedRow
    {
        private bool cEdited;
        private bool cEnabled;
        private int cID;
        private bool cNotified;
        private byte cRate;
        private byte cRateAve;
        private DateTime cReceiveTime;
        private frmStart mf;
        private string Name;

        public clsSeedRow(frmStart CF, int ID)
        {
            mf = CF;
            cID = ID;
            Name = "SeedRow" + ID.ToString();
            cEnabled = true;
        }

        public bool Enabled
        {
            get { return cEnabled; }
            set
            {
                if (cEnabled != value) cEdited = true;
                cEnabled = value;
            }
        }
        public int ModuleID
        {
            get
            {
                int Result = 0;
                foreach (clsModule Md in mf.BlockageModules.Items)
                {
                    if (ID >= Md.StartRow && ID <= Md.EndRow)
                    {
                        Result = Md.ID;
                        break;
                    }
                }
                return Result;
            }
        }

        public int ID
        { get { return cID; } }

        public bool Notified
        { get { return cNotified; } set { cNotified = value; } }

        public byte Rate
        {
            get { return cRate; }
            set
            {
                cRate = value;
                cRateAve = (byte)(cRateAve * 0.8 + value * 0.2);
            }
        }

        public byte RateAverage
        { get { return cRateAve; } }

        public DateTime ReceiveTime
        { get { return cReceiveTime; } set { cReceiveTime = value; } }

        public bool Blocked()
        {
            bool Result = false;
            double Sec = (DateTime.Now - ReceiveTime).TotalSeconds;
            Result = (Sec > mf.BlockSeconds);
            if (!Result) Notified = false;  // reset notifed
            return Result;
        }

        public void Load()
        {
            if (bool.TryParse(mf.Tls.LoadProperty(Name + "_Enabled"), out bool en)) cEnabled = en;
        }

        public void Save()
        {
            if (cEdited)
            {
                mf.Tls.SaveProperty(Name + "_Enabled", cEnabled.ToString());
                cEdited = false;
            }
        }
    }
}