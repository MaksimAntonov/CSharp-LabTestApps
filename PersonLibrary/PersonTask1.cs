using System;

namespace PersonLibrary
{
    public class PersonTask1 : Person
    {
        public PersonTask1():base() {
        
        }

        public bool IsConscript()
        {
            return (Gender == 'M' && (Age >= 18 && Age < 27));
        }

        public override string ToString()
        {
            return "Lastname: " + Lastname + " Age: " + Age + " Address: " + Address;
        }

        public override int CompareTo(object obj)
        {
            return obj is PersonTask1 person ? Address.CompareTo(person.Address) : throw new ArgumentException("Incorrect object type");
        }
    }
}
