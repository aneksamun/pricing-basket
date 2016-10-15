namespace Bjss.ProductBasket.Persistence.Repositories
{
    using Core.Entities;
    using Core.Repositories;
    using NHibernate;

    public sealed class RuleRepository : Repository<Rule, int>, IRuleRepository
    {
        public RuleRepository(ISession session)
            : base(session)
        {
        }
    }
}
