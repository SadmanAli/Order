using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrderingFoodSystem.Models
{
	public class Registration
	{
		[Key]
		public int CustomerID { get; set; }

		[Required(ErrorMessage = "This field is not required")]
		public string CustomerName { get; set; }
		[Required(ErrorMessage = "This field is required")]
		public string UserName { get; set; }
		[Required(ErrorMessage = "This field is required")]
		public string Password { get; set; }
		[Required(ErrorMessage = "This field is required")]
		public string Phonenumber { get; set; }
		[Required(ErrorMessage = "This field is required")]
		public string Email { get; set; }
		[Required(ErrorMessage = "This field is required")]
		public string DeliveryAddress { get; set; }
		
	}
}