namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCommentsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        UserId = c.Guid(nullable: false),
                        PostId = c.String(maxLength: 128),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        ReplyComment_CommentId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Post", t => t.PostId)
                .ForeignKey("dbo.Comment", t => t.ReplyComment_CommentId)
                .Index(t => t.PostId)
                .Index(t => t.ReplyComment_CommentId);
            
            AlterColumn("dbo.Post", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "ReplyComment_CommentId", "dbo.Comment");
            DropForeignKey("dbo.Comment", "PostId", "dbo.Post");
            DropIndex("dbo.Comment", new[] { "ReplyComment_CommentId" });
            DropIndex("dbo.Comment", new[] { "PostId" });
            AlterColumn("dbo.Post", "Title", c => c.String());
            DropTable("dbo.Comment");
        }
    }
}
