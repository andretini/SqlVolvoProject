using System;
using System.Collections.Generic;

namespace Projeto_SQL.Model;

public partial class TipoFuncionario
{
    public int IdProficao { get; set; }

    public string? Profissao { get; set; }

    public virtual ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
}
