using System;
using System.Reflection;

namespace BooksDatabase
{
    class Program
    {
        struct book
        {
            public string title;
            public string author;
        }
        static void Main(string[] args)
        {
            int capacity = 1000, amount = 0;
            string option, search;
            bool found, repeat = true;
            book[] books = new book[capacity];

            do
            {
                Console.WriteLine();
                Console.WriteLine("Books Databace");
                Console.WriteLine();
                Console.WriteLine("0: Exit");
                Console.WriteLine("1: Add a new Book");
                Console.WriteLine("2: Display All Books");
                Console.WriteLine("3: Exact Search for any Book");
                Console.WriteLine("4: Partial Search");
                Console.WriteLine("5: Delete a Book");
                Console.WriteLine();
                Console.Write("Enter an option: ");
                option = Console.ReadLine();

                switch (option)
                {
                    case "0": // Quite from the Book database
                        repeat = false;
                        break;
                   
                    case "1": // Add a new book to the database
                        if (amount < capacity)
                        {
                            Console.WriteLine("Enter data for book {0}", amount + 1);
                            Console.Write("Enter the name of the book: ");
                            books[amount].title = Console.ReadLine();
                            Console.Write("Enter the Author Name: : ");
                            books[amount].author = Console.ReadLine();
                            amount++;
                            Console.WriteLine();
                        }
                        else
                            Console.WriteLine("Database full");
                        break;

                    case "2":  // Display all Books 
                        if (amount == 0)
                            Console.WriteLine("No data to search");
                        else
                        {
                            for (int i = 0; i < amount; i++)
                                Console.WriteLine("{0} Title = {1}, Author = {2}", i + 1, books[i].title, books[i].author);
                            Console.WriteLine();
                        }
                        break;

                    case "3": //Search Books Exact title
                        Console.Write("Enter the name of the book");
                        search = Console.ReadLine();
                        found = false;

                        for (int i = 0; i < amount; i++)
                            if (books[i].title == search)
                            {
                                Console.WriteLine("Book {0} fornd", books[i].title);
                                found = true;
                            }
                        if (!found)
                            Console.WriteLine("Not found");
                        break;


                    case "4": //Search books partial
                        Console.Write("Enter the search string");
                        search = Console.ReadLine();
                        found = false;
                        for (int i = 0; i < amount; i++)
                            if (books[i].title.ToUpper().Contains(search.ToUpper()) || books[i].author.ToUpper().Contains(search.ToUpper()))
                            {
                                Console.WriteLine("{0} fornd in {i}", search, books[i].title);
                                found = true;
                            }
                        if (!found)
                            Console.WriteLine("Not found");
                        break;

                    case "5": //Delete book from the database
                        if (amount == 0)
                            Console.WriteLine("No data to delete");
                        else
                        {
                            Console.WriteLine("Enter the number of book to delete ( 1 to {0}", amount);
                            int posToDelete = Convert.ToInt32(Console.ReadLine()) - 1;
                            for (int i = posToDelete; i < amount - 1; i++)
                                books[i] = books[i + 1];
                            amount--;

                        }
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Wrong option. Try again!");
                        break;



                }






            }
            while (repeat);
        }
    }
}
