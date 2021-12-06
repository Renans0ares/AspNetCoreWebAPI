using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>(){
            new Aluno(){
                Id = 1,
                Nome = "Renan",
                Sobrenome = "Soares",
                Telefone = "19988523658"
            },
            new Aluno(){
                Id = 2,
                Nome = "Luana",
                Sobrenome = "Karoliny",
                Telefone = "19988525458"
            },
            new Aluno(){
                Id = 3,
                Nome = "Thiago",
                Sobrenome = "Vicente",
                Telefone = "19988523748"
            }
        };
        public AlunoController()
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        //api/aluno/id
        [HttpGet("byId")] //Or [HttpGet("{id:int}")] Or [HttpGet("{byId}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if(aluno == null) return BadRequest("O Aluno não foi encontrado!");

            return Ok(aluno);
        }

        //api/aluno/nome
        ///api/aluno/byName?nome=Jose&sobrenome=silva
        [HttpGet("byName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
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