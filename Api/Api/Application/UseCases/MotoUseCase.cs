using Api.Application.DTO.Request;
using Api.Application.DTO.Response;
using Api.Domain.Entity;
using Api.Domain.Enum;
using Api.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.Application.UseCases
{
    public class MotoUseCase
    {
        private readonly MotosContext _context;

        public MotoUseCase(MotosContext context)
        {
            _context = context;
        }

        public async Task<List<CreatedMotoResponse>> GetAllMotosAsync()
        {
            var motos = await _context.Motos.Include(m => m.user).ToListAsync();

            return motos.Select(m => new CreatedMotoResponse
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
            }).ToList();
        }

        public async Task<Moto> CreateAsync(CreateMotoRequest request, User user)
        {
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
            return moto;
        }
    }
}