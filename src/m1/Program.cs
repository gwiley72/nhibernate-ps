using System;
using System.Linq;
using System.Reflection;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Linq;

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
				x.LogSqlInConsole = true;
			});
			cfg.AddAssembly(Assembly.GetExecutingAssembly());
			var sessionFactory = cfg.BuildSessionFactory();

			using (var session = sessionFactory.OpenSession())
			using(var tx = session.BeginTransaction())
			{
				var query = from customer in session.Query<Customer>()
							where customer.LastName == "Comacho"
							select customer;
				var c = query.First();
				session.Delete(c);
				tx.Commit();
			}

			Console.WriteLine("Press any key to continue.");
			Console.Read();
		}
	}
}
