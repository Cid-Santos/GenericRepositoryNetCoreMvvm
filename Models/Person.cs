using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Models
{

    public class Person
    {
        #region Atributos da classe person
        private int persId;
        private string persFirstName;
        private string persLastName;
        private int persAge;
        private string persEmail;
        #endregion

        #region Métodos da classe person
        public int PersId
        {
            get { return persId; }
            set { persId = value; }
        }

        public string PersFirstName
        {
            get { return persFirstName; }
            set { persFirstName = value; }
        }

        public string PersLastName
        {
            get { return persLastName; }
            set { persLastName = value; }
        }

        public int PersAge
        {
            get { return persAge; }
            set { persAge = value; }
        }

        public string PersEmail
        {
            get { return persEmail; }
            set { persEmail = value; }
        }
        #endregion
    }
}