using LinqToDB.Mapping;

namespace ZBW.PEAII_Nuget_DatenLogger.Repositories.DbDTO.Impl
{
    [Table("location")]
    public class LocationDTO : BaseDTO<int>
    {
        [Column("location_id")]
        [PrimaryKey]
        [NotNull]
        public override int Id { get; set; }

        [Column("parent_location")]
        public int Parent_location { get; set; }

        [Column("adress_fk")]
        public int Adress_fk { get; set; }

        [Column("designation")]
        public string designation { get; set; }

        [Column("building")]
        public int building { get; set; }

        [Column("room")]
        public int room { get; set; }
    }
}