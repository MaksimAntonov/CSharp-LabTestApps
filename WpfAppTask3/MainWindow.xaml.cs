using PersonLibrary;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using WpfAppTask3.Forms;

namespace WpfAppTask3
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<PersonTask3> _persons;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _persons = new ObservableCollection<PersonTask3>();
            _persons.CollectionChanged += OnItemAdded;

            personsList.ItemsSource = _persons;
            personsList.Items.IsLiveSorting = true;
            personsList.Items.SortDescriptions.Add(new SortDescription("Age", ListSortDirection.Ascending));
        }

        private void OnItemAdded(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                ShowCountOfMalesWithAgeOver60();
                ShowAverageAge();
            }
        }

        private void OnAddClick(object sender, RoutedEventArgs e)
        {
            AddPersonForm personForm = new AddPersonForm(ref _persons);
            personForm.ShowDialog();
        }

        private void ShowCountOfMalesWithAgeOver60()
        {
            int count = _persons.Where(person => (person.Gender == 'M' && person.Age > 60)).Count();

            malesOver60.Text = count.ToString();

        }

        private void ShowAverageAge()
        {
            int summaryAge = 0;

            foreach (PersonTask3 person in _persons)
            {
                summaryAge += person.Age;
            }

            int result = summaryAge / _persons.Count;

            averageAge.Text = result.ToString();
        }
    }
}
