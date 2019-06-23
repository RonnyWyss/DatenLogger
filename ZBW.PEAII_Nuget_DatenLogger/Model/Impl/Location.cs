using System.Collections.Generic;

namespace ZBW.PEAII_Nuget_DatenLogger.Model.Impl
{
    public class Location : ILocation
    {
        public Location()
        {
            Childs = new List<ILocation>();
        }

        public int Id { get; set; }
        public int Fk_Address { get; set; }
        public int Room { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Building { get; set; }
        public int ParentId { get; set; }
        public List<ILocation> Childs { get; set; }
        public List<ILocation> Locations { get; set; }
    }
}