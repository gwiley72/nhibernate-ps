using System;
using System.Reflection;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace m2
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
			using (var tx = session.BeginTransaction())
			{
				var newCustomer = CreateCustomer();
				session.Save(newCustomer);
				tx.Commit();
			}
			Console.WriteLine("Press <ENTER> to exit...");
			Console.ReadLine();
		}

		private static Customer CreateCustomer()
		{
			return new Customer
			{
				FirstName = "John",
				LastName = "Doe",
				Points = 100,
				HasGoldStatus = true,
				MemberSince = new DateTime(2012, 1, 1),
				CreditRating = CustomerCreditRating.Good
			};
		}
	}
}