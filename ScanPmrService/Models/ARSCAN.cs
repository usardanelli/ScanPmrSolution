using System;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
namespace ScanPmrService.Models
{

    [DataContract]
    public class ARSCAN
    {

        [DataMember]
        public byte[] IMMAGINE_FRONTE { get; set; }

        [DataMember]
        public byte[] IMMAGINE_RETRO { get; set; }

        [DataMember]
        public string CODE_BAR { get; set; }

        [DataMember]
        public string CODE_OPE_SCAN { get; set; }

        public ARSCAN(byte[] iMMAGINE_FRONTE, byte[] iMMAGINE_RETRO, string cODE_BAR, string cODE_OPE_SCAN)
        {
            IMMAGINE_FRONTE = iMMAGINE_FRONTE ?? throw new ArgumentNullException(nameof(iMMAGINE_FRONTE));
            IMMAGINE_RETRO = iMMAGINE_RETRO ?? throw new ArgumentNullException(nameof(iMMAGINE_RETRO));
            CODE_BAR = cODE_BAR ?? throw new ArgumentNullException(nameof(cODE_BAR));
            CODE_OPE_SCAN = cODE_OPE_SCAN ?? throw new ArgumentNullException(nameof(cODE_OPE_SCAN));
        }

        public void Validation()
        {
            // Create regex
            Regex rx = new Regex(@"[^0-9a-zA-Z]", RegexOptions.IgnoreCase);
            if (rx.IsMatch(CODE_OPE_SCAN))
            {
                throw new ArgumentOutOfRangeException("CODE_OPE_SCAN");
            }

            if(rx.IsMatch(CODE_BAR))
            {
                throw new ArgumentOutOfRangeException("CODE_BAR");
            }

        }
    }
}