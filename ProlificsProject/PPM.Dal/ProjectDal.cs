using PPM.Model;
using System.Data.SqlClient;

namespace PPM.Dal
{
    public class ProjectDAL
    {
        string connectionString = "Server = RHJ-9F-D203\\SQLEXPRESS; Database = ProlificsProjectManager; Integrated Security=True;";

        public void AddProjectDal(Project project)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Project (ProjectId,ProjectName,StartDate,EndDate) VALUES (@ProjectId,@ProjectName,@StartDate,@EndDate)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProjectId", project.ProjectId);
                    command.Parameters.AddWithValue("@ProjectName", project.ProjectName);
                    command.Parameters.AddWithValue("@StartDate", project.StartDate);
                    command.Parameters.AddWithValue("@EndDate", project.EndDate);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Project> GetAllProjectsDal()
        {
            List<Project> projects = new List<Project>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Project";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            projects.Add(
                                new Project
                                {
                                    ProjectId = Convert.ToInt32(reader["ProjectId"]),
                                    ProjectName = reader["ProjectName"].ToString(),
                                    StartDate = Convert.ToDateTime(reader["StartDate"]),
                                    EndDate = Convert.ToDateTime(reader["EndDate"])
                                }
                            );
                        }
                    }
                }
            }

            return projects;
        }

        public Project GetProjectByIdDal(int projectId)
        {
            Project projects = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Project WHERE ProjectId = @ProjectId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProjectId", projectId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            projects = new Project
                            {
                                ProjectId = Convert.ToInt32(reader["ProjectId"]),
                                ProjectName = reader["ProjectName"].ToString(),
                                StartDate = Convert.ToDateTime(reader["StartDate"]),
                                EndDate = Convert.ToDateTime(reader["EndDate"])
                            };
                        }
                    }
                }
            }

            return projects;
        }

        public void DeleteProject(int projectId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Project WHERE ProjectId = @ProjectId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProjectId", projectId);

                    command.ExecuteNonQuery();
                }
            }
        }

        
    }
}
