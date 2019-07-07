using System.Collections.Generic;
using System.Linq;
using ZBW.PEAII_Nuget_DatenLogger.Model;
using ZBW.PEAII_Nuget_DatenLogger.Model.Impl;
using ZBW.PEAII_Nuget_DatenLogger.Repositories.DataAccessLayer.Impl;
using ZBW.PEAII_Nuget_DatenLogger.Repositories.DbDTO.Impl;

namespace ZBW.PEAII_Nuget_DatenLogger.Repositories.Table.Impl
{
    public class DeviceRepository : MySqlRepositoryBase<DeviceDTO, int>, IDeviceRepository
    {
        public List<IDevice> GetDevices()
        {
            var allDevice = GetAll();
            var devices = allDevice.Select(device => (IDevice) new Device
            {
                Categorie = device.Categorie,
                Fk_LocationId = device.LocationIdFk,
                Hostname = device.Hostname,
                Id = device.Id,
                Ip_Adress = device.Ip_Adress
            }).ToList();

            return devices;
        }

        public List<int> GetDeviceIds()
        {
            var allDevice = GetAll();
            var deviceIds = allDevice.Select(d => d.Id).ToList();

            return deviceIds;
        }

        public List<string> GetDeviceHostname()
        {
            var allDevice = GetAll();

            var deviceHostname = allDevice.Select(d => d.Hostname).ToList();

            return deviceHostname;
        }
    }
}