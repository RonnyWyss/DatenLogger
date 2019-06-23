using System.Collections.Generic;

namespace ZBW.PEAII_Nuget_DatenLogger.Model
{
    public interface ILocation
    {
        int Id { get; set; }
        int address_fk { get; set; }
        int room { get; set; }
        string Name { get; set; }
        string designation { get; set; }
        string building { get; set; }
        int parent_location { get; set; }
        List<ILocation> Childs { get; set; }
        List<ILocation> Locations { get; set; }
    }
}