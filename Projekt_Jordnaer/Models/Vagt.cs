namespace Projekt_Jordnaer.Models
{
    public class Vagt
    {
        
        private int vagtId;
        private string vagtName;
        private string vagtDescription;
        private DateTime vagtStart;
        private DateTime vagtEnd;
        private enum vagtType { Cafe, Bager, Cafeføl, Bagerføl };


        public int VagtId
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

        public DateTime VagtStart
        {
            get { return vagtStart; }
            set { vagtStart = value; }
        }

        public DateTime VagtEnd
        {
            get { return vagtEnd; }
            set { vagtEnd = value; }
        }

        /*public Enum VagtType
        {
            get { return vagtType; }
            set { vagtType = value; }
        }
        */

        public Vagt() 
        { }
        public Vagt(int vagtId, string vagtName, string vagtDescription, DateTime vagtStart, DateTime vagtEnd/*, Enum vagtType*/)
        {
            
            VagtId = vagtId;
            VagtName = vagtName;
            VagtDescription = vagtDescription;
            VagtStart = vagtStart;
            VagtEnd = vagtEnd;
            //  VagtType = vagtType;

        }

        public override string ToString()
        {
            return $"Id: {VagtId}, Navn: {VagtName}, Beskrivelse: {VagtDescription}, Varihed: {VagtStart} til {VagtEnd}, Type: ";
        }
    }
}
