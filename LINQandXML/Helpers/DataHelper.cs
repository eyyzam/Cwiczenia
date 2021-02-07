using System;
using System.Collections.Generic;
using LINQandXML.Models.Implementations;

namespace LINQandXML.Helpers
{
	public class DataHelper
	{
		public List<Customer> GetCustomers()
		{
			var response = new List<Customer>();

			response.AddRange(new List<Customer>()
			{
				new Customer()
				{
					CustomerID = "KRAHA",
					CompanyName = "Krakowski Handelek",
					City = "Kraków",
					Country = "Poland",
					Orders = new List<Order>()
				},
				new Customer()
				{
					CustomerID = "ANATR",
					CompanyName = "Ana Trujillo Emparedados y helados",
					City = "Mexico",
					Country = "Mexico",
					Orders = new List<Order>()
					{
						new Order()
						{
							OrderID = 10200,
							OrderDate = DateTime.Parse("2014-09-18T00:00:00"),
							Total = 88.00
						}
					}
				},
				new Customer()
				{
					CustomerID = "ANTON",
					CompanyName = "Antonio Moreno Taqueria",
					City = "Rio de Janeiro",
					Country = "Brazil",
					Orders = new List<Order>()
					{
						new Order()
						{
							OrderID = 10365,
							OrderDate = DateTime.Parse("2014-11-27T00:00:00"),
							Total = 403.20
						},
						new Order()
						{
							OrderID = 10507,
							OrderDate = DateTime.Parse("2015-04-15T00:00:00"),
							Total = 749.06
						}
					}
				}
			});

			return response;
		}
	}
}
