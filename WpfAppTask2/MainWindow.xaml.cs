using PersonLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppTask2.Forms;

namespace WpfAppTask2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<PersonTask2> _persons;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _persons = new ObservableCollection<PersonTask2>();
            _persons.CollectionChanged += OnItemAdded;

            personsList.ItemsSource = _persons;
            personsList.Items.IsLiveSorting = true;
            personsList.Items.SortDescriptions.Add(new SortDescription("Height", ListSortDirection.Ascending));
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
                ShowCountOfHeavyPersons();
                ShowAverageWeight();
            }
        }

        private void ShowAverageWeight()
        {
            int summaryWeight = 0;

            foreach (PersonTask2 person in _persons)
            {
                summaryWeight += person.Weight;
            }

            int result = summaryWeight / _persons.Count;

            averageWeight.Text = result.ToString();
        }

        private void ShowCountOfHeavyPersons()
        {
            int count = 0;

            foreach (PersonTask2 person in _persons)
            {
                if (person.Weight > 100)
                    count++;
            }

            heavyPersons.Text = count.ToString();
        }
    }
}
