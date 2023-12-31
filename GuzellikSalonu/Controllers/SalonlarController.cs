using Dapper;
using GuzellikSalonu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuzellikSalonu.Controllers
{
    public class SalonlarController : Controller
    {
        // GET: Salonlar
        public ActionResult Index()
        {
            return View(DP.Listeleme<SalonlarModel>("SalonListe"));
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

                degisken.Add("@SalonNo", id);

                return View(DP.Listeleme<SalonlarModel>("SalonlarByNo", degisken).FirstOrDefault<SalonlarModel>());
            }
        }

        [HttpPost]

        public ActionResult EY(SalonlarModel model)
        {
            DynamicParameters degisken = new DynamicParameters();
            degisken.Add("@SalonNo", model.SalonNo);
            degisken.Add("@SalonAdı", model.SalonAdı);
            degisken.Add("@KapıNo", model.KapıNo);
            degisken.Add("@Yapılanİslem", model.Yapılanİslem);
            degisken.Add("@IslemSayısı", model.IslemSayısı);

            DP.ExecuteReturn("SalonlarEY", degisken);
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id = 0)
        {
            DynamicParameters sil = new DynamicParameters();
            sil.Add("@SalonNo", id);
            DP.ExecuteReturn("SalonlarSil", sil);
            return RedirectToAction("Index");
        }
    }
}