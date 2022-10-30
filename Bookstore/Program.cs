using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bookstore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string Data = "Duomenys.txt";
            BookStore bookStore = InOutUtils.InputBooks(@"Knyga.txt");
            List<Book> sold = InOutUtils.InputSoldBooks(@"Parduota.txt");

            if (File.Exists(Data))
            {
                File.Delete(Data);
            }
            InOutUtils.Print(bookStore, Data, "Pradinė knygyno lentelė");
            InOutUtils.Print(sold, Data, "Pradinė knygų pardavimo lentelė");

            bookStore.AddSalePrice(sold);
            decimal FinalSum = bookStore.Sum();
            
            InOutUtils.Print(bookStore, Data, "Pakeista knygyno lentelė");
            InOutUtils.Print(sold, Data, "Papildyta knygų pardavimo lentelė");

            File.AppendAllText(Data, "Turi dar surinkti: ");
            File.AppendAllText(Data, Convert.ToString(bookStore.Sum()));
            File.AppendAllText(Data, "€");

            Console.ReadKey();
        }
    }
}
