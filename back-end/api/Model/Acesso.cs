using System;
using System.Collections.Generic;

namespace api.Model;

public partial class Acesso
{
    public decimal Id { get; set; }

    public string? Nome { get; set; }

    public DateTime? DataCadastro { get; set; }

    public decimal? UsuarioResponsavel { get; set; }

    public virtual ICollection<AcessosGrupo> AcessosGrupos { get; set; } = new List<AcessosGrupo>();

    public virtual ICollection<AcessosUsuario> AcessosUsuarios { get; set; } = new List<AcessosUsuario>();

    public virtual Usuario? UsuarioResponsavelNavigation { get; set; }
}
