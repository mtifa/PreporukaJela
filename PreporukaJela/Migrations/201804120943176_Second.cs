namespace PreporukaJela.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Jeloes", newName: "Jelo");
            RenameTable(name: "dbo.Restorans", newName: "Restoran");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Restoran", newName: "Restorans");
            RenameTable(name: "dbo.Jelo", newName: "Jeloes");
        }
    }
}
