using Domain.Entities;
using Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IStudentRepository : IRepository
    {
        Task<IEnumerable<Student>> GetStudentList();
        Task<Student> GetStudent(int Id);
    }
}
