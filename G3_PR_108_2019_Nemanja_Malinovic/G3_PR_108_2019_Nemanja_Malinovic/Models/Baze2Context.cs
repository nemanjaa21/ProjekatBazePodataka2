using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace G3_PR_108_2019_Nemanja_Malinovic.Models;

public partial class Baze2Context : DbContext
{
    public Baze2Context()
    {
    }

    public Baze2Context(DbContextOptions<Baze2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Clan> Clans { get; set; }

    public virtual DbSet<Grupa> Grupas { get; set; }

    public virtual DbSet<IzdavackaKuca> IzdavackaKucas { get; set; }

    public virtual DbSet<Izvodjac> Izvodjacs { get; set; }

    public virtual DbSet<Korisnik> Korisniks { get; set; }

    public virtual DbSet<MuzickiAlbum> MuzickiAlbums { get; set; }

    public virtual DbSet<Numera> Numeras { get; set; }

    public virtual DbSet<PlayListum> PlayLista { get; set; }

    public virtual DbSet<SoloIzvodjac> SoloIzvodjacs { get; set; }

    public virtual DbSet<Zanr> Zanrs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=baze2;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clan>(entity =>
        {
            entity.HasKey(e => e.IdCl).HasName("PK__Clan__B77390AF9D0B4DBF");

            entity.ToTable("Clan");

            entity.Property(e => e.IdCl).ValueGeneratedNever();
            entity.Property(e => e.Uloga)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdIzvNavigation).WithMany(p => p.Clans)
                .HasForeignKey(d => d.IdIzv)
                .HasConstraintName("FK__Clan__IdIzv__1EA48E88");
        });

        modelBuilder.Entity<Grupa>(entity =>
        {
            entity.HasKey(e => e.IdIzv).HasName("PK__Grupa__0C1B5EE21D5C0773");

            entity.ToTable("Grupa");

            entity.Property(e => e.IdIzv).ValueGeneratedNever();
            entity.Property(e => e.BrNg).HasColumnName("BrNG");

            entity.HasOne(d => d.IdIzvNavigation).WithOne(p => p.Grupa)
                .HasForeignKey<Grupa>(d => d.IdIzv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Grupa__IdIzv__1BC821DD");
        });

        modelBuilder.Entity<IzdavackaKuca>(entity =>
        {
            entity.HasKey(e => e.IdK).HasName("PK__Izdavack__C496000BB8B15A5F");

            entity.ToTable("IzdavackaKuca");

            entity.Property(e => e.IdK).ValueGeneratedNever();
            entity.Property(e => e.DatumOsn).HasColumnType("date");
            entity.Property(e => e.NazivK)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Izvodjac>(entity =>
        {
            entity.HasKey(e => e.IdIzv).HasName("PK__Izvodjac__0C1B5EE20557B063");

            entity.ToTable("Izvodjac");

            entity.Property(e => e.IdIzv).ValueGeneratedNever();
            entity.Property(e => e.DatumPocetka).HasColumnType("date");
            entity.Property(e => e.ImeIzv)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Korisnik>(entity =>
        {
            entity.HasKey(e => e.IdKorisnika).HasName("PK__Korisnik__703CA70A4E9757D1");

            entity.ToTable("Korisnik");

            entity.Property(e => e.IdKorisnika).ValueGeneratedNever();
            entity.Property(e => e.Ime)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.KorisnickoIme)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Lozinka)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Prezime)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MuzickiAlbum>(entity =>
        {
            entity.HasKey(e => e.IdM).HasName("PK__MuzickiA__C496000952F1AA4A");

            entity.ToTable("MuzickiAlbum");

            entity.Property(e => e.IdM).ValueGeneratedNever();
            entity.Property(e => e.DatumIzM).HasColumnType("date");

            entity.HasOne(d => d.IdKNavigation).WithMany(p => p.MuzickiAlbums)
                .HasForeignKey(d => d.IdK)
                .HasConstraintName("FK__MuzickiAlbu__IdK__1332DBDC");
        });

        modelBuilder.Entity<Numera>(entity =>
        {
            entity.HasKey(e => new { e.IdNum, e.IdIzv }).HasName("PK__Numera__3D116AE5FB1F23D0");

            entity.ToTable("Numera");

            entity.Property(e => e.DatumIz).HasColumnType("date");
            entity.Property(e => e.NazivN)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdIzvNavigation).WithMany(p => p.Numeras)
                .HasForeignKey(d => d.IdIzv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Numera__IdIzv__160F4887");

            entity.HasMany(d => d.IdZs).WithMany(p => p.Ids)
                .UsingEntity<Dictionary<string, object>>(
                    "ImaZanr",
                    r => r.HasOne<Zanr>().WithMany()
                        .HasForeignKey("IdZ")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ImaZanr__IdZ__245D67DE"),
                    l => l.HasOne<Numera>().WithMany()
                        .HasForeignKey("IdNum", "IdIzv")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ImaZanr__236943A5"),
                    j =>
                    {
                        j.HasKey("IdNum", "IdIzv", "IdZ").HasName("PK__ImaZanr__20D5FCE5FBBD786F");
                        j.ToTable("ImaZanr");
                    });
        });

        modelBuilder.Entity<PlayListum>(entity =>
        {
            entity.HasKey(e => e.IdPlay).HasName("PK__PlayList__FB810293CB8B589C");

            entity.Property(e => e.IdPlay).ValueGeneratedNever();
            entity.Property(e => e.NazivPl)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdKorisnikaNavigation).WithMany(p => p.PlayLista)
                .HasForeignKey(d => d.IdKorisnika)
                .HasConstraintName("FK__PlayLista__IdKor__29221CFB");

            entity.HasMany(d => d.Ids).WithMany(p => p.IdPlays)
                .UsingEntity<Dictionary<string, object>>(
                    "SadrziPlayNum",
                    r => r.HasOne<Numera>().WithMany()
                        .HasForeignKey("IdNum", "IdIzv")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__SadrziPlayNum__2CF2ADDF"),
                    l => l.HasOne<PlayListum>().WithMany()
                        .HasForeignKey("IdPlay")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__SadrziPla__IdPla__2BFE89A6"),
                    j =>
                    {
                        j.HasKey("IdPlay", "IdNum", "IdIzv").HasName("PK__SadrziPl__B850143D9925C23C");
                        j.ToTable("SadrziPlayNum");
                    });
        });

        modelBuilder.Entity<SoloIzvodjac>(entity =>
        {
            entity.HasKey(e => e.IdIzv).HasName("PK__SoloIzvo__0C1B5EE22A0CC4F0");

            entity.ToTable("SoloIzvodjac");

            entity.Property(e => e.IdIzv).ValueGeneratedNever();
            entity.Property(e => e.BrNs).HasColumnName("BrNS");

            entity.HasOne(d => d.IdIzvNavigation).WithOne(p => p.SoloIzvodjac)
                .HasForeignKey<SoloIzvodjac>(d => d.IdIzv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SoloIzvod__IdIzv__18EBB532");
        });

        modelBuilder.Entity<Zanr>(entity =>
        {
            entity.HasKey(e => e.IdZ).HasName("PK__Zanr__C496001CF6FA0232");

            entity.ToTable("Zanr");

            entity.Property(e => e.IdZ).ValueGeneratedNever();
            entity.Property(e => e.ImeZ)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Vek)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
