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
                .Include(u => u.motos)
                .ToListAsync();

            return users.Select(u => new User
            {
                idUser = u.idUser,
                nome = u.nome,
                email = u.email,
                cpf = u.cpf,
                rg = u.rg,
                dtaNasc = u.dtaNasc,
                numeroDeCadastro = u.numeroDeCadastro,
                ativo = u.ativo,
                nacionalidade = u.nacionalidade,
                carteira = u.carteira,
                enderco = u.enderco,
                contato = u.contato,
                plano = u.plano,
                motos = u.motos
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(long id)
        {
            var user = await _context.Users
                .Include(u => u.motos)
                .FirstOrDefaultAsync(u => u.idUser == id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create([FromBody] User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = user.idUser }, user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Update(long id, [FromBody] User user)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null)
                return NotFound();

            user.idUser = id;
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
