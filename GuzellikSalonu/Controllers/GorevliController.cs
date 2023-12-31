using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using GuzellikSalonu.Models;
using Dapper;

namespace GuzellikSalonu.Controllers
{
    public class GorevliController : Controller
    {
        // GET: Gorevli
        public ActionResult Index()
        {
            return View(DP.Listeleme<GorevliModel>("GorevliListe"));
        }

        public ActionResult EY(int id = 0)
        {
            if(id == 0)
            {
                return View();
            }
            else
            {
                DynamicParameters degisken = new DynamicParameters();

                degisken.Add("@GorevliNo", id);

                return View(DP.Listeleme<GorevliModel>("GorevliByNo",degisken).FirstOrDefault<GorevliModel>());
            }
        }

        [HttpPost]

        public ActionResult EY(GorevliModel model)
        {
            DynamicParameters degisken = new DynamicParameters();
            degisken.Add("@GorevliNo", model.GorevliNo);
            degisken.Add("@AdSoyad", model.AdSoyad);
            degisken.Add("@Yas", model.Yas);
            degisken.Add("@Telefon", model.Telefon);
            degisken.Add("@MesaiDurumu", model.MesaiDurumu);
            degisken.Add("@Maas", model.Maas);
            degisken.Add("@Prim", model.Prim);
            degisken.Add("@SalonNo", model.SalonNo);

            DP.ExecuteReturn("GorevliEY", degisken);
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id = 0)
        {
            DynamicParameters sil = new DynamicParameters();
            sil.Add("@GorevliNo", id);
            DP.ExecuteReturn("GorevliSil", sil);
            return RedirectToAction("Index");
        }
    }
}