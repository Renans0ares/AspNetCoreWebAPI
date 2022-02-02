using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Dtos;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        public AlunoController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("pegaResposta")]
        // public IActionResult pegaResposta()
        // {
        //     return Ok(_repo.pegaResposta());
        // }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllAlunos(true);
            return Ok(_mapper.Map<IEnumerable<AlunoDTO>>(result));
        }

        //api/aluno/id
        [HttpGet("{byId}")] //Or [HttpGet("{id:int}")] Or [HttpGet("{byId}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAllAlunoById(id, false);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado!");

            var alunoDto = _mapper.Map<AlunoDTO>(aluno);

            return Ok(alunoDto);
        }

        //api/aluno/nome
        ///api/aluno/byName?nome=Jose&sobrenome=silva
        // [HttpGet("byName")]
        // public IActionResult GetByName(string nome, string sobrenome)
        // {
        //     var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
        //     if (aluno == null) return BadRequest("O Aluno não foi encontrado!");

        //     return Ok(aluno);
        // }

        [HttpPost]
        public IActionResult Post(AlunoRegistrarDTO model)
        {
            var aluno = _mapper.Map<Aluno>(model);
            
            _repo.Add(aluno);
            if(_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDTO>(aluno));
            }    
            return BadRequest("Aluno não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, AlunoRegistrarDTO model)
        {
            var aluno = _repo.GetAllAlunoById(id);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            _mapper.Map(model, aluno);

            _repo.Update(aluno);
            if(_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDTO>(aluno));
            }    
            return BadRequest("Aluno não Atualizado");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, AlunoRegistrarDTO model)
        {
            var aluno = _repo.GetAllAlunoById(id);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            _mapper.Map(model, aluno);

            _repo.Update(aluno);
            if(_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDTO>(aluno));
            }    
            return BadRequest("Aluno não Atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAllAlunoById(id);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            _repo.Delete(aluno);
            if(_repo.SaveChanges())
            {
                return Ok(aluno);
            }    
            return BadRequest("Aluno não Deletado");
        }
    }
}