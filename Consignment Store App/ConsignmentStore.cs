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
        //Initiating our Store class, the name of the variable is store. 
        private Store store = new Store();

        //BindingSource is going to place our items data into the Store Items List Box in the Design Tab
        BindingSource itemsBinding = new BindingSource(); //Initiate our itemsBinding with type BindingSource

        //ConsignmentStoreUI() is a Constructor because it has no return type (no void, class, or data type), which means it is called when CosgnmentStoreUI is called
        public ConsignmentStoreUI()
        {
            InitializeComponent();
            SetupData();
            
            //Linking our items data to be displayed in the Store Items's itemsListBox that can be seen by the user
            itemsBinding.DataSource = store.Items; //Linking our items to the itemsBinding (which is a BindingSource). The data source for the itemsBinding (where it gets its data) is from the Items list in the Store
            //Need to link our itemsListBox to our itemsBinding Source. This will give us our items to display in the itemsListBox in our Consignment Store app
            itemsListBox.DataSource = itemsBinding; //Linking our Items data to the itemsListBox in our Consignment Store app

            //The code below will display what we would like to see in the Store Item's itemsListbox
            itemsListBox.DisplayMember = "Display"; //One property that can be displayed. Display is in parenthesis because it is a property in our Item.cs file. We will be getting the Title and Price for each item based on the Display properties information.
            itemsListBox.ValueMember = "Display";

        }

        //SetupData() is a method. This method takes care of filling up the application with data
        private void SetupData()
        {
            //We are adding a new Vendor. There are two ways to add a vendor below. The first way is shown then the second way.
            //First way to add a Vendor
            Vendor demoVendor = new Vendor(); //This is a new vendor object. This is Instantiation because we state that it is using the Vendor class on the right of the equal sign. On the left of the equal sign, we have the variable name (demoVendor) and the type of the variable (which is the Vendor class)
            //Once we Instantiate a class (like demoVendor in the line above), we can then invoke methods on it. We can also invoke properties, which is seen in the line below.
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


            //Adding Items that will be sold in the Consignment Store
            store.Items.Add(new Item 
            { 
                Title = "Moby Dick", 
                Description = "A book about a whale.", 
                Price = 4.50M, // M after price converts the double data type to a Decimal data type.
                Owner = store.Vendors[1] //The book belongs to Daniel Borleau
            });  

            store.Items.Add(new Item
            {
                Title = "A Tale of Two Cities",
                Description = "A book about a revolution.",
                Price = 5.80M, 
                Owner = store.Vendors[0]
            });

            store.Items.Add(new Item
            {
                Title = "Harry Potter Book 2",
                Description = "A book about a wizard and his friends.",
                Price = 3.70M,
                Owner = store.Vendors[2]
            });

            store.Items.Add(new Item
            {
                Title = "Harry Potter Book 1",
                Description = "A book about a wizard and his friends.",
                Price = 3.70M,
                Owner = store.Vendors[2]
            });

            store.Items.Add(new Item
            {
                Title = "The Cafe on the Edge of the World",
                Description = "A book about being content in life.",
                Price = 7.15M,
                Owner = store.Vendors[0]
            });

            store.Items.Add(new Item
            {
                Title = "Last Days: Survival Guide",
                Description = "A book about how to live your life during the last days of living.",
                Price = 10.90M,
                Owner = store.Vendors[0]
            });

            //The Name of Our Consignment Store
            store.Name = "Knowledge Through Words";
        }
    }
}
