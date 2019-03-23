using lab_04.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace lab_04.Tools
{
    static class IDataStorage
    {
        public static List<Person> Persons { get; }

        static IDataStorage()
        {
            var filepath = Path.Combine(GetAndCreateDataPath(), Person.Filename);
            if (File.Exists(filepath))
            {
                try
                {
                    Persons = SerializationManager.Deserialize<List<Person>>(filepath);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to get users from file.{Environment.NewLine}{ex.Message}");
                    throw;
                }
            }
            else
            {
                Persons = new List<Person>();
                Random rnd = new Random();
                string[] lastNames = { "Matsiuk", "Cocoshco", "Sakharov", "Fomiv", "Miminin", "Oletskiy", "Lopuhina", "Nayem" };
                string[] firstNames = { "Taras", "Max", "Vika", "Milena", "Dasha", "Sima", "Nazar", "Nikita", "Shon" };
                for (int i = 0; i < 50; i++)
                    Persons.Add(new Person(lastNames[rnd.Next(0, 8)], firstNames[rnd.Next(0, 9)], $"user{i}@ukma.edu.ua", new DateTime(rnd.Next(DateTime.Today.Year - 135, DateTime.Today.Year - 1), rnd.Next(1, 13), rnd.Next(1, 30))));
            }
        }
        internal static Person AddPerson(string lastName, string firstName, string email, DateTime date)
        {
            Person person = new Person(lastName, firstName, email, date);
            Persons.Add(person);
            return person;
        }
        internal static void SaveData()
        {
            SerializationManager.Serialize(Persons, Path.Combine(GetAndCreateDataPath(), Person.Filename));
        }

        private static string GetAndCreateDataPath()
        {
            string dir = StationManager.WorkingDirectory;
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            return dir;
        }
    }
}
