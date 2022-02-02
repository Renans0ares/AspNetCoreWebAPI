using System.Collections.Generic;

namespace SmartSchool.WebAPI.Dtos
{
    public class CursoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<DisciplinaDTO> Disciplinas { get; set; }
    }
}