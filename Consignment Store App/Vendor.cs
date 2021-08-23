using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consignment_Store_App
{
    public class Vendor
    {
        //Set of Properties. We are going to create an auto property for the first name. Properties can be read-write (they have a get and a set acessor)
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Commission { get; set; }
        //New Property that is the amount of money that we owe each vendor once their item gets sold. This PaymentDue p
        public decimal PaymentDue { get; set; }

        //Creating a Default Commission rate. We create a constructor (a special method) when a new instance of this class gets created.
        //When a class is created, its constructor is called. A class can have multiple constructors that take different arguments
        //Constructors enable the developer to set default values. If you see no return type, like data type or void, you know it is a Constructor.
        //We know the below Vendor is a constructor because there is no return data type. 
        //Vendor Constructor will run whenever the Vendor class is called upon
        public Vendor()
        {
            Commission = .5; //The defualt Commission that each vendor will get is 50%
        }

        //Creating a new property that will display the Name of the Vendor and how much the Consignment Store owes each vendor in the Vendors's vendorListbox1 
        public string Display
        {
            //get is a read-only property that puts the information together
            get
            {
                //return string.Format lets you mash multiple items together easily.
                //The first name of the vendor gets placed in the {0} section
                //The last name of the vendor gets placed in the {1} section
                //The value for how much money is owed to the vendor gets placed in the {2} section. We have a $ to display that the price is in dollars
                //The {2:.00} will display up to two decimal places for the dollar amount
                return string.Format("{0} {1} - ${2:.00}", FirstName, LastName, PaymentDue); //First value that you place into me goes into the {0} section, the second value goes to the {1}. This is a base 0 counting system (like an array)
            }
        }
    }
}
