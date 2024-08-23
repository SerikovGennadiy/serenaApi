namespace Entities.Exceptions
{
    public class IATAPortNotFoundException : NotFoundException
    {
        public IATAPortNotFoundException(string airPortIATACode) :
            base($"Аэропорта с указанным кодом IATA: ({airPortIATACode}) не существует")
        { }
    }
}
