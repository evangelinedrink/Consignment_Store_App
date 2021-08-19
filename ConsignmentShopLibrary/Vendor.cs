using System;
using System.Collections.Generic;
using System.Text;

namespace ConsignmentShopLibrary
{
    public class Vendor
    {
        //Set of Properties. We are going to create an auto property for the first name. Properties can be read-write (they have a get and a set acessor)
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Commission { get; set; }
    }
}
