using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using PPM.Model;

namespace PPM.Dal;

public class EmployeeProjectDal
{
    string connectionString =
        "Server = RHJ-9F-D203\\SQLEXPRESS; Database = ProlificsProjectManager; Integrated Security=True;";

    public void AddEmployeeToProject(EmployeeProject employeeProject)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query =
                "INSERT INTO AddingEmployeeToProject (ProjectId,ProjectName,StartDate,EndDate,EmployeeId,EmployeeFirstName,EmployeeLastName,RoleId) VALUES ( @ProjectId,@ProjectName,@StartDate,@EndDate,@EmployeeId,@EmployeeFirstName,@EmployeeLastName,@RoleId)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // command.Parameters.AddWithValue("@Id", employeeToProject.Id);
                command.Parameters.AddWithValue("@ProjectId", employeeProject.ProjectId);
                command.Parameters.AddWithValue("@ProjectName", employeeProject.ProjectName);
                command.Parameters.AddWithValue("@StartDate", employeeProject.StartDate);
                command.Parameters.AddWithValue("@EndDate", employeeProject.EndDate);
                command.Parameters.AddWithValue("@EmployeeId", employeeProject.EmployeeId);
                command.Parameters.AddWithValue("@EmployeeFirstName", employeeProject.EmployeeFirstName);
                command.Parameters.AddWithValue("@EmployeeLastName", employeeProject.EmployeeLastName);
                command.Parameters.AddWithValue("@RoleId", employeeProject.RoleId);

                command.ExecuteNonQuery();
            }
        }
    }

    public bool RemoveEmployeeFromProject(int projectId, int employeeId)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query1 =
                    "SELECT COUNT(*) FROM AddingEmployeeToProject  WHERE ProjectId = @ProjectId AND EmployeeId = @EmployeeId";
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    command.Parameters.AddWithValue("@ProjectId", projectId);
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);

                    var result = command.ExecuteScalar();
                    int rowCount = (result != null) ? Convert.ToInt32(result) : 0;
                    if (rowCount != 0)
                    {
                        string query =
                            "DELETE FROM AddingEmployeeToProject WHERE ProjectId = @ProjectId AND EmployeeId = @EmployeeId";

                        using (SqlCommand commands = new SqlCommand(query, connection))
                        {
                            commands.Parameters.AddWithValue("@ProjectId", projectId);
                            commands.Parameters.AddWithValue("@EmployeeId", employeeId);

                            commands.ExecuteNonQuery();
                            return true;
                        }
                    }
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("no value present in database" + $"{ex.StackTrace}");
            return false;
        }
    }

    public List<EmployeeProject> ViewProjectEmployeeDetails()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query1 =
                "select * from AddingEmployeeToProject";
            using (SqlCommand command = new SqlCommand(query1, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<EmployeeProject> listObject = new List<EmployeeProject>();

                    while (reader.Read())
                    {
                        EmployeeProject instance = new()
                        {
                            ProjectId = Convert.ToInt32(reader["ProjectID"]),
                            ProjectName = reader["ProjectName"].ToString(),
                            StartDate = Convert.ToDateTime(reader["StartDate"]),
                            EndDate = Convert.ToDateTime(reader["EndDate"]),
                            EmployeeId = Convert.ToInt32(reader["EmployeeID"]),
                            EmployeeFirstName = reader["EmployeeFirstName"].ToString(),
                            EmployeeLastName = reader["EmployeeLastName"].ToString(),
                            RoleId = Convert.ToInt32(reader["RoleId"])
                        };

                        listObject.Add(instance);
                    }
                    return listObject;
                }
            }
        }
    }
}
