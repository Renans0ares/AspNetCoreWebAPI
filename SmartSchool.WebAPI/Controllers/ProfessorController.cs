using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {

        private readonly DataContext _context;
        public ProfessorController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var Professor = _context.Professores.FirstOrDefault(a => a.Id == id);
            if(Professor == null) return BadRequest("O Professor não foi encontrado!");

            return Ok(Professor);
        }

        [HttpGet("byName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var Professor = _context.Professores.FirstOrDefault(a => a.Nome.Contains(nome));
            if(Professor == null) return BadRequest("O Professor não foi encontrado!");

            return Ok(Professor);
        }


        [HttpPost]
        public IActionResult Post(Professor Professor)
        {
            _context.Add(Professor);
            _context.SaveChanges();
            return Ok(Professor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor Professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(prof == null) return BadRequest("Professor não encontrado");

            _context.Update(Professor);
            _context.SaveChanges();
            return Ok(Professor);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor Professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(prof == null) return BadRequest("Professor não encontrado");

            _context.Update(Professor);
            _context.SaveChanges();
            return Ok(Professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prof = _context.Professores.FirstOrDefault(a => a.Id == id);
            if(prof == null) return BadRequest("Professor não encontrado");
            
            _context.Remove(prof);
            _context.SaveChanges();
            return Ok();
        }
    }
}