using System;
using System.Collections.Generic;

namespace Pizzaria.API.Domain.Entities;

public partial class Pedido
{
    public Guid Id { get; set; }

    public int Mesa { get; set; }

    public bool Status { get; set; }

    public bool Rascunho { get; set; }

    public string? NomeCliente { get; set; }

    public DateTime CriadoEm { get; set; }

    public DateTime AtualizadoEm { get; set; }

    public virtual ICollection<Iten> Itens { get; set; } = new List<Iten>();
}
