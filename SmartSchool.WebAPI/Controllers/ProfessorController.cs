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
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        public ProfessorController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var Professor = _repo.GetAllProfessores(true);
            return Ok(_mapper.Map<IEnumerable<ProfessorDTO>>(Professor));
        }

        [HttpGet("getRegister")]
        public IActionResult GetRegister()
        {
            return Ok(new ProfessorRegistrarDTO());
        }

        // api/Professor
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Professor = _repo.GetAllProfessoresById(id, true);
            if (Professor == null) return BadRequest("O Professor não foi encontrado");

            var professorDto = _mapper.Map<ProfessorDTO>(Professor);

            return Ok(Professor);
        }
        
        // api/Professor
        [HttpPost]
        public IActionResult Post(ProfessorRegistrarDTO model)
        {
            var prof = _mapper.Map<Professor>(model);

            _repo.Add(prof);
            if (_repo.SaveChanges())
            {
                return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDTO>(prof));
            }

            return BadRequest("Professor não cadastrado");
        }

        // api/Professor
        [HttpPut("{id}")]
        public IActionResult Put(int id, ProfessorRegistrarDTO model)
        {
            var prof = _repo.GetAllProfessoresById(id, false);
            if (prof == null) return BadRequest("Professor não encontrado");

            _mapper.Map(model, prof);

            _repo.Update(prof);
            if (_repo.SaveChanges())
            {
                return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDTO>(prof));
            }

            return BadRequest("Professor não Atualizado");
        }

        // api/Professor
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, ProfessorRegistrarDTO model)
        {
            var prof = _repo.GetAllProfessoresById(id, false);
            if (prof == null) return BadRequest("Professor não encontrado");

            _mapper.Map(model, prof);

            _repo.Update(prof);
            if (_repo.SaveChanges())
            {
                return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDTO>(prof));
            }

            return BadRequest("Professor não Atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prof = _repo.GetAllProfessoresById(id, false);
            if (prof == null) return BadRequest("Professor não encontrado");

            _repo.Delete(prof);
            if (_repo.SaveChanges())
            {
                return Ok("professor deletado");
            }

            return BadRequest("professor não deletado");
        }
    }
}