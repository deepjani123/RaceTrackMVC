namespace RaceTrackMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddtoDB : DbMigration
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
                "dbo.VehicleTracks",
                c => new
                    {
                        TrackId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TrackId, t.VehicleId })
                .ForeignKey("dbo.Tracks", t => t.TrackId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.TrackId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        Lift = c.Int(nullable: false),
                        TireWear = c.Int(nullable: false),
                        HasTowStrap = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleTracks", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.VehicleTracks", "TrackId", "dbo.Tracks");
            DropIndex("dbo.VehicleTracks", new[] { "VehicleId" });
            DropIndex("dbo.VehicleTracks", new[] { "TrackId" });
            DropTable("dbo.Vehicles");
            DropTable("dbo.VehicleTracks");
            DropTable("dbo.Tracks");
        }
    }
}
