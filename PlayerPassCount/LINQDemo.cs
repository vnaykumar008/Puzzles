using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerPassCount
{
    class LINQDemo
    {
        

        public IEnumerable<Employee> GetStudentInfo()
        {
            
            Test1232DbContext testDbContext = new Test1232DbContext();
            
            testDbContext.Employees.Add(new Employee {Id=11, Salary = 5555, dob=DateTime.Now });
            testDbContext.SaveChanges();

            var student = from s in testDbContext.Employees
                          //where s.Id == 1
                          select s;

            IEnumerable<Employee> enumera = student.ToList();

            return enumera;
        }
    }
    
    
}
