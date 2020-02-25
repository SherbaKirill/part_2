using System;
using Part_2;

namespace Part_2_Tests
{
    public class TestPerson : IPerson
    {
        private string _email;

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email
        {
            get => _email;
            set
            {
                if(string.IsNullOrWhiteSpace(value) || !value.Contains("@")) throw new ArgumentException();
                _email = value;
            }
        }

        public Gender Gender { get; set; }

        public int CompareTo(IPerson testPerson) => testPerson == null ? 1 : Id.CompareTo(testPerson.Id);

        public int CompareTo(object obj) => obj == null ? 1 : CompareTo(obj as IPerson);

        public string GetFullName() => $"{FirstName} {LastName}";

        public override bool Equals(object obj) => obj is IPerson testPerson && Id == testPerson.Id;

        public override int GetHashCode() => Id.GetHashCode();
    }
}
