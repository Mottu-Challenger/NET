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
                idUser = u.idUser,
                nome = u.nome,
                email = u.email,
                cpf = u.cpf,
                rg = u.rg,
                dtaNasc = DateOnly.FromDateTime(u.dtaNasc),
                numeroDeCadastro = u.numeroDeCadastro,
                ativo = u.ativo,
                nacionalidade = u.nacionalidade,
                carteira = u.carteira,
                enderco = u.enderco,
                contato = u.contato,
                plano = u.plano,
                motoId = u.motos?.idMoto ?? 0
            }).ToList();
        }

        public async Task<CreatedUserResponse?> GetByIdAsync(long id)
        {
            var u = await _context.Users.Include(u => u.motos).FirstOrDefaultAsync(u => u.idUser == id);
            if (u == null) return null;

            return new CreatedUserResponse
            {
                idUser = u.idUser,
                nome = u.nome,
                email = u.email,
                cpf = u.cpf,
                rg = u.rg,
                dtaNasc = DateOnly.FromDateTime(u.dtaNasc),
                numeroDeCadastro = u.numeroDeCadastro,
                ativo = u.ativo,
                nacionalidade = u.nacionalidade,
                carteira = u.carteira,
                enderco = u.enderco,
                contato = u.contato,
                plano = u.plano,
                motoId = u.motos?.idMoto ?? 0
            };
        }

        public async Task<User> CreateAsync(CreateUserRequest request, Moto moto)
        {
            var user = new User
            {
                nome = request.nome,
                email = request.email,
                cpf = request.cpf,
                rg = request.rg,
                dtaNasc = request.dtaNasc.ToDateTime(TimeOnly.MinValue),
                numeroDeCadastro = request.numeroDeCadastro,
                ativo = request.ativo,
                nacionalidade = request.nacionalidade,
                carteira = request.carteira,
                enderco = request.enderco,
                contato = request.contato,
                plano = request.plano,
                motos = moto
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}