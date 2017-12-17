﻿using SantaClauseVillage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SantaClauseVillageMongoDB = SantaClauseVillage.Classes.MongoDB;

namespace SantaClauseVillage.Controllers
{
    public class ToysController : Controller
    {
        // GET: Toys
        public ActionResult ToysList()
        {
            if (Session["ID"] != null)
            {
                SantaClauseVillageMongoDB db = new SantaClauseVillageMongoDB();
                var toys = db.GetAllToys();
                Models.ToysModel model = new ToysModel();
                model.EntityList = toys.ToList();
                //model.instanceDB = db;
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}