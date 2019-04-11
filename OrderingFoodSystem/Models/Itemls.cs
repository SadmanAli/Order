using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace OrderingFoodSystem.Models
{
	public class Itemls
	{
		[Key]
		public int ItemID { get; set; }
		public string Name { get; set; }
		public float Price { get; set; }
	}

	public class ItemlsDBContext : DbContext
	{
		public DbSet<Itemls> Itemlss { get; set; }

	}
}