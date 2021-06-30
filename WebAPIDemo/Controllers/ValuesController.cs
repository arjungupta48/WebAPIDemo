using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        public static List<EmployeeModels> _employeeList = new List<EmployeeModels>
        {
            new EmployeeModels()
            {
                Id = 1,
                FirstName = "Arjun",
                LastName = "Kasaudhan",
                UserName = "arjungupta48",
                DateOfBirth = new DateTime(2000, 06, 22),
                DateOfJoining =  new DateTime(2015, 10, 13),
                DateOfLeaving = new DateTime ? (),
                Band = 5,
                Level = "L3",
                Experience = 2,
                Salary = 20000,
                IsActive = true

            },
            new EmployeeModels()
            {
                Id = 2,
                FirstName = "Santhosh",
                LastName = "Kashyap",
                UserName = "santhos.kashyap",
                DateOfBirth = new DateTime(1997, 04, 12),
                DateOfJoining =  new DateTime(2013, 2, 1),
                DateOfLeaving = new DateTime ? (),
                Band = 5,
                Level = "L4",
                Experience = 4,
                Salary = 40000,
                IsActive = true

            },
            new EmployeeModels()
            {
                Id = 3,
                FirstName = "Sachin",
                LastName = "Tendulkar",
                UserName = "iamsachin",
                DateOfBirth = new DateTime(1991, 12, 28),
                DateOfJoining =  new DateTime(2007, 10, 1),
                DateOfLeaving = new DateTime?(),
                Band = 5,
                Level = "L5",
                Experience = 10,
                Salary = 80000,
                IsActive = false
            }
        };
        //// GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage LoadEmployee()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _employeeList);
        }

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage LoadEmployeeById(int id)
        {
            var entity = _employeeList.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Employee with Id " + id.ToString() + " not found");
            }
        }

        //// POST api/values
        //public void Post([FromBody]string value)
        //{
        //}

        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage CreateNewEmployee([FromBody] EmployeeModels employee)
        {
            try
            {
                if(_employeeList.Any(x=> x.Email == employee.Email))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Employee with Id " + employee.Id.ToString() + " already exists");
                }
                else
                {
                    employee.Id = _employeeList.Max(x => x.Id) + 1;
                    _employeeList.Add(employee);

                    var messsage = Request.CreateResponse(HttpStatusCode.Created, employee);
                    messsage.Headers.Location = new Uri(Request.RequestUri + employee.Id.ToString());

                    return messsage;
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage UpdateEmployeeDetails(EmployeeModels employee)
        {
            var entity = _employeeList.FirstOrDefault(e => e.Id == employee.Id);

            if(entity == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with Id " + employee.Id.ToString() + " not found to update");
            }
            else
            {
                entity.Id = employee.Id;
                entity.FirstName = employee.FirstName;
                entity.LastName = employee.LastName;
                entity.Email = employee.Email;
                entity.UserName = employee.UserName;
                entity.DateOfBirth = employee.DateOfBirth;
                entity.DateOfJoining = employee.DateOfJoining;
                entity.DateOfLeaving = employee.DateOfLeaving;
                entity.Band = employee.Band;
                entity.Level = employee.Level;
                entity.Experience = employee.Experience;
                entity.Salary = employee.Salary;
                entity.IsActive = employee.IsActive;

                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
        }

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}

        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage RemoveEmployee(int id)
        {
            var entity = _employeeList.FirstOrDefault(e => e.Id == id);

            if(entity == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with Id " + id.ToString() + " not found to delete");
            }
            else
            {
                _employeeList.Remove(entity);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
    }
}
