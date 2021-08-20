using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consignment_Store_App
{
    public class Store
    {
        public string Name { get; set; }

        //Each instance will be one vendor, which is why Vendor class is singular.
        //In our Store class, we have items from multiple Vendors (which is why the Vendors property here is plural)
        //The data type for Vendors is List<Vendor> because we have multiple vendors in this Vendors property
        public List<Vendor> Vendors { get; set; }
        //This is the same principle for Items property
        //A List has to be instantiated
        public List<Item> Items { get; set; }

        //Store ( the code below) is a constructor
        public Store()
        {
            //Instantiating Vendors and Items (both of these lists) in the Constructor.
            Vendors = new List<Vendor>();
            Items = new List<Item>();
        }
    }
}
