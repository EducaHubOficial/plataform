using System;
using System.Collections.Generic;

namespace api.Model;

public partial class AcessosGrupo
{
    public decimal AcessosId { get; set; }

    public decimal GruposId { get; set; }

    public DateTime? DataLancamento { get; set; }

    public decimal? UsuarioResponsavel { get; set; }

    public virtual Acesso Acessos { get; set; } = null!;

    public virtual Usuario? UsuarioResponsavelNavigation { get; set; }
}
