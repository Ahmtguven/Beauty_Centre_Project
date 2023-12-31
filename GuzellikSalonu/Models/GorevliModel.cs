using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuzellikSalonu.Models
{
    public class GorevliModel
    {
        public int GorevliNo {  get; set; }
        public string AdSoyad { get; set; }
        public int Yas { get; set; }
        public string Telefon { get; set; }
        public string MesaiDurumu { get; set; }
        public int Maas { get; set; }
        public int Prim { get; set; }
        public int SalonNo { get; set; }

    }
}