namespace AuctionDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBv3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Offers", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Offers", "UserName");
        }
    }
}
