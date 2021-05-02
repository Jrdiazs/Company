using Company.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.Data
{
    public partial class CompanyDatabaseContext : DbContext
    {
        public CompanyDatabaseContext()
        {
        }

        public CompanyDatabaseContext(DbContextOptions<CompanyDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LanguageApp> LanguageApps { get; set; }
        public virtual DbSet<LogApp> LogApps { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<ParametersApp> ParametersApps { get; set; }
        public virtual DbSet<RolMenu> RolMenus { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Third> Thirds { get; set; }
        public virtual DbSet<ThirdType> ThirdTypes { get; set; }
        public virtual DbSet<TypeIdentification> TypeIdentifications { get; set; }
        public virtual DbSet<UserApp> UserApps { get; set; }
        public virtual DbSet<UserInfoDetail> UserInfoDetails { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserStatus> UserStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<LanguageApp>(entity =>
            {
                entity.HasKey(e => e.LanguageId);

                entity.ToTable("LanguageApp");

                entity.Property(e => e.CodeHtmlLanguage).HasMaxLength(50);

                entity.Property(e => e.CodeLanguage)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.DescriptionLanguage)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LogApp>(entity =>
            {
                entity.HasKey(e => e.IdLog);

                entity.ToTable("LogApp");

                entity.Property(e => e.IdLog).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExceptionLog)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.LeveLog)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Logger)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MessagLog)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.ThreadLog)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("Menu");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.MenuClass).HasMaxLength(50);

                entity.Property(e => e.MenuName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MenuUrl).HasMaxLength(50);

                entity.HasOne(d => d.MenuParent)
                    .WithMany(p => p.InverseMenuParent)
                    .HasForeignKey(d => d.MenuParentId)
                    .HasConstraintName("FK_Menu_MenuParentId");
            });

            modelBuilder.Entity<ParametersApp>(entity =>
            {
                entity.HasKey(e => e.ParameterId);

                entity.ToTable("ParametersApp");

                entity.Property(e => e.ParameterId).ValueGeneratedNever();

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.ParameterDescription).HasMaxLength(100);

                entity.Property(e => e.ParameterKey)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ValueDateTime).HasColumnType("datetime");

                entity.Property(e => e.ValueString).IsUnicode(false);
            });

            modelBuilder.Entity<RolMenu>(entity =>
            {
                entity.ToTable("RolMenu");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.RolMenus)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolMenu_Menu");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.RolMenus)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolMenu_Roles");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RolId);

                entity.Property(e => e.RolId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.RolDescription)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Third)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.ThirdId)
                    .HasConstraintName("FK_Roles_Third");
            });

            modelBuilder.Entity<Third>(entity =>
            {
                entity.ToTable("Third");

                entity.Property(e => e.ThirdId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.ThirdDocument).HasMaxLength(50);

                entity.Property(e => e.ThirdName).HasMaxLength(100);

                entity.Property(e => e.ThirdTradeName).HasMaxLength(100);

                entity.HasOne(d => d.ThirdType)
                    .WithMany(p => p.Thirds)
                    .HasForeignKey(d => d.ThirdTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Third_ThirdType");

                entity.HasOne(d => d.ThirdTypeIdentification)
                    .WithMany(p => p.Thirds)
                    .HasForeignKey(d => d.ThirdTypeIdentificationId)
                    .HasConstraintName("FK_Third_TypeIdentification");
            });

            modelBuilder.Entity<ThirdType>(entity =>
            {
                entity.ToTable("ThirdType");

                entity.Property(e => e.ThirdTypeDescription)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TypeIdentification>(entity =>
            {
                entity.ToTable("TypeIdentification");

                entity.Property(e => e.TypeIdentificationAlias).HasMaxLength(50);

                entity.Property(e => e.TypeIdentificationDescription)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<UserApp>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("UserApp");

                entity.HasIndex(e => e.UserName, "UNIQUE_UserName")
                    .IsUnique();

                entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.LastAdmissionDate).HasColumnType("datetime");

                entity.Property(e => e.Pw).HasMaxLength(500);

                entity.Property(e => e.UserMail)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.UserApps)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_UserApp_LanguageApp");

                entity.HasOne(d => d.UserStatus)
                    .WithMany(p => p.UserApps)
                    .HasForeignKey(d => d.UserStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserApp_UserStatus");
            });

            modelBuilder.Entity<UserInfoDetail>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("UserInfoDetail");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.AlternateEmail).HasMaxLength(300);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.DocumentUser).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(201)
                    .HasComputedColumnSql("(concat([FirstName],' ',[LastName]))", false);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.HasOne(d => d.TypeIdentification)
                    .WithMany(p => p.UserInfoDetails)
                    .HasForeignKey(d => d.TypeIdentificationId)
                    .HasConstraintName("FK_UserInfoDetail_TypeIdentification");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserInfoDetail)
                    .HasForeignKey<UserInfoDetail>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserInfoDetail_UserApp");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.UserRolId);

                entity.Property(e => e.UserRolId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRoles_Roles");

                entity.HasOne(d => d.Third)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.ThirdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRoles_Third");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRoles_UserApp");
            });

            modelBuilder.Entity<UserStatus>(entity =>
            {
                entity.ToTable("UserStatus");

                entity.Property(e => e.UserStatusAlias)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserStatusDescriptions)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}