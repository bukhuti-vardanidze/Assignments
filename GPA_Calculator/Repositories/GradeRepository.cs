using GPA_Calculator.Db;
using GPA_Calculator.Db.Entities;
using GPA_Calculator.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GPA_Calculator.Repositories
{
    public interface IGradeRepository
    {
        Task<List<GradeRegisterRequest>> GetAllGrade();
        Task<List<GradeRegisterRequest>> GetSingleGradeById(int gradeId);
        Task<int> AddGrade([FromBody] GradeRegisterRequest request);



    }
    public class GradeRepository: IGradeRepository
    {
      
        private readonly AppDbContext _db;
        public GradeRepository(AppDbContext db) 
        { 
            _db=db;
        }

        public async Task<List<GradeRegisterRequest>> GetAllGrade()
        {
            var result = await _db.GradeDb.Select(x => new GradeRegisterRequest()
            {
                Id = x.Id,
                StudentId= x.StudentId,
                SubjectId= x.SubjectId,
                Score = (int)x.Score
            }).ToListAsync();

            
            return result;
        }

        public async Task<List<GradeRegisterRequest>> GetSingleGradeById(int gradeId)
        {
            var result = await _db.GradeDb.Where(x=>x.Id == gradeId).Select(x => new GradeRegisterRequest()
            {
                Id = x.Id,
                StudentId = x.StudentId,
                SubjectId = x.SubjectId,
                Score = (int)x.Score
            }).ToListAsync();

            return result;
        }


        public async Task<int> AddGrade([FromBody] GradeRegisterRequest request)
        {
            var result = new GradeEntity
            {
                Id = request.Id,
                StudentId = request.StudentId,
                SubjectId = request.SubjectId,
                Score = (int)request.Score
            };

           

            _db.GradeDb.Add(result);
            await _db.SaveChangesAsync();
            return result.Id;
        }


        public void GpaCalculator(double score)
        {
            var result = _db.GradeDb.Select(x => x.Score).ToList();
            
        }


    }

    
}
