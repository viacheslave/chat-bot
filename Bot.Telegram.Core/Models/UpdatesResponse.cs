using Bot.Telegram.Entities;
using System.Collections.Generic;

namespace Bot.Telegram.Core.Models
{
	public class UpdatesResponse
	{
		public string Status { get; set; }
		public IEnumerable<Update> Result { get; set; }
	}
}
