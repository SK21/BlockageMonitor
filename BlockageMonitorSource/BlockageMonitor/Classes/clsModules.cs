using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockageMonitor
{
    public class clsModules
    {
        public IList<clsModule> Items;
        private int cCount;
        private List<clsModule> cModules = new List<clsModule>();
        private frmStart mf;

        public clsModules(frmStart cf, int Count)
        {
            mf = cf;
            Items = cModules.AsReadOnly();
            Load(Count);
        }

        public int Count
        { get { return cCount; } }

        public void Load(int Count)
        {
            cCount = Count;
            cModules.Clear();
            for (int i = 0; i < Count; i++)
            {
                clsModule Md = new clsModule(mf, i);
                cModules.Add(Md);
                Md.Load();
            }
        }
        public void Save()
        {
            for (int i = 0; i < mf.RowCount; i++)
            {
                cModules[i].Save();
            }
        }
    }
}