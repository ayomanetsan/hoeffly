namespace Domain.Exceptions;

public class ConflictException(string message) : ExceptionBase(message, HttpStatusCode.Conflict);