using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BlockageMonitor
{
    public class clsSeedRows
    {
        public IList<clsSeedRow> Items;
        private List<clsSeedRow> cSeedRows = new List<clsSeedRow>();
        private frmStart mf;
        private int cCount;

        public clsSeedRows(frmStart CF, int RowCount)
        {
            mf = CF;
            Items = cSeedRows.AsReadOnly();
            cCount = RowCount;
            Load();
        }

        public void Load()
        {
            cSeedRows.Clear();
            for (int i = 0; i < cCount; i++)
            {
                clsSeedRow Rw = new clsSeedRow(mf, i);
                cSeedRows.Add(Rw);
                Rw.Load();
            }
        }

        public void Save()
        {
            for(int i=0;i<cCount;i++)
            {
                cSeedRows[i].Save();
            }
        }
    }
}
