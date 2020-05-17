using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace ZydusFrontline.Repository.ContextModel
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<CodeValue> CodeValue { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Desig> Desig { get; set; }
        public virtual DbSet<DesigGrp> DesigGrp { get; set; }
        public virtual DbSet<DrAddrDraft> DrAddrDraft { get; set; }
        public virtual DbSet<DrDropReason> DrDropReason { get; set; }
        public virtual DbSet<DrMstDraft> DrMstDraft { get; set; }
        public virtual DbSet<FamilyDetail> FamilyDetail { get; set; }
        public virtual DbSet<Headquarter> Headquarter { get; set; }
        public virtual DbSet<McrCategory> McrCategory { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MenuGroupRights> MenuGroupRights { get; set; }
        public virtual DbSet<Qualification> Qualification { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<RepMst> RepMst { get; set; }
        public virtual DbSet<Sbu> Sbu { get; set; }
        public virtual DbSet<SecurityQuest> SecurityQuest { get; set; }
        public virtual DbSet<Speciality> Speciality { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<TownType> TownType { get; set; }
        public virtual DbSet<UserHistory> UserHistory { get; set; }
        public virtual DbSet<UserMenuGroupRights> UserMenuGroupRights { get; set; }
        public virtual DbSet<UserMst> UserMst { get; set; }
        public virtual DbSet<UserSecurityQuest> UserSecurityQuest { get; set; }
        public virtual DbSet<UserZrahGroup> UserZrahGroup { get; set; }
        public virtual DbSet<Zone> Zone { get; set; }
        public virtual DbSet<ZrahGroupRights> ZrahGroupRights { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationBuilder builder = new ConfigurationBuilder();
                builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
                var root = builder.Build();
                var sampleConnectionString = root.GetConnectionString("DBContext");
                optionsBuilder.UseSqlServer(sampleConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("AREA", "MASTER");

                entity.Property(e => e.AreaId).HasColumnName("AREA_ID");

                entity.Property(e => e.AreaCode)
                    .IsRequired()
                    .HasColumnName("AREA_CODE")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.AreaDesc)
                    .IsRequired()
                    .HasColumnName("AREA_DESC")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.RegionId).HasColumnName("REGION_ID");

                entity.Property(e => e.ZdAreaCode)
                    .HasColumnName("ZD_AREA_CODE")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Area)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AREA_REGION");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("CITY", "MASTER");

                entity.Property(e => e.CityId).HasColumnName("CITY_ID");

                entity.Property(e => e.CityCode)
                    .IsRequired()
                    .HasColumnName("CITY_CODE")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasColumnName("CITY_NAME")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.FinDelFlag)
                    .HasColumnName("FIN_DEL_FLAG")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FinalCityCode)
                    .HasColumnName("FINAL_CITY_CODE")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.SerNoChemist).HasColumnName("SER_NO_CHEMIST");

                entity.Property(e => e.SerNoDr).HasColumnName("SER_NO_DR");

                entity.Property(e => e.StateId).HasColumnName("STATE_ID");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CITY_STATE");
            });

            modelBuilder.Entity<CodeValue>(entity =>
            {
                entity.HasKey(e => e.CodeValId);

                entity.ToTable("CODE_VALUE", "MASTER");

                entity.Property(e => e.CodeValId).HasColumnName("CODE_VAL_ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Admin')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Admin')");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SeqNo).HasColumnName("SEQ_NO");

                entity.Property(e => e.TypeCode)
                    .IsRequired()
                    .HasColumnName("TYPE_CODE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValCode)
                    .IsRequired()
                    .HasColumnName("VAL_CODE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValDesc)
                    .IsRequired()
                    .HasColumnName("VAL_DESC")
                    .HasMaxLength(2000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("COMPANY", "MASTER");

                entity.Property(e => e.CompanyId).HasColumnName("COMPANY_ID");

                entity.Property(e => e.CompanyCode)
                    .IsRequired()
                    .HasColumnName("COMPANY_CODE")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("COMPANY_NAME")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.OldCompCode)
                    .HasColumnName("OLD_COMP_CODE")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Place)
                    .HasColumnName("PLACE")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UndupliFlag)
                    .HasColumnName("UNDUPLI_FLAG")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Desig>(entity =>
            {
                entity.ToTable("DESIG", "MASTER");

                entity.Property(e => e.DesigId).HasColumnName("DESIG_ID");

                entity.Property(e => e.ConfirmationFlag)
                    .HasColumnName("CONFIRMATION_FLAG")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.DesigCategory)
                    .HasColumnName("DESIG_CATEGORY")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.DesigCode)
                    .IsRequired()
                    .HasColumnName("DESIG_CODE")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DesigDesc)
                    .IsRequired()
                    .HasColumnName("DESIG_DESC")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DesigHierarchy).HasColumnName("DESIG_HIERARCHY");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LeaveFlag)
                    .HasColumnName("LEAVE_FLAG")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.SbuId).HasColumnName("SBU_ID");

                entity.HasOne(d => d.Sbu)
                    .WithMany(p => p.Desig)
                    .HasForeignKey(d => d.SbuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DESIG_SBU");
            });

            modelBuilder.Entity<DesigGrp>(entity =>
            {
                entity.ToTable("DESIG_GRP", "MASTER");

                entity.Property(e => e.DesigGrpId).HasColumnName("DESIG_GRP_ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Admin')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DesigId).HasColumnName("DESIG_ID");

                entity.Property(e => e.GroupCode)
                    .IsRequired()
                    .HasColumnName("GROUP_CODE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Admin')");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Desig)
                    .WithMany(p => p.DesigGrp)
                    .HasForeignKey(d => d.DesigId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DESIG_GRP_DESIG");
            });

            modelBuilder.Entity<DrAddrDraft>(entity =>
            {
                entity.ToTable("DR_ADDR_DRAFT", "DOCTOR");

                entity.Property(e => e.DrAddrDraftId).HasColumnName("DR_ADDR_DRAFT_ID");

                entity.Property(e => e.Add1)
                    .IsRequired()
                    .HasColumnName("ADD1")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Add2)
                    .HasColumnName("ADD2")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Add3)
                    .HasColumnName("ADD3")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.AddrCode)
                    .IsRequired()
                    .HasColumnName("ADDR_CODE")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.AddrTypeId).HasColumnName("ADDR_TYPE_ID");

                entity.Property(e => e.ApprovalDate)
                    .HasColumnName("APPROVAL_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ApprovalFlag)
                    .HasColumnName("APPROVAL_FLAG")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ApprovalLevel1)
                    .HasColumnName("APPROVAL_LEVEL1")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('P')");

                entity.Property(e => e.ApprovalLevel1ById)
                    .HasColumnName("APPROVAL_LEVEL1_BY_ID")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.ApprovalLevel1Date)
                    .HasColumnName("APPROVAL_LEVEL1_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ApprovalLevel1Mcrno).HasColumnName("APPROVAL_LEVEL1_MCRNO");

                entity.Property(e => e.ApprovalLevel1Remark)
                    .HasColumnName("APPROVAL_LEVEL1_REMARK")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalLevel2)
                    .HasColumnName("APPROVAL_LEVEL2")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('P')");

                entity.Property(e => e.ApprovalLevel2ById)
                    .HasColumnName("APPROVAL_LEVEL2_BY_ID")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.ApprovalLevel2Date)
                    .HasColumnName("APPROVAL_LEVEL2_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ApprovalLevel2Mcrno).HasColumnName("APPROVAL_LEVEL2_MCRNO");

                entity.Property(e => e.ApprovalLevel2Remark)
                    .HasColumnName("APPROVAL_LEVEL2_REMARK")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalLevel3)
                    .HasColumnName("APPROVAL_LEVEL3")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('P')");

                entity.Property(e => e.ApprovalLevel3ById)
                    .HasColumnName("APPROVAL_LEVEL3_BY_ID")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.ApprovalLevel3Date)
                    .HasColumnName("APPROVAL_LEVEL3_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ApprovalLevel3Mcrno).HasColumnName("APPROVAL_LEVEL3_MCRNO");

                entity.Property(e => e.ApprovalLevel3Remark)
                    .HasColumnName("APPROVAL_LEVEL3_REMARK")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalRemark)
                    .HasColumnName("APPROVAL_REMARK")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovedById).HasColumnName("APPROVED_BY_ID");

                entity.Property(e => e.Area)
                    .IsRequired()
                    .HasColumnName("AREA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CityId).HasColumnName("CITY_ID");

                entity.Property(e => e.ClinicName)
                    .HasColumnName("CLINIC_NAME")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Admin')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Day)
                    .HasColumnName("DAY")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.DrMstDraftId).HasColumnName("DR_MST_DRAFT_ID");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EntryCategory)
                    .HasColumnName("ENTRY_CATEGORY")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FinalDrCode)
                    .HasColumnName("FINAL_DR_CODE")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.FromTime)
                    .HasColumnName("FROM_TIME")
                    .HasColumnType("decimal(16, 2)");

                entity.Property(e => e.HoApproval)
                    .HasColumnName("HO_APPROVAL")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('P')");

                entity.Property(e => e.HoApprovalById)
                    .HasColumnName("HO_APPROVAL_BY_ID")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.HoApprovalDate)
                    .HasColumnName("HO_APPROVAL_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.HoApprovalRemark)
                    .HasColumnName("HO_APPROVAL_REMARK")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("IMAGE_URL")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.McrNo).HasColumnName("MCR_NO");

                entity.Property(e => e.Mobile)
                    .HasColumnName("MOBILE")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Admin')");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PhoneC)
                    .HasColumnName("PHONE_C")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneR)
                    .HasColumnName("PHONE_R")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PinCode)
                    .IsRequired()
                    .HasColumnName("PIN_CODE")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.RegisterCode)
                    .HasColumnName("REGISTER_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .HasColumnName("REMARK")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.RepId).HasColumnName("REP_ID");

                entity.Property(e => e.SeqNo)
                    .HasColumnName("SEQ_NO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.StateId).HasColumnName("STATE_ID");

                entity.Property(e => e.ToTime)
                    .HasColumnName("TO_TIME")
                    .HasColumnType("decimal(16, 2)");

                entity.HasOne(d => d.AddrType)
                    .WithMany(p => p.DrAddrDraft)
                    .HasForeignKey(d => d.AddrTypeId)
                    .HasConstraintName("FK_DR_ADDR_DRAFT_CODE_VALUE");

                entity.HasOne(d => d.ApprovalLevel1By)
                    .WithMany(p => p.DrAddrDraftApprovalLevel1By)
                    .HasForeignKey(d => d.ApprovalLevel1ById)
                    .HasConstraintName("FK_DR_ADDR_DRAFT_REP_MST1");

                entity.HasOne(d => d.ApprovalLevel2By)
                    .WithMany(p => p.DrAddrDraftApprovalLevel2By)
                    .HasForeignKey(d => d.ApprovalLevel2ById)
                    .HasConstraintName("FK_DR_ADDR_DRAFT_REP_MST2");

                entity.HasOne(d => d.ApprovalLevel3By)
                    .WithMany(p => p.DrAddrDraftApprovalLevel3By)
                    .HasForeignKey(d => d.ApprovalLevel3ById)
                    .HasConstraintName("FK_DR_ADDR_DRAFT_REP_MST3");

                entity.HasOne(d => d.ApprovedBy)
                    .WithMany(p => p.DrAddrDraftApprovedBy)
                    .HasForeignKey(d => d.ApprovedById)
                    .HasConstraintName("FK_DR_ADDR_DRAFT_REP_MST");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.DrAddrDraft)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DR_ADDR_DRAFT_CITY");

                entity.HasOne(d => d.DrMstDraft)
                    .WithMany(p => p.DrAddrDraft)
                    .HasForeignKey(d => d.DrMstDraftId)
                    .HasConstraintName("FK_DR_ADDR_DRAFT_DR_MST_DRAFT");

                entity.HasOne(d => d.HoApprovalBy)
                    .WithMany(p => p.DrAddrDraftHoApprovalBy)
                    .HasForeignKey(d => d.HoApprovalById)
                    .HasConstraintName("FK_DR_ADDR_DRAFT_REP_MST4");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.DrAddrDraft)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DR_ADDR_DRAFT_STATE");
            });

            modelBuilder.Entity<DrDropReason>(entity =>
            {
                entity.HasKey(e => e.ReasonCode);

                entity.ToTable("DR_DROP_REASON", "MASTER");

                entity.Property(e => e.ReasonCode)
                    .HasColumnName("REASON_CODE")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ReasonDesc)
                    .IsRequired()
                    .HasColumnName("REASON_DESC")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DrMstDraft>(entity =>
            {
                entity.ToTable("DR_MST_DRAFT", "DOCTOR");

                entity.Property(e => e.DrMstDraftId).HasColumnName("DR_MST_DRAFT_ID");

                entity.Property(e => e.Add1)
                    .IsRequired()
                    .HasColumnName("ADD1")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Add2)
                    .HasColumnName("ADD2")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Add3)
                    .HasColumnName("ADD3")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.AnnDate)
                    .HasColumnName("ANN_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ApprovalDate)
                    .HasColumnName("APPROVAL_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ApprovalFlag)
                    .HasColumnName("APPROVAL_FLAG")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ApprovalLevel1)
                    .HasColumnName("APPROVAL_LEVEL1")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('P')");

                entity.Property(e => e.ApprovalLevel1ById)
                    .HasColumnName("APPROVAL_LEVEL1_BY_ID")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.ApprovalLevel1Date)
                    .HasColumnName("APPROVAL_LEVEL1_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ApprovalLevel1Mcrno).HasColumnName("APPROVAL_LEVEL1_MCRNO");

                entity.Property(e => e.ApprovalLevel1Remark)
                    .HasColumnName("APPROVAL_LEVEL1_REMARK")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalLevel2)
                    .HasColumnName("APPROVAL_LEVEL2")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('P')");

                entity.Property(e => e.ApprovalLevel2ById)
                    .HasColumnName("APPROVAL_LEVEL2_BY_ID")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.ApprovalLevel2Date)
                    .HasColumnName("APPROVAL_LEVEL2_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ApprovalLevel2Mcrno).HasColumnName("APPROVAL_LEVEL2_MCRNO");

                entity.Property(e => e.ApprovalLevel2Remark)
                    .HasColumnName("APPROVAL_LEVEL2_REMARK")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalLevel3)
                    .HasColumnName("APPROVAL_LEVEL3")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('P')");

                entity.Property(e => e.ApprovalLevel3ById)
                    .HasColumnName("APPROVAL_LEVEL3_BY_ID")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.ApprovalLevel3Date)
                    .HasColumnName("APPROVAL_LEVEL3_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ApprovalLevel3Mcrno).HasColumnName("APPROVAL_LEVEL3_MCRNO");

                entity.Property(e => e.ApprovalLevel3Remark)
                    .HasColumnName("APPROVAL_LEVEL3_REMARK")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalRemark)
                    .HasColumnName("APPROVAL_REMARK")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ApproveOnlyAddr)
                    .HasColumnName("APPROVE_ONLY_ADDR")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ApprovedById).HasColumnName("APPROVED_BY_ID");

                entity.Property(e => e.Area)
                    .IsRequired()
                    .HasColumnName("AREA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate)
                    .HasColumnName("BIRTH_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CardQuali)
                    .HasColumnName("CARD_QUALI")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CityId).HasColumnName("CITY_ID");

                entity.Property(e => e.ClinicName)
                    .HasColumnName("CLINIC_NAME")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyId).HasColumnName("COMPANY_ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Admin')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Day)
                    .HasColumnName("DAY")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.DrCode)
                    .IsRequired()
                    .HasColumnName("DR_CODE")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EntryCategory)
                    .HasColumnName("ENTRY_CATEGORY")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FinalDrCode)
                    .HasColumnName("FINAL_DR_CODE")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("FIRST_NAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FromTime)
                    .HasColumnName("FROM_TIME")
                    .HasColumnType("decimal(16, 2)");

                entity.Property(e => e.HoApproval)
                    .HasColumnName("HO_APPROVAL")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('P')");

                entity.Property(e => e.HoApprovalById)
                    .HasColumnName("HO_APPROVAL_BY_ID")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.HoApprovalDate)
                    .HasColumnName("HO_APPROVAL_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.HoApprovalRemark)
                    .HasColumnName("HO_APPROVAL_REMARK")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("IMAGE_URL")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastName)
                    .HasColumnName("LAST_NAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.McrNo).HasColumnName("MCR_NO");

                entity.Property(e => e.MiddleName)
                    .HasColumnName("MIDDLE_NAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasColumnName("MOBILE")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Admin')");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OnlyAddrDrCode)
                    .HasColumnName("ONLY_ADDR_DR_CODE")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.OriginalDrCode)
                    .HasColumnName("ORIGINAL_DR_CODE")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.OriginalSpecId).HasColumnName("ORIGINAL_SPEC_ID");

                entity.Property(e => e.PhoneC)
                    .HasColumnName("PHONE_C")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneR)
                    .HasColumnName("PHONE_R")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PinCode)
                    .IsRequired()
                    .HasColumnName("PIN_CODE")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.QualificationId).HasColumnName("QUALIFICATION_ID");

                entity.Property(e => e.RegisterCode)
                    .HasColumnName("REGISTER_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .HasColumnName("REMARK")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.RepId).HasColumnName("REP_ID");

                entity.Property(e => e.SeqNo)
                    .HasColumnName("SEQ_NO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SpecId).HasColumnName("SPEC_ID");

                entity.Property(e => e.StateId).HasColumnName("STATE_ID");

                entity.Property(e => e.ToTime)
                    .HasColumnName("TO_TIME")
                    .HasColumnType("decimal(16, 2)");

                entity.HasOne(d => d.ApprovalLevel1By)
                    .WithMany(p => p.DrMstDraftApprovalLevel1By)
                    .HasForeignKey(d => d.ApprovalLevel1ById)
                    .HasConstraintName("FK_DR_MST_DRAFT_REP_MST1");

                entity.HasOne(d => d.ApprovalLevel2By)
                    .WithMany(p => p.DrMstDraftApprovalLevel2By)
                    .HasForeignKey(d => d.ApprovalLevel2ById)
                    .HasConstraintName("FK_DR_MST_DRAFT_REP_MST2");

                entity.HasOne(d => d.ApprovalLevel3By)
                    .WithMany(p => p.DrMstDraftApprovalLevel3By)
                    .HasForeignKey(d => d.ApprovalLevel3ById)
                    .HasConstraintName("FK_DR_MST_DRAFT_REP_MST3");

                entity.HasOne(d => d.ApprovedBy)
                    .WithMany(p => p.DrMstDraftApprovedBy)
                    .HasForeignKey(d => d.ApprovedById)
                    .HasConstraintName("FK_DR_MST_DRAFT_REP_MST5");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.DrMstDraft)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DR_MST_DRAFT_CITY");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.DrMstDraft)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DR_MST_DRAFT_Company");

                entity.HasOne(d => d.HoApprovalBy)
                    .WithMany(p => p.DrMstDraftHoApprovalBy)
                    .HasForeignKey(d => d.HoApprovalById)
                    .HasConstraintName("FK_DR_MST_DRAFT_REP_MST4");

                entity.HasOne(d => d.OriginalSpec)
                    .WithMany(p => p.DrMstDraftOriginalSpec)
                    .HasForeignKey(d => d.OriginalSpecId)
                    .HasConstraintName("FK_DR_MST_DRAFT_SPECIALITY1");

                entity.HasOne(d => d.Qualification)
                    .WithMany(p => p.DrMstDraft)
                    .HasForeignKey(d => d.QualificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DR_MST_DRAFT_QUALIFICATION");

                entity.HasOne(d => d.Rep)
                    .WithMany(p => p.DrMstDraftRep)
                    .HasForeignKey(d => d.RepId)
                    .HasConstraintName("FK_DR_MST_DRAFT_REP_MST");

                entity.HasOne(d => d.Spec)
                    .WithMany(p => p.DrMstDraftSpec)
                    .HasForeignKey(d => d.SpecId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DR_MST_DRAFT_SPECIALITY");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.DrMstDraft)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DR_MST_DRAFT_STATE");
            });

            modelBuilder.Entity<FamilyDetail>(entity =>
            {
                entity.ToTable("FAMILY_DETAIL", "EMPLOYEE");

                entity.Property(e => e.FamilyDetailId).HasColumnName("FAMILY_DETAIL_ID");

                entity.Property(e => e.BirthDate)
                    .HasColumnName("BIRTH_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FirstName)
                    .HasColumnName("FIRST_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GenderId).HasColumnName("Gender_ID");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastName)
                    .HasColumnName("LAST_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LsmwDate)
                    .HasColumnName("LSMW_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MaritalStatusId).HasColumnName("MARITAL_STATUS_ID");

                entity.Property(e => e.MemberId).HasColumnName("MEMBER_ID");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.NomineeName)
                    .HasColumnName("NOMINEE_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NomineeRelationId).HasColumnName("NOMINEE_RELATION_ID");

                entity.Property(e => e.Reason)
                    .HasColumnName("REASON")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.RepId).HasColumnName("REP_ID");

                entity.Property(e => e.SerialNo).HasColumnName("SERIAL_NO");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.FamilyDetailGender)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK_WSITE_FAMILY_DETAIL_CODE_VALUE");

                entity.HasOne(d => d.MaritalStatus)
                    .WithMany(p => p.FamilyDetailMaritalStatus)
                    .HasForeignKey(d => d.MaritalStatusId)
                    .HasConstraintName("FK_WSITE_FAMILY_DETAIL_CODE_VALUE1");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.FamilyDetailMember)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WSITE_FAMILY_DETAIL_WSITE_MEMBER");

                entity.HasOne(d => d.NomineeRelation)
                    .WithMany(p => p.FamilyDetailNomineeRelation)
                    .HasForeignKey(d => d.NomineeRelationId)
                    .HasConstraintName("FK_WSITE_FAMILY_DETAIL_WSITE_MEMBER1");

                entity.HasOne(d => d.Rep)
                    .WithMany(p => p.FamilyDetail)
                    .HasForeignKey(d => d.RepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WSITE_FAMILY_DETAIL_WSITE_FAMILY_DETAIL");
            });

            modelBuilder.Entity<Headquarter>(entity =>
            {
                entity.ToTable("HEADQUARTER", "MASTER");

                entity.Property(e => e.HeadquarterId).HasColumnName("HEADQUARTER_ID");

                entity.Property(e => e.AreaId).HasColumnName("AREA_ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.HqCode)
                    .IsRequired()
                    .HasColumnName("HQ_CODE")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.HqDesc)
                    .IsRequired()
                    .HasColumnName("HQ_DESC")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ZdHqCode)
                    .HasColumnName("ZD_HQ_CODE")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Headquarter)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HEADQUARTER_AREA");
            });

            modelBuilder.Entity<McrCategory>(entity =>
            {
                entity.ToTable("MCR_CATEGORY", "MASTER");

                entity.Property(e => e.McrCategoryId).HasColumnName("MCR_CATEGORY_ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Admin')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DesigId).HasColumnName("DESIG_ID");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.McrCategory1)
                    .IsRequired()
                    .HasColumnName("MCR_CATEGORY")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Admin')");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Desig)
                    .WithMany(p => p.McrCategory)
                    .HasForeignKey(d => d.DesigId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MCR_CATEGORY_DESIG");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("MEMBER", "MASTER");

                entity.Property(e => e.MemberId).HasColumnName("MEMBER_ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MemberCode)
                    .IsRequired()
                    .HasColumnName("MEMBER_CODE")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MemberDesc)
                    .IsRequired()
                    .HasColumnName("MEMBER_DESC")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("MENU", "MASTER");

                entity.Property(e => e.MenuId).HasColumnName("MENU_ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Admin')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IconReference)
                    .HasColumnName("ICON_REFERENCE")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MenuCode)
                    .IsRequired()
                    .HasColumnName("MENU_CODE")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.MenuDesc)
                    .IsRequired()
                    .HasColumnName("MENU_DESC")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Admin')");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PageReference)
                    .HasColumnName("PAGE_REFERENCE")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ParentMenuId).HasColumnName("PARENT_MENU_ID");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("STATUS")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.ParentMenu)
                    .WithMany(p => p.InverseParentMenu)
                    .HasForeignKey(d => d.ParentMenuId)
                    .HasConstraintName("FK_MENU_MENU1");
            });

            modelBuilder.Entity<MenuGroupRights>(entity =>
            {
                entity.ToTable("MENU_GROUP_RIGHTS", "MASTER");

                entity.HasIndex(e => new { e.CompanyId, e.SbuId, e.MenuGroupId, e.MenuId })
                    .HasName("UC_Person")
                    .IsUnique();

                entity.Property(e => e.MenuGroupRightsId).HasColumnName("MENU_GROUP_RIGHTS_ID");

                entity.Property(e => e.CompanyId).HasColumnName("COMPANY_ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");

                entity.Property(e => e.MenuGroupId)
                    .IsRequired()
                    .HasColumnName("MENU_GROUP_ID")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.MenuId).HasColumnName("MENU_ID");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.RepDeptCode)
                    .HasColumnName("REP_DEPT_CODE")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.SbuId).HasColumnName("SBU_ID");

                entity.Property(e => e.SfaActiveFlag)
                    .HasColumnName("SFA_ACTIVE_FLAG")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.MenuGroupRights)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MENU_GROUP_RIGHTS_COMPANY");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.MenuGroupRights)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MENU_GROUP_RIGHTS_MENU");

                entity.HasOne(d => d.Sbu)
                    .WithMany(p => p.MenuGroupRights)
                    .HasForeignKey(d => d.SbuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MENU_GROUP_RIGHTS_SBU");
            });

            modelBuilder.Entity<Qualification>(entity =>
            {
                entity.ToTable("QUALIFICATION", "MASTER");

                entity.Property(e => e.QualificationId).HasColumnName("QUALIFICATION_ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Admin')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Admin')");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OldQuali)
                    .HasColumnName("OLD_QUALI")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.QualiCode)
                    .IsRequired()
                    .HasColumnName("QUALI_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.QualiDesc)
                    .IsRequired()
                    .HasColumnName("QUALI_DESC")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SpecId).HasColumnName("SPEC_ID");

                entity.HasOne(d => d.Spec)
                    .WithMany(p => p.Qualification)
                    .HasForeignKey(d => d.SpecId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QUALIFICATION_SPECIALITY");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("REGION", "MASTER");

                entity.Property(e => e.RegionId).HasColumnName("REGION_ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.RegionCode)
                    .IsRequired()
                    .HasColumnName("REGION_CODE")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.RegionDesc)
                    .IsRequired()
                    .HasColumnName("REGION_DESC")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ZdRegionCode)
                    .HasColumnName("ZD_REGION_CODE")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.ZoneId).HasColumnName("ZONE_ID");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.Region)
                    .HasForeignKey(d => d.ZoneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REGION_ZONE");
            });

            modelBuilder.Entity<RepMst>(entity =>
            {
                entity.HasKey(e => e.RepId);

                entity.ToTable("REP_MST", "EMPLOYEE");

                entity.Property(e => e.RepId).HasColumnName("REP_ID");

                entity.Property(e => e.AbscondingDate)
                    .HasColumnName("ABSCONDING_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.AbscondingFlag)
                    .IsRequired()
                    .HasColumnName("ABSCONDING_FLAG")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Add1)
                    .HasColumnName("ADD1")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Add2)
                    .HasColumnName("ADD2")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Add3)
                    .HasColumnName("ADD3")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.AlwPerKm)
                    .HasColumnName("ALW_PER_KM")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Area)
                    .HasColumnName("AREA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AreaId).HasColumnName("AREA_ID");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnName("CATEGORY")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CcmailFlag)
                    .IsRequired()
                    .HasColumnName("CCMAIL_FLAG")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CityId).HasColumnName("CITY_ID");

                entity.Property(e => e.CnsCode)
                    .HasColumnName("CNS_CODE")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ConfirmDate)
                    .HasColumnName("CONFIRM_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ConsiderationFlag)
                    .HasColumnName("CONSIDERATION_FLAG")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DcrStartDate)
                    .HasColumnName("DCR_START_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.DemotionDate)
                    .HasColumnName("DEMOTION_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.DesigId).HasColumnName("DESIG_ID");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeTypeId).HasColumnName("Employee_Type_ID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("FIRST_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.HoDesigGrpCode)
                    .HasColumnName("HO_DESIG_GRP_CODE")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.HoldFlag)
                    .HasColumnName("HOLD_FLAG")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.HoldMonth).HasColumnName("HOLD_MONTH");

                entity.Property(e => e.HoldYear).HasColumnName("HOLD_YEAR");

                entity.Property(e => e.HostIpName)
                    .HasColumnName("HOST_IP_NAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HqId).HasColumnName("HQ_ID");

                entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");

                entity.Property(e => e.JoinedDate)
                    .HasColumnName("JOINED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.LaptopSrNo)
                    .HasColumnName("LAPTOP_SR_NO")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("LAST_NAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LockCounter)
                    .HasColumnName("LOCK_COUNTER")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Locked)
                    .IsRequired()
                    .HasColumnName("LOCKED")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.McrCategoryId).HasColumnName("MCR_CATEGORY_ID");

                entity.Property(e => e.MiddleName)
                    .HasColumnName("MIDDLE_NAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasColumnName("MOBILE")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.OrgCompCode)
                    .HasColumnName("ORG_COMP_CODE")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.PartyCode)
                    .HasColumnName("PARTY_CODE")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("PHONE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PinCode)
                    .HasColumnName("PIN_CODE")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.PreDesigCode)
                    .HasColumnName("PRE_DESIG_CODE")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PromotionDate)
                    .HasColumnName("PROMOTION_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Pull)
                    .IsRequired()
                    .HasColumnName("PULL")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Push)
                    .IsRequired()
                    .HasColumnName("PUSH")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RegionId).HasColumnName("REGION_ID");

                entity.Property(e => e.RepCode)
                    .IsRequired()
                    .HasColumnName("REP_CODE")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ResignDate)
                    .HasColumnName("RESIGN_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ResignFlag)
                    .IsRequired()
                    .HasColumnName("RESIGN_FLAG")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ResignFlagDate)
                    .HasColumnName("RESIGN_FLAG_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ResignFlagId)
                    .HasColumnName("RESIGN_FLAG_ID")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.SalaryHold)
                    .HasColumnName("SALARY_HOLD")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SampleHold)
                    .IsRequired()
                    .HasColumnName("SAMPLE_HOLD")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SbuId).HasColumnName("SBU_ID");

                entity.Property(e => e.SmsMktFinAmt)
                    .IsRequired()
                    .HasColumnName("SMS_MKT_FIN_AMT")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SmsPushGroup)
                    .HasColumnName("SMS_PUSH_GROUP")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SmsTotalFlag)
                    .IsRequired()
                    .HasColumnName("SMS_TOTAL_FLAG")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Smsmail)
                    .HasColumnName("SMSMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StateId).HasColumnName("STATE_ID");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("STATUS")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TownTypeId).HasColumnName("TOWN_TYPE_ID");

                entity.Property(e => e.TrinityDesignationCode)
                    .HasColumnName("TRINITY_DESIGNATION_CODE")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.UnlockedTillDate)
                    .HasColumnName("UNLOCKED_TILL_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ZoneId).HasColumnName("ZONE_ID");

                entity.HasOne(d => d.AreaNavigation)
                    .WithMany(p => p.RepMst)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_REP_MST_AREA");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.RepMst)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REP_MST_CITY");

                entity.HasOne(d => d.Desig)
                    .WithMany(p => p.RepMst)
                    .HasForeignKey(d => d.DesigId)
                    .HasConstraintName("FK_REP_MST_DESIG");

                entity.HasOne(d => d.EmployeeType)
                    .WithMany(p => p.RepMst)
                    .HasForeignKey(d => d.EmployeeTypeId)
                    .HasConstraintName("FK_REP_MST_EmployeeType");

                entity.HasOne(d => d.Hq)
                    .WithMany(p => p.RepMst)
                    .HasForeignKey(d => d.HqId)
                    .HasConstraintName("FK_REP_MST_HEADQUARTER");

                entity.HasOne(d => d.McrCategory)
                    .WithMany(p => p.RepMst)
                    .HasForeignKey(d => d.McrCategoryId)
                    .HasConstraintName("FK_REP_MST_MCR_CATEGORY");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.RepMst)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REP_MST_REGION");

                entity.HasOne(d => d.Sbu)
                    .WithMany(p => p.RepMst)
                    .HasForeignKey(d => d.SbuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REP_MST_SBU");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.RepMst)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REP_MST_STATE");

                entity.HasOne(d => d.TownType)
                    .WithMany(p => p.RepMst)
                    .HasForeignKey(d => d.TownTypeId)
                    .HasConstraintName("FK_REP_MST_TOWN_TYPE");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.RepMst)
                    .HasForeignKey(d => d.ZoneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REP_MST_ZONE");
            });

            modelBuilder.Entity<Sbu>(entity =>
            {
                entity.ToTable("SBU", "MASTER");

                entity.Property(e => e.SbuId).HasColumnName("SBU_ID");

                entity.Property(e => e.CompanyId).HasColumnName("COMPANY_ID");

                entity.Property(e => e.CostCenter).HasColumnName("COST_CENTER");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.DisplayOrder).HasColumnName("DISPLAY_ORDER");

                entity.Property(e => e.ExpenseDeptCode)
                    .HasColumnName("EXPENSE_DEPT_CODE")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.FundCenter).HasColumnName("FUND_CENTER");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Isexpenselive)
                    .HasColumnName("ISEXPENSELIVE")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.LeaveProcessFlag)
                    .HasColumnName("LEAVE_PROCESS_FLAG")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.OldSbuCode)
                    .HasColumnName("OLD_SBU_CODE")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.PeriodDay)
                    .HasColumnName("PERIOD_DAY")
                    .HasDefaultValueSql("((3))");

                entity.Property(e => e.RepDeptCode)
                    .HasColumnName("REP_DEPT_CODE")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.RspFlag)
                    .HasColumnName("RSP_FLAG")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SalesCompanyCode)
                    .HasColumnName("SALES_COMPANY_CODE")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Samg2Comp)
                    .HasColumnName("SAMG2_COMP")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.SapDept)
                    .HasColumnName("SAP_DEPT")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SbuCode)
                    .IsRequired()
                    .HasColumnName("SBU_CODE")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.SbuName)
                    .IsRequired()
                    .HasColumnName("SBU_NAME")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SecSalesFlag)
                    .HasColumnName("SEC_SALES_FLAG")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SfaActiveFlag)
                    .HasColumnName("SFA_ACTIVE_FLAG")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ShortName)
                    .HasColumnName("SHORT_NAME")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TrinityActiveFlag)
                    .HasColumnName("TRINITY_ACTIVE_FLAG")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ZydusCompany)
                    .HasColumnName("ZYDUS_COMPANY")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Sbu)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SBU_company");
            });

            modelBuilder.Entity<SecurityQuest>(entity =>
            {
                entity.HasKey(e => e.QuestId);

                entity.ToTable("SECURITY_QUEST", "MASTER");

                entity.Property(e => e.QuestId).HasColumnName("QUEST_ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Admin')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Admin')");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.QuestLine)
                    .IsRequired()
                    .HasColumnName("QUEST_LINE")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Speciality>(entity =>
            {
                entity.ToTable("SPECIALITY", "MASTER");

                entity.Property(e => e.SpecialityId).HasColumnName("SPECIALITY_ID");

                entity.Property(e => e.CompanyId).HasColumnName("COMPANY_ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Admin')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DedupliStatus)
                    .HasColumnName("DEDUPLI_STATUS")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Admin')");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SpecCode)
                    .IsRequired()
                    .HasColumnName("SPEC_CODE")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.SpecDesc)
                    .HasColumnName("SPEC_DESC")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.SpecStatus)
                    .HasColumnName("SPEC_STATUS")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Speciality)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SPECIALITY_COMPANY");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("STATE", "MASTER");

                entity.Property(e => e.StateId).HasColumnName("STATE_ID");

                entity.Property(e => e.CompanyId).HasColumnName("COMPANY_ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.SapStateCode)
                    .HasColumnName("SAP_STATE_CODE")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.StateCode)
                    .IsRequired()
                    .HasColumnName("STATE_CODE")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasColumnName("STATE_NAME")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.TrinityActiveFlag)
                    .HasColumnName("TRINITY_ACTIVE_FLAG")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.WeeklyOff)
                    .HasColumnName("WEEKLY_OFF")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.State)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STATE_company");
            });

            modelBuilder.Entity<TownType>(entity =>
            {
                entity.ToTable("TOWN_TYPE", "MASTER");

                entity.Property(e => e.TownTypeId).HasColumnName("TOWN_TYPE_ID");

                entity.Property(e => e.CompanyId).HasColumnName("COMPANY_ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.TownTypeCode)
                    .IsRequired()
                    .HasColumnName("TOWN_TYPE_CODE")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.TownTypeDesc)
                    .IsRequired()
                    .HasColumnName("TOWN_TYPE_DESC")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.TownType)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TOWN_TYPE_company");
            });

            modelBuilder.Entity<UserHistory>(entity =>
            {
                entity.ToTable("USER_HISTORY", "EMPLOYEE");

                entity.HasIndex(e => new { e.CompanyId, e.SbuId, e.RepId, e.LoginTime })
                    .HasName("UC_USER_HISTORY")
                    .IsUnique();

                entity.Property(e => e.UserHistoryId).HasColumnName("USER_HISTORY_ID");

                entity.Property(e => e.CompanyId).HasColumnName("COMPANY_ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Admin')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.HostIpName)
                    .IsRequired()
                    .HasColumnName("HOST_IP_NAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LoginTime)
                    .HasColumnName("LOGIN_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.LogoutTime)
                    .HasColumnName("LOGOUT_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Admin')");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RepId).HasColumnName("REP_ID");

                entity.Property(e => e.SbuId).HasColumnName("SBU_ID");

                entity.Property(e => e.SeqNo).HasColumnName("SEQ_NO");

                entity.Property(e => e.TotDcr).HasColumnName("TOT_DCR");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.UserHistory)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_HISTORY_COMPANY");

                entity.HasOne(d => d.Rep)
                    .WithMany(p => p.UserHistory)
                    .HasForeignKey(d => d.RepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_HISTORY_REP_MST");

                entity.HasOne(d => d.Sbu)
                    .WithMany(p => p.UserHistory)
                    .HasForeignKey(d => d.SbuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_HISTORY_SBU");
            });

            modelBuilder.Entity<UserMenuGroupRights>(entity =>
            {
                entity.ToTable("USER_MENU_GROUP_RIGHTS", "EMPLOYEE");

                entity.HasIndex(e => new { e.CompanyId, e.SbuId, e.RepId, e.MenuGroupId })
                    .HasName("UC_USER_MENU_GROUP_RIGHTS")
                    .IsUnique();

                entity.Property(e => e.UserMenuGroupRightsId).HasColumnName("USER_MENU_GROUP_RIGHTS_ID");

                entity.Property(e => e.CompanyId).HasColumnName("COMPANY_ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Admin')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MenuGroupId)
                    .IsRequired()
                    .HasColumnName("MENU_GROUP_ID")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Admin')");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RepId).HasColumnName("REP_ID");

                entity.Property(e => e.SbuId).HasColumnName("SBU_ID");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.UserMenuGroupRights)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_MENU_GROUP_RIGHTS_COMPANY");

                entity.HasOne(d => d.Rep)
                    .WithMany(p => p.UserMenuGroupRights)
                    .HasForeignKey(d => d.RepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_MENU_GROUP_RIGHTS_REP_MST");

                entity.HasOne(d => d.Sbu)
                    .WithMany(p => p.UserMenuGroupRights)
                    .HasForeignKey(d => d.SbuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_MENU_GROUP_RIGHTS_SBU");
            });

            modelBuilder.Entity<UserMst>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("USER_MST", "EMPLOYEE");

                entity.HasIndex(e => new { e.CompanyId, e.SbuId, e.RepId })
                    .HasName("UC_user_mst")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.Property(e => e.CompanyId).HasColumnName("COMPANY_ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LockCounter)
                    .HasColumnName("LOCK_COUNTER")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LockTillDate)
                    .HasColumnName("LOCK_TILL_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Admin')");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Psw)
                    .IsRequired()
                    .HasColumnName("PSW")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PswChangeDate)
                    .HasColumnName("PSW_CHANGE_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.RepId).HasColumnName("REP_ID");

                entity.Property(e => e.SbuId).HasColumnName("SBU_ID");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.UserMst)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_MST_COMPANY");

                entity.HasOne(d => d.Rep)
                    .WithMany(p => p.UserMst)
                    .HasForeignKey(d => d.RepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_MST_REP_MST");

                entity.HasOne(d => d.Sbu)
                    .WithMany(p => p.UserMst)
                    .HasForeignKey(d => d.SbuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_MST_SBU");
            });

            modelBuilder.Entity<UserSecurityQuest>(entity =>
            {
                entity.ToTable("USER_SECURITY_QUEST", "EMPLOYEE");

                entity.Property(e => e.UserSecurityQuestId).HasColumnName("USER_SECURITY_QUEST_ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Admin')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Admin')");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.QuestAns)
                    .IsRequired()
                    .HasColumnName("QUEST_ANS")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.QuestId).HasColumnName("QUEST_ID");

                entity.Property(e => e.RepId).HasColumnName("REP_ID");

                entity.HasOne(d => d.Quest)
                    .WithMany(p => p.UserSecurityQuest)
                    .HasForeignKey(d => d.QuestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_SECURITY_QUEST_SECURITY_QUEST");

                entity.HasOne(d => d.Rep)
                    .WithMany(p => p.UserSecurityQuest)
                    .HasForeignKey(d => d.RepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_SECURITY_QUEST_REP_MST");
            });

            modelBuilder.Entity<UserZrahGroup>(entity =>
            {
                entity.ToTable("USER_ZRAH_GROUP", "EMPLOYEE");

                entity.HasIndex(e => new { e.CompanyId, e.SbuId, e.RepId, e.GeoGroupId })
                    .HasName("UC_USER_ZRAH_GROUP")
                    .IsUnique();

                entity.Property(e => e.UserZrahGroupId).HasColumnName("USER_ZRAH_GROUP_ID");

                entity.Property(e => e.CompanyId).HasColumnName("COMPANY_ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Admin')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GeoGroupId)
                    .IsRequired()
                    .HasColumnName("GEO_GROUP_ID")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Admin')");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RepId).HasColumnName("REP_ID");

                entity.Property(e => e.SbuId).HasColumnName("SBU_ID");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("STATUS")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.UserZrahGroup)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_ZRAH_GROUP_COMPANY");

                entity.HasOne(d => d.Rep)
                    .WithMany(p => p.UserZrahGroup)
                    .HasForeignKey(d => d.RepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_ZRAH_GROUP_REP_MST");

                entity.HasOne(d => d.Sbu)
                    .WithMany(p => p.UserZrahGroup)
                    .HasForeignKey(d => d.SbuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_ZRAH_GROUP_SBU");
            });

            modelBuilder.Entity<Zone>(entity =>
            {
                entity.ToTable("ZONE", "MASTER");

                entity.Property(e => e.ZoneId).HasColumnName("ZONE_ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.SbuId).HasColumnName("SBU_ID");

                entity.Property(e => e.ZdZoneCode)
                    .HasColumnName("ZD_ZONE_CODE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ZoneCode)
                    .IsRequired()
                    .HasColumnName("ZONE_CODE")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.ZoneDesc)
                    .IsRequired()
                    .HasColumnName("ZONE_DESC")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Sbu)
                    .WithMany(p => p.Zone)
                    .HasForeignKey(d => d.SbuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ZONE_SBU");
            });

            modelBuilder.Entity<ZrahGroupRights>(entity =>
            {
                entity.ToTable("ZRAH_GROUP_RIGHTS", "EMPLOYEE");

                entity.HasIndex(e => new { e.CompanyId, e.SbuId, e.GeoGroupId, e.ZoneId, e.RegionId, e.AreaId, e.HqId, e.RcompId, e.RsbuId })
                    .HasName("UC_ZRAH_GROUP_RIGHTS")
                    .IsUnique();

                entity.Property(e => e.ZrahGroupRightsId).HasColumnName("ZRAH_GROUP_RIGHTS_ID");

                entity.Property(e => e.AreaId)
                    .IsRequired()
                    .HasColumnName("AREA_ID")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyId).HasColumnName("COMPANY_ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Admin')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GeoGroupDesc)
                    .HasColumnName("GEO_GROUP_DESC")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.GeoGroupId)
                    .IsRequired()
                    .HasColumnName("GEO_GROUP_ID")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.HqId)
                    .IsRequired()
                    .HasColumnName("HQ_ID")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Admin')");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("MODIFIED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OldGeogroupId)
                    .HasColumnName("OLD_GEOGROUP_ID")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.RcompId)
                    .IsRequired()
                    .HasColumnName("RCOMP_ID")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.RegionId)
                    .IsRequired()
                    .HasColumnName("REGION_ID")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.RsbuId)
                    .IsRequired()
                    .HasColumnName("RSBU_ID")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.SbuId).HasColumnName("SBU_ID");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("STATUS")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ZoneId)
                    .IsRequired()
                    .HasColumnName("ZONE_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.ZrahGroupRights)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ZRAH_GROUP_RIGHTS_COMPANY");

                entity.HasOne(d => d.Sbu)
                    .WithMany(p => p.ZrahGroupRights)
                    .HasForeignKey(d => d.SbuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ZRAH_GROUP_RIGHTS_SBU");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
