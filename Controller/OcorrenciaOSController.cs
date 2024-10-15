using Interfocus.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class OcorrenciaOSController : ControllerBase
{
    private static List<OcorrenciaOS> ocorrenciasOS = new List<OcorrenciaOS>();

    [HttpGet]
    public ActionResult<IEnumerable<OcorrenciaOS>> Get()
    {
        return Ok(ocorrenciasOS);
    }

    [HttpGet("{id}")]
    public ActionResult<OcorrenciaOS> Get(Guid id)
    {
        var ocorrenciaOS = ocorrenciasOS.FirstOrDefault(o => o.Id == id);
        if (ocorrenciaOS == null) return NotFound();
        return Ok(ocorrenciaOS);
    }

    [HttpPost]
    public ActionResult Post([FromBody] OcorrenciaOS ocorrenciaOS)
    {
        ocorrenciasOS.Add(ocorrenciaOS);
        return Ok();
    }

    [HttpPut("{id:guid}")]
    public ActionResult Put(Guid id, [FromBody] OcorrenciaOS ocorrenciaOS)
    {
        var oldOcorrenciaOS = ocorrenciasOS.FirstOrDefault(o => o.Id == id);
        if (oldOcorrenciaOS == null) return NotFound();

        oldOcorrenciaOS.IdOrdemServico = ocorrenciaOS.IdOrdemServico;
        oldOcorrenciaOS.IdOcorrencia = ocorrenciaOS.IdOcorrencia;

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public ActionResult Delete(Guid id)
    {
        var ocorrenciaOS = ocorrenciasOS.FirstOrDefault(o => o.Id == id);
        if (ocorrenciaOS == null) return NotFound();

        ocorrenciasOS.Remove(ocorrenciaOS);
        return Ok();
    }
}
