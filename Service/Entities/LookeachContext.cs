using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Service.Entities;

public partial class LookeachContext : DbContext
{
    public LookeachContext()
    {
    }

    public LookeachContext(DbContextOptions<LookeachContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccessToken> AccessTokens { get; set; }

    public virtual DbSet<Action> Actions { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<BrandImage> BrandImages { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CategoryImage> CategoryImages { get; set; }

    public virtual DbSet<Chat> Chats { get; set; }

    public virtual DbSet<ChatImage> ChatImages { get; set; }

    public virtual DbSet<ChatMessage> ChatMessages { get; set; }

    public virtual DbSet<ChatUser> ChatUsers { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<FeedBack> FeedBacks { get; set; }

    public virtual DbSet<File> Files { get; set; }

    public virtual DbSet<Follow> Follows { get; set; }

    public virtual DbSet<GenderType> GenderTypes { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<ParticipantChat> ParticipantChats { get; set; }

    public virtual DbSet<PayPalAmount> PayPalAmounts { get; set; }

    public virtual DbSet<PayPalItem> PayPalItems { get; set; }

    public virtual DbSet<PayPalOrder> PayPalOrders { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductFile> ProductFiles { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<ProductSourcing> ProductSourcings { get; set; }

    public virtual DbSet<ProductSourcingImage> ProductSourcingImages { get; set; }

    public virtual DbSet<Resource> Resources { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Shop> Shops { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<SuperAdmin> SuperAdmins { get; set; }

    public virtual DbSet<TransactionMaster> TransactionMasters { get; set; }

    public virtual DbSet<TypeSize> TypeSizes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VnpayTransaction> VnpayTransactions { get; set; }

    public virtual DbSet<VnpayTransactionRefund> VnpayTransactionRefunds { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    public virtual DbSet<VoucherSourcing> VoucherSourcings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=cosplane.asia;Initial Catalog=Lookeach;User ID=lookeach;Password=LookEach!@#123...;Encrypt=False;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccessToken>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.RefreshToken).HasDefaultValueSql("(N'')");
        });

        modelBuilder.Entity<Action>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<BrandImage>(entity =>
        {
            entity.HasIndex(e => e.BrandId, "IX_BrandImages_BrandId");

            entity.HasIndex(e => e.ImageId, "IX_BrandImages_ImageId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Brand).WithMany(p => p.BrandImages).HasForeignKey(d => d.BrandId);

            entity.HasOne(d => d.Image).WithMany(p => p.BrandImages).HasForeignKey(d => d.ImageId);
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.ProductId, e.SizeId });

            entity.ToTable("Cart");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasMany(d => d.GenderTypes).WithMany(p => p.Categories)
                .UsingEntity<Dictionary<string, object>>(
                    "CategoryGenderType",
                    r => r.HasOne<GenderType>().WithMany().HasForeignKey("GenderTypesId"),
                    l => l.HasOne<Category>().WithMany().HasForeignKey("CategoriesId"),
                    j =>
                    {
                        j.HasKey("CategoriesId", "GenderTypesId");
                        j.ToTable("CategoryGenderType");
                        j.HasIndex(new[] { "GenderTypesId" }, "IX_CategoryGenderType_GenderTypesId");
                    });

            entity.HasMany(d => d.ProductSourcings).WithMany(p => p.Categories)
                .UsingEntity<Dictionary<string, object>>(
                    "CategoryProductSourcing",
                    r => r.HasOne<ProductSourcing>().WithMany().HasForeignKey("ProductSourcingsId"),
                    l => l.HasOne<Category>().WithMany().HasForeignKey("CategoriesId"),
                    j =>
                    {
                        j.HasKey("CategoriesId", "ProductSourcingsId");
                        j.ToTable("CategoryProductSourcing");
                        j.HasIndex(new[] { "ProductSourcingsId" }, "IX_CategoryProductSourcing_ProductSourcingsId");
                    });

            entity.HasMany(d => d.Products).WithMany(p => p.Categories)
                .UsingEntity<Dictionary<string, object>>(
                    "CategoryProduct",
                    r => r.HasOne<Product>().WithMany().HasForeignKey("ProductsId"),
                    l => l.HasOne<Category>().WithMany().HasForeignKey("CategoriesId"),
                    j =>
                    {
                        j.HasKey("CategoriesId", "ProductsId");
                        j.ToTable("CategoryProduct");
                        j.HasIndex(new[] { "ProductsId" }, "IX_CategoryProduct_ProductsId");
                    });
        });

        modelBuilder.Entity<CategoryImage>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "IX_CategoryImages_CategoryId");

            entity.HasIndex(e => e.ImageId, "IX_CategoryImages_ImageId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Category).WithMany(p => p.CategoryImages).HasForeignKey(d => d.CategoryId);

            entity.HasOne(d => d.Image).WithMany(p => p.CategoryImages).HasForeignKey(d => d.ImageId);
        });

        modelBuilder.Entity<Chat>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasDefaultValueSql("(N'')");
        });

        modelBuilder.Entity<ChatImage>(entity =>
        {
            entity.HasIndex(e => e.ChatId, "IX_ChatImages_ChatId");

            entity.HasIndex(e => e.ChatMessageId, "IX_ChatImages_ChatMessageId");

            entity.HasIndex(e => e.ImageId, "IX_ChatImages_ImageId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Chat).WithMany(p => p.ChatImages).HasForeignKey(d => d.ChatId);

            entity.HasOne(d => d.ChatMessage).WithMany(p => p.ChatImages).HasForeignKey(d => d.ChatMessageId);

            entity.HasOne(d => d.Image).WithMany(p => p.ChatImages).HasForeignKey(d => d.ImageId);
        });

        modelBuilder.Entity<ChatMessage>(entity =>
        {
            entity.HasIndex(e => e.ChatId, "IX_ChatMessages_ChatId");

            entity.HasIndex(e => e.UserId, "IX_ChatMessages_UserId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Chat).WithMany(p => p.ChatMessages).HasForeignKey(d => d.ChatId);

            entity.HasOne(d => d.User).WithMany(p => p.ChatMessages).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<ChatUser>(entity =>
        {
            entity.HasIndex(e => e.ChatId, "IX_ChatUsers_ChatId");

            entity.HasIndex(e => e.UserId, "IX_ChatUsers_UserId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Chat).WithMany(p => p.ChatUsers).HasForeignKey(d => d.ChatId);

            entity.HasOne(d => d.User).WithMany(p => p.ChatUsers).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasMany(d => d.ProductSourcings).WithMany(p => p.Colors)
                .UsingEntity<Dictionary<string, object>>(
                    "ColorProductSourcing",
                    r => r.HasOne<ProductSourcing>().WithMany().HasForeignKey("ProductSourcingsId"),
                    l => l.HasOne<Color>().WithMany().HasForeignKey("ColorsId"),
                    j =>
                    {
                        j.HasKey("ColorsId", "ProductSourcingsId");
                        j.ToTable("ColorProductSourcing");
                        j.HasIndex(new[] { "ProductSourcingsId" }, "IX_ColorProductSourcing_ProductSourcingsId");
                    });

            entity.HasMany(d => d.Products).WithMany(p => p.Colors)
                .UsingEntity<Dictionary<string, object>>(
                    "ColorProduct",
                    r => r.HasOne<Product>().WithMany().HasForeignKey("ProductsId"),
                    l => l.HasOne<Color>().WithMany().HasForeignKey("ColorsId"),
                    j =>
                    {
                        j.HasKey("ColorsId", "ProductsId");
                        j.ToTable("ColorProduct");
                        j.HasIndex(new[] { "ProductsId" }, "IX_ColorProduct_ProductsId");
                    });
        });

        modelBuilder.Entity<FeedBack>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.UserId });

            entity.ToTable("FeedBack");

            entity.Property(e => e.Comment).HasMaxLength(500);
        });

        modelBuilder.Entity<File>(entity =>
        {
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.FileData).IsUnicode(false);
            entity.Property(e => e.FileSize).HasMaxLength(100);
            entity.Property(e => e.FileType).HasMaxLength(250);
        });

        modelBuilder.Entity<Follow>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.MerchantId });

            entity.ToTable("Follow");
        });

        modelBuilder.Entity<GenderType>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.ToTable("Notification");

            entity.Property(e => e.Content).HasMaxLength(500);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_Orders_UserId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address).HasDefaultValueSql("(N'')");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DollarAmount)
                .HasDefaultValueSql("((0.0))")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.Phone).HasDefaultValueSql("(N'')");
            entity.Property(e => e.Status).HasDefaultValueSql("(N'')");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.User).WithMany(p => p.Orders).HasForeignKey(d => d.UserId);

            entity.HasMany(d => d.PaymentMethods).WithMany(p => p.Orders)
                .UsingEntity<Dictionary<string, object>>(
                    "OrderPaymentMethod",
                    r => r.HasOne<PaymentMethod>().WithMany().HasForeignKey("PaymentMethodsId"),
                    l => l.HasOne<Order>().WithMany().HasForeignKey("OrdersId"),
                    j =>
                    {
                        j.HasKey("OrdersId", "PaymentMethodsId");
                        j.ToTable("OrderPaymentMethod");
                        j.HasIndex(new[] { "PaymentMethodsId" }, "IX_OrderPaymentMethod_PaymentMethodsId");
                    });

            entity.HasMany(d => d.Vouchers).WithMany(p => p.Orders)
                .UsingEntity<Dictionary<string, object>>(
                    "OrderVoucher",
                    r => r.HasOne<Voucher>().WithMany().HasForeignKey("VouchersId"),
                    l => l.HasOne<Order>().WithMany().HasForeignKey("OrdersId"),
                    j =>
                    {
                        j.HasKey("OrdersId", "VouchersId");
                        j.ToTable("OrderVoucher");
                        j.HasIndex(new[] { "VouchersId" }, "IX_OrderVoucher_VouchersId");
                    });
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasIndex(e => e.OrderId, "IX_OrderItems_OrderId");

            entity.HasIndex(e => e.ProductId, "IX_OrderItems_ProductId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DollarPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems).HasForeignKey(d => d.OrderId);

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems).HasForeignKey(d => d.ProductId);
        });

        modelBuilder.Entity<ParticipantChat>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<PayPalAmount>(entity =>
        {
            entity.HasIndex(e => e.PaypalOrderId, "IX_PayPalAmounts_PaypalOrderId").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ItemTotalValue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Value).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.PaypalOrder).WithOne(p => p.PayPalAmount).HasForeignKey<PayPalAmount>(d => d.PaypalOrderId);
        });

        modelBuilder.Entity<PayPalItem>(entity =>
        {
            entity.HasIndex(e => e.PaypalOrderId, "IX_PayPalItems_PaypalOrderId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Value).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.PaypalOrder).WithMany(p => p.PayPalItems).HasForeignKey(d => d.PaypalOrderId);
        });

        modelBuilder.Entity<PayPalOrder>(entity =>
        {
            entity.HasIndex(e => e.OrderId, "IX_PayPalOrders_OrderId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ExchangeCurrency).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.PayPalOrders).HasForeignKey(d => d.OrderId);
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasIndex(e => e.ResourceId, "IX_Permissions_ResourceId");

            entity.HasIndex(e => e.RoleId, "IX_Permissions_RoleId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Resource).WithMany(p => p.Permissions).HasForeignKey(d => d.ResourceId);

            entity.HasOne(d => d.Role).WithMany(p => p.Permissions).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.BrandId, "IX_Products_BrandId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DollarPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.IsActived)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.Material).HasMaxLength(200);
            entity.Property(e => e.Origin).HasMaxLength(200);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Brand).WithMany(p => p.Products).HasForeignKey(d => d.BrandId);

            entity.HasMany(d => d.Sizes).WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductSize",
                    r => r.HasOne<Size>().WithMany().HasForeignKey("SizesId"),
                    l => l.HasOne<Product>().WithMany().HasForeignKey("ProductsId"),
                    j =>
                    {
                        j.HasKey("ProductsId", "SizesId");
                        j.ToTable("ProductSize");
                        j.HasIndex(new[] { "SizesId" }, "IX_ProductSize_SizesId");
                    });
        });

        modelBuilder.Entity<ProductFile>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.FileId });
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.HasIndex(e => e.ImageId, "IX_ProductImages_ImageId");

            entity.HasIndex(e => e.ProductId, "IX_ProductImages_ProductId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Image).WithMany(p => p.ProductImages).HasForeignKey(d => d.ImageId);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages).HasForeignKey(d => d.ProductId);
        });

        modelBuilder.Entity<ProductSourcing>(entity =>
        {
            entity.HasIndex(e => e.BrandId, "IX_ProductSourcings_BrandId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Brand).WithMany(p => p.ProductSourcings).HasForeignKey(d => d.BrandId);

            entity.HasMany(d => d.Sizes).WithMany(p => p.ProductSourcings)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductSourcingSize",
                    r => r.HasOne<Size>().WithMany().HasForeignKey("SizesId"),
                    l => l.HasOne<ProductSourcing>().WithMany().HasForeignKey("ProductSourcingsId"),
                    j =>
                    {
                        j.HasKey("ProductSourcingsId", "SizesId");
                        j.ToTable("ProductSourcingSize");
                        j.HasIndex(new[] { "SizesId" }, "IX_ProductSourcingSize_SizesId");
                    });
        });

        modelBuilder.Entity<ProductSourcingImage>(entity =>
        {
            entity.HasIndex(e => e.ProductSourcingId1, "IX_ProductSourcingImages_ProductSourcingId1");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.ProductSourcingId1Navigation).WithMany(p => p.ProductSourcingImages).HasForeignKey(d => d.ProductSourcingId1);
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasMany(d => d.SuperAdmins).WithMany(p => p.Roles)
                .UsingEntity<Dictionary<string, object>>(
                    "RoleSuperAdmin",
                    r => r.HasOne<SuperAdmin>().WithMany().HasForeignKey("SuperAdminsId"),
                    l => l.HasOne<Role>().WithMany().HasForeignKey("RolesId"),
                    j =>
                    {
                        j.HasKey("RolesId", "SuperAdminsId");
                        j.ToTable("RoleSuperAdmin");
                        j.HasIndex(new[] { "SuperAdminsId" }, "IX_RoleSuperAdmin_SuperAdminsId");
                    });

            entity.HasMany(d => d.Users).WithMany(p => p.Roles)
                .UsingEntity<Dictionary<string, object>>(
                    "RoleUser",
                    r => r.HasOne<User>().WithMany().HasForeignKey("UsersId"),
                    l => l.HasOne<Role>().WithMany().HasForeignKey("RolesId"),
                    j =>
                    {
                        j.HasKey("RolesId", "UsersId");
                        j.ToTable("RoleUser");
                        j.HasIndex(new[] { "UsersId" }, "IX_RoleUser_UsersId");
                    });
        });

        modelBuilder.Entity<Shop>(entity =>
        {
            entity.ToTable("Shop");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CitizenIdentityNumber)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.ClinicName).HasMaxLength(150);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.OwnerName).HasMaxLength(150);
            entity.Property(e => e.TaxCode)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<SuperAdmin>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<TransactionMaster>(entity =>
        {
            entity.HasIndex(e => e.OrderId, "IX_TransactionMasters_OrderId");

            entity.HasIndex(e => e.PaymentMethodId, "IX_TransactionMasters_PaymentMethodId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Order).WithMany(p => p.TransactionMasters).HasForeignKey(d => d.OrderId);

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.TransactionMasters).HasForeignKey(d => d.PaymentMethodId);
        });

        modelBuilder.Entity<TypeSize>(entity =>
        {
            entity.ToTable("TypeSize");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AccountNumber)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.AccountOwner).HasMaxLength(150);
            entity.Property(e => e.BankName).HasMaxLength(150);
        });

        modelBuilder.Entity<VnpayTransaction>(entity =>
        {
            entity.ToTable("VNPayTransactions");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<VnpayTransactionRefund>(entity =>
        {
            entity.ToTable("VNPayTransactionRefunds");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IsSystem)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.MaxPriceOff)
                .HasDefaultValueSql("((0.0))")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.PriceCondition).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<VoucherSourcing>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_VoucherSourcings_UserId");

            entity.HasIndex(e => e.VoucherId, "IX_VoucherSourcings_VoucherId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.User).WithMany(p => p.VoucherSourcings).HasForeignKey(d => d.UserId);

            entity.HasOne(d => d.Voucher).WithMany(p => p.VoucherSourcings).HasForeignKey(d => d.VoucherId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
