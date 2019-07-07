using System.Collections.Generic;
using ZBW.PEAII_Nuget_DatenLogger.Model;

namespace ZBW.PEAII_Nuget_DatenLogger.Repositories.Table
{
    public interface ILocationRepository
    {
        List<ILocation> GetAllLocation();
        List<ILocation> GetLocationsHierarchie();
    }
}