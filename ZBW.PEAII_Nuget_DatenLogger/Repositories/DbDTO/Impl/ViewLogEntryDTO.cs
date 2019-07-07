using System;
using LinqToDB.Mapping;

namespace ZBW.PEAII_Nuget_DatenLogger.Repositories.DbDTO.Impl
{
    [Table("v_logentries")]
    public class ViewLogEntryDTO : BaseDTO<int>
    {
        [Column("hostname")]
        public string Hostname { get; set; }

        [Column("id")]
        [PrimaryKey]
        [NotNull]
        public override int Id { get; set; }

        [Column("location")]
        public string Location { get; set; }

        [Column("pod")]
        public string Pod { get; set; }

        [Column("severity")]
        public int Severity { get; set; }

        [Column("message")]
        public string Text { get; set; }

        [Column("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}