using PPM.Domain;
using PPM.Dal;
using PPM.Model;
using System.Drawing;

namespace PPM.UI
{
    public class ConsoleAddEmployeeToProject
    {
        //EmployeeToProject empToProObject = new();
        EmployeeProjectRepo empProRepoObject = new();
        EmployeeProjectDal employeeProject=new();
        public void AddingEmployeeToProject()
        {
            ProjectRepo projectObj = new();
            EmployeeRepo employeeObj = new();
            ProjectDAL DalObj = new();

            Console.WriteLine("Enter the ProjectId");
            int pid = int.Parse(Console.ReadLine());
            while (true)
            {
                if (projectObj.IsProject(pid))
                {
                    Console.WriteLine("Enter the EmployeeId");
                    int emp = int.Parse(Console.ReadLine());

                    Employee employeeInstance = employeeObj.GetById(emp);
                    Project projectInstance = projectObj.ViewByID(pid);
                    

                    EmployeeProject employeeToProjectObject = new()
                    {
                        ProjectId = projectInstance.ProjectId,
                        ProjectName = projectInstance.ProjectName,
                        StartDate = projectInstance.StartDate,
                        EndDate = projectInstance.EndDate,
                        EmployeeId = employeeInstance.EmployeeId,
                        EmployeeFirstName = employeeInstance.EmployeeFirstName,
                        EmployeeLastName=employeeInstance.EmployeeLastName,
                        RoleId = employeeInstance.RoleId
                    };
                    empProRepoObject.AddEmployeeToProject(employeeToProjectObject);
                    // if (emp.RoleId != 0)
                    // {
                    //     empToProObject.AddEmployeeToProject();
                    //     Console.WriteLine("Employee is added Successfully to the Project");
                    // }
                    // else
                    // {
                    //     System.Console.WriteLine("The EmployeeId doesnot Exist");
                    // }
                }
                else
                {
                    Console.WriteLine("Enter the Valid ProjectId");
                    break;
                }
                break;
            }
        }

        public void DeleteEmployeeFromProject()
        {
            ProjectDAL projectDAL = new();
            ProjectRepo projectObj = new();
            EmployeeRepo employeeObj = new();
            Console.WriteLine("Enter the ProjectId");
            int pid1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the EmployeeId");
            int emp = int.Parse(Console.ReadLine());
            if (employeeProject.RemoveEmployeeFromProject(pid1, emp))
            {
                System.Console.WriteLine("Deleted successfully ...");
            }
            else
            {
                System.Console.WriteLine("no values present in database...");
                //    }
                //                     while (true)
                //                     {
                //                         if (projectObj.IsProject(pid1))
                //                         {
                //                             Console.WriteLine("Enter the EmployeeId");
                //                             int emp1 = int.Parse(Console.ReadLine());
                //                             var emp2 = employeeObj.GetById(emp);
                //                             projectObj.DeleteEmployeeToProject( pid1,  emp2);
                //                             Console.WriteLine("Employee is Removed Successfully from the Project");
                //                             // break;


                //                         }
                //                         else
                //                         {
                //                             Console.WriteLine("Enter the Valid ProjectId");
                //                             break;

                //                         }
                //                         break;
            }
        }

        public void viewEmployeesInProject()
        {
            List<EmployeeProject> employeeProjectlist = empProRepoObject.ViewAll();

            foreach(var item in employeeProjectlist)
            {
                Console.ForegroundColor=ConsoleColor.Green;
                System.Console.WriteLine($"Project ID: {item.ProjectId}, ProjectName:{item.ProjectName},ProjectStartDate:{item.StartDate},ProjectEndDate:{item.EndDate},EmployeeId:{item.EmployeeId},EmployeeFirstName:{item.EmployeeFirstName},EmployeeLastName:{item.EmployeeLastName},RoleId:{item.RoleId}");
                Console.ResetColor();
            }
        }

    }
}
