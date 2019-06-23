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
        public int address_fk { get; set; }
        public int room { get; set; }
        public string Name { get; set; }
        public string designation { get; set; }
        public string building { get; set; }
        public int parent_location { get; set; }
        public List<ILocation> Childs { get; set; }
        public List<ILocation> Locations { get; set; }
    }
}