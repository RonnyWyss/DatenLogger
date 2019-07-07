using System;
using LinqToDB.Mapping;

namespace ZBW.PEAII_Nuget_DatenLogger.Repositories.DbDTO.Impl
{
    [Table("Log")]
    public class LoggingDTO : BaseDTO<int>
    {
        [Column("log_id")]
        [PrimaryKey]
        [NotNull]
        public override int Id { get; set; }

        [Column("device_fk")]
        public int DeviceFk { get; set; }

        [Column("timestamp")]
        public DateTime Timestamp { get; set; }

        [Column("logMessage")]
        public string LogMessage { get; set; }

        [Column("is_acknowledged")]
        public int IsAcknowledged { get; set; }
    }
}