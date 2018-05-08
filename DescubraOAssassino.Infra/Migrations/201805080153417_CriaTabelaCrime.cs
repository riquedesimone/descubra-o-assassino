namespace DescubraOAssassino.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriaTabelaCrime : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Crimes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SuspeitoId = c.Int(nullable: false),
                        LocalId = c.Int(nullable: false),
                        ArmaId = c.Int(nullable: false),
                        ExpireDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Armas", t => t.ArmaId)
                .ForeignKey("dbo.Locais", t => t.LocalId)
                .ForeignKey("dbo.Suspeitos", t => t.SuspeitoId)
                .Index(t => t.SuspeitoId)
                .Index(t => t.LocalId)
                .Index(t => t.ArmaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Crimes", "SuspeitoId", "dbo.Suspeitos");
            DropForeignKey("dbo.Crimes", "LocalId", "dbo.Locais");
            DropForeignKey("dbo.Crimes", "ArmaId", "dbo.Armas");
            DropIndex("dbo.Crimes", new[] { "ArmaId" });
            DropIndex("dbo.Crimes", new[] { "LocalId" });
            DropIndex("dbo.Crimes", new[] { "SuspeitoId" });
            DropTable("dbo.Crimes");
        }
    }
}
