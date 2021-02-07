using System.Collections.Generic;
using System.Linq;
using LINQandXML.Models.Implementations;

namespace LINQandXML.Helpers
{
	public class SortAndFilterHelper
	{
		public List<Customer> SortAndFilterListOfCustomers(List<Customer> customersList, int year, double minTotal)
		{
			var filteredCustomers = customersList.Select(c => {
				c.Orders = c.Orders.Where(o => o.OrderDate.Year == year && o.Total >= minTotal).ToList();
				return c;
			}).Where(c => c.Orders.Any()).ToList();

			filteredCustomers.ForEach(customer => customer.Orders = customer.Orders.OrderBy(o => o.Total).ToList());
			filteredCustomers = filteredCustomers.OrderBy(c => c.CompanyName).ToList();

			return filteredCustomers;
		}
	}
}
