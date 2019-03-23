using lab_04.Models;
using System.Collections.Generic;

namespace lab_04.Tools
{
    public class PersonBase
    {
        private static readonly List<Person> Persons = new List<Person>();


        internal void Add(Person person)
        {
            Persons.Add(person);
        }

        internal void Remove(Person patient)
        {
            Persons.Remove(patient);
        }

    }
}
