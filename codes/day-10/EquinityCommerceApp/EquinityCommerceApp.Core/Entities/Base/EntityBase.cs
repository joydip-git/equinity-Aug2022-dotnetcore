namespace EquinityCommerceApp.Core.Entities.Base
{
    public class EntityBase<TId> : IEntityBase<TId>
    {
        public virtual TId Id { get; set ; }
    }
}
