using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGMA_8_2
{
    class Dairy : Product
    {
        public Dairy() { }

        public Dairy(string s_name, double dbl_price, double dbl_weight, int n_exp_date, string s_date) : base(s_name, dbl_price, dbl_weight, n_exp_date, s_date)
        {

        }

        public override bool Equals(object other)
        {
            if (other == null)
            {
                return false;
            }

            Dairy dairy = other as Dairy;

            if (dairy as Dairy == null)
            {
                return false;
            }

            return dairy.ExpirationDate == this.ExpirationDate;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override void ChangePrice(double percent)
        {
            double percentage = percent / 100;
            double addPercentage = 10 / 100;

            double newPrice = this.Price + (this.Price * percentage);

            this.Price = this.Price + (newPrice * addPercentage);
        }

    }
}

