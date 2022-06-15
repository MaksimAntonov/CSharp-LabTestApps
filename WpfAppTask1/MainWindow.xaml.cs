using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using PersonLibrary;
using WpfAppTask1.Forms;

namespace WpfAppTask1
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Person> _persons;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _persons = new ObservableCollection<Person>();
            _persons.CollectionChanged += OnItemAdded;

            personsList.ItemsSource = _persons;
            personsList.Items.IsLiveSorting = true;
            personsList.Items.SortDescriptions.Add(new SortDescription("Address", ListSortDirection.Ascending));

        }

        private void OnAddClick(object sender, RoutedEventArgs e)
        {
            AddPersonForm personForm = new AddPersonForm(ref _persons);
            personForm.ShowDialog();
        }

        private void OnItemAdded(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                ShowCountsOfMilitaryAge();
                ShowMiddleAge();
            }
        }

        private void ShowCountsOfMilitaryAge()
        {
            List<Person> males = _persons.Where(person => person.Gender == 'M').ToList();
            int count = 0;

            foreach (Person male in males)
            {
                if (male is PersonTask1 person && person.IsConscript())
                    count++;
            }

            militaryAge.Text = count.ToString();
        }

        private void ShowMiddleAge()
        {
            int summaryAge = 0;

            for (int i = 0; i < _persons.Count; i++)
            {
                summaryAge += _persons[i].Age();
            }

            int result = summaryAge / _persons.Count;

            middleAge.Text = result.ToString();
        }
    }
}
