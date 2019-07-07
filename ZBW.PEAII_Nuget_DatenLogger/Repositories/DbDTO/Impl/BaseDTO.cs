namespace ZBW.PEAII_Nuget_DatenLogger.Repositories.DbDTO.Impl
{
    public abstract class BaseDTO<TId>
    {
        public abstract TId Id { get; set; }
    }
}