using System;
using System.Collections.Generic;

namespace Projeto_SQL.Model;

public partial class TipoQuarto
{
    public int IdPlanta { get; set; }

    public string? Descricao { get; set; }

    public int? Capacidade { get; set; }

    public virtual ICollection<Quarto> Quartos { get; set; } = new List<Quarto>();
}
