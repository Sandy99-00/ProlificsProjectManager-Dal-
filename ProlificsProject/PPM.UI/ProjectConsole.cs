using PPM.Model;
using PPM.Domain;
using PPM.UI;

public class ProjectConsole
{
    ProjectRepo projectRepo = new();
    EmployeeRepo employeeRepo=new();

    ConsoleAddEmployeeToProject obj = new();

    public void ProjectModule()
    {
        while (true)
        {
            Console.WriteLine("Project Module");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. List All");
            Console.WriteLine("3. List By ID");
            Console.WriteLine("4. Delete");
            Console.WriteLine("5. Return to Main Menu");
            Console.Write("Enter your choice: ");
            string operation = Console.ReadLine();

            switch (operation)
            {
                case "1":
                    AddingProject();

                    break;

                case "2":
                    ViewProject();
                    break;

                case "3":
                    ViewByProjectId();
                    break;

                case "4":
                    DeleteProjectById();
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please select a valid operation.");
                    break;
            }
        }
    }

    public static List<Project> ViewDetails()
    {
        return ProjectRepo.projectList;
    }

    public void ViewProjectListWithEmployees()
    {
        Console.WriteLine("\n- Project Details are :");
        for (int i = 0; i < ProjectRepo.projectList.Count; i++)
        {
            Console.WriteLine("\n- Project ID = " + ProjectRepo.projectList[i].ProjectId);
            Console.WriteLine("  - Name Of Project = " + ProjectRepo.projectList[i].ProjectName);
            Console.WriteLine("  - Start date : " + ProjectRepo.projectList[i].StartDate);
            Console.WriteLine("  - End date : " + ProjectRepo.projectList[i].EndDate);
            Console.WriteLine("  - Employees Working on : ");
            for (int j = 0; j < ProjectRepo.projectList[i].projectEmployees.Count; j++)
            {
                Console.WriteLine(
                    "    - "
                        + ProjectRepo.projectList[i].projectEmployees[j].EmployeeFirstName
                        + " "
                        + ProjectRepo.projectList[i].projectEmployees[j].EmployeeLastName
                );
                Console.WriteLine(
                    "    - RoleID = " + ProjectRepo.projectList[i].projectEmployees[j].RoleId
                );
            }
        }


                        
    }

    public void ViewProject()
    {
        System.Console.WriteLine("The Projects List");
        System.Console.WriteLine();

        foreach (Project item in projectRepo.ViewAll())
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            System.Console.WriteLine(
                $"ProjectId:{item.ProjectId},ProjectName:{item.ProjectName},Startdate:{item.StartDate},Enddate:{item.EndDate}"
            );
            Console.ResetColor();
        }
    }

    public Project AddingProject()
    {
        ProjectRepo pr = new ProjectRepo();
        Project projectObject = new Project();
        System.Console.WriteLine();
        System.Console.WriteLine("Enter the ProjectId");
        projectObject.ProjectId = int.Parse(Console.ReadLine());

        while (true)
        {
            if (!pr.IsProject(projectObject.ProjectId))
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Enter the projectname ");
                projectObject.ProjectName = System.Console.ReadLine();

                System.Console.WriteLine();
                System.Console.WriteLine("Enter the starting date of project (yyyy-mm-dd)");
                projectObject.StartDate = DateTime.Parse(System.Console.ReadLine());

                while (true)
                {
                    System.Console.WriteLine();
                    System.Console.ForegroundColor = ConsoleColor.Gray;
                    System.Console.WriteLine("Enter the End date of project (yyyy-mm-dd)");
                    projectObject.EndDate = DateTime.Parse(System.Console.ReadLine());
                    System.Console.ResetColor();

                    if (projectObject.EndDate > projectObject.StartDate)
                    {
                        break;
                    }
                    else
                    {
                        System.Console.WriteLine();
                        System.Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine(
                            "** Entered date less than or equal to start date enter proper date **"
                        );
                        System.Console.ResetColor();
                    }
                }
            }
            else
            {
                System.Console.WriteLine("The Project already exist");
                break;
            }

            break;
        }

        pr.Add(projectObject);

        System.Console.WriteLine("Do you want to add Employee with project 'Yes' or 'No' ");

        string EmpToProject = Console.ReadLine();

        if (EmpToProject == "Yes")
        {
            if (employeeRepo.ViewAll().Count == 0)
            {
                System.Console.WriteLine("There is no Employee in the List to Add");
            }
            else
            {
                obj.AddingEmployeeToProject();
            }
        }
        // else
        // {
        //   return projectObject;

        // }

        return projectObject;
    }

    public void ViewByProjectId()
    {
        ProjectRepo projectObj = new();
        System.Console.WriteLine("Enter the projectId ");
        int projectById = int.Parse(System.Console.ReadLine());

        var project = projectObj.ViewByID(projectById);
        if (project != null)
        {
            if (project.ProjectId == projectById)
            {
                System.Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine(
                    $"ProjectId:{project.ProjectId}, ProjectName: {project.ProjectName}, Startsate: {project.StartDate}, EndDate:{project.EndDate}"
                );
                Console.ResetColor();
            }

         
        }
        else{
             Console.ForegroundColor = ConsoleColor.Red;
               System.Console.WriteLine("project does not exist");
                 Console.ResetColor();
        }
    }

    public void DeleteProjectById()
    {
        ProjectRepo projectObj = new();
        System.Console.WriteLine();

        foreach (var item in ProjectRepo.projectList)
        {
            System.Console.WriteLine(
                $"ProjectId:{item.ProjectId}, ProjectName: {item.ProjectName}, Startsate: {item.StartDate}, EndDate:{item.EndDate}"
            );
        }

        int initialCount = projectRepo.ViewAll().Count;

        System.Console.WriteLine();
        System.Console.WriteLine("Enter the projectId that you want delete");
        int projectIdToDelete = int.Parse(System.Console.ReadLine());
        projectObj.DeleteByID(projectIdToDelete);

        int finalCount = projectRepo.ViewAll().Count;

        if (finalCount < initialCount)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("Project deleted successfully.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            System.Console.WriteLine("No project with the specified ID found.");
            Console.ResetColor();
        }
    }
}
