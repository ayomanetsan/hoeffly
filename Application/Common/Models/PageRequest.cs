namespace Application.Common.Models;

public abstract record PageRequest<TResponse>(int PageNumber = 1, int PageSize = 10) : IRequest<TResponse>;