using System;

namespace Part_2
{
    // Implement without LINQ
    public class PersonRepository
    {
        private IPerson[] _persons;

        public PersonRepository(IPerson[] persons)
        {
            _persons = persons;
        }

        // TODO: return count of mans
        public int ManCount
        {
            get { throw new NotImplementedException(); }
        }

        // TODO: return count of womans
        public int WomanCount
        {
            get { throw new NotImplementedException(); }
        }

        public IPerson[] Get()
        {
            // TODO: return all persons
            throw new NotImplementedException();
        }

        public IPerson Get(long id)
        {
            // TODO: find person by Id
            throw new NotImplementedException();
        }

        public IPerson[] GetOrderedPersons()
        {
            // TODO: reuse Sorting class and return ordered Persons
            throw new NotImplementedException();
        }

        public IPerson[] GetDescendingOrderedPersons()
        {
            // TODO: reuse Sorting class and return descending ordered Persons
            throw new NotImplementedException();
        }

        public string[] GetUniquePersonEmails()
        {
            // TODO: get person emails and return list of Unique Emails
            throw new NotImplementedException();
        }

        public IPerson Add(IPerson person)
        {
            // TODO: add new Person
            throw new NotImplementedException();
        }

        public IPerson Edit(IPerson person)
        {
            // TODO: edit person
            throw new NotImplementedException();
        }

        public IPerson Delete(long id)
        {
            // TODO: delete person
            throw new NotImplementedException();
        }
    }
}
