using System;

namespace PersonLibrary
{
    public abstract class Person : IComparable
    {
        private char _gender;

        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public string Fullname => $"{Firstname} {Lastname}";

        public DateTime Birthday { get; set; }

        public char Gender
        {
            get => _gender;
            set
            {
                if (value == 'm' || value == 'f')
                    _gender = char.ToUpper(value);
                else
                    _gender = '-';
            }
        }

        public string Address { get; set; }

        public int Age
        {
            get
            {
                int a = DateTime.Now.Year - Birthday.Year;
                if (DateTime.Now.DayOfYear < Birthday.DayOfYear)
                    a--;
                return a;
            }
        }

        public abstract int CompareTo(object obj);
    }
}
