using System;

namespace BlockageMonitor
{
    public class clsSeedRow
    {
        private bool cEnabled;
        private int cID;
        private int cIndicatorNumber;
        private DateTime cReceiveTime;
        private bool cSensorConnected;
        private frmStart mf;
        private string Name;
        private bool cNotified;
        private int cModuleID;

        public clsSeedRow(frmStart CF, int ID)
        {
            mf = CF;
            cID = ID;
            Name = "SeedRow" + cID.ToString();
            //cReceiveTime= DateTime.Now;
        }

        public bool Enabled
        { get { return cEnabled; } set { cEnabled = value; } }
        public int ID
        { get { return cID; } }

        public int ModuleID
        {
            get { return cModuleID; }
            set
            {
                cModuleID = value;
            }
        }

        public int IndicatorNumber
        {
            get { return cIndicatorNumber; }
            set
            {
                if (value < mf.IndicatorCount)
                {
                    cIndicatorNumber = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public DateTime ReceiveTime
        { get { return cReceiveTime; } set { cReceiveTime = value; } }

        public bool SensorConnected
        { get { return cSensorConnected; } set { cSensorConnected = value; } }

        public bool Notified { get { return cNotified; } set { cNotified = value; } }

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
            if (int.TryParse(mf.Tls.LoadProperty(Name + "_IndicatorNumber"), out int ID))
            {
                cIndicatorNumber = ID;
            }
            else
            {
                // new record
                int RowsPerIndicator = mf.RowCount / mf.IndicatorCount;
                int NewID = (cID + ModuleID * 16) / RowsPerIndicator;
                if (NewID > mf.IndicatorCount - 1) NewID = mf.IndicatorCount - 1;
                cIndicatorNumber = NewID;
            }
        }

        public void Save()
        {
            mf.Tls.SaveProperty(Name + "_IndicatorNumber", cIndicatorNumber.ToString());
        }
    }
}