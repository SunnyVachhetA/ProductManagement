namespace ProductManagement.Service.Common.Exceptions;
public class ModelValidationException : Exception
{
    public object? Errors { get; set; }

    public ModelValidationException() : base("One or more validation failures have been occured.")
    { }

    public ModelValidationException(params string[] errorList) : this()
    {
        Errors = errorList.ToList();
    }

    public ModelValidationException(object errors) : this()
    {
        Errors = errors;
    }
}