using System;
using System.ComponentModel.DataAnnotations;

namespace EF_MOM_3_2.Models
{
	public class Artist
	{
        public int ArtistId { get; set; }
		public string? Name { get; set; }
		public string? Genre { get; set; }

		public ICollection<CD>? CD { get; set; }

        public Artist()
		{
		}
	}
}

