namespace Bjss.ProductBasket.Persistence.Setup
{
    using Mappings;
    using NHibernate;
    using NHibernate.Tool.hbm2ddl;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;

    public static class DatabaseInstaller
    {
        public static ISessionFactory Setup(string databaseFileName)
        {
            return Fluently.Configure()
                           .Database(SQLiteConfiguration.Standard
                               .UsingFile(databaseFileName)
                               .DoNot.ShowSql())
                           .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProductMap>())
                           .ExposeConfiguration(config => new SchemaUpdate(config).Execute(false, true))
                           .BuildSessionFactory();
        }
    }
}
