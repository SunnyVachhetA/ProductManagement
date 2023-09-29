using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Repository.Common;

public abstract class BaseEntity<T>
{
    [Key]
    public T Id { get; set; }
}