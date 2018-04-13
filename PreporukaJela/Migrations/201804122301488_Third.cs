namespace PreporukaJela.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Restoran", "Naziv", c => c.String(nullable: false));
            AlterColumn("dbo.Restoran", "Adresa", c => c.String(nullable: false));
            AlterColumn("dbo.Restoran", "Telefon", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Restoran", "Telefon", c => c.String());
            AlterColumn("dbo.Restoran", "Adresa", c => c.String());
            AlterColumn("dbo.Restoran", "Naziv", c => c.String());
        }
    }
}
