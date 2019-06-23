using System.Collections.Generic;
using System.Data;
using ZBW.PEAII_Nuget_DatenLogger.Model;
using ZBW.PEAII_Nuget_DatenLogger.Model.Impl;
using ZBW.PEAII_Nuget_DatenLogger.Repositories.DataAccessLayer.Impl;

namespace ZBW.PEAII_Nuget_DatenLogger.Repositories.Table.Impl
{
    public class LocationRepository : MySqlRepositoryBase<ILocation>, ILocationRepository
    {
        public override string TableName => "Location";

        public List<ILocation> GetAllLocation()
        {
            return GetAll();
        }

        public List<ILocation> GetLocationsHierarchie()
        {
            var allLocations = GetAll();
            var hierarchieTree = CreateHierarchieTree(allLocations);
            return hierarchieTree;
        }

        protected override ILocation CreateEntity(IDataReader r)
        {
            var entity = new Location();
            entity.Id = r.GetInt32(0);
            entity.Name = r.GetString(4);
            entity.address_fk = r.GetInt32(2);
            entity.building = r.GetString(3);
            entity.parent_location = r.GetInt32(1);
            entity.room = r.GetInt32(5);


            return entity;
        }

        private List<ILocation> CreateHierarchieTree(List<ILocation> locations)
        {
            var nodes = new List<ILocation>();
            foreach (var item in locations)
                if (item.parent_location == 0)
                    nodes.Add(item);
                else
                    CreateNode(nodes, item);
            return nodes;
        }

        private void CreateNode(List<ILocation> nodes, ILocation child)
        {
            foreach (var node in nodes)
                if (node.Id == child.parent_location)
                    node.Childs.Add(child);
                else
                    CreateNode(node.Childs, child);
        }
    }
}