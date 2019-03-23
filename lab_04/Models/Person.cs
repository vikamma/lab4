using System;

namespace lab_04.Models
{

    [Serializable]
    public class Person
    {
        internal const string Filename = "PersonsDB.dat";
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public bool IsAdult
        {
            get
            {
                CalculateAge();
                return _age >= 18;
            }
        }
        public string SunSign
        {
            get
            {
                CalculateZodiacs();
                return _sunSign;
            }
        }
        public string ChineseSign
        {
            get
            {
                CalculateZodiacs();
                return _chineseSign;
            }
        }

        public bool IsBirthday
        {
            get
            {
                if (Date.Day == DateTime.Today.Day && Date.Month == DateTime.Today.Month) _isBirthday = true;
                return _isBirthday;
            }
        }

        private string _sunSign;
        private string _chineseSign;
        private bool _isBirthday;
        public DateTime Date { get; set; }

        private int _age;
        public Person(string name, string lastName, string email, DateTime dateOfBirth)
        {
            Name = name;
            Surname = lastName;
            Email = email;
            Date = dateOfBirth;
        }
        public Person(string name, string lastName, string email)
        {
            Name = name;
            Surname = lastName;
            Email = email;
        }
        public Person(string name, string lastName, DateTime dateOfBirth)
        {
            Name = name;
            Surname = lastName;
            Date = dateOfBirth;
            Date = dateOfBirth;
        }

        public Person(DateTime dateOfBirth)
        {
            Date = dateOfBirth;
        }

        public Person()
        {
        }

        private void CalculateAge()
        {
            DateTime today = DateTime.Today;
            _age = today.DayOfYear <= Date.DayOfYear
                ? today.Year - Date.Year - 1
                : today.Year - Date.Year;
        }

        private void CalculateZodiacs()
        {
            switch (Date.Month)
            {
                case 1:
                    _sunSign = Date.Day < 20 ? "Capricorn" : "Aquarius";
                    break;
                case 2:
                    _sunSign = Date.Day < 18 ? "Aquarius" : "Pisces";
                    break;
                case 3:
                    _sunSign = Date.Day < 20 ? "Pisces" : "Aries";
                    break;
                case 4:
                    _sunSign = Date.Day < 20 ? "Aries" : "Taurus";
                    break;
                case 5:
                    _sunSign = Date.Day < 21 ? "Taurus" : "Gemini";
                    break;
                case 6:
                    _sunSign = Date.Day < 21 ? "Gemini" : "Cancer";
                    break;
                case 7:
                    _sunSign = Date.Day < 23 ? "Cancer" : "Leo";
                    break;
                case 8:
                    _sunSign = Date.Day < 23 ? "Leo" : "Virgo";
                    break;
                case 9:
                    _sunSign = Date.Day < 23 ? "Virgo" : "Libra";
                    break;
                case 10:
                    _sunSign = Date.Day < 23 ? "Libra" : "Scorpio";
                    break;
                case 11:
                    _sunSign = Date.Day < 22 ? "Scorpio" : "Sagittarius";
                    break;
                case 12:
                    _sunSign = Date.Day < 22 ? "Sagittarius" : "Capricorn";
                    break;
            }

            switch (Date.Year % 12)
            {
                case 0:
                    _chineseSign = "Monkey";
                    break;
                case 1:
                    _chineseSign = "Rooster";
                    break;
                case 2:
                    _chineseSign = "Dog";
                    break;
                case 3:
                    _chineseSign = "Pig";
                    break;
                case 4:
                    _chineseSign = "Rat";
                    break;
                case 5:
                    _chineseSign = "Ox";
                    break;
                case 6:
                    _chineseSign = "Tiger";
                    break;
                case 7:
                    _chineseSign = "Rabbit";
                    break;
                case 8:
                    _chineseSign = "Dragon";
                    break;
                case 9:
                    _chineseSign = "Snake";
                    break;
                case 10:
                    _chineseSign = "Horse";
                    break;
                case 11:
                    _chineseSign = "Sheep";
                    break;
            }
        }

    }
}
