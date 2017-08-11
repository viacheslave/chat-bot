using System.Collections.Generic;

namespace Bot.Telegram.Core.Models
{
	public class UpdatesResponse
	{
		public string Status { get; set; }
		public IEnumerable<UpdateResultResponse> Result { get; set; }
	}
}
