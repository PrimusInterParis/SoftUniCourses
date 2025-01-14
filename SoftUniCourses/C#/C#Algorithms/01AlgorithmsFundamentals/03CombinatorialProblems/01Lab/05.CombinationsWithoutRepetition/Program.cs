﻿using System;

namespace _05.CombinationsWithoutRepetition
{
    class Program
    {
        private static string[] elements;
        private static int k;

        private static string[] combinations;


        static void Main(string[] args)
        {
            elements = new[] { "4", "5", "6" };
            k = 2;
            combinations = new string[k]; 

            Combinations(0, 0);

        }

        private static void Combinations(int combIndex, int elementsStartIndex)
        {
            if (combIndex >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = elementsStartIndex; i < elements.Length; i++)
            {
                combinations[combIndex] = elements[i];
                Combinations(combIndex + 1, i + 1);
            }
        }
    }
}
