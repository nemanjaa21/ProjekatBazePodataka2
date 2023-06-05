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

    public virtual DbSet<ImaZanr> ImaZanrs { get; set; }

    public virtual DbSet<IzdavackaKuca> IzdavackaKucas { get; set; }

    public virtual DbSet<Izvodjac> Izvodjacs { get; set; }

    public virtual DbSet<Korisnik> Korisniks { get; set; }

    public virtual DbSet<MuzickiAlbum> MuzickiAlbums { get; set; }

    public virtual DbSet<Numera> Numeras { get; set; }

    public virtual DbSet<PlayListum> PlayLista { get; set; }

    public virtual DbSet<SadrziPlayNum> SadrziPlayNums { get; set; }

    public virtual DbSet<SoloIzvodjac> SoloIzvodjacs { get; set; }

    public virtual DbSet<Zanr> Zanrs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=baze2;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clan>(entity =>
        {
            entity.HasKey(e => e.IdCl).HasName("PK__Clan__B77390AF7489363F");

            entity.ToTable("Clan");

            entity.Property(e => e.IdCl).ValueGeneratedNever();
            entity.Property(e => e.Uloga)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdIzvNavigation).WithMany(p => p.Clans)
                .HasForeignKey(d => d.IdIzv)
                .HasConstraintName("FK__Clan__IdIzv__075714DC");
        });

        modelBuilder.Entity<Grupa>(entity =>
        {
            entity.HasKey(e => e.IdIzv).HasName("PK__Grupa__0C1B5EE250A15008");

            entity.ToTable("Grupa");

            entity.Property(e => e.IdIzv).ValueGeneratedNever();
            entity.Property(e => e.BrNg).HasColumnName("BrNG");

            entity.HasOne(d => d.IdIzvNavigation).WithOne(p => p.Grupa)
                .HasForeignKey<Grupa>(d => d.IdIzv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Grupa__IdIzv__047AA831");
        });

        modelBuilder.Entity<ImaZanr>(entity =>
        {
            entity.HasKey(e => e.IdImaZanr).HasName("IMAZ_PK");

            entity.ToTable("ImaZanr");

            entity.HasIndex(e => new { e.IdNum, e.IdIzv, e.IdZ }, "IMAZ_UN").IsUnique();

            entity.HasOne(d => d.IdZNavigation).WithMany(p => p.ImaZanrs)
                .HasForeignKey(d => d.IdZ)
                .HasConstraintName("FK__ImaZanr__IdZ__0E04126B");

            entity.HasOne(d => d.Id).WithMany(p => p.ImaZanrs)
                .HasForeignKey(d => new { d.IdNum, d.IdIzv })
                .HasConstraintName("FK__ImaZanr__0D0FEE32");
        });

        modelBuilder.Entity<IzdavackaKuca>(entity =>
        {
            entity.HasKey(e => e.IdK).HasName("PK__Izdavack__C496000BC5735FBF");

            entity.ToTable("IzdavackaKuca");

            entity.Property(e => e.IdK).ValueGeneratedNever();
            entity.Property(e => e.DatumOsn).HasColumnType("date");
            entity.Property(e => e.NazivK)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Izvodjac>(entity =>
        {
            entity.HasKey(e => e.IdIzv).HasName("PK__Izvodjac__0C1B5EE293F06ACC");

            entity.ToTable("Izvodjac");

            entity.Property(e => e.IdIzv).ValueGeneratedNever();
            entity.Property(e => e.DatumPocetka).HasColumnType("date");
            entity.Property(e => e.ImeIzv)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Korisnik>(entity =>
        {
            entity.HasKey(e => e.IdKorisnika).HasName("PK__Korisnik__703CA70A79F6A621");

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
            entity.HasKey(e => e.IdM).HasName("PK__MuzickiA__C496000960AF24A3");

            entity.ToTable("MuzickiAlbum");

            entity.Property(e => e.IdM).ValueGeneratedNever();
            entity.Property(e => e.DatumIzM).HasColumnType("date");

            entity.HasOne(d => d.IdKNavigation).WithMany(p => p.MuzickiAlbums)
                .HasForeignKey(d => d.IdK)
                .HasConstraintName("FK__MuzickiAlbu__IdK__7BE56230");
        });

        modelBuilder.Entity<Numera>(entity =>
        {
            entity.HasKey(e => new { e.IdNum, e.IdIzv }).HasName("PK__Numera__3D116AE52236DB19");

            entity.ToTable("Numera");

            entity.Property(e => e.DatumIz).HasColumnType("date");
            entity.Property(e => e.NazivN)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdIzvNavigation).WithMany(p => p.Numeras)
                .HasForeignKey(d => d.IdIzv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Numera__IdIzv__7EC1CEDB");
        });

        modelBuilder.Entity<PlayListum>(entity =>
        {
            entity.HasKey(e => e.IdPlay).HasName("PK__PlayList__FB810293AE7DE927");

            entity.Property(e => e.IdPlay).ValueGeneratedNever();
            entity.Property(e => e.NazivPl)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdKorisnikaNavigation).WithMany(p => p.PlayLista)
                .HasForeignKey(d => d.IdKorisnika)
                .HasConstraintName("FK__PlayLista__IdKor__12C8C788");
        });

        modelBuilder.Entity<SadrziPlayNum>(entity =>
        {
            entity.HasKey(e => e.IdPlayNum).HasName("SADRZIPN_PK");

            entity.ToTable("SadrziPlayNum");

            entity.HasIndex(e => new { e.IdPlay, e.IdNum, e.IdIzv }, "SADRZIPN_UN").IsUnique();

            entity.HasOne(d => d.IdPlayNavigation).WithMany(p => p.SadrziPlayNums)
                .HasForeignKey(d => d.IdPlay)
                .HasConstraintName("FK__SadrziPla__IdPla__1699586C");

            entity.HasOne(d => d.Id).WithMany(p => p.SadrziPlayNums)
                .HasForeignKey(d => new { d.IdNum, d.IdIzv })
                .HasConstraintName("FK__SadrziPlayNum__178D7CA5");
        });

        modelBuilder.Entity<SoloIzvodjac>(entity =>
        {
            entity.HasKey(e => e.IdIzv).HasName("PK__SoloIzvo__0C1B5EE2A468601A");

            entity.ToTable("SoloIzvodjac");

            entity.Property(e => e.IdIzv).ValueGeneratedNever();
            entity.Property(e => e.BrNs).HasColumnName("BrNS");

            entity.HasOne(d => d.IdIzvNavigation).WithOne(p => p.SoloIzvodjac)
                .HasForeignKey<SoloIzvodjac>(d => d.IdIzv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SoloIzvod__IdIzv__019E3B86");
        });

        modelBuilder.Entity<Zanr>(entity =>
        {
            entity.HasKey(e => e.IdZ).HasName("PK__Zanr__C496001C5CAC4665");

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
