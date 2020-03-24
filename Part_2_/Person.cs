
namespace Part_2
{
    // TODO: inherit IPerson interface
    // TODO: create Person class with public parameters Id (long), FirstName (string), LastName (string), Email (string), Gender (Enum).
    // TODO: add method to get full name()
    // TODO: validate an email, email validation: check for NULL or Empty and contains string = "@". OnFail - thrown an ArgumentException.
    // TODO: override Equals and  GetHashCode

    public class Person : IPerson
    {
        private string email;
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email {
            get => email;
            set
            {
                if (string.IsNullOrEmpty(value) || !value.Contains("@")) throw new System.ArgumentException();
                email = value;
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
                compareResult = this.GetFullName().CompareTo(other.GetFullName());
                if (compareResult != 0) return compareResult;
                compareResult = this.Email.CompareTo(other.Email);
                if (compareResult != 0) return compareResult;
                compareResult = this.Gender.CompareTo(other.Gender);
                return compareResult;
            }

        }

        public int CompareTo(object obj) => obj == null ? 1 : CompareTo(obj as IPerson);

        public string GetFullName() => FirstName + " " + LastName;
        public override bool Equals(object obj) => obj is IPerson person && Id == person.Id && GetFullName() == person.GetFullName() && email.Equals(person.Email) && Gender == person.Gender;
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
