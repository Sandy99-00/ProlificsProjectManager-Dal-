using System;
using PPM.Model;
using IEntityOperation;

namespace PPM.Domain
{
    public class EmployeeRepo : IEntity<Employee>
    {
        public static List<Employee> employeeList = new List<Employee>();
        EmployeeDAL employeeDal=new();


        public void Add(Employee employeeObject)              
        {
            if (employeeObject.RoleId != 0)
            {
                
                employeeDal.AddEmployee( employeeObject);
            }
        }

        public List<Employee> ViewAll()
        {
           var GetDetails= employeeDal.GetAllEmployees();
           return GetDetails;
        }
        public Employee GetById(int eid)
        {
            Employee emp = new Employee();
            for (int i = 0; i < ViewAll().Count; i++)
            {
                if (eid == ViewAll()[i].EmployeeId)
                {
                    emp = ViewAll()[i];
                    return emp;
                }
            }
            return emp;
        }

        public Employee ViewByID(int employeeId)
        {
           var viewByID= employeeDal.GetEmployeeById( employeeId);
           return viewByID;
        }

        public void DeleteByID(int employeeId)
        {
            Employee employeeToDelete =ViewAll().FirstOrDefault(
                e => e.EmployeeId == employeeId
            );
            if (employeeToDelete != null)
            {
                employeeDal.DeleteEmployee(employeeId);
            }
        }
    }
}
