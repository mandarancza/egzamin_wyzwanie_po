using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Newtonsoft.Json;

namespace Z1
{
    public abstract class Animal : IAnimal, IComparable<Animal>
    {
        public string Name { get; set; }
        public Animal(string name)
        {
            Name = name;
        }

        public int CompareTo(Animal other)
        {
            return Name.CompareTo(other.Name);
        }
        public static Animal Deserialize(string jsonString)
        {
            var jsettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };
            return (Animal)JsonConvert.DeserializeObject(jsonString, jsettings);
        }

        public override bool Equals(object obj)
        {
            return obj is Animal animal &&
                   Name == animal.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
        public abstract void MakeSound();
        public static string Serialize(Animal animal)
        {
            var jsettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };
            return JsonConvert.SerializeObject(animal, jsettings);
        }
        public class AnimalNameLengthComparer : IComparer<Animal>
        {
            public int Compare(Animal x, Animal y)
            {
                if(x == null || y == null) throw new ArgumentNullException();
                return x.Name.Length.CompareTo(y.Name.Length);
            }
        }
    }
}
