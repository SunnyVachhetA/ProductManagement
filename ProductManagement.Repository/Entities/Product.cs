using ProductManagement.Repository.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagement.Repository.Entities;

[Table("tblProduct")]
public class Product : BaseEntity<int>
{
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("price")]
    public decimal Price { get; set; }

    [Column("stock")]
    public int Stock { get; set; }
}
