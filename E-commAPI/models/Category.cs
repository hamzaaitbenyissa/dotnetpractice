using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace E_commAPI.models;

[Table("CATEGORIES")]
public class Category
{
    [Key] public int CategoryID { get; set; }
    [Required] [StringLength(35)] public string NameCategory { get; set; }

    // lazy loading using virtual keyword 
    [JsonIgnore]
    public virtual ICollection<Product> Products { get; set; }
}