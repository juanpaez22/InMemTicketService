using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TicketDataService.Models;

namespace TicketDataService.Models
{
	
	public class Contact
	{
		public enum GenderEnum
		{
			Male = 0,
			Female = 1,
			Other = 2
		}

		[Key]
		public Guid ContactID { get; set; }
		public string name { get; set; }
		public int age { get; set; }

		public double annualrevenue { get; set; }

		public GenderEnum gender { get; set; }

	}
}