using LINQandXML.Models.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQandXML.Helpers
{
	public class FormatHelper
	{
		public string FormatListOfCustomersToStandardOutput(List<Customer> customers, int year, double minTotal)
		{
			var response = new StringBuilder();
			var sortAndFilter = new SortAndFilterHelper();

			var filteredAndSortedCustomersList = sortAndFilter.SortAndFilterListOfCustomers(customers, year, minTotal);

			filteredAndSortedCustomersList.ForEach(customer =>
			{
				var sum = Math.Round(customer.Orders.Sum(x => x.Total), 2, MidpointRounding.AwayFromZero);
				response.AppendLine($@"{customer.CompanyName}; {sum.ToString("F2").Replace(",", ".")}");
			});

			if (response.ToString() == string.Empty)
				response.AppendLine("empty");

			return response.ToString();
		}
	}
}
