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

        //Creating a Default Commission rate. We create a constructor (a special method) when a new instance of this class gets created.
        //When a class is created, its constructor is called. A class can have multiple constructors that take different arguments
        //Constructors enable the developer to set default values. If you see no return type, like data type or void, you know it is a Constructor.
        //We know the below Vendor is a constructor because there is no return data type. 
        //Vendor Constructor will run whenever the Vendor class is called upon
        public Vendor()
        {
            Commission = .5; //The defualt Commission that each vendor will get is 50%
        }
    }
}
