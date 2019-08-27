namespace AgendaContatos.Dominio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contatosTipoFkRemovida : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tipo", "Contato_Id", "dbo.Contato");
            DropIndex("dbo.Tipo", new[] { "Contato_Id" });
            CreateTable(
                "dbo.TipoContato",
                c => new
                    {
                        Tipo_Id = c.Int(nullable: false),
                        Contato_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tipo_Id, t.Contato_Id })
                .ForeignKey("dbo.Tipo", t => t.Tipo_Id, cascadeDelete: true)
                .ForeignKey("dbo.Contato", t => t.Contato_Id, cascadeDelete: true)
                .Index(t => t.Tipo_Id)
                .Index(t => t.Contato_Id);
            
            DropColumn("dbo.Tipo", "Contato_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tipo", "Contato_Id", c => c.Int());
            DropForeignKey("dbo.TipoContato", "Contato_Id", "dbo.Contato");
            DropForeignKey("dbo.TipoContato", "Tipo_Id", "dbo.Tipo");
            DropIndex("dbo.TipoContato", new[] { "Contato_Id" });
            DropIndex("dbo.TipoContato", new[] { "Tipo_Id" });
            DropTable("dbo.TipoContato");
            CreateIndex("dbo.Tipo", "Contato_Id");
            AddForeignKey("dbo.Tipo", "Contato_Id", "dbo.Contato", "Id");
        }
    }
}
