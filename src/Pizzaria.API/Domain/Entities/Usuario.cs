using System;
using System.Collections.Generic;

namespace Pizzaria.API.Domain.Entities;

public partial class Usuario
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public DateTime CriadoEm { get; set; }

    public DateTime AtualizadoEm { get; set; }
}
