using System;
using System.Collections.Generic;

namespace Projeto_SQL.Model;

public partial class Filial
{
    public int IdFilial { get; set; }

    public string? Nome { get; set; }

    public string? Endereco { get; set; }

    public int? NumeroDeQuartos { get; set; }

    public int? Avaliacao { get; set; }

    public virtual ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();

    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();

    public virtual ICollection<Quarto> Quartos { get; set; } = new List<Quarto>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    public virtual ICollection<ServicosLavanderium> ServicosLavanderia { get; set; } = new List<ServicosLavanderium>();
}
