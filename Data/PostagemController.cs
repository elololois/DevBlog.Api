using DevBlog.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevBlog.Api.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostagemController : ControllerBase
    {
        private readonly blogContext _context;

        public PostagemController(blogContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Postagem>>> GetPostagens()
        {
            return await _context.Postagens.ToListAsync();
        }
        [HttpPost]

        public async Task<ActionResult<Postagem>> AddAutor(Postagem postagem)
        {
            _context.Postagens.Add(postagem);
            await _context.SaveChangesAsync();

            return Ok(postagem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostagem(int id, Postagem postagem)
        {
            if (id != postagem.Id)
            {
                return BadRequest();
            }

            _context.Entry(postagem).State = EntityState.Modified;


            await _context.SaveChangesAsync();


            return Ok("As postagens foram salvos  com sucesso!!!");
        }
    }
}
