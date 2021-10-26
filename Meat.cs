using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGMA_8_2
{
    enum CategoryOfMeat { HighGrade = 30, FirstGrade = 20, SecondGrade = 10};
    enum SortOfMeat { mutton, veal, pork, chicken};
    class Meat : Product
    {
        private CategoryOfMeat category;
        private SortOfMeat sort;

        public Meat() { }

        public Meat(CategoryOfMeat category, SortOfMeat sort, string s_name, double dbl_price, double dbl_weight, int n_exp_date, string s_date) : base(s_name, dbl_price, dbl_weight, n_exp_date, s_date)
        {
            this.category = category;
            this.sort = sort;
        }

        public CategoryOfMeat Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
            }
        }

        public SortOfMeat Sort
        {
            get
            {
                return sort;
            }
            set
            {
                sort = value;
            }
        }


        public override bool Equals(object other)
        {
            if(other == null)
            {
                return false;
            }

            Meat meat = other as Meat;

            if(meat as Meat == null)
            {
                return false;
            }

            return meat.Category == this.Category && meat.Sort == this.Sort;
        }

        public override string ToString()
        {
            return "\n" + base.ToString() + "\nCategory: " + this.Category + "\nSort: " + this.Sort;
        }

        public override void ChangePrice(double percent)
        {
            double percantage = percent / 100;
            double addPercentage = ((int)this.Category) / 100;

            double newPrice = this.Price + (this.Price * percantage);

            this.Price = this.Price + (newPrice * addPercentage);
        }


    }
}
