using Dapper;
using GuzellikSalonu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuzellikSalonu.Controllers
{
    public class MalzemeController : Controller
    {
        // GET: Malzeme
        public ActionResult Index()
        {
            return View(DP.Listeleme<MalzemeModel>("MalzemeListe"));
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

                degisken.Add("@MalzemeNo", id);

                return View(DP.Listeleme<MalzemeModel>("MalzemeByNo", degisken).FirstOrDefault<MalzemeModel>());
            }
        }

        [HttpPost]

        public ActionResult EY(MalzemeModel model)
        {
            DynamicParameters degisken = new DynamicParameters();
            degisken.Add("@MalzemeNo", model.MalzemeNo);
            degisken.Add("@MalzemeAdı", model.MalzemeAdı);
            degisken.Add("@MalzemeTutarı", model.MalzemeTutarı);
            degisken.Add("@Fayda", model.Fayda);
            degisken.Add("@Acıklama", model.Acıklama);
            degisken.Add("@HizmetNo", model.HizmetNo);


            DP.ExecuteReturn("MalzemeEY", degisken);
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id = 0)
        {
            DynamicParameters sil = new DynamicParameters();
            sil.Add("@MalzemeNo", id);
            DP.ExecuteReturn("MalzemeSil", sil);
            return RedirectToAction("Index");
        }
    }
}