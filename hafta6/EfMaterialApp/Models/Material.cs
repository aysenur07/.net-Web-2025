using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfMaterialApp.Models;

public class Material
{
    public int Id { get; set; }

    [Required, StringLength(50)]
    public string Name { get; set; }

    [Range(1, 10000)]
    public int Quantity { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    [Range(0.01, 999999.99)]
    public decimal UnitPrice { get; set; }

    [Required, StringLength(50)]
    public string Supplier { get; set; }

    [DataType(DataType.Date)]
    public DateTime? PurchaseDate { get; set; }
}
