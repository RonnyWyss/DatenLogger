﻿using ZBW.PEAII_Nuget_DatenLogger.Model;

namespace ZBW.PEAII_Nuget_DatenLogger.Repositories.Table
{
    internal interface ILoggingRepository
    {
        void AddLogEntry(IEntity entity);

        void ClearLogEntry(IEntity entity);
    }
}