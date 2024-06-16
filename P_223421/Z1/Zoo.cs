using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Z1
{
    public delegate void AnimalAddedEventHandler(object sender, AnimalEventArgs e);
    public class Zoo
    {
        List<Animal> animals = new List<Animal>();
        public List<Animal> Animals { get { return animals; } }
        public Animal this[int index]
        {

            get
            {
                if (index < 0 || index >= animals.Count) throw new IndexOutOfRangeException();
                return animals[index];
            }
            set
            {
                if (index < 0 || index >= animals.Count) throw new IndexOutOfRangeException();
                animals[index] = value;

            }
        }
        public Animal this[string name]
        {
            get
            {
                foreach (var animal in animals)
                {
                    if (animal.Name == name) return animal;
                }
                throw new KeyNotFoundException();
            }
        }
        [Obsolete("Use AddAnimal method instead.")]
        public void Add(Animal animal)
        {
            animals.Add(animal);
            OnAnimalAdded(new AnimalEventArgs(animal));
        }
        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
            OnAnimalAdded(new AnimalEventArgs(animal));
        }
        public void OnAnimalAdded(AnimalEventArgs e)
        {
            AnimalAdded?.Invoke(this, e);
        }
        public event AnimalAddedEventHandler AnimalAdded;
    }
}
