using System;
using System.Collections.Generic;

namespace api.Model;

public partial class Materia
{
    public decimal Id { get; set; }

    public string? Titulo { get; set; }

    public DateTime? DataCadastro { get; set; }

    public decimal? UsuariosId { get; set; }

    public virtual ICollection<Aula> Aulas { get; set; } = new List<Aula>();

    public virtual Usuario? Usuarios { get; set; }
}
