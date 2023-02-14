using GPA_Calculator.Calculate_GPA;
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
        Task<GradeEntity> AddGrade([FromBody] GradeRegisterRequest request);
        Task<List<int>> GetStudentScoreById(int gradeId);
        Task<List<StudentGrade>> GetStudnetGradeById(int StudentId);
    }
    public class GradeRepository : IGradeRepository
    {

        private readonly AppDbContext _db;
        public GradeRepository(AppDbContext db)
        {
            _db = db;
        }

        

        public async Task<List<GradeRegisterRequest>> GetAllGrade()
        {
            var result = await _db.GradeDb.Select(x => new GradeRegisterRequest()
            {
                Id = x.Id,
                StudentId = x.StudentId,
                SubjectId = x.SubjectId,
                Score = (int)x.Score
            }).ToListAsync();


            return result;
        }

        public async Task<List<GradeRegisterRequest>> GetSingleGradeById(int gradeId)
        {
            var result = await _db.GradeDb.Where(x => x.Id == gradeId).Select(x => new GradeRegisterRequest()
            {
                Id = x.Id,
                StudentId = x.StudentId,
                SubjectId = x.SubjectId,
                Score = (int)x.Score
            }).ToListAsync();

            return result;
        }


        public async Task<GradeEntity> AddGrade([FromBody] GradeRegisterRequest request)
        {
            var result = new GradeEntity
            {
              
                StudentId = request.StudentId,
                SubjectId = request.SubjectId,
                Score = (int)request.Score
            };



            _db.GradeDb.Add(result);
            await _db.SaveChangesAsync();
            return result;
        }

        

        public async Task<List<int>> GetStudentScoreById(int gradeId)
        {
            var result =  _db.GradeDb.Where(x => x.Id == gradeId).Select(x=>(int)x.Score).ToList();
            return  await Task.FromResult(result);
           
           
        }


        public async Task<List<StudentGrade>> GetStudnetGradeById(int StudentId)
        {
            var result = await _db.GradeDb.Where(i => i.StudentId == StudentId).Select(x => new StudentGrade
            {
                StudentId = x.StudentId,
                Credits = x.SubjectEntity.Credits,
                Score = (int)x.Score

            }).ToListAsync();

            return result;
        }

       

    }

    
}
