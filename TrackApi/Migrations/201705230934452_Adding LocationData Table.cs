namespace TrackApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingLocationDataTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LocationDatas",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        DeviceId = c.String(),
                        LoggedTime = c.DateTime(nullable: false),
                        LatLong = c.String(),
                        AdditionalData = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LocationDatas");
        }
    }
}
