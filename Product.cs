using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SIGMA_8_2
{
    class Product
    {
        private string name;
        private double price;
        private double weight;
        private int expirationDate;
        private string date;
        public Product(string s_name, double dbl_price, double dbl_weight, int n_exp_date, string s_date)
        {
            name = s_name;
            price = dbl_price;
            weight = dbl_weight;
            expirationDate = n_exp_date;
            date = s_date;
        }

        public Product() { }

        public int ExpirationDate
        {
            get
            {
                return expirationDate;
            }
            set
            {
                expirationDate = value;
            }

        }
        public string Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }

        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }

        }

        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
            }
        }


        public override bool Equals(object other)
        {
            if (other == null)
            {
                return false;
            }

            Product product = other as Product;

            if (product as Product == null)
            {
                return false;
            }

            return product.Name == this.Name;
        }

        public override string ToString()
        {
            return "Name: " + this.Name + "\nPrice: " + this.Price + "\nWeight: " + this.Weight + "\nDate: " + this.Date + "\nExpiration date: " + this.ExpirationDate;
        }

        public virtual void ChangePrice(double percent)
        {
            double percantage = percent / 100;
            this.Price = this.Price + (this.Price * percantage);
        }

        virtual public void Parse(string values)
        {
           
            var arr = values.Split(' ');

            Name = arr[0];

            double price;
            if (!double.TryParse(arr[1], out price))
                throw new ArgumentException("Wrong input(price)");
            Price = price;

            double weight;
            if (!double.TryParse(arr[2], out weight))
                throw new ArgumentException("Wrong input(weight)");
            Weight = weight;

            int expirationDate;
            if (!int.TryParse(arr[3], out expirationDate))
                throw new ArgumentException("Wrong input(expiration date)");
            ExpirationDate = expirationDate;

         
            Date = arr[4];

        }
    }


};

