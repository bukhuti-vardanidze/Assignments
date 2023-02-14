using GPA_Calculator.Calculate_GPA;
using GPA_Calculator.Db;
using GPA_Calculator.Db.Entities;
using GPA_Calculator.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GPA_Calculator.Repositories
{
    public interface ISubjectRepository
    {
        Task<List<SubjectRegisterRequest>> GetAllSubjectAsync();
        Task<List<SubjectRegisterRequest>> GetSingleSubjectAsync(int subjectId);
        Task<SubjectEntity> AddSubjectAsync([FromBody] SubjectRegisterRequest request);
        Task<List<SubjectEntity>> GetTop3EasySubject();

        Task<List<SubjectEntity>> GetLast3HardSubject();
        

    }

    public class SubjectRepository : ISubjectRepository
    {
        private readonly AppDbContext _db;

        public SubjectRepository(AppDbContext db)
        {
            _db = db;
        }



        public async Task<List<SubjectRegisterRequest>> GetAllSubjectAsync()
        {
            var subjects = await _db.Subjects.Select(x=> new SubjectRegisterRequest()
            {
               Id = x.Id,
               SubjectName= x.SubjectName,
               Credits= x.Credits    
            }).ToListAsync();
            return subjects;

        }

        public async Task<List<SubjectRegisterRequest>> GetSingleSubjectAsync(int subjectId)
        {
            var subjects = await _db.Subjects.Where(x=> x.Id == subjectId).Select(x => new SubjectRegisterRequest()
            {
                Id = x.Id,
                SubjectName = x.SubjectName,
                Credits = x.Credits
            }).ToListAsync();
            return subjects;

        }

        public async Task<SubjectEntity> AddSubjectAsync([FromBody] SubjectRegisterRequest request)
        {
            var subject = new SubjectEntity
            {
                Id = request.Id,
                SubjectName = request.SubjectName,
                Credits = request.Credits
            };
            _db.Subjects.Add(subject);
            await _db.SaveChangesAsync();
            return subject;


        }


        
        public async Task<List<SubjectEntity>> GetTop3EasySubject()
        {
            var result = _db.Grades.GroupBy(x => x.SubjectId).Select(x => new
            {
                SubjectName = x.Key,
                AverageScore = x.Average(x =>(int) x.Score)
            }).OrderBy(x => x.AverageScore).Take(3);

            var Top3 = new List<SubjectEntity>();

            foreach (var items in result)
            {
                Top3.Add(await _db.Subjects.FirstOrDefaultAsync(x => x.Id == items.SubjectName));
            }

            return Top3.ToList();

           
        }

     


        public async Task<List<SubjectEntity>> GetLast3HardSubject()
        {
                       
            var result = _db.Grades.GroupBy(x => x.SubjectId).Select(x => new
            {
                SubjectName = x.Key,
                AverageScore = x.Average(x => (int)x.Score)
            }).OrderByDescending(x => x.AverageScore).Take(3);

            var Top3 = new List<SubjectEntity>();

            foreach (var items in result)
            {
                
                Top3.Add(await _db.Subjects.FirstOrDefaultAsync(x => x.Id == items.SubjectName));
            }

            return Top3.ToList();
        }


        



    }

}
