
namespace Part_2
{
    // TODO: inherit IPerson interface
    // TODO: create Person class with public parameters Id (long), FirstName (string), LastName (string), Email (string), Gender (Enum).
    // TODO: add method to get full name()
    // TODO: validate an email, email validation: check for NULL or Empty and contains string = "@". OnFail - thrown an ArgumentException.
    // TODO: override Equals and  GetHashCode

    public class Person:IPerson
    {
        private string email;
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email {
            get=>email;
            set
            {
                if (string.IsNullOrEmpty(value) | !value.Contains("@")) throw new System.ArgumentException();
                email = value;
            }
        }
        public Gender Gender { get; set; }

        public int CompareTo(IPerson other)
        {
            if (other == null) return 1;
            else 
            {
                int returnCode = 0;// не знал как лучше назвать
                returnCode = this.Id.CompareTo(other.Id);
                if (returnCode != 0) return returnCode;
                returnCode = this.GetFullName().CompareTo(other.GetFullName());
                if (returnCode != 0) return returnCode;
                returnCode = this.Email.CompareTo(other.Email);
                if (returnCode != 0) return returnCode;
                returnCode = this.Gender.CompareTo(other.Gender);
                return returnCode;
            }

        }

        public int CompareTo(object obj) => obj == null ? 1 : CompareTo(obj as IPerson);

        public string GetFullName() => FirstName + LastName;
        public override bool Equals(object obj)
        {
            if (!(obj is IPerson person)) return false;
            if (Id != person.Id) return false;
            if (GetFullName() != person.GetFullName()) return false;
            if (!email.Equals(person.Email)) return false;
            if (Gender != person.Gender) return false;
            return true;
        }
        public override int GetHashCode()
        {
            int returncode = 0;
            returncode = Id.GetHashCode();
            returncode += FirstName.GetHashCode();
            returncode += LastName.GetHashCode();
            returncode += Email.GetHashCode();
            returncode += Gender.GetHashCode();
            return returncode;
        }

    }
}
