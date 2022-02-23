using System;
using System.ComponentModel.DataAnnotations;

namespace EF_MOM_3_2.Models
{
	public class Customer
	{
        public int CustomerId { get; set; }

		public string? Username { get; set; }

		public ICollection<CD>? CD { get; set; }

		public Customer()
		{
		}
	}
}

