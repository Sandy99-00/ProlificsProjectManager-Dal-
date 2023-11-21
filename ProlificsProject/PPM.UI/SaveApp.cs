using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PPM.Domain;
using PPM.Model;

namespace   SaveState
{
public class SaveApplication
{


        public static void SaveApp(
           List<Project> projectList ,
           List<Employee> employeeList ,
            List<Roles> ListRole,
            string projectData,
            string employeeData,
            string roleData
            
        )
        {
            try
            {
                using (var writer = new StreamWriter(projectData))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(  List<Project>));
                    System.Console.WriteLine($"  ----->   {projectList.Count}");
                    serializer.Serialize(writer, projectList);
                }
 
                using (var writer = new StreamWriter(employeeData))
                {
                    XmlSerializer serializer = new XmlSerializer(
                        typeof( List<Employee> )
                    );
                    serializer.Serialize(writer, employeeList);
                }
 
                using (var writer = new StreamWriter(roleData))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof( List<Roles> ));
                    serializer.Serialize(writer, ListRole);
                }
 
                // using (var writer = new StreamWriter(employeeProjectData))
                // {
                //     XmlSerializer serializer = new XmlSerializer(
                //         typeof(List<Project>)
                //     );
                //     serializer.Serialize(writer, employeeProjects);
                // }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while serializing data: " + ex.Message);
            }
        }
 
        public void SaveAppData()
        {
            string projectPath = "C:\\Users\\SMaduri\\Desktop\\ProlificsProjectManager\\PPM.UI\\SerializeData.xml";
            string employeePath = "C:\\Users\\SMaduri\\Desktop\\ProlificsProjectManager\\PPM.UI\\SerializeDataEmployee.xml";
            string rolePath = "C:\\Users\\SMaduri\\Desktop\\ProlificsProjectManager\\PPM.UI\\SerializeDataRole.xml";
            // string employeeProjectPath = "C:\\Users\\SMaduri\\Desktop\\ProlificsProjectManager\\PPM.UI\\serializedataaddemployetoproject.xml";
 
            SaveApplication.SaveApp(
                ProjectRepo.projectList,
                EmployeeRepo.employeeList,
                RoleRepo.ListRole,
                projectPath,
                employeePath,
                rolePath
                // employeeProjectPath
            );
 
            Console.WriteLine("Application data saved successfully.");
        }
    }
}