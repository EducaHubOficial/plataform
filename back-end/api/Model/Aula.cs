using System;
using System.Collections.Generic;

namespace api.Model;

public partial class Aula
{
    public decimal MateriasId { get; set; }

    public decimal Id { get; set; }

    public string? Conteudo { get; set; }

    public DateTime? DataCadastro { get; set; }

    public decimal? UsuariosId { get; set; }

    public virtual Usuario IdNavigation { get; set; } = null!;

    public virtual Materia Materias { get; set; } = null!;
}
