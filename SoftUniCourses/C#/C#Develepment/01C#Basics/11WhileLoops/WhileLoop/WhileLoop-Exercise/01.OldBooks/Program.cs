﻿using System;

namespace _01.OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string favBook = Console.ReadLine();

            int bookCount = 0;


            while (true)
            {
                string searchedBook = Console.ReadLine();

                if (searchedBook == "No More Books")
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {bookCount} books.");
                    break;

                }
                else if (searchedBook == favBook)
                {
                    Console.WriteLine($"You checked {bookCount} books and found it.");
                    break;
                }
                bookCount++;

            }
        }
    }
}
