using Api.Application.DTO.Request;
using Api.Application.DTO.Response;
using Api.Application.Validators;
using Api.Domain.Entity;
using Api.Infrastructure.Context;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;
        private readonly CreateUserRequestValidator _validator;

        public UserController(UserContext context, CreateUserRequestValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreatedUserResponse>>> GetUsers()
        {
            var users = await _context.Users
                .Include(u => u.motos)
                .ToListAsync();

            var response = users.Select(u => new CreatedUserResponse
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
            });

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CreatedUserResponse>> GetById(long id)
        {
            var u = await _context.Users
                .Include(u => u.motos)
                .FirstOrDefaultAsync(u => u.idUser == id);

            if (u == null)
                return NotFound();

            var response = new CreatedUserResponse
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

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<CreatedUserResponse>> Create([FromBody] CreateUserRequest request)
        {
            _validator.ValidateAndThrow(request);

            var moto = await _context.Set<Moto>().FindAsync(request.MotoId);
            if (moto == null)
                return BadRequest("Moto não encontrada.");

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

            var response = new CreatedUserResponse
            {
                IDUser = user.idUser,
                Nome = user.nome,
                Email = user.email,
                CPF = user.cpf,
                RG = user.rg,
                DtaNasc = DateOnly.FromDateTime(user.dtaNasc),
                NumeroDeCadastro = user.numeroDeCadastro,
                Ativo = user.ativo,
                Nacionalidade = user.nacionalidade,
                Carteira = user.carteira,
                Enderco = user.enderco,
                Contato = user.contato,
                Plano = user.plano,
                MotoId = moto.IDMoto
            };

            return CreatedAtAction(nameof(GetById), new { id = user.idUser }, response);
        }
    }
}