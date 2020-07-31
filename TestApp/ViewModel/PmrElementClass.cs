using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ScanPmrWinForm.ViewModel
{
    public class PmrElementClass
    {
        public int Indice { get; set; }
        public Image Fronte { get; set; }
        public Image Retro { get; set; }
        public string Codice { get; set; }
        public string NomeFileFronte { get; set; }
        public string NomeFileRetro { get; set; }
        public bool ErrorScan { get; set; }
        public bool ErrorValidation { get; set; }
        public bool ErrorInsert { get; set; }

       
        public bool InsertSuccess
        {
            get {
                if (!ErrorInsert && !ErrorScan && !ErrorValidation)
                    return true;
                else
                    return false;
                }
            private set { }
           
        }

        public PmrElementClass()
        {

        }

        public PmrElementClass(int indice, Image fronte, Image retro, string codice, string nomeFileFronte, string nomeFileRetro)
        {
            Indice = indice;
            Fronte = fronte ?? throw new ArgumentNullException(nameof(fronte));
            Retro = retro;
            Codice = codice;
            NomeFileFronte = nomeFileFronte ?? throw new ArgumentNullException(nameof(nomeFileFronte));
            NomeFileRetro = nomeFileRetro ?? throw new ArgumentNullException(nameof(nomeFileRetro));
            ErrorScan = string.IsNullOrWhiteSpace(codice) || codice.Length < 11 ? true : false;
            ErrorValidation = false;
            ErrorInsert = false;
            InsertSuccess = false;
        }
    }
}
