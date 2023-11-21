using System.ComponentModel;

namespace IEntityOperation
{
    public interface IEntity<T>
    {
        public void Add(T employee);
 
        public List<T> ViewAll();
 
        public T ViewByID(int Id);
 
        public void DeleteByID(int Id);
    }
}