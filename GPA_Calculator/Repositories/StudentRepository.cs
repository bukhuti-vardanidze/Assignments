using GPA_Calculator.Db;
using GPA_Calculator.Db.Entities;
using GPA_Calculator.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace GPA_Calculator.Repositories
{
    public interface IStudentRepository
    {
    }

    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _db;

        public StudentRepository(AppDbContext db) 
        {
            _db = db;
        }


        public async Task<List<StudentEntity>> StudentRegisterAsync([FromBody]StudentRegistrationRequest studentRegistration )
        {
            var student = new StudentEntity
            {
                Id = studentRegistration.Id,
                FirstName = studentRegistration.FirstName,
                LastName = studentRegistration.LastName,
                PersonalNumber = studentRegistration.PersonalNumber,
                CourseName = studentRegistration.CourseName
            };
            _db.StudentDb.AddAsync(student);
            _db.SaveChangesAsync();
            return _db.StudentDb.ToList();
            
        }

    }

    
}
