using System;

namespace ZBW.PEAII_Nuget_DatenLogger.Services.Impl
{
    internal class GuidGeneratorService : IGuidGeneratorService
    {
        public Guid GetNewGuid()
        {
            return Guid.NewGuid();
        }
    }
}