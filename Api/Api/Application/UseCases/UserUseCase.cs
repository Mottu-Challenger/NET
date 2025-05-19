using Api.Application.DTO.Request;
using Api.Application.DTO.Response;
using Api.Domain.Entity;
using Api.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.Application.UseCases
{
    public class UserUseCase
    {
        private readonly UserContext _context;

        public UserUseCase(UserContext context)
        {
            _context = context;
        }

        public async Task<List<CreatedUserResponse>> GetAllUsersAsync()
        {
            var users = await _context.Users.Include(u => u.motos).ToListAsync();

            return users.Select(u => new CreatedUserResponse
            {
                IDUser = u.idUser,
                Nome = u.nome,
                Email = u.email,
                CPF = u.cpf,
                RG = u.rg,
                DtaNasc = DateOnly.FromDateTime(u.dtaNasc),
                NumeroDeCadastro = u.numeroDeCadastro,
                Ativo = u.ativo,
                Nacionalidade = u.nacionalidade,
                Carteira = u.carteira,
                Enderco = u.enderco,
                Contato = u.contato,
                Plano = u.plano,
                MotoId = u.motos?.IDMoto ?? 0
            }).ToList();
        }

        public async Task<CreatedUserResponse?> GetByIdAsync(long id)
        {
            var u = await _context.Users.Include(u => u.motos).FirstOrDefaultAsync(u => u.idUser == id);
            if (u == null) return null;

            return new CreatedUserResponse
            {
                IDUser = u.idUser,
                Nome = u.nome,
                Email = u.email,
                CPF = u.cpf,
                RG = u.rg,
                DtaNasc = DateOnly.FromDateTime(u.dtaNasc),
                NumeroDeCadastro = u.numeroDeCadastro,
                Ativo = u.ativo,
                Nacionalidade = u.nacionalidade,
                Carteira = u.carteira,
                Enderco = u.enderco,
                Contato = u.contato,
                Plano = u.plano,
                MotoId = u.motos?.IDMoto ?? 0
            };
        }

        public async Task<User> CreateAsync(CreateUserRequest request, Moto moto)
        {
            var user = new User
            {
                nome = request.Nome,
                email = request.Email,
                cpf = request.CPF,
                rg = request.RG,
                dtaNasc = request.DtaNasc.ToDateTime(TimeOnly.MinValue),
                numeroDeCadastro = request.NumeroDeCadastro,
                ativo = request.Ativo,
                nacionalidade = request.Nacionalidade,
                carteira = request.Carteira,
                enderco = request.Enderco,
                contato = request.Contato,
                plano = request.Plano,
                motos = moto
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}