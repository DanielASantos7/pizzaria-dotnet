using System;
using System.Collections.Generic;

namespace Pizzaria.API.Domain.Entities;

public partial class Categoria
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = null!;

    public DateTime CriadoEm { get; set; }

    public DateTime AtualizadoEm { get; set; }

    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
