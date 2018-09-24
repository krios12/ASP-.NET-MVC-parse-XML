using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zaliczenie.Models;

namespace Zaliczenie.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult XmlDisplay()
        {
            var data = new List<PrzykladowyModel>();
            data = ZwrocDane();
            return View(data);


        }

        private List<PrzykladowyModel> ZwrocDane()
        {
            string xmldane = Server.MapPath("~/XMLFile/Data.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(xmldane);

            var customerlist = new List<PrzykladowyModel>();
            customerlist =
            (
              from rows in ds.Tables[0].AsEnumerable()
              select new PrzykladowyModel
              {
                 Id = Convert.ToInt32(rows[0].ToString()),
                 Imie = rows[1].ToString(),
                 Nazwisko = rows[2].ToString(),
                 Telefon = Convert.ToInt32(rows[3].ToString()),
              }
            ).ToList();
            return customerlist;

        }
    }
}