namespace TrackApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedDatabasegeneratedoptiononIdcolumn : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.LocationDatas");
            AlterColumn("dbo.LocationDatas", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.LocationDatas", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.LocationDatas");
            AlterColumn("dbo.LocationDatas", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.LocationDatas", "Id");
        }
    }
}
