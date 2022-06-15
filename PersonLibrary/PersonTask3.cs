using System;

namespace PersonLibrary
{
    public class PersonTask3 : Person
    {
        public override int CompareTo(object obj)
        {
            return (obj is PersonTask3 person) ? Age.CompareTo(person.Age) : throw new ArgumentException("Incorrect object type");
        }

        public override string ToString()
        {
            return $"{Fullname}, Age: {Age}";
        }
    }
}
