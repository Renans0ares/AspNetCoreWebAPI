using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly DataContext _context;
        public AlunoController(DataContext context)
        {
            _context = context;
        }
        
        public AlunoController()
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        //api/aluno/id
        [HttpGet("byId")] //Or [HttpGet("{id:int}")] Or [HttpGet("{byId}")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if(aluno == null) return BadRequest("O Aluno não foi encontrado!");

            return Ok(aluno);
        }

        //api/aluno/nome
        ///api/aluno/byName?nome=Jose&sobrenome=silva
        [HttpGet("byName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
            if(aluno == null) return BadRequest("O Aluno não foi encontrado!");

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPut]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPatch]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}