using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Book
    {
        public string Title;
        public string Author;
        public string ISBN;
        private int CopiesAvailable;

        public int copiesavailable
        {
            get { return CopiesAvailable; }
            set { CopiesAvailable = value; }
        }

        public void AddCopies(int copies)
        {
            if (copies > 0)
            {
                CopiesAvailable += copies;
            }
            else
            {
                Console.WriteLine("Not nough copies");
            }
        }


        public void RemoveCopies(int copies)
        {
            if (copies > 0 && copies <= CopiesAvailable)
            {
                CopiesAvailable -= copies;
            }
            else if (copies > CopiesAvailable)
            {
                Console.WriteLine("Not enough copies available to remove.");
            }
            else
            {
                Console.WriteLine("Operation cannot be performed");
            }
        }


        public void AddBook()
        {
            Console.Write("Enter title: ");
            Title = Console.ReadLine();
            Console.Write("Enter author: ");
            Author = Console.ReadLine();
            Console.Write("Enter ISBN: ");
            ISBN = Console.ReadLine();
            
            
        }

        public void UpdateBooks()
        {
            Console.Write("Update title (current: " + Title + "): ");
            Title = Console.ReadLine();

            Console.Write("Update author (current: " + Author + "): ");
            Author = Console.ReadLine();

            Console.Write("Update ISBN (current: " + ISBN + "): ");
            ISBN = Console.ReadLine();

            Console.Write("Update number of copies (current: " + CopiesAvailable + "): ");
            try
            {
                CopiesAvailable = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number format. The number of copies remains unchanged.");
            }
        }

        public void DisplayBooks()
        {
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("Author: " + Author);
            Console.WriteLine("ISBN: " + ISBN);
            Console.WriteLine("Copies Available: " + copiesavailable);
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            Book book = new Book();

            List<String> Book = new List<String>();


            Console.WriteLine("====Library Menu====");
            Console.WriteLine("A.Add a new book");
            Console.WriteLine("B.Update existing book");
            Console.WriteLine("C.Display Books");

            string userOption = Console.ReadLine();


            if (userOption == "A")
            {
                book.AddBook();
                Book.Add(book.Title + book.Author + book.ISBN + book.copiesavailable);
                Console.WriteLine("Book Added");
            }
            else if (userOption == "B")
            {
                if (Book.Count == 0)
                {
                    Console.WriteLine("No books available to update.");
                }
                else
                {
                    Console.WriteLine("Select a book to update:");
                    int index = 1;
                    foreach (var bookb in Book)
                    {
                        Console.WriteLine($"{index++}. {book.Title}");
                    }
                    Console.Write("Enter the book number: ");

                    try
                    {
                        int selectedBook = Convert.ToInt32(Console.ReadLine());
                        if (selectedBook > 0 && selectedBook <= Book.Count)
                        {
                            Book[selectedBook - 1].UpdateBook();
                            Console.WriteLine("Book Updated.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid selection.");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid book number.");
                    }
                }


            }
            else if (userOption == "C")
            {
                book.DisplayBooks();
            }
            else
            {
                return;
            }

            Console.ReadKey();
        }
    }
}
