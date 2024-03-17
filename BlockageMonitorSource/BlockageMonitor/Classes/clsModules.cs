using System.Collections.Generic;

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

        public void BuildRows(int RowsPerModule)
        {
            int RowCount = 0;
            int CurrentModule = 0;
            for (int i = 0; i < cCount; i++)
            {
                cModules[i].StartRow = 0;
                cModules[i].EndRow = 0;
            }

            foreach (clsSeedRow RW in mf.SeedRows.Items)
            {
                if (RW.Enabled)
                {
                    if (cModules[CurrentModule].StartRow == 0) cModules[CurrentModule].StartRow = RW.ID + 1;
                    RowCount++;
                    if (RowCount >= RowsPerModule)
                    {
                        RowCount = 0;
                        CurrentModule++;
                    }
                }
                if (CurrentModule > cCount - 1) CurrentModule = cCount - 1;
            }

            for (int i = 0; i < cCount; i++)
            {
                if (cModules[i].StartRow > 0)
                {
                    if (cModules[i + 1].StartRow == 0)
                    {
                        cModules[i].EndRow = mf.SeedRows.Count;
                    }
                    else
                    {
                        cModules[i].EndRow = cModules[i + 1].StartRow - 1;
                    }
                }
                else
                {
                    cModules[i].EndRow = 0;
                }
            }

            if (cModules[cCount - 1].StartRow > 0)
            {
                cModules[cCount - 1].EndRow = mf.SeedRows.Count;
            }
            else
            {
                cModules[cCount - 1].EndRow = 0;
            }
        }

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
            for (int i = 0; i < cCount; i++)
            {
                cModules[i].Save();
            }
        }

        public void UpdateRows(int ID, int End, int RowsPerModule)
        {
            bool Done = false;
            if (End <= mf.SeedRows.Count && End > -1 && ID > -1 && ID < cCount)
            {
                if (cModules[ID].StartRow > 0)
                {
                    cModules[ID].EndRow = End;
                    if (cModules[ID].EndRow < cModules[ID].StartRow) cModules[ID].EndRow = cModules[ID].StartRow;
                    for (int i = ID + 1; i < cCount; i++)
                    {
                        if (cModules[i - 1].EndRow < mf.SeedRows.Count && !Done)
                        {
                            cModules[i].StartRow = cModules[i - 1].EndRow + 1;
                            if (cModules[i].EndRow < cModules[i].StartRow) cModules[i].EndRow = cModules[i].StartRow + RowsPerModule - 1;
                            if (cModules[i].EndRow > mf.SeedRows.Count) cModules[i].EndRow = mf.SeedRows.Count;
                        }
                        else
                        {
                            Done = true;
                            cModules[i].StartRow = 0;
                            cModules[i].EndRow = 0;
                        }
                    }
                }
            }
        }
    }
}