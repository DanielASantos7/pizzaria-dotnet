using System;
using System.Collections.Generic;

namespace Pizzaria.API.Domain.Entities;

public partial class Iten
{
    public Guid Id { get; set; }

    public int Quantidade { get; set; }

    public Guid PedidoId { get; set; }

    public Guid ProdutoId { get; set; }

    public DateTime CriadoEm { get; set; }

    public DateTime AtualizadoEm { get; set; }

    public virtual Pedido Pedido { get; set; } = null!;

    public virtual Produto Produto { get; set; } = null!;
}
