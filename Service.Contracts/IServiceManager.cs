namespace Service.Contracts
{
    public interface IServiceManager
    {
        IIATAService iataService { get; }
        IRangeService rangeService { get; }
    }
}
