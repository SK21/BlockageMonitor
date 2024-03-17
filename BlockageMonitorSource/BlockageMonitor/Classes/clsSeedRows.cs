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
        private int cCount;
        private List<clsSeedRow> cSeedRows = new List<clsSeedRow>();
        private frmStart mf;

        public clsSeedRows(frmStart CF, int RowCount)
        {
            mf = CF;
            Items = cSeedRows.AsReadOnly();
            Load(RowCount);
        }

        public int Count
        { get { return cCount; } }

        public void Load(int Count)
        {
            cCount = Count;
            cSeedRows.Clear();
            for (int i = 0; i < Count; i++)
            {
                clsSeedRow Rw = new clsSeedRow(mf, i);
                cSeedRows.Add(Rw);
                Rw.Load();
            }
        }
        public bool RowBlocked()
        {
            bool Result = false;
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Blocked() && Items[i].Enabled)
                {
                    Result = true;
                    break;
                }
            }
            return Result;
        }
        public void Save()
        {
            for (int i = 0; i < mf.RowCount; i++)
            {
                cSeedRows[i].Save();
            }
        }
    }
}