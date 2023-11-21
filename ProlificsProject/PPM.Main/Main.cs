using System;
using PPM.Model;
using PPM.Domain;
using PPM.UI;
using SaveState;

namespace PPM.Main
{
    public class Program
    {
        public static void Main(String[] args)
        {
            int Option = 0;

            ProjectConsole projectObj1 = new();
            ConsoleAddEmployeeToProject viewobj=new();
            ConsoleUIs empObj = new();
            ConsoleRoles roleObj = new();
            ConsoleAddEmployeeToProject obj = new();

            do
            {
                Option = MainConsole.Mainfuncion();

                switch (Option)
                {
                    case 1:
                        projectObj1.ProjectModule();

                        break;

                    case 2:
                        empObj.EmployeeModule();
                        break;

                    case 3:
                        roleObj.RoleModule();
                        break;

                    case 4:
                        obj.AddingEmployeeToProject();

                        break;

                    case 5:
                        obj.DeleteEmployeeFromProject();

                        break;

                    case 6:

                        viewobj.viewEmployeesInProject();
                        break;


                    case 7:
                      SaveApplication saveApplication=  new();
                        saveApplication.SaveAppData();
                        break;
                        

                    case 8:
                        MainConsole.Exitfunction();
                        break;

                    default:
                        MainConsole.defaultfunction();
                        break;
                }
            } while (Option != 8);
        }
    }
}
