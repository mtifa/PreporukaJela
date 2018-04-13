namespace PreporukaJela.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jeloes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false),
                        Cijena = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RestoranId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restorans", t => t.RestoranId, cascadeDelete: true)
                .Index(t => t.RestoranId);
            
            CreateTable(
                "dbo.Restorans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Adresa = c.String(),
                        Telefon = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jeloes", "RestoranId", "dbo.Restorans");
            DropForeignKey("dbo.Restorans", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Restorans", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Jeloes", new[] { "RestoranId" });
            DropTable("dbo.Restorans");
            DropTable("dbo.Jeloes");
        }
    }
}
