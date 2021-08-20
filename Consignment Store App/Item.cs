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

        //Creating a new property that will display the Title and the Price of the Item in the Store Item's itemsListbox 
        public string Display
        {
            //get is a read-only property that puts the information together
            get
            {
                //return string.Format lets you mash multiple items together easily.
                //The value for Title gets placed in the {0} section
                //The value for Price gets placed in the {1} section. We have a $ to display that the price is in dollars
                return string.Format("{0} - ${1}", Title, Price); //First value that you place into me goes into the {0} section, the second value goes to the {1}. This is a base 0 counting system (like an array)
            }
        }
    }
}
