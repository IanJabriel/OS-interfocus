using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiCrud.src.Data;
using ApiCrud.src.Entidades;

namespace ApiCrud.src.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusOSController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StatusOSController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusOS>>> Get()
        {
            var statusList = await _context.StatusOS.ToListAsync();
            return Ok(statusList);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<StatusOS>> Get(int id)
        {
            var status = await _context.StatusOS.FindAsync(id);

            if (status == null)
            {
                return NotFound();
            }

            return Ok(status);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] StatusOS statusOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.StatusOS.Add(statusOS);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = statusOS.Id }, statusOS);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] StatusOS statusOS)
        {
            var statusExistente = await _context.StatusOS.FindAsync(id);

            if (statusExistente == null)
            {
                return NotFound();
            }

            statusExistente.Descricao = statusOS.Descricao ?? statusExistente.Descricao;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var statusOS = await _context.StatusOS.FindAsync(id);
            if (statusOS == null)
            {
                return NotFound();
            }

            _context.StatusOS.Remove(statusOS);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
