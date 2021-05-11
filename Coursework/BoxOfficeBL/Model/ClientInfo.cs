using System;

namespace BoxOfficeBL.Model
{
    public class ClientInfo
    {
        public string Name { get; }
        public string Surname { get; }
        public string Email { get; }
        public ClientInfo(string name, string surname, string email)
        {
            #region verify the conditions
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name cannot be empty or null", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(surname))
            {
                throw new ArgumentNullException("Surname cannot be empty or null", nameof(surname));
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException("Phone number cannot be empty or null", nameof(email));
            }
            #endregion
            Name = name;
            Surname = surname;
            Email = email;
        }
        public override int GetHashCode()
        {
            return Email.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is ClientInfo && obj != null)
            {
                ClientInfo person = (ClientInfo)obj;
                return Name == person.Name && Surname == person.Surname && Email == person.Email;
            }
            return false;
        }
        public override string ToString()
        {
            return $"{Surname} {Name}";
        }
    }
}
