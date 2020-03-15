using MvvmFramework;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Models {
    [XmlRoot]
    public class Person : Validatable {
        private int id;
        private string firstName;
        private string lastName;
        private int age;
        private string emailAddress;

        [XmlAttribute]
        [Required]
        public int Id {
            get { return id; }
            set {
                id = value; 
                OnPropertyChanged();
            }
        }

        [XmlAttribute]
        [Required]
        public string FirstName {
            get { return firstName; }
            set {
                firstName = value; 
                OnPropertyChanged();
            }
        }

        [XmlAttribute]
        [Required]
        public string LastName {
            get { return lastName; }
            set {
                lastName = value; 
                OnPropertyChanged();
            }
        }

        [XmlAttribute]
        [Required]
        public int Age {
            get { return age; }
            set {
                age = value; 
                OnPropertyChanged();
            }
        }

        [XmlAttribute]
        [EmailAddress]
        public string EmailAddress {
            get { return emailAddress; }
            set {
                emailAddress = value; 
                OnPropertyChanged();
            }
        }
    }
}