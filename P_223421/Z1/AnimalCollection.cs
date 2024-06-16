﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Z1
{
    public class AnimalCollection<T> : IEnumerable<T>
    {
        public List<T> animals = new List<T>();
        public int Count { get { return animals.Count; } }
        public void Add(T animal)
        {
            animals.Add(animal);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)animals).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)animals).GetEnumerator();
        }
    }
}
