namespace CompanyControl.Api.Dto.Common
{
    public abstract class EntityDto<TPrimaryKey>
    {
        public required TPrimaryKey Id { get; set; }
    }
    public abstract class EntityDto : EntityDto<int>
    {
    }
}
