using MaiAnhNam_baihat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaiAnhNam_baihat.Controllers
{
    public class BaiHatsController : Controller
    {
        // GET: BaiHats
        public ActionResult Index()
        {
            BaiHatList strBH = new BaiHatList();
            List<QLBaiHat> obj = strBH.getBaiHat(string.Empty);

            return View(obj);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(QLBaiHat strBH)
        {
            if (ModelState.IsValid)
            {
                BaiHatList BH = new BaiHatList();
                BH.AddBaiHat(strBH);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(string id = "")
        {
            BaiHatList BH = new BaiHatList();
            List<QLBaiHat> obj = BH.getBaiHat(id);
            return View(obj.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(QLBaiHat strBH)
        {
            BaiHatList BH = new BaiHatList();
            BH.EditBaiHat(strBH);
            return RedirectToAction("Index");

        }
        public ActionResult Delete(string id = "")
        {
            BaiHatList BH = new BaiHatList();
            List<QLBaiHat> obj = BH.getBaiHat(id);
            return View(obj.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(QLBaiHat strBH)
        {
            BaiHatList BH = new BaiHatList();
            BH.Delete(strBH);
            return RedirectToAction("Index");

        }
        public ActionResult Details(string id = "") //giong delete(id)
        {
            BaiHatList BH = new BaiHatList();
            List<QLBaiHat> obj = BH.getBaiHat(id);
            return View(obj.FirstOrDefault());
        }



    }
}