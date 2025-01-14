﻿using System;

namespace _03.VariationsWithoutRepetitions
{
    class Program
    {
        private static string[] elements;
        private static int k;

        private static string[] variations;
        private static bool[] used;

        static void Main(string[] args)
        {
            elements = new[] { "a", "b", "c" };
            k = 2;
            variations = new string[k];
            used = new bool[elements.Length];

            Variations(0);


        }

        private static void Variations(int index)
        {
            if (index >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    variations[index] = elements[i];
                    Variations(index + 1);
                    used[i] = false;
                }
            }
        }
    }
}
