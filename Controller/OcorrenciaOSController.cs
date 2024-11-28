using Microsoft.AspNetCore.Mvc;
using Interfocus.Models;

using Microsoft.EntityFrameworkCore;
using ApiCrud.Data;

namespace Interfocus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OcorrenciaOSController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OcorrenciaOSController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/OcorrenciaOS
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ocorrencias = await _context.OcorrenciasOS.ToListAsync();
            return Ok(ocorrencias);
        }

        // GET: api/OcorrenciaOS/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ocorrencia = await _context.OcorrenciasOS.FindAsync(id);

            if (ocorrencia == null) return NotFound();
            return Ok(ocorrencia);
        }

        [HttpPost]
        public ActionResult Post([FromBody] OcorrenciaOS request)
        {
            var ordemServico = _context.OrdensServico.SingleOrDefault(os => os.Id == request.IdOrdemServico);
            if (ordemServico == null)
            {
                return NotFound("Ordem de Serviço não encontrada.");
            }

            var ocorrencia = _context.Ocorrencias.SingleOrDefault(o => o.Id == request.IdOcorrencia);
            if (ocorrencia == null)
            {
                return NotFound("Ocorrência não encontrada.");
            }

            var ocorrenciaOS = new OcorrenciaOS
            {
                IdOrdemServico = request.IdOrdemServico,
                IdOcorrencia = request.IdOcorrencia
            };

            _context.OcorrenciasOS.Add(ocorrenciaOS);
            _context.SaveChanges();

            return Ok("Associação criada com sucesso.");
        }



        // PUT: api/OcorrenciaOS/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OcorrenciaOS ocorrencia)
        {
            if (id != ocorrencia.Id) return BadRequest();

            _context.Entry(ocorrencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.OcorrenciasOS.Any(e => e.Id == id)) return NotFound();
                throw;
            }

            return NoContent();
        }

        // DELETE: api/OcorrenciaOS/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ocorrencia = await _context.OcorrenciasOS.FindAsync(id);
            if (ocorrencia == null) return NotFound();

            _context.OcorrenciasOS.Remove(ocorrencia);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
