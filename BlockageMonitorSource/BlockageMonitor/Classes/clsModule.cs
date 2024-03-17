﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlockageMonitor
{
    public class clsModule
    {
        private bool cEdited;
        private bool cEnabled;
        private int cEndRow;
        private int cID;
        private int cStartRow;
        private frmStart mf;
        private string Name;

        public clsModule(frmStart cf, int ID)
        {
            mf = cf;
            cID = ID;
            Name = "ModuleID" + ID.ToString();
            cEnabled = true;
        }

        public bool Edited
        { get { return cEdited; } }

        public bool Enabled
        { get { return cEnabled; } set { cEnabled = value; } }

        public int EndRow
        {
            get { return cEndRow; }
            set
            {
                if (cEndRow != value)
                {
                    cEndRow = value;
                    cEdited = true;
                }
            }
        }

        public int ID
        { get { return cID; } }

        public int StartRow
        {
            get { return cStartRow; }
            set
            {
                if (cStartRow != value)
                {
                    cStartRow = value;
                    cEdited = true;
                }
            }
        }


        public bool IsValid()
        {
            bool Result = (cStartRow > -1 && cStartRow <= mf.RowCount && cEndRow >= cStartRow && cEndRow <= mf.RowCount);
            return Result;
        }

        public void Load()
        {
            if (int.TryParse(mf.Tls.LoadProperty(Name + "_Start"), out int sr)) cStartRow = sr;
            if (int.TryParse(mf.Tls.LoadProperty(Name + "_End"), out int er)) cEndRow = er;
            if (bool.TryParse(mf.Tls.LoadProperty(Name + "_Enabled"), out bool en)) cEnabled = en;
        }

        public void Save()
        {
            if (cEdited)
            {
                if (IsValid())
                {
                    mf.Tls.SaveProperty(Name + "_Start", cStartRow.ToString());
                    mf.Tls.SaveProperty(Name + "_End", cEndRow.ToString());
                    mf.Tls.SaveProperty(Name + "_Enabled", cEnabled.ToString());
                    cEdited = false;
                }
            }
        }
    }
}