namespace AgendaContatos.Dominio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TipoLogradouroRemovido : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Campo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Tabela_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tabela", t => t.Tabela_Id, cascadeDelete: true)
                .Index(t => t.Tabela_Id);
            
            CreateTable(
                "dbo.Tabela",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contato",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 75, unicode: false),
                        FoneticaSobrenome = c.String(maxLength: 75, unicode: false),
                        PronunciaNomeMeio = c.String(maxLength: 75, unicode: false),
                        PronunciaNome = c.String(maxLength: 75, unicode: false),
                        Foto = c.Binary(),
                        Empresa = c.String(maxLength: 50, unicode: false),
                        Cargo = c.String(maxLength: 50, unicode: false),
                        Observacao = c.String(maxLength: 8000, unicode: false),
                        Apelido = c.String(maxLength: 50, unicode: false),
                        Website = c.String(maxLength: 50, unicode: false),
                        ChamadaInternet = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Email",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Endereco = c.String(nullable: false, maxLength: 50, unicode: false),
                        Tipo_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tipo", t => t.Tipo_Id, cascadeDelete: true)
                .Index(t => t.Tipo_Id);
            
            CreateTable(
                "dbo.Tipo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 20, unicode: false),
                        Campo_Id = c.Int(nullable: false),
                        Contato_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campo", t => t.Campo_Id, cascadeDelete: true)
                .ForeignKey("dbo.Contato", t => t.Contato_Id)
                .Index(t => t.Campo_Id)
                .Index(t => t.Contato_Id);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Logradouro = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Numero = c.String(nullable: false, maxLength: 4, unicode: false),
                        Complemento = c.String(maxLength: 10, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 20, unicode: false),
                        Cidade = c.String(nullable: false, maxLength: 20, unicode: false),
                        UF = c.String(nullable: false, maxLength: 2, unicode: false),
                        Tipo_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tipo", t => t.Tipo_Id, cascadeDelete: true)
                .Index(t => t.Tipo_Id);
            
            CreateTable(
                "dbo.Evento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, storeType: "date"),
                        Tipo_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tipo", t => t.Tipo_Id, cascadeDelete: true)
                .Index(t => t.Tipo_Id);
            
            CreateTable(
                "dbo.Grupo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Telefone",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.String(nullable: false, maxLength: 11, unicode: false),
                        Tipo_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tipo", t => t.Tipo_Id, cascadeDelete: true)
                .Index(t => t.Tipo_Id);
            
            CreateTable(
                "dbo.ContatoContato",
                c => new
                    {
                        Contato_Id = c.Int(nullable: false),
                        Contato_Id1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Contato_Id, t.Contato_Id1 })
                .ForeignKey("dbo.Contato", t => t.Contato_Id)
                .ForeignKey("dbo.Contato", t => t.Contato_Id1)
                .Index(t => t.Contato_Id)
                .Index(t => t.Contato_Id1);
            
            CreateTable(
                "dbo.EmailContato",
                c => new
                    {
                        Email_Id = c.Int(nullable: false),
                        Contato_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Email_Id, t.Contato_Id })
                .ForeignKey("dbo.Email", t => t.Email_Id, cascadeDelete: true)
                .ForeignKey("dbo.Contato", t => t.Contato_Id, cascadeDelete: true)
                .Index(t => t.Email_Id)
                .Index(t => t.Contato_Id);
            
            CreateTable(
                "dbo.EnderecoContato",
                c => new
                    {
                        Endereco_Id = c.Int(nullable: false),
                        Contato_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Endereco_Id, t.Contato_Id })
                .ForeignKey("dbo.Endereco", t => t.Endereco_Id, cascadeDelete: true)
                .ForeignKey("dbo.Contato", t => t.Contato_Id, cascadeDelete: true)
                .Index(t => t.Endereco_Id)
                .Index(t => t.Contato_Id);
            
            CreateTable(
                "dbo.EventoContato",
                c => new
                    {
                        Evento_Id = c.Int(nullable: false),
                        Contato_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Evento_Id, t.Contato_Id })
                .ForeignKey("dbo.Evento", t => t.Evento_Id, cascadeDelete: true)
                .ForeignKey("dbo.Contato", t => t.Contato_Id, cascadeDelete: true)
                .Index(t => t.Evento_Id)
                .Index(t => t.Contato_Id);
            
            CreateTable(
                "dbo.GrupoContato",
                c => new
                    {
                        Grupo_Id = c.Int(nullable: false),
                        Contato_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Grupo_Id, t.Contato_Id })
                .ForeignKey("dbo.Grupo", t => t.Grupo_Id, cascadeDelete: true)
                .ForeignKey("dbo.Contato", t => t.Contato_Id, cascadeDelete: true)
                .Index(t => t.Grupo_Id)
                .Index(t => t.Contato_Id);
            
            CreateTable(
                "dbo.TelefoneContato",
                c => new
                    {
                        Telefone_Id = c.Int(nullable: false),
                        Contato_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Telefone_Id, t.Contato_Id })
                .ForeignKey("dbo.Telefone", t => t.Telefone_Id, cascadeDelete: true)
                .ForeignKey("dbo.Contato", t => t.Contato_Id, cascadeDelete: true)
                .Index(t => t.Telefone_Id)
                .Index(t => t.Contato_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tipo", "Contato_Id", "dbo.Contato");
            DropForeignKey("dbo.Telefone", "Tipo_Id", "dbo.Tipo");
            DropForeignKey("dbo.TelefoneContato", "Contato_Id", "dbo.Contato");
            DropForeignKey("dbo.TelefoneContato", "Telefone_Id", "dbo.Telefone");
            DropForeignKey("dbo.GrupoContato", "Contato_Id", "dbo.Contato");
            DropForeignKey("dbo.GrupoContato", "Grupo_Id", "dbo.Grupo");
            DropForeignKey("dbo.Evento", "Tipo_Id", "dbo.Tipo");
            DropForeignKey("dbo.EventoContato", "Contato_Id", "dbo.Contato");
            DropForeignKey("dbo.EventoContato", "Evento_Id", "dbo.Evento");
            DropForeignKey("dbo.Endereco", "Tipo_Id", "dbo.Tipo");
            DropForeignKey("dbo.EnderecoContato", "Contato_Id", "dbo.Contato");
            DropForeignKey("dbo.EnderecoContato", "Endereco_Id", "dbo.Endereco");
            DropForeignKey("dbo.Email", "Tipo_Id", "dbo.Tipo");
            DropForeignKey("dbo.Tipo", "Campo_Id", "dbo.Campo");
            DropForeignKey("dbo.EmailContato", "Contato_Id", "dbo.Contato");
            DropForeignKey("dbo.EmailContato", "Email_Id", "dbo.Email");
            DropForeignKey("dbo.ContatoContato", "Contato_Id1", "dbo.Contato");
            DropForeignKey("dbo.ContatoContato", "Contato_Id", "dbo.Contato");
            DropForeignKey("dbo.Campo", "Tabela_Id", "dbo.Tabela");
            DropIndex("dbo.TelefoneContato", new[] { "Contato_Id" });
            DropIndex("dbo.TelefoneContato", new[] { "Telefone_Id" });
            DropIndex("dbo.GrupoContato", new[] { "Contato_Id" });
            DropIndex("dbo.GrupoContato", new[] { "Grupo_Id" });
            DropIndex("dbo.EventoContato", new[] { "Contato_Id" });
            DropIndex("dbo.EventoContato", new[] { "Evento_Id" });
            DropIndex("dbo.EnderecoContato", new[] { "Contato_Id" });
            DropIndex("dbo.EnderecoContato", new[] { "Endereco_Id" });
            DropIndex("dbo.EmailContato", new[] { "Contato_Id" });
            DropIndex("dbo.EmailContato", new[] { "Email_Id" });
            DropIndex("dbo.ContatoContato", new[] { "Contato_Id1" });
            DropIndex("dbo.ContatoContato", new[] { "Contato_Id" });
            DropIndex("dbo.Telefone", new[] { "Tipo_Id" });
            DropIndex("dbo.Evento", new[] { "Tipo_Id" });
            DropIndex("dbo.Endereco", new[] { "Tipo_Id" });
            DropIndex("dbo.Tipo", new[] { "Contato_Id" });
            DropIndex("dbo.Tipo", new[] { "Campo_Id" });
            DropIndex("dbo.Email", new[] { "Tipo_Id" });
            DropIndex("dbo.Campo", new[] { "Tabela_Id" });
            DropTable("dbo.TelefoneContato");
            DropTable("dbo.GrupoContato");
            DropTable("dbo.EventoContato");
            DropTable("dbo.EnderecoContato");
            DropTable("dbo.EmailContato");
            DropTable("dbo.ContatoContato");
            DropTable("dbo.Telefone");
            DropTable("dbo.Grupo");
            DropTable("dbo.Evento");
            DropTable("dbo.Endereco");
            DropTable("dbo.Tipo");
            DropTable("dbo.Email");
            DropTable("dbo.Contato");
            DropTable("dbo.Tabela");
            DropTable("dbo.Campo");
        }
    }
}
