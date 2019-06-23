using System.Collections.Generic;
using ZBW.PEAII_Nuget_DatenLogger.Model;

namespace ZBW.PEAII_Nuget_DatenLogger.Repositories.Table
{
    public interface IDeviceRepository
    {
        List<string> GetDeviceHostname();

        List<int> GetDeviceIds();

        List<IDevice> GetDevices();

        void SetConnectionString(string connString);
    }
}