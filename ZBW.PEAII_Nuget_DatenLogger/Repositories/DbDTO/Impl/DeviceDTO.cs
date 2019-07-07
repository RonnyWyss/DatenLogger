using LinqToDB.Mapping;

namespace ZBW.PEAII_Nuget_DatenLogger.Repositories.DbDTO.Impl
{
    [Table("Device")]
    public class DeviceDTO : BaseDTO<int>
    {
        [Column("id")]
        [PrimaryKey]
        [NotNull]
        public override int Id { get; set; }

        [Column("Fk_LocationId")]
        public int LocationIdFk { get; set; }

        [Column("Hostname")]
        public string Hostname { get; set; }

        [Column("Ip-Adress")]
        public string Ip_Adress { get; set; }

        [Column("description")]
        public string Categorie { get; set; }
    }
}