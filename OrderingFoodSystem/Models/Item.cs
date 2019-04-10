using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderingFoodSystem.Models
{
	public class Item
	{
		[Key]
		public int ItemID { get; set; }
		public int RestaurantID { get; set; }
		public string ItemName { get; set; }
		public string Description { get; set; }
		public int ItemPrice { get; set; }
		public float Rating { get; set; }
	}
	public class ItemDBContext : DbContext
	{
		public DbSet<Item> Items { get; set; }
	}
}