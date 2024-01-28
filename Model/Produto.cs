using System;
using System.Collections.Generic;

namespace Projeto_SQL.Model;

public partial class Produto
{
    public int IdProduto { get; set; }

    public string? NomeProduto { get; set; }

    public double? ValorProduto { get; set; }

    public int? FkFilialIdFilial { get; set; }

    public virtual Filial? FkFilialIdFilialNavigation { get; set; }

    public virtual ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();
}
