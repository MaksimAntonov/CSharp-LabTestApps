using System;

namespace PersonLibrary
{
    public class PersonTask2 : Person
    {
        private int _weight;
        private int _height;

        public int Weight
        {
            get => _weight;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                _weight = value;
            }
        }

        public int Height 
        { 
            get => _height; 
            set
            {
                if (value < 0)
                    throw new AccessViolationException(nameof(value));
                _height = value;
            } 
        }

        public PersonTask2() : base() { }

        public override string ToString()
        {
            return $"{Lastname} {Firstname}, Weight: {Weight}, Height: {Height}";
        }

        public override int CompareTo(object obj)
        {
            return obj is PersonTask2 person ? Height.CompareTo(person.Height) : throw new ArgumentException("Incorrect object type");
        }
    }
}
