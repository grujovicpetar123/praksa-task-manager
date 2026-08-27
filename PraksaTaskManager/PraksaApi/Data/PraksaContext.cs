using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PraksaApi.Models;

namespace PraksaApi.Data;

public partial class PraksaContext : DbContext
{
    public PraksaContext(DbContextOptions<PraksaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Komentari> Komentari { get; set; }

    public virtual DbSet<Korisnici> Korisnici { get; set; }

    public virtual DbSet<Prioriteti> Prioriteti { get; set; }

    public virtual DbSet<Projekti> Projekti { get; set; }

    public virtual DbSet<Status> Statusi { get; set; }

    public virtual DbSet<Zadaci> Zadaci { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Komentari>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("komentari_pk");

            entity.ToTable("komentari");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.DatumKreiranja)
                .HasDefaultValueSql("now()")
                .HasColumnName("datum_kreiranja");
            entity.Property(e => e.KorisnikId).HasColumnName("korisnik_id");
            entity.Property(e => e.Tekst)
                .HasColumnType("character varying")
                .HasColumnName("tekst");
            entity.Property(e => e.ZadatakId).HasColumnName("zadatak_id");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.Komentaris)
                .HasForeignKey(d => d.KorisnikId)
                .HasConstraintName("komentari.korisnik_id");

            entity.HasOne(d => d.Zadatak).WithMany(p => p.Komentaris)
                .HasForeignKey(d => d.ZadatakId)
                .HasConstraintName("komentari.zadaci_id");
        });

        modelBuilder.Entity<Korisnici>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("korisnici_pk");

            entity.ToTable("korisnici");

            entity.HasIndex(e => e.Email, "korisnici_unique").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Aktivan)
                .HasDefaultValue(true)
                .HasColumnName("aktivan");
            entity.Property(e => e.DatumKreiranja)
                .HasDefaultValueSql("now()")
                .HasColumnName("datum_kreiranja");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.Ime)
                .HasColumnType("character varying")
                .HasColumnName("ime");
            entity.Property(e => e.Prezime)
                .HasColumnType("character varying")
                .HasColumnName("prezime");
        });

        modelBuilder.Entity<Prioriteti>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("prioriteti_pk");

            entity.ToTable("prioriteti");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Naziv)
                .HasColumnType("character varying")
                .HasColumnName("naziv");
        });

        modelBuilder.Entity<Projekti>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("projekti_pk");

            entity.ToTable("projekti");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Aktivan)
                .HasDefaultValue(true)
                .HasColumnName("aktivan");
            entity.Property(e => e.DatumKreiranja)
                .HasDefaultValueSql("now()")
                .HasColumnName("datum_kreiranja");
            entity.Property(e => e.Naziv)
                .HasColumnType("character varying")
                .HasColumnName("naziv");
            entity.Property(e => e.Opis)
                .HasColumnType("character varying")
                .HasColumnName("opis");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("status_pk");

            entity.ToTable("status");

            entity.Property(e => e.StatusId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("status_id");
            entity.Property(e => e.Naziv)
                .HasColumnType("character varying")
                .HasColumnName("naziv");
        });

        modelBuilder.Entity<Zadaci>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("zadaci_pk");

            entity.ToTable("zadaci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DatumKreiranja)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datum_kreiranja");
            entity.Property(e => e.KorisnikId).HasColumnName("korisnik_id");
            entity.Property(e => e.Naziv)
                .HasColumnType("character varying")
                .HasColumnName("naziv");
            entity.Property(e => e.Opis)
                .HasColumnType("character varying")
                .HasColumnName("opis");
            entity.Property(e => e.PrioritetId).HasColumnName("prioritet_id");
            entity.Property(e => e.ProjektiId).HasColumnName("projekti_id");
            entity.Property(e => e.Rok).HasColumnName("rok");
            entity.Property(e => e.StatusId).HasColumnName("status_id");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.Zadacis)
                .HasForeignKey(d => d.KorisnikId)
                .HasConstraintName("zadaci_korisnici_fk");

            entity.HasOne(d => d.Prioritet).WithMany(p => p.Zadacis)
                .HasForeignKey(d => d.PrioritetId)
                .HasConstraintName("zadaci.prioriteti.id");

            entity.HasOne(d => d.Projekti).WithMany(p => p.Zadacis)
                .HasForeignKey(d => d.ProjektiId)
                .HasConstraintName("zadaci.projekti_id");

            entity.HasOne(d => d.Status).WithMany(p => p.Zadacis)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("zadaci.status_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
