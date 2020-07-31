using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScanPmrWinForm.Models
{
    public class ARSCAN
    {
        public byte[] IMMAGINE_FRONTE { get; set; }

        public byte[] IMMAGINE_RETRO { get; set; }

        public string CODE_BAR { get; set; }

        public string CODE_OPE_SCAN { get; set; }

        public ARSCAN(byte[] iMMAGINE_FRONTE, byte[] iMMAGINE_RETRO, string cODE_BAR, string cODE_OPE_SCAN)
        {
            IMMAGINE_FRONTE = iMMAGINE_FRONTE ?? throw new ArgumentNullException(nameof(iMMAGINE_FRONTE));
            IMMAGINE_RETRO = iMMAGINE_RETRO ?? throw new ArgumentNullException(nameof(iMMAGINE_RETRO));
            CODE_BAR = cODE_BAR ?? throw new ArgumentNullException(nameof(cODE_BAR));
            CODE_OPE_SCAN = cODE_OPE_SCAN ?? throw new ArgumentNullException(nameof(cODE_OPE_SCAN));
        }
    }
}
