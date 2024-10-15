using Interfocus.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
namespace ApiCrud.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcorrenciaController : ControllerBase
    {
        private static List<Ocorrencia> ocorrencias = new List<Ocorrencia>();

        [HttpGet]
        public ActionResult<IEnumerable<Ocorrencia>> Get()
        {
            return Ok(ocorrencias);
        }

        [HttpGet("{id:guid}")]
        public ActionResult<Ocorrencia> Get(Guid id)
        {
            var ocorrencia = ocorrencias.FirstOrDefault(o => o.Id == id);
            if (ocorrencia == null) return NotFound();
            return Ok(ocorrencia);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Ocorrencia ocorrencia)
        {
            ocorrencias.Add(ocorrencia);
            return Ok();
        }

        [HttpPut("{id:guid}")]
        public ActionResult Put(Guid id, [FromBody] Ocorrencia ocorrencia)
        {
            var oldOcorrencia = ocorrencias.FirstOrDefault(o => o.Id == id);
            if (oldOcorrencia == null) return NotFound();

            oldOcorrencia.Descricao = ocorrencia.Descricao;
            oldOcorrencia.Anexo = ocorrencia.Anexo;

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public ActionResult Delete(Guid id)
        {
            var ocorrencia = ocorrencias.FirstOrDefault(o => o.Id == id);
            if (ocorrencia == null) return NotFound();

            ocorrencias.Remove(ocorrencia);
            return Ok();
        }
    }
}