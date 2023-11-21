using PPM.Domain;
using PPM.Model;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace PPM.UI
{
    public class ConsoleUIs
    {
        EmployeeRepo empObj = new();

        public void EmployeeModule()
        {
            while (true)
            {
                Console.WriteLine("Employee Module");
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
                        AddingEmployee();
                        break;

                    case "2":
                        ViewAll();
                        break;

                    case "3":
                        ViewEmployeeById();
                        break;

                    case "4":
                        DeleteEmployee();
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid operation.");
                        break;
                }
            }
        }

        public static List<Employee> ViewEmployees()
        {
            return EmployeeRepo.employeeList;
        }

        public void ViewAll()
        {
            System.Console.WriteLine();

            System.Console.ForegroundColor = ConsoleColor.Green;
         
            foreach (Employee item in empObj.ViewAll())
            {
                System.Console.WriteLine(
                    $"EmployeeId:{item.EmployeeId},EmployeeFirstName:{item.EmployeeFirstName},EmployeeLastName:{item.EmployeeLastName},Email:{item.Email},Address:{item.Address},RoleId:{item.RoleId}"
                );
            }
            System.Console.ResetColor();
        }

        public Employee AddingEmployee()
        {
            Employee employeeObject = new Employee();

            RoleRepo roleObj = new();
            while (true)
            {
                try
                {
                    System.Console.WriteLine("Enter the EmployeeId");
                    employeeObject.EmployeeId = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    continue;
                }

                System.Console.WriteLine();
                System.Console.WriteLine("Enter the  employee firstname:");
                employeeObject.EmployeeFirstName = System.Console.ReadLine();

                System.Console.WriteLine();
                System.Console.WriteLine("Enter the employee lastname:");
                employeeObject.EmployeeLastName = System.Console.ReadLine();

                System.Console.WriteLine();
                while (true)
                {
                    System.Console.WriteLine("Enter the employee email");
                    employeeObject.Email = System.Console.ReadLine();
                    Regex regex = new Regex(
                        @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                        RegexOptions.CultureInvariant | RegexOptions.Singleline
                    );
                    // Console.WriteLine($"The email is {employeeObject.Email}");
                    bool isValidEmail = regex.IsMatch(employeeObject.Email);
                    if (!isValidEmail)
                    {
                        Console.WriteLine($"The email is Invalid");
                        continue;
                    }

                    while (true)
                    {
                        System.Console.WriteLine();
                        System.Console.WriteLine("Enter the  employee mobilenumber:");
                        string enteredMobileNumber = System.Console.ReadLine();

                        if (
                            enteredMobileNumber.Length == 10
                            && long.TryParse(enteredMobileNumber, out long Mobile)
                        )
                        {
                            employeeObject.MobileNumber = Mobile;
                            break;
                        }
                        else
                        {
                            System.Console.WriteLine("Enter Proper mobile number");
                        }
                    }

                    System.Console.WriteLine();
                    System.Console.WriteLine("Enter the  employee address:");
                    employeeObject.Address = System.Console.ReadLine();

                    System.Console.WriteLine();

                    System.Console.WriteLine("Enter the  employee roleId:");
                    int roleId = int.Parse(System.Console.ReadLine());
                    while (true)
                    {
                        if (roleObj.IsRole(roleId))
                        {
                            employeeObject.RoleId = roleId;
                        }
                        else
                        {
                            Console.WriteLine("The RoleId doesnot exist");
                        }

                        System.Console.ResetColor();

                        Console.WriteLine("\n\n");

                        System.Console.ForegroundColor = ConsoleColor.Gray;
                        System.Console.WriteLine(" Employees Details succesfully added...");
                        System.Console.ResetColor();

                        break;
                    }
                    break;
                }

                empObj.Add(employeeObject);
                return employeeObject;
            }
        }

        public void ViewEmployeeById()
        {
            Console.WriteLine("Enter the Employee ID: ");
            int employeeId = int.Parse(Console.ReadLine());

            Employee employee = empObj.ViewByID(employeeId);

            if (employee != null)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"Employee ID: {employee.EmployeeId}");
                Console.WriteLine($"First Name: {employee.EmployeeFirstName}");
                Console.WriteLine($"Last Name: {employee.EmployeeLastName}");
                Console.WriteLine($"Email: {employee.Email}");
                Console.WriteLine($"MobileNumber:{employee.MobileNumber}");
                Console.WriteLine($"Address:{employee.Address}");
                Console.WriteLine($"Role Id:{employee.RoleId}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Employee does not exist.");
            }
        }

        public void DeleteEmployee()
        {
            Console.WriteLine();
            foreach (var employee in EmployeeRepo.employeeList)
            {
                Console.WriteLine($"Employee ID: {employee.EmployeeId}");
                Console.WriteLine($"First Name: {employee.EmployeeFirstName}");
                Console.WriteLine($"Last Name: {employee.EmployeeLastName}");
                Console.WriteLine($"Email: {employee.Email}");
                Console.WriteLine($"MobileNumber:{employee.MobileNumber}");
                Console.WriteLine($"Address:{employee.Address}");
                Console.WriteLine($"Role Id:{employee.RoleId}");
            }

            int initialCount = empObj.ViewAll().Count;

            Console.WriteLine();
            Console.WriteLine("Enter the Employee ID that you want to delete: ");
            int employeeIdToDelete = int.Parse(Console.ReadLine());
            // foreach (var project in ProjectRepo.projectList)
            // {
            //     var employee = project.projectEmployees.FirstOrDefault(
            //         emp => emp.EmployeeId == employeeIdToDelete
            //     );

            //     if (employee != null)
            //     {
            //         Console.WriteLine(
            //             $"Employee with ID {employeeIdToDelete} is working in project '{project.ProjectName}'."
            //         );
            //         break;
            //     }
            //     else
            //     {
                    empObj.DeleteByID(employeeIdToDelete);

                    int finalCount = EmployeeRepo.employeeList.Count;

                    if (finalCount < initialCount)
                    {
                        Console.WriteLine("Employee deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No employee with the specified ID found.");
                    }
                }
            }
        }
//     }
// }
