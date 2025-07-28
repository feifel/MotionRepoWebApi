namespace MotionRepoServer.Models;

public class PagedResponse<T>
{
    public IEnumerable<T> Data { get; set; } = new List<T>();
    public int Total { get; set; }
    public int Offset { get; set; }
    public int Limit { get; set; }
    public bool HasNext { get; set; }
    public bool HasPrevious { get; set; }

    public PagedResponse(IEnumerable<T> data, int total, int offset, int limit)
    {
        Data = data;
        Total = total;
        Offset = offset;
        Limit = limit;
        HasNext = offset + limit < total;
        HasPrevious = offset > 0;
    }
}