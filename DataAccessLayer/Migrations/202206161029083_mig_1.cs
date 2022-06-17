namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Messages", "FilePath");
            DropColumn("dbo.Messages", "FileName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "FileName", c => c.String(maxLength: 100));
            AddColumn("dbo.Messages", "FilePath", c => c.String(maxLength: 250));
        }
    }
}
