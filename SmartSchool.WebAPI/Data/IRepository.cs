using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
         void Add<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         bool SaveChanges();

         Aluno[] GetAllAlunos(bool includeProfessor = false);
         Aluno[] GetAllAlunosByDisciplinaId(int disciplinaID, bool includeProfessor = false);
         Aluno GetAllAlunoById(int alunoId, bool includeProfessor = false);

         Professor[] GetAllProfessores(bool includeAluno = false);
         Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeAluno = false);
         Professor GetAllProfessoresById(int professorid, bool includeAluno = false);

        
    }
}