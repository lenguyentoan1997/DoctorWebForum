namespace DoctorsWebForum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Content = c.String(),
                        DateTime = c.String(),
                        DoctorId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .ForeignKey("dbo.Posts", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        DOB = c.String(),
                        Gender = c.String(),
                        Workplace = c.String(),
                        Qualification = c.String(),
                        Achievement = c.String(),
                        Confirm = c.String(),
                        ExpertiseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.Expertises", t => t.ExpertiseId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.ExpertiseId);
            
            CreateTable(
                "dbo.CommentChilds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        DateTime = c.String(),
                        AccountId = c.String(maxLength: 128),
                        CommentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AccountId)
                .ForeignKey("dbo.Comments", t => t.CommentId, cascadeDelete: true)
                .Index(t => t.AccountId)
                .Index(t => t.CommentId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        DateTime = c.String(),
                        AccountId = c.String(maxLength: 128),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AccountId)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.AccountId)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        DateTime = c.String(),
                        Status = c.String(),
                        ExpertiseId = c.Int(nullable: false),
                        AccountId = c.String(maxLength: 128),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AccountId)
                .ForeignKey("dbo.Expertises", t => t.ExpertiseId, cascadeDelete: true)
                .ForeignKey("dbo.Types", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.ExpertiseId)
                .Index(t => t.AccountId)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.Emoticons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        PostId = c.Int(nullable: false),
                        AccountId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AccountId)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Expertises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AccountId = c.String(maxLength: 128),
                        PostId = c.Int(nullable: false),
                        AnswerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Answers", t => t.AnswerId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.AccountId)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.AccountId)
                .Index(t => t.PostId)
                .Index(t => t.AnswerId);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        DateTime = c.String(),
                        Status = c.String(),
                        AccountId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AccountId)
                .Index(t => t.AccountId);
            
            DropColumn("dbo.Clients", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "Image", c => c.String());
            DropForeignKey("dbo.Answers", "Id", "dbo.Posts");
            DropForeignKey("dbo.Answers", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "ExpertiseId", "dbo.Expertises");
            DropForeignKey("dbo.Doctors", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notifications", "AccountId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CommentChilds", "CommentId", "dbo.Comments");
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "TypeId", "dbo.Types");
            DropForeignKey("dbo.Images", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Images", "AccountId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Images", "AnswerId", "dbo.Answers");
            DropForeignKey("dbo.Posts", "ExpertiseId", "dbo.Expertises");
            DropForeignKey("dbo.Emoticons", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Emoticons", "AccountId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "AccountId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "AccountId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CommentChilds", "AccountId", "dbo.AspNetUsers");
            DropIndex("dbo.Notifications", new[] { "AccountId" });
            DropIndex("dbo.Images", new[] { "AnswerId" });
            DropIndex("dbo.Images", new[] { "PostId" });
            DropIndex("dbo.Images", new[] { "AccountId" });
            DropIndex("dbo.Emoticons", new[] { "AccountId" });
            DropIndex("dbo.Emoticons", new[] { "PostId" });
            DropIndex("dbo.Posts", new[] { "TypeId" });
            DropIndex("dbo.Posts", new[] { "AccountId" });
            DropIndex("dbo.Posts", new[] { "ExpertiseId" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropIndex("dbo.Comments", new[] { "AccountId" });
            DropIndex("dbo.CommentChilds", new[] { "CommentId" });
            DropIndex("dbo.CommentChilds", new[] { "AccountId" });
            DropIndex("dbo.Doctors", new[] { "ExpertiseId" });
            DropIndex("dbo.Doctors", new[] { "Id" });
            DropIndex("dbo.Answers", new[] { "DoctorId" });
            DropIndex("dbo.Answers", new[] { "Id" });
            DropTable("dbo.Notifications");
            DropTable("dbo.Types");
            DropTable("dbo.Images");
            DropTable("dbo.Expertises");
            DropTable("dbo.Emoticons");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
            DropTable("dbo.CommentChilds");
            DropTable("dbo.Doctors");
            DropTable("dbo.Answers");
        }
    }
}
