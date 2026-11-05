using System.ComponentModel.DataAnnotations;
using DeskFlow.API.Models.Enums;

namespace DeskFlow.API.Models.Dtos;

public class ChamadoCriarDto
{
    [Required(ErrorMessage = "O título é obrigatório.")]
    [StringLength(200, ErrorMessage = "O título deve ter no máximo 200 caracteres.")]
    public string Titulo { get; set; } = string.Empty;

    [Required(ErrorMessage = "A descrição é obrigatória.")]
    [StringLength(1000, ErrorMessage = "A descrição deve ter no máximo 1000 caracteres.")]
    public string Descricao { get; set; } = string.Empty;
    public string Prioridade { get; set; } = PrioridadeChamado.Baixa.ToString();

    [Required(ErrorMessage = "O nome do solicitante é obrigatório.")]
    [StringLength(150, ErrorMessage = "O nome do solicitante deve ter no máximo 150 caracteres.")]
    public string SolicitanteNome { get; set; } = string.Empty;

    [Required(ErrorMessage = "A categoria é obrigatória.")]
    public string CategoriaId { get; set; } = string.Empty;
}

