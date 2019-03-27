using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OrderingFoodSystem.Models
{
	public class Consumer
	{
		[Key]
		public int CustomerID { get; set; }
		public string Name { get; set; }
		public string Phonenumber { get; set; }
		public string Email { get; set; }
		public string DeliveryAddress { get; set; }
		public string Password { get; set; }
	}

	public class ConsumerDBContext : DbContext
	{
		public DbSet<Consumer> Consumers { get; set; }
	}

	


}