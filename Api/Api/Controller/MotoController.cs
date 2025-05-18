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
            var motos = await _context.Motos.Include(m => m.User).ToListAsync();

            var response = motos.Select(m => new CreatedMotoResponse
            {
                IDMoto = m.IDMoto,
                AnoDelançamento = DateOnly.FromDateTime(m.AnoDelançamento),
                Quilometragem = m.Quilometragem,
                AnoDeFabricacao = m.AnoDeFabricacao,
                Placa = m.Placa,
                TagDaMoto = m.TagDaMoto,
                Chassi = m.Chassi,
                Observacao = m.Observacao,
                FotoDaMoto = m.FotoDaMoto,
                IPVA = m.IPVA,
                Licenciamento = m.Licenciamento,
                DPVAT = m.DPVAT,
                Combustivel = m.Combustivel.ToString(),
                TypeMotos = m.TypeMoto.ToString(),
                PatioAtual = m.PatioAtual,
                PlanoAssociado = m.PlanoAssociado,
                Multas = m.Multas,
                HistoricoDeReparos = m.HistoricoDeReparos,
                HistoricoDeChecks = m.HistoricoDeChecks,
                UserId = m.User.idUser
            });

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CreatedMotoResponse>> GetById(long id)
        {
            var m = await _context.Motos
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.IDMoto == id);

            if (m == null)
                return NotFound();

            var response = new CreatedMotoResponse
            {
                IDMoto = m.IDMoto,
                AnoDelançamento = DateOnly.FromDateTime(m.AnoDelançamento),
                Quilometragem = m.Quilometragem,
                AnoDeFabricacao = m.AnoDeFabricacao,
                Placa = m.Placa,
                TagDaMoto = m.TagDaMoto,
                Chassi = m.Chassi,
                Observacao = m.Observacao,
                FotoDaMoto = m.FotoDaMoto,
                IPVA = m.IPVA,
                Licenciamento = m.Licenciamento,
                DPVAT = m.DPVAT,
                Combustivel = m.Combustivel.ToString(),
                TypeMotos = m.TypeMoto.ToString(),
                PatioAtual = m.PatioAtual,
                PlanoAssociado = m.PlanoAssociado,
                Multas = m.Multas,
                HistoricoDeReparos = m.HistoricoDeReparos,
                HistoricoDeChecks = m.HistoricoDeChecks,
                UserId = m.User.idUser
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<CreatedMotoResponse>> Create([FromBody] CreateMotoRequest request)
        {
            _validator.ValidateAndThrow(request);

            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null)
                return BadRequest("Usuário não encontrado.");

            var moto = new Moto
            {
                AnoDelançamento = request.AnoDelançamento.ToDateTime(TimeOnly.MinValue),
                Quilometragem = request.Quilometragem,
                AnoDeFabricacao = request.AnoDeFabricacao,
                Placa = request.Placa,
                TagDaMoto = request.TagDaMoto,
                Chassi = request.Chassi,
                Observacao = request.Observacao,
                FotoDaMoto = request.FotoDaMoto,
                IPVA = request.IPVA,
                Licenciamento = request.Licenciamento,
                DPVAT = request.DPVAT,
                Combustivel = (TypeCombustivel)request.Combustivel,
                TypeMoto = (TypeMoto)request.TypeMotos,
                PatioAtual = request.PatioAtual,
                PlanoAssociado = request.PlanoAssociado,
                Multas = request.Multas,
                HistoricoDeReparos = request.HistoricoDeReparos,
                HistoricoDeChecks = request.HistoricoDeChecks,
                User = user
            };

            _context.Motos.Add(moto);
            await _context.SaveChangesAsync();

            var response = new CreatedMotoResponse
            {
                IDMoto = moto.IDMoto,
                AnoDelançamento = DateOnly.FromDateTime(moto.AnoDelançamento),
                Quilometragem = moto.Quilometragem,
                AnoDeFabricacao = moto.AnoDeFabricacao,
                Placa = moto.Placa,
                TagDaMoto = moto.TagDaMoto,
                Chassi = moto.Chassi,
                Observacao = moto.Observacao,
                FotoDaMoto = moto.FotoDaMoto,
                IPVA = moto.IPVA,
                Licenciamento = moto.Licenciamento,
                DPVAT = moto.DPVAT,
                Combustivel = moto.Combustivel.ToString(),
                TypeMotos = moto.TypeMoto.ToString(),
                PatioAtual = moto.PatioAtual,
                PlanoAssociado = moto.PlanoAssociado,
                Multas = moto.Multas,
                HistoricoDeReparos = moto.HistoricoDeReparos,
                HistoricoDeChecks = moto.HistoricoDeChecks,
                UserId = user.idUser
            };

            return CreatedAtAction(nameof(GetById), new { id = moto.IDMoto }, response);
        }
    }
}