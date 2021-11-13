using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Student
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Date_Of_Birth { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }        
        public long ContactNo { get; set; }        
        public int Grade { get; set; }
    }
}
