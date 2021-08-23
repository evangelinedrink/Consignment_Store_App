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

        //Creating a List to store items that the user would like to purchase
        //When the client clicks on "Add to Cart", the items that the user would like to buy will be in a list. This list will be displayed in the shoppingCartListbox
        //shoppingCartData will contain the list of items that the user would like to purchase
        //Information about List<T> Class can be found here: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-5.0 
        private List<Item> shoppingCartData = new List<Item>();

        //BindingSource makes sure that the items in the shoppingCartData list will be displayed in the shoppingCartListBox
        BindingSource cartBinding = new BindingSource();

        //BindingSource to show the vendors in the vendorListbox1
        BindingSource vendorsBinding = new BindingSource();

        //Creating a variable that will determine the profit that the store will make
        private decimal storeProfit = 0;

        //ConsignmentStoreUI() is a Constructor because it has no return type (no void, class, or data type), which means it is called when CosgnmentStoreUI is called
        public ConsignmentStoreUI()
        {
            InitializeComponent();
            SetupData();
            
            //Linking our items data to be displayed in the Store Items's itemsListBox that can be seen by the user
            //Where function is a filter. The list conists of every item (every item is given a variable x), where x.Sold is equal to false. This means that the items will be in the Store Item's itemsListbox if the item's Sold property is equal to false. If the item's Sold property is equal to True, than it will not be in Store Item's list.
            //ToList() means the items are being returned to the Store Item's itemsListBox. This has to be done otherwise the items will not be placed into a list (it will just be floating around)
            itemsBinding.DataSource = store.Items.Where(x => x.Sold ==false).ToList(); //Linking our items to the itemsBinding (which is a BindingSource). The data source for the itemsBinding (where it gets its data) is from the Items list in the Store
            //Need to link our itemsListBox to our itemsBinding Source. This will give us our items to display in the itemsListBox in our Consignment Store app
            itemsListBox.DataSource = itemsBinding; //Linking our Items data to the itemsListBox in our Consignment Store app

            //The code below will display what we would like to see in the Store Item's itemsListbox
            itemsListBox.DisplayMember = "Display"; //One property that can be displayed. Display is in parenthesis because it will be displayed as a string on the app. Display is a property in our Item.cs file. We will be getting the Title and Price for each item based on the Display properties information.
            itemsListBox.ValueMember = "Display";

            /*Displaying the items that the user would like to purchase in the shoppingCartListBox*/
            cartBinding.DataSource = shoppingCartData;  //Our list of items that the user will buy is equal to the cartBinding.DataSource (cartBinding is from the BindingSource)
            shoppingCartListbox.DataSource = cartBinding; //The listbox for the shopping cart (shoppingCartListbox) will get the data of items to be purchased from the cartBinding (which is a Binding Source type)

            //The Display Member and the Value Member will be shown in the shopping cart list box in the app
            //One property that can be displayed. Display is in parenthesis because it will be displayed as a string on the app. Display is a property in our Item.cs file. We will be getting the Title and Price for each item based on the Display properties information.
            shoppingCartListbox.DisplayMember = "Display";
            shoppingCartListbox.ValueMember = "Display";

            //Displaying the vendors in the vendors in the vendorListbox1
            vendorsBinding.DataSource = store.Vendors;
            vendorListbox1.DataSource = vendorsBinding;
            //We want to display in the vendorListbox 1 the name of the vendor and how much the store owes each vendor
            vendorListbox1.DisplayMember = "Display"; //Display is a method in the Vendor.cs file
            vendorListbox1.ValueMember = "Display";
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

        //If you want to delete an Event that was placed by you by clicking on the toolbox item in the front-end design of the app (in this case, we created the event  by clicking on the button), make sure to click on the item that you created the event for (in this case the button).
        //Then click on the Lightning Bolt (which is for Event handlers) and delete the event on the right hand side of the table, then click away from that section. This will delete the Event handler.
        //If this code is still in the cs file after deleting the event in the Design section of the app, you can now remove/delete this code from the file. There will be no error on the design end of your app.
        //If you don't follow these steps, your design for the app will not work anymore
        //This event will work (run) when the user clicks on the Add To Cart --> button
        private void addToCart_Click(object sender, EventArgs e) //There are two parameters passed in that are required for an event to work: object sender and EventArgs e 
        {
            //This button should do are: Figure out what is selected from the items list
            //Copy that item to the shopping cart
            //Do we remove the item from the items list? No

            /*In the code below, we have:
             1) Figured out what is selected from the items list
            2) Copy selected item(s) to the shopping cart list
            */
            //SelectedItem is normally an object, so if we know the type it is, we can state it by typing in what is highlighted in blue/green below (in this case it is Item)
            //SelectedItem knows what is selected in the ListBox and it will get (read) or set (update) that selected item. SelectedItem is a Microsoft built too.
            Item selectedItem = (Item)itemsListBox.SelectedItem; //selectedItem is of type Item. SelectedItem is in a selectedItem variable. The Item and (Item) tells us what type it is. The selected item is of type Item (it is formulated by the Item class)

            //ShoppingCartData is our list that contains the items that the user would like to buy.
            //Whenever a user has selected item(s) to buy, the selected items will be added to the shoppingCartData list
            //cartBinding.DataSource has been bounded with the shoppingCartData (line 48), so this will be displayed in the shoppingCartListBox
            shoppingCartData.Add(selectedItem);

            //We need to tell the data binding to refresh that the information has been changed so our selected items can be displayed in the shoppingCartListbox.
            //If we want to change the entire list (meaning we want the values to be different), the ResetBindings will be True
            cartBinding.ResetBindings(false); //Whenever we add something to our shopping cart list, we need to have ResetBindings to ensure that the items selected will be shown in the shoppingCartListbox

            //Display selected item in the MessageBox
            MessageBox.Show("You have selected the following item(s) to be purchased: "+ selectedItem.Title);
            
            //MessageBox.Show("I have been clicked!");
        }

        private void makePurchase_Click(object sender, EventArgs e)
        {
            //Mark each item in the cart as sold (if we look at the Store.cs class, we see that there is a Sold property)
            //Clear the Cart (once the item(s) have been purchased, clear the shopping cart list)

            //Each item in the shoppring cart list will be marked as Sold (this is a property in the Store class, found in Store.cs file)
            foreach(Item item in shoppingCartData)
            {
                item.Sold = true;

                //Whenever an item is sold, the vendor will then get money from the purchase
                //Multiply the commission (it was originally a double, but we made it into a decimal) times the price of the item (its data type is a decimal)
                item.Owner.PaymentDue += (decimal)item.Owner.Commission * item.Price;

                //The amount of profit that the store will make (the store gets 50% of the profit from the items sold)
                storeProfit += (1-(decimal)item.Owner.Commission) * item.Price;
            }

            /*Updating the Store Item's List and the Shopping Cart's List when the user clicks on the Purchase button*/
            //Clearing the shopping cart list
            shoppingCartData.Clear();

            //We have to let the computer know that we want to update the Store Item's list to contain only the items where its Sold property is equal to false (Item has not been sold yet)
            //Items that have Sold= true, should not be in the itemsBinding list (Store Item's list)
            //The code below has to be restated here otherwise the Store Item's list won't remove the items that have been sold from its list. It has to be displayed here because makePurchase_Click is a new method
            itemsBinding.DataSource = store.Items.Where(x => x.Sold == false).ToList();

            //The store's profit will display in the storeProfitValue label in the UI (right next to the label that says "Store Profit: "
            //The {0:.00} will display up to two decimal places in the dollar amount
            storeProfitValue.Text= string.Format("${0:.00}", storeProfit); //The information from storeProfit will be displayed in the label

            //We need to reset the bindings to make sure that the shopping cart list will refresh and not show the data
            cartBinding.ResetBindings(false);

            //Whenever we change something in a list, we have to modifiy the binding.
            //Since the Store Item's list is being updated (it will only display items that have not yet been Sold, Sold property is False), the binding needs to reflect this
            itemsBinding.ResetBindings(false);

            //Need to update the bindings for the vendors. By doing this, the vendors in the vendorsListbox will display the amount of money they will get when their items are sold in the store
            vendorsBinding.ResetBindings(false);
        }
    }
}
