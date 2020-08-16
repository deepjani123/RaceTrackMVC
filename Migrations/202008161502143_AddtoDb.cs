namespace RaceTrackMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddtoDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleTracks",
                c => new
                    {
                        Vehicle_Id = c.Int(nullable: false),
                        Track_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Vehicle_Id, t.Track_Id })
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tracks", t => t.Track_Id, cascadeDelete: true)
                .Index(t => t.Vehicle_Id)
                .Index(t => t.Track_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleTracks", "Track_Id", "dbo.Tracks");
            DropForeignKey("dbo.VehicleTracks", "Vehicle_Id", "dbo.Vehicles");
            DropIndex("dbo.VehicleTracks", new[] { "Track_Id" });
            DropIndex("dbo.VehicleTracks", new[] { "Vehicle_Id" });
            DropTable("dbo.VehicleTracks");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Tracks");
        }
    }
}
