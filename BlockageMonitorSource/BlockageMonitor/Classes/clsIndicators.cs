using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockageMonitor
{
    public class clsIndicators
    {
        public IList<clsIndicator> Items;
        private List<clsIndicator> cIndicators = new List<clsIndicator>();
        private frmStart mf;

        public clsIndicators(frmStart CF)
        {
            mf = CF;
            Items = cIndicators.AsReadOnly();
            Load();
        }

        public void Load()
        {
            cIndicators.Clear();
            for (int i = 0; i < mf.IndicatorCount; i++)
            {
                clsIndicator Ind = new clsIndicator(mf, i);
                cIndicators.Add(Ind);
            }
        }
    }
}
