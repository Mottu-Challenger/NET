using System.Net;
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
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<IEnumerable<CreatedUserResponse>>> GetUsers()
        {
            var users = await _context.Users
                .Include(u => u.motos)
                .ToListAsync();

            var response = users.Select(u => new CreatedUserResponse
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
            });

            return Ok(response);
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<CreatedUserResponse>> GetById(long id)
        {
            var u = await _context.Users
                .Include(u => u.motos)
                .FirstOrDefaultAsync(u => u.idUser == id);

            if (u == null)
                return NotFound();

            var response = new CreatedUserResponse
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

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<CreatedUserResponse>> Create([FromBody] CreateUserRequest request)
        {
            _validator.ValidateAndThrow(request);

            var moto = await _context.Set<Moto>().FindAsync(request.motoId);
            if (moto == null)
                return BadRequest("Moto não encontrada.");

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

            var response = new CreatedUserResponse
            {
                idUser = user.idUser,
                nome = user.nome,
                email = user.email,
                cpf = user.cpf,
                rg = user.rg,
                dtaNasc = DateOnly.FromDateTime(user.dtaNasc),
                numeroDeCadastro = user.numeroDeCadastro,
                ativo = user.ativo,
                nacionalidade = user.nacionalidade,
                carteira = user.carteira,
                enderco = user.enderco,
                contato = user.contato,
                plano = user.plano,
                motoId = moto.idMoto
            };

            return CreatedAtAction(nameof(GetById), new { id = user.idUser }, response);
        }
    }
}