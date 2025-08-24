namespace Genesis.Shared.DTOs.Common;

public sealed class PagedResult<T>
{
    public IReadOnlyList<T> Items { get; init; }
    public int Total { get; init; }
    public int Page { get; init; }
    public int PageSize { get; init; }

    public int PageCount => Math.Max(1, (int)Math.Ceiling(Total / (double)PageSize));
    public bool HasPrev => Page > 1;
    public bool HasNext => Page < PageCount;
}