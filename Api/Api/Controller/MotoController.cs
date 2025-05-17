using Api.Domain.Entity;
using Api.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controller
{
    [ApiController]
    [Route("moto")]
    public class MotoController : ControllerBase
    {
        private readonly MotosContext _context;

        public MotoController(MotosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Moto>> GetMotos()
        {
            var motos = await _context.Motos
                .Include(m => m.User)
                .ToListAsync();

            return motos.Select(m => new Moto
            {
                IDMoto = m.IDMoto,
                AnoDelançamento = m.AnoDelançamento,
                AnoDeFabricacao = m.AnoDeFabricacao,
                Quilometragem = m.Quilometragem,
                Placa = m.Placa,
                TagDaMoto = m.TagDaMoto,
                Chassi = m.Chassi,
                Observacao = m.Observacao,
                FotoDaMoto = m.FotoDaMoto,
                IPVA = m.IPVA,
                Licenciamento = m.Licenciamento,
                DPVAT = m.DPVAT,
                Combustivel = m.Combustivel,
                TypeMoto = m.TypeMoto,
                PatioAtual = m.PatioAtual,
                PlanoAssociado = m.PlanoAssociado,
                Multas = m.Multas,
                HistoricoDeReparos = m.HistoricoDeReparos,
                HistoricoDeChecks = m.HistoricoDeChecks,
                User = m.User
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Moto>> GetById(long id)
        {
            var moto = await _context.Motos
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.IDMoto == id);

            if (moto == null)
                return NotFound();

            return Ok(moto);
        }

        [HttpPost]
        public async Task<ActionResult<Moto>> Create([FromBody] Moto moto)
        {
            _context.Motos.Add(moto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = moto.IDMoto }, moto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Moto>> Update(long id, [FromBody] Moto moto)
        {
            var existingMoto = await _context.Motos.FindAsync(id);
            if (existingMoto == null)
                return NotFound();

            moto.IDMoto = id;
            _context.Entry(existingMoto).CurrentValues.SetValues(moto);
            await _context.SaveChangesAsync();
            return Ok(moto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto == null)
                return NotFound();

            _context.Motos.Remove(moto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}