using System.Collections.Generic;

namespace ZBW.PEAII_Nuget_DatenLogger.Model
{
    public interface ILocation
    {
        int Id { get; set; }
        int Fk_Address { get; set; }
        int Room { get; set; }
        string Name { get; set; }
        string Designation { get; set; }
        string Building { get; set; }
        int ParentId { get; set; }
        List<ILocation> Childs { get; set; }
        List<ILocation> Locations { get; set; }
    }
}