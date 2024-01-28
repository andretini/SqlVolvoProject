using System;
using System.Collections.Generic;

namespace Projeto_SQL.Model;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? NomeCliente { get; set; }

    public string? Endereco { get; set; }

    public string? Nacionalidade { get; set; }

    public string? Telefone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
