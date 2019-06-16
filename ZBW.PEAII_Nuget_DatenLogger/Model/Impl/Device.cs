namespace ZBW.PEAII_Nuget_DatenLogger.Model.Impl
{
    public class Device : IDevice
    {
        public int Id { get; set; }
        public int Fk_LocationId { get; set; }
        public string Categorie { get; set; }
        public string Hostname { get; set; }
        public string Ip_Adress { get; set; }
    }
}