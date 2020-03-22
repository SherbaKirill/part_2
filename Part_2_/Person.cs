
namespace Part_2
{
    public class Person : IPerson
    {
        private string _email;
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email {
            get => _email;
            set
            {
                if (string.IsNullOrEmpty(value) || !value.Contains("@"))
                    throw new System.ArgumentException();
                _email = value;
            }
        }
        public Gender Gender { get; set; }

        public int CompareTo(IPerson other)
        {
            if (other == null) return 1;
            else 
            {
                int compareResult = 0;
                compareResult = this.Id.CompareTo(other.Id);
                if (compareResult != 0) return compareResult;
                compareResult = this.FirstName.CompareTo(other.FirstName);
                if (compareResult != 0) return compareResult;
                compareResult = this.LastName.CompareTo(other.LastName);
                if (compareResult != 0) return compareResult;
                compareResult = this.Email.CompareTo(other.Email);
                if (compareResult != 0) return compareResult;
                compareResult = this.Gender.CompareTo(other.Gender);
                return compareResult;
            }

        }

        public int CompareTo(object obj) => obj == null ? 1 : CompareTo(obj as IPerson);

        public string GetFullName() => FirstName + " " + LastName;
        public override bool Equals(object obj) => obj is IPerson person && Id == person.Id &&
             FirstName.Equals(person.FirstName) && LastName.Equals(person.LastName) && 
             Email.Equals(person.Email) && Gender == person.Gender;
        public override int GetHashCode()
        {
            int compareResult = 13;
            compareResult = compareResult * 13 + Id.GetHashCode();
            compareResult = compareResult * 13 + FirstName?.GetHashCode() ?? 0;
            compareResult = compareResult * 13 + LastName?.GetHashCode() ?? 0;
            compareResult = compareResult * 13 + Email?.GetHashCode() ?? 0;
            compareResult = compareResult * 13 + Gender.GetHashCode();
            return compareResult;
        }

    }
}
