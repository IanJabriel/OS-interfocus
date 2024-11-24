using Interfocus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiCrud.Data;


namespace ApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdemServicoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdemServicoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ordemservico
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdemServico>>> Get()
        {
            var ordensServico = await _context.OrdensServico
                .Include(os => os.StatusOS)
                .ToListAsync();
            return Ok(ordensServico);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<OrdemServico>> Get(Guid id)
        {
            var ordemServico = await _context.OrdensServico
                .Include(os => os.StatusOS)  
                .FirstOrDefaultAsync(os => os.Id == id);

            if (ordemServico == null)
            {
                return NotFound();  
            }

            return Ok(ordemServico);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] OrdemServico ordemServico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ordemServico.DataAgendamento = DateTime.UtcNow;

            ordemServico.StatusOS = new StatusOS
            {
                Descricao = "Aberto"
            };

            ordemServico.IdStatusOS = ordemServico.StatusOS.Id;

            _context.OrdensServico.Add(ordemServico);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = ordemServico.Id }, ordemServico);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] OrdemServico ordemServico)
        {
            var ordemExistente = await _context.OrdensServico.FindAsync(id);
            if (ordemExistente == null)
            {
                return NotFound();
            }


            ordemExistente.IdCliente = ordemServico.IdCliente;
            ordemExistente.IdTipoServico = ordemServico.IdTipoServico;
            ordemExistente.IdStatusOS = ordemServico.IdStatusOS;
            ordemExistente.DataAgendamento = ordemServico.DataAgendamento;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var ordemServico = await _context.OrdensServico.FindAsync(id);
            if (ordemServico == null)
            {
                return NotFound();
            }

            _context.OrdensServico.Remove(ordemServico);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
