using Microsoft.EntityFrameworkCore;
using Plato.MDM.Models;

namespace Plato.MDM.Data;

public partial class MdmSystemContext : DbContext
{
    public MdmSystemContext()
    {
    }

    public MdmSystemContext(DbContextOptions<MdmSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MdmDirectory> MdmDirectories { get; set; }

    public virtual DbSet<MdmDirectoryDomain> MdmDirectoryDomains { get; set; }

    public virtual DbSet<MdmDirectoryLevel> MdmDirectoryLevels { get; set; }

    public virtual DbSet<MdmDirectoryVersion> MdmDirectoryVersions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=MDM-system;Username=postgres;Password=admin");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<MdmDirectory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mdm_Directory_pkey");

            entity.ToTable("mdm_Directory");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.DirectoryDomain).WithMany(p => p.MdmDirectories)
                .HasForeignKey(d => d.DirectoryDomainId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mdm_Directory_DirectoryDomainId_fkey");

            entity.HasOne(d => d.DirectoryLevel).WithMany(p => p.MdmDirectories)
                .HasForeignKey(d => d.DirectoryLevelId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mdm_Directory_DirectoryLevelId_fkey");
        });

        modelBuilder.Entity<MdmDirectoryDomain>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mdm_DirectoryDomain_pkey");

            entity.ToTable("mdm_DirectoryDomain");

            entity.HasIndex(e => e.Name, "mdm_DirectoryDomain_Name_key").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<MdmDirectoryLevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mdm_DirectoryLevel_pkey");

            entity.ToTable("mdm_DirectoryLevel");

            entity.HasIndex(e => e.Name, "mdm_DirectoryLevel_Name_key").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<MdmDirectoryVersion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mdm_DirectoryVersion_pkey");

            entity.ToTable("mdm_DirectoryVersion");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.Version).HasMaxLength(50);
            entity.Property(e => e.VersionDate).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Directory).WithMany(p => p.MdmDirectoryVersions)
                .HasForeignKey(d => d.DirectoryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("mdm_DirectoryVersion_DirectoryId_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
