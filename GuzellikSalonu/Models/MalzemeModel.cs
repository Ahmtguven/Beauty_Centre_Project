using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuzellikSalonu.Models
{
    public class MalzemeModel
    {
        public int MalzemeNo { get; set; }
        public string MalzemeAdı { get; set; }
        public int MalzemeTutarı { get; set; }
        public string Fayda { get; set; }
        public string Acıklama { get; set; }
        public int HizmetNo { get; set; }
    }
}