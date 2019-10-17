namespace Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usersIDChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LongTermReservations", "Issuer_ID", "dbo.Users");
            DropForeignKey("dbo.ShortTermReservations", "Issuer_ID", "dbo.Users");
            DropIndex("dbo.LongTermReservations", new[] { "Issuer_ID" });
            DropIndex("dbo.ShortTermReservations", new[] { "Issuer_ID" });
            RenameColumn(table: "dbo.LongTermReservations", name: "Issuer_ID", newName: "Issuer_UserID");
            RenameColumn(table: "dbo.ShortTermReservations", name: "Issuer_ID", newName: "Issuer_UserID");
            DropPrimaryKey("dbo.Users");
            AddColumn("dbo.Users", "UserID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.LongTermReservations", "Issuer_UserID", c => c.String(maxLength: 128));
            AlterColumn("dbo.ShortTermReservations", "Issuer_UserID", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Users", "UserID");
            CreateIndex("dbo.LongTermReservations", "Issuer_UserID");
            CreateIndex("dbo.ShortTermReservations", "Issuer_UserID");
            AddForeignKey("dbo.LongTermReservations", "Issuer_UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.ShortTermReservations", "Issuer_UserID", "dbo.Users", "UserID");
            DropColumn("dbo.Users", "ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "ID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.ShortTermReservations", "Issuer_UserID", "dbo.Users");
            DropForeignKey("dbo.LongTermReservations", "Issuer_UserID", "dbo.Users");
            DropIndex("dbo.ShortTermReservations", new[] { "Issuer_UserID" });
            DropIndex("dbo.LongTermReservations", new[] { "Issuer_UserID" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.ShortTermReservations", "Issuer_UserID", c => c.Int());
            AlterColumn("dbo.LongTermReservations", "Issuer_UserID", c => c.Int());
            DropColumn("dbo.Users", "UserID");
            AddPrimaryKey("dbo.Users", "ID");
            RenameColumn(table: "dbo.ShortTermReservations", name: "Issuer_UserID", newName: "Issuer_ID");
            RenameColumn(table: "dbo.LongTermReservations", name: "Issuer_UserID", newName: "Issuer_ID");
            CreateIndex("dbo.ShortTermReservations", "Issuer_ID");
            CreateIndex("dbo.LongTermReservations", "Issuer_ID");
            AddForeignKey("dbo.ShortTermReservations", "Issuer_ID", "dbo.Users", "ID");
            AddForeignKey("dbo.LongTermReservations", "Issuer_ID", "dbo.Users", "ID");
        }
    }
}
