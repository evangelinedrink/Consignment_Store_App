using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Consignment_Store_App
{
    public partial class ConsignmentStoreUI : Form
    {
        private Store store = new Store();
        public ConsignmentStoreUI()
        {
            InitializeComponent();
        }

        private void SetupData()
        {
            //We are adding a new Vendor. There are two ways to add a vendor below. The first way is shown then the second way.
            //First way to add a Vendor
            Vendor demoVendor = new Vendor(); //This is a new vendor object
            demoVendor.FirstName = "Evangeline"; //Adding the three items that the vendor needs in the Vendor class
            demoVendor.LastName = "Drink";
            //demoVendor.Commission = .5; //We already have a default Commission in the Vendor() constructor in the Vendor.cs class file
            store.Vendors.Add(demoVendor); //The demoVendor that we have added above will then be added to the Vendors list that is contained in the Store class

            //We can create another vendor by taking all of the lines above and then just changing the three fields for the Vendor
            demoVendor = new Vendor(); //This is a new vendor object
            demoVendor.FirstName = "Daniel"; //Adding the three items that the vendor needs in the Vendor class
            demoVendor.LastName = "Borleau";
            //demoVendor.Commission = .5;
            store.Vendors.Add(demoVendor); //The demoVendor that we have added above will then be added to the Vendors list that is contained in the Store class


            //Second way to add a Vendor (this is an easier way to add the vendors)
            store.Vendors.Add(new Vendor { FirstName = "Quentin", LastName = "Debussy" }); //New instance of a Vendor is located inside of the parenthesis (right after the Add method). The curly braces allows us to populate the Vendor's information with the initial objects with its values. The curly braces lets us populate the information for the Vendor
        }
    }
}
