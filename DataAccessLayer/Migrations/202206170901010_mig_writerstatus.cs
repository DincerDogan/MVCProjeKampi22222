namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_writerstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "RememberMe", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "RememberMe");
        }
    }
}
