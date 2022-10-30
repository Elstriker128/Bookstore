using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore
{
    class Book
    {
        public string Publisher { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

        public Book(string publisher, string name, int amount, decimal price)
        {
            this.Publisher = publisher;
            this.Name = name;
            this.Amount = amount;
            this.Price = price;
        }
        public Book(string name, int amount, decimal price)
        {
            this.Name = name;
            this.Amount = 1;
            this.Price = 0;
        }
        public override string ToString()
        {
            string info;
            info = String.Format("{0,-15} |{1,-17} |{2,6} |{3,8:f} €|", this.Publisher, this.Name, this.Amount, this.Price);
                return info;
        }
        public static bool operator <=(Book lhs, Book rhs)
        {
            if(lhs.Name != rhs.Name)
            {
                return false;
            }
            if(lhs.Amount <=0)
            {
                return false;
            }
            return lhs.Price <= rhs.Price;
        }
        public static bool operator >=(Book lhs, Book rhs)
        {
            if (lhs.Name != rhs.Name)
            {
                return false;
            }
            if (lhs.Amount <= 0)
            {
                return false;
            }
            return lhs.Price >= rhs.Price;
        }
    }
}
