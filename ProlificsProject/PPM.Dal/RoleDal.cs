using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using PPM.Model;

public class RoleDAL
{
     string connectionString =
            "Server = RHJ-9F-D203\\SQLEXPRESS; Database = ProlificsProjectManager; Integrated Security=True;";

    public void AddRole(Roles role)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "INSERT INTO Roles (RoleId,RoleName) VALUES (@RoleId,@RoleName)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.AddWithValue("@RoleId", role.RoleId);
                command.Parameters.AddWithValue("@RoleName", role.RoleName);

                command.ExecuteNonQuery();
            }
        }
    }


    public List<Roles> GetAllRoles()
    {
        List<Roles> roles = new List<Roles>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM Roles";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Roles role = new Roles
                        {
                            RoleId = Convert.ToInt32(reader["RoleId"]),
                            RoleName = reader["RoleName"].ToString()
                        };

                        roles.Add(role);
                    }
                }
            }
        }

        return roles;
    }
     public Roles GetRoleById(int roleId)
    {
        Roles role = null;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM Roles WHERE RoleId = @RoleId";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@RoleId", roleId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        role = new Roles
                        {
                            RoleId = Convert.ToInt32(reader["RoleId"]),
                            RoleName = reader["RoleName"].ToString()
                        };
                    }
                }
            }
        }

        return role;
    }

    public void DeleteRole(int roleId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "DELETE FROM Roles WHERE RoleId = @RoleId";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@RoleId", roleId);

                command.ExecuteNonQuery();
            }
        }
    }
}




    