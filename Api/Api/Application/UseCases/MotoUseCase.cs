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
            var motos = await _context.Motos.Include(m => m.User).ToListAsync();

            return motos.Select(m => new CreatedMotoResponse
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
            }).ToList();
        }

        public async Task<Moto> CreateAsync(CreateMotoRequest request, User user)
        {
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
            return moto;
        }
    }
}