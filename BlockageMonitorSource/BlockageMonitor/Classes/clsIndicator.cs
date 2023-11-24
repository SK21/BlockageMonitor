using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockageMonitor
{
    public class clsIndicator
    {
        private frmStart mf;
        private int cID;

        public clsIndicator(frmStart CF, int ID)
        {
            mf = CF;
            cID = ID;
        }

        public bool Blocked()
        {
            bool Result = false;
            foreach (clsSeedRow Rw in mf.SeedRows.Items)
            {
                if (Rw.IndicatorNumber == cID && Rw.Blocked())
                {
                    Result = true;
                    break;
                }
            }
            return Result;
        }

        public int ID { get { return cID; } }

    }
}
