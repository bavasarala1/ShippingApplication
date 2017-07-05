using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shipping.Models;

namespace Shipping.Controllers
{
    public class ShippingController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetCharge(int ID)
        {

            return Json(new { charge=DriveCharge(ID) }, JsonRequestBehavior.AllowGet);
        }


        // POST: Shipping/Create
        [HttpPost]
        public ActionResult Create(Shippings ship)
        {
            
            try
            {
                ShippingDetails SD = new ShippingDetails();
                SD.FullName = ship.FullName;
                SD.OrderSubTotal = 20;
                SD.SalesTax = 6;
                SD.ShipOption = DriveShipOption(ship.ShipType);
                if (ship.ShipType == 1)
                    SD.ShipCharge = 0;
                else
                    SD.ShipCharge = 5;

                SD.OrderTotal = SD.OrderSubTotal + SD.SalesTax + SD.ShipCharge;
                return View("ShipDetails", SD);
            }
            catch
            {
                return View();
            }
        }

        private List<ShipType> DriveShipOption(int iType)
        {
            List<ShipType> ShipTypes = new List<ShipType>();
            
            if (iType == 1)
            {
                ShipType shiptype = new ShipType();
                shiptype.Name = "Free Shipping";
                shiptype.ID = 1;
                shiptype.Charge = 0;
                shiptype.Select = true;
                ShipTypes.Add(shiptype);
            }
            else
            {

                for (int i = 1; i < iType; i++)
                {
                    ShipType shiptype1 = new ShipType();
                    if (i == 1)
                    {
                        shiptype1.Name = "Free Shipping";
                    }
                    else
                    {
                        shiptype1.Name = "Economy Shipping" + (i-1).ToString();
                    }
                    shiptype1.ID = i;
                    shiptype1.Charge = (i-1)*5;
                    if (i == 2)
                        shiptype1.Select = true;
                    else
                        shiptype1.Select = false;

                    ShipTypes.Add(shiptype1);

                }
                ShipType shiptypeex = new ShipType();
                shiptypeex.Name = "Express Shipping";
                shiptypeex.ID = 99;
                shiptypeex.Charge =500;
                shiptypeex.Select = false;
                ShipTypes.Add(shiptypeex);
            }        
            return ShipTypes;
        }



        private decimal DriveCharge(int ID)
        {

            if (ID == 99)
            {
                return 500;
            }
            else
                return (ID - 1) * 5;
        }
    }
}
