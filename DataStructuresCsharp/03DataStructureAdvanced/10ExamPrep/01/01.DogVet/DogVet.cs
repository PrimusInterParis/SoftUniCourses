using System;
using System.Collections.Generic;
using System.Linq;
using _01.DogVet;

namespace _01.DogVet
{
    using System;
    using System.Collections.Generic;

    public class DogVet : IDogVet
    {
<<<<<<< HEAD
        private Dictionary<string, Owner> ownersById;
        private Dictionary<string, Dog> vetClinic;
        private Dictionary<Enum, SortedSet<Dog>> byBreed;
        private HashSet<Dog> ageSorted;
=======
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

        private Dictionary<string, Dog> dogsById;

        private Dictionary<string, Owner> ownersById;

        private SortedSet<Dog> dogs;

        private Dictionary<Enum, SortedSet<Dog>> breedSorted;

        private Dictionary<int, List<Dog>> byAge;
>>>>>>> c95aeb6797ce3635cbccc835de79501dce9dfe3f

        public DogVet()
        {
            this.dogsById = new Dictionary<string, Dog>();
            this.ownersById = new Dictionary<string, Owner>();
<<<<<<< HEAD
            this.vetClinic = new Dictionary<string, Dog>();
            this.ageSorted = new HashSet<Dog>();
            this.byBreed = new Dictionary<Enum, SortedSet<Dog>>();
=======
            this.dogs = new SortedSet<Dog>(new DogComparer());
            this.breedSorted = new Dictionary<Enum, SortedSet<Dog>>();
            this.byAge = new Dictionary<int, List<Dog>>();
>>>>>>> c95aeb6797ce3635cbccc835de79501dce9dfe3f
        }

        public int Size
        {
<<<<<<< HEAD
            get => this.vetClinic.Count;
=======
            get => this.dogs.Count;
>>>>>>> c95aeb6797ce3635cbccc835de79501dce9dfe3f
        }

        public void AddDog(Dog dog, Owner owner)
        {
<<<<<<< HEAD
            if (this.vetClinic.ContainsKey(dog.Id))
            {
                throw new ArgumentException();
            }

            if (!this.byBreed.ContainsKey(dog.Breed))
            {
                this.byBreed.Add(dog.Breed,new SortedSet<Dog>());
            }

            if (!this.ownersById.ContainsKey(owner.Id))
            {
                this.ownersById.Add(owner.Id, owner);
            }

            if (this.ownersById[owner.Id].dogsByName.ContainsKey(dog.Name))
            {
                throw new ArgumentException();
            }

            dog.Owner = owner;


            this.vetClinic[dog.Id] = dog;
            this.ageSorted.Add(dog);

            this.byBreed[dog.Breed].Add(dog);
            this.ownersById[owner.Id].dogsByName.Add(dog.Name, dog);
            this.ownersById[owner.Id].Dogs.Add(dog);
=======
            if (this.dogsById.ContainsKey(dog.Id))
                throw new ArgumentException();

            if (!this.ownersById.ContainsKey(owner.Id))
                this.ownersById.Add(owner.Id, owner);

            if (!this.breedSorted.ContainsKey(dog.Breed))
                this.breedSorted.Add(dog.Breed, new SortedSet<Dog>());

            if (!this.byAge.ContainsKey(dog.Age))
                this.byAge.Add(dog.Age, new List<Dog>());

            if (this.ownersById[owner.Id].DogsByName.ContainsKey(dog.Name))
                throw new ArgumentException();

            dog.Owner = owner;
            this.dogs.Add(dog);
            this.dogsById.Add(dog.Id, dog);
            this.ownersById[owner.Id].DogsByName.Add(dog.Name, dog);
            this.ownersById[owner.Id].Dogs.Add(dog);
            this.breedSorted[dog.Breed].Add(dog);
            this.byAge[dog.Age].Add(dog);
>>>>>>> c95aeb6797ce3635cbccc835de79501dce9dfe3f


        }

        public bool Contains(Dog dog)
        {
<<<<<<< HEAD
            return this.vetClinic[dog.Id] == dog;
=======
            return this.dogsById.ContainsKey(dog.Id);
>>>>>>> c95aeb6797ce3635cbccc835de79501dce9dfe3f
        }

        public Dog GetDog(string name, string ownerId)
        {
            if (!this.ownersById.ContainsKey(ownerId))
                throw new ArgumentException();


<<<<<<< HEAD
            if (!this.ownersById[ownerId].dogsByName.ContainsKey(name))
            {
=======
            if (!this.ownersById[ownerId].DogsByName.ContainsKey(name))
>>>>>>> c95aeb6797ce3635cbccc835de79501dce9dfe3f
                throw new ArgumentException();

            return this.ownersById[ownerId].dogsByName[name];
        }

        public Dog RemoveDog(string name, string ownerId)
        {
            if (!this.ownersById.ContainsKey(ownerId))
                throw new ArgumentException();


<<<<<<< HEAD
            if (!this.ownersById[ownerId].dogsByName.ContainsKey(name))
            {
=======
            if (!this.ownersById[ownerId].DogsByName.ContainsKey(name))
>>>>>>> c95aeb6797ce3635cbccc835de79501dce9dfe3f
                throw new ArgumentException();

<<<<<<< HEAD
            Dog toRemove = this.ownersById[ownerId].dogsByName[name];

            this.ownersById[ownerId].dogsByName.Remove(name);
            this.ownersById[ownerId].Dogs.Remove(toRemove);
            this.vetClinic.Remove(toRemove.Id);
            this.ageSorted.Remove(toRemove);
            this.byBreed[toRemove.Breed].Remove(toRemove);
=======
            Dog toRemove = this.ownersById[ownerId].DogsByName[name];

            this.dogsById.Remove(toRemove.Id);
            this.ownersById[ownerId].DogsByName.Remove(toRemove.Name);
            this.ownersById[ownerId].Dogs.Remove(toRemove);
            this.dogs.Remove(toRemove);
            this.breedSorted[toRemove.Breed].Remove(toRemove);
            this.byAge[toRemove.Age].Remove(toRemove);
>>>>>>> c95aeb6797ce3635cbccc835de79501dce9dfe3f

            return toRemove;

        }

        public IEnumerable<Dog> GetDogsByOwner(string ownerId)
        {
            if (this.ownersById.ContainsKey(ownerId))
                return this.ownersById[ownerId].Dogs;

            throw new ArgumentException();
        }



        public IEnumerable<Dog> GetDogsByBreed(Breed breed)
        {
<<<<<<< HEAD
            if (!this.byBreed.ContainsKey(breed))
            {
=======
            if (!this.breedSorted.ContainsKey(breed))
>>>>>>> c95aeb6797ce3635cbccc835de79501dce9dfe3f
                throw new ArgumentException();

<<<<<<< HEAD
            return this.byBreed[breed];
=======
            return this.breedSorted[breed];

>>>>>>> c95aeb6797ce3635cbccc835de79501dce9dfe3f
        }

        public void Vaccinate(string name, string ownerId)
        {
            if (!this.ownersById.ContainsKey(ownerId))
                throw new ArgumentException();


<<<<<<< HEAD
            if (!this.ownersById[ownerId].dogsByName.ContainsKey(name))
            {
=======
            if (!this.ownersById[ownerId].DogsByName.ContainsKey(name))
>>>>>>> c95aeb6797ce3635cbccc835de79501dce9dfe3f
                throw new ArgumentException();

<<<<<<< HEAD
            this.ownersById[ownerId].dogsByName[name].Vaccines++;
            //????????????????????????????????????????????????????????

=======
            this.ownersById[ownerId].DogsByName[name].Vaccines++;
>>>>>>> c95aeb6797ce3635cbccc835de79501dce9dfe3f
        }

        public void Rename(string oldName, string newName, string ownerId)
        {
            if (!this.ownersById.ContainsKey(ownerId))
                throw new ArgumentException();


<<<<<<< HEAD
            if (!this.ownersById[ownerId].dogsByName.ContainsKey(oldName))
            {
=======
            if (!this.ownersById[ownerId].DogsByName.ContainsKey(oldName))
>>>>>>> c95aeb6797ce3635cbccc835de79501dce9dfe3f
                throw new ArgumentException();

<<<<<<< HEAD
            this.ownersById[ownerId].dogsByName[oldName].Name = newName;

            var value = this.ownersById[ownerId].dogsByName[oldName];

            this.ownersById[ownerId].dogsByName.Remove(oldName);

            this.ownersById[ownerId].dogsByName.Add(value.Name, value);
=======
            Dog dog = this.ownersById[ownerId].DogsByName[oldName];
            this.ownersById[ownerId].Dogs.Remove(dog);

            dog.Name = newName;

            this.ownersById[ownerId].DogsByName.Remove(oldName);
            this.ownersById[ownerId].DogsByName.Add(dog.Name, dog);
>>>>>>> c95aeb6797ce3635cbccc835de79501dce9dfe3f
        }

        public IEnumerable<Dog> GetAllDogsByAge(int age)
        {
<<<<<<< HEAD
            return this.ageSorted.Where(d => d.Age == age);
=======
            if (!this.byAge.ContainsKey(age))
                throw new ArgumentException();

            return this.byAge[age];


>>>>>>> c95aeb6797ce3635cbccc835de79501dce9dfe3f
        }

        public IEnumerable<Dog> GetDogsInAgeRange(int lo, int hi)
        {
<<<<<<< HEAD
            return this.ageSorted.Where(d => d.Age >= lo && d.Age <= hi);
=======
            List<Dog> toReturn = new List<Dog>();

            foreach (var keyValue in byAge)
            {
                if (keyValue.Key>=lo && keyValue.Key<=hi)
                {
                    toReturn.AddRange(keyValue.Value);
                }
            }

            return toReturn;
>>>>>>> c95aeb6797ce3635cbccc835de79501dce9dfe3f
        }

        public IEnumerable<Dog> GetAllOrderedByAgeThenByNameThenByOwnerNameAscending()
        {
<<<<<<< HEAD
            return this.ageSorted;
=======
            return this.dogs.OrderBy(d=>d.Age).ThenBy(d=>d.Name).ThenBy(d=>d.Owner.Name);
>>>>>>> c95aeb6797ce3635cbccc835de79501dce9dfe3f
        }
    }
}