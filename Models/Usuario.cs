using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalogo.Models;

[Table("Usuario")]
public class Usuario
{
    [Key]
    public int UsuarioId { get; set; }

    [Required]
    [StringLength(80)]
    public string? Nome { get; set; }

    [Required]
    [StringLength(80)]
    public string? Email { get; set; }

    [Required]
    [StringLength(20)]
    public string? Senha { get; set; }
}