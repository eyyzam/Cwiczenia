using System.Collections.Generic;

namespace LINQandXML.Models.Implementations
{
	public class Customer
	{
		public string CustomerID { get; set; }

		public string CompanyName { get; set; }

		public string City { get; set; }

		public string Country { get; set; }

		public List<Order> Orders { get; set; } = new List<Order>();
	}
}
