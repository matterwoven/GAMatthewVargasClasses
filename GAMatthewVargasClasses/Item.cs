using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAMatthewVargasClasses
{
    class Item
    {
        string _name;
        string _description;
        double _price;
        double _discount;

        // Constructor
        // Access Modifer - SAME EXACT NAME AS THE CLASS - Take Paremeters


        public Item(string name, string description, double price, double discount)
        {
            // Field = argument
            _name = name;
            _description = description;
            Price = price;
            Discount = discount;

        } // Item
        
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

     
        public override string ToString()
        { 
           return $"Name: {_name} - Price: {_price.ToString("c")} - Discount:  {DiscountedAmount().ToString("c")} - Total Price: {CalculateTotalPrice().ToString("c")}";

        }
    }
}
