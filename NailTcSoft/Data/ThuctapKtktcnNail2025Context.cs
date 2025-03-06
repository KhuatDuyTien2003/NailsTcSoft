﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NailTcSoft.Data;

public partial class ThuctapKtktcnNail2025Context : DbContext
{
    public ThuctapKtktcnNail2025Context()
    {
    }

    public ThuctapKtktcnNail2025Context(DbContextOptions<ThuctapKtktcnNail2025Context> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<BillDetail> BillDetails { get; set; }

    public virtual DbSet<CalculatePoint> CalculatePoints { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ComboDetail> ComboDetails { get; set; }

    public virtual DbSet<CommissionPayment> CommissionPayments { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerRank> CustomerRanks { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<GoodsReceipt> GoodsReceipts { get; set; }

    public virtual DbSet<GoodsReceiptDetail> GoodsReceiptDetails { get; set; }

    public virtual DbSet<ImageFeedback> ImageFeedbacks { get; set; }

    public virtual DbSet<PriceList> PriceLists { get; set; }

    public virtual DbSet<PriceListDetail> PriceListDetails { get; set; }

    public virtual DbSet<ProductAndService> ProductAndServices { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<PromotionDetail> PromotionDetails { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<StaffService> StaffServices { get; set; }

    public virtual DbSet<WorkSchedule> WorkSchedules { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=thuctap.tcsoft.vn,1444;Initial Catalog=thuctap_ktktcn_nail_2025;User ID=user_thuctap_ktktcn_nail_2025;Password=mKm3IYhD7Jt4;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.BillId).HasName("PK__Bill__6D903F0377A66880");

            entity.ToTable("Bill");

            entity.Property(e => e.BillId).HasColumnName("billId");
            entity.Property(e => e.BillDate)
                .HasColumnType("datetime")
                .HasColumnName("billDate");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.MoneyPoint)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("moneyPoint");
            entity.Property(e => e.PaymentId).HasColumnName("paymentId");
            entity.Property(e => e.Points).HasColumnName("points");
            entity.Property(e => e.PromotionId).HasColumnName("promotionId");
            entity.Property(e => e.ReceptionistId).HasColumnName("receptionistId");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TotalMoney)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("totalMoney");
        });

        modelBuilder.Entity<BillDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BillDeta__3213E83F71D2C687");

            entity.ToTable("BillDetail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BillId).HasColumnName("billId");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.ProAndSerId).HasColumnName("proAndSerId");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.StaffId).HasColumnName("staffId");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TotalMoney)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("totalMoney");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("unitPrice");
        });

        modelBuilder.Entity<CalculatePoint>(entity =>
        {
            entity.HasKey(e => e.CalculateId).HasName("PK__Calculat__E8BD939A9A133C36");

            entity.Property(e => e.CalculateId).HasColumnName("calculateId");
            entity.Property(e => e.CalulateType).HasColumnName("calulateType");
            entity.Property(e => e.Money).HasColumnName("money");
            entity.Property(e => e.Point).HasColumnName("point");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__23CAF1D8AEA35084");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .HasColumnName("categoryName");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<ComboDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ComboDet__3214EC07E48DC2E4");

            entity.ToTable("ComboDetail");

            entity.Property(e => e.ComboId).HasColumnName("comboId");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.ServiceId).HasColumnName("serviceId");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<CommissionPayment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Commissi__A0D9EFC6C1464F3E");

            entity.ToTable("CommissionPayment");

            entity.Property(e => e.PaymentId).HasColumnName("paymentId");
            entity.Property(e => e.AccountantId).HasColumnName("accountantId");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.PaymentDate).HasColumnName("paymentDate");
            entity.Property(e => e.StaffId).HasColumnName("staffId");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TotalCommission)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("totalCommission");
            entity.Property(e => e.TotalWork).HasColumnName("totalWork");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__B611CB7D4A9DAF4B");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(100)
                .HasColumnName("customerName");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.NumberPhone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("numberPhone");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.RankId).HasColumnName("rankId");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TotalMoney)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("totalMoney");
            entity.Property(e => e.TotalPoints).HasColumnName("totalPoints");
            entity.Property(e => e.UrlAvatar)
                .IsUnicode(false)
                .HasColumnName("urlAvatar");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("userName");
        });

        modelBuilder.Entity<CustomerRank>(entity =>
        {
            entity.HasKey(e => e.RankId).HasName("PK__Customer__D639D7010B98D027");

            entity.ToTable("CustomerRank");

            entity.Property(e => e.RankId).HasColumnName("rankId");
            entity.Property(e => e.DiscountRate).HasColumnName("discountRate");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.RankName)
                .HasMaxLength(100)
                .HasColumnName("rankName");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TotalMoney)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("totalMoney");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__2613FD24A8E4A140");

            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId).HasColumnName("feedbackId");
            entity.Property(e => e.Comment)
                .HasColumnType("text")
                .HasColumnName("comment");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.ProAndSerId).HasColumnName("proAndSerId");
            entity.Property(e => e.StaffId).HasColumnName("staffId");
            entity.Property(e => e.Star).HasColumnName("star");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<GoodsReceipt>(entity =>
        {
            entity.HasKey(e => e.ReceiptId).HasName("PK__GoodsRec__CAA7E8B827A0BCC3");

            entity.ToTable("GoodsReceipt");

            entity.Property(e => e.ReceiptId).HasColumnName("receiptId");
            entity.Property(e => e.AccountantId).HasColumnName("accountantId");
            entity.Property(e => e.ImportDate)
                .HasColumnType("datetime")
                .HasColumnName("importDate");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TotalMoney)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("totalMoney");
        });

        modelBuilder.Entity<GoodsReceiptDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GoodsRec__3213E83F3C9020E1");

            entity.ToTable("GoodsReceiptDetail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ImportPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("importPrice");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.ReceiptId).HasColumnName("receiptId");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Supplier)
                .HasMaxLength(100)
                .HasColumnName("supplier");
        });

        modelBuilder.Entity<ImageFeedback>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ImageFee__3213E83F06E537D2");

            entity.ToTable("ImageFeedback");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FeedbackId).HasColumnName("feedbackId");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UrlImage)
                .IsUnicode(false)
                .HasColumnName("urlImage");
        });

        modelBuilder.Entity<PriceList>(entity =>
        {
            entity.HasKey(e => e.PriceListId).HasName("PK__PriceLis__5A789FD2851FFF30");

            entity.ToTable("PriceList");

            entity.Property(e => e.PriceListId).HasColumnName("priceListId");
            entity.Property(e => e.EndTime).HasColumnName("endTime");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.PriceListName)
                .HasMaxLength(100)
                .HasColumnName("priceListName");
            entity.Property(e => e.PriceListType).HasColumnName("priceListType");
            entity.Property(e => e.RankId).HasColumnName("rankId");
            entity.Property(e => e.StartTime).HasColumnName("startTime");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.ValuePriceList).HasColumnName("valuePriceList");
        });

        modelBuilder.Entity<PriceListDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PriceLis__3213E83FE30EF13B");

            entity.ToTable("PriceListDetail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PriceListId).HasColumnName("priceListId");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.SellPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("sellPrice");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<ProductAndService>(entity =>
        {
            entity.HasKey(e => e.ProAndSerId).HasName("PK__ProductA__4A1A7779B56E4014");

            entity.ToTable("ProductAndService");

            entity.HasIndex(e => e.ProAndSerCode, "UQ__ProductA__839A479656AAB0E9").IsUnique();

            entity.Property(e => e.ProAndSerId).HasColumnName("proAndSerId");
            entity.Property(e => e.Commission).HasColumnName("commission");
            entity.Property(e => e.InventoryQuantity).HasColumnName("inventoryQuantity");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.OriginalPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("originalPrice");
            entity.Property(e => e.ProAndSerCode)
                .HasMaxLength(20)
                .HasColumnName("proAndSerCode");
            entity.Property(e => e.ProAndSerName)
                .HasMaxLength(100)
                .HasColumnName("proAndSerName");
            entity.Property(e => e.ProAndSerType).HasColumnName("proAndSerType");
            entity.Property(e => e.ProductTypeId).HasColumnName("productTypeId");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Unit)
                .HasMaxLength(50)
                .HasColumnName("unit");
            entity.Property(e => e.UrlImage)
                .IsUnicode(false)
                .HasColumnName("urlImage");
            entity.Property(e => e.WorkTime).HasColumnName("workTime");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.ProductTypeId).HasName("PK__ProductT__CA28F4DED8EF8227");

            entity.ToTable("ProductType");

            entity.Property(e => e.ProductTypeId).HasColumnName("productTypeId");
            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.ProductTypeName)
                .HasMaxLength(100)
                .HasColumnName("productTypeName");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.HasKey(e => e.PromotionId).HasName("PK__Promotio__99EB696E5901E12D");

            entity.ToTable("Promotion");

            entity.Property(e => e.PromotionId).HasColumnName("promotionId");
            entity.Property(e => e.Condition)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("condition");
            entity.Property(e => e.EndDate).HasColumnName("endDate");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.IsPoints).HasColumnName("isPoints");
            entity.Property(e => e.ProductTypeId).HasColumnName("productTypeId");
            entity.Property(e => e.PromotionName).HasColumnName("promotionName");
            entity.Property(e => e.PromotionType).HasColumnName("promotionType");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.RankId).HasColumnName("rankId");
            entity.Property(e => e.StartDate).HasColumnName("startDate");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UrlImage)
                .IsUnicode(false)
                .HasColumnName("urlImage");
        });

        modelBuilder.Entity<PromotionDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Promotio__3213E83F4BBC59EC");

            entity.ToTable("PromotionDetail");

            entity.HasIndex(e => e.PromotionCode, "UQ__Promotio__E9685770A92520FF").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.IsUsed).HasColumnName("isUsed");
            entity.Property(e => e.PromotionCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("promotionCode");
            entity.Property(e => e.PromotionId).HasColumnName("promotionId");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UsedDate).HasColumnName("usedDate");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__6465E07E8CA3F912");

            entity.Property(e => e.StaffId).HasColumnName("staffId");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.JoinDate).HasColumnName("joinDate");
            entity.Property(e => e.NumberPhone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("numberPhone");
            entity.Property(e => e.StaffName)
                .HasMaxLength(100)
                .HasColumnName("staffName");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TotalMoney)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("totalMoney");
            entity.Property(e => e.TotalStar).HasColumnName("totalStar");
            entity.Property(e => e.UrlAvatar)
                .IsUnicode(false)
                .HasColumnName("urlAvatar");
        });

        modelBuilder.Entity<StaffService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StaffSer__3213E83FFD9B92CE");

            entity.ToTable("StaffService");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ServiceId).HasColumnName("serviceId");
            entity.Property(e => e.StaffId).HasColumnName("staffId");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<WorkSchedule>(entity =>
        {
            entity.HasKey(e => e.WorkScheduleId).HasName("PK__WorkSche__8691383837C7322D");

            entity.ToTable("WorkSchedule");

            entity.Property(e => e.WorkScheduleId).HasColumnName("workScheduleId");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.IsDone).HasColumnName("isDone");
            entity.Property(e => e.Shift).HasColumnName("shift");
            entity.Property(e => e.StaffId).HasColumnName("staffId");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
