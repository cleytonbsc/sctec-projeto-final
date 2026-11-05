using System.ComponentModel.DataAnnotations;

namespace DeskFlow.API.Models.Dtos;

public class InteracaoCriarDto
{
    [Required(ErrorMessage = "O autor é obrigatório.")]
    [StringLength(100, ErrorMessage = "O autor deve ter no máximo 100 caracteres.")]
    public string Autor { get; set; } = string.Empty;

    [Required(ErrorMessage = "A mensagem é obrigatória.")]
    [StringLength(1000, ErrorMessage = "A mensagem deve ter no máximo 1000 caracteres.")]
    public string Mensagem { get; set; } = string.Empty;

}

