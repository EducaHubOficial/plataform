using System;
using System.Collections.Generic;

namespace api.Model;

public partial class Grupo
{
    public decimal Id { get; set; }

    public string? Nome { get; set; }

    public DateTime? DataCadastro { get; set; }

    public decimal? UsuarioResponsavel { get; set; }

    public virtual ICollection<GruposUsuario> GruposUsuarios { get; set; } = new List<GruposUsuario>();

    public virtual Usuario? UsuarioResponsavelNavigation { get; set; }
}
