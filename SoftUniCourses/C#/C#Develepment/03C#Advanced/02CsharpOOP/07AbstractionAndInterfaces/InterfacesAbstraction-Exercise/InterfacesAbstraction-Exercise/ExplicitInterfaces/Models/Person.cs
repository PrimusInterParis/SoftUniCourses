﻿using ExplicitInterfaces.Contracts;

namespace ExplicitInterfaces.Models
{
    public class Person : IPerson, IResident
    {
        public Person(string name, string country, int age)
        {
            this.Name = name;
            this.Country = country;
            this.Age = age;
        }

        public string Name { get; }

        public string Country { get; }

        public int Age { get; }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }

        string IPerson.GetName()
        {
            return $"{this.Name}";
        }
    }
}