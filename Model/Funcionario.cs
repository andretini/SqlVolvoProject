using System;
using System.Collections.Generic;

namespace Projeto_SQL.Model;

public partial class Funcionario
{
    public int IdFuncionario { get; set; }

    public string? NomeFuncionario { get; set; }

    public int? FkFilialIdFilial { get; set; }

    public int? FkTipoFuncionarioIdProficao { get; set; }

    public virtual Filial? FkFilialIdFilialNavigation { get; set; }

    public virtual TipoFuncionario? FkTipoFuncionarioIdProficaoNavigation { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
