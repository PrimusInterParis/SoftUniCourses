using System;
using System.Collections.Generic;

namespace _01.DogVet
{
    public class Owner
    {
        private class DogComparer : IComparer<Dog>
        {
            public int Compare(Dog x, Dog y)
            {
                if (ReferenceEquals(x, y)) return 0;
                if (ReferenceEquals(null, y)) return 1;
                if (ReferenceEquals(null, x)) return -1;
                return string.Compare(x.Id, y.Id, StringComparison.Ordinal);
            }
        }

        public Owner(string id, string name)
        {
            this.Id = id;
            this.Name = name;
<<<<<<< HEAD
            this.Dogs = new SortedSet<Dog>();
            this.dogsByName = new Dictionary<string, Dog>();
        }

        public SortedSet<Dog> Dogs;
        public Dictionary<string, Dog> dogsByName;
=======
            this.DogsByName = new Dictionary<string, Dog>();
            this.Dogs = new SortedSet<Dog>(new DogComparer());
        }

        public Dictionary<string,Dog> DogsByName { get; set; }

        public SortedSet<Dog> Dogs { get; set; }
>>>>>>> c95aeb6797ce3635cbccc835de79501dce9dfe3f

        public string Id { get; set; }

        public string Name { get; set; }
    }
}