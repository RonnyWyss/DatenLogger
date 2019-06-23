using System.Collections.Generic;
using System.Data;
using ZBW.PEAII_Nuget_DatenLogger.Model;
using ZBW.PEAII_Nuget_DatenLogger.Model.Impl;
using ZBW.PEAII_Nuget_DatenLogger.Repositories.DataAccessLayer.Impl;

namespace ZBW.PEAII_Nuget_DatenLogger.Repositories.Table.Impl
{
    public class DeviceRepository : MySqlRepositoryBase<IDevice>, IDeviceRepository
    {
        public override string TableName => "Device";

        public List<IDevice> GetDevices()
        {
            var allDevice = GetAll();
            return allDevice;
        }

        public List<int> GetDeviceIds()
        {
            var devices = GetDevices();
            var ids = new List<int>();
            foreach (var dev in devices) ids.Add(dev.Id);

            return ids;
        }

        public List<string> GetDeviceHostname()
        {
            var devices = GetDevices();
            var hostname = new List<string>();
            foreach (var dev in devices) hostname.Add(dev.Hostname);

            return hostname;
        }

        protected override IDevice CreateEntity(IDataReader r)
        {
            var entity = new Device();
            entity.Id = r.GetInt32(0);
            entity.Hostname = r.GetString(1);
            entity.Ip_Adress = r.GetString(2);
            entity.Categorie = r.GetString(3);
            //  entity.Fk_LocationId = r.GetInt32(4);

            return entity;
        }
    }
}