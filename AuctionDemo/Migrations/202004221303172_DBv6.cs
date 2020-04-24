namespace AuctionDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBv6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Description", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Description", c => c.String(maxLength: 200));
        }
    }
}
