using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockageMonitor
{
    public class clsAlarm
    {
        private bool cPlayAlarm;
        private frmStart mf;
        private System.Media.SoundPlayer Sounds;

        public clsAlarm(frmStart CF)
        {
            mf = CF;
            System.IO.Stream Str = Properties.Resources.TF022;
            Sounds = new System.Media.SoundPlayer(Str);
        }

        public void CheckAlarms()
        {
            if (cPlayAlarm)
            {
                if (mf.SeedRows.RowBlocked()) Sounds.Play();
            }
            else
            {
                Sounds.Stop();
            }
        }

        public void PlayAlarm(bool Play)
        {
            cPlayAlarm = Play;
        }
    }
}
