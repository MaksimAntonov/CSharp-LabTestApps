using PersonLibrary;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    internal class ProgramTask1
    {
        private readonly List<Person> _persons;

        public static void Main()
        {
            ProgramTask1 app = new ProgramTask1();

            app.ReadPersons();

            app.ShowCountsOfMilitaryAge();

            app.ShowMiddleAge();

            app.ShowGroupList();

            Console.ReadLine();
        }

        public ProgramTask1()
        {
            _persons = new List<Person>();
        }

        public void ReadPersons()
        {
            ConsoleKey consoleKey = ConsoleKey.Y;

            while (consoleKey == ConsoleKey.Y)
            {
                Person person = new PersonTask1();

                Console.WriteLine("Enter Last name");
                person.Lastname = Console.ReadLine();

                Console.WriteLine("Enter Address");
                person.Address = Console.ReadLine();

                Console.WriteLine("Enter Birthday");
                person.Birthday = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Enter Gender");
                person.Gender = char.Parse(Console.ReadLine());

                _persons.Add(person);

                Console.WriteLine("Add new Person? Y - yes, N - no");
                consoleKey = Console.ReadKey(true).Key;
            }

            Console.WriteLine("");
        }

        public void ShowCountsOfMilitaryAge()
        {
            List<Person> males = _persons.FindAll(person => person.Gender == 'M');
            int count = 0;

            foreach (Person male in males)
            {
                if (male is PersonTask1 person && person.IsConscript())
                    count++;
            }

            Console.WriteLine("Military age males: " + count);
        }

        public void ShowMiddleAge()
        {
            int summaryAge = 0;

            for (int i = 0; i < _persons.Count; i++)
            {
                summaryAge += _persons[i].Age();
            }

            int result = summaryAge / _persons.Count;

            Console.WriteLine("Average age is " + result);
        }

        public void ShowGroupList()
        {
            _persons.Sort();

            foreach (Person person in _persons)
            {
                Console.WriteLine(person);
            }
        }
    }
}
