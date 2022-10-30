using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bookstore
{
    class InOutUtils
    {
        public static BookStore InputBooks(string filename)
        {
            BookStore bookStore = new BookStore();
            string[] Lines = File.ReadAllLines(filename, Encoding.UTF8);
            foreach(string Line in Lines)
            {
                string[] Values = Line.Split(';');
                string publisher = Values[0];
                string name = Values[1];
                int amount = int.Parse(Values[2]);
                decimal price = decimal.Parse(Values[3]);

                Book book = new Book(publisher, name, amount, price);
                bookStore.AddBook(book);
            }
            return bookStore;
        }
        public static List<Book> InputSoldBooks(string filename)
        {
            List<Book> books = new List<Book>();
            string[] Lines = File.ReadAllLines(filename, Encoding.UTF8);
            foreach( string Line in Lines)
            {
                string name = Line;

                Book book = new Book(name,1,0);
                books.Add(book);
            }
            return books;
        }
        public static void Print(BookStore books, string fileName, string header)
        {
            string[] Lines = new string[books.GetCount() + 6];
            Lines[0]=String.Format(header);
            Lines[1] = String.Format(new String('-', 105));
            Lines[2]=String.Format("{0,-17} {1,-18} {2,6} {3,8}", "Platintojas","Pavadinimas","Kiekis","Kaina");
            Lines[3] = String.Format(new String('-', 105));
            for (int i = 0; i < books.GetCount(); i++)
            {
                Book info = books.GetBook(i);
                Lines[i + 4] = info.ToString();
            }
            Lines[books.GetCount()+4] = String.Format(new String('-', 105));
            File.AppendAllLines(fileName, Lines, Encoding.UTF8);
        }
        public static void Print(List<Book> books, string fileName, string header)
        {
            string[] Lines = new string[books.Count() + 6];
            Lines[0] = String.Format(header);
            Lines[1] = String.Format(new String('-', 105));
            Lines[2] = String.Format("{0,-17} {1,8} {2,7}","Pavadinimas", "Kiekis", "Kaina");
            Lines[3] = String.Format(new String('-', 105));
            for (int i = 0; i < books.Count(); i++)
            {
                Lines[i + 4] = String.Format("{0,-17} |{1,6} |{2,8:f} €|", books[i].Name, books[i].Amount, books[i].Price);
            }
            Lines[books.Count() + 4] = String.Format(new String('-', 105));
            File.AppendAllLines(fileName, Lines, Encoding.UTF8);
        }
        
    }
}
