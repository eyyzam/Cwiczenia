﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using LINQandXML.Models.Implementations;

namespace LINQandXML.Helpers
{
	public class XMLHelper
	{
		public XElement SerializeCustomersToXML(List<Customer> customers)
		{
			return new XElement("Customers", SerializeCustomers(customers));
		}

		private static List<XElement> SerializeCustomers(List<Customer> customers)
		{
			var response = new List<XElement>();
			
			customers.ForEach(cust =>
			{
				var customer = new XElement("Customer", 
					new XElement("CustomerID", cust.CustomerID),
					new XElement("CompanyName", cust.CompanyName),
					new XElement("City", cust.City),
					new XElement("Country", cust.Country),
					new XElement("Orders", SerializeCustomersOrders(cust.Orders).Any() ? (object) SerializeCustomersOrders(cust.Orders) : string.Empty)
				);

				response.Add(customer);
			});
			return response;
		}

		private static List<XElement> SerializeCustomersOrders(List<Order> orders)
		{
			var response = new List<XElement>();

			orders.ForEach(ord =>
			{
				var order = new XElement("Order", 
					new XElement("OrderID", ord.OrderID),
					new XElement("OrderDate", ord.OrderDate),
					new XElement("Total", Math.Round(ord.Total, 2, MidpointRounding.AwayFromZero).ToString("F2").Replace(",", "."))
				);

				response.Add(order);
			});
			return response;
		}
	}
}
