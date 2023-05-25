namespace Projekt_Jordnaer.Models
{
    public class Medlem
    {
        private int _memberID;
        private string _name;
        private string _address;
        private string _email;
        private string _phoneNr;
        private bool _certificate;
        private bool _admin;

        public int MemberID 
        {
            get { return _memberID; }
            set { _memberID = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string PhoneNr
        {
            get { return _phoneNr; }
            set { _phoneNr = value; }
        }

        public bool Certificate
        {
            get { return _certificate; }
            set { _certificate = value; }
        }

        public bool Admin
        {
            get { return _admin; }
            set { _admin = value; }
        }

        public Medlem()
        {

        }

        public Medlem(int memberID, string name, string address, string email, string phoneNr, bool certificate, bool admin)
        {
            _memberID = memberID;
            _name = name;
            _address = address;
            _email = email;
            _phoneNr = phoneNr;
            _certificate = certificate;
            _admin = admin;
        }

        public override string ToString()
        {
            return $"Medlem ID: {MemberID}, Navn: {Name}, Adresse: {Address}, Email: {Email}, Telefon nr.: {PhoneNr}, Certifikat: {Certificate}, Admin: {Admin} ";
        }
    }
}
