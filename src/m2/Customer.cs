using System;

namespace m2
{
	public class Customer
	{
		public virtual int Id { get; set; }
		public virtual string FirstName { get; set; }
		public virtual string LastName { get; set; }
		public virtual int Points { get; set; }
		public virtual bool HasGoldStatus { get; set; }
		public virtual DateTime MemberSince { get; set; }
		public virtual CustomerCreditRating CreditRating { get; set; }

		public override string ToString()
		{
			return $"Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, Points: {Points}";
		}
	}

	public enum CustomerCreditRating
	{
		Excellent, Good, Neutral, Poor, Terrible
	}
}