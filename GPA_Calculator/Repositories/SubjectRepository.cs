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
            var subjects = await _db.SubjectDb.Select(x=> new SubjectRegisterRequest()
            {
               Id = x.Id,
               SubjectName= x.SubjectName,
               Credits= x.Credits    
            }).ToListAsync();
            return subjects;

        }

        public async Task<List<SubjectRegisterRequest>> GetSingleSubjectAsync(int subjectId)
        {
            var subjects = await _db.SubjectDb.Where(x=> x.Id == subjectId).Select(x => new SubjectRegisterRequest()
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
            _db.SubjectDb.Add(subject);
            await _db.SaveChangesAsync();
            return subject;


        }


    }
  
}
