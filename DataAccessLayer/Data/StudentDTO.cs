using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class StudentDTO
    {
        public virtual int? Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime Date_Of_Birth { get; set; }
        public virtual string Gender { get; set; }
        public virtual string City { get; set; }
        public virtual long ContactNo { get; set; }
        public virtual int Grade { get; set; }
    }
}
