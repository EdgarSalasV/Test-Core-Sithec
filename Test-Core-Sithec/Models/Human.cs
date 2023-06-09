using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Core_Sithec.Models;

public partial class Human
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
	[MaxLength(40)]
    public string Name { get; set; } = null!;

    public bool? Gender { get; set; }

    [Column(TypeName = "tinyint")]
    public byte Age { get; set; }

    [Precision(3, 2)]
    public decimal Height { get; set; }

    [Precision(5, 2)]
    public decimal Weight { get; set; }

    public static implicit operator List<object>(Human? v)
    {
        throw new NotImplementedException();
    }
}
