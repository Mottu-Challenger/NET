using Api.Domain.Entity;
using Api.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controller
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users
                .Include(u => u.Motos)
                .ToListAsync();

            return users.Select(u => new User
            {
                IDUser = u.IDUser,
                Nome = u.Nome,
                Email = u.Email,
                CPF = u.CPF,
                RG = u.RG,
                DtaNasc = u.DtaNasc,
                NumeroDeCadastro = u.NumeroDeCadastro,
                Ativo = u.Ativo,
                Nacionalidade = u.Nacionalidade,
                Carteira = u.Carteira,
                Enderco = u.Enderco,
                Contato = u.Contato,
                Plano = u.Plano,
                Motos = u.Motos
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(long id)
        {
            var user = await _context.Users
                .Include(u => u.Motos)
                .FirstOrDefaultAsync(u => u.IDUser == id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create([FromBody] User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = user.IDUser }, user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Update(long id, [FromBody] User user)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null)
                return NotFound();

            user.IDUser = id;
            _context.Entry(existingUser).CurrentValues.SetValues(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
