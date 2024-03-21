using System;

namespace BlockageMonitor
{
    public class PGN32200
    {
        // to monitor from sensors
        //0 HeaderLo                0xC8
        //1 HeaderHi                0x7D
        //2 Module/Product
        //3 Row         ID
        //4 Rate Lo     counts
        //5 Rate Hi     
        //6 Threshold
        //7 CRC

        private const byte cByteCount = 6;
        private const byte HeaderHi = 0x7D;
        private const byte HeaderLo = 0xC8;
        private frmStart mf;

        public PGN32200(frmStart CF)
        {
            mf = CF;
        }

        public bool ParseByteData(byte[] data)
        {
            bool Result = false;

            if (data[1] == HeaderHi && data[0] == HeaderLo && data.Length >= cByteCount)
            {
                byte ModuleID = (byte)(data[2] >> 4);
                byte RowID = data[3];
                clsModule Md = mf.BlockageModules.Items[ModuleID];
                mf.SeedRows.Items[Md.StartRow + RowID].ReceiveTime = DateTime.Now;
                mf.SeedRows.Items[Md.StartRow + RowID].Rate = data[4];
                Result = true;
            }

            return Result;
        }
    }
}