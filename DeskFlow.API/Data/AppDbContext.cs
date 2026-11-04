using System.Data;
using DeskFlow.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeskFlow.API.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Categoria>(c =>
            {
                c.HasKey(c => c.Id);
                c.Property(c => c.Nome).IsRequired().HasMaxLength(100);

                c.HasMany(c => c.Chamados)
                 .WithOne(ch => ch.Categoria)
                 .HasForeignKey(ch => ch.CategoriaId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Chamado>(ch =>
            {
                ch.HasKey(ch => ch.Id);
                ch.Property(ch => ch.Titulo).IsRequired().HasMaxLength(100);
                ch.Property(ch => ch.Descricao).IsRequired().HasMaxLength(1000);
                ch.Property(ch => ch.Prioridade).IsRequired();
                ch.Property(ch => ch.Status).IsRequired();
                ch.Property(ch => ch.SolicitanteNome).IsRequired().HasMaxLength(100);
                ch.Property(ch => ch.DataAbertura).IsRequired();
                ch.Property(ch => ch.DataFechamento);
                ch.Property(ch => ch.Solucao).HasMaxLength(500);

                ch.HasMany(ch => ch.Interacoes)
                 .WithOne(i => i.Chamado)
                 .HasForeignKey(i => i.ChamadoId);
            });

            modelBuilder.Entity<Interacao>(i =>
            {
                i.HasKey(i => i.Id);
                i.Property(i => i.Autor).IsRequired().HasMaxLength(100);
                i.Property(i => i.Mensagem).IsRequired().HasMaxLength(1000);
                i.Property(i => i.DataRegistro).IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Categoria> Categorias => Set<Categoria>();
        public DbSet<Chamado> Chamados => Set<Chamado>();

        public DbSet<Interacao> Interacoes => Set<Interacao>();

    }

}