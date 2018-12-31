using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Project1_5_Library;

namespace Consumer.Models
{
	public class EventCustomerView
	{
		public int Id { get; set; }

		[Required]
		public int CustomerId { get; set; }

		[Required]
		public int EventId { get; set; }
		[Required]
		public int EventName { get; set; }

		[Required]
		public bool Paid { get; set; }

		public virtual Customer Customer { get; set; }

		public virtual Event Event { get; set; }

		public List<Customer> CustomersList;

		public List<Event> EventsList;
	} 
}
