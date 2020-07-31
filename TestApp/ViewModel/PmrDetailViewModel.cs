using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ScanPmrWinForm.ViewModel
{
    public class PmrDetailViewModel
    {
        public string BarCode { get; set; }

        public Image ImgPmr { get; set; }

        public PmrDetailViewModel()
        {
                
        }

        public PmrDetailViewModel(string barCode, Image imgPmr)
        {
            BarCode = barCode ?? throw new ArgumentNullException(nameof(barCode));
            ImgPmr = imgPmr ?? throw new ArgumentNullException(nameof(imgPmr));
        }
    }
}
