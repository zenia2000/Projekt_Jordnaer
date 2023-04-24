namespace Projekt_Jordnaer.Models
{
    public class Medlem
    {
        private int _memberID;
        private string _name;
        private string _address;
        private string _email;
        private string _phoneNr;
        private bool _admin;

        public int MemberID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string PhoneNr { get; set; }

        public bool Admin { get; set; }

        public Medlem(int memberID, string name, string address, string email, string phoneNr, bool admin)
        {
            _memberID = memberID;
            _name = name;
            _address = address;
            _email = email;
            _phoneNr = phoneNr;
            _admin = admin;
        }

        public override string ToString()
        {
            return $"Medlem ID: {MemberID}, Navn: {Name}, Adresse: {Address}, Email: {Email}, Telefon nr.: {PhoneNr}, Admin: {Admin}";
        }
    }
}
