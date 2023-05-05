using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace StudentRestAPI.Model
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Student> AddStudent(Student student)
        {
            var result = await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteStudent(Guid studentId)
        {
            var result = await _context.Students.FirstOrDefaultAsync(x => x.StudentId == studentId);
            if (result != null)
            {
                _context.Students.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Student> GetStudent(Guid studentId)
        {
            return await _context.Students.FirstOrDefaultAsync(x => x.StudentId == studentId);
        }

        public async Task<Student> GetStudentByEmail(string email)
        {
            return await _context.Students.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        //public async Task<IEnumerable<Student>> GetAll()
        //{
        //    IQueryable<Student> query = _context.Students;
        //    return await query.AsQueryable();
        //}

        public async Task<IEnumerable<Student>> Search(string name, Gender? gender)
        {
            IQueryable<Student> query = _context.Students;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.FirstName.Contains(name) || x.LastName.Contains(name));
            }

            if (gender != null)
            {
                query = query.Where(x => x.Gender == gender);
            }

            return await query.ToListAsync();
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            var result = await _context.Students.FirstOrDefaultAsync(x => x.StudentId == student.StudentId);

            if (result != null)
            {
                result.FirstName = student.FirstName;
                result.LastName = student.LastName;
                result.DateOfBirth = student.DateOfBirth;
                result.Gender = student.Gender;
                result.Email = student.Email;
                if (student.DepartmentId != 0) result.DepartmentId = student.DepartmentId;
                result.PhotoPath = student.PhotoPath;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
           
        }

    }
}
