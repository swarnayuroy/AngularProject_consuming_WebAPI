using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using NHibernate;
using NHibernate.Linq;
using DataAccessLayer.Data;
using AutoMapper;

namespace DataAccessLayer.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ISession _session;        
        public StudentRepository()
        {
            this._session = OpenNHibernateSession.OpenSession();
        }
        public async Task<IEnumerable<Student>> GetStudentList()
        {
            try
            {
                Mapper.CreateMap<StudentDTO, Student>()
                    .ForMember(y => y.Date_Of_Birth, opt=>opt.MapFrom(x => x.Date_Of_Birth.ToString("dd-MMM-yyyy")));

                List<StudentDTO> dbStudentList = await Task.Run(() => _session.Query<StudentDTO>().ToList());
                List<Student> studentList = new List<Student>();
                foreach (var student in dbStudentList)
                {
                    studentList.Add(Mapper.Map<Student>(student));
                }
                return studentList;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<Student> GetStudent(int Id)
        {
            try
            {
                Mapper.CreateMap<StudentDTO, Student>()
                    .ForMember(y => y.Date_Of_Birth, opt => opt.MapFrom(x => x.Date_Of_Birth.ToString("dd-MMM-yyyy"))); ;
                StudentDTO student = await Task.Run(() => _session.Get<StudentDTO>(Id));
                if (student != null)
                {
                    return Mapper.Map<Student>(student);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }        
        public async Task<bool> Add(Student newStudent)
        {
            try
            {
                Mapper.CreateMap<Student, StudentDTO>()
                    .ForMember(y => y.Date_Of_Birth, opt => opt.MapFrom(x => Convert.ToDateTime(x.Date_Of_Birth)));

                StudentDTO dbNewStudent = Mapper.Map<StudentDTO>(newStudent);
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    await Task.Run(() => _session.Save(dbNewStudent));
                    transaction.Commit();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> Update(int Id, Student studentDetails)
        {
            try
            {
                StudentDTO student = _session.Get<StudentDTO>(Id);
                if (student != null)
                {
                    student.FirstName = studentDetails.FirstName;
                    student.LastName = studentDetails.LastName;
                    student.Date_Of_Birth = Convert.ToDateTime(studentDetails.Date_Of_Birth);
                    student.Gender = studentDetails.Gender;
                    student.City = studentDetails.City;
                    student.ContactNo = studentDetails.ContactNo;
                    student.Grade = studentDetails.Grade;

                    using (ITransaction transaction = _session.BeginTransaction())
                    {
                        await Task.Run(() => _session.Save(student));
                        transaction.Commit();
                    }
                    return true;
                }
                return false;                
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> Remove(int Id)
        {
            try
            {
                StudentDTO student = _session.Get<StudentDTO>(Id);
                if (student != null)
                {
                    using (ITransaction transaction = _session.BeginTransaction())
                    {
                        await Task.Run(() => _session.Delete(student));
                        transaction.Commit();
                    }
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }        
    }
}
