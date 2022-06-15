using PersonLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace WpfAppTask2.Forms
{
    /// <summary>
    /// Interaction logic for AddPersonForm.xaml
    /// </summary>
    public partial class AddPersonForm : Window
    {
        private ObservableCollection<PersonTask2> _persons;

        public AddPersonForm(ref ObservableCollection<PersonTask2> persons)
        {
            InitializeComponent();

            _persons = persons;
        }

        private void OnAddClick(object sender, RoutedEventArgs e)
        {
            PersonTask2 person = new PersonTask2();
            person.Firstname = firstname.Text.Trim();
            person.Lastname = lastname.Text.Trim();
            person.Address = address.Text.Trim();
            person.Birthday = birthday.SelectedDate.Value;
            ComboBoxItem comboBox = gender.SelectedValue as ComboBoxItem;
            person.Gender = char.Parse(comboBox.Tag.ToString());
            person.Weight = int.Parse(pWeight.Text.Trim());
            person.Height = int.Parse(pHeight.Text.Trim());

            _persons.Add(person);
            Close();
        }
    }
}
