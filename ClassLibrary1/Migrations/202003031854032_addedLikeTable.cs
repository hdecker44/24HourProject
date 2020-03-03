namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedLikeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Like",
                c => new
                    {
                        LikeId = c.Int(nullable: false, identity: true),
                        PostId = c.String(maxLength: 128),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.LikeId)
                .ForeignKey("dbo.Post", t => t.PostId)
                .Index(t => t.PostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Like", "PostId", "dbo.Post");
            DropIndex("dbo.Like", new[] { "PostId" });
            DropTable("dbo.Like");
        }
    }
}
