using System;
using System.Collections.Generic;

namespace Projeto_SQL.Model;

public partial class Quarto
{
    public int IdQuarto { get; set; }

    public double? Preco { get; set; }

    public int? FkFilialIdFilial { get; set; }

    public int? FkTipoQuartoIdPlanta { get; set; }

    public virtual Filial? FkFilialIdFilialNavigation { get; set; }

    public virtual TipoQuarto? FkTipoQuartoIdPlantaNavigation { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
