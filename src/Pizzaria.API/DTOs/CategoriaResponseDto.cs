namespace Pizzaria.API.DTOs.Categorias;

public record CategoriaResponseDto
(
    Guid Id,
    string Nome,
    DateTime CriadoEm
);