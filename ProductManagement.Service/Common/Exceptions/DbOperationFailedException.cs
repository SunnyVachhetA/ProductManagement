namespace ProductManagement.Service.Common.Exceptions;
public class DbOperationFailedException : Exception
{
    public DbOperationFailedException()
        : base("Something went wrong during database operation.")
    { }
}