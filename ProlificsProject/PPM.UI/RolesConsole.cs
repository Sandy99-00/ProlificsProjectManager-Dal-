using PPM.Domain;
using PPM.Model;
using PPM.UI;

public class ConsoleRoles
{

    public void RoleModule()
    {
       
        while (true)
        {
            Console.WriteLine("Role Module");
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
                    AddingRole();
                    break;

                case "2":
                    ViewAll();
                    break;

                case "3":
                    ViewRoleById();
                    break;

                case "4":
                    DeleteRole();
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please select a valid operation.");
                    break;
            }
        }
    }

    public Roles AddingRole()
    {
        Roles roleObj = new Roles();
        RoleRepo roleRepoObj = new RoleRepo();

        Console.WriteLine("Enter the RoleId");
        roleObj.RoleId = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the RoleName");
        roleObj.RoleName = Console.ReadLine();

        roleRepoObj.Add(roleObj);

        return roleObj;
    }

    public void ViewAll()
        {
             RoleRepo roleRepoObj = new RoleRepo();
        
            foreach (Roles i in roleRepoObj.ViewAll())
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"RoleId:{i.RoleId},RoleName:{i.RoleName}");
                Console.ResetColor();
            }
            

        }

    public void ViewRoleById()
    {
        RoleRepo roleRepoObj = new RoleRepo();
        Console.WriteLine("Enter the Role ID: ");
        int roleId = int.Parse(Console.ReadLine());

        Roles role = roleRepoObj.ViewByID(roleId);

        if (role != null)
        {
             Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine($"Role ID: {role.RoleId}");
            Console.WriteLine($"Role Name: {role.RoleName}");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("Role does not exist.");
        }
    }

    public void DeleteRole()
    {
        RoleRepo roleRepoObj = new RoleRepo();
        Console.WriteLine();
        foreach (var role in roleRepoObj.ViewAll())
        {
            Console.WriteLine($"Role ID: {role.RoleId}");
            Console.WriteLine($"Role Name: {role.RoleName}");
        }
        int initialCount = roleRepoObj.ViewAll().Count;
        Console.WriteLine();
        Console.WriteLine("Enter the Role ID that you want to delete: ");
        int roleIdToDelete = int.Parse(Console.ReadLine());

        // foreach (var project in ProjectRepo.projectList)
        // {
        //     var role = project.projectEmployees.FirstOrDefault(emp => emp.RoleId == roleIdToDelete);

        //     if (role != null)
        //     {
        //         Console.WriteLine(
        //             $"An employee with Role ID {roleIdToDelete} is working in project '{project.ProjectName}'."
        //         );
        //         break;
        //     }
        //     else
        //     {
                roleRepoObj.DeleteByID(roleIdToDelete);
                int finalCount = roleRepoObj.ViewAll().Count;
                if (finalCount < initialCount)
                {
                    Console.WriteLine("Role deleted successfully.");
                }
                else
                {
                    Console.WriteLine("No role with the specified ID found.");
                }
            }
        }
//     }
// }
