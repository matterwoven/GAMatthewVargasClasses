﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GAMatthewVargasClasses
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Declare a list of Items
        List<Item> inventory;

        // And a Shopping Cart Object
        ShoppingCart cart;

        public MainWindow()
        {
            InitializeComponent();
            PreloadInventory();

            // Add to lbInventory ItemsSource
            lbInventory.ItemsSource = inventory;

            cart = new ShoppingCart("Wills Mart");

            lbShopping.ItemsSource = cart.ItemsInCart;


        } // MainWindow

        private void lbInventory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // I Am GRABBING the selected INDEX of the object
            int selectedIndex = lbInventory.SelectedIndex;
            Item selectedItem = inventory[selectedIndex];

            rtbItemDescription.Text = "";


            rtbItemDescription.Text += $"Name: {selectedItem.Name}\n";
            rtbItemDescription.Text += $"Desciption: {selectedItem.Description}\n";
            rtbItemDescription.Text += $"Price: {selectedItem.Price.ToString("c")}\n";
            rtbItemDescription.Text += $"Discount: {selectedItem.DiscountedAmount().ToString("c")}\n";
            rtbItemDescription.Text += $"Total Price: {selectedItem.CalculateTotalPrice().ToString("c")}\n";

            //Name: Salt
            //Desciption: Balsamic
            //Price: $18.74
            //Discount: $4.50
            //Total Price: $14.24
            //Useful info, storing here still
        } // lbInventory_SelectionChanged

        private void btnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = lbInventory.SelectedIndex;
            Item selectedItem = inventory[selectedIndex];

            cart.AddItem(selectedItem);

            // Refresh Cart Display
            lbShopping.Items.Refresh();

        } // btnAddToCart_Click

        private void btnTotalTransaction_Click(object sender, RoutedEventArgs e)
        {
            rtbReceipt.Text = cart.Receipt();
        } // btnTotalTransaction_Click

        // PreloadInventory

        public void PreloadInventory()
        {
            inventory = new List<Item>
            {
                new Item("Yogurt", "Premium cut", 17.56, 0.2),
                new Item("Salt", "Soothing blend", 13.15, 0.64),
                new Item("Strawberries", "Crisp and fresh", 6.95, 0.18),
                new Item("Tomatoes", "Local farm product", 16.43, 0.57),
                new Item("Fish", "Starchy and filling", 1.68, 0.01),
                new Item("Garlic", "Freshwater", 11.83, 0.08),
                new Item("Salt", "Balsamic", 18.74, 0.24),
                new Item("Bread", "Lean and healthy", 7.91, 0.37),
                new Item("Lettuce", "Ripe and juicy", 16.81, 0.82),
                new Item("Beef", "Vitamin-rich", 11.44, 0.28),
                new Item("Quinoa", "Free-range", 3.17, 0.53),
                new Item("Tofu", "Spicy and colorful", 13.63, 0.44),
                new Item("Herbs", "Steel-cut", 3.23, 0.78),
                new Item("Bread", "Vitamin-rich", 16.96, 0.7),
                new Item("Soda", "High-protein", 1.71, 0.56),
                new Item("Peppers", "Balsamic", 11.93, 0.05),
                new Item("Chicken", "Lean and healthy", 12.11, 0.54),
                new Item("Quinoa", "Low-calorie", 9.26, 0.16),
                new Item("Beef", "Organic and fresh", 4.27, 0.29),
                new Item("Cheese", "Seedless variety", 7.94, 0.35),
                new Item("Soda", "Seedless variety", 2.11, 0.22),
                new Item("Olive Oil", "Fruit spread", 8.35, 0.36),
                new Item("Oats", "Crunchy snack", 3.56, 0.08),
                new Item("Ginger", "Zesty", 4.71, 0.71),
                new Item("Bread", "Crisp and fresh", 10.76, 0.5),
                new Item("Nuts", "Fruit spread", 8.76, 0.97),
                new Item("Peppers", "Grass-fed beef", 15.47, 0.78),
                new Item("Tofu", "Sugar-free", 10.21, 0.72),
                new Item("Nuts", "Local farm product", 16.03, 0.42),
                new Item("Vinegar", "Maple-flavored", 11.46, 0.35),
                new Item("Potatoes", "Freshly ground", 13.6, 0.77),
                new Item("Oats", "Grass-fed beef", 10.05, 0.71),
                new Item("Coffee", "Sweet treat", 6.92, 0.08),
                new Item("Chocolate", "Assorted herbs", 3.88, 0.9),
                new Item("Candy", "Sugar-free", 1.04, 0.8),
                new Item("Soda", "Juicy and flavorful", 6.42, 0.93),
                new Item("Pasta", "Premium cut", 10.34, 0.48),
                new Item("Jam", "Crunchy snack", 7.38, 0.51),
                new Item("Beef", "100% natural", 5.52, 0.68),
                new Item("Chocolate", "Fresh and tasty", 13.71, 0.32),
                new Item("Butter", "Vitamin-rich", 8.63, 0.3),
                new Item("Ketchup", "Full of flavor", 17.83, 0.97),
                new Item("Banana", "Crunchy snack", 8.8, 0.49),
                new Item("Herbs", "Extra virgin", 17.56, 0.14),
                new Item("Pepper", "Full of flavor", 13.66, 1.0),
                new Item("Water", "Steel-cut", 2.0, 1.0),
                new Item("Pepper", "Sweet and crunchy", 13.68, 0.58),
                new Item("Cheese", "Seedless variety", 4.03, 0.87),
                new Item("Tea", "Full of flavor", 9.9, 0.72),
                new Item("Grapes", "Sweet treat", 19.73, 0.05) }; }
            

                private class Item
        {
            string _name;
            string _description;
            double _price;
            double _discount;

            public Item(string name, string description, double price, double discount)
            {

                _name = name;
                _description = description;
                Price = price;
                Discount = discount;

            }

            public Item(string name, double price)
            {
                _name = name;
                Price = price;
                _description = "";
                Discount = 0;
            }

            public string Name
            {
                get
                {
                    return _name;
                }
                set
                {
                    _name = value;
                }
            }

            public string Description
            {
                get
                {
                    return _description;
                }
                set => _description = value;
            }

            public double Price
            {
                get
                {
                    return _price;
                }
                set
                {

                    if (value >= 0)
                    {
                        _price = value;
                    }

                }



            }

            public double Discount
            {

                get => _discount;

                set
                {

                    if (value >= 0 && value <= 1)
                    {
                        _discount = value;
                    }

                }
            }

            public double DiscountedAmount()
            {
                return Price * Discount;
            }

            public double CalculateTotalPrice()
            {
                return Price - DiscountedAmount();
            }

            // OVERRIDE ToString()
            public override string ToString()
            {
                // Name: Granny Smith - Price: $1.50 - Discount: $0.15 - Total Price: $1.35
                return $"Name: {_name} - Price: {_price.ToString("c")} - Discount:  {DiscountedAmount().ToString("c")} - Total Price: {CalculateTotalPrice().ToString("c")}";
            } // ToString()

            
    public class ShoppingCart
            {
                // Fields
                string _storeName;
                List<Item> _itemsInCart;
                double _tax;

                // Constructor
                public ShoppingCart(string storeName)
                {
                    _storeName = storeName;

                    // Instantiated
                    // Creating a new INSTANCE of an object
                    // use the new keyword, it's creating a new INSTNACE of an object
                    _itemsInCart = new List<Item>();
                    _tax = .1;
                } // ShoppingCart()


                // Abstraction
                public void AddItem(Item item)
                {
                    _itemsInCart.Add(item);
                } // 

                public string StoreName
                {
                    get => _storeName;
                    set => _storeName = value;
                } // StoreName


                public List<Item> ItemsInCart
                {
                    get
                    {
                        return _itemsInCart;
                    }
                }

                public double Tax
                {
                    get => _tax;
                } // Tax

                public double TotalBeforeTax()
                {
                    double sum = 0;
                    foreach (Item item in _itemsInCart)
                    {
                        sum += item.CalculateTotalPrice();
                    }

                    return sum;
                } // TotalBeforeTax()

                public double TaxOnTotal()
                {
                    return TotalBeforeTax() * _tax;
                } // TaxOnTotal()

                public double TotalPrice()
                {
                    return TotalBeforeTax() + TaxOnTotal();
                } // TotalPrice()


                public string Receipt()
                {
                    DateTime dto = DateTime.Now;
                    string fullReceipt = "";

                    fullReceipt += $"Welcome to {_storeName}\n";
                    fullReceipt += $"Date: {dto.ToShortDateString()} {dto.ToLongTimeString()}";
                    fullReceipt += $"\n-----\n\n";
                    fullReceipt += $"Items\n";
                    foreach (Item item in _itemsInCart)
                    {
                        fullReceipt += $"{item.ToString()}\n";
                    }

                    fullReceipt += $"\n-----\n\n";
                    fullReceipt += $"Number Of Items : {_itemsInCart.Count}\n";
                    fullReceipt += $"Total Before Tax : {TotalBeforeTax().ToString("c")}\n";
                    fullReceipt += $"Tax : {TaxOnTotal().ToString("c")}\n";
                    fullReceipt += $"Total Price : {TotalPrice().ToString("c")}\n";
                    return fullReceipt;
                } // Receipt

            } // class

        } // namespace

    } // class

    } 
