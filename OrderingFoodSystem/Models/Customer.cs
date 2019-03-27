using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace OrderingFoodSystem.Models
{
	public class Customer
	{
		public int CustomerID { get; set; }
		public string Name { get; set; }
		public string phonenumber { get; set; }
		public string Email { get; set; }
		public string DeliveryAddress { get; set; }
		//public string Password { get; set; }
	}

	public class CustomerDBContext: DbContext
	{
		public DbSet<Customer> Customers { get; set; }
	}
}