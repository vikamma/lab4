using lab_04.Models;
using lab_04.Tools;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace lab_04.ViewModels
{
    public class PersonViewModel : INotifyPropertyChanged
    {

        private readonly Person _domObject;
        private readonly Action<bool> _showLoaderAction;

        public PersonViewModel(Action<bool> showLoader)
        {
            _domObject = new Person();
            new PersonManager();
            Persons = new ObservableCollection<Person>(IDataStorage.Persons);
            AddPersonCmd = new RelayCommand(Add);
            EditPersonCmd = new RelayCommand(Edit);
            SavePersonCmd = new RelayCommand(Save);
            DeletePersonCmd = new RelayCommand(Delete);
            _showLoaderAction = showLoader;
        }

        public PersonViewModel()
        {
            _domObject = new Person();
            new PersonManager();
            Persons = new ObservableCollection<Person>();
            AddPersonCmd = new RelayCommand(Add);
        }

        public string Surname
        {
            get => _domObject.Surname;
            set
            {
                _domObject.Surname = value;
                OnPropertyChanged("LastName");
            }
        }

        public string Name
        {
            get => _domObject.Name;
            set
            {
                _domObject.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Email
        {
            get => _domObject.Email;
            set
            {
                _domObject.Email = value;
                OnPropertyChanged("Email");
            }
        }

        public DateTime Date
        {
            get => _domObject.Date;
            set
            {
                _domObject.Date = value;
                OnPropertyChanged("DateOfBirth");
            }
        }

        public bool IsAdult => _domObject.IsAdult;
        public string SunSign => _domObject.SunSign;
        public string ChineseSign => _domObject.ChineseSign;
        public bool IsBirthday => _domObject.IsBirthday;

        public ObservableCollection<Person> Persons { get; }
        public ICommand AddPersonCmd { get; }
        public ICommand EditPersonCmd { get; }
        public ICommand SavePersonCmd { get; }
        public ICommand DeletePersonCmd { get; }
        public Person SelectedItem { get; set; }

        public async void Add(object obj)
        {
            _showLoaderAction.Invoke(true);

            await Task.Run((() => { Thread.Sleep(2000); }));
            try
            {
                if (Surname == string.Empty)
                {
                    throw new IlligalInputException("Last Name");
                }

                if (Name == string.Empty)
                {
                    throw new IlligalInputException("Last Name");
                }

                int check = DateTime.Today.Year - Date.Year;
                if (DateTime.Today.Date < Date.Date || check > 135)
                {
                    throw new IlligalDateException(Date.ToString(CultureInfo.InvariantCulture) + " ");
                }

                var person = new Person {Surname = Surname, Name = Name, Email = Email, Date = Date};
                IDataStorage.AddPerson(Surname, Name, Email, Date);
                Persons.Add(person);
                if (person.Date.DayOfYear.Equals(DateTime.Today.DayOfYear)) MessageBox.Show("HappyBirthday");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            ResetPerson();
            _showLoaderAction.Invoke(false);
        }

        public void Edit(object obj)
        {
            SetPerson(SelectedItem);
        }

        public void Save(object obj)
        {
            try
            {
                if (Surname == string.Empty)
                {
                    throw new IlligalInputException("Last Name");
                }

                if (Name == string.Empty)
                {
                    throw new IlligalInputException("Last Name");
                }

                //if (!new EmailAddressAttribute().IsValid(Email))
                //{
                //    throw new IlligalEmailException(Email);
                //}
                int check = DateTime.Today.Year - Date.Year;
                if (DateTime.Today.Date < Date.Date || check > 135)
                {
                    throw new IlligalDateException(Date.ToString(CultureInfo.InvariantCulture) + " ");
                }

                SelectedItem.Surname = Surname;
                SelectedItem.Name = Name;
                SelectedItem.Email = Email;
                SelectedItem.Date = Date;
                if (Date.DayOfYear.Equals(DateTime.Today.DayOfYear)) MessageBox.Show("HappyBirthday");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            ResetPerson();
        }

        public void Delete(object obj)
        {
            Persons.Remove(SelectedItem);
            IDataStorage.Persons.Remove(SelectedItem);
        }

        private void ResetPerson()
        {
            Surname = string.Empty;
            Name = string.Empty;
            Email = string.Empty;
        }

        private void SetPerson(Person p)
        {
            Surname = p.Surname;
            Name = p.Name;
            Email = p.Email;
            Date = p.Date;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal class IlligalInputException : Exception
        {
            public IlligalInputException(string error)
                : base("Error: this field" + error + " is required")
            {
            }
        }

        internal class IlligalDateException : Exception
        {
            public IlligalDateException(string error)
                : base("Error: illigal format of date: " + error +
                       "You can`t be older than 135 years or have not born yet")
            {
            }
        }

        internal class IlligalEmailException : Exception
        {
            public IlligalEmailException(string error)
                : base("Error: illigal format of email: " + error)
            {
            }
        }
    }
}
