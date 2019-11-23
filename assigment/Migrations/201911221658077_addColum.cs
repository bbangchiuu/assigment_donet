namespace assigment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "image", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "image");
        }
    }
}
