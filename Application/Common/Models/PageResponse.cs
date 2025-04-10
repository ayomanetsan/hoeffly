namespace Application.Common.Models;

public record PageResponse<T>(IEnumerable<T> Collection, int PageNumber, int PageSize, int TotalPages)
    where T : class;
