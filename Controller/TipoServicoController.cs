using ApiCrud.src.Data;
using ApiCrud.src.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.src.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoServicoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TipoServicoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> Get()
        {
            var tipoServicos = await _context.TiposServico
                .Select(t => new
                {
                    t.Id,
                    t.Descricao,
                    t.StatusCt
                })
                .ToListAsync();

            return Ok(tipoServicos);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<object>> Get(int id)
        {
            var tipoServico = await _context.TiposServico
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();

            if (tipoServico == null)
                return NotFound();

            var response = new
            {
                tipoServico.Id,
                tipoServico.Descricao,
                tipoServico.StatusCt
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<object>> Post([FromBody] TipoServico tipoServico)
        {
            if (tipoServico == null)
            {
                return BadRequest("TipoServico não pode ser nulo.");
            }

            _context.TiposServico.Add(tipoServico);
            await _context.SaveChangesAsync();

            var response = new
            {
                tipoServico.Id,
                tipoServico.Descricao,
                tipoServico.StatusCt
            };

            return CreatedAtAction(nameof(Get), new { id = tipoServico.Id }, response);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(int id, [FromBody] TipoServico tipoServico)
        {
            if (id != tipoServico.Id)
            {
                return BadRequest("ID da URL e do corpo da requisição não coincidem.");
            }

            var oldTipoServico = await _context.TiposServico.FindAsync(id);
            if (oldTipoServico == null)
            {
                return NotFound();
            }

            oldTipoServico.Descricao = tipoServico.Descricao;
            oldTipoServico.StatusCt = tipoServico.StatusCt;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "Erro ao atualizar o tipo de serviço no banco de dados.");
            }

            var response = new
            {
                oldTipoServico.Id,
                oldTipoServico.Descricao,
                oldTipoServico.StatusCt
            };

            return Ok(response);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var tipoServico = await _context.TiposServico.FindAsync(id);
            if (tipoServico == null)
            {
                return NotFound();
            }

            _context.TiposServico.Remove(tipoServico);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
