using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiCrud.src.Data;
using ApiCrud.src.Entidades;

namespace ApiCrud.src.Controller
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdemServico>>> Get()
        {
            var ordensServico = await _context.OrdensServico
                .ToListAsync();

            return Ok(ordensServico);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<OrdemServico>> Get(int id)
        {
            var ordemServico = await _context.OrdensServico
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

            var statusOS = await _context.StatusOS.FindAsync(ordemServico.IdStatusOS);
            if (statusOS == null)
            {
                return NotFound($"StatusOS com ID {ordemServico.IdStatusOS} não encontrado.");
            }

            _context.OrdensServico.Add(ordemServico);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = ordemServico.Id }, ordemServico);
        }

        // PUT: api/OrdemServico/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] OrdemServico ordemServico)
        {
            var ordemExistente = await _context.OrdensServico
                .FirstOrDefaultAsync(os => os.Id == id);

            if (ordemExistente == null)
            {
                return NotFound();
            }

            ordemExistente.IdCliente = ordemServico.IdCliente;
            ordemExistente.IdTipoServico = ordemServico.IdTipoServico;
            ordemExistente.DataAgendamento = ordemServico.DataAgendamento;

            if (ordemServico.IdStatusOS != ordemExistente.IdStatusOS)
            {
                var statusOS = await _context.StatusOS.FindAsync(ordemServico.IdStatusOS);
                if (statusOS == null)
                {
                    return NotFound($"StatusOS com ID {ordemServico.IdStatusOS} não encontrado.");
                }

                ordemExistente.IdStatusOS = ordemServico.IdStatusOS;
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
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
