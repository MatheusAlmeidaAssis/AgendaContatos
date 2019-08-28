using AgendaContatos.Dominio.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AgendaContatos.Dominio.DbContexts
{
    public class AgendaContatosDbContext : DbContext
    {             
        public DbSet<Campo> Campos { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Tabela> Tabelas { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public AgendaContatosDbContext() : base("AgendaContatos")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            var tblCampo = modelBuilder.Entity<Campo>();
            tblCampo.Property(x => x.Nome).IsRequired().HasColumnType("varchar").HasMaxLength(50);
            tblCampo.HasRequired(x => x.Tabela);
            var tblContato = modelBuilder.Entity<Contato>();
            tblContato.Property(x => x.Nome).IsRequired().HasColumnType("varchar").HasMaxLength(75);
            tblContato.Property(x => x.FoneticaSobrenome).IsOptional().HasColumnType("varchar").HasMaxLength(75);
            tblContato.Property(x => x.PronunciaNomeMeio).IsOptional().HasColumnType("varchar").HasMaxLength(75);
            tblContato.Property(x => x.PronunciaNome).IsOptional().HasColumnType("varchar").HasMaxLength(75);
            tblContato.Property(x => x.Empresa).IsOptional().HasColumnType("varchar").HasMaxLength(50);
            tblContato.Property(x => x.Cargo).IsOptional().HasColumnType("varchar").HasMaxLength(50);
            tblContato.Property(x => x.Observacao).IsOptional().HasColumnType("varchar").IsMaxLength();
            tblContato.Property(x => x.Apelido).IsOptional().HasColumnType("varchar").HasMaxLength(50);
            tblContato.Property(x => x.Website).IsOptional().HasColumnType("varchar").HasMaxLength(50);
            tblContato.Property(x => x.ChamadaInternet).IsOptional().HasColumnType("varchar").HasMaxLength(50);
            var tblEmail = modelBuilder.Entity<Email>();
            tblEmail.Property(x => x.Endereco).IsRequired().HasColumnType("varchar").HasMaxLength(50);
            tblEmail.HasRequired(x => x.Tipo);
            var tblEndereco = modelBuilder.Entity<Endereco>();
            tblEndereco.Property(x => x.Logradouro).IsRequired().HasColumnType("varchar").IsMaxLength();            
            tblEndereco.Property(x => x.Numero).IsRequired().HasColumnType("varchar").HasMaxLength(4);
            tblEndereco.Property(x => x.Complemento).IsOptional().HasColumnType("varchar").HasMaxLength(10);
            tblEndereco.Property(x => x.Bairro).IsRequired().HasColumnType("varchar").HasMaxLength(20);
            tblEndereco.Property(x => x.Cidade).IsRequired().HasColumnType("varchar").HasMaxLength(20);
            tblEndereco.Property(x => x.UF).IsRequired().HasColumnType("varchar").HasMaxLength(2);
            tblEndereco.HasRequired(x => x.Tipo);
            var tblEvento = modelBuilder.Entity<Evento>();
            tblEvento.Property(x => x.Data).IsRequired().HasColumnType("date");
            tblEvento.HasRequired(x => x.Tipo);
            var tblGrupo = modelBuilder.Entity<Grupo>();
            tblGrupo.Property(x => x.Nome).IsRequired().HasColumnType("varchar").HasMaxLength(50);
            var tblTabela = modelBuilder.Entity<Tabela>();
            tblTabela.Property(x => x.Nome).IsRequired().HasColumnType("varchar").HasMaxLength(20);
            var tblTelefone = modelBuilder.Entity<Telefone>();
            tblTelefone.Property(x => x.Numero).IsRequired().HasColumnType("varchar").HasMaxLength(11);
            tblTelefone.HasRequired(x => x.Tipo);
            var tblTipo = modelBuilder.Entity<Tipo>();
            tblTipo.Property(x => x.Descricao).IsRequired().HasColumnType("varchar").HasMaxLength(20);
            tblTipo.HasRequired(x => x.Campo);
        }
    }
}
