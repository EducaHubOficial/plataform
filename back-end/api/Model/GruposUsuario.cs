using System;
using System.Collections.Generic;

namespace api.Model;

public partial class GruposUsuario
{
    public decimal GruposId { get; set; }

    public decimal UsuariosId { get; set; }

    public DateTime? DataCadastro { get; set; }

    public decimal? UsuarioResponsavel { get; set; }

    public virtual Grupo Grupos { get; set; } = null!;

    public virtual Usuario? UsuarioResponsavelNavigation { get; set; }

    public virtual Usuario Usuarios { get; set; } = null!;
}
