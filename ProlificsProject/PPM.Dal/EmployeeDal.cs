using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using PPM.Model;

public class EmployeeDAL
{
    string connectionString = "Server = RHJ-9F-D203\\SQLEXPRESS; Database = ProlificsProjectManager; Integrated Security=True;";

    public void AddEmployee(Employee employee)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            System.Console.WriteLine("entered into employee");

            string query = "INSERT INTO Employee(EmployeeId,EmployeeFirstName,EmployeeLastName,Email,MobileNumber,Address,RoleId) VALUES (@EmployeeId, @EmployeeFirstName,@EmployeeLastName,@Email,@MobileNumber,@Address,@RoleId)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                command.Parameters.AddWithValue("@EmployeeFirstName", employee.EmployeeFirstName);
                command.Parameters.AddWithValue("@EmployeeLastName", employee.EmployeeLastName);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@MobileNumber", employee.MobileNumber);
                command.Parameters.AddWithValue("@Address",employee.Address);
                command.Parameters.AddWithValue("@RoleId",employee.RoleId);
   
                command.ExecuteNonQuery();
            }
        }
    }


    public List<Employee> GetAllEmployees()
    {
        List<Employee> employees = new List<Employee>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM Employee";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee
                        {
                            EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                            EmployeeFirstName = reader["EmployeeFirstName"].ToString(),
                            EmployeeLastName = reader["EmployeeLastName"].ToString(),
                            Email=reader["Email"].ToString(),
                          
                            Address=reader["Address"].ToString(),
                            MobileNumber=Convert.ToInt64(reader["MobileNumber"]),
                            RoleId=Convert.ToInt32(reader["RoleId"])


                            // Add other properties as needed
                        };

                        employees.Add(employee);
                    }
                }
            }
        }

        return employees;
    }


    public Employee GetEmployeeById(int employeeId)
    {
        Employee employee = null;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM Employee WHERE EmployeeId = @EmployeeId";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@EmployeeId", employeeId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        employee = new Employee
                        {
                           EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                            EmployeeFirstName = reader["EmployeeFirstName"].ToString(),
                            EmployeeLastName = reader["EmployeeLastName"].ToString(),
                            Email=reader["Email"].ToString(),
                          
                            Address=reader["Address"].ToString(),
                            MobileNumber=Convert.ToInt64(reader["MobileNumber"]),
                            RoleId=Convert.ToInt32(reader["RoleId"])
                        };
                    }
                }
            }
        }

        return employee;
    }

    public void DeleteEmployee(int employeeId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "DELETE FROM Employee WHERE EmployeeId = @EmployeeId";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@EmployeeId", employeeId);

                command.ExecuteNonQuery();
            }
        }
    }
}


