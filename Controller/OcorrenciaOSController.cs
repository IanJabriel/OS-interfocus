using ApiCrud.Data;
using Interfocus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcorrenciaOSController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OcorrenciaOSController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> Get()
        {
            var ocorrenciasOS = await _context.OcorrenciasOS
                .Select(o => new
                {
                    o.Id,
                    o.IdOrdemServico,
                    o.IdOcorrencia
                })
                .ToListAsync();

            return Ok(ocorrenciasOS);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<object>> Get(Guid id)
        {
            var ocorrenciaOS = await _context.OcorrenciasOS
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync();

            if (ocorrenciaOS == null) return NotFound();

            var response = new
            {
                ocorrenciaOS.Id,
                ocorrenciaOS.IdOrdemServico,
                ocorrenciaOS.IdOcorrencia
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<object>> Post([FromBody] OcorrenciaOS ocorrenciaOS)
        {
            if (ocorrenciaOS == null)
            {
                return BadRequest("OcorrenciaOS não pode ser nulo.");
            }

            _context.OcorrenciasOS.Add(ocorrenciaOS);
            await _context.SaveChangesAsync();

            var response = new
            {
                ocorrenciaOS.Id,
                ocorrenciaOS.IdOrdemServico,
                ocorrenciaOS.IdOcorrencia
            };

            return CreatedAtAction(nameof(Get), new { id = ocorrenciaOS.Id }, response);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] OcorrenciaOS ocorrenciaOS)
        {
            if (id != ocorrenciaOS.Id)
            {
                return BadRequest("ID da URL e do corpo da requisição não coincidem.");
            }

            var oldOcorrenciaOS = await _context.OcorrenciasOS.FindAsync(id);
            if (oldOcorrenciaOS == null)
            {
                return NotFound();
            }

            oldOcorrenciaOS.IdOrdemServico = ocorrenciaOS.IdOrdemServico;
            oldOcorrenciaOS.IdOcorrencia = ocorrenciaOS.IdOcorrencia;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "Erro ao atualizar a ocorrência no banco de dados.");
            }

            var response = new
            {
                oldOcorrenciaOS.Id,
                oldOcorrenciaOS.IdOrdemServico,
                oldOcorrenciaOS.IdOcorrencia
            };

            return Ok(response);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var ocorrenciaOS = await _context.OcorrenciasOS.FindAsync(id);
            if (ocorrenciaOS == null) return NotFound();

            _context.OcorrenciasOS.Remove(ocorrenciaOS);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
