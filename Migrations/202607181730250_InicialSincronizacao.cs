namespace HubSpace.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InicialSincronizacao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        SenhaHash = c.String(nullable: false, maxLength: 255),
                        Status = c.String(nullable: false, maxLength: 20),
                        DataCriacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
        }
    }
}
