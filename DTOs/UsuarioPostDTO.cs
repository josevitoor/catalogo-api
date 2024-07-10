using System.ComponentModel.DataAnnotations;

namespace APICatalogo.DTOs;

public class UsuarioPostDTO
{
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
