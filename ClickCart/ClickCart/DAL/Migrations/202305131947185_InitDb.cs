namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CartId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carts", t => t.CartId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CartId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CartBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CartBy)
                .Index(t => t.CartBy);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false),
                        Gender = c.String(nullable: false, maxLength: 100),
                        Dob = c.DateTime(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderedBy = c.String(nullable: false, maxLength: 128),
                        OrderDate = c.DateTime(nullable: false),
                        DeliveryAddress = c.String(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        Status = c.String(nullable: false),
                        DeliveryBy = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shippers", t => t.DeliveryBy, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.OrderedBy, cascadeDelete: true)
                .Index(t => t.OrderedBy)
                .Index(t => t.DeliveryBy);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Price = c.Int(),
                        Description = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        DiscountId = c.Int(nullable: false),
                        SupplyBy = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Discounts", t => t.DiscountId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplyBy)
                .Index(t => t.CategoryId)
                .Index(t => t.DiscountId)
                .Index(t => t.SupplyBy);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        DiscountPercent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Active = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ProductId = c.Int(nullable: false),
                        ReviewBy = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.ReviewBy)
                .Index(t => t.ProductId)
                .Index(t => t.ReviewBy);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Gender = c.String(nullable: false, maxLength: 100),
                        Dob = c.DateTime(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.WishLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ProductId = c.Int(nullable: false),
                        WishBy = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.WishBy)
                .Index(t => t.ProductId)
                .Index(t => t.WishBy);
            
            CreateTable(
                "dbo.PaymentDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentBy = c.String(maxLength: 128),
                        OrderId = c.Int(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        PaymentMethod = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.PaymentBy)
                .Index(t => t.PaymentBy)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Shippers",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Gender = c.String(nullable: false, maxLength: 100),
                        Dob = c.DateTime(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TKey = c.String(nullable: false, maxLength: 100),
                        CreatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "UserId", "dbo.Users");
            DropForeignKey("dbo.CartItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.CartItems", "CartId", "dbo.Carts");
            DropForeignKey("dbo.Carts", "CartBy", "dbo.Users");
            DropForeignKey("dbo.Orders", "OrderedBy", "dbo.Users");
            DropForeignKey("dbo.Orders", "DeliveryBy", "dbo.Shippers");
            DropForeignKey("dbo.PaymentDetails", "PaymentBy", "dbo.Users");
            DropForeignKey("dbo.PaymentDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.WishLists", "WishBy", "dbo.Users");
            DropForeignKey("dbo.WishLists", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "SupplyBy", "dbo.Suppliers");
            DropForeignKey("dbo.Reviews", "ReviewBy", "dbo.Users");
            DropForeignKey("dbo.Reviews", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "DiscountId", "dbo.Discounts");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropIndex("dbo.Tokens", new[] { "UserId" });
            DropIndex("dbo.PaymentDetails", new[] { "OrderId" });
            DropIndex("dbo.PaymentDetails", new[] { "PaymentBy" });
            DropIndex("dbo.WishLists", new[] { "WishBy" });
            DropIndex("dbo.WishLists", new[] { "ProductId" });
            DropIndex("dbo.Reviews", new[] { "ReviewBy" });
            DropIndex("dbo.Reviews", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "SupplyBy" });
            DropIndex("dbo.Products", new[] { "DiscountId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.Orders", new[] { "DeliveryBy" });
            DropIndex("dbo.Orders", new[] { "OrderedBy" });
            DropIndex("dbo.Carts", new[] { "CartBy" });
            DropIndex("dbo.CartItems", new[] { "ProductId" });
            DropIndex("dbo.CartItems", new[] { "CartId" });
            DropTable("dbo.Tokens");
            DropTable("dbo.Shippers");
            DropTable("dbo.PaymentDetails");
            DropTable("dbo.WishLists");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Reviews");
            DropTable("dbo.Discounts");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.Users");
            DropTable("dbo.Carts");
            DropTable("dbo.CartItems");
        }
    }
}
