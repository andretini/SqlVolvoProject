using System;
using System.Collections.Generic;

namespace Projeto_SQL.Model;

public partial class Gasto
{
    public int IdGasto { get; set; }

    public int? Quantidade { get; set; }

    public bool? EntregaQuarto { get; set; }

    public int? FkReservaIdReserva { get; set; }

    public int? FkProdutosIdProduto { get; set; }

    public int? FkServicosLavanderiaIdLavagem { get; set; }

    public virtual Produto? FkProdutosIdProdutoNavigation { get; set; }

    public virtual Reserva? FkReservaIdReservaNavigation { get; set; }

    public virtual ServicosLavanderium? FkServicosLavanderiaIdLavagemNavigation { get; set; }
}
