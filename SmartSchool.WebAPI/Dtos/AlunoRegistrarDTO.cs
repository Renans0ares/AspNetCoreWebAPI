using System;
using System.Collections.Generic;

namespace SmartSchool.WebAPI.Dtos
{
    public class AlunoRegistrarDTO
    {
        public int Id { get; set; }
        public int Matricula { get; set; }
        public string DataNasc { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool Ativo { get; set; } = true;  
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
    }
}