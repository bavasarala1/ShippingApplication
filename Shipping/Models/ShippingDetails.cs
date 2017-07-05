using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shipping.Models
{
    public class ShippingDetails
    {
        public string FullName{ get; set; }
        public int OrderSubTotal { get; set; }
        public int SalesTax { get; set; }
        public int ShipCharge { get; set; }
        public int OrderTotal { get; set; }
        public List<ShipType> ShipOption { get; set; }
    }
    public class ShipType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Charge { get; set; }
        public Boolean Select { get; set; }
    }
}