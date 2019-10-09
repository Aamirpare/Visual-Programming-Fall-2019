/*
   Author       :   Aamir Pare
   Description  :   Visual Programming Course Lectures
   Topics       :   C# Built in Delegates, Func and Action
                    Use of Lamda Expression
   Date         :   Oct 5, 2019
   Location     :   G-11/2 Home
   Contact      :   aamirpare@gmail.com
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism.Delegates
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Author { get; set; }
    }
    public static class BookFilter
    {
        public static List<Book> Where(List<Book> books, Func<Book, bool> search)
        {
            var list = new List<Book>();
            books.ForEach(x =>
            {
                if (search(x)) { list.Add(x); }
            });

            return list;
        }

        public readonly static Action<List<Book>> Display = (books) => {
            Console.WriteLine("===========================================");
            books.ForEach(b =>
            {
                Console.WriteLine($"Id : {b.BookId}");
                Console.WriteLine($"Title : {b.Title}");
                Console.WriteLine($"Price : {b.Price}");
                Console.WriteLine($"Author : {b.Author}");
            });
            Console.WriteLine("");
        };
    }
    public static class BookDb
    {
        readonly static List<Book> Books = new List<Book>();
        static BookDb()
        {
            Books.Add(new Book() { BookId = 100, Title = "System Programming Pratices", Price = 450.40m, Author = "David Kohen" });
            Books.Add(new Book() { BookId = 101, Title = "Visual Programming Fundamentals", Price = 450.40m, Author = "David Kohen" });
            Books.Add(new Book() { BookId = 102, Title = "System Programming", Price = 450.40m, Author = "Aamir Pare" });
            Books.Add(new Book() { BookId = 103, Title = "Visual Programming Pratices", Price = 1450.40m, Author = "Mark Pearson" });
            Books.Add(new Book() { BookId = 104, Title = "System Programming Pratices", Price = 550.40m, Author = "Mark Pearson" });
            Books.Add(new Book() { BookId = 105, Title = "Linear Algebra", Price = 650.40m, Author = "Aamir Pare" });
            Books.Add(new Book() { BookId = 106, Title = "Applied Mathematics", Price = 950.40m, Author = "Sara Khan" });
            Books.Add(new Book() { BookId = 107, Title = "Programming Pratices", Price = 450.40m, Author = "Nosheen Rehman" });
            Books.Add(new Book() { BookId = 108, Title = "Numerical Methods", Price = 650.40m, Author = "Ram Singh" });
            Books.Add(new Book() { BookId = 109, Title = "Advance Networks", Price = 650.40m, Author = "Sara Khan" });
            Books.Add(new Book() { BookId = 110, Title = "Database Management", Price = 550.40m, Author = "Aamir Pare" });
        }
        public static void Main_AdvanceDelegates(string[] args)
        {
            Console.WriteLine("Books that cost less than 500");
            var books = BookFilter.Where(Books, (b) => { return b.Price > 500; });
            BookFilter.Display(books);

            Console.WriteLine("Books Written by the same Author");
            books = BookFilter.Where(Books, (x) => {
                return x.Author == "Aamir Pare";
            });
            BookFilter.Display(books);


            Console.ReadKey();
        }
    }
}
