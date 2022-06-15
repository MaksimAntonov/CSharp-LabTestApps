using PersonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTask2
{
    internal class ProgramTask2
    {
        private readonly List<PersonTask2> _persons;

        static void Main(string[] args)
        {
            ProgramTask2 app = new ProgramTask2();

            app.ReadPersons();

            app.ShowCountOfHeavyPersons();

            app.ShowAverageWeight();

            app.ShowGroupList();

            Console.ReadLine();
        }

        private ProgramTask2()
        {
            _persons = new List<PersonTask2>();
        }

        public void ReadPersons()
        {
            ConsoleKey consoleKey = ConsoleKey.Y;

            while (consoleKey == ConsoleKey.Y)
            {
                PersonTask2 person = new PersonTask2();

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

                Console.WriteLine("Enter weight:");
                person.Weight = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter height:");
                person.Height = int.Parse(Console.ReadLine());

                _persons.Add(person);

                Console.WriteLine("Add new Person? Y - yes, N - no");
                consoleKey = Console.ReadKey(true).Key;
            }

            Console.WriteLine("");
        }

        public void ShowCountOfHeavyPersons()
        {
            int count = 0;

            foreach (PersonTask2 person in _persons)
            {
                if (person.Weight > 100)
                    count++;
            }

            Console.WriteLine("Persons with large weight: " + count);
        }

        public void ShowAverageWeight()
        {
            int summaryWeight = 0;

            foreach (PersonTask2 person in _persons)
            {
                summaryWeight += person.Weight;
            }

            int result = summaryWeight / _persons.Count;

            Console.WriteLine("Average weight: " + result);
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
