﻿using System;

namespace _07._07._Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(GetFibonacci(n));
        }

        private static int GetFibonacci(int n)
        {

            if (n <= 1)
            {
                return 1;
            }

            return GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }
    }
}
