namespace Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LongTermReservations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        Finnish = c.DateTime(nullable: false),
                        Issuer_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.Issuer_ID)
                .Index(t => t.Issuer_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                        Points = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ShortTermReservations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        Finnish = c.DateTime(nullable: false),
                        Issuer_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.Issuer_ID)
                .Index(t => t.Issuer_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShortTermReservations", "Issuer_ID", "dbo.Users");
            DropForeignKey("dbo.LongTermReservations", "Issuer_ID", "dbo.Users");
            DropIndex("dbo.ShortTermReservations", new[] { "Issuer_ID" });
            DropIndex("dbo.LongTermReservations", new[] { "Issuer_ID" });
            DropTable("dbo.ShortTermReservations");
            DropTable("dbo.Users");
            DropTable("dbo.LongTermReservations");
        }
    }
}
