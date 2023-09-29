namespace ProductManagement.Repository.QueryExtension;
public static class ApplyFilterPageQuery
{
    public static IQueryable<T> ApplyQuery<T>(this IQueryable<T> query,
        int pageNumber, int pageSize)
    {
        int skip = (pageNumber - 1) * pageSize;

        return
            query
            .Skip(skip)
            .Take(pageSize);
    }
}