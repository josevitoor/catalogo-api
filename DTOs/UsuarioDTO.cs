using System.ComponentModel.DataAnnotations;

namespace APICatalogo.DTOs;

public class UsuarioDTO
{
    public int UsuarioId { get; set; }

    [Required]
    [StringLength(80)]
    public string? Nome { get; set; }

    [Required]
    [StringLength(80)]
    public string? Email { get; set; }

}
