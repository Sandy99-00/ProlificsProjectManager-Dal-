using PPM.Model;
using IEntityOperation;
namespace PPM.Domain
{
    public class RoleRepo:IEntity<Roles>
    {
        
     
        public static List<Roles> ListRole = new List<Roles>();

           RoleDAL RoleDalObj=new RoleDAL();


        public void Add(Roles RoleObj)
        {
           RoleDalObj.AddRole(RoleObj);
            System.Console.WriteLine("Added Role details");
        }

       
        
    public List<Roles> ViewAll()
    {
        var RoleList=RoleDalObj.GetAllRoles();
        return RoleList;
    }

        public bool IsRole(int rid)
        {
            for (int i = 0; i < ViewAll().Count; i++)
            {
                if (rid == ViewAll()[i].RoleId)
                {
                    return true;
                }
            }
            return false;
        }

        public Roles ViewByID(int roleId)
        {
            var ViewRoleById=RoleDalObj.GetRoleById( roleId);
            return ViewRoleById;
        }

        public void DeleteByID(int roleId)
        {
            Roles roleToDelete = ViewAll().FirstOrDefault(r => r.RoleId == roleId);
            if (roleToDelete != null)
            {
               RoleDalObj.DeleteRole(roleId);
            }
        }
    }
}
