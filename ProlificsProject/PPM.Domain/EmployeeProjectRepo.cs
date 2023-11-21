using PPM.Dal;
using PPM.Model;

namespace PPM.Domain;

public class EmployeeProjectRepo
{
    ProjectRepo projectRepo = new();
    EmployeeProjectDal employeeProjectDal = new();

    public void AddEmployeeToProject(EmployeeProject empProInstance)
    {
        employeeProjectDal.AddEmployeeToProject(empProInstance);

        // for (int i = 0; i < projectRepo.ViewAll().Count; i++)
        // {
        //     if (pid == projectRepo.ViewAll()[i].ProjectId)
        //     {
        //         projectRepo.ViewAll()[i].projectEmployees.Add(emp);
        //     }
        // }
    }

    public void DeleteEmployeeToProject(int pid, int emp)
    {
        employeeProjectDal.RemoveEmployeeFromProject( pid , emp);
        // for (int i = 0; i < projectRepo.ViewAll().Count; i++)
        // {
        //     if (pid == projectRepo.ViewAll()[i].ProjectId)
        //     {
        //         projectRepo.ViewAll()[i].projectEmployees.Remove(emp);
        //     }
        // }
    }

    public List<EmployeeProject> ViewAll() 
    { 
        List<EmployeeProject> employeeProjectlist = employeeProjectDal.ViewProjectEmployeeDetails();
        return employeeProjectlist;

    }
}
