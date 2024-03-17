using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockageMonitor
{
    public class PGN32100
    {
        // to monitor from sensors
        //0 HeaderLo                0x64, 100
        //1 HeaderHi                0x7D, 125
        //2 Module ID/row
        //      bits 0-3, module ID
        //      bits 4-7, row ID
        //3 rate
        //4 CRC

        private const byte cByteCount = 5;
        private const byte HeaderHi = 0x7D;
        private const byte HeaderLo = 0x64;
        private frmStart mf;

        public PGN32100(frmStart CF)
        {
            mf = CF;
        }

        public bool ParseByteData(byte[] data)
        {
            byte ModuleID;
            byte RowID;
            bool Result = false;

            if (data[1] == HeaderHi && data[0] == HeaderLo && data.Length >= cByteCount && mf.Tls.GoodCRC(data))
            {
                ModuleID = (byte)(data[2] & 0b1111);
                RowID = (byte)(data[2] >> 4);
                clsModule Md = mf.BlockageModules.Items[ModuleID];
                mf.SeedRows.Items[Md.StartRow + RowID].ReceiveTime = DateTime.Now;
                mf.SeedRows.Items[Md.StartRow + RowID].Rate = data[3];
                Result = true;
            }
            return Result;
        }
    }
}