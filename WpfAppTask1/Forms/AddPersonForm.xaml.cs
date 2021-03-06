using PersonLibrary;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace WpfAppTask1.Forms
{
    public partial class AddPersonForm : Window
    {
        private ObservableCollection<PersonTask1> _persons;

        public AddPersonForm(ref ObservableCollection<PersonTask1> persons)
        {
            InitializeComponent();

            _persons = persons;
        }

        private void OnAddClick(object sender, RoutedEventArgs e)
        {
            PersonTask1 person = new PersonTask1();
            person.Lastname = lastname.Text.Trim();
            person.Address = address.Text.Trim();
            person.Birthday = birthday.SelectedDate.Value;
            ComboBoxItem comboBox = gender.SelectedValue as ComboBoxItem;
            person.Gender = char.Parse(comboBox.Tag.ToString());

            _persons.Add(person);
            Close();
        }
    }
}
