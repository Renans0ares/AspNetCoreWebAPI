using System;
using System.Collections.Generic;

namespace SmartSchool.WebAPI.Models
{
    public class Professor
    {
        public Professor()
        {
        }

        public Professor(int id, int registro, string nome, string sobrenome)
        {
            this.Id = id;
            this.Nome = nome;
            this.Registro = registro;
            this.Sobrenome = Sobrenome;
        }
        
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Registro { get; set; }
        public IEnumerable<Disciplina> Disciplinas { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; } = true;
    }
}