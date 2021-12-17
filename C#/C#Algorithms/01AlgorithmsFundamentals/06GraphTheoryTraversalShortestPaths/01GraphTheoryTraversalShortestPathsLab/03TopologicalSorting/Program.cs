﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _03TopologicalSorting
{
    class Program
    {

        private static Dictionary<string, List<string>> graph;

        private static Dictionary<string, int> dependencies;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            graph = ReadGraph(n);

            dependencies = ExtractDepencancies();

            var sorted = TopologicalSorting();

            if (sorted == null)
            {
                Console.WriteLine("Invalid topological sorting");
            }
            else
            {
                Console.WriteLine($"Topological sorting: {string.Join(", ", sorted)}");
            }


        }

        private static List<string> TopologicalSorting()
        {
            var result = new List<string>();

            while (dependencies.Count > 0)
            {
                var nodeToRemove = dependencies.FirstOrDefault(n => n.Value == 0);

                if (string.IsNullOrWhiteSpace(nodeToRemove.Key))
                {
                    break;
                }

                var children = graph[nodeToRemove.Key];

                foreach (var child in children)
                {
                    dependencies[child] -= 1;
                }

                dependencies.Remove(nodeToRemove.Key);

                result.Add(nodeToRemove.Key);
            }

            if (dependencies.Count > 0)
            {
                return null;
            }

            return result;
        }

        private static Dictionary<string, int> ExtractDepencancies()
        {
            Dictionary<string, int> toReturn = new Dictionary<string, int>();

            foreach (var kvp in graph)
            {
                string node = kvp.Key;

                List<string> children = kvp.Value;

                if (!toReturn.ContainsKey(node))
                {
                    toReturn.Add(node, 0);
                }

                foreach (var child in children)
                {
                    if (!toReturn.ContainsKey(child))
                    {
                        toReturn.Add(child, 1);
                    }
                    else
                    {
                        toReturn[child] += 1;
                    }
                }
            }

            return toReturn;
        }

        private static Dictionary<string, List<string>> ReadGraph(int n)
        {
            Dictionary<string, List<string>> toReturn = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                string[] inputData = Console.ReadLine().Split("->", StringSplitOptions.RemoveEmptyEntries).ToArray();

                var key = inputData[0].Trim();

                if (inputData.Length > 1)
                {
                    var children = inputData[1].Trim().Split(", ").ToList();

                    toReturn[key] = children;
                }
                else
                {
                    toReturn[key] = new List<string>();

                }

            }


            return toReturn;
        }
    }
}