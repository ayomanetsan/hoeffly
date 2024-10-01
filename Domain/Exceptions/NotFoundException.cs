namespace Domain.Exceptions;

public class NotFoundException(string message) : ExceptionBase(message, HttpStatusCode.NotFound);
