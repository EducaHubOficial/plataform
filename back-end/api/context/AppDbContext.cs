using Microsoft.EntityFrameworkCore;

namespace api.Model;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acesso> Acessos { get; set; }

    public virtual DbSet<AcessosGrupo> AcessosGrupos { get; set; }

    public virtual DbSet<AcessosUsuario> AcessosUsuarios { get; set; }

    public virtual DbSet<Grupo> Grupos { get; set; }

    public virtual DbSet<GruposUsuario> GruposUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acesso>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("id");
            entity.Property(e => e.DataCadastro)
                .HasColumnType("datetime")
                .HasColumnName("dataCadastro");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.UsuarioResponsavel)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("usuarioResponsavel");

            entity.HasOne(d => d.UsuarioResponsavelNavigation).WithMany(p => p.Acessos)
                .HasForeignKey(d => d.UsuarioResponsavel)
                .HasConstraintName("FK_Acessos_Usuarios");
        });

        modelBuilder.Entity<AcessosGrupo>(entity =>
        {
            entity.HasKey(e => new { e.AcessosId, e.GruposId });

            entity.Property(e => e.AcessosId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("acessosId");
            entity.Property(e => e.GruposId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("gruposId");
            entity.Property(e => e.DataLancamento)
                .HasColumnType("datetime")
                .HasColumnName("dataLancamento");
            entity.Property(e => e.UsuarioResponsavel)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("usuarioResponsavel");

            entity.HasOne(d => d.Acessos).WithMany(p => p.AcessosGrupos)
                .HasForeignKey(d => d.AcessosId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AcessosGrupos_Acessos");

            entity.HasOne(d => d.UsuarioResponsavelNavigation).WithMany(p => p.AcessosGrupos)
                .HasForeignKey(d => d.UsuarioResponsavel)
                .HasConstraintName("FK_AcessosGrupos_Usuarios");
        });

        modelBuilder.Entity<AcessosUsuario>(entity =>
        {
            entity.HasKey(e => new { e.AcessosId, e.UsuariosId });

            entity.Property(e => e.AcessosId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("acessosId");
            entity.Property(e => e.UsuariosId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("usuariosId");
            entity.Property(e => e.DataLancamento)
                .HasColumnType("datetime")
                .HasColumnName("dataLancamento");
            entity.Property(e => e.UsuarioResponsavel)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("usuarioResponsavel");

            entity.HasOne(d => d.Acessos).WithMany(p => p.AcessosUsuarios)
                .HasForeignKey(d => d.AcessosId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AcessosUsuarios_Acessos");

            entity.HasOne(d => d.UsuarioResponsavelNavigation).WithMany(p => p.AcessosUsuarioUsuarioResponsavelNavigations)
                .HasForeignKey(d => d.UsuarioResponsavel)
                .HasConstraintName("FK_AcessosUsuarios_Usuarios1");

            entity.HasOne(d => d.Usuarios).WithMany(p => p.AcessosUsuarioUsuarios)
                .HasForeignKey(d => d.UsuariosId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AcessosUsuarios_Usuarios");
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("id");
            entity.Property(e => e.DataCadastro)
                .HasColumnType("datetime")
                .HasColumnName("dataCadastro");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.UsuarioResponsavel)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("usuarioResponsavel");

            entity.HasOne(d => d.UsuarioResponsavelNavigation).WithMany(p => p.Grupos)
                .HasForeignKey(d => d.UsuarioResponsavel)
                .HasConstraintName("FK_Grupos_Usuarios");
        });

        modelBuilder.Entity<GruposUsuario>(entity =>
        {
            entity.HasKey(e => new { e.GruposId, e.UsuariosId });

            entity.Property(e => e.GruposId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("gruposId");
            entity.Property(e => e.UsuariosId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("usuariosId");
            entity.Property(e => e.DataCadastro)
                .HasColumnType("datetime")
                .HasColumnName("dataCadastro");
            entity.Property(e => e.UsuarioResponsavel)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("usuarioResponsavel");

            entity.HasOne(d => d.Grupos).WithMany(p => p.GruposUsuarios)
                .HasForeignKey(d => d.GruposId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GruposUsuarios_Grupos");

            entity.HasOne(d => d.UsuarioResponsavelNavigation).WithMany(p => p.GruposUsuarioUsuarioResponsavelNavigations)
                .HasForeignKey(d => d.UsuarioResponsavel)
                .HasConstraintName("FK_GruposUsuarios_Usuarios1");

            entity.HasOne(d => d.Usuarios).WithMany(p => p.GruposUsuarioUsuarios)
                .HasForeignKey(d => d.UsuariosId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GruposUsuarios_Usuarios");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasComment("Identificação do usuário")
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("id");
            entity.Property(e => e.DataCadastro)
                .HasColumnType("datetime")
                .HasColumnName("dataCadastro");
            entity.Property(e => e.DataNascimento)
                .HasColumnType("date")
                .HasColumnName("dataNascimento");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Hash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("hash");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Salt)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("salt");
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sexo");
            entity.Property(e => e.Tratamento)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tratamento");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
