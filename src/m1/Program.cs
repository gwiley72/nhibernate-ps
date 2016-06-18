using System.Reflection;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace m1
{
	public class Program
	{
		static void Main(string[] args)
		{
			var cfg = new Configuration();
			cfg.DataBaseIntegration(x =>
			{
				x.ConnectionString = "Server=SMACCO\\SQLEXPRESS;Database=NHibernateDemo;Integrated Security=SSPI;";
				x.Driver<SqlClientDriver>();
				x.Dialect<MsSql2012Dialect>();
			});
			cfg.AddAssembly(Assembly.GetExecutingAssembly());
			var sessionFactory = cfg.BuildSessionFactory();
			using (var session = sessionFactory.OpenSession())
			using(var tx = session.BeginTransaction())
			{
				tx.Commit();
			}
		}
	}
}
