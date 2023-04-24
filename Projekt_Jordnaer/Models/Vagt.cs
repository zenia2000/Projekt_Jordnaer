namespace Projekt_Jordnaer.Models
{
    public class Vagt
    {
        private string vagtId; 
        private string vagtName;
        private string vagtDescription;
        private DateTime vagtDuration;
        private enum vagtType {Bager, Bagerføl };

        public string VagtId
        {
            get { return vagtId; }
            set { vagtId = value; }
        }

        public string VagtName
        {
            get { return vagtName; }
            set { vagtName = value; }
        }

        public string VagtDescription
        {
            get { return vagtDescription; }
            set { vagtDescription = value; }
        }

        public DateTime VagtDuration
        {
            get { return vagtDuration; }
            set { vagtDuration = value; }
        }

        /*public Enum VagtType
        {
            get { return vagtType; }
            set { vagtType = value; }
        }
        */
        public Vagt(string vagtId, string vagtName, string vagtDescription, DateTime vagtDuration/*, Enum vagtType*/)
        {
            VagtId = vagtId;
            VagtName = vagtName;
            VagtDescription = vagtDescription;
            VagtDuration = vagtDuration;
          //  VagtType = vagtType;
            
        }

        public override string ToString()
        {
            return $"Id: {VagtId}, Navn: {VagtName}, Beskrivelse: {VagtDescription}, Varihed: {VagtDuration}, Type: ";
        }
    }
}
