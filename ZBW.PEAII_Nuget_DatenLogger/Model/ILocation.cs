using System.Collections.Generic;

namespace ZBW.PEAII_Nuget_DatenLogger.Model
{
    public interface ILocation
    {
        int Id { get; set; }
        int Adress_fk { get; set; }
        int Room { get; set; }
        string Name { get; set; }
        string Designation { get; set; }
        string Building { get; set; }
        int Parent_location { get; set; }
        List<ILocation> Childs { get; set; }
        List<ILocation> Locations { get; set; }
    }
}