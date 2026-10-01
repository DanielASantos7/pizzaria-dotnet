using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzaria.API.DTOs.Categorias;
using Pizzaria.API.Infrastructure.Data;

namespace Pizzaria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriaController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Endpoint para obter todas as categorias
        /// </summary>
        /// <param name="cancellation">
        /// sinalizador .NET para interrompaer operações assíncronas que já não são mais necessarias
        /// Ex: Um front-end fez essa requisição e o usuário cancelou ou perdeu conexão 100 milissegundos depois
        /// o servidor ficaria processando e alocando memória.
        /// Com o CancellationToken o EF Core aborta imediatamente a execução da instrução SQL e encerra a Task.
        /// </param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaResponseDto>>> ObterTodas(CancellationToken cancellation)
        {
            var categorias = await _context.Categorias
                .AsNoTracking()
                .Select(c => new CategoriaResponseDto(c.Id, c.Nome, c.CriadoEm))
                .ToListAsync(cancellation);

            return Ok(categorias);
        }

    }
}
