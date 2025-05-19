using Api.Application.DTO.Request;
using Api.Application.DTO.Response;
using Api.Application.Validators;
using Api.Domain.Entity;
using Api.Domain.Enum;
using Api.Infrastructure.Context;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotoController : ControllerBase
    {
        private readonly MotosContext _context;
        private readonly CreateMotoRequestValidator _validator;

        public MotoController(MotosContext context, CreateMotoRequestValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreatedMotoResponse>>> GetMotos()
        {
            var motos = await _context.Motos.Include(m => m.user).ToListAsync();

            var response = motos.Select(m => new CreatedMotoResponse
            {
                idMoto = m.idMoto,
                anoDeLancamento = DateOnly.FromDateTime(m.anoDeLancamento),
                quilometragem = m.quilometragem,
                anoDeFabricacao = m.anoDeFabricacao,
                placa = m.placa,
                tagDaMoto = m.tagDaMoto,
                chassi = m.chassi,
                observacao = m.observacao,
                fotoDaMoto = m.fotoDaMoto,
                ipva = m.ipva,
                licenciamento = m.licenciamento,
                dpvat = m.dpvat,
                combustivel = m.combustivel.ToString(),
                typeMotos = m.typeMoto.ToString(),
                patioAtual = m.patioAtual,
                planoAssociado = m.planoAssociado,
                multas = m.multas,
                historicoDeReparos = m.historicoDeReparos,
                historicoDeChecks = m.historicoDeChecks,
                userId = m.user.idUser
            });

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CreatedMotoResponse>> GetById(long id)
        {
            var m = await _context.Motos
                .Include(m => m.user)
                .FirstOrDefaultAsync(m => m.idMoto == id);

            if (m == null)
                return NotFound();

            var response = new CreatedMotoResponse
            {
                idMoto = m.idMoto,
                anoDeLancamento = DateOnly.FromDateTime(m.anoDeLancamento),
                quilometragem = m.quilometragem,
                anoDeFabricacao = m.anoDeFabricacao,
                placa = m.placa,
                tagDaMoto = m.tagDaMoto,
                chassi = m.chassi,
                observacao = m.observacao,
                fotoDaMoto = m.fotoDaMoto,
                ipva = m.ipva,
                licenciamento = m.licenciamento,
                dpvat = m.dpvat,
                combustivel = m.combustivel.ToString(),
                typeMotos = m.typeMoto.ToString(),
                patioAtual = m.patioAtual,
                planoAssociado = m.planoAssociado,
                multas = m.multas,
                historicoDeReparos = m.historicoDeReparos,
                historicoDeChecks = m.historicoDeChecks,
                userId = m.user.idUser
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<CreatedMotoResponse>> Create([FromBody] CreateMotoRequest request)
        {
            _validator.ValidateAndThrow(request);

            var user = await _context.Users.FindAsync(request.userId);
            if (user == null)
                return BadRequest("Usuário não encontrado.");

            var moto = new Moto
            {
                anoDeLancamento = request.anoDeLancamento.ToDateTime(TimeOnly.MinValue),
                quilometragem = request.quilometragem,
                anoDeFabricacao = request.anoDeFabricacao,
                placa = request.placa,
                tagDaMoto = request.tagDaMoto,
                chassi = request.chassi,
                observacao = request.observacao,
                fotoDaMoto = request.fotoDaMoto,
                ipva = request.ipva,
                licenciamento = request.licenciamento,
                dpvat = request.dpvat,
                combustivel = (TypeCombustivel)request.combustivel,
                typeMoto = (TypeMoto)request.typeMotos,
                patioAtual = request.patioAtual,
                planoAssociado = request.planoAssociado,
                multas = request.multas,
                historicoDeReparos = request.historicoDeReparos,
                historicoDeChecks = request.historicoDeChecks,
                user = user
            };

            _context.Motos.Add(moto);
            await _context.SaveChangesAsync();

            var response = new CreatedMotoResponse
            {
                idMoto = moto.idMoto,
                anoDeLancamento = DateOnly.FromDateTime(moto.anoDeLancamento),
                quilometragem = moto.quilometragem,
                anoDeFabricacao = moto.anoDeFabricacao,
                placa = moto.placa,
                tagDaMoto = moto.tagDaMoto,
                chassi = moto.chassi,
                observacao = moto.observacao,
                fotoDaMoto = moto.fotoDaMoto,
                ipva = moto.ipva,
                licenciamento = moto.licenciamento,
                dpvat = moto.dpvat,
                combustivel = moto.combustivel.ToString(),
                typeMotos = moto.typeMoto.ToString(),
                patioAtual = moto.patioAtual,
                planoAssociado = moto.planoAssociado,
                multas = moto.multas,
                historicoDeReparos = moto.historicoDeReparos,
                historicoDeChecks = moto.historicoDeChecks,
                userId = user.idUser
            };

            return CreatedAtAction(nameof(GetById), new { id = moto.idMoto }, response);
        }
    }
}