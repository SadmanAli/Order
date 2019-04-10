using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace OrderingFoodSystem.Models
{
	public class FoodOrderContext: DbContext
	{
		public DbSet<Registration> Registrations { get; set; }
		
	}
}