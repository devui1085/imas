namespace IMAS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "core.Advertisment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                        ExpireDate = c.DateTime(),
                        Comment = c.String(),
                        UserId = c.Int(nullable: false),
                        TypeIdentity = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("core.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "core.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 25),
                        LastName = c.String(nullable: false, maxLength: 25),
                        Email = c.String(nullable: false, maxLength: 50),
                        Sexuality = c.Byte(),
                        BirthDate = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "core.Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContentId = c.Int(nullable: false),
                        SenderId = c.Int(nullable: false),
                        Text = c.String(nullable: false, maxLength: 4000),
                        CreateDate = c.DateTime(nullable: false),
                        IsPrivate = c.Boolean(nullable: false),
                        Status = c.Byte(nullable: false),
                        LikeCount = c.Int(nullable: false),
                        DislikeCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("core.Content", t => t.ContentId, cascadeDelete: true)
                .ForeignKey("core.User", t => t.SenderId)
                .Index(t => t.ContentId)
                .Index(t => t.SenderId);
            
            CreateTable(
                "core.Content",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorId = c.Int(nullable: false),
                        PublicationId = c.Int(),
                        Type = c.Byte(nullable: false),
                        Title = c.String(nullable: false, maxLength: 200),
                        Text = c.String(nullable: false),
                        ShortAbstract = c.String(maxLength: 250),
                        CultureLcid = c.Int(nullable: false),
                        State = c.Byte(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        LastModifyDate = c.DateTime(),
                        PublishDate = c.DateTime(),
                        MetaDescription = c.String(),
                        PersianCreateDateYear = c.Short(nullable: false),
                        PersianCreateDateMonth = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("core.Publication", t => t.PublicationId)
                .ForeignKey("core.User", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.PublicationId);
            
            CreateTable(
                "core.FeaturedContent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("core.Content", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "core.Media",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ContentId = c.Int(),
                        FileName = c.String(nullable: false, maxLength: 50),
                        Size = c.Int(nullable: false),
                        CreateDate = c.DateTime(precision: 2, storeType: "datetime2"),
                        Type = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("core.Content", t => t.ContentId)
                .ForeignKey("core.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ContentId);
            
            CreateTable(
                "core.Publication",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Byte(nullable: false),
                        CreatorId = c.Int(nullable: false),
                        Name = c.String(maxLength: 30),
                        Title = c.String(nullable: false, maxLength: 50),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("core.User", t => t.CreatorId, cascadeDelete: true)
                .Index(t => t.CreatorId);
            
            CreateTable(
                "core.BlogLink",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Url = c.String(nullable: false, maxLength: 200),
                        BlogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("core.Blog", t => t.BlogId)
                .Index(t => t.BlogId);
            
            CreateTable(
                "core.Rate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContentId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Value = c.Byte(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("core.Content", t => t.ContentId, cascadeDelete: true)
                .ForeignKey("core.User", t => t.UserId)
                .Index(t => t.ContentId)
                .Index(t => t.UserId);
            
            CreateTable(
                "core.Reference",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContentId = c.Int(nullable: false),
                        CultureLcid = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 200),
                        Url = c.String(maxLength: 2048),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("core.Content", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "core.Tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "core.Visit",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContentId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("core.Content", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "core.EducationalResume",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        OrganizationId = c.Int(nullable: false),
                        UniversityFieldId = c.Int(nullable: false),
                        EducationGrade = c.Byte(nullable: false),
                        StartYear = c.Short(),
                        EndYear = c.Short(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("core.Organization", t => t.OrganizationId, cascadeDelete: true)
                .ForeignKey("core.UniversityField", t => t.UniversityFieldId, cascadeDelete: true)
                .ForeignKey("core.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.OrganizationId)
                .Index(t => t.UniversityFieldId);
            
            CreateTable(
                "core.Organization",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Type = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "core.JobResume",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        JobId = c.Int(),
                        OrganizationId = c.Int(nullable: false),
                        StartYear = c.Short(),
                        EndYear = c.Short(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("core.Job", t => t.JobId)
                .ForeignKey("core.Organization", t => t.OrganizationId, cascadeDelete: true)
                .ForeignKey("core.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.JobId)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "core.Job",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "core.UniversityField",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "core.Follow",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FollowerId = c.Int(nullable: false),
                        FollowedId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 2, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("core.User", t => t.FollowedId)
                .ForeignKey("core.User", t => t.FollowerId, cascadeDelete: true)
                .Index(t => t.FollowerId)
                .Index(t => t.FollowedId);
            
            CreateTable(
                "core.Membership",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Password = c.Binary(nullable: false, maxLength: 32, fixedLength: true),
                        IsApproved = c.Boolean(nullable: false),
                        IsLockedOut = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        LastLoginDate = c.DateTime(),
                        LastPasswordChangedDate = c.DateTime(),
                        LastLockoutDate = c.DateTime(),
                        FailedPasswordAttemptCount = c.Int(nullable: false),
                        VerificationCode = c.Guid(nullable: false),
                        VerificationCodeSendDate = c.DateTime(nullable: false),
                        PasswordResetToken = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("core.User", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "core.Message",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SenderId = c.Int(nullable: false),
                        ReceiverId = c.Int(nullable: false),
                        Text = c.String(),
                        CreateDate = c.DateTime(nullable: false, precision: 2, storeType: "datetime2"),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("core.User", t => t.ReceiverId)
                .ForeignKey("core.User", t => t.SenderId)
                .Index(t => t.SenderId)
                .Index(t => t.ReceiverId);
            
            CreateTable(
                "core.Notification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(nullable: false),
                        Type = c.Byte(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                        SubjectId = c.Int(),
                        ObjectId = c.Int(),
                        ReceiverId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("core.User", t => t.ReceiverId, cascadeDelete: true)
                .ForeignKey("core.User", t => t.SubjectId)
                .Index(t => t.SubjectId)
                .Index(t => t.ReceiverId);
            
            CreateTable(
                "core.Profile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Type = c.Short(nullable: false),
                        Value = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("core.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "core.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Title = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "core.ExceptionLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 50),
                        Message = c.String(nullable: false, maxLength: 4000),
                        InnerMessage = c.String(maxLength: 4000),
                        HttpRequestUrl = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "core.ForbiddenIdentifier",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Identifier = c.String(nullable: false, maxLength: 50),
                        Context = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "core.Location",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "core.ContentTag",
                c => new
                    {
                        ContentId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ContentId, t.TagId })
                .ForeignKey("core.Content", t => t.ContentId, cascadeDelete: true)
                .ForeignKey("core.Tag", t => t.TagId, cascadeDelete: true)
                .Index(t => t.ContentId)
                .Index(t => t.TagId);
            
            CreateTable(
                "core.UserRole",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("core.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("core.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "core.Blog",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Description = c.String(maxLength: 4000),
                        Email = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("core.Publication", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "core.Channel",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("core.Publication", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "core.Machinery",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Model = c.String(maxLength: 100),
                        ManufacturingCountry = c.Byte(nullable: false),
                        ManufacturingFactory = c.String(maxLength: 100),
                        ConstructionYear = c.Int(),
                        Height = c.Int(),
                        Width = c.Int(),
                        Length = c.Int(),
                        Wieght = c.Int(),
                        HealthStatus = c.Byte(nullable: false),
                        MaxWorkPieceWeight = c.Int(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("core.Advertisment", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "core.CncLathe",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ControlStatus = c.String(),
                        LatheType = c.Int(),
                        RailType = c.Int(),
                        HasXAxis = c.Boolean(nullable: false),
                        XAxisMovementFeed = c.String(maxLength: 100),
                        XAxisTableType = c.Int(),
                        XAxisSpeed = c.String(maxLength: 100),
                        HasYAxis = c.Boolean(nullable: false),
                        YAxisMovementFeed = c.String(maxLength: 100),
                        YAxisTableType = c.Int(),
                        YAxisSpeed = c.String(maxLength: 100),
                        HasZAxis = c.Boolean(nullable: false),
                        ZAxisMovementFeed = c.String(maxLength: 100),
                        ZAxisTableType = c.Int(),
                        ZAxisSpeed = c.String(maxLength: 100),
                        SpindleEnginePower = c.String(maxLength: 100),
                        SpindleRoundPerMinute = c.String(),
                        SpindleHasGearbox = c.Boolean(nullable: false),
                        HasAcEngine = c.Boolean(nullable: false),
                        HasDcEngine = c.Boolean(nullable: false),
                        HasOtherEngine = c.Boolean(nullable: false),
                        EnginMarks = c.String(maxLength: 200),
                        DriveMarks = c.String(nullable: false, maxLength: 200),
                        ToolChangerType = c.String(),
                        ToolsNumber = c.Int(),
                        AliveToolsNumber = c.Int(),
                        HasSoapAndWaterSystem = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("core.Machinery", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "core.NormalLathe",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        RailsArePlated = c.Byte(nullable: false),
                        HasRulerAndViewer = c.Byte(nullable: false),
                        RulerMark = c.String(maxLength: 100),
                        HasMorghak = c.Byte(nullable: false),
                        MorghakDiagonal = c.Int(),
                        MorghakDisplacementLength = c.Int(),
                        HasLapent = c.Byte(nullable: false),
                        MaximumBorderDiameter = c.Int(),
                        MaximumDiameter = c.Int(),
                        BedWidth = c.Int(),
                        MaximumMachiningLength = c.Int(),
                        SpindleSpinsNumber = c.Int(),
                        SpindleSpinsFrom = c.Int(),
                        SpindleSpinsTo = c.Int(),
                        AxisMovementSpeedFrom = c.Int(),
                        AxisMovementSpeedTo = c.Int(),
                        MetricScrewFrom = c.Int(),
                        MetricScrewTo = c.Int(),
                        InkyScrewFrom = c.Int(),
                        InkyScrewTo = c.Int(),
                        HasSoapAndWaterSystem = c.Byte(nullable: false),
                        HasThreeOrder = c.Byte(nullable: false),
                        ThreeOrderDiameter = c.Int(),
                        HasFourOrder = c.Byte(nullable: false),
                        FourOrderDiameter = c.Int(),
                        HasLift = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("core.Machinery", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("core.NormalLathe", "Id", "core.Machinery");
            DropForeignKey("core.CncLathe", "Id", "core.Machinery");
            DropForeignKey("core.Machinery", "Id", "core.Advertisment");
            DropForeignKey("core.Channel", "Id", "core.Publication");
            DropForeignKey("core.Blog", "Id", "core.Publication");
            DropForeignKey("core.UserRole", "UserId", "core.User");
            DropForeignKey("core.UserRole", "RoleId", "core.Role");
            DropForeignKey("core.Rate", "UserId", "core.User");
            DropForeignKey("core.Publication", "CreatorId", "core.User");
            DropForeignKey("core.Profile", "UserId", "core.User");
            DropForeignKey("core.Notification", "SubjectId", "core.User");
            DropForeignKey("core.Notification", "ReceiverId", "core.User");
            DropForeignKey("core.Message", "SenderId", "core.User");
            DropForeignKey("core.Message", "ReceiverId", "core.User");
            DropForeignKey("core.Membership", "Id", "core.User");
            DropForeignKey("core.Follow", "FollowerId", "core.User");
            DropForeignKey("core.Follow", "FollowedId", "core.User");
            DropForeignKey("core.EducationalResume", "UserId", "core.User");
            DropForeignKey("core.EducationalResume", "UniversityFieldId", "core.UniversityField");
            DropForeignKey("core.JobResume", "UserId", "core.User");
            DropForeignKey("core.JobResume", "OrganizationId", "core.Organization");
            DropForeignKey("core.JobResume", "JobId", "core.Job");
            DropForeignKey("core.EducationalResume", "OrganizationId", "core.Organization");
            DropForeignKey("core.Content", "AuthorId", "core.User");
            DropForeignKey("core.Comment", "SenderId", "core.User");
            DropForeignKey("core.Visit", "ContentId", "core.Content");
            DropForeignKey("core.ContentTag", "TagId", "core.Tag");
            DropForeignKey("core.ContentTag", "ContentId", "core.Content");
            DropForeignKey("core.Reference", "ContentId", "core.Content");
            DropForeignKey("core.Rate", "ContentId", "core.Content");
            DropForeignKey("core.BlogLink", "BlogId", "core.Blog");
            DropForeignKey("core.Content", "PublicationId", "core.Publication");
            DropForeignKey("core.Media", "UserId", "core.User");
            DropForeignKey("core.Media", "ContentId", "core.Content");
            DropForeignKey("core.FeaturedContent", "ContentId", "core.Content");
            DropForeignKey("core.Comment", "ContentId", "core.Content");
            DropForeignKey("core.Advertisment", "UserId", "core.User");
            DropIndex("core.NormalLathe", new[] { "Id" });
            DropIndex("core.CncLathe", new[] { "Id" });
            DropIndex("core.Machinery", new[] { "Id" });
            DropIndex("core.Channel", new[] { "Id" });
            DropIndex("core.Blog", new[] { "Id" });
            DropIndex("core.UserRole", new[] { "UserId" });
            DropIndex("core.UserRole", new[] { "RoleId" });
            DropIndex("core.ContentTag", new[] { "TagId" });
            DropIndex("core.ContentTag", new[] { "ContentId" });
            DropIndex("core.Profile", new[] { "UserId" });
            DropIndex("core.Notification", new[] { "ReceiverId" });
            DropIndex("core.Notification", new[] { "SubjectId" });
            DropIndex("core.Message", new[] { "ReceiverId" });
            DropIndex("core.Message", new[] { "SenderId" });
            DropIndex("core.Membership", new[] { "Id" });
            DropIndex("core.Follow", new[] { "FollowedId" });
            DropIndex("core.Follow", new[] { "FollowerId" });
            DropIndex("core.JobResume", new[] { "OrganizationId" });
            DropIndex("core.JobResume", new[] { "JobId" });
            DropIndex("core.JobResume", new[] { "UserId" });
            DropIndex("core.EducationalResume", new[] { "UniversityFieldId" });
            DropIndex("core.EducationalResume", new[] { "OrganizationId" });
            DropIndex("core.EducationalResume", new[] { "UserId" });
            DropIndex("core.Visit", new[] { "ContentId" });
            DropIndex("core.Reference", new[] { "ContentId" });
            DropIndex("core.Rate", new[] { "UserId" });
            DropIndex("core.Rate", new[] { "ContentId" });
            DropIndex("core.BlogLink", new[] { "BlogId" });
            DropIndex("core.Publication", new[] { "CreatorId" });
            DropIndex("core.Media", new[] { "ContentId" });
            DropIndex("core.Media", new[] { "UserId" });
            DropIndex("core.FeaturedContent", new[] { "ContentId" });
            DropIndex("core.Content", new[] { "PublicationId" });
            DropIndex("core.Content", new[] { "AuthorId" });
            DropIndex("core.Comment", new[] { "SenderId" });
            DropIndex("core.Comment", new[] { "ContentId" });
            DropIndex("core.Advertisment", new[] { "UserId" });
            DropTable("core.NormalLathe");
            DropTable("core.CncLathe");
            DropTable("core.Machinery");
            DropTable("core.Channel");
            DropTable("core.Blog");
            DropTable("core.UserRole");
            DropTable("core.ContentTag");
            DropTable("core.Location");
            DropTable("core.ForbiddenIdentifier");
            DropTable("core.ExceptionLog");
            DropTable("core.Role");
            DropTable("core.Profile");
            DropTable("core.Notification");
            DropTable("core.Message");
            DropTable("core.Membership");
            DropTable("core.Follow");
            DropTable("core.UniversityField");
            DropTable("core.Job");
            DropTable("core.JobResume");
            DropTable("core.Organization");
            DropTable("core.EducationalResume");
            DropTable("core.Visit");
            DropTable("core.Tag");
            DropTable("core.Reference");
            DropTable("core.Rate");
            DropTable("core.BlogLink");
            DropTable("core.Publication");
            DropTable("core.Media");
            DropTable("core.FeaturedContent");
            DropTable("core.Content");
            DropTable("core.Comment");
            DropTable("core.User");
            DropTable("core.Advertisment");
        }
    }
}
