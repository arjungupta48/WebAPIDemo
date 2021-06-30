using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIDemo.Models
{
    public class EmployeeModels
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoining { get; set; }
        public DateTime? DateOfLeaving { get; set; }
        public int Band { get; set; }
        public string Level { get; set; }
        public int Experience { get; set; }
        public int Salary { get; set; }
        public bool IsActive { get; set; }
    }
}