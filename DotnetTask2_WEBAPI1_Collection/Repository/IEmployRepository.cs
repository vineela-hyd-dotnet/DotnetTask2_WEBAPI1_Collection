using DotnetTask2_WEBAPI1_Collection.Models;

namespace DotnetTask2_WEBAPI1_Collection.Repository
{
    public interface IEmployRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int employeeId);
        Employee GetByDept(string Dept);
        void Update(Employee employee);
        void UpdateEmail(int id,string email);
        void Delete(int id);
        void Add(Employee employee);

    }
}
