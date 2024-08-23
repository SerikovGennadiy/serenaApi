namespace Entities.Exceptions
{
    public class IATAPortIncorrectFormatException : BadRequestException
    {
        public IATAPortIncorrectFormatException(string airPortIATACode)
            :base($"Некорректный код IATA аэропорта. Формат: три заглавные латинские буквы н, JKF")
        {  }
    }
}
