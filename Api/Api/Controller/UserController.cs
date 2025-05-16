using Api.Domain.Entity;
using Api.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace fiap.br.com.challenger.controller
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;
        

        public UserController(UserContext _context, UserContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<IEnumerable<CreatedUserResponse>> GetUsers()
        {
            var users = await _context.Users
                .Include(u => u.Motos)
                .ToListAsync();

            return users.Select(u => new CreatedUserResponse
            {
                IDUser = u.IDUser,
                Nome = u.Nome,
                Email = u.Email,
                CPF = u.CPF.ToString("00000000000"),
                RG = u.RG,
                DtaNasc = u.DtaNasc,
                NumeroDeCadastro = u.NumeroDeCadastro,
                Ativo = u.Ativo,
                Nacionalidade = u.Nacionalidade,
                Carteira = u.Carteira,
                Enderco = u.Enderco,
                Contato = u.Contato,
                Plano = u.Plano,
                Moto = u.Motos == null ? null : new CreatedMotoResponse
                {
                    IdMoto = u.Motos.IdMoto,
                    Placa = u.Motos.Placa,
                    Chassi = u.Motos.Chassi,
                    Tipo = u.Motos.TypeMotos.ToString()
                }
            });
        }

        
        
        
        
        
        
        

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(long id)
        {
            var user = await _context.GetByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create([FromBody] User user)
        {
            var createdUser = await _context.CreateAsync(user);
            return Ok(createdUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Update(long id, [FromBody] User user)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
                return NotFound();

            user.IDUser = id;
            var updatedUser = await _userRepository.UpdateAsync(user);
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return NotFound();

            await _userRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
