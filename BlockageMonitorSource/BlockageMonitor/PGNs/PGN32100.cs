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
        //0 HeaderLo                100
        //1 HeaderHi                125
        //2 Module ID/wifi strength 
        //      bits 0-3, module ID
        //      bit 4   - wifi rssi < -80
        //      bit 5	- wifi rssi < -70
        //      bit 6	- wifi rssi < -65
        //3 sensors 0-7 signals
        //4 sensors 8-15 signals
        //5 CRC

        private const byte cByteCount = 6;
        private const byte HeaderHi = 127;
        private const byte HeaderLo = 101;
        private frmStart mf;
        private byte[] cWifiStrength;

        public PGN32100(frmStart CF)
        {
            mf = CF;
            cWifiStrength = new byte[16];
        }

        public bool ParseByteData(byte[] data)
        {
            byte Bit;
            byte ModuleID;
            bool Result = false;

            if (data[1] == HeaderHi && data[0] == HeaderLo
                && data.Length >= cByteCount && mf.Tls.GoodCRC(data))
            {
                ModuleID = (byte)(data[2] & 0b1111);

                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        Bit = (byte)(2 ^ j);
                        if ((data[3 + i] & Bit) == Bit)
                        {
                            mf.SeedRows.Items[j + i * 8].ReceiveTime = DateTime.Now;
                            mf.SeedRows.Items[j + i * 8].ModuleID = ModuleID;
                        }
                    }
                }

                // wifi strength
                cWifiStrength[ModuleID] = 0;
                if ((data[2] & 0b00000100) == 0b00010000) cWifiStrength[ModuleID] = 1;
                if ((data[2] & 0b00001000) == 0b00100000) cWifiStrength[ModuleID] = 2;
                if ((data[2] & 0b00010000) == 0b01000000) cWifiStrength[ModuleID] = 3;

                Result = true;
            }
            return Result;
        }

        public byte WifiStrength(byte ModuleID)
        {
            return cWifiStrength[ModuleID];
        }
    }
}
