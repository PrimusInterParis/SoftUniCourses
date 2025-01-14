﻿using System;

namespace _8._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberKegs = int.Parse(Console.ReadLine());
            string biggestKeg = string.Empty;
            double theBiggestKeg = 0;

            for (int i = 0; i < numberKegs; i++)
            {
                string keg = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                double hight = double.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(radius,2) * hight;

                if (volume > theBiggestKeg)
                {
                    biggestKeg = keg;
                    theBiggestKeg = volume;
                }

            }

            Console.WriteLine(biggestKeg);
        }
    }
}