﻿using ApiCrud.src.Data;
using ApiCrud.src.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCrud.src.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcorrenciaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OcorrenciaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ocorrencia>>> Get()
        {
            var ocorrencias = await _context.Ocorrencias.ToListAsync();
            return Ok(ocorrencias);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Ocorrencia>> Get(int id)
        {
            var ocorrencia = await _context.Ocorrencias.FindAsync(id);
            if (ocorrencia == null) return NotFound();
            return Ok(ocorrencia);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Ocorrencia ocorrencia)
        {
            if (ocorrencia == null)
            {
                return BadRequest("Ocorrência não pode ser nula.");
            }

            _context.Ocorrencias.Add(ocorrencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = ocorrencia.Id }, ocorrencia);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Ocorrencia ocorrencia)
        {
            if (id != ocorrencia.Id)
            {
                return BadRequest("ID da URL e do corpo da requisição não coincidem.");
            }

            var oldOcorrencia = await _context.Ocorrencias.FindAsync(id);
            if (oldOcorrencia == null)
            {
                return NotFound();
            }

            oldOcorrencia.Descricao = ocorrencia.Descricao;
            oldOcorrencia.Anexo = ocorrencia.Anexo;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "Erro ao atualizar a ocorrência no banco de dados.");
            }

            return Ok(oldOcorrencia);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var ocorrencia = await _context.Ocorrencias.FindAsync(id);
            if (ocorrencia == null) return NotFound();

            _context.Ocorrencias.Remove(ocorrencia);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}