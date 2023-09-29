namespace ProductManagement.Service.Common.Exceptions;
public class ResourceNotFoundException : Exception
{
    public ResourceNotFoundException(string message = "Resource Not Found.") :
        base(message)
    { }
}