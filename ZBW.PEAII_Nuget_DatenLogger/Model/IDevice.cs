namespace ZBW.PEAII_Nuget_DatenLogger.Model
{
    public interface IDevice
    {
        int Id { get; set; }
        int Fk_LocationId { get; set; }
        string Categorie { get; set; }
        string Hostname { get; set; }
        string Ip_Adress { get; set; }
    }
}