using PersonLibrary;
using System;
using System.Collections.Generic;

namespace ConsoleAppTask3
{
    internal class ProgramTask3
    {
        private readonly List<PersonTask3> _persons;

        static void Main()
        {
            ProgramTask3 app = new ProgramTask3();

            app.ReadPersons();
            app.ShowCountOfMalesWithAgeOver60();
            app.ShowAverageAge();
            app.ShowGroupList();

            Console.ReadLine();
        }

        private ProgramTask3() 
        { 
            _persons = new List<PersonTask3>();
        }

        private void ReadPersons()
        {
            ConsoleKey consoleKey = ConsoleKey.Y;

            while (consoleKey == ConsoleKey.Y)
            {
                PersonTask3 person = new PersonTask3();

                Console.WriteLine("Enter Firstname:");
                person.Firstname = Console.ReadLine();

                Console.WriteLine("Enter Lastname:");
                person.Lastname = Console.ReadLine();

                Console.WriteLine("Enter Address:");
                person.Address = Console.ReadLine();

                Console.WriteLine("Enter Birthday:");
                person.Birthday = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Enter Gender:");
                person.Gender = char.Parse(Console.ReadLine());

                _persons.Add(person);

                Console.WriteLine("Add new Person? Y - yes, N - no");
                consoleKey = Console.ReadKey(true).Key;
            }

            Console.WriteLine("");
        }

        private void ShowCountOfMalesWithAgeOver60()
        {
            int count = _persons.FindAll(person => (person.Gender == 'M' && person.Age > 60)).Count;

            Console.WriteLine("Males with age more than 60: " + count);
           
        }

        private void ShowAverageAge()
        {
            int summaryAge = 0;

            foreach (PersonTask3 person in _persons)
            {
                summaryAge += person.Age;
            }

            int result = summaryAge / _persons.Count;

            Console.WriteLine("Average age is: " + result);
        }

        private void ShowGroupList()
        {
            _persons.Sort();

            foreach (PersonTask3 person in _persons)
            {
                Console.WriteLine(person);
            }
        }
    }
}
