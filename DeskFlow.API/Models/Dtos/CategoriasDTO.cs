using System.ComponentModel.DataAnnotations;

namespace DeskFlow.API.Models.Dtos;

public class CategoriasDto
{
    [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome da categoria deve ter no máximo 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;

}

