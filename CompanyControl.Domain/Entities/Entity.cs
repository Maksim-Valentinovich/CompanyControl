namespace CompanyControl.Domain.Entities
{
    public abstract class Entity<TPrimaryKey>
    {
        public required TPrimaryKey Id { get; set; }
    }
    public abstract class Entity : Entity<int>
    {
    }
}
