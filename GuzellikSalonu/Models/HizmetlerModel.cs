using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuzellikSalonu.Models
{
    public class HizmetlerModel
    {
        public int HizmetNo { get; set; }
        public string HizmetAdı { get; set; }
        public string HizmetAmacı { get; set; }
        public int Tutar { get; set; }
        public string OdemeTuru { get; set; }
        public int GorevliNo { get; set; }
    }
}