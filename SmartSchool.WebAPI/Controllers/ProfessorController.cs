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
        private readonly IRepository _repo;
        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllProfessores(true);
            return Ok(result);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var Professor = _repo.GetAllProfessoresById(id,false);
            if(Professor == null) return BadRequest("O Professor não foi encontrado!");

            return Ok(Professor);
        }

        // [HttpGet("byName")]
        // public IActionResult GetByName(string nome, string sobrenome)
        // {
        //     var Professor = _context.Professores.FirstOrDefault(a => a.Nome.Contains(nome));
        //     if(Professor == null) return BadRequest("O Professor não foi encontrado!");

        //     return Ok(Professor);
        // }


        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);
            if(_repo.SaveChanges())
            {
                return Ok(professor);
            }    
            return BadRequest("Aluno não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _repo.GetAllProfessoresById(id,false);
            if(prof == null) return BadRequest("Professor não encontrado");

            _repo.Update(professor);
            _repo.SaveChanges();
            return Ok(professor);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _repo.GetAllProfessoresById(id,false);
            if(prof == null) return BadRequest("Professor não encontrado");

            _repo.Update(professor);
            _repo.SaveChanges();
            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prof = _repo.GetAllProfessoresById(id, false);
            if(prof == null) return BadRequest("Professor não encontrado");
            
            _repo.Delete(prof);
            _repo.SaveChanges();
            return Ok();
        }
    }
}