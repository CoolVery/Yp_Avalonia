using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace YP.Models;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activety> Activeties { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Direction> Directions { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<ImagesCity> ImagesCities { get; set; }

    public virtual DbSet<JuryDirection> JuryDirections { get; set; }

    public virtual DbSet<ModeratorsDirectionsEvent> ModeratorsDirectionsEvents { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<ScheduleActivetiesInEvent> ScheduleActivetiesInEvents { get; set; }

    public virtual DbSet<ScheduleActivetiesJury> ScheduleActivetiesJuries { get; set; }

    public virtual DbSet<ScheduleEvent> ScheduleEvents { get; set; }

    public virtual DbSet<TypesEvent> TypesEvents { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=YP;Username=postgres;Password=123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activety>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("activeties_pkey");

            entity.ToTable("activeties");

            entity.HasIndex(e => e.Name, "activeties_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cities_pkey");

            entity.ToTable("cities");

            entity.HasIndex(e => e.Name, "cities_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("countries_pkey");

            entity.ToTable("countries");

            entity.HasIndex(e => e.Code, "countries_code_key").IsUnique();

            entity.HasIndex(e => e.EnName, "countries_en_name_key").IsUnique();

            entity.HasIndex(e => e.Name, "countries_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.CodeSecond).HasColumnName("code_second");
            entity.Property(e => e.EnName).HasColumnName("en_name");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Direction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("directions_pkey");

            entity.ToTable("directions");

            entity.HasIndex(e => e.Name, "directions_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("events_pkey");

            entity.ToTable("events");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateStart).HasColumnName("date_start");
            entity.Property(e => e.Days).HasColumnName("days");
            entity.Property(e => e.IdCity).HasColumnName("id_city");
            entity.Property(e => e.IdTypeEvent).HasColumnName("id_type_event");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Name).HasColumnName("name");

            entity.HasOne(d => d.IdCityNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdCity)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_event_id");

            entity.HasOne(d => d.IdTypeEventNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdTypeEvent)
                .HasConstraintName("events_types_events_fk");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("genders_pkey");

            entity.ToTable("genders");

            entity.HasIndex(e => e.Name, "genders_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<ImagesCity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("images_cities_pk");

            entity.ToTable("images_cities");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCity).HasColumnName("id_city");
            entity.Property(e => e.Image).HasColumnName("image");

            entity.HasOne(d => d.IdCityNavigation).WithMany(p => p.ImagesCities)
                .HasForeignKey(d => d.IdCity)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("images_cities_cities_fk");
        });

        modelBuilder.Entity<JuryDirection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("jury_directions_pkey");

            entity.ToTable("jury_directions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdDirection).HasColumnName("id_direction");
            entity.Property(e => e.IdUserJury).HasColumnName("id_user_jury");

            entity.HasOne(d => d.IdDirectionNavigation).WithMany(p => p.JuryDirections)
                .HasForeignKey(d => d.IdDirection)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_direction_id");

            entity.HasOne(d => d.IdUserJuryNavigation).WithMany(p => p.JuryDirections)
                .HasForeignKey(d => d.IdUserJury)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_user_id");
        });

        modelBuilder.Entity<ModeratorsDirectionsEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("moderators_directions_events_pkey");

            entity.ToTable("moderators_directions_events");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdDirection).HasColumnName("id_direction");
            entity.Property(e => e.IdTypeEvent).HasColumnName("id_type_event");
            entity.Property(e => e.IdUserModerator).HasColumnName("id_user_moderator");

            entity.HasOne(d => d.IdDirectionNavigation).WithMany(p => p.ModeratorsDirectionsEvents)
                .HasForeignKey(d => d.IdDirection)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_direction_id");

            entity.HasOne(d => d.IdTypeEventNavigation).WithMany(p => p.ModeratorsDirectionsEvents)
                .HasForeignKey(d => d.IdTypeEvent)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_event_id");

            entity.HasOne(d => d.IdUserModeratorNavigation).WithMany(p => p.ModeratorsDirectionsEvents)
                .HasForeignKey(d => d.IdUserModerator)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_user_id");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.HasIndex(e => e.Name, "roles_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<ScheduleActivetiesInEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("schedule_activeties_in_events_pk");

            entity.ToTable("schedule_activeties_in_events");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Day).HasColumnName("day");
            entity.Property(e => e.IdActivity).HasColumnName("id_activity");
            entity.Property(e => e.IdModeratorUser).HasColumnName("id_moderator_user");
            entity.Property(e => e.IdScheduleEvent).HasColumnName("id_schedule_event");
            entity.Property(e => e.TimeStart).HasColumnName("time_start");

            entity.HasOne(d => d.IdActivityNavigation).WithMany(p => p.ScheduleActivetiesInEvents)
                .HasForeignKey(d => d.IdActivity)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("schedule_activeties_in_events_activeties_fk");

            entity.HasOne(d => d.IdModeratorUserNavigation).WithMany(p => p.ScheduleActivetiesInEvents)
                .HasForeignKey(d => d.IdModeratorUser)
                .HasConstraintName("schedule_activeties_in_events_users_fk");

            entity.HasOne(d => d.IdScheduleEventNavigation).WithMany(p => p.ScheduleActivetiesInEvents)
                .HasForeignKey(d => d.IdScheduleEvent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("schedule_activeties_in_events_schedule_events_fk");
        });

        modelBuilder.Entity<ScheduleActivetiesJury>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("schedule_activeties_moderators_jury_pk");

            entity.ToTable("schedule_activeties_jury");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdJuryUser).HasColumnName("id_jury_user");
            entity.Property(e => e.IdScheduleActivity).HasColumnName("id_schedule_activity");

            entity.HasOne(d => d.IdJuryUserNavigation).WithMany(p => p.ScheduleActivetiesJuries)
                .HasForeignKey(d => d.IdJuryUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("schedule_activeties_jury_users_fk_1");

            entity.HasOne(d => d.IdScheduleActivityNavigation).WithMany(p => p.ScheduleActivetiesJuries)
                .HasForeignKey(d => d.IdScheduleActivity)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("schedule_activeties_jury_schedule_activeties_in_events_fk");
        });

        modelBuilder.Entity<ScheduleEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("events_activities_pkey");

            entity.ToTable("schedule_events");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Day).HasColumnName("day");
            entity.Property(e => e.IdEvent).HasColumnName("id_event");
            entity.Property(e => e.IdWinnerUser).HasColumnName("id_winner_user");

            entity.HasOne(d => d.IdEventNavigation).WithMany(p => p.ScheduleEvents)
                .HasForeignKey(d => d.IdEvent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("schedule_events_events_fk");

            entity.HasOne(d => d.IdWinnerUserNavigation).WithMany(p => p.ScheduleEvents)
                .HasForeignKey(d => d.IdWinnerUser)
                .HasConstraintName("schedule_events_users_fk");
        });

        modelBuilder.Entity<TypesEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("types_events_pk");

            entity.ToTable("types_events");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.FullName).HasColumnName("full_name");
            entity.Property(e => e.IdCountry).HasColumnName("id_country");
            entity.Property(e => e.IdGender).HasColumnName("id_gender");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.Photo).HasColumnName("photo");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdCountry)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_country_id");

            entity.HasOne(d => d.IdGenderNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdGender)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_gender_id");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_roles_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
