using ApiCrud.Migrations;
using Interfocus.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

[Route("api/[controller]")]
[ApiController]
public class OrdemServicoController : ControllerBase
{
    private static List<OrdemServico> ordensServico = new List<OrdemServico>();

    [HttpGet]
    public ActionResult<IEnumerable<OrdemServico>> Get()
    {
        return Ok(ordensServico);
    }

    [HttpGet("{id:guid}")]
    public ActionResult<OrdemServico> Get(Guid id)
    {
        var ordemServico = ordensServico.FirstOrDefault(o => o.Id == id);
        if (ordemServico == null) return NotFound();
        return Ok(ordemServico);
    }

    [HttpPost]
    public ActionResult Post([FromBody] OrdemServico ordemServico)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        ordemServico.DataAgendamento = DateTime.UtcNow;
        ordemServico.StatusOS = new StatusOS
        {
            Id = ordemServico.IdStatusOS,
            Descricao = "Aberto",
            //Tipo = StatusOS.StatusTipo.Aberto
        };
        ordemServico.IdFuncionarioFechou = null;

        ordensServico.Add(ordemServico);
        return CreatedAtAction(nameof(Get), new { id = ordemServico.Id }, ordemServico);
    }

    [HttpPut("{id:guid}")]
    public ActionResult Put(Guid id, [FromBody] OrdemServico ordemServico)
    {
        var antigaOrdemServico = ordensServico.FirstOrDefault(o => o.Id == id);
        if (antigaOrdemServico == null) return NotFound();

        antigaOrdemServico.IdCliente = ordemServico.IdCliente;
        antigaOrdemServico.IdTipoServico = ordemServico.IdTipoServico;
        antigaOrdemServico.IdStatusOS = ordemServico.IdStatusOS;
        antigaOrdemServico.DataAgendamento = ordemServico.DataAgendamento;

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public ActionResult Delete(Guid id)
    {
        var ordemServico = ordensServico.FirstOrDefault(o => o.Id == id);
        if (ordemServico == null) return NotFound();

        ordensServico.Remove(ordemServico);
        return NoContent();
    }
}
