using System;

namespace ZBW.PEAII_Nuget_DatenLogger.Services
{
    public interface IGuidGeneratorService
    {
        Guid GetNewGuid();
    }
}