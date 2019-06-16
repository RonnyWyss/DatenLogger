namespace ZBW.PEAII_Nuget_DatenLogger.Model.Impl
{
    public class Logging : ILogging
    {
        public int Id { get; set; }
        public int Fk_Adress { get; set; }
        public int Room { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Building { get; set; }
        public int ParentId { get; set; }
    }
}