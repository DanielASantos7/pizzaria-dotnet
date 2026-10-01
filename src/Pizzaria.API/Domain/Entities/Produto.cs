using System;
using System.Collections.Generic;

namespace Pizzaria.API.Domain.Entities;

public partial class Produto
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = null!;

    public decimal Preco { get; set; }

    public string Descricao { get; set; } = null!;

    public string Banner { get; set; } = null!;

    public Guid CategoriaId { get; set; }

    public DateTime CriadoEm { get; set; }

    public DateTime AtualizadoEm { get; set; }

    public virtual Categoria Categoria { get; set; } = null!;

    public virtual ICollection<Iten> Itens { get; set; } = new List<Iten>();
}
