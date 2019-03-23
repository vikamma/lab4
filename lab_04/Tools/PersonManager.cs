using lab_04.Models;

namespace lab_04.Tools
{
    public class PersonManager
    {
        readonly PersonBase _personBase;
        public PersonManager()
        {
            _personBase = new PersonBase();
        }

        public bool Add(Person person)
        {
            return true;
        }
    }
}
