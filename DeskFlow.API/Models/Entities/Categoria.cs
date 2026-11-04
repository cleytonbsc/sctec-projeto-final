namespace DeskFlow.API.Models.Entities
{
    public class Categoria
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Nome { get; set; } = string.Empty;
        public virtual ICollection<Chamado> Chamados { get; set; } = new List<Chamado>();

        public void Update (Categoria categoria)
        {
            Nome = categoria.Nome;
        }
    }
}