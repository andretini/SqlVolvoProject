using System;
using System.Collections.Generic;

namespace Projeto_SQL.Model;

public partial class ServicosLavanderium
{
    public int IdLavagem { get; set; }

    public string? NomeLavagem { get; set; }

    public double? ValorLavagem { get; set; }

    public int? FkFilialIdFilial { get; set; }

    public virtual Filial? FkFilialIdFilialNavigation { get; set; }

    public virtual ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();
}
