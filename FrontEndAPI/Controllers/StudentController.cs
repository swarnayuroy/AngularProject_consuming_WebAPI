using DataAccessLayer.Repositories;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FrontEndAPI.Controllers
{
    public class StudentController : ApiController
    {
        private readonly IStudentRepository _repo;
        public StudentController()
        {
            this._repo = new StudentRepository();
        }

        [HttpGet]
        public Task<IEnumerable<Student>> GetAllStudent()
        {
            return _repo.GetStudentList();
        }

        [HttpPost]
        public async Task<Student> GetStudent([FromUri] int Id)
        {
            return await Task.Run(() => _repo.GetStudent(Id));
        }

        [HttpPost]
        public async Task<bool> AddStudent([FromBody] Student newStudent)
        {
            return await Task.Run(() => _repo.Add(newStudent));
        }

        [HttpPut]
        public async Task<bool> UpdateStudentDetails([FromUri] int Id, [FromBody] Student studentDetails)
        {
            return await Task.Run(() => _repo.Update(Id, studentDetails));
        }

        [HttpDelete]
        public async Task<bool> RemoveStudentDetails([FromUri] int Id)
        {
            return await Task.Run(() => _repo.Remove(Id));
        }
    }
}
