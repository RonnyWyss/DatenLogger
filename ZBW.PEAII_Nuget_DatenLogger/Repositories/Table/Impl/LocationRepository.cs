using System.Collections.Generic;
using System.Linq;
using ZBW.PEAII_Nuget_DatenLogger.Model;
using ZBW.PEAII_Nuget_DatenLogger.Model.Impl;
using ZBW.PEAII_Nuget_DatenLogger.Repositories.DataAccessLayer.Impl;
using ZBW.PEAII_Nuget_DatenLogger.Repositories.DbDTO.Impl;

namespace ZBW.PEAII_Nuget_DatenLogger.Repositories.Table.Impl
{
    public class LocationRepository : MySqlRepositoryBase<LocationDTO, int>, ILocationRepository
    {
        //  public override string TableName => "Location";

        public List<ILocation> GetAllLocation()
        {
            var allLocation = GetAll();
            var locations = allLocation.Select(location => (ILocation) new Location
            {
                Room = location.room,
                Adress_fk = location.Adress_fk,
                Id = location.Id,
                Name = location.designation,
                Parent_location = location.Parent_location
            }).ToList();

            return locations;
        }

        public List<ILocation> GetLocationsHierarchie()
        {
            var allLocations = GetAllLocation();
            var hierarchieTree = CreateHierarchieTree(allLocations);
            return hierarchieTree;
        }

        private List<ILocation> CreateHierarchieTree(List<ILocation> locations)
        {
            var nodes = new List<ILocation>();
            foreach (var item in locations)
                if (item.Parent_location == 0)
                    nodes.Add(item);
                else
                    CreateNode(nodes, item);
            return nodes;
        }

        private void CreateNode(List<ILocation> nodes, ILocation child)
        {
            foreach (var node in nodes)
                if (node.Id == child.Parent_location)
                    node.Childs.Add(child);
                else
                    CreateNode(node.Childs, child);
        }
    }
}