using System;
using System.Collections.Generic;

namespace Projeto_SQL.Model;

public partial class Reserva
{
    public int IdReserva { get; set; }

    public DateTime? DataReserva { get; set; }

    public bool? ColchaoAdicional { get; set; }

    public int? FkClienteIdCliente { get; set; }

    public int? FkFuncionariosIdFuncionario { get; set; }

    public int? FkQuartosIdQuarto { get; set; }

    public int? FkFilialIdFilial { get; set; }

    public virtual Cliente? FkClienteIdClienteNavigation { get; set; }

    public virtual Filial? FkFilialIdFilialNavigation { get; set; }

    public virtual Funcionario? FkFuncionariosIdFuncionarioNavigation { get; set; }

    public virtual Quarto? FkQuartosIdQuartoNavigation { get; set; }

    public virtual ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();
}
