using System;
using System.Reflection.Metadata;
using PPM.Model;
using PPM.Dal;
using IEntityOperation;

namespace PPM.Domain
{
    public class ProjectRepo : IEntity<Project>
    {
        public static List<Project> projectList = new List<Project>();

        ProjectDAL DalObj=new ProjectDAL();

        public  Project ViewByID(int id)
        {
           var viewProjectById=DalObj.GetProjectByIdDal(id);
           return viewProjectById;
        }
 
        public  void DeleteByID(int deleteid)
        {
           DalObj.DeleteProject(deleteid);
        }

        public void Add( Project ProjectObject)
        {
            // projectList.Add(ProjectObject);

              DalObj.AddProjectDal(ProjectObject);
        }

        public bool IsProject(int pid)

        {
            for (int i = 0; i < ViewAll().Count; i++)
            {
                if (pid == ViewAll()[i].ProjectId)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Project> ViewAll()
        {
            var projectList1 =DalObj.GetAllProjectsDal();
            return projectList1;
        }

      
    }
}
