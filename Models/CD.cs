using System;
using System.ComponentModel.DataAnnotations;

namespace EF_MOM_3_2.Models
{
	public class CD
	{
        public int CDId { get; set; }
		[Required]
        public string? Album { get; set; }

		public int? ArtistId { get; set; }
		public Artist? Artist { get; set; }
		public int? CustomerId { get; set; }
		public Customer? Customer { get; set; }

		public DateTime? DateLent { get; set; } = null;

		public CD()
		{
		}
	}
}

