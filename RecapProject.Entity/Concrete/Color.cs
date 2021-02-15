using Core.Entity;

namespace RecapProject.Entities.Concrete
{
    public class Color:IEntity
    {
        public int Id { get; set; }
        public string ColorName { get; set; }
    }
}
