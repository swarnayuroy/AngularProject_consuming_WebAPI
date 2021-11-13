using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Base
{
    public interface IRepository
    {
        Task<bool> Add(Student newStudent);
        Task<bool> Update(int Id, Student studentDetails);
        Task<bool> Remove(int Id);
    }
}
