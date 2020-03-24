using System;

namespace Part_2
{
    public class PersonRepository
    {
        private IPerson[] _persons;

        public PersonRepository(IPerson[] persons)
        {
            _persons = persons;
        }

        public int ManCount
        {
            get { return Array.FindAll(_persons, x => x.Gender == Gender.M).Length; }
        }

        public int WomanCount
        {
            get { return Array.FindAll( _persons, x => x.Gender == Gender.W).Length; }
        }

        public IPerson[] Get()
        {
            return _persons;
        }

        public IPerson Get(long id)
        {
            return Array.Find(_persons, x => x.Id == id);
        }

        public IPerson[] GetOrderedPersons()
        {
            return Sorting.Order(_persons);
        }

        public IPerson[] GetDescendingOrderedPersons()
        {
            return Sorting.DescendingOrder(_persons);
        }

        public string[] GetUniquePersonEmails()
        {
            string[] listEmails = new string[_persons.Length];
            for (int elem = 0; elem < _persons.Length; elem++)
                listEmails[elem] = _persons[elem].Email;
            return Sorting.Unique(listEmails);
        }

        public IPerson Add(IPerson person)
        {
            Array.Resize(ref _persons, _persons.Length + 1);
            _persons[_persons.Length - 1] = person;
            return Get(person.Id);
        }

        public IPerson Edit(IPerson person)
        {
                _persons[Array.IndexOf(_persons, Get(person.Id))] = person;
                return Get(person.Id);
        }

        public IPerson Delete(long id)
        {
            IPerson[] personsAfterDel = new IPerson[_persons.Length - 1];
            int index = Array.IndexOf(_persons, Get(id));
            IPerson deletedPerson = _persons[index];
            Array.Copy(_persons, 0, personsAfterDel, 0, index);
            Array.Copy(_persons, index + 1, personsAfterDel, index, _persons.Length - index-1);
            _persons = personsAfterDel;
            return deletedPerson;
            
        }
    }
}
