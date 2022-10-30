using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore
{
     class BookStore
    {
        private List<Book> AllBooks;
        
        public BookStore()
        {
            AllBooks = new List<Book>();
        }
        public BookStore(List<Book> allBooks) : this()
        {
            foreach (Book book in allBooks)
            {
                AllBooks.Add(book);
            }
        }
        public int GetCount()
        {
            return this.AllBooks.Count();
        }
        public void AddBook(Book book)
        {
            this.AllBooks.Add(book);
        }
        public Book GetBook(int index)
        {
            return this.AllBooks[index];
        }
        public decimal Sum()
        {
            decimal sum = 0;
            foreach(Book book in this.AllBooks)
            {
                sum += book.Amount * book.Price;
            }
            return sum;
        }
        public int IndexMaxPrice(Book book)
        {
            int index = -1;            
            for (int i = 0; i < this.GetCount(); i++)
            {
                Book currentBook = this.GetBook(i);
                if(currentBook >= book)
                {
                    index= i;
                }
            }
            return index;
        }
        public void AddSalePrice(List<Book> books)
        {
            for (int i = 0; i < books.Count(); i++)
            {
                int index = IndexMaxPrice(books[i]);
                if(index >= 0)
                {
                    var currentBook = this.GetBook(index);
                    books[i].Price = currentBook.Price;
                    currentBook.Amount--;
                }
            }           
        }
    }
}
