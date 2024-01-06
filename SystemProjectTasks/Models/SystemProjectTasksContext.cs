using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SystemProjectTasks.Models;

public partial class SystemProjectTasksContext : DbContext
{
    public SystemProjectTasksContext()
    {
    }

    public SystemProjectTasksContext(DbContextOptions<SystemProjectTasksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectUser> ProjectUsers { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.IdProject).HasName("PRIMARY");

            entity.ToTable("project");

            entity.Property(e => e.IdProject).HasColumnName("id_project");
            entity.Property(e => e.DescriptionP)
                .HasMaxLength(100)
                .HasColumnName("descriptionP");
            entity.Property(e => e.NameP)
                .HasMaxLength(50)
                .HasColumnName("nameP");
            entity.Property(e => e.StatusP)
                .HasDefaultValueSql("'0'")
                .HasColumnName("statusP");
        });

        modelBuilder.Entity<ProjectUser>(entity =>
        {
            entity.HasKey(e => e.IdProjectUser).HasName("PRIMARY");

            entity.ToTable("project_user");

            entity.HasIndex(e => e.IdProjectFk, "id_project_fk");

            entity.HasIndex(e => e.IdUserFx, "id_user_fx");

            entity.Property(e => e.IdProjectUser).HasColumnName("id_project_user");
            entity.Property(e => e.IdProjectFk).HasColumnName("id_project_fk");
            entity.Property(e => e.IdUserFx).HasColumnName("id_user_fx");

            entity.HasOne(d => d.IdProjectFkNavigation).WithMany(p => p.ProjectUsers)
                .HasForeignKey(d => d.IdProjectFk)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("project_user_ibfk_1");

            entity.HasOne(d => d.IdUserFxNavigation).WithMany(p => p.ProjectUsers)
                .HasForeignKey(d => d.IdUserFx)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("project_user_ibfk_2");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.IdTask).HasName("PRIMARY");

            entity.ToTable("task");

            entity.HasIndex(e => e.IdProjectFk, "id_project_fk");

            entity.HasIndex(e => e.IdUserFx, "id_user_fx");

            entity.Property(e => e.IdTask).HasColumnName("id_task");
            entity.Property(e => e.DescriptionT)
                .HasMaxLength(100)
                .HasColumnName("descriptionT");
            entity.Property(e => e.DueDate)
                .HasDefaultValueSql("'curdate()'")
                .HasColumnType("date")
                .HasColumnName("due_date");
            entity.Property(e => e.IdProjectFk).HasColumnName("id_project_fk");
            entity.Property(e => e.IdUserFx).HasColumnName("id_user_fx");
            entity.Property(e => e.NameT)
                .HasMaxLength(50)
                .HasColumnName("nameT");
            entity.Property(e => e.Priority)
                .HasDefaultValueSql("'0'")
                .HasColumnName("priority");
            entity.Property(e => e.StatusP)
                .HasDefaultValueSql("'0'")
                .HasColumnName("statusP");

            entity.HasOne(d => d.IdProjectFkNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.IdProjectFk)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("task_ibfk_1");

            entity.HasOne(d => d.IdUserFxNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.IdUserFx)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("task_ibfk_2");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.NameU)
                .HasMaxLength(50)
                .HasColumnName("nameU");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
