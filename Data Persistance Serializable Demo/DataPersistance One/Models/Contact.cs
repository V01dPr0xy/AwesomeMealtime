using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPersistance_One.Models
{
    [Serializable]
    public class Contact
    {
        public string firstName;
        public string lastName;

        public List<PhoneNumber> phoneNumbers;
        public List<Email> emails;

        public Group group;
    }

    [Serializable]
    public struct PhoneNumber
    {
        public string number;
        public NumberType type;
    }

    [Serializable]
    public struct Email
    {
        public string emailAdress;
        public emailType type;
    }

    [Serializable]
    public enum Group
    {
        Family, Friends, Coworkers
    }

    [Serializable]
    public enum NumberType
    {
        Work, Home, Cell
    }

    [Serializable]
    public enum emailType
    {
        Work,Personal
    }
}
