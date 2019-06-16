namespace ZBW.PEAII_Nuget_DatenLogger.Model
{
    public interface ILogging
    {
        int Id { get; set; }
        int Fk_Adress { get; set; }
        int Room { get; set; }
        string Name { get; set; }
        string Designation { get; set; }
        string Building { get; set; }
        int ParentId { get; set; }
    }
}