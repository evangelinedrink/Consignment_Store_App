using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consignment_Store_App
{
    public class Item
    {
        //There are 6 properties for the Item class
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Sold { get; set; }
        public bool PaymentDistributed { get; set; }
        public Vendor Owner { get; set; } //Vendor class is already in the ConsignmentStoreLibrary folder, which is why it can be called here.
    }
}
