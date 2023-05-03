using System.ComponentModel.DataAnnotations;
using static Projekt_Jordnaer.Models.Vagt;

namespace Projekt_Jordnaer.Models
{
    //    public enum VagtType { Cafe, Cafeføl, Bager, Bagerføl}
    public enum VTypes
    {
        Cafe = 0,
        Cafeføl = 1,
        Bager = 2,
        Bagerføl = 3
    }

    public class Vagt
    {
        
        private int vagtId;
        private string vagtName;
        private string vagtDescription;
        private DateTime vagtStart;
        private DateTime vagtEnd;
        private VTypes vagtType;

        [Required]
        public virtual int VagtTypeId
        {
            get
            {
                return (int)this.vagtType;
            }
            set
            {
                vagtType = (VTypes)value;
            }
        }
        //[EnumDataType(typeof(VTypes))]
        //public VTypes VType { get; set; }




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

        public Vagt() 
        { }
        public Vagt(int vagtId, string vagtName, string vagtDescription, DateTime vagtStart, DateTime vagtEnd, VTypes vTypes)
        {
            
            VagtId = vagtId;
            VagtName = vagtName;
            VagtDescription = vagtDescription;
            VagtStart = vagtStart;
            VagtEnd = vagtEnd;
            VagtTypeId = (int)vTypes;

        }
        public override string ToString()
        {
            return $"Id: {VagtId}, Navn: {VagtName}, Beskrivelse: {VagtDescription}, Varihed: {VagtStart} til {VagtEnd}, Type: ";
        }
    }
}
