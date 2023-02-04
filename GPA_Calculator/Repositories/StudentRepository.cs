using GPA_Calculator.Db;
using GPA_Calculator.Db.Entities;
using GPA_Calculator.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GPA_Calculator.Repositories
{
    public interface IStudentRepository
    {
        Task<List<StudentRegistrationRequest>> GetAllStudentsAsync();
        Task<List<StudentRegistrationRequest>> GetSingleStudentAsync(int StudentId);
        Task<StudentEntity> StudentRegisterAsync([FromBody] StudentRegistrationRequest studentRegistration);
    }

    public class StudentRepository : IStudentRepository
    {

        private readonly AppDbContext _db;

        public StudentRepository(AppDbContext db) 
        {
            _db = db;
        }


        public async Task<List<StudentRegistrationRequest>> GetAllStudentsAsync()
        {
            var students = await _db.StudentDb.Select(x => new StudentRegistrationRequest()
            {
                Id= x.Id,
                FirstName= x.FirstName,
                LastName= x.LastName,
                PersonalNumber= x.PersonalNumber,
                CourseName= x.CourseName,
                
            }).ToListAsync();
            return students;
        }


        public async Task<List<StudentRegistrationRequest>> GetSingleStudentAsync(int StudentId)
        {
            var student = await _db.StudentDb.Where(x => x.Id == StudentId).Select(x => new StudentRegistrationRequest()
            {
                Id= x.Id,
                FirstName= x.FirstName,
                LastName= x.LastName,
                PersonalNumber= x.PersonalNumber,
                CourseName= x.CourseName
            }).ToListAsync();
            return student;
            
        }

      


        public async Task<StudentEntity> StudentRegisterAsync([FromBody]StudentRegistrationRequest studentRegistration )
        {
            var student = new StudentEntity
            {
                Id = studentRegistration.Id,
                FirstName = studentRegistration.FirstName,
                LastName = studentRegistration.LastName,
                PersonalNumber = studentRegistration.PersonalNumber,
                CourseName = studentRegistration.CourseName
            };
            _db.StudentDb.Add(student);
            await _db.SaveChangesAsync();

            return student;
            
        }

    }

    
}
