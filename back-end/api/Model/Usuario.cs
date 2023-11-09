using System;
using System.Collections.Generic;

namespace api.Model;

public partial class Usuario
{
    /// <summary>
    /// Identificação do usuário
    /// </summary>
    public decimal Id { get; set; }

    public string? Nome { get; set; }

    public string? Tratamento { get; set; }

    public DateTime? DataNascimento { get; set; }

    public DateTime? DataCadastro { get; set; }

    public string? Sexo { get; set; }

    public string? Email { get; set; }

    public string? Salt { get; set; }

    public string? Hash { get; set; }

    public virtual ICollection<Acesso> Acessos { get; set; } = new List<Acesso>();

    public virtual ICollection<AcessosGrupo> AcessosGrupos { get; set; } = new List<AcessosGrupo>();

    public virtual ICollection<AcessosUsuario> AcessosUsuarioUsuarioResponsavelNavigations { get; set; } = new List<AcessosUsuario>();

    public virtual ICollection<AcessosUsuario> AcessosUsuarioUsuarios { get; set; } = new List<AcessosUsuario>();

    public virtual ICollection<Aula> Aulas { get; set; } = new List<Aula>();

    public virtual ICollection<Grupo> Grupos { get; set; } = new List<Grupo>();

    public virtual ICollection<GruposUsuario> GruposUsuarioUsuarioResponsavelNavigations { get; set; } = new List<GruposUsuario>();

    public virtual ICollection<GruposUsuario> GruposUsuarioUsuarios { get; set; } = new List<GruposUsuario>();

    public virtual ICollection<Materia> Materia { get; set; } = new List<Materia>();
}
