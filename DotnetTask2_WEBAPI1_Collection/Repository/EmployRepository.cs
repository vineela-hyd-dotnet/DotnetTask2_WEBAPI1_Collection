using DotnetTask2_WEBAPI1_Collection.Models;

namespace DotnetTask2_WEBAPI1_Collection.Repository
{
    public class EmployRepository : IEmployRepository
    {
        
        private static List<Employee> _employees = new List<Employee>()
        {
            new Employee{Id=1,Name="Vineela",Email="vineela@gmail.com",Department="IT",Mobile="7396489807"},
            new Employee{Id=2,Name="Vineetha",Email="vineetha@gmail.com",Department="HR",Mobile="8976849576"
        }
        };
        public void Add(Employee employee)
        {
         _employees.Add(employee);
        }

        public void Delete(int id)
        {
            var emp=_employees.FirstOrDefault(x => x.Id == id);
            if(emp != null)
                _employees.Remove(emp);

            
        }

        public IEnumerable<Employee> GetAll()
        {
           return _employees;
        }

        public Employee GetByDept(string Dept)
        {
            var emp=_employees.FirstOrDefault(x=>x.Department== Dept);
            if(emp != null)
                return emp;
            return null;

        }

        public Employee GetById(int employeeId)
        {
            var emp=_employees.FirstOrDefault(x=>x.Id==employeeId);
            if (emp != null)
                return emp;
            return null;

        }

        public void Update(Employee employee)
        {
            var existing=_employees.FirstOrDefault(x=>x.Id == employee.Id);
            if (existing != null)
            {
                existing.Email = employee.Email;
                existing.Department = employee.Department;
                existing.Mobile = employee.Mobile;
                existing.Name = employee.Name;
            }
           }

        public void UpdateEmail(int id,string email)
        {
            var existing = _employees.FirstOrDefault(x => x.Id == id);
            if (existing != null)
            {
                existing.Email = email;
            }

        }
    }
}
