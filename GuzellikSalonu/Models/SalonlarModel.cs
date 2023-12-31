using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuzellikSalonu.Models
{
    public class SalonlarModel
    {
        public int SalonNo { get; set; }
        public string SalonAdı { get; set; }
        public int KapıNo { get; set; }
        public string Yapılanİslem { get; set; }
        public int IslemSayısı { get; set; }
    }
}