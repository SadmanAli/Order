using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace OrderingFoodSystem.Models
{
	public class Restaurantls
	{
		[Key]
		public int RestaurantID { get; set; }
		public string RestaurantName { get; set; }
		public string Location { get; set; }
	}

	public class RestaurantlsDBContext : DbContext
	{
		public DbSet<Restaurantls> Restaurantlss { get; set; }
	}
}