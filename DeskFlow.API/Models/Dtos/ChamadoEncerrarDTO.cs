using System.ComponentModel.DataAnnotations;

namespace DeskFlow.API.Models.Dtos;

public class ChamadoEncerrarDto
{
    [Required(ErrorMessage = "A solução é obrigatória para encerrar o chamado.")]
    [StringLength(2000, ErrorMessage = "A solução deve ter no máximo 2000 caracteres.")]
    public string Solucao { get; set; } = string.Empty;
}
