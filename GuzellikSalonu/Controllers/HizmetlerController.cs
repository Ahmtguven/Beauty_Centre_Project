using Dapper;
using GuzellikSalonu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuzellikSalonu.Controllers
{
    public class HizmetlerController : Controller
    {
        // GET: Hizmetler
        public ActionResult Index()
        {
            return View(DP.Listeleme<HizmetlerModel>("HizmetlerListe"));
        }

        public ActionResult EY(int id = 0)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                DynamicParameters degisken = new DynamicParameters();

                degisken.Add("@HizmetNo", id);

                return View(DP.Listeleme<HizmetlerModel>("HizmetlerByNo", degisken).FirstOrDefault<HizmetlerModel  >());
            }
        }

        [HttpPost]

        public ActionResult EY(HizmetlerModel model)
        {
            DynamicParameters degisken = new DynamicParameters();
            degisken.Add("@HizmetNo", model.HizmetNo);
            degisken.Add("@HizmetAdı", model.HizmetAdı);
            degisken.Add("@HizmetAmacı", model.HizmetAmacı);
            degisken.Add("@Tutar", model.Tutar);
            degisken.Add("@OdemeTuru", model.OdemeTuru);
            degisken.Add("@GorevliNo", model.GorevliNo);


            DP.ExecuteReturn("HizmetEY", degisken);
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id = 0)
        {
            DynamicParameters sil = new DynamicParameters();
            sil.Add("@HizmetNo", id);
            DP.ExecuteReturn("HizmetSil", sil);
            return RedirectToAction("Index");
        }
    }
}